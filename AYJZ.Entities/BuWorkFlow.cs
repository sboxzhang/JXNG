using System;
using System.Data;
namespace VSM.Entities{	
	 	//BuWorkFlow
		public class BuWorkFlow : BaseEntitie
	{
   		     
      	/// <summary>
		/// WorkflowGUID
        /// </summary>		
		private  string  _workflowguid;
        public  string  WorkflowGUID
        {
            get{ return _workflowguid; }
            set
            { 
            	_workflowguid = value; 
            	if (Column.Contains("WorkflowGUID"))
            		Column["WorkflowGUID"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("WorkflowGUID",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// WorkflowName
        /// </summary>		
		private  string  _workflowname;
        public  string  WorkflowName
        {
            get{ return _workflowname; }
            set
            { 
            	_workflowname = value; 
            	if (Column.Contains("WorkflowName"))
            		Column["WorkflowName"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("WorkflowName",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		   
	}
}