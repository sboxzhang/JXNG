using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VSM.DataAccess;
using VSM.Entities;
namespace VSM.BusinessLogic
{
	 	//BuWFRelationshipLog
		public class BuWFRelationshipLogLogic
	{
        BuWFRelationshipLogDao dao = new BuWFRelationshipLogDao();

        public List<BuWFRelationshipLog> GetBuWFRelationshipLogList(string Where)
        {
            return dao.GetBuWFRelationshipLogList(Where);
        }

        public BuWFRelationshipLog GetBuWFRelationshipLog(int LogId)
        {
            return dao.GetBuWFRelationshipLog(LogId);
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