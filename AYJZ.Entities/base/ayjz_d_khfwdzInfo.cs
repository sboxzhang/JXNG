using System;
using System.Data;
namespace AYJZ.Entities
{
	public partial class ayjz_d_khfwdzInfo : BaseEntitie
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
        private string _KHFWDZ;
		public string KHFWDZ
		{
			get { return _KHFWDZ; }
			set
            {
                _KHFWDZ = value;
                if (Column.Contains("KHFWDZ"))
                    Column["KHFWDZ"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("KHFWDZ",DbType.String, true, false, false, value));

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
        private string _XB;
		public string XB
		{
			get { return _XB; }
			set
            {
                _XB = value;
                if (Column.Contains("XB"))
                    Column["XB"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("XB",DbType.String, true, false, false, value));

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
        private string _HYZK;
		public string HYZK
		{
			get { return _HYZK; }
			set
            {
                _HYZK = value;
                if (Column.Contains("HYZK"))
                    Column["HYZK"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("HYZK",DbType.String, true, false, false, value));

            }
		}
    }
}