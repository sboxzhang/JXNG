using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AYJZ.DataAccess;
using AYJZ.Entities;
namespace AYJZ.BusinessLogic
{
	 	//BuWFRelationship
		public class BuWFRelationshipLogic
	{
        BuWFRelationshipDao dao = new BuWFRelationshipDao();

        public List<BuWFRelationship> GetBuWFRelationshipList(string Where)
        {
            return dao.GetBuWFRelationshipList(Where);
        }

        public BuWFRelationship GetBuWFRelationship(int RelationshipId)
        {
            return dao.GetBuWFRelationship(RelationshipId);
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