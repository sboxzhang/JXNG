using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VSM.DataAccess;
using VSM.Entities;
namespace VSM.BusinessLogic
{
	 	//BuGastankRepair
		public class BuGastankRepairLogic
	{
        BuGastankRepairDao dao = new BuGastankRepairDao();

        public List<BuGastankRepair> GetBuGastankRepairList(string Where)
        {
            return dao.GetBuGastankRepairList(Where);
        }

        public BuGastankRepair GetBuGastankRepair(int GasRepairId)
        {
            return dao.GetBuGastankRepair(GasRepairId);
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