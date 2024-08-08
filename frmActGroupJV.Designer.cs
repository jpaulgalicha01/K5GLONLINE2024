namespace K5GLONLINE
{
    partial class frmActGroupJV
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
            this.cboPA = new System.Windows.Forms.ComboBox();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.txtDebit = new System.Windows.Forms.TextBox();
            this.txtCredit = new System.Windows.Forms.TextBox();
            this.btnRecord = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtrefer = new System.Windows.Forms.TextBox();
            this.txtVoucher = new System.Windows.Forms.TextBox();
            this.cbAccountNo = new System.Windows.Forms.CheckBox();
            this.Reference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // cboPA
            // 
            this.cboPA.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboPA.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPA.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPA.FormattingEnabled = true;
            this.cboPA.Location = new System.Drawing.Point(23, 27);
            this.cboPA.Name = "cboPA";
            this.cboPA.Size = new System.Drawing.Size(400, 23);
            this.cboPA.TabIndex = 0;
            this.cboPA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter);
            this.cboPA.Validating += new System.ComponentModel.CancelEventHandler(this.cboPA_Validating);
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Reference,
            this.Date,
            this.Bal});
            this.dgv1.Location = new System.Drawing.Point(23, 56);
            this.dgv1.Name = "dgv1";
            this.dgv1.Size = new System.Drawing.Size(400, 315);
            this.dgv1.TabIndex = 1;
            this.dgv1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellEnter);
            // 
            // txtDebit
            // 
            this.txtDebit.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDebit.Location = new System.Drawing.Point(23, 405);
            this.txtDebit.Name = "txtDebit";
            this.txtDebit.Size = new System.Drawing.Size(100, 22);
            this.txtDebit.TabIndex = 2;
            this.txtDebit.Text = "0.00";
            this.txtDebit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDebit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter);
            this.txtDebit.Validating += new System.ComponentModel.CancelEventHandler(this.txtDebit_Validating);
            // 
            // txtCredit
            // 
            this.txtCredit.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCredit.Location = new System.Drawing.Point(129, 406);
            this.txtCredit.Name = "txtCredit";
            this.txtCredit.Size = new System.Drawing.Size(100, 22);
            this.txtCredit.TabIndex = 3;
            this.txtCredit.Text = "0.00";
            this.txtCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCredit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter);
            this.txtCredit.Validating += new System.ComponentModel.CancelEventHandler(this.txtCredit_Validating);
            // 
            // btnRecord
            // 
            this.btnRecord.Location = new System.Drawing.Point(263, 405);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(75, 23);
            this.btnRecord.TabIndex = 4;
            this.btnRecord.Text = "Record";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(348, 405);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
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
            this.label1.Size = new System.Drawing.Size(85, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Account Title:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(83, 387);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Debit:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(183, 387);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Credit:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtrefer
            // 
            this.txtrefer.Location = new System.Drawing.Point(245, 382);
            this.txtrefer.Name = "txtrefer";
            this.txtrefer.Size = new System.Drawing.Size(51, 20);
            this.txtrefer.TabIndex = 9;
            this.txtrefer.Visible = false;
            // 
            // txtVoucher
            // 
            this.txtVoucher.Location = new System.Drawing.Point(315, 377);
            this.txtVoucher.Name = "txtVoucher";
            this.txtVoucher.Size = new System.Drawing.Size(51, 20);
            this.txtVoucher.TabIndex = 10;
            this.txtVoucher.Visible = false;
            // 
            // cbAccountNo
            // 
            this.cbAccountNo.AutoSize = true;
            this.cbAccountNo.Checked = true;
            this.cbAccountNo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAccountNo.Location = new System.Drawing.Point(317, 4);
            this.cbAccountNo.Name = "cbAccountNo";
            this.cbAccountNo.Size = new System.Drawing.Size(106, 17);
            this.cbAccountNo.TabIndex = 141;
            this.cbAccountNo.Text = "Account Number";
            this.cbAccountNo.UseVisualStyleBackColor = true;
            this.cbAccountNo.CheckedChanged += new System.EventHandler(this.cbAccountNo_CheckedChanged);
            // 
            // Reference
            // 
            this.Reference.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Reference.HeaderText = "Reference";
            this.Reference.Name = "Reference";
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            // 
            // Bal
            // 
            this.Bal.HeaderText = "Amount";
            this.Bal.Name = "Bal";
            // 
            // frmActGroupJV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 440);
            this.Controls.Add(this.cbAccountNo);
            this.Controls.Add(this.txtVoucher);
            this.Controls.Add(this.txtrefer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRecord);
            this.Controls.Add(this.txtCredit);
            this.Controls.Add(this.txtDebit);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.cboPA);
            this.Name = "frmActGroupJV";
            this.Text = "Balance - Account Title";
            this.Load += new System.EventHandler(this.frmActGroupJV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboPA;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.TextBox txtDebit;
        private System.Windows.Forms.TextBox txtCredit;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtrefer;
        private System.Windows.Forms.TextBox txtVoucher;
        private System.Windows.Forms.CheckBox cbAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reference;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bal;
    }
}