using System;
using System.Collections.Generic;

using System.Text;

namespace VSM.DevFx.SysManage
{
    public class Role
    {
        RoleDao _role = new RoleDao();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool CreateRole(RoleInfo role)
        {
            return _role.CreateRole(role);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool ModifyRole(RoleInfo role)
        {
            return _role.ModifyRole(role);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public bool DeleteRole(string RoleId)
        {
            return _role.DeleteRole(RoleId);
        }

        public List<RoleInfo> GetRoleAll()
        {
            return _role.GetRoleAll();
        }
        public RoleInfo GetRoleById(string RoleId)
        {
            return _role.GetRoleById(RoleId);
        }

        
    }
}
