using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VSM.DataAccess;
using VSM.Entities;
namespace VSM.BusinessLogic
{
	 	//BuWorkFlow
		public class BuWorkFlowLogic
	{
        BuWorkFlowDao dao = new BuWorkFlowDao();

        public List<BuWorkFlow> GetBuWorkFlowList(string Where)
        {
            return dao.GetBuWorkFlowList(Where);
        }

        public BuWorkFlow GetBuWorkFlow(string WorkflowGUID)
        {
            return dao.GetBuWorkFlow(WorkflowGUID);
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