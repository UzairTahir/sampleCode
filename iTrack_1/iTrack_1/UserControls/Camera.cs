using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Web;
using System.IO;
using System.Net;
using Emgu.CV;
using Emgu.CV.Structure;
using iTrack.Controller;
using iTrack_1.View;
using System.Diagnostics;

namespace iTrack.UserControls
{
    public partial class Camera : UserControl
    {

        private EventHandler eh;
        public string url { get; set; }
        private bool running = true;
        private CameraInfo info;

        //for request frame and finish frame method
        private Bitmap loadedBitmap = null;
        private System.Threading.Thread recordingThread;
        

        ~Camera()
        {
            //recordingThread.Abort();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                    components.Dispose();
                //recordingThread.Abort();
                //recordingThread.DisableComObjectEagerCleanup();
                //recordingThread.IsBackground = true;
                //p.Kill();
                p.Kill();
                
                
            }
            base.Dispose(disposing);
        }

        //for EmguCV
        private Capture cap;

        int fps;

        public Bitmap Image
        {
            get { return (Bitmap)pbCam.Image; }
        }


        public Camera(CameraInfo cam)
        {
            InitializeComponent();
            info = cam;

            eh = new EventHandler(getFrame);
            ////Process p = new Process();
            ////p.Start

            //url = "http://";
            //url = url + cam.IP;

            //For streaming
            //url = url + "/videofeed";



            //for hikvision DS-2CD2132F-IS
            url = "rtsp://";
            url = url + info.User + ":" + info.Password;
            url = url + "@" + info.IP + "/Streaming/channels/1";


            //url = url + @"/Streaming/channels/1/picture?snapShotImageType=JPEG";
            //url =  "http://admin:admin12345@" + url + "/Streaming/channels/1/preview";
            //url = url + @"/Streaming/channels/1/preview";


            //for Image
            //url = url + "/short.jpg";

            //for commented emgucv
            //eh = new EventHandler(getFrameEmgu);
            //url = cam.IP;
            

        cap = new Capture(url);
            //cap = new Capture(0);
            //cap = new Capture("rtsp://admin:admin12345@192.168.10.201/Streaming/channels/1");
            //cap = new Emgu.CV.Capture("http://admin:admin12345@192.168.10.201/Streaming/channels/102/httppreview");
            //Application.Idle += process;
            //fps = (int)cap.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps);


            groupBox1.Text = cam.Name;
            Application.Idle += eh;


            //for Recording thread
            //recordingThread = new System.Threading.Thread(Record);
            //recordingThread.IsBackground = true;
            //recordingThread.Start();
            

            //for Recording Process
            Record();


            CameraManager cMan = CameraManager.Instance;
            cMan.addEH(info.name, eh);

            
        }


        //private VideoWriter VideoW = new VideoWriter(@"temp.avi",
        //                           CvInvoke.CV_FOURCC('M', 'P', '4', '2'), 
        //                           (Convert.ToInt32(upDownFPS.Value)), 
        //                           frame.Width, 
        //                           frame.Height, 
        //                           true); 


        

        private void Grab()
        {
            Bitmap bmp, bmp1;
            do
            {
                Mat frame = cap.QueryFrame();
                VideoWriter vw = new VideoWriter(@"C:/testing.avi", 20, new Size(frame.Width, frame.Height), true);
                vw.Write(frame);

            }
            while (true);
        }

