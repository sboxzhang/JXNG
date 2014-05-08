using System;
using System.Data;
namespace VSM.Entities{	
	 	//BuAddress
		public class BuAddress : BaseEntitie
	{
   		     
      	/// <summary>
		/// auto_increment
        /// </summary>		
		private  int  _id;
        public  int  Id
        {
            get{ return _id; }
            set
            { 
            	_id = value; 
            	if (Column.Contains("Id"))
            		Column["Id"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("Id",
				    						DbType.Int32
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// AddressName
        /// </summary>		
		private  string  _addressname;
        public  string  AddressName
        {
            get{ return _addressname; }
            set
            { 
            	_addressname = value; 
            	if (Column.Contains("AddressName"))
            		Column["AddressName"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("AddressName",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		   
	}
}