using iTrack;
using iTrack_1;
using iTrack_1.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTrack_1
{
    public partial class frontend : Form
    {
        private Form1 newMDIChildHome;
        private Map newMDIChildMap;
        private Registration newMDIChildReg;
        private Tracking newMDIChildTrack;
        private Tracking newMDIChildTrack1;
        private ViewRecordedVideos newMDIRecorded;
        private Indentification newMDIiden; 
        public frontend()
        {
            InitializeComponent();
            SplashScreen(); 
            startup();
            timer1.Start();
           // MapBtn();
           
        }
        void SplashScreen()
        {
            try
            {
                Thread t = new Thread(new ThreadStart(Splash));
                t.Start();
                string str = string.Empty;
                for (int i = 0; i <= 50000; i++)
                {
                    str += i.ToString();
                }
                //complete
                t.Abort();
            }
            catch(Exception ex)
            { }
        }
        void Splash()
        {
            try
            {
                SplashScreen.SplashForm frm = new SplashScreen.SplashForm();
                frm.AppName = "iTrack";
                
                frm.BackColor = Color.FromArgb(65, 65, 65);
                //frm.BackgroundImage = Properties.Resources.eye_tracking;
                frm.Icon = Properties.Resources.eye_tracking;
                frm.ShowIcon = true;
                frm.ShowInTaskbar = true;
                Application.Run(frm);
            }
            catch (Exception ex)
            {

            }
        }
        private void startup()
        {
            panel1.BringToFront();
            //startupPnl.SendToBack();  
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            int w = Width >= screen.Width ? screen.Width : (screen.Width + Width) / 2;
            int h = Height >= screen.Height ? screen.Height : (screen.Height + Height) / 2;
            this.Location = new Point((screen.Width - w) / 2, (screen.Height - h) / 2);
            this.Size = new Size(screen.Width, screen.Height);
            this.IsMdiContainer = true;
            //
            itracklbl.Font = new Font("Anton", 142, FontStyle.Bold);
            Sipslbl.Font = new Font("Montserrat", 16, FontStyle.Bold);
            //
            //welcomePnl.Location= new Point(welcomePnl.Location.X,welcomePnl.Location.Y+50 );
            //welcomePnl.Width = startupPnl.Width - 30;
            //Topnl.Location = new Point(Topnl.Location.X,welcomePnl.Location.Y + 50);
            //Topnl.Width = startupPnl.Width - 80;
            //startmsgpnl.Location= new Point(startmsgpnl.Location.X,welcomePnl.Location.Y+100 );
            //startmsgpnl.Width = startupPnl.Width-80 ;
            ////
            //
            //welcomelbl.Location = new Point(welcomePnl.Width-150,welcomelbl.Location.Y);
            //tolbl.Location = new Point(Topnl.Width - 100, tolbl.Location.Y);
            //startuplbl.Location = new Point(startupPnl.Location.X , startuplbl.Location.Y);
            //welcomelbl.Font = new Font("League Spartan", 16, FontStyle.Bold);
            //tolbl.Font = new Font("League Spartan", 16, FontStyle.Bold);
            //startuplbl.Font = new Font("League Spartan", 16, FontStyle.Bold);
            ////
            /*Making MdiContainers*/
 
             //newMDIChildHome = new Form1();
             //newMDIChildMap = new Map();
             //newMDIChildReg = new Registration();
            //newMDIChildTrack = new Tracking();
            //

            /* Start Side panal setting */
             pnlRight.Width = 47;
             Image img = pictureBox3.Image;
             img.RotateFlip(RotateFlipType.Rotate180FlipY);
             pictureBox3.Image = img;
            //

            /* Start left menu panel */
             //homebtn.ImageAlign = ContentAlignment.MiddleRight;
             //mapbtn.ImageAlign = ContentAlignment.MiddleRight;
             //trackbtn.ImageAlign = ContentAlignment.MiddleRight;
             //regbtn.ImageAlign = ContentAlignment.MiddleRight;
             //recbtn.ImageAlign = ContentAlignment.MiddleRight;
             // identificationbtn.ImageAlign = ContentAlignment.MiddleRight;
             panel1.Width = 42;
            //

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to close?", "Close Window", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do nothing
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void homebtn_Click(object sender, EventArgs e)
        {


            homeBtn();
            
        }
        private void homeBtn()
        {
            
            startupPnl.Visible = false;
            disposing();
            newMDIChildHome = new Form1(  );
            // Set the Parent Form of the Child window.
            newMDIChildHome.MdiParent = this;
            newMDIChildHome.Dock = DockStyle.Fill;
            // Display the new form.
            //this.mriContainer.Controls.Add(newMDIChild);
            newMDIChildHome.Show();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (panel1.Width >= 300)
                {
                    //
                    while (!(panel1.Width <= 52))
                    {
                        panel1.Width = panel1.Width - 10;
                        Refresh();
                    }
                    //
              //      panel1.Dock = DockStyle.Left;
                    panel1.BringToFront();
                    //homebtn.ImageAlign = ContentAlignment.MiddleRight;
                    //mapbtn.ImageAlign = ContentAlignment.MiddleRight;
                    //trackbtn.ImageAlign = ContentAlignment.MiddleRight;
                    //regbtn.ImageAlign = ContentAlignment.MiddleRight;

                    //recbtn.ImageAlign = ContentAlignment.MiddleRight;
                    //identificationbtn.ImageAlign = ContentAlignment.MiddleRight;
                    panel1.Width = 42;
                    label3.Visible = false;
                }
                else if (panel1.Width <= 42)
                {
                //    panel1.Dock = DockStyle.None;
                    while (!(panel1.Width >= 300))
                    {
                        panel1.Width = panel1.Width + 10;
                        Refresh();
                    }
                    panel1.BringToFront();
                    //homebtn.ImageAlign = ContentAlignment.MiddleLeft;
                    //mapbtn.ImageAlign = ContentAlignment.MiddleLeft;
                    //trackbtn.ImageAlign = ContentAlignment.MiddleLeft;
                    //regbtn.ImageAlign = ContentAlignment.MiddleLeft;
                    //recbtn.ImageAlign = ContentAlignment.MiddleLeft;

                    //identificationbtn.ImageAlign = ContentAlignment.MiddleLeft;
                    //// 
                    panel1.Width = 300;
                    label3.Visible = true;
                }
            }
            catch { }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (pnlRight.Width>=228)
            {
                while (!(pnlRight.Width <=47))
                {
                    pnlRight.Width = pnlRight.Width - 10;
                    Refresh();
                }
                pnlRight.Width = 47;
                Image img = pictureBox3.Image;
                img.RotateFlip(RotateFlipType.Rotate180FlipY);
                pictureBox3.Image=img;

            }
            else if (pnlRight.Width <= 47)
            {
                while (!(pnlRight.Width >= 228))
                {
                    pnlRight.Width = pnlRight.Width + 10;
                    Refresh();
                }
                pnlRight.Width = 228;
                Image img = pictureBox3.Image;
                img.RotateFlip(RotateFlipType.Rotate180FlipY);
                pictureBox3.Image = img;
            }
        }

        private void mapbtn_Click(object sender, EventArgs e)
        {
            startupPnl.Visible = false;
            disposing();
            MapBtn();
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
       
        }
        private void MapBtn()
        {
            
            newMDIChildMap = new Map();
            
            // Set the Parent Form of the Child window.
            newMDIChildMap.MdiParent = this;
            newMDIChildMap.Dock = DockStyle.Fill;
            // Display the new form.
            //this.mriContainer.Controls.Add(newMDIChild);
            newMDIChildMap.Show();
        }
  

        private void regbtn_Click(object sender, EventArgs e)
        {
            startupPnl.Visible = false;
            disposing();
            newMDIChildReg = new Registration();
            // Set the Parent Form of the Child window.
            newMDIChildReg.MdiParent = this;
            newMDIChildReg.Dock = DockStyle.Fill;
            // Display the new form.
            //this.mriContainer.Controls.Add(newMDIChild);
            newMDIChildReg.Show();
        }
        private void disposing()
        {
            if (newMDIChildHome != null)
                newMDIChildHome.Dispose();
            else if (newMDIChildMap != null)
                newMDIChildMap.Dispose();
            else if (newMDIChildReg != null)
                newMDIChildReg.Dispose();
            else if (newMDIChildTrack != null)
                newMDIChildTrack.Dispose();

            else if (newMDIRecorded != null)
                newMDIRecorded.Dispose();
            else if (newMDIiden != null)
                newMDIiden.Dispose();
            
        }

        private void trackbtn_Click(object sender, EventArgs e)
        {
            startupPnl.Visible = false;

           // disposing();
           string  fileName = @"E:\8th Semester\FYP-2\iTrack_01\iTrack_1\iTrack_1\bin\Debug\TV_6.mp4";
           string fileName1 = @"E:\8th Semester\FYP-2\iTrack_01\iTrack_1\iTrack_1\bin\Debug\TV_8.mp4";
        
            //Tracking track = new Tracking(fileName);
           newMDIChildTrack = new Tracking(fileName);
            // Set the Parent Form of the Child window.
            newMDIChildTrack.MdiParent = this;
            newMDIChildTrack.Dock = DockStyle.Fill;
            newMDIChildTrack.Show();
            // Display the new form.
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);

            newMDIChildTrack1 = new Tracking(fileName1);

            newMDIChildTrack1.MdiParent = this;
            // newMDIChildTrack1.Dock = DockStyle.Fill;

            //this.mriContainer.Controls.Add(newMDIChild);
            newMDIChildTrack1.Show();

            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
       
        }

        private void frontend_Load(object sender, EventArgs e)
        {

        }

        private void pnlRight_DoubleClick(object sender, EventArgs e)
        {
            if (pnlRight.Width >= 228)
            {
                while (!(pnlRight.Width <= 47))
                {
                    pnlRight.Width = pnlRight.Width - 10;
                    Refresh();
                }
                pnlRight.Width = 47;
                Image img = pictureBox3.Image;
                img.RotateFlip(RotateFlipType.Rotate180FlipY);
                pictureBox3.Image = img;

            }
            else if (pnlRight.Width <= 47)
            {
                while (!(pnlRight.Width >= 228))
                {
                    pnlRight.Width = pnlRight.Width + 10;
                    Refresh();
                }
                pnlRight.Width = 228;
                Image img = pictureBox3.Image;
                img.RotateFlip(RotateFlipType.Rotate180FlipY);
                pictureBox3.Image = img;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void startuplbl_Click(object sender, EventArgs e)
        {

        }

        private void welcomePnl_MouseEnter(object sender, EventArgs e)
        {
            ExpandPanel(ref sender);
        }

        private void welcomePnl_MouseLeave(object sender, EventArgs e)
        {
            ContractPanel(ref sender);
        }

        private void Topnl_MouseEnter(object sender, EventArgs e)
        {
            ExpandPanel(ref sender);
        }

        private void Topnl_MouseLeave(object sender, EventArgs e)
        {
            ContractPanel(ref sender);
        }

        private void ExpandPanel(ref object sender)
        {
            Panel p;
            if(sender is Label)
            {
                p= ((sender as Label).Parent as Panel);
            }
            else
            {
                p = sender as Panel;
            }

            p.Size = new Size(p.Width, p.Height + 20);
            p.Location = new Point(p.Location.X, p.Location.Y - 10);
            //if (p.Name == "welcomePnl")
            //{
            //    welcomelbl.Font = new Font("League Spartan", 22, FontStyle.Bold);
            //    welcomelbl.Location = new Point(welcomelbl.Location.X-50,welcomelbl.Location.Y-5);
            //}
            //else if (p.Name=="Topnl")
            //{
            //     tolbl.Font = new Font("League Spartan", 22, FontStyle.Bold);
            //    tolbl.Location = new Point(tolbl.Location.X - 50, tolbl.Location.Y - 5);
           
            //}
            //else if (p.Name == "startmsgpnl")
            //{
            //    startuplbl.Font = new Font("League Spartan", 22, FontStyle.Bold);
            //    startuplbl.Location = new Point(startuplbl.Location.X, startuplbl.Location.Y+5 );

            //}

        }
        private void ContractPanel (ref object sender)
        {
            Panel p;
            if (sender is Label)
            {
                p = ((sender as Label).Parent as Panel);
            }
            else
            {
                p = sender as Panel;
            }

            p.Size = new Size(p.Width, p.Height - 20);
            p.Location = new Point(p.Location.X, p.Location.Y + 10);
            //if (p.Name == "welcomePnl")
            //{
            //    welcomelbl.Font = new Font("League Spartan", 16, FontStyle.Bold);
            //    welcomelbl.Location = new Point(welcomelbl.Location.X + 50, welcomelbl.Location.Y+5);
            //}
            //else if (p.Name == "Topnl")
            //{
            //    tolbl.Font = new Font("League Spartan", 16, FontStyle.Bold);
            //    tolbl.Location = new Point(tolbl.Location.X + 50, tolbl.Location.Y + 5);

            //}
            //else if (p.Name == "startmsgpnl")
            //{
            //    startuplbl.Font = new Font("League Spartan", 16, FontStyle.Bold);
            //    startuplbl.Location = new Point(startuplbl.Location.X , startuplbl.Location.Y-5);

            //}
        }

        private void startmsgpnl_MouseEnter(object sender, EventArgs e)
        {
            ExpandPanel(ref sender);
            
        }

        private void startmsgpnl_MouseLeave(object sender, EventArgs e)
        {
            ContractPanel(ref sender);
        }

        private void welcomelbl_MouseEnter(object sender, EventArgs e)
        {
           // ExpandPanel(ref sender);
        }

        private void welcomelbl_MouseLeave(object sender, EventArgs e)
        {
          //  ContractPanel(ref sender);
        }

        private void tolbl_MouseEnter(object sender, EventArgs e)
        {
           // ExpandPanel(ref sender);
        }

        private void tolbl_MouseLeave(object sender, EventArgs e)
        {
           // ContractPanel(ref sender);
        }

        private void startuplbl_MouseEnter(object sender, EventArgs e)
        {
          //  ExpandPanel(ref sender);
        }

        private void startuplbl_MouseLeave(object sender, EventArgs e)
        {
         //   ContractPanel(ref sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            startupPnl.Visible = false;
            
            newMDIChildHome = new Form1();
            // Set the Parent Form of the Child window.
            newMDIChildHome.MdiParent = this;
            newMDIChildHome.Dock = DockStyle.Fill;
            // Display the new form.
            //this.mriContainer.Controls.Add(newMDIChild);
            newMDIChildHome.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            startupPnl.Visible = false;
            
            newMDIChildMap = new Map();
        
            // Set the Parent Form of the Child window.
            newMDIChildMap.MdiParent = this;
            newMDIChildMap.Dock = DockStyle.Fill;
            // Display the new form.
            //this.mriContainer.Controls.Add(newMDIChild);
            newMDIChildMap.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            startupPnl.Visible = false;
            disposing();
            newMDIRecorded = new ViewRecordedVideos();

            // Set the Parent Form of the Child window.
            newMDIRecorded.MdiParent = this;
            newMDIRecorded.Dock = DockStyle.Fill;
            // Display the new form.
            //this.mriContainer.Controls.Add(newMDIChild);
            newMDIRecorded.Show();
        }

        private void identificationbtn_Click(object sender, EventArgs e)
        {
            startupPnl.Visible = false;
            disposing();
            newMDIiden = new Indentification();
            // Set the Parent Form of the Child window.
            newMDIiden.MdiParent = this;
            newMDIiden.Dock = DockStyle.Fill;
            // Display the new form.
            //this.mriContainer.Controls.Add(newMDIChild);
            newMDIiden.Show();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void copyrightlbl_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlRight_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupVList_Enter(object sender, EventArgs e)
        {

        }

        private void pnlTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void startupPnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void identificationbtn_MouseMove(object sender, MouseEventArgs e)
        {
            //splitpnl.Visible = true;
           
            //    while (!(splitpnl.Width >= 295))
            //    {
            //        splitpnl.Width = splitpnl.Width + 9;
            //        Refresh();
            //    }
            //    splitpnl.Width = 295;
            //identificationbtn.ForeColor = SystemColors.MenuHighlight;
         //   identificationbtn.ForeColor = Color.FromArgb(5, 89, 144);
           
        }

        private void identificationbtn_MouseLeave(object sender, EventArgs e)
        {
        //    while (!(splitpnl.Width <= 97))
        //    {
        //        splitpnl.Width = splitpnl.Width - 17;
        //        Refresh();
        //    }
        //    splitpnl.Width = 97;
        //    splitpnl.Visible = false;
       //     identificationbtn.ForeColor = SystemColors.ControlLightLight;
        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            float fcpu = pCpu.NextValue();
            float fcpu1 = pCpu1.NextValue();
            float fcpu2 = pCpu2.NextValue();
            float fcpu3 = pCpu3.NextValue();
            float fram = pRam.NextValue();

            circularProgressBarProcessor.Value = (int)fcpu;
            circularProgressBarProcessor.Text =Convert.ToString((int)fcpu)+"%";
            
            circularProgressBar1.Value = (int)fcpu1;
            circularProgressBar1.Text = Convert.ToString((int)fcpu1) + "%";

            circularProgressBar2.Value = (int)fcpu2;
            circularProgressBar2.Text = Convert.ToString((int)fcpu2) + "%";

            circularProgressBar3.Value = (int)fcpu3;
            circularProgressBar3.Text = Convert.ToString((int)fcpu3) + "%";

            circularProgressBarRam.Value = (int)fram;
            circularProgressBarRam.Text = Convert.ToString((int)fram)+"%";
        }

        private void circularProgressBarProcessor_Click(object sender, EventArgs e)
        {

        }
    }
}
