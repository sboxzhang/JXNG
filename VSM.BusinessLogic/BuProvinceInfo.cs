using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VSM.DataAccess;
using VSM.Entities;
namespace VSM.BusinessLogic
{
	 	//BuProvinceInfo
		public class BuProvinceInfoLogic
	{
        BuProvinceInfoDao dao = new BuProvinceInfoDao();

        public List<BuProvinceInfo> GetBuProvinceInfoList(string Where)
        {
            return dao.GetBuProvinceInfoList(Where);
        }

        public BuProvinceInfo GetBuProvinceInfo(string ProvinceCode)
        {
            return dao.GetBuProvinceInfo(ProvinceCode);
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