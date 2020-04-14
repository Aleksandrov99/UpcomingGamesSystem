namespace UpcomingGamesSystem.Web.ViewModels.Games
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using UpcomingGamesSystem.Web.ViewModels.Categories;

    public class AllGamesViewModel
    {
        public virtual IEnumerable<HomePageGameViewModel> Games { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<CategoriesDropDownModel> Categories { get; set; }
    }
}
