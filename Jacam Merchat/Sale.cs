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
    public partial class Sale : MetroFramework.Forms.MetroForm
    {
        MySqlConnection conn;
        public int user_id { get; set; }
        public int user_type { get; set; }
        private int id;
        private DataTable dt2;
        public Dashboard prevform { get; set; }
        public Sale()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost; database=jacammerchant; uid=root; pwd=root");
            btnSupBack.Hide();
            btnDeliver.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            prevform.Show();
            this.Close();
        }
        private void showSup()//Supplier
        {
            //string sel = "SELECT bi.name, c.qty, bs.date_purch, b.title, p.name FROM bid_sales bs LEFT JOIN cart c ON bs.cart_id = c.cart_id LEFT JOIN bid_offer bo ON bo.bid_offer_id = c.bid_offer_id LEFT JOIN bid_items bi ON bo.item_id = bi.item_id LEFT JOIN bid b ON bi.bid_id = b.bid_id LEFT JOIN profile p ON p.prof_id = bs.prof_id WHERE bo.user_id = '"+user_id+"'";
            string sel = "SELECT * FROM jacammerchant.po_bid pb  LEFT JOIN profile pr ON pr.prof_id = pb.prof_id LEFT JOIN po_bid_line pbl ON pb.po_bid_id = pbl.po_bid_id WHERE sup_id = 10";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dt2 = dt;
            dgvSales.DataSource = dt;
        }

        private void showBid(int id)//What Bid (SUpplier)
        {
            // LEFt JOIN bid_offer bo ON bo.item_id = pbl.item_id 
            string sel = "SELECT * FROM po_bid_line pbl LEFT JOIN bid_items bi ON bi.item_id = pbl.item_id WHERE sup_id = '"+user_id+"' and po_bid_id = '"+id+"' ";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dt2 = dt;
            dgvSales.DataSource = dt;
        }

        public void showSales()//Admin
        {
            string sel = "";
            if (user_type == 1)
            {
                sel = "SELECT o.order_id, p.name, c.name, o.order_date, o.total, o.rn FROM jacammerchant.order o LEFT JOIN profile p ON o.user_id = p.prof_id LEFT JOIN profile c ON c.prof_id = o.prof_id";
            }else if (user_type == 3)
            {
                sel = "SELECT o.order_id, p.name, c.name, o.order_date, o.total, o.rn FROM jacammerchant.order o LEFT JOIN profile p ON o.user_id = p.prof_id LEFT JOIN profile c ON c.prof_id = o.prof_id WHERE o.user_id = '"+user_id+"'";
            }
            
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dt2 = dt;
            dgvSales.DataSource = dt;
            dgvSales.Columns[0].Visible = false;
            dgvSales.Columns[1].HeaderText = "Sold By";
            dgvSales.Columns[2].HeaderText = "Sold To";
            dgvSales.Columns[3].HeaderText = "Date Sold";
            dgvSales.Columns[4].HeaderText = "Total";
        }

        private void supSale_Load(object sender, EventArgs e)
        {
            if (user_type == 4)
            {
                showSup();
            }
            else if(user_type == 1|| user_type ==3)
            {
                showSales();
            }
            
        }

        private void supSale_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevform.Show();
        }

        private void dgvSales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (user_type == 4)
            {
                int ri = dgvSales.CurrentRow.Index;
                if (ri >= 0)
                {
                    id = int.Parse(dgvSales.Rows[ri].Cells[0].Value.ToString());
                    dgvSales.DataSource = null;
                    showBid(id);
                    btnSupBack.Show();
                    btnSupBack.Location = new Point(36, 100);
                    btnBack.Hide();
                    btnView.Hide();
                    btnDeliver.Show();
                    btnDeliver.Location = new Point(558, 100);
                }
            }else if(user_type == 5 || user_type == 3 || user_type == 1)
            {

            }
        }

        private void btnSupBack_Click(object sender, EventArgs e)
        {
            btnBack.Show();
            btnSupBack.Hide();
            btnDeliver.Hide();
            btnView.Show();
            showSup();
        }

        private void btnDeliver_Click(object sender, EventArgs e)
        {
           int ri = dgvSales.CurrentRow.Index;
            if(ri >= 0)
            {
                addAddressSupplier add = new addAddressSupplier();
                add.po_id = id;
                add.user_id = user_id;
                add.user_type = user_type;
                add.dt = dt2;
                add.ShowDialog();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            int ri = dgvSales.CurrentRow.Index;
            if (ri >= 0 )
            {
                btnSupBack.Show();
                btnSupBack.Location = new Point(36, 100);
                btnBack.Hide();
                btnView.Hide();
                btnDeliver.Show();
                btnDeliver.Location = new Point(558, 100);
                id = int.Parse(dgvSales.Rows[ri].Cells[0].Value.ToString());
                dgvSales.DataSource = null;
                showBid(id);
            }
        }
    }
}
