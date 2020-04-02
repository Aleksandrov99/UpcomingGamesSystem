namespace UpcomingGamesSystem.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using UpcomingGamesSystem.Services.Data;
    using UpcomingGamesSystem.Web.ViewModels.Categories;
    using UpcomingGamesSystem.Web.ViewModels.Games;

    public class GamesController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IGamesService gamesService;

        public GamesController(ICategoriesService categoriesService, IGamesService gamesService)
        {
            this.categoriesService = categoriesService;
            this.gamesService = gamesService;
        }

        [Authorize]
        public IActionResult Create()
        {
            var categories = this.categoriesService.GetAllCategories<CategoriesDropDownModel>();
            var viewModel = new GamesCreateInputModel
            {
                Categories = categories,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(GamesCreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.gamesService.CreateAsync(input.Title, input.PictureUrl, input.ReleaseDate, input.CompanyName, input.Description, input.CategoryId);

            return this.Redirect("/Home/Index");
        }

        public IActionResult ById(int id)
        {
            var gameViewModel = this.gamesService.GetGameById(id);

            if (gameViewModel == null)
            {
                return this.Redirect("/");
            }

            return this.View(gameViewModel);
        }
    }
}
