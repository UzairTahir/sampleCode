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
using Emgu.CV;
using Emgu.CV.Structure;

namespace iTrack_1.UserControls
{
    public partial class BodyFeatureView : UserControl
    {
        public BodyFeatureView()
        {
            InitializeComponent();
            ClearControl();
        }
        //public BodyFeatureView(Image<Bgr, byte> bodyImage)
        //{
        //    InitializeComponent();

        //    RefreshControl(bodyImage);

        //}
        public void RefreshImage(Image<Bgr, byte> bodyImage)
        {
            //ClearControl();
            //pbBodyImage.Image = bodyImage.Resize(1.18, Emgu.CV.CvEnum.Inter.Cubic).ToBitmap();
            ibBodyImage.Image = bodyImage.Resize(75, 150, Emgu.CV.CvEnum.Inter.Cubic);//.ToBitmap();

            histogramBox.ClearHistogram();
            histogramBox.GenerateHistograms(bodyImage, 256);
            histogramBox.Refresh();

        }
        public void RefreshText(double HOG, double RGB, double HS)
        {
            lblHog.Text = HOG.ToString();
            lblHs.Text = HS.ToString();
            lblRgb.Text = RGB.ToString();
        }
        public void RefreshControl(Image<Bgr, byte> bodyImage,double HOG,double RGB,double HS)
        {
            //ClearControl();
            ibBodyImage.Image = bodyImage.Resize(75,150, Emgu.CV.CvEnum.Inter.Cubic);//.ToBitmap();

            histogramBox.ClearHistogram();
            histogramBox.GenerateHistograms(bodyImage, 256);
            histogramBox.Refresh();

            lblHog.Text = HOG.ToString();
            lblHs.Text = HS.ToString();
            lblRgb.Text = RGB.ToString();

        }
        
        public void ClearControl()
        {
            ibBodyImage.Image = null;
            histogramBox.ClearHistogram();
           
            lblHog.Text = String.Empty;
            lblHs.Text = String.Empty;
            lblRgb.Text = String.Empty;
            
        }

        
    }
}
