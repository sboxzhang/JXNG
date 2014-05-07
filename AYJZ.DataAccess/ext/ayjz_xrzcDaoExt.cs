using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using JITE.CIS.Framework.DBProviders;

namespace AYJZ.DataAccess
{
    public partial class ayjz_xrzcDao
    {
        public DataTable GetData(string where)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("  select a.* ");
            sb.Append(",(select XM from AYJZ_EmployeeInfo t where a.eiid=t.id ) xm ");
            sb.Append(" from AYJZ_XRZC a where 1=1 ");
            sb.Append(where);
            DataSet ds = DataBaseManage.ExecuteDataSet(sb.ToString());
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return new DataTable();
        }
    }
}
