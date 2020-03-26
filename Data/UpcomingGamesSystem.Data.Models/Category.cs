namespace UpcomingGamesSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using UpcomingGamesSystem.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Games = new HashSet<Game>();
        }

        [Required]
        [MaxLength(10)]
        public string Name { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
