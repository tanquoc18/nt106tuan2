namespace CUOICUNG
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button StartServerButton;
        private System.Windows.Forms.Label ServerStatusLabel;
        private System.Windows.Forms.Button StartStreamingButton;
        private System.Windows.Forms.Label StreamingStatusLabel;
        /// <summary>
        /// Required designer variable.
        /// </summary>

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
        private void InitializeComponent()
        {
            this.StartStreamingButton = new System.Windows.Forms.Button();
            this.StreamingStatusLabel = new System.Windows.Forms.Label();
            this.StartServerButton = new System.Windows.Forms.Button();
            this.ServerStatusLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartStreamingButton
            // 
            this.StartStreamingButton.Location = new System.Drawing.Point(13, 123);
            this.StartStreamingButton.Name = "StartStreamingButton";
            this.StartStreamingButton.Size = new System.Drawing.Size(120, 40);
            this.StartStreamingButton.TabIndex = 0;
            this.StartStreamingButton.Text = "Start Streaming";
            this.StartStreamingButton.UseVisualStyleBackColor = true;
            this.StartStreamingButton.Click += new System.EventHandler(this.StartStreamingButton_Click);
            // 
            // StreamingStatusLabel
            // 
            this.StreamingStatusLabel.Location = new System.Drawing.Point(157, 123);
            this.StreamingStatusLabel.Name = "StreamingStatusLabel";
            this.StreamingStatusLabel.Size = new System.Drawing.Size(174, 40);
            this.StreamingStatusLabel.TabIndex = 1;
            this.StreamingStatusLabel.Text = "Streaming: Stopped";
            this.StreamingStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StartServerButton
            // 
            this.StartServerButton.Location = new System.Drawing.Point(13, 37);
            this.StartServerButton.Name = "StartServerButton";
            this.StartServerButton.Size = new System.Drawing.Size(120, 40);
            this.StartServerButton.TabIndex = 0;
            this.StartServerButton.Text = "Start Server";
            this.StartServerButton.Click += new System.EventHandler(this.StartServerButton_Click);
            // 
            // ServerStatusLabel
            // 
            this.ServerStatusLabel.Location = new System.Drawing.Point(157, 37);
            this.ServerStatusLabel.Name = "ServerStatusLabel";
            this.ServerStatusLabel.Size = new System.Drawing.Size(174, 40);
            this.ServerStatusLabel.TabIndex = 2;
            this.ServerStatusLabel.Text = "Server stopped";
            this.ServerStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.StartStreamingButton);
            this.panel1.Controls.Add(this.StartServerButton);
            this.panel1.Controls.Add(this.StreamingStatusLabel);
            this.panel1.Controls.Add(this.ServerStatusLabel);
            this.panel1.Location = new System.Drawing.Point(12, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(334, 187);
            this.panel1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 236);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Server";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>

        #endregion

        private System.Windows.Forms.Panel panel1;
    }
}

