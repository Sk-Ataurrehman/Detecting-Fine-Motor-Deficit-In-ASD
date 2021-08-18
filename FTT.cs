using System;
using System.Drawing;
using System.Windows.Forms;

namespace Motor_Deficit_Detection
{
    public partial class FTT : Form
    {
        public static int count = 0;
        Home h1 = new Home();
        public FTT()
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

        Random x = new Random();
        int j = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            count++;
            Point pt = new Point(
            int.Parse(x.Next(500).ToString()),
            int.Parse(x.Next(300).ToString())
            );
            button1.Location = pt;
            Control ctrl = ((Control)sender);
            switch (ctrl.BackColor.Name)
            {
                case "Red":
                    ctrl.BackColor = Color.Yellow;
                    break;
                case "Black":
                    ctrl.BackColor = Color.White;
                    break;
                case "White":
                    ctrl.BackColor = Color.Red;
                    break;
                case "Yellow":
                    ctrl.BackColor = Color.Purple;
                    break;
                default:
                    ctrl.BackColor = Color.Red;
                    break;
            }
            textBox2.Text = count.ToString();
        }

        int i = 60;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i--;
            textBox1.Text = i.ToString() + " seconds";
            if (i==0)
            {
                timer1.Stop();
                Home.tap = "1";
                MessageBox.Show("Success!");
                this.Close();
                h1.Show();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            h1.Show();
        }
    }
}
