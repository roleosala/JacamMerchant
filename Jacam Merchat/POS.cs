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
    public partial class POS : MetroFramework.Forms.MetroForm
    {
        MySqlConnection conn;
        public Dashboard prevform { get; set; }
        public int user_id { get; set; }
        public int user_type { get; set; }
        public POS()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost; database=jacammerchant; uid=root; pwd=root");
            showProd();
        }

        public int quant = 0;
        public decimal total = 0;

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            int t = 0;
            int ri = 0;
            ri = dgvInv.CurrentRow.Index;
            if (ri >= 0)
            {
                int lim = int.Parse(dgvInv.Rows[ri].Cells[2].Value.ToString());
                addQuantity add = new addQuantity();
                add.limit = lim;
                add.offSet = 3;
                add.pos = this;
                add.ShowDialog();
                if (quant != 0)
                {
                    dgvInv.Rows[ri].Cells[2].Value = int.Parse(dgvInv.Rows[ri].Cells[2].Value.ToString()) - quant;
                    for (int i = 0; dgvCart.Rows.Count > i; i++)
                    {
                        if (dgvInv.Rows[ri].Cells[0].Value.ToString() == dgvCart.Rows[i].Cells[0].Value.ToString())
                        {
                            dgvCart.Rows[i].Cells[2].Value = int.Parse(dgvCart.Rows[i].Cells[2].Value.ToString()) + quant;
                            
                            t = 1;
                        }
                    }
                    if (t != 1 && quant != 0)
                    {
                        dgvCart.Rows.Add(dgvInv.Rows[ri].Cells[0].Value.ToString(), dgvInv.Rows[ri].Cells[1].Value.ToString(), quant, dgvInv.Rows[ri].Cells[3].Value.ToString());
                        quant = 0;
                    }
                }
                else
                {
                    MessageBox.Show("You can't add 0 items.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
            if (dgvCart.Rows.Count > 0)
            {
                total = 0;
                for (int i = 0; i < dgvCart.Rows.Count; i++)
                {
                    total = total + (int.Parse(dgvCart.Rows[i].Cells[2].Value.ToString()) * (decimal)Convert.ToDecimal(dgvCart.Rows[i].Cells[3].Value.ToString()));
                    //MessageBox.Show(dgvCart.Rows[i].Cells[2].Value.ToString() + dgvCart.Rows[i].Cells[3].Value.ToString());
                    lblTotal.Text = total.ToString("c");
                }
            }
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            if (dgvCart.Rows.Count > 0)
            {
                int ri = 0;
                ri = dgvInv.CurrentRow.Index;
                if (ri >= 0)
                {
                    dgvCart.Rows.RemoveAt(ri);
                    total = total - (int.Parse(dgvCart.Rows[ri].Cells[2].Value.ToString()) * (decimal)Convert.ToDecimal(dgvCart.Rows[ri].Cells[3].Value.ToString()));
                    lblTotal.Text = total.ToString("c");
                }
            }
        }
        private void showProd()
        {
            string sel = "SELECT * FROM inventory WHERE price <> ''";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvInv.DataSource = dt;
            dgvInv.Columns[0].Visible = false;
            dgvInv.Columns[1].HeaderText = "Item Description";
            dgvInv.Columns[2].HeaderText = "Qty Available";
            dgvInv.Columns[3].HeaderText = "Price";
        }

        public int cust_id;
        private int prof_id = 0;

        private void btnSelCust_Click(object sender, EventArgs e)
        {
            selCustomer sel = new selCustomer();
            sel.prevform = this;
            sel.ShowDialog();
            showCust();
        }

        private void showCust()
        {
            string sel = "SELECT prof_id, name FROM profile WHERE prof_id = '"+cust_id+"'";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                prof_id = int.Parse(dt.Rows[0][0].ToString());
                lblCustName.Text = dt.Rows[0][1].ToString();
            }
        }

        private void POS_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevform.Show();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (change >= 0 && dgvCart.Rows.Count >= 1 && prof_id != 0)
            {
                conn.Open();
                for (int i = 0; i < dgvCart.Rows.Count; i++)
                {
                    string upd = "UPDATE inventory SET qty = '"+ dgvCart.Rows[i].Cells[2].Value.ToString() +"' WHERE item_id = '"+ dgvCart.Rows[i].Cells[0].Value.ToString() + "'";
                    MySqlCommand comm = new MySqlCommand(upd, conn);
                    comm.ExecuteNonQuery();
                    string ins = "INSERT INTO stock_out VALUES (NULL, '"+ dgvCart.Rows[i].Cells[0].Value.ToString() + "', '"+ DateTime.Now.ToString("yyyy-MM-dd") +"', '"+ dgvCart.Rows[i].Cells[2].Value.ToString() + "', '"+user_id+"')";
                    comm = new MySqlCommand(ins, conn);
                    comm.ExecuteNonQuery();
                }
                string sel2 = "SELECT max(order_id) FROM jacammerchant.order";
                MySqlCommand id2 = new MySqlCommand(sel2, conn);
                MySqlDataAdapter adp2 = new MySqlDataAdapter(id2);
                id2.ExecuteNonQuery();
                DataTable dt2 = new DataTable();
                adp2.Fill(dt2);
                int oi = 0;
                if (dt2.Rows[0][0].ToString() != "")
                {
                    oi = int.Parse(dt2.Rows[0][0].ToString()) + 1;
                }
                else
                {
                    oi = 1;
                }
                string order = "INSERT INTO jacammerchant.order VALUES (NULL, '"+ prof_id + "', '"+ user_id +"', '"+ DateTime.Now.ToString("yyyy-MM-dd") + "', '"+ total + "', '"+DateTime.Now.ToString("yyyy-MM-dd")+oi+"');";
                MySqlCommand comm2 = new MySqlCommand(order, conn);
                comm2.ExecuteNonQuery();
                string sel = "SELECT max(order_id) FROM jacammerchant.order";
                MySqlCommand id = new MySqlCommand(sel, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(id);
                id.ExecuteNonQuery();
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    int order_id = int.Parse(dt.Rows[0][0].ToString());
                        for (int i = 0; i < dgvCart.Rows.Count; i++)
                        {
                            string ol = "INSERT INTO order_line VALUES(NULL, '" + order_id + "', '" + dgvCart.Rows[i].Cells[0].Value.ToString() + "', '" + dgvCart.Rows[i].Cells[2].Value.ToString() + "', '" + dgvCart.Rows[i].Cells[3].Value.ToString() + "', '"+ dgvCart.Rows[i].Cells[2].Value.ToString() + "')";
                            MySqlCommand comm = new MySqlCommand(ol, conn);
                            comm.ExecuteNonQuery();
                        }
                }
                MessageBox.Show("Succesfully Checked Out!","", MessageBoxButtons.OK, MessageBoxIcon.Information);
                for (int i = 0; i < dgvInv.Rows.Count; i++)
                {
                    string upd = "UPDATE inventory SET qty = '"+ dgvInv.Rows[i].Cells[2].Value.ToString() + "' WHERE item_id = '"+ dgvInv.Rows[i].Cells[0].Value.ToString() + "'";
                    MySqlCommand comm = new MySqlCommand(upd, conn);
                    comm.ExecuteNonQuery();
                }
                conn.Close();
                dgvCart.Rows.Clear();
                total = 0;
                change = 0;
                txtCash.Text = "";
                prof_id = 0;
                lblCustName.Text = "N/A";
                showProd();
            }
            else
            {
                MessageBox.Show("No Items Or Please add a customer before proceeding.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

         public decimal change = 0;

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtCash.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtCash.Text = textBox1.Text.Remove(txtCash.Text.Length - 1);
            }
            else
            {
                if (total != 0 && txtCash.Text != "")
                {
                    change = (decimal)Convert.ToDecimal(txtCash.Text) - total;
                    if (change >= 0)
                    {
                        lblChange.Text = change.ToString("c");
                    }
                }
                else if(txtCash.Text == "")
                {
                    change = 0;
                    lblChange.Text = change.ToString("c"); ;
                }
            }
        }

        private void POS_Load(object sender, EventArgs e)
        {

        }
    }
}
