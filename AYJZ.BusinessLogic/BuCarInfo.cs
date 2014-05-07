using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AYJZ.DataAccess;
using AYJZ.Entities;
namespace AYJZ.BusinessLogic
{
	 	//BuCarInfo
		public class BuCarInfoLogic
	{
        BuCarInfoDao dao = new BuCarInfoDao();

        public List<BuCarInfo> GetBuCarInfoList(string Where)
        {
            return dao.GetBuCarInfoList(Where);
        }

        public BuCarInfo GetBuCarInfo(string CarNumber)
        {
            return dao.GetBuCarInfo(CarNumber);
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