using System;
using System.Data;
namespace AYJZ.Entities
{
	public partial class ayjz_d_lxdhInfo : BaseEntitie
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