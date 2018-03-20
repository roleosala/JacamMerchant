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
        public string del_id { get; set; }
        public delStatus()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost; database=jacammerchant; uid=root; pwd=root");
            lblOrder_id.Hide();
            lbl_Del_id.Hide();
            dgvItems.EnableHeadersVisualStyles = false;
            dgvItems.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
        }

        private void show()
        {
            string sh = "select i.des,dl.*,  ol.qtyRem from delivery_line dl LEFT JOIN delivery d ON d.del_id = dl.del_id LEFT JOIN order_line ol ON ol.order_line_id = dl.order_line_id LEFT JOIN inventory i ON i.item_id = dl.item_id WHERE d.del_id = '" + del_id+"'";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sh, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            conn.Close();
            dgvItems.DataSource = dt;
            dgvItems.Columns[0].HeaderText = "Item Description";
            dgvItems.Columns[1].Visible = false;
            dgvItems.Columns[2].Visible = false;
            dgvItems.Columns[3].Visible = false;
            dgvItems.Columns[4].HeaderText = "Delivered QTYs";
            dgvItems.Columns[5].Visible = false;
            dgvItems.Columns[6].HeaderText = "Deliverables";
            dgvItems.ClearSelection();
        }

        private void se()
        {
            string sh = "SELECT d.*, o.*, del.name, c.name FROM jacammerchant.delivery d LEFT JOIN jacammerchant.order o ON o.order_id = d.order_id LEFT JOIN profile del ON del.prof_id = d.prof_id LEFT JOIN profile c ON c.prof_id = o.prof_id WHERE d.del_id = '" + del_id + "'";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sh, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            conn.Close();
            if (dt.Rows.Count == 1)
            {
                //lblDelId.Text = dt.Rows[0][8].ToString();
                lbl_Del_id.Text = dt.Rows[0]["del_id"].ToString();
                lbldr.Text = dt.Rows[0]["dr"].ToString();
                if (dt.Rows[0]["status"].ToString() == "1")
                {
                    lblStat.Text = "On Delivery";
                    lblStat.ForeColor = Color.Red;
                }else
                {
                    lblStat.Text = "Delivered";
                    lblStat.ForeColor = Color.Green;
                    btnUp.BackColor = Color.LightGray;
                    btnUp.Enabled = false;
                    btnUp.ForeColor = Color.White;
                }
                lblAdd.Text = dt.Rows[0]["address"].ToString();
                lblClient.Text = dt.Rows[0]["name1"].ToString();
                lblDelBy.Text = dt.Rows[0]["name"].ToString();
                lblPC.Text = dt.Rows[0]["postal"].ToString();
                lblOrder.Text = dt.Rows[0]["rn"].ToString();
                lblDelDate.Text = DateTime.Parse(dt.Rows[0]["del_date"].ToString()).ToString("yyyy-MM-dd");
                if (dt.Rows[0]["rec_date"].ToString() == "")
                {
                    lblDateRec.Text = "N/A";
                }
                else
                {
                    lblDateRec.Text = Convert.ToDateTime(dt.Rows[0]["rec_date"].ToString()).ToString("yyyy-MM-dd");
                }
            }
        }

        private void delStatus_Load(object sender, EventArgs e)
        {
            show();
            se();
            lblOrder_id.Text = order_id.ToString();
        }

        private void delStatus_FormClosing(object sender, FormClosingEventArgs e)
        {
            del.Show();
        }

        private void dgvItems_SelectionChanged(object sender, EventArgs e)
        {
            dgvItems.ClearSelection();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to updated delivery status to DELIVERED?","", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult.Yes == res)
            {
                conn.Open();
                string sel = "SELECT status FROM delivery WHERE del_id = '" + lbl_Del_id.Text + "'";
                MySqlCommand comm = new MySqlCommand(sel, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                comm.ExecuteNonQuery();
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        string upd = "UPDATE delivery SET status = 0, rec_date = '"+DateTime.Today.ToString("yyyy-MM-dd")+"' WHERE del_id = '" + lbl_Del_id.Text + "'";
                        comm = new MySqlCommand(upd, conn);
                        comm.ExecuteNonQuery();
                        MessageBox.Show("You have successfully updated the status to DELIVERED!", "Succesful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lblStat.Text = "Delivered";
                        lblStat.ForeColor = Color.Green;
                    }
                    else
                    {
                        MessageBox.Show("This has already been delivered.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                conn.Close();
                se();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
