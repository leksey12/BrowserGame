
using BG_BLL.Services;
using BG_DAL.Entityes;
using BG_DAL.Services;
using BrowserGame.Models;
using BrowserGame.Services;
using Mapster;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BG_BLL.Imlementations
{
    public class PersonageServices : IPersonageServices
    {
        private readonly IPersonageBusinessServices personageData;
        public PersonageServices(IPersonageBusinessServices personageData)
        {
            this.personageData = personageData;
        }

        public IEnumerable<Personage> GetAllPersonages()
        {
            return personageData.GetAllPersonages().Adapt<IEnumerable<Personage>>();
        }

        //получаем по id
        public async Task<Personage> GetPersonageByIdAsync(int? id)
        {
            return (await personageData.GetPersonageByIdAsync(id)).Adapt<Personage>();
        }

        public int SavePersonage(Personage personage, string operation)
        {
            var personageBus = personage.Adapt<PersonageBusiness>();
            personageData.SavePersonage(personageBus, operation);
            return personageBus.Id;
        }

        public Task DeletePersonageAsync(int id)
        {
            return personageData.DeletePersonageAsync(id);
        }
       
    }
}