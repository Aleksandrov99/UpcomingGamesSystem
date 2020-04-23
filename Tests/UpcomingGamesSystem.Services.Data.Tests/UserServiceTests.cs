namespace UpcomingGamesSystem.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using UpcomingGamesSystem.Data;
    using UpcomingGamesSystem.Data.Models;
    using UpcomingGamesSystem.Data.Repositories;
    using UpcomingGamesSystem.Web.ViewModels.User;
    using Xunit;

    public class UserServiceTests
    {
        [Fact]
        public async Task TestAddUserToFollower()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var repository = new EfDeletableEntityRepository<Follower>(new ApplicationDbContext(options.Options));
            var service = new UserServices(repository);

            var model = new UserFollowerViewModel
            {
                GameId = 5,
                UserId = "4",
            };

            for (int i = 0; i < 2; i++)
            {
                await service.AddUserToFollower(model);
            }

            var counter = await repository.All().CountAsync();

            Assert.Equal(1, counter);
        }

        [Fact]
        public void TestAllFollowedGamesForUser()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var repository = new EfDeletableEntityRepository<Follower>(new ApplicationDbContext(options.Options));
            var gameRepository = new EfDeletableEntityRepository<Game>(new ApplicationDbContext(options.Options));
            var service = new UserServices(repository);

            var firstGame = new Game
            {
                CategoryId = 1,
                Description = "asd",
                Title = "test",
                ReleaseDate = DateTime.UtcNow,
                PictureUrl = "empty",
            };

            var secondGame = new Game
            {
                CategoryId = 2,
                Description = "asdd",
                Title = "test2",
                ReleaseDate = DateTime.UtcNow,
                PictureUrl = "empty",
            };

            gameRepository.AddAsync(firstGame).GetAwaiter().GetResult();
            gameRepository.SaveChangesAsync().GetAwaiter().GetResult();

            gameRepository.AddAsync(secondGame).GetAwaiter().GetResult();
            gameRepository.SaveChangesAsync().GetAwaiter().GetResult();

            var firstModel = new Follower
            {
                GameId = 1,
                UserId = "4",
            };

            var secondModel = new Follower
            {
                GameId = 2,
                UserId = "4",
            };

            var thirdModel = new Follower
            {
                GameId = 1,
                UserId = "2",
            };

            var models = new List<Follower>()
            {
                firstModel, secondModel, thirdModel,
            };

            foreach (var model in models)
            {
                repository.AddAsync(model).GetAwaiter().GetResult();
                repository.SaveChangesAsync().GetAwaiter().GetResult();
            }

            var userId = "4";

            var elements = service.AllFollowedGamesForUser(userId);
            var counter = elements.AllGames.Count();

            Assert.Equal(2, counter);
        }
    }
}
