using System;
using System.Collections.Generic;
using System.Management;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winhex.Interfaces;
using Winhex.Models;

namespace Winhex
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var syms = new []
            {
                'a', 'b', 'c', 'd', 'e',
                'g', 'h', 'i', 'j', ' '
            };

            Task.Run(() =>
            {
                ILogCreator loger = new UserLogCreator();
                int c = 0;
                while (true)
                {
                    Random rand = new Random();
                    if (c > 40) c = 0;
                    if (c > 20) loger.AddKey("Chrome", syms[rand.Next(0, 9)]);
                    else loger.AddKey("Yandex", syms[rand.Next(0, 9)]);
                    Thread.Sleep(1000);
                    c++;
                }
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<UserAction> actions = new List<UserAction>();
            actions.Add(new UserAction() { ActionDateTime = DateTime.Now, AppTitle = "Chrome", TextLog = "heelo!" });
            actions.Add(new UserAction() { ActionDateTime = DateTime.Now, AppTitle = "Yandex", TextLog = "hih" });
            var log = new UserLog() { CompName = "New", SendingDateTime = DateTime.Now };
            log.Logs.Add(actions[0]);
            log.Logs.Add(actions[1]);

            WebSender.SendToServer(log, "http://www.ihih.somee.com/upload");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //List<UserAction> actions = new List<UserAction>();
            //actions.Add(new UserAction() { ActionDateTime = DateTime.Now, AppTitle = "Chrome", TextLog = "heelo!" });
            //actions.Add(new UserAction() { ActionDateTime = DateTime.Now, AppTitle = "Yandex", TextLog = "hih" });
            //var log = new UserLog() { CompName = "Old", SendingDateTime = DateTime.Now };
            //log.Logs.Add(actions[0]);
            //log.Logs.Add(actions[1]);

            //WebSender.SendToServer(log, "http://www.ihih.somee.com/upload");
        }
    }
}
