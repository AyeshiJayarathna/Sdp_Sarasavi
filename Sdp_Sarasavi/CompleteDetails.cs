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
    public partial class CompleteDetails : Form
    {
        public CompleteDetails()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CompleteDetails_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source =DESKTOP-TS98DKN\\SQLEXPRESS; database=Sarasavi;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from Ibook where bookreturndate is null";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DA.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            cmd.CommandText = "select * from Ibook where bookreturndate is not null";
            SqlDataAdapter DA1 = new SqlDataAdapter(cmd);
            DataSet ds1= new DataSet();
            DA1.Fill(ds1);
            dataGridView2.DataSource = ds1.Tables[0];

        }

    }
}
