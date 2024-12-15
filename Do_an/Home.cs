using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CUOICUNG;
using Client;
namespace Do_an
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        private void Home_Load(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            CUOICUNG.Form1 form1 = new CUOICUNG.Form1();    
            form1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Client.Form1 form1 = new Client.Form1();
            form1.ShowDialog();
        }
    }
}
