using iTrack_1.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTrack_1.View
{
    public partial class ViewRecordedVideos : Form
    {
        public ViewRecordedVideos()
        {
            InitializeComponent();

            string[] fileEntries = Directory.GetFiles("Recording");
            
            foreach (string fileName in fileEntries)
            {
                flpVideos.Controls.Add(new VideoPallet(fileName, this));
            }
            

        }

        public void playVideo(string file)
        {
            wmp.URL = file;
        }

        public void stopVideo()
        {
            wmp.Ctlcontrols.pause();
        }

        private void ViewRecordedVideos_Load(object sender, EventArgs e)
        {

        }

        private void flpVideos_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Videolistlbl_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
