using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VSM.DataAccess;
using VSM.Entities;
namespace VSM.BusinessLogic
{
	 	//BuGPSLog
		public class BuGPSLogLogic
	{
        BuGPSLogDao dao = new BuGPSLogDao();

        public List<BuGPSLog> GetBuGPSLogList(string Where)
        {
            return dao.GetBuGPSLogList(Where);
        }

        public BuGPSLog GetBuGPSLog(int GPSLogId)
        {
            return dao.GetBuGPSLog(GPSLogId);
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