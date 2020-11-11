using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WinhexWebServer.Models;

namespace WinhexWebServer.Interfaces
{
    public interface ILogManager
    {
        bool AddUserLog(UserLog log);
        UserLog[] GetUsers();
        UserLog GetUserLog(Expression<Func<UserLog, bool>> act);
        bool SetNote(int id, string note);
    }
}