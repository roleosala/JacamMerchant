namespace Jacam_Merchat
{
    partial class addReturns
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvRet)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRet
            // 
            this.dgvRet.AllowUserToAddRows = false;
            this.dgvRet.AllowUserToDeleteRows = false;
            this.dgvRet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRet.Location = new System.Drawing.Point(36, 100);
            this.dgvRet.Name = "dgvRet";
            this.dgvRet.ReadOnly = true;
            this.dgvRet.Size = new System.Drawing.Size(738, 446);
            this.dgvRet.TabIndex = 0;
            this.dgvRet.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // addReturns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 581);
            this.Controls.Add(this.dgvRet);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "addReturns";
            this.Padding = new System.Windows.Forms.Padding(33, 97, 33, 32);
            this.Text = "addReturns";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRet;
    }
}