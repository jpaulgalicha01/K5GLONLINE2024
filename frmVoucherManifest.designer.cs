namespace K5GLONLINE
{
    partial class frmVoucherManifest
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
            this.txtMNum = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDTDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTDate = new System.Windows.Forms.MaskedTextBox();
            this.cboDVCode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgv2 = new System.Windows.Forms.DataGridView();
            this.TDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Post = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.RowIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBegDate = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEndDate = new System.Windows.Forms.MaskedTextBox();
            this.btnpreview = new System.Windows.Forms.Button();
            this.cbPrint = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboWHCode = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(11, 136);
            this.dgv1.Name = "dgv1";
            this.dgv1.Size = new System.Drawing.Size(636, 328);
            this.dgv1.TabIndex = 10;
            this.dgv1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellClick);
            this.dgv1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellContentClick);
            this.dgv1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellDoubleClick);
            // 
            // btnclose
            // 
            this.btnclose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnclose.Location = new System.Drawing.Point(573, 471);
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
            this.btnsave.Location = new System.Drawing.Point(492, 471);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 7;
            this.btnsave.Text = "&Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // txtMNum
            // 
            this.txtMNum.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMNum.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMNum.Location = new System.Drawing.Point(533, 12);
            this.txtMNum.Name = "txtMNum";
            this.txtMNum.ReadOnly = true;
            this.txtMNum.Size = new System.Drawing.Size(115, 26);
            this.txtMNum.TabIndex = 13;
            this.txtMNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label11.Location = new System.Drawing.Point(376, 83);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 19);
            this.label11.TabIndex = 55;
            this.label11.Text = "Delivery Team:";
            // 
            // txtDTDesc
            // 
            this.txtDTDesc.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtDTDesc.Location = new System.Drawing.Point(378, 104);
            this.txtDTDesc.Name = "txtDTDesc";
            this.txtDTDesc.Size = new System.Drawing.Size(270, 26);
            this.txtDTDesc.TabIndex = 6;
            this.txtDTDesc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter2);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label2.Location = new System.Drawing.Point(8, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 19);
            this.label2.TabIndex = 57;
            this.label2.Text = "Delivery Date:";
            // 
            // txtTDate
            // 
            this.txtTDate.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtTDate.Location = new System.Drawing.Point(12, 104);
            this.txtTDate.Mask = "00/00/0000";
            this.txtTDate.Name = "txtTDate";
            this.txtTDate.Size = new System.Drawing.Size(98, 26);
            this.txtTDate.TabIndex = 4;
            this.txtTDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTDate.ValidatingType = typeof(System.DateTime);
            this.txtTDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter2);
            // 
            // cboDVCode
            // 
            this.cboDVCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDVCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDVCode.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cboDVCode.FormattingEnabled = true;
            this.cboDVCode.Location = new System.Drawing.Point(116, 104);
            this.cboDVCode.Name = "cboDVCode";
            this.cboDVCode.Size = new System.Drawing.Size(256, 27);
            this.cboDVCode.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label5.Location = new System.Drawing.Point(116, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 19);
            this.label5.TabIndex = 58;
            this.label5.Text = "Delivery Van:";
            // 
            // dgv2
            // 
            this.dgv2.AllowUserToAddRows = false;
            this.dgv2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TDate,
            this.Reference,
            this.MNum,
            this.Post,
            this.RowIndex,
            this.IC});
            this.dgv2.Location = new System.Drawing.Point(11, 330);
            this.dgv2.Name = "dgv2";
            this.dgv2.Size = new System.Drawing.Size(636, 135);
            this.dgv2.TabIndex = 12;
            // 
            // TDate
            // 
            this.TDate.HeaderText = "TDate";
            this.TDate.Name = "TDate";
            // 
            // Reference
            // 
            this.Reference.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Reference.HeaderText = "Reference";
            this.Reference.Name = "Reference";
            // 
            // MNum
            // 
            this.MNum.HeaderText = "MNum";
            this.MNum.Name = "MNum";
            // 
            // Post
            // 
            this.Post.HeaderText = "Post";
            this.Post.Name = "Post";
            // 
            // RowIndex
            // 
            this.RowIndex.HeaderText = "RowIndex";
            this.RowIndex.Name = "RowIndex";
            // 
            // IC
            // 
            this.IC.HeaderText = "IC";
            this.IC.Name = "IC";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label1.Location = new System.Drawing.Point(8, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 19);
            this.label1.TabIndex = 61;
            this.label1.Text = "Date From:";
            // 
            // txtBegDate
            // 
            this.txtBegDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBegDate.Location = new System.Drawing.Point(12, 51);
            this.txtBegDate.Mask = "00/00/0000";
            this.txtBegDate.Name = "txtBegDate";
            this.txtBegDate.Size = new System.Drawing.Size(102, 26);
            this.txtBegDate.TabIndex = 0;
            this.txtBegDate.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label3.Location = new System.Drawing.Point(116, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 19);
            this.label3.TabIndex = 63;
            this.label3.Text = "Date To:";
            // 
            // txtEndDate
            // 
            this.txtEndDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndDate.Location = new System.Drawing.Point(120, 51);
            this.txtEndDate.Mask = "00/00/0000";
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(102, 26);
            this.txtEndDate.TabIndex = 1;
            this.txtEndDate.ValidatingType = typeof(System.DateTime);
            // 
            // btnpreview
            // 
            this.btnpreview.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnpreview.Location = new System.Drawing.Point(575, 51);
            this.btnpreview.Name = "btnpreview";
            this.btnpreview.Size = new System.Drawing.Size(73, 26);
            this.btnpreview.TabIndex = 3;
            this.btnpreview.Text = "Preview";
            this.btnpreview.UseVisualStyleBackColor = true;
            this.btnpreview.Click += new System.EventHandler(this.btnpreview_Click);
            // 
            // cbPrint
            // 
            this.cbPrint.AutoSize = true;
            this.cbPrint.Location = new System.Drawing.Point(12, 471);
            this.cbPrint.Name = "cbPrint";
            this.cbPrint.Size = new System.Drawing.Size(102, 17);
            this.cbPrint.TabIndex = 9;
            this.cbPrint.Text = "Save and Print?";
            this.cbPrint.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label4.Location = new System.Drawing.Point(228, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 19);
            this.label4.TabIndex = 131;
            this.label4.Text = "Warehouse:";
            // 
            // cboWHCode
            // 
            this.cboWHCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboWHCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboWHCode.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cboWHCode.FormattingEnabled = true;
            this.cboWHCode.Location = new System.Drawing.Point(228, 51);
            this.cboWHCode.Name = "cboWHCode";
            this.cboWHCode.Size = new System.Drawing.Size(339, 27);
            this.cboWHCode.TabIndex = 2;
            // 
            // frmVoucherManifest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 503);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboWHCode);
            this.Controls.Add(this.cbPrint);
            this.Controls.Add(this.btnpreview);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEndDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBegDate);
            this.Controls.Add(this.cboDVCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTDate);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtDTDesc);
            this.Controls.Add(this.txtMNum);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.dgv2);
            this.Controls.Add(this.dgv1);
            this.Name = "frmVoucherManifest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manifest";
            this.Load += new System.EventHandler(this.frmNameEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.TextBox txtMNum;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDTDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtTDate;
        private System.Windows.Forms.ComboBox cboDVCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reference;
        private System.Windows.Forms.DataGridViewTextBoxColumn MNum;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Post;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn IC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtBegDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtEndDate;
        private System.Windows.Forms.Button btnpreview;
        private System.Windows.Forms.CheckBox cbPrint;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboWHCode;
    }
}