using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using JITE.CIS.Framework.DBProviders;
namespace VSM.DevFx.SysManage
{
    partial class RoleDao
    {
        private static readonly string _SelectSql = "Select roleid, rolename,remark From roleinfo";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool CreateRole(RoleInfo role)
        {
            string Sql = string.Format("Insert Into roleinfo(rolename,remark)Values('{0}','{1}')", role.RoleName,role.Remark);

            return DataBaseManage.ExecuteSql(Sql) > 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool ModifyRole(RoleInfo role)
        {
            string Sql = string.Format("Update roleinfo  Set rolename = '{0}',remark = '{1}' Where roleid = '{2}'", role.RoleName,role.Remark, role.RoleId);
            return DataBaseManage.ExecuteSql(Sql) > 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public bool DeleteRole(string RoleId)
        {
            string sql = "Delete roleinfo Where roleid = '" + RoleId + "'";
            return DataBaseManage.ExecuteSql(sql) > 0;
        }
        /// <summary>
        /// 取得所有角色
        /// </summary>
        /// <returns></returns>
        public List<RoleInfo> GetRoleAll()
        {
            List<RoleInfo> ListInfo = new List<RoleInfo>();

            using (DbDataReader reader = DataBaseManage.ExecuteReader(_SelectSql))
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                       ListInfo.Add(BuilderEntity(reader));
                    }
                }
            }
            return ListInfo;
        }
        /// <summary>
        /// 根据角色ID取得角色信息
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public RoleInfo GetRoleById(string RoleId)
        {
            RoleInfo info = new RoleInfo();

            using (DbDataReader reader = DataBaseManage.ExecuteReader(_SelectSql + " where roleid='" + RoleId + "'"))
            {
                if (reader.Read())
                {
                    info = BuilderEntity(reader);
                }
            }
            return info;
        }

        private RoleInfo BuilderEntity(DbDataReader reader)
        {
            RoleInfo info = new RoleInfo();

            info.RoleId = (reader.IsDBNull(reader.GetOrdinal("roleid"))) ? int.Parse("0") : int.Parse(reader["roleid"].ToString());
            info.RoleName = (reader.IsDBNull(reader.GetOrdinal("rolename"))) ? "" : reader["rolename"].ToString();
            info.Remark = (reader.IsDBNull(reader.GetOrdinal("remark"))) ? "" : reader["remark"].ToString();

            return info;
        }
    }
}
