using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VSM.DataAccess;
using VSM.Entities;
namespace VSM.BusinessLogic
{
	 	//BuCityInfo
		public class BuCityInfoLogic
	{
        BuCityInfoDao dao = new BuCityInfoDao();

        public List<BuCityInfo> GetBuCityInfoList(string Where)
        {
            return dao.GetBuCityInfoList(Where);
        }

        public BuCityInfo GetBuCityInfo(string CityCode)
        {
            return dao.GetBuCityInfo(CityCode);
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