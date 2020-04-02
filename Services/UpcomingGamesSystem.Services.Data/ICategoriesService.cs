namespace UpcomingGamesSystem.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoriesService
    {
        Task CreateAsync(string categoryName);

        IEnumerable<T> GetAllCategories<T>();
    }
}
