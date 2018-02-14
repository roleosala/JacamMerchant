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
    public partial class Profile : MetroFramework.Forms.MetroForm
    {
        MySqlConnection conn;
        public Dashboard prevform { get; set; }
        public Profile()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost; database=jacammerchant; uid=root; pwd=root");
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            show();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            addProfile add = new addProfile();
            add.prevform = this;
            add.ShowDialog();
            show();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string view = "SELECT * FROM profile WHERE ln LIKE '"+txtFilter.Text+"%' OR fn LIKE '"+txtFilter.Text+"%'";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(view, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dtgView.DataSource = dt;
        }
         
        public void show()
        {
            string view = "SELECT * FROM profile";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(view, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dtgView.DataSource = dt;
            
            dtgView.Columns["prof_id"].HeaderText = "ID";
            dtgView.Columns["name"].HeaderText = "Name";
            dtgView.Columns["fn"].Visible = false;
            dtgView.Columns["ln"].Visible = false;
            dtgView.Columns["mi"].Visible = false;
            dtgView.Columns["sex"].HeaderText = "Gender";
            dtgView.Columns["cn"].HeaderText = "Contact No.";
            dtgView.Columns["address"].HeaderText = "Address";
            dtgView.Columns["added"].HeaderText = "Date Added";
            dtgView.Columns["user_type"].HeaderText = "User Type";
            
            for (int i = 0; i<dtgView.Rows.Count;i++)
            {
                if (int.Parse(dtgView.Rows[i].Cells[10].Value.ToString()) == 1)
                {
                    dtgView.Rows[i].Cells[10].Value = "Owner";
                }
                else if (int.Parse(dtgView.Rows[i].Cells[10].Value.ToString()) == 2)
                {
                    dtgView.Rows[i].Cells[10].Value = "Manager";
                }
                else if (int.Parse(dtgView.Rows[i].Cells[10].Value.ToString()) == 3)
                {
                    dtgView.Rows[i].Cells[10].Value = "Staff";
                }
                else if (int.Parse(dtgView.Rows[i].Cells[10].Value.ToString()) == 4)
                {
                    dtgView.Rows[i].Cells[10].Value = "Supplier";
                }
                else if (int.Parse(dtgView.Rows[i].Cells[10].Value.ToString()) == 5)
                {
                    dtgView.Rows[i].Cells[10].Value = "Delivery";
                }
                else if (int.Parse(dtgView.Rows[i].Cells[10].Value.ToString()) == 6)
                {
                    dtgView.Rows[i].Cells[10].Value = "Client";
                }
            }
            
        }

        private void Profile_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevform.Show();
        }

        private void dtgView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int usrType = 0;
            if (e.RowIndex >= 0)
            {
                int id;
                string fn, mi, ln, gen, cn, email, add, type;
                type = usrType.ToString();
                id = int.Parse(dtgView.Rows[e.RowIndex].Cells["prof_id"].Value.ToString());
                fn = dtgView.Rows[e.RowIndex].Cells["fn"].Value.ToString();
                ln = dtgView.Rows[e.RowIndex].Cells["ln"].Value.ToString();
                mi = dtgView.Rows[e.RowIndex].Cells["mi"].Value.ToString();
                gen = dtgView.Rows[e.RowIndex].Cells["sex"].Value.ToString(); 
                email = dtgView.Rows[e.RowIndex].Cells["email"].Value.ToString();
                cn = dtgView.Rows[e.RowIndex].Cells["cn"].Value.ToString();
                add = dtgView.Rows[e.RowIndex].Cells["address"].Value.ToString();
                type = dtgView.Rows[e.RowIndex].Cells["user_type"].Value.ToString();
                addProfile view = new addProfile();
                view.edit(id, fn, mi, ln, gen, cn, email, add, type);
                view.ShowDialog();
                show();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            
            int rowIndex = dtgView.CurrentCell.RowIndex;
            if (rowIndex >= 0)
            {
                int id;
                string fn, mi, ln, gen, cn, email, add, type;
                id = int.Parse(dtgView.Rows[rowIndex].Cells["prof_id"].Value.ToString());
                fn = dtgView.Rows[rowIndex].Cells["fn"].Value.ToString();
                ln = dtgView.Rows[rowIndex].Cells["ln"].Value.ToString();
                mi = dtgView.Rows[rowIndex].Cells["mi"].Value.ToString();
                gen = dtgView.Rows[rowIndex].Cells["sex"].Value.ToString();
                email = dtgView.Rows[rowIndex].Cells["email"].Value.ToString();
                cn = dtgView.Rows[rowIndex].Cells["cn"].Value.ToString();
                add = dtgView.Rows[rowIndex].Cells["address"].Value.ToString();
                type = dtgView.Rows[rowIndex].Cells["user_type"].Value.ToString();
                addProfile view = new addProfile();
                view.edit(id, fn, mi, ln, gen, cn, email, add, type);
                view.ShowDialog();
                show();
            }
        }
    }
}
