using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using JITE.CIS.Framework.DBProviders;
using System.Data;

namespace VSM.DevFx.SysManage
{
    partial class DeptDao
    {
        private static readonly string _SelectSql = "Select deptid, deptname, IFNULL(parentid,'0') parentid, remark,DEPTTYPE From deptinfo";
        public bool CreateDept(DeptInfo info)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("    Insert Into deptinfo ");
            sql.Append("        ( deptid,deptname, parentid, remark,DEPTTYPE) ");
            sql.Append("    Values( ");
            sql.Append("         '" + info.DeptId + "',");
            sql.Append("         '" + info.DeptName + "',");
            sql.Append("         '" + info.ParentId + "',");
            sql.Append("         '" + info.Remark + "',");
            sql.Append("         '" + info.DeptType + "'");
            sql.Append("    ) ");
            return DataBaseManage.ExecuteSql(sql.ToString()) > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool ModifyDept(DeptInfo info)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" Update deptinfo ");
            sql.Append("    Set deptname = '" + info.DeptName + "',");
            sql.Append("        parentid = '" + info.ParentId + "', ");
            sql.Append("        remark = '" + info.Remark + "', ");
            sql.Append("        DEPTTYPE = '" + info.DeptType + "' ");
            sql.Append("   Where deptid = '" + info.DeptId + "'");
            return DataBaseManage.ExecuteSql(sql.ToString()) > 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public bool DeleteDept(string DeptId)
        {
            string sql = "Delete deptinfo Where deptid = '" + DeptId + "' Or parentid='" + DeptId + "'";
            return DataBaseManage.ExecuteSql(sql) > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="MoudleId"></param>
        /// <returns></returns>
        public DeptInfo GetDeptInfo(string DeptId)
        {
            DeptInfo info = null;
            string sql = _SelectSql + " where deptid='" + DeptId + "'";
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
        public List<DeptInfo> GetDeptAll()
        {
            List<DeptInfo> list = new List<DeptInfo>();
            using (DbDataReader reader = DataBaseManage.ExecuteReader(_SelectSql))
            {
                if (reader != null)
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
        /// 根据部门类型取得部门列表
        /// </summary>
        /// <param name="Type">部门类型</param>
        /// <returns></returns>
        public List<DeptInfo> GetDeptByType(string Type)
        {
            List<DeptInfo> list = new List<DeptInfo>();
            string Sql = _SelectSql + string.Format(" where DEPTTYPE='{0}'", Type);
            using (DbDataReader reader = DataBaseManage.ExecuteReader(Sql))
            {
                if (reader != null)
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
        /// <param name="reader"></param>
        /// <returns></returns>
        private DeptInfo BuilderEntity(DbDataReader reader)
        {
            DeptInfo info = new DeptInfo();

            info.DeptId = (reader.IsDBNull(reader.GetOrdinal("deptid"))) ? "" : reader["deptid"].ToString();
            info.DeptName = (reader.IsDBNull(reader.GetOrdinal("deptname"))) ? "" : reader["deptname"].ToString();
            info.ParentId = (reader.IsDBNull(reader.GetOrdinal("parentid"))) ? "" : reader["parentid"].ToString();
            info.Remark = (reader.IsDBNull(reader.GetOrdinal("remark"))) ? "" : reader["remark"].ToString();
            info.DeptType = (reader.IsDBNull(reader.GetOrdinal("DEPTTYPE"))) ? "" : reader["DEPTTYPE"].ToString();
            return info;
        }
    }
}