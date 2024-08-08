namespace K5GLONLINE
{
    partial class frmVATEntry
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cboPAVAT = new System.Windows.Forms.ComboBox();
            this.txtTGross = new System.Windows.Forms.TextBox();
            this.txtTVAT = new System.Windows.Forms.TextBox();
            this.btnRecord = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtrefer = new System.Windows.Forms.TextBox();
            this.txtVoucher = new System.Windows.Forms.TextBox();
            this.txtTNet = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgv1 = new K5GLONLINE.moveNextCellDataGridView();
            this.txtPA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboPA = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.txtGross = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtVAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbAccountNo = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // cboPAVAT
            // 
            this.cboPAVAT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboPAVAT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPAVAT.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPAVAT.FormattingEnabled = true;
            this.cboPAVAT.Location = new System.Drawing.Point(23, 27);
            this.cboPAVAT.Name = "cboPAVAT";
            this.cboPAVAT.Size = new System.Drawing.Size(735, 23);
            this.cboPAVAT.TabIndex = 0;
            this.cboPAVAT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter);
            this.cboPAVAT.Validating += new System.ComponentModel.CancelEventHandler(this.cboPAVAT_Validating);
            // 
            // txtTGross
            // 
            this.txtTGross.Enabled = false;
            this.txtTGross.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTGross.Location = new System.Drawing.Point(23, 348);
            this.txtTGross.Name = "txtTGross";
            this.txtTGross.Size = new System.Drawing.Size(100, 22);
            this.txtTGross.TabIndex = 2;
            this.txtTGross.Text = "0.00";
            this.txtTGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTGross.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter);
            // 
            // txtTVAT
            // 
            this.txtTVAT.Enabled = false;
            this.txtTVAT.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTVAT.Location = new System.Drawing.Point(129, 346);
            this.txtTVAT.Name = "txtTVAT";
            this.txtTVAT.Size = new System.Drawing.Size(100, 22);
            this.txtTVAT.TabIndex = 3;
            this.txtTVAT.Text = "0.00";
            this.txtTVAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTVAT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter);
            // 
            // btnRecord
            // 
            this.btnRecord.Location = new System.Drawing.Point(602, 328);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(75, 23);
            this.btnRecord.TabIndex = 2;
            this.btnRecord.Text = "Record";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(683, 328);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Account Title - Tax:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(79, 328);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Gross:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(196, 328);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "VAT:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtrefer
            // 
            this.txtrefer.Location = new System.Drawing.Point(427, 328);
            this.txtrefer.Name = "txtrefer";
            this.txtrefer.Size = new System.Drawing.Size(51, 20);
            this.txtrefer.TabIndex = 9;
            this.txtrefer.Visible = false;
            // 
            // txtVoucher
            // 
            this.txtVoucher.Location = new System.Drawing.Point(511, 328);
            this.txtVoucher.Name = "txtVoucher";
            this.txtVoucher.Size = new System.Drawing.Size(51, 20);
            this.txtVoucher.TabIndex = 10;
            this.txtVoucher.Visible = false;
            // 
            // txtTNet
            // 
            this.txtTNet.Enabled = false;
            this.txtTNet.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTNet.Location = new System.Drawing.Point(235, 346);
            this.txtTNet.Name = "txtTNet";
            this.txtTNet.Size = new System.Drawing.Size(100, 22);
            this.txtTNet.TabIndex = 11;
            this.txtTNet.Text = "0.00";
            this.txtTNet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(305, 328);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Net:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dgv1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtPA,
            this.cboPA,
            this.txtGross,
            this.txtVAT,
            this.txtNet});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgv1.Location = new System.Drawing.Point(23, 66);
            this.dgv1.Name = "dgv1";
            this.dgv1.Size = new System.Drawing.Size(735, 244);
            this.dgv1.TabIndex = 1;
            this.dgv1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellEndEdit);
            this.dgv1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellEnter);
            this.dgv1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgv1_CellValidating);
            this.dgv1.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgv1_CurrentCellDirtyStateChanged);
            this.dgv1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv1_EditingControlShowing);
            this.dgv1.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv1_RowValidating);
            this.dgv1.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgv1_UserDeletedRow);
            // 
            // txtPA
            // 
            this.txtPA.HeaderText = "txtPA";
            this.txtPA.Name = "txtPA";
            this.txtPA.Visible = false;
            // 
            // cboPA
            // 
            this.cboPA.HeaderText = "Account Title";
            this.cboPA.Name = "cboPA";
            this.cboPA.Width = 380;
            // 
            // txtGross
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.txtGross.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtGross.HeaderText = "Gross";
            this.txtGross.Name = "txtGross";
            // 
            // txtVAT
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.txtVAT.DefaultCellStyle = dataGridViewCellStyle3;
            this.txtVAT.HeaderText = "VAT";
            this.txtVAT.Name = "txtVAT";
            this.txtVAT.ReadOnly = true;
            // 
            // txtNet
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.txtNet.DefaultCellStyle = dataGridViewCellStyle4;
            this.txtNet.HeaderText = "Net";
            this.txtNet.Name = "txtNet";
            this.txtNet.ReadOnly = true;
            // 
            // cbAccountNo
            // 
            this.cbAccountNo.AutoSize = true;
            this.cbAccountNo.Location = new System.Drawing.Point(557, 4);
            this.cbAccountNo.Name = "cbAccountNo";
            this.cbAccountNo.Size = new System.Drawing.Size(106, 17);
            this.cbAccountNo.TabIndex = 141;
            this.cbAccountNo.Text = "Account Number";
            this.cbAccountNo.UseVisualStyleBackColor = true;
            this.cbAccountNo.CheckedChanged += new System.EventHandler(this.cbAccountNo_CheckedChanged);
            // 
            // frmVATEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 387);
            this.Controls.Add(this.cbAccountNo);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTNet);
            this.Controls.Add(this.txtVoucher);
            this.Controls.Add(this.txtrefer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRecord);
            this.Controls.Add(this.txtTVAT);
            this.Controls.Add(this.txtTGross);
            this.Controls.Add(this.cboPAVAT);
            this.Name = "frmVATEntry";
            this.Text = "VAT Entry";
            this.Load += new System.EventHandler(this.frmVATEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboPAVAT;
        private System.Windows.Forms.TextBox txtTGross;
        private System.Windows.Forms.TextBox txtTVAT;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtrefer;
        private System.Windows.Forms.TextBox txtVoucher;
        private System.Windows.Forms.TextBox txtTNet;
        private System.Windows.Forms.Label label4;
        private moveNextCellDataGridView dgv1;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtPA;
        private System.Windows.Forms.DataGridViewComboBoxColumn cboPA;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtGross;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtVAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtNet;
        private System.Windows.Forms.CheckBox cbAccountNo;
    }
}