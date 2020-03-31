namespace UpcomingGamesSystem.Services.Data
{
    using System.Threading.Tasks;

    public interface ICategoriesService
    {
        Task Create(string categoryName);
    }
}
