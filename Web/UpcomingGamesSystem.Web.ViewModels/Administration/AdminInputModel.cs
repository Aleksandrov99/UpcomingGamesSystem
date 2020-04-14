namespace UpcomingGamesSystem.Web.ViewModels.Administration
{
    using System.ComponentModel.DataAnnotations;

    using UpcomingGamesSystem.Data.Models;
    using UpcomingGamesSystem.Services.Mapping;

    public class AdminInputModel : IMapFrom<ApplicationUser>
    {
        [Display(Name = "Name of the user:")]
        public string UserName { get; set; }
    }
}
