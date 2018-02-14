namespace Jacam_Merchat
{
    partial class OrderList
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
            this.dgvOL = new System.Windows.Forms.DataGridView();
            this.btnBackForm = new System.Windows.Forms.Button();
            this.btnView = new MetroFramework.Controls.MetroTile();
            this.dgvView = new System.Windows.Forms.DataGridView();
            this.btnBackdgv = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOL
            // 
            this.dgvOL.AllowUserToAddRows = false;
            this.dgvOL.AllowUserToDeleteRows = false;
            this.dgvOL.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOL.BackgroundColor = System.Drawing.Color.White;
            this.dgvOL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOL.Location = new System.Drawing.Point(23, 104);
            this.dgvOL.MultiSelect = false;
            this.dgvOL.Name = "dgvOL";
            this.dgvOL.ReadOnly = true;
            this.dgvOL.RowHeadersVisible = false;
            this.dgvOL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOL.Size = new System.Drawing.Size(711, 363);
            this.dgvOL.TabIndex = 1;
            // 
            // btnBackForm
            // 
            this.btnBackForm.FlatAppearance.BorderSize = 0;
            this.btnBackForm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnBackForm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBackForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackForm.Location = new System.Drawing.Point(23, 63);
            this.btnBackForm.Name = "btnBackForm";
            this.btnBackForm.Size = new System.Drawing.Size(94, 35);
            this.btnBackForm.TabIndex = 2;
            this.btnBackForm.Text = "<< Back";
            this.btnBackForm.UseVisualStyleBackColor = true;
            this.btnBackForm.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnView
            // 
            this.btnView.ActiveControl = null;
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.Location = new System.Drawing.Point(659, 63);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 39);
            this.btnView.TabIndex = 3;
            this.btnView.Text = "View";
            this.btnView.UseSelectable = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // dgvView
            // 
            this.dgvView.AllowUserToAddRows = false;
            this.dgvView.AllowUserToDeleteRows = false;
            this.dgvView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvView.BackgroundColor = System.Drawing.Color.White;
            this.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvView.Location = new System.Drawing.Point(23, 104);
            this.dgvView.MultiSelect = false;
            this.dgvView.Name = "dgvView";
            this.dgvView.ReadOnly = true;
            this.dgvView.RowHeadersVisible = false;
            this.dgvView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvView.Size = new System.Drawing.Size(711, 363);
            this.dgvView.TabIndex = 4;
            // 
            // btnBackdgv
            // 
            this.btnBackdgv.FlatAppearance.BorderSize = 0;
            this.btnBackdgv.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnBackdgv.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBackdgv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackdgv.Location = new System.Drawing.Point(123, 63);
            this.btnBackdgv.Name = "btnBackdgv";
            this.btnBackdgv.Size = new System.Drawing.Size(94, 35);
            this.btnBackdgv.TabIndex = 2;
            this.btnBackdgv.Text = "<< Back";
            this.btnBackdgv.UseVisualStyleBackColor = true;
            this.btnBackdgv.Click += new System.EventHandler(this.btnBackdgv_Click);
            // 
            // OrderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 490);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnBackdgv);
            this.Controls.Add(this.btnBackForm);
            this.Controls.Add(this.dgvOL);
            this.Controls.Add(this.dgvView);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "OrderList";
            this.Text = "Order List";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OrderList_FormClosing);
            this.Load += new System.EventHandler(this.OrderList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvOL;
        private System.Windows.Forms.Button btnBackForm;
        private MetroFramework.Controls.MetroTile btnView;
        private System.Windows.Forms.DataGridView dgvView;
        private System.Windows.Forms.Button btnBackdgv;
    }
}