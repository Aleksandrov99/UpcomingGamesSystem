namespace UpcomingGamesSystem.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using UpcomingGamesSystem.Data.Common.Repositories;
    using UpcomingGamesSystem.Data.Models;
    using UpcomingGamesSystem.Web.ViewModels.User;

    public class UserServices : IUserServices
    {
        private readonly IDeletableEntityRepository<Follower> followerRepository;

        public UserServices(IDeletableEntityRepository<Follower> followerRepository)
        {
            this.followerRepository = followerRepository;
        }

        public async Task AddUserToFollower(UserFollowerViewModel input)
        {
            var follower = new Follower
            {
                UserId = input.UserId,
                GameId = input.GameId,
            };

            var check = this.followerRepository.All().Where(x => x.GameId == input.GameId && x.UserId == input.UserId).FirstOrDefault();

            if (check == null)
            {
                await this.followerRepository.AddAsync(follower);
                await this.followerRepository.SaveChangesAsync();
            }
        }

        public AllFollowedGamesViewModel AllFollowedGamesForUser(string userId)
        {
            var games = this.followerRepository.All().Where(x => x.UserId == userId)
                .Select(x => new UserDetailsGamesViewModel
                {
                    Title = x.Game.Title,
                    ReleaseDate = x.Game.ReleaseDate,
                    PictureUrl = x.Game.PictureUrl,
                })
                .OrderBy(x => x.ReleaseDate)
                .ToList();

            var allGames = new AllFollowedGamesViewModel
            {
                AllGames = games,
            };

            return allGames;
        }
    }
}
