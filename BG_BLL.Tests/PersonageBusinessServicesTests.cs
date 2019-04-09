using BG_BLL.Imlementations;
using BG_DAL.Entityes;
using BG_DAL.Services;
using BrowserGame.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BG_BLL.Tests
{
    [TestFixture]
    class PersonageBusinessServicesTests
    {
        Mock<IPersonageDataServices> personageDataServices;
        PersonageBusinessServices personageServices;
        PersonageData model;

        [SetUp]
        public void Setup()
        {
            // Arrange
            model = new PersonageData { Name = "Alexander", History = "Живет футболом", Possession = "Нападающий", Category = "Лига Европы", Capital = "700000", Id = 1 };
            personageDataServices = new Mock<IPersonageDataServices>();
            personageServices = new PersonageBusinessServices(personageDataServices.Object);
        }
        private List<PersonageData> GetAllPersonage()
        {
            var personage = new List<PersonageData>
            {
                new PersonageData { Name = "Alexander", History = "Живет футболом", Possession = "Нападающий", Category = "Лига Европы", Capital = "700000", Id = 1},
                new PersonageData { Name="Roman",History="Любит Деньги",Possession="Защитник",Category="Лига Европы",Capital="500000",Id=2},
            };
            return personage;
        }
        [Test]
        public async Task GetPersonageByIdAsync()
        {
            // Arrange
            personageDataServices.Setup(m => m.GetPersonageByIdAsync(100)).ReturnsAsync(model);

            PersonageBusinessServices _personageServices = new PersonageBusinessServices(personageDataServices.Object);

            // Act
            var result = await _personageServices.GetPersonageByIdAsync(100);

            // Assert
            Assert.That(result, Is.TypeOf<PersonageBusiness>());
        }
        [Test]
        public void DeletePersonageAsync()
        {
            // Arrange

            // Act
            var result = personageServices.DeletePersonageAsync(100);

            // Assert
            personageDataServices.Verify(m => m.DeletePersonageAsync(100));
            Assert.That(result, Is.TypeOf<Task<bool>>());
        }
    }
}