using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Motor_Deficit_Detection
{
    public partial class report : Form
    {
        int avg;
        int min;
        int max;
        int count;
        public report()
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Home h1 = new Home();
            this.Hide();
            h1.Show();
        }

        private void report_Load(object sender, EventArgs e)
        {
            label9.Text = login.name;
            label10.Text = login.gender;
            label11.Text = login.age;

            if (Home.chat == "1")
            {
                label14.Text = "Completed!";
                label14.BackColor = Color.Green;
            }
            else
            {
                label14.Text = "Not Completed!";
                label14.BackColor = Color.Red;
            }

            if (Home.tap == "1")
            {
                label13.Text = "Completed!";
                label13.BackColor = Color.Green;
            }
            else
            {
                label13.Text = "Not Completed!";
                label13.BackColor = Color.Red;
            }

            if (Home.block == "1")
            {
                label12.Text = "Completed!";
                label12.BackColor = Color.Green;
            }
            else
            {
                label12.Text = "Not Completed!";
                label12.BackColor = Color.Red;
            }
            var DBPath = Application.StartupPath + "\\ASD.mdb";
            var DBControl = Application.StartupPath + "\\Control.mdb";
            OleDbConnection conn;
            OleDbConnection conn1;

            conn = new OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + DBPath);
            conn.Open();
            
            conn1 = new OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + DBControl);
            conn1.Open();

            string command1 = "select Avg(Taps) from ControlGroup";
            OleDbCommand cmdd1 = new OleDbCommand(command1, conn1);
            OleDbDataReader reader = cmdd1.ExecuteReader();
            if (reader.Read())
            {
                string result = reader.GetValue(0).ToString();
                double a = Double.Parse(result);
                avg = (int)a;
            }

            string commandmin = "select Min(Taps) from ControlGroup";
            OleDbCommand cmddmin = new OleDbCommand(commandmin, conn1);
            OleDbDataReader readermin = cmddmin.ExecuteReader();
            if (readermin.Read())
            {
                string result = readermin.GetValue(0).ToString();
                double a = Double.Parse(result);
                min = (int)a;
            }

            string commandmax = "select Max(Taps) from ControlGroup";
            OleDbCommand cmddmax = new OleDbCommand(commandmax, conn1);
            OleDbDataReader readermax = cmddmax.ExecuteReader();
            if (readermax.Read())
            {
                string result = readermax.GetValue(0).ToString();
                double a = Double.Parse(result);
                max = (int)a;
            }

            string commandc = "select Count(Taps) from ControlGroup";
            OleDbCommand cmddc = new OleDbCommand(commandc, conn1);
            OleDbDataReader readerc = cmddc.ExecuteReader();
            if (readerc.Read())
            {
                string result = readerc.GetValue(0).ToString();
                double a = Double.Parse(result);
                count = (int)a;
            }

            double acc = ((double)FTT.count / (double)avg * 100);
            int ab = (int) acc;            
            label20.Text = ab.ToString() + "%";
            label26.Text = FTT.count.ToString();

            if (FTT.count >= min && FTT.count <= max)
            {
                label22.Text = "Control";
                label22.ForeColor = Color.Green;
                label20.ForeColor = Color.Green;
            }
            else {
                label22.Text = "Target";
                label22.ForeColor = Color.Red;
                label20.ForeColor = Color.Red;
            }

            string command = "insert into data(Name,Gender,Age,Chatbot,Finger,Taps,Accuracy,Block) values('" + login.name + "', '" + login.gender + "','" + login.age + "','" + label14.Text + "','" + label13.Text + "','" + FTT.count + "','" + label20.Text + "','" + label12.Text + "') ";
            OleDbCommand cmdd = new OleDbCommand(command, conn);
            cmdd.ExecuteNonQuery();
        }
    }
}
