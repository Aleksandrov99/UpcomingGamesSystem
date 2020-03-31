namespace UpcomingGamesSystem.Web.ViewModels.Games
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using UpcomingGamesSystem.Data.Models;
    using UpcomingGamesSystem.Services.Mapping;
    using UpcomingGamesSystem.Web.ViewModels.Categories;

    public class GamesCreateInputModel : IMapTo<Game>
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [Display(Name ="Picture")]
        public string PictureUrl { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<CategoriesDropDownModel> Categories { get; set; }
    }
}
