using Emgu.CV;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using iTrack.Controller;
using iTrack_1.Controller;
using iTrack_1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTrack_1.View
{
    public partial class Indentification : Form
    {
        Capture videoDevice;
        FaceController face;
        Timer timer;
        int fps = 0;
        int totalFrames = 0;
        List<long> msColl = new List<long>();

        private EventHandler eh;
        CameraManager cMan;

        public Indentification()
        {
            InitializeComponent();

            cMan = CameraManager.Instance;
            face = new FaceController(FaceIdentification.identificaitonMinFaceSize);
            //face.LoadRecognizer();
            // initialize Camera

            List<CameraInfo> inf = cMan.GetAllIdnCams();
            //if (inf.Count > 0)
            //    videoDevice = new Emgu.CV.Capture(inf[0].URL);
            //else
                videoDevice = new Emgu.CV.Capture(0);


            for(int i=0;i<30;i++)
            {
                videoDevice.QueryFrame();
            }


            //videoDevice = new Emgu.CV.Capture(@"C:\Users\Nabeel\Desktop\Arrange it\Test Subjects\Video_Test_1.mp4");
            eh = new EventHandler(ProcessFrame);
            Application.Idle += eh;

            // Timer
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(FpsCounter);

            timer.Start();
            sw.Start();
        }
        Stopwatch sw = new Stopwatch();

        List<PersonInfo> authorized = new List<PersonInfo>();
        List<PersonInfo> unauthorized = new List<PersonInfo>();


        void FpsCounter(object sender, EventArgs e)
        {
            try
            {
                Invoke((MethodInvoker)delegate { lblFps.Text = fps.ToString(); });
                fps = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void ProcessFrame(object sender, EventArgs e)
        {
            //FindAverageFrameTime();

            fps++;
            if (videoDevice == null) return;
            try
            {
                for (int i = 0; i < 10; i++)
                    videoDevice.QueryFrame();
                
                Mat currentFrame = videoDevice.QueryFrame();
                //Emgu.CV.CvInvoke.Resize(currentFrame, currentFrame, new Size(), 0.5, 0.5,Emgu.CV.CvEnum.Inter.Cubic);
                //CvInvoke.GaussianBlur(currentFrame, currentFrame,new Size(5,5),2);


                int type = 0;
                Rectangle[] faces = face.FindAllFaces(currentFrame, ref type);


                if (faces.Length != 0)
                {
                    var image = currentFrame.ToImage<Gray, Byte>();
                    var colorFace = currentFrame.ToImage<Bgr, byte>();
                    image.ROI = faces[0];
                    colorFace.ROI = faces[0];
                    Image<Gray, Byte> faceImage = image.Copy().Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic);

                    double distance = 0;
                    int personId = face.MatchedFace(faceImage, ref distance);

                    //if (personId != -1)
                    //{


                    int guess = GuessFace(personId);
                    if (guess == -1)
                    {
                        // Unauthorized
                        pbView.Image = DrawController.DrawRectangle(faces, currentFrame, Color.Red, 2).ToBitmap();

                        for (int i = 0; i < unauthorized.Count; i++)
                            if (unauthorized[i].id == personId)
                                return;
                        unauthorized.Add(new PersonInfo(personId, "unknown", colorFace.Copy().Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic).ToBitmap()));
                        MessageBox.Show("Unauthorized Person Detected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (guess == -2)
                    {
                        pbView.Image = DrawController.DrawRectangle(faces[0], "Working...", currentFrame.ToImage<Bgr, byte>(), Color.Yellow, 2).ToBitmap();
                    }
                    else
                    {
                        // Authorized

                        string personName = face.GetPersonName(personId);
                        pbView.Image = DrawController.DrawRectangle(faces[0], personName, currentFrame.ToImage<Bgr, Byte>(), Color.Green, 2).ToBitmap();
                        //BeginInvoke((MethodInvoker)delegate { tbConsole.Text += "\n" + pr.Label.ToString()+" Detected"; });

                        for (int i = 0; i < authorized.Count; i++)
                            if (authorized[i].id == personId)
                                return;

                        authorized.Add(new PersonInfo(personId, personName, colorFace.Copy().Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic).ToBitmap()));
                    }
                    //}
                    //else
                    //{
                    //    // Face Mismatched
                    //    pbView.Image = DrawController.DrawRectangle(faces, currentFrame, Color.Red, 2).ToBitmap();
                    //}

                    BeginInvoke((MethodInvoker)delegate { tbConsole.Text = distance + " " + personId.ToString(); });

                }
                else
                    pbView.Image = currentFrame.Bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.InnerException);
            }
        }

        private void FindAverageFrameTime()
        {
            sw.Stop();

            long currMS = sw.ElapsedMilliseconds;
            totalFrames++;
            msColl.Add(currMS);



            if (totalFrames == 100)
                Invoke((MethodInvoker)delegate
                {
                    tbConsole.Text += (msColl.Sum() / totalFrames).ToString() + "   ";
                    totalFrames = 0;
                    msColl.Clear();
                });
            else
                Invoke((MethodInvoker)delegate
                {
                    lblFps.Text = currMS.ToString();
                });

            sw.Restart();
        }

        private void Indentification_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer.Stop();
            timer.Enabled = false;
            this.Dispose();
        }

        private void cbUseGpu_CheckedChanged(object sender, EventArgs e)
        {
            Global.useCuda = cbUseGpu.Checked;
        }



        public class Pair<T1, T2>
        {
            public T1 id { get; set; }
            public T2 count { get; set; }

            public Pair(T1 id, T2 count)
            {
                this.id = id;
                this.count = count;
            }
        }
        List<Pair<int, int>> faceRec = new List<Pair<int, int>>();
        int faceCountThreshold = 10;

        // Suggestion: make all other count to 1 if faceCountThreshold meet
        public int GuessFace(int id)
        {
            // -1 is face not recognized
            // -2 working on it


            for (int i = 0; i < faceRec.Count; i++)
            {
                if (faceRec[i].id == id)
                {
                    faceRec[i].count++;
                    if (faceRec[i].count >= faceCountThreshold)
                    {
                        for (int j = 0; j < faceRec.Count; j++)
                        {
                            if (i == j)
                                continue;

                            faceRec[j].count = 1;
                        }
                        return i;
                    }
                    else
                        return -2;
                }
            }

            // if no match found before
            faceRec.Add(new Pair<int, int>(id, 1));
            return -2;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Confirm user wants to close
            Application.Idle -= eh;

        }


    }
}
