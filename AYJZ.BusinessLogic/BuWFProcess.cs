using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AYJZ.DataAccess;
using AYJZ.Entities;
namespace AYJZ.BusinessLogic
{
	 	//BuWFProcess
		public class BuWFProcessLogic
	{
        BuWFProcessDao dao = new BuWFProcessDao();

        public List<BuWFProcess> GetBuWFProcessList(string Where)
        {
            return dao.GetBuWFProcessList(Where);
        }

        public BuWFProcess GetBuWFProcess(int ProcessId)
        {
            return dao.GetBuWFProcess(ProcessId);
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