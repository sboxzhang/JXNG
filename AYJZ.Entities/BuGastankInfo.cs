using System;
using System.Data;
namespace AYJZ.Entities{	
	 	//BuGastankInfo
		public class BuGastankInfo : BaseEntitie
	{
   		     
      	/// <summary>
		/// TankNumber
        /// </summary>		
		private  string  _tanknumber;
        public  string  TankNumber
        {
            get{ return _tanknumber; }
            set
            { 
            	_tanknumber = value; 
            	if (Column.Contains("TankNumber"))
            		Column["TankNumber"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("TankNumber",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// TankKind
        /// </summary>		
		private  string  _tankkind;
        public  string  TankKind
        {
            get{ return _tankkind; }
            set
            { 
            	_tankkind = value; 
            	if (Column.Contains("TankKind"))
            		Column["TankKind"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("TankKind",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// TankVolume
        /// </summary>		
		private  string  _tankvolume;
        public  string  TankVolume
        {
            get{ return _tankvolume; }
            set
            { 
            	_tankvolume = value; 
            	if (Column.Contains("TankVolume"))
            		Column["TankVolume"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("TankVolume",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// Tank1
        /// </summary>		
		private  string  _tank1;
        public  string  Tank1
        {
            get{ return _tank1; }
            set
            { 
            	_tank1 = value; 
            	if (Column.Contains("Tank1"))
            		Column["Tank1"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("Tank1",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// Tank2
        /// </summary>		
		private  string  _tank2;
        public  string  Tank2
        {
            get{ return _tank2; }
            set
            { 
            	_tank2 = value; 
            	if (Column.Contains("Tank2"))
            		Column["Tank2"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("Tank2",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// Tank3
        /// </summary>		
		private  string  _tank3;
        public  string  Tank3
        {
            get{ return _tank3; }
            set
            { 
            	_tank3 = value; 
            	if (Column.Contains("Tank3"))
            		Column["Tank3"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("Tank3",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		   
	}
}