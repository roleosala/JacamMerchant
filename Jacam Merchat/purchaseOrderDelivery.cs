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
    public partial class purchaseOrderDelivery : MetroFramework.Forms.MetroForm
    {
        MySqlConnection conn;
        public int user_id { get; set; }
        public int user_type { get; set; }
        public Dashboard prevform { get; set; }
        public string dtpDate { get; set; }
        public purchaseOrderDelivery()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost; database=jacammerchant; uid=root; pwd=root");
            lbldate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lbldate.Hide();
        }

        private void showPoBid()
        {
            string sel = "SELECT * FROM po_bid";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvDel.DataSource = dt;
            dgvDel.ClearSelection();
        }

        private void showDelLineSup(int id)// po_bid_line show
        {
            string sel = "SELECT * FROM jacammerchant.po_del_line pdl LEFT JOIN po_bid_line pbl ON pbl.po_bid_line_id = pdl.po_bid_line_id LEFT JOIN profile p ON p.prof_id = pdl.prof_id LEFT JOIN profile s ON s.prof_id = pbl.sup_id LEFT JOIN bid_items bi ON bi.item_id = pbl.item_id LEFT JOIN po_del pd ON pdl.po_del_id = pd.po_del_id WHERE pdl.po_del_id = '" + id+"' AND pd.sup_id = '"+user_id+"'";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvDel.DataSource = dt;
            dgvDel.ClearSelection();
            dgvDel.Columns[0].Visible = false;
            dgvDel.Columns[1].Visible = false;
            dgvDel.Columns[2].Visible = false;
            dgvDel.Columns[3].Visible = true;
            dgvDel.Columns[3].HeaderText = "Qty Revieved";
            dgvDel.Columns[4].Visible = true;
            dgvDel.Columns[4].HeaderText = "Date Received";
            dgvDel.Columns[5].Visible = false;
            dgvDel.Columns[6].Visible = false;
            dgvDel.Columns[7].Visible = false;
            dgvDel.Columns[8].Visible = false;
            dgvDel.Columns[9].Visible = true;
            dgvDel.Columns[9].HeaderText = "Qty Bought";
            dgvDel.Columns[10].Visible = false;
            dgvDel.Columns[11].Visible = false;
            dgvDel.Columns[12].HeaderText = "Received By";
            dgvDel.Columns[13].Visible = false;
            dgvDel.Columns[14].Visible = false;
            dgvDel.Columns[15].Visible = false;
            dgvDel.Columns[16].Visible = false;
            dgvDel.Columns[17].Visible = false;
            dgvDel.Columns[18].Visible = false;
            dgvDel.Columns[19].Visible = false;
            dgvDel.Columns[20].Visible = false;
            dgvDel.Columns[21].Visible = false;
            dgvDel.Columns[22].Visible = false;
            dgvDel.Columns[23].HeaderText = "From Supplier";
            dgvDel.Columns[24].Visible = false;
            dgvDel.Columns[25].Visible = false;
            dgvDel.Columns[26].Visible = false;
            dgvDel.Columns[27].Visible = false;
            dgvDel.Columns[28].Visible = false;
            dgvDel.Columns[29].Visible = false;
            dgvDel.Columns[30].Visible = false;
            dgvDel.Columns[31].Visible = false;
            dgvDel.Columns[32].Visible = false;
            dgvDel.Columns[33].Visible = false;
            dgvDel.Columns[34].Visible = false;
            dgvDel.Columns[35].HeaderText = "Item Description";
            dgvDel.Columns[36].Visible = false;
            dgvDel.Columns[37].Visible = false;
            dgvDel.Columns[37].HeaderText = "Address";
            dgvDel.Columns[38].Visible = false;
            dgvDel.Columns[39].Visible = false;
            dgvDel.Columns["address2"].Visible = false;
            dgvDel.ClearSelection();
        }

        private void showDelLineSupRec(int id)// po_bid_line Receive
        {
            string sel = "SELECT * FROM jacammerchant.po_del_line pdl LEFT JOIN po_bid_line pbl ON pbl.po_bid_line_id = pdl.po_bid_line_id LEFT JOIN profile p ON p.prof_id = pdl.prof_id LEFT JOIN profile s ON s.prof_id = pbl.sup_id LEFT JOIN bid_items bi ON bi.item_id = pbl.item_id WHERE po_del_id = '" + id + "'";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvDel.DataSource = dt;
            dgvDel.Columns[0].Visible = false;
            dgvDel.Columns[1].Visible = false;
            dgvDel.Columns[2].Visible = false;
            dgvDel.Columns[3].Visible = true;
            dgvDel.Columns[3].HeaderText = "Qty Revieved";
            dgvDel.Columns[4].Visible = true;
            dgvDel.Columns[4].HeaderText = "Date Received";
            dgvDel.Columns[5].Visible = false;
            dgvDel.Columns[6].Visible = false;
            dgvDel.Columns[7].Visible = false;
            dgvDel.Columns[8].Visible = false;
            dgvDel.Columns[9].Visible = true;
            dgvDel.Columns[9].HeaderText = "Qty Bought";
            dgvDel.Columns[10].Visible = false;
            dgvDel.Columns[11].HeaderText = "PO Number";
            dgvDel.Columns[12].Visible = false;
            dgvDel.Columns[13].HeaderText = "Received By";
            dgvDel.Columns[14].Visible = false;
            dgvDel.Columns[15].Visible = false;
            dgvDel.Columns[16].Visible = false;
            dgvDel.Columns[17].Visible = false;
            dgvDel.Columns[18].Visible = false;
            dgvDel.Columns[19].Visible = false;
            dgvDel.Columns[20].Visible = false;
            dgvDel.Columns[21].Visible = false;
            dgvDel.Columns[22].Visible = false;
            dgvDel.Columns[23].Visible = false;
            dgvDel.Columns[24].HeaderText = "From Supplier";
            dgvDel.Columns[25].Visible = false;
            dgvDel.Columns[26].Visible = false;
            dgvDel.Columns[27].Visible = false;
            dgvDel.Columns[28].Visible = false;
            dgvDel.Columns[29].Visible = false;
            dgvDel.Columns[30].Visible = false;
            dgvDel.Columns[31].Visible = false;
            dgvDel.Columns[32].Visible = false;
            dgvDel.Columns[33].Visible = false;
            dgvDel.Columns[34].Visible = false;
            dgvDel.Columns[35].Visible = false;
            dgvDel.Columns[36].HeaderText = "Item Description";
            dgvDel.Columns[37].Visible = false;
            dgvDel.Columns[38].Visible = false;
            dgvDel.ClearSelection();
        }

        private void showDelSup()// show supplier side po_id_del
        {
            string sel = "SELECT * FROM po_Del pd WHERE pd.sup_id = '" + user_id+"' ";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvDel.DataSource = dt;
            dgvDel.ClearSelection();
            dgvDel.Columns[0].Visible = false;
            dgvDel.Columns[1].Visible = false;
            dgvDel.Columns[2].HeaderText = "Date Delivered";
            dgvDel.Columns[3].HeaderText = "Address";
            dgvDel.Columns[4].Visible = false;
            dgvDel.Columns[5].HeaderText = "Delivery receipt";
        }

        private void showPurchDelStaff()// Jacam Personel
        {
            string sel = "SELECT pd.*, p.name FROM po_del pd LEFT JOIN po_bid po ON po.po_bid_id = pd.po_bid_id LEFT JOIN profile p ON p.prof_id = pd.sup_id";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvDel.DataSource = dt;
            dgvDel.ClearSelection();
            dgvDel.Columns[0].Visible = false;
            dgvDel.Columns[1].Visible = false;
            dgvDel.Columns[2].HeaderText = "Date Delivered";
            dgvDel.Columns[3].HeaderText = "Address";
            dgvDel.Columns[4].Visible = false;
            dgvDel.Columns[5].HeaderText = "Delivery receipt";
            dgvDel.Columns[6].HeaderText = "From Supplier";
        }

        private void dgvDel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (user_type == 4 && offset != 1)
            {
                int ri = dgvDel.CurrentRow.Index;
                if (ri >= 0)
                {
                    btnView.Text = "Deliver";
                    btnView.Hide();
                    int id = int.Parse(dgvDel.Rows[ri].Cells[0].Value.ToString());
                    showDelLineSup(id);
                    offset = 2;
                }
            }
        }

        private void purchaseOrderDelivery_Load(object sender, EventArgs e)
        {
            if (user_type == 5 || user_type == 1 && offset != 1)
            {
                showPurchDelStaff();
                btnView.Text = "View";
            }
            else if (user_type == 4)
            {
                showDelSup();
                btnView.Text = "View";
            }
            else
            {
                MessageBox.Show("Walay User do!");
            }
        }
        private int offset;
        public int quant { get; set; }
        private void btnView_Click(object sender, EventArgs e)
        {
            if (offset == 1 || offset == 0)
            {
                if (dgvDel.Rows.Count >= 1)
                {
                    int ri = dgvDel.CurrentRow.Index;
                    if (ri >= 0)
                    {
                        int id = int.Parse(dgvDel.Rows[ri].Cells[0].Value.ToString());
                        if (user_type == 5 || user_type == 1 && user_type != 4)
                        {
                            showDelLineSupRec(id);
                            btnView.Text = "Receive";
                            offset = 2;
                            
                        }
                        else if (user_type == 4 && btnView.Text == "View")
                        {
                            btnView.Hide();
                            showDelLineSup(id);
                            offset = 1;
                        }
                    }
                }
            }
            else if(user_type == 5 || user_type == 1 && offset == 2)
            {
                int ri = dgvDel.CurrentRow.Index;
                if (ri >= 0)
                {
                    conn.Open();
                    string ch = "SELECT date_rec, date_del FROM po_del_line pdl, po_del pd WHERE line_id = '"+ dgvDel.Rows[ri].Cells[0].Value.ToString()+"' AND pd.po_del_id = pdl.po_del_id";
                    MySqlCommand comm2 = new MySqlCommand(ch, conn);
                    MySqlDataAdapter adp2 = new MySqlDataAdapter(comm2);
                    comm2.ExecuteNonQuery();
                    DataTable dt2 = new DataTable();
                    adp2.Fill(dt2);
                    conn.Close();
                    if (dt2.Rows[0][0].ToString() == "")
                    {
                        if (dgvDel.Rows[ri].Cells[7].Value.ToString() != "")
                        {
                            int id = int.Parse(dgvDel.Rows[ri].Cells[0].Value.ToString());
                            addQuantity add = new addQuantity();
                            add.offSet = 4;
                            add.limit = int.Parse(dgvDel.Rows[ri].Cells[9].Value.ToString());
                            add.rec = this;
                            add.ShowDialog();
                            conn.Open();
                            string checkDate = "SELECT DATEDIFF('"+ DateTime.Parse(dt2.Rows[0][1].ToString()).ToString("yyyy-MM-dd") + "', '"+ lbldate.Text +"')";
                            comm2 = new MySqlCommand(checkDate, conn);
                            adp2 = new MySqlDataAdapter(comm2);
                            comm2.ExecuteNonQuery();
                            DataTable dt3 = new DataTable();
                            adp2.Fill(dt3);
                            conn.Close();
                            if (int.Parse(dt3.Rows[0][0].ToString()) <= 0 || dt3.Rows[0][0].ToString() != "")
                            {
                                if (quant > 0)
                                {
                                    string upd = "UPDATE po_del_line SET qty_rec = '" + quant + "', date_rec ='" + DateTime.Today.ToString("yyyy-MM-dd") + "', prof_id = '" + user_id + "' WHERE line_id = '" + dgvDel.Rows[ri].Cells[0].Value.ToString() + "'";
                                    conn.Open();
                                    MySqlCommand comm = new MySqlCommand(upd, conn);
                                    comm.ExecuteNonQuery();
                                    string ins = "INSERT INTO stock_in VALUES(NULL, '" + dgvDel.Rows[ri].Cells[8].Value.ToString() + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', '" + quant + "', '" + user_id + "', '" + dgvDel.Rows[ri].Cells[35].Value.ToString() + "')";
                                    comm = new MySqlCommand(ins, conn);
                                    comm.ExecuteNonQuery();
                                    string ser = "SELECT item_id, qty FROM inventory WHERE des = '" + dgvDel.Rows[ri].Cells[36].Value.ToString() + "'";
                                    comm = new MySqlCommand(ser, conn);
                                    MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                                    comm.ExecuteNonQuery();
                                    DataTable dt = new DataTable();
                                    adp.Fill(dt);
                                    if (dt.Rows.Count == 1)
                                    {
                                        int qt = int.Parse(dt.Rows[0][1].ToString()) + int.Parse(dgvDel.Rows[ri].Cells[9].Value.ToString());
                                        upd = "UPDATE inventory SET qty = '" + qt + "' WHERE item_id = '" + dt.Rows[0][0].ToString() + "'";
                                        comm = new MySqlCommand(upd, conn);
                                        comm.ExecuteNonQuery();
                                    }
                                    else
                                    {
                                        ins = "INSERT INTO inventory VALUES(NULL, '" + dgvDel.Rows[ri].Cells[36].Value.ToString() + "','" + quant + "', NULL)";
                                        comm = new MySqlCommand(ins, conn);
                                        comm.ExecuteNonQuery();
                                    }
                                    conn.Close();
                                    offset = 1;
                                    if (quant < int.Parse(dgvDel.Rows[ri].Cells[9].Value.ToString()))
                                    {
                                        int excess = int.Parse(dgvDel.Rows[ri].Cells[9].Value.ToString()) - quant;
                                        DialogResult res = MessageBox.Show("Do you want to set the date for the damaged items now?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                        if (DialogResult.OK == res)
                                        {
                                            addDate det = new addDate();
                                            det.del = this;
                                            det.offSet = 1;
                                            det.ShowDialog();
                                            ins = "INSERT INTO po_return VALUES(NULL, '" + dgvDel.Rows[ri].Cells[0].Value.ToString() + "', '" + dtpDate + "', '" + user_id + "', NULL, NULL, NULL, '"+excess+"')";
                                        }
                                        else
                                        {
                                            ins = "INSERT INTO po_return VALUES(NULL, '"+dgvDel.Rows[ri].Cells[0].Value.ToString()+ "', NULL, NULL, NULL, NULL , '" + excess + "')";
                                        }
                                        int re = int.Parse(dgvDel.Rows[ri].Cells[9].Value.ToString()) - quant;
                                        MessageBox.Show("Incomplete Items Received Successfully!", "");
                                        conn.Open();
                                        comm = new MySqlCommand(ins, conn);
                                        comm.ExecuteNonQuery();
                                        conn.Close();
                                        MessageBox.Show("You can update the return date from the Return Form from the Dashboard.", "Successfully Set!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Received All Items Successfully!", "");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("You must Receive more than 0 items!", "");
                                }
                                
                            }
                            else
                            {
                                MessageBox.Show("You cannot Receive Items Now! Please see Date Delivery Before receiving", "");
                            }
                            offset = 1;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Already Received! Cannot Receive again", "Please Choose another Item!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnView.Enabled = false;
                        btnView.BackColor = Color.LightGray;
                        btnView.ForeColor = Color.White;
                    }
                }
            }
        }

        private void purchaseOrderDelivery_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevform.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (offset == 2 || offset == 1)
            {
                if (user_type == 5 || user_type == 1)
                {
                    dgvDel.DataSource = null;
                    showPurchDelStaff();
                    btnView.Text = "View";
                }
                else if (user_type == 4)
                {
                    btnView.Show();
                    showDelSup();
                    btnView.Text = "View";
                }
                else
                {
                    MessageBox.Show("Walay User do!");
                }
                offset = 0;
            }
            else
            {
                this.Close();
            }
        }

        private void dgvDel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            int ri = dgvDel.CurrentRow.Index;
            if (ri >= 0)
            {
                if (offset == 1)
                {
                    string check = dgvDel.Rows[ri].Cells[4].Value.ToString();
                    if (check == "")
                    {
                        btnView.Enabled = true;
                        btnView.BackColor = Color.DeepSkyBlue;
                        btnView.ForeColor = Color.White;
                    }else
                    {
                        btnView.Enabled = false;
                        btnView.BackColor = Color.LightGray;
                        btnView.ForeColor = Color.White;
                    }
                }
            }
            */
        }
    }
}
