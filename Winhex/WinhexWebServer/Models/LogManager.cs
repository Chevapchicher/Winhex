using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
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
            }
            catch (Exception ex)
            {
                //todo loging
                return false;
            }
            return true;
        }
        
        public List<UserLog> GetUserLogs()
        {
            foreach (var log in db.UserLog.ToList())
            {
                Console.WriteLine(log);
            }
            return db.UserLog.ToList();
        }

        public UserLog GetUserLog(Expression<Func<UserLog, bool>> act)
        {
            return db.UserLog.FirstOrDefault(act);
        }
    }
}
