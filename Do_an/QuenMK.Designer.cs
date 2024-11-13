namespace Do_an
{
    partial class QuenMK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuenMK));
            btnLayLaiMatKhau = new Button();
            lblGMDangKi = new Label();
            lblKetQua = new Label();
            txtGMDangKi = new TextBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnLayLaiMatKhau
            // 
            btnLayLaiMatKhau.BackColor = Color.White;
            btnLayLaiMatKhau.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLayLaiMatKhau.ForeColor = Color.Black;
            btnLayLaiMatKhau.Location = new Point(248, 461);
            btnLayLaiMatKhau.Name = "btnLayLaiMatKhau";
            btnLayLaiMatKhau.Size = new Size(274, 73);
            btnLayLaiMatKhau.TabIndex = 1;
            btnLayLaiMatKhau.Text = "Lấy Lại Mật Khẩu ";
            btnLayLaiMatKhau.UseVisualStyleBackColor = false;
            btnLayLaiMatKhau.Click += btnLayLaiMatKhau_Click;
            // 
            // lblGMDangKi
            // 
            lblGMDangKi.AutoSize = true;
            lblGMDangKi.BackColor = Color.White;
            lblGMDangKi.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGMDangKi.ForeColor = Color.Black;
            lblGMDangKi.Location = new Point(156, 252);
            lblGMDangKi.Name = "lblGMDangKi";
            lblGMDangKi.Size = new Size(176, 31);
            lblGMDangKi.TabIndex = 2;
            lblGMDangKi.Text = "Gmail đăng kí: ";
            lblGMDangKi.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblKetQua
            // 
            lblKetQua.BackColor = Color.White;
            lblKetQua.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblKetQua.ForeColor = Color.Black;
            lblKetQua.Location = new Point(162, 330);
            lblKetQua.Name = "lblKetQua";
            lblKetQua.Size = new Size(434, 40);
            lblKetQua.TabIndex = 3;
            lblKetQua.Text = "Mật Khẩu: ";
            lblKetQua.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtGMDangKi
            // 
            txtGMDangKi.BackColor = Color.White;
            txtGMDangKi.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtGMDangKi.ForeColor = Color.Black;
            txtGMDangKi.Location = new Point(338, 249);
            txtGMDangKi.Name = "txtGMDangKi";
            txtGMDangKi.Size = new Size(258, 38);
            txtGMDangKi.TabIndex = 4;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(282, 44);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(211, 167);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // QuenMK
            // 
            AcceptButton = btnLayLaiMatKhau;
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(790, 653);
            Controls.Add(pictureBox1);
            Controls.Add(txtGMDangKi);
            Controls.Add(lblKetQua);
            Controls.Add(lblGMDangKi);
            Controls.Add(btnLayLaiMatKhau);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "QuenMK";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnLayLaiMatKhau;
        private Label lblGMDangKi;
        private Label lblKetQua;
        private TextBox txtGMDangKi;
        private PictureBox pictureBox1;
    }
}