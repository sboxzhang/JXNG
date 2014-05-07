
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
    public partial class ayjz_d_lxsjDao:IDataAccess
    {
        const bool isDebug = true;
        private static readonly string DalSql = "SELECT ID,EIID,LXDH,LX FROM ayjz_d_lxsj where 1=1 ";
        
    
        private int RunCommandWithTransatcion(ayjz_d_lxsjInfo ent, string vSql, IDbTransaction TRANS)
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
            StringBuilder insSQL = new StringBuilder(" INSERT INTO ayjz_d_lxsj (");
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
            return RunCommandWithTransatcion((ayjz_d_lxsjInfo)ent, insSQL.ToString(), TRANS);
        }

        public int Delete(BaseEntitie ent, IDbTransaction TRANS)
        {
            string s_DelSQL = " DELETE FROM ayjz_d_lxsj   WHERE  ID=@ID ";
            return RunCommandWithTransatcion((ayjz_d_lxsjInfo)ent, s_DelSQL, TRANS);
        }

        public int Update(BaseEntitie ent, IDbTransaction TRANS)
        {
            StringBuilder s_UpdSQL = new StringBuilder(" UPDATE ayjz_d_lxsj SET ");
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
            return RunCommandWithTransatcion((ayjz_d_lxsjInfo)ent, s_UpdSQL.ToString(), TRANS);
        }

        /// <summary>
        /// 根据Id得到
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public ayjz_d_lxsjInfo Getayjz_d_lxsj( long ID)
        {
              ayjz_d_lxsjInfo ent = null;
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
					ent = new ayjz_d_lxsjInfo();
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
        public List<ayjz_d_lxsjInfo> Getayjz_d_lxsjList(string Where)
        {
            List<ayjz_d_lxsjInfo> list = new List<ayjz_d_lxsjInfo>();
            using(DbDataReader reader = DataBaseManage.ExecuteReader(DalSql+Where))
			{
                while (reader.Read())
                {
                   ayjz_d_lxsjInfo ent = new ayjz_d_lxsjInfo();
                    SetEnt(ent, reader);
                    list.Add(ent);
                }
            }
            return list;
        }

        public void SetEnt(ayjz_d_lxsjInfo ent, IDataReader dr)
        {
            ent.ID = MyConvert.ToLong(dr["ID"]);
            ent.EIID = MyConvert.ToLong(dr["EIID"]);
            ent.LXDH = MyConvert.ToLong(dr["LXDH"]);
            ent.LX = MyConvert.ToString(dr["LX"]);
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
