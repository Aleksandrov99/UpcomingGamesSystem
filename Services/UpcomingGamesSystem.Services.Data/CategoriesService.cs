namespace UpcomingGamesSystem.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using UpcomingGamesSystem.Data.Common.Repositories;
    using UpcomingGamesSystem.Data.Models;
    using UpcomingGamesSystem.Services.Mapping;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoryRepository;

        public CategoriesService(IDeletableEntityRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task Create(string categoryName)
        {
            var category = new Category
            {
                Name = categoryName,
            };

            await this.categoryRepository.AddAsync(category);
            await this.categoryRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllCategories<T>()
        {
            var categories = this.categoryRepository.All().OrderBy(x => x.Name);

            return categories.To<T>().ToList();
        }
    }
}
