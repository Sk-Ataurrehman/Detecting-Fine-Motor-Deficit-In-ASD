using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace Motor_Deficit_Detection
{
    public partial class Chat : Form
    {
        public Chat()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;
            this.Hide();
            Home h1 = new Home();
            h1.Show();
        }

        private void Chat_Load(object sender, EventArgs e)
        {
            label7.Visible = false;
            textBox3.Visible = false;
            label8.Visible = false;
            textBox4.Visible = false;
            voice(label5.Text);
            timer1.Enabled = true;
        }

        public void voice(String lbl)
        {
            string toSpeak = lbl;
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            speechSynthesizer.Speak(toSpeak);
            speechSynthesizer.Dispose();
        }

        int i = 10;
        String name;
        Home h1 = new Home();
        private void timer1_Tick(object sender, EventArgs e)
        {
            i--;
            textBox2.Text = i.ToString() + " seconds";
            if (i == 0)
            {
                timer1.Stop();
                if (textBox1.Text == "")
                {
                    MessageBox.Show("You have not filled the information! Try Again.");
                    this.Close();
                    h1.Show();
                }
                else
                {
                    timer1.Enabled = false;
                    name = textBox1.Text;
                    label7.Visible = true;
                    textBox3.Visible = true;
                    textBox1.Enabled = false;
                    label7.Text = name + ", " + label7.Text;
                    voice(label7.Text);
                    timer2.Enabled = true;
                }
            }
        }

        int j = 10;
        private void timer2_Tick(object sender, EventArgs e)
        {
            j--;
            textBox2.Text = j.ToString() + " seconds";
            if (j == 0)
            {
                timer2.Stop();
                if (textBox3.Text == "")
                {
                    MessageBox.Show("You have not filled the information! Try Again.");
                    this.Close();
                    h1.Show();
                }
                else
                {
                    timer2.Enabled = false;
                    name = textBox1.Text;
                    label8.Visible = true;
                    textBox4.Visible = true;
                    textBox3.Enabled = false;
                    label8.Text = name + ", " + label8.Text;
                    voice(label8.Text);
                    timer3.Enabled = true;
                }
            }
        }

        int k = 10;
        private void timer3_Tick(object sender, EventArgs e)
        {
            k--;
            textBox2.Text = k.ToString() + " seconds";
            if (k == 0)
            {
                timer3.Stop();
                if (textBox4.Text == "")
                {
                    MessageBox.Show("You have not filled the information! Try Again.");
                    this.Close();
                    h1.Show();
                }
                else
                {
                    timer1.Enabled = false;
                    timer2.Enabled = false;
                    timer3.Enabled = false;
                    Home.chat = "1";
                    MessageBox.Show("Success!");
                    this.Close();
                    h1.Show();
                }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                timer1.Enabled = false;
                name = textBox1.Text;
                label7.Visible = true;
                textBox3.Visible = true;
                textBox1.Enabled = false;
                label7.Text = name + ", " + label7.Text;
                voice(label7.Text);
                timer2.Enabled = true;
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                timer2.Enabled = false;
                name = textBox1.Text;
                label8.Visible = true;
                textBox4.Visible = true;
                textBox3.Enabled = false;
                label8.Text = name + ", " + label8.Text;
                voice(label8.Text);
                timer3.Enabled = true;
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Home.chat = "1";
                MessageBox.Show("Success!");
                this.Close();
                h1.Show();
            }
        }
    }
}
