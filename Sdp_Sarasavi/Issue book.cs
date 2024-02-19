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
    public partial class Issue_book
    {
        public Issue_book()
        {
            InitializeComponent();
        }

        private void Issue_book_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source=DESKTOP-TS98DKN\\SQLEXPRESS;database=Library;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();

            cmd = new SqlCommand("select bname from newbok ", con);
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

        private void btnsearch_Click(object sender, EventArgs e)
        {


        }

        private void btnissuebok_Click(object sender, EventArgs e)
        {
        }

    } 
    }

