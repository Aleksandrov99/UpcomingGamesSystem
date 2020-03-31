namespace UpcomingGamesSystem.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using UpcomingGamesSystem.Data.Models;
    using UpcomingGamesSystem.Services.Data;
    using UpcomingGamesSystem.Services.Mapping;
    using UpcomingGamesSystem.Web.ViewModels.Categories;

    public class CategoriesController : Controller
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CategoriesCreateInputModel input)
        {
            var category = AutoMapperConfig.MapperInstance.Map<Category>(input);
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.categoriesService.Create(input.Name);

            return this.Redirect("/Home/Index");
        }
    }
}
