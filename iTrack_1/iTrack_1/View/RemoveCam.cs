using iTrack.Controller;
using iTrack_1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTrack.View
{
    public partial class RemoveCam : Form
    {
       private FlowLayoutPanel flp;
        private CameraManager CMan;
        
        public RemoveCam(FlowLayoutPanel temp)
        {
            InitializeComponent();
            CMan = CameraManager.Instance;

            flp = temp;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            for (int i=0;i<flp.Controls.Count;i++)
            {
                Control ctrl = flp.Controls[i];
                if ((ctrl as iTrack.UserControls.Camera).CameraName==txtCamName.Text)
                {
                    flp.Controls.RemoveAt(i);

                    //string query = string.Format("delete from Cameras where Name = {0};", ("'" + txtCamName.Text + "'"));
                    //sql.ExecuteNonQuery(query);
                    CMan.DelCameraDB(txtCamName.Text);
                    CMan.RemoveCamera(txtCamName.Text);

                    MessageBox.Show("Camera Removed Successfully");
                    this.Dispose();
                }
            }

            MessageBox.Show("Camera not found");
            
        }
    }
}
