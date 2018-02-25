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

namespace Jacam_Merchat
{
    public partial class Dashboard : MetroForm
    {
        public Login prevform { get; set; }
        public string name { get; set; }
        public int user_id { get; set; }
        public int user_type { get; set; }
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            lblName.Text = name;
            if (user_type == 1)
            {
                btnPurchOrd.Enabled = false;
                btnSupProd.Enabled = false;
                btnOrder.Enabled = false;
                btnPurchOrd.BackColor = Color.LightGray;
                btnSupProd.BackColor = Color.LightGray;
                btnOrder.BackColor = Color.LightGray;
            }
            if(user_type == 4)
            {
                btnPurchOrd.Enabled = false;
                btnSupProd.Enabled = false;
                btnOrder.Enabled = false;
                btnProfMan.Enabled = false;
                btnCompany.Enabled = false;
                btnDel.Enabled = false;
                btnInv.Enabled = false;
                btnPurchOrd.BackColor = Color.LightGray;
                btnSupProd.BackColor = Color.LightGray;
                btnOrder.BackColor = Color.LightGray;
                btnProfMan.BackColor = Color.LightGray;
                btnCompany.BackColor = Color.LightGray;
                btnDel.BackColor = Color.LightGray;
                btnInv.BackColor = Color.LightGray;
            }
            else
            {
                btnPurchOrd.Enabled = false;
                btnSupProd.Enabled = false;
                btnOrder.Enabled = false;
                btnProfMan.Enabled = false;
                btnCompany.Enabled = false;
                btnDel.Enabled = false;
                btnInv.Enabled = false;
                btnPOS.Enabled = false;
                btnPurchOrd.Enabled = false;
                btnPurchOrderDel.Enabled = false;
                btnPurchOrd.BackColor = Color.LightGray;
                btnSupProd.BackColor = Color.LightGray;
                btnOrder.BackColor = Color.LightGray;
                btnProfMan.BackColor = Color.LightGray;
                btnCompany.BackColor = Color.LightGray;
                btnDel.BackColor = Color.LightGray;
                btnInv.BackColor = Color.LightGray;
            }
        }

        private void btnProfMan_Click(object sender, EventArgs e)
        {
            Profile prof = new Profile();
            this.Hide();
            prof.prevform = this;
            prof.Show();
        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevform.Show();
        }

        private void btnSupProd_Click(object sender, EventArgs e)
        {
            Supplier_Supplies sup = new Supplier_Supplies();
            sup.prevform = this;
            sup.user_id = this.user_id;
            sup.type = this.user_type;
            this.Hide();
            sup.Show();
        }

        private void btnPurchOrd_Click(object sender, EventArgs e)
        {
            PurcharseOrder add = new PurcharseOrder();
            add.prevform = this;
            add.user_id = this.user_id;
            add.Show();
            this.Hide();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            OrderList ol = new OrderList();
            ol.prevform = this;
            ol.user_id = this.user_id;
            ol.user_type = this.user_type;
            ol.Show();
            this.Hide();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Settings set = new Settings();
            set.prevform = this;
            set.user_id = this.user_id;
            this.Hide();
            set.Show();
        }

        private void btnCompany_Click(object sender, EventArgs e)
        {
            Company com = new Company();
            com.prevform = this;
            com.user_id = this.user_id;
            com.type = this.user_type;
            com.Show();
            this.Hide();
        }

        private void btnBid_Click(object sender, EventArgs e)
        {
            Bids bid = new Bids();
            bid.prevform = this;
            bid.user_id = user_id;
            bid.user_type = user_type;
            bid.ShowDialog();
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
                Sale sale = new Sale();
                sale.user_id = user_id;
                sale.user_type = user_type;
                sale.prevform = this;
                this.Hide();
                sale.Show();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            Inventory inv = new Inventory();
            inv.user_id = user_id;
            inv.user_type = user_type;
            inv.prevform = this;
            this.Hide();
            inv.Show();
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            POS pos = new POS();
            pos.prevform = this;
            pos.user_id = user_id;
            pos.user_type = user_type;
            pos.Show();
            this.Hide();
        }

        private void metroTile6_Click(object sender, EventArgs e)
        {
            Delivery del = new Delivery();
            del.prevform = this;
            del.user_id = user_id;
            del.user_type = user_type;
            del.Show();
            this.Hide();
        }

        private void btnPurchOrderDel_Click(object sender, EventArgs e)
        {
            purchaseOrderDelivery purch = new purchaseOrderDelivery();
            purch.user_id = user_id;
            purch.user_type = user_type;
            purch.prevform = this;
            purch.Show();
            this.Hide();
        }

        private void btnBidPO_Click(object sender, EventArgs e)
        {
            bidPurchOrder bid = new bidPurchOrder();
            bid.user_id = user_id;
            bid.user_type = user_type;
            bid.prevform = this;
            bid.Show();
            this.Hide();
        }

        private void metroTile7_Click(object sender, EventArgs e)
        {
            Returns ret = new Returns();
            ret.prevform = this;
            ret.user_id = user_id;
            ret.user_type = user_type;
            ret.Show();
            this.Hide();
        }
    }
}
