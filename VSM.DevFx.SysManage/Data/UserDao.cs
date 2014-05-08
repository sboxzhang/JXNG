using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Data ;
using System.Data .SqlClient ;
using JITE.CIS.Framework.DBProviders;
namespace VSM.DevFx.SysManage
{
    public class UserDao
    {
        private static readonly string _SelectSql = "Select userid, usercode, username, Password, email, address, deptid,(Select deptname From deptinfo Where deptid=a.deptid) deptname,(Select parentid From deptinfo Where deptid=a.deptid) company, postcode, telephone, mobile,(Select Name From postinfo Where code=postcode) postname,ISENABLE,ZD From userinfo a";
        /// <summary>
        /// 创建新用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool CreateUser(UserInfo info)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("    Insert Into userinfo ");
            sql.Append("        ( usercode, username, Password, email, address, deptid, postcode, telephone, mobile,ZD) ");
            sql.Append("    Values( ");
            sql.Append("         '" + info.UserCode + "',");
            sql.Append("         '" + info.UserName + "',");
            sql.Append("         '123',");
            sql.Append("         '" + info.Email + "',");
            sql.Append("         '" + info.Address + "',");
            sql.Append("         '" + info.DeptId + "',");
            sql.Append("         '" + info.PostCode + "',");
            sql.Append("         '" + info.Telephone + "',");
            sql.Append("         '" + info.Mobile + "',");
            sql.Append("         '" + info.ZD + "'");
            sql.Append("    ) ");

