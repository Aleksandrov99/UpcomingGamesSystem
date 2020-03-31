namespace UpcomingGamesSystem.Web.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    using UpcomingGamesSystem.Data.Models;
    using UpcomingGamesSystem.Services.Mapping;

    public class CategoriesCreateInputModel : IMapTo<Category>
    {
        [Required]
        [MaxLength(10)]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
    }
}
