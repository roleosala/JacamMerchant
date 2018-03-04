﻿using System;
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
            lblDelId.Hide();
            label10.Hide();
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
            string sh = "SELECT o.*, c.prof_id ,c.name, d.*, p.prof_id ,p.name FROM jacammerchant.order o LEFT JOIN profile c ON c.prof_id = o.prof_id LEFT JOIN delivery d ON d.order_id = o.order_id LEFT JOIN profile p ON p.prof_id = d.prof_id WHERE d.order_id = '" + order_id + "'";
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
                label10.Text = dt.Rows[0][8].ToString();
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
                lblClient.Text = dt.Rows[0][7].ToString();
                lblDelBy.Text = dt.Rows[0]["name1"].ToString();
                lblPC.Text = dt.Rows[0]["postal"].ToString();
                lblOrder.Text = dt.Rows[0]["rn"].ToString();
                lblDelDate.Text = DateTime.Parse(dt.Rows[0]["del_date"].ToString()).ToString("yyyy-MM-dd");
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

        private void btnUp_Click(object sender, EventArgs e)
        {
            conn.Open();
            string sel = "SELECT status FROM delivery WHERE del_id = '"+ label10.Text+"'";
            MySqlCommand comm = new MySqlCommand(sel , conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                if (dt.Rows[0][0].ToString() == "1")
                {
                    string upd = "UPDATE delivery SET status = 0 WHERE del_id = '" + label10.Text + "'";
                    comm = new MySqlCommand(upd, conn);
                    comm.ExecuteNonQuery();
                    MessageBox.Show("You have successfully updated the status to DELIVERED!", "Succesful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblStat.Text = "Delivered";
                    lblStat.ForeColor = Color.Green;
                }
                else
                {
                    MessageBox.Show("This has already been delivered.","", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            conn.Close();
        }
    }
}
