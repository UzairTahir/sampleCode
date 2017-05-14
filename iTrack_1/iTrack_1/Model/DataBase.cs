using Emgu.CV;
using Emgu.CV.CvEnum;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTrack_1.Model
{

    public struct PersonInfo
    {
        public int id;
        public string name;
        public Bitmap faceFront;
        public PersonInfo(string name, Bitmap faceFront)
        {
            this.name = name;
            this.faceFront = faceFront;
            this.id = -1;
        }
        public PersonInfo(int id, string name)
        {
            this.name = name;
            this.faceFront = null;
            this.id = id;
        }
        public PersonInfo(int id, string name,Bitmap image)
        {
            this.name = name;
            this.faceFront = image;
            this.id = id;
            
        }
    }

    class DataBase
    {
        public static string facesPath = "faces";
        SQLManager sql;

        public DataBase()
        {
            sql = new SQLManager();
        }

        public void Register(PersonInfo person)
        {
            int id = sql.ExecuteAddPerson(person);

            Image<Emgu.CV.Structure.Gray, byte> faceFront = new Image<Emgu.CV.Structure.Gray, byte>(person.faceFront);
            faceFront = faceFront.Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic);//.Convert<Gray, byte>();

            // Save image
            if (!Directory.Exists(facesPath)) Directory.CreateDirectory(facesPath);
            faceFront.Save(Path.Combine(facesPath, id.ToString() + "_front.bmp"));

           // MessageBox.Show(String.Format("[DEBUG] {0}'s face added with id = {1}", person.name, id));
        }

        public void Register(List<PersonInfo> personImages)
        {
            int number = 0;
            int id = sql.ExecuteAddPerson(personImages[0]);

            foreach (PersonInfo person in personImages)
            {

                Image<Emgu.CV.Structure.Gray, byte> faceFront = new Image<Emgu.CV.Structure.Gray, byte>(person.faceFront);
                faceFront = faceFront.Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic);//.Convert<Gray, byte>();

                // Save image
                if (!Directory.Exists(facesPath)) Directory.CreateDirectory(facesPath);
                faceFront.Save(Path.Combine(facesPath, id.ToString() + "_"+(number++)+".bmp"));

              
            }
            MessageBox.Show(String.Format("[DEBUG] {0}'s face added with id = {1}", personImages[0].name, id));

        }

        public List<PersonInfo> GetAllAuthorized()
        {
            return sql.GetAllAuthorized();
        }
    }
}
