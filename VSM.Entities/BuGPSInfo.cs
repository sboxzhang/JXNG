using System;
using System.Data;
namespace VSM.Entities{	
	 	//BuGPSInfo
		public class BuGPSInfo : BaseEntitie
	{
   		     
      	/// <summary>
		/// GPSId
        /// </summary>		
		private  string  _gpsid;
        public  string  GPSId
        {
            get{ return _gpsid; }
            set
            { 
            	_gpsid = value; 
            	if (Column.Contains("GPSId"))
            		Column["GPSId"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("GPSId",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// SynchronizationType
        /// </summary>		
		private  string  _synchronizationtype;
        public  string  SynchronizationType
        {
            get{ return _synchronizationtype; }
            set
            { 
            	_synchronizationtype = value; 
            	if (Column.Contains("SynchronizationType"))
            		Column["SynchronizationType"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("SynchronizationType",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// SynchronizationTime
        /// </summary>		
		private DateTime? _synchronizationtime;
        public DateTime? SynchronizationTime
        {
            get{ return _synchronizationtime; }
            set
            { 
            	_synchronizationtime = value; 
            	if (Column.Contains("SynchronizationTime"))
            		Column["SynchronizationTime"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("SynchronizationTime",
				    						DbType.DateTime
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
		/// Longitude
        /// </summary>		
		private  string  _longitude;
        public  string  Longitude
        {
            get{ return _longitude; }
            set
            { 
            	_longitude = value; 
            	if (Column.Contains("Longitude"))
            		Column["Longitude"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("Longitude",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// Latitude
        /// </summary>		
		private  string  _latitude;
        public  string  Latitude
        {
            get{ return _latitude; }
            set
            { 
            	_latitude = value; 
            	if (Column.Contains("Latitude"))
            		Column["Latitude"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("Latitude",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// CarId
        /// </summary>		
		private  int  _carid;
        public  int  CarId
        {
            get{ return _carid; }
            set
            { 
            	_carid = value; 
            	if (Column.Contains("CarId"))
            		Column["CarId"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("CarId",
				    						DbType.Int32
					, true, false, false, value));
            }
        }        
		   
	}
}