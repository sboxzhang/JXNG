using System;
using System.Data;
namespace AYJZ.Entities{	
	 	//BuGastankRepair
		public class BuGastankRepair : BaseEntitie
	{
   		     
      	/// <summary>
		/// auto_increment
        /// </summary>		
		private  int  _gasrepairid;
        public  int  GasRepairId
        {
            get{ return _gasrepairid; }
            set
            { 
            	_gasrepairid = value; 
            	if (Column.Contains("GasRepairId"))
            		Column["GasRepairId"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("GasRepairId",
				    						DbType.Int32
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// GasRepairDate
        /// </summary>		
		private DateTime? _gasrepairdate;
        public DateTime? GasRepairDate
        {
            get{ return _gasrepairdate; }
            set
            { 
            	_gasrepairdate = value; 
            	if (Column.Contains("GasRepairDate"))
            		Column["GasRepairDate"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("GasRepairDate",
				    						DbType.DateTime
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// TankNumber
        /// </summary>		
		private  string  _tanknumber;
        public  string  TankNumber
        {
            get{ return _tanknumber; }
            set
            { 
            	_tanknumber = value; 
            	if (Column.Contains("TankNumber"))
            		Column["TankNumber"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("TankNumber",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// DutyOfficer
        /// </summary>		
		private  string  _dutyofficer;
        public  string  DutyOfficer
        {
            get{ return _dutyofficer; }
            set
            { 
            	_dutyofficer = value; 
            	if (Column.Contains("DutyOfficer"))
            		Column["DutyOfficer"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("DutyOfficer",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// Remark
        /// </summary>		
		private  string  _remark;
        public  string  Remark
        {
            get{ return _remark; }
            set
            { 
            	_remark = value; 
            	if (Column.Contains("Remark"))
            		Column["Remark"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("Remark",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		   
	}
}