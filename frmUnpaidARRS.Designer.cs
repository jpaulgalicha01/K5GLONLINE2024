namespace K5GLONLINE
{
    partial class frmUnpaidARRS
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
            this.LVUnpaidAR = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.txtRefer = new System.Windows.Forms.TextBox();
            this.btnPost = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LVUnpaidAR
            // 
            this.LVUnpaidAR.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.LVUnpaidAR.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.LVUnpaidAR.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LVUnpaidAR.ForeColor = System.Drawing.Color.Red;
            this.LVUnpaidAR.Location = new System.Drawing.Point(12, 33);
            this.LVUnpaidAR.Name = "LVUnpaidAR";
            this.LVUnpaidAR.Size = new System.Drawing.Size(457, 221);
            this.LVUnpaidAR.TabIndex = 7;
            this.LVUnpaidAR.UseCompatibleStateImageBehavior = false;
            this.LVUnpaidAR.View = System.Windows.Forms.View.Details;
            this.LVUnpaidAR.SelectedIndexChanged += new System.EventHandler(this.LVpso_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Reference";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Date";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Balance";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 100;
            // 
            // txtRefer
            // 
            this.txtRefer.Location = new System.Drawing.Point(261, 8);
            this.txtRefer.Name = "txtRefer";
            this.txtRefer.Size = new System.Drawing.Size(100, 20);
            this.txtRefer.TabIndex = 26;
            this.txtRefer.Visible = false;
            // 
            // btnPost
            // 
            this.btnPost.Location = new System.Drawing.Point(394, 271);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(75, 23);
            this.btnPost.TabIndex = 27;
            this.btnPost.Text = "Post";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // frmUnpaidARRS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 306);
            this.Controls.Add(this.btnPost);
            this.Controls.Add(this.txtRefer);
            this.Controls.Add(this.LVUnpaidAR);
            this.Name = "frmUnpaidARRS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unpaid Accounts Receivable";
            this.Load += new System.EventHandler(this.frmUnpaidARRS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView LVUnpaidAR;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TextBox txtRefer;
        private System.Windows.Forms.Button btnPost;
    }
}