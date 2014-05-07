using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AYJZ.DataAccess;
using AYJZ.Entities;

namespace AYJZ.BusinessLogic
{
    
    public class ayjz_employeeinfoLogic
    {
        ayjz_employeeinfoDao dao = new ayjz_employeeinfoDao();
        public List<ayjz_employeeinfoInfo> Getayjz_employeeinfoList(string Where)
        {
            return dao.Getayjz_employeeinfoList(Where);
        }
    }
}
