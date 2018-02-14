namespace Jacam_Merchat
{
    partial class addCompany
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
            this.txtcn = new System.Windows.Forms.TextBox();
            this.txtComAdd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtComName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.metroTile2 = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // txtcn
            // 
            this.txtcn.Location = new System.Drawing.Point(40, 229);
            this.txtcn.Name = "txtcn";
            this.txtcn.Size = new System.Drawing.Size(487, 27);
            this.txtcn.TabIndex = 5;
            // 
            // txtComAdd
            // 
            this.txtComAdd.Location = new System.Drawing.Point(40, 175);
            this.txtComAdd.Name = "txtComAdd";
            this.txtComAdd.Size = new System.Drawing.Size(487, 27);
            this.txtComAdd.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Company Contact No:";
            // 
            // txtComName
            // 
            this.txtComName.Location = new System.Drawing.Point(40, 121);
            this.txtComName.Name = "txtComName";
            this.txtComName.Size = new System.Drawing.Size(487, 27);
            this.txtComName.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Company Address:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Company Name:";
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Location = new System.Drawing.Point(424, 262);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(103, 43);
            this.metroTile1.TabIndex = 8;
            this.metroTile1.Text = "Add";
            this.metroTile1.UseSelectable = true;
            this.metroTile1.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // metroTile2
            // 
            this.metroTile2.ActiveControl = null;
            this.metroTile2.BackColor = System.Drawing.Color.Coral;
            this.metroTile2.Location = new System.Drawing.Point(315, 262);
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Size = new System.Drawing.Size(103, 43);
            this.metroTile2.TabIndex = 8;
            this.metroTile2.Text = "Cancel";
            this.metroTile2.UseCustomBackColor = true;
            this.metroTile2.UseSelectable = true;
            this.metroTile2.Click += new System.EventHandler(this.metroTile2_Click);
            // 
            // addCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 335);
            this.Controls.Add(this.metroTile2);
            this.Controls.Add(this.metroTile1);
            this.Controls.Add(this.txtcn);
            this.Controls.Add(this.txtComAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtComName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "addCompany";
            this.Padding = new System.Windows.Forms.Padding(33, 97, 33, 33);
            this.Text = "Add Company";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.addCompany_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtcn;
        private System.Windows.Forms.TextBox txtComAdd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtComName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Controls.MetroTile metroTile2;
    }
}