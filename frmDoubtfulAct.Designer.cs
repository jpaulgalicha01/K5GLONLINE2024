namespace K5GLONLINE
{
    partial class frmDoubtfulAct
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
            this.Refer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinMinDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnOI = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtrefer = new System.Windows.Forms.TextBox();
            this.btnDA = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Refer,
            this.MinMinDate,
            this.Bal});
            this.dgv1.Location = new System.Drawing.Point(23, 23);
            this.dgv1.Name = "dgv1";
            this.dgv1.Size = new System.Drawing.Size(400, 348);
            this.dgv1.TabIndex = 1;
            this.dgv1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellEnter);
            // 
            // Refer
            // 
            this.Refer.HeaderText = "Reference";
            this.Refer.Name = "Refer";
            this.Refer.Width = 130;
            // 
            // MinMinDate
            // 
            this.MinMinDate.HeaderText = "Date";
            this.MinMinDate.Name = "MinMinDate";
            // 
            // Bal
            // 
            this.Bal.HeaderText = "Amount";
            this.Bal.Name = "Bal";
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(23, 405);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 22);
            this.txtAmount.TabIndex = 2;
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter);
            this.txtAmount.Validating += new System.ComponentModel.CancelEventHandler(this.txtAmount_Validating);
            // 
            // btnOI
            // 
            this.btnOI.Location = new System.Drawing.Point(246, 405);
            this.btnOI.Name = "btnOI";
            this.btnOI.Size = new System.Drawing.Size(89, 23);
            this.btnOI.TabIndex = 4;
            this.btnOI.Text = "Other Income";
            this.btnOI.UseVisualStyleBackColor = true;
            this.btnOI.Click += new System.EventHandler(this.btnOI_Click);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(69, 387);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Amount:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtrefer
            // 
            this.txtrefer.Location = new System.Drawing.Point(245, 382);
            this.txtrefer.Name = "txtrefer";
            this.txtrefer.Size = new System.Drawing.Size(90, 20);
            this.txtrefer.TabIndex = 9;
            this.txtrefer.Visible = false;
            // 
            // btnDA
            // 
            this.btnDA.Location = new System.Drawing.Point(151, 405);
            this.btnDA.Name = "btnDA";
            this.btnDA.Size = new System.Drawing.Size(89, 23);
            this.btnDA.TabIndex = 10;
            this.btnDA.Text = "Doubtful Acct";
            this.btnDA.UseVisualStyleBackColor = true;
            this.btnDA.Click += new System.EventHandler(this.btnDA_Click);
            // 
            // frmDoubtfulAct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 440);
            this.Controls.Add(this.btnDA);
            this.Controls.Add(this.txtrefer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOI);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.dgv1);
            this.Name = "frmDoubtfulAct";
            this.Text = "Balance - Customer";
            this.Load += new System.EventHandler(this.frmDoubtfulAct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnOI;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtrefer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Refer;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinMinDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bal;
        private System.Windows.Forms.Button btnDA;
    }
}