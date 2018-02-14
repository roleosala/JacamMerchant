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
using MySql.Data.MySqlClient;

namespace Jacam_Merchat
{
    public partial class Settings : MetroForm
    {
        MySqlConnection conn;
        public Dashboard prevform { get; set; }
        public int user_id { get; set; }
        public Settings()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost; database=jacammerchant; uid=root; pwd=root");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            prevform.Show();
            this.Close();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            if (txtNewUsr.Text == txtConfirmNewUsr.Text)
            {
                string sel = "Select * FROM user WHERE prof_id = '" + user_id + "' AND username = '" + txtOldUsr.Text + "'";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(sel, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                comm.ExecuteNonQuery();
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    sel = "SELECT * FROM USER WHERE prof_id <> '" + user_id + "' AND username = '" + txtNewUsr.Text + "'";
                    comm = new MySqlCommand(sel, conn);
                    adp = new MySqlDataAdapter(comm);
                    comm.ExecuteNonQuery();
                    DataTable dt2 = new DataTable();
                    adp.Fill(dt2);
                    if (!(dt2.Rows.Count == 1))
                    {
                        string upd = "UPDATE user SET username = '"+txtNewUsr.Text+"' WHERE prof_id = '"+user_id+"'";
                        comm = new MySqlCommand(upd, conn);
                        comm.ExecuteNonQuery();
                        MessageBox.Show("Successfully Updated Username!","", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearUsr();
                    }
                    else
                    {
                        MessageBox.Show("Username is already taken!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Your old username is incorrect!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Your new username does not match!","", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            if (txtConfirmNewPass.Text == txtNewPass.Text)
            {
                string upd = "UPDATE user SET password = '"+txtNewPass.Text+"' WHERE prof_id = '"+user_id+"'";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(upd, conn);
                comm.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Successfully Updated Password!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Your new Passwords do not match!","", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void clearUsr()
        {
            txtOldUsr.Clear();
            txtNewUsr.Clear();
            txtConfirmNewUsr.Clear();
            txtOldUsr.Focus();
        }

        private void clearPass()
        {
            txtOldPass.Clear();
            txtNewPass.Clear();
            txtConfirmNewPass.Clear();
            txtOldPass.Focus();
        }
        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevform.Show();
        }
    }
}
