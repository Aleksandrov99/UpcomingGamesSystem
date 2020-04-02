namespace UpcomingGamesSystem.Web.ViewModels.Games
{
    using UpcomingGamesSystem.Data.Models;
    using UpcomingGamesSystem.Services.Mapping;

    public class GamesDropDownModel : IMapFrom<Game>
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}
