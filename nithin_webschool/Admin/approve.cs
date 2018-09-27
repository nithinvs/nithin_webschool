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

namespace nithin_webschool.Admin
{
    public partial class approve : Form
    {
        //string s = nithin_webschool.Properties.Settings.Default.webschooldb;
        //DataTable dt1;
      //  string s = Properties.Settings.Default.webschooldb;
        int i,id;
       
        string s1 = "";
        string s2 = "";
        
        public approve()
        {
            InitializeComponent();
        }

      
       

        public void insert()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-H0LS289\\SQLEXPRESS;Initial Catalog=webschool_db;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "insert into tbl_login(rid,email,password) values (@id,@s1,@s2)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@s1", s1);
            cmd.Parameters.AddWithValue("@s2", s2);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-H0LS289\\SQLEXPRESS;Initial Catalog=webschool_db;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "update tbl_reg set status = 1 where rid = @i";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@i", i);
            int re = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

            if (re != 0)
            {
                MessageBox.Show("Success");

                con.Close();
                fillgrid();
                insert();
            }
            else
            {

                MessageBox.Show("Failed");
            }
        }



        private void approve_Load(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            //dataGridView1.Visible = false;
            fillgrid();
        }
        public void fillgrid()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-H0LS289\\SQLEXPRESS;Initial Catalog=webschool_db;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from tbl_reg where status = 0";
            cmd.CommandType = CommandType.Text;
            SqlDataReader rd= cmd.ExecuteReader();
            if (rd.HasRows)
            {
             
                DataTable dt = new DataTable();
                dt.Load(rd);
                dataGridView1.DataSource = dt;

                con.Close();
           dataGridView1.Visible = true;
            }
            else
            {
                con.Close();
                this.Hide();

                MessageBox.Show("No new users registered");

                adminpage ob = new adminpage();
                


                this.Hide();
                ob.Show();

            }

        

        }
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            i = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            s1 = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            s2 = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }
    }
}
