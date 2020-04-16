namespace UpcomingGamesSystem.Services.Data
{
    using System.Threading.Tasks;

    using UpcomingGamesSystem.Web.ViewModels.Comments;

    public interface ICommentsServices
    {
        Task CreateAsync(CommentsInputModel input);
    }
}
