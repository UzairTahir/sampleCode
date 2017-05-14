
using iTrack_1.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrack.UserControls;
using Emgu.CV.Structure;
using Emgu.CV;
using iTrack_1;
using System.Windows.Forms;
using iTrack_1.View;
using iTrack_1.Controller;

namespace iTrack.Controller
{
    public class CameraInfo
    {
        public string name { get; set; }
        public string ip { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public double degree { get; set; }
        public Point Coordinates{get;set;}
        public List<string> neighbours { get; set; }
        public bool Tracking { get; set; }
        public bool OD { get; set; }
        public string ODneighbour { get; set; }
        public bool Registration { get; set; }
        public bool Identification { get; set; }
        private string url;
        public string URL
        {
            get
            {
                url = "rtsp://";
                url = url + User + ":" + Password;
                url = url + "@" + IP + "/Streaming/channels/1";
                return url;
            }

            //get
            //{
            //    url = "rtsp://";
            //    url = url + User + ":" + Password;
            //    url = url + "@" + IP + "/11";
            //    return url;
            //}

        }

        public CameraInfo (string name,string ip,double degree,List<string>neighbours)
        {
            this.name=name;
            this.ip=ip;
            this.degree=degree;
            this.neighbours=neighbours;
        }

         public CameraInfo(string name, string ip, double degree, List<string> neighbours,string username , string pwd)
         {
             this.name = name;
             this.ip = ip;
             this.degree = degree;
             this.neighbours = neighbours;
             this.user = username;
             this.password = pwd;
         }
        public CameraInfo(string name, string ip, double degree, List<string> neighbours, string username, string pwd,int reg,int id,int tr)
        {
            this.name = name;
            this.ip = ip;
            this.degree = degree;
            this.neighbours = neighbours;
            this.user = username;
            this.password = pwd;
            Registration = false;
            Identification = false;
            Tracking = false;
            if (reg==1)
                Registration = true;
            if (id == 1)
                Identification = true;
            if (tr == 1)
                Tracking = true;
            
        }

        public CameraInfo(string name, string ip, double degree, List<string> neighbours, string username, string pwd, int reg, int id, int tr,int od)
        {
            this.name = name;
            this.ip = ip;
            this.degree = degree;
            this.neighbours = neighbours;
            this.user = username;
            this.password = pwd;
            Registration = false;
            Identification = false;
            Tracking = false;
            OD = false;
            if (reg == 1)
                Registration = true;
            if (id == 1)
                Identification = true;
            if (tr == 1)
                Tracking = true;
            if (od == 1)
                OD = true;
        }
        public CameraInfo(string name, string ip, double degree, List<string> neighbours, string username, string pwd, int reg, int id, int tr, int od,string odneighbour)
        {
            this.name = name;
            this.ip = ip;
            this.degree = degree;
            this.neighbours = neighbours;
            this.user = username;
            this.password = pwd;
            Registration = false;
            Identification = false;
            Tracking = false;
            OD = false;
            if (reg == 1)
                Registration = true;
            if (id == 1)
                Identification = true;
            if (tr == 1)
                Tracking = true;
            if (od == 1)
                OD = true;
            this.ODneighbour = odneighbour;
        }
        public CameraInfo()
        {
            name = null;
            ip = null;
        }
        public CameraInfo(string Name, string IP)
        {
            name = Name;
            ip = IP;
        }

        public CameraInfo(string Name, string IP, string User, string Password)
        {
            name = Name;
            ip = IP;
            user = User;
            password = Password;
        }

        public CameraInfo(string Name, string IP, float Rotation, Point Coordinates)
        {
            name = Name;
            ip = IP;
            this.degree = Rotation;
            this.Coordinates = Coordinates;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string IP
        {
            get { return ip; }
            set { ip = value; }
        }

        public string User
        {
            get { return user; }
            set { user = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }

    public class CameraManager
    {
        private SQLManager sql;
        List<Camera> cameras;
        List<CameraInfo> AllCams;
        List<EventHandler> eh;
        List<string> camNames;

        private static CameraManager ins;

        public static CameraManager Instance
        {
            get
            {
                if (ins == null)
                {
                    ins = new CameraManager();
                }
                return ins;
            }
        }

        private CameraManager()
        {
            sql = new SQLManager();
            cameras = new List<Camera>();
            AllCams = sql.getAllCams();
            eh = new List<EventHandler>();
            camNames = new List<string>();
        }

        public List<Controller.CameraInfo> GetAllCams()
        {
            return sql.getAllCams();
        }

        public List<Controller.CameraInfo> GetAllRegCams()
        {
            List<CameraInfo> cams = sql.getAllCams();
            List<CameraInfo> fin = new List<CameraInfo>();
            foreach (CameraInfo c in cams)
                if (c.Registration)
                    fin.Add(c);
            return fin;
        }


        public List<string> getNeighbours(string cameraname)
        {

            return sql.getNeighbors(cameraname);
        }
        public int chkODNeighbour(string cameraname)
        {
            int ret = 0;
            string chk;
            chk = sql.ChkODCam(cameraname);
            ret = Convert.ToInt32(chk);
            return ret;

        }
        public List<Controller.CameraInfo> GetAllIdnCams()
        {
            List<CameraInfo> cams = sql.getAllCams();
            List<CameraInfo> fin = new List<CameraInfo>();
            foreach (CameraInfo c in cams)
                if (c.Identification)
                    fin.Add(c);
            return fin;
        }

        public List<Controller.CameraInfo> GetAllTrackCams()
        {
            List<CameraInfo> cams = sql.getAllCams();
            List<CameraInfo> fin = new List<CameraInfo>();
            foreach (CameraInfo c in cams)
                if (c.Tracking)
                    fin.Add(c);
            return fin;
        }


        public bool AddCamera(CameraInfo info)
        {

            return false;
        }
        
        public void AddCamera(Camera c)
        {
            if (c != null)
                cameras.Add(c);
        }

        public void AddCamera(string name,string ip,double rotation)
        {
            
                sql.AddCamera( name, ip, rotation);
            
        }
        public void AddCamera(string name, string ip, double rotation,string username,string pwd)
        {

            sql.AddCamera(name, ip, rotation,username,pwd);

        }
        public void AddCamera(string name, string ip, double rotation, string username, string pwd,bool reg,bool iden,bool tr)
        {

            sql.AddCamera(name, ip, rotation, username, pwd,reg,iden,tr);

        }
        public void AddCamera(string name, string ip, double rotation, string username, string pwd, bool reg, bool iden, bool tr,Point pt)
        {

            sql.AddCamera(name, ip, rotation, username, pwd, reg, iden, tr, pt.X, pt.Y);

        }

        public void AddCamera(string name, string ip, double rotation, string username, string pwd, bool reg, bool iden, bool tr, Point pt,bool od)
        {

            sql.AddCamera(name, ip, rotation, username, pwd, reg, iden, tr, pt.X, pt.Y,od);

        }
        public void addNeighbours(string name,List<string> lst)
        {
            for (int i = 0; i < lst.Count;i++ )

                sql.AddNeighbour(name, lst[i]);

        }
        //add neighbour
        public void addNeighbours(string name, List<string> lst,string odneighbour)
        {

            for (int i = 0; i < lst.Count; i++)
                if (lst[i] != odneighbour)
                    sql.AddNeighbour(name, lst[i], "CD");
                else
                    sql.AddNeighbour(name, lst[i], "OD");

        }

        public void RemoveCamera(string name)
        {
            if (name != null)
                return;
            for (int i=0;i<cameras.Count;i++)
                if (cameras[i].Name==name)
                {
                    cameras.RemoveAt(i);
                    return;
                }

        }

        public int GetCameraIndex(string name)
        {
            for (int i=0;i<cameras.Count;i++)
            {
                if (cameras[i].CameraName == name)
                    return i;
            }
            return -1;
        }


        public Mat GetFrameAt(int i)
        {
            if (i>=0 && i<cameras.Count)
            {
                return cameras[i].GetFrame();
            }
            return null;
        }

        public Mat GetFrame(string name)
        {
            foreach (Camera c in cameras)
            {
                if (c.CameraName == name)
                {
                    return c.GetFrame();
                }
            }
            return null;
        }

        public List<Mat> GetFrameFromAllCams()
        {
            List<Mat> frames = new List<Mat>();
            foreach (Camera c in cameras)
                frames.Add(c.GetFrame());

            return frames;
        }


        public bool AddCameraDB(CameraInfo info)
        {
            return sql.AddCamera(info);
        }

        public bool DelCameraDB(string name)
        {
            return sql.DelCamera(name);
        }

      
        public CameraInfo GetCamInfo(string name)
        {
            foreach (CameraInfo cam in AllCams)
                if (cam.Name == name)
                    return cam;
            return null;
        }

        public void addEH(string name,EventHandler eeh)
        {
            camNames.Add(name);
            eh.Add(eeh);
        }

        public List<Point> getpts()
        {
            List<int> pts;
            List<Point> pts1=new List<Point>();
           pts= sql.getAllpts();
                int i=0;
            while (i<pts.Count)
            {
                Point Tpt = new Point(pts[i], pts[i + 1]);
                pts1.Add(Tpt);
                i += 2;
            }
            return pts1;
        }

        public List<int> getRotation()
        {
            return sql.getCamRotation();
           
        }

        public bool StopCam(string CameraName)
        {
            int index = -1;
            for (int i=0;i<camNames.Count;i++)
            {
                if (camNames.ElementAt(i) == CameraName)
                {
                    index = i;
                }
            }
            if (index == -1)
                return false;
            Application.Idle -= eh.ElementAt(index);


            //call frame to show same frame video

            CamerafromMap form=new CamerafromMap(GetCamInfo(CameraName),eh.ElementAt(index));
            form.Visible = true;



            return true;
        }



        int FrameCount = 0;
        int RecordedFPS = 25;
        List<List<Video>> allVids = null;
        List<int> secs = new List<int>();
        List<Capture> cap = new List<Capture>();
        List<int> fps;

        public Mat getRecordedFrame(string cam)
        {
            if (allVids == null)
            {
                GetVideosinfo();
            }
            for (int i=0;i<allVids.Count;i++)
            {
                if (AllCams.ElementAt(i).Name == cam)
                    if (cap.ElementAt(i) == null)
                        return null;
            }
            
            Mat frame = null;
            if (FrameCount < 30)
            {
                FrameCount++;
                for (int i = 0; i < cap.Count; i++)
                {
                    if (cap.ElementAt(i) == null)
                        continue;
                    if (AllCams.ElementAt(i).Name == cam)
                        
                        frame = cap.ElementAt(i).QueryFrame();
                    else
                        cap.ElementAt(i).QueryFrame();
                }
            }
            else
            {
                FrameCount = 0;
                for (int i = 0; i < cap.Count; i++)
                {
                    if (cap.ElementAt(i) == null)
                        continue;
                    if (AllCams.ElementAt(i).Name == cam)
                        frame = cap.ElementAt(i).QueryFrame();
                    else
                        cap.ElementAt(i).QueryFrame();
                    secs[i] = secs[i] - 1;
                    if (secs[i] == 0)
                    {
                        return null;
                    }
                    if (secs.ElementAt(i) == 0)
                    {
                        
                        if (allVids.ElementAt(i).Count > 0)
                        {
                            allVids.ElementAt(i).RemoveAt(0);
                            cap[i] = new Capture(allVids.ElementAt(i).ElementAt(0).FileName);
                            secs[i] = VideoGeneration.initSec(allVids.ElementAt(i).ElementAt(0).StartTime.ToString("hh:mm:ss"), allVids.ElementAt(i).ElementAt(0).EndTime.ToString("hh:mm:ss"));

                        }


                    }

                }

            }
            return frame;

            //if (RecordedFPS == 0)
            //{
            //    ShellFile shellFile = ShellFile.FromFilePath(sourceFile);
            //    int fps =  Convert.ToInt32((shellFile.Properties.System.Video.FrameRate.Value / 1000));
            //}


        }
        public void GetVideosinfo()
        {
            allVids = new List<List<Video>>();
            secs = new List<int>();
            fps = new List<int>();

            for (int i = 0; i < AllCams.Count; i++)
            {
                allVids.Add(sql.GetCamVideos(AllCams.ElementAt(i).Name));
                if (allVids.ElementAt(i).Count == 0)
                {
                    secs.Add(0);
                    cap.Add(null);
                }
                else
                {
                    Video temp = allVids.ElementAt(i).ElementAt(0);
                    secs.Add(VideoGeneration.initSec(temp.StartTime.ToString("hh:mm:ss"), temp.EndTime.ToString("hh:mm:ss")));
                    cap.Add(new Capture("Recording/" + temp.FileName));
                }
                //ShellFile shellFile = ShellFile.FromFilePath("Recording/" + allVids.ElementAt(i).ElementAt(0).FileName);
                //fps.Add(Convert.ToInt32((shellFile.Properties.System.Video.FrameRate.Value / 1000)));
            }
        }

    }



}
