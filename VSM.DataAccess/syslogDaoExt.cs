using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using JITE.CIS.Framework.DBProviders;

namespace VSM.DataAccess
{
    public partial class syslogDao
    {
        public DataTable GetData(string where)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("  select a.* ");
            sb.Append(",(select username from userinfo t where a.usercode=t.usercode ) username ");
            sb.Append(",(select MOUDLENAME from moudleinfo t where a.MOUDLEID=t.MOUDLEID ) MOUDLENAME ");
            sb.Append(" from syslog a where 1=1 ");
            sb.Append(where);
            DataSet ds = DataBaseManage.ExecuteDataSet(sb.ToString());
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return new DataTable();
        }
    }
}
