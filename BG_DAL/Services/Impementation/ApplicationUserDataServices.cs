using BG_DAL.EFContext;
using BG_DAL.Entityes;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BG_DAL.Services.Impementation
{
   public class ApplicationUserDataServices : IApplicationUserDataServices
    {
        private ApplicationDbContext db;
        private UserManager<ApplicationUserData> _userManager;
        private SignInManager<ApplicationUserData> _signInManager;
        public ApplicationUserDataServices(ApplicationDbContext context, UserManager<ApplicationUserData> userManager, SignInManager<ApplicationUserData> signInManager)
        {
            db = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> Register(ApplicationUserData user, string pass)
        {
            //UserData userData = new UserData { Email = user.Email, UserName = user.Email };
            // добавляем пользователя

            return await _userManager.CreateAsync(user, pass);
            //await this.db.SaveChangesAsync();
        }

        public Task SignIn(ApplicationUserData user)
        {
            return _signInManager.SignInAsync(user, false);
        }

        public async Task<SignInResult> PasswordSignIn(string email, string pass, bool rememberMe)
        {
            var user = await _userManager.FindByNameAsync(email);
            return await _signInManager.PasswordSignInAsync(email, pass, rememberMe, false);
        }
    }
}