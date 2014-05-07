using System;
using System.Data;
namespace AYJZ.Entities
{
	public partial class ayjz_ddjsInfo : BaseEntitie
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
        private long _DDID;
		public long DDID
		{
			get { return _DDID; }
			set
            {
                _DDID = value;
                if (Column.Contains("DDID"))
                    Column["DDID"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("DDID",DbType.Int64, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private decimal _DDJE;
		public decimal DDJE
		{
			get { return _DDJE; }
			set
            {
                _DDJE = value;
                if (Column.Contains("DDJE"))
                    Column["DDJE"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("DDJE",DbType.Decimal, true, false, false, value));

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
        private long _SFSP;
		public long SFSP
		{
			get { return _SFSP; }
			set
            {
                _SFSP = value;
                if (Column.Contains("SFSP"))
                    Column["SFSP"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("SFSP",DbType.Int64, true, false, false, value));

            }
		}
    }
}