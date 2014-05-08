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
	public partial class BuTypeInfoDao : IDataAccess
	{
		const bool isDebug = true;
        private static readonly string DalSql = " Select TypeId,TypeName,KindId from BuTypeInfo Where 1=1 ";
   		     
   		private int RunCommandWithTransatcion(VSM.Entities.BuTypeInfo ent, string vSql, IDbTransaction TRANS)
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
            StringBuilder insSQL = new StringBuilder(" Insert Into BuTypeInfo (");
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
            return RunCommandWithTransatcion((BuTypeInfo)ent, insSQL.ToString(), TRANS);
        }
        
        public int Delete(BaseEntitie ent, IDbTransaction TRANS)
        {
            string s_DelSQL = " Delete From BuTypeInfo Where TypeId = @TypeId";
            return RunCommandWithTransatcion((BuTypeInfo)ent, s_DelSQL, TRANS);
        }
        
        public int Update(BaseEntitie ent, IDbTransaction TRANS)
        {
            StringBuilder s_UpdSQL = new StringBuilder(" Update BuTypeInfo Set ");
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
            s_UpdSQL.Append(" WHERE TypeId = @TypeId");
            return RunCommandWithTransatcion((BuTypeInfo)ent, s_UpdSQL.ToString(), TRANS);
        }
        
        /// <summary>
        /// 根据TypeId得到 BuTypeInfo 实体
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public BuTypeInfo GetBuTypeInfo(int TypeId)
        {
            BuTypeInfo ent = null;
            string sql = DalSql;
            sql = sql + " And  TypeId";
            MySqlParameter[] paras = new MySqlParameter[]
            {
                new MySqlParameter("TypeId",TypeId)
            };
            using(DbDataReader reader = DataBaseManage.ExecuteReader(sql, paras))
			{
				if (reader.Read())
				{
					ent = new BuTypeInfo();
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
        public List<BuTypeInfo> GetBuTypeInfoList(string Where)
        {
            List<BuTypeInfo> list = new List<BuTypeInfo>();
            using(DbDataReader reader = DataBaseManage.ExecuteReader(DalSql+Where))
			{
                while (reader.Read())
                {
                   BuTypeInfo ent = new BuTypeInfo();
                    SetEnt(ent, reader);
                    list.Add(ent);
                }
            }
            return list;
        }

        public void SetEnt(BuTypeInfo ent, IDataReader dr)
        {
			ent.TypeId = MyConvert.ToInt(dr["TypeId"]);
			ent.TypeName = MyConvert.ToString(dr["TypeName"]);
			ent.KindId = MyConvert.ToInt(dr["KindId"]);
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