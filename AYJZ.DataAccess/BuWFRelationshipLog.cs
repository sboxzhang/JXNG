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
	public partial class BuWFRelationshipLogDao : IDataAccess
	{
		const bool isDebug = true;
        private static readonly string DalSql = " Select LogId,RelationshipId,Status from BuWFRelationshipLog Where 1=1 ";
   		     
   		private int RunCommandWithTransatcion(VSM.Entities.BuWFRelationshipLog ent, string vSql, IDbTransaction TRANS)
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
            StringBuilder insSQL = new StringBuilder(" Insert Into BuWFRelationshipLog (");
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
            return RunCommandWithTransatcion((BuWFRelationshipLog)ent, insSQL.ToString(), TRANS);
        }
        
        public int Delete(BaseEntitie ent, IDbTransaction TRANS)
        {
            string s_DelSQL = " Delete From BuWFRelationshipLog Where LogId = @LogId";
            return RunCommandWithTransatcion((BuWFRelationshipLog)ent, s_DelSQL, TRANS);
        }
        
        public int Update(BaseEntitie ent, IDbTransaction TRANS)
        {
            StringBuilder s_UpdSQL = new StringBuilder(" Update BuWFRelationshipLog Set ");
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
            s_UpdSQL.Append(" WHERE LogId = @LogId");
            return RunCommandWithTransatcion((BuWFRelationshipLog)ent, s_UpdSQL.ToString(), TRANS);
        }
        
        /// <summary>
        /// 根据LogId得到 BuWFRelationshipLog 实体
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public BuWFRelationshipLog GetBuWFRelationshipLog(int LogId)
        {
            BuWFRelationshipLog ent = null;
            string sql = DalSql;
            sql = sql + " And  LogId";
            MySqlParameter[] paras = new MySqlParameter[]
            {
                new MySqlParameter("LogId",LogId)
            };
            using(DbDataReader reader = DataBaseManage.ExecuteReader(sql, paras))
			{
				if (reader.Read())
				{
					ent = new BuWFRelationshipLog();
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
        public List<BuWFRelationshipLog> GetBuWFRelationshipLogList(string Where)
        {
            List<BuWFRelationshipLog> list = new List<BuWFRelationshipLog>();
            using(DbDataReader reader = DataBaseManage.ExecuteReader(DalSql+Where))
			{
                while (reader.Read())
                {
                   BuWFRelationshipLog ent = new BuWFRelationshipLog();
                    SetEnt(ent, reader);
                    list.Add(ent);
                }
            }
            return list;
        }

        public void SetEnt(BuWFRelationshipLog ent, IDataReader dr)
        {
			ent.LogId = MyConvert.ToInt(dr["LogId"]);
			ent.RelationshipId = MyConvert.ToInt(dr["RelationshipId"]);
			ent.Status = MyConvert.ToInt(dr["Status"]);
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