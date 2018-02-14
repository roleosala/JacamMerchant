using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework.Forms;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Jacam_Merchat
{
    public partial class OrderList : MetroForm
    {
        MySqlConnection conn;
        public Dashboard prevform { get; set; }
        public int user_id { get; set; }
        public int user_type { get; set; }
        public OrderList()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost; database=jacammerchant; uid=root; pwd=root");
            dgvView.Hide();
            btnBackdgv.Hide();
        }

        private void OrderList_Load(object sender, EventArgs e)
        {
            show();
        }
        public void show()
        {
            string show = "SELECT po_id, name, po_no, po_date FROM purch_order, profile WHERE purch_order.prof_id = profile.prof_id";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(show, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvOL.DataSource = dt;
            dgvOL.Columns["po_id"].Visible = false;
            dgvOL.Columns["name"].HeaderText = "Ordered By";
            dgvOL.Columns["po_no"].HeaderText = "Purchase Order Number";
            dgvOL.Columns["po_date"].HeaderText = "Purchased Date";
            dgvOL.ClearSelection();
        }

        private void OrderList_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevform.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            prevform.Show();
            this.Close();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            int ri = dgvOL.CurrentCell.RowIndex;
            if (ri >= 0)
            {
                int id = int.Parse(dgvOL.Rows[ri].Cells[0].Value.ToString());
                dgvView.Show();
                dgvOL.Hide();
                string show = "SELECT des, purch_order_line.qty, name FROM purch_order_line, product_supply, profile WHERE po_id = "+id+ " and purch_order_line.prod_id = product_supply.prod_id  AND profile.prof_id = product_supply.prof_id";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(show, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                comm.ExecuteNonQuery();
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dgvView.DataSource = dt;
                btnBackdgv.Show();
                btnBackForm.Hide();
                btnBackdgv.Location = new Point(23, 63);
            }
        }

        private void btnBackdgv_Click(object sender, EventArgs e)
        {
            btnBackdgv.Hide();
            btnBackForm.Show();
            dgvOL.Show();
            dgvView.Hide();
        }
    }
}
