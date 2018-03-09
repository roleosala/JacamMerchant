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
    public partial class addDate : MetroFramework.Forms.MetroForm
    {
        MySqlConnection conn;
        public purchaseOrderDelivery del { get; set; }
        public purchaseOrderDelivery delRet { get; set; }
        public Returns ret { get; set; }
        public int offSet { get; set; }
        public string date { get; set; }
        public poBIdReturns poRet {get;set;}
        public addDate()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost; database=jacammerchant; uid=root; pwd=root");
            lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lblDate.Hide();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (offSet == 3)
            {
                poRet.det = dtpDate.Value.ToString("yyyy-MM-dd");
                this.Close();
            }
            else if (offSet == 4)
            {
                delRet.det = dtpDate.Value.ToString("yyyy-MM-dd");
                this.Close();
            }
            else
            {
                string check = "SELECT DATEDIFF('" + lblDate.Text + "', '" + dtpDate.Value.ToString("yyyy-MM-dd") + "');";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(check, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                comm.ExecuteNonQuery();
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);
                int diff = int.Parse(dt.Rows[0][0].ToString());
                if (diff <= 0)
                {
                    if (offSet == 1)
                    {
                        del.dtpDate = dtpDate.Value.ToString("yyyy-MM-dd");
                        this.Close();
                    }
                    else if (offSet == 2)
                    {
                        ret.dtpDate = dtpDate.Value.ToString("yyyy-MM-dd");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Cannot travel back through time. Please select another Date, today or the proceeding days. ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (offSet == 1 && diff <= 0)
                    {

                    }
                    else if (offSet == 2 && diff <= 0)
                    {
                        ret.counter = 1;
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addDate_Load(object sender, EventArgs e)
        {

        }
    }
}
