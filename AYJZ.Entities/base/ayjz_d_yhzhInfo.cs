using System;
using System.Data;
namespace AYJZ.Entities
{
	public partial class ayjz_d_yhzhInfo : BaseEntitie
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
        private string _YHZH;
		public string YHZH
		{
			get { return _YHZH; }
			set
            {
                _YHZH = value;
                if (Column.Contains("YHZH"))
                    Column["YHZH"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("YHZH",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _KHH;
		public string KHH
		{
			get { return _KHH; }
			set
            {
                _KHH = value;
                if (Column.Contains("KHH"))
                    Column["KHH"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("KHH",DbType.String, true, false, false, value));

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
    }
}