using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nithin_webschool.New_User
{
    public partial class newuserhome : Form
    {
        public newuserhome()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            registration ob = new registration();
            this.Hide();
            ob.Show();
        }
    }
}
