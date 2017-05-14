using iTrack_1.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTrack_1.Controller
{
    public class RecordingInfo
    {
        public string CameraName
        {
            get;
            set;
        }

        public string URL
        {
            get;
            set;
        }

        public Process RecordingProcess
        {
            get;
            set;
        }

        public DateTime StartTime
        {
            get;
            set;
        }

        public RecordingInfo (string CamName,string url,Process RecordProcess=null)
        {
            CameraName = CamName;
            RecordingProcess = RecordProcess;
            URL = url;
        }
       

        public void StartRecording()
        {
            RecordingProcess = new Process();
            RecordingProcess.StartInfo.FileName = "ffmpeg.exe";
            string dt = DateTime.Now.ToString("hh-mm-ss"); //string dt = DateTime.Now.ToString("hh-mm-ss-tt");
            string output = "Recording/" + CameraName + "_" + dt + ".mp4";//+ dt + ".mp4";
            //string output = "e:/" + info.Name + ".mp4";//+ "-" + dt + ".mp4";
            //p.StartInfo.Arguments = "-i " + url + " -acodec copy " + output; //Recording/"+info.Name+dt+".mp4";
            RecordingProcess.StartInfo.Arguments = "-i " + URL + " -acodec copy -y " + output; //Recording/"+info.Name+dt+".mp4";
            RecordingProcess.StartInfo.UseShellExecute = false;
            RecordingProcess.StartInfo.RedirectStandardOutput = true;

            StartTime = DateTime.Now;
            RecordingProcess.Start();

        }

        public void StopRecording()
        {

            RecordingProcess.Kill();
        }
        

        
    }

    public class Video
    {
        public DateTime StartTime
        {
            get;
            set;
        }
        public DateTime EndTime
        {
            get;
            set;
        }
        public string FileName
        {
            get;
            set;
        }
    }


    public class CameraRecording
    {
        private static CameraRecording ins;

        private List<RecordingInfo> Processes;

        public static CameraRecording Instance
        {
            get
            {
                if (ins == null)
                {
                    ins = new CameraRecording();
                    
                }
                return ins;
            }
        }

        public void InteruptRecording(string cam)
        {
            for (int i=0;i<Processes.Count;i++)
            {
                if (Processes.ElementAt(i).CameraName==cam)
                {
                    Processes.ElementAt(i).StopRecording();

                    DateTime pre = Processes.ElementAt(i).StartTime;
                    // insert file info into db here
                    DateTime dt = DateTime.Now; //string dt = DateTime.Now.ToString("hh-mm-ss-tt");
                    Processes.ElementAt(i).StartTime = dt;
                    string time = dt.ToString("hh-mm-ss");

                    SQLManager sql = new SQLManager();
                    
                    sql.AddVideoFile(cam, pre, cam + "_" + pre + ".mp4");

                    Processes.ElementAt(i).StartRecording();
                    return;
                }
            }
        }

        public void AddProcess(RecordingInfo inf)
        {
            if (Processes == null)
                Processes = new List<RecordingInfo>();

            Processes.Add(inf);
        }



        // For timeline
        public void CutVideo(string CamName,DateTime start,DateTime end,string output)
        {
            SQLManager sql = new SQLManager();
            List<Video> vid= null;
            
            for (int i=0;i<Processes.Count;i++)
            {
                if (CamName==Processes.ElementAt(i).CameraName)
                {
                    vid = sql.GetFiles(CamName,start.ToString("hh-mm-ss"),end.ToString("hh-mm-ss"));
                    break;
                }
            }

            
            int totalSeconds = VideoGeneration.initSec(start.ToString("hh:mm:ss"), end.ToString("hh-mm-ss"));



            for (int i = 0; totalSeconds > 0; i++)
            {
                int skip = VideoGeneration.initSec(vid.ElementAt(i).StartTime.ToString("hh-mm-ss"), start.ToString("hh-mm-ss"));
                int get = VideoGeneration.initSec(start.ToString("hh-mm-ss"), vid.ElementAt(i).EndTime.ToString("hh-mm-ss"));
                start = vid.ElementAt(i).EndTime;
                totalSeconds = totalSeconds - get;
                Cutting(skip, get, vid.ElementAt(i).FileName, "Crop\\"+output + ".mp4");
            }



           
        }


        public void Cutting(int after, int crop,string fileName,string outputFile)
        {
            //   ffmpeg - i movie.mp4 - ss 00:00:03 - t 00:00:08 - async 1 cut.mp4



            Process p = new Process();
            p.StartInfo.FileName = "ffmpeg.exe";
            //p.StartInfo.Arguments = "-i C:\\Users\\Arslan\\Desktop\\Camera21.mp4 - ss 00:00:03 - t 00:00:08 - async 1 C:\\Users\\Arslan\\Desktop\\cut.mp4";


            crop = crop - 10;
            //it works fine :D
            p.StartInfo.Arguments = "-ss " + after + " -i " + fileName + " -c copy -y -t " + crop + outputFile;
            //start after 30 seconds and copy 10 seconds video

            //p.StartInfo.Arguments = "-i C:\\Users\\Arslan\\Desktop\\Camera21.mp4 -ss 00:00:10 -t 00:00:02 -acodec copy -vcodec copy C:\\Users\\Arslan\\Desktop\\cut2.mp4";
            //p.StartInfo.Arguments = "-i C:\\Users\\Arslan\\Desktop\\Camera21.mp4 -ss 00:00:10 -c copy -t 00:00:05 C:\\Users\\Arslan\\Desktop\\cut2.mp4";





            //p.StartInfo.Arguments = "-i C:\\Users\\Arslan\\Desktop\\Camera21.mp4 -vf trim=10:30 C:\\Users\\Arslan\\Desktop\\cut2.mp4";

            //p.StartInfo.Arguments = " -ss 00:00:10 -i C:\\Users\\Arslan\\Desktop\\Camera21.mp4 -to 00:00:30 -c copy -copyts C:\\Users\\Arslan\\Desktop\\cut2.mp4";

            p.Start();
        }



    }
    
}
