using System;
using System.Collections.Generic;

using System.Text;

namespace AYJZ.DevFx.SysManage
{
    public class RoleMoudle
    {
        RoleMoudleDao _roleMoudle = new RoleMoudleDao();

        public bool GrantRoleMoudle(int RoleId, List<string> MoudleId)
        {
            return _roleMoudle.GrantRoleMoudle(RoleId, MoudleId);
        }
        public bool GrantRolePower(List<RoleMoudleInfo> ListInfo)
        {
            return _roleMoudle.GrantRolePower(ListInfo);
        }
        public List<RoleMoudleInfo> GetRoleMoudle(string RoleId)
        {
            return _roleMoudle.GetRoleMoudle(RoleId);
        }
        public RoleMoudleInfo GetRolePower(string RoleId, string MoudleId)
        {
            return _roleMoudle.GetRolePower(RoleId, MoudleId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="RoleId"></param>
        /// <param name="MoudleId"></param>
        /// <returns></returns>
        public int GetPowerValue(string RoleId, string MoudleId)
        {
            return _roleMoudle.GetPowerValue(RoleId, MoudleId);
        }
    }
}
