using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTrack_1.Controller;

namespace iTrack_1.UserControls
{

   
    public partial class TimeLine : UserControl
    {
        public TimeInterval main;
        

        public TimeLine()
        {
            InitializeComponent();
        }

        public void Initialize(DateTime startTime, DateTime endTime)
        {

            main = new TimeInterval(startTime, endTime);

        }
        public void Initialize()
        {
            main = new TimeInterval(DateTime.Now, DateTime.Now.AddMinutes(10));
        }

        



        public void DrawCameraStrip(CameraTimeInfo cam)
        {
            if (cam.timeIntervals[cam.timeIntervals.Count - 1].endTime.Subtract(main.endTime).TotalMilliseconds > 0)
            {
                main.endTime = cam.timeIntervals[cam.timeIntervals.Count - 1].endTime.AddMinutes(2);
            }

            int heightOfstrip = 32;
            int widthOfstrip = 512;

            Bitmap img = new Bitmap(widthOfstrip, heightOfstrip);

            using (Graphics g = Graphics.FromImage(img))
            {
                // Draw horizontal line
                g.DrawLine(new Pen(Color.Black, 1), new Point(0, img.Height / 2), new Point(img.Width, img.Height / 2));

                // Draw strip time periods
                foreach (TimeInterval ti in cam.timeIntervals)
                {
                    Point startPoint = new Point((int)(((ti.startTime.Subtract(main.startTime).TotalSeconds) / (float)(main.endTime.Subtract(main.startTime)).TotalSeconds) * img.Width), img.Height / 4);
                    Size size = new Size((int)(((ti.endTime.Subtract(ti.startTime).TotalSeconds) / (float)(main.endTime.Subtract(main.startTime).TotalSeconds)) * img.Width), img.Height / 2);
                    g.FillRectangle(new SolidBrush(cam.color), new Rectangle(startPoint, size));
                }
            }


            // Add PictureBox
            PictureBox pb = new PictureBox();
            pb.Size = new Size(widthOfstrip, heightOfstrip);
            pb.Dock = DockStyle.Bottom;
            pb.BackColor = Color.FromArgb(53,66,75);
            pb.Image = img;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pnlTimeLine.Controls.Add(pb);
            pb.MouseEnter += delegate (System.Object o, System.EventArgs e) { pb.BackColor = Color.FromArgb(43, 56, 65); };
            pb.MouseLeave += delegate (System.Object o, System.EventArgs e) { pb.BackColor = Color.FromArgb(53, 66, 75); };
            pb.Tag = cam;
            
        }
        public void UpdateCameraStip(CameraTimeInfo cam)
        {
            if(cam.timeIntervals[cam.timeIntervals.Count-1].endTime.Subtract(main.endTime).TotalMilliseconds > 0)
            {
                main.endTime = cam.timeIntervals[cam.timeIntervals.Count - 1].endTime.AddMinutes(2);
            }


            foreach(PictureBox pb in pnlTimeLine.Controls)
            {
                if( ((CameraTimeInfo)pb.Tag).Equals(cam) )
                {
                    Image img = pb.Image;

                    using (Graphics g = Graphics.FromImage(img))
                    {
                        // Draw horizontal line
                        g.DrawLine(new Pen(Color.Black, 1), new Point(0, img.Height / 2), new Point(img.Width, img.Height / 2));

                        // Draw strip time periods
                        foreach (TimeInterval ti in cam.timeIntervals)
                        {
                            Point startPoint = new Point((int)(((ti.startTime.Subtract(main.startTime).TotalSeconds) / (float)(main.endTime.Subtract(main.startTime)).TotalSeconds) * img.Width), img.Height / 4);
                            Size size = new Size((int)(((ti.endTime.Subtract(ti.startTime).TotalSeconds) / (float)(main.endTime.Subtract(main.startTime).TotalSeconds)) * img.Width), img.Height / 2);
                            g.FillRectangle(new SolidBrush(cam.color), new Rectangle(startPoint, size));
                        }
                    }
                    pb.Image = img;
                    break;
                }
            }
        }
        


        public void UpdateAll(CameraTimeInfo[] tmpList)
        {
            // instead of this update image of each panel

            pnlTimeLine.Controls.Clear();
            //CameraTimeInfo[] tmpList = new CameraTimeInfo[cameraList.Count];
            //cameraList.CopyTo(tmpList);
            //cameraList.Clear();


            //foreach (CameraTimeInfo cam in tmpList)
            //{
            //    foreach (TimeInterval interval in cam.timeIntervals)
            //        AddCameraStrip(cam.cameraName, interval);
            //}


        }
        public void UpdateMainInterval(TimeInterval ti, CameraTimeInfo[] tmpList)
        {
            main = ti;
            UpdateAll(tmpList);
        }



    }


}
