using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WinhexWebServer.Interfaces;

namespace WinhexWebServer.Models
{
    public class LogManager : ILogManager
    {
        private Context db;

        public LogManager(Context c)
        {
            db = c;
        }
        public bool AddUserLog(UserLog log)
        {
            try
            {
                db.UserLog.Add(log);
                db.SaveChanges();
                var tt = db.UserLog.FirstOrDefault(x => x.SendingDateTime == log.SendingDateTime);
               
            }
            catch (Exception ex)
            {
                //todo loging
                return false;
            }
            return true;
        }
        
        public UserLog[] GetUserLogs()
        {
            return db.UserLog.Include(x => x.Logs).ToArray();
        }

        public UserLog GetUserLog(Expression<Func<UserLog, bool>> act)
        {
            return db.UserLog.Include(x => x.Logs).FirstOrDefault(act);
        }
    }
}
