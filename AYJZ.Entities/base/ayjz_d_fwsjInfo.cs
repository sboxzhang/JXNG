using System;
using System.Data;
namespace AYJZ.Entities
{
	public partial class ayjz_d_fwsjInfo : BaseEntitie
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
        private long _AYID;
		public long AYID
		{
			get { return _AYID; }
			set
            {
                _AYID = value;
                if (Column.Contains("AYID"))
                    Column["AYID"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("AYID",DbType.Int64, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _KSSJ;
		public string KSSJ
		{
			get { return _KSSJ; }
			set
            {
                _KSSJ = value;
                if (Column.Contains("KSSJ"))
                    Column["KSSJ"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("KSSJ",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _JSSJ;
		public string JSSJ
		{
			get { return _JSSJ; }
			set
            {
                _JSSJ = value;
                if (Column.Contains("JSSJ"))
                    Column["JSSJ"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("JSSJ",DbType.String, true, false, false, value));

            }
		}
    }
}