using System;
using System.Collections.Generic;

using System.Text;
using JITE.CIS.Framework.DBProviders;
using System.Data.Common;
using System.Data;
namespace VSM.DevFx.SysManage
{
    partial class RoleMoudleDao
    {
        public bool GrantRoleMoudle(int RoleId, List<string> MoudleId)
        {
            List<string> list = new List<string>();
            string sql = string.Format("Delete FROM rolemoudleinfo  Where roleid = '{0}'", RoleId);
            list.Add(sql);
            foreach (string _MoudleId in MoudleId)
            {
                sql = string.Format("Insert Into rolemoudleinfo (roleid, moudleid, powervalue)Values  ('{0}', '{1}','0')", RoleId, _MoudleId);
                list.Add(sql);
            }
            return DataBaseManage.ExecuteSqlTran(list) > 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ListInfo"></param>
        /// <returns></returns>
        public bool GrantRolePower(List<RoleMoudleInfo> ListInfo)
        {
            List<string> list = new List<string>();
            string sql = "";
            foreach (RoleMoudleInfo info in ListInfo)
            {
                sql = string.Format("Update rolemoudleinfo  Set powervalue = '{0}' Where roleid = '{1}' And moudleid = '{2}'", info.PowerValue, info.RoleId, info.MoudleId);
                list.Add(sql);
            }
            return DataBaseManage.ExecuteSqlTran(list) > 0;
        }

        public bool DeleteRoleMoudle(int RoleId)
        {
            return true;
        }
        public bool ModifyRoleMoudle(int RoleId, List<int> FuntionId)
        {
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public List<RoleMoudleInfo> GetRoleMoudle(string RoleId)
        {
            List<RoleMoudleInfo> ListInfo = new List<RoleMoudleInfo>();
            RoleMoudleInfo info = null;
            string sql = "Select roleid, moudleid,powervalue From rolemoudleinfo where roleid='" + RoleId.ToString() + "'";
            using (DbDataReader reader = DataBaseManage.ExecuteReader(sql))
            {
                while (reader.Read())
                {
                    info = new RoleMoudleInfo();
                    info.MoudleId = (reader.IsDBNull(reader.GetOrdinal("moudleid"))) ? int.Parse("0") : int.Parse(reader["moudleid"].ToString());
                    info.RoleId = (reader.IsDBNull(reader.GetOrdinal("roleid"))) ? int.Parse("0") : int.Parse(reader["roleid"].ToString());
                    info.PowerValue = (reader.IsDBNull(reader.GetOrdinal("powervalue"))) ? int.Parse("0") : int.Parse(reader["powervalue"].ToString());
                    ListInfo.Add(info);
                }
            }
            return ListInfo;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public RoleMoudleInfo GetRolePower(string RoleId, string MoudleId)
        {
            RoleMoudleInfo info = new RoleMoudleInfo();
            string sql = "Select roleid, moudleid,powervalue From rolemoudleinfo where roleid in(" + RoleId + ") and moudleid='" + MoudleId + "'";
            using (DbDataReader reader = DataBaseManage.ExecuteReader(sql))
            {
                if (reader.Read())
                {
                    info.MoudleId = (reader.IsDBNull(reader.GetOrdinal("moudleid"))) ? int.Parse("0") : int.Parse(reader["moudleid"].ToString());
                    info.RoleId = (reader.IsDBNull(reader.GetOrdinal("roleid"))) ? int.Parse("0") : int.Parse(reader["roleid"].ToString());
                    info.PowerValue = (reader.IsDBNull(reader.GetOrdinal("powervalue"))) ? int.Parse("0") : int.Parse(reader["powervalue"].ToString());
                }
            }
            return info;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="RoleId"></param>
        /// <param name="MoudleId"></param>
        /// <returns></returns>
        public int GetPowerValue(string RoleId, string MoudleId)
        {
            RoleMoudleInfo info = new RoleMoudleInfo();
            string sql = "Select sum(powervalue) powervalue From rolemoudleinfo where roleid in(" + RoleId + ") and moudleid='" + MoudleId + "'";
            using (DbDataReader reader = DataBaseManage.ExecuteReader(sql))
            {
                if (reader.Read())
                {
                    info.PowerValue = (reader.IsDBNull(reader.GetOrdinal("powervalue"))) ? int.Parse("0") : int.Parse(reader["powervalue"].ToString());
                }
            }
            return int.Parse(info.PowerValue.ToString());
        }
    }
}