namespace K5GLONLINE
{
    partial class frmCAMainAcctAdd
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.txtAcctNo = new System.Windows.Forms.TextBox();
            this.txtTitleAcct = new System.Windows.Forms.TextBox();
            this.cboFCCode = new System.Windows.Forms.ComboBox();
            this.cboFSClass = new System.Windows.Forms.ComboBox();
            this.cboNormalBal = new System.Windows.Forms.ComboBox();
            this.cboSCCode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboUsageCode = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cboALC = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboBSClass = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboUsage = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboDRCR = new System.Windows.Forms.ComboBox();
            this.cboBSIS = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Account Number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Account Title:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(455, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "FS Classification:";
            this.label3.Visible = false;
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(290, 478);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 7;
            this.btnsave.Text = "&Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(371, 478);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 8;
            this.btnclose.Text = "&Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // txtAcctNo
            // 
            this.txtAcctNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcctNo.Location = new System.Drawing.Point(25, 44);
            this.txtAcctNo.Name = "txtAcctNo";
            this.txtAcctNo.Size = new System.Drawing.Size(421, 26);
            this.txtAcctNo.TabIndex = 0;
            this.txtAcctNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAcctNo_KeyDown);
            // 
            // txtTitleAcct
            // 
            this.txtTitleAcct.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitleAcct.Location = new System.Drawing.Point(25, 107);
            this.txtTitleAcct.Name = "txtTitleAcct";
            this.txtTitleAcct.Size = new System.Drawing.Size(418, 26);
            this.txtTitleAcct.TabIndex = 1;
            this.txtTitleAcct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTitleAcct_KeyDown);
            // 
            // cboFCCode
            // 
            this.cboFCCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboFCCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboFCCode.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFCCode.FormattingEnabled = true;
            this.cboFCCode.Location = new System.Drawing.Point(459, 234);
            this.cboFCCode.Name = "cboFCCode";
            this.cboFCCode.Size = new System.Drawing.Size(421, 27);
            this.cboFCCode.TabIndex = 3;
            this.cboFCCode.Visible = false;
            this.cboFCCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboFCCode_KeyDown);
            this.cboFCCode.Validating += new System.ComponentModel.CancelEventHandler(this.cboFCCode_Validating);
            // 
            // cboFSClass
            // 
            this.cboFSClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboFSClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboFSClass.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFSClass.FormattingEnabled = true;
            this.cboFSClass.Location = new System.Drawing.Point(459, 170);
            this.cboFSClass.Name = "cboFSClass";
            this.cboFSClass.Size = new System.Drawing.Size(421, 27);
            this.cboFSClass.TabIndex = 2;
            this.cboFSClass.Visible = false;
            this.cboFSClass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboFSClass_KeyDown);
            this.cboFSClass.Validating += new System.ComponentModel.CancelEventHandler(this.cboFSClass_Validating);
            // 
            // cboNormalBal
            // 
            this.cboNormalBal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboNormalBal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboNormalBal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNormalBal.FormattingEnabled = true;
            this.cboNormalBal.Location = new System.Drawing.Point(459, 362);
            this.cboNormalBal.Name = "cboNormalBal";
            this.cboNormalBal.Size = new System.Drawing.Size(421, 27);
            this.cboNormalBal.TabIndex = 5;
            this.cboNormalBal.Visible = false;
            this.cboNormalBal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboNormalBal_KeyDown);
            this.cboNormalBal.Validating += new System.ComponentModel.CancelEventHandler(this.cboNormalBal_Validating);
            // 
            // cboSCCode
            // 
            this.cboSCCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSCCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSCCode.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSCCode.FormattingEnabled = true;
            this.cboSCCode.Location = new System.Drawing.Point(459, 298);
            this.cboSCCode.Name = "cboSCCode";
            this.cboSCCode.Size = new System.Drawing.Size(421, 27);
            this.cboSCCode.TabIndex = 4;
            this.cboSCCode.Visible = false;
            this.cboSCCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboSCCode_KeyDown);
            this.cboSCCode.Validating += new System.ComponentModel.CancelEventHandler(this.cboSCCode_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(455, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 19);
            this.label4.TabIndex = 17;
            this.label4.Text = "Second Caption:";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(455, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 19);
            this.label5.TabIndex = 16;
            this.label5.Text = "First Caption:";
            this.label5.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(452, 341);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 19);
            this.label7.TabIndex = 18;
            this.label7.Text = "Normal Balance:";
            this.label7.Visible = false;
            // 
            // cboUsageCode
            // 
            this.cboUsageCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboUsageCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboUsageCode.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUsageCode.FormattingEnabled = true;
            this.cboUsageCode.Location = new System.Drawing.Point(459, 426);
            this.cboUsageCode.Name = "cboUsageCode";
            this.cboUsageCode.Size = new System.Drawing.Size(421, 27);
            this.cboUsageCode.TabIndex = 6;
            this.cboUsageCode.Visible = false;
            this.cboUsageCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboUsageCode_KeyDown);
            this.cboUsageCode.Validating += new System.ComponentModel.CancelEventHandler(this.cboUsageCode_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(455, 405);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 19);
            this.label8.TabIndex = 20;
            this.label8.Text = "Usage:";
            this.label8.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(21, 408);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(140, 19);
            this.label13.TabIndex = 42;
            this.label13.Text = "ALC Classification:";
            // 
            // cboALC
            // 
            this.cboALC.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboALC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboALC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboALC.FormattingEnabled = true;
            this.cboALC.Location = new System.Drawing.Point(25, 429);
            this.cboALC.Name = "cboALC";
            this.cboALC.Size = new System.Drawing.Size(418, 27);
            this.cboALC.TabIndex = 41;
            this.cboALC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboALC_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(21, 342);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(128, 19);
            this.label12.TabIndex = 40;
            this.label12.Text = "BS Classification:";
            // 
            // cboBSClass
            // 
            this.cboBSClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboBSClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBSClass.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBSClass.FormattingEnabled = true;
            this.cboBSClass.Location = new System.Drawing.Point(25, 363);
            this.cboBSClass.Name = "cboBSClass";
            this.cboBSClass.Size = new System.Drawing.Size(418, 27);
            this.cboBSClass.TabIndex = 39;
            this.cboBSClass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboBSClass_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(21, 278);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 19);
            this.label11.TabIndex = 38;
            this.label11.Text = "Usage:";
            // 
            // cboUsage
            // 
            this.cboUsage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboUsage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboUsage.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUsage.FormattingEnabled = true;
            this.cboUsage.Location = new System.Drawing.Point(25, 299);
            this.cboUsage.Name = "cboUsage";
            this.cboUsage.Size = new System.Drawing.Size(418, 27);
            this.cboUsage.TabIndex = 37;
            this.cboUsage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboUsage_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(21, 214);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 19);
            this.label10.TabIndex = 36;
            this.label10.Text = "Debit or Credit:";
            // 
            // cboDRCR
            // 
            this.cboDRCR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDRCR.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDRCR.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDRCR.FormattingEnabled = true;
            this.cboDRCR.Location = new System.Drawing.Point(25, 235);
            this.cboDRCR.Name = "cboDRCR";
            this.cboDRCR.Size = new System.Drawing.Size(418, 27);
            this.cboDRCR.TabIndex = 35;
            this.cboDRCR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboDRCR_KeyDown);
            // 
            // cboBSIS
            // 
            this.cboBSIS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboBSIS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBSIS.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBSIS.FormattingEnabled = true;
            this.cboBSIS.Location = new System.Drawing.Point(25, 170);
            this.cboBSIS.Name = "cboBSIS";
            this.cboBSIS.Size = new System.Drawing.Size(418, 27);
            this.cboBSIS.TabIndex = 33;
            this.cboBSIS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboBSIS_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(21, 148);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(165, 19);
            this.label9.TabIndex = 34;
            this.label9.Text = "BS or IS Classification:";
            // 
            // frmCAMainAcctAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 522);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cboALC);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cboBSClass);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cboUsage);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cboDRCR);
            this.Controls.Add(this.cboBSIS);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboUsageCode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboNormalBal);
            this.Controls.Add(this.cboSCCode);
            this.Controls.Add(this.cboFCCode);
            this.Controls.Add(this.cboFSClass);
            this.Controls.Add(this.txtTitleAcct);
            this.Controls.Add(this.txtAcctNo);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmCAMainAcctAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Account - Add";
            this.Load += new System.EventHandler(this.frmCAPAAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.TextBox txtAcctNo;
        private System.Windows.Forms.TextBox txtTitleAcct;
        private System.Windows.Forms.ComboBox cboFCCode;
        private System.Windows.Forms.ComboBox cboFSClass;
        private System.Windows.Forms.ComboBox cboNormalBal;
        private System.Windows.Forms.ComboBox cboSCCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboUsageCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboALC;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboBSClass;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboUsage;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboDRCR;
        private System.Windows.Forms.ComboBox cboBSIS;
        private System.Windows.Forms.Label label9;
    }
}