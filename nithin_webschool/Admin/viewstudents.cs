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
    public partial class viewstudents : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-H0LS289\\SQLEXPRESS;Initial Catalog=webschool_db;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        public viewstudents()
        {
            InitializeComponent();
        }
        int id;
        string s;
        public void Fillgrid()
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from tbl_reg where status=1";
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            dataGridView1.Visible = true;
        }
        public void Showdata()
        {
            DateTime dt;
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select name, email, address, gender, dob, phone, batch from tbl_reg where rid=@id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader rd = cmd.ExecuteReader();
            cmd.Parameters.Clear();
            if (rd.Read())
            {
                lbl_name.Text = rd[0].ToString();
                lbl_email.Text = rd[1].ToString();
                lbl_address.Text = rd[2].ToString();
                lbl_gender.Text = rd[3].ToString();
                //s= rd[4].ToString();
                dt = Convert.ToDateTime(rd[4]);
                //dt = dt.
                s = dt.ToShortDateString();
                lbl_dob.Text = s;
                lbl_phone.Text = rd[5].ToString();
                lbl_batch.Text = rd[6].ToString();
            }
            else
            {
                MessageBox.Show("Something went wrong!", "Error");
            }
            con.Close();
            panel1.Visible = true;
        }

        private void viewstudents_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            dataGridView1.Visible = false;
            Fillgrid();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            Showdata();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }
    }
}
