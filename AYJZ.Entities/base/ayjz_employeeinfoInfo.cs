using System;
using System.Data;
namespace AYJZ.Entities
{
	public partial class ayjz_employeeinfoInfo : BaseEntitie
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
        private string _SFZH;
		public string SFZH
		{
			get { return _SFZH; }
			set
            {
                _SFZH = value;
                if (Column.Contains("SFZH"))
                    Column["SFZH"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("SFZH",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _FWGZ;
		public string FWGZ
		{
			get { return _FWGZ; }
			set
            {
                _FWGZ = value;
                if (Column.Contains("FWGZ"))
                    Column["FWGZ"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("FWGZ",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _KHZT;
		public string KHZT
		{
			get { return _KHZT; }
			set
            {
                _KHZT = value;
                if (Column.Contains("KHZT"))
                    Column["KHZT"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("KHZT",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _KHYXQ;
		public string KHYXQ
		{
			get { return _KHYXQ; }
			set
            {
                _KHYXQ = value;
                if (Column.Contains("KHYXQ"))
                    Column["KHYXQ"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("KHYXQ",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _SFHMD;
		public string SFHMD
		{
			get { return _SFHMD; }
			set
            {
                _SFHMD = value;
                if (Column.Contains("SFHMD"))
                    Column["SFHMD"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("SFHMD",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _KHFZDZ;
		public string KHFZDZ
		{
			get { return _KHFZDZ; }
			set
            {
                _KHFZDZ = value;
                if (Column.Contains("KHFZDZ"))
                    Column["KHFZDZ"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("KHFZDZ",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _FWNR;
		public string FWNR
		{
			get { return _FWNR; }
			set
            {
                _FWNR = value;
                if (Column.Contains("FWNR"))
                    Column["FWNR"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("FWNR",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _FWXX;
		public string FWXX
		{
			get { return _FWXX; }
			set
            {
                _FWXX = value;
                if (Column.Contains("FWXX"))
                    Column["FWXX"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("FWXX",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _BM;
		public string BM
		{
			get { return _BM; }
			set
            {
                _BM = value;
                if (Column.Contains("BM"))
                    Column["BM"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("BM",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _GLF;
		public string GLF
		{
			get { return _GLF; }
			set
            {
                _GLF = value;
                if (Column.Contains("GLF"))
                    Column["GLF"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("GLF",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _HYLX;
		public string HYLX
		{
			get { return _HYLX; }
			set
            {
                _HYLX = value;
                if (Column.Contains("HYLX"))
                    Column["HYLX"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("HYLX",DbType.String, true, false, false, value));

            }
		}

        private string _FWXX1;
        public string FWXX1
        {
            get { return _FWXX1; }
            set
            {
                _FWXX1 = value;
                if (Column.Contains("FWXX1"))
                    Column["FWXX1"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("FWXX1", DbType.String, true, false, false, value));

            }
        }

        private string _FWXX2;
        public string FWXX2
        {
            get { return _FWXX2; }
            set
            {
                _FWXX2 = value;
                if (Column.Contains("FWXX2"))
                    Column["FWXX2"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("FWXX2", DbType.String, true, false, false, value));

            }
        }

        private string _FWXX3;
        public string FWXX3
        {
            get { return _FWXX3; }
            set
            {
                _FWXX3 = value;
                if (Column.Contains("FWXX3"))
                    Column["FWXX3"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("FWXX3", DbType.String, true, false, false, value));

            }
        }
    }
}