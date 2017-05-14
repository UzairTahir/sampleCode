using Emgu.CV;
using iTrack.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTrack_1.View
{
    public partial class CamerafromMap : Form
    {

        EventHandler eh;
        string url;
        CameraInfo info;
        EventHandler parent;
        private Capture cap;
        public CamerafromMap(CameraInfo cam,EventHandler par)
        {
            InitializeComponent();


            info = cam;
            url = "rtsp://";
            url = url + info.User + ":" + info.Password;
            url = url + "@" + info.IP + "/Streaming/channels/1";

            parent = par;
            cap = new Capture(url);
            eh = new EventHandler(getFrame);
            Application.Idle += eh;


        }


        private void getFrame(object sender, EventArgs e)
        {
            //for downloading
            //pbCam.Load(url);

            //requestFrame();
            //return;
            //pbCam.Image = (Bitmap)loadedBitmap;

            //using EmguCV
            Mat frame = cap.QuerySmallFrame();

            if (frame != null)
                pictureBox1.Image = frame.Bitmap;
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Confirm user wants to close
            Application.Idle -= eh;
            Application.Idle += parent;

        }

    }
}
