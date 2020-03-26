namespace UpcomingGamesSystem.Web.Areas.Administration.Controllers
{
    using UpcomingGamesSystem.Common;
    using UpcomingGamesSystem.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
