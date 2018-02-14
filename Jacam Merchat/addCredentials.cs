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
    public partial class addCredentials : MetroFramework.Forms.MetroForm
    {
        MySqlConnection conn;
        public addProfile prevForm { get; set; }
        public int usrType { get; set; }
        public addCredentials()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost; database=jacammerchant; uid=root; pwd=root");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPwd.Text == txtConPwd.Text)
            {
                string selProf = "select max(prof_id) from profile";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(selProf, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                comm.ExecuteNonQuery();
                DataTable dt = new DataTable();
                adp.Fill(dt);
                int prof_id = int.Parse(dt.Rows[0][0].ToString());
                string addCredential = "INSERT INTO user VALUES(NULL, '" + txtUsrnm.Text + "', '" + txtPwd.Text + "', '"+prof_id+"')";
                comm = new MySqlCommand(addCredential, conn);
                comm.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Successfully added Username and Password!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                prevForm.clear();
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
