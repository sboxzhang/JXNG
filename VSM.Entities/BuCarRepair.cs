using System;
using System.Data;
namespace VSM.Entities{	
	 	//BuCarRepair
		public class BuCarRepair : BaseEntitie
	{
   		     
      	/// <summary>
		/// RepairId
        /// </summary>		
		private  int  _repairid;
        public  int  RepairId
        {
            get{ return _repairid; }
            set
            { 
            	_repairid = value; 
            	if (Column.Contains("RepairId"))
            		Column["RepairId"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("RepairId",
				    						DbType.Int32
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// RepairDate
        /// </summary>		
		private DateTime? _repairdate;
        public DateTime? RepairDate
        {
            get{ return _repairdate; }
            set
            { 
            	_repairdate = value; 
            	if (Column.Contains("RepairDate"))
            		Column["RepairDate"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("RepairDate",
				    						DbType.DateTime
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// CarNumber
        /// </summary>		
		private  string  _carnumber;
        public  string  CarNumber
        {
            get{ return _carnumber; }
            set
            { 
            	_carnumber = value; 
            	if (Column.Contains("CarNumber"))
            		Column["CarNumber"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("CarNumber",
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
		/// RepairComment
        /// </summary>		
		private  string  _repaircomment;
        public  string  RepairComment
        {
            get{ return _repaircomment; }
            set
            { 
            	_repaircomment = value; 
            	if (Column.Contains("RepairComment"))
            		Column["RepairComment"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("RepairComment",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		   
	}
}