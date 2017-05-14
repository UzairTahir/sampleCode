using Emgu.CV;
using Emgu.CV.Cuda;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace iTrack_1.Controller
{
    class BodyRecognition
    {
        // Bhatta hs=8 rgb=15
        // ChiSqr hs=50000 rgb=30000
        // My hs=30000, rgb=20000 


        public static bool tmpVar = false;

        static int hogThreshold = 150;
        static int hsThreshold = 45000;//30000;
        static int rgbThreshold = 32000;//20000;//15000;

        static int qhogThreshold = 140;
        static int qhsThreshold = 45000;
        static int qrgbThreshold = 28000;

        //static int qhogThreshold = 140;
        //static int qhsThreshold = 26000;
        //static int qrgbThreshold = 17000;//15000;


        public Image<Gray, byte> mask;



        public BodyRecognition()
        {
            mask = CreateMask();
        }



        public Image<Bgr, byte> RemoveBackground(Image<Bgr, byte> image)
        {

            Point centre = new Point(image.Width / 2, image.Height / 2);
            //double borderSize = 0.25;
            //int whites = 0;
            //Bgr white = new Bgr(Color.White);
            for (int r = 0; r < image.Height; r++)
            {
                //if (r > (image.Height * borderSize) && r < (image.Height - (image.Height * borderSize)))
                //{
                //    continue;
                //}
                for (int c = 0; c < image.Width; c++)
                {
                    //if (c>(image.Width * borderSize) && c<(image.Width-(image.Width*borderSize))
                    //    && (r > (image.Height * borderSize) && r < (image.Height - (image.Height * borderSize))))
                    //    continue;

                    Bgr org = image[r, c];
                    double dist = Math.Abs((r - centre.Y) * 1.56) + Math.Abs((c - centre.X) * 3.1);
                    Bgr newImg = new Bgr(dist * 1.27 /*+ org.Blue*/, dist * 1.27 /*+ org.Green*/, dist * 1.27/* + org.Red*/);
                    if (dist < (100))
                        continue;
                    //whites++;
                    image[r, c] = new Bgr(Color.Black);
                }
            }
            return image;
        }
        public Image<Gray, byte> CreateMask()
        {
            Image<Gray, byte> mask = new Image<Gray, byte>(64, 128);
            Point centre = new Point(mask.Width / 2, mask.Height / 2);
            //double borderSize = 0.25;
            //int whites = 0;
            //Bgr white = new Bgr(Color.White);
            for (int r = 0; r < mask.Height; r++)
            {
                for (int c = 0; c < mask.Width; c++)
                {

                    double dist = Math.Sqrt(Math.Pow((r - centre.Y) * 1.56, 2) + Math.Pow((c - centre.X) * 3.1, 2));
                    Bgr newImg = new Bgr(dist * 1.27 /*+ org.Blue*/, dist * 1.27 /*+ org.Green*/, dist * 1.27/* + org.Red*/);

                    if (dist < 40)
                        mask[r, c] = new Gray(((200 / dist)) * 55);
                    else if (dist < 60)
                        mask[r, c] = new Gray(((200 / dist)) * 45);
                    else if (dist < 90)
                        mask[r, c] = new Gray(((200 / dist)) * 35);
                    else
                        mask[r, c] = new Gray(0);
                }
            }
            return mask;
        }



        public BodyInfo ExtractBodyFeatures(Image<Bgr, byte> image)
        {

            image = image.Resize(64, 128, Inter.Cubic);

            image = RemoveBackground(image);


            Tuple<List<Mat>, List<Mat>> hs = CalculateHsv(image);
            Tuple<List<Mat>, List<Mat>, List<Mat>> rgb = CalculateRgb(image);
            double[] hog = CalculateHog(image);

            // squareroot all
            //double[] normalizedHogs = new double[hogs.Length];
            //for (int i = 0; i < hogs.Length; i++)
            //{
            //    normalizedHogs[i] = Math.Sqrt((double)hogs[i]);
            //}


            return new BodyInfo(hs, hog, rgb);

        }

        


        public Tuple<List<Mat>, List<Mat>> CalculateHsv(Image<Bgr, byte> image)
        {

            //Image<Hsv, Byte> img = image.Convert<Hsv, Byte>();
            //RangeF[] ranges = new RangeF[] { new RangeF(0.0f, 255.0f) , new RangeF(0.0f, 180.0f) }
            //DenseHistogram hist = new DenseHistogram(binSizes,ranges);
            //hist.Calculate<Byte>(new Image<Gray, byte>[] { image }, true, null);


            List<Mat> h = new List<Mat>();
            List<Mat> s = new List<Mat>();


            DenseHistogram dh = new DenseHistogram(255, new RangeF(0, 255));
            DenseHistogram dh2 = new DenseHistogram(255, new RangeF(0, 255));
            Image<Hsv, byte> hsvImage = image.Convert<Hsv, byte>();

            for (int i = 0; i < 8; i++)
            {
                hsvImage.ROI = new Rectangle(0, i * 16, 64, 16);

                Image<Gray, byte>[] channels = hsvImage.Copy().Split();
                Image<Gray, byte> hue = channels[0]; // range = 0-360
                Image<Gray, byte> sat = channels[1]; // range = 0-100


                dh.Calculate<byte>(new Image<Gray, byte>[] { hue }, true, null);
                dh2.Calculate<byte>(new Image<Gray, byte>[] { sat }, true, null);


                Mat tmp = new Mat();
                dh.CopyTo(tmp);
                h.Add(tmp);

                dh2.CopyTo(tmp);
                s.Add(tmp);

            }


            /*--*/
            //Image<Gray, byte>[] channels = hsvImage.Copy().Split();
            //Image<Gray, byte> hue = channels[0]; // range = 0-360
            //Image<Gray, byte> sat = channels[1]; // range = 0-100
            //dh.Calculate<byte>(new Image<Gray, byte>[] { hue }, true, mask);
            //dh2.Calculate<byte>(new Image<Gray, byte>[] { sat }, true, mask);
            //hueHists = dh.GetBinValues();
            //satHists = dh2.GetBinValues();
            /*--*/



            return new Tuple<List<Mat>, List<Mat>>(h, s);
        }
        public Tuple<List<Mat>, List<Mat>, List<Mat>> CalculateRgb(Image<Bgr, byte> image)
        {

            float[] redHists = new float[256];
            float[] greenHists = new float[256];
            float[] blueHists = new float[256];

            DenseHistogram dh = new DenseHistogram(255, new RangeF(0, 255));
            Image<Rgb, byte> hsvImage = image.Convert<Rgb, byte>();
            Image<Gray, byte> partialMask = null;

            var orgHSV = hsvImage.Clone();
            var orgMask = mask.Clone();

            float[] lastarr = null;
            List<Mat> red = new List<Mat>();
            List<Mat> green = new List<Mat>();
            List<Mat> blue = new List<Mat>();
            for (int i = 0; i < 8; i++)
            {
                hsvImage = orgHSV.Clone();
                mask = orgMask.Clone();

                hsvImage.ROI = new Rectangle(0, i * 16, 64, 16);
                mask.ROI = hsvImage.ROI;
                partialMask = mask.Copy();
                Image<Gray, byte>[] channels = hsvImage.Copy().Split();

                Image<Gray, byte> r = channels[0]; // range = 0-250
                Image<Gray, byte> g = channels[1]; // range = 0-250
                Image<Gray, byte> b = channels[2]; // range = 0-250

                try
                {
                    Mat tmp = new Mat();
                    dh.Calculate<byte>(new Image<Gray, byte>[] { channels[0] }, true, partialMask);
                    redHists = dh.GetBinValues();
                    dh.CopyTo(tmp);
                    red.Add(tmp);

                    dh.Clear();
                    dh.Calculate<byte>(new Image<Gray, byte>[] { channels[1] }, true, partialMask);
                    dh.CopyTo(tmp);
                    green.Add(tmp);

                    dh.Clear();
                    dh.Calculate<byte>(new Image<Gray, byte>[] { channels[2] }, true, partialMask);
                    dh.CopyTo(tmp);
                    blue.Add(tmp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            return new Tuple<List<Mat>, List<Mat>, List<Mat>>(red, green, blue);

        }
        public double[] CalculateHog(Image<Bgr, byte> image)
        {
            Size imageSize = new Size(64, 16);

            Size blockSize = new Size(16, 16);
            // non overlapping rows
            Size blockStride = new Size(16, 8);
            Size cellSize = new Size(8, 8);


            HOGDescriptor hog = new HOGDescriptor(imageSize, blockSize, blockStride, cellSize);

            float[] hogs = hog.Compute(image);

            double[] hogd = new double[hogs.Length];
            for (int i = 0; i < hogs.Length; i++)
            {
                hogd[i] = hogs[i];
            }

            return hogd;
        }



        public static double MatchHistograms(double[] hist1, double[] hist2, bool isHog = false)
        {
            double distance = 0;
            hist1 = NormalizeHist(hist1);
            hist2 = NormalizeHist(hist2);


            // Bhattacharyya (not working)
            //try
            //{
            //    var a = new VectorOfDouble(hist1);
            //    var b = new VectorOfDouble(hist2);
            //    return CvInvoke.CompareHist(a, b, HistogramCompMethod.Bhattacharyya);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //return 0;

            // City Block Distance (not to accurate)

            for (int i = 0; i < hist1.Length; i++)
            {
                distance += Math.Abs(hist1[i] - hist2[i]);
            }
            return distance;

            // Ecludean (too slow)
            //for (int i = 0; i < hist1.Length; i++)
            //{
            //    distance += Math.Pow(hist1[i] - hist2[i], 2);
            //}
            //return Math.Sqrt(distance);
        }
        public static double MatchHistograms(List<Mat> hist1, List<Mat> hist2)
        {
            double distance = 0;
            for (int i = 0; i < hist1.Count; i++)
            {
                double tmp = CvInvoke.CompareHist(hist1[i], hist2[i], HistogramCompMethod.ChisqrAlt);
                distance += tmp;
            }

            return distance;
        }




        public static bool ApplyThresholds(double hogVal,double hsVal,double rgbVal)
        {
            if (tmpVar) return false;

            return (hogVal < hogThreshold) && (hsVal < hsThreshold) && (rgbVal < rgbThreshold);
        }

        

        private static double[] NormalizeHist(double[] hist)
        {
            //int max = 255;
            //double[] ret = new double[hist.Length];
            //for (int i = 0; i < hist.Length; i++)
            //{
            //    ret[i] = ((max * (hist[i] + 1)) / 2.0);
            //}
            //return ret;

            // Translation invarient
            double mean = hist.Average();
            for (int i = 0; i < hist.Length; i++)
            {
                hist[i] -= mean;
            }
            return hist;
        }

        public bool isBelowQualityThreshold(double hogVal, double hsVal, double rgbVal)
        {
            // return true if quality is not good enough

           
            return (hogVal > qhogThreshold) || (hsVal > qhsThreshold) || (rgbVal > qrgbThreshold);
        }

        public bool IsSame(BodyInfo person1, BodyInfo person2, out bool isBadQuality)
        {
            
            double distancHog = MatchHistograms(person1.hog, person2.hog, true);

            double distanceHs = MatchHistograms(person1.hs, person2.hs);

            double distanceRgb = MatchHistograms(person1.rgb.Item1, person2.rgb.Item1);
            distanceRgb += MatchHistograms(person1.rgb.Item2, person2.rgb.Item2);
            distanceRgb += MatchHistograms(person1.rgb.Item3, person2.rgb.Item3);

            isBadQuality = isBelowQualityThreshold(distancHog, distanceHs, distanceRgb);

            return ApplyThresholds(distancHog ,distanceHs,distanceRgb);

        }

        public static double MatchHistograms(Tuple<List<Mat>,List<Mat>> hist1, Tuple<List<Mat>, List<Mat>> hist2)
        {
            double distance = MatchHistograms(hist1.Item1, hist2.Item1);
            distance += MatchHistograms(hist1.Item2, hist2.Item2);

            return distance;
        }
        public static double MatchHistograms(Tuple<List<Mat>, List<Mat>, List<Mat>> hist1, Tuple<List<Mat>, List<Mat>, List<Mat>> hist2)
        {
            double distance = MatchHistograms(hist1.Item1, hist2.Item1);
            distance += MatchHistograms(hist1.Item2, hist2.Item2);
            distance += MatchHistograms(hist1.Item3, hist2.Item3);

            return distance;
        }

    }


    
}
