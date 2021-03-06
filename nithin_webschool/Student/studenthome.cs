﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace nithin_webschool.Student
{
    public partial class studenthome : Form
    {
        //string name1;
        int rid;
        
        string s;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-H0LS289\\SQLEXPRESS;Initial Catalog=webschool_db;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        public studenthome()
        {
            InitializeComponent();
        }
        public studenthome(string name, string id)
        {
            InitializeComponent();
            label2.Text = name;
            rid = Convert.ToInt32(id);

        }
        public void Getdata()
        {
            DateTime dt;
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select name, email, address, gender, dob, phone, batch from tbl_reg where rid=@rid";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@rid", rid);
            SqlDataReader rd = cmd.ExecuteReader();
            cmd.Parameters.Clear();
            if(rd.Read())
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
        
        

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            F1_welcome ob = new F1_welcome();
            this.Hide();
            ob.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            F1_welcome ob = new F1_welcome();
            this.Hide();
            ob.Show();
               
        }

        private void studenthome_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Getdata();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addfeedback ob = new addfeedback();
            this.Hide();
            ob.Show();
        }
    }
}
