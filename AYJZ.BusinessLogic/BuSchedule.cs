using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VSM.DataAccess;
using VSM.Entities;
namespace VSM.BusinessLogic
{
	 	//BuSchedule
		public class BuScheduleLogic
	{
        BuScheduleDao dao = new BuScheduleDao();

        public List<BuSchedule> GetBuScheduleList(string Where)
        {
            return dao.GetBuScheduleList(Where);
        }

        public BuSchedule GetBuSchedule(int ScheduleId)
        {
            return dao.GetBuSchedule(ScheduleId);
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