using System;
using System.Data;
namespace AYJZ.Entities{	
	 	//BuGPSLog
		public class BuGPSLog : BaseEntitie
	{
   		     
      	/// <summary>
		/// auto_increment
        /// </summary>		
		private  int  _gpslogid;
        public  int  GPSLogId
        {
            get{ return _gpslogid; }
            set
            { 
            	_gpslogid = value; 
            	if (Column.Contains("GPSLogId"))
            		Column["GPSLogId"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("GPSLogId",
				    						DbType.Int32
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// SynchronizationStatus
        /// </summary>		
		private  string  _synchronizationstatus;
        public  string  SynchronizationStatus
        {
            get{ return _synchronizationstatus; }
            set
            { 
            	_synchronizationstatus = value; 
            	if (Column.Contains("SynchronizationStatus"))
            		Column["SynchronizationStatus"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("SynchronizationStatus",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// SynchronizationDate
        /// </summary>		
		private DateTime? _synchronizationdate;
        public DateTime? SynchronizationDate
        {
            get{ return _synchronizationdate; }
            set
            { 
            	_synchronizationdate = value; 
            	if (Column.Contains("SynchronizationDate"))
            		Column["SynchronizationDate"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("SynchronizationDate",
				    						DbType.DateTime
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// SynchronizationInfo
        /// </summary>		
		private  string  _synchronizationinfo;
        public  string  SynchronizationInfo
        {
            get{ return _synchronizationinfo; }
            set
            { 
            	_synchronizationinfo = value; 
            	if (Column.Contains("SynchronizationInfo"))
            		Column["SynchronizationInfo"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("SynchronizationInfo",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		   
	}
}