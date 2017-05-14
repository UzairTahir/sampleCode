using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using Emgu.CV.Cuda;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTrack_1.Controller;
using iTrack_1.Model;
using iTrack_1.View;
using iTrack.Controller;

namespace iTrack_1
{
    public partial class Registration : Form
    {
        List<Image<Gray, Byte>> registeredImages;
        int fps = 0;
        bool isExpertMode = true;
        CameraSource cameraSource;
        Capture videoDevice;
        FaceController face;
        DataBase db = new DataBase();
        Timer timer;

        private CameraManager CMag;
        bool camFound=false;
        CameraInfo RegCam;

        #region Initialize
        public Registration()
        {
            InitializeComponent();
            CMag = CameraManager.Instance;
            List<CameraInfo> RegCams = CMag.GetAllRegCams();
            if (RegCams.Count == 0)
            {
                camFound = false;
                cbCameraList.Enabled = true;
            }
            else
            {
                camFound = true;
                cbCameraList.Enabled = false;
                RegCam = RegCams[0];
            }
                
            
        }
        private void Registration_Load(object sender, EventArgs e)
        {
            //GPUTest();

            // Inilizations
            
            cameraSource = new CameraSource();
            face = new FaceController(FaceIdentification.registrationMinFaceSize);

            // Loading camera list
            cameraSource.FillCBWithCameras(ref cbCameraList);
            cbCameraList.SelectedIndex = 0;

            // 
            registeredImages = new List<Image<Gray, byte>>();


            // Timer
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(FpsCounter);
            //timer.Enabled = isExpertMode;
            
            //ExpertModeEnableDisable(true);
        }
        #endregion

        #region Temporary Code
        //public void GPUTest()
        //{
        //    MessageBox.Show(CudaInvoke.GetCudaDevicesSummary());

        //    if (CudaInvoke.HasCuda)
        //        MessageBox.Show("Cuda Device Detected");
        //    else
        //        MessageBox.Show("Nope could't find");
        //}

        
        #endregion

        #region Other Event Handlers

        private void expertModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).Checked = !((ToolStripMenuItem)sender).Checked;
            isExpertMode = ((ToolStripMenuItem)sender).Checked;
            ((ToolStripMenuItem)sender).CheckState = ((ToolStripMenuItem)sender).Checked?CheckState.Checked:CheckState.Unchecked;

