using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace nithin_webschool
{
    public partial class adminpage : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-H0LS289\\SQLEXPRESS;Initial Catalog=webschool_db;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();

        public adminpage()
        {
            InitializeComponent();
        }

        private void adminpage_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
       
            Admin.approve ob = new Admin.approve();
            this.Hide();
            ob.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Admin.viewstudents ob = new Admin.viewstudents();
            this.Hide();
            ob.Show();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Admin.viewstudents ob = new Admin.viewstudents();
            this.Hide();
            ob.Show();
        }
    }
}
