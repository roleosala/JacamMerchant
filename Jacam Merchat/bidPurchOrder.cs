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
        }

        private void showPurchOrderLine(int id) //staff
        {
            string sel = "SELECT * FROM po_bid_line pbl LEFT JOIN bid_items bi ON bi.item_id = pbl.item_id LEFT JOIN profile s ON s.prof_id = pbl.sup_id LEFT JOIN po_bid pb ON pb.po_bid_id = pbl.po_bid_id LEFT JOIN profile p ON p.prof_id = pb.prof_id JOIN bid b ON b.bid_id = bi.bid_id WHERE pbl.po_bid_id = '" + id+"'";
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
            dgvPO.Columns[2].Visible = false;
            dgvPO.Columns[3].HeaderText = "Purchased Quantity";
            dgvPO.Columns[4].Visible = false;
            dgvPO.Columns[5].Visible = false;
            dgvPO.Columns[6].Visible = false;
            dgvPO.Columns[7].HeaderText = "Item Description";
            dgvPO.Columns[8].Visible = false;
            dgvPO.Columns[9].Visible = false;
            dgvPO.Columns[10].Visible = false;
            dgvPO.Columns[11].HeaderText = "Offered By";
            dgvPO.Columns[12].Visible = false;
            dgvPO.Columns[13].Visible = false;
            dgvPO.Columns[14].Visible = false;
            dgvPO.Columns[15].Visible = false;
            dgvPO.Columns[16].Visible = false;
            dgvPO.Columns[17].Visible = false;
            dgvPO.Columns[18].Visible = false;
            dgvPO.Columns[19].Visible = false;
            dgvPO.Columns[20].Visible = false;
            dgvPO.Columns[21].Visible = false;
            dgvPO.Columns[22].Visible = false;
            dgvPO.Columns[23].Visible = false;
            dgvPO.Columns[24].Visible = false;
            dgvPO.Columns[25].Visible = false;
            dgvPO.Columns[26].HeaderText = "Purchased By";
            dgvPO.Columns[27].Visible = false;
            dgvPO.Columns[28].Visible = false;
            dgvPO.Columns[29].Visible = false;
            dgvPO.Columns[30].Visible = false;
            dgvPO.Columns[31].Visible = false;
            dgvPO.Columns[32].Visible = false;
            dgvPO.Columns[33].Visible = false;
            dgvPO.Columns[34].Visible = false;
            dgvPO.Columns[35].Visible = false;
            dgvPO.Columns[36].Visible = false;
            dgvPO.Columns[37].HeaderText = "From Bid";
            dgvPO.Columns[38].Visible = false;
            dgvPO.Columns[39].Visible = false;
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
            dgvPO.Columns[0].Visible = false;
            dgvPO.Columns[1].Visible = false;
            dgvPO.Columns[2].Visible = false;
            dgvPO.Columns[3].HeaderText = "QTY Bought";
            dgvPO.Columns[4].Visible = false;
            dgvPO.Columns[5].HeaderText = "Item Description";
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
        }

        public int quant { get; set; }

        private void btnDelRec_Click(object sender, EventArgs e)
        {
            int ri = dgvPO.CurrentRow.Index;
            if (ri >= 0)
            {
                int id = int.Parse(dgvPO.Rows[ri].Cells[0].Value.ToString());
                int po_bid_id = int.Parse(dgvPO.Rows[ri].Cells[1].Value.ToString());
                if (user_type == 1 || user_type == 5 && offset == 0)
                {
                    showPurchOrderLine(id);
                    offset = 1;
                    btnDelRec.Hide();
                }
                else if (user_type == 4)
                {
                    addAddressSupplier purch = new addAddressSupplier();
                    purch.user_id = user_id;
                    purch.user_type = user_type;
                    purch.po_id = id;
                    purch.po_bid_id = po_bid_id;
                    purch.ShowDialog();
                }
            }
        }
    }
}
