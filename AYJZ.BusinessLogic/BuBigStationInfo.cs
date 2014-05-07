using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AYJZ.DataAccess;
using AYJZ.Entities;
namespace AYJZ.BusinessLogic
{
	 	//BuBigStationInfo
		public class BuBigStationInfoLogic
	{
        BuBigStationInfoDao dao = new BuBigStationInfoDao();

        public List<BuBigStationInfo> GetBuBigStationInfoList(string Where)
        {
            return dao.GetBuBigStationInfoList(Where);
        }

        public BuBigStationInfo GetBuBigStationInfo(int BigStationId)
        {
            return dao.GetBuBigStationInfo(BigStationId);
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