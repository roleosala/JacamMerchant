﻿namespace Jacam_Merchat
{
    partial class bidPurchOrder
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
            this.dgvPO = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnDelRec = new MetroFramework.Controls.MetroTile();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRn = new System.Windows.Forms.Label();
            this.lblPo_Bid_id = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.lblSup = new System.Windows.Forms.Label();
            this.cmbSup = new System.Windows.Forms.ComboBox();
            this.sup_id = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPO)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPO
            // 
            this.dgvPO.AllowUserToAddRows = false;
            this.dgvPO.AllowUserToDeleteRows = false;
            this.dgvPO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPO.BackgroundColor = System.Drawing.Color.White;
            this.dgvPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPO.Location = new System.Drawing.Point(38, 138);
            this.dgvPO.Margin = new System.Windows.Forms.Padding(5);
            this.dgvPO.Name = "dgvPO";
            this.dgvPO.ReadOnly = true;
            this.dgvPO.RowHeadersVisible = false;
            this.dgvPO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPO.Size = new System.Drawing.Size(855, 509);
            this.dgvPO.TabIndex = 2;
            this.dgvPO.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPO_CellContentClick);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(38, 100);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 30);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnDelRec
            // 
            this.btnDelRec.ActiveControl = null;
            this.btnDelRec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelRec.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnDelRec.Location = new System.Drawing.Point(794, 655);
            this.btnDelRec.Name = "btnDelRec";
            this.btnDelRec.Size = new System.Drawing.Size(99, 42);
            this.btnDelRec.TabIndex = 4;
            this.btnDelRec.Text = "Deliver";
            this.btnDelRec.UseCustomBackColor = true;
            this.btnDelRec.UseSelectable = true;
            this.btnDelRec.Click += new System.EventHandler(this.btnDelRec_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "Reference NO.";
            // 
            // lblRn
            // 
            this.lblRn.AutoSize = true;
            this.lblRn.Location = new System.Drawing.Point(164, 57);
            this.lblRn.Name = "lblRn";
            this.lblRn.Size = new System.Drawing.Size(57, 21);
            this.lblRn.TabIndex = 6;
            this.lblRn.Text = "label2";
            // 
            // lblPo_Bid_id
            // 
            this.lblPo_Bid_id.AutoSize = true;
            this.lblPo_Bid_id.Location = new System.Drawing.Point(389, 57);
            this.lblPo_Bid_id.Name = "lblPo_Bid_id";
            this.lblPo_Bid_id.Size = new System.Drawing.Size(86, 21);
            this.lblPo_Bid_id.TabIndex = 7;
            this.lblPo_Bid_id.Text = "po_bid_id";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(818, 100);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 30);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.DocumentName = global::Jacam_Merchat.Properties.Settings.Default.PurchaseOderNo;
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // lblSup
            // 
            this.lblSup.AutoSize = true;
            this.lblSup.Location = new System.Drawing.Point(497, 108);
            this.lblSup.Name = "lblSup";
            this.lblSup.Size = new System.Drawing.Size(71, 21);
            this.lblSup.TabIndex = 9;
            this.lblSup.Text = "Supplier";
            // 
            // cmbSup
            // 
            this.cmbSup.FormattingEnabled = true;
            this.cmbSup.Location = new System.Drawing.Point(574, 100);
            this.cmbSup.Name = "cmbSup";
            this.cmbSup.Size = new System.Drawing.Size(238, 29);
            this.cmbSup.TabIndex = 10;
            this.cmbSup.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // sup_id
            // 
            this.sup_id.AutoSize = true;
            this.sup_id.Location = new System.Drawing.Point(818, 47);
            this.sup_id.Name = "sup_id";
            this.sup_id.Size = new System.Drawing.Size(59, 21);
            this.sup_id.TabIndex = 11;
            this.sup_id.Text = "sup_id";
            // 
            // bidPurchOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 732);
            this.Controls.Add(this.sup_id);
            this.Controls.Add(this.cmbSup);
            this.Controls.Add(this.lblSup);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblPo_Bid_id);
            this.Controls.Add(this.lblRn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDelRec);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dgvPO);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "bidPurchOrder";
            this.Padding = new System.Windows.Forms.Padding(33, 97, 33, 32);
            this.Text = "Bidding Purchase Order";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.bidPurchOrder_FormClosing);
            this.Load += new System.EventHandler(this.bidPurchOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPO)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPO;
        private System.Windows.Forms.Button btnBack;
        private MetroFramework.Controls.MetroTile btnDelRec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRn;
        private System.Windows.Forms.Label lblPo_Bid_id;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label lblSup;
        private System.Windows.Forms.ComboBox cmbSup;
        private System.Windows.Forms.Label sup_id;
    }
}