namespace UpcomingGamesSystem.Services.Data.Tests
{
    using System;
    using System.Linq;

    using Microsoft.EntityFrameworkCore;
    using UpcomingGamesSystem.Data;
    using UpcomingGamesSystem.Data.Models;
    using UpcomingGamesSystem.Data.Repositories;
    using UpcomingGamesSystem.Web.ViewModels.Comments;
    using Xunit;

    public class CommentServiceTests
    {
        [Fact]
        public void TestCreateAsync()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var repository = new EfDeletableEntityRepository<Comment>(new ApplicationDbContext(options.Options));
            var service = new CommentsServices(repository);

            var comment = new CommentsInputModel
            {
                GameId = 1,
                Content = "test",
                UserId = "2",
            };

            service.CreateAsync(comment).GetAwaiter().GetResult();

            var counter = repository.All().Count();

            Assert.Equal(1, counter);
        }

        [Fact]
        public void TestDeleteCommentAsync()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var repository = new EfDeletableEntityRepository<Comment>(new ApplicationDbContext(options.Options));
            var service = new CommentsServices(repository);

            var comment = new CommentsInputModel
            {
                GameId = 1,
                Content = "test",
                UserId = "2",
            };

            service.CreateAsync(comment).GetAwaiter().GetResult();

            var firstCounter = repository.All().Count();

            service.DeleteCommentAsync("test", "2", 1).GetAwaiter().GetResult();

            var secondCounter = repository.All().Count();

            Assert.True(firstCounter == 1 && secondCounter == 0);
        }
    }
}
