using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using JITE.CIS.Framework.DBProviders;
namespace AYJZ.DevFx.SysManage
{
    public class PowerDao
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool CreatePower(PowerInfo info)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("    Insert Into powerinfo ");
            sql.Append("        ( powername, powervalue, moudleid) ");
            sql.Append("    Values( ");
            sql.Append("         '" + info.PowerName + "',");
            sql.Append("         '" + info.PowerValue.ToString() + "',");
            sql.Append("         '" + info.MoudleId.ToString() + "'");
            sql.Append("    ) ");
            return DataBaseManage.ExecuteSql(sql.ToString()) > 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool ModifyPower(PowerInfo info)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" Update powerinfo ");
            sql.Append("    Set powername = '" + info.PowerName + "',");
            sql.Append("        powervalue = '" + info.PowerValue.ToString() + "' ");
            sql.Append("   Where powerid = '" + info.PowerId.ToString() + "'");
            return DataBaseManage.ExecuteSql(sql.ToString()) > 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public bool DeletePower(string PowerId)
        {
            string sql = "Delete powerinfo Where powerid = '" + PowerId + "'";
            return DataBaseManage.ExecuteSql(sql) > 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="PowerId"></param>
        /// <returns></returns>
        public PowerInfo GetPowerInfo(string PowerId)
        {
            string Sql = "Select powerid, powername, powervalue, moudleid From powerinfo where powerid='" + PowerId + "'";
            PowerInfo info = new PowerInfo();
            using (DbDataReader reader = DataBaseManage.ExecuteReader(Sql))
            {
                if (reader.Read())
                {
                    info.MoudleId = (reader.IsDBNull(reader.GetOrdinal("moudleid"))) ? "" : reader["moudleid"].ToString();
                    info.PowerId = (reader.IsDBNull(reader.GetOrdinal("powerid"))) ? "" : reader["powerid"].ToString();
                    info.PowerName = (reader.IsDBNull(reader.GetOrdinal("powername"))) ? "" : reader["powername"].ToString();
                    info.PowerValue = (reader.IsDBNull(reader.GetOrdinal("powervalue"))) ? int.Parse("0") : int.Parse(reader["powervalue"].ToString());
                }
            }
            return info;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<PowerInfo> GetPowerByMoudleId(string MoudleId)
        {
            string Sql = "Select powerid, powername, powervalue, moudleid From powerinfo where moudleid='" + MoudleId + "'";
            List<PowerInfo> ListInfo = new List<PowerInfo>();
            PowerInfo info = null;
            using (DbDataReader reader = DataBaseManage.ExecuteReader(Sql))
            {
                if (reader!=null)
                {
                    while (reader.Read())
                    {
                        info = new PowerInfo();
                        info.MoudleId = (reader.IsDBNull(reader.GetOrdinal("moudleid"))) ? "" : reader["moudleid"].ToString();
                        info.PowerId = (reader.IsDBNull(reader.GetOrdinal("powerid"))) ? "" : reader["powerid"].ToString();
                        info.PowerName = (reader.IsDBNull(reader.GetOrdinal("powername"))) ? "" : reader["powername"].ToString();
                        info.PowerValue = (reader.IsDBNull(reader.GetOrdinal("powervalue"))) ? int.Parse("0") : int.Parse(reader["powervalue"].ToString());
                        ListInfo.Add(info);
                    }
                }
            }
            return ListInfo;
        }
    }
}
