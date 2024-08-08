using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace K5GLONLINE
{
    public partial class frmReset : Form
    {
        ClsGetSomethingOthers ClsGetSomethingOthers1 = new ClsGetSomethingOthers(); 
        public frmReset()
        {
            InitializeComponent();
        }

      

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            ClsGetSomethingOthers1.ClsZeroTheDoor(cboVouchers.Text);
            MessageBox.Show("Finished", "GL");
        }
    }
}
