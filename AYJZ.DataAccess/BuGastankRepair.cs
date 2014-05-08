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
	public partial class BuGastankRepairDao : IDataAccess
	{
		const bool isDebug = true;
        private static readonly string DalSql = " Select GasRepairId,GasRepairDate,TankNumber,DutyOfficer,Remark from BuGastankRepair Where 1=1 ";
   		     
   		private int RunCommandWithTransatcion(VSM.Entities.BuGastankRepair ent, string vSql, IDbTransaction TRANS)
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
            StringBuilder insSQL = new StringBuilder(" Insert Into BuGastankRepair (");
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
            return RunCommandWithTransatcion((BuGastankRepair)ent, insSQL.ToString(), TRANS);
        }
        
        public int Delete(BaseEntitie ent, IDbTransaction TRANS)
        {
            string s_DelSQL = " Delete From BuGastankRepair Where GasRepairId = @GasRepairId";
            return RunCommandWithTransatcion((BuGastankRepair)ent, s_DelSQL, TRANS);
        }
        
        public int Update(BaseEntitie ent, IDbTransaction TRANS)
        {
            StringBuilder s_UpdSQL = new StringBuilder(" Update BuGastankRepair Set ");
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
            s_UpdSQL.Append(" WHERE GasRepairId = @GasRepairId");
            return RunCommandWithTransatcion((BuGastankRepair)ent, s_UpdSQL.ToString(), TRANS);
        }
        
        /// <summary>
        /// 根据GasRepairId得到 BuGastankRepair 实体
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public BuGastankRepair GetBuGastankRepair(int GasRepairId)
        {
            BuGastankRepair ent = null;
            string sql = DalSql;
            sql = sql + " And  GasRepairId";
            MySqlParameter[] paras = new MySqlParameter[]
            {
                new MySqlParameter("GasRepairId",GasRepairId)
            };
            using(DbDataReader reader = DataBaseManage.ExecuteReader(sql, paras))
			{
				if (reader.Read())
				{
					ent = new BuGastankRepair();
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
        public List<BuGastankRepair> GetBuGastankRepairList(string Where)
        {
            List<BuGastankRepair> list = new List<BuGastankRepair>();
            using(DbDataReader reader = DataBaseManage.ExecuteReader(DalSql+Where))
			{
                while (reader.Read())
                {
                   BuGastankRepair ent = new BuGastankRepair();
                    SetEnt(ent, reader);
                    list.Add(ent);
                }
            }
            return list;
        }

        public void SetEnt(BuGastankRepair ent, IDataReader dr)
        {
			ent.GasRepairId = MyConvert.ToInt(dr["GasRepairId"]);
			ent.GasRepairDate = MyConvert.ToDateTime(dr["GasRepairDate"]);
			ent.TankNumber = MyConvert.ToString(dr["TankNumber"]);
			ent.DutyOfficer = MyConvert.ToString(dr["DutyOfficer"]);
			ent.Remark = MyConvert.ToString(dr["Remark"]);
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