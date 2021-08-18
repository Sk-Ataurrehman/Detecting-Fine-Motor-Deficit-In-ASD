using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Motor_Deficit_Detection
{
    public partial class login : Form
    {
        public static string name = "";
        public static string gender = "";
        public static string age = "";

        public login()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Please, fill all fields!");
            }
            else
            {
                name = textBox1.Text;
                gender = textBox2.Text;
                age = textBox3.Text;
                Home h1 = new Home();
                this.Hide();
                h1.Show();
            }
        }
    }
}
