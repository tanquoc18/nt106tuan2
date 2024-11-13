namespace Do_an
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void lklblQuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QuenMK quenMK = new QuenMK();
            quenMK.ShowDialog();
        }

        private void lklblDangKi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DangKi dangKi = new DangKi();
            dangKi.ShowDialog();
        }

        Modify modify = new Modify();
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenTK = txtTenTaiKhoan.Text;
            string matkhau = txtMatKhau.Text;
            if (tenTK.Trim() == "") { MessageBox.Show("Vui lòng nhập lại tên tài khoản!", "Thông báo"); }
            else if (matkhau.Trim() == "") { MessageBox.Show("Vui lòng nhập lại mật khẩu!", "Thông báo"); }
            else
            {
                string query = "Select * from TaiKhoan where TenTaiKhoan = '" + tenTK + "' and MatKhau = '" + matkhau + "'";
                if (modify.TaiKhoans(query).Count != 0)
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Home home = new Home();
                    home.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e) { }
    }
}
