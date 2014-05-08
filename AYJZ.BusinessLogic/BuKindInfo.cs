using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VSM.DataAccess;
using VSM.Entities;
namespace VSM.BusinessLogic
{
	 	//BuKindInfo
		public class BuKindInfoLogic
	{
        BuKindInfoDao dao = new BuKindInfoDao();

        public List<BuKindInfo> GetBuKindInfoList(string Where)
        {
            return dao.GetBuKindInfoList(Where);
        }

        public BuKindInfo GetBuKindInfo(int KindId)
        {
            return dao.GetBuKindInfo(KindId);
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