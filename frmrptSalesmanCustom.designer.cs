﻿namespace K5GLONLINE
{
    partial class frmrptSalesmanCustom
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbortprint = new System.Windows.Forms.ComboBox();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.txtEndDate = new System.Windows.Forms.MaskedTextBox();
            this.txtBeginDate = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSalesman = new System.Windows.Forms.Label();
            this.cboWHCode = new System.Windows.Forms.ComboBox();
            this.lblBeginDate = new System.Windows.Forms.Label();
            this.btnPreview = new System.Windows.Forms.Button();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CRSalesmanCustom1 = new K5GLONLINE.CRSalesmanCustom();
            this.cboSalesman = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv1 = new K5GLONLINE.moveNextCellDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbortprint
            // 
            this.cbortprint.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbortprint.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbortprint.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbortprint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbortprint.DropDownWidth = 300;
            this.cbortprint.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbortprint.FormattingEnabled = true;
            this.cbortprint.Items.AddRange(new object[] {
            "Sales - Salesman - Supplier - Detailed",
            "Sales - Salesman - Supplier - Summary",
            "Sales - Salesman - Customer - Detailed",
            "Sales - Salesman - Customer - Summary",
            "Sales - Salesman - Detailed",
            "Sales - Salesman - Amount"});
            this.cbortprint.Location = new System.Drawing.Point(113, 10);
            this.cbortprint.Name = "cbortprint";
            this.cbortprint.Size = new System.Drawing.Size(327, 25);
            this.cbortprint.TabIndex = 0;
            this.cbortprint.SelectedIndexChanged += new System.EventHandler(this.cbortprint_SelectedIndexChanged);
            this.cbortprint.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter2);
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndDate.Location = new System.Drawing.Point(704, 47);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(72, 17);
            this.lblEndDate.TabIndex = 28;
            this.lblEndDate.Text = "End Date:";
            // 
            // txtEndDate
            // 
            this.txtEndDate.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndDate.Location = new System.Drawing.Point(776, 44);
            this.txtEndDate.Mask = "00/00/0000";
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(82, 23);
            this.txtEndDate.TabIndex = 5;
            this.txtEndDate.ValidatingType = typeof(System.DateTime);
            this.txtEndDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter2);
            this.txtEndDate.Leave += new System.EventHandler(this.txtEndDate_Leave_1);
            // 
            // txtBeginDate
            // 
            this.txtBeginDate.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBeginDate.Location = new System.Drawing.Point(599, 47);
            this.txtBeginDate.Mask = "00/00/0000";
            this.txtBeginDate.Name = "txtBeginDate";
            this.txtBeginDate.Size = new System.Drawing.Size(82, 23);
            this.txtBeginDate.TabIndex = 4;
            this.txtBeginDate.ValidatingType = typeof(System.DateTime);
            this.txtBeginDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter2);
            this.txtBeginDate.Leave += new System.EventHandler(this.txtBeginDate_Leave_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 26;
            this.label1.Text = "Report to Print";
            // 
            // lblSalesman
            // 
            this.lblSalesman.AutoSize = true;
            this.lblSalesman.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesman.Location = new System.Drawing.Point(513, 13);
            this.lblSalesman.Name = "lblSalesman";
            this.lblSalesman.Size = new System.Drawing.Size(80, 17);
            this.lblSalesman.TabIndex = 31;
            this.lblSalesman.Text = "Warehouse";
            this.lblSalesman.Visible = false;
            // 
            // cboWHCode
            // 
            this.cboWHCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboWHCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboWHCode.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboWHCode.FormattingEnabled = true;
            this.cboWHCode.Location = new System.Drawing.Point(599, 9);
            this.cboWHCode.Name = "cboWHCode";
            this.cboWHCode.Size = new System.Drawing.Size(259, 25);
            this.cboWHCode.TabIndex = 1;
            this.cboWHCode.Visible = false;
            this.cboWHCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter2);
            // 
            // lblBeginDate
            // 
            this.lblBeginDate.AutoSize = true;
            this.lblBeginDate.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBeginDate.Location = new System.Drawing.Point(510, 53);
            this.lblBeginDate.Name = "lblBeginDate";
            this.lblBeginDate.Size = new System.Drawing.Size(83, 17);
            this.lblBeginDate.TabIndex = 32;
            this.lblBeginDate.Text = "Begin Date:";
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Location = new System.Drawing.Point(1080, 11);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 35;
            this.btnPreview.Text = "&Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click_1);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(12, 82);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1143, 436);
            this.crystalReportViewer1.TabIndex = 203;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // cboSalesman
            // 
            this.cboSalesman.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSalesman.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSalesman.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cboSalesman.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSalesman.DropDownWidth = 300;
            this.cboSalesman.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSalesman.FormattingEnabled = true;
            this.cboSalesman.Items.AddRange(new object[] {
            "Sales - Salesman - Supplier - Detailed",
            "Sales - Salesman - Supplier - Summary",
            "Sales - Salesman - Customer - Detailed",
            "Sales - Salesman - Customer - Summary",
            "Sales - Salesman - Detailed",
            "Sales - Salesman - Amount"});
            this.cboSalesman.Location = new System.Drawing.Point(113, 44);
            this.cboSalesman.Name = "cboSalesman";
            this.cboSalesman.Size = new System.Drawing.Size(327, 25);
            this.cboSalesman.TabIndex = 204;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 205;
            this.label2.Text = "Salesman";
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(12, 82);
            this.dgv1.Name = "dgv1";
            this.dgv1.Size = new System.Drawing.Size(412, 436);
            this.dgv1.TabIndex = 206;
            this.dgv1.Visible = false;
            this.dgv1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellEndEdit);
            // 
            // frmrptSalesmanCustom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1165, 530);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.cboSalesman);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.lblBeginDate);
            this.Controls.Add(this.cboWHCode);
            this.Controls.Add(this.lblSalesman);
            this.Controls.Add(this.cbortprint);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.txtEndDate);
            this.Controls.Add(this.txtBeginDate);
            this.Controls.Add(this.label1);
            this.Name = "frmrptSalesmanCustom";
            this.Text = "DOLE Sales";
            this.Load += new System.EventHandler(this.frmrptSalesmanCustom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbortprint;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.MaskedTextBox txtEndDate;
        private System.Windows.Forms.MaskedTextBox txtBeginDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSalesman;
        private System.Windows.Forms.ComboBox cboWHCode;
        private System.Windows.Forms.Label lblBeginDate;
        private System.Windows.Forms.Button btnPreview;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private CRSalesmanCustom CRSalesmanCustom1;
        private System.Windows.Forms.ComboBox cboSalesman;
        private System.Windows.Forms.Label label2;
        private moveNextCellDataGridView dgv1;
    }
}