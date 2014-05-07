using System;
using System.Data;
namespace AYJZ.Entities{	
	 	//BuWFRelationship
		public class BuWFRelationship : BaseEntitie
	{
   		     
      	/// <summary>
		/// auto_increment
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
		/// LastProcessId
        /// </summary>		
		private  int  _lastprocessid;
        public  int  LastProcessId
        {
            get{ return _lastprocessid; }
            set
            { 
            	_lastprocessid = value; 
            	if (Column.Contains("LastProcessId"))
            		Column["LastProcessId"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("LastProcessId",
				    						DbType.Int32
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// CurProcessId
        /// </summary>		
		private  int  _curprocessid;
        public  int  CurProcessId
        {
            get{ return _curprocessid; }
            set
            { 
            	_curprocessid = value; 
            	if (Column.Contains("CurProcessId"))
            		Column["CurProcessId"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("CurProcessId",
				    						DbType.Int32
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// NextProcessId
        /// </summary>		
		private  int  _nextprocessid;
        public  int  NextProcessId
        {
            get{ return _nextprocessid; }
            set
            { 
            	_nextprocessid = value; 
            	if (Column.Contains("NextProcessId"))
            		Column["NextProcessId"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("NextProcessId",
				    						DbType.Int32
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// ApprovePostId
        /// </summary>		
		private  int  _approvepostid;
        public  int  ApprovePostId
        {
            get{ return _approvepostid; }
            set
            { 
            	_approvepostid = value; 
            	if (Column.Contains("ApprovePostId"))
            		Column["ApprovePostId"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("ApprovePostId",
				    						DbType.Int32
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// ApprovePostName
        /// </summary>		
		private  string  _approvepostname;
        public  string  ApprovePostName
        {
            get{ return _approvepostname; }
            set
            { 
            	_approvepostname = value; 
            	if (Column.Contains("ApprovePostName"))
            		Column["ApprovePostName"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("ApprovePostName",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// Enable
        /// </summary>		
		private  int  _enable;
        public  int  Enable
        {
            get{ return _enable; }
            set
            { 
            	_enable = value; 
            	if (Column.Contains("Enable"))
            		Column["Enable"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("Enable",
				    						DbType.Int32
					, true, false, false, value));
            }
        }        
		   
	}
}