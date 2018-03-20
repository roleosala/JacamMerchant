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
    public partial class Company : MetroFramework.Forms.MetroForm
    {
        MySqlConnection conn;
        public Dashboard prevform { get; set; }
        public int user_id { get; set; }
        public int type { get; set; }
        public Company()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost; database=jacammerchant; uid=root; pwd=root");
            if (type == 1)
            {
                showAll();
            }
            else
            {
                showCom();
            }
        }
        public void showAll()
        {

            string sel = "SELECT C.com_id, C.name, C.add, C.cn, P.name FROM COMPANY C LEFT JOIN com_rep on com_rep.com_id = C.com_id LEFT JOIN profile P on com_rep.prof_id = P.prof_id;  ";
            //string sel = "Select * FROM company";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvCompany.DataSource = dt;
            
        }
        public void showCom()
        {
            string sel = "SELECT C.com_id, C.name, C.add, C.cn, P.name FROM COMPANY C LEFT JOIN com_rep on com_rep.com_id = C.com_id LEFT JOIN profile P on com_rep.prof_id = P.prof_id;  ";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvCompany.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvCompany.Rows.Count > 0)
            {
                int ri = dgvCompany.CurrentRow.Index;
                if (ri >= 0)
                {
                    addComControl con = new addComControl();
                    con.prevform = this;
                    con.user_id = user_id;
                    con.com_id = int.Parse(dgvCompany.Rows[ri].Cells[0].Value.ToString());
                    con.Show();
                }
            }
            showCom();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            prevform.Show();
            this.Close();
        }

        private void Company_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevform.Show();
        }

        private void dgvCompany_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int ri = dgvCompany.CurrentCell.RowIndex;
            if (ri >= 0)
            {
                DialogResult res = MessageBox.Show("Are you sure you want to add representative to this company?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (DialogResult.OK == res)
                {
                    addRepresentative add = new addRepresentative();
                    add.com_id = int.Parse(dgvCompany.Rows[ri].Cells[0].Value.ToString());
                    add.ShowDialog();
                }
            }
        }
    }
}
