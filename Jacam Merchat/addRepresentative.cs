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
    public partial class addRepresentative : MetroFramework.Forms.MetroForm
    {
        MySqlConnection conn;
        public int com_id;
        public Company prevform { get; set; }
        public addRepresentative()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost; database=jacammerchant; uid=root; pwd=root");
        }

        private void addRepresentative_Load(object sender, EventArgs e)
        {
            show();
        }
        public void show()
        {
            string sel = "SELECT * FROM profile WHERE user_type =  4";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvSupProf.DataSource = dt;
        }

        private void btnSe_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvSupProf.CurrentCell.RowIndex;
            if (rowIndex >= 0)
            {
                DialogResult res = MessageBox.Show("Are you sure you want to set the current supplier to this company?","", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (DialogResult.OK == res)
                {
                    int prof_id = int.Parse(dgvSupProf.Rows[rowIndex].Cells[0].Value.ToString());
                    string ins = "INSERT INTO com_rep VALUES(NULL,'"+prof_id+"','"+com_id+"')";
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(ins, conn);
                    comm.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Succesfully added as representative to the company!","", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    prevform.showCom();
                }
            }
        }
    }
}
