using System;
using System.Data;
namespace AYJZ.Entities{	
	 	//BuSchedule
		public class BuSchedule : BaseEntitie
	{
   		     
      	/// <summary>
		/// auto_increment
        /// </summary>		
		private  int  _scheduleid;
        public  int  ScheduleId
        {
            get{ return _scheduleid; }
            set
            { 
            	_scheduleid = value; 
            	if (Column.Contains("ScheduleId"))
            		Column["ScheduleId"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("ScheduleId",
				    						DbType.Int32
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// ScheduleName
        /// </summary>		
		private  string  _schedulename;
        public  string  ScheduleName
        {
            get{ return _schedulename; }
            set
            { 
            	_schedulename = value; 
            	if (Column.Contains("ScheduleName"))
            		Column["ScheduleName"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("ScheduleName",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// CreateMan
        /// </summary>		
		private  string  _createman;
        public  string  CreateMan
        {
            get{ return _createman; }
            set
            { 
            	_createman = value; 
            	if (Column.Contains("CreateMan"))
            		Column["CreateMan"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("CreateMan",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// CreateDate
        /// </summary>		
		private DateTime? _createdate;
        public DateTime? CreateDate
        {
            get{ return _createdate; }
            set
            { 
            	_createdate = value; 
            	if (Column.Contains("CreateDate"))
            		Column["CreateDate"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("CreateDate",
				    						DbType.DateTime
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// UpdateMan
        /// </summary>		
		private  string  _updateman;
        public  string  UpdateMan
        {
            get{ return _updateman; }
            set
            { 
            	_updateman = value; 
            	if (Column.Contains("UpdateMan"))
            		Column["UpdateMan"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("UpdateMan",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// UpdateDate
        /// </summary>		
		private  string  _updatedate;
        public  string  UpdateDate
        {
            get{ return _updatedate; }
            set
            { 
            	_updatedate = value; 
            	if (Column.Contains("UpdateDate"))
            		Column["UpdateDate"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("UpdateDate",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// ScheduleStatus
        /// </summary>		
		private  string  _schedulestatus;
        public  string  ScheduleStatus
        {
            get{ return _schedulestatus; }
            set
            { 
            	_schedulestatus = value; 
            	if (Column.Contains("ScheduleStatus"))
            		Column["ScheduleStatus"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("ScheduleStatus",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// ScheduleKind
        /// </summary>		
		private  int  _schedulekind;
        public  int  ScheduleKind
        {
            get{ return _schedulekind; }
            set
            { 
            	_schedulekind = value; 
            	if (Column.Contains("ScheduleKind"))
            		Column["ScheduleKind"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("ScheduleKind",
				    						DbType.Int32
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// StationId
        /// </summary>		
		private  string  _stationid;
        public  string  StationId
        {
            get{ return _stationid; }
            set
            { 
            	_stationid = value; 
            	if (Column.Contains("StationId"))
            		Column["StationId"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("StationId",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// StationBossId
        /// </summary>		
		private  string  _stationbossid;
        public  string  StationBossId
        {
            get{ return _stationbossid; }
            set
            { 
            	_stationbossid = value; 
            	if (Column.Contains("StationBossId"))
            		Column["StationBossId"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("StationBossId",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// ExecuteDate
        /// </summary>		
		private DateTime? _executedate;
        public DateTime? ExecuteDate
        {
            get{ return _executedate; }
            set
            { 
            	_executedate = value; 
            	if (Column.Contains("ExecuteDate"))
            		Column["ExecuteDate"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("ExecuteDate",
				    						DbType.DateTime
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
		/// <summary>
		/// StartAddress
        /// </summary>		
		private  string  _startaddress;
        public  string  StartAddress
        {
            get{ return _startaddress; }
            set
            { 
            	_startaddress = value; 
            	if (Column.Contains("StartAddress"))
            		Column["StartAddress"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("StartAddress",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// BigStationId
        /// </summary>		
		private  int  _bigstationid;
        public  int  BigStationId
        {
            get{ return _bigstationid; }
            set
            { 
            	_bigstationid = value; 
            	if (Column.Contains("BigStationId"))
            		Column["BigStationId"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("BigStationId",
				    						DbType.Int32
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// TakeTime
        /// </summary>		
		private DateTime? _taketime;
        public DateTime? TakeTime
        {
            get{ return _taketime; }
            set
            { 
            	_taketime = value; 
            	if (Column.Contains("TakeTime"))
            		Column["TakeTime"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("TakeTime",
				    						DbType.DateTime
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// AddTime
        /// </summary>		
		private DateTime? _addtime;
        public DateTime? AddTime
        {
            get{ return _addtime; }
            set
            { 
            	_addtime = value; 
            	if (Column.Contains("AddTime"))
            		Column["AddTime"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("AddTime",
				    						DbType.DateTime
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// TargetAddress
        /// </summary>		
		private  string  _targetaddress;
        public  string  TargetAddress
        {
            get{ return _targetaddress; }
            set
            { 
            	_targetaddress = value; 
            	if (Column.Contains("TargetAddress"))
            		Column["TargetAddress"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("TargetAddress",
				    						DbType.String
					, true, false, false, value));
            }
        }        
		/// <summary>
		/// NeedTime
        /// </summary>		
		private DateTime? _needtime;
        public DateTime? NeedTime
        {
            get{ return _needtime; }
            set
            { 
            	_needtime = value; 
            	if (Column.Contains("NeedTime"))
            		Column["NeedTime"].FieldValue = value;
            	else
            		Column.Add(new ColumnSchema("NeedTime",
				    						DbType.DateTime
					, true, false, false, value));
            }
        }        
		   
	}
}