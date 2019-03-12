using BG_BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BG_BLL
{
   public class DataManagerRepo
    {
        private readonly IPersonage _pRepository;

        public DataManagerRepo(IPersonage pRepository)
        {
            _pRepository = pRepository;
        }

        public IPersonage Personage { get { return _pRepository; } }

    }
}
