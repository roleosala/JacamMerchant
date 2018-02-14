using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;

namespace Jacam_Merchat
{
    public partial class PurcharseOrder : MetroForm
    {
        MySqlConnection conn;
        public Dashboard prevform { get; set; }
        private decimal total;
        public int user_id { get; set; }
        private int ri = 0;
        public int quant;
        public PurcharseOrder()
        {
            InitializeComponent();
            total = 0;
            conn = new MySqlConnection("server=localhost; database=jacammerchant; uid=root; pwd=root");
            lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void PurcharseOrder_Load(object sender, EventArgs e)
        {
            showProd();
            lblTotal.Text = total.ToString("c");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            quant = 0;
            this.total = 0;
            string id, code, des, up, qty, name;
            int t = 0;
            if (ri >= 0)
            {
                addQuantity aq = new addQuantity();
                aq.po = this;
                aq.limit = int.Parse(dgvProd.Rows[ri].Cells[4].Value.ToString());
                aq.ShowDialog();
                if (quant != 0)
                {
                    for (int i=0; i < dgvCart.Rows.Count; i++)
                    {
                        id = dgvProd.Rows[ri].Cells[0].Value.ToString();
                        if (dgvCart.Rows[i].Cells[0].Value.ToString() == id)
                        {
                            // qty = dgvProd.Rows[ri].Cells[4].Value.ToString();
                            dgvCart.Rows[i].Cells[4].Value = int.Parse(dgvCart.Rows[i].Cells[4].Value.ToString()) + quant;
                            t++;
                        }
                    }
                    if (t == 0)
                    {
                        id = dgvProd.Rows[ri].Cells[0].Value.ToString();
                        code = dgvProd.Rows[ri].Cells[1].Value.ToString();
                        des = dgvProd.Rows[ri].Cells[2].Value.ToString();
                        up = dgvProd.Rows[ri].Cells[3].Value.ToString();
                        qty = quant.ToString();
                        name = dgvProd.Rows[ri].Cells[5].Value.ToString();
                        string[] row = new string[] { id, code, des, up, qty, name };
                        dgvCart.Rows.Add(row);
                        dgvCart.ClearSelection();
                        dgvProd.ClearSelection();
                    }
                    dgvProd.Rows[ri].Cells[4].Value = int.Parse(dgvProd.Rows[ri].Cells[4].Value.ToString()) - quant;
                    for (int i = 0; i < dgvCart.Rows.Count; i++)
                    {
                        this.total += Convert.ToDecimal(dgvCart.Rows[i].Cells[3].Value.ToString()) * int.Parse(dgvCart.Rows[i].Cells[4].Value.ToString());
                    }
                    lblTotal.Text = total.ToString("c");
                }
            }
            else
            {
                MessageBox.Show("Please Select a product befor proceeding!","", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        public void showProd()
        {
            string showprd = "SELECT prod_id, code, des, unit_price, qty, name FROM product_supply, profile WHERE product_supply.prof_id <> '" + this.user_id + "' AND product_supply.prof_id = profile.prof_id";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(showprd, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvProd.DataSource = dt;
            dgvProd.Columns["prod_id"].Visible = false;
            dgvProd.Columns["code"].HeaderText = "Code";
            dgvProd.Columns["des"].HeaderText = "Description";
            dgvProd.Columns["unit_price"].HeaderText = "Unit Price";
            dgvProd.Columns["qty"].HeaderText = "Quantity";
            dgvProd.Columns["name"].HeaderText = "By";
            dgvProd.ClearSelection();
        }

        private void PurcharseOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevform.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int ri = dgvCart.CurrentCell.RowIndex;
            if (ri >= 0)
            {   
                int qty = int.Parse(dgvCart.Rows[ri].Cells[4].Value.ToString());
                decimal up = Convert.ToDecimal(dgvCart.Rows[ri].Cells[3].Value.ToString());
                total -= qty * up;
                for (int i = 0; i < dgvProd.Rows.Count; i++)
                {
                    if (dgvProd.Rows[i].Cells[0].Value.ToString() == dgvCart.Rows[ri].Cells[0].Value.ToString())
                    {
                        dgvProd.Rows[i].Cells[4].Value = int.Parse(dgvCart.Rows[ri].Cells[4].Value.ToString()) + int.Parse(dgvProd.Rows[i].Cells[4].Value.ToString());
                    }
                }
                dgvCart.Rows.RemoveAt(ri);
                lblTotal.Text = total.ToString("c");
                dgvCart.ClearSelection();
                dgvProd.ClearSelection();
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (dgvCart.Rows.Count > 0)
            {
                string sel = "SELECT max(po_id) FROM purch_order";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(sel, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                comm.ExecuteNonQuery();
                DataTable dt = new DataTable();
                adp.Fill(dt);
                string pid = dt.Rows[0][0].ToString();
                string insert = "INSERT INTO purch_order VALUES(NULL, '" + this.user_id + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', '" + DateTime.Now.ToString("yyyy") + "001" + (int.Parse(pid)+1) + "')";
                comm = new MySqlCommand(insert, conn);
                comm.ExecuteNonQuery();
                string upd = "";
                for (int i = 0; i < dgvCart.Rows.Count; i++)
                {
                    insert = "INSERT INTO purch_order_line VALUES (NULL, '" + (int.Parse(pid) + 1) + "', '" + dgvCart.Rows[i].Cells[0].Value.ToString() + "', '" + dgvCart.Rows[i].Cells[4].Value.ToString() + "')";
                    comm = new MySqlCommand(insert, conn);
                    comm.ExecuteNonQuery();
                }
                for (int i = 0; i < dgvProd.Rows.Count; i++)
                {
                    upd = "UPDATE product_supply SET qty = '" + dgvProd.Rows[i].Cells[4].Value.ToString() + "' WHERE prod_id = '" + dgvProd.Rows[i].Cells[0].Value.ToString() + "'";
                    comm = new MySqlCommand(upd, conn);
                    comm.ExecuteNonQuery();
                }
                conn.Close();
                showProd();
                MessageBox.Show("Succefully Checked Out!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvProd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ri = dgvProd.CurrentCell.RowIndex;
        }
    }
}
