using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTrack_1.View
{
    public partial class OdNeighbour : MetroFramework.Forms.MetroForm
    {
        private string selectedCamera ;
        private imageManupilation im;
        private Point firstPt;
        private Point SecPt;
        public OdNeighbour()
        {
            InitializeComponent();
        }
        public OdNeighbour(string cameraname)
        {
            this.selectedCamera = cameraname;
            InitializeComponent();
            firstPt = new Point();
            SecPt = new Point();
            this.Text = cameraname;
        }

        private void OdNeighbour_Load(object sender, EventArgs e)
        {
            //getframe 
            
            //
            string path = @"E:\8th Semester\FYP-2\door.jpg";
            //
            //Image img = im.ScaleImage(new Bitmap(path), cameraframepicbox.Size.Width, cameraframepicbox.Size.Height);
            Image img = new Bitmap(new Bitmap(path),640,480);
            cameraframepicbox.BackgroundImage = new Bitmap(img);
          //
            
        }

        private void cameraframepicbox_Click(object sender, EventArgs e)
        {
            var mouseEventArgs = e as MouseEventArgs;
            
             if (mouseEventArgs != null)
             {
                 //if (firstPt == null)
                 //{
                 //    Point pt = new Point(mouseEventArgs.X, mouseEventArgs.Y);
                 //    firstPt = pt;
                 //}
                 //else if (SecPt==null)
                 //{
                 //    Point pt = new Point(mouseEventArgs.X, mouseEventArgs.Y);
                 //    SecPt = pt;
                 //   // Draw();
                 //}
                 //
                 
                 if (mouseEventArgs.Button== MouseButtons.Right)
                 {
                     SecPt= new Point(mouseEventArgs.X, mouseEventArgs.Y);
                     this.Refresh();
                     
                 }
                 else if (mouseEventArgs.Button == MouseButtons.Left)
                 {
                     firstPt = new Point(mouseEventArgs.X, mouseEventArgs.Y);
                     
                     this.Refresh();
                    
                 }

             }
        }
        private void Draw()
        {
            if (firstPt != null && SecPt != null)
            {
                System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Red);
                

                System.Drawing.Graphics formGraphics;
                formGraphics = this.CreateGraphics();
                formGraphics.DrawRectangle(myPen, new Rectangle(firstPt.X, firstPt.Y, Math.Abs(SecPt.X - firstPt.X), Math.Abs(SecPt.Y - firstPt.Y)));
                myPen.Dispose();
                formGraphics.Dispose();
            }
        }

        private void cameraframepicbox_Paint(object sender, PaintEventArgs e)
        {
            if (firstPt != null && SecPt != null)
            {
                System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Red,2);
                //System.Drawing.Graphics formGraphics;
                //formGraphics = this.CreateGraphics();
                e.Graphics.DrawRectangle(myPen, new Rectangle(firstPt.X, firstPt.Y, (SecPt.X - firstPt.X), (SecPt.Y - firstPt.Y)));
                myPen.Dispose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Calling controller to add in the database ODCamera
            this.Close();
        }

    }
}
