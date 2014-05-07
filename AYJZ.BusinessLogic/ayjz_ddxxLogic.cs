using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AYJZ.DataAccess;
using System.Data;
using AYJZ.Entities;

namespace AYJZ.BusinessLogic
{
    public class ayjz_ddxxLogic
    {
        ayjz_ddxxDao dao = new ayjz_ddxxDao();
        
        public List<ayjz_ddxxInfo> Getayjz_ddxxList(string Where)
        {
            return dao.Getayjz_ddxxList(Where);
        }
        public ayjz_ddxxInfo Getayjz_ddxx(long ID)
        {
            return dao.Getayjz_ddxx(ID);
        }

        public bool Insert(ayjz_ddxx_spInfo info)
        {
            ayjz_ddxx_spDao ddxx = new ayjz_ddxx_spDao();
            return ddxx.Insert(info, null) > 0;
        }
    }
}
