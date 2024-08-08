namespace K5GLONLINE
{
    partial class frmVoucherAI
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtTDate = new System.Windows.Forms.MaskedTextBox();
            this.txtreference = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDocNum = new System.Windows.Forms.TextBox();
            this.cbSP = new System.Windows.Forms.CheckBox();
            this.cboWHCode = new System.Windows.Forms.ComboBox();
            this.cboPC = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cboStockNumber = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtOrdQCS = new System.Windows.Forms.TextBox();
            this.txtOrdQIB = new System.Windows.Forms.TextBox();
            this.txtOrdQPC = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtIB = new System.Windows.Forms.TextBox();
            this.txtPiece = new System.Windows.Forms.TextBox();
            this.cbPoulty = new System.Windows.Forms.CheckBox();
            this.cbSNEncode = new System.Windows.Forms.CheckBox();
            this.txtChickAQty = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgv2 = new K5GLONLINE.moveNextCellDataGridView();
            this.dgv2StockNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv2Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv2UM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv2AQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnChickAQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 19);
            this.label2.TabIndex = 31;
            this.label2.Text = "Date:";
            // 
            // txtTDate
            // 
            this.txtTDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTDate.Location = new System.Drawing.Point(25, 139);
            this.txtTDate.Mask = "00/00/0000";
            this.txtTDate.Name = "txtTDate";
            this.txtTDate.Size = new System.Drawing.Size(262, 26);
            this.txtTDate.TabIndex = 1;
            this.txtTDate.ValidatingType = typeof(System.DateTime);
            this.txtTDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter);
            this.txtTDate.Leave += new System.EventHandler(this.txtTDate_Leave);
            // 
            // txtreference
            // 
            this.txtreference.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreference.Location = new System.Drawing.Point(25, 206);
            this.txtreference.Name = "txtreference";
            this.txtreference.Size = new System.Drawing.Size(262, 26);
            this.txtreference.TabIndex = 2;
            this.txtreference.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter);
            this.txtreference.Validating += new System.ComponentModel.CancelEventHandler(this.txtreference_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 19);
            this.label1.TabIndex = 33;
            this.label1.Text = "Reference:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(312, 119);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 19);
            this.label11.TabIndex = 40;
            this.label11.Text = "Remarks:";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(316, 141);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(345, 26);
            this.txtRemarks.TabIndex = 4;
            this.txtRemarks.Text = "Actual Count";
            this.txtRemarks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(675, 545);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(594, 545);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDocNum
            // 
            this.txtDocNum.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocNum.Location = new System.Drawing.Point(665, 9);
            this.txtDocNum.Name = "txtDocNum";
            this.txtDocNum.ReadOnly = true;
            this.txtDocNum.Size = new System.Drawing.Size(85, 26);
            this.txtDocNum.TabIndex = 52;
            this.txtDocNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbSP
            // 
            this.cbSP.AutoSize = true;
            this.cbSP.Location = new System.Drawing.Point(25, 517);
            this.cbSP.Name = "cbSP";
            this.cbSP.Size = new System.Drawing.Size(102, 17);
            this.cbSP.TabIndex = 57;
            this.cbSP.Text = "Save and Print?";
            this.cbSP.UseVisualStyleBackColor = true;
            // 
            // cboWHCode
            // 
            this.cboWHCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboWHCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboWHCode.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboWHCode.FormattingEnabled = true;
            this.cboWHCode.Location = new System.Drawing.Point(25, 71);
            this.cboWHCode.Name = "cboWHCode";
            this.cboWHCode.Size = new System.Drawing.Size(262, 27);
            this.cboWHCode.TabIndex = 0;
            this.cboWHCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter);
            this.cboWHCode.Validating += new System.ComponentModel.CancelEventHandler(this.cboWHCode_Validating);
            // 
            // cboPC
            // 
            this.cboPC.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboPC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPC.FormattingEnabled = true;
            this.cboPC.Location = new System.Drawing.Point(316, 71);
            this.cboPC.Name = "cboPC";
            this.cboPC.Size = new System.Drawing.Size(345, 27);
            this.cboPC.TabIndex = 3;
            this.cboPC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter);
            this.cboPC.Validating += new System.ComponentModel.CancelEventHandler(this.cboPC_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 19);
            this.label5.TabIndex = 117;
            this.label5.Text = "Warehouse:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(312, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 19);
            this.label10.TabIndex = 119;
            this.label10.Text = "Salesman";
            // 
            // cboStockNumber
            // 
            this.cboStockNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboStockNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboStockNumber.DropDownWidth = 338;
            this.cboStockNumber.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStockNumber.FormattingEnabled = true;
            this.cboStockNumber.Location = new System.Drawing.Point(316, 206);
            this.cboStockNumber.Name = "cboStockNumber";
            this.cboStockNumber.Size = new System.Drawing.Size(280, 27);
            this.cboStockNumber.TabIndex = 5;
            this.cboStockNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter);
            this.cboStockNumber.Validating += new System.ComponentModel.CancelEventHandler(this.cboStockNumber_Validating);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(312, 184);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(102, 19);
            this.label17.TabIndex = 125;
            this.label17.Text = "Stock Number:";
            // 
            // txtOrdQCS
            // 
            this.txtOrdQCS.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrdQCS.Location = new System.Drawing.Point(602, 206);
            this.txtOrdQCS.Name = "txtOrdQCS";
            this.txtOrdQCS.Size = new System.Drawing.Size(60, 26);
            this.txtOrdQCS.TabIndex = 6;
            this.txtOrdQCS.Text = "0.00";
            this.txtOrdQCS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOrdQCS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter);
            this.txtOrdQCS.Validating += new System.ComponentModel.CancelEventHandler(this.txtOrdQCS_Validating);
            // 
            // txtOrdQIB
            // 
            this.txtOrdQIB.Enabled = false;
            this.txtOrdQIB.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrdQIB.Location = new System.Drawing.Point(690, 72);
            this.txtOrdQIB.Name = "txtOrdQIB";
            this.txtOrdQIB.Size = new System.Drawing.Size(60, 26);
            this.txtOrdQIB.TabIndex = 7;
            this.txtOrdQIB.Text = "0.00";
            this.txtOrdQIB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOrdQIB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter);
            this.txtOrdQIB.Validating += new System.ComponentModel.CancelEventHandler(this.txtOrdQIB_Validating);
            // 
            // txtOrdQPC
            // 
            this.txtOrdQPC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrdQPC.Location = new System.Drawing.Point(690, 141);
            this.txtOrdQPC.Name = "txtOrdQPC";
            this.txtOrdQPC.Size = new System.Drawing.Size(60, 26);
            this.txtOrdQPC.TabIndex = 8;
            this.txtOrdQPC.Text = "0.00";
            this.txtOrdQPC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOrdQPC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter);
            this.txtOrdQPC.Validating += new System.ComponentModel.CancelEventHandler(this.txtORDQPC_Validating);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(633, 184);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(29, 19);
            this.label19.TabIndex = 131;
            this.label19.Text = "CS";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(686, 49);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(24, 19);
            this.label20.TabIndex = 132;
            this.label20.Text = "IB";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(686, 119);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(29, 19);
            this.label21.TabIndex = 133;
            this.label21.Text = "PC";
            // 
            // txtIB
            // 
            this.txtIB.Enabled = false;
            this.txtIB.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIB.Location = new System.Drawing.Point(397, 3);
            this.txtIB.Name = "txtIB";
            this.txtIB.Size = new System.Drawing.Size(58, 22);
            this.txtIB.TabIndex = 151;
            this.txtIB.Text = "0";
            this.txtIB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIB.Visible = false;
            // 
            // txtPiece
            // 
            this.txtPiece.Enabled = false;
            this.txtPiece.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPiece.Location = new System.Drawing.Point(521, 12);
            this.txtPiece.Name = "txtPiece";
            this.txtPiece.Size = new System.Drawing.Size(58, 22);
            this.txtPiece.TabIndex = 152;
            this.txtPiece.Text = "0";
            this.txtPiece.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPiece.Visible = false;
            // 
            // cbPoulty
            // 
            this.cbPoulty.AutoSize = true;
            this.cbPoulty.Location = new System.Drawing.Point(25, 567);
            this.cbPoulty.Name = "cbPoulty";
            this.cbPoulty.Size = new System.Drawing.Size(61, 17);
            this.cbPoulty.TabIndex = 162;
            this.cbPoulty.Text = "Poulty?";
            this.cbPoulty.UseVisualStyleBackColor = true;
            this.cbPoulty.CheckedChanged += new System.EventHandler(this.cbPoulty_CheckedChanged);
            // 
            // cbSNEncode
            // 
            this.cbSNEncode.AutoSize = true;
            this.cbSNEncode.Checked = true;
            this.cbSNEncode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSNEncode.Location = new System.Drawing.Point(26, 542);
            this.cbSNEncode.Name = "cbSNEncode";
            this.cbSNEncode.Size = new System.Drawing.Size(148, 17);
            this.cbSNEncode.TabIndex = 165;
            this.cbSNEncode.Text = "Stock Number Encoding?";
            this.cbSNEncode.UseVisualStyleBackColor = true;
            this.cbSNEncode.CheckedChanged += new System.EventHandler(this.cbSNEncode_CheckedChanged);
            // 
            // txtChickAQty
            // 
            this.txtChickAQty.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChickAQty.Location = new System.Drawing.Point(690, 206);
            this.txtChickAQty.Name = "txtChickAQty";
            this.txtChickAQty.Size = new System.Drawing.Size(60, 26);
            this.txtChickAQty.TabIndex = 9;
            this.txtChickAQty.Text = "0";
            this.txtChickAQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtChickAQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter);
            this.txtChickAQty.Validating += new System.ComponentModel.CancelEventHandler(this.txtChickAQty_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(703, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 19);
            this.label3.TabIndex = 167;
            this.label3.Text = "P. Qty";
            // 
            // dgv2
            // 
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
            this.dgv2UM,
            this.dgv2AQty,
            this.ColumnChickAQty});
            this.dgv2.Location = new System.Drawing.Point(25, 239);
            this.dgv2.Name = "dgv2";
            this.dgv2.Size = new System.Drawing.Size(725, 270);
            this.dgv2.TabIndex = 10;
            // 
            // dgv2StockNumber
            // 
            this.dgv2StockNumber.HeaderText = "Stock Number";
            this.dgv2StockNumber.Name = "dgv2StockNumber";
            this.dgv2StockNumber.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv2StockNumber.Width = 130;
            // 
            // dgv2Item
            // 
            this.dgv2Item.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgv2Item.HeaderText = "Description";
            this.dgv2Item.Name = "dgv2Item";
            this.dgv2Item.ReadOnly = true;
            // 
            // dgv2UM
            // 
            this.dgv2UM.HeaderText = "UM";
            this.dgv2UM.Name = "dgv2UM";
            this.dgv2UM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv2UM.Width = 70;
            // 
            // dgv2AQty
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.NullValue = null;
            this.dgv2AQty.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv2AQty.HeaderText = "Qty/Weight";
            this.dgv2AQty.Name = "dgv2AQty";
            this.dgv2AQty.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv2AQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgv2AQty.Width = 75;
            // 
            // ColumnChickAQty
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnChickAQty.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnChickAQty.HeaderText = "Qty";
            this.ColumnChickAQty.Name = "ColumnChickAQty";
            this.ColumnChickAQty.Width = 70;
            // 
            // frmVoucherAI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 611);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtChickAQty);
            this.Controls.Add(this.dgv2);
            this.Controls.Add(this.cbSNEncode);
            this.Controls.Add(this.cbPoulty);
            this.Controls.Add(this.txtPiece);
            this.Controls.Add(this.txtIB);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtOrdQPC);
            this.Controls.Add(this.txtOrdQIB);
            this.Controls.Add(this.txtOrdQCS);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cboStockNumber);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboPC);
            this.Controls.Add(this.cboWHCode);
            this.Controls.Add(this.cbSP);
            this.Controls.Add(this.txtDocNum);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtreference);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTDate);
            this.KeyPreview = true;
            this.Name = "frmVoucherAI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actual Inventory";
            this.Load += new System.EventHandler(this.frmVoucherAI_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVoucherAI_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtTDate;
        private System.Windows.Forms.TextBox txtreference;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDocNum;
        private System.Windows.Forms.CheckBox cbSP;
        private System.Windows.Forms.ComboBox cboWHCode;
        private System.Windows.Forms.ComboBox cboPC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboStockNumber;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtOrdQCS;
        private System.Windows.Forms.TextBox txtOrdQIB;
        private System.Windows.Forms.TextBox txtOrdQPC;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtIB;
        private System.Windows.Forms.TextBox txtPiece;
        private System.Windows.Forms.CheckBox cbPoulty;
        private System.Windows.Forms.CheckBox cbSNEncode;
        private moveNextCellDataGridView dgv2;
        private System.Windows.Forms.TextBox txtChickAQty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv2StockNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv2Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv2UM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv2AQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnChickAQty;
    }
}