using iTrack_1.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace iTrack_1.Controller
{
    public class Interval
    {
        public string cameraName
        {
            get;
            set;
        }
        
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }

        public Interval(string cameraName,DateTime startTime, DateTime endTime)
        {
            this.startTime = startTime;
            this.endTime = endTime;
            this.cameraName = cameraName;
        }


    }

    public static class VideoGeneration
    {
        public static void CutVideo(string input,string output,string start,string end,string videoStartingTime,string ffmpeg = "ffmpeg.exe")
        {
            //   ffmpeg - i movie.mp4 - ss 00:00:03 - t 00:00:08 - async 1 cut.mp4

            Process p = new Process();
            p.StartInfo.FileName = ffmpeg;
            
            p.StartInfo.Arguments = "-ss "+ initSec(videoStartingTime,start) + " - i "+input+" -c copy -t "+ initSec(start, end)  + output;
            
            p.Start();
        }

        public static int initSec(string Vstart,string start)
        {
            int hour, min, sec;
            string temp = Vstart[0].ToString() + Vstart[1].ToString();
            hour = Convert.ToInt32(temp);
            min = Convert.ToInt32(Vstart[3].ToString() + Vstart[4].ToString());
            sec = Convert.ToInt32(Vstart[6].ToString() + Vstart[7].ToString());

            int houra, mina, seca;
            houra = Convert.ToInt32(start[0].ToString() + start[1].ToString());
            mina = Convert.ToInt32(start[3].ToString() + start[4].ToString());
            seca = Convert.ToInt32(start[6].ToString() + start[7].ToString());


            int total = 0;

            int s, m, h;
            s = seca - sec;
            m = mina - min;
            h = houra - hour;
            total = total + s;
            total = total + m * 60;
            total = total + h * 3600;

            return total;


            total = 0;
            if (sec!=seca)
            { 
                if (sec < seca)
                {
                    total = total + seca - sec;
                }
                else
                    total = total - sec + seca;
            }

            if (min != mina)
            {
                if (min < mina)
                {
                    total = total + (mina - min) * 60;
                }
                else
                    total = total - (min - mina) * 60;
            }

            if (hour != houra)
            {
                if (hour < houra)
                {
                    total = total + (houra - hour) * 3600;
                }
                else
                    total = total - (hour - houra) * 3600;
            }


            return total;
        }

        public static void combinevidsList(List<string> inputVideos, string output)
        {
            
            if (inputVideos==null)
            {
                return;
            }
            if (inputVideos.Count==0)
            {
                return;
            }
            if (!Directory.Exists("Temp"))
                Directory.CreateDirectory("Temp");
            System.IO.DirectoryInfo di = new DirectoryInfo("Temp/");
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }


            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "ffmpeg.exe";
            //startInfo.WorkingDirectory = "c:/ffmpeg/";

            int count = 0;
            foreach (string vid in inputVideos)
            {
                count++;
                startInfo.Arguments = " -i " + vid + " -c copy -bsf:v h264_mp4toannexb -f mpegts -y Temp/intermediate" + count + ".ts";
                process.StartInfo = startInfo;
                process.Start();
            }
            string concat = "";
            for (int i = 1; i <= count; i++)
            {
                concat = concat + "Temp/" + "intermediate" + i + ".ts";
                if (i + 1 <= count)
                {
                    concat = concat + "|";
                }

            }


            startInfo.Arguments = " -i \"concat:" + concat + "\" -c copy -y -bsf:a aac_adtstoasc " + output;
            process.StartInfo = startInfo;
            process.Start();



        }

        public static string GenerateVideo(List<Interval> timeIntervals)
        {
            int i = 0;
            string outputFileName = null;
            List<string> outputs = new List<string>();
            SQLManager sql = new SQLManager();

            if (!Directory.Exists("MultipleTemp"))
                Directory.CreateDirectory("MultipleTemp");


            System.IO.DirectoryInfo di = new DirectoryInfo("MultipleTemp/");
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }

            foreach (Interval Time in timeIntervals)
            {
                i++;
                List<Video> vidFiles = sql.GetFiles(Time.cameraName, Time.startTime.ToString("hh:mm:ss"), Time.endTime.ToString("hh:mm:ss"));
                string file = i + ".mp4";
                if (vidFiles.Count < 1)
                {
                    //no video found
                    return null;
                }
                else if (vidFiles.Count == 1)
                {
                    CutVideo(vidFiles[0].FileName, "Cut/" + file, Time.startTime.ToString("hh:mm:ss"), Time.endTime.ToString("hh:mm:ss"), vidFiles[0].StartTime.ToString("hh:mm:ss"));
                    outputs.Add(file);
                }
                else
                {
                    int count = vidFiles.Count;
                    CutVideo(vidFiles[0].FileName, "MultipleTemp/" + "0.mp4", Time.startTime.ToString("hh:mm:ss"), vidFiles[0].EndTime.ToString("hh:mm:ss"), vidFiles[0].StartTime.ToString("hh:mm:ss"));
                    CutVideo(vidFiles[count - 1].FileName, "MultipleTemp/" + "1.mp4", vidFiles[count - 1].StartTime.ToString("hh:mm:ss"), Time.endTime.ToString("hh:mm:ss"), vidFiles[0].StartTime.ToString("hh:mm:ss"));
                    List<string> temp = new List<string>();
                    temp.Add("MultipleTemp/0.mp4");
                    for (int j = 1; j < count - 1; j++)
                    {
                        temp.Add(vidFiles[j].FileName);
                    }
                    temp.Add("MultipleTemp/1.mp4");
                    combinevidsList(temp, file);
                    outputs.Add(file);
                }

            }
            if (!Directory.Exists(Global.VideoOutputDirectory))
            {
                Directory.CreateDirectory(Global.VideoOutputDirectory);
            }

            DateTime time = DateTime.Now;
            outputFileName = "Output-" + time.ToString("hh:mm:ss") + ".mp4";
            combinevidsList(outputs, outputFileName);
            return outputFileName;

        }

    }
}
