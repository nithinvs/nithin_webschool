using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nithin_webschool
{
    public partial class adminlogin : Form
    {
        public adminlogin()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            F1_welcome ob1 = new F1_welcome();
            this.Hide();
            ob1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="admin"&&textBox2.Text=="admin")
            {
                adminpage ob = new adminpage();
                this.Hide();
                ob.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password!!");
            }
        }
    }
}
