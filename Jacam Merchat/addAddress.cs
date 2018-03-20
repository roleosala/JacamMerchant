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
    public partial class addAddress : MetroFramework.Forms.MetroForm
    {
        MySqlConnection conn;
        public int user_id { get; set; }
        public int user_type { get; set; }
        public string order_id { get; set; }
        public string rn { get; set; }
        public int offSet { get; set; }
        public addAddress()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost; database=jacammerchant; uid=root; pwd=root");
            lblId.Hide();
            txtCharge.Text = "0";
        }

        private void addAddress_Load(object sender, EventArgs e)
        {
            lblId.Text = order_id;
            lblRn.Text = rn;
            show();
            showItems();
        }

        private void show()
        {
            string sel = "SELECT p.name, p.prof_id FROM profile p WHERE user_type = 5";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            conn.Close();
            for (int i = 0; dt.Rows.Count > i; i++)
            {
                cmbPer.Items.Add(dt.Rows[i][0].ToString());
            }
        }

        private void showItems()
        {
            string sel = "SELECT i.des ,ol.* FROM order_line ol LEFT JOIN inventory i ON i.item_id = ol.item_id WHERE order_id = '" + order_id+"' AND qtyRem <> 0";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            conn.Close();
            dgvItems.DataSource = dt;
            dgvItems.Columns[0].HeaderText = "Items Description";
            dgvItems.Columns[1].Visible = false;
            dgvItems.Columns[2].Visible = false;
            dgvItems.Columns[3].Visible = false;
            dgvItems.Columns[4].HeaderText = "Qty Bought";
            dgvItems.Columns[5].HeaderText = "Price";
            dgvItems.Columns[6].HeaderText = "Deliverables";
            DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
            txt.Name = "txt";
            txt.HeaderText = "Items to be Delivered";
            dgvItems.Columns.Add(txt);
            for(int i = 0; i< dgvItems.Rows.Count; i++)
            {
                dgvItems.Rows[i].Cells["txt"].Value = 0;
            }
            dgvItems.Columns[0].ReadOnly = true;
            dgvItems.Columns[4].ReadOnly = true;
            dgvItems.Columns[5].ReadOnly = true;
            dgvItems.Columns[6].ReadOnly = true;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtStreet.Text != "" && txtPostalCode.Text != "" && cmbPer.Text != "" && lblId.Text != "id" && lblRn.Text != "Number XOXO" && txtCharge.Text != "")
            {
                string sel = "SELECT prof_id, name FROM profile WHERE user_type = 5";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(sel, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                conn.Close();
                string id = "0";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][1].ToString() == cmbPer.Text)
                    {
                        id = dt.Rows[i][0].ToString();
                    }
                }
                if (id != "0")
                {
                    string max = "SELECT max(dr) FROM delivery";
                    conn.Open();
                    comm = new MySqlCommand(max, conn);
                    adp = new MySqlDataAdapter(comm);
                    comm.ExecuteNonQuery();
                    dt = new DataTable();
                    adp.Fill(dt);
                    int dr;
                    if (dt.Rows[0][0].ToString() == "" || dt.Rows[0][0].ToString() == null)
                    {
                        dr = 1;
                    }else
                    {
                        dr = int.Parse(dt.Rows[0][0].ToString()) + 1;
                    }
                    string ins = "INSERT INTO delivery VALUES(NULL, '" + id + "', '" + order_id + "', '"+txtStreet.Text+"', '"+txtPostalCode.Text+"', '1', '"+dr+"', '"+DateTime.Now.ToString("yyyy-MM-dd")+"', NULL, '"+txtCharge.Text+"')";
                    comm = new MySqlCommand(ins, conn);
                    comm.ExecuteNonQuery();
                    sel = "SELECT max(del_id) FROM delivery";
                    comm = new MySqlCommand(sel, conn);
                    adp = new MySqlDataAdapter(comm);
                    dt = new DataTable();
                    adp.Fill(dt);
                    conn.Close();
                    int excess = 0;
                    for (int i = 0; dgvItems.Rows.Count > i;i++)
                    {
                        if (dgvItems.Rows[i].Cells["txt"].Value.ToString() != "0")
                        {
                            if (int.Parse(dgvItems.Rows[i].Cells[6].Value.ToString()) - int.Parse(dgvItems.Rows[i].Cells["txt"].Value.ToString()) < 0)
                            {
                                excess = 0;
                            }else
                            {
                                excess = int.Parse(dgvItems.Rows[i].Cells[6].Value.ToString()) - int.Parse(dgvItems.Rows[i].Cells["txt"].Value.ToString());
                            }
                            if (int.Parse(dgvItems.Rows[i].Cells["txt"].Value.ToString()) >int.Parse(dgvItems.Rows[i].Cells[6].Value.ToString()))
                            {
                                dgvItems.Rows[i].Cells["txt"].Value = dgvItems.Rows[i].Cells[6].Value.ToString();
                            }
                            ins = "INSERT INTO delivery_line VALUES(NULL, '" + dt.Rows[0][0].ToString() + "', '" + dgvItems.Rows[i].Cells[3].Value.ToString() + "', '"+ dgvItems.Rows[i].Cells["txt"].Value.ToString() + "', '"+ dgvItems.Rows[i].Cells[1].Value.ToString() + "');";
                            conn.Open();
                            comm = new MySqlCommand(ins, conn);
                            comm.ExecuteNonQuery();
                            string upd = "UPDATE order_line set qtyRem = '"+excess+"' WHERE order_line_id = '"+ dgvItems.Rows[i].Cells[1].Value.ToString() + "'";
                            comm = new MySqlCommand(upd, conn);
                            comm.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                    MessageBox.Show("Succesfully Added!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please Check all TextBox before proceeding", "There is something wrong!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCharge_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtCharge.Text, "  ^ [0-9]"))
            {
                txtCharge.Text = "";
            }
            total();
        }

        private void total()
        {
            if (txtCharge.Text != "")
            {
                double total = 0;
                for (int i = 0; i < dgvItems.Rows.Count; i++)
                {
                    total += (double)Convert.ToDouble(dgvItems.Rows[i].Cells["price"].Value.ToString());
                }
                total += (double)Convert.ToDouble(txtCharge.Text);
                lblTotal.Text = total.ToString("c");
            }
            
        }
    }
}
