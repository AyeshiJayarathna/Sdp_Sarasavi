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
    public partial class VIEWBOOKS : Form
    {
        public VIEWBOOKS()
        {
            InitializeComponent();
        }

        private void VIEWBOOKS_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source= DESKTOP-TS98DKN\\SQLEXPRESS;database=Sarasavi;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "Select * from newbok";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }


        int bid;
        Int64 rawid;
            private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel2.Visible = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source= DESKTOP-TS98DKN\\SQLEXPRESS;database=Sarasavi;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "Select * from newbok where bid="+bid+"";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            rawid =Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

            txtbname.Text = ds.Tables[0].Rows[0][1].ToString();
            txtbauthor.Text = ds.Tables[0].Rows[0][2].ToString();
            txtbpub.Text = ds.Tables[0].Rows[0][3].ToString();
            txtbpdate.Text = ds.Tables[0].Rows[0][4].ToString();
            txtbprice.Text = ds.Tables[0].Rows[0][5].ToString();
            txtbquan.Text = ds.Tables[0].Rows[0][6].ToString();

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void txtbookname_TextChanged(object sender, EventArgs e)
        {
            if (txtbookname.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source= DESKTOP-TS98DKN\\SQLEXPRESS;database=Sarasavi;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "Select * from newbok where bname LIKE '"+txtbookname+"%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source= DESKTOP-TS98DKN\\SQLEXPRESS;database=Sarasavi;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "Select * from newbok";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            txtbookname.Clear();
            panel2.Visible = false;
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be updated,Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string bname = txtbname.Text;
                string bauthor = txtbauthor.Text;
                string bpublication = txtbpub.Text;
                string bdate = txtbpdate.Text;
                Int64 price = Int64.Parse(txtbprice.Text);
                Int64 quantity = Int64.Parse(txtbquan.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source= DESKTOP-TS98DKN\\SQLEXPRESS;database=Sarasavi;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "update newbok set bname='" + bname + "',bauthor='" + bauthor + "',bpub='" + bpublication + "',bpdate='" + bdate + "',bprice=" + price + ",bquan=" + quantity + " where bid=" + rawid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will Deleted,Confirm?", "Confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
               SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source= DESKTOP-TS98DKN\\SQLEXPRESS;database=Sarasavi;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "delete from newbok  where bid=" + rawid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
