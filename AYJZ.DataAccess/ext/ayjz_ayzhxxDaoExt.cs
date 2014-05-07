using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AYJZ.Entities;
using JITE.CIS.Framework.DBProviders;
using System.Data;

namespace AYJZ.DataAccess
{
    public partial class ayjz_ayzhxxDao
    {
        public long InsertIdentity(BaseEntitie ent)
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
                    if (_column[i].FieldType == System.Data.DbType.Int64)
                    {
                        sp.Append(_column[i].FieldValue);
                    }
                    else if (_column[i].FieldType == System.Data.DbType.String)
                    {
                        sp.Append(string.Format("'{0}'", _column[i].FieldValue));
                    }                    
                }
                else
                {
                    insSQL.Append("," + _column[i].FieldName);
                    if (_column[i].FieldType == System.Data.DbType.Int64)
                    {
                        sp.Append("," + _column[i].FieldValue);
                    }
                    else if (_column[i].FieldType == System.Data.DbType.String)
                    {
                        sp.Append("," + string.Format("'{0}'", _column[i].FieldValue));
                    }                    
                }
            }
            insSQL.Append(") values (" + sp.ToString() + ")");

            IDbConnection connection = DataBaseManage.GetdbConnection();
            connection.Open();
            System.Data.IDbCommand CM = connection.CreateCommand();
            CM.CommandText = string.Format("{0};{1};",insSQL.ToString(),"SELECT @@IDENTITY");
            CM.CommandType = System.Data.CommandType.Text;
            try
            {
                object result = CM.ExecuteScalar();
                if (result != null)
                {
                    return MyConvert.ToLong(result);
                }

                return 0;
            }
            catch (System.Exception e)
            {
                return 0;
            }
            finally
            {
                CM.Dispose();
                connection.Close();
                connection.Dispose();
            }
        }
    }
}
