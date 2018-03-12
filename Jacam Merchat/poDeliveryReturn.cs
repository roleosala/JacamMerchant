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
    public partial class poDeliveryReturn : MetroFramework.Forms.MetroForm
    {
        MySqlConnection conn;
        public int user_id { get; set; }
        public int user_type { get; set; }
        public Dashboard prevform { get; set; }
        public poDeliveryReturn()
        {
            conn = new MySqlConnection("server=localhost; database=jacammerchant; uid=root; pwd=root");
            InitializeComponent();
        }

        public void showSup()
        {
            dgvDel.DataSource = null;
            string sh = "SELECT * FROM po_del_ret WHERE sup_id = '" + user_id + "'";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sh, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvDel.DataSource = dt;
        }

        public void show()
        {
            dgvDel.DataSource = null;
            string sh = "SELECT * FROM po_del_ret ";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sh, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvDel.DataSource = dt;
        }

        private void poDeliveryReturn_Load(object sender, EventArgs e)
        {
            if (user_type == 4)
            {
                showSup();
            }
            else if (user_type == 1)
            {
                show();
            }
        }

        private void poDeliveryReturn_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevform.Show();
        }
    }
}
