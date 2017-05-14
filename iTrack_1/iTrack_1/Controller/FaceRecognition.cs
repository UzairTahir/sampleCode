using Emgu.CV;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using iTrack_1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace iTrack_1.Controller
{
    class FaceRecognition
    {
        DataBase db = new DataBase();
        List<Tuple<int, string>> names;
        FaceRecognizer recognizer;

        int threshold = 100;

        //CudaCascadeClassifier cuda_ccAltFace;





        public FaceRecognition()
        {
            this.names = new List<Tuple<int, string>>();

            //recognizer = new EigenFaceRecognizer(80,double.PositiveInfinity);
            recognizer = new LBPHFaceRecognizer(1, 8, 8, 8);
            //recognizer = new FisherFaceRecognizer(0, 3500);

            LoadRecognizer();
        }



        public void LoadRecognizer(string dbPath)
        {
            try
            {
                //string dbPath = Path.Combine(Directory.GetCurrentDirectory(), DataBase.facesPath);

                List<Image<Gray, Byte>> images = new List<Image<Gray, byte>>();
                List<int> labels = new List<int>();


                foreach (string imagePath in Directory.GetFiles(dbPath))
                {
                    images.Add(new Image<Gray, Byte>(Path.Combine(dbPath, imagePath)));
                    labels.Add(Convert.ToInt32((new FileInfo(imagePath).Name.Split('_')[0])));

                }
                List<PersonInfo> authPeople = db.GetAllAuthorized();
                // insert names against id
                foreach (PersonInfo person in authPeople)
                {
                    names.Add(Tuple.Create<int, string>(person.id, person.name));
                }

                // check if atleast 1 person is register
                if (images.Count < 1)
                    return;

                recognizer.Train(images.ToArray(), labels.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Recognition");
            }
        }


        public void LoadRecognizer()
        {
            try
            {



                string dbPath = Path.Combine(Directory.GetCurrentDirectory(), DataBase.facesPath);

                List<Image<Gray, Byte>> images = new List<Image<Gray, byte>>();
                List<int> labels = new List<int>();


                foreach (string imagePath in Directory.GetFiles(dbPath))
                {
                    images.Add(new Image<Gray, Byte>(Path.Combine(dbPath, imagePath)));
                    labels.Add(Convert.ToInt32((new FileInfo(imagePath).Name.Split('_')[0])));

                }
                List<PersonInfo> authPeople = db.GetAllAuthorized();
                // insert names against id
                foreach (PersonInfo person in authPeople)
                {
                    names.Add(Tuple.Create<int, string>(person.id, person.name));
                }

                // check if atleast 1 person is register
                if (images.Count < 1)
                    return;

                recognizer.Train(images.ToArray(), labels.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Recognition");
            }
        }

        public string GetPersonName(int i)
        {
            foreach (Tuple<int, string> name in names)
            {
                if (name.Item1 == i)
                    return name.Item2;
            }
            return null;
        }

        public bool IsMatched(Image<Gray, Byte> face, Image<Gray, Byte>[] trainedImages)
        {
            try
            {
                int[] ids = new int[trainedImages.Length];
                for (int i = 0; i < trainedImages.Length; i++)
                    ids[i] = i + 1;

                if (trainedImages.ToArray().Length != 0)
                {
                    recognizer.Train(trainedImages, ids);

                    FaceRecognizer.PredictionResult pr = recognizer.Predict(face.Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic));


                    if (recognizer is EigenFaceRecognizer)
                        return (pr.Distance > 100);
                    else if (recognizer is LBPHFaceRecognizer)
                        return pr.Distance < 110;
                    else
                        return pr.Distance > 300;





                    //return (pr.Distance > threshold);
                }
            }
            catch (Exception ex)
            {
                //if no person is registered
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        public int MatchedFace(Image<Gray, Byte> face, ref double distance)
        {


            FaceRecognizer.PredictionResult pr = new FaceRecognizer.PredictionResult();
            try
            {
                string dbPath = Path.Combine(Directory.GetCurrentDirectory(), DataBase.facesPath);
                //if (Directory.Exists(dbPath))
                //    dbPath = dbPath;

                //FisherFaceRecognizer recognizer = new FisherFaceRecognizer(/*DataBase.facesPath*/);
                //recognizer.Train( .Load(dbPath);
                pr = recognizer.Predict(face);//.Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic));

                distance = pr.Distance;

                if (recognizer is EigenFaceRecognizer)
                    return /*pr.Label;*/(pr.Distance > 2500) ? pr.Label : -1;
                else if (recognizer is LBPHFaceRecognizer)
                    return /*pr.Label;*/pr.Distance < 250 ? pr.Label : -1;
                else
                    return /*pr.Label;*/pr.Distance > 300 ? pr.Label : -1;



            }
            catch (Exception ex)
            {
                // if no person is registered
                MessageBox.Show(ex.Message, "Matched Face");
            }
            return -1;

        }

        public int ApplyThreshold(int id, int distance)
        {
            if (distance < threshold)
                return -1;
            else
                return id;
        }

    }
}
