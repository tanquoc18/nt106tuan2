namespace Do_an
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            picbTenDangNhap = new PictureBox();
            picbMatKhau = new PictureBox();
            txtTenTaiKhoan = new TextBox();
            txtMatKhau = new TextBox();
            btnDangNhap = new Button();
            lklblQuenMatKhau = new LinkLabel();
            lklblDangKi = new LinkLabel();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picbTenDangNhap).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picbMatKhau).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // picbTenDangNhap
            // 
            picbTenDangNhap.BackColor = Color.White;
            picbTenDangNhap.Image = (Image)resources.GetObject("picbTenDangNhap.Image");
            picbTenDangNhap.Location = new Point(313, 212);
            picbTenDangNhap.Name = "picbTenDangNhap";
            picbTenDangNhap.Size = new Size(39, 34);
            picbTenDangNhap.SizeMode = PictureBoxSizeMode.StretchImage;
            picbTenDangNhap.TabIndex = 1;
            picbTenDangNhap.TabStop = false;
            // 
            // picbMatKhau
            // 
            picbMatKhau.BackColor = Color.FromArgb(16, 22, 34);
            picbMatKhau.Image = (Image)resources.GetObject("picbMatKhau.Image");
            picbMatKhau.Location = new Point(313, 277);
            picbMatKhau.Name = "picbMatKhau";
            picbMatKhau.Size = new Size(39, 34);
            picbMatKhau.SizeMode = PictureBoxSizeMode.StretchImage;
            picbMatKhau.TabIndex = 2;
            picbMatKhau.TabStop = false;
            // 
            // txtTenTaiKhoan
            // 
            txtTenTaiKhoan.BackColor = Color.White;
            txtTenTaiKhoan.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTenTaiKhoan.ForeColor = Color.Black;
            txtTenTaiKhoan.Location = new Point(376, 212);
            txtTenTaiKhoan.Name = "txtTenTaiKhoan";
            txtTenTaiKhoan.PlaceholderText = "Tên đăng nhập";
            txtTenTaiKhoan.Size = new Size(307, 34);
            txtTenTaiKhoan.TabIndex = 3;
            // 
            // txtMatKhau
            // 
            txtMatKhau.BackColor = Color.White;
            txtMatKhau.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMatKhau.ForeColor = Color.Black;
            txtMatKhau.Location = new Point(376, 277);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.PlaceholderText = "Mật khẩu";
            txtMatKhau.Size = new Size(307, 34);
            txtMatKhau.TabIndex = 4;
            // 
            // btnDangNhap
            // 
            btnDangNhap.BackColor = Color.White;
            btnDangNhap.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDangNhap.ForeColor = Color.Black;
            btnDangNhap.Location = new Point(390, 448);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(209, 60);
            btnDangNhap.TabIndex = 5;
            btnDangNhap.Text = "Đăng Nhập ";
            btnDangNhap.UseVisualStyleBackColor = false;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // lklblQuenMatKhau
            // 
            lklblQuenMatKhau.AutoSize = true;
            lklblQuenMatKhau.BackColor = Color.White;
            lklblQuenMatKhau.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lklblQuenMatKhau.LinkColor = Color.Black;
            lklblQuenMatKhau.Location = new Point(414, 374);
            lklblQuenMatKhau.Name = "lklblQuenMatKhau";
            lklblQuenMatKhau.Size = new Size(159, 28);
            lklblQuenMatKhau.TabIndex = 6;
            lklblQuenMatKhau.TabStop = true;
            lklblQuenMatKhau.Text = "Quên mật khẩu? ";
            lklblQuenMatKhau.LinkClicked += lklblQuenMatKhau_LinkClicked;
            // 
            // lklblDangKi
            // 
            lklblDangKi.AutoSize = true;
            lklblDangKi.BackColor = Color.White;
            lklblDangKi.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lklblDangKi.LinkColor = Color.Black;
            lklblDangKi.Location = new Point(447, 549);
            lklblDangKi.Name = "lklblDangKi";
            lklblDangKi.Size = new Size(93, 28);
            lklblDangKi.TabIndex = 7;
            lklblDangKi.TabStop = true;
            lklblDangKi.Text = "Đăng Kí ";
            lklblDangKi.LinkClicked += lklblDangKi_LinkClicked;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(390, 28);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(209, 165);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AcceptButton = btnDangNhap;
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(972, 665);
            Controls.Add(pictureBox1);
            Controls.Add(lklblDangKi);
            Controls.Add(lklblQuenMatKhau);
            Controls.Add(btnDangNhap);
            Controls.Add(txtMatKhau);
            Controls.Add(txtTenTaiKhoan);
            Controls.Add(picbMatKhau);
            Controls.Add(picbTenDangNhap);
            Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Đăng Nhập ";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)picbTenDangNhap).EndInit();
            ((System.ComponentModel.ISupportInitialize)picbMatKhau).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox picbTenDangNhap;
        private PictureBox picbMatKhau;
        private TextBox txtTenTaiKhoan;
        private TextBox txtMatKhau;
        private Button btnDangNhap;
        private LinkLabel lklblQuenMatKhau;
        private LinkLabel lklblDangKi;
        private PictureBox pictureBox1;
    }
}
