using System;
using System.Data;
namespace AYJZ.Entities{	
	 	//BuTypeInfo
		public class BuTypeInfo : BaseEntitie
	{
   		     
      	/// <summary>
		/// auto_increment
        /// </summary>		
		private  int  _typeid;
        public  int  TypeId
        {
            get{ return _typeid; }
            set
            { 
            	_typeid = value; 
            	if (Column.Contains("TypeId"))
            		Column["TypeId"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("TypeId",
				    						DbType.Int32
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// TypeName
        /// </summary>		
		private  string  _typename;
        public  string  TypeName
        {
            get{ return _typename; }
            set
            { 
            	_typename = value; 
            	if (Column.Contains("TypeName"))
            		Column["TypeName"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("TypeName",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// KindId
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
		   
	}
}