using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Motor_Deficit_Detection
{
    public partial class Home : Form
    {
        public static string face = "0";
        public static string chat = "0";
        public static string tap = "0";
        public static string block = "0";
        public Home()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            FTT f1 = new FTT();
            f1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Chat c1 = new Chat();
            c1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Block b1 = new Block();
            b1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            report r1 = new report();
            if (Home.tap == "1" && Home.block == "1" && Home.chat == "1") { 
                this.Hide();
                r1.Show();
            }
            else
              MessageBox.Show("Complete all the Tasks!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            about a1 = new about();
            a1.Show();
        }
    }
}