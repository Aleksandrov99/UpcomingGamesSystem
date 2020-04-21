namespace UpcomingGamesSystem.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using UpcomingGamesSystem.Web.ViewModels.Comments;

    public interface ICommentsServices
    {
        Task CreateAsync(CommentsInputModel input);

        Task DeleteCommentAsync(string commentContent, string userId, int gameId);
    }
}
