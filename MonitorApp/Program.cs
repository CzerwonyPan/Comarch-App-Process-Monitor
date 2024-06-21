using System;
using System.Windows.Forms;

namespace MonitoringApp
{
    static class Program
    {
        /// <summary>
        /// G³ówna metoda wejœciowa dla aplikacji.
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
