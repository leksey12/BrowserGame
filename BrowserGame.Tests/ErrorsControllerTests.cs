using BrowserGame.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrowserGame.Tests
{
    [TestFixture]
   public class ErrorsControllerTests
    {
        ErrorsController controller;
       

        [SetUp]
        public void Setup()
        {
            // Arrange
            controller = new ErrorsController();
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
            Assert.AreEqual("Error", (result as ViewResult).ViewName);
        }
        [Test]
        public void Error404_ReturnView()
        {
            // Arrange

            // Act
            var result = controller.Error(404);

            // Assert
            Assert.That(result, Is.TypeOf<ViewResult>());
            Assert.AreEqual("Error404", (result as ViewResult).ViewName);
        }
    }
}