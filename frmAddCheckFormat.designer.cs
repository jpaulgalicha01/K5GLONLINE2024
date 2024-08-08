
namespace K5GLONLINE
{
    partial class frmAddCheckFormat
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
            this.txtBankCode = new System.Windows.Forms.TextBox();
            this.txtBankName = new System.Windows.Forms.TextBox();
            this.txtYDate = new System.Windows.Forms.NumericUpDown();
            this.txtXDate = new System.Windows.Forms.NumericUpDown();
            this.txtXCustName = new System.Windows.Forms.NumericUpDown();
            this.txtYCustName = new System.Windows.Forms.NumericUpDown();
            this.txtXAmount = new System.Windows.Forms.NumericUpDown();
            this.txtYAmount = new System.Windows.Forms.NumericUpDown();
            this.txtXCompDoc = new System.Windows.Forms.NumericUpDown();
            this.txtYCompDoc = new System.Windows.Forms.NumericUpDown();
            this.txtXAmountWords = new System.Windows.Forms.NumericUpDown();
            this.txtYAmountWords = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtFontSize = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtYDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtXDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtXCustName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYCustName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtXAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtXCompDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYCompDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtXAmountWords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYAmountWords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBankCode
            // 
            this.txtBankCode.Enabled = false;
            this.txtBankCode.Location = new System.Drawing.Point(12, 12);
            this.txtBankCode.Name = "txtBankCode";
            this.txtBankCode.ReadOnly = true;
            this.txtBankCode.Size = new System.Drawing.Size(42, 20);
            this.txtBankCode.TabIndex = 0;
            // 
            // txtBankName
            // 
            this.txtBankName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBankName.Location = new System.Drawing.Point(12, 76);
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Size = new System.Drawing.Size(213, 26);
            this.txtBankName.TabIndex = 1;
            this.txtBankName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CellNextEnter);
            // 
            // txtYDate
            // 
            this.txtYDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYDate.Location = new System.Drawing.Point(163, 130);
            this.txtYDate.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtYDate.Name = "txtYDate";
            this.txtYDate.Size = new System.Drawing.Size(145, 26);
            this.txtYDate.TabIndex = 4;
            this.txtYDate.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.txtYDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CellNextEnter);
            // 
            // txtXDate
            // 
            this.txtXDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXDate.Location = new System.Drawing.Point(12, 130);
            this.txtXDate.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtXDate.Name = "txtXDate";
            this.txtXDate.Size = new System.Drawing.Size(145, 26);
            this.txtXDate.TabIndex = 3;
            this.txtXDate.Value = new decimal(new int[] {
            605,
            0,
            0,
            0});
            this.txtXDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CellNextEnter);
            // 
            // txtXCustName
            // 
            this.txtXCustName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXCustName.Location = new System.Drawing.Point(12, 191);
            this.txtXCustName.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtXCustName.Name = "txtXCustName";
            this.txtXCustName.Size = new System.Drawing.Size(145, 26);
            this.txtXCustName.TabIndex = 5;
            this.txtXCustName.Value = new decimal(new int[] {
            105,
            0,
            0,
            0});
            this.txtXCustName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CellNextEnter);
            // 
            // txtYCustName
            // 
            this.txtYCustName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYCustName.Location = new System.Drawing.Point(163, 191);
            this.txtYCustName.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtYCustName.Name = "txtYCustName";
            this.txtYCustName.Size = new System.Drawing.Size(145, 26);
            this.txtYCustName.TabIndex = 6;
            this.txtYCustName.Value = new decimal(new int[] {
            65,
            0,
            0,
            0});
            this.txtYCustName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CellNextEnter);
            // 
            // txtXAmount
            // 
            this.txtXAmount.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXAmount.Location = new System.Drawing.Point(12, 251);
            this.txtXAmount.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtXAmount.Name = "txtXAmount";
            this.txtXAmount.Size = new System.Drawing.Size(145, 26);
            this.txtXAmount.TabIndex = 7;
            this.txtXAmount.Value = new decimal(new int[] {
            605,
            0,
            0,
            0});
            this.txtXAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CellNextEnter);
            // 
            // txtYAmount
            // 
            this.txtYAmount.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYAmount.Location = new System.Drawing.Point(163, 251);
            this.txtYAmount.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtYAmount.Name = "txtYAmount";
            this.txtYAmount.Size = new System.Drawing.Size(145, 26);
            this.txtYAmount.TabIndex = 8;
            this.txtYAmount.Value = new decimal(new int[] {
            62,
            0,
            0,
            0});
            this.txtYAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CellNextEnter);
            // 
            // txtXCompDoc
            // 
            this.txtXCompDoc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXCompDoc.Location = new System.Drawing.Point(12, 369);
            this.txtXCompDoc.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtXCompDoc.Name = "txtXCompDoc";
            this.txtXCompDoc.Size = new System.Drawing.Size(145, 26);
            this.txtXCompDoc.TabIndex = 11;
            this.txtXCompDoc.Value = new decimal(new int[] {
            230,
            0,
            0,
            0});
            this.txtXCompDoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CellNextEnter);
            // 
            // txtYCompDoc
            // 
            this.txtYCompDoc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYCompDoc.Location = new System.Drawing.Point(163, 369);
            this.txtYCompDoc.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtYCompDoc.Name = "txtYCompDoc";
            this.txtYCompDoc.Size = new System.Drawing.Size(145, 26);
            this.txtYCompDoc.TabIndex = 12;
            this.txtYCompDoc.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.txtYCompDoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CellNextEnter);
            // 
            // txtXAmountWords
            // 
            this.txtXAmountWords.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXAmountWords.Location = new System.Drawing.Point(12, 309);
            this.txtXAmountWords.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtXAmountWords.Name = "txtXAmountWords";
            this.txtXAmountWords.Size = new System.Drawing.Size(145, 26);
            this.txtXAmountWords.TabIndex = 9;
            this.txtXAmountWords.Value = new decimal(new int[] {
            75,
            0,
            0,
            0});
            this.txtXAmountWords.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CellNextEnter);
            // 
            // txtYAmountWords
            // 
            this.txtYAmountWords.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYAmountWords.Location = new System.Drawing.Point(163, 309);
            this.txtYAmountWords.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtYAmountWords.Name = "txtYAmountWords";
            this.txtYAmountWords.Size = new System.Drawing.Size(145, 26);
            this.txtYAmountWords.TabIndex = 10;
            this.txtYAmountWords.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.txtYAmountWords.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CellNextEnter);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(156, 416);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(71, 35);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CellNextEnter);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(233, 416);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(71, 35);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 19;
            this.label1.Text = "Bank Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "X-Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(160, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 21;
            this.label3.Text = "Y-Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 15);
            this.label4.TabIndex = 22;
            this.label4.Text = "X-Customer Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(160, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 15);
            this.label5.TabIndex = 23;
            this.label5.Text = "Y-Customer Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 15);
            this.label6.TabIndex = 24;
            this.label6.Text = "X-Amount";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(160, 234);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 15);
            this.label7.TabIndex = 25;
            this.label7.Text = "Y-Amount";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 292);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 15);
            this.label8.TabIndex = 26;
            this.label8.Text = "X-Amount in words";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(160, 292);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 15);
            this.label9.TabIndex = 27;
            this.label9.Text = "Y-Amount in words";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 352);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 15);
            this.label10.TabIndex = 28;
            this.label10.Text = "X-CompDoc";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(160, 352);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 15);
            this.label11.TabIndex = 29;
            this.label11.Text = "Y-CompDoc";
            // 
            // txtFontSize
            // 
            this.txtFontSize.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFontSize.Location = new System.Drawing.Point(233, 76);
            this.txtFontSize.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtFontSize.Name = "txtFontSize";
            this.txtFontSize.Size = new System.Drawing.Size(75, 26);
            this.txtFontSize.TabIndex = 2;
            this.txtFontSize.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.txtFontSize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CellNextEnter);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(230, 59);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 15);
            this.label12.TabIndex = 31;
            this.label12.Text = "Font Size";
            // 
            // frmAddCheckFormat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(320, 462);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtFontSize);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtXCompDoc);
            this.Controls.Add(this.txtYCompDoc);
            this.Controls.Add(this.txtXAmountWords);
            this.Controls.Add(this.txtYAmountWords);
            this.Controls.Add(this.txtXAmount);
            this.Controls.Add(this.txtYAmount);
            this.Controls.Add(this.txtXCustName);
            this.Controls.Add(this.txtYCustName);
            this.Controls.Add(this.txtXDate);
            this.Controls.Add(this.txtYDate);
            this.Controls.Add(this.txtBankName);
            this.Controls.Add(this.txtBankCode);
            this.Name = "frmAddCheckFormat";
            this.Text = "New Check Format";
            this.Load += new System.EventHandler(this.frmAddCheckFormat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtYDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtXDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtXCustName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYCustName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtXAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtXCompDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYCompDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtXAmountWords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYAmountWords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFontSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBankCode;
        private System.Windows.Forms.TextBox txtBankName;
        private System.Windows.Forms.NumericUpDown txtYDate;
        private System.Windows.Forms.NumericUpDown txtXDate;
        private System.Windows.Forms.NumericUpDown txtXCustName;
        private System.Windows.Forms.NumericUpDown txtYCustName;
        private System.Windows.Forms.NumericUpDown txtXAmount;
        private System.Windows.Forms.NumericUpDown txtYAmount;
        private System.Windows.Forms.NumericUpDown txtXCompDoc;
        private System.Windows.Forms.NumericUpDown txtYCompDoc;
        private System.Windows.Forms.NumericUpDown txtXAmountWords;
        private System.Windows.Forms.NumericUpDown txtYAmountWords;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown txtFontSize;
        private System.Windows.Forms.Label label12;
    }
}