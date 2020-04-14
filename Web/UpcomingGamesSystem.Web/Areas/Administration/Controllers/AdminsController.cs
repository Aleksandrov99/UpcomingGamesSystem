namespace UpcomingGamesSystem.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using UpcomingGamesSystem.Services.Data;
    using UpcomingGamesSystem.Web.ViewModels.Administration;

    public class AdminsController : AdministrationController
    {
        private readonly IAdminsServices adminsServices;

        public AdminsController(IAdminsServices adminsServices)
        {
            this.adminsServices = adminsServices;
        }

        public IActionResult AssignRole()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(AdminInputModel input)
        {
            if ((await this.adminsServices.AddToRoleAsync(input.UserName)) == false)
            {
                return this.View(input);
            }

            return this.Redirect("/");
        }
    }
}
