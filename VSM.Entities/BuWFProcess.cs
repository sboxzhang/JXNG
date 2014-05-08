using System;
using System.Data;
namespace VSM.Entities{	
	 	//BuWFProcess
		public class BuWFProcess : BaseEntitie
	{
   		     
      	/// <summary>
		/// auto_increment
        /// </summary>		
		private  int  _processid;
        public  int  ProcessId
        {
            get{ return _processid; }
            set
            { 
            	_processid = value; 
            	if (Column.Contains("ProcessId"))
            		Column["ProcessId"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("ProcessId",
				    						DbType.Int32
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// processName
        /// </summary>		
		private  string  _processname;
        public  string  processName
        {
            get{ return _processname; }
            set
            { 
            	_processname = value; 
            	if (Column.Contains("processName"))
            		Column["processName"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("processName",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		   
	}
}