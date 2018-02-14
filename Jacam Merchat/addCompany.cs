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
    public partial class addCompany : MetroFramework.Forms.MetroForm
    {
        MySqlConnection conn;
        public int user_id { get; set; }
        public Company prevform { get; set; }
        public addCompany()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost; database=jacammerchant; uid=root; pwd=root");
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            prevform.Show();
            this.Close();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            string ins = "INSERT INTO company VALUES (null, '"+txtComName.Text+"', '"+txtComAdd.Text+"', '"+txtcn.Text+"')";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(ins, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Successfully Added!","", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void addCompany_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevform.Show();
        }
    }
}
