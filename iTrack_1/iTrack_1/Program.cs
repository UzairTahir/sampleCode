using iTrack_1.Test;
using iTrack_1.View;
using iTrack_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTrack_1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

               // Application.Run(new Registration());
                //Application.Run(new Indentification());
                //Application.Run(new Tracking());
                //Application.Run(new Testing());
                //Application.Run(new Form1());
                //Application.Run(new AccTest());
               Application.Run(new frontend());

//                Application.Run(new OdNeighbour("camera1"));
                //Application.Run(new Test.Form1());
             //  Application.Run(new iTrack.Form1());
              //  Application.Run(new ViewRecordedVideos());

            }
            catch(AccessViolationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
