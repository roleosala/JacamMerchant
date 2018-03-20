namespace Jacam_Merchat
{
    partial class Delivery
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAdd = new MetroFramework.Controls.MetroTile();
            this.btnStat = new MetroFramework.Controls.MetroTile();
            this.dgvDel = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDel)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.ActiveControl = null;
            this.btnAdd.BackColor = System.Drawing.Color.Coral;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(665, 655);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(119, 42);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Return";
            this.btnAdd.UseCustomBackColor = true;
            this.btnAdd.UseCustomForeColor = true;
            this.btnAdd.UseSelectable = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnStat
            // 
            this.btnStat.ActiveControl = null;
            this.btnStat.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnStat.ForeColor = System.Drawing.Color.White;
            this.btnStat.Location = new System.Drawing.Point(790, 655);
            this.btnStat.Name = "btnStat";
            this.btnStat.Size = new System.Drawing.Size(103, 42);
            this.btnStat.TabIndex = 2;
            this.btnStat.Text = "Status";
            this.btnStat.UseCustomBackColor = true;
            this.btnStat.UseCustomForeColor = true;
            this.btnStat.UseSelectable = true;
            this.btnStat.Click += new System.EventHandler(this.btnStat_Click);
            // 
            // dgvDel
            // 
            this.dgvDel.AllowUserToAddRows = false;
            this.dgvDel.AllowUserToDeleteRows = false;
            this.dgvDel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDel.BackgroundColor = System.Drawing.Color.White;
            this.dgvDel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDel.Location = new System.Drawing.Point(38, 102);
            this.dgvDel.Margin = new System.Windows.Forms.Padding(5);
            this.dgvDel.MultiSelect = false;
            this.dgvDel.Name = "dgvDel";
            this.dgvDel.ReadOnly = true;
            this.dgvDel.RowHeadersVisible = false;
            this.dgvDel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDel.Size = new System.Drawing.Size(855, 545);
            this.dgvDel.TabIndex = 0;
            this.dgvDel.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDel_CellContentClick);
            this.dgvDel.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDel_CellDoubleClick);
            // 
            // Delivery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 732);
            this.Controls.Add(this.btnStat);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvDel);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Delivery";
            this.Padding = new System.Windows.Forms.Padding(33, 97, 33, 32);
            this.Text = "Delivery";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Delivery_FormClosing);
            this.Load += new System.EventHandler(this.Delivery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroTile btnAdd;
        private MetroFramework.Controls.MetroTile btnStat;
        private System.Windows.Forms.DataGridView dgvDel;
    }
}