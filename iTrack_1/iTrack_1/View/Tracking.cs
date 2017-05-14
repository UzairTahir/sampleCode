using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.VideoSurveillance;
using iTrack.Controller;
using iTrack_1.Controller;
using iTrack_1.Model;
using iTrack_1.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTrack_1.View
{
    public partial class Tracking : Form
    {

        BodyController body = new BodyController();
        Track track;
        Capture videoDevice;
        Timer timer;
        int fps = 0;
        EventHandler eh;

        bool isLive = false;
        public CameraInfo info;
        private int skipCams = 2;

        bool isFirstTimeInNewNeighbour = false;

        string currentCam;

        CameraManager cMan = CameraManager.Instance;

        #region Initailization

        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlAppDomain)]
        public Tracking(string file)
        {
            currentCam = file.Substring(10).Split('_')[0].Split('.')[0];

            isLive = false;
            InitializeComponent();

            System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.High;

            videoDevice = new Emgu.CV.Capture(file);
            videoDevice.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.OpenniMaxBufferSize, 1);

            videoDevice.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.OpenniCircleBuffer, 1);




            eh = new EventHandler(ProcessFrame);
            Application.Idle += eh;



            flpsuspects.Controls.Add(new BodyFeatureView());
            flpsuspects.Controls.Add(new BodyFeatureView());

        }
        public Tracking()
        {
            
            
            isLive = true;
            InitializeComponent();

            System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.High;

            //cMan = CameraManager.Instance;
            List<CameraInfo> cam = cMan.GetAllTrackCams();
            if (cam.Count > 0)
                videoDevice = new Emgu.CV.Capture(cam[0].URL);
            else
                videoDevice = new Emgu.CV.Capture(0);

            info = cam[0];
            videoDevice.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.OpenniMaxBufferSize, 1);

            videoDevice.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.OpenniCircleBuffer, 1);

            for (int i = 0; i < 30; i++)
                videoDevice.QueryFrame();


            eh = new EventHandler(ProcessFrame);
            Application.Idle += eh;

            skipCams = 20;

            flpsuspects.Controls.Add(new BodyFeatureView());
            flpsuspects.Controls.Add(new BodyFeatureView());

        }
        public Tracking(CameraInfo inf)
        {
            

            isLive = true;

            InitializeComponent();

            System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.High;

            //videoDevice = new Emgu.CV.Capture(0);
            //videoDevice = new Emgu.CV.Capture(@"C:\Users\Nabeel\Desktop\Test_Videos\TV_6.mp4");

            info = inf;
            string url = "rtsp://";
            url = url + info.User + ":" + info.Password;
            url = url + "@" + info.IP + "/Streaming/channels/1";
            videoDevice = new Emgu.CV.Capture(url);
            //videoDevice = new Emgu.CV.Capture(@"C:\Users\Nabeel\Desktop\Arrange it\Test Subjects\Video_Test_1.mp4");
            //videoDevice = new Emgu.CV.Capture(@"C:\Users\Nabeel\Desktop\Arrange it\Test Subjects\Video_Test_2.mp4");


            Application.Idle += new EventHandler(ProcessFrame);

            for (int i = 0; i < 30; i++)
                videoDevice.QueryFrame();

            skipCams = 20;
            // Timer FPS
            //timer = new Timer();
            //timer.Interval = 1000;
            //timer.Tick += new EventHandler(FpsCounter);

            //timer.Start();


            //AppDomain currentDomain = AppDomain.CurrentDomain;
            //currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);
            //currentDomain.UnhandledException += CurrentDomain_UnhandledException;


            // enabling it when re-identification is enabled
            //track = new Track(ref timeLine,new TimeInterval(DateTime.Now, DateTime.Now.AddMinutes(10)));


            flpsuspects.Controls.Add(new BodyFeatureView());
            flpsuspects.Controls.Add(new BodyFeatureView());
        }
        
        private void Tracking_Load(object sender, EventArgs e)
        {
            Debug.trackingConsole = tbConsole;
        }



        #endregion

        #region Exception Handler
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            //throw new NotImplementedException();
        }

        void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;

            //ProcessFrame(sender,args);

        }
        #endregion
        

        void FpsCounter(object sender, EventArgs e)
        {
            //try
            //{
            //    int currFps = fps;
            //    BeginInvoke((MethodInvoker)delegate { lblFps.Text = currFps.ToString(); });
            //    fps = 0;
            //}
            //catch (AccessViolationException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }


        //BackgroundSubtractor mogDetector = new BackgroundSubtractorMOG2(500, 16, false);
        //BodyInfo person1 = null;
        //List<BodyInfo> person1 = new List<BodyInfo>();

        Rectangle[] detectedBodies;
        Image<Bgr, byte> tagetbodyImage = null;

        CameraInfo odNeighbour;
        bool lastSeenOnOD_Door = false;

        //int i = 0;
        void ProcessFrame(object sender, EventArgs e)
        {
            if (btn_pause.Checked) return;


            try
            {
                fps++;

                #region Get Frame
                if (videoDevice == null)
                    return;
                //videoDevice.QueryFrame();      
                for (int i = 0; i < skipCams; i++)
                    cMan.getRecordedFrame(currentCam);
                //videoDevice.QuerySmallFrame();

                Mat frame = cMan.getRecordedFrame(currentCam);
                


                //Mat frame = videoDevice.QuerySmallFrame();
                //Mat frame = videoDevice.QueryFrame();

                if (frame == null || frame.IsEmpty)
                {
                    GenerateVideo();
                    return;
                }
                    

                frame = frame.ToImage<Bgr, byte>().Resize(640, 480,Inter.Cubic).Mat;

                //pbView.Image = frame.Bitmap;
                //return;

                #endregion
                
                detectedBodies = body.GetAllPersonBodies(frame);

                if (detectedBodies != null && detectedBodies.Length != 0)
                {

                    #region Variable initialization
                    List<Rectangle> brec = new List<Rectangle>();
                    List<double> distHog = new List<double>();
                    List<double> distHs = new List<double>();
                    List<double> distRgb = new List<double>();
                    List<bool> mtch = new List<bool>();


                    int index = 0;
                    ((BodyFeatureView)flpsuspects.Controls[0]).ClearControl();
                    ((BodyFeatureView)flpsuspects.Controls[1]).ClearControl();
                    #endregion

                    foreach (Rectangle detectedBody in detectedBodies)
                    {
                        #region Body Crop and Resize
                        // Cropping image
                        var img = frame.ToImage<Bgr, byte>();
                        img.ROI = detectedBody;
                        img = img.Copy();

                        // Reduce rectangle size to remove background
                        Size imgSize = img.Size;
                        img.ROI = new Rectangle((imgSize.Width / 4), (imgSize.Height / 8), (imgSize.Width / 2), (int)(imgSize.Height / 1.5)); img = img.Copy();
                        img = img.Copy();

                        img = img.Resize(64, 128, Inter.Cubic);
                        #endregion

                        #region Equaulize the body

                        // 1
                        //img._EqualizeHist();

                        // 2 YCrCb method
                        Image<Ycc, byte> yccImage = img.Convert<Ycc, byte>();
                        //var channels = yccImage.Split();
                        //channels[0]._EqualizeHist();
                        //yccImage[0] = channels[0];
                        yccImage[0]._EqualizeHist();
                        img = yccImage.Convert<Bgr, byte>();
                        //CvInvoke.Merge(channels, yccImage);


                        #endregion


                        if (rbIndentification.Checked)
                        {
                            #region Identification
                            // non-tracking mode


                            bfvTarget.ClearControl();
                            bfvTarget.RefreshImage(img);

                            tagetbodyImage = (img);


                            pbView.Image = DrawController.DrawRectangle(detectedBodies, frame, Color.Yellow, 2).ToBitmap();
                            #endregion
                        }
                        else
                        {
                            #region Re-identification

                            if (tagetbodyImage != null)
                            {
                                // Get its bodyfeatures
                                body.AddTargetBody(body.GetAllBodyFeatures(tagetbodyImage));
                                tagetbodyImage = null;
                            }


                            // tracking mode
                            // Can use this to display all person on side
                            // pbBody.Image = img.ToBitmap();

                            if (index < 2)
                                ((BodyFeatureView)flpsuspects.Controls[index]).RefreshImage(img);


                            // Extract Features after removing background
                            body.suspectBody = body.GetAllBodyFeatures(img);


                            // Just for display OTHERWISE use direct method
                            double distancHog = body.GetHogDistance();
                            double distanceHs = body.GetHSDistance();
                            double distanceRgb = body.GetRGBDistance();

                            if (index < 2)
                                ((BodyFeatureView)flpsuspects.Controls[index++]).RefreshText(distancHog, distanceRgb, distanceHs);

                            brec.Add(detectedBody);
                            distHog.Add(distancHog);
                            distHs.Add(distanceHs);
                            distRgb.Add(distanceRgb);

                            //bool isMatched = body.IsBodySame(distancHog, distanceHs, distanceRgb);
                            bool isMatched = body.IsBodySame();

                            mtch.Add(isMatched);



                            #endregion
                        }

                    }


                    Rectangle mostMatchedBodyLocation = Rectangle.Empty;
                    bool isSuspectFound = false;
                    Rectangle lastSuspectPosition = new Rectangle();
                    if (!rbIndentification.Checked)
                    {

                        #region Find most matched body and its location and Verification
                        int suspectIndexinMtch = -1;
                        body.FindMostMatchedBody(distHog, distHs, distRgb, ref mtch);
                        for (int i = 0; i < mtch.Count; i++)
                            if (mtch[i])
                            {
                                mostMatchedBodyLocation = detectedBodies[i];
                                //When body is found using DC then Set the person verification (i.e. set the body
                                // to track if it is lost in next frame)
                                body.SetPersonVerification(frame, mostMatchedBodyLocation, detectedBodies);
                                suspectIndexinMtch = i;

                                if(isFirstTimeInNewNeighbour)
                                {
                                    // Add suspect image everytime camera switches
                                    Debug.AddTrackText("New Body Image added");
                                    var temp = frame.ToImage<Bgr, byte>();
                                    temp.ROI = mostMatchedBodyLocation;

                                    body.AddTargetBody(body.GetAllBodyFeatures(temp.Copy()));

                                    isFirstTimeInNewNeighbour = false;
                                }

                            }


                        #endregion

                        #region Track timeline
                        if (track == null)
                        {
                            track = new Track(ref timeLine, new TimeInterval(DateTime.Now, DateTime.Now.AddMinutes(1)));
                            lblStart.Text = DateTime.Now.Hour + " : " + DateTime.Now.Minute + " : " + DateTime.Now.Second;
                            
                        }
                        #endregion

                        body.VerifyPerson(frame, mostMatchedBodyLocation, detectedBodies);


                        for (int i = 0; i < brec.Count; i++)
                        {
                            // suspectIndex is the index of suspect in mtch, brec
                            if (body.IsPersonVerified() && (/*i == suspectIndexinMtch ||*/ i == body.GetVerificationPersonIndex()))
                            {
                                #region Suspect Verified
                                if (body.IsPersonVerified() && !mtch[i])
                                {
                                    // temp if
                                    int a = 10;
                                }

                                // Calculating for next frame (if suspect lost in next frame)
                                PointF[] points = body.CalculateOF(frame, brec[i], brec.ToArray(), true);

                                #region Display found Suspect Body
                                //DrawController.DrawCircles(frame, points);
                                //pbView.Image = frame.Bitmap;
                                //return;
                                lastSuspectPosition = brec[i];
                                isSuspectFound = true;
                                //double colorRatio = Math.Min(((double)body.currentVerificationNumber) / BodyController.numberOfVerificationFrames, 1);
                                double colorRatio = body.GetVerficationConfidence();

                                //Debug.AddTrackText(String.Format("{0}% OF>({1}) DC>({1}))",body.GetVerficationConfidence()*100, body.IsPersonVerified()),mtch[i]);

                                if (body.IsPersonVerified())
                                    frame = DrawController.DrawRectangle(brec[i], (Convert.ToInt32(distHog[i])) + " " + (Convert.ToInt32(distHs[i])) + " " + ((distRgb[i])), frame.ToImage<Bgr, byte>(), Color.Green).Mat;
                                else
                                    frame = DrawController.DrawRectangle(brec[i], "Verifying " + body.GetVerficationConfidence(), frame.ToImage<Bgr, byte>(), Color.FromArgb(0, (int)((colorRatio) * 255), (int)((1 - colorRatio) * 255))).Mat;

                                //histogramBox1.ClearHistogram();
                                //histogramBox1.AddHistogram("Red",Color.Red, body.suspectBody.rgb.Item1,256, new float[] { 0f, 255f });
                                //histogramBox1.Refresh();
                                #endregion
                                #endregion
                            }
                            else if (body.IsUnderVerification() && (/*i == suspectIndexinMtch ||*/ i == body.GetVerificationPersonIndex()))
                            {
                                #region Not Verified but matched (for less number of frames than threshold)
                                // if person is being verified

                                double colorRatio = body.GetVerficationConfidence();

                                frame = DrawController.DrawRectangle(brec[i], "Verifying " + body.GetVerficationConfidence(), frame.ToImage<Bgr, byte>(), Color.FromArgb(0, (int)((colorRatio) * 255), (int)((1 - colorRatio) * 255))).Mat;
                                #endregion
                            }
                            else
                            {
                                #region Display bodies which is not target
                                frame = DrawController.DrawRectangle(brec[i], (Convert.ToInt32(distHog[i])) + " " + (Convert.ToInt32(distHs[i])) + " " + ((distRgb[i])), frame.ToImage<Bgr, byte>(), Color.Red).Mat;
                                //frame = Draw.DrawRectangle(brec[i], ((distHog[i])) + " " + ((distHs[i])) + " " + ((distRgb[i])), frame.ToImage<Bgr, byte>(), Color.Red).Mat;
                                #endregion
                            }
                        }
                        pbView.Image = frame.Bitmap;
                    }



                    #region If suspect not found
                    if (track != null && !isSuspectFound)
                    {
                        if (!isLive)
                        {
                            #region Draw OF

                            PointF[] points = body.CalculateOF(frame, lastSuspectPosition, brec.ToArray());

                            //Rectangle ofRect = BodyTracking.FindOuterRectangle(points);
                            //frame = DrawController.DrawRectangle(ofRect, "Using OF", frame.ToImage<Bgr, byte>(), Color.Brown).Mat;

                            //pbView.Image = frame.Bitmap;

                            #endregion

                            #region Draw person suggested by OF

                            Rectangle ofApproxBody = body.GetOFApproxBody();
                            frame = DrawController.DrawRectangle(ofApproxBody, frame.ToImage<Bgr, byte>(), Color.Purple).Mat;

                            #endregion

                            pbView.Image = frame.Bitmap; //DrawController.DrawCircles(frame, points).Bitmap;

                            //pbView.Image = frame.Bitmap;
                        }
                    }
                    #endregion

                    #region manage timeline Track
                    if (track != null)
                    {
                        if (isSuspectFound)
                        {
                            track.CheckCamera(currentCam);

                            lblStart.Text = track.TimeToString(track.camtime.startTime);
                            lblEnd.Text = track.TimeToString(track.camtime.endTime);
                        }
                        else
                        {





                            if (track.CheckCamera(null))
                                SuspectLeftFOV();
                            else
                            {

                                lblStart.Text = track.TimeToString(track.camtime.startTime);
                                lblEnd.Text = track.TimeToString(track.camtime.endTime);

                            }

                        }
                    }
                    #endregion

                    #region Temporary
                    //var image = frame.ToImage<Bgr, byte>();
                    //image.ROI = detectedBodies[0];
                    //image = image.Copy();
                    //image = image.Resize(64, 128, Inter.Cubic);
                    //Point centre = new Point(image.Width / 2, image.Height / 2);
                    ////double borderSize = 0.25;

                    //Bgr white = new Bgr(Color.White);
                    //// apply weighted filter
                    //for (int r = 0; r < image.Height; r++)
                    //{
                    //    //if (r > (image.Height * borderSize) && r < (image.Height - (image.Height * borderSize)))
                    //    //{
                    //    //    continue;
                    //    //}
                    //    for (int c = 0; c < image.Width; c++)
                    //    {
                    //        //if (c>(image.Width * borderSize) && c<(image.Width-(image.Width*borderSize))
                    //        //    && (r > (image.Height * borderSize) && r < (image.Height - (image.Height * borderSize))))
                    //        //    continue;

                    //        Bgr org = image[r, c];
                    //        double dist = Math.Abs((r - centre.Y) * 1.56) + Math.Abs((c - centre.X) * 3.1);
                    //        Bgr newImg = new Bgr(dist * 1.27 /*+ org.Blue*/, dist * 1.27 /*+ org.Green*/, dist * 1.27/* + org.Red*/);
                    //        if (dist < (100))
                    //            continue;
                    //        image[r, c] = new Bgr(Color.White);
                    //    }
                    //}

                    //pbView.Image = image.Bitmap;

                    // if a body detected
                    //pbView.Image = Draw.DrawRectangle(detectedBodies, frame, Color.Green, 2).ToBitmap();
                    #endregion

                    #region OD Pass

                    //if (body.IsInOD_Door_outSide(mostMatchedBodyLocation, currentCam))
                    //{
                    //    odNeighbour = currentCam.OD_Neighbour;
                    //    lastSeenOnOD_Door = true;
                    //}
                    //else
                    //    lastSeenOnOD_Door = false;
                    
                    #endregion

                }
                else
                {
                    if (track != null && track.CheckCamera(null))
                        SuspectLeftFOV();
                    //else
                    //    lblEnd.Text = DateTime.Now.Hour + " " + DateTime.Now.Minute + " " + DateTime.Now.Second;


                    pbView.Image = frame.Bitmap;
                }



            }
            catch (AccessViolationException ex)
            {
                MessageBox.Show(ex.Message);
            }





            // next here
            //try
            //{
            //    using (GFTTDetector detector = new GFTTDetector(1000, 0.01, 1, 3, false, 0.04))
            //    {
            //        Mat img = frame.Clone();

            //        var keypoints = detector.Detect(img);

            //        foreach (MKeyPoint p in keypoints)
            //        {
            //            CvInvoke.Circle(img, Point.Round(p.Point), 3, new Bgr(255, 0, 0).MCvScalar, 1);
            //        }


            //        pbView.Image = img.Bitmap;
            //    }

            //}
            //catch (Exception ex)
            //{ MessageBox.Show(ex.Message); }
        }

        private void Tracking_FormClosed(object sender, FormClosedEventArgs e)
        {
            //timer.Stop();
            //timer.Dispose();
            this.Dispose();
        }

        private void cbUseGpu_CheckedChanged(object sender, EventArgs e)
        {
            Global.useCuda = cbUseGpu.Checked;
            Debug.AddTrackText("GPU turned " + (Global.useCuda ? "ON" : "OFF"));
        }

        // if the target lost at OD Door then wait for number of frames (OD_LostThreahold) to
        //   declare in lost globally
        int OD_LostThreahold = 20;
        int currentOD_LostCount = 0;

        float neighbourDetectionPercent = 0.8f;
        private void SuspectLeftFOV()
        {
            Debug.AddTrackText("Suspect Left FOV");
            // Neighbour
            int framesToCheck = 10;
            List<string> neighs = cMan.getNeighbours(currentCam);
            Rectangle detectedSuspect = Rectangle.Empty;
            int[] count = new int[neighs.Count];
            for (int fr = 0; fr < framesToCheck; fr++)
                for (int i = 0; i < neighs.Count; i++)
                {
                    //here
                    Mat frame = cMan.getRecordedFrame(neighs[i]);

                    if (frame == null)
                        continue;
                    #region Find Suspect

                    Rectangle[] detectedBodies = body.GetAllPersonBodies(frame);

                    bool isMatched = false;
                    if (detectedBodies != null && detectedBodies.Length != 0)
                    {

                        #region Variable initialization


                        #endregion

                        foreach (Rectangle detectedBody in detectedBodies)
                        {
                            #region Body Crop and Resize
                            // Cropping image
                            var img = frame.ToImage<Bgr, byte>();
                            img.ROI = detectedBody;
                            img = img.Copy();

                            // Reduce rectangle size to remove background
                            Size imgSize = img.Size;
                            img.ROI = new Rectangle((imgSize.Width / 4), (imgSize.Height / 8), (imgSize.Width / 2), (int)(imgSize.Height / 1.5)); img = img.Copy();
                            img = img.Copy();

                            img = img.Resize(64, 128, Inter.Cubic);
                            #endregion

                            #region Equaulize the body

                            // 1
                            //img._EqualizeHist();

                            // 2 YCrCb method
                            Image<Ycc, byte> yccImage = img.Convert<Ycc, byte>();
                            //var channels = yccImage.Split();
                            //channels[0]._EqualizeHist();
                            //yccImage[0] = channels[0];
                            yccImage[0]._EqualizeHist();
                            img = yccImage.Convert<Bgr, byte>();
                            //CvInvoke.Merge(channels, yccImage);


                            #endregion
                            
                            #region Re-identification

                            // Extract Features after removing background
                            body.suspectBody = body.GetAllBodyFeatures(img);


                            // Just for display OTHERWISE use direct method
                            double distancHog = body.GetHogDistance();
                            double distanceHs = body.GetHSDistance();
                            double distanceRgb = body.GetRGBDistance();


                            //bool isMatched = body.IsBodySame(distancHog, distanceHs, distanceRgb);
                            isMatched = body.IsBodySame();
                            

                            #endregion


                        }

                        #endregion
                    }
                    if (isMatched)
                        count[i]++;
                }
            int max = count.Max();
            if (max > framesToCheck * neighbourDetectionPercent)
            {
                for (int i = 0; i < count.Length; i++)
                {
                    if (count[i] == max)
                    {
                        currentCam = neighs[i];
                        Debug.AddTrackText("Camera Changed to " + currentCam);

                        isFirstTimeInNewNeighbour = true;

                        break;
                    }
                }
            }
            else
            {
                Debug.AddTrackText("Could not found in neighbours");
            }
            //if (lastSeenOnOD_Door)
            //{
            //    Debug.AddTrackText("Left at OD Door");
            //    Image<Bgr, byte> bodyInNeighour = body.IsInOD_Door_inSide(odNeighbour);
            //    if (bodyInNeighour != null)
            //    {
            //        Debug.AddTrackText("Person Moved from OD Door");

            //        currentOD_LostCount = 0;
            //        lastSeenOnOD_Door = false;

            //        body.AddTargetBody(body.GetAllBodyFeatures(bodyInNeighour));
            //        currentCam = odNeighbour;
            //    }
            //    else
            //    {
            //        if (++currentOD_LostCount < OD_LostThreahold)
            //        {
            //            return;
            //        }
            //        else
            //        {
            //            // Suspect not found in the OD door of parent
            //            lastSeenOnOD_Door = false;
            //            currentOD_LostCount = 0;
            //        }
            //    }
            //}


            //body.currentVerificationNumber = 0;
            lbTime.Items.Clear();
            foreach (CameraTimeInfo cameratime in track.cameraList)
            {
                foreach (TimeInterval ti in cameratime.timeIntervals)
                {
                    lbTime.Items.Add(cameratime.cameraName + " " + track.TimeToString(ti.startTime) + " - " + track.TimeToString(ti.endTime));

                }
            }


            //MessageBox.Show("Out of View");
            // get neighbours of currect camera
            // foreach neighbour find person
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Confirm user wants to close
            Application.Idle -= eh;

        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // For Debugging purpose only

            BodyRecognition.tmpVar = checkBox1.Checked;

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            body.changeUseOFCleaning(checkBox2.Checked);
        }

        private void btn_pause_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void GenerateVideo()
        {
            Application.Idle -= ProcessFrame;

            MessageBox.Show("Generating Video");
            List<Interval> I = new List<Interval>();
            List<CameraTimeInfo> cams = track.cameraList;

            SQLManager sql = new SQLManager();
            
            while(true)
            {
                int index = -1;
                bool check = true;
                CameraTimeInfo min = cams[0];
                for (int i=0;i<cams.Count;i++)
                {
                    if (cams[i].timeIntervals.Count>1)
                    {
                        index = i;
                        min = cams[i];
                        break;
                    }
                }
                if (index == -1)
                    break;
                for (int i=0;i<cams.Count;i++)
                {
                    if (cams[i].timeIntervals.Count>1)
                    { 
                        if (cams[i].timeIntervals[0].startTime<min.timeIntervals[0].startTime)
                        {
                            min = cams[i];
                            index = i;

                        }
                    }
                }
                
                I.Add(new Interval(cams[index].cameraName, cams[index].timeIntervals[0].startTime, cams[index].timeIntervals[0].endTime));
                cams[index].timeIntervals.RemoveAt(0);

                
            }



            string output = VideoGeneration.GenerateVideo(I);
        }


    }




}