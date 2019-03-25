using BG_BLL.Services;
using BG_DAL.Entityes;
using BrowserGame.Models;
using BrowserGame.Services;
using Mapster;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BG_BLL.Imlementations
{
    public class ApplicationUserServices: IApplicationUserServices
    {
        private readonly IApplicationUserBusinessServices userServices;

        public ApplicationUserServices(IApplicationUserBusinessServices userServices)
        {
            this.userServices = userServices;
        }

        public async Task<IdentityResult> Register(ApplicationUser user, string pass)
        {
            var userData = user.Adapt<ApplicationUserBusiness>();
            return await userServices.Register(userData, pass);
        }

        public Task SignIn(ApplicationUser user)
        {
            var userData = user.Adapt<ApplicationUserBusiness>();
            return userServices.SignIn(userData);
        }

        public async Task<SignInResult> PasswordSignIn(string email, string pass, bool rememberMe)
        {
            return await userServices.PasswordSignIn(email, pass, rememberMe);
        }
    }
}
