namespace UpcomingGamesSystem.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoriesService
    {
        Task Create(string categoryName);

        IEnumerable<T> GetAllCategories<T>();
    }
}
