namespace UpcomingGamesSystem.Web.ViewModels.Comments
{
    using System;

    using UpcomingGamesSystem.Data.Models;
    using UpcomingGamesSystem.Services.Mapping;

    public class CommentViewModel : IMapFrom<Comment>
    {
        public DateTime CreatedOn { get; set; }

        public string UserId { get; set; }

        public string Content { get; set; }
    }
}
