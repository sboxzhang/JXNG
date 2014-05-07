using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AYJZ.DataAccess;
using AYJZ.Entities;

namespace AYJZ.BusinessLogic
{
    public class ayjz_d_lxdhLogic
    {
        private ayjz_d_lxdhDao dao = new ayjz_d_lxdhDao();

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

        /// <summary>
        /// 根据Id得到
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public ayjz_d_lxdhInfo Getayjz_d_lxdh(long ID)
        {            
            return dao.Getayjz_d_lxdh(ID);
        }

        /// <summary>
        /// 得到列表
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public List<ayjz_d_lxdhInfo> Getayjz_d_lxdhList(string Where)
        {
            return dao.Getayjz_d_lxdhList(Where);
        }

    }
}
