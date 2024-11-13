using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions; 

namespace Do_an
{
    public partial class DangKi : Form
    {
        public DangKi()
        {
            InitializeComponent();
        }

        public bool CheckTaiKhoan(string taikhoan)
        {
            return Regex.IsMatch(taikhoan, "^[a-zA-Z0-9]{6,25}$");
        }

        public bool CheckMatKhau(string matkhau)
        {
            return Regex.IsMatch(matkhau, @"^[a-zA-Z0-9!@#\$%\^&\*\(\)_\+\-=\{\}\[\]:;""'<>,\.\?/\\|`~]{6,25}");
        }

        public bool CheckGmail(string gmail)
        {
            return Regex.IsMatch(gmail, @"^[a-zA-Z0-9._%+-]{3,20}@gmail\.com$");
        }

        Modify modify = new Modify();
        private void btnDangKi_Click(object sender, EventArgs e)
        {
            string tentk = txtTenTaiKhoan.Text;
            string matkhau = txtMatKhau.Text;
            string xnmatkhau = txtXacNhanMatKhau.Text;
            string gmail = txtgm.Text;

            if (!CheckTaiKhoan(tentk))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản từ 6 đến 25 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!CheckMatKhau(matkhau))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu từ 6 đến 25 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (xnmatkhau != matkhau)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp, vui lòng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!CheckGmail(gmail))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng Gmail!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (modify.TaiKhoans("Select * from TaiKhoan where Gmail = '" + gmail + "'").Count() > 0)
            {
                MessageBox.Show("Gmail đã được đăng kí!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string query = "Insert into TaiKhoan values ('" + tentk + "', '" + matkhau + "', '" + gmail + "')";
                modify.Command(query);
                if (MessageBox.Show("Đăng Ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
