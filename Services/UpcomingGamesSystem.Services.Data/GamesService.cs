namespace UpcomingGamesSystem.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using UpcomingGamesSystem.Data.Common.Repositories;
    using UpcomingGamesSystem.Data.Models;
    using UpcomingGamesSystem.Web.ViewModels.Comments;
    using UpcomingGamesSystem.Web.ViewModels.Games;

    public class GamesService : IGamesService
    {
        private readonly IDeletableEntityRepository<Game> gamesRepository;
        private readonly IDeletableEntityRepository<Comment> commentsRepository;

        public GamesService(IDeletableEntityRepository<Game> gamesRepository, IDeletableEntityRepository<Comment> commentsRepository)
        {
            this.gamesRepository = gamesRepository;
            this.commentsRepository = commentsRepository;
        }

        public async Task CreateAsync(string title, string pictureUrl, DateTime releaseDate, string companyName, string description, int category)
        {
            var game = new Game
            {
                Title = title,
                PictureUrl = pictureUrl,
                ReleaseDate = releaseDate,
                CompanyName = companyName,
                Description = description,
                CategoryId = category,
            };

            await this.gamesRepository.AddAsync(game);
            await this.gamesRepository.SaveChangesAsync();
        }

        public async Task DeleteGameAsync(int gameId)
        {
            var game = this.gamesRepository.All()
                .Where(x => x.Id == gameId)
                .FirstOrDefault();

            this.gamesRepository.Delete(game);
            await this.gamesRepository.SaveChangesAsync();
        }

        public AllGamesViewModel GetAllGames()
        {
            var games = this.gamesRepository.All()
                .Select(x => new HomePageGameViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    PictureUrl = x.PictureUrl,
                    ReleaseDate = x.ReleaseDate,
                }).OrderBy(x => x.ReleaseDate)
                .ToList();

            var allGames = new AllGamesViewModel
            {
                Games = games,
            };

            return allGames;
        }

        public GameViewModel GetGameById(int id)
        {
            var comments = this.commentsRepository.All()
                .Where(x => x.GameId == id)
                .Select(x => new CommentViewModel
                {
                    CreatedOn = x.CreatedOn,
                    UserId = x.UserId,
                    Content = x.Content,
                })
                .OrderByDescending(x => x.CreatedOn)
                .ToList();

            var game = this.gamesRepository.All()
                .Where(x => x.Id == id)
                .Select(x => new GameViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    PictureUrl = x.PictureUrl,
                    ReleaseDate = x.ReleaseDate,
                    CompanyName = x.CompanyName,
                    Description = x.Description,
                    CategoryName = x.Category.Name,
                    Comments = comments,
                }).FirstOrDefault();

            return game;
        }

        public HotGamesViewModel TopGames()
        {
            var gamesFollowers = this.gamesRepository.All()
                .OrderByDescending(x => x.Followers.Count())
                .Take(5)
                .Select(x => new HomePageGameViewModel
                {
                    Id = x.Id,
                    PictureUrl = x.PictureUrl,
                    ReleaseDate = x.ReleaseDate,
                    Title = x.Title,
                })
                .ToList();

            var gamesComments = this.gamesRepository.All()
                .OrderByDescending(x => x.Comments.Count())
                .Take(5)
                .Select(x => new HomePageGameViewModel
                {
                    Id = x.Id,
                    PictureUrl = x.PictureUrl,
                    ReleaseDate = x.ReleaseDate,
                    Title = x.Title,
                })
                .ToList();

            var allGames = new HotGamesViewModel
            {
                TopCommentsGames = gamesComments,
                TopFollowersGames = gamesFollowers,
            };

            return allGames;
        }

        public async Task UpdateGames()
        {
            var allGames = this.gamesRepository.All().ToList();

            var date = DateTime.UtcNow;

            foreach (var game in allGames)
            {
                if (game.ReleaseDate <= date)
                {
                    var gameUpdate = this.gamesRepository.All()
                        .Where(x => x.Id == game.Id)
                        .FirstOrDefault();

                    this.gamesRepository.Delete(gameUpdate);
                    await this.gamesRepository.SaveChangesAsync();
                }
            }
        }
    }
}
