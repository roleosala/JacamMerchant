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
    public partial class biddedItems : MetroFramework.Forms.MetroForm
    {
        MySqlConnection conn;
        public int user_id { get; set; }
        public int user_type { get; set; }
        public biddedItems()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost; database=jacammerchant; uid=root; pwd=root");
            showItems();
            
        }
        public void showItems()
        {
            string sel = "SELECT bi.name, c.qty, c.date_added , bo.offer_price , p.name, bi.item_id , c.cart_id, bo.bid_offer_id, bo.item_id, b.bid_id, b.title, c.status, bo.user_id FROM cart c LEFT JOIN bid_offer bo ON c.bid_offer_id = bo.bid_offer_id LEFT JOIN bid_items bi ON bi.item_id = bo.item_id LEFT JOIN profile p ON p.prof_id = bo.user_id LEFT JOIN bid b ON b.bid_id = bi.bid_id WHERE c.status = 0";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvBid.DataSource = dt;
            dgvBid.Columns[0].HeaderText = "Description";
            dgvBid.Columns[1].HeaderText = "Quantity Bought";
            dgvBid.Columns[2].HeaderText = "Date Added";
            dgvBid.Columns[3].HeaderText = "Offered Price";
            dgvBid.Columns[4].HeaderText = "Offered By";
            dgvBid.Columns[5].Visible = false;
            dgvBid.Columns[6].Visible = false;
            dgvBid.Columns[7].Visible = false;
            dgvBid.Columns[8].Visible = false;
            dgvBid.Columns[9].Visible = false;
            dgvBid.Columns[10].HeaderText = "From";
            dgvBid.Columns[11].Visible = false;
            dgvBid.Columns[12].Visible = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int selBidId(int item_id)
        {
            string sel = "SELECT b.bid_id FROM bid b LEFT JOIN bid_items bi ON bi.bid_id = b.bid_id where bi.item_id = '"+item_id+"'";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                return int.Parse(dt.Rows[0][0].ToString());
            }else
            {
                return 0;
            }
        }

        private int [] selSup_id()
        {
            string sel = "SELECT DISTINCT(bo.user_id) FROM cart c LEFT JOIN bid_offer bo ON c.bid_offer_id = bo.bid_offer_id LEFT JOIN bid_items bi ON bi.item_id = bo.item_id LEFT JOIN profile p ON p.prof_id = bo.user_id LEFT JOIN bid b ON b.bid_id = bi.bid_id WHERE c.status = 0";
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            int[] sup_id = new int[dt.Rows.Count];
            if (dt.Rows.Count >= 1)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sup_id[i] = (int.Parse(dt.Rows[i][0].ToString()));
                }
            }
            return sup_id;
        }

        public int bid_id;
        public int[] sup_id;

        private void btnRem_Click(object sender, EventArgs e)
        {
            int ri = dgvBid.CurrentRow.Index;
            if (ri >= 0)
            {
                
                string item_id = dgvBid.Rows[ri].Cells[8].Value.ToString();
                string bo_id = dgvBid.Rows[ri].Cells[7].Value.ToString();
                string sel = "SELECT qty_offer FROM bid_offer WHERE item_id = '"+item_id+"' AND bid_offer_id = '"+bo_id+"' ";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(sel, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                comm.ExecuteNonQuery();
                DataTable dt = new DataTable();
                adp.Fill(dt);
                conn.Close();
                if (dt.Rows.Count == 1)
                {
                    conn.Open();
                    int boqty = int.Parse(dt.Rows[0][0].ToString());
                    boqty = boqty + int.Parse(dgvBid.Rows[ri].Cells[1].Value.ToString());
                    string del = "DELETE FROM cart WHERE cart_id = '"+ dgvBid.Rows[ri].Cells[6].Value.ToString() + "'";
                    comm = new MySqlCommand(del, conn);
                    comm.ExecuteNonQuery();
                    string upd = "UPDATE bid_offer SET qty_offer = '"+boqty+"' WHERE item_id = '"+ dgvBid.Rows[ri].Cells[8].Value.ToString() + "'";
                    comm = new MySqlCommand(upd, conn);
                    comm.ExecuteNonQuery();
                    conn.Close();
                    showItems();
                    MessageBox.Show("Product Successfully Removed!","", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cannot remove current item.", "Item not found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            total();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            int cart_id;
            if (dgvBid.Rows.Count > 0)
            {
                conn.Open();
                string selRn = "SELECT max(po_bid_id) FROM po_bid";
                MySqlCommand comm = new MySqlCommand(selRn, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dtRn = new DataTable();
                adp.Fill(dtRn);
                int rn = 0;
                if (dtRn.Rows.Count == 0 || dtRn.Rows[0][0].ToString() == "" || dtRn.Rows[0][0].ToString() == null)
                {
                    rn = int.Parse(DateTime.Now.ToString("yyyyMMdd")) + 1;
                }else
                {
                    rn = int.Parse(DateTime.Now.ToString("yyyyMMdd")) + int.Parse(dtRn.Rows[0][0].ToString());
                }
                string ins = "INSERT INTO po_bid VALUES(NULL,  '" + user_id + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', '"+rn+"');";
                comm = new MySqlCommand(ins, conn);
                comm.ExecuteNonQuery();
                string sel = "SELECT max(po_num) FROM po_bid_line";
                comm = new MySqlCommand(sel, conn);
                adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                int[] sup = selSup_id();
                adp.Fill(dt);
                string po = "";
                string sel2 = "SELECT max(pb.po_bid_id) FROM po_bid pb;";
                comm = new MySqlCommand(sel2, conn);
                adp = new MySqlDataAdapter(comm);
                DataTable dt2 = new DataTable();
                adp.Fill(dt2);
                if (dt.Rows.Count == 1)
                {
                    int po_num = 0;
                    if (dt.Rows[0][0].ToString() == "" || dt.Rows[0][0].ToString() == null)
                    {
                        po_num = 1;
                    }else
                    {
                        po_num = int.Parse(dt.Rows[0][0].ToString());
                    }
                    string po_bid_id = dt2.Rows[0][0].ToString();
                    int[] pon = new int[sup.Length];
                    for (int i = 0; i < sup.Length; i++)
                    {
                        po_num += 1;
                        pon[i] = po_num;
                    }
                    for (int i = 0; i < dgvBid.Rows.Count; i++)
                    {
                        int sup_id = int.Parse(dgvBid.Rows[i].Cells[12].Value.ToString());
                        cart_id = int.Parse(dgvBid.Rows[i].Cells[6].Value.ToString());
                        string item_id = dgvBid.Rows[i].Cells[5].Value.ToString();
                        for (int j = 0; j < sup.Length; j++)
                        {
                            if (sup_id == sup[j])
                            {
                                po_num = pon[j];
                            }
                        }
                        po = "INSERT INTO po_bid_line VALUES(NULL, '"+ po_bid_id + "', '" + item_id + "', '"+ dgvBid.Rows[i].Cells[1].Value.ToString()+"', '"+ sup_id + "', '"+po_num+"', '"+ dgvBid.Rows[i].Cells[1].Value.ToString() + "')";
                        comm = new MySqlCommand(po, conn);
                        comm.ExecuteNonQuery();
                        string upd = "UPDATE cart SET status = 1 WHERE cart_id = '" + cart_id + "'";
                        comm = new MySqlCommand(upd, conn);
                        comm.ExecuteNonQuery();
                        int counter = i + 1;
                    }
                }
                conn.Close();
                showItems();
                MessageBox.Show("All items in the cart are purchased Successfully", "Purcahsed Successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No items currently inside in the cart.", "Empty Cart!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            /*for (int i = 0; i < dgvBid.Rows.Count; i++)
            {
                cart_id = int.Parse(dgvBid.Rows[i].Cells[6].Value.ToString());
                string upd = "UPDATE cart SET status = 1 WHERE cart_id = '" + cart_id + "'";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(upd, conn);
                comm.ExecuteNonQuery();
                string name = dgvBid.Rows[i].Cells[0].Value.ToString();
                
                conn.Close();
                string check = "SELECT item_id, qty FROM inventory WHERE des LIKE '"+ name + "' ";
                comm = new MySqlCommand(check, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count != 0 && dt.Rows[0][0].ToString() != "")
                {
                    int qty = int.Parse(dt.Rows[0][1].ToString()) + int.Parse(dgvBid.Rows[i].Cells[1].Value.ToString());
                        string updQty = "UPDATE inventory SET qty = '" + qty + "' WHERE item_id = '" + dt.Rows[0][0].ToString() + "'";
                        comm = new MySqlCommand(updQty, conn);
                        comm.ExecuteNonQuery();
                }
                else
                {
                    string inv = "INSERT INTO inventory VALUES(NULL, '" + dgvBid.Rows[i].Cells[0].Value.ToString() + "', '" + dgvBid.Rows[i].Cells[1].Value.ToString() + "', NULL)";
                    comm = new MySqlCommand(inv, conn);
                    comm.ExecuteNonQuery();
                }
                string ins = "INSERT INTO inventory VALUES(NULL, '" + dgvBid.Rows[i].Cells[6].Value.ToString() + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', '" + user_id + "');";
                comm = new MySqlCommand(ins, conn);
                comm.ExecuteNonQuery();
                string sel = "SELECT max(item_id) FROM inventory";
                comm = new MySqlCommand(sel, conn);
                adp = new MySqlDataAdapter(comm);
                comm.ExecuteNonQuery();
                dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    string si = "INSERT INTO stock_in VALUES(NULL, '" + dt.Rows[0][0].ToString() +"' ,'" + DateTime.Now.ToString("yyyy-MM-dd") + "', '" + dgvBid.Rows[i].Cells[1].Value.ToString() + "', '" + user_id + "')";
                    comm = new MySqlCommand(si, conn);
                    comm.ExecuteNonQuery();
                    conn.Close();
                }
                
            }*/
            total();
        }
        

        private void total()
        {
            if (dgvBid.Rows.Count > 0)
            {
                double total = 0;
                for (int i = 0; dgvBid.Rows.Count > i; i++)
                {
                    total += (double)Convert.ToDouble(dgvBid.Rows[i].Cells[3].Value.ToString());
                }
                lblTotal.Text = total.ToString("c");
            }
            else
            {
                int z = 0;
                lblTotal.Text = z.ToString("c");
            }
        }
        private void biddedItems_Load(object sender, EventArgs e)
        {
            total();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
