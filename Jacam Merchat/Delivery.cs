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
    public partial class Delivery : MetroFramework.Forms.MetroForm
    {
        MySqlConnection conn;
        public int user_id { get; set; }
        public int user_type { get; set; }
        public Dashboard prevform { get; set; }
        public Delivery()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost; database=jacammerchant; uid=root; pwd=root");
            
        }
        public void sales() //Jacam
        {
            string sel = "SELECT o.order_id, p.name, c.name, o.order_date, o.total, o.rn FROM jacammerchant.order o LEFT JOIN profile p ON o.user_id = p.prof_id LEFT JOIN profile c ON c.prof_id = o.prof_id LEFT JOIN delivery d ON d.order_id = o.order_id";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvDel.DataSource = dt;
            dgvDel.Columns[0].Visible = false;
            dgvDel.Columns[1].HeaderText = "Sold by";
            dgvDel.Columns[2].HeaderText = "Sold to";
            dgvDel.Columns[3].HeaderText = "Date Sold";
            dgvDel.Columns[4].HeaderText = "Total";
            dgvDel.Columns[5].HeaderText = "Reference NO.";
            dgvDel.ClearSelection();
        }
        public void showDel() // sup
        {
            string sel = "SELECT d.del_id, d.address, d.postal, d.status, p.name, o.rn FROM delivery d LEFT JOIN profile p ON p.prof_id = d.prof_id LEFT JOIN orders o ON o.order_id = d.order_id";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvDel.DataSource = dt;
            dgvDel.Columns[0].Visible = false;
            dgvDel.Columns[1].HeaderText = "Address";
            dgvDel.Columns[2].HeaderText = "Postal Code";
            dgvDel.Columns[3].HeaderText = "Status";
            dgvDel.Columns[4].HeaderText = "Delivery Personel";
            dgvDel.Columns[5].HeaderText = "Reference Number";
            dgvDel.ClearSelection();
            /*
            for (int i = 0;i < dgvDel.Rows.Count; i++)
            {
                if (int.Parse(dgvDel.Rows[i].Cells[3].Value.ToString()) == 1)
                {
                    dgvDel.Rows[i].Cells[3].Value = "On Delivery";
                }else if (int.Parse(dgvDel.Rows[i].Cells[3].Value.ToString()) == 0)
                {
                    dgvDel.Rows[i].Cells[3].Value = "Delivered";
                }
                else
                {
                    dgvDel.Rows[i].Cells[3].Value = "Ambot asa ang delivery";
                }
            }
            */
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int ri = dgvDel.CurrentRow.Index;
            if (ri >= 0 && user_type == 1)
            {
                string ch = "SELECT * FROM delivery WHERE order_id = '"+ dgvDel.Rows[ri].Cells[0].Value.ToString() +"'";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(ch, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                comm.ExecuteNonQuery();
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    addAddress add = new addAddress();
                    add.user_id = user_id;
                    add.user_type = user_type;
                    add.order_id = dgvDel.Rows[ri].Cells[0].Value.ToString();
                    add.rn = dgvDel.Rows[ri].Cells[5].Value.ToString();
                    add.ShowDialog();
                }else
                {
                    MessageBox.Show("This order is already on delivery please select another order to be delivered","Delivered!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnAdd.Enabled = false;
                    btnAdd.BackColor = Color.LightGray;
                    btnAdd.ForeColor = Color.White;
                }
            }
        }

        private void Delivery_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevform.Show();
        }

        private void Delivery_Load(object sender, EventArgs e)
        {
            if (user_type == 5)
            {
                showDel();
            }
            else if (user_type == 3 || user_type == 1)
            {
                sales();
            }
            else
            {
                sales();
            }
            dgvDel.ClearSelection();
        }

        private void dgvDel_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnStat_Click(object sender, EventArgs e)
        {
            int ri = dgvDel.CurrentRow.Index;
            if (ri >= 0)
            {
                delStatus stat = new delStatus();
                stat.order_id = int.Parse(dgvDel.Rows[ri].Cells[0].Value.ToString());
                stat.del = this;
                stat.user_id = user_id;
                stat.user_type = user_type;
                this.Hide();
                stat.Show();
            }
            
        }

        private void dgvDel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int ri = dgvDel.CurrentRow.Index;
            if (ri >= 0 && user_type == 1)
            {
                string ch = "SELECT * FROM delivery WHERE order_id = '" + dgvDel.Rows[ri].Cells[0].Value.ToString() + "'";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(ch, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                comm.ExecuteNonQuery();
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    btnAdd.Enabled = true;
                    btnAdd.BackColor = Color.DeepSkyBlue;
                    btnAdd.ForeColor = Color.White;
                    
                }
                else
                {
                    btnAdd.Enabled = false;
                    btnAdd.BackColor = Color.LightGray;
                    btnAdd.ForeColor = Color.White;
                }
            }
        }
    }
}
