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
    public partial class addBidItems : MetroFramework.Forms.MetroForm
    {
        MySqlConnection conn;
        public int user_id { get; set; }
        public int user_type { get; set; }
        public int bid_id;
        public int offSet = 0;
        public Bids prevform { get; set; }
        public int exp { get; set; }
        public addBidItems()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost; database=jacammerchant; uid=root; pwd=root");
            lblID.Hide();
            btnAddToCart.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (user_type == 4)
            {
                if (txtDesc.Text != "" && txtAp.Text != "" && txtAp.Text != "")
                {
                    string check = "SELECT qty_offer FROM bid_offer WHERE item_id = '" + lblID.Text + "' AND user_id = '"+user_id+"'";
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(check, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                    comm.ExecuteNonQuery();
                    conn.Close();
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count == 1)
                    {
                        int old = int.Parse(dt.Rows[0][0].ToString());
                        int newQTY = old + int.Parse(txtQty.Text);
                        string insSup = "UPDATE bid_offer SET qty_offer = '"+newQTY+"' WHERE item_id = '"+lblID.Text+"' and user_id = '"+user_id+"'";
                        conn.Open();
                        comm = new MySqlCommand(insSup, conn);
                        comm.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Successfully Added!", "Successful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showSup();
                    }
                    else
                    {
                        string insSup = "INSERT INTO bid_offer VALUES(NULL, '" + lblID.Text + "', '" + txtQty.Text + "', '" + txtAp.Text + "' , '"+user_id+"')";
                        conn.Open();
                        comm = new MySqlCommand(insSup, conn);
                        comm.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Successfully Added!", "Successful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showSup();
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in all the text fields before proceeding!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (txtDesc.Text != "" && txtAp.Text != "" && txtAp.Text != "")
                {
                    string check = "SELECT * FROM bid_items WHERE name LIKE '" + txtDesc.Text + "' AND bid_id = '" + bid_id + "'";
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(check, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                    comm.ExecuteNonQuery();
                    conn.Close();
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count >= 1)
                    {
                        MessageBox.Show("Item already in current Bid!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtDesc.Clear();
                        txtDesc.Focus();
                    }
                    else
                    {
                        string ins = "INSERT INTO bid_items VALUES(NULL,'" + bid_id + "' ,'" + txtDesc.Text + "','" + txtQty.Text + "','" + txtAp.Text + "')";
                        conn.Open();
                        comm = new MySqlCommand(ins, conn);
                        comm.ExecuteNonQuery();
                        conn.Close();
                        show();
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in all the text fields before proceeding!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void show()
        {
            string sh = "SELECT * FROM bid_items WHERE bid_id = '"+bid_id+"'";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sh, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvCurBid.DataSource = dt;
            dgvCurBid.Columns[0].Visible = false;
            dgvCurBid.Columns[1].Visible = false;
            dgvCurBid.Columns[2].HeaderText = "Description";
            dgvCurBid.Columns[3].HeaderText = "Quantity";
            dgvCurBid.Columns[4].HeaderText = "Asking Price";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtQty.Text != "" && txtDesc.Text != "" && txtAp.Text != "")
            {
                if (user_type == 4)
                {
                    string upd = "UPDATE bid_offer SET qty_offer = '" + txtQty.Text + "', offer_price = '" + txtAp.Text + "' WHERE item_id = '" + lblID.Text + "' AND user_id = '" + user_id + "'";
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(upd, conn);
                    comm.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Successfully Updated!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showSup();
                }
                else
                {
                    string upd = "UPDATE bid_items SET name = '" + txtDesc.Text + "' quant = '" + txtQty.Text + "' base_price = '" + txtAp.Text + "' where item_id = '" + lblID.Text + "'";
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(upd, conn);
                    comm.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Successfully Updated!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    show();
                }
            }
        }

        private void dgvCurBid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (exp == 1)
            {

            }
            else
            {
                int ri = dgvCurBid.CurrentRow.Index;
                if (user_type == 4)
                {
                    if (ri >= 0)
                    {
                        lblID.Text = dgvCurBid.Rows[ri].Cells[0].Value.ToString();
                        txtDesc.Text = dgvCurBid.Rows[ri].Cells[2].Value.ToString();
                        txtQty.Text = dgvCurBid.Rows[ri].Cells[7].Value.ToString();
                        txtAp.Text = dgvCurBid.Rows[ri].Cells[8].Value.ToString();
                    }
                }
                else if (offSet == 1 && user_type == 1)
                {

                }
                else
                {
                    if (ri >= 0)
                    {
                        lblID.Text = dgvCurBid.Rows[ri].Cells[0].Value.ToString();
                        txtDesc.Text = dgvCurBid.Rows[ri].Cells[2].Value.ToString();
                        txtQty.Text = dgvCurBid.Rows[ri].Cells[3].Value.ToString();
                        txtAp.Text = dgvCurBid.Rows[ri].Cells[4].Value.ToString();
                    }
                }
            }
        }

        private void addBidItems_Load(object sender, EventArgs e)
        {
            if (exp == 1 && user_type == 1)
            {
                btnAddToCart.Hide();
            }
            if (user_type == 4 && offSet == 0)
            {
                showSup();
                this.Text = "Add Items";
                btnAddToCart.Hide();
            }
            else if (offSet == 1 && user_type == 4)
            {
                showSup();
                txtDesc.ReadOnly = true;
                txtQty.ReadOnly = true;
                txtAp.ReadOnly = true;
                btnAddToCart.Hide();
                btnAdd.Hide();
                btnDelete.Hide();
                btnEdit.Hide();
            }
            else if (offSet == 1 && user_type == 1)
            {
                viewItems();
                txtDesc.ReadOnly = true;
                txtQty.ReadOnly = true;
                txtAp.ReadOnly = true;
            }
            else
            {
                show();
                this.Text = "Add Items";
                btnAddToCart.Hide();
            }
            dgvCurBid.ClearSelection();
        }
        private void showSup()
        {
            txtDesc.ReadOnly = true;
            lblPrice.Text = "Offer Price:";
            //string sh = "SELECT * FROM bid_items WHERE bid_id = '" + bid_id + "'";
            string sh = "SELECT * FROM bid_items bi Left join bid_offer bo ON bo.item_id = bi.item_id AND bo.user_id = '" + user_id + "' WHERE bi.bid_id = '" + bid_id + "' ";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sh, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvCurBid.DataSource = dt;
            dgvCurBid.Columns[0].Visible = false;
            dgvCurBid.Columns[1].Visible = false;
            dgvCurBid.Columns[2].HeaderText = "Description";
            dgvCurBid.Columns[3].HeaderText = "Quantity";
            dgvCurBid.Columns[4].HeaderText = "Asking Price";
            dgvCurBid.Columns[5].Visible = false;
            dgvCurBid.Columns[6].Visible = false;
            dgvCurBid.Columns[7].HeaderText = "Offered Quantity";
            dgvCurBid.Columns[8].HeaderText = "Offered Price";
            dgvCurBid.Columns[9].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int ri = dgvCurBid.CurrentRow.Index;
            if (ri >= 0)
            {
                if (user_type == 4)
                {
                    DialogResult dr = MessageBox.Show("Are you sure you want to remove your current offered bid?","", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (DialogResult.OK == dr)
                    {
                        string bid_offer_id = dgvCurBid.Rows[ri].Cells[5].Value.ToString();
                        string del = "DELETE FROM bid_offer WHERE bid_offer_id = '" + bid_offer_id + "'";
                        conn.Open();
                        MySqlCommand comm = new MySqlCommand(del, conn);
                        comm.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Sucessfully Removed Offered Bid", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showSup();
                    }
                }
                else
                {
                    
                }
            }
            
        }

        public void viewItems()
        {
            btnAdd.Hide();
            btnEdit.Hide();
            btnDelete.Hide();
            this.Text = "View Items";
            selItem();
        }

        private void selItem()
        {
            string sh = "SELECT * FROM bid_items bi LEFT JOIN bid_offer bo ON bo.item_id = bi.item_id LEFT JOIN profile p ON p.prof_id = bo.user_id WHERE bid_id = '"+bid_id+"' /*AND*/ ";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sh, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvCurBid.DataSource = dt;
            dgvCurBid.DataSource = dt;
            dgvCurBid.Columns[0].Visible = false;
            dgvCurBid.Columns[1].Visible = false;
            dgvCurBid.Columns[2].HeaderText = "Description";
            dgvCurBid.Columns[3].HeaderText = "Quantity";
            dgvCurBid.Columns[4].HeaderText = "Asking Price";
            dgvCurBid.Columns[5].Visible = false;
            dgvCurBid.Columns[6].Visible = false;
            dgvCurBid.Columns[7].HeaderText = "Offered Quantity";
            dgvCurBid.Columns[8].HeaderText = "Offered Price";
            dgvCurBid.Columns[9].Visible = false;
            dgvCurBid.Columns[10].Visible = false;
            dgvCurBid.Columns[11].HeaderText = "Offered By";
            dgvCurBid.Columns[12].Visible = false;
            dgvCurBid.Columns[13].Visible = false;
            dgvCurBid.Columns[14].Visible = false;
            dgvCurBid.Columns[15].Visible = false;
            dgvCurBid.Columns[16].Visible = false;
            dgvCurBid.Columns[17].Visible = false;
            dgvCurBid.Columns[18].Visible = false;
            dgvCurBid.Columns[19].Visible = false;
            dgvCurBid.Columns[20].Visible = false;
        }
        public int quant;
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            int ri = dgvCurBid.CurrentRow.Index;
            if (ri >= 0)
            {
                if (dgvCurBid.Rows[ri].Cells[7].Value.ToString() != "" && dgvCurBid.Rows[ri].Cells[8].Value.ToString() != "")
                {
                    addQuantity add = new addQuantity();
                    add.offSet = 2;
                    add.limit = int.Parse(dgvCurBid.Rows[ri].Cells[7].Value.ToString());
                    add.bo = this;
                    add.ShowDialog();
                    if (quant != 0)
                    {
                        conn.Open();
                        string check = "SELECT * FROM cart WHERE bid_offer_id = '"+ dgvCurBid.Rows[ri].Cells[5].Value.ToString() + "' and STATUS <> 1";
                        MySqlCommand comm = new MySqlCommand(check, conn);
                        MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                        comm.ExecuteNonQuery();
                        DataTable dt = new DataTable();
                        adp.Fill(dt);
                        if (dt.Rows.Count == 1)
                        {
                            quant += int.Parse(dt.Rows[0][2].ToString());
                            string updCart = "UPDATE cart SET qty = '"+quant+"' WHERE cart_id = '"+ dt.Rows[0][0].ToString() + "'";
                            comm = new MySqlCommand(updCart, conn);
                            comm.ExecuteNonQuery();
                        }else
                        {
                            string ins = "INSERT INTO cart VALUES(NULL, '" + dgvCurBid.Rows[ri].Cells[5].Value.ToString() + "', '" + quant + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', 0);";
                            comm = new MySqlCommand(ins, conn);
                            comm.ExecuteNonQuery();
                        }
                        int newQty = int.Parse(dgvCurBid.Rows[ri].Cells[7].Value.ToString()) - quant;
                        string upd = "UPDATE bid_offer SET qty_offer = '" + newQty + "' WHERE bid_offer_id = '" + dgvCurBid.Rows[ri].Cells[5].Value.ToString() + "'";
                        comm = new MySqlCommand(upd, conn);
                        comm.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Successfully added to cart!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        selItem();
                    }
                    else
                    {
                        MessageBox.Show("Please Select 1 or more than the quantity offered in the bids offered!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("CURRENTLY NO OFFER IN THIS ITEM!","", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Select an Item First!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCurBid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           btnAddToCart.Enabled = true;
        }
    }
}
