
namespace K5GLONLINE
{
    partial class frmrptInvExpDetailsEdit
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
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtExpDate = new System.Windows.Forms.MaskedTextBox();
            this.txtStockNumber = new System.Windows.Forms.TextBox();
            this.txtIC = new System.Windows.Forms.TextBox();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.txtCS = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Location = new System.Drawing.Point(157, 122);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 43;
            this.btnPreview.Text = "Save";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(238, 122);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 46;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 22);
            this.label2.TabIndex = 48;
            this.label2.Text = "Exp Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 22);
            this.label1.TabIndex = 47;
            this.label1.Text = "StockNumber";
            // 
            // txtExpDate
            // 
            this.txtExpDate.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpDate.Location = new System.Drawing.Point(13, 93);
            this.txtExpDate.Mask = "00/00/0000";
            this.txtExpDate.Name = "txtExpDate";
            this.txtExpDate.Size = new System.Drawing.Size(127, 29);
            this.txtExpDate.TabIndex = 49;
            this.txtExpDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStockNumber
            // 
            this.txtStockNumber.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtStockNumber.Location = new System.Drawing.Point(13, 36);
            this.txtStockNumber.Name = "txtStockNumber";
            this.txtStockNumber.ReadOnly = true;
            this.txtStockNumber.Size = new System.Drawing.Size(300, 29);
            this.txtStockNumber.TabIndex = 50;
            // 
            // txtIC
            // 
            this.txtIC.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtIC.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.txtIC.Location = new System.Drawing.Point(95, 152);
            this.txtIC.Name = "txtIC";
            this.txtIC.Size = new System.Drawing.Size(66, 23);
            this.txtIC.TabIndex = 51;
            this.txtIC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIC.Visible = false;
            // 
            // txtNum
            // 
            this.txtNum.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtNum.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.txtNum.Location = new System.Drawing.Point(23, 152);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(66, 23);
            this.txtNum.TabIndex = 51;
            this.txtNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNum.Visible = false;
            // 
            // txtCS
            // 
            this.txtCS.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtCS.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.txtCS.Location = new System.Drawing.Point(177, 152);
            this.txtCS.Name = "txtCS";
            this.txtCS.Size = new System.Drawing.Size(66, 23);
            this.txtCS.TabIndex = 51;
            this.txtCS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCS.Visible = false;
            // 
            // frmrptInvExpDetailsEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 161);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.txtCS);
            this.Controls.Add(this.txtIC);
            this.Controls.Add(this.txtStockNumber);
            this.Controls.Add(this.txtExpDate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmrptInvExpDetailsEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Date Expiration";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmrptInvExpDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtExpDate;
        private System.Windows.Forms.TextBox txtStockNumber;
        private System.Windows.Forms.TextBox txtIC;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.TextBox txtCS;
    }
}