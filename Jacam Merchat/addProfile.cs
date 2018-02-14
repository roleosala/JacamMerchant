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
    public partial class addProfile : MetroFramework.Forms.MetroForm
    {
        public Profile prevform { get; set; }
        MySqlConnection conn;
        public addProfile()
        {
            InitializeComponent();
            conn = new MySqlConnection("server=localhost; database=jacammerchant; uid=root; pwd=root");
            lblID.Hide();
            lblIdNo.Hide();
            btnUpd.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string gen = null;
            int usrType = 0;
            if (rbtnGenF.Checked)
            {
                gen = "F";
            }else if (rbtnGenM.Checked)
            {
                gen = "M";
            }else
            {
                this.Refresh();
            }
            if(cmbUsrTyp.Text == "Owner")
            {
                usrType = 1;
            }else if (cmbUsrTyp.Text == "Manager")
            {
                usrType = 2;
            }else if (cmbUsrTyp.Text == "Staff")
            {
                usrType = 3;
            }else if (cmbUsrTyp.Text == "Supplier")
            {
                usrType = 4;
            }else if (cmbUsrTyp.Text == "Delivery")
            {
                usrType = 5;
            }
            else if (cmbUsrTyp.Text == "Client")
            {
                usrType = 6;
            }
            else
            {
                MessageBox.Show("Please Select What User Type!","", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                this.Refresh();
            }
            string verify = "SELECT * FROM profile WHERE fn = '"+ txtFn.Text + "' AND ln = '"+ txtLn.Text + "' AND mi = '"+ txtMI.Text + "'";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(verify, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                DialogResult res = MessageBox.Show("Profile Already Exist!","", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (res == DialogResult.Retry)
                {
                    clear();
                }else
                {
                    this.Close();
                }
            }
            else
            {
                if (gen != null && usrType != 0)
                {
                    add(gen, usrType);
                }
            }
        }
        private void add(string gen, int usrType)
        {
            if (!(txtFn.Text =="" && txtLn.Text == "" && txtMI.Text == "" && txtEmail.Text == "" && txtcn.Text == "" &&txtAddress.Text == ""))
            {
                string fullname = txtFn.Text +" "+ txtMI.Text+". " + txtLn.Text;
                string addProf = "INSERT INTO profile VALUES(NULL, '" + fullname + "', '" + txtFn.Text + "','" + txtLn.Text + "','" + txtMI.Text + "','" + gen + "','" + txtEmail.Text + "','" + txtcn.Text + "','" + txtAddress.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "', '"+usrType+"')";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(addProf, conn);
                comm.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Successfully added new Profile!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (usrType == 1 || usrType == 2 || usrType == 3 || usrType == 4)
                {
                    addCredentials addC = new addCredentials();
                    addC.prevForm = this;
                    addC.ShowDialog();
                }
                this.Close();
            }
            else
            {
                DialogResult res = MessageBox.Show("Please fill in all the fields!","", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (res == DialogResult.Retry)
                {
                    this.Refresh();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            this.Text = "Add Profile";
            lblID.Hide();
            lblIdNo.Hide();
            btnUpd.Hide();
            txtFn.Clear();
            txtLn.Clear();
            txtMI.Clear();
            txtEmail.Clear();
            txtcn.Clear();
            txtAddress.Clear();
            txtFn.Focus();
            btnSave.Show();
        }

        private void txtcn_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar);
        }
        public void clear()
        {
            txtFn.Clear();
            txtLn.Clear();
            txtMI.Clear();
            txtEmail.Clear();
            txtcn.Clear();
            txtAddress.Clear();
            txtFn.Focus();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public int id;
        public void edit(int id, string fn, string mi, string ln, string gen, string email, string cn, string add, string type)
        {
            this.Text = "Edit Profile";
            btnUpd.Show();
            btnSave.Hide();
            btnUpd.Location = new Point(560, 352);
            this.id = id;
            lblID.Show();
            lblIdNo.Show();
            lblIdNo.Text = id.ToString(); ;
            txtFn.Text = fn;
            txtLn.Text = ln;
            txtMI.Text = mi;
            txtEmail.Text = email;
            txtcn.Text = cn;
            txtAddress.Text = add;
            /*
            if (int.Parse(type) == 1)
            {
                type = "Owner";
            }
            else if (int.Parse(type) == 2)
            {
                type = "Manager";
            }
            else if (int.Parse(type) == 3)
            {
                type = "Staff";
            }
            else if (int.Parse(type) == 4)
            {
                type = "Supplier";
            }
            else if (int.Parse(type) == 5)
            {
                type = "Delivery";
            }
            */
            if (gen == "M")
            {
                rbtnGenM.Checked = true;
            }
            else if (gen == "F")
            {
                rbtnGenF.Checked = true;
            }
            else
            {

            }
            cmbUsrTyp.SelectedItem = type;
            txtFn.Focus();
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            int usrType = 0;
            if (!(txtFn.Text == "" && txtLn.Text == "" && txtMI.Text == "" && txtEmail.Text == "" && txtcn.Text == "" && txtAddress.Text == ""))
            {
                if (cmbUsrTyp.Text == "Owner")
                {
                    usrType = 1;
                }
                else if (cmbUsrTyp.Text == "Manager")
                {
                    usrType = 2;
                }
                else if (cmbUsrTyp.Text == "Staff")
                {
                    usrType = 3;
                }
                else if (cmbUsrTyp.Text == "Supplier")
                {
                    usrType = 4;
                }
                else if (cmbUsrTyp.Text == "Delivery")
                {
                    usrType = 5;
                }
                else if (cmbUsrTyp.Text == "Client")
                {
                    usrType = 6;
                }
                else
                {
                    MessageBox.Show("Please Select What User Type!", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    this.Refresh();
                }
                string gen = null;
                if (rbtnGenF.Checked)
                {
                    gen = "F";
                }
                else if (rbtnGenM.Checked)
                {
                    gen = "M";
                }else
                {
                    MessageBox.Show("Please Select a gender Before Proceeding!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (gen != null)
                {
                    string fullname = txtFn.Text + " " + txtMI.Text + ". " + txtLn.Text;
                    string upd = "UPDATE profile SET fn = '" + txtFn.Text + "', ln = '" + txtLn.Text + "', mi = '" + txtMI.Text + "', email = '" + txtEmail.Text + "',cn = '" + txtcn.Text + "', address = '" + txtAddress.Text + "',user_type = " + usrType + ", sex = '" + gen + "', name = '" + fullname + "' WHERE prof_id = '" + lblIdNo.Text + "'";
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(upd, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                    comm.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Successfully Updated Profile!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
