using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Sdp_Sarasavi
{
    public partial class USER_REGISTRATION : Form
    {
        public USER_REGISTRATION()
        {
            InitializeComponent();
        }

        private void USER_REGISTRATION_Load(object sender, EventArgs e)
        {

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm?", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
                
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            txtsname.Clear();
            txteno.Clear();
            txtsex.Clear();
            txtadres.Clear();
            txtnic.Clear();
            
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtsname.Text != "" && txteno.Text != "" && txtsex.Text != "" && txtadres.Text != "" && txtnic.Text != "")
            {
                string sname = txtsname.Text;
                string eno = txteno.Text;
                string ssex = txtsex.Text;
                string adres = txtadres.Text;
                Int64 Nic = Int64.Parse(txtnic.Text);
                

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=DESKTOP-TS98DKN\\SQLEXPRESS;database = Sarasavi;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText= "insert into studentregistration(studentname,enrollmentno,sex,Adress,NICno) values('" + sname+ "','" +eno+ "','" +ssex+ "','" +adres+ "',"+Nic+")";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            else
            {
                MessageBox.Show("Empty Fileds are not allowed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
