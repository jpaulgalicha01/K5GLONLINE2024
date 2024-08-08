namespace K5GLONLINE
{
    partial class frmrptIndLedger
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
            this.label4 = new System.Windows.Forms.Label();
            this.cboControlNo = new System.Windows.Forms.ComboBox();
            this.cbortprint = new System.Windows.Forms.ComboBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEndDate = new System.Windows.Forms.MaskedTextBox();
            this.txtBeginDate = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
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
            this.crystalReportViewer1.Location = new System.Drawing.Point(14, 56);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1191, 462);
            this.crystalReportViewer1.TabIndex = 6;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 15);
            this.label4.TabIndex = 40;
            this.label4.Text = "Name:";
            // 
            // cboControlNo
            // 
            this.cboControlNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboControlNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboControlNo.DropDownWidth = 500;
            this.cboControlNo.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboControlNo.FormattingEnabled = true;
            this.cboControlNo.Location = new System.Drawing.Point(101, 27);
            this.cboControlNo.Name = "cboControlNo";
            this.cboControlNo.Size = new System.Drawing.Size(346, 23);
            this.cboControlNo.TabIndex = 1;
            this.cboControlNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter);
            this.cboControlNo.Validating += new System.ComponentModel.CancelEventHandler(this.cboControlNo_Validating);
            // 
            // cbortprint
            // 
            this.cbortprint.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbortprint.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbortprint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbortprint.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbortprint.FormattingEnabled = true;
            this.cbortprint.Location = new System.Drawing.Point(101, 2);
            this.cbortprint.Name = "cbortprint";
            this.cbortprint.Size = new System.Drawing.Size(346, 23);
            this.cbortprint.TabIndex = 0;
            this.cbortprint.SelectedIndexChanged += new System.EventHandler(this.cbortprint_SelectedIndexChanged);
            this.cbortprint.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Location = new System.Drawing.Point(1130, 6);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 5;
            this.btnPreview.Text = "&Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(453, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 47;
            this.label1.Text = "Ending Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(453, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 15);
            this.label5.TabIndex = 46;
            this.label5.Text = "Beginning Date";
            // 
            // txtEndDate
            // 
            this.txtEndDate.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndDate.Location = new System.Drawing.Point(564, 27);
            this.txtEndDate.Mask = "00/00/0000";
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(83, 22);
            this.txtEndDate.TabIndex = 3;
            this.txtEndDate.ValidatingType = typeof(System.DateTime);
            this.txtEndDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter);
            this.txtEndDate.Leave += new System.EventHandler(this.txtEndDate_Leave);
            // 
            // txtBeginDate
            // 
            this.txtBeginDate.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBeginDate.Location = new System.Drawing.Point(564, 2);
            this.txtBeginDate.Mask = "00/00/0000";
            this.txtBeginDate.Name = "txtBeginDate";
            this.txtBeginDate.Size = new System.Drawing.Size(83, 22);
            this.txtBeginDate.TabIndex = 2;
            this.txtBeginDate.ValidatingType = typeof(System.DateTime);
            this.txtBeginDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter);
            this.txtBeginDate.Leave += new System.EventHandler(this.txtBeginDate_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 15);
            this.label6.TabIndex = 42;
            this.label6.Text = "Report to Print";
            // 
            // frmrptIndLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 530);
            this.Controls.Add(this.cbortprint);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEndDate);
            this.Controls.Add(this.txtBeginDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboControlNo);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "frmrptIndLedger";
            this.Text = "Individual Ledger";
            this.Load += new System.EventHandler(this.frmrptIndLedger_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboControlNo;
        private System.Windows.Forms.ComboBox cbortprint;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox txtEndDate;
        private System.Windows.Forms.MaskedTextBox txtBeginDate;
        private System.Windows.Forms.Label label6;
    }
}