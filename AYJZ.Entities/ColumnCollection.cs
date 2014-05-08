using System;
using System.Collections.Generic;
namespace VSM.Entities
{
    public class ColumnCollection : List<ColumnSchema>
    {
        public ColumnSchema this[string columnName]
        {
            get
            {
                ColumnSchema column = FindColumn(columnName);
                if (column == null)
                {
                    throw new Exception("??????");
                }
                return column;
            }
        }

        public ColumnSchema FindColumn(string columnName)
        {
            Predicate<ColumnSchema> find = delegate(ColumnSchema column)
            {
                return column.FieldName.Equals(columnName);
            };
            return base.Find(find);
        }

        public bool Contains(string columnName)
        {
            return FindColumn(columnName) != null;
        }
    }
}