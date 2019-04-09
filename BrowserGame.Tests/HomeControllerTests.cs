using BrowserGame.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrowserGame.Tests
{
    [TestFixture]
    public class HomeControllerTests
    {
        HomeController controller;
        Mock<ILogger<HomeController>> log;

        [SetUp]
        public void Setup()
        {
            // Arrange
            log = new Mock<ILogger<HomeController>>();
            controller = new HomeController(log.Object);
        }
        [Test]
        public void Index_ReturnView()
        {
            // Arrange

            // Act
            var result = controller.Index();

            // Assert
            Assert.That(result, Is.TypeOf<ViewResult>());
            Assert.NotNull(result as ViewResult);
            Assert.AreEqual("Index", (result as ViewResult).ViewName);
        }

    }
}