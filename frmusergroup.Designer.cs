namespace K5GLONLINE
{
    partial class frmusergroup
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
            this.txtgroupname = new System.Windows.Forms.TextBox();
            this.txtsave = new System.Windows.Forms.Button();
            this.txtclose = new System.Windows.Forms.Button();
            this.txtgroupcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtgroupname
            // 
            this.txtgroupname.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtgroupname.Location = new System.Drawing.Point(56, 109);
            this.txtgroupname.Name = "txtgroupname";
            this.txtgroupname.Size = new System.Drawing.Size(432, 32);
            this.txtgroupname.TabIndex = 0;
            // 
            // txtsave
            // 
            this.txtsave.Location = new System.Drawing.Point(332, 209);
            this.txtsave.Name = "txtsave";
            this.txtsave.Size = new System.Drawing.Size(75, 23);
            this.txtsave.TabIndex = 1;
            this.txtsave.Text = "&Save";
            this.txtsave.UseVisualStyleBackColor = true;
            this.txtsave.Click += new System.EventHandler(this.txtsave_Click);
            // 
            // txtclose
            // 
            this.txtclose.Location = new System.Drawing.Point(413, 209);
            this.txtclose.Name = "txtclose";
            this.txtclose.Size = new System.Drawing.Size(75, 23);
            this.txtclose.TabIndex = 2;
            this.txtclose.Text = "&Close";
            this.txtclose.UseVisualStyleBackColor = true;
            this.txtclose.Click += new System.EventHandler(this.txtclose_Click);
            // 
            // txtgroupcode
            // 
            this.txtgroupcode.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtgroupcode.Location = new System.Drawing.Point(410, 25);
            this.txtgroupcode.Name = "txtgroupcode";
            this.txtgroupcode.ReadOnly = true;
            this.txtgroupcode.Size = new System.Drawing.Size(78, 32);
            this.txtgroupcode.TabIndex = 3;
            this.txtgroupcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Group Name:";
            // 
            // frmusergroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 262);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtgroupcode);
            this.Controls.Add(this.txtclose);
            this.Controls.Add(this.txtsave);
            this.Controls.Add(this.txtgroupname);
            this.Name = "frmusergroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Group";
            this.Load += new System.EventHandler(this.frmusergroup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtgroupname;
        private System.Windows.Forms.Button txtsave;
        private System.Windows.Forms.Button txtclose;
        private System.Windows.Forms.TextBox txtgroupcode;
        private System.Windows.Forms.Label label1;
    }
}