namespace UpcomingGamesSystem.Web.ViewModels.Games
{
    using System.Collections.Generic;

    public class HotGamesViewModel
    {
        public IEnumerable<HomePageGameViewModel> TopCommentsGames { get; set; }

        public IEnumerable<HomePageGameViewModel> TopFollowersGames { get; set; }
    }
}
