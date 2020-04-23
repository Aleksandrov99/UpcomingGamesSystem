namespace UpcomingGamesSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ErrorController : Controller
    {
        [Route("{*url}", Order = 999)]
        public IActionResult Error404()
        {
            this.Response.StatusCode = 404;

            return this.View();
        }
    }
}
