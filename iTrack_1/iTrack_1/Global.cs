using Emgu.CV.Cuda;
using System;
using System.Windows.Forms;

namespace iTrack_1
{
    class Global
    {
        public static bool useCuda = false;
        public static string VideoOutputDirectory = "Output/";

        public static bool canRunCuda
        {
            get
            { return (CudaInvoke.HasCuda && Global.useCuda); }
        }
    }

    class Debug
    {
        public static TextBox trackingConsole;
        

        public static void ClearTrackConsole()
        {
            trackingConsole.Text = "";
        }
        public static void AddTrackText (string text,bool newLine = true)
        {
            if (newLine && trackingConsole.Text != "")
                trackingConsole.AppendText(Environment.NewLine);
            trackingConsole.AppendText(text);
        }
             

    }
}
