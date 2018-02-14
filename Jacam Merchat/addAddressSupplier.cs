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
    public partial class addAddressSupplier : MetroFramework.Forms.MetroForm
    {
        MySqlConnection conn;
        public int user_id { get; set; }
        public int user_type { get; set; }
        public int po_id { get; set; }
        public int po_bid_id { get; set; }
        public DataTable dt { get; set; }
        public addAddressSupplier()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost; database=jacammerchant; uid=root; pwd=root");
            lblId.Hide();
            lblpo_bid_id.Hide();
        }

        private void addAddressSupplier_Load(object sender, EventArgs e)
        {
            lblId.Text = po_id.ToString();
            lblpo_bid_id.Text = po_bid_id.ToString();
        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            int year, month, ty, tm, day, td;
            year = int.Parse(date.Value.ToString("yyyy"));
            month = int.Parse(date.Value.ToString("MM"));
            day = int.Parse(date.Value.ToString("dd"));
            ty = int.Parse(DateTime.Now.ToString("yyyy"));
            tm = int.Parse(DateTime.Now.ToString("MM"));
            td = int.Parse(DateTime.Now.ToString("dd"));
            ty -= year;
            tm -= month;
            conn.Open();
            if (year >= 0 && tm >= 0 && txtAdd.Text != "")
            {
                string ins = "INSERT INTO po_del VALUES(NULL, '"+lblpo_bid_id.Text+"','"+date.Value.ToString("yyyy-MM-dd")+"', '"+txtAdd.Text+"', '"+user_id+"')";
                MySqlCommand comm = new MySqlCommand(ins, conn);
                comm.ExecuteNonQuery();
                string sel = "SELECT max(po_del_id) FROM po_del";
                comm = new MySqlCommand(sel, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                comm.ExecuteNonQuery();
                DataTable id = new DataTable();
                adp.Fill(id);
                if (id.Rows.Count >= 0)
                {
                    for (int i = 0; i < id.Rows.Count; i++)
                    {
                        ins = "INSERT INTO po_del_line VALUES(NULL, '" + id.Rows[i][0].ToString() + "', '" + lblId.Text + "', NULL, NULL, NULL)";
                        comm = new MySqlCommand(ins, conn);
                        comm.ExecuteNonQuery();
                    }
                    conn.Close();
                    MessageBox.Show("Successfully Set!", "");
                    this.Close();
                }else
                {
                    MessageBox.Show("Error! No Data Found", "");
                }
            }else
            {
                MessageBox.Show("Wrong!", "");
            }
            conn.Close();
        }
    }
}
