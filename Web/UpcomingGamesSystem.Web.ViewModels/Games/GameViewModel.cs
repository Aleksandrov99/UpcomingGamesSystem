﻿namespace UpcomingGamesSystem.Web.ViewModels.Games
{
    using System;

    using UpcomingGamesSystem.Data.Models;
    using UpcomingGamesSystem.Services.Mapping;

    public class GameViewModel : IMapFrom<Game>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string PictureUrl { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string CompanyName { get; set; }

        public string Description { get; set; }
    }
}