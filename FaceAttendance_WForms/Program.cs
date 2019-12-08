using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.ExceptionServices;

namespace FaceAttendance_WForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        [HandleProcessCorruptedStateExceptions]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new LandingForm());
            }
            catch (AccessViolationException e)
            {
                Console.WriteLine(e.StackTrace.ToString());
            }
            
        }
    }
}
