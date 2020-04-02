namespace UpcomingGamesSystem.Web.ViewModels.Games
{
    using System;

    using UpcomingGamesSystem.Data.Models;
    using UpcomingGamesSystem.Services.Mapping;

    public class HomePageGameViewModel : IMapFrom<Game>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string PictureUrl { get; set; }
    }
}
