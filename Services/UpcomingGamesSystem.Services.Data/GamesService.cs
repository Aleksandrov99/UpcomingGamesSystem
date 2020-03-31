namespace UpcomingGamesSystem.Services.Data
{
    using System;
    using System.Threading.Tasks;
    using UpcomingGamesSystem.Data.Common.Repositories;
    using UpcomingGamesSystem.Data.Models;

    public class GamesService : IGamesService
    {
        private readonly IDeletableEntityRepository<Game> gamesRepository;

        public GamesService(IDeletableEntityRepository<Game> gamesRepository)
        {
            this.gamesRepository = gamesRepository;
        }

        public async Task Create(string title, string pictureUrl, DateTime releaseDate, string companyName, string description, int category)
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
    }
}
