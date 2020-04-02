namespace UpcomingGamesSystem.Web.ViewModels.Games
{
    using System.Collections.Generic;

    public class AllGamesViewModel
    {
        public virtual IEnumerable<HomePageGameViewModel> Games { get; set; }
    }
}
