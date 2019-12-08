using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

using Emgu;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using Emgu.CV.Util;

using Newtonsoft;
using Newtonsoft.Json;

namespace FaceAttendance_WForms
{

    public partial class MainForm : Form
    {
        public MainForm()
        {
            Camera.InitCam();

            InitializeComponent();

            Application.Idle += this.CaptureImage;
            this.camerCaptureTimer.Start();

            this.FormClosed += this.CleanUp;
        }


        #region Public Fields

        #endregion

        #region Private Fields

        private bool _willSend = false;

        #endregion

        #region Private Methods

        private void CleanUp(object sender, EventArgs e)
        {
            this.camerCaptureTimer.Stop();
            this.closingTimer.Stop();
            Camera.CloseCam();
            Application.Idle -= this.CaptureImage;
            this.FormClosed -= this.CleanUp;
        }

        private void DrawRects(Image<Bgr, byte> image, int[][] faceLocations)
        {
            foreach (var location in faceLocations)
            {
                var top = location[0];
                var right = location[1];
                var bottom = location[2];
                var left = location[3];

                Rectangle rectangle = new Rectangle(left, top, right - left, bottom - top);
                image.Draw(rectangle, new Bgr(Color.AliceBlue));
            }
        }

        private void DrawPolyLines()
        {

        }

        private string GetFaceJsonData(Image<Bgr, byte> frame)
        {
            string base64 = Utils.EncodeToBase64(".jpg", frame);
            MessageQueue.Send(MessageQueue.RecognitionEngineClient,
                (int)Constants.RequestIntents.INTENT_REQ_FACE_ID, base64);
            string json = MessageQueue.Receive(MessageQueue.RecognitionEngineClient);

            return json;
        }

        private FaceData GetFaceData(string json)
        {
            try
            {
                return JsonConvert
                    .DeserializeObject<FaceData>(json, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private void DisplayNames(FaceData faceData)
        {
            StringBuilder names = new StringBuilder(faceData.ids.Length);
            foreach (var id in faceData.ids)
            {
                string name = Users.UsersData[id];
                names.Append(name);
            }

            this.nameLabel.Text = names.ToString();
        }

        private void CaptureImage(object sender, EventArgs e)
        {
            Camera.GetFrame(delegate (Mat frame) {
                using (var currentFrame = frame.ToImage<Bgr, byte>())
                {
                    if (this.captureCheckBox.Checked)
                    {
                        _willSend = false;

                        string json = this.GetFaceJsonData(currentFrame);
                        if (json != null)
                        {
                            FaceData data = this.GetFaceData(json);
                            if (data != null && data.ids.Length > 0)
                            {
                                this.closingTimer.Start();

                                this.DisplayNames(data);
                                this.DrawRects(currentFrame, data.face_locations);

                                object attendanceData = new { ids = data.ids };
                                string jsonAttendance = JsonConvert.SerializeObject(attendanceData);

                                // Console.WriteLine(jsonAttendance);

                                MessageQueue.Send(MessageQueue.NodeJSClient, (int)Constants.RequestIntents.INTENT_REQ_UPDATE_ATTENDANCE_DATA, jsonAttendance);
                                MessageQueue.Receive(MessageQueue.NodeJSClient);
                            }
                            else
                            {
                                this.nameLabel.Text = "";
                            }
                        }
                    }
                    this.cameraCaptureImageBox.Image = currentFrame;
                }
            });
        }

        #endregion

        #region UI Event Callbacks
        private void MainForm_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = true;
        }

        private void AddFaceButton_Click(object sender, EventArgs e)
        {
            new UserForm().Show();
        }

        private void CamerCaptureTimer_Tick(object sender, EventArgs e)
        {
            _willSend = true;
        }

        private void ClosingTimer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    
    struct FaceLandmark
    {

    }

    class FaceData
    {
        public int[][] face_locations;
        public Int16[] ids;
    }
}
