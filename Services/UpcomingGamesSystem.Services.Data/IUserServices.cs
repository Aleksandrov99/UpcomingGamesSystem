namespace UpcomingGamesSystem.Services.Data
{
    using System.Threading.Tasks;

    using UpcomingGamesSystem.Web.ViewModels.User;

    public interface IUserServices
    {
        Task AddUserToFollower(UserFollowerViewModel input);
    }
}
