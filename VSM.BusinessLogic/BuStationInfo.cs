using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VSM.DataAccess;
using VSM.Entities;
namespace VSM.BusinessLogic
{
	 	//BuStationInfo
		public class BuStationInfoLogic
	{
        BuStationInfoDao dao = new BuStationInfoDao();

        public List<BuStationInfo> GetBuStationInfoList(string Where)
        {
            return dao.GetBuStationInfoList(Where);
        }

        public BuStationInfo GetBuStationInfo(int StationId)
        {
            return dao.GetBuStationInfo(StationId);
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