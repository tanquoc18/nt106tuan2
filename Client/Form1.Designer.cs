using System.Windows.Forms;

namespace Client
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button DisconnectButton;
        private Button StartReceivingButton;
        private Label ReceivingStatusLabel;
        private PictureBox ScreenPictureBox;


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
            this.StartReceivingButton = new System.Windows.Forms.Button();
            this.ReceivingStatusLabel = new System.Windows.Forms.Label();
            this.ScreenPictureBox = new System.Windows.Forms.PictureBox();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.btnCutScreen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ScreenPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // StartReceivingButton
            // 
            this.StartReceivingButton.Location = new System.Drawing.Point(566, 8);
            this.StartReceivingButton.Name = "StartReceivingButton";
            this.StartReceivingButton.Size = new System.Drawing.Size(100, 30);
            this.StartReceivingButton.TabIndex = 3;
            this.StartReceivingButton.Text = "Start Receiving";
            this.StartReceivingButton.UseVisualStyleBackColor = true;
            this.StartReceivingButton.Click += new System.EventHandler(this.StartReceivingButton_Click);
            // 
            // ReceivingStatusLabel
            // 
            this.ReceivingStatusLabel.Location = new System.Drawing.Point(950, 9);
            this.ReceivingStatusLabel.Name = "ReceivingStatusLabel";
            this.ReceivingStatusLabel.Size = new System.Drawing.Size(200, 25);
            this.ReceivingStatusLabel.TabIndex = 4;
            this.ReceivingStatusLabel.Text = "Receiving: Stopped";
            this.ReceivingStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ScreenPictureBox
            // 
            this.ScreenPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.ScreenPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ScreenPictureBox.Location = new System.Drawing.Point(3, 40);
            this.ScreenPictureBox.Name = "ScreenPictureBox";
            this.ScreenPictureBox.Size = new System.Drawing.Size(1920, 1080);
            this.ScreenPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ScreenPictureBox.TabIndex = 5;
            this.ScreenPictureBox.TabStop = false;
            this.ScreenPictureBox.Click += new System.EventHandler(this.ScreenPictureBox_Click);
            this.ScreenPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ScreenPictureBox_MouseClick);
            this.ScreenPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.ScreenPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ScreenPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(12, 12);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(240, 22);
            this.txtServerIP.TabIndex = 0;
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(284, 8);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(100, 30);
            this.ConnectButton.TabIndex = 1;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Enabled = false;
            this.DisconnectButton.Location = new System.Drawing.Point(421, 8);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(100, 30);
            this.DisconnectButton.TabIndex = 2;
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // btnCutScreen
            // 
            this.btnCutScreen.Location = new System.Drawing.Point(726, 8);
            this.btnCutScreen.Name = "btnCutScreen";
            this.btnCutScreen.Size = new System.Drawing.Size(100, 30);
            this.btnCutScreen.TabIndex = 6;
            this.btnCutScreen.Text = "ScreenShot";
            this.btnCutScreen.UseVisualStyleBackColor = true;
            this.btnCutScreen.Click += new System.EventHandler(this.btnCutScreen_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1615, 748);
            this.Controls.Add(this.btnCutScreen);
            this.Controls.Add(this.txtServerIP);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.DisconnectButton);
            this.Controls.Add(this.StartReceivingButton);
            this.Controls.Add(this.ReceivingStatusLabel);
            this.Controls.Add(this.ScreenPictureBox);
            this.Name = "Form1";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ScreenPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnCutScreen;
    }
}

