using BG_DAL.EFContext;
using BG_DAL.Entityes;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BG_DAL.Services
{
   public interface IApplicationUserDataServices
    {
     /// <summary>
     /// Регистрация пользователя
     /// </summary>
     /// <param name="user">Пользователь</param>
     /// <param name="pass">Пароль</param>
        Task<IdentityResult> Register(ApplicationUserData user, string pass);

        /// <summary>
        /// Вход на сайт при регистрации
        /// </summary>
        /// <param name="user">Пользователь</param>
        Task SignIn(ApplicationUserData user);

        /// <summary>
        /// Вход на сайт по паролю
        /// </summary>
        /// <param name="email">Email</param>
        /// <param name="pass">Пароль</param>
        /// <param name="rememberMe">Флаг запоминания на сайте</param>
        Task<SignInResult> PasswordSignIn(string email, string pass, bool rememberMe);
    }
}