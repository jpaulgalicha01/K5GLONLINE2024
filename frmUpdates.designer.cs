namespace K5GLONLINE
{
    partial class frmUpdates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdates));
            this.txtBookBalance = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtBookBalance
            // 
            this.txtBookBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBookBalance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookBalance.Location = new System.Drawing.Point(12, 12);
            this.txtBookBalance.Multiline = true;
            this.txtBookBalance.Name = "txtBookBalance";
            this.txtBookBalance.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBookBalance.Size = new System.Drawing.Size(800, 507);
            this.txtBookBalance.TabIndex = 7;
            this.txtBookBalance.Text = resources.GetString("txtBookBalance.Text");
            this.txtBookBalance.TextChanged += new System.EventHandler(this.txtBookBalance_TextChanged);
            // 
            // frmUpdates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(824, 531);
            this.Controls.Add(this.txtBookBalance);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "frmUpdates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Updates";
            this.Load += new System.EventHandler(this.frmUpdates_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtBookBalance;
    }
}