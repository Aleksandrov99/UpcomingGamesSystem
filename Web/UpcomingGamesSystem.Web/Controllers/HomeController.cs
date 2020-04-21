namespace UpcomingGamesSystem.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using UpcomingGamesSystem.Services.Data;
    using UpcomingGamesSystem.Web.ViewModels;

    public class HomeController : BaseController
    {
        private readonly IGamesService gamesService;

        public HomeController(IGamesService gamesService)
        {
            this.gamesService = gamesService;
        }

        public async Task<IActionResult> Index()
        {
            await this.gamesService.UpdateGames();

            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
