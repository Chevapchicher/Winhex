using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WinhexWebServer.Models;

namespace WinhexWebServer.Interfaces
{
    public interface ILogManager
    {
        bool AddUserLog(UserLog log);
        List<UserLog> GetUserLogs();
        UserLog GetUserLog(Expression<Func<UserLog, bool>> act);
    }
}