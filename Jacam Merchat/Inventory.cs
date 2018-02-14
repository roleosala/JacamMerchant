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
    public partial class Inventory : MetroFramework.Forms.MetroForm
    {
        MySqlConnection conn;
        public int user_id { get; set; }
        public int user_type { get; set; }
        public Dashboard prevform { get; set; }
        public Inventory()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost; database=jacammerchant; uid=root; pwd=root");
            showInv();
            showSO();
            showSI();
            lblId.Hide();
        }
        private void showInv()
        {
            string sel = "SELECT * FROM inventory";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvPro.DataSource = dt;
        }

        private void showSO()
        {
            string sel = "SELECT * FROM stock_out";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvSO.DataSource = dt;
        }

        private void showSI()
        {
            string sel = "SELECT bi.name, si.qty, p.name, si.date_added, b.title  FROM stock_in si LEFT JOIN inventory i ON si.item_id = i.item_id LEFT JOIN profile p ON p.prof_id = si.user_id LEFT JOIN bid_items bi ON bi.item_id = si.item_id LEFT JOIN bid b ON b.bid_id = si.bid_id ";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvSI.DataSource = dt;
            dgvSI.Columns[0].HeaderText = "Description";
            dgvSI.Columns[1].HeaderText = "Added QTY";
            dgvSI.Columns[2].HeaderText = "Added BY";
            dgvSI.Columns[3].HeaderText = "Date Added";
            dgvSI.Columns[4].HeaderText = "From Bid";
        }

        private void Inventory_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevform.Show();
        }

        private void btnAddPrice_Click(object sender, EventArgs e)
        {
            int ri = dgvPro.CurrentRow.Index;
            if (ri >= 0 && lblDes.Text != "No Product Selected")
            {
                string upd = "UPDATE inventory SET price = '"+txtPrice.Text+"' WHERE item_id = '"+dgvPro.Rows[ri].Cells[0].Value.ToString()+"'";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(upd, conn);
                comm.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Price Successfully Added!","", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showInv();
            }
        }

        private void dgvPro_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int ri = dgvPro.CurrentRow.Index;
            if (ri >= 0)
            {
                lblId.Text = dgvPro.Rows[ri].Cells[0].Value.ToString();
                lblDes.Text = dgvPro.Rows[ri].Cells[1].Value.ToString();
            }
        }

        private void Inventory_Load(object sender, EventArgs e)
        {

        }
    }
}
