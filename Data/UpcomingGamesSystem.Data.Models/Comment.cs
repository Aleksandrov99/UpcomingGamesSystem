namespace UpcomingGamesSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using UpcomingGamesSystem.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        public int GameId { get; set; }

        public virtual Game Game { get; set; }

        [Required]
        [MaxLength(100)]
        public string Content { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
