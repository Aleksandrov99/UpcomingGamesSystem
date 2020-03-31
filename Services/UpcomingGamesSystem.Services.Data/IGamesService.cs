namespace UpcomingGamesSystem.Services.Data
{
    using System;
    using System.Threading.Tasks;

    public interface IGamesService
    {
        Task Create(string title, string pictureUrl, DateTime releaseDate, string companyName, string description, int category);
    }
}
