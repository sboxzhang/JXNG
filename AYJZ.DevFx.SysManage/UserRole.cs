using System;
using System.Collections.Generic;

using System.Text;

namespace VSM.DevFx.SysManage
{
    public class UserRole
    {
        UserRoleDao _Dao = new UserRoleDao();
        public bool GrantUserRole(int UserId, List<string> RoleId)
        {
            return _Dao.GrantUserRole(UserId, RoleId);
        }
        public bool ModifyUserRole(int UserId, List<string> RoleId)
        {
            return _Dao.ModifyUserRole(UserId, RoleId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<UserRoleInfo> GetUserRole(string UserId)
        {
            return _Dao.GetUserRole(UserId);
        }
    }
}
