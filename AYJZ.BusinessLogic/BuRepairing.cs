using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AYJZ.DataAccess;
using AYJZ.Entities;
namespace AYJZ.BusinessLogic
{
	 	//BuRepairing
		public class BuRepairingLogic
	{
        BuRepairingDao dao = new BuRepairingDao();

        public List<BuRepairing> GetBuRepairingList(string Where)
        {
            return dao.GetBuRepairingList(Where);
        }

        public BuRepairing GetBuRepairing(int RepairingId)
        {
            return dao.GetBuRepairing(RepairingId);
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