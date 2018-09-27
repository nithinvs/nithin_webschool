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

namespace nithin_webschool.Admin
{
    public partial class updatestudent : Form
    {
        int i;
        string s = Properties.Settings.Default.webschooldb;
        public updatestudent()
        {
            InitializeComponent();
        }

        private void updatestudent_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'webschool_dbDataSet1.tbl_reg' table. You can move, or remove it, as needed.
            this.tbl_regTableAdapter.Fill(this.webschool_dbDataSet1.tbl_reg);

        }
        public void delete()
        {
            if (MessageBox.Show("Do you want to continue", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(s);
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "delete from tbl_reg where rid = @i";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@i", i);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            delete();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            i = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
