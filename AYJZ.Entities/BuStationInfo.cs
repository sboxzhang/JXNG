using System;
using System.Data;
namespace VSM.Entities{	
	 	//BuStationInfo
		public class BuStationInfo : BaseEntitie
	{
   		     
      	/// <summary>
		/// auto_increment
        /// </summary>		
		private  int  _stationid;
        public  int  StationId
        {
            get{ return _stationid; }
            set
            { 
            	_stationid = value; 
            	if (Column.Contains("StationId"))
            		Column["StationId"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("StationId",
				    						DbType.Int32
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// StationName
        /// </summary>		
		private  string  _stationname;
        public  string  StationName
        {
            get{ return _stationname; }
            set
            { 
            	_stationname = value; 
            	if (Column.Contains("StationName"))
            		Column["StationName"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("StationName",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// StationBoss
        /// </summary>		
		private  string  _stationboss;
        public  string  StationBoss
        {
            get{ return _stationboss; }
            set
            { 
            	_stationboss = value; 
            	if (Column.Contains("StationBoss"))
            		Column["StationBoss"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("StationBoss",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// ProvinceId
        /// </summary>		
		private  int  _provinceid;
        public  int  ProvinceId
        {
            get{ return _provinceid; }
            set
            { 
            	_provinceid = value; 
            	if (Column.Contains("ProvinceId"))
            		Column["ProvinceId"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("ProvinceId",
				    						DbType.Int32
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// CityId
        /// </summary>		
		private  int  _cityid;
        public  int  CityId
        {
            get{ return _cityid; }
            set
            { 
            	_cityid = value; 
            	if (Column.Contains("CityId"))
            		Column["CityId"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("CityId",
				    						DbType.Int32
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// Address
        /// </summary>		
		private  string  _address;
        public  string  Address
        {
            get{ return _address; }
            set
            { 
            	_address = value; 
            	if (Column.Contains("Address"))
            		Column["Address"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("Address",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		   
	}
}