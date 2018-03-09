using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Jacam_Merchat
{
    public partial class poBIdReturns : MetroFramework.Forms.MetroForm
    {
        MySqlConnection conn;
        public int user_id { get; set; }
        public int user_type { get; set; }
        public Dashboard prevform { get; set; }
        public poBIdReturns()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost; database=jacammerchant; uid=root; pwd=root");
        }

        private int offSet;

        private void showSup()
        {
            dgvRet.DataSource = null;
            string sh = "SELECT * FROM po_return WHERE del_id IN (SELECT po_del_id FROM po_del WHERE sup_id = '"+user_id+"')";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sh, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvRet.DataSource = dt;
            offSet = 0;
        }

        private void show()
        {
            dgvRet.DataSource = null;
            string sh = "SELECT * FROM po_return ";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sh, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvRet.DataSource = dt;
            offSet = 0;
        }

        private void showLine(string ret_id)
        {
            dgvRet.DataSource = null;
            string sh = "SELECT * FROM jacammerchant.po_return_line prl LEFT JOIN po_del_line pdl ON pdl.po_del_line_id = prl.po_del_line_id WHERE prl.ret_id = '"+ret_id+"';";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sh, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvRet.DataSource = dt;
            offSet = 1;
        }

        private void poBIdReturns_Load(object sender, EventArgs e)
        {
            if (user_type == 4)
            {
                showSup();
            }else if (user_type == 1)
            {
                show();
            }
        }

        public string det { get; set; }

        private void btnViewRet_Click(object sender, EventArgs e)
        {
            if (offSet == 0)
            {
                int ri = dgvRet.CurrentRow.Index;
                if (ri >= 0)
                {
                    lblRetId.Text = dgvRet.Rows[ri].Cells[0].Value.ToString();
                    showLine(lblRetId.Text);
                    btnViewRet.Text = "Receive";
                }
            }else if (offSet == 1)
            {
                conn.Open();
                string ch = "SELECT sup_id FROM po_return WHERE ret_id = '"+lblRetId.Text+"'";
                MySqlCommand comm = new MySqlCommand(ch, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                comm.ExecuteNonQuery();
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows[0][0].ToString() == "")
                {
                    string upd = "UPDATE po_return SET date_rec = '" + DateTime.Now.ToString("yyyy-MM-dd") + "', sup_id = '" + user_id + "' WHERE ret_id = '" + lblRetId.Text + "'";
                    comm = new MySqlCommand(upd, conn);
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Successfully Received all Item/s.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }else
                {
                    MessageBox.Show("You have Already Received this Return.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();
            }
        }

        private void poBIdReturns_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevform.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (offSet == 1)
            {
                show();
                btnViewRet.Text = "View";
            }
            else
            {
                this.Close();
                prevform.Show();
            }
        }
    }
}
