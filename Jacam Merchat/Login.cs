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
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        MySqlConnection conn;
        public Login()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost; database=jacammerchant; uid=root; pwd=root");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsrnme.Text != "" && txtPwd.Text != "")
            {
                string login = "SELECT user.prof_id, name, user_type FROM user, profile WHERE username = '" + txtUsrnme.Text + "' AND password = '" + txtPwd.Text + "' AND user.prof_id = profile.prof_id";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(login, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                comm.ExecuteNonQuery();
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    int id = int.Parse(dt.Rows[0][0].ToString());
                    string name = dt.Rows[0][1].ToString();
                    int type = int.Parse(dt.Rows[0][2].ToString());
                    Dashboard dash = new Dashboard();
                    dash.prevform = this;
                    dash.name = name;
                    dash.user_id = id;
                    dash.user_type = type;
                    this.Hide();
                    dash.Show();
                    clear();
                }
                else
                {
                    MessageBox.Show("Invalid Username and Password!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clear();
                }
            }
            else
            {
                DialogResult res = MessageBox.Show("Please fill in all the forms!","", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                if (res == DialogResult.Retry)
                {
                    clear();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clear()
        {
            txtUsrnme.Clear();
            txtPwd.Clear();
            txtUsrnme.Focus();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
