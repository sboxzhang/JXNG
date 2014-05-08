using System;
using System.Data;
namespace VSM.Entities{	
	 	//BuWFRelationshipLog
		public class BuWFRelationshipLog : BaseEntitie
	{
   		     
      	/// <summary>
		/// auto_increment
        /// </summary>		
		private  int  _logid;
        public  int  LogId
        {
            get{ return _logid; }
            set
            { 
            	_logid = value; 
            	if (Column.Contains("LogId"))
            		Column["LogId"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("LogId",
				    						DbType.Int32
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// RelationshipId
        /// </summary>		
		private  int  _relationshipid;
        public  int  RelationshipId
        {
            get{ return _relationshipid; }
            set
            { 
            	_relationshipid = value; 
            	if (Column.Contains("RelationshipId"))
            		Column["RelationshipId"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("RelationshipId",
				    						DbType.Int32
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// Status
        /// </summary>		
		private  int  _status;
        public  int  Status
        {
            get{ return _status; }
            set
            { 
            	_status = value; 
            	if (Column.Contains("Status"))
            		Column["Status"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("Status",
				    						DbType.Int32
					, true, false, false, value));
            }
        }        
		   
	}
}