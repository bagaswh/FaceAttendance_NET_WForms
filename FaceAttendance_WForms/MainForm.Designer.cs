namespace FaceAttendance_WForms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.nameLabel = new System.Windows.Forms.Label();
            this.cameraCaptureImageBox = new Emgu.CV.UI.ImageBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.camerCaptureTimer = new System.Windows.Forms.Timer(this.components);
            this.closingTimer = new System.Windows.Forms.Timer(this.components);
            this.captureCheckBox = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraCaptureImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.64557F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.35443F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tableLayoutPanel1.Controls.Add(this.nameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cameraCaptureImageBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.captureCheckBox, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 1;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.TableLayoutPanel1_Paint);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(3, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(0, 17);
            this.nameLabel.TabIndex = 1;
            // 
            // cameraCaptureImageBox
            // 
            this.cameraCaptureImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cameraCaptureImageBox.Location = new System.Drawing.Point(253, 3);
            this.cameraCaptureImageBox.Name = "cameraCaptureImageBox";
            this.cameraCaptureImageBox.Size = new System.Drawing.Size(534, 391);
            this.cameraCaptureImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cameraCaptureImageBox.TabIndex = 2;
            this.cameraCaptureImageBox.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 0);
            this.panel2.TabIndex = 0;
            // 
            // camerCaptureTimer
            // 
            this.camerCaptureTimer.Interval = 2000;
            this.camerCaptureTimer.Tick += new System.EventHandler(this.CamerCaptureTimer_Tick);
            // 
            // closingTimer
            // 
            this.closingTimer.Interval = 6000000;
            this.closingTimer.Tick += new System.EventHandler(this.ClosingTimer_Tick);
            // 
            // captureCheckBox
            // 
            this.captureCheckBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.captureCheckBox.AutoSize = true;
            this.captureCheckBox.Checked = true;
            this.captureCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.captureCheckBox.Location = new System.Drawing.Point(488, 415);
            this.captureCheckBox.Name = "captureCheckBox";
            this.captureCheckBox.Size = new System.Drawing.Size(63, 17);
            this.captureCheckBox.TabIndex = 4;
            this.captureCheckBox.Text = "Capture";
            this.captureCheckBox.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Face Attendance System";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraCaptureImageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label nameLabel;
        private Emgu.CV.UI.ImageBox cameraCaptureImageBox;
        private System.Windows.Forms.Timer camerCaptureTimer;
        private System.Windows.Forms.Timer closingTimer;
        private System.Windows.Forms.CheckBox captureCheckBox;
    }
}

