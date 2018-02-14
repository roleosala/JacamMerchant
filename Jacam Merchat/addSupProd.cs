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
    public partial class addSupProd : MetroFramework.Forms.MetroForm
    {
        MySqlConnection conn;
        public int user_id { get; set; }
        public addSupProd()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost; database=jacammerchant; uid=root; pwd=root");
            btnUpd.Hide();
            btnAdd.Hide();
            lblIdNo.Hide();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string add = "INSERT INTO product_supply VALUES (NULL, '"+txtCode.Text+"', '"+txtDesc.Text+"', '"+txtUP.Text+"', '"+txtQnt.Text+"','"+ DateTime.Now.ToString("yyyy-MM-dd")+"', '"+this.user_id+"')";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(add, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Succesfully Added!","");
            Supplier_Supplies sup = new Supplier_Supplies();
            sup.show();
        }
        public void edit(int id, string code, string des, string up, string qty)
        {
            this.Text = "Update Product";
            btnAdd.Hide();
            btnUpd.Show();
            btnUpd.Location = new Point(164, 244);
            lblIdNo.Text = id.ToString();
            txtCode.Text = code;
            txtDesc.Text = des;
            txtUP.Text = up;
            txtQnt.Text = qty;
        }

        private void addSupProd_Load(object sender, EventArgs e)
        {
            btnAdd.Show();
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            string upd = "UPDATE product_supply SET code = '"+txtCode.Text+"', des = '"+txtDesc.Text+"', unit_price = '"+txtUP.Text+"', qty = '"+txtQnt.Text+"', added = '"+ DateTime.Now.ToString("yyyy-MM-dd")+"' WHERE prod_id = '"+lblIdNo.Text+"'";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(upd, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Succesfully Updated!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
