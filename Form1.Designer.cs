namespace K5GLONLINE
{
    partial class Form1
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
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.txtPasswordExist = new System.Windows.Forms.TextBox();
            this.txtUserExist = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblpassword = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtGroupCode = new System.Windows.Forms.TextBox();
            this.txtUserCode = new System.Windows.Forms.TextBox();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.cbConnectMode = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCNCode = new System.Windows.Forms.TextBox();
            this.cboUpdates = new System.Windows.Forms.ComboBox();
            this.rbPLDT = new System.Windows.Forms.RadioButton();
            this.rbGLOBE = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtaddress
            // 
            this.txtaddress.Location = new System.Drawing.Point(211, 11);
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(46, 20);
            this.txtaddress.TabIndex = 21;
            this.txtaddress.Visible = false;
            this.txtaddress.TextChanged += new System.EventHandler(this.txtaddress_TextChanged);
            // 
            // txtCompany
            // 
            this.txtCompany.Location = new System.Drawing.Point(260, 11);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(46, 20);
            this.txtCompany.TabIndex = 20;
            this.txtCompany.Visible = false;
            // 
            // txtPasswordExist
            // 
            this.txtPasswordExist.Location = new System.Drawing.Point(104, 11);
            this.txtPasswordExist.Name = "txtPasswordExist";
            this.txtPasswordExist.Size = new System.Drawing.Size(53, 20);
            this.txtPasswordExist.TabIndex = 19;
            this.txtPasswordExist.Visible = false;
            // 
            // txtUserExist
            // 
            this.txtUserExist.Location = new System.Drawing.Point(163, 11);
            this.txtUserExist.Name = "txtUserExist";
            this.txtUserExist.Size = new System.Drawing.Size(53, 20);
            this.txtUserExist.TabIndex = 18;
            this.txtUserExist.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(198, 81);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(108, 32);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(198, 43);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(108, 32);
            this.btnOk.TabIndex = 16;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblpassword
            // 
            this.lblpassword.AutoSize = true;
            this.lblpassword.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpassword.Location = new System.Drawing.Point(18, 69);
            this.lblpassword.Name = "lblpassword";
            this.lblpassword.Size = new System.Drawing.Size(95, 22);
            this.lblpassword.TabIndex = 15;
            this.lblpassword.Text = "Password:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(18, 13);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(63, 22);
            this.lblName.TabIndex = 14;
            this.lblName.Text = "Name:";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(22, 94);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(162, 29);
            this.txtPassword.TabIndex = 13;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(22, 37);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(162, 29);
            this.txtUserName.TabIndex = 12;
            this.txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserName_KeyDown);
            // 
            // txtGroupCode
            // 
            this.txtGroupCode.Location = new System.Drawing.Point(106, 68);
            this.txtGroupCode.Name = "txtGroupCode";
            this.txtGroupCode.Size = new System.Drawing.Size(53, 20);
            this.txtGroupCode.TabIndex = 23;
            this.txtGroupCode.Visible = false;
            // 
            // txtUserCode
            // 
            this.txtUserCode.Location = new System.Drawing.Point(174, 148);
            this.txtUserCode.Name = "txtUserCode";
            this.txtUserCode.Size = new System.Drawing.Size(114, 20);
            this.txtUserCode.TabIndex = 22;
            this.txtUserCode.Visible = false;
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(38, 148);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(240, 20);
            this.txtServerName.TabIndex = 29;
            this.txtServerName.Text = "WINSERVER";
            this.txtServerName.Visible = false;
            // 
            // cbConnectMode
            // 
            this.cbConnectMode.AutoSize = true;
            this.cbConnectMode.Location = new System.Drawing.Point(22, 166);
            this.cbConnectMode.Name = "cbConnectMode";
            this.cbConnectMode.Size = new System.Drawing.Size(119, 17);
            this.cbConnectMode.TabIndex = 30;
            this.cbConnectMode.Text = "Online Connection?";
            this.cbConnectMode.UseVisualStyleBackColor = true;
            this.cbConnectMode.CheckedChanged += new System.EventHandler(this.cbConnectMode_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(246, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "11/07/2023";
            this.label1.Visible = false;
            // 
            // txtCNCode
            // 
            this.txtCNCode.Location = new System.Drawing.Point(147, 180);
            this.txtCNCode.Name = "txtCNCode";
            this.txtCNCode.Size = new System.Drawing.Size(53, 20);
            this.txtCNCode.TabIndex = 32;
            this.txtCNCode.Visible = false;
            // 
            // cboUpdates
            // 
            this.cboUpdates.FormattingEnabled = true;
            this.cboUpdates.Items.AddRange(new object[] {
            "042523 - SO, TF, CI, CS zero cost posting, add FreeGoods field tblStocks",
            "042523 - report - sales - sales all sku detail add"});
            this.cboUpdates.Location = new System.Drawing.Point(22, 139);
            this.cboUpdates.Name = "cboUpdates";
            this.cboUpdates.Size = new System.Drawing.Size(121, 21);
            this.cboUpdates.TabIndex = 33;
            this.cboUpdates.Visible = false;
            // 
            // rbPLDT
            // 
            this.rbPLDT.AutoSize = true;
            this.rbPLDT.Location = new System.Drawing.Point(22, 190);
            this.rbPLDT.Name = "rbPLDT";
            this.rbPLDT.Size = new System.Drawing.Size(53, 17);
            this.rbPLDT.TabIndex = 34;
            this.rbPLDT.Text = "PLDT";
            this.rbPLDT.UseVisualStyleBackColor = true;
            this.rbPLDT.Visible = false;
            this.rbPLDT.CheckedChanged += new System.EventHandler(this.rbPLDT_CheckedChanged);
            // 
            // rbGLOBE
            // 
            this.rbGLOBE.AutoSize = true;
            this.rbGLOBE.Location = new System.Drawing.Point(115, 190);
            this.rbGLOBE.Name = "rbGLOBE";
            this.rbGLOBE.Size = new System.Drawing.Size(61, 17);
            this.rbGLOBE.TabIndex = 35;
            this.rbGLOBE.Text = "GLOBE";
            this.rbGLOBE.UseVisualStyleBackColor = true;
            this.rbGLOBE.Visible = false;
            this.rbGLOBE.CheckedChanged += new System.EventHandler(this.rbGLOBE_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 22);
            this.label2.TabIndex = 36;
            this.label2.Text = "Version:";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(99, 130);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(35, 22);
            this.lblVersion.TabIndex = 37;
            this.lblVersion.Text = "3.6";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(317, 243);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rbGLOBE);
            this.Controls.Add(this.rbPLDT);
            this.Controls.Add(this.cboUpdates);
            this.Controls.Add(this.txtCNCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbConnectMode);
            this.Controls.Add(this.txtServerName);
            this.Controls.Add(this.txtGroupCode);
            this.Controls.Add(this.txtUserCode);
            this.Controls.Add(this.txtaddress);
            this.Controls.Add(this.txtCompany);
            this.Controls.Add(this.txtPasswordExist);
            this.Controls.Add(this.txtUserExist);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblpassword);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.TextBox txtPasswordExist;
        private System.Windows.Forms.TextBox txtUserExist;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblpassword;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtGroupCode;
        private System.Windows.Forms.TextBox txtUserCode;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.CheckBox cbConnectMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCNCode;
        private System.Windows.Forms.ComboBox cboUpdates;
        private System.Windows.Forms.RadioButton rbPLDT;
        private System.Windows.Forms.RadioButton rbGLOBE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblVersion;
    }
}

