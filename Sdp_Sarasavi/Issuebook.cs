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
    public partial class Issuebook : Form
    {
        public Issuebook()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Issuebook_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source =DESKTOP-TS98DKN\\SQLEXPRESS; database=Sarasavi;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();

            cmd = new SqlCommand("Select bname from newbok", con);
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    comboBox1.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
            con.Close();
        }
        int count;
        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (txteno.Text != "")
            {
                String eid = txteno.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source =DESKTOP-TS98DKN\\SQLEXPRESS; database=Sarasavi;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText= "select * from studentregistration where enrollmentno ='"+eid+"'";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet Ds = new DataSet();
                DA.Fill(Ds);

                cmd.CommandText = "select count (enrollmentno) from Ibook where enrollmentno ='" + eid + "' and bookreturndate is null";
                SqlDataAdapter DA1 = new SqlDataAdapter(cmd);
                DataSet Ds1 = new DataSet();
                DA.Fill(Ds1);

                count = int.Parse(Ds1.Tables[0].Rows[0][0].ToString());

                if (Ds.Tables[0].Rows.Count != 0)
                {
                    txtsname.Text = Ds.Tables[0].Rows[0][1].ToString();
                    txtsex.Text = Ds.Tables[0].Rows[0][3].ToString();
                    txtadres.Text = Ds.Tables[0].Rows[0][4].ToString();
                    txtnic.Text = Ds.Tables[0].Rows[0][5].ToString();
                }
                else
                {
                    txtsname.Clear();
                    txtsex.Clear();
                    txtadres.Clear();
                    txtnic.Clear();
                    MessageBox.Show("Inavid Enrollment no", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnissuebok_Click(object sender, EventArgs e)
        {
            if (txtsname.Text != "")
            {
                if(comboBox1.SelectedIndex != -1 && count <= 4)
                {
                    String enroll = txteno.Text;
                    String sname = txtsname.Text;
                    String sex = txtsex.Text;
                    String addres = txtadres.Text;
                    Int64 nic = Int64.Parse(txtnic.Text);
                    Int64 Contact = Int64.Parse(txtcno.Text);
                    String bookname = comboBox1.Text;
                    String bookissuedate = dateTimePicker1.Text;

                    String eid = txteno.Text;
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "data source =DESKTOP-TS98DKN\\SQLEXPRESS; database=Sarasavi;integrated security=True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    con.Open();
                    cmd.CommandText = "insert into Ibook(enrollmentno,studentname,sex,Adress,NICno,contactno,bookname,bookissuedate) values ('" + enroll + "','" + sname + "','" + sex + "','" + addres + "'," + nic + "," + Contact + ",'" + bookname + "','" + bookissuedate + "') ";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Book Issued", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                else
                {
                    MessageBox.Show("Select book or maximum number of book has been issued", "No book selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txteno_TextChanged(object sender, EventArgs e)
        {
            if (txteno.Text == "")
            {
                txteno.Clear();
                txtsname.Clear();
                txtsex.Clear();
                txtadres.Clear();
                txtnic.Clear();
                txtcno.Clear();
            }
            
            
        }

        private void btbrefresh_Click(object sender, EventArgs e)
        {
            txteno.Clear();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to exit", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
