using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jacam_Merchat
{
    public partial class addComControl : MetroFramework.Forms.MetroForm
    {
        public int user_id { get; set; }
        public Company prevform { get; set; }
        public int com_id { get; set; }
        public addComControl()
        {
            InitializeComponent();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            addRepresentative add = new addRepresentative();
            add.prevform = prevform;
            add.Show();
            add.com_id = com_id;
            this.Close();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            addCompany add = new addCompany();
            add.prevform = prevform;
            add.user_id = prevform.user_id;
            add.Show();
            prevform.Hide();
            this.Close();
        }
    }
}
