using System;
using System.Data;
namespace AYJZ.Entities
{
    public interface IEntityField
    {
        string FieldName { get; }
        DbType FieldType { get; set; }
        object FieldValue { get; set; }
    }
}