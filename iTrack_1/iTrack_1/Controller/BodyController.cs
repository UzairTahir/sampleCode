using Emgu.CV;
using Emgu.CV.Cuda;
using Emgu.CV.CvEnum;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.VideoSurveillance;
using iTrack.Controller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTrack_1.Controller
{
    public class BodyInfo
    {
        public int id;
        public Tuple<List<Mat>, List<Mat>> hs; // 15000
        public double[] hog; // 150
        public Tuple<List<Mat>, List<Mat>, List<Mat>> rgb; // 10000
        public BodyInfo(Tuple<List<Mat>, List<Mat>> hs, double[] hog, Tuple<List<Mat>, List<Mat>, List<Mat>> rgb)
        {
            this.hs = hs;
            this.hog = hog;
            this.rgb = rgb;
        }

    }

    class BodyController
    {
        private BodyVerification bodyVerification;
        private BodyDetection bodyDetection;
        private BodyRecognition bodyRecognition;
        private BodyTracking bodyTracking;

        public int maxNumberOfTagetBodies = 10;

        //public int currentVerificationNumber = 0;
        //public int currentLostTrackCount = 0;
        public BodyController()
        {
            // initalization
            bodyVerification = new BodyVerification();
            bodyDetection = new BodyDetection();
            bodyRecognition = new BodyRecognition();
            bodyTracking = new BodyTracking();
        }


        private List<BodyInfo> targetBodies = null;
        public BodyInfo suspectBody = null;

        //Rectangle[] detectedBodies;

        public bool AddTargetBody(BodyInfo targetBody)
        {
            if (targetBodies == null)
                targetBodies = new List<BodyInfo>();

            if (targetBodies.Count <= maxNumberOfTagetBodies)
            {
                targetBodies.Add(targetBody);
                return true;
            }
            return false;
        }

        public Rectangle[] GetAllPersonBodies(Mat image)
        {
            double[] confidence;
            Rectangle[] bodiesfound = bodyDetection.FindBodyHOG(image, out confidence);

            return bodiesfound;
        }

        public BodyInfo GetAllBodyFeatures(Image<Bgr, byte> image)
        {
            image = bodyRecognition.RemoveBackground(image);

            return bodyRecognition.ExtractBodyFeatures(image);
        }
        

        public bool IsBodySame()
        {
            //bool overAllQuality = true;
            //bool bodyMatched = false;
            bool isBadQuality;
            //bool newFeaturesNeeded = false;
            foreach (BodyInfo targetBody in targetBodies)
            {
                if (bodyRecognition.IsSame(targetBody, suspectBody, out isBadQuality))
                {
                    //if(isBadQuality)
                    //{
                    //    Debug.AddTrackText("+1 Suspect Added > " + (targetBodies.Count + 1));
                    //    AddTargetBody(suspectBody);
                    //}
                    return true;
                }
                // if body matched but the body is under
                
            }
            //if (!overAllQuality)
            //{
            //    Debug.AddTrackText("+1 Suspect Added > "+(targetBodies.Count+1));
            //    AddTargetBody(suspectBody);
            //}


            return false;
        }
        public bool IsBodySame(double distHog, double distHS, double distRgb)
        {
            return BodyRecognition.ApplyThresholds(distHog, distHS, distRgb);
        }

        public PointF[] CalculateOF(Mat frame,Rectangle roi, Rectangle[] rois, bool force = false)
        {
            return bodyTracking.CalculateOpticalFlow_Sparse(frame,roi, rois, force);
        }

        public Rectangle GetOFApproxBody()
        {
            return bodyTracking.rectOfPerson;
        }


        #region new Work
        public void InitializeBodyVerificationTracker(Mat frame, Rectangle roi, Rectangle[] rois)
        {
            //bodyVerification.CalculateOF(frame,roi,rois,true);
        }

        public int GetVerificationPersonIndex()
        {
            return bodyVerification.indexOfPerson;
        }
        public bool IsUnderVerification()
        {
            return bodyVerification.isUnderVerfication;
        }
        public bool IsPersonVerified()
        {
            return bodyVerification.isPersonVerified();
        }
        public void VerifyPerson(Mat frame, Rectangle roi, Rectangle[] rois)
        {
            bodyVerification.VerifyPerson(frame, roi, rois);
        }
        public void SetPersonVerification(Mat frame, Rectangle roi, Rectangle[] rois)
        {
            bodyVerification.SetPersonVerification(frame, roi, rois);
        }
        public float GetVerficationConfidence()
        {
            return bodyVerification.currentVerificationNumber / (float)BodyVerification.numberOfVerificationFrames;
        }
        #endregion

        public void FindMostMatchedBody(List<double> distHog, List<double> distHs, List<double> distRgb, ref List<bool> mtch)
        {
            if (distHs.Count == 0) return;

            List<double> distances = new List<double>();

            for (int i = 0; i < distHog.Count; i++)
            {
                distances.Add(distHog[i] * 10 + distHs[i] * 0.8 + distRgb[i] * 0.8);
            }

            double min = distances.Min();

            bool isTargetFound = false;
            for (int i = 0; i < mtch.Count; i++)
                if ((distances[i] == min) && (mtch[i]))
                {
                    mtch[i] = true;
                    isTargetFound = true;
                }
                else
                    mtch[i] = false;





            // to change

            //if (isTargetFound)
            //{
            //    currentVerificationNumber++;
            //    currentLostTrackCount = 0;
            //}
            //else
            //{
            //    currentLostTrackCount++;
            //    if(currentLostTrackCount>=framesForLostTrack)
            //        currentVerificationNumber = 0;
            //}



        }



        public Image<Gray, byte> GetMask()
        {
            return bodyRecognition.mask;
        }


        public double GetHogDistance()
        {
            List<double> distances = new List<double>(); ;
            foreach (BodyInfo targetBody in targetBodies)
                distances.Add(BodyRecognition.MatchHistograms(suspectBody.hog, targetBody.hog));
            return distances.Min();
        }
        public double GetHSDistance()
        {
            List<double> distances = new List<double>(); ;
            foreach (BodyInfo targetBody in targetBodies)
                distances.Add(BodyRecognition.MatchHistograms(suspectBody.hs, targetBody.hs));

            return distances.Min(); ;
        }
        public double GetRGBDistance()
        {
            List<double> distances = new List<double>(); ;
            foreach (BodyInfo targetBody in targetBodies)
                distances.Add(BodyRecognition.MatchHistograms(suspectBody.rgb, targetBody.rgb));

            return distances.Min();
        }

        
        public void changeUseOFCleaning(bool toggleOFCleansing)
        {
            // debugging method only

            bodyTracking.useOFCleaning = toggleOFCleansing;

        }



        public bool IsInOD_Door_outSide(Rectangle suspect,CameraInfo camera)
        {
            //if(!camera.isOD)return false 

            suspect.X = suspect.X + (int)(suspect.Width*0.25);
            suspect.Y = suspect.Y + (int)(suspect.Height * 0.25);
            suspect.Width = suspect.Width / 2;
            suspect.Height = suspect.Height / 2;

            //return camera.OD_Door.Contains(suspect);
            return false; 
        }

        public Image<Bgr,byte> IsInOD_Door_inSide(CameraInfo camera)
        {
            //Rectangle door = camera.OD_Door;
            ////if(!camera.isOD)return false 

            //door.X = door.X - (int)(door.Width * 0.25);
            //door.Y = door.Y - (int)(door.Height * 0.25);
            //door.Width = door.Width + (int)(door.Width * 0.5);
            //door.Height = door.Height + (int)(door.Height * 0.5);

            //// In Neighbour camera

            //Mat frame = camera.GetFrame();
            //Rectangle[] bodies = GetAllPersonBodies(frame);

            //foreach (Rectangle body in bodies)
            //{
            //    if (door.Contains(body))
            //    {
            //        Image<Bgr, byte> temp = frame.ToImage<Bgr, byte>();
            //        temp.ROI = body;
            //        return temp.Copy();
            //    }
            //}


            return null;
        }
        
    }
}
