using System;
using System.Data;
namespace AYJZ.Entities
{
	public partial class ayjz_ayzhxxInfo : BaseEntitie
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
		///<Summary>
		///
		///</Summary>
        private string _MZ;
		public string MZ
		{
			get { return _MZ; }
			set
            {
                _MZ = value;
                if (Column.Contains("MZ"))
                    Column["MZ"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("MZ",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _YHCD;
		public string YHCD
		{
			get { return _YHCD; }
			set
            {
                _YHCD = value;
                if (Column.Contains("YHCD"))
                    Column["YHCD"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("YHCD",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _SG;
		public string SG
		{
			get { return _SG; }
			set
            {
                _SG = value;
                if (Column.Contains("SG"))
                    Column["SG"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("SG",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _TZ;
		public string TZ
		{
			get { return _TZ; }
			set
            {
                _TZ = value;
                if (Column.Contains("TZ"))
                    Column["TZ"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("TZ",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _ZTCY;
		public string ZTCY
		{
			get { return _ZTCY; }
			set
            {
                _ZTCY = value;
                if (Column.Contains("ZTCY"))
                    Column["ZTCY"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("ZTCY",DbType.String, true, false, false, value));

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
        private string _SJZDQR;
		public string SJZDQR
		{
			get { return _SJZDQR; }
			set
            {
                _SJZDQR = value;
                if (Column.Contains("SJZDQR"))
                    Column["SJZDQR"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("SJZDQR",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _JKZBH;
		public string JKZBH
		{
			get { return _JKZBH; }
			set
            {
                _JKZBH = value;
                if (Column.Contains("JKZBH"))
                    Column["JKZBH"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("JKZBH",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _BLYY;
		public string BLYY
		{
			get { return _BLYY; }
			set
            {
                _BLYY = value;
                if (Column.Contains("BLYY"))
                    Column["BLYY"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("BLYY",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _BSYSQ;
		public string BSYSQ
		{
			get { return _BSYSQ; }
			set
            {
                _BSYSQ = value;
                if (Column.Contains("BSYSQ"))
                    Column["BSYSQ"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("BSYSQ",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _BSGMQ;
		public string BSGMQ
		{
			get { return _BSGMQ; }
			set
            {
                _BSGMQ = value;
                if (Column.Contains("BSGMQ"))
                    Column["BSGMQ"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("BSGMQ",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _SS;
		public string SS
		{
			get { return _SS; }
			set
            {
                _SS = value;
                if (Column.Contains("SS"))
                    Column["SS"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("SS",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _XZZ;
		public string XZZ
		{
			get { return _XZZ; }
			set
            {
                _XZZ = value;
                if (Column.Contains("XZZ"))
                    Column["XZZ"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("XZZ",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _HJDZ;
		public string HJDZ
		{
			get { return _HJDZ; }
			set
            {
                _HJDZ = value;
                if (Column.Contains("HJDZ"))
                    Column["HJDZ"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("HJDZ",DbType.String, true, false, false, value));

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
        private string _GX;
		public string GX
		{
			get { return _GX; }
			set
            {
                _GX = value;
                if (Column.Contains("GX"))
                    Column["GX"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("GX",DbType.String, true, false, false, value));

            }
		}
		///<Summary>
		///
		///</Summary>
        private string _FP;
		public string FP
		{
			get { return _FP; }
			set
            {
                _FP = value;
                if (Column.Contains("FP"))
                    Column["FP"].FieldValue = value;
                else
                    Column.Add(new ColumnSchema("FP",DbType.String, true, false, false, value));

            }
		}
    }
}