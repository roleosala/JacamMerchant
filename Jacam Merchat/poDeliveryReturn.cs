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
    public partial class poDeliveryReturn : MetroFramework.Forms.MetroForm
    {
        MySqlConnection conn;
        public int user_id { get; set; }
        public int user_type { get; set; }
        public Dashboard prevform { get; set; }
        public poDeliveryReturn()
        {
            conn = new MySqlConnection("server=localhost; database=jacammerchant; uid=root; pwd=root");
            InitializeComponent();
        }

        public void showSup()
        {
            dgvDel.DataSource = null;
            string sh = "SELECT pdr.*, s.name, p.name FROM po_del_ret pdr LEFT JOIN profile s ON s.prof_id = pdr.sup_id LEFT JOIN profile p ON p.prof_id = pdr.prof_id WHERE sup_id = '" + user_id + "'";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sh, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvDel.DataSource = dt;
            dgvDel.Columns[0].Visible = false;
            dgvDel.Columns[1].HeaderText = "Delivery Date";
            dgvDel.Columns[2].Visible = false;
            dgvDel.Columns[3].HeaderText = "Delivery Receipt";
            dgvDel.Columns[4].Visible = false;
            dgvDel.Columns[5].HeaderText = "Date Rec";
            dgvDel.Columns[6].Visible = false;
            dgvDel.Columns[7].HeaderText = "Received By";
            DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
            txt.Name = "txt";
            txt.HeaderText = "Items to be Returned";
            dgvDel.Columns.Add(txt);
            for (int i = 0; i < dgvDel.Rows.Count; i++)
            {
                if (dgvDel.Rows[i].Cells[5].Value.ToString() == "")
                {
                    dgvDel.Rows[i].Cells["txt"].Value = "Not Yet Received";
                    dgvDel.Rows[i].Cells["txt"].Style.ForeColor = Color.Red;
                }
                else
                {
                    dgvDel.Rows[i].Cells["txt"].Value = "Received!";
                    dgvDel.Rows[i].Cells["txt"].Style.ForeColor = Color.Green;
                }
            }
        }

        public void show()
        {
            dgvDel.DataSource = null;
            string sh = "SELECT pdr.*, s.name, p.name FROM po_del_ret pdr LEFT JOIN profile s ON s.prof_id = pdr.sup_id LEFT JOIN profile p ON p.prof_id = pdr.prof_id";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sh, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvDel.DataSource = dt;
            dgvDel.Columns[0].Visible = false;
            dgvDel.Columns[1].HeaderText = "Delivery Date" ;
            dgvDel.Columns[2].Visible = false;
            dgvDel.Columns[3].Visible = false;
            dgvDel.Columns[4].HeaderText = "Date Received";
            dgvDel.Columns[5].Visible = false;
            dgvDel.Columns[6].Visible = false;
            dgvDel.Columns[7].HeaderText = "Received By";
            DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
            txt.Name = "txt";
            txt.HeaderText = "Status";
            dgvDel.Columns.Add(txt);
            for (int i = 0; i < dgvDel.Rows.Count; i++)
            {
                if (dgvDel.Rows[i].Cells[5].Value.ToString() == "")
                {
                    dgvDel.Rows[i].Cells["txt"].Value = "Not Yet Received!";
                    dgvDel.Rows[i].Cells["txt"].Style.ForeColor = Color.Red;
                }
                else
                {
                    dgvDel.Rows[i].Cells["txt"].Value = "Received!";
                    dgvDel.Rows[i].Cells["txt"].Style.ForeColor = Color.Green;
                }
            }
        }

        private void showLine()
        {
            int ri = dgvDel.CurrentRow.Index;
            if (dgvDel.Rows[ri].Cells["txt"].Value.ToString() == "Received!")
            {
                btnViewRec.Hide();
            }
            dgvDel.DataSource = null;
            string sh = "SELECT i.des, pdlr.* FROM po_del_ret_line pdlr LEFT JOIN inventory i ON i.item_id = pdlr.item_id WHERE del_ret_id = '" + lblDelRetId.Text+"'";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sh, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvDel.DataSource = dt;
            dgvDel.Columns["des"].HeaderText = "Item Description";
            dgvDel.Columns["del_ret_line_id"].Visible = false;
            dgvDel.Columns["del_ret_id"].Visible = false;
            dgvDel.Columns["ret_line_id"].Visible = false;
            dgvDel.Columns["item_id"].Visible = false;
            dgvDel.Columns["qty"].HeaderText = "Qty Delivered";
            dgvDel.Columns.Remove("txt");
        }

        private void poDeliveryReturn_Load(object sender, EventArgs e)
        {
            if (user_type == 4)
            {
                showSup();
            }
            else if (user_type == 1)
            {
                show();
            }
        }

        private void poDeliveryReturn_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevform.Show();
        }

        private void btnViewRec_Click(object sender, EventArgs e)
        {
            if (btnViewRec.Text == "View" && user_type == 4)
            {
                btnViewRec.Hide();
            }
            else if (btnViewRec.Text == "Receive")
            {
                conn.Open();
                string ch = "SELECT date_rec FROM po_del_Ret WHERE del_Ret_id = '"+lblDelRetId.Text+"'";
                MySqlCommand comm = new MySqlCommand(ch, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                comm.ExecuteNonQuery();
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows[0][0].ToString() == "" || dt.Rows[0][0].ToString() == null)
                {
                    string upd = "UPDATE po_del_ret SET date_rec = '"+DateTime.Now.ToString("yyyy-MM-dd")+"', prof_id = '"+user_id+"' WHERE del_ret_id = '"+lblDelRetId.Text+"'";
                    comm = new MySqlCommand(upd, conn);
                    comm.ExecuteNonQuery();
                    for (int i = 0; i < dgvDel.Rows.Count; i++)
                    {
                        string co = "SELECT qty FROM inventory WHERE item_id = '" + dgvDel.Rows[i].Cells["item_id"].Value.ToString() +"'";
                        comm = new MySqlCommand(co, conn);
                        adp = new MySqlDataAdapter(comm);
                        dt = new DataTable();
                        adp.Fill(dt);
                        int add = int.Parse(dt.Rows[0][0].ToString()) + int.Parse(dgvDel.Rows[i].Cells["qty"].Value.ToString());
                        upd = "UPDATE inventory SET qty = '" + add + "' WHERE item_id = '" + dgvDel.Rows[i].Cells["item_id"].Value.ToString() + "'";
                        comm = new MySqlCommand(upd, conn);
                        comm.ExecuteNonQuery();
                        MessageBox.Show(upd + dt.Rows[0][0].ToString(), add.ToString());
                    }
                    MessageBox.Show("Successfully Received all Items!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Item/s already received! Cannot receive again.","", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();
            }
            else
            {
                btnViewRec.Text = "Receive";
            }
            if (dgvDel.Rows.Count > 0)
            {
                int ri = dgvDel.CurrentRow.Index;
                if (ri >= 0)
                {
                    lblDelRetId.Text = dgvDel.Rows[ri].Cells[0].Value.ToString();
                    showLine();
                }
            }
        }

        private void dgvDel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
