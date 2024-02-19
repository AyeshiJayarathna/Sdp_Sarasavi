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

namespace Sdp_Sarasavi
{
    public partial class Bookregistration : Form
    {
        public Bookregistration()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtBOOKNAME.Text != "" && txtAUTHOR.Text != "" && txtPUBLICATION.Text !="" && txtPRICE.Text != "" && txtQUAN.Text != "")
            {
                string bname = txtBOOKNAME.Text;
                string bauthor = txtAUTHOR.Text;
                string publication = txtPUBLICATION.Text;
                string bpdate = dateTimePicker1.Text;
                Int64 price = Int64.Parse(txtPRICE.Text);
                Int64 quantity = Int64.Parse(txtQUAN.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=DESKTOP-TS98DKN\\SQLEXPRESS ;database = Sarasavi;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "insert into newbok(bname,bauthor,bpub,bpdate,bprice,bquan) values('" + bname + "','" + bauthor + "','" + publication + "','" + bpdate + "'," + price + "," + quantity + ")";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBOOKNAME.Clear();
                txtAUTHOR.Clear();
                txtPUBLICATION.Clear();
                txtPRICE.Clear();
                txtQUAN.Clear();
            }
            else
            {
                MessageBox.Show("Empty Fileds are not allowed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("THIS WILL DELETE YOUR UNSAVED DATA","ARE YOU SURE?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void txtBOOKNAME_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
