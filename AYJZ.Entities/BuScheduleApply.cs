using System;
using System.Data;
namespace VSM.Entities{	
	 	//BuScheduleApply
		public class BuScheduleApply : BaseEntitie
	{
   		     
      	/// <summary>
		/// ApplyId
        /// </summary>		
		private  string  _applyid;
        public  string  ApplyId
        {
            get{ return _applyid; }
            set
            { 
            	_applyid = value; 
            	if (Column.Contains("ApplyId"))
            		Column["ApplyId"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("ApplyId",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// ApplyMan
        /// </summary>		
		private  string  _applyman;
        public  string  ApplyMan
        {
            get{ return _applyman; }
            set
            { 
            	_applyman = value; 
            	if (Column.Contains("ApplyMan"))
            		Column["ApplyMan"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("ApplyMan",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// ApplyDate
        /// </summary>		
		private DateTime? _applydate;
        public DateTime? ApplyDate
        {
            get{ return _applydate; }
            set
            { 
            	_applydate = value; 
            	if (Column.Contains("ApplyDate"))
            		Column["ApplyDate"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("ApplyDate",
				    						DbType.DateTime
					, true, false, false, value));
            }
        }        
		   
	}
}