using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTrack.Controller;
using iTrack_1.Controller;

namespace iTrack_1.Model
{

    class SQLManager
    {
       //  string connectionString = "Data Source=beel;Initial Catalog=FaceReg;Integrated Security=True";
        //string connectionString = "Data Source=Beel;Initial Catalog=FaceReg;Integrated Security=True";
        string connectionString = "Data Source=DELL;Initial Catalog=FaceReg;Integrated Security=True";
        //string connectionString = "Data Source=DESKTOP-9NU3PLG;Initial Catalog=FaceReg;Integrated Security=True";

        SqlConnection connection;
        SqlCommand command;

        public static string createPersonTable = "CREATE TABLE PersonInfo (id INT IDENTITY(1,1) PRIMARY KEY, name VARCHAR(20));";
        public static string insertPersonTable = "INSERT INTO PersonInfo(name) OUTPUT Inserted.id VALUES('{0}');";
        public static string getAllPersonTable = "SELECT * FROM PersonInfo";
        public static string getAllCameras = "Select * from Cameras";
        public static string addCamera = "insert into Cameras(Name,IP,Rotation,Neighbour) values ('{0}','{1}','{2}','{3}')";
        public static string addNeighbour = "insert into Neighbour(Name,Neighbour) values ('{0}','{1}')";
        public static string addNeighbour1 = "insert into Neighbour(Name,Neighbour,Type) values ('{0}','{1}','{2}')";
       
        public static string selectNeighbors = "select * from Neighbour where Name ='{0}'";
        public static string selectCamOD= "select * from Cameras where Name ='{0}'";
        

        public static string delCamera = "delete from Cameras where Name = '{0}'";
        public static string addCamera1 = "insert into Cameras(Name,IP,Rotation,UserName,Password) values ('{0}','{1}','{2}','{3}','{4}')";
        public static string addCamera2 = "insert into Cameras(Name,IP,Rotation,UserName,Password,Registration,Identification,Tracking) values ('{0}','{1}','{2}','{3}','{4}',{5},{6},{7})";
        public static string addCamera3 = "insert into Cameras(Name,IP,Rotation,UserName,Password,Registration,Identification,Tracking,PointX,PointY) values ('{0}','{1}','{2}','{3}','{4}',{5},{6},{7},{8},{9})";
        public static string addCamera4 = "insert into Cameras(Name,IP,Rotation,UserName,Password,Registration,Identification,Tracking,PointX,PointY,OD) values ('{0}','{1}','{2}','{3}','{4}',{5},{6},{7},{8},{9},{10})";
        public static string getAllCameraPts = "SELECT * FROM Cameras ";

        public static string addRecordingVideo = "insert into VideoRecording(Camera,StartTime,EndTime,FileName) values ('{0}','{1}','{2}','{3}')";
        public static string getFileName = "select * from VideoRecording where Camera = '{0}'";
        public SQLManager()
        {
            connection = new SqlConnection(connectionString);
       //     ExecuteNonQuery(createPersonTable);
        }


        public int ExecuteNonQuery(string query)
        {
            command = new SqlCommand(query, connection);
            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();

            command.Dispose();
            connection.Close();
            return rowsAffected;
        }
        public SqlDataReader ExecuteSelect(string query)
        {
            command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();


            command.Dispose();
            connection.Close();
            connection.Close();
            return reader;
        }

        public int ExecuteAddPerson(PersonInfo person)
        {
            command = new SqlCommand(String.Format(insertPersonTable, person.name), connection);
            connection.Open();

            int id = (int)command.ExecuteScalar();

            command.Dispose();
            connection.Close();
            connection.Close();
            return id;
        }

        public List<PersonInfo> GetAllAuthorized()
        {
            List<PersonInfo> people = new List<PersonInfo>();

            string query = String.Format(SQLManager.getAllPersonTable);

            command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();



            while (reader.Read())
            {
                people.Add(new PersonInfo((int)reader[0], (string)reader[1]));
            }



            command.Dispose();
            connection.Close();
            connection.Close();

            return people;
        }

