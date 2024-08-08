namespace K5GLONLINE
{
    partial class frmSearchEntry
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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cboPA = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbAccountNo = new System.Windows.Forms.CheckBox();
            this.rbTDate = new System.Windows.Forms.RadioButton();
            this.rbIC = new System.Windows.Forms.RadioButton();
            this.rbRefer = new System.Windows.Forms.RadioButton();
            this.rbDebit = new System.Windows.Forms.RadioButton();
            this.rbCredit = new System.Windows.Forms.RadioButton();
            this.rbRemarks = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv1
            // 
            this.dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(12, 73);
            this.dgv1.Name = "dgv1";
            this.dgv1.Size = new System.Drawing.Size(1228, 555);
            this.dgv1.TabIndex = 0;
            // 
            // btnclose
            // 
            this.btnclose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnclose.Location = new System.Drawing.Point(1165, 605);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 4;
            this.btnclose.Text = "&Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Visible = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnsave
            // 
            this.btnsave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsave.Location = new System.Drawing.Point(1084, 605);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 3;
            this.btnsave.Text = "&Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Visible = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(669, 20);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(443, 29);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Validating += new System.ComponentModel.CancelEventHandler(this.txtSearch_Validating);
            // 
            // cboPA
            // 
            this.cboPA.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPA.FormattingEnabled = true;
            this.cboPA.Location = new System.Drawing.Point(148, 20);
            this.cboPA.Name = "cboPA";
            this.cboPA.Size = new System.Drawing.Size(417, 29);
            this.cboPA.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(586, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 22);
            this.label1.TabIndex = 7;
            this.label1.Text = "Search :";
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Location = new System.Drawing.Point(1149, 14);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(91, 38);
            this.btnView.TabIndex = 8;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 22);
            this.label2.TabIndex = 9;
            this.label2.Text = "Account Title :";
            // 
            // cbAccountNo
            // 
            this.cbAccountNo.AutoSize = true;
            this.cbAccountNo.Checked = true;
            this.cbAccountNo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAccountNo.Location = new System.Drawing.Point(148, 55);
            this.cbAccountNo.Name = "cbAccountNo";
            this.cbAccountNo.Size = new System.Drawing.Size(106, 17);
            this.cbAccountNo.TabIndex = 142;
            this.cbAccountNo.Text = "Account Number";
            this.cbAccountNo.UseVisualStyleBackColor = true;
            this.cbAccountNo.CheckedChanged += new System.EventHandler(this.cbAccountNo_CheckedChanged);
            // 
            // rbTDate
            // 
            this.rbTDate.AutoSize = true;
            this.rbTDate.Checked = true;
            this.rbTDate.Location = new System.Drawing.Point(669, 54);
            this.rbTDate.Name = "rbTDate";
            this.rbTDate.Size = new System.Drawing.Size(48, 17);
            this.rbTDate.TabIndex = 143;
            this.rbTDate.Text = "Date";
            this.rbTDate.UseVisualStyleBackColor = true;
            // 
            // rbIC
            // 
            this.rbIC.AutoSize = true;
            this.rbIC.Location = new System.Drawing.Point(740, 54);
            this.rbIC.Name = "rbIC";
            this.rbIC.Size = new System.Drawing.Size(35, 17);
            this.rbIC.TabIndex = 144;
            this.rbIC.Text = "IC";
            this.rbIC.UseVisualStyleBackColor = true;
            // 
            // rbRefer
            // 
            this.rbRefer.AutoSize = true;
            this.rbRefer.Location = new System.Drawing.Point(808, 54);
            this.rbRefer.Name = "rbRefer";
            this.rbRefer.Size = new System.Drawing.Size(51, 17);
            this.rbRefer.TabIndex = 145;
            this.rbRefer.Text = "Refer";
            this.rbRefer.UseVisualStyleBackColor = true;
            // 
            // rbDebit
            // 
            this.rbDebit.AutoSize = true;
            this.rbDebit.Location = new System.Drawing.Point(892, 54);
            this.rbDebit.Name = "rbDebit";
            this.rbDebit.Size = new System.Drawing.Size(50, 17);
            this.rbDebit.TabIndex = 146;
            this.rbDebit.Text = "Debit";
            this.rbDebit.UseVisualStyleBackColor = true;
            // 
            // rbCredit
            // 
            this.rbCredit.AutoSize = true;
            this.rbCredit.Location = new System.Drawing.Point(972, 54);
            this.rbCredit.Name = "rbCredit";
            this.rbCredit.Size = new System.Drawing.Size(52, 17);
            this.rbCredit.TabIndex = 147;
            this.rbCredit.Text = "Credit";
            this.rbCredit.UseVisualStyleBackColor = true;
            // 
            // rbRemarks
            // 
            this.rbRemarks.AutoSize = true;
            this.rbRemarks.Location = new System.Drawing.Point(1045, 54);
            this.rbRemarks.Name = "rbRemarks";
            this.rbRemarks.Size = new System.Drawing.Size(67, 17);
            this.rbRemarks.TabIndex = 148;
            this.rbRemarks.Text = "Remarks";
            this.rbRemarks.UseVisualStyleBackColor = true;
            // 
            // frmSearchEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 640);
            this.Controls.Add(this.rbRemarks);
            this.Controls.Add(this.rbCredit);
            this.Controls.Add(this.rbDebit);
            this.Controls.Add(this.rbRefer);
            this.Controls.Add(this.rbIC);
            this.Controls.Add(this.rbTDate);
            this.Controls.Add(this.cbAccountNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboPA);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.dgv1);
            this.Name = "frmSearchEntry";
            this.Text = "Search Entry";
            this.Load += new System.EventHandler(this.frmNameEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cboPA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbAccountNo;
        private System.Windows.Forms.RadioButton rbTDate;
        private System.Windows.Forms.RadioButton rbIC;
        private System.Windows.Forms.RadioButton rbRefer;
        private System.Windows.Forms.RadioButton rbDebit;
        private System.Windows.Forms.RadioButton rbCredit;
        private System.Windows.Forms.RadioButton rbRemarks;
    }
}