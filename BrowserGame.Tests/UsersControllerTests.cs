﻿using BG_DAL.Entityes;
using BrowserGame.Controllers;
using BrowserGame.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BrowserGame.Tests.AccountControllerTests;

namespace BrowserGame.Tests
{
    [TestFixture]
    public class UsersControllerTests
    {
        UsersController controller;
        Mock<FakeUserManager> _userManagerMock;
        ApplicationUserData appuserData;
        ChangePasswordViewModel changePasswordModel;

        [SetUp]
        public void Setup()
        {
            // Arrange
            appuserData = new ApplicationUserData
            {
                Id = "1"
            };
            changePasswordModel = new ChangePasswordViewModel
            {
                Id = "id",
                Email = "Email",
                OldPassword = "OldPassword",
                NewPassword = "NewPassword"
            };

            _userManagerMock = new Mock<FakeUserManager>();

            controller = new UsersController(_userManagerMock.Object);
        }

        [Test]
        public async Task Edit_RedirectToIndex()
        {
            // Arrange
            EditUserViewModel model = new EditUserViewModel { Id = "id" };

            _userManagerMock.Setup(m => m.FindByIdAsync(model.Id)).ReturnsAsync(appuserData);
            _userManagerMock.Setup(m => m.UpdateAsync(appuserData)).ReturnsAsync(IdentityResult.Success);

            UsersController contr = new UsersController(_userManagerMock.Object);

            // Act
            var result = await contr.Edit(model);

            // Assert
            Assert.AreEqual("Index", (result as RedirectToActionResult).ActionName);
        }

        [Test]
        public async Task Delete_RedirectToActionResult()
        {
            // Arrange
            _userManagerMock.Setup(m => m.FindByIdAsync("id")).ReturnsAsync(appuserData);

            UsersController contr = new UsersController(_userManagerMock.Object);

            // Act
            var result = await contr.Delete("id");

            // Assert
            _userManagerMock.Verify(m => m.DeleteAsync(appuserData));
            Assert.AreEqual("Index", (result as RedirectToActionResult).ActionName);
        }

        [Test]
        public async Task ChangePassword_ValidModel_RedirectToActionResult()
        {
            // Arrange
            _userManagerMock.Setup(m => m.FindByIdAsync(changePasswordModel.Id)).ReturnsAsync(appuserData);
            _userManagerMock.Setup(m => m.ChangePasswordAsync(appuserData, changePasswordModel.OldPassword, changePasswordModel.NewPassword))
                .ReturnsAsync(IdentityResult.Success);

            UsersController contr = new UsersController(_userManagerMock.Object);

            // Act
            var result = await contr.ChangePassword(changePasswordModel);

            // Assert
            Assert.AreEqual("Index", (result as RedirectToActionResult).ActionName);
        }

        [Test]
        public async Task ChangePassword_UserNotFound_ReturnError()
        {
            // Arrange

            // Act
            var result = await controller.ChangePassword(changePasswordModel);

            // Assert
            Assert.That(result, Is.TypeOf<ViewResult>());
            Assert.AreEqual(controller.ModelState
                .Values
                .First()
                .Errors[0]
                .ErrorMessage, "Пользователь не найден");
        }
    }
}