        public List<CameraInfo> getAllCams()
        {
            string query = String.Format(SQLManager.getAllCameras);
            command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            List<CameraInfo> cameras = new List<CameraInfo>();

            while (reader.Read())
            {
                CameraInfo cam = new CameraInfo((reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString());
                if (Convert.ToInt32(reader["Registration"])==1)
                    cam.Registration = true;
                if (Convert.ToInt32(reader["Identification"]) == 1)
                    cam.Identification = true;
                if (Convert.ToInt32(reader["Tracking"]) == 1)
                    cam.Tracking = true;
                cameras.Add(cam);
                //break;    //for single camera
            }

            connection.Close();
            command.Dispose();
            return cameras;
        }
       
        //CameraPts
         public List<int> getAllpts()
        {
            string query = String.Format(SQLManager.getAllCameraPts);
            command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            List<int> Pts = new List<int>();


            while (reader.Read())
            {
                Pts.Add(Convert.ToInt32(reader[9].ToString()));
                Pts.Add(Convert.ToInt32(reader[10].ToString())); 
            }

            connection.Close();
            command.Dispose();
            return Pts;
        }

       
        //
        //get rotation 
         public List<int> getCamRotation()
         {
             string query = String.Format(SQLManager.getAllCameraPts);
             command = new SqlCommand(query, connection);
             connection.Open();

             SqlDataReader reader = command.ExecuteReader();
             List<int> Pts = new List<int>();


             while (reader.Read())
             {
                
                 Pts.Add(Convert.ToInt32(reader[4].ToString()));

             }

             connection.Close();
             command.Dispose();
             return Pts;
         }
        //
        //public bool AddCamera(CameraInfo info)
        //{
        //    string query = String.Format(addCamera, info.Name, info.IP);

        //    command = new SqlCommand(query, connection);
        //    connection.Open();

        //    int row = ExecuteNonQuery(query);
        //    if (row == 1)
        //    {
        //        command.Dispose();
        //        connection.Close();
        //        return true;
        //    }

        //    command.Dispose();
        //    connection.Close();
        //    return false;
        //}
        public bool AddCamera(CameraInfo info )
        {
            string query = "INSERT INTO Cameras(Name,IP,RotationAngle,CoordinateX,CoordinateY) VALUES(@Name,@IP,@Rotation,@CoordinateX,@CoordinateY);";
            command.Parameters.AddWithValue("@id", info.Name);
            command.Parameters.AddWithValue("@id", info.IP);
       //     command.Parameters.AddWithValue("@id", info.Rotation);
            command.Parameters.AddWithValue("@id", info.Coordinates.X);
            command.Parameters.AddWithValue("@id", info.Coordinates.Y);
            command = new SqlCommand(query, connection);
            connection.Open();

            int row = ExecuteNonQuery(query);
            if (row == 1)
            {
                command.Dispose();
                connection.Close();
                return true;
            }

            command.Dispose();
            connection.Close();
            return false;
        }

        public bool DelCamera(string name)
        {
            string query = String.Format(delCamera, name);
            command = new SqlCommand(query, connection);
            connection.Open();

            int row = ExecuteNonQuery(query);
            if (row == 1)
            {
                command.Dispose();
                connection.Close();
                return true;
            }

            command.Dispose();
            connection.Close();
            return false;
        }
        //
        //
        //
        public bool AddCamera(string name,string ip, double rotation )
        {
            string query = String.Format(addCamera1, name, ip,rotation);
            command = new SqlCommand(query, connection);

            int row = ExecuteNonQuery(query);
            if (row == 1)
            {
                command.Dispose();
                return true;
            }

            command.Dispose();
          return false;
        }
        public bool AddCamera(string name, string ip, double rotation,string username,string pwd)
        {
            string query = String.Format(addCamera1, name, ip, rotation,username,pwd);
            command = new SqlCommand(query, connection);

            int row = ExecuteNonQuery(query);
            if (row == 1)
            {
                command.Dispose();
                return true;
            }

            command.Dispose();
            return false;
        }



        public bool AddCamera(string name, string ip, double rotation, string username, string pwd,bool reg,bool iden,bool tr)
        {
            int a, b, c;
            a = 0;
            b = 0;
            c = 0;
            if (reg)
                a = 1;
            if (iden)
                b = 1;
            if (tr)
                c = 1;
            string query = String.Format(addCamera2, name, ip, rotation, username, pwd,a,b,c);
            command = new SqlCommand(query, connection);

            int row = ExecuteNonQuery(query);
            if (row == 1)
            {
                command.Dispose();
                return true;
            }

            command.Dispose();
            return false;
        }
        //new editing 
        public bool AddCamera(string name, string ip, double rotation, string username, string pwd, bool reg, bool iden, bool tr, double xPt, double yPt)
        {
            int a, b, c;
            a = 0;
            b = 0;
            c = 0;
            if (reg)
                a = 1;
            if (iden)
                b = 1;
            if (tr)
                c = 1;
            string query = String.Format(addCamera3, name, ip, rotation, username, pwd, a, b, c,xPt,yPt);
            command = new SqlCommand(query, connection);

            int row = ExecuteNonQuery(query);
            if (row == 1)
            {
                command.Dispose();
                return true;
            }

            command.Dispose();
            return false;
        }
        //end 

        //
        public bool AddCamera(string name, string ip, double rotation, string username, string pwd, bool reg, bool iden, bool tr, double xPt, double yPt,bool od)
        {
            int a, b, c,d;
            a = 0;
            b = 0;
            c = 0;
            d = 0;
            if (reg)
                a = 1;
            if (iden)
                b = 1;
            if (tr)
                c = 1;
            if (od)
                d = 1;
            string query = String.Format(addCamera4, name, ip, rotation, username, pwd, a, b, c, xPt, yPt,d);
            command = new SqlCommand(query, connection);

            int row = ExecuteNonQuery(query);
            if (row == 1)
            {
                command.Dispose();
                return true;
            }

            command.Dispose();
            return false;
        }
        //
        public bool AddNeighbour(string name, string neighbour)
        {
            string query = String.Format(addNeighbour, name,neighbour);
            command = new SqlCommand(query, connection);
            
            int row = ExecuteNonQuery(query);
            if (row == 1)
            {
                command.Dispose();
                return true;
            }

            command.Dispose();
            return false;
        }

        public bool AddNeighbour(string name, string neighbour,string type)
        {
            string query = String.Format(addNeighbour1, name, neighbour,type);
            command = new SqlCommand(query, connection);

            int row = ExecuteNonQuery(query);
            if (row == 1)
            {
                command.Dispose();
                return true;
            }

            command.Dispose();
            return false;
        }
        public List<string> getNeighbors(string name)
        {
            string query = String.Format(selectNeighbors, name);
            command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            List<string> neighbors = new List<string>();

            while (reader.Read())
                neighbors.Add(reader["Neighbour"].ToString());


            connection.Close();
            command.Dispose();
            return neighbors;


        }

        // Get OD camera
        public string ChkODCam(string name)
        {
            string query = String.Format(selectCamOD, name);
            command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            string neighbors = "";
           
            while (reader.Read())
                neighbors=(reader["OD"].ToString());


            connection.Close();
            command.Dispose();
            return neighbors;


        }

        public bool AddVideoFile(string name, DateTime startTime, string fileName)
        {
            // Format
            //insert into VideoRecording values ('Cam1', ('20120618 10:34:09 AM'), ('20120618 10:34:10 AM'), 'testing.mp4')
            string query = String.Format(addRecordingVideo, name, startTime.ToString("yyyymmdd hh:mm:ss tt"), DateTime.Now.ToString("yyyymmdd hh:mm:ss tt"), fileName);

            command = new SqlCommand(query, connection);
            connection.Open();
            if (command.ExecuteNonQuery() != 1)
            {
                connection.Close();
                command.Dispose();
                return false;
            }

            connection.Close();
            command.Dispose();

            return true;
        }
        public List<Video> GetFiles(string camName, string startTime, string endTime)
        {
            List<Video> ret = new List<Video>();
            string[] temp = new string[2];

            Video v = GetVideo(camName, startTime, endTime);
            ret.Add(v);
            //ret.Add(temp[0]);
            while (isTimeLess(v.EndTime.ToString("hh:mm:ss"), endTime))
            {
                v = GetVideo(camName, startTime, endTime);
                ret.Add(v);
                //ret.Add(temp[0]);
            }

            return ret;
        }

        public List<Video> GetCamVideos(string camName)
        {
            string query = String.Format(getFileName, camName);
            List<Video> vid = new List<Video>();

            command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Video v = new Video();
                v.StartTime = Convert.ToDateTime(reader["StartTime"]);
                v.EndTime = Convert.ToDateTime(reader["EndTime"]);
                v.FileName = reader["FileName"].ToString();
                vid.Add(v);
            }

            command.Dispose();
            connection.Close();


            return vid;
        }

