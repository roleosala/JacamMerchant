namespace Jacam_Merchat
{
    partial class poDeliveryReturn
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
            this.dgvDel = new System.Windows.Forms.DataGridView();
            this.btnViewRec = new MetroFramework.Controls.MetroTile();
            this.lblDelRetId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDel)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDel
            // 
            this.dgvDel.AllowUserToAddRows = false;
            this.dgvDel.AllowUserToDeleteRows = false;
            this.dgvDel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDel.BackgroundColor = System.Drawing.Color.White;
            this.dgvDel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDel.GridColor = System.Drawing.Color.Black;
            this.dgvDel.Location = new System.Drawing.Point(38, 82);
            this.dgvDel.Margin = new System.Windows.Forms.Padding(5);
            this.dgvDel.MultiSelect = false;
            this.dgvDel.Name = "dgvDel";
            this.dgvDel.ReadOnly = true;
            this.dgvDel.RowHeadersVisible = false;
            this.dgvDel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDel.Size = new System.Drawing.Size(929, 572);
            this.dgvDel.TabIndex = 0;
            this.dgvDel.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDel_CellContentClick);
            // 
            // btnViewRec
            // 
            this.btnViewRec.ActiveControl = null;
            this.btnViewRec.Location = new System.Drawing.Point(862, 662);
            this.btnViewRec.Name = "btnViewRec";
            this.btnViewRec.Size = new System.Drawing.Size(105, 45);
            this.btnViewRec.TabIndex = 1;
            this.btnViewRec.Text = "View";
            this.btnViewRec.UseSelectable = true;
            this.btnViewRec.Click += new System.EventHandler(this.btnViewRec_Click);
            // 
            // lblDelRetId
            // 
            this.lblDelRetId.AutoSize = true;
            this.lblDelRetId.Location = new System.Drawing.Point(910, 56);
            this.lblDelRetId.Name = "lblDelRetId";
            this.lblDelRetId.Size = new System.Drawing.Size(57, 21);
            this.lblDelRetId.TabIndex = 2;
            this.lblDelRetId.Text = "label1";
            // 
            // poDeliveryReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 742);
            this.Controls.Add(this.lblDelRetId);
            this.Controls.Add(this.btnViewRec);
            this.Controls.Add(this.dgvDel);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "poDeliveryReturn";
            this.Padding = new System.Windows.Forms.Padding(33, 97, 33, 32);
            this.Text = "poDeliveryReturn";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.poDeliveryReturn_FormClosing);
            this.Load += new System.EventHandler(this.poDeliveryReturn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDel;
        private MetroFramework.Controls.MetroTile btnViewRec;
        private System.Windows.Forms.Label lblDelRetId;
    }
}