            return DataBaseManage.ExecuteSql(sql.ToString()) > 0;
        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool ModifyUser(UserInfo info)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" Update userinfo ");
            sql.Append("    Set ");
            sql.Append("        username = '" + info.UserName + "', ");
            sql.Append("        email = '" + info.Email + "', ");
            sql.Append("        address = '" + info.Address + "', ");
            sql.Append("        deptid = '" + info.DeptId + "',");
            sql.Append("        postcode = '" + info.PostCode + "',");
            sql.Append("        telephone = '" + info.Telephone + "',");
            sql.Append("        ZD = '" + info.ZD + "',");
            sql.Append("        mobile = '" + info.Mobile + "'");
            sql.Append("   Where userid = '" + info.UserId + "'");
            return DataBaseManage.ExecuteSql(sql.ToString()) > 0;
        }
        /// <summary>
        ///修改密码
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="OldPassword"></param>
        /// <param name="NewPassword"></param>
        /// <returns></returns>
        public bool ModifyPassword(string UserCode, string NewPassword)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("    Update userinfo ");
            sql.Append("    Set Password = '" + NewPassword + "'");
            sql.Append("     Where usercode = '" + UserCode + "'");
            return DataBaseManage.ExecuteSql(sql.ToString()) > 0; 
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public bool DeleteUser(string UserId)
        {
            string Sql = string.Format("Delete userinfo Where userid = '{0}'", UserId);
            return DataBaseManage.ExecuteSql(Sql) > 0;
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="UserCode"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public UserInfo Login(string UserCode,string Password)
        {
            UserInfo info = null;
            StringBuilder Sql = new StringBuilder();
            Sql.Append(_SelectSql);
            Sql.Append(" where ISENABLE ='Y' ");
            Sql.Append(" and Upper(usercode)='" + UserCode.ToUpper() + "'");
            Sql.Append(" and Password='" + Password + "'");
            using (DbDataReader reader = DataBaseManage.ExecuteReader(Sql.ToString()))
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        info = BuilderEntity(reader);
                    }
                }
            }
            return info;
        }
        /// <summary>
        /// 取得所有用户
        /// </summary>
        /// <returns></returns>
        public List<UserInfo> GetUserAll()
        {
            List<UserInfo> list = new List<UserInfo>();
            string sql = _SelectSql + " where ISENABLE ='Y' ";
            using (DbDataReader reader = DataBaseManage.ExecuteReader(sql))
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
        /// 更加条件取得用户信息
        /// </summary>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public List<UserInfo> GetUserByCondition(UserInfo Condition)
        {
            List<UserInfo> list = new List<UserInfo>();
            StringBuilder Sql = new StringBuilder();
            Sql.Append(_SelectSql);
            Sql.Append(" where 1=1 ");
            if (Condition != null)
            {
                if (Condition.UserId.ToString() != "0")
                    Sql.Append("    and userid='" + Condition.UserId.ToString() + "'");
                if (!string.IsNullOrEmpty(Condition.DeptId) && Condition.DeptId != "0")
                    Sql.Append("    and deptid='" + Condition.DeptId.ToString() + "'");
                if (Condition.UserCode != "")
                    Sql.Append("    and usercode like '%" + Condition.UserCode + "%'");
                if (Condition.UserName != "")
                    Sql.Append("    and username like '%" + Condition.UserName + "%'");
                if (Condition.Telephone != "")
                    Sql.Append("    and telephone like '%" + Condition.Telephone + "%'");
                if (Condition.PostCode != "")
                    Sql.Append("    and postcode = '" + Condition.PostCode + "'");
                if (Condition.Email != "")
                    Sql.Append("    and email like '%" + Condition.Email + "%'");
                if (Condition.Address != "")
                    Sql.Append("    and address like '%" + Condition.Address + "%'");
                if (Condition.Mobile != "")
                    Sql.Append("    and mobile like '%" + Condition.Mobile + "%'");
                if (Condition.IsEnable.ToString() != "")
                    Sql.Append("    and ISENABLE='" + Condition.IsEnable.ToString() + "'");
                if (!string.IsNullOrEmpty(Condition.ZD))
                    Sql.Append("    and ZD='" + Condition.ZD + "'");
                //else
                //    Sql.Append("    and ISENABLE='Y'");
            }
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
        /// 根据ID取得单个用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserInfo GetUserInfo(string id)
        {
            UserInfo info = null;
            string sql = _SelectSql + " where userid='" + id + "'";
            using (DbDataReader reader = DataBaseManage.ExecuteReader(sql))
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        info = BuilderEntity(reader);
                    }
                }
            }
            return info;
        }

        /// <summary>
        /// 根据DeptID取得user信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetUserInfoByDeptID(string deptid)
        {

            string sql = _SelectSql + " where deptid='" + deptid + "'";
            return DataBaseManage.ExecuteDataSet(sql).Tables[0];
        }
        /// <summary>
        /// 根据用户代码取得单个用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserInfo GetUserInfoByUserCode(string UserCode)
        {
            UserInfo info = null;
            string sql = _SelectSql + " where usercode='" + UserCode + "'";
            using (DbDataReader reader = DataBaseManage.ExecuteReader(sql))
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        info = BuilderEntity(reader);
                    }

                }
            }
            return info;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private UserInfo BuilderEntity(DbDataReader reader)
        {
            UserInfo info = new UserInfo();

            info.UserId = (reader.IsDBNull(reader.GetOrdinal("userid"))) ? int.Parse("0") : int.Parse(reader["userid"].ToString());
            info.DeptId = (reader.IsDBNull(reader.GetOrdinal("deptid"))) ? "" : reader["deptid"].ToString();
            info.UserCode = (reader.IsDBNull(reader.GetOrdinal("usercode"))) ? "" : reader["usercode"].ToString();
            info.UserName = (reader.IsDBNull(reader.GetOrdinal("username"))) ? "" : reader["username"].ToString();
            info.Password = (reader.IsDBNull(reader.GetOrdinal("Password"))) ? "" : reader["Password"].ToString();
            info.Email = (reader.IsDBNull(reader.GetOrdinal("email"))) ? "" : reader["email"].ToString();
            info.Address = (reader.IsDBNull(reader.GetOrdinal("address"))) ? "" : reader["address"].ToString();
            info.PostCode = (reader.IsDBNull(reader.GetOrdinal("postcode"))) ? "" : reader["postcode"].ToString();
            info.Telephone = (reader.IsDBNull(reader.GetOrdinal("telephone"))) ? "" : reader["telephone"].ToString();
            info.Mobile = (reader.IsDBNull(reader.GetOrdinal("mobile"))) ? "" : reader["mobile"].ToString();
            info.Company = (reader.IsDBNull(reader.GetOrdinal("company"))) ? "" : reader["company"].ToString();
            info.DeptName = (reader.IsDBNull(reader.GetOrdinal("deptname"))) ? "" : reader["deptname"].ToString();
            info.PostName = (reader.IsDBNull(reader.GetOrdinal("postname"))) ? "" : reader["postname"].ToString();
            info.IsEnable = (reader.IsDBNull(reader.GetOrdinal("ISENABLE"))) ? "" : reader["ISENABLE"].ToString();
            info.ZD = (reader.IsDBNull(reader.GetOrdinal("ZD"))) ? "" : reader["ZD"].ToString();
            return info;
        }
    }
}
