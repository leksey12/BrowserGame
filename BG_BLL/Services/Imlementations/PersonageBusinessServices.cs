
using BG_BLL.Services;
using BG_DAL.Entityes;
using BG_DAL.Services;
using BrowserGame.Models;
using Mapster;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BG_BLL.Imlementations
{
    public class PersonageBusinessServices : IPersonageBusinessServices
    {
        private readonly IPersonageDataServices personageServices;
        public PersonageBusinessServices(IPersonageDataServices personageServices)
        {
            this.personageServices = personageServices;
        }

        public IEnumerable<PersonageBusiness> GetAllPersonages()
        {
            var personageDto = personageServices.GetAllPersonages();
            var personage = new List<PersonageBusiness>();
            foreach (var el in personageDto)
            {
                var personages = el.Adapt<PersonageBusiness>();
                personage.Add(personages);
            }
            return personage;
        }

        //получаем по id
        public async Task<PersonageBusiness> GetPersonageByIdAsync(int? id)
        {
            var personageDto = await personageServices.GetPersonageByIdAsync(id);
            return personageDto.Adapt<PersonageBusiness>();
        }

        public void SavePersonage(PersonageBusiness personage, string operation)
        {
             
            var personageDto = personage.Adapt<PersonageData>();
           personageDto.Id = personage.Id;
            switch (operation)
            {
                case "add":
                     personageServices.SavePersonage(personageDto);
                    break;
                case "update":
                    personageServices.UpdatePersonage(personageDto);
                    break;
            }
        }

        public Task DeletePersonageAsync(int id)
        {
            return personageServices.DeletePersonageAsync(id);
        }
       
    }
}