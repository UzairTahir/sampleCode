using Emgu.CV;
using Emgu.CV.Cuda;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace iTrack_1.Controller
{
    class BodyDetection
    {

        public BodyDetection()
        {
            InitalizeBodyTracker();
        }

        private CudaHOG des;

        public void InitalizeBodyTracker()
        {
            if (!Global.canRunCuda) return;

            // Used when body identification with GPU
            Size winSize = new Size(64, 128);
            Size blockSize = new Size(16, 16);
            Size blockStride = new Size(8, 8);
            Size cellSize = new Size(8, 8);
            int nBins = 9;

            des = new CudaHOG(winSize, blockSize, blockStride, cellSize, nBins);
            des.HitThreshold = 0;

            des.GroupThreshold = 0;
        }


        public Rectangle[] FindBodyHOG(Mat image, out double[] confidence)
        {
            // If can't use Cuda then go for Without cuda implementation
            if (!Global.canRunCuda)
            {
                confidence = null;
                return FindBodyHOG_WithoutGpu(image);
            }
            if (des == null)
                InitalizeBodyTracker();



            List<Rectangle> regions = new List<Rectangle>();
            VectorOfRect rects = new VectorOfRect();
            VectorOfDouble confColl = new VectorOfDouble();
            confidence = new double[0];
            try
            {

                des.SetSVMDetector(des.GetDefaultPeopleDetector());

                des.GroupThreshold = 1;
                des.HitThreshold = 0;
                des.NumLevels = 15;
                des.ScaleFactor = 1.05;
                

                using (GpuMat cudaBgr = new GpuMat(image))
                using (GpuMat cudaBgra = new GpuMat())
                {
                    CudaInvoke.CvtColor(cudaBgr, cudaBgra, ColorConversion.Bgr2Bgra);
                    //des.DetectMultiScale(cudaBgra, rects, confColl);
                    des.DetectMultiScale(cudaBgra, rects, null);
                }


                //confidence = confColl.ToArray();

                for (int i = 0; i < rects.ToArray().Length; i++)
                {
                    //if (confidence[i] > 0.5)
                    regions.Add(rects[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return regions.ToArray();//rects.ToArray();
        }

        public Rectangle[] FindBodyHOG_WithoutGpu(Mat image)
        {
            Rectangle[] regions = null;


            //this is the CPU version
            using (HOGDescriptor des = new HOGDescriptor())
            {
                try
                {

                    //Mat newImage = new Mat();
                    //BackgroundSubtractor bs = new BackgroundSubtractorMOG2(500, 16, false);
                    //bs.Apply(image, newImage);

                    des.SetSVMDetector(HOGDescriptor.GetDefaultPeopleDetector());

                    MCvObjectDetection[] allBodies = des.DetectMultiScale(image);

                    regions = new Rectangle[allBodies.Length];
                    for (int i = 0; i < allBodies.Length; i++)
                    {
                        regions[i] = allBodies[i].Rect;
                        //if (body.Score > threshold)
                        //regions.Add(body.Rect);
                    }

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }


            return regions;
        }


    }

}
