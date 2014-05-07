using System;
using System.Data;
namespace AYJZ.Entities
{
	public partial class ayjz_xrzcInfo : BaseEntitie
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
        private string _LX;
		public string LX
		{
			get { return _LX; }
			set
            {
                _LX = value;
                if (Column.Contains("LX"))
                    Column["LX"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("LX",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private long _EIID;
		public long EIID
		{
			get { return _EIID; }
			set
            {
                _EIID = value;
                if (Column.Contains("EIID"))
                    Column["EIID"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("EIID",DbType.Int64, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _XM;
		public string XM
		{
			get { return _XM; }
			set
            {
                _XM = value;
                if (Column.Contains("XM"))
                    Column["XM"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("XM",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _YHLX;
		public string YHLX
		{
			get { return _YHLX; }
			set
            {
                _YHLX = value;
                if (Column.Contains("YHLX"))
                    Column["YHLX"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("YHLX",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _KM;
		public string KM
		{
			get { return _KM; }
			set
            {
                _KM = value;
                if (Column.Contains("KM"))
                    Column["KM"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("KM",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _FS;
		public string FS
		{
			get { return _FS; }
			set
            {
                _FS = value;
                if (Column.Contains("FS"))
                    Column["FS"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("FS",DbType.String, true, false, false, value));

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
        private string _TT;
		public string TT
		{
			get { return _TT; }
			set
            {
                _TT = value;
                if (Column.Contains("TT"))
                    Column["TT"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("TT",DbType.String, true, false, false, value));

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