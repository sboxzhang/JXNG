using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VSM.DataAccess;
using VSM.Entities;
namespace VSM.BusinessLogic
{
	 	//BuGastankInfo
		public class BuGastankInfoLogic
	{
        BuGastankInfoDao dao = new BuGastankInfoDao();

        public List<BuGastankInfo> GetBuGastankInfoList(string Where)
        {
            return dao.GetBuGastankInfoList(Where);
        }

        public BuGastankInfo GetBuGastankInfo(string TankNumber)
        {
            return dao.GetBuGastankInfo(TankNumber);
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