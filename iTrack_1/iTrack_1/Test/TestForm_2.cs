using iTrack_1.Controller;
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
    public partial class TestForm_2 : Form
    {
        Track track;
        public TestForm_2()
        {
            InitializeComponent();

            timeLine1.Initialize(new DateTime(2016,10,18), new DateTime(2016, 10, 19));
            //timeLine1.AddDummyData();

            track = new Track(ref timeLine1,new TimeInterval(new DateTime(2016, 10, 18), new DateTime(2016, 10, 19)));
            
            Timer timer = new Timer();
            timer.Interval += 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //timeLine1.UpdateAll();
        }
    }
}
