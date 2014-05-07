using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///IUserCommunications 的摘要说明
/// </summary>

public interface IUserCommunications
{
    void GetID(string strID);
    bool Save();
    Dictionary<string, object> GetFlowData();
}

