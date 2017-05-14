using iTrack.Controller;
using iTrack.UserControls;
using iTrack_1;
using iTrack_1.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTrack_1
{
    public partial class Map : Form
    {
        private string Chosen_File;
        private int count;
        private Point cameraplacept;
        private Point selectedcamerapt;
        private imageManupilation im;
        private List<PictureBox> pblist;
        private Image CameraImage;
        private List<Point> pointList;
        private List<Point> previousPtList;
        private List<float> rotateCamera;
        private bool mulchk;
        private float angle;
        private object selectedCameraPicturebox;
        private List<Label> labellist;
        private Rectangle circle;
        private Graph g1;
        private List<bool> checkedCamera;
        private FlowLayoutPanel flp;
        private List<int> odlist;
        private List<int> odchklst;
        CameraManager controller;
        private OdNeighbour odn;
        public Map()
        {
            InitializeComponent();
            im = new imageManupilation();
            cameraplacept = new Point();
            pblist =new List<PictureBox>();
            pointList = new List<Point>();
            previousPtList = new List<Point>();
            rotateCamera = new List<float>();
            selectedCameraPicturebox = new object();
            labellist = new List<Label>();
            odlist = new List<int>();
            odchklst = new List<int>();
            g1 = new Graph();
            checkedCamera = new List<bool>();
            loadPrevious();
        }

        private void loadPrevious()
        {

            CameraManager cm = CameraManager.Instance;
           previousPtList=cm.getpts();
             List<int> rotationTemp=new List<int>();
            rotationTemp=cm.getRotation();
            if (previousPtList.Count!=0)
            {
                //Getting file name function to which points have to be applied 
                //
                //For now direct picture address
                Chosen_File = @"E:\8th Semester\FYP-2\copy.jpg";
                displayMap();
                //
                //Adding pts to map 
                int i = 0;
                foreach (Point pt in previousPtList)
                {
                    addcamera1(pt);
                    angle = rotationTemp[i];
                    
                    //
                    selectedCameraPicturebox = pblist[i];
                    PictureBox oPictureBox = (PictureBox)selectedCameraPicturebox;

                    //load both images
                    Image rtimg = RotateImage(camera1.Image, angle);
                    oPictureBox.Image = rtimg;
                    
                    rotate(pt);
                    //
                    i++;
                }
              
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            openFileDialog1.Title = "Insert an Image";
            openFileDialog1.FileName = "";
            Chosen_File = "";

            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                Chosen_File = openFileDialog1.FileName;
                displayMap();      
            }
        }
        private void displayMap()
        {
            count = 0;
            pictureBox1.Dock = DockStyle.Fill;
            Image img = im.ScaleImage(new Bitmap(Chosen_File), pictureBox1.Size.Width, pictureBox1.Size.Height);
            pictureBox1.BackgroundImage = new Bitmap(img);
            pictureBox1.Dock = DockStyle.None;

            

            pictureBox1.Width = img.Width;
            pictureBox1.Height = img.Height;
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            var mouseEventArgs = e as MouseEventArgs;
           
            if (mouseEventArgs != null)
            {
                
                Point pt = new Point(mouseEventArgs.X, mouseEventArgs.Y);
                cameraplacept = pt;
                if (e.Button == MouseButtons.Right)
                {
                    optionpanal.Visible = true;

                    optionpanal.Location = pt;
                }
                else if (e.Button==MouseButtons.Left)
                {
                    if(optionpanal.Visible==true || pboptionpanel.Visible==true)
                    { optionpanal.Visible = false; pboptionpanel.Visible = false; }
                    if (mulchk == true && pictureBox1.BackgroundImage != null)
                    {        
                        addcamera1(cameraplacept);
                    }
                }
            }
        }
        
        public void addcamera1(Point pt)//,List<PictureBox> pblist)
        {
            //pictureBox2.Visible = true;
            //pictureBox2.Size = camera1.Size;
            //pictureBox2.Image = camera1.Image;
            //pictureBox2.Location = pt;
            try
            {
                //adding picturebox
                PictureBox pb = new PictureBox();
                pb.Image = camera1.Image;
                pb.Location = pt;
                pb.Size = camera1.Size;
                pb.BringToFront();
                pb.Visible = true;
                pictureBox1.Controls.Add(pb);
                pb.BackColor = Color.Transparent;
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                
                pb.Click += this.PictureClick;
                pblist.Add(pb);
                rotateCamera.Add(0);
                pointList.Add(pt);
              
                //adding label 
                Label lb = new Label();
                lb.Text = "Camera"+(pblist.Count);
                Point lbpt = new Point();
                if (pt.X >= pictureBox1.Width - 125)
                {
                    lbpt.X = pt.X-55 ;
                    lbpt.Y = pt.Y+5;
                    lb.Location = lbpt;

                    //g.DrawString("Camera" + count1, new Font("Arial", 10), Brushes.Black, pt.X - 55, pt.Y);
                }
                //Font Font = new Font("Arial", 6);
                else
                {

                    lbpt.X = pt.X+25;
                    lbpt.Y = pt.Y+5;
                    lb.Location = lbpt;
                   // g.DrawString("Camera" + count1, new Font("Arial", 10), Brushes.Black, pt.X + 20, pt.Y);

                }
                lb.BackColor = System.Drawing.Color.Transparent;
                lb.Width = 70;
                lb.BringToFront();
                labellist.Add(lb);
                pictureBox1.Controls.Add(lb);

                //adding in cameralst
                count++;

                cameralst.Items.Add("Camera" + count);
                //adding in the nieghbour list cameralist
                cameralist.Items.Add("Camera" + count);

                //giving chk to camera 
                bool chk = false;
                checkedCamera.Add(chk);
            }
            catch { }


        }
        private void PictureClick(object sender, EventArgs e)
        {
            try
            {
                PictureBox oPictureBox = (PictureBox)sender;
                pboptionpanel.Visible = true;
                pboptionpanel.Location = oPictureBox.Location;
                //camera point which is selected;
                selectedcamerapt = new Point();
                selectedcamerapt.X = oPictureBox.Location.X;
                selectedcamerapt.Y = oPictureBox.Location.Y;
                //

                selectedCameraPicturebox = sender;
                
                //
            }
            catch { }
            
        }
      
        private void addcamerabtn_Click(object sender, EventArgs e)
        {
            if (pictureBox1.BackgroundImage != null)
            {
                addcamera1(cameraplacept);
                
                //picturebox size and first load the picture
            }
            optionpanal.Visible = false;

        }

        private void mulcamerabtn_Click(object sender, EventArgs e)
        {
           
        }

        private void optionpanal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mulcamerabtn_Click_1(object sender, EventArgs e)
        {
            if (mulchk == false && pictureBox1.BackgroundImage != null)
            {
                mulchk = true;
                pictureBox1.Cursor = Cursors.Cross;
                
                mulcamerabtn.Image = Image.FromFile("Resources\\checked.png");
                // Align the image and text on the button.
                button1.ImageAlign = ContentAlignment.MiddleLeft;
                button1.TextAlign = ContentAlignment.MiddleRight;
            }
            else if (mulchk == true)
            {
                mulchk = false;
                pictureBox1.Cursor = Cursors.Arrow;
                mulcamerabtn.Image = Image.FromFile("Resources\\multiple-shots.png");
                // Align the image and text on the button.
                button1.ImageAlign = ContentAlignment.MiddleLeft;
                button1.TextAlign = ContentAlignment.MiddleRight;
            }
           
            optionpanal.Visible = false;
        }

        private void RemoveCamerabtn_Click(object sender, EventArgs e)
        {
            //close optionbox
            int selpt;
            try 
            { 
                if (selectedcamerapt!=null)
                {

                    if (points.Contains(selectedcamerapt))
                    {
                        //
                        DialogResult dialogResult = MessageBox.Show("You can not change the dependent camera","Warning Box",MessageBoxButtons.OK , MessageBoxIcon.Warning);
                  
                        //
                    }
                    else
                    {
                        //removing pictureBox
                        PictureBox oPictureBox = (PictureBox)selectedCameraPicturebox;

                        selpt = pointList.IndexOf(selectedcamerapt);
                        pblist.RemoveAt(selpt);
                        pointList.RemoveAt(selpt);

                        oPictureBox.Dispose();
                        //removing label
                        Label lb1 = new Label();
                        lb1 = labellist[selpt];
                        lb1.Dispose();
                        labellist.RemoveAt(selpt);
                        lblrefresh();
                        //removing from camera lists both combo box and list view
                        cameralst.Items.RemoveAt(cameralst.Items.Count - 1);
                        cameralst.Refresh();
                        cameralist.Items.RemoveAt(cameralist.Items.Count - 1);
                        cameralist.Refresh();
                        //removing from chk list 
                        checkedCamera.RemoveAt(selpt);
                        //setting all the other variables
                        pboptionpanel.Visible = false;
                        selectedCameraPicturebox = null;
                        count--;
                        this.Refresh();
                    }
                }
            
            }
            catch { }
        }
  
        private void lblrefresh()
        {
            int i = 1;
            foreach (Label lb in labellist)
            {
                lb.Text = "Camera" + i;
                i++;
            }
        }
        private void rotatebtn_Click(object sender, EventArgs e)
        {
            trackBar1.Visible = true;
            donebtn.Visible = true;
            pboptionpanel.Visible = false;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {

            try
            {
                PictureBox oPictureBox = (PictureBox)selectedCameraPicturebox;

                //load both images
                Image rtimg = RotateImage(camera1.Image, trackBar1.Value);
                oPictureBox.Image = rtimg;
                angle = trackBar1.Value;

            }
            catch { }
        }
        //
        public static Image RotateImage(Image img, double rotationAngle)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform((float)rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            return bmp;
        }

        private void donebtn_Click(object sender, EventArgs e)
        {
            rotate(selectedcamerapt);
        }
        
        private void rotate (Point pt)
        {
            int index = pointList.IndexOf(pt);
            rotateCamera[index] = angle;
            angle = 0;
            selectedCameraPicturebox = null;
            trackBar1.Visible = false;
            donebtn.Visible = false;
        }
        //paint camera on picture 
        public void paintcamera(Point pt,Image p,int count1)
        {

            Image mainImage = (Bitmap)pictureBox1.BackgroundImage;
            Image imposeImage = (Bitmap)p;


            using (Graphics g = Graphics.FromImage(mainImage))
            {

                g.DrawImage(imposeImage, pt.X, pt.Y, 20, 23);
                string path = System.IO.Directory.GetCurrentDirectory();
                //count++;
                //  double hei=pictureBox1.Height;
                if (pt.X >= pictureBox1.Width - 125)
                {
                    g.DrawString("Camera" + count1, new Font("Arial", 10), Brushes.Black, pt.X - 55, pt.Y);
                }
                //Font Font = new Font("Arial", 6);
                else
                    g.DrawString("Camera" + count1, new Font("Arial", 10), Brushes.Black, pt.X + 20, pt.Y);

                mainImage.Save(path + "\\final.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                //cameralist.Items.Add("Camera" + count);

            }
        }

        private void nxtbtn_Click(object sender, EventArgs e)
        {
            //foreach (PictureBox p in pblist)
            //{
                
            //    paintcamera(p.Location, p.Image, pblist.IndexOf(p)+1);
            //}
            //string path = System.IO.Directory.GetCurrentDirectory() + "\\final.jpg";
            //Image img = new Bitmap(path);
            //pictureBox1.Image = img;
            //
            CameraManager cm= CameraManager.Instance;
            MessageBox.Show("Number of cameras : " + g1.numberofcameras());

            
            for (int i = 0; i < g1.numberofcameras(); i++)
            {
                //var message = string.Join(Environment.NewLine, g1.getneighbour(i));
                //MessageBox.Show(message);

                cm.AddCamera(g1.getName(i), g1.getip(i), g1.getRotation(i),g1.getUserName(i),g1.getPwd(i),g1.getReg(i),g1.getIden(i),g1.getTrack(i),pointList[i],g1.getOD(i));
                cm.addNeighbours(g1.getName(i), g1.getneighbour(i),g1.getodNeighbour(i));

            }

            //
        }

        private void regpnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cameralst_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sel=cameralst.SelectedIndex;
            makecircle(pointList,sel);
        }
        public void makecircle(List<Point> pt, int turn1)
        {
           // Graphics g = pictureBox1.CreateGraphics();
          
            try
            {
                circle = new Rectangle(pt[turn1].X - 10, pt[turn1].Y - 10, 50, 50);
                this.Refresh();
                //g.DrawEllipse(new Pen(Brushes.Yellow), circle);
               // turn++;
                //cameraNamelbl.Text = "Camera" + turn;
            }
            catch { }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen dashed_pen = new Pen(Color.Red, 2);
            e.Graphics.DrawEllipse(new Pen(Brushes.Yellow), circle);
            for (int i = 0; i < points.Count; i += 2)
                e.Graphics.DrawLine(graphPen, points[i], points[i + 1]);
            //
            for (int i = 0; i < odpoints.Count; i += 2)
            {
                dashed_pen.DashStyle = DashStyle.Dash;
               
                e.Graphics.DrawLine(dashed_pen, odpoints[i], odpoints[i+1]);
                
            }
            //
           
        }
        public void addnode(int turn)
        {
            try
            {
                List<string> strlst = new List<string>();
                foreach (int indexChecked in cameralist.CheckedIndices)
                {
                    strlst.Add("Camera" + (indexChecked + 1));
                }
                string IP =iptxt.Text.ToString();
                string userName = usertxt.Text.ToString();
                string Pwd = pwdtxt.Text.ToString();
                string odneighbour= "";
                double rotation = rotateCamera[turn];
                int a, b, c, d;
                a = 0;
                b = 0;
                c = 0;
                d = 0;
                if (Regchk.Checked)
                    a = 1;
                if (identificationchk.Checked)
                    b = 1;
                if (trackchk.Checked)
                    c = 1;
                foreach  (int od in odlist)
                {
                    if (cameralst.SelectedIndex==od)
                    {
                        d=1;
                    }
                }
                if (odcameralst.SelectedItem == null)
                {
                    odneighbour="";
                }
                else{
                    odneighbour=odcameralst.SelectedItem.ToString();
                }
                
                 
                g1.add("Camera" + (turn+1), IP, rotation, strlst,userName,Pwd,a,b,c,d,odneighbour);
                

            }
            catch { }

        }
        //
        public void updatenode(int turn)
        {
            try
            {
                List<string> strlst = new List<string>();
                foreach (int indexChecked in cameralist.CheckedIndices)
                {
                    strlst.Add("Camera" + (indexChecked + 1));
                }
                string IP = iptxt.Text.ToString();
                double rotation = rotateCamera[turn];
                string userName = usertxt.Text.ToString();
                string Pwd = pwdtxt.Text.ToString();
                g1.update( IP, rotation, strlst,turn,userName,Pwd);
                removePts(turn);
              
            }
            catch { }

        }
        private void prodonebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (iptxt.Text.ToString() == "" || usertxt.Text.ToString() == "" || pwdtxt.Text.ToString() == "")
                {
                    DialogResult dialogResult = MessageBox.Show("Information is missing!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {

                    if (checkedCamera[cameralst.SelectedIndex] == false)
                    {
                        if(odcameralst.SelectedItem!=null)
                        {
                            //Get frames from 2 cameras 
                            //CameraManager.Instance.GetFrame(odcameralst.SelectedItem.ToString());
                            //odn = new OdNeighbour(odcameralst.SelectedItem.ToString());

                            //odn.Show();
                            //odn = new OdNeighbour(cameralst.SelectedIndex.ToString());
                            //odn.Show();
                        }
                        addnode(cameralst.SelectedIndex);

                        showneighbour(cameralst.SelectedIndex);
                        clearneighbour();
                        // MessageBox.Show("Number of cameras : " + g1.numberofcameras());
                        checkedCamera[cameralst.SelectedIndex] = true;


                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Are you sure you want to make changes?", "Warning Box", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            //do something

                            updatenode(cameralst.SelectedIndex);

                            showneighbour(cameralst.SelectedIndex);

                            clearneighbour();

                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            //do something else

                        }
                    }
                    //clear cameralist
                }
            }
            catch { }
            this.Refresh();
        }

        private void clearneighbour()
        {
            foreach (int i in cameralist.CheckedIndices)
            {
                cameralist.SetItemCheckState(i, CheckState.Unchecked);
            }
            //unchecking others
            Regchk.CheckState=CheckState.Unchecked;
            identificationchk.CheckState = CheckState.Unchecked;
            trackchk.CheckState = CheckState.Unchecked;
         
            //  adchk1.CheckState = CheckState.Unchecked;
            //Default value for od camera combo box
            odcameralst.ResetText();

            //to reset selected value
            odcameralst.SelectedIndex = -1;
            
        }
        //
        List<PointF> points = new List<PointF>();
        List<PointF> odpoints = new List<PointF>();
        Pen graphPen = new Pen(Color.Red, 2);
        //
        public void showneighbour(int turn1)
        {

            Graphics g = pictureBox1.CreateGraphics();
            string odneighbour="";
            if(odcameralst.SelectedItem!=null)
            {
                odneighbour = odcameralst.SelectedItem.ToString();
            }
            foreach (int indexChecked in cameralist.CheckedIndices)
            {
                PointF pt1D = new PointF();
                PointF pt2D = new PointF();

                
                
                pt1D.X = pointList[turn1].X;
                pt1D.Y = pointList[turn1].Y;
                pt2D.X = pointList[indexChecked].X;
                pt2D.Y = pointList[indexChecked].Y;

             //   g.DrawLine(graphPen, pt1D, pt2D);
                if ("Camera" + (indexChecked + 1) == odneighbour)
                {
                    odpoints.Add(pt1D);
                    odpoints.Add(pt2D);
                }
                else
                {
                    points.Add(pt1D);
                    points.Add(pt2D);
                }
                

            }
        }
        public void removePts(int turn)
        {
            Point pt = new Point();
            List<int> lst = new List<int>();
            pt = pointList[turn];
            for (int i=0;i<points.Count;i++)
            {
                if(i%2==0 && points[i]==pt)
                {
                    lst.Add(i);
                }
            }
            for (int i=0;i<lst.Count;i++)
            {
                points.RemoveAt(lst[i]);
                //after deleting the next point comes to the same place
                points.RemoveAt(lst[i]);

            }
        }
        public void addcameraInfo(string name,string ip,Point pt,float rotation)
        {
            CameraInfo info = new CameraInfo();
            info.Name = name;
            info.IP = ip;
            info.Coordinates=pt;
           // info.Rotation=rotation;
           

            //controller.AddCameraDB(info);
            //Camera cam = new Camera(info);

            //if (cam.CamRunning)
            //{
            //    flp.Controls.Add(cam);
            //    controller.AddCamera(cam);

            //    this.Dispose();
            //}
        }

        private void streambtn_Click(object sender, EventArgs e)
        {
            CameraManager cm = CameraManager.Instance;
            int index = pointList.IndexOf(selectedcamerapt);
            cm.StopCam("Camera" + (index+1));
            pboptionpanel.Visible = false;
                      

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int sel_pt;
            //getting camera name
            sel_pt = pointList.IndexOf(selectedcamerapt);
            if (!odchklst.Contains(sel_pt))
            {
                //setting image
              //  ODbtn.Image = Properties.Resources._checked;
                //setting OD property of that camera
                if (g1.nodes.Count >= sel_pt + 1)
                {

                    g1.setOD(sel_pt, true);
                    odchklst.Add(sel_pt);

                }

                else
                {
                    odlist.Add(sel_pt);
                    odchklst.Add(sel_pt);
                }
                //adding in the odcameralst
                odcameralst.Items.Add("Camera" + (sel_pt + 1));
                //chk list update
            }
            else
            {
            //    ODbtn.Image = Properties.Resources.camera_remove_button;
              //  ODbtn.Text = "Remove as OD Camera";
                MessageBox.Show("Already an OD camera.");
                DialogResult dialogResult = MessageBox.Show("Already an OD camera.", "Information Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  
            }
            //
            pboptionpanel.Visible = false;
                      

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
       
    
    }
}
