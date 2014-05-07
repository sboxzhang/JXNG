
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
    public partial class ayjz_htxxDao:IDataAccess
    {
        const bool isDebug = true;
        private static readonly string DalSql = "SELECT ID,EIID,SFZ,LXDH,DZ,KSSJ,JSSJ,GZXX,DJ,AYID,NL,YBGZ,BZ,HTZT,SFSP FROM ayjz_htxx where 1=1 ";
        
    
        private int RunCommandWithTransatcion(ayjz_htxxInfo ent, string vSql, IDbTransaction TRANS)
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
            StringBuilder insSQL = new StringBuilder(" INSERT INTO ayjz_htxx (");
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
            return RunCommandWithTransatcion((ayjz_htxxInfo)ent, insSQL.ToString(), TRANS);
        }

        public int Delete(BaseEntitie ent, IDbTransaction TRANS)
        {
            string s_DelSQL = " DELETE FROM ayjz_htxx   WHERE  ID=@ID ";
            return RunCommandWithTransatcion((ayjz_htxxInfo)ent, s_DelSQL, TRANS);
        }

        public int Update(BaseEntitie ent, IDbTransaction TRANS)
        {
            StringBuilder s_UpdSQL = new StringBuilder(" UPDATE ayjz_htxx SET ");
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
            return RunCommandWithTransatcion((ayjz_htxxInfo)ent, s_UpdSQL.ToString(), TRANS);
        }

        /// <summary>
        /// 根据Id得到
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public ayjz_htxxInfo Getayjz_htxx( long ID)
        {
              ayjz_htxxInfo ent = null;
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
					ent = new ayjz_htxxInfo();
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
        public List<ayjz_htxxInfo> Getayjz_htxxList(string Where)
        {
            List<ayjz_htxxInfo> list = new List<ayjz_htxxInfo>();
            using(DbDataReader reader = DataBaseManage.ExecuteReader(DalSql+Where))
			{
                while (reader.Read())
                {
                   ayjz_htxxInfo ent = new ayjz_htxxInfo();
                    SetEnt(ent, reader);
                    list.Add(ent);
                }
            }
            return list;
        }

        public void SetEnt(ayjz_htxxInfo ent, IDataReader dr)
        {
            ent.ID = MyConvert.ToLong(dr["ID"]);
            ent.EIID = MyConvert.ToLong(dr["EIID"]);
            ent.SFZ = MyConvert.ToString(dr["SFZ"]);
            ent.LXDH = MyConvert.ToString(dr["LXDH"]);
            ent.DZ = MyConvert.ToString(dr["DZ"]);
            ent.KSSJ = MyConvert.ToString(dr["KSSJ"]);
            ent.JSSJ = MyConvert.ToString(dr["JSSJ"]);
            ent.GZXX = MyConvert.ToString(dr["GZXX"]);
            ent.DJ = MyConvert.ToDecimal(dr["DJ"]);
            ent.AYID = MyConvert.ToLong(dr["AYID"]);
            ent.NL = MyConvert.ToLong(dr["NL"]);
            ent.YBGZ = MyConvert.ToString(dr["YBGZ"]);
            ent.BZ = MyConvert.ToString(dr["BZ"]);
            ent.HTZT = MyConvert.ToString(dr["HTZT"]);
            ent.SFSP = MyConvert.ToString(dr["SFSP"]);
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
