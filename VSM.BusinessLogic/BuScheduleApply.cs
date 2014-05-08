using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VSM.DataAccess;
using VSM.Entities;
namespace VSM.BusinessLogic
{
	 	//BuScheduleApply
		public class BuScheduleApplyLogic
	{
        BuScheduleApplyDao dao = new BuScheduleApplyDao();

        public List<BuScheduleApply> GetBuScheduleApplyList(string Where)
        {
            return dao.GetBuScheduleApplyList(Where);
        }

        public BuScheduleApply GetBuScheduleApply(string ApplyId)
        {
            return dao.GetBuScheduleApply(ApplyId);
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