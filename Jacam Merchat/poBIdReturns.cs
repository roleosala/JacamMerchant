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
            lblRetId.Hide();
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
            dgvRet.Columns[0].Visible = false;
            dgvRet.Columns[1].Visible = false;
            dgvRet.Columns[2].HeaderText = "Return Date";
            dgvRet.Columns[3].Visible = false;
            dgvRet.Columns[4].HeaderText = "Date Receive";
            dgvRet.Columns[5].Visible = false;
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
            dgvRet.Columns[0].Visible = false;
            dgvRet.Columns[1].Visible = false;
            dgvRet.Columns[2].HeaderText = "Return Date";
            dgvRet.Columns[3].Visible = false;
            dgvRet.Columns[4].HeaderText = "Date Receive";
            dgvRet.Columns[5].Visible = false;
        }

        private void showLine(string ret_id)
        {
            dgvRet.DataSource = null;
            string sh = "SELECT prl.*, bi.name FROM jacammerchant.po_return_line prl LEFT JOIN po_del_line pdl ON pdl.po_del_line_id = prl.po_del_line_id LEFT JOIN bid_items bi ON bi.item_id = prl.item_id WHERE prl.ret_id = '" + ret_id+"';";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sh, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvRet.DataSource = dt;
            dgvRet.Columns[0].Visible = false;
            dgvRet.Columns[1].Visible = false;
            dgvRet.Columns[2].Visible = false;
            dgvRet.Columns[3].Visible = false;
            dgvRet.Columns[4].HeaderText = "QTY Returned";
            dgvRet.Columns[5].HeaderText = "Item Description";
            offSet = 1;
            int c = 0;
            for (int i = 0; i < dgvRet.Rows.Count; i++)
            {
                if (dgvRet.Rows[i].Cells["qty"].Value.ToString() != "")
                {
                    c++;
                }
            }
            if (c > 0)
            {
                DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
                txt.Name = "txt";
                txt.HeaderText = "Items to be Delivered";
                dgvRet.Columns.Add(txt);
                for (int i = 0; i < dgvRet.Rows.Count; i++)
                {
                    dgvRet.Rows[i].Cells["txt"].Value = 0;
                }
            }
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
                    if (dgvRet.Rows[ri].Cells[5].Value.ToString() != "" && user_type == 4)
                    {
                        btnViewRet.Text = "Deliver";
                    }
                    else if (user_type == 1     )
                    {
                        btnViewRet.Hide();
                    }
                    else
                    {
                        btnViewRet.Text = "Receive";
                    }
                    showLine(lblRetId.Text);
                    
                }
            }else if (offSet == 1)
            {
                if (btnViewRet.Text == "Receive")
                {
                    conn.Open();
                    string ch = "SELECT sup_id FROM po_return WHERE ret_id = '" + lblRetId.Text + "'";
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
                    }
                    else
                    {
                        MessageBox.Show("You have Already Received this Returned Items.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    conn.Close();
                }else if (btnViewRet.Text == "Deliver")
                {
                    conn.Open();
                    string ch = "SELECT max(del_ret_id), MAX(dr) FROM po_del_ret";
                    MySqlCommand comm = new MySqlCommand(ch, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                    comm.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    int dr = 1;
                    int del_ret_id = 0;
                    if (dt.Rows[0][0].ToString() == "" && dt.Rows[0][1].ToString() == "")
                    {
                        dr = 1;
                        del_ret_id = 1;
                    }else
                    {
                        dr = int.Parse(dt.Rows[0][0].ToString()) + 1;
                        del_ret_id = int.Parse(dt.Rows[0][1].ToString());
                    }
                    addDate add = new addDate();
                    add.offSet = 3;
                    add.poRet = this;
                    add.ShowDialog();
                    string ins = "INSERT INTO po_del_ret VALUES(NULL, '" + det + "', '" + user_id + "', '" + dr + "', NULL, NULL)";
                    comm = new MySqlCommand(ins, conn);
                    comm.ExecuteNonQuery();
                    int co = 0;
                    for (int i = 0; i < dgvRet.Rows.Count; i++)
                    {
                        if (dgvRet.Rows[i].Cells["txt"].Value.ToString() != "0")
                        {
                            ins = "INSERT INTO po_del_ret_line VALUES(NULL, '" + del_ret_id + "', '" + dgvRet.Rows[i].Cells[0].Value.ToString()+"', '"+ dgvRet.Rows[i].Cells["txt"].Value.ToString() + "')";
                            comm = new MySqlCommand(ins, conn);
                            comm.ExecuteNonQuery();
                            co++;
                        }
                    }
                    if (co > 0)
                    {
                        MessageBox.Show("Successfully set the delivery date!");
                    }
                    conn.Close();
                }
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
                btnViewRet.Show();
                dgvRet.Columns.Remove("txt");
            }
            else
            {
                this.Close();
                prevform.Show();
            }
        }
    }
}
