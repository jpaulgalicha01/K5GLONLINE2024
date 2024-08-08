namespace K5GLONLINE
{
    partial class frmrptDoleSales
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
            this.cbortprint = new System.Windows.Forms.ComboBox();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.txtEndDate = new System.Windows.Forms.MaskedTextBox();
            this.txtBeginDate = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSalesman = new System.Windows.Forms.Label();
            this.cboSupplier = new System.Windows.Forms.ComboBox();
            this.lblBeginDate = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.dgv2 = new System.Windows.Forms.DataGridView();
            this.K5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DistName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ControlNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salesman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Channel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Outlet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SFACode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Voucher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Volume1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Volume2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetWithoutVat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Currency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetWithVat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Currency1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Warehouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreLoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPreview = new System.Windows.Forms.Button();
            this.PBProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
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
            this.cbortprint.Size = new System.Drawing.Size(224, 25);
            this.cbortprint.TabIndex = 0;
            this.cbortprint.SelectedIndexChanged += new System.EventHandler(this.cbortprint_SelectedIndexChanged);
            this.cbortprint.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter2);
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndDate.Location = new System.Drawing.Point(841, 13);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(72, 17);
            this.lblEndDate.TabIndex = 28;
            this.lblEndDate.Text = "End Date:";
            // 
            // txtEndDate
            // 
            this.txtEndDate.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndDate.Location = new System.Drawing.Point(913, 10);
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
            this.txtBeginDate.Location = new System.Drawing.Point(748, 10);
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
            this.lblSalesman.Location = new System.Drawing.Point(353, 13);
            this.lblSalesman.Name = "lblSalesman";
            this.lblSalesman.Size = new System.Drawing.Size(58, 17);
            this.lblSalesman.TabIndex = 31;
            this.lblSalesman.Text = "Supplier";
            // 
            // cboSupplier
            // 
            this.cboSupplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSupplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSupplier.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSupplier.FormattingEnabled = true;
            this.cboSupplier.Location = new System.Drawing.Point(418, 10);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Size = new System.Drawing.Size(224, 25);
            this.cboSupplier.TabIndex = 1;
            this.cboSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter2);
            // 
            // lblBeginDate
            // 
            this.lblBeginDate.AutoSize = true;
            this.lblBeginDate.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBeginDate.Location = new System.Drawing.Point(659, 13);
            this.lblBeginDate.Name = "lblBeginDate";
            this.lblBeginDate.Size = new System.Drawing.Size(83, 17);
            this.lblBeginDate.TabIndex = 32;
            this.lblBeginDate.Text = "Begin Date:";
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(1079, 10);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 33;
            this.btnExport.Text = "&Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Visible = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dgv2
            // 
            this.dgv2.AllowUserToAddRows = false;
            this.dgv2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.K5,
            this.DistName,
            this.TDate,
            this.Reference,
            this.LineItem,
            this.ControlNo,
            this.Salesman,
            this.RegName,
            this.Channel,
            this.Outlet,
            this.CustGroup,
            this.SFACode,
            this.Voucher,
            this.CustName,
            this.Qty,
            this.Volume1,
            this.UM,
            this.Volume2,
            this.NetWithoutVat,
            this.Currency,
            this.NetWithVat,
            this.Currency1,
            this.DE,
            this.Warehouse,
            this.StoreLoc});
            this.dgv2.Location = new System.Drawing.Point(11, 53);
            this.dgv2.Name = "dgv2";
            this.dgv2.Size = new System.Drawing.Size(1143, 447);
            this.dgv2.TabIndex = 34;
            this.dgv2.Visible = false;
            // 
            // K5
            // 
            this.K5.HeaderText = "CO. Code";
            this.K5.Name = "K5";
            // 
            // DistName
            // 
            this.DistName.HeaderText = "Dist Name";
            this.DistName.Name = "DistName";
            // 
            // TDate
            // 
            this.TDate.HeaderText = "Billing Date";
            this.TDate.Name = "TDate";
            // 
            // Reference
            // 
            this.Reference.HeaderText = "Billing Document No.";
            this.Reference.Name = "Reference";
            // 
            // LineItem
            // 
            this.LineItem.HeaderText = "Billing Line Item";
            this.LineItem.Name = "LineItem";
            // 
            // ControlNo
            // 
            this.ControlNo.HeaderText = "Sold To Code";
            this.ControlNo.Name = "ControlNo";
            // 
            // Salesman
            // 
            this.Salesman.HeaderText = "Salesman";
            this.Salesman.Name = "Salesman";
            // 
            // RegName
            // 
            this.RegName.HeaderText = "Region";
            this.RegName.Name = "RegName";
            // 
            // Channel
            // 
            this.Channel.HeaderText = "Distribution Channel";
            this.Channel.Name = "Channel";
            // 
            // Outlet
            // 
            this.Outlet.HeaderText = "Store Type";
            this.Outlet.Name = "Outlet";
            // 
            // CustGroup
            // 
            this.CustGroup.HeaderText = "Customer Group 4";
            this.CustGroup.Name = "CustGroup";
            // 
            // SFACode
            // 
            this.SFACode.HeaderText = "Material Code";
            this.SFACode.Name = "SFACode";
            // 
            // Voucher
            // 
            this.Voucher.HeaderText = "Billing Type";
            this.Voucher.Name = "Voucher";
            // 
            // CustName
            // 
            this.CustName.HeaderText = "Sold To";
            this.CustName.Name = "CustName";
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Invoiced Qty in Case";
            this.Qty.Name = "Qty";
            // 
            // Volume1
            // 
            this.Volume1.HeaderText = "Net Weight";
            this.Volume1.Name = "Volume1";
            // 
            // UM
            // 
            this.UM.HeaderText = "Sales Unit";
            this.UM.Name = "UM";
            // 
            // Volume2
            // 
            this.Volume2.HeaderText = "Weight in KG";
            this.Volume2.Name = "Volume2";
            // 
            // NetWithoutVat
            // 
            this.NetWithoutVat.HeaderText = "Invoice Net Price";
            this.NetWithoutVat.Name = "NetWithoutVat";
            // 
            // Currency
            // 
            this.Currency.HeaderText = "Currency";
            this.Currency.Name = "Currency";
            // 
            // NetWithVat
            // 
            this.NetWithVat.HeaderText = "Gross Price";
            this.NetWithVat.Name = "NetWithVat";
            // 
            // Currency1
            // 
            this.Currency1.HeaderText = "Currency";
            this.Currency1.Name = "Currency1";
            // 
            // DE
            // 
            this.DE.HeaderText = "Creation Date";
            this.DE.Name = "DE";
            // 
            // Warehouse
            // 
            this.Warehouse.HeaderText = "Plant";
            this.Warehouse.Name = "Warehouse";
            // 
            // StoreLoc
            // 
            this.StoreLoc.HeaderText = "Store Location";
            this.StoreLoc.Name = "StoreLoc";
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Location = new System.Drawing.Point(1041, 10);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 35;
            this.btnPreview.Text = "&Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click_1);
            // 
            // PBProgressBar1
            // 
            this.PBProgressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PBProgressBar1.Location = new System.Drawing.Point(179, 506);
            this.PBProgressBar1.Name = "PBProgressBar1";
            this.PBProgressBar1.Size = new System.Drawing.Size(974, 17);
            this.PBProgressBar1.TabIndex = 201;
            this.PBProgressBar1.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 506);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 17);
            this.label2.TabIndex = 202;
            this.label2.Text = "Exporting to EXCEL . . . .";
            this.label2.Visible = false;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.DisplayStatusBar = false;
            this.crystalReportViewer1.Location = new System.Drawing.Point(11, 53);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1143, 447);
            this.crystalReportViewer1.TabIndex = 203;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmrptDoleSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1165, 530);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PBProgressBar1);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.dgv2);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblBeginDate);
            this.Controls.Add(this.cboSupplier);
            this.Controls.Add(this.lblSalesman);
            this.Controls.Add(this.cbortprint);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.txtEndDate);
            this.Controls.Add(this.txtBeginDate);
            this.Controls.Add(this.label1);
            this.Name = "frmrptDoleSales";
            this.Text = "DOLE Reports";
            this.Load += new System.EventHandler(this.frmrptDoleSales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
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
        private System.Windows.Forms.ComboBox cboSupplier;
        private System.Windows.Forms.Label lblBeginDate;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridView dgv2;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.DataGridViewTextBoxColumn K5;
        private System.Windows.Forms.DataGridViewTextBoxColumn DistName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reference;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ControlNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salesman;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Channel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Outlet;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn SFACode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Voucher;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Volume1;
        private System.Windows.Forms.DataGridViewTextBoxColumn UM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Volume2;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetWithoutVat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Currency;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetWithVat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Currency1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DE;
        private System.Windows.Forms.DataGridViewTextBoxColumn Warehouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreLoc;
        private System.Windows.Forms.ProgressBar PBProgressBar1;
        private System.Windows.Forms.Label label2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}