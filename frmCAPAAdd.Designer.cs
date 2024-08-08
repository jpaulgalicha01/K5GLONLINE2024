namespace K5GLONLINE
{
    partial class frmCAPAAdd
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
            this.cboAcctNo = new System.Windows.Forms.ComboBox();
            this.cboD1Code = new System.Windows.Forms.ComboBox();
            this.cboD2Code = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboAcctNo
            // 
            this.cboAcctNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboAcctNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboAcctNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAcctNo.FormattingEnabled = true;
            this.cboAcctNo.Location = new System.Drawing.Point(66, 73);
            this.cboAcctNo.Name = "cboAcctNo";
            this.cboAcctNo.Size = new System.Drawing.Size(421, 27);
            this.cboAcctNo.TabIndex = 0;
            this.cboAcctNo.Validating += new System.ComponentModel.CancelEventHandler(this.cboAcctNo_Validating);
            // 
            // cboD1Code
            // 
            this.cboD1Code.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboD1Code.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboD1Code.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboD1Code.FormattingEnabled = true;
            this.cboD1Code.Location = new System.Drawing.Point(66, 158);
            this.cboD1Code.Name = "cboD1Code";
            this.cboD1Code.Size = new System.Drawing.Size(421, 27);
            this.cboD1Code.TabIndex = 1;
            this.cboD1Code.Validating += new System.ComponentModel.CancelEventHandler(this.cboD1Code_Validating);
            // 
            // cboD2Code
            // 
            this.cboD2Code.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboD2Code.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboD2Code.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboD2Code.FormattingEnabled = true;
            this.cboD2Code.Location = new System.Drawing.Point(66, 243);
            this.cboD2Code.Name = "cboD2Code";
            this.cboD2Code.Size = new System.Drawing.Size(421, 27);
            this.cboD2Code.TabIndex = 2;
            this.cboD2Code.Validating += new System.ComponentModel.CancelEventHandler(this.cboD2Code_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Account Title:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(62, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Department 1:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(62, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Department 2:";
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(319, 313);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 6;
            this.btnsave.Text = "&Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(412, 313);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 7;
            this.btnclose.Text = "&Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // frmCAPAAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 359);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboD2Code);
            this.Controls.Add(this.cboD1Code);
            this.Controls.Add(this.cboAcctNo);
            this.Name = "frmCAPAAdd";
            this.Text = "Posting Account - Add";
            this.Load += new System.EventHandler(this.frmCAPAAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboAcctNo;
        private System.Windows.Forms.ComboBox cboD1Code;
        private System.Windows.Forms.ComboBox cboD2Code;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnclose;
    }
}