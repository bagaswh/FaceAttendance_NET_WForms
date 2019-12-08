using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceAttendance_WForms
{
    public partial class LandingForm : Form
    {
        public LandingForm()
        {
            InitializeComponent();

            Users.Load();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            new MainForm().Show();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            new UserForm().Show();
        }
    }
}
