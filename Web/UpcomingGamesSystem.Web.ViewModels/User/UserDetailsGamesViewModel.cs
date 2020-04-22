namespace UpcomingGamesSystem.Web.ViewModels.User
{
    using System;

    using UpcomingGamesSystem.Data.Models;
    using UpcomingGamesSystem.Services.Mapping;

    public class UserDetailsGamesViewModel : IMapFrom<Game>
    {
        public DateTime ReleaseDate { get; set; }

        public string Title { get; set; }

        public string PictureUrl { get; set; }
    }
}
