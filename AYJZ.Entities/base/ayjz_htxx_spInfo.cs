using System;
using System.Data;
namespace AYJZ.Entities
{
	public partial class ayjz_htxx_spInfo : BaseEntitie
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
        private string _SFZ;
		public string SFZ
		{
			get { return _SFZ; }
			set
            {
                _SFZ = value;
                if (Column.Contains("SFZ"))
                    Column["SFZ"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("SFZ",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _LXDH;
		public string LXDH
		{
			get { return _LXDH; }
			set
            {
                _LXDH = value;
                if (Column.Contains("LXDH"))
                    Column["LXDH"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("LXDH",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _DZ;
		public string DZ
		{
			get { return _DZ; }
			set
            {
                _DZ = value;
                if (Column.Contains("DZ"))
                    Column["DZ"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("DZ",DbType.String, true, false, false, value));

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
		///<Summary>
		///
		///</Summary>
        private string _GZXX;
		public string GZXX
		{
			get { return _GZXX; }
			set
            {
                _GZXX = value;
                if (Column.Contains("GZXX"))
                    Column["GZXX"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("GZXX",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private decimal _DJ;
		public decimal DJ
		{
			get { return _DJ; }
			set
            {
                _DJ = value;
                if (Column.Contains("DJ"))
                    Column["DJ"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("DJ",DbType.Decimal, true, false, false, value));

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
        private long _NL;
		public long NL
		{
			get { return _NL; }
			set
            {
                _NL = value;
                if (Column.Contains("NL"))
                    Column["NL"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("NL",DbType.Int64, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _YBGZ;
		public string YBGZ
		{
			get { return _YBGZ; }
			set
            {
                _YBGZ = value;
                if (Column.Contains("YBGZ"))
                    Column["YBGZ"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("YBGZ",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _BZ;
		public string BZ
		{
			get { return _BZ; }
			set
            {
                _BZ = value;
                if (Column.Contains("BZ"))
                    Column["BZ"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("BZ",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _HTZT;
		public string HTZT
		{
			get { return _HTZT; }
			set
            {
                _HTZT = value;
                if (Column.Contains("HTZT"))
                    Column["HTZT"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("HTZT",DbType.String, true, false, false, value));

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
		///<Summary>
		///
		///</Summary>
        private long _SPID;
		public long SPID
		{
			get { return _SPID; }
			set
            {
                _SPID = value;
                if (Column.Contains("SPID"))
                    Column["SPID"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("SPID",DbType.Int64, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _SPJG;
		public string SPJG
		{
			get { return _SPJG; }
			set
            {
                _SPJG = value;
                if (Column.Contains("SPJG"))
                    Column["SPJG"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("SPJG",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _CZLX;
		public string CZLX
		{
			get { return _CZLX; }
			set
            {
                _CZLX = value;
                if (Column.Contains("CZLX"))
                    Column["CZLX"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("CZLX",DbType.String, true, false, false, value));

            }
		}
    }
}