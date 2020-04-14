namespace UpcomingGamesSystem.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using UpcomingGamesSystem.Common;
    using UpcomingGamesSystem.Data.Common.Repositories;
    using UpcomingGamesSystem.Data.Models;

    public class AdminsServices : IAdminsServices
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;

        public AdminsServices(UserManager<ApplicationUser> userManager, IDeletableEntityRepository<ApplicationUser> userRepository)
        {
            this.userManager = userManager;
            this.userRepository = userRepository;
        }

        public async Task<bool> AddToRoleAsync(string userName)
        {
            var user = this.userRepository.All()
                .Where(x => x.UserName == userName)
                .FirstOrDefault();

            if (user == null)
            {
                return false;
            }

            await this.userManager.AddToRoleAsync(user, GlobalConstants.AdministratorRoleName);

            return true;
        }
    }
}
