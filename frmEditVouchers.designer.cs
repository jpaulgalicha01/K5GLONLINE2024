namespace K5GLONLINE
{
    partial class frmEditVouchers
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.dgvSearch = new System.Windows.Forms.DataGridView();
            this.Reference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboVoucher = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cbVoid = new System.Windows.Forms.CheckBox();
            this.cbAccountNo = new System.Windows.Forms.CheckBox();
            this.txtWarehouse = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtIC = new System.Windows.Forms.TextBox();
            this.dgv2 = new K5GLONLINE.moveNextCellDataGridView();
            this.dgv2StockNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv2Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv2ChickOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv2Out = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv2UM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv2UP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv2ActDisct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv2PDisct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1Vat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefforAC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv1 = new K5GLONLINE.moveNextCellDataGridView();
            this.cboPA = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.txtrefer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.txtVDate = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDE = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(277, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 19);
            this.label2.TabIndex = 31;
            this.label2.Text = "Date:";
            // 
            // txtTDate
            // 
            this.txtTDate.Enabled = false;
            this.txtTDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTDate.Location = new System.Drawing.Point(281, 51);
            this.txtTDate.Mask = "00/00/0000";
            this.txtTDate.Name = "txtTDate";
            this.txtTDate.Size = new System.Drawing.Size(88, 26);
            this.txtTDate.TabIndex = 3;
            this.txtTDate.ValidatingType = typeof(System.DateTime);
            this.txtTDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDate_KeyDown);
            this.txtTDate.Leave += new System.EventHandler(this.txtTDate_Leave);
            // 
            // txtreference
            // 
            this.txtreference.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreference.Location = new System.Drawing.Point(281, 109);
            this.txtreference.Name = "txtreference";
            this.txtreference.Size = new System.Drawing.Size(299, 26);
            this.txtreference.TabIndex = 4;
            this.txtreference.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtreference_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(277, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 19);
            this.label1.TabIndex = 33;
            this.label1.Text = "Reference:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(582, 28);
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
            this.cboControlNo.Location = new System.Drawing.Point(586, 49);
            this.cboControlNo.Name = "cboControlNo";
            this.cboControlNo.Size = new System.Drawing.Size(437, 27);
            this.cboControlNo.TabIndex = 5;
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
            this.txtRemarks.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(281, 167);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(742, 26);
            this.txtRemarks.TabIndex = 7;
            this.txtRemarks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRemarks_KeyDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(577, 570);
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
            this.label12.Location = new System.Drawing.Point(368, 570);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 13);
            this.label12.TabIndex = 50;
            this.label12.Text = "Total Debit:";
            // 
            // txtdrtot
            // 
            this.txtdrtot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdrtot.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtdrtot.Location = new System.Drawing.Point(445, 570);
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
            this.txtcrtot.Location = new System.Drawing.Point(660, 570);
            this.txtcrtot.Name = "txtcrtot";
            this.txtcrtot.ReadOnly = true;
            this.txtcrtot.Size = new System.Drawing.Size(108, 20);
            this.txtcrtot.TabIndex = 48;
            this.txtcrtot.Text = "0.00";
            this.txtcrtot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(948, 567);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(867, 567);
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
            this.txtDocNum.Location = new System.Drawing.Point(938, 12);
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
            this.label6.Location = new System.Drawing.Point(127, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 19);
            this.label6.TabIndex = 74;
            this.label6.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(131, 51);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(116, 26);
            this.txtSearch.TabIndex = 1;
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
            this.cboPC.Location = new System.Drawing.Point(794, 108);
            this.cboPC.Name = "cboPC";
            this.cboPC.Size = new System.Drawing.Size(229, 27);
            this.cboPC.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(790, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 19);
            this.label4.TabIndex = 76;
            this.label4.Text = "Salesman:";
            // 
            // dgvSearch
            // 
            this.dgvSearch.AllowUserToAddRows = false;
            this.dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Reference});
            this.dgvSearch.Location = new System.Drawing.Point(26, 83);
            this.dgvSearch.Name = "dgvSearch";
            this.dgvSearch.Size = new System.Drawing.Size(221, 110);
            this.dgvSearch.TabIndex = 2;
            this.dgvSearch.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSearch_CellEnter);
            this.dgvSearch.DoubleClick += new System.EventHandler(this.dgvSearch_DoubleClick);
            // 
            // Reference
            // 
            this.Reference.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Reference.HeaderText = "Reference";
            this.Reference.Name = "Reference";
            // 
            // cboVoucher
            // 
            this.cboVoucher.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboVoucher.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboVoucher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVoucher.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboVoucher.FormattingEnabled = true;
            this.cboVoucher.Items.AddRange(new object[] {
            "APV",
            "ARV",
            "JV",
            "CV",
            "OR",
            "CS",
            "CI",
            "RS",
            "PD",
            "AS",
            "RV",
            "TF"});
            this.cboVoucher.Location = new System.Drawing.Point(26, 50);
            this.cboVoucher.Name = "cboVoucher";
            this.cboVoucher.Size = new System.Drawing.Size(89, 27);
            this.cboVoucher.TabIndex = 0;
            this.cboVoucher.Validating += new System.ComponentModel.CancelEventHandler(this.cboVoucher_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 19);
            this.label5.TabIndex = 78;
            this.label5.Text = "Voucher:";
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(786, 567);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 79;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cbVoid
            // 
            this.cbVoid.AutoSize = true;
            this.cbVoid.Location = new System.Drawing.Point(24, 573);
            this.cbVoid.Name = "cbVoid";
            this.cbVoid.Size = new System.Drawing.Size(53, 17);
            this.cbVoid.TabIndex = 121;
            this.cbVoid.Text = "Void?";
            this.cbVoid.UseVisualStyleBackColor = true;
            // 
            // cbAccountNo
            // 
            this.cbAccountNo.AutoSize = true;
            this.cbAccountNo.Checked = true;
            this.cbAccountNo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAccountNo.Location = new System.Drawing.Point(131, 571);
            this.cbAccountNo.Name = "cbAccountNo";
            this.cbAccountNo.Size = new System.Drawing.Size(106, 17);
            this.cbAccountNo.TabIndex = 141;
            this.cbAccountNo.Text = "Account Number";
            this.cbAccountNo.UseVisualStyleBackColor = true;
            // 
            // txtWarehouse
            // 
            this.txtWarehouse.Enabled = false;
            this.txtWarehouse.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWarehouse.Location = new System.Drawing.Point(586, 109);
            this.txtWarehouse.Name = "txtWarehouse";
            this.txtWarehouse.Size = new System.Drawing.Size(202, 26);
            this.txtWarehouse.TabIndex = 142;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(582, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 19);
            this.label7.TabIndex = 143;
            this.label7.Text = "Warehouse:";
            // 
            // txtIC
            // 
            this.txtIC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIC.Location = new System.Drawing.Point(464, 1);
            this.txtIC.Name = "txtIC";
            this.txtIC.Size = new System.Drawing.Size(116, 26);
            this.txtIC.TabIndex = 144;
            this.txtIC.Visible = false;
            // 
            // dgv2
            // 
            this.dgv2.AllowUserToAddRows = false;
            this.dgv2.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv2StockNumber,
            this.dgv2Item,
            this.dgv2ChickOut,
            this.dgv2Out,
            this.dgv2UM,
            this.dgv2UP,
            this.dgv2ActDisct,
            this.dgv2PDisct,
            this.dgv1Vat,
            this.dgvTotal,
            this.dgv1Cost,
            this.RefforAC});
            this.dgv2.Location = new System.Drawing.Point(24, 382);
            this.dgv2.Name = "dgv2";
            this.dgv2.ReadOnly = true;
            this.dgv2.Size = new System.Drawing.Size(999, 177);
            this.dgv2.TabIndex = 9;
            // 
            // dgv2StockNumber
            // 
            this.dgv2StockNumber.HeaderText = "Stock Number";
            this.dgv2StockNumber.Name = "dgv2StockNumber";
            this.dgv2StockNumber.ReadOnly = true;
            this.dgv2StockNumber.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dgv2Item
            // 
            this.dgv2Item.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv2Item.HeaderText = "Description";
            this.dgv2Item.Name = "dgv2Item";
            this.dgv2Item.ReadOnly = true;
            // 
            // dgv2ChickOut
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgv2ChickOut.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv2ChickOut.HeaderText = "Qty";
            this.dgv2ChickOut.Name = "dgv2ChickOut";
            this.dgv2ChickOut.ReadOnly = true;
            this.dgv2ChickOut.Width = 70;
            // 
            // dgv2Out
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgv2Out.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv2Out.HeaderText = "Qty/Weight";
            this.dgv2Out.Name = "dgv2Out";
            this.dgv2Out.ReadOnly = true;
            this.dgv2Out.Width = 70;
            // 
            // dgv2UM
            // 
            this.dgv2UM.HeaderText = "UM";
            this.dgv2UM.Name = "dgv2UM";
            this.dgv2UM.ReadOnly = true;
            this.dgv2UM.Width = 40;
            // 
            // dgv2UP
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgv2UP.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv2UP.HeaderText = "Unit Price";
            this.dgv2UP.Name = "dgv2UP";
            this.dgv2UP.ReadOnly = true;
            this.dgv2UP.Width = 80;
            // 
            // dgv2ActDisct
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgv2ActDisct.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgv2ActDisct.HeaderText = "% Disct";
            this.dgv2ActDisct.Name = "dgv2ActDisct";
            this.dgv2ActDisct.ReadOnly = true;
            this.dgv2ActDisct.Width = 80;
            // 
            // dgv2PDisct
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgv2PDisct.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgv2PDisct.HeaderText = "P Disct";
            this.dgv2PDisct.Name = "dgv2PDisct";
            this.dgv2PDisct.ReadOnly = true;
            this.dgv2PDisct.Width = 80;
            // 
            // dgv1Vat
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgv1Vat.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgv1Vat.HeaderText = "VAT";
            this.dgv1Vat.Name = "dgv1Vat";
            this.dgv1Vat.ReadOnly = true;
            this.dgv1Vat.Width = 75;
            // 
            // dgvTotal
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgvTotal.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvTotal.HeaderText = "Total";
            this.dgvTotal.Name = "dgvTotal";
            this.dgvTotal.ReadOnly = true;
            this.dgvTotal.Width = 90;
            // 
            // dgv1Cost
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgv1Cost.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgv1Cost.HeaderText = "Cost";
            this.dgv1Cost.Name = "dgv1Cost";
            this.dgv1Cost.ReadOnly = true;
            this.dgv1Cost.Width = 90;
            // 
            // RefforAC
            // 
            this.RefforAC.HeaderText = "RefforAC";
            this.RefforAC.Name = "RefforAC";
            this.RefforAC.ReadOnly = true;
            this.RefforAC.Visible = false;
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
            this.dgv1.Size = new System.Drawing.Size(997, 177);
            this.dgv1.TabIndex = 8;
            this.dgv1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellEndEdit);
            this.dgv1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgv1_CellValidating);
            this.dgv1.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgv1_CurrentCellDirtyStateChanged);
            this.dgv1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv1_EditingControlShowing);
            this.dgv1.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv1_RowValidating);
            this.dgv1.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgv1_UserDeletedRow);
            // 
            // cboPA
            // 
            this.cboPA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cboPA.HeaderText = "Account Title";
            this.cboPA.Name = "cboPA";
            // 
            // txtrefer
            // 
            this.txtrefer.HeaderText = "Reference";
            this.txtrefer.Name = "txtrefer";
            this.txtrefer.Width = 150;
            // 
            // txtDR
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.txtDR.DefaultCellStyle = dataGridViewCellStyle10;
            this.txtDR.HeaderText = "Debit";
            this.txtDR.Name = "txtDR";
            this.txtDR.Width = 150;
            // 
            // txtCR
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.txtCR.DefaultCellStyle = dataGridViewCellStyle11;
            this.txtCR.HeaderText = "Credit";
            this.txtCR.Name = "txtCR";
            this.txtCR.Width = 150;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(378, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 19);
            this.label8.TabIndex = 146;
            this.label8.Text = "Value Date:";
            // 
            // txtVDate
            // 
            this.txtVDate.Enabled = false;
            this.txtVDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVDate.Location = new System.Drawing.Point(382, 51);
            this.txtVDate.Mask = "00/00/0000";
            this.txtVDate.Name = "txtVDate";
            this.txtVDate.Size = new System.Drawing.Size(88, 26);
            this.txtVDate.TabIndex = 145;
            this.txtVDate.ValidatingType = typeof(System.DateTime);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(478, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 19);
            this.label9.TabIndex = 148;
            this.label9.Text = "Date Encoded:";
            // 
            // txtDE
            // 
            this.txtDE.Enabled = false;
            this.txtDE.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDE.Location = new System.Drawing.Point(482, 50);
            this.txtDE.Mask = "00/00/0000";
            this.txtDE.Name = "txtDE";
            this.txtDE.Size = new System.Drawing.Size(95, 26);
            this.txtDE.TabIndex = 147;
            this.txtDE.ValidatingType = typeof(System.DateTime);
            // 
            // frmEditVouchers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 602);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtDE);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtVDate);
            this.Controls.Add(this.txtIC);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtWarehouse);
            this.Controls.Add(this.cbAccountNo);
            this.Controls.Add(this.cbVoid);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgv2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboVoucher);
            this.Controls.Add(this.dgvSearch);
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
            this.Name = "frmEditVouchers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search - Vouchers";
            this.Load += new System.EventHandler(this.frmVoucherJV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvSearch;
        private System.Windows.Forms.ComboBox cboVoucher;
        private System.Windows.Forms.Label label5;
        private moveNextCellDataGridView dgv2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.CheckBox cbVoid;
        private System.Windows.Forms.CheckBox cbAccountNo;
        private System.Windows.Forms.TextBox txtWarehouse;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reference;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv2StockNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv2Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv2ChickOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv2Out;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv2UM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv2UP;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv2ActDisct;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv2PDisct;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1Vat;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv1Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefforAC;
        private System.Windows.Forms.DataGridViewComboBoxColumn cboPA;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtrefer;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDR;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCR;
        private System.Windows.Forms.TextBox txtIC;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox txtVDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox txtDE;
    }
}