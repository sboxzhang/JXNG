using System;
using System.Data;
namespace AYJZ.Entities{	
	 	//BuRepairing
		public class BuRepairing : BaseEntitie
	{
   		     
      	/// <summary>
		/// auto_increment
        /// </summary>		
		private  int  _repairingid;
        public  int  RepairingId
        {
            get{ return _repairingid; }
            set
            { 
            	_repairingid = value; 
            	if (Column.Contains("RepairingId"))
            		Column["RepairingId"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("RepairingId",
				    						DbType.Int32
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// RepairingName
        /// </summary>		
		private  string  _repairingname;
        public  string  RepairingName
        {
            get{ return _repairingname; }
            set
            { 
            	_repairingname = value; 
            	if (Column.Contains("RepairingName"))
            		Column["RepairingName"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("RepairingName",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// RepairingDate
        /// </summary>		
		private  string  _repairingdate;
        public  string  RepairingDate
        {
            get{ return _repairingdate; }
            set
            { 
            	_repairingdate = value; 
            	if (Column.Contains("RepairingDate"))
            		Column["RepairingDate"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("RepairingDate",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		   
	}
}