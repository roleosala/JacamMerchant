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

        private void showLine(string del_id)
        {
            dgvRet.DataSource = null;
            string sh = "SELECT * FROM jacammerchant.po_return_line prl LEFT JOIN po_del_line pdl ON pdl.po_del_line_id = prl.po_del_line_id;";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sh, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvRet.DataSource = dt;
            DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
            txt.Name = "txt";
            txt.HeaderText = "Items to be Returned";
            dgvRet.Columns.Add(txt);
            for (int i = 0; i < dgvRet.Rows.Count; i++)
            {
                dgvRet.Rows[i].Cells["txt"].Value = 0;
            }
            offSet = 1;
        }

        private void poBIdReturns_Load(object sender, EventArgs e)
        {
            show();
        }

        public string det { get; set; }

        private void btnViewRet_Click(object sender, EventArgs e)
        {
            if (offSet == 0)
            {
                int ri = dgvRet.CurrentRow.Index;
                if (ri >= 0)
                {
                    lblDelId.Text = dgvRet.Rows[ri].Cells[0].Value.ToString();
                    showLine(lblDelId.Text);
                    btnViewRet.Text = "Return";
                }
            }else if (offSet == 1)
            {
                addDate add = new addDate();
                add.offSet = 3;
                add.poRet = this;
                add.ShowDialog();
                DialogResult res = MessageBox.Show("Are you sure you want to return the item/s on this date: "+det+"?","",MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (DialogResult.Yes == res)
                {
                    string ins = "INSERT INTO po_return VALUES(NULL, '" + lblDelId.Text + "', '" + det + "', '" + user_id + "')";
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(ins, conn);
                    comm.ExecuteNonQuery();
                    string sel = "SELECT MAX(ret_id) FROM po_return";
                    comm = new MySqlCommand(sel, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                    comm.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    for (int i = 0; dgvRet.Rows.Count > i;i++)
                    {
                        if (dgvRet.Rows[i].Cells["txt"].Value.ToString() != "0")
                        {
                            ins = "INSERT INTO po_return_line VALUES (NULL, '" + dt.Rows[0][0].ToString() + "', '" + dgvRet.Rows[i].Cells["po_del_line_id"].Value.ToString() + "', '" + dgvRet.Rows[i].Cells["item_id"].Value.ToString() + "', '"+ dgvRet.Rows[i].Cells["txt"].Value.ToString() + "');";
                            comm = new MySqlCommand(ins, conn);
                            comm.ExecuteNonQuery();
                        }
                    }
                    conn.Close();
                    showLine(lblDelId.Text);
                }
                else
                {
                    add = new addDate();
                    add.offSet = 3;
                    add.poRet = this;
                    add.ShowDialog();
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
            }
            else
            {
                this.Close();
                prevform.Show();
            }
        }
    }
}
