using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Emgu.CV;

namespace FaceAttendance_WForms
{
    static class Camera
    {
        private static VideoCapture _cameraCapture;

        public static void InitCam(int cameraIndex = 0)
        {
            Camera._cameraCapture = new VideoCapture(cameraIndex);
        }


        public static void CloseCam()
        {
            Camera._cameraCapture.Stop();
            Camera._cameraCapture.Dispose();
        }

        public delegate void FrameHandler(Mat frame);
        public static void GetFrame(FrameHandler handler)
        {
            using (var frame = Camera._cameraCapture.QueryFrame())
            {
                handler(frame);
            }
        }

    }
}
