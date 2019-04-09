using BrowserGame.Controllers;
using BrowserGame.Models;
using BrowserGame.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BrowserGame.Tests
{
    [TestFixture]
    public class PersonagesControllerTests
    {
        
        
        PersonagesController controller;
        PersonagesController _controllercontext;
        Personage model;
        Mock<IPersonageServices> personage;
        Mock<ILogger<PersonagesController>> logger;

        [SetUp]
        public void Setup()
        {
            // Arrange
            model = new Personage { Id = 1, Name = "Pers", Category = "Ligaa",Capital= "1700000" , History="взрывной" , Possession= "Полузащитник"};

            logger = new Mock<ILogger<PersonagesController>>();
            personage = new Mock<IPersonageServices>();
            controller = new PersonagesController(personage.Object, logger.Object);

            _controllercontext = new PersonagesController(personage.Object, logger.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext
                    {
                        User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                    {
                         new Claim(ClaimTypes.Name, "User")
                    }, "someAuthTypeName"))
                    }
                }
            };
        }

        private List<Personage> GetTestPersons()
        {
            var personage = new List<Personage>
            {
               new Personage{ Name = "Alexander", History = "Живет футболом", Possession = "Нападающий", Category = "Лига Европы", Capital = "700000", Id = 1},
               new Personage { Name="Roman",History="Любит Деньги",Possession="Защитник",Category="Лига Европы",Capital="500000",Id=2},
            };
            return personage;
        }

        [Test]
        public async Task Details_IdIsNull_ReturnNotFoundResult()
        {
            // Arrange

            // Act
            var result = await controller.Details(null);

            // Arrange
            Assert.That(result, Is.TypeOf<NotFoundResult>());
        }
        [Test]
        public void Create_ValidModel_ReturnRedirectToAction()
        {
            // Arrange

            //Act
            var result = _controllercontext.Create(model);

            //Assert
            personage.Verify(m => m.SavePersonage(model, "add"));
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());
        }
        [Test]
        public async Task Edit_IdIsNull_ReturnNotFoundResult()
        {
            // Arrange

            // Act
            var result = await controller.Edit(null);

            // Arrange
            Assert.That(result, Is.TypeOf<NotFoundResult>());
        }
        [Test]
        public async Task Delete_IdIsNull_ReturnNotFoundResult()
        {
            // Arrange

            // Act
            var result = await controller.Delete(null);

            // Arrange
            Assert.That(result, Is.TypeOf<NotFoundResult>());
        }
        [Test]
        public void DeleteConfirmed_ReturnRedirectToAction()
        {
            // Arrange

            //Act
            var result = controller.DeleteConfirmed(1);
            //Assert
            personage.Verify(m => m.DeletePersonageAsync(1));
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());
        }

    }
}