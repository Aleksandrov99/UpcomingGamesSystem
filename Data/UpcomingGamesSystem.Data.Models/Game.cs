namespace UpcomingGamesSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using UpcomingGamesSystem.Data.Common.Models;

    public class Game : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string CompanyName { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
