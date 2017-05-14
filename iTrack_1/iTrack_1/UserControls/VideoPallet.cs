using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTrack_1.View;

namespace iTrack_1.UserControls
{
    public partial class VideoPallet : UserControl
    {

        private ViewRecordedVideos parent;
        public string fileName;

        public VideoPallet(string file, ViewRecordedVideos p)
        {
            InitializeComponent();
            fileName = file;
            string[] splt = file.Split('\\');
            lblFile.Text = splt[1];
            parent = p;
        }

        private void VideoPallet_Load(object sender, EventArgs e)
        {

        }

        private void VideoPallet_MouseClick(object sender, MouseEventArgs e)
        {
            playVideo();
        }

        private void lblFile_Click(object sender, EventArgs e)
        {
            playVideo();
        }

        private void playVideo()
        {
            parent.playVideo(fileName);
        }

        private void stopVideo()
        {
            parent.stopVideo();
        }
        private void btnTrack_Click(object sender, EventArgs e)
        {
            stopVideo();
            Tracking track = new Tracking(fileName);
            
            track.ShowDialog();
        }

        private void playbtn_Click(object sender, EventArgs e)
        {
            playVideo();
        }
    }
}
