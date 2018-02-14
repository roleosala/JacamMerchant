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
    public partial class addBidInfo : MetroFramework.Forms.MetroForm
    {
        MySqlConnection conn;
        public int user_id { get; set; }
        public int user_type { get; set; }
        public addBidInfo()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost; database=jacammerchant; uid=root; pwd=root");
            dateStart.Format = DateTimePickerFormat.Custom;
            dateEnd.Format = DateTimePickerFormat.Custom;
            dateStart.CustomFormat = "yyyy-MM-dd";
            dateEnd.CustomFormat = "yyyy-MM-dd";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string ins = "Insert into bid Values(NULL, '"+txtTitle.Text+"', '"+dateStart.Text + "', '"+ dateEnd.Text+ "')";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(ins, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            DialogResult res = MessageBox.Show("Bid Information Added Successfully! Do you want to add items now?","", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (DialogResult.OK== res)
            {
                string sel = "SELECT max(bid_id) FROm bid";
                conn.Open();
                comm = new MySqlCommand(sel, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                comm.ExecuteNonQuery();
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    addBidItems add = new addBidItems();
                    add.bid_id = int.Parse(dt.Rows[0][0].ToString());
                    add.user_id = user_id;
                    add.user_type = user_type;
                    add.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No selected bid!","Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                DialogResult re = MessageBox.Show("Do you want to add more?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (DialogResult.OK == re)
                {
                    foc();
                }
                else
                {
                    this.Close();
                }
            }
        }

        public void foc()
        {
            txtTitle.Clear();
            dateStart.Text = DateTime.Now.ToString("yyyy - mm - dd");
            dateEnd.Text = DateTime.Now.ToString("yyyy - mm - dd");
            txtTitle.Focus();
        }
    }
}
