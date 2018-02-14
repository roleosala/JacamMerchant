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
    public partial class Bids : MetroFramework.Forms.MetroForm
    {
        MySqlConnection conn;
        public Dashboard prevform{get;set;}
        public int user_id { get; set; }
        public int user_type { get; set; }
        public Bids()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost; database=jacammerchant; uid=root; pwd=root");
        }

        private void Bids_Load(object sender, EventArgs e)
        {
            show();
        }
        public void show()
        {
            string sel = "SELECT * FROM bid";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvViewBidItems.DataSource = dt;
            dgvViewBidItems.Columns[0].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addBidInfo add = new addBidInfo();
            add.user_id = user_id;
            add.user_type = user_type;
            add.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            prevform.Show();
            this.Close();
        }

        private void dgvViewBidItems_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int ri = dgvViewBidItems.CurrentRow.Index;
            if (ri >= 0)
            {
                int bid_id = int.Parse(dgvViewBidItems.Rows[ri].Cells[0].Value.ToString());
                addBidItems add = new addBidItems();
                add.bid_id = bid_id;
                add.user_id = user_id;
                add.user_type = user_type;
                add.ShowDialog();
            }
            
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            int ri = dgvViewBidItems.CurrentRow.Index;
            if (ri >= 0)
            {
                int bid_id = int.Parse(dgvViewBidItems.Rows[ri].Cells[0].Value.ToString());
                addBidItems add = new addBidItems();
                add.bid_id = bid_id;
                add.user_id = user_id;
                add.user_type = user_type;
                add.ShowDialog();
            }
        }

        private void btnViewItems_Click(object sender, EventArgs e)
        {
            int ri = dgvViewBidItems.CurrentRow.Index;
            if (ri >= 0)
            {
                int bid_id = int.Parse(dgvViewBidItems.Rows[ri].Cells[0].Value.ToString());
                addBidItems add = new addBidItems();
                add.bid_id = bid_id;
                add.user_id = user_id;
                add.user_type = user_type;
                add.offSet = 1;
                add.prevform = this;
                add.ShowDialog();
            }
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            biddedItems bid = new biddedItems();
            bid.user_id = user_id;
            bid.user_type = user_type;
            bid.ShowDialog();
        }
    }
}
