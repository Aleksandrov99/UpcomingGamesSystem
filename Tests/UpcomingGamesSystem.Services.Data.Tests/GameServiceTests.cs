namespace UpcomingGamesSystem.Services.Data.Tests
{
    using System;
    using System.Linq;

    using Microsoft.EntityFrameworkCore;
    using UpcomingGamesSystem.Data;
    using UpcomingGamesSystem.Data.Models;
    using UpcomingGamesSystem.Data.Repositories;
    using Xunit;

    public class GameServiceTests
    {
        [Fact]
        public void TestCreateAsync()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var repository = new EfDeletableEntityRepository<Game>(new ApplicationDbContext(options.Options));
            var commentsRepository = new EfDeletableEntityRepository<Comment>(new ApplicationDbContext(options.Options));

            var service = new GamesService(repository, commentsRepository);

            var game = new Game
            {
                Title = "test",
                CategoryId = 1,
                Description = "sds",
                ReleaseDate = DateTime.UtcNow,
                CompanyName = "tests",
                PictureUrl = "est",
            };

            service.CreateAsync(game.Title, game.PictureUrl, game.ReleaseDate, game.CompanyName, game.Description, game.CategoryId).GetAwaiter().GetResult();

            var counter = repository.All().CountAsync().GetAwaiter().GetResult();

            Assert.Equal(1, counter);
        }

        [Fact]
        public void TestGetAllGames()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var repository = new EfDeletableEntityRepository<Game>(new ApplicationDbContext(options.Options));
            var commentsRepository = new EfDeletableEntityRepository<Comment>(new ApplicationDbContext(options.Options));

            var service = new GamesService(repository, commentsRepository);

            var game = new Game
            {
                Title = "test",
                CategoryId = 1,
                Description = "sds",
                ReleaseDate = DateTime.UtcNow,
                CompanyName = "tests",
                PictureUrl = "est",
            };

            var game2 = new Game
            {
                Title = "tes2t",
                CategoryId = 1,
                Description = "sds",
                ReleaseDate = DateTime.UtcNow,
                CompanyName = "tests",
                PictureUrl = "est",
            };

            repository.AddAsync(game).GetAwaiter().GetResult();
            repository.AddAsync(game2).GetAwaiter().GetResult();
            repository.SaveChangesAsync();

            var games = service.GetAllGames();

            var counter = games.Games.Count();

            Assert.Equal(2, counter);
        }

        [Fact]
        public void TestDeleteGameAsync()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var repository = new EfDeletableEntityRepository<Game>(new ApplicationDbContext(options.Options));
            var commentsRepository = new EfDeletableEntityRepository<Comment>(new ApplicationDbContext(options.Options));

            var service = new GamesService(repository, commentsRepository);

            var game = new Game
            {
                Title = "test",
                CategoryId = 1,
                Description = "sds",
                ReleaseDate = DateTime.UtcNow,
                CompanyName = "tests",
                PictureUrl = "est",
            };

            repository.AddAsync(game).GetAwaiter().GetResult();
            repository.SaveChangesAsync().GetAwaiter().GetResult();

            var firstCounter = repository.All().Count();

            service.DeleteGameAsync(1).GetAwaiter().GetResult();

            var secondCounter = repository.All().Count();

            Assert.True(firstCounter == 1 && secondCounter == 0);
        }

        [Fact]
        public void TestUpdateGames()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var repository = new EfDeletableEntityRepository<Game>(new ApplicationDbContext(options.Options));
            var commentsRepository = new EfDeletableEntityRepository<Comment>(new ApplicationDbContext(options.Options));

            var service = new GamesService(repository, commentsRepository);

            var game = new Game
            {
                Title = "test",
                CategoryId = 1,
                Description = "sds",
                ReleaseDate = DateTime.UtcNow,
                CompanyName = "tests",
                PictureUrl = "est",
            };

            repository.AddAsync(game).GetAwaiter().GetResult();
            repository.SaveChangesAsync().GetAwaiter().GetResult();

            var firstCounter = repository.All().Count();

            service.UpdateGames().GetAwaiter().GetResult();

            var secondCounter = repository.All().Count();

            Assert.True(firstCounter == 1 && secondCounter == 0);
        }
    }
}
