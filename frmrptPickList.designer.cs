namespace K5GLONLINE
{
    partial class frmrptPickList
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboWHCode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboListing = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.crystalReportViewer1.Location = new System.Drawing.Point(12, 34);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1141, 487);
            this.crystalReportViewer1.TabIndex = 4;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // cbortprint
            // 
            this.cbortprint.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbortprint.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbortprint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbortprint.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbortprint.FormattingEnabled = true;
            this.cbortprint.Items.AddRange(new object[] {
            "Customer",
            "Salesman",
            "Salesman Customer"});
            this.cbortprint.Location = new System.Drawing.Point(102, 4);
            this.cbortprint.Name = "cbortprint";
            this.cbortprint.Size = new System.Drawing.Size(226, 23);
            this.cbortprint.TabIndex = 0;
            this.cbortprint.DropDownClosed += new System.EventHandler(this.cbortprint_DropDownClosed);
            this.cbortprint.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Location = new System.Drawing.Point(1078, 4);
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
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 15);
            this.label1.TabIndex = 32;
            this.label1.Text = "Report to Print:";
            // 
            // cboWHCode
            // 
            this.cboWHCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboWHCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboWHCode.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboWHCode.FormattingEnabled = true;
            this.cboWHCode.Location = new System.Drawing.Point(736, 5);
            this.cboWHCode.Name = "cboWHCode";
            this.cboWHCode.Size = new System.Drawing.Size(284, 23);
            this.cboWHCode.TabIndex = 2;
            this.cboWHCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter);
            this.cboWHCode.Validating += new System.ComponentModel.CancelEventHandler(this.cboWHCode_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(662, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 34;
            this.label4.Text = "Warehouse:";
            // 
            // cboListing
            // 
            this.cboListing.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboListing.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboListing.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboListing.FormattingEnabled = true;
            this.cboListing.Location = new System.Drawing.Point(384, 6);
            this.cboListing.Name = "cboListing";
            this.cboListing.Size = new System.Drawing.Size(264, 23);
            this.cboListing.TabIndex = 1;
            this.cboListing.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter);
            this.cboListing.Validating += new System.ComponentModel.CancelEventHandler(this.cboListing_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(334, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 36;
            this.label2.Text = "Listing:";
            // 
            // frmrptPickList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 530);
            this.Controls.Add(this.cboListing);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboWHCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbortprint);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "frmrptPickList";
            this.Text = "Pick List";
            this.Load += new System.EventHandler(this.frmrptIndividualLedger_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.ComboBox cbortprint;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboWHCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboListing;
        private System.Windows.Forms.Label label2;

    }
}