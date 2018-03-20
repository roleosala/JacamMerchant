namespace Jacam_Merchat
{
    partial class Inventory
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
            this.tabPage = new System.Windows.Forms.TabControl();
            this.tb1 = new System.Windows.Forms.TabPage();
            this.lblId = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDes = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddPrice = new System.Windows.Forms.Button();
            this.dgvPro = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tb2 = new System.Windows.Forms.TabPage();
            this.btnPrintSi = new System.Windows.Forms.Button();
            this.dgvSI = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.tb3 = new System.Windows.Forms.TabPage();
            this.btnPrintSO = new System.Windows.Forms.Button();
            this.dgvSO = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.printDialogSi = new System.Windows.Forms.PrintDialog();
            this.PrintDocSi = new System.Drawing.Printing.PrintDocument();
            this.PrintDocSO = new System.Drawing.Printing.PrintDocument();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvSoR = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage.SuspendLayout();
            this.tb1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPro)).BeginInit();
            this.tb2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSI)).BeginInit();
            this.tb3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSO)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoR)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage
            // 
            this.tabPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPage.Controls.Add(this.tb1);
            this.tabPage.Controls.Add(this.tb2);
            this.tabPage.Controls.Add(this.tb3);
            this.tabPage.Controls.Add(this.tabPage1);
            this.tabPage.Location = new System.Drawing.Point(36, 100);
            this.tabPage.Name = "tabPage";
            this.tabPage.SelectedIndex = 0;
            this.tabPage.Size = new System.Drawing.Size(960, 579);
            this.tabPage.TabIndex = 0;
            // 
            // tb1
            // 
            this.tb1.Controls.Add(this.lblId);
            this.tb1.Controls.Add(this.txtPrice);
            this.tb1.Controls.Add(this.label5);
            this.tb1.Controls.Add(this.lblDes);
            this.tb1.Controls.Add(this.label4);
            this.tb1.Controls.Add(this.btnAddPrice);
            this.tb1.Controls.Add(this.dgvPro);
            this.tb1.Controls.Add(this.label1);
            this.tb1.Location = new System.Drawing.Point(4, 30);
            this.tb1.Name = "tb1";
            this.tb1.Padding = new System.Windows.Forms.Padding(3);
            this.tb1.Size = new System.Drawing.Size(952, 545);
            this.tb1.TabIndex = 0;
            this.tb1.Text = "Stocks";
            this.tb1.UseVisualStyleBackColor = true;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(166, 3);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(42, 21);
            this.lblId.TabIndex = 7;
            this.lblId.Text = "N/A";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(580, 18);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(247, 27);
            this.txtPrice.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(523, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 21);
            this.label5.TabIndex = 5;
            this.label5.Text = "Price:";
            // 
            // lblDes
            // 
            this.lblDes.AutoSize = true;
            this.lblDes.Location = new System.Drawing.Point(113, 24);
            this.lblDes.Name = "lblDes";
            this.lblDes.Size = new System.Drawing.Size(171, 21);
            this.lblDes.TabIndex = 4;
            this.lblDes.Text = "No Product Selected";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Description:";
            // 
            // btnAddPrice
            // 
            this.btnAddPrice.Location = new System.Drawing.Point(833, 18);
            this.btnAddPrice.Name = "btnAddPrice";
            this.btnAddPrice.Size = new System.Drawing.Size(113, 27);
            this.btnAddPrice.TabIndex = 2;
            this.btnAddPrice.Text = "Add Price";
            this.btnAddPrice.UseVisualStyleBackColor = true;
            this.btnAddPrice.Click += new System.EventHandler(this.btnAddPrice_Click);
            // 
            // dgvPro
            // 
            this.dgvPro.AllowUserToAddRows = false;
            this.dgvPro.AllowUserToDeleteRows = false;
            this.dgvPro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPro.BackgroundColor = System.Drawing.Color.White;
            this.dgvPro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPro.Location = new System.Drawing.Point(6, 48);
            this.dgvPro.MultiSelect = false;
            this.dgvPro.Name = "dgvPro";
            this.dgvPro.ReadOnly = true;
            this.dgvPro.RowHeadersVisible = false;
            this.dgvPro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPro.Size = new System.Drawing.Size(940, 491);
            this.dgvPro.TabIndex = 1;
            this.dgvPro.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPro_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Available Products";
            // 
            // tb2
            // 
            this.tb2.Controls.Add(this.btnPrintSi);
            this.tb2.Controls.Add(this.dgvSI);
            this.tb2.Controls.Add(this.label2);
            this.tb2.Location = new System.Drawing.Point(4, 30);
            this.tb2.Name = "tb2";
            this.tb2.Padding = new System.Windows.Forms.Padding(3);
            this.tb2.Size = new System.Drawing.Size(952, 545);
            this.tb2.TabIndex = 1;
            this.tb2.Text = "Stocks In";
            this.tb2.UseVisualStyleBackColor = true;
            // 
            // btnPrintSi
            // 
            this.btnPrintSi.Location = new System.Drawing.Point(855, 7);
            this.btnPrintSi.Name = "btnPrintSi";
            this.btnPrintSi.Size = new System.Drawing.Size(91, 36);
            this.btnPrintSi.TabIndex = 4;
            this.btnPrintSi.Text = "Print";
            this.btnPrintSi.UseVisualStyleBackColor = true;
            this.btnPrintSi.Click += new System.EventHandler(this.btnPrintSi_Click);
            // 
            // dgvSI
            // 
            this.dgvSI.AllowUserToAddRows = false;
            this.dgvSI.AllowUserToDeleteRows = false;
            this.dgvSI.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSI.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSI.BackgroundColor = System.Drawing.Color.White;
            this.dgvSI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSI.Location = new System.Drawing.Point(6, 49);
            this.dgvSI.MultiSelect = false;
            this.dgvSI.Name = "dgvSI";
            this.dgvSI.ReadOnly = true;
            this.dgvSI.RowHeadersVisible = false;
            this.dgvSI.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSI.Size = new System.Drawing.Size(940, 490);
            this.dgvSI.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Stock In History";
            // 
            // tb3
            // 
            this.tb3.Controls.Add(this.btnPrintSO);
            this.tb3.Controls.Add(this.dgvSO);
            this.tb3.Controls.Add(this.label3);
            this.tb3.Location = new System.Drawing.Point(4, 30);
            this.tb3.Name = "tb3";
            this.tb3.Padding = new System.Windows.Forms.Padding(3);
            this.tb3.Size = new System.Drawing.Size(952, 545);
            this.tb3.TabIndex = 2;
            this.tb3.Text = "Stocks out";
            this.tb3.UseVisualStyleBackColor = true;
            // 
            // btnPrintSO
            // 
            this.btnPrintSO.Location = new System.Drawing.Point(855, 7);
            this.btnPrintSO.Name = "btnPrintSO";
            this.btnPrintSO.Size = new System.Drawing.Size(91, 36);
            this.btnPrintSO.TabIndex = 5;
            this.btnPrintSO.Text = "Print";
            this.btnPrintSO.UseVisualStyleBackColor = true;
            this.btnPrintSO.Click += new System.EventHandler(this.btnPrintSO_Click);
            // 
            // dgvSO
            // 
            this.dgvSO.AllowUserToAddRows = false;
            this.dgvSO.AllowUserToDeleteRows = false;
            this.dgvSO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSO.BackgroundColor = System.Drawing.Color.White;
            this.dgvSO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSO.Location = new System.Drawing.Point(6, 49);
            this.dgvSO.MultiSelect = false;
            this.dgvSO.Name = "dgvSO";
            this.dgvSO.ReadOnly = true;
            this.dgvSO.RowHeadersVisible = false;
            this.dgvSO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSO.Size = new System.Drawing.Size(940, 472);
            this.dgvSO.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Stock Out History";
            // 
            // printDialogSi
            // 
            this.printDialogSi.UseEXDialog = true;
            // 
            // PrintDocSi
            // 
            this.PrintDocSi.DocumentName = "Stocks In";
            this.PrintDocSi.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocSi_PrintPage);
            // 
            // PrintDocSO
            // 
            this.PrintDocSO.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocSO_PrintPage);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.dgvSoR);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(952, 545);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Stock Out Returns";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(855, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 36);
            this.button1.TabIndex = 8;
            this.button1.Text = "Print";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dgvSoR
            // 
            this.dgvSoR.AllowUserToAddRows = false;
            this.dgvSoR.AllowUserToDeleteRows = false;
            this.dgvSoR.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSoR.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSoR.BackgroundColor = System.Drawing.Color.White;
            this.dgvSoR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSoR.Location = new System.Drawing.Point(6, 49);
            this.dgvSoR.MultiSelect = false;
            this.dgvSoR.Name = "dgvSoR";
            this.dgvSoR.ReadOnly = true;
            this.dgvSoR.RowHeadersVisible = false;
            this.dgvSoR.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSoR.Size = new System.Drawing.Size(940, 472);
            this.dgvSoR.TabIndex = 7;
            this.dgvSoR.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 21);
            this.label6.TabIndex = 6;
            this.label6.Text = "Stock Out History";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 714);
            this.Controls.Add(this.tabPage);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Inventory";
            this.Padding = new System.Windows.Forms.Padding(33, 97, 33, 32);
            this.Text = "Inventory";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Inventory_FormClosing);
            this.Load += new System.EventHandler(this.Inventory_Load);
            this.tabPage.ResumeLayout(false);
            this.tb1.ResumeLayout(false);
            this.tb1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPro)).EndInit();
            this.tb2.ResumeLayout(false);
            this.tb2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSI)).EndInit();
            this.tb3.ResumeLayout(false);
            this.tb3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSO)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoR)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabPage;
        private System.Windows.Forms.TabPage tb1;
        private System.Windows.Forms.TabPage tb2;
        private System.Windows.Forms.TabPage tb3;
        private System.Windows.Forms.DataGridView dgvPro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSI;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvSO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddPrice;
        private System.Windows.Forms.Label lblDes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.PrintDialog printDialogSi;
        private System.Drawing.Printing.PrintDocument PrintDocSi;
        private System.Windows.Forms.Button btnPrintSi;
        private System.Windows.Forms.Button btnPrintSO;
        private System.Drawing.Printing.PrintDocument PrintDocSO;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvSoR;
        private System.Windows.Forms.Label label6;
    }
}