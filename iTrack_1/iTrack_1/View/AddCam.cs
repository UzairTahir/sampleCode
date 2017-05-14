using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTrack.UserControls;

using iTrack.Controller;
using iTrack_1.Model;

namespace iTrack.View
{
    public partial class AddCam : Form
    {
        private FlowLayoutPanel flp;
        private SQLManager sql;
        CameraManager controller;

        public AddCam(FlowLayoutPanel temp)
        {
            InitializeComponent();

            sql = new SQLManager();
            controller =CameraManager.Instance;
            flp = temp;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CameraInfo info = new CameraInfo();
            info.Name = txtCamName.Text;
            info.IP = txtCamIP.Text;

            controller.AddCameraDB(info);
            //Camera cam = new Camera(info);
            
            //if (cam.CamRunning)
            //{
            //    flp.Controls.Add(cam);
            //    controller.AddCamera(cam);

            //    this.Dispose();
            //}
        }

        private void txtCamIP_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
