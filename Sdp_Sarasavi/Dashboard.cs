using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sdp_Sarasavi
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to Exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void bOOKREGISTRATIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bookregistration brs = new Bookregistration();
            brs.Show();
        }

        private void viewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VIEWBOOKS vb = new VIEWBOOKS();
            vb.Show();
        }

        private void userRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            USER_REGISTRATION usr = new USER_REGISTRATION();
            usr.Show();
        }

        private void userDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user_details ud = new user_details();
            ud.Show();
        }

        private void iSSUBOOKToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
       
        }

        private void iSSUBOOKToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Issuebook isb = new Issuebook();
            isb.Show();
        }

        private void rETRUNBOOKSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bookreturn br = new Bookreturn();
            br.Show();
        }

        private void cOMPLETEDETAILToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompleteDetails cm = new CompleteDetails();
            cm.Show();
        }

        private void iNQUARYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inquerys inq = new Inquerys();
            inq.Show();
        }
    }
}
