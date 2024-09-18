using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tuan2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double so1 = 0, so2 = 0;
        double kq = 0;
        char pt;

        private void khong_Click(object sender, EventArgs e)
        {
            hienthi.Text += "0";
        }

        private void mot_Click(object sender, EventArgs e)
        {
            hienthi.Text += "1";
        }

        private void hai_Click(object sender, EventArgs e)
        {
            hienthi.Text += "2";
        }

        private void ba_Click(object sender, EventArgs e)
        {
            hienthi.Text += "3";
        }

        private void bon_Click(object sender, EventArgs e)
        {
            hienthi.Text += "4";
        }

        private void nam_Click(object sender, EventArgs e)
        {
            hienthi.Text += "5";
        }

        private void sau_Click(object sender, EventArgs e)
        {
            hienthi.Text += "6";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hienthi.Text += "7";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hienthi.Text += "8";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pt = '+';
            so1 = double.Parse(hienthi.Text);
            hienthi.Text = "";
        }

        private void tru_Click(object sender, EventArgs e)
        {
            pt = '-';
            so1 = double.Parse(hienthi.Text);
            hienthi.Text = "";
        }

        private void nhan_Click(object sender, EventArgs e)
        {
            pt = '*';
            so1 = double.Parse(hienthi.Text);
            hienthi.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pt = '/';
            so1 = double.Parse(hienthi.Text);
            hienthi.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            hienthi.Clear();
        }

        private void cham_Click(object sender, EventArgs e)
        {
            hienthi.Text += ".";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hienthi.Text += "9";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                so2 = double.Parse(hienthi.Text);
                tinh(so1, so2, pt);
            }
            catch(Exception ex)
            {
                MessageBox.Show("xoa va nhap lai");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (hienthi.Text.Length > 0)
            {
                hienthi.Text = hienthi.Text.Substring(0, hienthi.Text.Length - 1);
            }
            if (hienthi.Text == "")
            {
                hienthi.Text = "";
            }
        }
        private void tinh(double n1, double n2, char pt)
        {
            double kq = 0;
            switch(pt)
            {

                case '+':
                    kq = n1 + n2;
                    break;
                case '-':
                    kq = n1 - n2;
                    break;
                case '*':
                    kq = n1 * n2;
                    break;
                case '/':
                    if(n2==0)
                    {
                        MessageBox.Show("khong chia duoc so 0");
                        return;
                    }
                    else
                    {
                        kq = n1 / n2;
                    }
                    break;
                    

            }
            hienthi.Text = kq.ToString();
        }
    }
}
