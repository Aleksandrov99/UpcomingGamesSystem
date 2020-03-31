namespace UpcomingGamesSystem.Web.ViewModels.Categories
{
    using UpcomingGamesSystem.Data.Models;
    using UpcomingGamesSystem.Services.Mapping;

    public class CategoriesDropDownModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
