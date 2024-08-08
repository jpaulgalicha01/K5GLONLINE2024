namespace K5GLONLINE
{
    partial class frmVoucherDSCR
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
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTDate = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEndDate = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBegDate = new System.Windows.Forms.MaskedTextBox();
            this.btnpreview = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cboSalesman = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboRoute = new System.Windows.Forms.ComboBox();
            this.cbSP = new System.Windows.Forms.CheckBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTotalItem = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbListCI = new System.Windows.Forms.CheckBox();
            this.cbListRS = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(12, 154);
            this.dgv1.Name = "dgv1";
            this.dgv1.Size = new System.Drawing.Size(987, 423);
            this.dgv1.TabIndex = 10;
            this.dgv1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellContentClick);
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
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(143, 48);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(290, 26);
            this.txtRemarks.TabIndex = 6;
            this.txtRemarks.Text = "NA";
            this.txtRemarks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter2);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 19);
            this.label2.TabIndex = 57;
            this.label2.Text = "Report Date:";
            // 
            // txtTDate
            // 
            this.txtTDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTDate.Location = new System.Drawing.Point(13, 48);
            this.txtTDate.Mask = "00/00/0000";
            this.txtTDate.Name = "txtTDate";
            this.txtTDate.Size = new System.Drawing.Size(110, 26);
            this.txtTDate.TabIndex = 0;
            this.txtTDate.ValidatingType = typeof(System.DateTime);
            this.txtTDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter2);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 19);
            this.label3.TabIndex = 67;
            this.label3.Text = "Date To:";
            // 
            // txtEndDate
            // 
            this.txtEndDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndDate.Location = new System.Drawing.Point(22, 96);
            this.txtEndDate.Mask = "00/00/0000";
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(118, 26);
            this.txtEndDate.TabIndex = 5;
            this.txtEndDate.ValidatingType = typeof(System.DateTime);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 19);
            this.label1.TabIndex = 66;
            this.label1.Text = "Date From:";
            // 
            // txtBegDate
            // 
            this.txtBegDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBegDate.Location = new System.Drawing.Point(18, 38);
            this.txtBegDate.Mask = "00/00/0000";
            this.txtBegDate.Name = "txtBegDate";
            this.txtBegDate.Size = new System.Drawing.Size(120, 26);
            this.txtBegDate.TabIndex = 4;
            this.txtBegDate.ValidatingType = typeof(System.DateTime);
            // 
            // btnpreview
            // 
            this.btnpreview.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnpreview.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnpreview.Location = new System.Drawing.Point(272, 38);
            this.btnpreview.Name = "btnpreview";
            this.btnpreview.Size = new System.Drawing.Size(128, 84);
            this.btnpreview.TabIndex = 7;
            this.btnpreview.Text = "Preview";
            this.btnpreview.UseVisualStyleBackColor = false;
            this.btnpreview.Click += new System.EventHandler(this.btnpreview_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label10.Location = new System.Drawing.Point(10, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 19);
            this.label10.TabIndex = 127;
            this.label10.Text = "Salesman";
            // 
            // cboSalesman
            // 
            this.cboSalesman.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSalesman.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSalesman.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cboSalesman.FormattingEnabled = true;
            this.cboSalesman.Location = new System.Drawing.Point(13, 96);
            this.cboSalesman.Name = "cboSalesman";
            this.cboSalesman.Size = new System.Drawing.Size(420, 27);
            this.cboSalesman.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label5.Location = new System.Drawing.Point(139, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 19);
            this.label5.TabIndex = 129;
            this.label5.Text = "Route:";
            // 
            // cboRoute
            // 
            this.cboRoute.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboRoute.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRoute.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cboRoute.FormattingEnabled = true;
            this.cboRoute.Location = new System.Drawing.Point(224, 15);
            this.cboRoute.Name = "cboRoute";
            this.cboRoute.Size = new System.Drawing.Size(91, 27);
            this.cboRoute.TabIndex = 1;
            this.cboRoute.Visible = false;
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
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.RoyalBlue;
            this.GroupBox1.Controls.Add(this.cbListRS);
            this.GroupBox1.Controls.Add(this.cbListCI);
            this.GroupBox1.Controls.Add(this.label1);
            this.GroupBox1.Controls.Add(this.txtBegDate);
            this.GroupBox1.Controls.Add(this.txtEndDate);
            this.GroupBox1.Controls.Add(this.label3);
            this.GroupBox1.Controls.Add(this.btnpreview);
            this.GroupBox1.Location = new System.Drawing.Point(457, 11);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(416, 137);
            this.GroupBox1.TabIndex = 130;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Invoice Date:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.RoyalBlue;
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtRemarks);
            this.groupBox2.Controls.Add(this.txtTDate);
            this.groupBox2.Controls.Add(this.cboRoute);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cboSalesman);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(11, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(440, 137);
            this.groupBox2.TabIndex = 131;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Details:";
            // 
            // txtTotalItem
            // 
            this.txtTotalItem.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalItem.ForeColor = System.Drawing.Color.Red;
            this.txtTotalItem.Location = new System.Drawing.Point(664, 583);
            this.txtTotalItem.Name = "txtTotalItem";
            this.txtTotalItem.ReadOnly = true;
            this.txtTotalItem.Size = new System.Drawing.Size(67, 33);
            this.txtTotalItem.TabIndex = 132;
            this.txtTotalItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(539, 584);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 19);
            this.label4.TabIndex = 133;
            this.label4.Text = "No. of Records :";
            // 
            // cbListCI
            // 
            this.cbListCI.AutoSize = true;
            this.cbListCI.Checked = true;
            this.cbListCI.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbListCI.Location = new System.Drawing.Point(163, 56);
            this.cbListCI.Name = "cbListCI";
            this.cbListCI.Size = new System.Drawing.Size(98, 17);
            this.cbListCI.TabIndex = 68;
            this.cbListCI.Text = "Charge Invoice";
            this.cbListCI.UseVisualStyleBackColor = true;
            this.cbListCI.CheckedChanged += new System.EventHandler(this.cbListCI_CheckedChanged);
            // 
            // cbListRS
            // 
            this.cbListRS.AutoSize = true;
            this.cbListRS.Location = new System.Drawing.Point(163, 102);
            this.cbListRS.Name = "cbListRS";
            this.cbListRS.Size = new System.Drawing.Size(84, 17);
            this.cbListRS.TabIndex = 69;
            this.cbListRS.Text = "Return Form";
            this.cbListRS.UseVisualStyleBackColor = true;
            this.cbListRS.CheckedChanged += new System.EventHandler(this.cbListRS_CheckedChanged);
            // 
            // frmVoucherDSCR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1011, 618);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTotalItem);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.cbSP);
            this.Controls.Add(this.txtDocNum);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.dgv1);
            this.Name = "frmVoucherDSCR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Daily Sales and Collection";
            this.Load += new System.EventHandler(this.frmNameEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.TextBox txtDocNum;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtTDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtEndDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtBegDate;
        private System.Windows.Forms.Button btnpreview;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboSalesman;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboRoute;
        private System.Windows.Forms.CheckBox cbSP;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTotalItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbListCI;
        private System.Windows.Forms.CheckBox cbListRS;
    }
}