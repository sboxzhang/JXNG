using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AYJZ.DataAccess;
using AYJZ.Entities;
namespace AYJZ.BusinessLogic
{
	 	//BuAddress
		public class BuAddressLogic
	{
        BuAddressDao dao = new BuAddressDao();

        public List<BuAddress> GetBuAddressList(string Where)
        {
            return dao.GetBuAddressList(Where);
        }

        public BuAddress GetBuAddress(int Id)
        {
            return dao.GetBuAddress(Id);
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