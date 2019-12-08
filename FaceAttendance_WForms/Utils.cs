using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace FaceAttendance_WForms
{
    static class Utils
    {
        public static string EncodeToBase64(string ext, Image<Bgr, byte> image)
        {
            VectorOfByte buf = new VectorOfByte(image.Rows * image.Cols);
            CvInvoke.Imencode(ext, image, buf);

            string base64 = Convert.ToBase64String(buf.ToArray());
            return base64;
        }
    }
}
