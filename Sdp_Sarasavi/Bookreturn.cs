using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sdp_Sarasavi
{
    public partial class Bookreturn : Form
    {
        public Bookreturn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsearchus_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source =DESKTOP-TS98DKN\\SQLEXPRESS; database=Sarasavi;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from Ibook where enrollmentno ='" + txtenum.Text + "' and bookreturndate IS NULL";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DA.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Invalid ID or No issued book", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Bookreturn_Load(object sender, EventArgs e)
        {
            panel3.Visible = false;
            txtenum.Clear();
        }
        String bname;
        String bdate;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel3.Visible = true;
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                rowid = Int64.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                bname =dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                bdate = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            }
            txtbname.Text = bname;
            txtissue.Text = bdate;
        }

        private void btnretun_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source =DESKTOP-TS98DKN\\SQLEXPRESS; database=Sarasavi;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();

            cmd.CommandText = "update Ibook set bookreturndate ='" + dateTimePicker1.Text + "' where enrollmentno ='" + txtenum.Text + "'and id =" + rowid + "";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Book return success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Bookreturn_Load(this, null);

        }

        private void txtenum_TextChanged(object sender, EventArgs e)
        {
            if (txtenum.Text == "")
            {
                panel3.Visible = false;
                dataGridView1.DataSource = null;

            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            txtenum.Clear();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }
    }
}
