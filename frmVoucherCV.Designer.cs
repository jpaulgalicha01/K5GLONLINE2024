﻿namespace K5GLONLINE
{
    partial class frmVoucherCV
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTDate = new System.Windows.Forms.MaskedTextBox();
            this.txtreference = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboControlNo = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDocNum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCAmount = new System.Windows.Forms.TextBox();
            this.txtCheckNo = new System.Windows.Forms.TextBox();
            this.cbSP = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtdrtot = new System.Windows.Forms.TextBox();
            this.txtcrtot = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDifference = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboPC = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtVDate = new System.Windows.Forms.MaskedTextBox();
            this.btnActGroup = new System.Windows.Forms.Button();
            this.dgv1 = new K5GLONLINE.moveNextCellDataGridView();
            this.cboPA = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtrefer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtActRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbdgvSIT = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnVAT = new System.Windows.Forms.Button();
            this.cbAccountNo = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 19);
            this.label2.TabIndex = 31;
            this.label2.Text = "Date:";
            // 
            // txtTDate
            // 
            this.txtTDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTDate.Location = new System.Drawing.Point(26, 52);
            this.txtTDate.Mask = "00/00/0000";
            this.txtTDate.Name = "txtTDate";
            this.txtTDate.Size = new System.Drawing.Size(134, 26);
            this.txtTDate.TabIndex = 0;
            this.txtTDate.ValidatingType = typeof(System.DateTime);
            this.txtTDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfiledenter);
            this.txtTDate.Leave += new System.EventHandler(this.txtTDate_Leave);
            // 
            // txtreference
            // 
            this.txtreference.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreference.Location = new System.Drawing.Point(26, 111);
            this.txtreference.Name = "txtreference";
            this.txtreference.Size = new System.Drawing.Size(286, 26);
            this.txtreference.TabIndex = 2;
            this.txtreference.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfiledenter);
            this.txtreference.Validating += new System.ComponentModel.CancelEventHandler(this.txtreference_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 19);
            this.label1.TabIndex = 33;
            this.label1.Text = "Reference:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(370, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 19);
            this.label3.TabIndex = 35;
            this.label3.Text = "Name:";
            // 
            // cboControlNo
            // 
            this.cboControlNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboControlNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboControlNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboControlNo.FormattingEnabled = true;
            this.cboControlNo.Location = new System.Drawing.Point(374, 51);
            this.cboControlNo.Name = "cboControlNo";
            this.cboControlNo.Size = new System.Drawing.Size(607, 27);
            this.cboControlNo.TabIndex = 5;
            this.cboControlNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfiledenter);
            this.cboControlNo.Validating += new System.ComponentModel.CancelEventHandler(this.cboControlNo_Validating);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(370, 148);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 19);
            this.label11.TabIndex = 40;
            this.label11.Text = "Remarks:";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(374, 170);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(607, 26);
            this.txtRemarks.TabIndex = 7;
            this.txtRemarks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfiledenter);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(906, 554);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(825, 554);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDocNum
            // 
            this.txtDocNum.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocNum.Location = new System.Drawing.Point(896, 12);
            this.txtDocNum.Name = "txtDocNum";
            this.txtDocNum.ReadOnly = true;
            this.txtDocNum.Size = new System.Drawing.Size(85, 26);
            this.txtDocNum.TabIndex = 52;
            this.txtDocNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(174, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 19);
            this.label5.TabIndex = 56;
            this.label5.Text = "Amount:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 19);
            this.label4.TabIndex = 55;
            this.label4.Text = "Check No.:";
            // 
            // txtCAmount
            // 
            this.txtCAmount.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCAmount.Location = new System.Drawing.Point(178, 170);
            this.txtCAmount.Name = "txtCAmount";
            this.txtCAmount.Size = new System.Drawing.Size(134, 26);
            this.txtCAmount.TabIndex = 4;
            this.txtCAmount.Text = "0.00";
            this.txtCAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfiledenter);
            this.txtCAmount.Validating += new System.ComponentModel.CancelEventHandler(this.txtCAmount_Validating);
            // 
            // txtCheckNo
            // 
            this.txtCheckNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckNo.Location = new System.Drawing.Point(26, 170);
            this.txtCheckNo.Name = "txtCheckNo";
            this.txtCheckNo.Size = new System.Drawing.Size(134, 26);
            this.txtCheckNo.TabIndex = 3;
            this.txtCheckNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfiledenter);
            // 
            // cbSP
            // 
            this.cbSP.AutoSize = true;
            this.cbSP.Location = new System.Drawing.Point(26, 564);
            this.cbSP.Name = "cbSP";
            this.cbSP.Size = new System.Drawing.Size(102, 17);
            this.cbSP.TabIndex = 57;
            this.cbSP.Text = "Save and Print?";
            this.cbSP.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(235, 518);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 13);
            this.label13.TabIndex = 103;
            this.label13.Text = "Total Credit:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(25, 518);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 13);
            this.label12.TabIndex = 102;
            this.label12.Text = "Total Debit:";
            // 
            // txtdrtot
            // 
            this.txtdrtot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdrtot.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtdrtot.Location = new System.Drawing.Point(101, 515);
            this.txtdrtot.Name = "txtdrtot";
            this.txtdrtot.ReadOnly = true;
            this.txtdrtot.Size = new System.Drawing.Size(108, 20);
            this.txtdrtot.TabIndex = 101;
            this.txtdrtot.Text = "0.00";
            this.txtdrtot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtcrtot
            // 
            this.txtcrtot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcrtot.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtcrtot.Location = new System.Drawing.Point(314, 515);
            this.txtcrtot.Name = "txtcrtot";
            this.txtcrtot.ReadOnly = true;
            this.txtcrtot.Size = new System.Drawing.Size(108, 20);
            this.txtcrtot.TabIndex = 100;
            this.txtcrtot.Text = "0.00";
            this.txtcrtot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(842, 522);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 99;
            this.label6.Text = "Difference";
            // 
            // txtDifference
            // 
            this.txtDifference.Location = new System.Drawing.Point(904, 515);
            this.txtDifference.Name = "txtDifference";
            this.txtDifference.Size = new System.Drawing.Size(77, 20);
            this.txtDifference.TabIndex = 98;
            this.txtDifference.Text = "0.00";
            this.txtDifference.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(370, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 19);
            this.label10.TabIndex = 123;
            this.label10.Text = "Salesman";
            // 
            // cboPC
            // 
            this.cboPC.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboPC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPC.FormattingEnabled = true;
            this.cboPC.Location = new System.Drawing.Point(374, 110);
            this.cboPC.Name = "cboPC";
            this.cboPC.Size = new System.Drawing.Size(607, 27);
            this.cboPC.TabIndex = 6;
            this.cboPC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfiledenter);
            this.cboPC.Validating += new System.ComponentModel.CancelEventHandler(this.cboPC_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(174, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 19);
            this.label9.TabIndex = 133;
            this.label9.Text = "Value Date:";
            // 
            // txtVDate
            // 
            this.txtVDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVDate.Location = new System.Drawing.Point(178, 52);
            this.txtVDate.Mask = "00/00/0000";
            this.txtVDate.Name = "txtVDate";
            this.txtVDate.Size = new System.Drawing.Size(134, 26);
            this.txtVDate.TabIndex = 1;
            this.txtVDate.ValidatingType = typeof(System.DateTime);
            this.txtVDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfiledenter);
            // 
            // btnActGroup
            // 
            this.btnActGroup.Location = new System.Drawing.Point(205, 554);
            this.btnActGroup.Name = "btnActGroup";
            this.btnActGroup.Size = new System.Drawing.Size(121, 23);
            this.btnActGroup.TabIndex = 135;
            this.btnActGroup.Text = "Balance - Account Title";
            this.btnActGroup.UseVisualStyleBackColor = true;
            this.btnActGroup.Click += new System.EventHandler(this.btnActGroup_Click);
            // 
            // dgv1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cboPA,
            this.ColumnAT,
            this.txtrefer,
            this.txtActRemarks,
            this.txtDR,
            this.txtCR,
            this.cbdgvSIT});
            this.dgv1.Location = new System.Drawing.Point(26, 213);
            this.dgv1.Name = "dgv1";
            this.dgv1.Size = new System.Drawing.Size(956, 296);
            this.dgv1.TabIndex = 9;
            this.dgv1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellEndEdit);
            this.dgv1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgv1_CellValidating);
            this.dgv1.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgv1_CurrentCellDirtyStateChanged);
            this.dgv1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv1_EditingControlShowing);
            this.dgv1.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgv1_UserDeletedRow);
            // 
            // cboPA
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPA.DefaultCellStyle = dataGridViewCellStyle2;
            this.cboPA.HeaderText = "Account Title";
            this.cboPA.Name = "cboPA";
            this.cboPA.Width = 120;
            // 
            // ColumnAT
            // 
            this.ColumnAT.HeaderText = "Account Title";
            this.ColumnAT.Name = "ColumnAT";
            this.ColumnAT.Width = 300;
            // 
            // txtrefer
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrefer.DefaultCellStyle = dataGridViewCellStyle3;
            this.txtrefer.HeaderText = "Reference";
            this.txtrefer.Name = "txtrefer";
            // 
            // txtActRemarks
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActRemarks.DefaultCellStyle = dataGridViewCellStyle4;
            this.txtActRemarks.HeaderText = "Remarks";
            this.txtActRemarks.Name = "txtActRemarks";
            this.txtActRemarks.Width = 140;
            // 
            // txtDR
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDR.DefaultCellStyle = dataGridViewCellStyle5;
            this.txtDR.HeaderText = "Debit";
            this.txtDR.Name = "txtDR";
            this.txtDR.Width = 90;
            // 
            // txtCR
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCR.DefaultCellStyle = dataGridViewCellStyle6;
            this.txtCR.HeaderText = "Credit";
            this.txtCR.Name = "txtCR";
            this.txtCR.Width = 90;
            // 
            // cbdgvSIT
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.NullValue = false;
            this.cbdgvSIT.DefaultCellStyle = dataGridViewCellStyle7;
            this.cbdgvSIT.HeaderText = "SIT";
            this.cbdgvSIT.Name = "cbdgvSIT";
            this.cbdgvSIT.Width = 50;
            // 
            // btnVAT
            // 
            this.btnVAT.Location = new System.Drawing.Point(362, 554);
            this.btnVAT.Name = "btnVAT";
            this.btnVAT.Size = new System.Drawing.Size(121, 23);
            this.btnVAT.TabIndex = 138;
            this.btnVAT.Text = "VAT";
            this.btnVAT.UseVisualStyleBackColor = true;
            this.btnVAT.Click += new System.EventHandler(this.btnVAT_Click);
            // 
            // cbAccountNo
            // 
            this.cbAccountNo.AutoSize = true;
            this.cbAccountNo.Checked = true;
            this.cbAccountNo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAccountNo.Location = new System.Drawing.Point(26, 541);
            this.cbAccountNo.Name = "cbAccountNo";
            this.cbAccountNo.Size = new System.Drawing.Size(106, 17);
            this.cbAccountNo.TabIndex = 140;
            this.cbAccountNo.Text = "Account Number";
            this.cbAccountNo.UseVisualStyleBackColor = true;
            this.cbAccountNo.CheckedChanged += new System.EventHandler(this.cbAccountNo_CheckedChanged);
            // 
            // frmVoucherCV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 593);
            this.Controls.Add(this.cbAccountNo);
            this.Controls.Add(this.btnVAT);
            this.Controls.Add(this.btnActGroup);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtVDate);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cboPC);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtdrtot);
            this.Controls.Add(this.txtcrtot);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDifference);
            this.Controls.Add(this.cbSP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCAmount);
            this.Controls.Add(this.txtCheckNo);
            this.Controls.Add(this.txtDocNum);
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
            this.Name = "frmVoucherCV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check Voucher";
            this.Load += new System.EventHandler(this.frmVoucherCV_Load);
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
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDocNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCAmount;
        private System.Windows.Forms.TextBox txtCheckNo;
        private System.Windows.Forms.CheckBox cbSP;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtdrtot;
        private System.Windows.Forms.TextBox txtcrtot;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDifference;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboPC;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox txtVDate;
        private System.Windows.Forms.Button btnActGroup;
        private System.Windows.Forms.Button btnVAT;
        private System.Windows.Forms.CheckBox cbAccountNo;
        private System.Windows.Forms.DataGridViewComboBoxColumn cboPA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtrefer;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtActRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDR;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCR;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cbdgvSIT;
    }
}