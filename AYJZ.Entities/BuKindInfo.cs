using System;
using System.Data;
namespace AYJZ.Entities{	
	 	//BuKindInfo
		public class BuKindInfo : BaseEntitie
	{
   		     
      	/// <summary>
		/// auto_increment
        /// </summary>		
		private  int  _kindid;
        public  int  KindId
        {
            get{ return _kindid; }
            set
            { 
            	_kindid = value; 
            	if (Column.Contains("KindId"))
            		Column["KindId"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("KindId",
				    						DbType.Int32
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// KindName
        /// </summary>		
		private  string  _kindname;
        public  string  KindName
        {
            get{ return _kindname; }
            set
            { 
            	_kindname = value; 
            	if (Column.Contains("KindName"))
            		Column["KindName"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("KindName",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		   
	}
}