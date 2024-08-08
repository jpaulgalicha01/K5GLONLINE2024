namespace K5GLONLINE
{
    partial class frmCAMainAcctEdit
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
            this.btnsave = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.txtAcctNo = new System.Windows.Forms.TextBox();
            this.txtTitleAcct = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboSearchActNo = new System.Windows.Forms.ComboBox();
            this.cboBSIS = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cboDRCR = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboUsage = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboBSClass = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cboALC = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Account Number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Account Title:";
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(290, 571);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 8;
            this.btnsave.Text = "&Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(371, 571);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 9;
            this.btnclose.Text = "&Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // txtAcctNo
            // 
            this.txtAcctNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcctNo.Location = new System.Drawing.Point(25, 137);
            this.txtAcctNo.Name = "txtAcctNo";
            this.txtAcctNo.Size = new System.Drawing.Size(421, 26);
            this.txtAcctNo.TabIndex = 1;
            this.txtAcctNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAcctNo_KeyDown);
            // 
            // txtTitleAcct
            // 
            this.txtTitleAcct.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitleAcct.Location = new System.Drawing.Point(25, 200);
            this.txtTitleAcct.Name = "txtTitleAcct";
            this.txtTitleAcct.Size = new System.Drawing.Size(418, 26);
            this.txtTitleAcct.TabIndex = 2;
            this.txtTitleAcct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTitleAcct_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(175, 19);
            this.label6.TabIndex = 22;
            this.label6.Text = "Search Account Number:";
            // 
            // cboSearchActNo
            // 
            this.cboSearchActNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSearchActNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSearchActNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSearchActNo.FormattingEnabled = true;
            this.cboSearchActNo.Location = new System.Drawing.Point(22, 42);
            this.cboSearchActNo.Name = "cboSearchActNo";
            this.cboSearchActNo.Size = new System.Drawing.Size(421, 27);
            this.cboSearchActNo.TabIndex = 0;
            this.cboSearchActNo.SelectedIndexChanged += new System.EventHandler(this.cboSearchActNo_SelectedIndexChanged);
            this.cboSearchActNo.Validating += new System.ComponentModel.CancelEventHandler(this.cboSearchActNo_Validating);
            // 
            // cboBSIS
            // 
            this.cboBSIS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboBSIS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBSIS.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBSIS.FormattingEnabled = true;
            this.cboBSIS.Location = new System.Drawing.Point(25, 267);
            this.cboBSIS.Name = "cboBSIS";
            this.cboBSIS.Size = new System.Drawing.Size(421, 27);
            this.cboBSIS.TabIndex = 23;
            this.cboBSIS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboBSIS_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(21, 245);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(165, 19);
            this.label9.TabIndex = 24;
            this.label9.Text = "BS or IS Classification:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(21, 311);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 19);
            this.label10.TabIndex = 26;
            this.label10.Text = "Debit or Credit:";
            // 
            // cboDRCR
            // 
            this.cboDRCR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDRCR.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDRCR.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDRCR.FormattingEnabled = true;
            this.cboDRCR.Location = new System.Drawing.Point(25, 332);
            this.cboDRCR.Name = "cboDRCR";
            this.cboDRCR.Size = new System.Drawing.Size(421, 27);
            this.cboDRCR.TabIndex = 25;
            this.cboDRCR.SelectedIndexChanged += new System.EventHandler(this.cboDRCR_SelectedIndexChanged);
            this.cboDRCR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboDRCR_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(21, 375);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 19);
            this.label11.TabIndex = 28;
            this.label11.Text = "Usage:";
            // 
            // cboUsage
            // 
            this.cboUsage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboUsage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboUsage.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUsage.FormattingEnabled = true;
            this.cboUsage.Location = new System.Drawing.Point(25, 396);
            this.cboUsage.Name = "cboUsage";
            this.cboUsage.Size = new System.Drawing.Size(421, 27);
            this.cboUsage.TabIndex = 27;
            this.cboUsage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboUsage_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(21, 439);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(128, 19);
            this.label12.TabIndex = 30;
            this.label12.Text = "BS Classification:";
            // 
            // cboBSClass
            // 
            this.cboBSClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboBSClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBSClass.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBSClass.FormattingEnabled = true;
            this.cboBSClass.Location = new System.Drawing.Point(25, 460);
            this.cboBSClass.Name = "cboBSClass";
            this.cboBSClass.Size = new System.Drawing.Size(421, 27);
            this.cboBSClass.TabIndex = 29;
            this.cboBSClass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboBSClass_KeyDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(21, 505);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(140, 19);
            this.label13.TabIndex = 32;
            this.label13.Text = "ALC Classification:";
            // 
            // cboALC
            // 
            this.cboALC.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboALC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboALC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboALC.FormattingEnabled = true;
            this.cboALC.Location = new System.Drawing.Point(25, 526);
            this.cboALC.Name = "cboALC";
            this.cboALC.Size = new System.Drawing.Size(421, 27);
            this.cboALC.TabIndex = 31;
            this.cboALC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboALC_KeyDown);
            // 
            // frmCAMainAcctEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 613);
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
            this.Controls.Add(this.cboSearchActNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTitleAcct);
            this.Controls.Add(this.txtAcctNo);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmCAMainAcctEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Account - Edit";
            this.Load += new System.EventHandler(this.frmCAPAAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.TextBox txtAcctNo;
        private System.Windows.Forms.TextBox txtTitleAcct;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboSearchActNo;
        private System.Windows.Forms.ComboBox cboBSIS;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboDRCR;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboUsage;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboBSClass;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboALC;
    }
}