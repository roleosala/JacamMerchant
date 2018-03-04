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
        public int offSet { get; set; }
        public addAddressSupplier()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost; database=jacammerchant; uid=root; pwd=root");
            lblId.Hide();
            lblpo_del_id.Hide();
        }

        private void addAddressSupplier_Load(object sender, EventArgs e)
        {
            lblId.Text = po_id.ToString();
            lblpo_del_id.Text = po_bid_id.ToString();
            show();
        }

        private void show()
        {
            dgvDel.DataSource = this.dt;
            dgvDel.Columns[0].Visible = false;//po_bid_line_id
            dgvDel.Columns[1].Visible = false;//po_bid_id
            dgvDel.Columns[2].Visible = false;//item_id
            dgvDel.Columns[3].HeaderText = "QTY Bought";
            dgvDel.Columns[4].Visible = false;//sup_id
            dgvDel.Columns[5].Visible = false;//po_num
            dgvDel.Columns[6].HeaderText = "QTY Rem";
            dgvDel.Columns[7].HeaderText = "Item Description";
            DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
            txt.Name = "txt";
            txt.HeaderText = "Items to be Delivered";
            dgvDel.Columns.Add(txt);
            dgvDel.ClearSelection();
            dgvDel.Columns[3].ReadOnly = true;
            dgvDel.Columns[6].ReadOnly = true;
            dgvDel.Columns[7].ReadOnly = true;
            dgvDel.Columns["txt"].ReadOnly = false;
            for (int i = 0; i <dgvDel.Rows.Count; i++)
            {
                dgvDel.Rows[i].Cells["txt"].Value = 0;
            }
            //dgvDel.Columns[7].txt_TextChange += new DataGridViewCellEventHandler(txt_TextChange);
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
                string se = "SELECT max(dr) FROM po_del";
                MySqlCommand com = new MySqlCommand(se, conn);
                MySqlDataAdapter ad = new MySqlDataAdapter(com);
                com.ExecuteNonQuery();
                DataTable d = new DataTable();
                ad.Fill(d);
                int max;
                string counter = d.Rows[0][0].ToString();
                if (d.Rows.Count == 0 || d.Rows[0][0].ToString() == "" || d.Rows[0][0].ToString() == null)
                {
                    max = 1;
                }else
                {
                    max = int.Parse(d.Rows[0][0].ToString()) + 1;
                }
                int c = 0;
                int t = 0;
                for (int i = 0; i < dgvDel.Rows.Count; i++)
                {
                    if (dgvDel.Rows[i].Cells["txt"].Value.ToString() == null || dgvDel.Rows[i].Cells["txt"].Value.ToString() == "")
                    {
                        c++;
                    }
                    if (int.Parse(dgvDel.Rows[i].Cells["txt"].Value.ToString()) > int.Parse(dgvDel.Rows[i].Cells[3].Value.ToString()) && dgvDel.Rows[i].Cells["txt"].Value.ToString() != "")
                    {
                        dgvDel.Rows[i].Cells["txt"].Value = dgvDel.Rows[i].Cells[3].Value.ToString();
                        t++;
                    }
                }
                if (t > 0)
                {
                    MessageBox.Show("You have delivered more items that the qty bought. Automatically set it to maximum deliverable items to the qty bought.","Delivered more items", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
                if (c != dgvDel.Rows.Count)
                {
                    string ins = "INSERT INTO po_del VALUES(NULL, '" + lblpo_del_id.Text + "','" + date.Value.ToString("yyyy-MM-dd") + "', '" + txtAdd.Text + "', '" + user_id + "', '" + max + "')";
                    MySqlCommand comm = new MySqlCommand(ins, conn);
                    comm.ExecuteNonQuery();
                    string sel = "SELECT max(po_del_id) FROM po_del";
                    comm = new MySqlCommand(sel, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                    comm.ExecuteNonQuery();
                    DataTable id = new DataTable();
                    adp.Fill(id);
                    int k = 0;
                    if (id.Rows.Count >= 0)
                    {
                        string ch = "walay query";
                        for (int i = 0; i < dgvDel.Rows.Count; i++)
                        {
                            if (int.Parse(dgvDel.Rows[i].Cells["txt"].Value.ToString()) != 0)
                            {
                                int qtyRem = int.Parse(dgvDel.Rows[i].Cells[3].Value.ToString()) - int.Parse(dgvDel.Rows[i].Cells["txt"].Value.ToString());
                                ins = "INSERT INTO po_del_line VALUES(NULL,'" + id.Rows[0][0].ToString() + "' ,'" + dgvDel.Rows[i].Cells[0].Value.ToString() + "', '" + dgvDel.Rows[i].Cells[2].Value.ToString() + "', '" + dgvDel.Rows[i].Cells[3].Value.ToString() + "', NULL, NULL, NULL, '" + dgvDel.Rows[i].Cells["txt"].Value.ToString() + "')";
                                comm = new MySqlCommand(ins, conn);
                                comm.ExecuteNonQuery();
                                ch = "SELECT qtyRem FROM po_bid_line WHERE po_bid_line_id = '"+ dgvDel.Rows[i].Cells[0].Value.ToString() + "'";
                                comm = new MySqlCommand(ch, conn);
                                adp = new MySqlDataAdapter(comm);
                                comm.ExecuteNonQuery();
                                DataTable dt = new DataTable();
                                adp.Fill(dt);
                                if (dt.Rows.Count == 1)
                                {
                                    if (dt.Rows[0][0].ToString() == null || dt.Rows[0][0].ToString() == "")
                                    {
                                        string upd = "UPDATE po_bid_line SET qtyRem = '"+qtyRem+"' WHERE po_bid_line_id = '"+ dgvDel.Rows[i].Cells[0].Value.ToString() + "'";
                                        comm = new MySqlCommand(upd, conn);
                                        comm.ExecuteNonQuery();
                                    }
                                    else
                                    {
                                        qtyRem = int.Parse(dt.Rows[0][0].ToString()) - int.Parse(dgvDel.Rows[i].Cells["txt"].Value.ToString());
                                        if (qtyRem >= 0)
                                        {
                                            string upd = "UPDATE po_bid_line SET qtyRem = '" + qtyRem + "' WHERE po_bid_line_id = '" + dgvDel.Rows[i].Cells[0].Value.ToString() + "'";
                                            comm = new MySqlCommand(upd, conn);
                                            comm.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            qtyRem = 0;
                                            string upd = "UPDATE po_bid_line SET qtyRem = '" + qtyRem + "' WHERE po_bid_line_id = '" + dgvDel.Rows[i].Cells[0].Value.ToString() + "'";
                                            comm = new MySqlCommand(upd, conn);
                                            comm.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                c++;
                            }
                        }
                        conn.Close();
                        MessageBox.Show("Successfully Set! ", "");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error! No Data Found", "");
                    }
                }
                else
                {
                    MessageBox.Show("Please Deliver 1 or more items","Deliver 1 or more items", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }else
            {
                MessageBox.Show("Please Check The Date you want to deliver or the address to continue!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }
        
        private void dgvDel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvDel_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
