﻿namespace UpcomingGamesSystem.Web.Controllers
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

        public IActionResult All()
        {
            var games = this.gamesService.GetAllGames();

            return this.View(games);
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

            return this.Redirect("/Games/All");
        }

        public IActionResult ById(int id)
        {
            var gameViewModel = this.gamesService.GetGameById(id);

            if (gameViewModel == null)
            {
                return this.Redirect("/Games/All");
            }

            return this.View(gameViewModel);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult DeleteGame()
        {
            return this.Redirect("/Games/All");
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteGame(int gameId)
        {
            await this.gamesService.DeleteGameAsync(gameId);

            return this.Redirect("/Games/All");
        }
    }
}
