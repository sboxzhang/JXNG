using System;
using System.Data;
namespace VSM.Entities{	
	 	//BuPost
		public class BuPost : BaseEntitie
	{
   		     
      	/// <summary>
		/// auto_increment
        /// </summary>		
		private  int  _postid;
        public  int  PostId
        {
            get{ return _postid; }
            set
            { 
            	_postid = value; 
            	if (Column.Contains("PostId"))
            		Column["PostId"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("PostId",
				    						DbType.Int32
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// PostName
        /// </summary>		
		private  string  _postname;
        public  string  PostName
        {
            get{ return _postname; }
            set
            { 
            	_postname = value; 
            	if (Column.Contains("PostName"))
            		Column["PostName"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("PostName",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// UserId
        /// </summary>		
		private  int  _userid;
        public  int  UserId
        {
            get{ return _userid; }
            set
            { 
            	_userid = value; 
            	if (Column.Contains("UserId"))
            		Column["UserId"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("UserId",
				    						DbType.Int32
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// UserName
        /// </summary>		
		private  string  _username;
        public  string  UserName
        {
            get{ return _username; }
            set
            { 
            	_username = value; 
            	if (Column.Contains("UserName"))
            		Column["UserName"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("UserName",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		   
	}
}