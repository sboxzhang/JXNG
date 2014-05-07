using System;
using AYJZ.Entities;
using System.Data;
namespace AYJZ.DataAccess
{
	interface IDataAccess
    {
        int Insert(BaseEntitie obj, IDbTransaction TRANS);
        int Delete(BaseEntitie obj, IDbTransaction TRANS);
        int Update(BaseEntitie obj, IDbTransaction TRANS);
    }
}