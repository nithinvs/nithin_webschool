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
    public partial class registration : Form
    {
        public registration()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-H0LS289\\SQLEXPRESS;Initial Catalog=webschool_db;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            F1_welcome ob = new F1_welcome();
            this.Hide();
            ob.Show();
        }
        

        private void rb_male_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tb_phone_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            if(rb_male.Checked)
            {
                label2.Text = rb_male.Text;
            }
            else if(rb_female.Checked)
            {
                label2.Text = rb_female.Text;

            }
            else if(rb_others.Checked)
            {
                label2.Text = rb_others.Text;
            }
            if (tb_pass.Text == tb_cnfpass.Text)
            {
                int re = 0;
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "insert into tbl_reg(name,email,address,dob,gender,phone,batch,password) values ('" + tb_name.Text + "','" + tb_email.Text + "','" + tb_address.Text + "','" + Convert.ToDateTime(dateTimePicker1.Text) + "','" + label2.Text + "','" +tb_phone.Text+ "','" + comboBox1.Text + "','" + tb_pass.Text + "')";
                cmd.CommandType = CommandType.Text;
                re = cmd.ExecuteNonQuery();
                if(re!=0)
                {
                    MessageBox.Show("Registration Successfull. We will notify you when the Admin confirms your registration","Success");
                    //panel1.Visible = true;
                }
                con.Close();
            }

            else
            {
                MessageBox.Show("Password mismatch !!","Failed");
                //label3.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //panel1.Visible = false;
        }
    }
}
