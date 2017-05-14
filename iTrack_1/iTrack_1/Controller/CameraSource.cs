using DirectShowLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTrack_1.Controller
{
    class CameraSource
    {
        List<KeyValuePair<int, string>> ListCamerasData = new List<KeyValuePair<int, string>>();
        DsDevice[] Cameras = DsDevice.GetDevicesOfCat(DirectShowLib.FilterCategory.VideoInputDevice);
        int CameraCount = 0;


        public CameraSource()
        {
            // Get the list of all the available cameras
            Refresh();
        }
        public void Refresh()
        {
            ListCamerasData.Clear();
            CameraCount = 0;
            foreach (DirectShowLib.DsDevice _Camera in Cameras)
            {
                ListCamerasData.Add(new KeyValuePair<int, string>(CameraCount, _Camera.Name));
                CameraCount++;
            }

        }
        public string[] GetCamerasNames()
        {
            string[] devicesNames = new string[CameraCount];

            for (int i = 0; i < CameraCount; i++)
                devicesNames[i] = ListCamerasData[i].Value;

            return devicesNames;
        }

        public string GetMonikerString(int index)
        {
            //return videoDevices[index].MonikerString;
            return null;
        }

        public int GetCameraIndex(int ind)
        {
            return ListCamerasData[ind].Key;
        }

        public int GetCameraCount()
        {
            return CameraCount;
        }

        public void FillCBWithCameras(ref ComboBox cb)
        {
            for (int i = 0; i < CameraCount; i++)
            {
                cb.Items.Add(ListCamerasData[i].Value);
            }
        }

    }

}
