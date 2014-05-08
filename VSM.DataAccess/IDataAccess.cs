using System;
using VSM.Entities;
using System.Data;
namespace VSM.DataAccess
{
	interface IDataAccess
    {
        int Insert(BaseEntitie obj, IDbTransaction TRANS);
        int Delete(BaseEntitie obj, IDbTransaction TRANS);
        int Update(BaseEntitie obj, IDbTransaction TRANS);
    }
}