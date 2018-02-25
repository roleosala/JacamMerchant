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
    public partial class selCustomer : MetroFramework.Forms.MetroForm
    {
        MySqlConnection conn;
        public int user_id { get; set; }
        public int user_type { get; set; }
        public POS prevform { get; set; }
        private int ri = 0;
        public selCustomer()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost; database=jacammerchant; uid=root; pwd=root");
            show();
        }

        private void show()
        {
            string sel = "SELECT prof_id, name FROM profile WHERE user_type = 6";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvCust.DataSource = dt;
            dgvCust.Columns[0].Visible = false;
            dgvCust.Columns[1].HeaderText = "Client Name";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string sel = "SELECT prof_id, name FROM profile WHERE user_type = 6 AND name LIKE '%"+txtSearch.Text+"%'";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvCust.DataSource = dt;
            dgvCust.Columns[0].Visible = false;
            dgvCust.Columns[1].HeaderText = "Client Name";
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            ri = dgvCust.CurrentRow.Index;
            if (ri >= 0)
            {
                prevform.cust_id = int.Parse(dgvCust.Rows[ri].Cells[0].Value.ToString());
                this.Close();
            }
            
        }

        private void selCustomer_Load(object sender, EventArgs e)
        {

        }
    }
}
