using BG_BLL.Services;
using BG_DAL.Entityes;
using BG_DAL.Services;
using Mapster;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BG_BLL.Imlementations
{
    public class ApplicationUserBusinessServices: IApplicationUserBusinessServices
    {
        private readonly IApplicationUserDataServices userServices;

        public ApplicationUserBusinessServices(IApplicationUserDataServices userServices)
        {
            this.userServices = userServices;
        }

        public async Task<IdentityResult> Register(ApplicationUserBusiness user, string pass)
        {
            var userData = user.Adapt<ApplicationUserData>();
            return await userServices.Register(userData, pass);
        }

        public Task SignIn(ApplicationUserBusiness user)
        {
            var userData = user.Adapt<ApplicationUserData>();
            return userServices.SignIn(userData);
        }

        public async Task<SignInResult> PasswordSignIn(string email, string pass, bool rememberMe)
        {
            return await userServices.PasswordSignIn(email, pass, rememberMe);
        }
    }
}
