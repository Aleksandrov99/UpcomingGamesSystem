namespace UpcomingGamesSystem.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using UpcomingGamesSystem.Common;
    using UpcomingGamesSystem.Data.Common.Repositories;
    using UpcomingGamesSystem.Data.Models;
    using UpcomingGamesSystem.Web.ViewModels.Administration;

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
            var user = this.GetUser(userName);

            if (user == null)
            {
                return false;
            }

            await this.userManager.AddToRoleAsync(user, GlobalConstants.AdministratorRoleName);

            return true;
        }

        public async Task<bool> RemoveFromRoleAsync(string userName)
        {
            var user = this.GetUser(userName);

            if (user == null)
            {
                return false;
            }

            await this.userManager.RemoveFromRoleAsync(user, GlobalConstants.AdministratorRoleName);

            return true;
        }

        public AllAdminsViewModel GetAllAdmins()
        {
            var admin = this.userManager.Users.Where(x => x.Roles.Count() > 0)
                .Select(x => new AdminInputModel
                {
                    UserName = x.UserName,
                }).ToList();

            var admins = new AllAdminsViewModel
            {
                Admins = admin,
            };

            return admins;
        }

        private ApplicationUser GetUser(string userName)
        {
            var user = this.userRepository.All()
                .Where(x => x.UserName == userName)
                .FirstOrDefault();

            return user;
        }
    }
}
