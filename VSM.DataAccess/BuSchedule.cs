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
	public partial class BuScheduleDao : IDataAccess
	{
		const bool isDebug = true;
        private static readonly string DalSql = " Select ScheduleId,ScheduleName,CreateMan,CreateDate,UpdateMan,UpdateDate,ScheduleStatus,ScheduleKind,StationId,StationBossId,ExecuteDate,ApplyDate,StartAddress,BigStationId,TakeTime,AddTime,TargetAddress,NeedTime from BuSchedule Where 1=1 ";
   		     
   		private int RunCommandWithTransatcion(VSM.Entities.BuSchedule ent, string vSql, IDbTransaction TRANS)
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
            StringBuilder insSQL = new StringBuilder(" Insert Into BuSchedule (");
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
            return RunCommandWithTransatcion((BuSchedule)ent, insSQL.ToString(), TRANS);
        }
        
        public int Delete(BaseEntitie ent, IDbTransaction TRANS)
        {
            string s_DelSQL = " Delete From BuSchedule Where ScheduleId = @ScheduleId";
            return RunCommandWithTransatcion((BuSchedule)ent, s_DelSQL, TRANS);
        }
        
        public int Update(BaseEntitie ent, IDbTransaction TRANS)
        {
            StringBuilder s_UpdSQL = new StringBuilder(" Update BuSchedule Set ");
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
            s_UpdSQL.Append(" WHERE ScheduleId = @ScheduleId");
            return RunCommandWithTransatcion((BuSchedule)ent, s_UpdSQL.ToString(), TRANS);
        }
        
        /// <summary>
        /// 根据ScheduleId得到 BuSchedule 实体
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public BuSchedule GetBuSchedule(int ScheduleId)
        {
            BuSchedule ent = null;
            string sql = DalSql;
            sql = sql + " And  ScheduleId";
            MySqlParameter[] paras = new MySqlParameter[]
            {
                new MySqlParameter("ScheduleId",ScheduleId)
            };
            using(DbDataReader reader = DataBaseManage.ExecuteReader(sql, paras))
			{
				if (reader.Read())
				{
					ent = new BuSchedule();
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
        public List<BuSchedule> GetBuScheduleList(string Where)
        {
            List<BuSchedule> list = new List<BuSchedule>();
            using(DbDataReader reader = DataBaseManage.ExecuteReader(DalSql+Where))
			{
                while (reader.Read())
                {
                   BuSchedule ent = new BuSchedule();
                    SetEnt(ent, reader);
                    list.Add(ent);
                }
            }
            return list;
        }

        public void SetEnt(BuSchedule ent, IDataReader dr)
        {
			ent.ScheduleId = MyConvert.ToInt(dr["ScheduleId"]);
			ent.ScheduleName = MyConvert.ToString(dr["ScheduleName"]);
			ent.CreateMan = MyConvert.ToString(dr["CreateMan"]);
			ent.CreateDate = MyConvert.ToDateTime(dr["CreateDate"]);
			ent.UpdateMan = MyConvert.ToString(dr["UpdateMan"]);
			ent.UpdateDate = MyConvert.ToString(dr["UpdateDate"]);
			ent.ScheduleStatus = MyConvert.ToString(dr["ScheduleStatus"]);
			ent.ScheduleKind = MyConvert.ToInt(dr["ScheduleKind"]);
			ent.StationId = MyConvert.ToString(dr["StationId"]);
			ent.StationBossId = MyConvert.ToString(dr["StationBossId"]);
			ent.ExecuteDate = MyConvert.ToDateTime(dr["ExecuteDate"]);
			ent.ApplyDate = MyConvert.ToDateTime(dr["ApplyDate"]);
			ent.StartAddress = MyConvert.ToString(dr["StartAddress"]);
			ent.BigStationId = MyConvert.ToInt(dr["BigStationId"]);
			ent.TakeTime = MyConvert.ToDateTime(dr["TakeTime"]);
			ent.AddTime = MyConvert.ToDateTime(dr["AddTime"]);
			ent.TargetAddress = MyConvert.ToString(dr["TargetAddress"]);
			ent.NeedTime = MyConvert.ToDateTime(dr["NeedTime"]);
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