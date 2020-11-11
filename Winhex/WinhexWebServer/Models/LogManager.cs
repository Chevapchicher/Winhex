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

        public LogManager()//Context c)
        {
        }
        public bool AddUserLog(UserLog log)
        {
<<<<<<< HEAD
            //try
            //{
            //    db.UserLog.Add(log);
            //    db.SaveChanges();
            //    var tt = db.UserLog.FirstOrDefault(x => x.SendingDateTime == log.SendingDateTime);
=======
            try
            {
                var userLog = db.UserLog.FirstOrDefault(x => x.CompName == log.CompName);

                if (userLog == null)
                    db.UserLog.Add(log);
                else
                    userLog.Logs.AddRange(log.Logs);

                db.SaveChanges();
>>>>>>> a643e807a398f7d545a0f0de378f13d060b280e3
               
            //}
            //catch (Exception ex)
            //{
            //    //todo loging
            //    return false;
            //}
            return true;
        }
        
        public UserLog[] GetUsers()
        {
<<<<<<< HEAD
            // return db.UserLog.Include(x => x.Logs).ToArray();
            return new[] { new UserLog() { CompName = "123", SendingDateTime = DateTime.MaxValue } };
=======
            return db.UserLog.ToArray();
>>>>>>> a643e807a398f7d545a0f0de378f13d060b280e3
        }

        public UserLog GetUserLog(Expression<Func<UserLog, bool>> act)
        {
            return db.UserLog.Include(x => x.Logs).FirstOrDefault(act);
        }

        public bool SetNote(int id, string note)
        {
            var user = db.UserLog.FirstOrDefault(x => x.Id == id);
            if (user == null) return false;
            user.CustomNote = note;
            db.SaveChanges();
            return true;
        }
    }
}
