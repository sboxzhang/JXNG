
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
    public partial class ayjz_ayzhxxDao:IDataAccess
    {
        const bool isDebug = true;
        private static readonly string DalSql = "SELECT ID,XM,XB,SFZH,HYZK,MZ,YHCD,SG,TZ,ZTCY,SFHMD,SJZDQR,JKZBH,BLYY,BSYSQ,BSGMQ,SS,XZZ,HJDZ,FWGZ,FWNR,BM,GX,FP FROM ayjz_ayzhxx where 1=1 ";
        
    
        private int RunCommandWithTransatcion(ayjz_ayzhxxInfo ent, string vSql, IDbTransaction TRANS)
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
            StringBuilder insSQL = new StringBuilder(" INSERT INTO ayjz_ayzhxx (");
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
            return RunCommandWithTransatcion((ayjz_ayzhxxInfo)ent, insSQL.ToString(), TRANS);
        }

        public int Delete(BaseEntitie ent, IDbTransaction TRANS)
        {
            string s_DelSQL = " DELETE FROM ayjz_ayzhxx   WHERE  ID=@ID ";
            return RunCommandWithTransatcion((ayjz_ayzhxxInfo)ent, s_DelSQL, TRANS);
        }

        public int Update(BaseEntitie ent, IDbTransaction TRANS)
        {
            StringBuilder s_UpdSQL = new StringBuilder(" UPDATE ayjz_ayzhxx SET ");
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
            return RunCommandWithTransatcion((ayjz_ayzhxxInfo)ent, s_UpdSQL.ToString(), TRANS);
        }

        /// <summary>
        /// 根据Id得到
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public ayjz_ayzhxxInfo Getayjz_ayzhxx( long ID)
        {
              ayjz_ayzhxxInfo ent = null;
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
					ent = new ayjz_ayzhxxInfo();
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
        public List<ayjz_ayzhxxInfo> Getayjz_ayzhxxList(string Where)
        {
            List<ayjz_ayzhxxInfo> list = new List<ayjz_ayzhxxInfo>();
            using(DbDataReader reader = DataBaseManage.ExecuteReader(DalSql+Where))
			{
                while (reader.Read())
                {
                   ayjz_ayzhxxInfo ent = new ayjz_ayzhxxInfo();
                    SetEnt(ent, reader);
                    list.Add(ent);
                }
            }
            return list;
        }

        public void SetEnt(ayjz_ayzhxxInfo ent, IDataReader dr)
        {
            ent.ID = MyConvert.ToLong(dr["ID"]);
            ent.XM = MyConvert.ToString(dr["XM"]);
            ent.XB = MyConvert.ToString(dr["XB"]);
            ent.SFZH = MyConvert.ToString(dr["SFZH"]);
            ent.HYZK = MyConvert.ToString(dr["HYZK"]);
            ent.MZ = MyConvert.ToString(dr["MZ"]);
            ent.YHCD = MyConvert.ToString(dr["YHCD"]);
            ent.SG = MyConvert.ToString(dr["SG"]);
            ent.TZ = MyConvert.ToString(dr["TZ"]);
            ent.ZTCY = MyConvert.ToString(dr["ZTCY"]);
            ent.SFHMD = MyConvert.ToString(dr["SFHMD"]);
            ent.SJZDQR = MyConvert.ToString(dr["SJZDQR"]);
            ent.JKZBH = MyConvert.ToString(dr["JKZBH"]);
            ent.BLYY = MyConvert.ToString(dr["BLYY"]);
            ent.BSYSQ = MyConvert.ToString(dr["BSYSQ"]);
            ent.BSGMQ = MyConvert.ToString(dr["BSGMQ"]);
            ent.SS = MyConvert.ToString(dr["SS"]);
            ent.XZZ = MyConvert.ToString(dr["XZZ"]);
            ent.HJDZ = MyConvert.ToString(dr["HJDZ"]);
            ent.FWGZ = MyConvert.ToString(dr["FWGZ"]);
            ent.FWNR = MyConvert.ToString(dr["FWNR"]);
            ent.BM = MyConvert.ToString(dr["BM"]);
            ent.GX = MyConvert.ToString(dr["GX"]);
            ent.FP = MyConvert.ToString(dr["FP"]);
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
