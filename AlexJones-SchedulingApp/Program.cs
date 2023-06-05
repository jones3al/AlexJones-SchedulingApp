using AlexJones_SchedulingApp.Database;
using System;
using System.Windows.Forms;

namespace AlexJones_SchedulingApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            DBHelper.StartConnection();
            Application.Run(new LoginForm());
            DBHelper.CloseConnection();
        }
    }
}
