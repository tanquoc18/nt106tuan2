namespace Sever
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ListMessages = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblPORT = new System.Windows.Forms.Label();
            this.lblHOSTNAME = new System.Windows.Forms.Label();
            this.lblIPADD = new System.Windows.Forms.Label();
            this.txtPORT = new System.Windows.Forms.TextBox();
            this.txtHOSTNAME = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtSEND = new System.Windows.Forms.TextBox();
            this.btnSEND = new System.Windows.Forms.Button();
            this.btnSTART = new System.Windows.Forms.Button();
            this.btnSTOP = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ListMessages);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(32, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 268);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Messages:";
            // 
            // ListMessages
            // 
            this.ListMessages.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListMessages.FormattingEnabled = true;
            this.ListMessages.ItemHeight = 23;
            this.ListMessages.Location = new System.Drawing.Point(6, 29);
            this.ListMessages.Name = "ListMessages";
            this.ListMessages.Size = new System.Drawing.Size(308, 234);
            this.ListMessages.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblPORT);
            this.groupBox2.Controls.Add(this.lblHOSTNAME);
            this.groupBox2.Controls.Add(this.lblIPADD);
            this.groupBox2.Controls.Add(this.txtPORT);
            this.groupBox2.Controls.Add(this.txtHOSTNAME);
            this.groupBox2.Controls.Add(this.txtIP);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(370, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(568, 252);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sever Infor: ";
            // 
            // lblPORT
            // 
            this.lblPORT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPORT.Location = new System.Drawing.Point(19, 207);
            this.lblPORT.Name = "lblPORT";
            this.lblPORT.Size = new System.Drawing.Size(124, 27);
            this.lblPORT.TabIndex = 5;
            this.lblPORT.Text = "Port: ";
            this.lblPORT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHOSTNAME
            // 
            this.lblHOSTNAME.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHOSTNAME.Location = new System.Drawing.Point(19, 130);
            this.lblHOSTNAME.Name = "lblHOSTNAME";
            this.lblHOSTNAME.Size = new System.Drawing.Size(124, 27);
            this.lblHOSTNAME.TabIndex = 4;
            this.lblHOSTNAME.Text = "Host Name: ";
            this.lblHOSTNAME.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIPADD
            // 
            this.lblIPADD.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIPADD.Location = new System.Drawing.Point(19, 52);
            this.lblIPADD.Name = "lblIPADD";
            this.lblIPADD.Size = new System.Drawing.Size(124, 27);
            this.lblIPADD.TabIndex = 3;
            this.lblIPADD.Text = "IP Address: ";
            this.lblIPADD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPORT
            // 
            this.txtPORT.Location = new System.Drawing.Point(135, 207);
            this.txtPORT.Name = "txtPORT";
            this.txtPORT.Size = new System.Drawing.Size(416, 30);
            this.txtPORT.TabIndex = 2;
            // 
            // txtHOSTNAME
            // 
            this.txtHOSTNAME.Location = new System.Drawing.Point(135, 130);
            this.txtHOSTNAME.Name = "txtHOSTNAME";
            this.txtHOSTNAME.Size = new System.Drawing.Size(416, 30);
            this.txtHOSTNAME.TabIndex = 1;
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(135, 52);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(416, 30);
            this.txtIP.TabIndex = 0;
            // 
            // txtSEND
            // 
            this.txtSEND.Location = new System.Drawing.Point(38, 299);
            this.txtSEND.Multiline = true;
            this.txtSEND.Name = "txtSEND";
            this.txtSEND.Size = new System.Drawing.Size(229, 72);
            this.txtSEND.TabIndex = 2;
            // 
            // btnSEND
            // 
            this.btnSEND.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSEND.Location = new System.Drawing.Point(271, 299);
            this.btnSEND.Name = "btnSEND";
            this.btnSEND.Size = new System.Drawing.Size(81, 72);
            this.btnSEND.TabIndex = 3;
            this.btnSEND.Text = "SEND";
            this.btnSEND.UseVisualStyleBackColor = true;
            this.btnSEND.Click += new System.EventHandler(this.btnSEND_Click);
            // 
            // btnSTART
            // 
            this.btnSTART.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSTART.Location = new System.Drawing.Point(433, 299);
            this.btnSTART.Name = "btnSTART";
            this.btnSTART.Size = new System.Drawing.Size(159, 60);
            this.btnSTART.TabIndex = 4;
            this.btnSTART.Text = "START";
            this.btnSTART.UseVisualStyleBackColor = true;
            this.btnSTART.Click += new System.EventHandler(this.btnSTART_Click);
            // 
            // btnSTOP
            // 
            this.btnSTOP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSTOP.Location = new System.Drawing.Point(739, 299);
            this.btnSTOP.Name = "btnSTOP";
            this.btnSTOP.Size = new System.Drawing.Size(159, 60);
            this.btnSTOP.TabIndex = 5;
            this.btnSTOP.Text = "STOP";
            this.btnSTOP.UseVisualStyleBackColor = true;
            this.btnSTOP.Click += new System.EventHandler(this.btnSTOP_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 383);
            this.Controls.Add(this.btnSTOP);
            this.Controls.Add(this.btnSTART);
            this.Controls.Add(this.btnSEND);
            this.Controls.Add(this.txtSEND);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "SEVER";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox ListMessages;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblPORT;
        private System.Windows.Forms.Label lblHOSTNAME;
        private System.Windows.Forms.Label lblIPADD;
        private System.Windows.Forms.TextBox txtPORT;
        private System.Windows.Forms.TextBox txtHOSTNAME;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtSEND;
        private System.Windows.Forms.Button btnSEND;
        private System.Windows.Forms.Button btnSTART;
        private System.Windows.Forms.Button btnSTOP;
    }
}

