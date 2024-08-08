namespace K5GLONLINE
{
    partial class frmrptFS
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
            this.cbortprint = new System.Windows.Forms.ComboBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblBeginDate = new System.Windows.Forms.Label();
            this.txtEndDate = new System.Windows.Forms.MaskedTextBox();
            this.txtBeginDate = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEnterDate = new System.Windows.Forms.Label();
            this.txtEnterDate = new System.Windows.Forms.MaskedTextBox();
            this.txtControNo = new System.Windows.Forms.TextBox();
            this.txtNetIncome = new System.Windows.Forms.TextBox();
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
            this.crystalReportViewer1.Location = new System.Drawing.Point(12, 37);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1141, 481);
            this.crystalReportViewer1.TabIndex = 6;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // cbortprint
            // 
            this.cbortprint.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbortprint.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbortprint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbortprint.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbortprint.FormattingEnabled = true;
            this.cbortprint.Location = new System.Drawing.Point(115, 4);
            this.cbortprint.Name = "cbortprint";
            this.cbortprint.Size = new System.Drawing.Size(205, 27);
            this.cbortprint.TabIndex = 0;
            this.cbortprint.SelectedIndexChanged += new System.EventHandler(this.cbortprint_SelectedIndexChanged);
            this.cbortprint.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter2);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Location = new System.Drawing.Point(1080, 10);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 5;
            this.btnPreview.Text = "&Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndDate.Location = new System.Drawing.Point(532, 11);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(83, 19);
            this.lblEndDate.TabIndex = 18;
            this.lblEndDate.Text = "Ending Date";
            this.lblEndDate.Visible = false;
            // 
            // lblBeginDate
            // 
            this.lblBeginDate.AutoSize = true;
            this.lblBeginDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBeginDate.Location = new System.Drawing.Point(326, 11);
            this.lblBeginDate.Name = "lblBeginDate";
            this.lblBeginDate.Size = new System.Drawing.Size(100, 19);
            this.lblBeginDate.TabIndex = 17;
            this.lblBeginDate.Text = "Beginning Date";
            this.lblBeginDate.Visible = false;
            // 
            // txtEndDate
            // 
            this.txtEndDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndDate.Location = new System.Drawing.Point(621, 5);
            this.txtEndDate.Mask = "00/00/0000";
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(82, 26);
            this.txtEndDate.TabIndex = 2;
            this.txtEndDate.ValidatingType = typeof(System.DateTime);
            this.txtEndDate.Visible = false;
            this.txtEndDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter2);
            this.txtEndDate.Leave += new System.EventHandler(this.txtEndDate_Leave);
            // 
            // txtBeginDate
            // 
            this.txtBeginDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBeginDate.Location = new System.Drawing.Point(431, 5);
            this.txtBeginDate.Mask = "00/00/0000";
            this.txtBeginDate.Name = "txtBeginDate";
            this.txtBeginDate.Size = new System.Drawing.Size(82, 26);
            this.txtBeginDate.TabIndex = 1;
            this.txtBeginDate.ValidatingType = typeof(System.DateTime);
            this.txtBeginDate.Visible = false;
            this.txtBeginDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter2);
            this.txtBeginDate.Leave += new System.EventHandler(this.txtBeginDate_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 19);
            this.label1.TabIndex = 13;
            this.label1.Text = "Report to Print";
            // 
            // lblEnterDate
            // 
            this.lblEnterDate.AutoSize = true;
            this.lblEnterDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnterDate.Location = new System.Drawing.Point(359, 9);
            this.lblEnterDate.Name = "lblEnterDate";
            this.lblEnterDate.Size = new System.Drawing.Size(38, 19);
            this.lblEnterDate.TabIndex = 22;
            this.lblEnterDate.Text = "Date";
            // 
            // txtEnterDate
            // 
            this.txtEnterDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnterDate.Location = new System.Drawing.Point(464, 3);
            this.txtEnterDate.Mask = "00/00/0000";
            this.txtEnterDate.Name = "txtEnterDate";
            this.txtEnterDate.Size = new System.Drawing.Size(82, 26);
            this.txtEnterDate.TabIndex = 3;
            this.txtEnterDate.ValidatingType = typeof(System.DateTime);
            this.txtEnterDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter2);
            this.txtEnterDate.Leave += new System.EventHandler(this.txtEnterDate_Leave);
            // 
            // txtControNo
            // 
            this.txtControNo.Location = new System.Drawing.Point(54, 4);
            this.txtControNo.Name = "txtControNo";
            this.txtControNo.Size = new System.Drawing.Size(38, 20);
            this.txtControNo.TabIndex = 23;
            this.txtControNo.Visible = false;
            // 
            // txtNetIncome
            // 
            this.txtNetIncome.Location = new System.Drawing.Point(296, 3);
            this.txtNetIncome.Name = "txtNetIncome";
            this.txtNetIncome.Size = new System.Drawing.Size(101, 20);
            this.txtNetIncome.TabIndex = 24;
            this.txtNetIncome.Text = "0";
            this.txtNetIncome.Visible = false;
            // 
            // frmrptFS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 530);
            this.Controls.Add(this.txtNetIncome);
            this.Controls.Add(this.txtControNo);
            this.Controls.Add(this.lblEnterDate);
            this.Controls.Add(this.txtEnterDate);
            this.Controls.Add(this.cbortprint);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblBeginDate);
            this.Controls.Add(this.txtEndDate);
            this.Controls.Add(this.txtBeginDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "frmrptFS";
            this.Text = "Financial Statement";
            this.Load += new System.EventHandler(this.frmrptFS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.ComboBox cbortprint;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblBeginDate;
        private System.Windows.Forms.MaskedTextBox txtEndDate;
        private System.Windows.Forms.MaskedTextBox txtBeginDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEnterDate;
        private System.Windows.Forms.MaskedTextBox txtEnterDate;
        private System.Windows.Forms.TextBox txtControNo;
        private System.Windows.Forms.TextBox txtNetIncome;
    }
}