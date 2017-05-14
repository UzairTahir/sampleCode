using Emgu.CV;
using Emgu.CV.Cuda;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace iTrack_1.Controller
{
    class FaceIdentification
    {
        string faceHaar = "haarcascade_frontalface_default.xml";
        string sideFaceHaar = "haarcascade_profileface.xml";
        string faceAltHaar = "haarcascade_frontalface_alt2.xml";

        CascadeClassifier ccFace;
        CascadeClassifier ccSideFace;
        CascadeClassifier ccAltFace;

        CudaCascadeClassifier cuda_ccFace;
        CudaCascadeClassifier cuda_ccSideFace;

        public readonly static int registrationMinFaceSize = 8;
        public readonly static int identificaitonMinFaceSize = 16;
        public readonly static int compressedImageSize = 24;

        int minFaceSize;

        public FaceIdentification(int minFaceSize)
        {
            // eigen 2100
            // lbph 100
            // fisher 250-500
            
            //recognizer = new EigenFaceRecognizer(80,double.PositiveInfinity);
            //recognizer = new LBPHFaceRecognizer(1, 8, 8, 8);
            //recognizer = new FisherFaceRecognizer(0, 3500);

            // 

            this.minFaceSize = minFaceSize;

            try
            {
                ccFace = new CascadeClassifier(faceHaar);
                ccSideFace = new CascadeClassifier(sideFaceHaar);
                ccAltFace = new CascadeClassifier(faceAltHaar);

                cuda_ccFace = new CudaCascadeClassifier(faceHaar);
                cuda_ccSideFace = new CudaCascadeClassifier(sideFaceHaar);
                //cuda_ccAltFace = new CudaCascadeClassifier(faceAltHaar);


                cuda_ccFace.MinNeighbors = 5;
                cuda_ccFace.ScaleFactor = 1.02;

                cuda_ccSideFace.MinNeighbors = 5;
                cuda_ccSideFace.ScaleFactor = 1.02;

                //cuda_ccAltFace.MinNeighbors = 5;
                //cuda_ccAltFace.ScaleFactor = 1.02;

                cuda_ccFace.MinObjectSize = new Size(640 / minFaceSize, 480 / minFaceSize);
                cuda_ccSideFace.MinObjectSize = cuda_ccFace.MinObjectSize;
                //cuda_ccAltFace.MinObjectSize = cuda_ccFace.MinObjectSize;

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

        }



        public Rectangle[] FindFaces(Mat frame, ref int type)
        {
            if (CudaInvoke.HasCuda && Global.useCuda)
            {


                using (CudaImage<Bgr, Byte> gpuImage = new CudaImage<Bgr, byte>(frame))
                using (CudaImage<Gray, Byte> gpuGray = gpuImage.Convert<Gray, Byte>())
                using (GpuMat region = new GpuMat())
                {
                    cuda_ccFace.DetectMultiScale(gpuGray, region);
                    Rectangle[] faces = cuda_ccFace.Convert(region);

                    if (faces.Length == 0)
                    {
                        cuda_ccSideFace.DetectMultiScale(gpuGray, region);
                        faces = cuda_ccSideFace.Convert(region);
                        if (faces.Length == 0)
                        {
                            Image<Gray, byte> grayImage = gpuGray.ToImage();
                            faces = ccAltFace.DetectMultiScale(grayImage, 1.02, 5, cuda_ccFace.MinObjectSize);
                            if (faces.Length != 0)
                                type = 3;
                        }
                        else
                        {
                            type = 2;
                        }
                    }
                    else
                    {
                        type = 1;
                    }

                    return faces;

                }
            }
            else
                return FindFaces_WithoutGPU(frame, ref type);
            //return null;
        }

        public Rectangle[] FindFaces_WithoutGPU(Mat frame, ref int type)
        {
            try
            {
                // Without cuda support

                using (Image<Bgr, byte> nextFrame = frame.ToImage<Bgr, byte>())
                {
                    if (nextFrame != null)
                    {
                        // Convert Frame to GrayScale
                        Image<Gray, byte> grayframe = nextFrame.Convert<Gray, byte>();//.Resize(320, 240, Emgu.CV.CvEnum.Inter.Cubic);

                        //grayframe = grayframe.SmoothGaussian(3, 3, 34.3, 45.3);

                        Rectangle[] faces = ccAltFace.DetectMultiScale(grayframe, 1.02, 5, new Size(nextFrame.Width / minFaceSize, nextFrame.Height / minFaceSize));
                        type = 1;
                        if (faces.Length == 0)
                        {
                            type = 2;
                            faces = ccSideFace.DetectMultiScale(grayframe, 1.02, 5, new Size(nextFrame.Width / minFaceSize, nextFrame.Height / minFaceSize));

                            if (faces.Length == 0)
                            {
                                type = 3;
                                faces = ccFace.DetectMultiScale(grayframe, 1.02, 5, new Size(nextFrame.Width / minFaceSize, nextFrame.Height / minFaceSize));
                            }
                        }

                        if (faces.Length == 0) type = 0;
                        return faces;
                    }

                }
                return null;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        

    }
}
