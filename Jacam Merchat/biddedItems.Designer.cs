namespace Jacam_Merchat
{
    partial class biddedItems
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
            this.dgvBid = new System.Windows.Forms.DataGridView();
            this.btnRem = new MetroFramework.Controls.MetroTile();
            this.btnCheckOut = new MetroFramework.Controls.MetroTile();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBid)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBid
            // 
            this.dgvBid.AllowUserToAddRows = false;
            this.dgvBid.AllowUserToDeleteRows = false;
            this.dgvBid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBid.Location = new System.Drawing.Point(38, 151);
            this.dgvBid.Margin = new System.Windows.Forms.Padding(5);
            this.dgvBid.MultiSelect = false;
            this.dgvBid.Name = "dgvBid";
            this.dgvBid.ReadOnly = true;
            this.dgvBid.RowHeadersVisible = false;
            this.dgvBid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBid.Size = new System.Drawing.Size(623, 478);
            this.dgvBid.TabIndex = 0;
            // 
            // btnRem
            // 
            this.btnRem.ActiveControl = null;
            this.btnRem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRem.BackColor = System.Drawing.Color.Red;
            this.btnRem.Location = new System.Drawing.Point(467, 101);
            this.btnRem.Name = "btnRem";
            this.btnRem.Size = new System.Drawing.Size(95, 42);
            this.btnRem.TabIndex = 1;
            this.btnRem.Text = "Remove";
            this.btnRem.UseCustomBackColor = true;
            this.btnRem.UseSelectable = true;
            this.btnRem.Click += new System.EventHandler(this.btnRem_Click);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.ActiveControl = null;
            this.btnCheckOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckOut.BackColor = System.Drawing.Color.Coral;
            this.btnCheckOut.Location = new System.Drawing.Point(568, 101);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(93, 41);
            this.btnCheckOut.TabIndex = 2;
            this.btnCheckOut.Text = "Check Out";
            this.btnCheckOut.UseCustomBackColor = true;
            this.btnCheckOut.UseSelectable = true;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(38, 100);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(109, 41);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "<< BACK";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // biddedItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 666);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.btnRem);
            this.Controls.Add(this.dgvBid);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "biddedItems";
            this.Padding = new System.Windows.Forms.Padding(33, 97, 33, 32);
            this.Text = "Cart";
            this.Load += new System.EventHandler(this.biddedItems_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBid;
        private MetroFramework.Controls.MetroTile btnRem;
        private MetroFramework.Controls.MetroTile btnCheckOut;
        private System.Windows.Forms.Button btnBack;
    }
}