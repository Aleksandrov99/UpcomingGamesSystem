namespace UpcomingGamesSystem.Web.ViewModels.User
{
    using UpcomingGamesSystem.Data.Models;
    using UpcomingGamesSystem.Services.Mapping;

    public class UserFollowerViewModel : IMapFrom<Follower>
    {
        public string UserId { get; set; }

        public int GameId { get; set; }
    }
}
