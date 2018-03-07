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
    public partial class addReturns : MetroFramework.Forms.MetroForm
    {
        MySqlConnection conn;
        public int user_id { get; set; }
        public int user_type { get; set; }
        public string po_del_id { get; set; }
        public addReturns()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost; database=jacammerchant; uid=root; pwd=root");
        }

        public void showDel()
        {
            string sh = "SELECT * FROM po_del WHERE po_del_id = '"+po_del_id+"'";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sh, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
        }

        public void showDelLine()
        {
            string sh = "SELECT * FROM po_del_line WHERE po_del_id = '" + po_del_id + "'";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sh, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvRet.DataSource = dt;
            DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
            txt.Name = "txt";
            txt.HeaderText = "Items to be Delivered";
            dgvRet.Columns.Add(txt);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
