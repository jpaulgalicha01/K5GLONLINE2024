namespace K5GLONLINE
{
    partial class frmVoucherPLNo
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
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.btnclose = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.txtDocNum = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTDate = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEndDate = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBegDate = new System.Windows.Forms.MaskedTextBox();
            this.btnpreview = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cboPC = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboWHCode = new System.Windows.Forms.ComboBox();
            this.cbSP = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(12, 119);
            this.dgv1.Name = "dgv1";
            this.dgv1.Size = new System.Drawing.Size(987, 458);
            this.dgv1.TabIndex = 10;
            this.dgv1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellDoubleClick);
            this.dgv1.Click += new System.EventHandler(this.dgv1_Click);
            // 
            // btnclose
            // 
            this.btnclose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnclose.Location = new System.Drawing.Point(924, 583);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 8;
            this.btnclose.Text = "&Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnsave
            // 
            this.btnsave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsave.Location = new System.Drawing.Point(843, 583);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 7;
            this.btnsave.Text = "&Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // txtDocNum
            // 
            this.txtDocNum.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDocNum.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocNum.Location = new System.Drawing.Point(890, 12);
            this.txtDocNum.Name = "txtDocNum";
            this.txtDocNum.ReadOnly = true;
            this.txtDocNum.Size = new System.Drawing.Size(109, 26);
            this.txtDocNum.TabIndex = 53;
            this.txtDocNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(453, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 19);
            this.label11.TabIndex = 55;
            this.label11.Text = "Remarks:";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(453, 85);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(419, 26);
            this.txtRemarks.TabIndex = 5;
            this.txtRemarks.Text = "Pick List";
            this.txtRemarks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter2);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 19);
            this.label2.TabIndex = 57;
            this.label2.Text = "Date:";
            // 
            // txtTDate
            // 
            this.txtTDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTDate.Location = new System.Drawing.Point(12, 37);
            this.txtTDate.Mask = "00/00/0000";
            this.txtTDate.Name = "txtTDate";
            this.txtTDate.Size = new System.Drawing.Size(89, 26);
            this.txtTDate.TabIndex = 0;
            this.txtTDate.ValidatingType = typeof(System.DateTime);
            this.txtTDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter2);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(566, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 19);
            this.label3.TabIndex = 67;
            this.label3.Text = "Date To:";
            // 
            // txtEndDate
            // 
            this.txtEndDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndDate.Location = new System.Drawing.Point(570, 36);
            this.txtEndDate.Mask = "00/00/0000";
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(102, 26);
            this.txtEndDate.TabIndex = 3;
            this.txtEndDate.ValidatingType = typeof(System.DateTime);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(449, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 19);
            this.label1.TabIndex = 66;
            this.label1.Text = "Date From:";
            // 
            // txtBegDate
            // 
            this.txtBegDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBegDate.Location = new System.Drawing.Point(453, 36);
            this.txtBegDate.Mask = "00/00/0000";
            this.txtBegDate.Name = "txtBegDate";
            this.txtBegDate.Size = new System.Drawing.Size(102, 26);
            this.txtBegDate.TabIndex = 2;
            this.txtBegDate.ValidatingType = typeof(System.DateTime);
            // 
            // btnpreview
            // 
            this.btnpreview.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnpreview.Location = new System.Drawing.Point(890, 85);
            this.btnpreview.Name = "btnpreview";
            this.btnpreview.Size = new System.Drawing.Size(109, 26);
            this.btnpreview.TabIndex = 6;
            this.btnpreview.Text = "Preview";
            this.btnpreview.UseVisualStyleBackColor = true;
            this.btnpreview.Click += new System.EventHandler(this.btnpreview_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label10.Location = new System.Drawing.Point(9, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 19);
            this.label10.TabIndex = 127;
            this.label10.Text = "Salesman";
            // 
            // cboPC
            // 
            this.cboPC.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboPC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPC.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cboPC.FormattingEnabled = true;
            this.cboPC.Location = new System.Drawing.Point(12, 85);
            this.cboPC.Name = "cboPC";
            this.cboPC.Size = new System.Drawing.Size(420, 27);
            this.cboPC.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label5.Location = new System.Drawing.Point(124, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 19);
            this.label5.TabIndex = 129;
            this.label5.Text = "Source Warehouse:";
            // 
            // cboWHCode
            // 
            this.cboWHCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboWHCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboWHCode.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cboWHCode.FormattingEnabled = true;
            this.cboWHCode.Location = new System.Drawing.Point(124, 36);
            this.cboWHCode.Name = "cboWHCode";
            this.cboWHCode.Size = new System.Drawing.Size(308, 27);
            this.cboWHCode.TabIndex = 1;
            // 
            // cbSP
            // 
            this.cbSP.AutoSize = true;
            this.cbSP.Location = new System.Drawing.Point(13, 589);
            this.cbSP.Name = "cbSP";
            this.cbSP.Size = new System.Drawing.Size(102, 17);
            this.cbSP.TabIndex = 9;
            this.cbSP.Text = "Save and Print?";
            this.cbSP.UseVisualStyleBackColor = true;
            // 
            // frmVoucherPLNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 618);
            this.Controls.Add(this.cbSP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboWHCode);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cboPC);
            this.Controls.Add(this.btnpreview);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEndDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBegDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTDate);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.txtDocNum);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.dgv1);
            this.Name = "frmVoucherPLNo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pick List Number";
            this.Load += new System.EventHandler(this.frmNameEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.TextBox txtDocNum;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtTDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtEndDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtBegDate;
        private System.Windows.Forms.Button btnpreview;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboPC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboWHCode;
        private System.Windows.Forms.CheckBox cbSP;
    }
}