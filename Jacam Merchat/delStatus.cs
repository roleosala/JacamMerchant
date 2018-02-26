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
    public partial class delStatus : MetroFramework.Forms.MetroForm
    {
        MySqlConnection conn;
        public Delivery del { get; set; }
        public int user_id { get; set; }
        public int user_type { get; set; }
        public int order_id { get; set; }
        public delStatus()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost; database=jacammerchant; uid=root; pwd=root");
            //lblDelId.Hide();
            dgvItems.EnableHeadersVisualStyles = false;
            dgvItems.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
        }

        private void show()
        {
            string sh = "SELECT * FROM order_line ol LEFT JOIN inventory i ON i.item_id = ol.item_id WHERE ol.order_id = '"+order_id+"'";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sh, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            conn.Close();
            dgvItems.DataSource = dt;
            dgvItems.Columns[0].Visible = false;
            dgvItems.Columns[1].Visible = false;
            dgvItems.Columns[2].Visible = false;
            dgvItems.Columns[3].HeaderText = "QTY Bought";
            dgvItems.Columns[4].Visible = false;
            dgvItems.Columns[5].Visible = false;
            dgvItems.Columns[6].HeaderText = "Item Description";
            dgvItems.Columns[7].Visible = false;
            dgvItems.Columns[8].HeaderText = "Price";
            dgvItems.ClearSelection();
        }

        private void se()
        {
            string sh = "SELECT o.*, c.prof_id ,c.name, d.*, p.prof_id ,p.name FROM jacammerchant.orders o LEFT JOIN profile c ON c.prof_id = o.user_id LEFT JOIN delivery d ON d.order_id = o.order_id LEFT JOIN profile p ON p.prof_id = d.prof_id WHERE d.order_id = '" + order_id + "'";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sh, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            conn.Close();
            if (dt.Rows.Count == 1)
            {
                lblDelId.Text = dt.Rows[0]["del_id"].ToString();
                lbldr.Text = dt.Rows[0]["dr"].ToString();
                if (dt.Rows[0][6].ToString() == "1")
                {
                    lblStat.Text = "On Delivery";
                }
                lblAdd.Text = dt.Rows[0]["address"].ToString();
                lblClient.Text = dt.Rows[0][8].ToString();
                lblDelBy.Text = dt.Rows[0][18].ToString();
                lblPC.Text = dt.Rows[0]["postal"].ToString();
                lblOrder.Text = dt.Rows[0]["rn"].ToString();
                lblDelDate.Text = DateTime.Parse(dt.Rows[0][16].ToString()).ToString("yyyy-MM-dd");
            }
        }

        private void delStatus_Load(object sender, EventArgs e)
        {
            show();
            se();
            lblDelId.Text = order_id.ToString();
        }

        private void delStatus_FormClosing(object sender, FormClosingEventArgs e)
        {
            del.Show();
        }

        private void dgvItems_SelectionChanged(object sender, EventArgs e)
        {
            dgvItems.ClearSelection();
        }
    }
}
