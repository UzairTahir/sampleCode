using Emgu.CV;
using Emgu.CV.Cuda;
using Emgu.CV.CvEnum;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.XFeatures2D;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace iTrack_1.Controller
{
    // For Optical Flow
    partial class BodyTracking
    {
        public float badOFPointsToRemove = 0.05f;
        public bool useOFCleaning = true;
        private int thresholdToRecalculateOF = 50; // in points
        public bool needToRecalculateOF = false;

        public Rectangle rectOfPerson = Rectangle.Empty;
        public int indexOfPerson = -1;

        PointF[] prePoints = null;
        PointF[] currFeatures = new PointF[0];
        byte[] status = new byte[0];
        float[] trackError = new float[0];
        public Mat preFrame = new Mat();

        public Rectangle lastSuspectPosition;
        
        private void GetCorners(Mat newFrame, Rectangle roi)
        {
            using (GFTTDetector detector = new GFTTDetector(1000, 0.01, 1, 3, false, 0.04))
            {
                Mat img = newFrame.Clone();

                // Create SPECIAL Mask with ROI
                Image<Gray, byte> maskImg = new Image<Gray, byte>(img.Size);

                roi = new Rectangle((int)(roi.X + roi.Width * 0.25), (int)(roi.Y + roi.Height * 0.1), (int)(roi.Width * 0.5), (int)(roi.Height * 0.4));

                maskImg.Draw(roi, new Gray(255), -1, LineType.FourConnected);



                var keypoints = detector.Detect(img, maskImg);
                //prePoints = keypoints;

                prePoints = new PointF[keypoints.Length];

                for (int i = 0; i < keypoints.Length; i++)
                {
                    prePoints[i] = (keypoints[i].Point);
                }

            }
        }
        public PointF[] CalculateOpticalFlow_Sparse(Mat newFrame,Rectangle roi, Rectangle[] rois, bool forceRecheck = false)
        {
            //Mat newFrame = currFrame.Clone();
            if (prePoints == null || forceRecheck)
            {
                #region Extract Points
                // if running for first frame
                GetCorners(newFrame,roi);

                try
                {
                    //preFrame = new Mat();
                    //newFrame.CopyTo(preFrame);
                    if (prePoints.Length != 0)
                        CvInvoke.CalcOpticalFlowPyrLK(newFrame, newFrame, prePoints, new Size(9, 9), 3, new MCvTermCriteria(20, 1), out currFeatures, out status, out trackError);
                }
                catch (Exception e)
                {
                    MessageBox.Show("In CalculateOpticalFlow_Sparse (true) : " + e.Message);
                }
                prePoints = currFeatures;

                preFrame = newFrame.Clone();

                return null;
                #endregion

            }
            else
            {
                #region Find Points

                if (useOFCleaning)
                {
                    prePoints = CleanOFPoints(prePoints, rois);


                    if (needToRecalculateOF)
                    {
                        // this will recalculate the OF points
                        CalculateOpticalFlow_Sparse(newFrame, rectOfPerson, rois, true);

                        Debug.AddTrackText("Recalculating OF");
                    }
                }

                try
                {
                    CvInvoke.CalcOpticalFlowPyrLK(preFrame, newFrame, prePoints, new Size(9, 9), 3, new MCvTermCriteria(20, 1), out currFeatures, out status, out trackError);
                    prePoints = currFeatures;
                }
                catch(Exception e)
                {
                    MessageBox.Show("In CalculateOpticalFlow_Sparse (false) : " + e.Message);
                }


                #endregion
            }
            preFrame = newFrame.Clone();
            return currFeatures;
            //preFrame = newFrame.Clone();
            //preFrame = new Mat();
            //newFrame.CopyTo(preFrame);
        }
        
        public static Rectangle FindOuterRectangle(PointF[] points)
        {
            if (points == null) return Rectangle.Empty;

            Point p1 = new Point(int.MaxValue, int.MaxValue), p2 = new Point(-1,-1);
            for(int i=0;i<points.Length;i++)
            {
                if (points[i].X < p1.X)
                    p1.X = (int)points[i].X;
                if (points[i].X > p2.X)
                    p2.X = (int)points[i].X;

                if (points[i].Y < p1.Y)
                    p1.Y = (int)points[i].Y;
                if (points[i].Y > p2.Y)
                    p2.Y = (int)points[i].Y;

                    
            }
            return new Rectangle(p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y);
        }

        public PointF[] CleanOFPoints(PointF[] ppoints, Rectangle[] rois)
        {
            #region Remove Outliers using distance (not working)
            /*
            PointF centre = new Point(0, 0);
            List<PointF> points = new List<PointF>(ppoints);


            foreach (PointF point in points)
            {
                centre.X += point.X;
                centre.Y += centre.Y;
            }

            centre.X /= points.Count;
            centre.Y /= points.Count;

            List<float> distances = new List<float>();
            
            for (int i = 0; i < points.Count; i++)
            {
                distances.Add(Math.Abs(points[i].X - centre.X) + Math.Abs(points[i].Y - centre.Y));
            }

            if (points.Count < 50) return points.ToArray();

            for(int i=0;i<points.Count * badOFPointsToRemove;i++)
            {
                int index = distances.IndexOf(distances.Max());

                points.RemoveAt(index);
                distances.RemoveAt(index);

            }

            return points.ToArray();
            */
            #endregion


            

            List<PointF> points = new List<PointF>(ppoints);
            int[] counts = new int[rois.Length];
            if (counts.Length == 0) return ppoints;
            for (int i = 0; i < counts.Length; i++) counts[i] = 0;

            // find number of points exists in all rois(rectangle of people)
            for(int i=0;i<points.Count;i++)
            {
                for (int rect = 0; rect < rois.Length; rect++)
                {
                    if (rois[rect].Contains((int)points[i].X, (int)points[i].Y))
                        counts[rect]++;
                    
                }
            }

            // find the person with most points on it
            indexOfPerson = counts.ToList().IndexOf(counts.Max());
            rectOfPerson = rois[counts.ToList().IndexOf(counts.Max())];

            // check if number of points is less than the threshold
            //
            //     then recalculate the OF in method CalculateOpticalFlow_Sparse
            //         by setting the needToRecalculateOF = true and rectOfPerson => person with most points on it
            //         and break
            //     
            //     else remove all those points which are not in rectOfPerson

            if (points.Count < thresholdToRecalculateOF)
            {

                needToRecalculateOF = true;
                return points.ToArray();
            }
            else
                needToRecalculateOF = false;

            for (int i = 0; i < points.Count;i++)
            {
                if (!rectOfPerson.Contains((int)points[i].X, (int)points[i].Y))
                {
                    points.RemoveAt(i);
                }

            }

            // Summary:
            // return all those points in a person's rectangle which had most points in it

            return points.ToArray();
        }

    }

    // For SURF
    partial class BodyTracking
    {

        public Image<Bgr, byte> frame;
        public Image<Bgr, byte> targetImage;
        public Image<Gray, byte> mask;
        public PointF[] FindMatches(Image<Bgr, byte> targetImage, Image<Gray, byte> sampleMask, Image<Bgr, byte> frame)
        {
            Mat modelImage = targetImage.Mat;
            Mat observedImage = frame.Mat;

            VectorOfVectorOfDMatch matches = new VectorOfVectorOfDMatch();

            int k = 4;
            double uniquenessThreshold = 0.925;
            double hessianThresh = 300;

            Mat homography = null;
            Mat mask = null;

            var modelKeyPoints = new VectorOfKeyPoint();
            var observedKeyPoints = new VectorOfKeyPoint();


            using (UMat uModelImage = modelImage.ToUMat(AccessType.Read))
            using (UMat uObservedImage = observedImage.ToUMat(AccessType.Read))
            {
                SURF surfCPU = new SURF(hessianThresh);
                //extract features from the object image
                UMat modelDescriptors = new UMat();
                try {
                    surfCPU.DetectAndCompute(uModelImage, sampleMask.Mat, modelKeyPoints, modelDescriptors, false);
                }catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }

                // extract features from the observed image
                UMat observedDescriptors = new UMat();
                surfCPU.DetectAndCompute(uObservedImage, null, observedKeyPoints, observedDescriptors, false);
                BFMatcher matcher = new BFMatcher(DistanceType.L2);
                matcher.Add(modelDescriptors);
                try {
                    matcher.KnnMatch(observedDescriptors, matches, k, null);
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                mask = new Mat(matches.Size, 1, DepthType.Cv8U, 1);
                mask.SetTo(new MCvScalar(255));
                Features2DToolbox.VoteForUniqueness(matches, uniquenessThreshold, mask);

                int nonZeroCount = CvInvoke.CountNonZero(mask);
                if (nonZeroCount >= 4)
                {
                    nonZeroCount = Features2DToolbox.VoteForSizeAndOrientation(modelKeyPoints, observedKeyPoints,
                       matches, mask, 1.5, 20);
                    if (nonZeroCount >= 4)
                        homography = Features2DToolbox.GetHomographyMatrixFromMatchedFeatures(modelKeyPoints,
                           observedKeyPoints, matches, mask, 2);
                }


                MKeyPoint[] aa = observedKeyPoints.ToArray();
                List<PointF> a = new List<PointF>();
                foreach (MKeyPoint aaa in aa)
                    a.Add(aaa.Point);

                return a.ToArray();
            }


            // Extracting points from homography
            if (homography != null)
            {
                //draw a rectangle along the projected model
                Rectangle rect = new Rectangle(Point.Empty, modelImage.Size);
                PointF[] pts = new PointF[]
                {
                  new PointF(rect.Left, rect.Bottom),
                  new PointF(rect.Right, rect.Bottom),
                  new PointF(rect.Right, rect.Top),
                  new PointF(rect.Left, rect.Top)
                };
                pts = CvInvoke.PerspectiveTransform(pts, homography);

                Point[] points = Array.ConvertAll<PointF, Point>(pts, Point.Round);

                return null;//points;
            }
            return null;

        }
    }
}
