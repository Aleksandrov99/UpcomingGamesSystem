namespace UpcomingGamesSystem.Services.Data
{
    using System.Threading.Tasks;

    public interface IAdminsServices
    {
        Task<bool> AddToRoleAsync(string userName);
    }
}
