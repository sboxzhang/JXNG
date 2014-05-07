using System;
using System.Data;
namespace AYJZ.Entities
{
	public partial class ayjz_spxxInfo : BaseEntitie
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
        private long _XXID;
		public long XXID
		{
			get { return _XXID; }
			set
            {
                _XXID = value;
                if (Column.Contains("XXID"))
                    Column["XXID"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("XXID",DbType.Int64, true, false, false, value));

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
    }
}