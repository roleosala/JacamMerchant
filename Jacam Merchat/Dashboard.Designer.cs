namespace Jacam_Merchat
{
    partial class Dashboard
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.label1 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnProfMan = new MetroFramework.Controls.MetroTile();
            this.btnSettings = new MetroFramework.Controls.MetroTile();
            this.btnDel = new MetroFramework.Controls.MetroTile();
            this.btnReturns = new MetroFramework.Controls.MetroTile();
            this.btnCompany = new MetroFramework.Controls.MetroTile();
            this.btnBid = new MetroFramework.Controls.MetroTile();
            this.btnInv = new MetroFramework.Controls.MetroTile();
            this.btnSale = new MetroFramework.Controls.MetroTile();
            this.btnPOS = new MetroFramework.Controls.MetroTile();
            this.btnPurchOrderDel = new MetroFramework.Controls.MetroTile();
            this.btnBidPO = new MetroFramework.Controls.MetroTile();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroStyleExtender1 = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPOReturns = new MetroFramework.Controls.MetroTile();
            this.btnDelRet = new MetroFramework.Controls.MetroTile();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(36, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome: ";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(133, 97);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(57, 21);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "label2";
            // 
            // btnProfMan
            // 
            this.btnProfMan.ActiveControl = null;
            this.btnProfMan.BackColor = System.Drawing.Color.Coral;
            this.btnProfMan.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnProfMan.Location = new System.Drawing.Point(40, 163);
            this.btnProfMan.Name = "btnProfMan";
            this.btnProfMan.Size = new System.Drawing.Size(168, 155);
            this.btnProfMan.TabIndex = 2;
            this.btnProfMan.Text = "Profile Management";
            this.btnProfMan.TileImage = ((System.Drawing.Image)(resources.GetObject("btnProfMan.TileImage")));
            this.btnProfMan.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnProfMan.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.btnProfMan.UseCustomBackColor = true;
            this.btnProfMan.UseCustomForeColor = true;
            this.btnProfMan.UseSelectable = true;
            this.btnProfMan.UseTileImage = true;
            this.btnProfMan.Click += new System.EventHandler(this.btnProfMan_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.ActiveControl = null;
            this.btnSettings.BackColor = System.Drawing.Color.Coral;
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Location = new System.Drawing.Point(214, 163);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(168, 72);
            this.btnSettings.TabIndex = 2;
            this.btnSettings.Text = "Settings";
            this.btnSettings.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.btnSettings.UseCustomBackColor = true;
            this.btnSettings.UseCustomForeColor = true;
            this.btnSettings.UseSelectable = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnDel
            // 
            this.btnDel.ActiveControl = null;
            this.btnDel.BackColor = System.Drawing.Color.Coral;
            this.btnDel.ForeColor = System.Drawing.Color.White;
            this.btnDel.Location = new System.Drawing.Point(736, 324);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(168, 77);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "Delivery";
            this.btnDel.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.btnDel.UseCustomBackColor = true;
            this.btnDel.UseCustomForeColor = true;
            this.btnDel.UseSelectable = true;
            this.btnDel.Click += new System.EventHandler(this.metroTile6_Click);
            // 
            // btnReturns
            // 
            this.btnReturns.ActiveControl = null;
            this.btnReturns.BackColor = System.Drawing.Color.Coral;
            this.btnReturns.ForeColor = System.Drawing.Color.White;
            this.btnReturns.Location = new System.Drawing.Point(736, 407);
            this.btnReturns.Name = "btnReturns";
            this.btnReturns.Size = new System.Drawing.Size(168, 72);
            this.btnReturns.TabIndex = 2;
            this.btnReturns.Text = "Returns";
            this.btnReturns.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.btnReturns.UseCustomBackColor = true;
            this.btnReturns.UseCustomForeColor = true;
            this.btnReturns.UseSelectable = true;
            this.btnReturns.Click += new System.EventHandler(this.metroTile7_Click);
            // 
            // btnCompany
            // 
            this.btnCompany.ActiveControl = null;
            this.btnCompany.BackColor = System.Drawing.Color.Coral;
            this.btnCompany.ForeColor = System.Drawing.Color.White;
            this.btnCompany.Location = new System.Drawing.Point(40, 324);
            this.btnCompany.Name = "btnCompany";
            this.btnCompany.Size = new System.Drawing.Size(168, 155);
            this.btnCompany.TabIndex = 2;
            this.btnCompany.Text = "Company";
            this.btnCompany.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.btnCompany.UseCustomBackColor = true;
            this.btnCompany.UseCustomForeColor = true;
            this.btnCompany.UseSelectable = true;
            this.btnCompany.Click += new System.EventHandler(this.btnCompany_Click);
            // 
            // btnBid
            // 
            this.btnBid.ActiveControl = null;
            this.btnBid.BackColor = System.Drawing.Color.Coral;
            this.btnBid.ForeColor = System.Drawing.Color.White;
            this.btnBid.Location = new System.Drawing.Point(214, 241);
            this.btnBid.Name = "btnBid";
            this.btnBid.Size = new System.Drawing.Size(168, 77);
            this.btnBid.TabIndex = 2;
            this.btnBid.Text = "Bids";
            this.btnBid.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.btnBid.UseCustomBackColor = true;
            this.btnBid.UseCustomForeColor = true;
            this.btnBid.UseSelectable = true;
            this.btnBid.Click += new System.EventHandler(this.btnBid_Click);
            // 
            // btnInv
            // 
            this.btnInv.ActiveControl = null;
            this.btnInv.BackColor = System.Drawing.Color.Coral;
            this.btnInv.ForeColor = System.Drawing.Color.White;
            this.btnInv.Location = new System.Drawing.Point(388, 163);
            this.btnInv.Name = "btnInv";
            this.btnInv.Size = new System.Drawing.Size(168, 72);
            this.btnInv.TabIndex = 2;
            this.btnInv.Text = "Inventory";
            this.btnInv.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.btnInv.UseCustomBackColor = true;
            this.btnInv.UseCustomForeColor = true;
            this.btnInv.UseSelectable = true;
            this.btnInv.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // btnSale
            // 
            this.btnSale.ActiveControl = null;
            this.btnSale.BackColor = System.Drawing.Color.Coral;
            this.btnSale.ForeColor = System.Drawing.Color.White;
            this.btnSale.Location = new System.Drawing.Point(736, 163);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(168, 155);
            this.btnSale.TabIndex = 2;
            this.btnSale.Text = "Sales";
            this.btnSale.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.btnSale.UseCustomBackColor = true;
            this.btnSale.UseCustomForeColor = true;
            this.btnSale.UseSelectable = true;
            this.btnSale.Click += new System.EventHandler(this.btnSale_Click);
            // 
            // btnPOS
            // 
            this.btnPOS.ActiveControl = null;
            this.btnPOS.BackColor = System.Drawing.Color.Coral;
            this.btnPOS.ForeColor = System.Drawing.Color.White;
            this.btnPOS.Location = new System.Drawing.Point(562, 324);
            this.btnPOS.Name = "btnPOS";
            this.btnPOS.Size = new System.Drawing.Size(168, 155);
            this.btnPOS.TabIndex = 2;
            this.btnPOS.Text = "POS";
            this.btnPOS.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.btnPOS.UseCustomBackColor = true;
            this.btnPOS.UseCustomForeColor = true;
            this.btnPOS.UseSelectable = true;
            this.btnPOS.Click += new System.EventHandler(this.btnPOS_Click);
            // 
            // btnPurchOrderDel
            // 
            this.btnPurchOrderDel.ActiveControl = null;
            this.btnPurchOrderDel.BackColor = System.Drawing.Color.Coral;
            this.btnPurchOrderDel.ForeColor = System.Drawing.Color.White;
            this.btnPurchOrderDel.Location = new System.Drawing.Point(214, 407);
            this.btnPurchOrderDel.Name = "btnPurchOrderDel";
            this.btnPurchOrderDel.Size = new System.Drawing.Size(342, 72);
            this.btnPurchOrderDel.TabIndex = 2;
            this.btnPurchOrderDel.Text = "Purchase Order Delivery";
            this.btnPurchOrderDel.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.btnPurchOrderDel.UseCustomBackColor = true;
            this.btnPurchOrderDel.UseCustomForeColor = true;
            this.btnPurchOrderDel.UseSelectable = true;
            this.btnPurchOrderDel.Click += new System.EventHandler(this.btnPurchOrderDel_Click);
            // 
            // btnBidPO
            // 
            this.btnBidPO.ActiveControl = null;
            this.btnBidPO.BackColor = System.Drawing.Color.Coral;
            this.btnBidPO.ForeColor = System.Drawing.Color.White;
            this.btnBidPO.Location = new System.Drawing.Point(214, 324);
            this.btnBidPO.Name = "btnBidPO";
            this.btnBidPO.Size = new System.Drawing.Size(342, 77);
            this.btnBidPO.TabIndex = 2;
            this.btnBidPO.Text = "Bidding Purchase Order";
            this.btnBidPO.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.btnBidPO.UseCustomBackColor = true;
            this.btnBidPO.UseCustomForeColor = true;
            this.btnBidPO.UseSelectable = true;
            this.btnBidPO.Click += new System.EventHandler(this.btnBidPO_Click);
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            this.metroStyleManager1.Style = MetroFramework.MetroColorStyle.Red;
            this.metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroStyleExtender1
            // 
            this.metroStyleExtender1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(862, 109);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Location = new System.Drawing.Point(787, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Log out";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnPOReturns
            // 
            this.btnPOReturns.ActiveControl = null;
            this.btnPOReturns.BackColor = System.Drawing.Color.Coral;
            this.btnPOReturns.ForeColor = System.Drawing.Color.White;
            this.btnPOReturns.Location = new System.Drawing.Point(388, 241);
            this.btnPOReturns.Name = "btnPOReturns";
            this.btnPOReturns.Size = new System.Drawing.Size(168, 77);
            this.btnPOReturns.TabIndex = 2;
            this.btnPOReturns.Text = "Bidding PO Returns";
            this.btnPOReturns.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.btnPOReturns.UseCustomBackColor = true;
            this.btnPOReturns.UseCustomForeColor = true;
            this.btnPOReturns.UseSelectable = true;
            this.btnPOReturns.Click += new System.EventHandler(this.btnPOReturns_Click);
            // 
            // btnDelRet
            // 
            this.btnDelRet.ActiveControl = null;
            this.btnDelRet.BackColor = System.Drawing.Color.Coral;
            this.btnDelRet.ForeColor = System.Drawing.Color.White;
            this.btnDelRet.Location = new System.Drawing.Point(562, 163);
            this.btnDelRet.Name = "btnDelRet";
            this.btnDelRet.Size = new System.Drawing.Size(168, 155);
            this.btnDelRet.TabIndex = 2;
            this.btnDelRet.Text = "Delivery Returns";
            this.btnDelRet.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.btnDelRet.UseCustomBackColor = true;
            this.btnDelRet.UseCustomForeColor = true;
            this.btnDelRet.UseSelectable = true;
            this.btnDelRet.Click += new System.EventHandler(this.btnDelRet_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 529);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnReturns);
            this.Controls.Add(this.btnPOS);
            this.Controls.Add(this.btnBidPO);
            this.Controls.Add(this.btnPurchOrderDel);
            this.Controls.Add(this.btnDelRet);
            this.Controls.Add(this.btnSale);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnPOReturns);
            this.Controls.Add(this.btnInv);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnBid);
            this.Controls.Add(this.btnCompany);
            this.Controls.Add(this.btnProfMan);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Dashboard";
            this.Padding = new System.Windows.Forms.Padding(33, 97, 33, 32);
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = " ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dashboard_FormClosing);
            this.Load += new System.EventHandler(this.Dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblName;
        private MetroFramework.Controls.MetroTile btnProfMan;
        private MetroFramework.Controls.MetroTile btnSettings;
        private MetroFramework.Controls.MetroTile btnDel;
        private MetroFramework.Controls.MetroTile btnReturns;
        private MetroFramework.Controls.MetroTile btnCompany;
        private MetroFramework.Controls.MetroTile btnBid;
        private MetroFramework.Controls.MetroTile btnInv;
        private MetroFramework.Controls.MetroTile btnSale;
        private MetroFramework.Controls.MetroTile btnPOS;
        private MetroFramework.Controls.MetroTile btnPurchOrderDel;
        private MetroFramework.Controls.MetroTile btnBidPO;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        public MetroFramework.Components.MetroStyleExtender metroStyleExtender1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroTile btnPOReturns;
        private MetroFramework.Controls.MetroTile btnDelRet;
    }
}