
namespace K5GLONLINE
{
    partial class frmCheckWriter
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
            this.btnSettings = new System.Windows.Forms.Button();
            this.cboBankCode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.ColumnNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnVoucher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCustName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnBankActEntry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCheckNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboCNCode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtamtinwords = new System.Windows.Forms.TextBox();
            this.txtcamount = new System.Windows.Forms.TextBox();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnrefresh = new System.Windows.Forms.Button();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.Location = new System.Drawing.Point(757, 9);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(147, 35);
            this.btnSettings.TabIndex = 85;
            this.btnSettings.Text = "Check Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // cboBankCode
            // 
            this.cboBankCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboBankCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBankCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBankCode.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBankCode.FormattingEnabled = true;
            this.cboBankCode.Location = new System.Drawing.Point(246, 31);
            this.cboBankCode.Name = "cboBankCode";
            this.cboBankCode.Size = new System.Drawing.Size(486, 27);
            this.cboBankCode.TabIndex = 2;
            this.cboBankCode.SelectedIndexChanged += new System.EventHandler(this.cboBankCode_SelectedIndexChanged);
            this.cboBankCode.SelectionChangeCommitted += new System.EventHandler(this.cboBankCode_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(196, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 19);
            this.label1.TabIndex = 83;
            this.label1.Text = "Bank:";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(829, 549);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 31);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnNumber,
            this.ColumnVoucher,
            this.ColumnCustName,
            this.ColumnBankActEntry,
            this.ColumnCheckNo,
            this.ColumnTDate,
            this.ColumnCredit});
            this.dgv1.Location = new System.Drawing.Point(12, 123);
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersWidth = 51;
            this.dgv1.Size = new System.Drawing.Size(892, 349);
            this.dgv1.TabIndex = 3;
            this.dgv1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellEnter);
            // 
            // ColumnNumber
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnNumber.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnNumber.HeaderText = "Number";
            this.ColumnNumber.MinimumWidth = 6;
            this.ColumnNumber.Name = "ColumnNumber";
            this.ColumnNumber.ReadOnly = true;
            this.ColumnNumber.Width = 65;
            // 
            // ColumnVoucher
            // 
            this.ColumnVoucher.HeaderText = "Voucher";
            this.ColumnVoucher.MinimumWidth = 6;
            this.ColumnVoucher.Name = "ColumnVoucher";
            this.ColumnVoucher.ReadOnly = true;
            this.ColumnVoucher.Width = 60;
            // 
            // ColumnCustName
            // 
            this.ColumnCustName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnCustName.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnCustName.HeaderText = "Name";
            this.ColumnCustName.MinimumWidth = 6;
            this.ColumnCustName.Name = "ColumnCustName";
            this.ColumnCustName.ReadOnly = true;
            this.ColumnCustName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnCustName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnBankActEntry
            // 
            this.ColumnBankActEntry.HeaderText = "Bank";
            this.ColumnBankActEntry.MinimumWidth = 6;
            this.ColumnBankActEntry.Name = "ColumnBankActEntry";
            this.ColumnBankActEntry.ReadOnly = true;
            this.ColumnBankActEntry.Width = 180;
            // 
            // ColumnCheckNo
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnCheckNo.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnCheckNo.HeaderText = "Check No.";
            this.ColumnCheckNo.MinimumWidth = 6;
            this.ColumnCheckNo.Name = "ColumnCheckNo";
            this.ColumnCheckNo.ReadOnly = true;
            this.ColumnCheckNo.Width = 126;
            // 
            // ColumnTDate
            // 
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnTDate.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnTDate.HeaderText = "Date";
            this.ColumnTDate.MinimumWidth = 6;
            this.ColumnTDate.Name = "ColumnTDate";
            this.ColumnTDate.ReadOnly = true;
            this.ColumnTDate.Width = 75;
            // 
            // ColumnCredit
            // 
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnCredit.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColumnCredit.HeaderText = "Amount";
            this.ColumnCredit.MinimumWidth = 6;
            this.ColumnCredit.Name = "ColumnCredit";
            this.ColumnCredit.ReadOnly = true;
            this.ColumnCredit.Width = 125;
            // 
            // cboCNCode
            // 
            this.cboCNCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCNCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCNCode.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCNCode.FormattingEnabled = true;
            this.cboCNCode.Location = new System.Drawing.Point(196, 92);
            this.cboCNCode.Name = "cboCNCode";
            this.cboCNCode.Size = new System.Drawing.Size(709, 27);
            this.cboCNCode.TabIndex = 73;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(192, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 19);
            this.label4.TabIndex = 80;
            this.label4.Text = "Branch";
            // 
            // txtamtinwords
            // 
            this.txtamtinwords.BackColor = System.Drawing.SystemColors.Window;
            this.txtamtinwords.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtamtinwords.ForeColor = System.Drawing.Color.Black;
            this.txtamtinwords.Location = new System.Drawing.Point(14, 514);
            this.txtamtinwords.Name = "txtamtinwords";
            this.txtamtinwords.ReadOnly = true;
            this.txtamtinwords.Size = new System.Drawing.Size(890, 29);
            this.txtamtinwords.TabIndex = 79;
            // 
            // txtcamount
            // 
            this.txtcamount.BackColor = System.Drawing.SystemColors.Window;
            this.txtcamount.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcamount.Location = new System.Drawing.Point(699, 479);
            this.txtcamount.Name = "txtcamount";
            this.txtcamount.ReadOnly = true;
            this.txtcamount.Size = new System.Drawing.Size(206, 29);
            this.txtcamount.TabIndex = 78;
            this.txtcamount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCustName
            // 
            this.txtCustName.BackColor = System.Drawing.SystemColors.Window;
            this.txtCustName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustName.Location = new System.Drawing.Point(14, 479);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.ReadOnly = true;
            this.txtCustName.Size = new System.Drawing.Size(603, 29);
            this.txtCustName.TabIndex = 77;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 19);
            this.label2.TabIndex = 76;
            this.label2.Text = "Ending Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 19);
            this.label3.TabIndex = 75;
            this.label3.Text = "Beginning Date";
            // 
            // btnrefresh
            // 
            this.btnrefresh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrefresh.Location = new System.Drawing.Point(757, 51);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(147, 35);
            this.btnrefresh.TabIndex = 74;
            this.btnrefresh.Text = "Refresh List";
            this.btnrefresh.UseVisualStyleBackColor = true;
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // dtpFrom
            // 
            this.dtpFrom.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(13, 32);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(167, 26);
            this.dtpFrom.TabIndex = 0;
            this.dtpFrom.Value = new System.DateTime(2022, 8, 3, 8, 53, 38, 0);
            // 
            // dtpTo
            // 
            this.dtpTo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(14, 92);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(166, 26);
            this.dtpTo.TabIndex = 1;
            this.dtpTo.Value = new System.DateTime(2022, 8, 10, 12, 10, 40, 0);
            // 
            // frmCheckWriter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(914, 591);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.cboBankCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.cboCNCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtamtinwords);
            this.Controls.Add(this.txtcamount);
            this.Controls.Add(this.txtCustName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnrefresh);
            this.Name = "frmCheckWriter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check Writer";
            this.Load += new System.EventHandler(this.frmCheckWriter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.ComboBox cboBankCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.ComboBox cboCNCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtamtinwords;
        private System.Windows.Forms.TextBox txtcamount;
        private System.Windows.Forms.TextBox txtCustName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnrefresh;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnVoucher;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnCustName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBankActEntry;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCheckNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCredit;
    }
}