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
    public partial class bidPurchOrder : MetroFramework.Forms.MetroForm
    {
        MySqlConnection conn;
        public int user_id { get; set; }
        public int user_type { get; set; }
        public Dashboard prevform { get; set; }
        public bidPurchOrder()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost; database=jacammerchant; uid=root; pwd=root");
            lblRn.Hide();
            label1.Hide();
            lblPo_Bid_id.Hide();
        }

        private void showPurchOrder() //staff
        {
            string sel = "SELECT * FROM po_bid pb";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvPO.DataSource = dt;
            dgvPO.ClearSelection();
            dgvPO.Columns[0].Visible = false;
            dgvPO.Columns[1].Visible = false;
            dgvPO.Columns[2].HeaderText = "Date Purchased";
            dgvPO.Columns[3].HeaderText = "Reference Number";
            dgvPO.ClearSelection();
        }

        private void showPurchOrderLine(int id) //staff
        {
            string sel = "SELECT pbl.*, bi.name, bo.offer_price, s.name, b.title FROM po_bid_line pbl LEFT JOIN bid_items bi ON bi.item_id = pbl.item_id LEFT JOIN bid_offer bo ON bo.item_id = pbl.item_id LEFT JOIN profile s ON s.prof_id = pbl.sup_id LEFT JOIN po_bid pb ON pb.po_bid_id = pbl.po_bid_id JOIN bid b ON b.bid_id = bi.bid_id WHERE pbl.po_bid_id = '" + id+"'";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvPO.DataSource = dt;
            dgvPO.ClearSelection();
            
        }

        private void showSupPurchOrder() //supplier
        {
            string sel = "SELECT pb.*, p.name FROM po_bid pb LEFT JOIN profile p ON p.prof_id = pb.prof_id WHERE po_bid_id in (SELECT po_bid_id FROM po_bid_line WHERE sup_id = '"+user_id+"')";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvPO.DataSource = dt;
            dgvPO.Columns[0].Visible = false;
            dgvPO.Columns[1].Visible = false;
            dgvPO.Columns[2].HeaderText = "Date Purchased";
            dgvPO.Columns[3].HeaderText = "Reference No.";
            dgvPO.Columns[4].HeaderText = "Purchased By";
            dgvPO.ClearSelection();
        }

        private void showSupPurchOrderLine(int id) //supplier
        {
            string sel = "SELECT pbl.*, bi.name FROM po_bid_line pbl LEFT JOIN bid_items bi ON bi.item_id = pbl.item_id WHERE po_bid_id = '" + id+"' AND sup_id = '"+user_id+"'";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvPO.DataSource = dt;
            dgvPO.Columns[0].Visible = false;//po_bid_line_id
            dgvPO.Columns[1].Visible = false;//po_bid_id
            dgvPO.Columns[2].Visible = false;//item_id
            dgvPO.Columns[3].HeaderText = "QTY Bought";
            dgvPO.Columns[4].Visible = false;
            dgvPO.Columns[5].Visible = false;
            dgvPO.Columns[6].HeaderText = "Remaining QTY to be delivered";
            dgvPO.Columns[7].HeaderText = "Item Description";
            dgvPO.ClearSelection();
        }

        private void bidPurchOrder_Load(object sender, EventArgs e)
        {
            if (user_type == 1 || user_type == 5)
            {
                showPurchOrder();
                btnDelRec.Text = "View";
            }
            else if (user_type == 4)
            {
                showSupPurchOrder();
                btnDelRec.Text = "Deliver";
            }
            dgvPO.ClearSelection();
        }

        private void bidPurchOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevform.Show();
        }
        
        private int offset = 0;

        private void dgvPO_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int ri = dgvPO.CurrentRow.Index;
            if (ri >= 0 && offset == 0)
            {
                lblPo_Bid_id.Text = dgvPO.Rows[ri].Cells[0].Value.ToString();
                int id = int.Parse(dgvPO.Rows[ri].Cells[0].Value.ToString());
                if (user_type == 1 || user_type == 5)
                {
                    lblRn.Text = dgvPO.Rows[ri].Cells[3].Value.ToString();
                    showPurchOrderLine(id);
                    offset = 1;
                    btnDelRec.Hide();
                    lblRn.Show();
                    label1.Show();
                }
                else if (user_type == 4)
                {
                    showSupPurchOrderLine(id);
                    offset = 1;
                }
            }
            dgvPO.ClearSelection();
            btnDelRec.Enabled = true;
            btnDelRec.BackColor = Color.DeepSkyBlue;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (offset == 1)
            {
                dgvPO.DataSource = null;
                if (user_type == 1 || user_type == 5)
                {
                    showPurchOrder();
                    btnDelRec.Show();
                    lblRn.Show();
                    label1.Show();
                }
                else if (user_type == 4)
                {
                    showSupPurchOrder();
                }
                offset = 0;
            }else if (offset == 2)
            {
                dgvPO.DataSource = null;
                if (user_type == 1 || user_type == 5)
                {
                    showPurchOrder();
                }
                else if (user_type == 4)
                {
                    showSupPurchOrder();
                }
            }
            else
            {
                this.Close();
            }
            dgvPO.ClearSelection();
            label1.Hide();
            lblRn.Text = "";
        }

        public int quant { get; set; }

        public int offSet = 0;

        private void btnDelRec_Click(object sender, EventArgs e)
        {
            int ri = dgvPO.CurrentRow.Index;
            if (ri >= 0 && offset == 0)
            {
                lblPo_Bid_id.Text = dgvPO.Rows[ri].Cells[0].Value.ToString();
                int id = int.Parse(dgvPO.Rows[ri].Cells[0].Value.ToString());
                if (user_type == 1 || user_type == 5)
                {
                    lblRn.Text = dgvPO.Rows[ri].Cells[3].Value.ToString();
                    showPurchOrderLine(id);
                    offset = 1;
                    btnDelRec.Hide();
                    lblRn.Show();
                    label1.Show();
                    
                }
                else if (user_type == 4)
                {
                    showSupPurchOrderLine(id);
                    offset = 1;
                }
            }
            else
            { 
                ri = dgvPO.CurrentRow.Index;
                if (ri >= 0)
                {
                    int id = int.Parse(dgvPO.Rows[ri].Cells[0].Value.ToString());
                    int po_bid_id = int.Parse(lblPo_Bid_id.Text);
                    if (user_type == 1 || user_type == 5 && offset == 0)
                    {
                        showPurchOrderLine(id);
                        offset = 1;
                        btnDelRec.Hide();
                    }
                    else if (user_type == 4 && dgvPO.Rows.Count > 0)
                    {
                        string ch = "SELECT * FROM po_bid_line WHERE po_bid_line_id IN (SELECT pdl.po_bid_line_id FROM po_del_line pdl LEFT JOIN po_del_line_rem pdlr ON pdlr.po_bid_line_id = pdl.po_bid_line_id WHERE po_bid_id = '" + po_bid_id+"' AND sup_id = '"+user_id+"' AND qtyRem = 0)";
                        conn.Open();
                        MySqlCommand comm = new MySqlCommand(ch, conn);
                        MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                        comm.ExecuteNonQuery();
                        conn.Close();
                        DataTable dt = new DataTable();
                        adp.Fill(dt);
                        if (dt.Rows.Count >= 1)
                        {
                            MessageBox.Show("The item you are trying to set a delivery date is already scheduled. Please select another item to be delivered.","Item Already in Delivery!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }else
                        {
                            conn.Open();
                            string items = "SELECT * FROM po_del_line pdl LEFT JOIN po_del_line_rem pdlr ON pdlr.po_del_line_id = pdl.po_del_line_id WHERE po_bid_id = '"+po_bid_id+"'";
                            MySqlCommand comm2 = new MySqlCommand(items, conn);
                            MySqlDataAdapter adp2 = new MySqlDataAdapter(comm2);
                            comm.ExecuteNonQuery();
                            DataTable dt2 = new DataTable();
                            adp.Fill(dt2);
                            conn.Close();
                            if (dt.Rows.Count > 0)
                            {
                                string sel = "SELECT max(po_del_id) FROM po_del";
                                conn.Open();
                                comm = new MySqlCommand(sel, conn);
                                adp = new MySqlDataAdapter(comm);
                                comm.ExecuteNonQuery();
                                dt = new DataTable();
                                conn.Close();
                                adp.Fill(dt);
                                if (dt.Rows.Count >= 1)
                                {
                                    string po_del_id = dt.Rows[0][0].ToString();
                                    addAddressSupplier purch = new addAddressSupplier();
                                    purch.user_id = user_id;
                                    purch.user_type = user_type;
                                    purch.po_id = id;
                                    purch.po_bid_id = po_bid_id;
                                    purch.dt = dt;
                                    purch.offSet = 0;
                                    purch.ShowDialog();
                                }
                            }
                            else
                            {
                                DataTable data = new DataTable();
                                foreach (DataGridViewColumn col in dgvPO.Columns)
                                {
                                    data.Columns.Add(col.Name);
                                }
                                foreach (DataGridViewRow row in dgvPO.Rows)
                                {
                                    DataRow dRow = data.NewRow();
                                    foreach (DataGridViewCell cell in row.Cells)
                                    {
                                        dRow[cell.ColumnIndex] = cell.Value;
                                    }
                                    data.Rows.Add(dRow);
                                }
                                string sel = "SELECT max(po_del_id) FROM po_del";
                                conn.Open();
                                comm = new MySqlCommand(sel, conn);
                                adp = new MySqlDataAdapter(comm);
                                comm.ExecuteNonQuery();
                                dt = new DataTable();
                                conn.Close();
                                adp.Fill(dt);
                                if (dt.Rows.Count == 1)
                                {
                                    string po_del_id = dt.Rows[0][0].ToString();
                                    addAddressSupplier purch = new addAddressSupplier();
                                    purch.user_id = user_id;
                                    purch.user_type = user_type;
                                    purch.po_id = id;
                                    purch.po_bid_id = po_bid_id;
                                    purch.dt = data;
                                    purch.offSet = 1;
                                    purch.ShowDialog();
                                }
                                showSupPurchOrderLine(po_bid_id);
                            }
                        }
                    }
                }
                dgvPO.ClearSelection();
            }
        }
    }
}
