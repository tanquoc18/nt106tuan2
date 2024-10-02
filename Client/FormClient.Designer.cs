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
            this.btnCONNECT = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ListMessages);
            this.groupBox1.Location = new System.Drawing.Point(28, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 272);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Messages: ";
            // 
            // ListMessages
            // 
            this.ListMessages.FormattingEnabled = true;
            this.ListMessages.ItemHeight = 23;
            this.ListMessages.Location = new System.Drawing.Point(11, 28);
            this.ListMessages.Name = "ListMessages";
            this.ListMessages.Size = new System.Drawing.Size(325, 234);
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
            this.groupBox2.Location = new System.Drawing.Point(402, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(534, 286);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sever Infor: ";
            // 
            // lblPORT
            // 
            this.lblPORT.Location = new System.Drawing.Point(22, 217);
            this.lblPORT.Name = "lblPORT";
            this.lblPORT.Size = new System.Drawing.Size(147, 41);
            this.lblPORT.TabIndex = 5;
            this.lblPORT.Text = "Port: ";
            this.lblPORT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHOSTNAME
            // 
            this.lblHOSTNAME.Location = new System.Drawing.Point(22, 135);
            this.lblHOSTNAME.Name = "lblHOSTNAME";
            this.lblHOSTNAME.Size = new System.Drawing.Size(147, 41);
            this.lblHOSTNAME.TabIndex = 4;
            this.lblHOSTNAME.Text = "Host Name: ";
            this.lblHOSTNAME.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHOSTNAME.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblIPADD
            // 
            this.lblIPADD.Location = new System.Drawing.Point(22, 42);
            this.lblIPADD.Name = "lblIPADD";
            this.lblIPADD.Size = new System.Drawing.Size(147, 41);
            this.lblIPADD.TabIndex = 3;
            this.lblIPADD.Text = "IP Address:";
            this.lblIPADD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPORT
            // 
            this.txtPORT.Location = new System.Drawing.Point(175, 223);
            this.txtPORT.Name = "txtPORT";
            this.txtPORT.Size = new System.Drawing.Size(340, 30);
            this.txtPORT.TabIndex = 2;
            // 
            // txtHOSTNAME
            // 
            this.txtHOSTNAME.Location = new System.Drawing.Point(175, 141);
            this.txtHOSTNAME.Name = "txtHOSTNAME";
            this.txtHOSTNAME.Size = new System.Drawing.Size(340, 30);
            this.txtHOSTNAME.TabIndex = 1;
            this.txtHOSTNAME.TextChanged += new System.EventHandler(this.txtHOSTNAME_TextChanged);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(175, 48);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(340, 30);
            this.txtIP.TabIndex = 0;
            // 
            // txtSEND
            // 
            this.txtSEND.Location = new System.Drawing.Point(40, 303);
            this.txtSEND.Multiline = true;
            this.txtSEND.Name = "txtSEND";
            this.txtSEND.Size = new System.Drawing.Size(228, 71);
            this.txtSEND.TabIndex = 2;
            // 
            // btnSEND
            // 
            this.btnSEND.Location = new System.Drawing.Point(274, 303);
            this.btnSEND.Name = "btnSEND";
            this.btnSEND.Size = new System.Drawing.Size(90, 71);
            this.btnSEND.TabIndex = 3;
            this.btnSEND.Text = "SEND";
            this.btnSEND.UseVisualStyleBackColor = true;
            this.btnSEND.Click += new System.EventHandler(this.btnSEND_Click);
            // 
            // btnCONNECT
            // 
            this.btnCONNECT.Location = new System.Drawing.Point(587, 323);
            this.btnCONNECT.Name = "btnCONNECT";
            this.btnCONNECT.Size = new System.Drawing.Size(219, 49);
            this.btnCONNECT.TabIndex = 4;
            this.btnCONNECT.Text = "CONNECT ";
            this.btnCONNECT.UseVisualStyleBackColor = true;
            this.btnCONNECT.Click += new System.EventHandler(this.btnCONNECT_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 384);
            this.Controls.Add(this.btnCONNECT);
            this.Controls.Add(this.btnSEND);
            this.Controls.Add(this.txtSEND);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "CLIENT";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtPORT;
        private System.Windows.Forms.TextBox txtHOSTNAME;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label lblPORT;
        private System.Windows.Forms.Label lblHOSTNAME;
        private System.Windows.Forms.Label lblIPADD;
        private System.Windows.Forms.TextBox txtSEND;
        private System.Windows.Forms.ListBox ListMessages;
        private System.Windows.Forms.Button btnSEND;
        private System.Windows.Forms.Button btnCONNECT;
    }
}

