namespace Jacam_Merchat
{
    partial class poBIdReturns
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
            this.dgvRet = new System.Windows.Forms.DataGridView();
            this.lblRetId = new System.Windows.Forms.Label();
            this.btnViewRet = new MetroFramework.Controls.MetroTile();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRet)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRet
            // 
            this.dgvRet.AllowUserToAddRows = false;
            this.dgvRet.AllowUserToDeleteRows = false;
            this.dgvRet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRet.Location = new System.Drawing.Point(36, 136);
            this.dgvRet.MultiSelect = false;
            this.dgvRet.Name = "dgvRet";
            this.dgvRet.RowHeadersVisible = false;
            this.dgvRet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRet.Size = new System.Drawing.Size(751, 485);
            this.dgvRet.TabIndex = 0;
            // 
            // lblRetId
            // 
            this.lblRetId.AutoSize = true;
            this.lblRetId.Location = new System.Drawing.Point(688, 55);
            this.lblRetId.Name = "lblRetId";
            this.lblRetId.Size = new System.Drawing.Size(54, 21);
            this.lblRetId.TabIndex = 1;
            this.lblRetId.Text = "ret_id";
            // 
            // btnViewRet
            // 
            this.btnViewRet.ActiveControl = null;
            this.btnViewRet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewRet.Location = new System.Drawing.Point(684, 627);
            this.btnViewRet.Name = "btnViewRet";
            this.btnViewRet.Size = new System.Drawing.Size(103, 41);
            this.btnViewRet.TabIndex = 2;
            this.btnViewRet.Text = "View";
            this.btnViewRet.UseSelectable = true;
            this.btnViewRet.Click += new System.EventHandler(this.btnViewRet_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(36, 100);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 30);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // poBIdReturns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 704);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnViewRet);
            this.Controls.Add(this.lblRetId);
            this.Controls.Add(this.dgvRet);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "poBIdReturns";
            this.Padding = new System.Windows.Forms.Padding(33, 97, 33, 33);
            this.Text = "PO Bid Returns";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.poBIdReturns_FormClosing);
            this.Load += new System.EventHandler(this.poBIdReturns_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRet;
        private System.Windows.Forms.Label lblRetId;
        private MetroFramework.Controls.MetroTile btnViewRet;
        private System.Windows.Forms.Button btnBack;
    }
}