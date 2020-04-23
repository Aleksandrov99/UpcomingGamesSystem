namespace UpcomingGamesSystem.Services.Data
{
    using System.Threading.Tasks;

    using UpcomingGamesSystem.Web.ViewModels.Administration;

    public interface IAdminsServices
    {
        Task<bool> AddToRoleAsync(string userName);

        Task<bool> RemoveFromRoleAsync(string userName);

        AllAdminsViewModel GetAllAdmins();
    }
}
