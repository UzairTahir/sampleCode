using Emgu.CV;
using Emgu.CV.Cuda;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using iTrack_1.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTrack_1.Controller
{
    class FaceController
    {
        FaceIdentification faceInd;
        FaceRecognition faceRec;


        public FaceController(int minFaceSize)
        {
            faceInd = new FaceIdentification(minFaceSize);
            faceRec = new FaceRecognition();
        }


        public Rectangle[] FindAllFaces(Mat currentFrame,ref int type)
        {
            return faceInd.FindFaces(currentFrame,ref type);
        }

        public int MatchedFace(Image<Gray,byte> faceImage,ref double distance)
        {
            return faceRec.MatchedFace(faceImage, ref distance);
        }

        public string GetPersonName(int personId)
        {
            return faceRec.GetPersonName(personId);
        }

        public bool IsFaceMatched(Image<Gray, Byte> face, Image<Gray, Byte>[] trainedImages)
        {
            return faceRec.IsMatched(face, trainedImages);
        }

    }
}