        private Process p;
        private void Record()
        {
            
            p = new Process();
            p.StartInfo.FileName = "ffmpeg.exe";
            // p.StartInfo.Arguments = "-framerate 0.2 -i %3d.jpg -vf fps=10 -pix_fmt yuv420p output.mp4";
            //  p.StartInfo.Arguments = "-f image2 -i "+ imgD+" %3d.jpeg -r 12 -s WxH C:/ffmpeg/foo.avi";
            // p.StartInfo.Arguments = "-framerate 1/5 -i %03d.jpeg -c:v libx264 -r 30 -pix_fmt yuv420p out.mp4";
            //p.StartInfo.Arguments = " -r 2 -start_number 0 -i " + imgD + "%03d.jpeg -c:v libx264 -r 30 -pix_fmt yuv420p " + vidD + "silentVideo.mp4";
            //p.StartInfo.Arguments= "-i rtsp://admin:admin12345@192.168.10.201/Streaming/channels/1 -c copy -map 0 -f segment -segment_time 300 -segment_format mp4 \"outfile%%01.mp4\"";
            string dt = DateTime.Now.ToString(" dd-MM-yyyy h-mm-tt");
            string output = "Recording/" + info.Name + ".mp4";//+ dt + ".mp4";
            //string output = "e:/" + info.Name + ".mp4";//+ "-" + dt + ".mp4";
            //p.StartInfo.Arguments = "-i " + url + " -acodec copy " + output; //Recording/"+info.Name+dt+".mp4";
            p.StartInfo.Arguments = "-i " + url + " -acodec copy -y " + output+" "; //Recording/"+info.Name+dt+".mp4";
            p.StartInfo.UseShellExecute = false;
            //p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            
            p.Start();
            

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

            if (frame!=null)
            pbCam.Image = frame.Bitmap;


            //with Memory
            //byte[] buffer = new byte[1280 * 800];
            //int read, total = 0;
            //WebResponse res=null;

            //try
            //{
            //    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            //    res = req.GetResponse();
            //    running = true;
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show("Invalid IP");
            //    running = false;
            //    Application.Idle -= eh;
            //    this.Dispose();
            //    return;
                
            //}
            //if (res==null)
            //{
            //    MessageBox.Show("Invalid IP");
            //    Application.Idle -= eh;
            //    running = false;
            //    this.Dispose();
            //    return;
            //}
            //Stream stream = res.GetResponseStream();
           
            //while ((read = stream.Read(buffer, total, 1000)) != 0)
            //{
            //    total += read;
            //}
            
            //Bitmap bmp = (Bitmap)Bitmap.FromStream(new MemoryStream(buffer, 0, total));

            //pbCam.Image = bmp;

        }

        public Mat GetFrame()
        {
            return cap.QueryFrame();
            
            //byte[] buffer = new byte[1280 * 800];
            //int read, total = 0;
            //WebResponse res = null;
            ////Image<Bgr, byte> inputImage = new Image<Bgr, byte>(url);
            //try
            //{
            //    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            //    res = req.GetResponse();
            //}
            //catch (Exception ex)
            //{
            //    running = false;
            //    return null;
            //}
            //if (res == null)
            //{
            //    running = false;
            //    return null;
            //}
            //running = true;

            //Stream stream = res.GetResponseStream();

            //while ((read = stream.Read(buffer, total, 1000)) != 0)
            //{
            //    total += read;
            //}

            //return new Emgu.CV.Image<Bgr, Byte>((Bitmap)Bitmap.FromStream(new MemoryStream(buffer, 0, total)));

        }
        

        private void getFrameEmgu(object sender,EventArgs e)
        {
            //Capture cameraCapture;
            //cameraCapture = new Capture(String.Format("http://:@http://{0}",url));
            //Mat frame = cameraCapture.QueryFrame();
            //pbCam.Image = frame.Bitmap;
        }

        private void process(object sender, EventArgs e)
        {
            var frame = cap.QueryFrame();
            if (frame == null)
                return;
            System.Threading.Thread.Sleep(1000 / fps);
            pbCam.Image = frame.Bitmap;
        }


        public string IP
        {
            get { return url; }
        }

        public string CameraName
        {
            get { return groupBox1.Text; }
        }

        private void pbCam_Click(object sender, EventArgs e)
        {
            Tracking track = new Tracking(info);
            Application.Idle -= eh;

            track.ShowDialog();
            Application.Idle += eh;
        }





        public bool CamRunning
        {
            get { return running; }
        }

        private void requestFrame()
        {
            string cameraUrl = @"http://192.168.10.201:80/Streaming/channels/1/picture?snapShotImageType=JPEG";
            var request = System.Net.HttpWebRequest.Create(cameraUrl);
            request.Credentials = new NetworkCredential("admin","admin12345");
            request.Proxy = null;
            request.BeginGetResponse(new AsyncCallback(finishRequestFrame), request);
        }

        void finishRequestFrame(IAsyncResult result)
        {
            HttpWebResponse response = (result.AsyncState as HttpWebRequest).EndGetResponse(result) as HttpWebResponse;
            Stream responseStream = response.GetResponseStream();

            using (Bitmap frame = new Bitmap(responseStream))
            {
                if (frame != null)
                {
                    pbCam.Image = (Bitmap)frame.Clone();
                }
            }
        }


        



    }
}
