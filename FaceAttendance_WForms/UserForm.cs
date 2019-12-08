using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft;
using Newtonsoft.Json;

using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;

namespace FaceAttendance_WForms
{
    public partial class UserForm : Form
    {
        private bool _buttonClicked = false;

        public UserForm()
        {
            Camera.InitCam();

            InitializeComponent();

            Application.Idle += this.CaptureImage;
            this.FormClosed += this.CleanUp;
        }

        private void CleanUp(object sender, EventArgs e)
        {
            Camera.CloseCam();
            Application.Idle -= this.CaptureImage;
            this.FormClosed -= this.CleanUp;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            
        }

        private void CaptureImage(object sender, EventArgs e)
        {
            Camera.GetFrame(delegate (Mat frame) {
                if (Form.ActiveForm != this)
                {
                    return;
                }

                using (var frameCopy = frame.ToImage<Bgr, byte>())
                {
                    this.imageBox.Image = frameCopy;
                    if (this._buttonClicked)
                    {
                        this._buttonClicked = false;

                        string user_id = this.nisTextBox.Text;
                        string image_base64 = Utils.EncodeToBase64(".jpg", frameCopy);
                        if (!String.IsNullOrEmpty(user_id) && !String.IsNullOrEmpty(image_base64))
                        {
                            object obj = new { user_id = user_id, image_base64 = image_base64 };
                            string json = JsonConvert.SerializeObject(obj);

                            this.addUserButton.Enabled = false;
                            MessageQueue.Send(MessageQueue.NodeJSClient, (int)Constants.RequestIntents.INTENT_REQ_INSERT_FACE_DATA, json);
                            MessageQueue.Receive(MessageQueue.NodeJSClient);
                            this.addUserButton.Enabled = true;
                        }                        
                    }
                }
            });
            
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            _buttonClicked = true;
        }
    }
}
