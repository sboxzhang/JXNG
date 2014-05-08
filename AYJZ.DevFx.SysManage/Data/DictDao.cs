using System;
using System.Collections.Generic;
using System.Text;
using JITE.CIS.Framework.DBProviders;
using System.Data.Common;
namespace VSM.DevFx.SysManage
{
    partial class DictDao
    {
        #region =======字典维护=========
        
        private static readonly string _SelectSql = "select a.code,a.name,a.type,a.remark,a.sort,a.isenable,(Select b.Name From dicttypeinfo b Where b.code=a.type) typename from dictinfo a";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool CreateDict(DictInfo info)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" Insert Into dictinfo ");
            sql.Append("    (code, Name, Type, remark, Sort, isenable) ");
            sql.Append(" Values ");
            sql.Append("    ( ");
            sql.Append("     '" + info.Code + "',");
            sql.Append("     '" + info.Name + "',");
            sql.Append("     '" + info.TypeCode + "',");
            sql.Append("     '" + info.Remark + "',");
            sql.Append("     '" + info.Sort + "',");
            sql.Append("     '" + info.IsEnable + "'");
            sql.Append("    )");
            return DataBaseManage.ExecuteSql(sql.ToString()) > 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool ModifyDict(DictInfo info)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Update dictinfo ");
            sql.Append("   Set Name = '" + info.Name + "',");
            sql.Append("       Type = '" + info.TypeCode + "',");
            sql.Append("       remark = '" + info.Remark + "',");
            sql.Append("       Sort = '" + info.Sort + "',");
            sql.Append("       isenable = '" + info.IsEnable + "'");
            sql.Append(" Where code = '" + info.Code + "' and Type='" + info.TypeCode + "'");
            return DataBaseManage.ExecuteSql(sql.ToString()) > 0;
        }
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public bool DeleteDict(string Code,string Type)
        {
            string sql = string.Format(" Update dictinfo  Set  isenable = 'N' Where code = '{0}' and Type='{1}'", Code, Type);
            return DataBaseManage.ExecuteSql(sql) > 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public DictInfo GetDictInfo(string Code,string Type)
        {
            DictInfo info = null;
            string sql = _SelectSql + string.Format(" where code='{0}' and Type='{1}'", Code, Type);
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
        /// <param name="Condition"></param>
        /// <returns></returns>
        public List<DictInfo> GetDictInfoByCondition(DictInfo Condition)
        {
            List<DictInfo> list = new List<DictInfo>();
            StringBuilder Sql = new StringBuilder();
            Sql.Append(_SelectSql);
            Sql.Append("    where 1=1 ");
            if (Condition != null)
            {
                if (Condition.Code.Trim() != "")
                    Sql.Append("    and code='" + Condition.Code.Trim() + "'");
                if (Condition.Name.Trim() != "")
                    Sql.Append("    and Name like '%" + Condition.Name.Trim() + "%'");
                if (Condition.TypeCode != "")
                    Sql.Append("    and Type = '" + Condition.TypeCode + "'");
                if (Condition.IsEnable != "")
                    Sql.Append("    and isenable = '" + Condition.IsEnable + "'");
                else
                    Sql.Append("    and isenable='Y' ");
            }
            Sql.Append(" Order By Type,Sort ");
            using (DbDataReader reader = DataBaseManage.ExecuteReader(Sql.ToString()))
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
        private DictInfo BuilderEntity(DbDataReader reader)
        {
            DictInfo info = new DictInfo();

            info.Code = (reader.IsDBNull(reader.GetOrdinal("code"))) ? "" : reader["code"].ToString();
            info.Name = (reader.IsDBNull(reader.GetOrdinal("name"))) ? "" : reader["name"].ToString();
            info.Remark = (reader.IsDBNull(reader.GetOrdinal("remark"))) ? "" : reader["remark"].ToString();
            info.Sort = (reader.IsDBNull(reader.GetOrdinal("sort"))) ? 0 : decimal.Parse(reader["sort"].ToString());
            info.IsEnable = (reader.IsDBNull(reader.GetOrdinal("isenable"))) ? "" : reader["isenable"].ToString();
            info.TypeCode = (reader.IsDBNull(reader.GetOrdinal("type"))) ? "" : reader["type"].ToString();
            info.TypeName = (reader.IsDBNull(reader.GetOrdinal("typename"))) ? "" : reader["typename"].ToString();

            return info;
        }
        #endregion

        #region ======字典类型维护=====

        private static readonly string _SelectSql2 = "Select code, Name From dicttypeinfo";

        public bool CreateDictType(DictTypeInfo info)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" Insert Into dicttypeinfo ");
            sql.Append("    (code, Name) ");
            sql.Append(" Values ");
            sql.Append("    ( ");
            sql.Append("     '" + info.Code + "',");
            sql.Append("     '" + info.Name + "'");
            sql.Append("    )");
            return DataBaseManage.ExecuteSql(sql.ToString()) > 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool ModifyDictType(DictTypeInfo info)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Update dicttypeinfo ");
            sql.Append("   Set Name = '" + info.Name + "'");
            sql.Append(" Where code = '" + info.Code + "'");
            return DataBaseManage.ExecuteSql(sql.ToString()) > 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public bool DeleteDictType(string Code)
        {
            string sql = string.Format("Delete dicttypeinfo Where code = '{0}'", Code);
            return DataBaseManage.ExecuteSql(sql) > 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public DictTypeInfo GetDictTypeInfo(string Code)
        {
            DictTypeInfo info = null;
            string sql = _SelectSql2 + string.Format(" Where code = '{0}'", Code);
            using (DbDataReader reader = DataBaseManage.ExecuteReader(sql))
            {
                if (reader.Read())
                {
                    info = BuilderDictType(reader);
                }
            }
            return info;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public List<DictTypeInfo> GetDictTypeInfoAll()
        {
            List<DictTypeInfo> list = new List<DictTypeInfo>();
            using (DbDataReader reader = DataBaseManage.ExecuteReader(_SelectSql2))
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        list.Add(BuilderDictType(reader));
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
        private DictTypeInfo BuilderDictType(DbDataReader reader)
        {
            DictTypeInfo info = new DictTypeInfo();

            info.Code = (reader.IsDBNull(reader.GetOrdinal("code"))) ? "" : reader["code"].ToString();
            info.Name = (reader.IsDBNull(reader.GetOrdinal("name"))) ? "" : reader["name"].ToString();

            return info;
        }
        #endregion
    }
}