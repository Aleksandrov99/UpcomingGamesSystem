namespace UpcomingGamesSystem.Web.ViewModels.User
{
    using System.Collections.Generic;

    public class AllFollowedGamesViewModel
    {
        public IEnumerable<UserDetailsGamesViewModel> AllGames { get; set; }
    }
}
