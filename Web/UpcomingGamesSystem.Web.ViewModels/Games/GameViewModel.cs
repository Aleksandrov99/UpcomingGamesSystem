namespace UpcomingGamesSystem.Web.ViewModels.Games
{
    using System;
    using System.Collections.Generic;

    using UpcomingGamesSystem.Data.Models;
    using UpcomingGamesSystem.Services.Mapping;
    using UpcomingGamesSystem.Web.ViewModels.Comments;

    public class GameViewModel : IMapFrom<Game>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string PictureUrl { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string CompanyName { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
