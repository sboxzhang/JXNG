using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VSM.DataAccess;
using VSM.Entities;
namespace VSM.BusinessLogic
{
	 	//BuTypeInfo
		public class BuTypeInfoLogic
	{
        BuTypeInfoDao dao = new BuTypeInfoDao();

        public List<BuTypeInfo> GetBuTypeInfoList(string Where)
        {
            return dao.GetBuTypeInfoList(Where);
        }

        public BuTypeInfo GetBuTypeInfo(int TypeId)
        {
            return dao.GetBuTypeInfo(TypeId);
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
	}
}