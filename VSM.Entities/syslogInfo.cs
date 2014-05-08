using System;
using System.Data;
namespace VSM.Entities
{
	public partial class syslogInfo : BaseEntitie
	{

		///<Summary>
		///
		///</Summary>
        private long _ID;
		public long ID
		{
			get { return _ID; }
			set
            {
                _ID = value;
                if (Column.Contains("ID"))
                    Column["ID"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("ID",DbType.Int64, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _USERCODE;
		public string USERCODE
		{
			get { return _USERCODE; }
			set
            {
                _USERCODE = value;
                if (Column.Contains("USERCODE"))
                    Column["USERCODE"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("USERCODE",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private long _MOUDLEID;
		public long MOUDLEID
		{
			get { return _MOUDLEID; }
			set
            {
                _MOUDLEID = value;
                if (Column.Contains("MOUDLEID"))
                    Column["MOUDLEID"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("MOUDLEID",DbType.Int64, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private DateTime? _SJ;
		public DateTime? SJ
		{
			get { return _SJ; }
			set
            {
                _SJ = value;
                if (Column.Contains("SJ"))
                    Column["SJ"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("SJ",DbType.DateTime, true, false, false, value));

            }
		}
    }
}