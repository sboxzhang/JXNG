using System; 
using System.Text;
using System.Reflection;
using System.Collections.Generic; 
using System.Data;
using MySql.Data.MySqlClient;
using VSM.Entities;
using System.Data.Common;
using JITE.CIS.Framework.DBProviders;
namespace VSM.DataAccess  
{	
	public partial class BuGPSLogDao : IDataAccess
	{
		const bool isDebug = true;
        private static readonly string DalSql = " Select GPSLogId,SynchronizationStatus,SynchronizationDate,SynchronizationInfo from BuGPSLog Where 1=1 ";
   		     
   		private int RunCommandWithTransatcion(VSM.Entities.BuGPSLog ent, string vSql, IDbTransaction TRANS)
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
            StringBuilder insSQL = new StringBuilder(" Insert Into BuGPSLog (");
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
            return RunCommandWithTransatcion((BuGPSLog)ent, insSQL.ToString(), TRANS);
        }
        
        public int Delete(BaseEntitie ent, IDbTransaction TRANS)
        {
            string s_DelSQL = " Delete From BuGPSLog Where GPSLogId = @GPSLogId";
            return RunCommandWithTransatcion((BuGPSLog)ent, s_DelSQL, TRANS);
        }
        
        public int Update(BaseEntitie ent, IDbTransaction TRANS)
        {
            StringBuilder s_UpdSQL = new StringBuilder(" Update BuGPSLog Set ");
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
            s_UpdSQL.Append(" WHERE GPSLogId = @GPSLogId");
            return RunCommandWithTransatcion((BuGPSLog)ent, s_UpdSQL.ToString(), TRANS);
        }
        
        /// <summary>
        /// 根据GPSLogId得到 BuGPSLog 实体
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public BuGPSLog GetBuGPSLog(int GPSLogId)
        {
            BuGPSLog ent = null;
            string sql = DalSql;
            sql = sql + " And  GPSLogId";
            MySqlParameter[] paras = new MySqlParameter[]
            {
                new MySqlParameter("GPSLogId",GPSLogId)
            };
            using(DbDataReader reader = DataBaseManage.ExecuteReader(sql, paras))
			{
				if (reader.Read())
				{
					ent = new BuGPSLog();
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
        public List<BuGPSLog> GetBuGPSLogList(string Where)
        {
            List<BuGPSLog> list = new List<BuGPSLog>();
            using(DbDataReader reader = DataBaseManage.ExecuteReader(DalSql+Where))
			{
                while (reader.Read())
                {
                   BuGPSLog ent = new BuGPSLog();
                    SetEnt(ent, reader);
                    list.Add(ent);
                }
            }
            return list;
        }

        public void SetEnt(BuGPSLog ent, IDataReader dr)
        {
			ent.GPSLogId = MyConvert.ToInt(dr["GPSLogId"]);
			ent.SynchronizationStatus = MyConvert.ToString(dr["SynchronizationStatus"]);
			ent.SynchronizationDate = MyConvert.ToDateTime(dr["SynchronizationDate"]);
			ent.SynchronizationInfo = MyConvert.ToString(dr["SynchronizationInfo"]);
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