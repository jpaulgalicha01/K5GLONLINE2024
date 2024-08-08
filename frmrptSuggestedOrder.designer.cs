namespace K5GLONLINE
{
    partial class frmrptSuggestedOrder
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
            this.btnPreview = new System.Windows.Forms.Button();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblBeginDate = new System.Windows.Forms.Label();
            this.txtEndDate = new System.Windows.Forms.MaskedTextBox();
            this.txtBeginDate = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboSupplierCode = new System.Windows.Forms.ComboBox();
            this.cboWHCode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEnterDate = new System.Windows.Forms.MaskedTextBox();
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
            this.crystalReportViewer1.Location = new System.Drawing.Point(12, 64);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1141, 454);
            this.crystalReportViewer1.TabIndex = 6;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Location = new System.Drawing.Point(1078, 7);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 51);
            this.btnPreview.TabIndex = 5;
            this.btnPreview.Text = "&Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndDate.Location = new System.Drawing.Point(413, 33);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(76, 15);
            this.lblEndDate.TabIndex = 28;
            this.lblEndDate.Text = "Ending Date:";
            // 
            // lblBeginDate
            // 
            this.lblBeginDate.AutoSize = true;
            this.lblBeginDate.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBeginDate.Location = new System.Drawing.Point(394, 7);
            this.lblBeginDate.Name = "lblBeginDate";
            this.lblBeginDate.Size = new System.Drawing.Size(93, 15);
            this.lblBeginDate.TabIndex = 27;
            this.lblBeginDate.Text = "Beginning Date:";
            // 
            // txtEndDate
            // 
            this.txtEndDate.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndDate.Location = new System.Drawing.Point(493, 29);
            this.txtEndDate.Mask = "00/00/0000";
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(82, 23);
            this.txtEndDate.TabIndex = 3;
            this.txtEndDate.ValidatingType = typeof(System.DateTime);
            this.txtEndDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter2);
            this.txtEndDate.Leave += new System.EventHandler(this.txtEndDate_Leave_1);
            // 
            // txtBeginDate
            // 
            this.txtBeginDate.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBeginDate.Location = new System.Drawing.Point(493, 3);
            this.txtBeginDate.Mask = "00/00/0000";
            this.txtBeginDate.Name = "txtBeginDate";
            this.txtBeginDate.Size = new System.Drawing.Size(82, 23);
            this.txtBeginDate.TabIndex = 2;
            this.txtBeginDate.ValidatingType = typeof(System.DateTime);
            this.txtBeginDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter2);
            this.txtBeginDate.Leave += new System.EventHandler(this.txtBeginDate_Leave_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 33;
            this.label3.Text = "Principal:";
            // 
            // cboSupplierCode
            // 
            this.cboSupplierCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSupplierCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSupplierCode.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSupplierCode.FormattingEnabled = true;
            this.cboSupplierCode.Location = new System.Drawing.Point(106, 3);
            this.cboSupplierCode.Name = "cboSupplierCode";
            this.cboSupplierCode.Size = new System.Drawing.Size(268, 25);
            this.cboSupplierCode.TabIndex = 0;
            this.cboSupplierCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter2);
            this.cboSupplierCode.Validating += new System.ComponentModel.CancelEventHandler(this.cboSupplierCode_Validating);
            // 
            // cboWHCode
            // 
            this.cboWHCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboWHCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboWHCode.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboWHCode.FormattingEnabled = true;
            this.cboWHCode.Location = new System.Drawing.Point(106, 30);
            this.cboWHCode.Name = "cboWHCode";
            this.cboWHCode.Size = new System.Drawing.Size(268, 23);
            this.cboWHCode.TabIndex = 1;
            this.cboWHCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter2);
            this.cboWHCode.Validating += new System.ComponentModel.CancelEventHandler(this.cboWHCode_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 37;
            this.label4.Text = "Warehouse:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(637, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 39;
            this.label1.Text = "As of Date:";
            // 
            // txtEnterDate
            // 
            this.txtEnterDate.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnterDate.Location = new System.Drawing.Point(711, 3);
            this.txtEnterDate.Mask = "00/00/0000";
            this.txtEnterDate.Name = "txtEnterDate";
            this.txtEnterDate.Size = new System.Drawing.Size(82, 23);
            this.txtEnterDate.TabIndex = 4;
            this.txtEnterDate.ValidatingType = typeof(System.DateTime);
            this.txtEnterDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter2);
            this.txtEnterDate.Validating += new System.ComponentModel.CancelEventHandler(this.txtEnterDate_Validating);
            // 
            // frmrptSuggestedOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1165, 530);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEnterDate);
            this.Controls.Add(this.cboWHCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboSupplierCode);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblBeginDate);
            this.Controls.Add(this.txtEndDate);
            this.Controls.Add(this.txtBeginDate);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "frmrptSuggestedOrder";
            this.Text = "Suggested Order";
            this.Load += new System.EventHandler(this.frmrptSuggestedOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblBeginDate;
        private System.Windows.Forms.MaskedTextBox txtEndDate;
        private System.Windows.Forms.MaskedTextBox txtBeginDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboSupplierCode;
        private System.Windows.Forms.ComboBox cboWHCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtEnterDate;
    }
}