using System;
using System.Windows.Forms;

namespace MonitoringApp
{
    static class Program
    {
        /// <summary>
        /// G��wna metoda wej�ciowa dla aplikacji.
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
