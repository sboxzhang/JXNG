
using System;
using System.Text;
using System.Reflection;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using AYJZ.Entities;
using JITE.CIS.Framework.DBProviders;
using System.Data.Common;
namespace AYJZ.DataAccess
{
    public partial class ayjz_employeeinfoDao:IDataAccess
    {
        const bool isDebug = true;
        private static readonly string DalSql = "SELECT ID,XM,SFZH,FWGZ,KHZT,KHYXQ,SFHMD,KHFZDZ,FWNR,FWXX,BM,GLF,HYLX,FWXX1,FWXX2,FWXX3 FROM ayjz_employeeinfo where 1=1 ";
        
    
        private int RunCommandWithTransatcion(ayjz_employeeinfoInfo ent, string vSql, IDbTransaction TRANS)
        {
            if (null == TRANS)
            {
                MySqlParameter[] paras = new MySqlParameter[ent.Column.Count];
                for (int i = 0; i < ent.Column.Count; i++)
                {
                    paras[i] = new MySqlParameter();
                    paras[i].ParameterName = ent.Column[i].FieldName;
                    paras[i].DbType = ent.Column[i].FieldType;
                    paras[i].Value = ent.Column[i].FieldValue;
                }
                return  DataBaseManage.ExecuteSql(vSql, paras);
            }
            else
            {
                System.Data.IDbCommand CM = TRANS.Connection.CreateCommand();
                CM.CommandText = vSql;
                CM.CommandType = CommandType.Text;
                CM.Transaction = TRANS;
                GetEntityDeleteParameter(CM, ent);
                try
                {
                    return CM.ExecuteNonQuery();
                }
                catch (System.Exception e)
                {
                    if (isDebug)
                        throw new Exception(e.Message);
                    return 0;
                }
            }
        }

        public int Insert(BaseEntitie ent, IDbTransaction TRANS)
        {
            StringBuilder insSQL = new StringBuilder(" INSERT INTO ayjz_employeeinfo (");
            bool isFirstValue = true;
            StringBuilder sp = new StringBuilder();
            ColumnCollection _column = ent.Column;
            for (int i = 0; i < _column.Count; i++)
            {
                if (isFirstValue)
                {
                    isFirstValue = false;
                    insSQL.Append(_column[i].FieldName);
                    sp.Append("@" + _column[i].FieldName);
                }
                else
                {
                    insSQL.Append("," + _column[i].FieldName);
                    sp.Append(",@" + _column[i].FieldName);
                }
            }
            insSQL.Append(") values (" + sp.ToString() + ")");
            return RunCommandWithTransatcion((ayjz_employeeinfoInfo)ent, insSQL.ToString(), TRANS);
        }

        public int Delete(BaseEntitie ent, IDbTransaction TRANS)
        {
            string s_DelSQL = " DELETE FROM ayjz_employeeinfo   WHERE  ID=@ID ";
            return RunCommandWithTransatcion((ayjz_employeeinfoInfo)ent, s_DelSQL, TRANS);
        }

        public int Update(BaseEntitie ent, IDbTransaction TRANS)
        {
            StringBuilder s_UpdSQL = new StringBuilder(" UPDATE ayjz_employeeinfo SET ");
            bool isFirstValue = true;
            ColumnCollection _column = ent.Column;//entity.TableFieldsName;
            for (int i = 0; i < _column.Count; i++)
            {
                if (isFirstValue)
                {
                    isFirstValue = false;
                    s_UpdSQL.Append(_column[i].FieldName);
                    s_UpdSQL.Append("=");
                    s_UpdSQL.Append("@" + _column[i].FieldName);
                }
                else
                {
                    s_UpdSQL.Append("," + _column[i].FieldName);
                    s_UpdSQL.Append("=");
                    s_UpdSQL.Append("@" + _column[i].FieldName);
                }
            }
            s_UpdSQL.Append("    WHERE  ID=@ID  ");
            return RunCommandWithTransatcion((ayjz_employeeinfoInfo)ent, s_UpdSQL.ToString(), TRANS);
        }

        /// <summary>
        /// 根据Id得到
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public ayjz_employeeinfoInfo Getayjz_employeeinfo( long ID)
        {
              ayjz_employeeinfoInfo ent = null;
            string sql = DalSql;
            sql = sql + " And  ID=@ID ";
            MySqlParameter[] paras = new MySqlParameter[]
            {
                new MySqlParameter("ID",ID)
            };
            using(DbDataReader reader = DataBaseManage.ExecuteReader(sql, paras))
			{
				if (reader.Read())
				{
					ent = new ayjz_employeeinfoInfo();
                    SetEnt(ent, reader);
				}
				
       		}
            return ent;
        }

        /// <summary>
        /// 得到列表
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public List<ayjz_employeeinfoInfo> Getayjz_employeeinfoList(string Where)
        {
            List<ayjz_employeeinfoInfo> list = new List<ayjz_employeeinfoInfo>();
            using(DbDataReader reader = DataBaseManage.ExecuteReader(DalSql+Where))
			{
                while (reader.Read())
                {
                   ayjz_employeeinfoInfo ent = new ayjz_employeeinfoInfo();
                    SetEnt(ent, reader);
                    list.Add(ent);
                }
            }
            return list;
        }

        public void SetEnt(ayjz_employeeinfoInfo ent, IDataReader dr)
        {
            ent.ID = MyConvert.ToLong(dr["ID"]);
            ent.XM = MyConvert.ToString(dr["XM"]);
            ent.SFZH = MyConvert.ToString(dr["SFZH"]);
            ent.FWGZ = MyConvert.ToString(dr["FWGZ"]);
            ent.KHZT = MyConvert.ToString(dr["KHZT"]);
            ent.KHYXQ = MyConvert.ToString(dr["KHYXQ"]);
            ent.SFHMD = MyConvert.ToString(dr["SFHMD"]);
            ent.KHFZDZ = MyConvert.ToString(dr["KHFZDZ"]);
            ent.FWNR = MyConvert.ToString(dr["FWNR"]);
            ent.FWXX = MyConvert.ToString(dr["FWXX"]);
            ent.BM = MyConvert.ToString(dr["BM"]);
            ent.GLF = MyConvert.ToString(dr["GLF"]);
            ent.HYLX = MyConvert.ToString(dr["HYLX"]);
            ent.FWXX1 = MyConvert.ToString(dr["FWXX1"]);
            ent.FWXX2 = MyConvert.ToString(dr["FWXX2"]);
            ent.FWXX3 = MyConvert.ToString(dr["FWXX3"]);
        }

        private IDbDataParameter _CreateParameter(string szParameter, object sdtObject, ParameterDirection pdDirection, System.Data.IDbDataParameter sParameter)
        {
            sParameter.ParameterName = szParameter;
            sParameter.Value = sdtObject;
            sParameter.Direction = pdDirection;
            return sParameter;
        }

        protected virtual void GetEntityDeleteParameter(System.Data.IDbCommand CM, BaseEntitie ent)
        {
            ColumnCollection _column = ent.Column;
            for (int i = 0; i < _column.Count; i++)
            {
                System.Data.IDbDataParameter sParameter = CM.CreateParameter();
                sParameter.ParameterName = _column[i].FieldName;
                sParameter.Value = _column[i].FieldValue;
                sParameter.DbType = _column[i].FieldType;
                CM.Parameters.Add(sParameter);
            }
        }       
    }
}
