namespace K5GLONLINE
{
    partial class frmEditVoucherCS
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTDate = new System.Windows.Forms.MaskedTextBox();
            this.txtreference = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboControlNo = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtdrtot = new System.Windows.Forms.TextBox();
            this.txtcrtot = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDocNum = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cboPC = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgv1 = new K5GLONLINE.moveNextCellDataGridView();
            this.cboPA = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.txtrefer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbAccountNo = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 19);
            this.label2.TabIndex = 31;
            this.label2.Text = "Date:";
            // 
            // txtTDate
            // 
            this.txtTDate.Enabled = false;
            this.txtTDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTDate.Location = new System.Drawing.Point(26, 109);
            this.txtTDate.Mask = "00/00/0000";
            this.txtTDate.Name = "txtTDate";
            this.txtTDate.Size = new System.Drawing.Size(191, 26);
            this.txtTDate.TabIndex = 1;
            this.txtTDate.ValidatingType = typeof(System.DateTime);
            this.txtTDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDate_KeyDown);
            this.txtTDate.Leave += new System.EventHandler(this.txtTDate_Leave);
            // 
            // txtreference
            // 
            this.txtreference.Enabled = false;
            this.txtreference.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreference.Location = new System.Drawing.Point(26, 167);
            this.txtreference.Name = "txtreference";
            this.txtreference.Size = new System.Drawing.Size(191, 26);
            this.txtreference.TabIndex = 2;
            this.txtreference.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtreference_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 19);
            this.label1.TabIndex = 33;
            this.label1.Text = "Reference:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(277, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 19);
            this.label3.TabIndex = 35;
            this.label3.Text = "Name:";
            // 
            // cboControlNo
            // 
            this.cboControlNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboControlNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboControlNo.Enabled = false;
            this.cboControlNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboControlNo.FormattingEnabled = true;
            this.cboControlNo.Location = new System.Drawing.Point(281, 51);
            this.cboControlNo.Name = "cboControlNo";
            this.cboControlNo.Size = new System.Drawing.Size(726, 27);
            this.cboControlNo.TabIndex = 3;
            this.cboControlNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboControlNo_KeyDown);
            this.cboControlNo.Validating += new System.ComponentModel.CancelEventHandler(this.cboControlNo_Validating);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(277, 145);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 19);
            this.label11.TabIndex = 40;
            this.label11.Text = "Remarks:";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Enabled = false;
            this.txtRemarks.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(281, 167);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(726, 26);
            this.txtRemarks.TabIndex = 5;
            this.txtRemarks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRemarks_KeyDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(233, 528);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 13);
            this.label13.TabIndex = 51;
            this.label13.Text = "Total Credit:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(23, 528);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 13);
            this.label12.TabIndex = 50;
            this.label12.Text = "Total Debit:";
            // 
            // txtdrtot
            // 
            this.txtdrtot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdrtot.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtdrtot.Location = new System.Drawing.Point(99, 525);
            this.txtdrtot.Name = "txtdrtot";
            this.txtdrtot.ReadOnly = true;
            this.txtdrtot.Size = new System.Drawing.Size(108, 20);
            this.txtdrtot.TabIndex = 49;
            this.txtdrtot.Text = "0.00";
            this.txtdrtot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtcrtot
            // 
            this.txtcrtot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcrtot.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtcrtot.Location = new System.Drawing.Point(312, 525);
            this.txtcrtot.Name = "txtcrtot";
            this.txtcrtot.ReadOnly = true;
            this.txtcrtot.Size = new System.Drawing.Size(108, 20);
            this.txtcrtot.TabIndex = 48;
            this.txtcrtot.Text = "0.00";
            this.txtcrtot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(932, 526);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(851, 526);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDocNum
            // 
            this.txtDocNum.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocNum.Location = new System.Drawing.Point(922, 12);
            this.txtDocNum.Name = "txtDocNum";
            this.txtDocNum.ReadOnly = true;
            this.txtDocNum.Size = new System.Drawing.Size(85, 26);
            this.txtDocNum.TabIndex = 52;
            this.txtDocNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 19);
            this.label6.TabIndex = 74;
            this.label6.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(26, 51);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(191, 26);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.Validating += new System.ComponentModel.CancelEventHandler(this.txtSearch_Validating);
            // 
            // cboPC
            // 
            this.cboPC.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboPC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPC.Enabled = false;
            this.cboPC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPC.FormattingEnabled = true;
            this.cboPC.Location = new System.Drawing.Point(281, 109);
            this.cboPC.Name = "cboPC";
            this.cboPC.Size = new System.Drawing.Size(726, 27);
            this.cboPC.TabIndex = 75;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(277, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 19);
            this.label4.TabIndex = 76;
            this.label4.Text = "Salesman:";
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cboPA,
            this.txtrefer,
            this.txtDR,
            this.txtCR});
            this.dgv1.Location = new System.Drawing.Point(26, 199);
            this.dgv1.Name = "dgv1";
            this.dgv1.Size = new System.Drawing.Size(981, 310);
            this.dgv1.TabIndex = 6;
            this.dgv1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellEndEdit);
            this.dgv1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgv1_CellValidating);
            this.dgv1.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgv1_CurrentCellDirtyStateChanged);
            this.dgv1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv1_EditingControlShowing);
            this.dgv1.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv1_RowValidating);
            this.dgv1.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgv1_UserDeletedRow);
            // 
            // cboPA
            // 
            this.cboPA.HeaderText = "Account Title";
            this.cboPA.Name = "cboPA";
            this.cboPA.Width = 425;
            // 
            // txtrefer
            // 
            this.txtrefer.HeaderText = "Reference";
            this.txtrefer.Name = "txtrefer";
            this.txtrefer.Width = 150;
            // 
            // txtDR
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.txtDR.DefaultCellStyle = dataGridViewCellStyle1;
            this.txtDR.HeaderText = "Debit";
            this.txtDR.Name = "txtDR";
            this.txtDR.Width = 150;
            // 
            // txtCR
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.txtCR.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtCR.HeaderText = "Credit";
            this.txtCR.Name = "txtCR";
            this.txtCR.Width = 150;
            // 
            // cbAccountNo
            // 
            this.cbAccountNo.AutoSize = true;
            this.cbAccountNo.Checked = true;
            this.cbAccountNo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAccountNo.Location = new System.Drawing.Point(26, 573);
            this.cbAccountNo.Name = "cbAccountNo";
            this.cbAccountNo.Size = new System.Drawing.Size(106, 17);
            this.cbAccountNo.TabIndex = 141;
            this.cbAccountNo.Text = "Account Number";
            this.cbAccountNo.UseVisualStyleBackColor = true;
            // 
            // frmEditVoucherCS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 602);
            this.Controls.Add(this.cbAccountNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboPC);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.txtDocNum);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtdrtot);
            this.Controls.Add(this.txtcrtot);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboControlNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtreference);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTDate);
            this.Name = "frmEditVoucherCS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search - Cash Sales";
            this.Load += new System.EventHandler(this.frmVoucherJV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtTDate;
        private System.Windows.Forms.TextBox txtreference;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboControlNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRemarks;
        private moveNextCellDataGridView dgv1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtdrtot;
        private System.Windows.Forms.TextBox txtcrtot;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDocNum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cboPC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewComboBoxColumn cboPA;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtrefer;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDR;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCR;
        private System.Windows.Forms.CheckBox cbAccountNo;
    }
}