        public Video GetVideo(string camName, string startTime, string endTime)
        {
            string query = String.Format(getFileName, camName);
            Video v = new Video();

            command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            List<string> FileNames = new List<string>();

            while (reader.Read())
            {
                string time = Convert.ToDateTime(reader["StartTime"]).ToString("hh:mm:ss");

                if (isTimeLess(time, startTime))
                {
                    string[] a = new string[2];
                    string ret = reader["FileName"].ToString();
                    command.Dispose();
                    connection.Close();
                    v.FileName = ret;
                    v.StartTime = Convert.ToDateTime(reader["StartTime"]);
                    v.EndTime = Convert.ToDateTime(reader["EndTime"]);
                    a[0] = ret;
                    a[1] = reader["EndTime"].ToString();
                    return v;
                }

            }

            command.Dispose();
            connection.Close();


            return null;
        }


        bool isTimeLess(string time, string startTime)
        {

            if (Convert.ToInt32(time[0] + time[1]) > Convert.ToInt32(startTime[0] + startTime[1]))
            {
                return false;
            }
            else if (Convert.ToInt32(time[0] + time[1]) < Convert.ToInt32(startTime[0] + startTime[1]))
            {
                return true;
            }

            if (Convert.ToInt32(time[3] + time[4]) > Convert.ToInt32(startTime[3] + startTime[4]))
            {
                return false;
            }
            else if (Convert.ToInt32(time[3] + time[4]) < Convert.ToInt32(startTime[3] + startTime[4]))
            {
                return true;
            }

            if (Convert.ToInt32(time[6] + time[7]) > Convert.ToInt32(startTime[6] + startTime[7]))
            {
                return false;
            }
            else if (Convert.ToInt32(time[6] + time[7]) < Convert.ToInt32(startTime[6] + startTime[7]))
            {
                return true;
            }


            return false;
        }



    }



}
