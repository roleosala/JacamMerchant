namespace Jacam_Merchat
{
    partial class Returns
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
            this.btnUpdDate = new MetroFramework.Controls.MetroTile();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRet)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRet
            // 
            this.dgvRet.AllowUserToAddRows = false;
            this.dgvRet.AllowUserToDeleteRows = false;
            this.dgvRet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRet.BackgroundColor = System.Drawing.Color.White;
            this.dgvRet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRet.GridColor = System.Drawing.Color.Black;
            this.dgvRet.Location = new System.Drawing.Point(36, 100);
            this.dgvRet.MultiSelect = false;
            this.dgvRet.Name = "dgvRet";
            this.dgvRet.ReadOnly = true;
            this.dgvRet.RowHeadersVisible = false;
            this.dgvRet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRet.Size = new System.Drawing.Size(847, 454);
            this.dgvRet.TabIndex = 0;
            this.dgvRet.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRet_CellContentClick);
            // 
            // btnUpdDate
            // 
            this.btnUpdDate.ActiveControl = null;
            this.btnUpdDate.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnUpdDate.ForeColor = System.Drawing.Color.White;
            this.btnUpdDate.Location = new System.Drawing.Point(757, 560);
            this.btnUpdDate.Name = "btnUpdDate";
            this.btnUpdDate.Size = new System.Drawing.Size(126, 46);
            this.btnUpdDate.TabIndex = 1;
            this.btnUpdDate.Text = "Update Date";
            this.btnUpdDate.UseCustomBackColor = true;
            this.btnUpdDate.UseCustomForeColor = true;
            this.btnUpdDate.UseSelectable = true;
            this.btnUpdDate.Click += new System.EventHandler(this.btnUpdDate_Click);
            // 
            // Returns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 641);
            this.Controls.Add(this.btnUpdDate);
            this.Controls.Add(this.dgvRet);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Returns";
            this.Padding = new System.Windows.Forms.Padding(33, 97, 33, 32);
            this.Text = "Returns";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Returns_FormClosing);
            this.Load += new System.EventHandler(this.Returns_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRet;
        private MetroFramework.Controls.MetroTile btnUpdDate;
    }
}