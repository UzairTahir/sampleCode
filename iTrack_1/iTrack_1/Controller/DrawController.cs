using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTrack_1.Controller
{
    class DrawController
    {
        public static Image<Bgr, Byte> DrawRectangle(Rectangle[] rects, Mat image, Color color, int thickness = 3)
        {
            return DrawRectangle(rects,image.ToImage<Bgr, Byte>(), color, thickness);
        }
        public static Image<Bgr, Byte> DrawRectangle(Rectangle[] rects, Image<Bgr, Byte> image,Color color,int thickness=3)
        {

            foreach (Rectangle rect in rects)
            {
                
                image.Draw(rect, new Bgr(color), thickness);
                //return image;
            }
            return image;
        }

        public static Image<Bgr, Byte> DrawRectangle(Rectangle rect,string name, Image<Bgr, Byte> image, Color color, int thickness = 3)
        {
            image.Draw(rect, new Bgr(color), thickness);
            
            Font font = new Font(new FontFamily(System.Drawing.Text.GenericFontFamilies.SansSerif), 1,FontStyle.Bold);
            image.Draw(name,new Point(rect.X-2,rect.Y),Emgu.CV.CvEnum.FontFace.HersheyPlain,1,new Bgr(color),thickness);

            return image;
        }

        public static Image<Bgr, Byte> DrawRectangle(Rectangle rect, Image<Bgr, Byte> image, Color color, int thickness = 3)
        {
            image.Draw(rect, new Bgr(color), thickness);
            return image;
        }

        public static Image<Bgr, byte> DrawCircles(Mat image, PointF[] points)
        {
            return DrawCircles(image.ToImage<Bgr, byte>(), points);
        }
        public static Image<Bgr,byte> DrawCircles(Image<Bgr,byte> image,PointF[] points)
        {
            if (points == null) return image;

            foreach (PointF p in points)
            {
                CvInvoke.Circle(image, Point.Round(p), 3, new Bgr(255, 0, 0).MCvScalar, 1);
            }
            return image;
        }

        public static Image<Bgr,byte> DrawPolygon(Image<Bgr,byte> image,Point[] points)
        {

            using (VectorOfPoint vp = new VectorOfPoint(points))
            {
                CvInvoke.Polylines(image.Copy(), vp, true, new MCvScalar(255, 255, 0, 255), 1);
            }

            return image;
        }


        //public static Image<Bgr, Byte> DrawCircle(Rectangle[] rects, Mat image, Color color, int thickness = 3)
        //{
        //    return DrawCircle(rects,image.ToImage<Bgr,byte>(),color,thickness);
        //}
        //public static Image<Bgr, Byte> DrawCircle(Rectangle[] rects, Image<Bgr, byte> image,Color color, int thickness = 3)
        //{
        //    foreach (Rectangle rect in rects)
        //    {
        //        CircleF circle = new CircleF(new PointF((rect.X + rect.Width) / 2, (rect.Y + rect.Height) / 2), rect.Width / 2);
        //        image.Draw(circle, new Bgr(color), thickness);
        //    }
        //    return image;
        //}


    }
}
