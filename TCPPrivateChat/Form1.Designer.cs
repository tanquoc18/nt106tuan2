namespace TCPPrivateChat
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
            this.Path = new System.Windows.Forms.TextBox();
            this.Listen = new System.Windows.Forms.Button();
            this.Hienthi = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // ServerIP
            // 
            this.ServerIP.AutoSize = true;
            this.ServerIP.Location = new System.Drawing.Point(10, 16);
            this.ServerIP.Name = "ServerIP";
            this.ServerIP.Size = new System.Drawing.Size(62, 16);
            this.ServerIP.TabIndex = 0;
            this.ServerIP.Text = "Servar IP";
            // 
            // Path
            // 
            this.Path.Location = new System.Drawing.Point(76, 13);
            this.Path.Name = "Path";
            this.Path.Size = new System.Drawing.Size(176, 22);
            this.Path.TabIndex = 1;
            this.Path.Text = "127.0.0.1";
            // 
            // Listen
            // 
            this.Listen.Location = new System.Drawing.Point(292, 12);
            this.Listen.Name = "Listen";
            this.Listen.Size = new System.Drawing.Size(75, 23);
            this.Listen.TabIndex = 2;
            this.Listen.Text = "Listen";
            this.Listen.UseVisualStyleBackColor = true;
            this.Listen.Click += new System.EventHandler(this.Listen_Click);
            // 
            // Hienthi
            // 
            this.Hienthi.Location = new System.Drawing.Point(13, 41);
            this.Hienthi.Name = "Hienthi";
            this.Hienthi.Size = new System.Drawing.Size(354, 349);
            this.Hienthi.TabIndex = 3;
            this.Hienthi.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 402);
            this.Controls.Add(this.Hienthi);
            this.Controls.Add(this.Listen);
            this.Controls.Add(this.Path);
            this.Controls.Add(this.ServerIP);
            this.Name = "Form1";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ServerIP;
        private System.Windows.Forms.TextBox Path;
        private System.Windows.Forms.Button Listen;
        private System.Windows.Forms.RichTextBox Hienthi;
    }
}

