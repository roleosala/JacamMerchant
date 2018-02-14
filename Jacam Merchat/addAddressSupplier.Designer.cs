namespace Jacam_Merchat
{
    partial class addAddressSupplier
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
            this.lblId = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.btnDelivery = new MetroFramework.Controls.MetroTile();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAdd = new System.Windows.Forms.TextBox();
            this.lblpo_bid_id = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(36, 211);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(120, 21);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "po_bid_line_id";
            // 
            // date
            // 
            this.date.Location = new System.Drawing.Point(36, 100);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(325, 27);
            this.date.TabIndex = 1;
            // 
            // btnDelivery
            // 
            this.btnDelivery.ActiveControl = null;
            this.btnDelivery.Location = new System.Drawing.Point(277, 191);
            this.btnDelivery.Name = "btnDelivery";
            this.btnDelivery.Size = new System.Drawing.Size(84, 41);
            this.btnDelivery.TabIndex = 2;
            this.btnDelivery.Text = "Set";
            this.btnDelivery.UseSelectable = true;
            this.btnDelivery.Click += new System.EventHandler(this.btnDelivery_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Address:";
            // 
            // txtAdd
            // 
            this.txtAdd.Location = new System.Drawing.Point(40, 158);
            this.txtAdd.Name = "txtAdd";
            this.txtAdd.Size = new System.Drawing.Size(321, 27);
            this.txtAdd.TabIndex = 4;
            // 
            // lblpo_bid_id
            // 
            this.lblpo_bid_id.AutoSize = true;
            this.lblpo_bid_id.Location = new System.Drawing.Point(36, 232);
            this.lblpo_bid_id.Name = "lblpo_bid_id";
            this.lblpo_bid_id.Size = new System.Drawing.Size(86, 21);
            this.lblpo_bid_id.TabIndex = 0;
            this.lblpo_bid_id.Text = "po_bid_id";
            // 
            // addAddressSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 270);
            this.Controls.Add(this.txtAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDelivery);
            this.Controls.Add(this.date);
            this.Controls.Add(this.lblpo_bid_id);
            this.Controls.Add(this.lblId);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "addAddressSupplier";
            this.Padding = new System.Windows.Forms.Padding(33, 97, 33, 32);
            this.Text = "Set Delivery Date";
            this.Load += new System.EventHandler(this.addAddressSupplier_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.DateTimePicker date;
        private MetroFramework.Controls.MetroTile btnDelivery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAdd;
        private System.Windows.Forms.Label lblpo_bid_id;
    }
}