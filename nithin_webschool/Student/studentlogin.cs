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
    public partial class studentlogin : Form
    {
        
       // string s = Properties.Settings.Default
        public studentlogin()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-H0LS289\\SQLEXPRESS;Initial Catalog=webschool_db;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        string id,name;

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select rid from tbl_login where email = '"+textBox1.Text+"' and password = '"+textBox2.Text+"'";
            cmd.CommandType = CommandType.Text;
            SqlDataReader rd = cmd.ExecuteReader();

            if(rd.Read())
            {
                id = rd[0].ToString();
                con.Close();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "select name from tbl_reg where rid = @id";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader rd1 = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                if(rd1.Read())
                {
                    name = rd1[0].ToString();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Something went wrong !", "Error");
                    con.Close();
                }
                studenthome ob = new studenthome(name,id);
                this.Hide();
                ob.Show();
            }
            else
            {
                MessageBox.Show("The email or password entered is incorrect", "Login Failed");
                con.Close();
            }

        }
    }
}
