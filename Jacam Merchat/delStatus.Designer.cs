﻿namespace Jacam_Merchat
{
    partial class delStatus
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.lblClient = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbldr = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblStat = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAdd = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPC = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblOrder = new System.Windows.Forms.Label();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDelBy = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnUpd = new MetroFramework.Controls.MetroTile();
            this.lblOrder_id = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblDelDate = new System.Windows.Forms.Label();
            this.btnUp = new MetroFramework.Controls.MetroTile();
            this.lbl_Del_id = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblDateRec = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Client:";
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(102, 134);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(103, 21);
            this.lblClient.TabIndex = 1;
            this.lblClient.Text = "client name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Delivery Receipt:";
            // 
            // lbldr
            // 
            this.lbldr.AutoSize = true;
            this.lbldr.Location = new System.Drawing.Point(182, 97);
            this.lbldr.Name = "lbldr";
            this.lbldr.Size = new System.Drawing.Size(58, 21);
            this.lbldr.TabIndex = 1;
            this.lbldr.Text = "ref no.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(427, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Status:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblStat
            // 
            this.lblStat.AutoSize = true;
            this.lblStat.Location = new System.Drawing.Point(496, 204);
            this.lblStat.Name = "lblStat";
            this.lblStat.Size = new System.Drawing.Size(85, 21);
            this.lblStat.TabIndex = 3;
            this.lblStat.Text = "del status";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "Address:";
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.Location = new System.Drawing.Point(118, 169);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(147, 21);
            this.lblAdd.TabIndex = 5;
            this.lblAdd.Text = "basta Address na";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 21);
            this.label6.TabIndex = 6;
            this.label6.Text = "Postal Code:";
            // 
            // lblPC
            // 
            this.lblPC.AutoSize = true;
            this.lblPC.Location = new System.Drawing.Point(151, 204);
            this.lblPC.Name = "lblPC";
            this.lblPC.Size = new System.Drawing.Size(85, 21);
            this.lblPC.TabIndex = 7;
            this.lblPC.Text = "postal nni";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(427, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 21);
            this.label5.TabIndex = 8;
            this.label5.Text = "Reference No:";
            // 
            // lblOrder
            // 
            this.lblOrder.AutoSize = true;
            this.lblOrder.Location = new System.Drawing.Point(561, 97);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(95, 21);
            this.lblOrder.TabIndex = 9;
            this.lblOrder.Text = "sales receit";
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItems.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvItems.GridColor = System.Drawing.Color.Black;
            this.dgvItems.Location = new System.Drawing.Point(36, 326);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(739, 240);
            this.dgvItems.TabIndex = 10;
            this.dgvItems.SelectionChanged += new System.EventHandler(this.dgvItems_SelectionChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 244);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 21);
            this.label7.TabIndex = 11;
            this.label7.Text = "Delivered By:";
            // 
            // lblDelBy
            // 
            this.lblDelBy.AutoSize = true;
            this.lblDelBy.Location = new System.Drawing.Point(151, 244);
            this.lblDelBy.Name = "lblDelBy";
            this.lblDelBy.Size = new System.Drawing.Size(148, 21);
            this.lblDelBy.TabIndex = 12;
            this.lblDelBy.Text = "kinsay nag deliver";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 302);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(142, 21);
            this.label8.TabIndex = 13;
            this.label8.Text = "Items on Delivery";
            // 
            // btnUpd
            // 
            this.btnUpd.ActiveControl = null;
            this.btnUpd.Location = new System.Drawing.Point(659, 775);
            this.btnUpd.Name = "btnUpd";
            this.btnUpd.Size = new System.Drawing.Size(120, 38);
            this.btnUpd.TabIndex = 14;
            this.btnUpd.Text = "Update Status";
            this.btnUpd.UseSelectable = true;
            // 
            // lblOrder_id
            // 
            this.lblOrder_id.AutoSize = true;
            this.lblOrder_id.Location = new System.Drawing.Point(36, 58);
            this.lblOrder_id.Name = "lblOrder_id";
            this.lblOrder_id.Size = new System.Drawing.Size(73, 21);
            this.lblOrder_id.TabIndex = 15;
            this.lblOrder_id.Text = "order_id";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(427, 134);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(138, 21);
            this.label9.TabIndex = 16;
            this.label9.Text = "Date of Delivery:";
            // 
            // lblDelDate
            // 
            this.lblDelDate.AutoSize = true;
            this.lblDelDate.Location = new System.Drawing.Point(571, 134);
            this.lblDelDate.Name = "lblDelDate";
            this.lblDelDate.Size = new System.Drawing.Size(66, 21);
            this.lblDelDate.TabIndex = 17;
            this.lblDelDate.Text = "label10";
            // 
            // btnUp
            // 
            this.btnUp.ActiveControl = null;
            this.btnUp.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnUp.ForeColor = System.Drawing.Color.White;
            this.btnUp.Location = new System.Drawing.Point(644, 572);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(131, 47);
            this.btnUp.TabIndex = 18;
            this.btnUp.Text = "Update Status";
            this.btnUp.UseCustomBackColor = true;
            this.btnUp.UseCustomForeColor = true;
            this.btnUp.UseSelectable = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // lbl_Del_id
            // 
            this.lbl_Del_id.AutoSize = true;
            this.lbl_Del_id.Location = new System.Drawing.Point(427, 58);
            this.lbl_Del_id.Name = "lbl_Del_id";
            this.lbl_Del_id.Size = new System.Drawing.Size(56, 21);
            this.lbl_Del_id.TabIndex = 15;
            this.lbl_Del_id.Text = "del_id";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(427, 169);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(153, 21);
            this.label10.TabIndex = 16;
            this.label10.Text = "Delivery Received:";
            // 
            // lblDateRec
            // 
            this.lblDateRec.AutoSize = true;
            this.lblDateRec.Location = new System.Drawing.Point(586, 169);
            this.lblDateRec.Name = "lblDateRec";
            this.lblDateRec.Size = new System.Drawing.Size(42, 21);
            this.lblDateRec.TabIndex = 17;
            this.lblDateRec.Text = "N/A";
            // 
            // delStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 654);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.lblDateRec);
            this.Controls.Add(this.lblDelDate);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbl_Del_id);
            this.Controls.Add(this.lblOrder_id);
            this.Controls.Add(this.btnUpd);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblDelBy);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.lblOrder);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblPC);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblAdd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblStat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbldr);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "delStatus";
            this.Padding = new System.Windows.Forms.Padding(33, 97, 33, 32);
            this.Text = "Delivery Status";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.delStatus_FormClosing);
            this.Load += new System.EventHandler(this.delStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbldr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblStat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblAdd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblOrder;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDelBy;
        private System.Windows.Forms.Label label8;
        private MetroFramework.Controls.MetroTile btnUpd;
        private System.Windows.Forms.Label lblOrder_id;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblDelDate;
        private MetroFramework.Controls.MetroTile btnUp;
        private System.Windows.Forms.Label lbl_Del_id;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblDateRec;
    }
}