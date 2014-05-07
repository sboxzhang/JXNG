using System;
using System.Data;
namespace AYJZ.Entities{	
	 	//BuCarInfo
		public class BuCarInfo : BaseEntitie
	{
   		     
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
		/// CarName
        /// </summary>		
		private  string  _carname;
        public  string  CarName
        {
            get{ return _carname; }
            set
            { 
            	_carname = value; 
            	if (Column.Contains("CarName"))
            		Column["CarName"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("CarName",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// CarKind
        /// </summary>		
		private  string  _carkind;
        public  string  CarKind
        {
            get{ return _carkind; }
            set
            { 
            	_carkind = value; 
            	if (Column.Contains("CarKind"))
            		Column["CarKind"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("CarKind",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// CarRemark
        /// </summary>		
		private  string  _carremark;
        public  string  CarRemark
        {
            get{ return _carremark; }
            set
            { 
            	_carremark = value; 
            	if (Column.Contains("CarRemark"))
            		Column["CarRemark"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("CarRemark",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		   
	}
}