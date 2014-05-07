using System;
using System.Data;
namespace AYJZ.Entities
{
	public partial class ayjz_htjsInfo : BaseEntitie
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
        private long _HTID;
		public long HTID
		{
			get { return _HTID; }
			set
            {
                _HTID = value;
                if (Column.Contains("HTID"))
                    Column["HTID"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("HTID",DbType.Int64, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _JSR;
		public string JSR
		{
			get { return _JSR; }
			set
            {
                _JSR = value;
                if (Column.Contains("JSR"))
                    Column["JSR"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("JSR",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private decimal _ZJE;
		public decimal ZJE
		{
			get { return _ZJE; }
			set
            {
                _ZJE = value;
                if (Column.Contains("ZJE"))
                    Column["ZJE"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("ZJE",DbType.Decimal, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private DateTime? _JSSJ;
		public DateTime? JSSJ
		{
			get { return _JSSJ; }
			set
            {
                _JSSJ = value;
                if (Column.Contains("JSSJ"))
                    Column["JSSJ"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("JSSJ",DbType.DateTime, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _SFSP;
		public string SFSP
		{
			get { return _SFSP; }
			set
            {
                _SFSP = value;
                if (Column.Contains("SFSP"))
                    Column["SFSP"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("SFSP",DbType.String, true, false, false, value));

            }
		}
    }
}