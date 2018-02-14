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
        public purchaseOrderDelivery()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost; database=jacammerchant; uid=root; pwd=root");
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
            dgvDel.Columns[4].HeaderText = "Date Recieved";
            dgvDel.Columns[5].Visible = false;
            dgvDel.Columns[6].Visible = false;
            dgvDel.Columns[7].Visible = false;
            dgvDel.Columns[8].Visible = false;
            dgvDel.Columns[9].Visible = true;
            dgvDel.Columns[9].HeaderText = "Qty Bought";
            dgvDel.Columns[10].Visible = false;
            dgvDel.Columns[11].Visible = false;
            dgvDel.Columns[12].HeaderText = "Recieved By";
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
        }

        private void showDelLineSupRec(int id)// po_bid_line Recieve
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
            dgvDel.Columns[4].HeaderText = "Date Recieved";
            dgvDel.Columns[5].Visible = false;
            dgvDel.Columns[6].Visible = false;
            dgvDel.Columns[7].Visible = false;
            dgvDel.Columns[8].Visible = false;
            dgvDel.Columns[9].Visible = true;
            dgvDel.Columns[9].HeaderText = "Qty Bought";
            dgvDel.Columns[10].Visible = false;
            dgvDel.Columns[11].Visible = false;
            dgvDel.Columns[12].HeaderText = "Recieved By";
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
            dgvDel.ClearSelection();
        }

        private void showDelSup()// show supplier side po_id_del
        {
            string sel = "SELECT * FROM po_del pd LEFT JOIN po_bid po ON po.po_bid_id = pd.po_bid_id LEFT JOIN po_del_line pdl ON pdl.po_del_id = pd.po_del_id LEFT JOIN po_bid_line pbl ON pbl.po_bid_line_id = pdl.po_bid_line_id LEFT JOIN bid_items bi ON bi.item_id = pbl.item_id LEFT JOIN bid b ON b.bid_id = bi.bid_id LEFT JOIN profile p ON p.prof_id = pdl.prof_id WHERE pd.sup_id = '" + user_id+"' ";
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
            dgvDel.Columns[5].Visible = false;
            dgvDel.Columns[6].Visible = false;
            dgvDel.Columns[7].HeaderText = "Date Recieved";
            dgvDel.Columns[8].HeaderText = "Reference NO.";
            dgvDel.Columns[9].Visible = false;
            dgvDel.Columns[10].Visible = false;
            dgvDel.Columns[11].Visible = false;
            dgvDel.Columns[12].Visible = false;
            dgvDel.Columns[13].Visible = false;
            dgvDel.Columns[14].Visible = false;
            dgvDel.Columns[15].Visible = false;
            dgvDel.Columns[16].Visible = false;
            dgvDel.Columns[17].Visible = false;
            dgvDel.Columns[18].Visible = false;
            dgvDel.Columns[19].Visible = false;
            dgvDel.Columns[20].Visible = false;
            dgvDel.Columns[21].Visible = false;
            dgvDel.Columns[22].HeaderText = "Item Description";
            dgvDel.Columns[23].Visible = false;
            dgvDel.Columns[24].Visible = false;
            dgvDel.Columns[25].Visible = false;
            dgvDel.Columns[26].HeaderText = "From BID";
            dgvDel.Columns[27].Visible = false;
            dgvDel.Columns[28].Visible = false;
            dgvDel.Columns[29].Visible = false;
            dgvDel.Columns[30].HeaderText = "Recieved By";
            dgvDel.Columns[31].Visible = false;
            dgvDel.Columns[32].Visible = false;
            dgvDel.Columns[33].Visible = false;
            dgvDel.Columns[34].Visible = false;
            dgvDel.Columns[35].Visible = false;
            dgvDel.Columns[36].Visible = false;
            dgvDel.Columns[37].Visible = false;
            dgvDel.Columns[38].Visible = false;
            dgvDel.Columns[39].Visible = false;
        }

        private void showPurchDelStaff()// Jacam Personel
        {
            string sel = "SELECT * FROM po_del pd LEFT JOIN po_bid po ON po.po_bid_id = pd.po_bid_id LEFT JOIN po_del_line pdl ON pdl.po_del_id = pd.po_del_id LEFT JOIN po_bid_line pbl ON pbl.po_bid_line_id = pdl.po_bid_line_id LEFT JOIN bid_items bi ON bi.item_id = pbl.item_id LEFT JOIN bid b ON b.bid_id = bi.bid_id LEFT JOIN profile p ON p.prof_id = pd.sup_id";
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
            dgvDel.Columns[5].Visible = false;
            dgvDel.Columns[6].Visible = false;
            dgvDel.Columns[7].HeaderText = "Date Recieved";
            dgvDel.Columns[8].HeaderText = "Reference NO.";
            dgvDel.Columns[9].Visible = false;
            dgvDel.Columns[10].Visible = false;
            dgvDel.Columns[11].Visible = false;
            dgvDel.Columns[12].Visible = false;
            dgvDel.Columns[13].Visible = false;
            dgvDel.Columns[14].Visible = false;
            dgvDel.Columns[15].Visible = false;
            dgvDel.Columns[16].Visible = false;
            dgvDel.Columns[17].Visible = false;
            dgvDel.Columns[18].Visible = false;
            dgvDel.Columns[19].Visible = false;
            dgvDel.Columns[20].Visible = false;
            dgvDel.Columns[21].Visible = false;
            dgvDel.Columns[22].HeaderText = "Item Description";
            dgvDel.Columns[23].Visible = false;
            dgvDel.Columns[24].Visible = false;
            dgvDel.Columns[25].Visible = false;
            dgvDel.Columns[26].HeaderText = "From BID";
            dgvDel.Columns[27].Visible = false;
            dgvDel.Columns[28].Visible = false;
            dgvDel.Columns[29].Visible = false;
            dgvDel.Columns[30].HeaderText = "Supplier";
            dgvDel.Columns[31].Visible = false;
            dgvDel.Columns[32].Visible = false;
            dgvDel.Columns[33].Visible = false;
            dgvDel.Columns[34].Visible = false;
            dgvDel.Columns[35].Visible = false;
            dgvDel.Columns[36].Visible = false;
            dgvDel.Columns[37].Visible = false;
            dgvDel.Columns[38].Visible = false;
            dgvDel.Columns[39].Visible = false;
        }

        private void dgvDel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (user_type == 4 && offset != 1)
            {
                int ri = dgvDel.CurrentRow.Index;
                if (ri >= 0)
                {
                    int id = int.Parse(dgvDel.Rows[ri].Cells[0].Value.ToString());
                    showDelLineSup(id);
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
                            btnView.Text = "Recieve";
                            offset = 2;
                            
                        }
                        else if (user_type == 4)
                        {
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
                    int id = int.Parse(dgvDel.Rows[ri].Cells[0].Value.ToString());
                    addQuantity add = new addQuantity();
                    add.offSet = 4;
                    add.limit = int.Parse(dgvDel.Rows[ri].Cells[9].Value.ToString());
                    add.rec = this;
                    add.ShowDialog();
                    if (quant > 0)
                    {
                        string upd = "UPDATE po_del_line SET qty_rec = '" + quant + "', date_rec ='" + DateTime.Today.ToString("yyyy-MM-dd") + "', prof_id = '" + user_id + "' WHERE line_id = '" + dgvDel.Rows[ri].Cells[0].Value.ToString() + "'";
                        conn.Open();
                        MySqlCommand comm = new MySqlCommand(upd, conn);
                        comm.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Recieved Successfully!", "");
                        offset = 1;
                    }else
                    {
                        MessageBox.Show("You must recieve more than 0 items!","");
                    }
                    showPurchDelStaff();
                    offset = 1;
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
    }
}
