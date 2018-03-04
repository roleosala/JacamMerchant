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
    public partial class Returns : MetroFramework.Forms.MetroForm
    {
        MySqlConnection conn;
        public Dashboard prevform { get; set; }
        public int user_id { get; set; }
        public int user_type { get; set; }
        public string dtpDate { get; set; }
        public Returns()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost; database=jacammerchant; uid=root; pwd=root");
            btnUpdDate.BackColor = Color.DeepSkyBlue;
            btnUpdDate.ForeColor = Color.White;
        }

        public void showReturnStaff()
        {
            if (user_type == 4)
            {
                string sel = "SELECT bi.name, pb.ref_num ,p.name, pr.return_id, pr.return_date, s.name, pr.date_rec FROM jacammerchant.po_return pr LEFT JOIN po_del_line pdl ON pdl.line_id = pr.po_del_line_id LEFT JOIN po_bid_line pbl ON pbl.po_bid_line_id = pdl.po_bid_line_id LEFT JOIN po_bid pb ON pb.po_bid_id = pbl.po_bid_id LEFT JOIN bid_items bi ON pbl.item_id = bi.item_id LEFT JOIN profile p ON p.prof_id = pr.prof_id LEFT JOIN profile s ON s.prof_id = pbl.sup_id WHERE pbl.sup_id = '" + user_id+"';";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(sel, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                comm.ExecuteNonQuery();
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dgvRet.DataSource = dt;
                dgvRet.Columns[0].HeaderText = "Item Description";
                dgvRet.Columns[1].HeaderText = "Reference No.";
                dgvRet.Columns[2].HeaderText = "Returned By";
                dgvRet.Columns[3].Visible = false; //return_id (po_return)
                dgvRet.Columns[4].HeaderText = "Returned By";
                dgvRet.Columns[5].Visible = false; // supplier_name
                dgvRet.Columns[6].HeaderText = "Date Receive";
            }
            else if (user_type == 1)
            {
                string sel = "SELECT bi.name, pr.qty ,pb.ref_num ,p.name, pr.return_id, pr.return_date, s.name, pr.date_rec FROM jacammerchant.po_return pr LEFT JOIN po_del_line pdl ON pdl.po_del_line_id = pr.po_del_line_id LEFT JOIN po_bid_line pbl ON pbl.po_bid_line_id = pdl.po_bid_line_id LEFT JOIN po_bid pb ON pb.po_bid_id = pbl.po_bid_id LEFT JOIN bid_items bi ON pbl.item_id = bi.item_id LEFT JOIN profile p ON p.prof_id = pr.prof_id LEFT JOIN profile s ON s.prof_id = pbl.sup_id;";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(sel, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                comm.ExecuteNonQuery();
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dgvRet.DataSource = dt;
                dgvRet.Columns[0].HeaderText = "Item Description";
                dgvRet.Columns[1].HeaderText = "Returned QTY.";
                dgvRet.Columns[2].HeaderText = "Reference No.";
                dgvRet.Columns[3].HeaderText = "Returned By";
                dgvRet.Columns[4].Visible = false; //return_id (po_return)
                dgvRet.Columns[5].HeaderText = "Returned By";
                dgvRet.Columns[6].HeaderText = "Supplier Name";
                dgvRet.Columns[7].HeaderText = "Date Receive";
            }
        }


        private void Returns_Load(object sender, EventArgs e)
        {
            if (user_type == 1)
            {
                showReturnStaff();
            }
            else if (user_type == 4)
            {
                btnUpdDate.Text = "Recieve";
                showReturnStaff();
            }
            if (dgvRet.Rows.Count > 0)
            {
                string detdet = dgvRet.Rows[0].Cells[6].Value.ToString();
                if (detdet == "")
                {
                    btnUpdDate.Enabled = true;
                    btnUpdDate.BackColor = Color.DeepSkyBlue;
                    btnUpdDate.ForeColor = Color.White;
                }
                else
                {
                    btnUpdDate.Enabled = false;
                    btnUpdDate.BackColor = Color.LightGray;
                    btnUpdDate.ForeColor = Color.White;
                }
            }
            else
            {
                btnUpdDate.Enabled = false;
                btnUpdDate.BackColor = Color.LightGray;
                btnUpdDate.ForeColor = Color.White;
            }

        }

        private void Returns_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevform.Show();
        }
        // need improvements sa returns
        public int counter { get; set; }
        private void btnUpdDate_Click(object sender, EventArgs e)
        {
            dtpDate = null;
            int ri = dgvRet.CurrentRow.Index;
            if (ri >= 0)
            {
                string id = dgvRet.Rows[ri].Cells[3].Value.ToString();
                string detdet = dgvRet.Rows[ri].Cells[6].Value.ToString();
                if (dtpDate != null || dtpDate != "" && counter == 0 && detdet == "")
                {
                    addDate det = new addDate();
                    det.ret = this;
                    det.offSet = 2;
                    det.ShowDialog();
                    if (user_type == 4 && dtpDate != null)
                    {
                        string upd = "UPDATE po_return SET date_rec = '" + dtpDate + "', sup_id = '"+user_id+"' WHERE return_id = '" + id + "'";
                        conn.Open();
                        MySqlCommand comm = new MySqlCommand(upd, conn);
                        comm.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Successfully updated the Return Date!", "Successful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (user_type == 1 && dtpDate != null)
                    {
                        string upd = "UPDATE po_return SET return_date = '" + dtpDate + "' WHERE return_id = '" + id + "'";
                        conn.Open();
                        MySqlCommand comm = new MySqlCommand(upd, conn);
                        comm.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Successfully updated the Return Date!", "Successful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    counter = 0;
                    showReturnStaff();
                }
                else
                {
                    MessageBox.Show("Already Received cannot change the return date!", "Already Received!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnUpdDate.Enabled = false;
                    btnUpdDate.BackColor = Color.LightGray;
                    btnUpdDate.ForeColor = Color.White;
                }
            }
        }

        private void dgvRet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int ri = dgvRet.CurrentRow.Index;
            if (ri >= 0)
            {
                string detdet = dgvRet.Rows[ri].Cells[6].Value.ToString();
                if (detdet == "")
                {
                    btnUpdDate.Enabled = true;
                    btnUpdDate.BackColor = Color.DeepSkyBlue;
                    btnUpdDate.ForeColor = Color.White;
                }
                else
                {
                    btnUpdDate.Enabled = false;
                    btnUpdDate.BackColor = Color.LightGray;
                    btnUpdDate.ForeColor = Color.White;
                }
            }
        }
    }
}
