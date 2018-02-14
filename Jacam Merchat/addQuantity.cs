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
    public partial class addQuantity : MetroForm
    {
        public int limit { get; set; }
        public PurcharseOrder po { get; set; }
        public addBidItems bo { get; set; }
        public POS pos { get; set; }
        public purchaseOrderDelivery rec { get; set; }
        public int offSet = 0;
        public addQuantity()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtQty.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtQty.Text = txtQty.Text.Remove(txtQty.Text.Length - 1);
            }
            else
            {
                if (int.Parse(txtQty.Text) > limit && txtQty.Text != "")
                {
                    MessageBox.Show("The Maximum for this product to be added is: " + limit.ToString() + "", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    if (offSet == 1)
                    {
                        po.quant = int.Parse(txtQty.Text);
                    }
                    else if (offSet == 2)
                    {
                        bo.quant = int.Parse(txtQty.Text);
                    }
                    else if (offSet == 3)
                    {
                        pos.quant = int.Parse(txtQty.Text);
                    }
                    else if (offSet == 4)
                    {
                        rec.quant = int.Parse(txtQty.Text);
                    }
                    else
                    {

                    }

                }
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
