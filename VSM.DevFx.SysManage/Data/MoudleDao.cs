using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using JITE.CIS.Framework.DBProviders;
using System.Data;
namespace VSM.DevFx.SysManage
{
    partial class MoudleDao
    {
        private static readonly string _SelectSql = "Select moudleid, moudlename, url, parentid, img, isenable, isroot,Sort,ywlx From moudleinfo ";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strUsl"></param>
        /// <returns></returns>
        public string Exists(string strUsl)
        {
            string Sql = string.Format("select moudleid from moudleinfo  Where url = '{0}'", strUsl);
            using (DbDataReader reader = DataBaseManage.ExecuteReader(Sql))
            {
                if (reader.Read())
                {
                    return (reader.IsDBNull(reader.GetOrdinal("moudleid"))) ? "" : reader["moudleid"].ToString();
                }
                else
                {
                    return "";
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool CreateMoudle(MoudleInfo info)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("    Insert Into moudleinfo ");
            sql.Append("        ( moudlename, url, parentid, img, isenable, isroot,ywlx,Sort) ");
            sql.Append("    Values( ");
            sql.Append("         '" + info.MoudleName + "',");
            sql.Append("         '" + info.Url + "',");
            sql.Append("         '" + info.ParentId + "',");
            sql.Append("         '" + info.Img + "',");
            sql.Append("         '" + info.IsEnable + "',");
            sql.Append("         '" + info.IsRoot + "',");
            sql.Append("         '" + info.YWLX + "',");
            sql.Append("         '" + info.Sort + "'");
            sql.Append("    ) ");
            return DataBaseManage.ExecuteSql(sql.ToString())>0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool ModifyMoudle(MoudleInfo info)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" Update moudleinfo ");
            sql.Append("    Set moudlename = '" + info .MoudleName+ "',");
            sql.Append("        url = '" + info .Url+ "', ");
            sql.Append("        parentid = '" + info.ParentId + "', ");
            sql.Append("        img = '" + info.Img + "', ");
            sql.Append("        isenable = '" + info.IsEnable + "',");
            sql.Append("        isroot = '" + info.IsRoot + "',");
            sql.Append("        ywlx = '" + info.YWLX + "',");
            sql.Append("        Sort = '" + info.Sort + "'");
            sql.Append("   Where moudleid = '" + info.MoudleId + "'");
            return DataBaseManage.ExecuteSql(sql.ToString()) > 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public bool DeleteMoudle(string MoudleId)
        {
            string sql = "Delete moudleinfo Where moudleid = '" + MoudleId + "'";
            return DataBaseManage.ExecuteSql(sql) > 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool ModifyMoudleSort(Dictionary<string, string> Dic)
        {
            List<string> list = new List<string>();
            StringBuilder sql = new StringBuilder();
            foreach (KeyValuePair<string, string> kvp in Dic)
            {
                list.Add(" Update moudleinfo Set Sort='" + kvp.Value + "' Where moudleid = '" + kvp.Key + "'");
            }
            return DataBaseManage.ExecuteSqlTran(list) > 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="MoudleId"></param>
        /// <returns></returns>
        public MoudleInfo GetMoudleInfo(string MoudleId)
        {
            MoudleInfo info = null;
            string sql = _SelectSql + " where moudleid='" + MoudleId + "'";
            using (DbDataReader reader = DataBaseManage.ExecuteReader(sql))
            {
                if (reader.Read())
                {
                    info = BuilderEntity(reader);
                }
            }
            return info;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<MoudleInfo> GetMoudleAll()
        {
            List<MoudleInfo> list = new List<MoudleInfo>();
            string sql = _SelectSql + " order by Sort";
            using (DbDataReader reader = DataBaseManage.ExecuteReader(sql))
            {
                if (reader!=null)
                {
                    while (reader.Read())
                    {
                        list.Add(BuilderEntity(reader));
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public List<MoudleInfo> GetMoudleByRole(List<string> RoleId)
        {
            List<MoudleInfo> ListInfo = new List<MoudleInfo>();
            string role = "";
            foreach (string id in RoleId)
            {
                role = "'"+id + "'," + role;
            }
            role = role.Substring(0, role.Length - 1);
            string sql = _SelectSql + " where moudleid in (Select moudleid From rolemoudleinfo where roleid in (" + role + ")) order by Sort";
            using (DbDataReader reader = DataBaseManage.ExecuteReader(sql))
            {
                while (reader.Read())
                {
                    ListInfo.Add(BuilderEntity(reader));
                }
            }
            return ListInfo;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public List<MoudleInfo> GetMoudleByRole(string RoleId)
        {
            List<MoudleInfo> ListInfo = new List<MoudleInfo>();
            string role = RoleId;
            if (role == "")
                role = "0";
            string sql = _SelectSql + " where moudleid in (Select moudleid From rolemoudleinfo where roleid in (" + role + ")) order by Sort";
            using (DbDataReader reader = DataBaseManage.ExecuteReader(sql))
            {
                while (reader.Read())
                {
                    ListInfo.Add(BuilderEntity(reader));
                }
            }
            return ListInfo;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="MoudleId"></param>
        /// <returns></returns>
        public string GetCurrentLocation(string MoudleId)
        {
            string strSQL = "select CONCAT((Select moudlename From moudleinfo Where moudleid =t.parentid ),'>>',t.moudlename) Location from moudleinfo t Where t.moudleid='" + MoudleId + "'";
            string Location = "";
            using (DbDataReader reader = DataBaseManage.ExecuteReader(strSQL))
            {
                while (reader.Read())
                {
                    Location = (reader.IsDBNull(reader.GetOrdinal("Location"))) ? "" : reader["Location"].ToString();
                }
            }
            return Location;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private MoudleInfo BuilderEntity(DbDataReader reader)
        {
            MoudleInfo info = new MoudleInfo();

            info.MoudleId = (reader.IsDBNull(reader.GetOrdinal("moudleid"))) ? "" : reader["moudleid"].ToString();
            info.MoudleName = (reader.IsDBNull(reader.GetOrdinal("moudlename"))) ? "" : reader["moudlename"].ToString();
            info.Url = (reader.IsDBNull(reader.GetOrdinal("url"))) ? "" : reader["url"].ToString();
            info.ParentId = (reader.IsDBNull(reader.GetOrdinal("parentid"))) ? "" : reader["parentid"].ToString();
            info.Img = (reader.IsDBNull(reader.GetOrdinal("img"))) ? "" : reader["img"].ToString();
            info.IsEnable = (reader.IsDBNull(reader.GetOrdinal("isenable"))) ? "" : reader["isenable"].ToString();
            info.IsRoot = (reader.IsDBNull(reader.GetOrdinal("isroot"))) ? "" : reader["isroot"].ToString();
            info.Sort = (reader.IsDBNull(reader.GetOrdinal("Sort"))) ? "" : reader["Sort"].ToString();
            info.YWLX = (reader.IsDBNull(reader.GetOrdinal("ywlx"))) ? "" : reader["ywlx"].ToString();
            return info;
        }
    }
}
