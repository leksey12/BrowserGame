using BG_BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BG_BLL
{
   public class DataManagerRepo
    {
        private readonly IPersonage _pRepository;
        private readonly IApplicationUser _appRepository;

        public DataManagerRepo(IPersonage pRepository, IApplicationUser appRepository)
        {
            _pRepository = pRepository;
            _appRepository = appRepository;
        }

        public IPersonage Personage { get { return _pRepository; } }
        public IApplicationUser User { get { return _appRepository; } }

    }
}
