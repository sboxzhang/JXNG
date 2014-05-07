using System;
using System.Data;
namespace AYJZ.Entities
{
	public partial class ayjz_xxtsInfo : BaseEntitie
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
        private string _FSR;
		public string FSR
		{
			get { return _FSR; }
			set
            {
                _FSR = value;
                if (Column.Contains("FSR"))
                    Column["FSR"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("FSR",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private DateTime? _FSSJ;
		public DateTime? FSSJ
		{
			get { return _FSSJ; }
			set
            {
                _FSSJ = value;
                if (Column.Contains("FSSJ"))
                    Column["FSSJ"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("FSSJ",DbType.DateTime, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _FSNR;
		public string FSNR
		{
			get { return _FSNR; }
			set
            {
                _FSNR = value;
                if (Column.Contains("FSNR"))
                    Column["FSNR"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("FSNR",DbType.String, true, false, false, value));

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
        private DateTime? _QLSJ;
		public DateTime? QLSJ
		{
			get { return _QLSJ; }
			set
            {
                _QLSJ = value;
                if (Column.Contains("QLSJ"))
                    Column["QLSJ"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("QLSJ",DbType.DateTime, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _CLJG;
		public string CLJG
		{
			get { return _CLJG; }
			set
            {
                _CLJG = value;
                if (Column.Contains("CLJG"))
                    Column["CLJG"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("CLJG",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _BJ;
		public string BJ
		{
			get { return _BJ; }
			set
            {
                _BJ = value;
                if (Column.Contains("BJ"))
                    Column["BJ"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("BJ",DbType.String, true, false, false, value));

            }
		}
    }
}