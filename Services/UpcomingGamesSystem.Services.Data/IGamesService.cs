namespace UpcomingGamesSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using UpcomingGamesSystem.Web.ViewModels.Games;

    public interface IGamesService
    {
        Task CreateAsync(string title, string pictureUrl, DateTime releaseDate, string companyName, string description, int category);

        GameViewModel GetGameById(int id);

        AllGamesViewModel GetAllGames();

        Task DeleteGameAsync(int gameId);

        AllGamesViewModel GetTop5GamesByFollow();

        AllGamesViewModel GetTop5GamesByComments();

        Task UpdateGames();
    }
}
