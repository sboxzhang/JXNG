using System;
using System.Data;
namespace AYJZ.Entities{	
	 	//BuBigStationInfo
		public class BuBigStationInfo : BaseEntitie
	{
   		     
      	/// <summary>
		/// auto_increment
        /// </summary>		
		private  int  _bigstationid;
        public  int  BigStationId
        {
            get{ return _bigstationid; }
            set
            { 
            	_bigstationid = value; 
            	if (Column.Contains("BigStationId"))
            		Column["BigStationId"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("BigStationId",
				    						DbType.Int32
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// BigStationName
        /// </summary>		
		private  string  _bigstationname;
        public  string  BigStationName
        {
            get{ return _bigstationname; }
            set
            { 
            	_bigstationname = value; 
            	if (Column.Contains("BigStationName"))
            		Column["BigStationName"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("BigStationName",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// BigStationProvince
        /// </summary>		
		private  int  _bigstationprovince;
        public  int  BigStationProvince
        {
            get{ return _bigstationprovince; }
            set
            { 
            	_bigstationprovince = value; 
            	if (Column.Contains("BigStationProvince"))
            		Column["BigStationProvince"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("BigStationProvince",
				    						DbType.Int32
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// BigStationCity
        /// </summary>		
		private  int  _bigstationcity;
        public  int  BigStationCity
        {
            get{ return _bigstationcity; }
            set
            { 
            	_bigstationcity = value; 
            	if (Column.Contains("BigStationCity"))
            		Column["BigStationCity"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("BigStationCity",
				    						DbType.Int32
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// BigSstationAddress
        /// </summary>		
		private  int  _bigsstationaddress;
        public  int  BigSstationAddress
        {
            get{ return _bigsstationaddress; }
            set
            { 
            	_bigsstationaddress = value; 
            	if (Column.Contains("BigSstationAddress"))
            		Column["BigSstationAddress"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("BigSstationAddress",
				    						DbType.Int32
					, true, false, false, value));
            }
        }        
		   
	}
}