using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace nithin_webschool.Student
{
    public partial class addfeedback : Form
    {
        string s = Properties.Settings.Default.webschooldb;
        public addfeedback()
        {
            InitializeComponent();
        }
        private void addfeed()
        {
            int re = 0;
            SqlConnection con = new SqlConnection(s);
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "insert into tbl_feedback (comments) values ('" + textBox1.Text + "')";
            cmd.CommandType = CommandType.Text;
            re = cmd.ExecuteNonQuery();
            if (re != 0)
            {
                MessageBox.Show("Thank You!","Success");
            }
            else
            {
                MessageBox.Show("Something went wrong!","Failed");
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addfeed();
            this.Hide();
            studenthome ob = new studenthome();
            ob.Show();
            
        }
    }
}
