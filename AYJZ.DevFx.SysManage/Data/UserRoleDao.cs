using System;
using System.Collections.Generic;

using System.Text;
using JITE.CIS.Framework.DBProviders;
using System.Data.Common;
namespace AYJZ.DevFx.SysManage
{
    partial class UserRoleDao
    {
        /// <summary>
        /// 授予用户角色
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public bool GrantUserRole(int UserId, List<string> RoleId)
        {
            List<string> list = new List<string>();
            string sql = "";
            foreach (string _RoleId in RoleId)
            {
                sql = string.Format("Insert Into userroleinfo (userid, roleid)Values  ('{0}', '{1}')", UserId, _RoleId);
                list.Add(sql);
            }
            return DataBaseManage.ExecuteSqlTran(list) > 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<UserRoleInfo> GetUserRole(string UserId)
        {
            List<UserRoleInfo> ListInfo = new List<UserRoleInfo>();
            UserRoleInfo info = null;
            string Sql = string.Format("select t.userid,t.roleid,(Select rolename From roleinfo Where roleid=t.roleid) rolename from userroleinfo t Where t.userid='{0}'", UserId);
            using (DbDataReader reader = DataBaseManage.ExecuteReader(Sql))
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        info = new UserRoleInfo();
                        info.UserId = (reader.IsDBNull(reader.GetOrdinal("userid"))) ? "" : reader["userid"].ToString();
                        info.RoleId = (reader.IsDBNull(reader.GetOrdinal("roleid"))) ? "" : reader["roleid"].ToString();
                        info.RoleName = (reader.IsDBNull(reader.GetOrdinal("rolename"))) ? "" : reader["rolename"].ToString();
                        ListInfo.Add(info);
                    }
                }
            }
            return ListInfo;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool DeleteUserRole()
        {
            return true;
        }
        /// <summary>
        /// 修改用户角色
        /// </summary>
        /// <returns></returns>
        public bool ModifyUserRole(int UserId, List<string> RoleId)
        {
            List<string> list = new List<string>();
            string sql = string.Format("Delete FROM userroleinfo Where userid = '{0}'", UserId);
            list.Add(sql);
            foreach (string _RoleId in RoleId)
            {
                sql = string.Format("Insert Into userroleinfo (userid, roleid)Values  ('{0}', '{1}')", UserId, _RoleId);
                list.Add(sql);
            }
            return DataBaseManage.ExecuteSqlTran(list) > 0;
        }
    }
}
