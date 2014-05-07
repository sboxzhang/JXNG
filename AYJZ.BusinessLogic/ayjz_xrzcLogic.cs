using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AYJZ.DataAccess;
using AYJZ.Entities;

namespace AYJZ.BusinessLogic
{
    public class ayjz_xrzcLogic
    {
        ayjz_xrzcDao dao = new ayjz_xrzcDao();
        public DataTable GetData(string where)
        {
            return dao.GetData(where);
        }

        public bool Delete(string id)
        {
            ayjz_xrzcInfo info = new ayjz_xrzcInfo();
            info.ID = Convert.ToInt64(id);
            return dao.Delete(info, null) > 0;
        }
        public List<ayjz_xrzcInfo> Getayjz_xrzcList(string Where)
        {
            return dao.Getayjz_xrzcList(Where);
        }
        public ayjz_xrzcInfo Getayjz_xrzc(long ID)
        {
            return dao.Getayjz_xrzc(ID);
        }

        public bool Update(ayjz_xrzcInfo ent)
        {
            return dao.Update(ent, null) > 0;
        }
        public bool Add(ayjz_xrzcInfo ent)
        {
            return dao.Insert(ent, null) > 0;
        }
    }
}
