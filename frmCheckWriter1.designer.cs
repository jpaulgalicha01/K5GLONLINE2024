namespace K5GLONLINE
{
    partial class frmCheckWriter1
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
            this.lvvoucherslist = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnrefresh = new System.Windows.Forms.Button();
            this.txtdocnum = new System.Windows.Forms.TextBox();
            this.btnclose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEndDate = new System.Windows.Forms.MaskedTextBox();
            this.txtBeginDate = new System.Windows.Forms.MaskedTextBox();
            this.txtvoucher = new System.Windows.Forms.TextBox();
            this.txtdate = new System.Windows.Forms.TextBox();
            this.txtcheckno = new System.Windows.Forms.TextBox();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.txtcamount = new System.Windows.Forms.TextBox();
            this.txtamtinwords = new System.Windows.Forms.TextBox();
            this.txtmetrobank = new System.Windows.Forms.Button();
            this.txtMetrobank2 = new System.Windows.Forms.Button();
            this.cboCName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMonth = new System.Windows.Forms.TextBox();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lvvoucherslist
            // 
            this.lvvoucherslist.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lvvoucherslist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader5,
            this.columnHeader4,
            this.columnHeader3,
            this.columnHeader6,
            this.columnHeader1});
            this.lvvoucherslist.ForeColor = System.Drawing.Color.Red;
            this.lvvoucherslist.Location = new System.Drawing.Point(12, 132);
            this.lvvoucherslist.Name = "lvvoucherslist";
            this.lvvoucherslist.Size = new System.Drawing.Size(721, 332);
            this.lvvoucherslist.TabIndex = 0;
            this.lvvoucherslist.UseCompatibleStateImageBehavior = false;
            this.lvvoucherslist.View = System.Windows.Forms.View.Details;
            this.lvvoucherslist.SelectedIndexChanged += new System.EventHandler(this.lvvoucherslist_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Number";
            this.columnHeader2.Width = 65;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Name";
            this.columnHeader5.Width = 172;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Check No.";
            this.columnHeader4.Width = 126;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "TDate";
            this.columnHeader3.Width = 131;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Amount";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader6.Width = 95;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Voucher";
            this.columnHeader1.Width = 78;
            // 
            // btnrefresh
            // 
            this.btnrefresh.Location = new System.Drawing.Point(658, 11);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(75, 23);
            this.btnrefresh.TabIndex = 4;
            this.btnrefresh.Text = "&Refresh List";
            this.btnrefresh.UseVisualStyleBackColor = true;
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // txtdocnum
            // 
            this.txtdocnum.Location = new System.Drawing.Point(540, 95);
            this.txtdocnum.Name = "txtdocnum";
            this.txtdocnum.Size = new System.Drawing.Size(100, 20);
            this.txtdocnum.TabIndex = 2;
            this.txtdocnum.Visible = false;
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(658, 40);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 5;
            this.btnclose.Text = "&Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 19);
            this.label2.TabIndex = 12;
            this.label2.Text = "Ending Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 19);
            this.label3.TabIndex = 11;
            this.label3.Text = "Beginning Date";
            // 
            // txtEndDate
            // 
            this.txtEndDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndDate.Location = new System.Drawing.Point(12, 95);
            this.txtEndDate.Mask = "00/00/0000";
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(116, 26);
            this.txtEndDate.TabIndex = 2;
            this.txtEndDate.ValidatingType = typeof(System.DateTime);
            this.txtEndDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter);
            this.txtEndDate.Leave += new System.EventHandler(this.txtEndDate_Leave);
            // 
            // txtBeginDate
            // 
            this.txtBeginDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBeginDate.Location = new System.Drawing.Point(12, 34);
            this.txtBeginDate.Mask = "00/00/0000";
            this.txtBeginDate.Name = "txtBeginDate";
            this.txtBeginDate.Size = new System.Drawing.Size(116, 26);
            this.txtBeginDate.TabIndex = 1;
            this.txtBeginDate.ValidatingType = typeof(System.DateTime);
            this.txtBeginDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter);
            this.txtBeginDate.Leave += new System.EventHandler(this.txtBeginDate_Leave);
            // 
            // txtvoucher
            // 
            this.txtvoucher.Location = new System.Drawing.Point(531, 68);
            this.txtvoucher.Name = "txtvoucher";
            this.txtvoucher.Size = new System.Drawing.Size(100, 20);
            this.txtvoucher.TabIndex = 13;
            this.txtvoucher.Visible = false;
            // 
            // txtdate
            // 
            this.txtdate.Location = new System.Drawing.Point(522, 43);
            this.txtdate.Name = "txtdate";
            this.txtdate.Size = new System.Drawing.Size(100, 20);
            this.txtdate.TabIndex = 14;
            this.txtdate.Visible = false;
            // 
            // txtcheckno
            // 
            this.txtcheckno.Location = new System.Drawing.Point(522, 17);
            this.txtcheckno.Name = "txtcheckno";
            this.txtcheckno.Size = new System.Drawing.Size(100, 20);
            this.txtcheckno.TabIndex = 15;
            this.txtcheckno.Visible = false;
            // 
            // txtCustName
            // 
            this.txtCustName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustName.Location = new System.Drawing.Point(12, 482);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.ReadOnly = true;
            this.txtCustName.Size = new System.Drawing.Size(475, 29);
            this.txtCustName.TabIndex = 16;
            // 
            // txtcamount
            // 
            this.txtcamount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcamount.Location = new System.Drawing.Point(557, 482);
            this.txtcamount.Name = "txtcamount";
            this.txtcamount.ReadOnly = true;
            this.txtcamount.Size = new System.Drawing.Size(176, 29);
            this.txtcamount.TabIndex = 17;
            this.txtcamount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtamtinwords
            // 
            this.txtamtinwords.BackColor = System.Drawing.Color.Red;
            this.txtamtinwords.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtamtinwords.ForeColor = System.Drawing.Color.Black;
            this.txtamtinwords.Location = new System.Drawing.Point(12, 517);
            this.txtamtinwords.Name = "txtamtinwords";
            this.txtamtinwords.ReadOnly = true;
            this.txtamtinwords.Size = new System.Drawing.Size(721, 29);
            this.txtamtinwords.TabIndex = 18;
            // 
            // txtmetrobank
            // 
            this.txtmetrobank.Location = new System.Drawing.Point(658, 69);
            this.txtmetrobank.Name = "txtmetrobank";
            this.txtmetrobank.Size = new System.Drawing.Size(75, 23);
            this.txtmetrobank.TabIndex = 6;
            this.txtmetrobank.Text = "Metrobank1";
            this.txtmetrobank.UseVisualStyleBackColor = true;
            this.txtmetrobank.Click += new System.EventHandler(this.txtmetrobank_Click);
            // 
            // txtMetrobank2
            // 
            this.txtMetrobank2.Location = new System.Drawing.Point(658, 97);
            this.txtMetrobank2.Name = "txtMetrobank2";
            this.txtMetrobank2.Size = new System.Drawing.Size(75, 23);
            this.txtMetrobank2.TabIndex = 7;
            this.txtMetrobank2.Text = "Metrobank2";
            this.txtMetrobank2.UseVisualStyleBackColor = true;
            this.txtMetrobank2.Click += new System.EventHandler(this.txtMetrobank2_Click);
            // 
            // cboCName
            // 
            this.cboCName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCName.FormattingEnabled = true;
            this.cboCName.Location = new System.Drawing.Point(159, 33);
            this.cboCName.Name = "cboCName";
            this.cboCName.Size = new System.Drawing.Size(307, 27);
            this.cboCName.TabIndex = 3;
            this.cboCName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter);
            this.cboCName.Validated += new System.EventHandler(this.cboCName_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(155, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 19);
            this.label4.TabIndex = 30;
            this.label4.Text = "Branch";
            // 
            // txtMonth
            // 
            this.txtMonth.Location = new System.Drawing.Point(159, 66);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(100, 20);
            this.txtMonth.TabIndex = 33;
            this.txtMonth.Text = "b";
            this.txtMonth.Visible = false;
            // 
            // txtDay
            // 
            this.txtDay.Location = new System.Drawing.Point(262, 66);
            this.txtDay.Name = "txtDay";
            this.txtDay.Size = new System.Drawing.Size(100, 20);
            this.txtDay.TabIndex = 32;
            this.txtDay.Visible = false;
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(366, 66);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(100, 20);
            this.txtYear.TabIndex = 31;
            this.txtYear.Visible = false;
            // 
            // frmCheckWriter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 558);
            this.Controls.Add(this.txtMonth);
            this.Controls.Add(this.txtDay);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.cboCName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMetrobank2);
            this.Controls.Add(this.txtmetrobank);
            this.Controls.Add(this.txtamtinwords);
            this.Controls.Add(this.txtcamount);
            this.Controls.Add(this.txtCustName);
            this.Controls.Add(this.txtcheckno);
            this.Controls.Add(this.txtdate);
            this.Controls.Add(this.txtvoucher);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEndDate);
            this.Controls.Add(this.txtBeginDate);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.txtdocnum);
            this.Controls.Add(this.btnrefresh);
            this.Controls.Add(this.lvvoucherslist);
            this.Name = "frmCheckWriter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check Writer";
            this.Load += new System.EventHandler(this.frmCheckWriter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvvoucherslist;
        private System.Windows.Forms.Button btnrefresh;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox txtdocnum;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtEndDate;
        private System.Windows.Forms.MaskedTextBox txtBeginDate;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.TextBox txtvoucher;
        private System.Windows.Forms.TextBox txtdate;
        private System.Windows.Forms.TextBox txtcheckno;
        private System.Windows.Forms.TextBox txtCustName;
        private System.Windows.Forms.TextBox txtcamount;
        private System.Windows.Forms.TextBox txtamtinwords;
        private System.Windows.Forms.Button txtmetrobank;
        private System.Windows.Forms.Button txtMetrobank2;
        private System.Windows.Forms.ComboBox cboCName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMonth;
        private System.Windows.Forms.TextBox txtDay;
        private System.Windows.Forms.TextBox txtYear;

    }
}