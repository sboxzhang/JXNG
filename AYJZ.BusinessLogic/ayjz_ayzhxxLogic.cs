using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AYJZ.DataAccess;
using AYJZ.Entities;

namespace AYJZ.BusinessLogic
{
    public class ayjz_ayzhxxLogic
    {
        ayjz_ayzhxxDao dao = new ayjz_ayzhxxDao();

        public List<ayjz_ayzhxxInfo> Getayjz_ayzhxxList(string Where)
        {
            return dao.Getayjz_ayzhxxList(Where);
        }

        public ayjz_ayzhxxInfo Getayjz_ayzhxx(long ID)
        {
            return dao.Getayjz_ayzhxx(ID);
        }

        public bool Insert(BaseEntitie ent)
        {
            return dao.Insert(ent, null) > 0;
        }

        public bool Delete(BaseEntitie ent)
        {
            return dao.Delete(ent, null) > 0;
        }

        public bool Update(BaseEntitie ent)
        {
            return dao.Update(ent, null) > 0;
        }

        public long InsertIdentity(BaseEntitie ent)
        {
            return dao.InsertIdentity(ent);
        }
    }
}
