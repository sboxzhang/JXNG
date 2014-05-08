using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VSM.DataAccess;
using VSM.Entities;
using System.Data;

namespace VSM.BusinessLogic
{
    public class syslogLogic
    {
        syslogDao dao = new syslogDao();
        public int Insert(syslogInfo ent)
        {
            return dao.Insert(ent,null);
        }
        public int Delete(syslogInfo ent)
        {
            return dao.Delete(ent, null);
        }
        public int Update(syslogInfo ent)
        {
            return dao.Update(ent,null);
        }

        public DataTable GetData(string where)
        {
            return dao.GetData(where);
        }
    }
}
