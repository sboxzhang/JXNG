using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AYJZ.DataAccess;
using AYJZ.Entities;

namespace AYJZ.BusinessLogic
{
    public class ayjz_khxxlogic
    {
        ayjz_employeeinfoDao dao = new ayjz_employeeinfoDao();

        public ayjz_employeeinfoInfo Getayjz_khxx(long ID)
        {
            return dao.Getayjz_employeeinfo(ID);
        }
    }
}
