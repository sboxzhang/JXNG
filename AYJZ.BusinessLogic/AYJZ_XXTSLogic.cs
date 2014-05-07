using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AYJZ.DataAccess;
using System.Data;
using AYJZ.Entities;
namespace AYJZ.BusinessLogic
{
    public class AYJZ_XXTSLogic
    {
        public ayjz_xxtsDao dao = new ayjz_xxtsDao();

        public DataTable GetData(string where)
        {
            return dao.GetData(where);
        }

        public bool Add(ayjz_xxtsInfo info, List<string> users)
        {
            return dao.Add(info, users);
        }
        public bool Delete(string id)
        {
            ayjz_xxtsInfo info = new ayjz_xxtsInfo();
            info.ID = Convert.ToInt64(id);
            return dao.Delete(info, null)>0;
        }
        public int Update(ayjz_xxtsInfo ent)
        {
            return dao.Update(ent, null);
        }

        public ayjz_xxtsInfo Getayjz_xxts(long ID)
        {
            return dao.Getayjz_xxts(ID);
        }
    }
}
