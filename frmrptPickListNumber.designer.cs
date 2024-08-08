namespace K5GLONLINE
{
    partial class frmrptPickListNumber
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.txtCAmount = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtremarks = new System.Windows.Forms.TextBox();
            this.txtDocNum = new System.Windows.Forms.TextBox();
            this.cbortprint = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPreview = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboCNCode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(14, 45);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1141, 473);
            this.crystalReportViewer1.TabIndex = 4;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // txtCAmount
            // 
            this.txtCAmount.Location = new System.Drawing.Point(529, 8);
            this.txtCAmount.Name = "txtCAmount";
            this.txtCAmount.Size = new System.Drawing.Size(54, 20);
            this.txtCAmount.TabIndex = 48;
            this.txtCAmount.Visible = false;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(419, 8);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(54, 20);
            this.txtName.TabIndex = 49;
            this.txtName.Visible = false;
            // 
            // txtremarks
            // 
            this.txtremarks.Location = new System.Drawing.Point(954, 8);
            this.txtremarks.Name = "txtremarks";
            this.txtremarks.Size = new System.Drawing.Size(54, 20);
            this.txtremarks.TabIndex = 50;
            this.txtremarks.Visible = false;
            // 
            // txtDocNum
            // 
            this.txtDocNum.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocNum.Location = new System.Drawing.Point(483, 13);
            this.txtDocNum.Name = "txtDocNum";
            this.txtDocNum.Size = new System.Drawing.Size(100, 26);
            this.txtDocNum.TabIndex = 1;
            this.txtDocNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter1);
            // 
            // cbortprint
            // 
            this.cbortprint.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbortprint.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbortprint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbortprint.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbortprint.FormattingEnabled = true;
            this.cbortprint.Items.AddRange(new object[] {
            "Pick List - SO"});
            this.cbortprint.Location = new System.Drawing.Point(120, 12);
            this.cbortprint.Name = "cbortprint";
            this.cbortprint.Size = new System.Drawing.Size(289, 27);
            this.cbortprint.TabIndex = 0;
            this.cbortprint.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter2);
            this.cbortprint.Leave += new System.EventHandler(this.cbortprint_Leave);
            this.cbortprint.Validating += new System.ComponentModel.CancelEventHandler(this.cbortprint_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(415, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 19);
            this.label4.TabIndex = 64;
            this.label4.Text = "Number:";
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Location = new System.Drawing.Point(997, 16);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 3;
            this.btnPreview.Text = "&Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 19);
            this.label1.TabIndex = 63;
            this.label1.Text = "Report to Print";
            // 
            // cboCNCode
            // 
            this.cboCNCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCNCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCNCode.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCNCode.FormattingEnabled = true;
            this.cboCNCode.Location = new System.Drawing.Point(652, 13);
            this.cboCNCode.Name = "cboCNCode";
            this.cboCNCode.Size = new System.Drawing.Size(307, 27);
            this.cboCNCode.TabIndex = 2;
            this.cboCNCode.Visible = false;
            this.cboCNCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter2);
            this.cboCNCode.Validating += new System.ComponentModel.CancelEventHandler(this.cboCName_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(594, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 19);
            this.label2.TabIndex = 66;
            this.label2.Text = "Branch";
            this.label2.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(1080, 16);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 132;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmrptPickListNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 530);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.cboCNCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDocNum);
            this.Controls.Add(this.cbortprint);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtremarks);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCAmount);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "frmrptPickListNumber";
            this.Text = "Pick List";
            this.Load += new System.EventHandler(this.frmrptPickListNumber1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.TextBox txtCAmount;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtremarks;
        private System.Windows.Forms.TextBox txtDocNum;
        private System.Windows.Forms.ComboBox cbortprint;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCNCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPrint;
    }
}