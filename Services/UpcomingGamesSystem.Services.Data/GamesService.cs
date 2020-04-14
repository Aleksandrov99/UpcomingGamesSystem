namespace UpcomingGamesSystem.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using UpcomingGamesSystem.Data.Common.Repositories;
    using UpcomingGamesSystem.Data.Models;
    using UpcomingGamesSystem.Web.ViewModels.Games;

    public class GamesService : IGamesService
    {
        private readonly IDeletableEntityRepository<Game> gamesRepository;

        public GamesService(IDeletableEntityRepository<Game> gamesRepository)
        {
            this.gamesRepository = gamesRepository;
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
                }).FirstOrDefault();

            return game;
        }
    }
}
