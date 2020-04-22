namespace UpcomingGamesSystem.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using UpcomingGamesSystem.Data.Models;
    using UpcomingGamesSystem.Services.Data;
    using UpcomingGamesSystem.Web.ViewModels.User;

    public class UserController : Controller
    {
        private readonly IUserServices userServices;
        private readonly UserManager<ApplicationUser> userManager;

        public UserController(IUserServices userServices, UserManager<ApplicationUser> userManager)
        {
            this.userServices = userServices;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Details()
        {
            var userId = this.userManager.GetUserId(this.User);

            var viewModel = this.userServices.AllFollowedGamesForUser(userId);

            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult AddFollower()
        {
            return this.Redirect("/");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddFollower(UserFollowerViewModel input)
        {
            await this.userServices.AddUserToFollower(input);

            return this.Redirect("/User/Details");
        }
    }
}
