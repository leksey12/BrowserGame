using BG_DAL.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BG_BLL.Interfaces
{
  public  interface IApplicationUser
    {
        IEnumerable<ApplicationUser> GetAllApplicationUsers();
        ApplicationUser GetApplicationUserById(int Id);
        void SaveApplicationUser(ApplicationUser achieve);
        void DeleteApplicationUser(ApplicationUser achieve);
    }
}
