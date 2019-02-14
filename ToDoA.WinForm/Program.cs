using Autofac;
using System;
using System.Windows.Forms;
using Autofac.Core;
using ToDoA.Data.Database;
using Container = System.ComponentModel.Container;

namespace ToDoA.WinForm
{
    static class Program
    {
        private static Container container;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
