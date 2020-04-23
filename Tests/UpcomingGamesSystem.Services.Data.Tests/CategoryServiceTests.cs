namespace UpcomingGamesSystem.Services.Data.Tests
{
    using System;
    using System.Linq;

    using Microsoft.EntityFrameworkCore;
    using UpcomingGamesSystem.Data;
    using UpcomingGamesSystem.Data.Models;
    using UpcomingGamesSystem.Data.Repositories;
    using Xunit;

    public class CategoryServiceTests
    {
        [Fact]
        public void TestCreateAsync()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var repository = new EfDeletableEntityRepository<Category>(new ApplicationDbContext(options.Options));
            var service = new CategoriesService(repository);

            service.CreateAsync("test").GetAwaiter().GetResult();

            var counter = repository.All().Count();

            Assert.Equal(1, counter);
        }
    }
}
