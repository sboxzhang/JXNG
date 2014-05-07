using System;
using System.Data;
namespace AYJZ.Entities
{
	public partial class ayjz_htjsmxInfo : BaseEntitie
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
        private string _SJ;
		public string SJ
		{
			get { return _SJ; }
			set
            {
                _SJ = value;
                if (Column.Contains("SJ"))
                    Column["SJ"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("SJ",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private decimal _JE;
		public decimal JE
		{
			get { return _JE; }
			set
            {
                _JE = value;
                if (Column.Contains("JE"))
                    Column["JE"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("JE",DbType.Decimal, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private long _JSID;
		public long JSID
		{
			get { return _JSID; }
			set
            {
                _JSID = value;
                if (Column.Contains("JSID"))
                    Column["JSID"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("JSID",DbType.Int64, true, false, false, value));

            }
		}
    }
}