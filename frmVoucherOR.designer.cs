namespace K5GLONLINE
{
    partial class frmVoucherOR
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
            this.cbCPay = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtReceiveAmt = new System.Windows.Forms.TextBox();
            this.btnRecord = new System.Windows.Forms.Button();
            this.txtLORRefer = new System.Windows.Forms.TextBox();
            this.txtCDiff = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtVDate = new System.Windows.Forms.MaskedTextBox();
            this.cbAccountNo = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvListReceive = new K5GLONLINE.moveNextCellDataGridView();
            this.ColumnReference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1 = new K5GLONLINE.moveNextCellDataGridView();
            this.cboPA = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtrefer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumncbdgvSIT = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListReceive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 19);
            this.label2.TabIndex = 31;
            this.label2.Text = "Date:";
            // 
            // txtTDate
            // 
            this.txtTDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTDate.Location = new System.Drawing.Point(6, 40);
            this.txtTDate.Mask = "00/00/0000";
            this.txtTDate.Name = "txtTDate";
            this.txtTDate.Size = new System.Drawing.Size(120, 26);
            this.txtTDate.TabIndex = 0;
            this.txtTDate.ValidatingType = typeof(System.DateTime);
            this.txtTDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfiledenter);
            this.txtTDate.Leave += new System.EventHandler(this.txtTDate_Leave);
            // 
            // txtreference
            // 
            this.txtreference.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreference.Location = new System.Drawing.Point(289, 40);
            this.txtreference.Name = "txtreference";
            this.txtreference.Size = new System.Drawing.Size(361, 26);
            this.txtreference.TabIndex = 2;
            this.txtreference.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfiledenter);
            this.txtreference.Validating += new System.ComponentModel.CancelEventHandler(this.txtreference_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(289, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 19);
            this.label1.TabIndex = 33;
            this.label1.Text = "Reference:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 69);
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
            this.cboControlNo.Location = new System.Drawing.Point(6, 91);
            this.cboControlNo.Name = "cboControlNo";
            this.cboControlNo.Size = new System.Drawing.Size(252, 27);
            this.cboControlNo.TabIndex = 3;
            this.cboControlNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfiledenter);
            this.cboControlNo.Validating += new System.ComponentModel.CancelEventHandler(this.cboControlNo_Validating);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(289, 121);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 19);
            this.label11.TabIndex = 40;
            this.label11.Text = "Remarks:";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(289, 143);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(361, 26);
            this.txtRemarks.TabIndex = 7;
            this.txtRemarks.Text = "Collection";
            this.txtRemarks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfiledenter);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Teal;
            this.btnClose.Location = new System.Drawing.Point(572, 649);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(97, 31);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Teal;
            this.btnSave.Location = new System.Drawing.Point(469, 649);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 31);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDocNum
            // 
            this.txtDocNum.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocNum.Location = new System.Drawing.Point(540, 2);
            this.txtDocNum.Name = "txtDocNum";
            this.txtDocNum.ReadOnly = true;
            this.txtDocNum.Size = new System.Drawing.Size(130, 26);
            this.txtDocNum.TabIndex = 0;
            this.txtDocNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(138, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 19);
            this.label5.TabIndex = 56;
            this.label5.Text = "Amount:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 19);
            this.label4.TabIndex = 55;
            this.label4.Text = "Check No.:";
            // 
            // txtCAmount
            // 
            this.txtCAmount.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCAmount.Location = new System.Drawing.Point(138, 143);
            this.txtCAmount.Name = "txtCAmount";
            this.txtCAmount.Size = new System.Drawing.Size(120, 26);
            this.txtCAmount.TabIndex = 6;
            this.txtCAmount.Text = "0.00";
            this.txtCAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfiledenter);
            this.txtCAmount.Validating += new System.ComponentModel.CancelEventHandler(this.txtCAmount_Validating);
            // 
            // txtCheckNo
            // 
            this.txtCheckNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckNo.Location = new System.Drawing.Point(6, 143);
            this.txtCheckNo.Name = "txtCheckNo";
            this.txtCheckNo.Size = new System.Drawing.Size(117, 26);
            this.txtCheckNo.TabIndex = 5;
            this.txtCheckNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfiledenter);
            // 
            // cbSP
            // 
            this.cbSP.AutoSize = true;
            this.cbSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSP.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbSP.Location = new System.Drawing.Point(14, 635);
            this.cbSP.Name = "cbSP";
            this.cbSP.Size = new System.Drawing.Size(160, 28);
            this.cbSP.TabIndex = 57;
            this.cbSP.Text = "Save and Print?";
            this.cbSP.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label13.Location = new System.Drawing.Point(531, 603);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 13);
            this.label13.TabIndex = 103;
            this.label13.Text = "Total Credit:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label12.Location = new System.Drawing.Point(386, 602);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 13);
            this.label12.TabIndex = 102;
            this.label12.Text = "Total Debit:";
            // 
            // txtdrtot
            // 
            this.txtdrtot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdrtot.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtdrtot.Location = new System.Drawing.Point(389, 618);
            this.txtdrtot.Name = "txtdrtot";
            this.txtdrtot.ReadOnly = true;
            this.txtdrtot.Size = new System.Drawing.Size(139, 20);
            this.txtdrtot.TabIndex = 101;
            this.txtdrtot.Text = "0.00";
            this.txtdrtot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtcrtot
            // 
            this.txtcrtot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcrtot.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtcrtot.Location = new System.Drawing.Point(531, 618);
            this.txtcrtot.Name = "txtcrtot";
            this.txtcrtot.ReadOnly = true;
            this.txtcrtot.Size = new System.Drawing.Size(139, 20);
            this.txtcrtot.TabIndex = 100;
            this.txtcrtot.Text = "0.00";
            this.txtcrtot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(228, 644);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 99;
            this.label6.Text = "Difference";
            // 
            // txtDifference
            // 
            this.txtDifference.Location = new System.Drawing.Point(231, 660);
            this.txtDifference.Name = "txtDifference";
            this.txtDifference.ReadOnly = true;
            this.txtDifference.Size = new System.Drawing.Size(77, 20);
            this.txtDifference.TabIndex = 98;
            this.txtDifference.Text = "0.00";
            this.txtDifference.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(289, 69);
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
            this.cboPC.Location = new System.Drawing.Point(289, 91);
            this.cboPC.Name = "cboPC";
            this.cboPC.Size = new System.Drawing.Size(361, 27);
            this.cboPC.TabIndex = 4;
            this.cboPC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfiledenter);
            this.cboPC.Validating += new System.ComponentModel.CancelEventHandler(this.cboPC_Validating);
            // 
            // cbCPay
            // 
            this.cbCPay.AutoSize = true;
            this.cbCPay.BackColor = System.Drawing.Color.Silver;
            this.cbCPay.Checked = true;
            this.cbCPay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCPay.ForeColor = System.Drawing.Color.Blue;
            this.cbCPay.Location = new System.Drawing.Point(6, 179);
            this.cbCPay.Name = "cbCPay";
            this.cbCPay.Size = new System.Drawing.Size(189, 19);
            this.cbCPay.TabIndex = 124;
            this.cbCPay.Text = "Payment Through Check?";
            this.cbCPay.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(289, 142);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 19);
            this.label8.TabIndex = 128;
            this.label8.Text = "Amount:";
            // 
            // txtReceiveAmt
            // 
            this.txtReceiveAmt.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceiveAmt.Location = new System.Drawing.Point(355, 142);
            this.txtReceiveAmt.Name = "txtReceiveAmt";
            this.txtReceiveAmt.Size = new System.Drawing.Size(161, 26);
            this.txtReceiveAmt.TabIndex = 9;
            this.txtReceiveAmt.Text = "0.00";
            this.txtReceiveAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtReceiveAmt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfiledenter);
            this.txtReceiveAmt.Validating += new System.ComponentModel.CancelEventHandler(this.txtReceiveAmt_Validating);
            // 
            // btnRecord
            // 
            this.btnRecord.Location = new System.Drawing.Point(522, 142);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(128, 26);
            this.btnRecord.TabIndex = 10;
            this.btnRecord.Text = "Record";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // txtLORRefer
            // 
            this.txtLORRefer.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLORRefer.Location = new System.Drawing.Point(219, 142);
            this.txtLORRefer.Name = "txtLORRefer";
            this.txtLORRefer.Size = new System.Drawing.Size(57, 26);
            this.txtLORRefer.TabIndex = 129;
            this.txtLORRefer.Visible = false;
            // 
            // txtCDiff
            // 
            this.txtCDiff.Location = new System.Drawing.Point(328, 660);
            this.txtCDiff.Name = "txtCDiff";
            this.txtCDiff.ReadOnly = true;
            this.txtCDiff.Size = new System.Drawing.Size(77, 20);
            this.txtCDiff.TabIndex = 132;
            this.txtCDiff.Text = "0.00";
            this.txtCDiff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label14.Location = new System.Drawing.Point(325, 644);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 13);
            this.label14.TabIndex = 133;
            this.label14.Text = "Cash Difference";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(138, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 19);
            this.label9.TabIndex = 135;
            this.label9.Text = "Value Date:";
            // 
            // txtVDate
            // 
            this.txtVDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVDate.Location = new System.Drawing.Point(138, 40);
            this.txtVDate.Mask = "00/00/0000";
            this.txtVDate.Name = "txtVDate";
            this.txtVDate.Size = new System.Drawing.Size(120, 26);
            this.txtVDate.TabIndex = 1;
            this.txtVDate.ValidatingType = typeof(System.DateTime);
            this.txtVDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfiledenter);
            this.txtVDate.Validating += new System.ComponentModel.CancelEventHandler(this.txtVDate_Validating);
            // 
            // cbAccountNo
            // 
            this.cbAccountNo.AutoSize = true;
            this.cbAccountNo.Checked = true;
            this.cbAccountNo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAccountNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAccountNo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbAccountNo.Location = new System.Drawing.Point(14, 601);
            this.cbAccountNo.Name = "cbAccountNo";
            this.cbAccountNo.Size = new System.Drawing.Size(173, 28);
            this.cbAccountNo.TabIndex = 140;
            this.cbAccountNo.Text = "Account Number";
            this.cbAccountNo.UseVisualStyleBackColor = true;
            this.cbAccountNo.CheckedChanged += new System.EventHandler(this.cbAccountNo_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTDate);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtVDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbCPay);
            this.groupBox1.Controls.Add(this.txtreference);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCheckNo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboControlNo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cboPC);
            this.groupBox1.Controls.Add(this.txtCAmount);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtRemarks);
            this.groupBox1.Location = new System.Drawing.Point(12, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(658, 205);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Entry :";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Controls.Add(this.dgvListReceive);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtReceiveAmt);
            this.groupBox2.Controls.Add(this.txtLORRefer);
            this.groupBox2.Controls.Add(this.btnRecord);
            this.groupBox2.Location = new System.Drawing.Point(12, 245);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(658, 172);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "List of Receivables:";
            // 
            // dgvListReceive
            // 
            this.dgvListReceive.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListReceive.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListReceive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListReceive.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnReference,
            this.ColumnTDate,
            this.ColumnBalance});
            this.dgvListReceive.Location = new System.Drawing.Point(6, 19);
            this.dgvListReceive.Name = "dgvListReceive";
            this.dgvListReceive.Size = new System.Drawing.Size(644, 120);
            this.dgvListReceive.TabIndex = 0;
            this.dgvListReceive.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListReceive_CellEnter);
            // 
            // ColumnReference
            // 
            this.ColumnReference.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnReference.HeaderText = "Reference";
            this.ColumnReference.Name = "ColumnReference";
            // 
            // ColumnTDate
            // 
            this.ColumnTDate.HeaderText = "Date";
            this.ColumnTDate.Name = "ColumnTDate";
            this.ColumnTDate.Width = 150;
            // 
            // ColumnBalance
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnBalance.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnBalance.HeaderText = "Balance";
            this.ColumnBalance.Name = "ColumnBalance";
            this.ColumnBalance.Width = 150;
            // 
            // dgv1
            // 
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cboPA,
            this.ColumnAT,
            this.txtrefer,
            this.txtDR,
            this.txtCR,
            this.ColumncbdgvSIT});
            this.dgv1.Location = new System.Drawing.Point(12, 423);
            this.dgv1.Name = "dgv1";
            this.dgv1.Size = new System.Drawing.Size(658, 172);
            this.dgv1.TabIndex = 2;
            this.dgv1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellEndEdit);
            this.dgv1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgv1_CellValidating);
            this.dgv1.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgv1_CurrentCellDirtyStateChanged);
            this.dgv1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv1_EditingControlShowing);
            this.dgv1.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv1_RowValidating);
            this.dgv1.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgv1_UserDeletedRow);
            // 
            // cboPA
            // 
            this.cboPA.HeaderText = "Account #";
            this.cboPA.Name = "cboPA";
            // 
            // ColumnAT
            // 
            this.ColumnAT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnAT.HeaderText = "Account Title";
            this.ColumnAT.Name = "ColumnAT";
            // 
            // txtrefer
            // 
            this.txtrefer.HeaderText = "Reference";
            this.txtrefer.Name = "txtrefer";
            // 
            // txtDR
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.txtDR.DefaultCellStyle = dataGridViewCellStyle3;
            this.txtDR.HeaderText = "Debit";
            this.txtDR.Name = "txtDR";
            this.txtDR.Width = 90;
            // 
            // txtCR
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.txtCR.DefaultCellStyle = dataGridViewCellStyle4;
            this.txtCR.HeaderText = "Credit";
            this.txtCR.Name = "txtCR";
            this.txtCR.Width = 90;
            // 
            // ColumncbdgvSIT
            // 
            this.ColumncbdgvSIT.HeaderText = "SIT";
            this.ColumncbdgvSIT.Name = "ColumncbdgvSIT";
            this.ColumncbdgvSIT.Width = 50;
            // 
            // frmVoucherOR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(682, 686);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbAccountNo);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtCDiff);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtdrtot);
            this.Controls.Add(this.txtcrtot);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDifference);
            this.Controls.Add(this.cbSP);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDocNum);
            this.Controls.Add(this.dgv1);
            this.Name = "frmVoucherOR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Official Receipts";
            this.Load += new System.EventHandler(this.frmVoucherOR_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListReceive)).EndInit();
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
        private System.Windows.Forms.CheckBox cbCPay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtReceiveAmt;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.TextBox txtLORRefer;
        private System.Windows.Forms.TextBox txtCDiff;
        private System.Windows.Forms.Label label14;
        private moveNextCellDataGridView dgvListReceive;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox txtVDate;
        private System.Windows.Forms.CheckBox cbAccountNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReference;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBalance;
        private System.Windows.Forms.DataGridViewComboBoxColumn cboPA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtrefer;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDR;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCR;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumncbdgvSIT;
    }
}