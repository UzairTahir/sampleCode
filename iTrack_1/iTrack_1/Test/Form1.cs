using iTrack_1.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTrack_1.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool isLeftPanelOpen = false;
        bool isClosing = false;
        int expandSize = 185;
        int shrinkSize = 35;
        int desiredSize;
        private void button1_Click(object sender, EventArgs e)
        {
            if (leftPanel.Width == expandSize)
                desiredSize = shrinkSize;
            else
                desiredSize = expandSize;

            isClosing = leftPanel.Width == expandSize;
            sliderTimer.Enabled = true;

        }

        private void sliderTimer_Tick(object sender, EventArgs e)
        {
            if (!isClosing)
            {
                leftPanel.Width += 6;
            }
            else
            {
                leftPanel.Width -= 6;
            }
            if (leftPanel.Width == desiredSize)
                sliderTimer.Enabled = false;
        }

        Indentification indForm;
        private void btnIdentify_Click(object sender, EventArgs e)
        {
            if (indForm == null)
            {
                indForm = new Indentification();
                indForm.MdiParent = this;
                indForm.FormClosed += IndForm_FormClosed;
                indForm.Show();
            }
            else
            {
                indForm.Activate();
            }

        }

        private void IndForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            indForm = null;
        }
    }
}
