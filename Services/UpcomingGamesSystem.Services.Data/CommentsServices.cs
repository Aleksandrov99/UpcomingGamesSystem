namespace UpcomingGamesSystem.Services.Data
{
    using System.Threading.Tasks;

    using UpcomingGamesSystem.Data.Common.Repositories;
    using UpcomingGamesSystem.Data.Models;
    using UpcomingGamesSystem.Web.ViewModels.Comments;

    public class CommentsServices : ICommentsServices
    {
        private readonly IDeletableEntityRepository<Comment> commentsRepository;

        public CommentsServices(IDeletableEntityRepository<Comment> commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        public async Task CreateAsync(CommentsInputModel input)
        {
            var comment = new Comment
            {
                GameId = input.GameId,
                Content = input.Content,
                UserId = input.UserId,
            };

            await this.commentsRepository.AddAsync(comment);
            await this.commentsRepository.SaveChangesAsync();
        }
    }
}
