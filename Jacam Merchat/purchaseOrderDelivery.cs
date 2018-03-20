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
            btnRet.Hide();
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
            dgvDel.DataSource = null;
            string sel = "SELECT pdl.*, pbl.po_num, bi.name, p.name AS 'person', prl.qty FROM jacammerchant.po_del_line pdl LEFT JOIN po_bid_line pbl ON pbl.po_bid_line_id = pdl.po_bid_line_id LEFT JOIN profile p ON p.prof_id = pdl.prof_id LEFT JOIN bid_items bi ON bi.item_id = pdl.item_id LEFT JOIN po_del pd ON pdl.po_del_id = pd.po_del_id LEFT JOIN po_return_line prl ON prl.po_del_line_id = pdl.po_del_line_id WHERE pdl.po_del_id = '" + id+"' AND pd.sup_id = '"+user_id+"'";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvDel.DataSource = dt;
            dgvDel.ClearSelection();
            dgvDel.Columns["name"].HeaderText = "Item Description";
            dgvDel.Columns["po_del_line_id"].Visible = false;
            dgvDel.Columns["po_del_id"].Visible = false;
            dgvDel.Columns["po_bid_line_id"].Visible = false;
            dgvDel.Columns["item_id"].Visible = false;
            dgvDel.Columns["qtyToDel"].HeaderText = "Qty Bought";
            dgvDel.Columns["qty_rec"].HeaderText = "Qty Received";
            dgvDel.Columns["date_rec"].HeaderText = "Date Received";
            dgvDel.Columns["prof_id"].Visible = false;
            dgvDel.Columns["qtyDel"].Visible = false;
            dgvDel.Columns["po_num"].Visible = false;
            dgvDel.Columns["person"].HeaderText = "Received By";
            //dgvDel.Columns["qty"].HeaderText = "Returned Qtys";
        }

        private void showDelLineSupRec(int id)// po_bid_line Receive
        {
            //dgvDel.Columns.Remove("txt");
            dgvDel.DataSource = null;
            string sel = "SELECT pdl.*, pbl.*, p.name, s.name , bi.name AS 'itemDes', b.bid_id FROM jacammerchant.po_del_line pdl LEFT JOIN po_bid_line pbl ON pbl.po_bid_line_id = pdl.po_bid_line_id LEFT JOIN profile p ON p.prof_id = pdl.prof_id LEFT JOIN profile s ON s.prof_id = pbl.sup_id LEFT JOIN bid_items bi ON bi.item_id = pbl.item_id LEFT JOIN bid b ON bi.bid_id = b.bid_id WHERE po_del_id = '" + id + "'";
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
            dgvDel.Columns[3].Visible = false;
            dgvDel.Columns[4].HeaderText = "QTY Bought";
            dgvDel.Columns[5].HeaderText = "Recieved QTY";
            dgvDel.Columns[6].HeaderText = "Date Received";
            dgvDel.Columns[7].Visible = false;
            dgvDel.Columns[8].HeaderText = "Delivered QTY";
            dgvDel.Columns[9].HeaderText = "Returnables";
            dgvDel.Columns[10].Visible = false;
            dgvDel.Columns[11].Visible = false;
            dgvDel.Columns[12].Visible = false;
            dgvDel.Columns[13].Visible = false;
            dgvDel.Columns[14].Visible = false;
            dgvDel.Columns[15].HeaderText = "PO No.";
            dgvDel.Columns[16].HeaderText = "Deliverables";
            dgvDel.Columns[17].Visible = false;
            dgvDel.Columns[18].Visible = false;
            dgvDel.Columns[19].HeaderText = "Item Description";
            dgvDel.Columns[20].Visible = false;
            dgvDel.Columns[4].ReadOnly = true;
            dgvDel.Columns[5].ReadOnly = true;
            dgvDel.Columns[6].ReadOnly = true;
            dgvDel.Columns[8].ReadOnly = true;
            dgvDel.Columns[14].ReadOnly = true;
            dgvDel.Columns[15].ReadOnly = true;
            dgvDel.Columns[18].ReadOnly = true;
            dgvDel.Columns[19].ReadOnly = true;
            dgvDel.Columns[20].ReadOnly = true;
            dgvDel.ClearSelection();
            int c = 0;
            for (int i = 0; i < dgvDel.Rows.Count; i++)
            {
                if (dgvDel.Rows[i].Cells[15].Value.ToString() != "")
                {
                    c++;
                }
            }
            if (c > 0)
            {
                DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
                txt.Name = "txt";
                txt.HeaderText = "Items to be Returned";
                dgvDel.Columns.Add(txt);
                for (int i = 0; i < dgvDel.Rows.Count; i++)
                {
                    dgvDel.Rows[i].Cells["txt"].Value = 0;
                }
                btnRet.Show();
            }
        }

        private void showDelSup()// show supplier side po_id_del
        {
            dgvDel.DataSource = null;
            this.Refresh();
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
            DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
            txt.Name = "txt";
            txt.HeaderText = "Status";
            dgvDel.Columns.Add(txt);
            conn.Open();
            for (int i =0; dgvDel.Rows.Count > i; i++)
            {
                int c = 0;
                string ch = "SELECT qtyRem FROM po_del_line pdl LEFT JOIN po_bid_line pbl ON pdl.po_bid_line_id = pbl.po_bid_line_id WHERE po_del_id = '" + dgvDel.Rows[i].Cells[0].Value.ToString()+"'";
                comm = new MySqlCommand(ch, conn);
                adp = new MySqlDataAdapter(comm);
                comm.ExecuteNonQuery();
                dt = new DataTable();
                adp.Fill(dt);
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (int.Parse(dt.Rows[j][0].ToString()) > 0)
                    {
                        c++;
                    }
                }
                if(c > 0)
                {
                    dgvDel.Rows[i].Cells["txt"].Value = "Partially Delivered!";
                    dgvDel.Rows[i].Cells["txt"].Style.ForeColor = Color.Coral;
                }
                else if (c == 0)
                {
                    dgvDel.Rows[i].Cells["txt"].Value = "Fully Delivered!";
                    dgvDel.Rows[i].Cells["txt"].Style.ForeColor = Color.Green;
                }
                else
                {
                    dgvDel.Rows[i].Cells["txt"].Value = "Som Ting Wong!";
                    dgvDel.Rows[i].Cells["txt"].Style.ForeColor = Color.Red;
                }
            }
            conn.Close();
        }

        private void showPurchDelStaff()// Jacam Personel
        {
            dgvDel.DataSource = null;
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
            /*DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
            txt.Name = "txt";
            txt.HeaderText = "Status";
            dgvDel.Columns.Add(txt);
            conn.Open();
            if (dgvDel.Rows.Count > 0 || int.Parse(dgvDel.Rows[0].Cells[0].Value.ToString()) >= 0)
            {
                for (int i = 0; dgvDel.Rows.Count > i; i++)
                {
                    int c = 0;
                    string ch = "SELECT qtyRem FROM po_del_line pdl LEFT JOIN po_bid_line pbl ON pdl.po_bid_line_id = pbl.po_bid_line_id WHERE po_del_id = '" + dgvDel.Rows[i].Cells[0].Value.ToString() + "'";
                    comm = new MySqlCommand(ch, conn);
                    adp = new MySqlDataAdapter(comm);
                    comm.ExecuteNonQuery();
                    dt = new DataTable();
                    adp.Fill(dt);
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        if (int.Parse(dt.Rows[j][0].ToString()) > 0)
                        {
                            c++;
                        }
                    }
                    if (c > 0)
                    {
                        dgvDel.Rows[i].Cells["txt"].Value = "Partially Delivered!";
                        dgvDel.Rows[i].Cells["txt"].Style.ForeColor = Color.Coral;
                    }
                    else if (c == 0)
                    {
                        dgvDel.Rows[i].Cells["txt"].Value = "Fully Delivered!";
                        dgvDel.Rows[i].Cells["txt"].Style.ForeColor = Color.Green;
                    }
                    else
                    {
                        dgvDel.Rows[i].Cells["txt"].Value = "Som Ting Wong!";
                        dgvDel.Rows[i].Cells["txt"].Style.ForeColor = Color.Red;
                    }
                }
            }*/
            conn.Close();
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
                    int id = int.Parse(dgvDel.Rows[ri].Cells["po_del_id"].Value.ToString());
                    showDelLineSup(id);
                    offset = 2;
                }
            }
        }

        private void purchaseOrderDelivery_Load(object sender, EventArgs e)
        {
            lblPO_del_id.Hide();
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
                        int id = int.Parse(dgvDel.Rows[ri].Cells["po_del_id"].Value.ToString());
                        if (user_type == 5 || user_type == 1 && user_type != 4)
                        {
                            showDelLineSupRec(id);
                            btnView.Text = "Receive Items";
                            offset = 2;
                        }
                        else if (user_type == 4 && btnView.Text == "View")
                        {
                            btnView.Hide();
                            showDelLineSup(id);
                            offset = 1;
                        }
                        lblPO_del_id.Text = id.ToString();
                    }
                }
            }
            else if (user_type == 5 || user_type == 1 && offset == 2)
            {
                int c = 0;
                for (int i = 0; i < dgvDel.Rows.Count; i++)
                {
                    int ri = i;
                    if (ri >= 0 )
                    {
                        conn.Open();
                        string ch = "SELECT date_rec, date_del FROM po_del_line pdl, po_del pd WHERE po_del_line_id = '" + dgvDel.Rows[ri].Cells[0].Value.ToString() + "' AND pd.po_del_id = pdl.po_del_id";
                        MySqlCommand comm2 = new MySqlCommand(ch, conn);
                        MySqlDataAdapter adp2 = new MySqlDataAdapter(comm2);
                        comm2.ExecuteNonQuery();
                        DataTable dt2 = new DataTable();
                        adp2.Fill(dt2);
                        conn.Close();
                        if (dt2.Rows[0][0].ToString() == "")
                        {
                            if (dgvDel.Rows[ri].Cells[5].Value.ToString() == "")
                            {
                                /*int id = int.Parse(dgvDel.Rows[ri].Cells[0].Value.ToString());
                                addQuantity add = new addQuantity();
                                add.offSet = 4;
                                add.limit = int.Parse(dgvDel.Rows[ri].Cells[8].Value.ToString());
                                add.rec = this;
                                add.ShowDialog();*/
                                conn.Open();
                                string checkDate = "SELECT DATEDIFF('" + DateTime.Parse(dt2.Rows[0][1].ToString()).ToString("yyyy-MM-dd") + "', '" + lbldate.Text + "')";
                                comm2 = new MySqlCommand(checkDate, conn);
                                adp2 = new MySqlDataAdapter(comm2);
                                comm2.ExecuteNonQuery();
                                DataTable dt3 = new DataTable();
                                adp2.Fill(dt3);
                                conn.Close();
                                quant = int.Parse(dgvDel.Rows[i].Cells["qtyDel"].Value.ToString());
                                if (int.Parse(dt3.Rows[0][0].ToString()) <= 0 || dt3.Rows[0][0].ToString() != "")
                                {
                                    if (quant > 0)
                                    {
                                        string upd = "UPDATE po_del_line SET qty_rec = '" + quant + "', date_rec ='" + DateTime.Today.ToString("yyyy-MM-dd") + "', prof_id = '" + user_id + "' WHERE po_del_line_id = '" + dgvDel.Rows[ri].Cells[0].Value.ToString() + "'";
                                        conn.Open();
                                        MySqlCommand comm = new MySqlCommand(upd, conn);
                                        comm.ExecuteNonQuery();
                                        string ins = "INSERT INTO stock_in VALUES(NULL, '" + dgvDel.Rows[ri].Cells[3].Value.ToString() + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', '" + quant + "', '" + user_id + "', '" + dgvDel.Rows[ri].Cells[20].Value.ToString() + "')";
                                        comm = new MySqlCommand(ins, conn);
                                        comm.ExecuteNonQuery();
                                        string ser = "SELECT item_id, qty FROM inventory WHERE des = '" + dgvDel.Rows[ri].Cells[18].Value.ToString() + "'";
                                        comm = new MySqlCommand(ser, conn);
                                        MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                                        comm.ExecuteNonQuery();
                                        DataTable dt = new DataTable();
                                        adp.Fill(dt);
                                        if (dt.Rows.Count == 1)
                                        {
                                            int qt = int.Parse(dt.Rows[0][1].ToString()) + int.Parse(dgvDel.Rows[ri].Cells[8].Value.ToString());
                                            upd = "UPDATE inventory SET qty = '" + qt + "' WHERE item_id = '" + dt.Rows[0][0].ToString() + "'";
                                            comm = new MySqlCommand(upd, conn);
                                            comm.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            ins = "INSERT INTO inventory VALUES(NULL, '" + dgvDel.Rows[ri].Cells[19].Value.ToString() + "','" + quant + "', NULL)";
                                            comm = new MySqlCommand(ins, conn);
                                            comm.ExecuteNonQuery();
                                        }
                                        conn.Close();
                                        offset = 1;
                                        if (quant < int.Parse(dgvDel.Rows[ri].Cells[8].Value.ToString()))
                                        {
                                            int excess = int.Parse(dgvDel.Rows[ri].Cells[8].Value.ToString()) - quant;
                                            DialogResult res = MessageBox.Show("Do you want to set the date for the damaged items now?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                            if (DialogResult.OK == res)
                                            {
                                                addDate det = new addDate();
                                                det.del = this;
                                                det.offSet = 1;
                                                det.ShowDialog();
                                                ins = "INSERT INTO po_return VALUES(NULL, '" + dgvDel.Rows[ri].Cells[0].Value.ToString() + "', '" + dtpDate + "', '" + user_id + "', NULL, NULL, NULL, '" + excess + "')";
                                            }
                                            else
                                            {
                                                ins = "INSERT INTO po_return VALUES(NULL, '" + dgvDel.Rows[ri].Cells[0].Value.ToString() + "', NULL, NULL, NULL, NULL , NULL, '" + excess + "')";
                                            }
                                            int re = int.Parse(dgvDel.Rows[ri].Cells[9].Value.ToString()) - quant;
                                            conn.Open();
                                            comm = new MySqlCommand(ins, conn);
                                            comm.ExecuteNonQuery();
                                            conn.Close();
                                            MessageBox.Show("Incomplete Items Received Successfully! You can update the return date from the Return Form from the Dashboard.", "Successfully Set!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            c++;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Item cannot be found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (c > 0)
                {
                    MessageBox.Show("Already Received! Cannot Receive again", "Please Choose another Item!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Received All Items Successfully!", "");
                }
                if (user_type == 5 || user_type == 1 && user_type != 4)
                {
                    dgvDel.DataSource = null;
                    dgvDel.Rows.Clear();
                    //showPurchDelStaff();
                    btnView.Text = "View";
                    btnRet.Hide();
                    offset = 0;
                }
                else if (user_type == 4 && btnView.Text == "View")
                {
                    showDelLineSup(int.Parse(lblPO_del_id.Text));
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
                    btnRet.Hide();
                    dgvDel.Columns.Remove("txt");
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

        public string det { get; set; }

        private void btnRet_Click(object sender, EventArgs e)
        {
            int c = 0;
            for (int i = 0; i < dgvDel.Rows.Count; i++)
            {
                if (int.Parse(dgvDel.Rows[i].Cells["txt"].Value.ToString()) != 0 || dgvDel.Rows[i].Cells["txt"].Value.ToString() == "" && dgvDel.Rows[i].Cells["qtyRet"].Value.ToString() != "0")
                {
                    c++;
                }
            }
            if (c > 0)
            {
                addDate add = new addDate();
                add.offSet = 4;
                add.delRet = this;
                add.ShowDialog();
                conn.Open();
                string set = "SELECT max(ret_id) FROM po_return";
                MySqlCommand com = new MySqlCommand(set, conn);
                MySqlDataAdapter ad = new MySqlDataAdapter(com);
                com.ExecuteNonQuery();
                DataTable d = new DataTable();
                ad.Fill(d);
                int rn = 0;
                if (d.Rows[0][0].ToString() == null || d.Rows[0][0].ToString() == "")
                {
                    rn = int.Parse(DateTime.Now.ToString("yyyyMMdd")) + 1;
                }else
                {
                    rn = int.Parse(DateTime.Now.ToString("yyyyMMdd")) + int.Parse(d.Rows[0][0].ToString());
                }
                conn.Close();
                string ins = "INSERT INTO po_return VALUES(NULL, '" + lblPO_del_id.Text + "', '" + det + "', '" + user_id + "', null, null, '"+rn+"');";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(ins, conn);
                comm.ExecuteNonQuery();
                string sel = "SELECT max(ret_id), rn FROM po_return";
                comm = new MySqlCommand(sel, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                comm.ExecuteNonQuery();
                DataTable dt = new DataTable();
                DataTable drn = new DataTable();
                adp.Fill(dt);
                adp.Fill(drn);
                int o = 0;
                for (int i = 0; i < dgvDel.Rows.Count; i++)
                {
                    if (int.Parse(dgvDel.Rows[i].Cells["qtyRet"].Value.ToString()) - int.Parse(dgvDel.Rows[i].Cells["txt"].Value.ToString()) < 0)
                    {
                        dgvDel.Rows[i].Cells["txt"].Value = dgvDel.Rows[i].Cells["qtyRet"].Value.ToString();
                        o++;
                    }
                    if (int.Parse(dgvDel.Rows[i].Cells["txt"].Value.ToString()) != 0 || dgvDel.Rows[i].Cells["txt"].Value.ToString() != "" && int.Parse(dgvDel.Rows[i].Cells["txt"].Value.ToString()) > 0)
                    {
                        ins = "INSERT INTO po_return_line VALUES(NULL, '" + dt.Rows[0][0].ToString() + "', '" + dgvDel.Rows[i].Cells["po_del_line_id"].Value.ToString() + "', '" + dgvDel.Rows[i].Cells["item_id"].Value.ToString() + "', '" + dgvDel.Rows[i].Cells["txt"].Value.ToString() + "', '"+ dgvDel.Rows[i].Cells["txt"].Value.ToString() + "')";
                        comm = new MySqlCommand(ins, conn);
                        comm.ExecuteNonQuery();
                        sel = "SELECT item_id, qty FROM inventory WHERE des = '"+ dgvDel.Rows[i].Cells[19].Value.ToString() + "'";
                        comm = new MySqlCommand(sel,conn);
                        adp = new MySqlDataAdapter(comm);
                        comm.ExecuteNonQuery();
                        DataTable dtr = new DataTable();
                        adp.Fill(dtr);
                        int excess = int.Parse(dtr.Rows[0][1].ToString()) - int.Parse(dgvDel.Rows[i].Cells["txt"].Value.ToString());
                        string upd = "UPDATE inventory set qty = '"+ excess +"' WHERE item_id = '"+ dtr.Rows[0][0].ToString() +"'";
                        comm = new MySqlCommand(upd, conn);
                        comm.ExecuteNonQuery();
                        int ret = int.Parse(dgvDel.Rows[i].Cells["qtyRet"].Value.ToString()) - int.Parse(dgvDel.Rows[i].Cells["txt"].Value.ToString());
                        upd = "UPDATE po_del_line set qtyRet = '" + ret + "' WHERE po_del_line_id = '" + dgvDel.Rows[i].Cells["po_del_line_id"].Value.ToString() + "'";
                        comm = new MySqlCommand(upd, conn);
                        comm.ExecuteNonQuery();
                        ins = "INSERT INTO stock_out_ret VALUES(NULL, '"+ dtr.Rows[0][0].ToString() + "', '"+det+"', '"+ dgvDel.Rows[i].Cells["txt"].Value.ToString() + "', '"+user_id+"', '"+drn.Rows[0][0].ToString()+"')";
                        comm = new MySqlCommand(ins, conn);
                        comm.ExecuteNonQuery();
                    }
                }
                if (o > 0)
                {
                    MessageBox.Show("Some of the items returned exceed more than the returnables so it automatically set it to the highest possible returns.","", MessageBoxButtons.OK);
                }
                MessageBox.Show("Successfully Returned!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                showDelLineSupRec(int.Parse(lblPO_del_id.Text));
            }
            else
            {
                MessageBox.Show("You must return more than 0 items!","", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }
    }
}
