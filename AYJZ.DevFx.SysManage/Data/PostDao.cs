using System;
using System.Collections.Generic;

using System.Text;
using JITE.CIS.Framework.DBProviders;
using System.Data.Common;
namespace VSM.DevFx.SysManage
{
    partial class PostDao
    {
        private static readonly string _SelectSql = "Select code, Name, isenable,remark From postinfo ";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool CreatePost(PostInfo info)
        {
            StringBuilder Sql = new StringBuilder();
            Sql.Append("  Insert Into postinfo  ");
            Sql.Append("    (code, Name,remark,isenable)  ");
            Sql.Append("  Values  ");
            Sql.Append("    (  ");
            Sql.Append("     '" + info.Code + "',  ");
            Sql.Append("     '" + info.Name + "' , ");
            Sql.Append("     '" + info.Remark + "' , ");
            Sql.Append("    '" + info.IsEnable + "' ");
            Sql.Append("    )  ");

            return DataBaseManage.ExecuteSql(Sql.ToString()) > 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool ModifyPost(PostInfo info)
        {
            string Sql = string.Format("Update postinfo Set Name = '{1}',remark='{2}', isenable = '{3}' Where code = '{0}'", info.Code, info.Name,info.Remark, info.IsEnable);
            return DataBaseManage.ExecuteSql(Sql) > 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public bool DeletePost(string Code)
        {
            string Sql = string.Format("Delete postinfo Where code = '{0}'", Code.Trim());
            return DataBaseManage.ExecuteSql(Sql) > 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public PostInfo GetPostInfo(string Code)
        {
            PostInfo info = null;
            string Sql = _SelectSql + string.Format(" where code = '{0}'",Code.Trim());
            using (DbDataReader reader = DataBaseManage.ExecuteReader(Sql))
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
        public List<PostInfo> GetPostInfoAll()
        {
            List<PostInfo> list = new List<PostInfo>();
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
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private PostInfo BuilderEntity(DbDataReader reader)
        {
            PostInfo info = new PostInfo();

            info.Code = (reader.IsDBNull(reader.GetOrdinal("code"))) ? "" : reader["code"].ToString();
            info.Name = (reader.IsDBNull(reader.GetOrdinal("name"))) ? "" : reader["name"].ToString();
            info.IsEnable = (reader.IsDBNull(reader.GetOrdinal("isenable"))) ? "" : reader["isenable"].ToString();
            info.Remark = (reader.IsDBNull(reader.GetOrdinal("remark"))) ? "" : reader["remark"].ToString();
            return info;
        }
    }
}
