namespace K5GLONLINE
{
    partial class frmCustomerNameAdd
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
            this.txtCustCode = new System.Windows.Forms.TextBox();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboSellingPrice = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtContactPerson = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCreditLimit = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTerm = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTIN = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboRegion = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboSalesman = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboGeographical = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboChannel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txtBusinessType = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCustCode
            // 
            this.txtCustCode.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustCode.Location = new System.Drawing.Point(717, 12);
            this.txtCustCode.Name = "txtCustCode";
            this.txtCustCode.ReadOnly = true;
            this.txtCustCode.Size = new System.Drawing.Size(91, 26);
            this.txtCustCode.TabIndex = 4;
            this.txtCustCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCustName
            // 
            this.txtCustName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustName.Location = new System.Drawing.Point(21, 60);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.Size = new System.Drawing.Size(343, 26);
            this.txtCustName.TabIndex = 0;
            this.txtCustName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBusinessType);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.cboSellingPrice);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtContactPerson);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtCreditLimit);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtTerm);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtTIN);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cboRegion);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cboSalesman);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboGeographical);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboChannel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.txtContactNo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCustName);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(796, 433);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data";
            // 
            // cboSellingPrice
            // 
            this.cboSellingPrice.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSellingPrice.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSellingPrice.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.cboSellingPrice.FormattingEnabled = true;
            this.cboSellingPrice.Location = new System.Drawing.Point(422, 274);
            this.cboSellingPrice.Name = "cboSellingPrice";
            this.cboSellingPrice.Size = new System.Drawing.Size(343, 27);
            this.cboSellingPrice.TabIndex = 11;
            this.cboSellingPrice.Validating += new System.ComponentModel.CancelEventHandler(this.cboSellingPrice_Validating);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(418, 252);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(146, 19);
            this.label12.TabIndex = 32;
            this.label12.Text = "Selling Price Option:";
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContactPerson.Location = new System.Drawing.Point(422, 220);
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.Size = new System.Drawing.Size(343, 26);
            this.txtContactPerson.TabIndex = 10;
            this.txtContactPerson.Text = "NA";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(418, 198);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 19);
            this.label11.TabIndex = 30;
            this.label11.Text = "Contact Person:";
            // 
            // txtCreditLimit
            // 
            this.txtCreditLimit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditLimit.Location = new System.Drawing.Point(422, 166);
            this.txtCreditLimit.Name = "txtCreditLimit";
            this.txtCreditLimit.Size = new System.Drawing.Size(343, 26);
            this.txtCreditLimit.TabIndex = 9;
            this.txtCreditLimit.Text = "0.00";
            this.txtCreditLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCreditLimit.Validating += new System.ComponentModel.CancelEventHandler(this.txtCreditLimit_Validating);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(418, 144);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 19);
            this.label10.TabIndex = 28;
            this.label10.Text = "Credit Limit:";
            // 
            // txtTerm
            // 
            this.txtTerm.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTerm.Location = new System.Drawing.Point(422, 113);
            this.txtTerm.Name = "txtTerm";
            this.txtTerm.Size = new System.Drawing.Size(343, 26);
            this.txtTerm.TabIndex = 8;
            this.txtTerm.Text = "0";
            this.txtTerm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTerm.Validating += new System.ComponentModel.CancelEventHandler(this.txtTerm_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(418, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 19);
            this.label9.TabIndex = 26;
            this.label9.Text = "Term:";
            // 
            // txtTIN
            // 
            this.txtTIN.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTIN.Location = new System.Drawing.Point(422, 60);
            this.txtTIN.Name = "txtTIN";
            this.txtTIN.Size = new System.Drawing.Size(343, 26);
            this.txtTIN.TabIndex = 7;
            this.txtTIN.Text = "NA";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(418, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 19);
            this.label8.TabIndex = 24;
            this.label8.Text = "TIN:";
            // 
            // cboRegion
            // 
            this.cboRegion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboRegion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRegion.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.cboRegion.FormattingEnabled = true;
            this.cboRegion.Location = new System.Drawing.Point(21, 326);
            this.cboRegion.Name = "cboRegion";
            this.cboRegion.Size = new System.Drawing.Size(343, 27);
            this.cboRegion.TabIndex = 5;
            this.cboRegion.Validating += new System.ComponentModel.CancelEventHandler(this.cboRegion_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 304);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 19);
            this.label7.TabIndex = 21;
            this.label7.Text = "Region:";
            // 
            // cboSalesman
            // 
            this.cboSalesman.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSalesman.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSalesman.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.cboSalesman.FormattingEnabled = true;
            this.cboSalesman.Location = new System.Drawing.Point(21, 274);
            this.cboSalesman.Name = "cboSalesman";
            this.cboSalesman.Size = new System.Drawing.Size(343, 27);
            this.cboSalesman.TabIndex = 4;
            this.cboSalesman.Validating += new System.ComponentModel.CancelEventHandler(this.cboSalesman_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 19);
            this.label5.TabIndex = 19;
            this.label5.Text = "Salesman:";
            // 
            // cboGeographical
            // 
            this.cboGeographical.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboGeographical.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboGeographical.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.cboGeographical.FormattingEnabled = true;
            this.cboGeographical.Location = new System.Drawing.Point(21, 220);
            this.cboGeographical.Name = "cboGeographical";
            this.cboGeographical.Size = new System.Drawing.Size(343, 27);
            this.cboGeographical.TabIndex = 3;
            this.cboGeographical.Validating += new System.ComponentModel.CancelEventHandler(this.cboGeographical_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 19);
            this.label4.TabIndex = 17;
            this.label4.Text = "Geographical Area:";
            // 
            // cboChannel
            // 
            this.cboChannel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboChannel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboChannel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.cboChannel.FormattingEnabled = true;
            this.cboChannel.Location = new System.Drawing.Point(21, 166);
            this.cboChannel.Name = "cboChannel";
            this.cboChannel.Size = new System.Drawing.Size(343, 27);
            this.cboChannel.TabIndex = 2;
            this.cboChannel.Validating += new System.ComponentModel.CancelEventHandler(this.cboChannel_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 19);
            this.label2.TabIndex = 15;
            this.label2.Text = "Channel:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(418, 304);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 19);
            this.label6.TabIndex = 14;
            this.label6.Text = "Address:";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(422, 326);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(343, 76);
            this.txtAddress.TabIndex = 12;
            this.txtAddress.Text = "NA";
            this.txtAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter);
            // 
            // txtContactNo
            // 
            this.txtContactNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContactNo.Location = new System.Drawing.Point(21, 113);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(343, 26);
            this.txtContactNo.TabIndex = 1;
            this.txtContactNo.Text = "NA";
            this.txtContactNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "Contact No.:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(652, 506);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(733, 506);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 353);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(111, 19);
            this.label13.TabIndex = 34;
            this.label13.Text = "Business Type:";
            // 
            // txtBusinessType
            // 
            this.txtBusinessType.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusinessType.Location = new System.Drawing.Point(21, 375);
            this.txtBusinessType.Name = "txtBusinessType";
            this.txtBusinessType.Size = new System.Drawing.Size(343, 26);
            this.txtBusinessType.TabIndex = 6;
            this.txtBusinessType.Text = "NA";
            // 
            // frmCustomerNameAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 551);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtCustCode);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCustomerNameAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer - Add";
            this.Load += new System.EventHandler(this.frmNameAdd_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCustCode;
        private System.Windows.Forms.TextBox txtCustName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboSellingPrice;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtContactPerson;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCreditLimit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTerm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTIN;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboRegion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboSalesman;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboGeographical;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboChannel;
        private System.Windows.Forms.TextBox txtBusinessType;
        private System.Windows.Forms.Label label13;
    }
}