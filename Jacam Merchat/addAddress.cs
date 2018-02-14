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
    public partial class addAddress : MetroFramework.Forms.MetroForm
    {
        MySqlConnection conn;
        public int user_id { get; set; }
        public int user_type { get; set; }
        public string order_id { get; set; }
        public string rn { get; set; }
        public addAddress()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost; database=jacammerchant; uid=root; pwd=root");
            lblId.Hide(); 
        }

        private void addAddress_Load(object sender, EventArgs e)
        {
            lblId.Text = order_id;
            lblRn.Text = rn;
            show();
        }

        private void show()
        {
            string sel = "SELECT prof_id, name FROM profile WHERE user_type = 5";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            conn.Close();
            for (int i = 0; dt.Rows.Count > i; i++)
            {
                cmbPer.Items.Add(dt.Rows[i][1].ToString());
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtStreet.Text != "" && txtPostalCode.Text != "" && cmbPer.Text != "" && lblId.Text != "id" && lblRn.Text != "Number XOXO")
            {
                string sel = "SELECT prof_id, name FROM profile WHERE user_type = 5";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(sel, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                conn.Close();
                string id = "0";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][1].ToString() == cmbPer.Text)
                    {
                        id = dt.Rows[i][0].ToString();
                    }
                }
                if (id != "0")
                {
                    string ins = "INSERT INTO delivery VALUES(NULL, '" + id + "', '" + order_id + "', '"+txtStreet.Text+"', '"+txtPostalCode.Text+"', '1')";
                    conn.Open();
                    comm = new MySqlCommand(ins, conn);
                    comm.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Succesfully Added!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("There is something wrong!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
