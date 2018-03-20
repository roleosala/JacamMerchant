using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using MySql.Data.MySqlClient;
using Microsoft.VisualBasic;

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
            showSOR();
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
            dgvPro.Columns[0].Visible = false;
            dgvPro.Columns[1].HeaderText = "Description";
            dgvPro.Columns[2].HeaderText = "Qty";
            dgvPro.Columns[3].HeaderText = "Price";
            dgvPro.ClearSelection();
        }

        private void showSO()
        {
            string sel = "SELECT i.des, so.qty, p.name, so.date FROM stock_out so LEFT JOIN inventory i ON i.item_id = so.item_id LEFT JOIN profile p ON p.prof_id = so.user_id;";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvSO.DataSource = dt;
            dgvSO.ClearSelection();
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
            dgvSI.ClearSelection();
        }

        private void showSOR()
        {
            string sel = "SELECT i.des, so.qty, p.name, so.date, pr.rn FROM stock_out_ret so LEFT JOIN inventory i ON i.item_id = so.item_id LEFT JOIN profile p ON p.prof_id = so.prof_id LEFT JOIN po_return pr ON pr.ret_id = so.ret_id;";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvSoR.DataSource = dt;
            dgvSoR.Columns[0].HeaderText = "Description";
            dgvSoR.Columns[1].HeaderText = "Returned QTY";
            dgvSoR.Columns[2].HeaderText = "Returned BY";
            dgvSoR.Columns[3].HeaderText = "Date Returned";
            dgvSoR.Columns[4].HeaderText = "Reference No.";
            dgvSoR.ClearSelection();
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
            for (int i = 0; i < dgvPro.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    dgvPro.Rows[i].DefaultCellStyle.BackColor = Color.Gainsboro;
                }
            }
            for (int i = 0; i < dgvSI.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    dgvSI.Rows[i].DefaultCellStyle.BackColor = Color.Gainsboro;
                }
            }
            for (int i = 0; i < dgvSO.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    dgvSO.Rows[i].DefaultCellStyle.BackColor = Color.Gainsboro;
                }
            }
            if (user_type == 3)
            {
                txtPrice.Hide();
                btnAddPrice.Hide();
            }
        }
        private void btnPrintSi_Click(object sender, EventArgs e)
        {
            printDialogSi.Document = PrintDocSi;
            if (printDialogSi.ShowDialog() == DialogResult.OK)
            {
                PrintDocSi.Print();
            }
        }

        private void PrintDocSi_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int x = 50;
            int y = 50;
            e.Graphics.DrawString("Jacam Merchant Stocks In Report", new Font("Times New Roman", 18, FontStyle.Bold), Brushes.Black, x, y);
            e.Graphics.DrawString("Date Printed:" + DateTime.Today.ToString("yyyy-MM-dd"), new Font("Times New Roman", 12, FontStyle.Italic), Brushes.Black, x += 550, 50);
            x = 50;
            y = 100;
            e.Graphics.DrawString("Description", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, x, y);
            e.Graphics.DrawString("Added QTY", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, x += 150, y );
            e.Graphics.DrawString("Added By", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, x += 150, y );
            e.Graphics.DrawString("Date Added", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, x += 170, y );
            e.Graphics.DrawString("From Bid", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, x += 170, y );
            x = 50;
            y = 130;
            int c = 0;
            for (int i=0; i < dgvSI.Rows.Count; i++)
            {
                e.Graphics.DrawString(dgvSI.Rows[i].Cells[0].Value.ToString(), new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, x, y);
                e.Graphics.DrawString(dgvSI.Rows[i].Cells[1].Value.ToString(), new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, x += 170, y);
                e.Graphics.DrawString(dgvSI.Rows[i].Cells[2].Value.ToString(), new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, x += 130, y);
                e.Graphics.DrawString(DateTime.Parse(dgvSI.Rows[i].Cells[3].Value.ToString()).ToString("yyyy-MM-dd"), new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, x += 170, y);
                e.Graphics.DrawString(dgvSI.Rows[i].Cells[4].Value.ToString(), new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, x += 170, y);
                x = 50;
                y += 25;
                c++;
            }
        }

        private void btnPrintSO_Click(object sender, EventArgs e)
        {
            printDialogSi.Document = PrintDocSO;
            if (printDialogSi.ShowDialog() == DialogResult.OK)
            {
                PrintDocSO.Print();
            }
        }

        private void PrintDocSO_PrintPage(object sender, PrintPageEventArgs e)
        {
            int x = 50;
            int y = 50;
            e.Graphics.DrawString("Jacam Merchant Stocks Out Report", new Font("Times New Roman", 18, FontStyle.Bold), Brushes.Black, x, y);
            e.Graphics.DrawString("Date Printed:" + DateTime.Today.ToString("yyyy-MM-dd"), new Font("Times New Roman", 12, FontStyle.Italic), Brushes.Black, x += 550, 50);
            x = 50;
            y = 100;
            e.Graphics.DrawString("Description", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, x, y);
            e.Graphics.DrawString("QTY OUT", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, x += 170, y);
            e.Graphics.DrawString("Sold By", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, x += 170, y);
            e.Graphics.DrawString("Date Sold", new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, x += 190, y);
            x = 50;
            y = 130;
            for (int i = 0; i < dgvSO.Rows.Count; i++)
            {
                e.Graphics.DrawString(dgvSO.Rows[i].Cells[0].Value.ToString(), new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, x, y);
                e.Graphics.DrawString(dgvSO.Rows[i].Cells[1].Value.ToString(), new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, x += 190, y);
                e.Graphics.DrawString(dgvSO.Rows[i].Cells[2].Value.ToString(), new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, x += 150, y);
                e.Graphics.DrawString(DateTime.Parse(dgvSO.Rows[i].Cells[3].Value.ToString()).ToString("yyyy-MM-dd"), new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, x += 190, y);
                x = 50;
                y += 25;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
