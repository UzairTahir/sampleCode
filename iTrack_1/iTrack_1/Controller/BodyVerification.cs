using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTrack_1.Controller
{
    class BodyVerification
    {

        public const int numberOfVerificationFrames = 10;
        public const int framesForLostTrack = 5;
        public int currentVerificationNumber = 0;
        public int currentLostNumber = 0;

        public int indexOfPerson = -1;
        public bool isUnderVerfication = false;
        private bool personVerified = false;
        public Rectangle rectOfPerson;

        bool isTrackingSuspect = false;
        BodyTracking bodyTracking = new BodyTracking();


        public void SetPersonVerification(Mat frame, Rectangle roi, Rectangle[] rois)
        {
            bodyTracking.CalculateOpticalFlow_Sparse(frame, roi, rois, true);
            //Debug.AddTrackText("SET OF");
            // here
            isTrackingSuspect = true;
        }

        public void VerifyPerson(Mat frame, Rectangle roi, Rectangle[] rois)
        {
            if (!isTrackingSuspect && roi != Rectangle.Empty)
            {
                ProcessVerification(frame, roi, rois, true);

                isTrackingSuspect = true;
            }
            else
            {
                ProcessVerification(frame, roi, rois, false);
                indexOfPerson = bodyTracking.indexOfPerson;
                //Debug.AddTrackText("Match OF " + indexOfPerson);
                rectOfPerson = bodyTracking.rectOfPerson;
            }
        }
        public void ProcessVerification(Mat frame, Rectangle roi, Rectangle[] rois, bool force = false)
        {
            bodyTracking.CalculateOpticalFlow_Sparse(frame, roi, rois, force);

            

            if (bodyTracking.rectOfPerson == roi)
            {
                currentVerificationNumber = Math.Min(++currentVerificationNumber, numberOfVerificationFrames);
                currentLostNumber = 0;
                isUnderVerfication = true;
            }
            else
            {
                isUnderVerfication = false;
                currentVerificationNumber = Math.Max(--currentVerificationNumber, 0);

                if (personVerified)
                {
                    currentLostNumber = Math.Min(++currentLostNumber, framesForLostTrack);
                }
            }

            if (currentVerificationNumber >= numberOfVerificationFrames)
            {
                personVerified = true;
                currentLostNumber = 0;
            }
            else if(currentLostNumber >= framesForLostTrack)
            {
                personVerified = false;
                currentVerificationNumber = 0;
            }
        }

        public bool isPersonVerified()
        {
            return personVerified;
        }

    }
}
