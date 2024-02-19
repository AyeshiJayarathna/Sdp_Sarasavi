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
    public partial class user_details : Form
    {
        public user_details()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtsearcheno_TextChanged(object sender, EventArgs e)
        {
            if (txtsearcheno.Text != "")
            {
                label1.Visible = false;
                Image image = Image.FromFile("C:/Users/pc/Desktop/sdphoto/global-223_256.GIF");
                pictureBox1.Image = image;


                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=DESKTOP-TS98DKN\\SQLEXPRESS;database = Sarasavi;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from studentregistration where enrollmentno LIKE '"+txtsearcheno.Text+"%'";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];
            }
            else
            {
                label1.Visible = true;
                Image image = Image.FromFile("C:/Users/pc/Desktop/sdphoto/user1.PNG");
                pictureBox1.Image = image;


                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=DESKTOP-TS98DKN\\SQLEXPRESS;database = Sarasavi;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from studentregistration";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                dataGridView1.DataSource = DS.Tables[0];
            }
        }

        private void user_details_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source=DESKTOP-TS98DKN\\SQLEXPRESS;database = Sarasavi;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from studentregistration";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            dataGridView1.DataSource = DS.Tables[0];
        }
        int bid;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value!= null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel2.Visible = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source=DESKTOP-TS98DKN\\SQLEXPRESS;database = Sarasavi;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from studentregistration where studentid="+bid+"";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            rowid = Int64.Parse(DS.Tables[0].Rows[0][0].ToString());
            txtsname.Text = DS.Tables[0].Rows[0][1].ToString();
            txteno.Text = DS.Tables[0].Rows[0][2].ToString();
            txtsex.Text = DS.Tables[0].Rows[0][3].ToString();
            txtaddres.Text = DS.Tables[0].Rows[0][4].ToString();
            txtnic.Text = DS.Tables[0].Rows[0][5].ToString();
          
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            string sname = txtsname.Text;
            string eno = txteno.Text;
            string sex = txtsex.Text;
            string adress = txtaddres.Text;
            Int64 nic = Int64.Parse(txtnic.Text);

            if (MessageBox.Show("Data will be Updedated.Confirm?", "succses", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=DESKTOP-TS98DKN\\SQLEXPRESS;database = Sarasavi;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "Update studentregistration set studentname='" + sname + "' ,enrollmentno='" + eno + "' ,sex='" + sex + "' ,Adress='" + adress + "' ,NICno=" + nic + " where studentid=" + bid + "";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                user_details_Load(this, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            user_details_Load(this, null);
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be Deleted.Confirm?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=DESKTOP-TS98DKN\\SQLEXPRESS;database = Sarasavi;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "Delete from studentregistration where studentid=" + rowid + "";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                user_details_Load(this, null);
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Unsaved Data Will be Lost","Are you sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
