using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VSM.DataAccess;
using VSM.Entities;
namespace VSM.BusinessLogic
{
	 	//BuGPSInfo
		public class BuGPSInfoLogic
	{
        BuGPSInfoDao dao = new BuGPSInfoDao();

        public List<BuGPSInfo> GetBuGPSInfoList(string Where)
        {
            return dao.GetBuGPSInfoList(Where);
        }

        public BuGPSInfo GetBuGPSInfo(string GPSId)
        {
            return dao.GetBuGPSInfo(GPSId);
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