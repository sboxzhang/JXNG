using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AYJZ.DataAccess;
using AYJZ.Entities;
namespace AYJZ.BusinessLogic
{
	 	//BuCarRepair
		public class BuCarRepairLogic
	{
        BuCarRepairDao dao = new BuCarRepairDao();

        public List<BuCarRepair> GetBuCarRepairList(string Where)
        {
            return dao.GetBuCarRepairList(Where);
        }

        public BuCarRepair GetBuCarRepair(int RepairId)
        {
            return dao.GetBuCarRepair(RepairId);
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