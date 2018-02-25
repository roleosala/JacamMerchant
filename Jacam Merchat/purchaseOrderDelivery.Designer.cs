namespace Jacam_Merchat
{
    partial class purchaseOrderDelivery
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
            this.btnView = new MetroFramework.Controls.MetroTile();
            this.btnBack = new System.Windows.Forms.Button();
            this.lbldate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDel)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDel
            // 
            this.dgvDel.AllowUserToAddRows = false;
            this.dgvDel.AllowUserToDeleteRows = false;
            this.dgvDel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDel.Location = new System.Drawing.Point(38, 140);
            this.dgvDel.Margin = new System.Windows.Forms.Padding(5);
            this.dgvDel.Name = "dgvDel";
            this.dgvDel.ReadOnly = true;
            this.dgvDel.RowHeadersVisible = false;
            this.dgvDel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDel.Size = new System.Drawing.Size(855, 507);
            this.dgvDel.TabIndex = 1;
            this.dgvDel.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDel_CellClick);
            this.dgvDel.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDel_CellContentClick);
            // 
            // btnView
            // 
            this.btnView.ActiveControl = null;
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.Location = new System.Drawing.Point(799, 655);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(94, 42);
            this.btnView.TabIndex = 2;
            this.btnView.Text = "View";
            this.btnView.UseSelectable = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(38, 100);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 32);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.Location = new System.Drawing.Point(649, 111);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(102, 21);
            this.lbldate.TabIndex = 4;
            this.lbldate.Text = "Date Today";
            // 
            // purchaseOrderDelivery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 732);
            this.Controls.Add(this.lbldate);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.dgvDel);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "purchaseOrderDelivery";
            this.Padding = new System.Windows.Forms.Padding(33, 97, 33, 32);
            this.Text = "Purchase Order Delivery";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.purchaseOrderDelivery_FormClosing);
            this.Load += new System.EventHandler(this.purchaseOrderDelivery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDel;
        private MetroFramework.Controls.MetroTile btnView;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lbldate;
    }
}