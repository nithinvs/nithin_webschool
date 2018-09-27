using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nithin_webschool.Admin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fillgrid();
        }

        public void fillgrid()
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=webschool_db;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from tbl_reg where status = 0";
            cmd.CommandType = CommandType.Text;
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
              
                DataTable dt = new DataTable();
                dt.Load(rd);

                MessageBox.Show(dt.ToString());
              dataGridView1.DataSource = dt;

                con.Close();
            
            }
            else
            {
                con.Close();

                MessageBox.Show("No new users registered");

                adminpage ob = new adminpage();
                this.Hide();
                ob.Show();

            }



        }

    }
}