            gbExpert.Enabled = gbExpert.Visible = isExpertMode;

        }
        void FpsCounter(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)delegate { lblFps.Text = fps.ToString(); });
            fps = 0;
        }

        void ExpertModeEnableDisable(bool expertMode)
        {
            if (expertMode)
                timer.Start();
            else
                timer.Stop();
            timer.Enabled = expertMode;
            gbExpert.Enabled = gbExpert.Visible = isExpertMode;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            if (btnStart.Text == "Start")
            {
                // initialize Camera
                if (!camFound)
                    videoDevice = new Emgu.CV.Capture(cameraSource.GetCameraIndex(cbCameraList.SelectedIndex));
                else
                    videoDevice = new Emgu.CV.Capture(RegCam.URL);

                //For getting live frame

                //videoDevice.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps, 4);
                //videoDevice.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.PosFrames, 20);
                videoDevice.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.OpenniMaxBufferSize, 1);

                videoDevice.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.OpenniCircleBuffer, 1);

                for (int i = 0; i < 30; i++)
                    videoDevice.QueryFrame();
                //videoDevice=new Emgu.CV.Capture("rtsp://")

                //videoDevice = new Emgu.CV.Capture(@"C:\Users\Nabeel\Desktop\Arrange it\Test Subjects\Video_Test_1.mp4");

                Application.Idle += new EventHandler(ProcessFrame);
                
                timer.Start();

                cbCameraList.Enabled = false;
                btnStart.Text = "Stop";
            }
            else
            {
                if (videoDevice != null)
                {
                    timer.Stop();
                    videoDevice.Dispose();
                    videoDevice = null;
                }

                cbCameraList.Enabled = true;
                pbView.Image = null;
                pbView.BackColor = Color.Black;

                cameraSource.Refresh();
                cbCameraList.Items.Clear();
                foreach (string cameraName in cameraSource.GetCamerasNames())
                    cbCameraList.Items.Add(cameraName);
                cbCameraList.SelectedIndex = 0;

                btnStart.Text = "Start";
            }
        }

        #endregion


        public static Image<Gray, byte> Sharpen(Image<Gray, byte> image)
        {
            int k = 2;

            int w = image.Size.Width;
            int h = image.Size.Height;
            w = (w % 2 == 0) ? w - 1 : w;
            h = (h % 2 == 0) ? h - 1 : h;
            var gaussianSmooth = image.SmoothGaussian(w, h, 0.5, 0.5);
            var mask = image - gaussianSmooth;
            //add a weighted value k to the obtained mask 
            mask *= k;
            //sum with the original image 
            image += mask;
            return image;
        }

        void ProcessFrame(object sender, EventArgs e)
        {
            try
            {
                fps++;
                if (videoDevice == null) return;
                for (int i = 0; i < 5; i++)
                    videoDevice.QueryFrame();
                Mat currentFrame= videoDevice.QueryFrame();

                //Mat tempFrame;
                //while(true)
                //{
                //    tempFrame = videoDevice.QueryFrame();
                //    if (tempFrame != null)
                //        currentFrame = tempFrame;
                //    else
                //        break;
                //}


                //Emgu.CV.CvInvoke.Resize(currentFrame, currentFrame, new Size(), 0.5, 0.5,Emgu.CV.CvEnum.Inter.Cubic);
                //CvInvoke.GaussianBlur(currentFrame, currentFrame,new Size(5,5),2);

                int type = 0;
                Rectangle[] faces = face.FindAllFaces(currentFrame, ref type);

                if (isExpertMode)
                    BeginInvoke((MethodInvoker)delegate { tbConsole.Text += "\n" + type; });


                pbView.Image = DrawController.DrawRectangle(faces, currentFrame, Color.Green, 1).ToBitmap();



                if (faces.Length != 0)
                {
                    // Standardize the Value (hsV)
                    // Increase contrast
                    //var enhanced = currentFrame.ToImage<Hsv, byte>().Copy();
                    //enhanced._EqualizeHist();
                    //enhanced._GammaCorrect(1.5d);
                    //for (int i = 0; i < enhanced.Size.Height; i++)
                    //    for (int j = 0; j < enhanced.Size.Width; j++)
                    //        enhanced.Data[i, j, 1] = 250;


                    var image = currentFrame.ToImage<Gray, byte>();

                    //var image = currentFrame.ToImage<Gray, byte>();

                    image.ROI = faces[0];
                    var faceImage = image.Copy().Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic);


                    if (registeredImages.Count == 0)
                    {
                        registeredImages.Add(faceImage.Convert<Gray, Byte>());
                        registeredImages.Add(faceImage.Convert<Gray, Byte>());
                        PictureBox pb = new PictureBox();
                        pb.Size = new Size(50, 50);
                        pb.Image = faceImage.ToBitmap();
                        pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        flpFaces.Controls.Add(pb);
                    }
                    else
                    {
                        bool isMatched = face.IsFaceMatched(faceImage, registeredImages.ToArray());
                        pbFace.Image = faceImage.ToBitmap();

                        //flpFaces.Controls.Clear();
                        //for(int i=1;i< registeredImages.Count;i++)
                        //{
                        //    PictureBox pb = new PictureBox();
                        //    pb.Size = new Size(50, 50);
                        //    pb.Image = registeredImages[i].ToBitmap();
                        //    pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        //    flpFaces.Controls.Add(pb);
                        //}

                        //if(isExpertMode)
                        //    BeginInvoke((MethodInvoker)delegate { tbConsole.Text = isMatched.ToString() ; });

                        if (!isMatched)
                        {
                            registeredImages.Add(faceImage.Convert<Gray, Byte>());
                            PictureBox pb = new PictureBox();
                            pb.Size = new Size(50, 50);
                            pb.Image = faceImage.ToBitmap();
                            pb.SizeMode = PictureBoxSizeMode.StretchImage;
                            flpFaces.Controls.Add(pb);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("--> " + ex.Message);
            }
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            string personName = tbName.Text;
            List<PersonInfo> person = new List<PersonInfo>();

            for(int i=1;i<registeredImages.Count;i++)
            {
                person.Add(new PersonInfo(personName,registeredImages[i].ToBitmap()));
            }

            db.Register(person);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            registeredImages.Clear();
            flpFaces.Controls.Clear();

        }

        private void btnInd_Click(object sender, EventArgs e)
        {
            Indentification indForm = new Indentification();
            indForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tracking trk = new Tracking();
            trk.Show();
        }

        //void ProcessFrame(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        fps++;
        //        if (videoDevice == null) return;

        //        Mat currentFrame = videoDevice.QueryFrame();
        //        //Emgu.CV.CvInvoke.Resize(currentFrame, currentFrame, new Size(), 0.5, 0.5,Emgu.CV.CvEnum.Inter.Cubic);
        //        //CvInvoke.GaussianBlur(currentFrame, currentFrame,new Size(5,5),2);

        //        int type = 0;
        //        Rectangle[] faces = face.FindFaces(currentFrame, ref type);

        //        pbView.Image = Draw.DrawRectangle(faces, currentFrame, Color.Green, 2).Bitmap;

        //        if (isExpertMode)
        //            BeginInvoke((MethodInvoker)delegate { tbConsole.Text += "\n" + type; });


        //        if (faces.Length != 0)
        //        {
        //            var image = currentFrame.ToImage<Gray, Byte>();
        //            image.ROI = faces[0];
        //            var faceImage = image.Copy().Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic);


        //            if (registeredImages.Count == 0)
        //            {
        //                registeredImages.Add(faceImage);
        //                registeredImages.Add(faceImage);
        //                PictureBox pb = new PictureBox();
        //                pb.Size = new Size(50, 50);
        //                pb.Image = faceImage.ToBitmap();
        //                pb.SizeMode = PictureBoxSizeMode.StretchImage;
        //                flpFaces.Controls.Add(pb);
        //            }
        //            else
        //            {
        //                double isMatched = face.IsMatched(faceImage, registeredImages.ToArray(), 100);
        //                pbFace.Image = faceImage.ToBitmap();

        //                //flpFaces.Controls.Clear();
        //                //for(int i=1;i< registeredImages.Count;i++)
        //                //{
        //                //    PictureBox pb = new PictureBox();
        //                //    pb.Size = new Size(50, 50);
        //                //    pb.Image = registeredImages[i].ToBitmap();
        //                //    pb.SizeMode = PictureBoxSizeMode.StretchImage;
        //                //    flpFaces.Controls.Add(pb);
        //                //}

        //                //if(isExpertMode)
        //                //    BeginInvoke((MethodInvoker)delegate { tbConsole.Text = isMatched.ToString() ; });

        //                if (isMatched > 100)
        //                {
        //                    registeredImages.Add(faceImage);
        //                    PictureBox pb = new PictureBox();
        //                    pb.Size = new Size(50, 50);
        //                    pb.Image = faceImage.ToBitmap();
        //                    pb.SizeMode = PictureBoxSizeMode.StretchImage;
        //                    flpFaces.Controls.Add(pb);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}


    }
}
