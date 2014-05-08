using System;
using System.Data;
namespace VSM.Entities{	
	 	//BuCityInfo
		public class BuCityInfo : BaseEntitie
	{
   		     
      	/// <summary>
		/// CityCode
        /// </summary>		
		private  string  _citycode;
        public  string  CityCode
        {
            get{ return _citycode; }
            set
            { 
            	_citycode = value; 
            	if (Column.Contains("CityCode"))
            		Column["CityCode"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("CityCode",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// CityName
        /// </summary>		
		private  string  _cityname;
        public  string  CityName
        {
            get{ return _cityname; }
            set
            { 
            	_cityname = value; 
            	if (Column.Contains("CityName"))
            		Column["CityName"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("CityName",
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
		   
	}
}