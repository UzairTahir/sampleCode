using iTrack_1.Model;
using iTrack_1.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTrack_1.Controller
{

    public struct TimeInterval
    {
        public DateTime startTime;
        public DateTime endTime;

        public TimeInterval(DateTime startTime, DateTime endTime)
        {
            this.startTime = startTime;
            this.endTime = endTime;
        }
    }

    public class CameraTimeInfo
    {
        public string cameraName;
        public List<TimeInterval> timeIntervals = new List<TimeInterval>();
        public Color color;

        private SQLManager sql =new SQLManager();

        public CameraTimeInfo(string cameraName, DateTime startTime, DateTime endTime, Color color)
        {
            this.cameraName = cameraName;
            timeIntervals.Add(new TimeInterval(startTime, endTime));
            this.color = color;
        }
        public CameraTimeInfo(string cameraName, DateTime startTime, DateTime endTime)
        {
            this.cameraName = cameraName;
            timeIntervals.Add(new TimeInterval(startTime, endTime));
            
        }

        public void AddTimeInterval(TimeInterval time)
        {
            timeIntervals.Add(time);
        }
        
    }



    class Track
    {

        TimeLine timeLine;

        public TimeSpan thresholdTime = TimeSpan.FromSeconds(2);


        public List<CameraTimeInfo> cameraList = new List<CameraTimeInfo>();

        public DateTime checkTime;
        public string lastCamera = null;
        public TimeInterval camtime;

        public Track(ref TimeLine timeLine, TimeInterval interval)
        {
            this.timeLine = timeLine;

            timeLine.Initialize(interval.startTime, interval.endTime);


            //AddCameraStrip("camera1", new TimeInterval(new DateTime(2016, 10, 18, 1, 0, 0), new DateTime(2016, 10, 18, 10, 0, 0)));
            //AddCameraStrip("camera2", new TimeInterval(new DateTime(2016, 10, 18, 10, 0, 0), new DateTime(2016, 10, 18, 15, 0, 0)));
            //AddCameraStrip("camera3", new TimeInterval(new DateTime(2016, 10, 18, 15, 0, 0), new DateTime(2016, 10, 18, 17, 0, 0)));
            //AddCameraStrip("camera4", new TimeInterval(new DateTime(2016, 10, 18, 17, 0, 0), new DateTime(2016, 10, 18, 18, 0, 0)));
            //AddCameraStrip("camera1", new TimeInterval(new DateTime(2016, 10, 18, 18, 0, 0), new DateTime(2016, 10, 18, 23, 0, 0)));
            //AddDummyData();
        }

        public void AddDummyData()
        {
            //AddCameraStrip("camera1", new TimeInterval(new DateTime(2016, 10, 18, 1, 0, 0), new DateTime(2016, 10, 18, 10, 0, 0)));
            //AddCameraStrip("camera2", new TimeInterval(new DateTime(2016, 10, 18, 10, 0, 0), new DateTime(2016, 10, 18, 15, 0, 0)));
            //AddCameraStrip("camera3", new TimeInterval(new DateTime(2016, 10, 18, 15, 0, 0), new DateTime(2016, 10, 18, 17, 0, 0)));
            //AddCameraStrip("camera4", new TimeInterval(new DateTime(2016, 10, 18, 17, 0, 0), new DateTime(2016, 10, 18, 18, 0, 0)));
            //AddCameraStrip("camera1", new TimeInterval(new DateTime(2016, 10, 18, 18, 0, 0), new DateTime(2016, 10, 18, 23, 0, 0)));
            //AddCameraStrip("camera5", new TimeInterval(new DateTime(2016, 10, 18, 15, 0, 0), new DateTime(2016, 10, 18, 17, 0, 0)));
            //AddCameraStrip("camera6", new TimeInterval(new DateTime(2016, 10, 18, 15, 0, 0), new DateTime(2016, 10, 18, 17, 0, 0)));

        }

        public void AddCameraStrip(string camName, TimeInterval timeInterval)
        {
            int cameraIndex = GetCameraIndex(camName);
            if (cameraIndex == -1)
            {
                // new camera
                CameraTimeInfo cam = new CameraTimeInfo(camName, timeInterval.startTime, timeInterval.endTime, Color.FromArgb(167, 173, 173));
                cameraList.Add(cam);
                timeLine.DrawCameraStrip(cam);
            }
            else
            {
                // old camera
                CameraTimeInfo cam = cameraList[cameraIndex];
                cam.AddTimeInterval(timeInterval);
                cameraList[cameraIndex] = cam;
                timeLine.UpdateCameraStip(cam);
            }

        }
        public int GetCameraIndex(string cameraName)
        {
            for (int i = 0; i < cameraList.Count; i++)
            {
                if (cameraList[i].cameraName == cameraName)
                    return i;
            }
            return -1;

        }

        //bool trackLost = true;
        public bool CheckCamera(string cameraName)
        {

            if (cameraName == null)
            {
                //trackLost = true;
                // if person not found 
                if (lastCamera == null)
                {
                    // could not find person since last miss
                    return false;
                }
                TimeSpan missingTime = DateTime.Now.Subtract(checkTime);
                if (missingTime > thresholdTime)
                {
                    //camtime.endTime = DateTime.Now;
                    ////cameraList.Add(new CameraTimeInfo(lastCamera, camtime.startTime, camtime.endTime));
                    //AddCameraStrip(lastCamera, camtime);
                    SuspectLeftFov();

                    return true;
                }
                else
                    return false;
            }
            else
            {
                //if (trackLost)
                //    camtime.startTime = DateTime.Now;

                checkTime = DateTime.Now;

                if (lastCamera != null)
                {
                    if (lastCamera.Equals(cameraName))
                    {
                        // same camera
                        camtime.endTime = DateTime.Now;
                    }
                    else
                    {
                        // camera changed
                        //camtime.endTime = DateTime.Now;
                        //cameraList.Add(new CameraTimeInfo(lastCamera, camtime.startTime, camtime.endTime));
                        //AddCameraStrip(lastCamera, camtime);
                        SuspectLeftFov();
                    }


                }
                else
                {
                    // first occurance
                    camtime = new TimeInterval(DateTime.Now, DateTime.MaxValue);

                }


                
                //trackLost = false;
                lastCamera = cameraName;
                return false;
            }
        }

        public void SuspectLeftFov()
        {
            if (lastCamera != null)
            {
                camtime.endTime = DateTime.Now;
                //cameraList.Add(new CameraTimeInfo(lastCamera, camtime.startTime, camtime.endTime));
                AddCameraStrip(lastCamera, camtime);

            }
            lastCamera = null;
        }


        public string TimeToString(DateTime dt)
        {
            return dt.Hour + ":" + dt.Minute + ":" + dt.Second;

        }


    }
}
