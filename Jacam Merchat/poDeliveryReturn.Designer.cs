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
            ((System.ComponentModel.ISupportInitialize)(this.dgvDel)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDel
            // 
            this.dgvDel.AllowUserToAddRows = false;
            this.dgvDel.AllowUserToDeleteRows = false;
            this.dgvDel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDel.Location = new System.Drawing.Point(38, 102);
            this.dgvDel.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dgvDel.Name = "dgvDel";
            this.dgvDel.ReadOnly = true;
            this.dgvDel.Size = new System.Drawing.Size(929, 603);
            this.dgvDel.TabIndex = 0;
            // 
            // poDeliveryReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 742);
            this.Controls.Add(this.dgvDel);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "poDeliveryReturn";
            this.Padding = new System.Windows.Forms.Padding(33, 97, 33, 32);
            this.Text = "poDeliveryReturn";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.poDeliveryReturn_FormClosing);
            this.Load += new System.EventHandler(this.poDeliveryReturn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDel;
    }
}