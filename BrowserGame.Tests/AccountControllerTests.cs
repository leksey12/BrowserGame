using BG_DAL.Entityes;
using BrowserGame.Controllers;
using BrowserGame.Services;
using BrowserGame.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrowserGame.Tests
{
    [TestFixture]
    public class AccountControllerTests
    {
        public class FakeUserManager : UserManager<ApplicationUserData>
        {
            public FakeUserManager()
                : base(new Mock<IUserStore<ApplicationUserData>>().Object,
                      new Mock<IOptions<IdentityOptions>>().Object,
                      new Mock<IPasswordHasher<ApplicationUserData>>().Object,
                      new IUserValidator<ApplicationUserData>[0],
                      new IPasswordValidator<ApplicationUserData>[0],
                      new Mock<ILookupNormalizer>().Object,
                      new Mock<IdentityErrorDescriber>().Object,
                      new Mock<IServiceProvider>().Object,
                      new Mock<ILogger<UserManager<ApplicationUserData>>>().Object)
            { }
        }

        public class FakeSignInManager : SignInManager<ApplicationUserData>
        {
            public FakeSignInManager()
                : base(new FakeUserManager(),
                new Mock<IHttpContextAccessor>().Object,
                new Mock<IUserClaimsPrincipalFactory<ApplicationUserData>>().Object,
                new Mock<IOptions<IdentityOptions>>().Object,
                new Mock<ILogger<SignInManager<ApplicationUserData>>>().Object,
                new Mock<IAuthenticationSchemeProvider>().Object)
            { }
        }

        AccountController controller;
        Mock<ILogger<AccountController>> log;
        Mock<IApplicationUserServices> user;
        Mock<FakeUserManager> _userManagerMock;
        Mock<FakeSignInManager> _signInManagerMock;
        RegisterViewModel registerModel;
        ApplicationUserData appuserData;

        [SetUp]
        public void Setup()
        {
            // Arrange
            log = new Mock<ILogger<AccountController>>();
            user = new Mock<IApplicationUserServices>();
            _userManagerMock = new Mock<FakeUserManager>();
            _signInManagerMock = new Mock<FakeSignInManager>();

            registerModel = new RegisterViewModel
            {
                Email = "SomeEmail",
                Password = "SomePassword"
            };

            appuserData = new ApplicationUserData
            {
                Id = "1"
            };

            controller = new AccountController(_userManagerMock.Object, _signInManagerMock.Object);
        }
    }
}