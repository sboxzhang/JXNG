using System;
using System.Data;
namespace AYJZ.Entities
{
    public class ColumnSchema : IEntityField
    {
        public ColumnSchema()
        { }
        public ColumnSchema(string name, DbType dbtype, bool isnullable, bool isprimarykey, bool isforeighkey, object columnvalue)
        {
            _name = name;
            _dbType = dbtype;
            _isNullable = isnullable;
            _isPrimaryKey = isprimarykey;
            _isForeighKey = isforeighkey;
            _columnvalue = columnvalue;
        }
        #region 
        private string _name;
        private DbType _dbType;
        private bool _isNullable;
        private bool _isPrimaryKey;
        private bool _isForeighKey;
        private object _columnvalue;
        #endregion

        #region 
        
        public string FieldName
        {
            get { return _name; }
        }
        
        public DbType FieldType
        {
            get { return _dbType; }
            set { _dbType = value; }
        }
        
        public bool IsNullable
        {
            get { return _isNullable; }
            set { _isNullable = value; }
        }
        
        public bool IsPrimeryKey
        {
            get { return _isPrimaryKey; }
            set { _isPrimaryKey = value; }
        }
        
        public bool IsForeighKey
        {
            get { return _isForeighKey; }
            set { _isForeighKey = value; }
        }
        
        public object FieldValue
        {
            get { return _columnvalue; }
            set { _columnvalue = value; }
        }
        #endregion
    }
}