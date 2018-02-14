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
    public partial class Supplier_Supplies : MetroFramework.Forms.MetroForm
    {
        MySqlConnection conn;
        public int user_id { get; set; }
        public int type { get; set; }
        public Dashboard prevform { get; set; }
        private string sel;
        public Supplier_Supplies()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost; database=jacammerchant; uid=root; pwd=root");
        }

        private void Supplier_Supplies_Load(object sender, EventArgs e)
        {
            show();
        }

        private void Supplier_Supplies_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevform.Show();
        }

        private void btnAddProd_Click(object sender, EventArgs e)
        {
            addSupProd addSup = new addSupProd();
            addSup.user_id = user_id;
            addSup.ShowDialog();
            show();
        }
        public void show()
        {
            sel = "SELECT prod_id,  code, des, unit_price, qty, name, product_supply.added FROM product_supply, profile WHERE product_supply.prof_id = profile.prof_id";
            if (this.type == 4)
            {
                sel = "SELECT prod_id, code, des, unit_price, qty, product_supply.added FROM product_supply WHERE product_supply.prof_id = '" + this.user_id + "'";
            }
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvSupplies.DataSource = dt;
            dgvSupplies.Columns["prod_id"].Visible = false;
            dgvSupplies.Columns["code"].HeaderText = "Code";
            dgvSupplies.Columns["des"].HeaderText = "Description";
            dgvSupplies.Columns["unit_price"].HeaderText = "Unit Price";
            dgvSupplies.Columns["qty"].HeaderText = "Quantity";
            dgvSupplies.Columns["added"].HeaderText = "Date Added";
            if (this.type != 4)
            {
                dgvSupplies.Columns["name"].HeaderText = "Added By";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            prevform.Show();
            this.Close();
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            int RowIndex = dgvSupplies.CurrentCell.RowIndex;
            if (RowIndex >= 0)
            {
                addSupProd addSup = new addSupProd();
                addSup.user_id = user_id;
                int id;
                string code, des, up, qty;
                id = int.Parse(dgvSupplies.Rows[RowIndex].Cells["prod_id"].Value.ToString());
                code = dgvSupplies.Rows[RowIndex].Cells["code"].Value.ToString();
                des = dgvSupplies.Rows[RowIndex].Cells["des"].Value.ToString();
                up = dgvSupplies.Rows[RowIndex].Cells["unit_price"].Value.ToString();
                qty = dgvSupplies.Rows[RowIndex].Cells[4].Value.ToString(); ;
                addSup.edit(id, code, des, up, qty);
                addSup.ShowDialog();
                show();
                dgvSupplies.Rows[RowIndex].Selected = true;
            }
        }
    }
}
