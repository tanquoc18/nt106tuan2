using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_an
{
    public partial class QuenMK : Form
    {
        public QuenMK()
        {
            InitializeComponent();
            lblKetQua.Text = "";
        }

        Modify modify = new Modify();

        private void btnLayLaiMatKhau_Click(object sender, EventArgs e)
        {
            string gmail = txtGMDangKi.Text;
            if (gmail == "")
            {
                MessageBox.Show("Vui lòng nhập gmail đăng kí!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string query = "Select * from TaiKhoan where Gmail = '" + gmail + "' ";
                if (modify.TaiKhoans(query).Count() != 0)
                {
                    lblKetQua.Text = "Mật khẩu: " + modify.TaiKhoans(query)[0].MatKhau;
                }
                else
                {
                    lblKetQua.Text = "Gmail này chưa được đăng kí!";
                }
            }
        }
    }
}
