using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace K5GLONLINE
{
    public partial class frmrptInvExpDetailsEdit : Form
    {
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        //ClsGetSomething ClsGetSomething1 = new ClsGetSomething();
        private SqlConnection myconnection;
        private SqlCommand mycommand;
        //SqlDataReader SqlDataReader1;
        //BindingSource bindingSource = null;
        public static TextBox glbltxtNum, glbltxtIC;
        //private string pristrIB, pristrpiece;
        public frmrptInvExpDetailsEdit()
        {
            InitializeComponent();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();

            string sqlstatement;
            sqlstatement = "UPDATE tblMain2 set ExpDate=@_ExpDate  WHERE IC ='" + txtIC.Text + "' AND Num = '" + txtNum.Text + "'";
            mycommand = new SqlCommand(sqlstatement, myconnection);
            mycommand.Parameters.Add("_ExpDate", SqlDbType.DateTime).Value = txtExpDate.Text;
            mycommand.CommandTimeout = 600;
            int n2 = mycommand.ExecuteNonQuery();

            Form EntryForm = Application.OpenForms["frmrptInvExpDetails"];
            if (EntryForm != null)
            {
                frmrptInvExpDetails CloseEntryForm = (frmrptInvExpDetails)Application.OpenForms["frmrptInvExpDetails"];
                CloseEntryForm.Close();
            }
            this.Close();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmrptInvExpDetails_Load(object sender, EventArgs e)
        {
            txtIC.Text = frmrptInvExpDetails.glbldgvED.CurrentRow.Cells[2].Value.ToString();
            txtNum.Text = frmrptInvExpDetails.glbldgvED.CurrentRow.Cells[3].Value.ToString();
            txtStockNumber.Text = frmrptInvExpDetails.glbldgvED.CurrentRow.Cells[4].Value.ToString();
            txtExpDate.Text = frmrptInvExpDetails.glbldgvED.CurrentRow.Cells[1].Value.ToString();
            //txtExpDate1.Text = frmrptInvExpDetails.glbldgvED.CurrentRow.Cells[1].Value.ToString();
            txtCS.Text = frmrptInvExpDetails.glbldgvED.CurrentRow.Cells[0].Value.ToString();
        }

    }
}
