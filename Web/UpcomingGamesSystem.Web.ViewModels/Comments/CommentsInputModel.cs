namespace UpcomingGamesSystem.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;

    using UpcomingGamesSystem.Data.Models;
    using UpcomingGamesSystem.Services.Mapping;

    public class CommentsInputModel : IMapTo<Comment>
    {
        public int GameId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Content { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
