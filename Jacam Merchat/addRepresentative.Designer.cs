namespace Jacam_Merchat
{
    partial class addRepresentative
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.dgvSupProf = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSe = new MetroFramework.Controls.MetroTile();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupProf)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Company:";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(130, 97);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(57, 21);
            this.lblCompany.TabIndex = 1;
            this.lblCompany.Text = "label2";
            // 
            // dgvSupProf
            // 
            this.dgvSupProf.AllowUserToAddRows = false;
            this.dgvSupProf.AllowUserToDeleteRows = false;
            this.dgvSupProf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSupProf.Location = new System.Drawing.Point(36, 121);
            this.dgvSupProf.Name = "dgvSupProf";
            this.dgvSupProf.ReadOnly = true;
            this.dgvSupProf.Size = new System.Drawing.Size(621, 351);
            this.dgvSupProf.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(410, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Search:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(484, 91);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(173, 27);
            this.textBox1.TabIndex = 4;
            // 
            // btnSe
            // 
            this.btnSe.ActiveControl = null;
            this.btnSe.Location = new System.Drawing.Point(561, 482);
            this.btnSe.Name = "btnSe";
            this.btnSe.Size = new System.Drawing.Size(96, 39);
            this.btnSe.TabIndex = 5;
            this.btnSe.Text = "Select";
            this.btnSe.UseSelectable = true;
            this.btnSe.Click += new System.EventHandler(this.btnSe_Click);
            // 
            // addRepresentative
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 548);
            this.Controls.Add(this.btnSe);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvSupProf);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "addRepresentative";
            this.Padding = new System.Windows.Forms.Padding(33, 97, 33, 32);
            this.Text = "Representative";
            this.Load += new System.EventHandler(this.addRepresentative_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupProf)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.DataGridView dgvSupProf;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private MetroFramework.Controls.MetroTile btnSe;
    }
}