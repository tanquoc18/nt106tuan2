namespace Client
{
    partial class Form1
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
            this.ServerIP = new System.Windows.Forms.Label();
            this.Port = new System.Windows.Forms.Label();
            this.PathServer = new System.Windows.Forms.TextBox();
            this.PathPort = new System.Windows.Forms.TextBox();
            this.Connect = new System.Windows.Forms.Button();
            this.HienThi = new System.Windows.Forms.RichTextBox();
            this.Go = new System.Windows.Forms.RichTextBox();
            this.Send = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ServerIP
            // 
            this.ServerIP.AutoSize = true;
            this.ServerIP.Location = new System.Drawing.Point(13, 13);
            this.ServerIP.Name = "ServerIP";
            this.ServerIP.Size = new System.Drawing.Size(62, 16);
            this.ServerIP.TabIndex = 0;
            this.ServerIP.Text = "Server IP";
            // 
            // Port
            // 
            this.Port.AutoSize = true;
            this.Port.Location = new System.Drawing.Point(240, 13);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(31, 16);
            this.Port.TabIndex = 1;
            this.Port.Text = "Port";
            // 
            // PathServer
            // 
            this.PathServer.Location = new System.Drawing.Point(81, 6);
            this.PathServer.Name = "PathServer";
            this.PathServer.Size = new System.Drawing.Size(137, 22);
            this.PathServer.TabIndex = 2;
            this.PathServer.Text = "127.0.0.1";
            // 
            // PathPort
            // 
            this.PathPort.Location = new System.Drawing.Point(286, 5);
            this.PathPort.Name = "PathPort";
            this.PathPort.Size = new System.Drawing.Size(125, 22);
            this.PathPort.TabIndex = 3;
            this.PathPort.Text = "11000";
            // 
            // Connect
            // 
            this.Connect.Location = new System.Drawing.Point(417, 6);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(75, 23);
            this.Connect.TabIndex = 4;
            this.Connect.Text = "Connect";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // HienThi
            // 
            this.HienThi.Location = new System.Drawing.Point(13, 47);
            this.HienThi.Name = "HienThi";
            this.HienThi.Size = new System.Drawing.Size(558, 122);
            this.HienThi.TabIndex = 5;
            this.HienThi.Text = "";
            // 
            // Go
            // 
            this.Go.Location = new System.Drawing.Point(13, 175);
            this.Go.Name = "Go";
            this.Go.Size = new System.Drawing.Size(558, 118);
            this.Go.TabIndex = 6;
            this.Go.Text = "";
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(13, 299);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(558, 55);
            this.Send.TabIndex = 7;
            this.Send.Text = "Send";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(508, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Open File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.Go);
            this.Controls.Add(this.HienThi);
            this.Controls.Add(this.Connect);
            this.Controls.Add(this.PathPort);
            this.Controls.Add(this.PathServer);
            this.Controls.Add(this.Port);
            this.Controls.Add(this.ServerIP);
            this.Name = "Form1";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ServerIP;
        private System.Windows.Forms.Label Port;
        private System.Windows.Forms.TextBox PathServer;
        private System.Windows.Forms.TextBox PathPort;
        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.RichTextBox HienThi;
        private System.Windows.Forms.RichTextBox Go;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
    }
}

