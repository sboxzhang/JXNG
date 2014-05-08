using System;
using System.Data;
namespace VSM.Entities{	
	 	//BuProvinceInfo
		public class BuProvinceInfo : BaseEntitie
	{
   		     
      	/// <summary>
		/// ProvinceCode
        /// </summary>		
		private  string  _provincecode;
        public  string  ProvinceCode
        {
            get{ return _provincecode; }
            set
            { 
            	_provincecode = value; 
            	if (Column.Contains("ProvinceCode"))
            		Column["ProvinceCode"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("ProvinceCode",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// ProvinceName
        /// </summary>		
		private  string  _provincename;
        public  string  ProvinceName
        {
            get{ return _provincename; }
            set
            { 
            	_provincename = value; 
            	if (Column.Contains("ProvinceName"))
            		Column["ProvinceName"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("ProvinceName",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		   
	}
}