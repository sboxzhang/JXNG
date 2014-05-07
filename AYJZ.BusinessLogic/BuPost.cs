using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AYJZ.DataAccess;
using AYJZ.Entities;
namespace AYJZ.BusinessLogic
{
	 	//BuPost
		public class BuPostLogic
	{
        BuPostDao dao = new BuPostDao();

        public List<BuPost> GetBuPostList(string Where)
        {
            return dao.GetBuPostList(Where);
        }

        public BuPost GetBuPost(int PostId)
        {
            return dao.GetBuPost(PostId);
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