namespace NVRClient
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtBaseUrl = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cmbCameraId = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnPlayback = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnPlayLive = new System.Windows.Forms.Button();
            this.btnStartListener = new System.Windows.Forms.Button();
            this.btnStopListener = new System.Windows.Forms.Button();
            this.videoPanel = new System.Windows.Forms.Panel();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.lblBaseUrl = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblCameraId = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.grpPTZ = new System.Windows.Forms.GroupBox();
            this.btnPTZUp = new System.Windows.Forms.Button();
            this.btnPTZDown = new System.Windows.Forms.Button();
            this.btnPTZLeft = new System.Windows.Forms.Button();
            this.btnPTZRight = new System.Windows.Forms.Button();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.grpPTZ.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBaseUrl
            // 
            this.txtBaseUrl.Location = new System.Drawing.Point(80, 12);
            this.txtBaseUrl.Name = "txtBaseUrl";
            this.txtBaseUrl.Size = new System.Drawing.Size(160, 20);
            this.txtBaseUrl.TabIndex = 1;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(320, 12);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 20);
            this.txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(500, 12);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // cmbCameraId
            // 
            this.cmbCameraId.Location = new System.Drawing.Point(80, 47);
            this.cmbCameraId.Name = "cmbCameraId";
            this.cmbCameraId.Size = new System.Drawing.Size(160, 21);
            this.cmbCameraId.TabIndex = 9;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(620, 10);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click_1);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(720, 10);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 7;
            this.btnDisconnect.Text = "Disconnect";
            // 
            // btnPlayback
            // 
            this.btnPlayback.Location = new System.Drawing.Point(80, 80);
            this.btnPlayback.Name = "btnPlayback";
            this.btnPlayback.Size = new System.Drawing.Size(75, 23);
            this.btnPlayback.TabIndex = 10;
            this.btnPlayback.Text = "Play Back";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(170, 80);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 11;
            this.btnExport.Text = "Export";
            // 
            // btnPlayLive
            // 
            this.btnPlayLive.Location = new System.Drawing.Point(250, 80);
            this.btnPlayLive.Name = "btnPlayLive";
            this.btnPlayLive.Size = new System.Drawing.Size(75, 23);
            this.btnPlayLive.TabIndex = 12;
            this.btnPlayLive.Text = "Play Live";
            // 
            // btnStartListener
            // 
            this.btnStartListener.Location = new System.Drawing.Point(12, 120);
            this.btnStartListener.Name = "btnStartListener";
            this.btnStartListener.Size = new System.Drawing.Size(75, 23);
            this.btnStartListener.TabIndex = 13;
            this.btnStartListener.Text = "Start Listener";
            // 
            // btnStopListener
            // 
            this.btnStopListener.Location = new System.Drawing.Point(12, 155);
            this.btnStopListener.Name = "btnStopListener";
            this.btnStopListener.Size = new System.Drawing.Size(75, 23);
            this.btnStopListener.TabIndex = 14;
            this.btnStopListener.Text = "Stop Listener";
            // 
            // videoPanel
            // 
            this.videoPanel.Location = new System.Drawing.Point(200, 120);
            this.videoPanel.Name = "videoPanel";
            this.videoPanel.Size = new System.Drawing.Size(518, 345);
            this.videoPanel.TabIndex = 19;
            // 
            // dtFrom
            // 
            this.dtFrom.Location = new System.Drawing.Point(12, 220);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(182, 20);
            this.dtFrom.TabIndex = 16;
            // 
            // dtTo
            // 
            this.dtTo.Location = new System.Drawing.Point(12, 270);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(182, 20);
            this.dtTo.TabIndex = 18;
            // 
            // lblBaseUrl
            // 
            this.lblBaseUrl.Location = new System.Drawing.Point(12, 10);
            this.lblBaseUrl.Name = "lblBaseUrl";
            this.lblBaseUrl.Size = new System.Drawing.Size(62, 23);
            this.lblBaseUrl.TabIndex = 0;
            this.lblBaseUrl.Text = "Base URL";
            this.lblBaseUrl.Click += new System.EventHandler(this.lblBaseUrl_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.Location = new System.Drawing.Point(243, 12);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(75, 23);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Username";
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(426, 12);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(68, 23);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password";
            // 
            // lblCameraId
            // 
            this.lblCameraId.Location = new System.Drawing.Point(12, 47);
            this.lblCameraId.Name = "lblCameraId";
            this.lblCameraId.Size = new System.Drawing.Size(62, 23);
            this.lblCameraId.TabIndex = 8;
            this.lblCameraId.Text = "CameraId";
            // 
            // lblFrom
            // 
            this.lblFrom.Location = new System.Drawing.Point(12, 197);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(75, 20);
            this.lblFrom.TabIndex = 15;
            this.lblFrom.Text = "From";
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(12, 250);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(100, 17);
            this.lblTo.TabIndex = 17;
            this.lblTo.Text = "To";
            // 
            // grpPTZ
            // 
            this.grpPTZ.Controls.Add(this.btnPTZUp);
            this.grpPTZ.Controls.Add(this.btnPTZDown);
            this.grpPTZ.Controls.Add(this.btnPTZLeft);
            this.grpPTZ.Controls.Add(this.btnPTZRight);
            this.grpPTZ.Controls.Add(this.btnZoomIn);
            this.grpPTZ.Controls.Add(this.btnZoomOut);
            this.grpPTZ.Location = new System.Drawing.Point(20, 310);
            this.grpPTZ.Name = "grpPTZ";
            this.grpPTZ.Size = new System.Drawing.Size(150, 170);
            this.grpPTZ.TabIndex = 20;
            this.grpPTZ.TabStop = false;
            this.grpPTZ.Text = "PTZ Control";
            // 
            // btnPTZUp
            // 
            this.btnPTZUp.Location = new System.Drawing.Point(55, 25);
            this.btnPTZUp.Name = "btnPTZUp";
            this.btnPTZUp.Size = new System.Drawing.Size(40, 30);
            this.btnPTZUp.TabIndex = 0;
            this.btnPTZUp.Text = "▲";
            // 
            // btnPTZDown
            // 
            this.btnPTZDown.Location = new System.Drawing.Point(55, 95);
            this.btnPTZDown.Name = "btnPTZDown";
            this.btnPTZDown.Size = new System.Drawing.Size(40, 30);
            this.btnPTZDown.TabIndex = 1;
            this.btnPTZDown.Text = "▼";
            // 
            // btnPTZLeft
            // 
            this.btnPTZLeft.Location = new System.Drawing.Point(15, 60);
            this.btnPTZLeft.Name = "btnPTZLeft";
            this.btnPTZLeft.Size = new System.Drawing.Size(40, 30);
            this.btnPTZLeft.TabIndex = 2;
            this.btnPTZLeft.Text = "◄";
            // 
            // btnPTZRight
            // 
            this.btnPTZRight.Location = new System.Drawing.Point(95, 60);
            this.btnPTZRight.Name = "btnPTZRight";
            this.btnPTZRight.Size = new System.Drawing.Size(40, 30);
            this.btnPTZRight.TabIndex = 3;
            this.btnPTZRight.Text = "►";
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Location = new System.Drawing.Point(20, 130);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(45, 25);
            this.btnZoomIn.TabIndex = 4;
            this.btnZoomIn.Text = "+";
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Location = new System.Drawing.Point(80, 130);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(45, 25);
            this.btnZoomOut.TabIndex = 5;
            this.btnZoomOut.Text = "-";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(850, 492);
            this.Controls.Add(this.lblBaseUrl);
            this.Controls.Add(this.txtBaseUrl);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.lblCameraId);
            this.Controls.Add(this.cmbCameraId);
            this.Controls.Add(this.btnPlayback);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnPlayLive);
            this.Controls.Add(this.btnStartListener);
            this.Controls.Add(this.btnStopListener);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.dtFrom);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.dtTo);
            this.Controls.Add(this.videoPanel);
            this.Controls.Add(this.grpPTZ);
            this.Name = "Form1";
            this.Text = "NVR Client";
            this.grpPTZ.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox txtBaseUrl;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cmbCameraId;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnPlayback;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnPlayLive;
        private System.Windows.Forms.Button btnStartListener;
        private System.Windows.Forms.Button btnStopListener;
        private System.Windows.Forms.Panel videoPanel;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label lblBaseUrl;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblCameraId;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.GroupBox grpPTZ;
        private System.Windows.Forms.Button btnPTZUp;
        private System.Windows.Forms.Button btnPTZDown;
        private System.Windows.Forms.Button btnPTZLeft;
        private System.Windows.Forms.Button btnPTZRight;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnZoomOut;
    }
}
