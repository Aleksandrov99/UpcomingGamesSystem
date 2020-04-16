namespace UpcomingGamesSystem.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using UpcomingGamesSystem.Services.Data;
    using UpcomingGamesSystem.Web.ViewModels.User;

    public class UserController : Controller
    {
        private readonly IUserServices userServices;

        public UserController(IUserServices userServices)
        {
            this.userServices = userServices;
        }

        [Authorize]
        public IActionResult Details()
        {
            return this.View();
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
