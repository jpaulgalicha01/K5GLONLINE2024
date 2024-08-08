using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;

namespace K5GLONLINE
{
    public partial class frmrptSalesmanCollect : Form
    {
        SqlConnection myconnection;
       // SqlDataReader dr;
        //SqlCommand mycommand;
        BindingSource dbind = new BindingSource();
        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();
        ClsBuildVoucherComboBox ClsBuildVoucherComboBox1 = new ClsBuildVoucherComboBox(); 
        ClsCompName ClsCompName1 = new ClsCompName();
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection(); 

        public frmrptSalesmanCollect()
        {
            InitializeComponent();
        }
        private void txtBeginDate_Leave(object sender, EventArgs e)
        {
            if (new ClsValidation().errordate(txtBeginDate.Text) == true)
            {
                MessageBox.Show("Invalid Date", "GL");
                txtBeginDate.Focus();
            }

        }

        private void txtEndDate_Leave(object sender, EventArgs e)
        {
            if (new ClsValidation().errordate(txtEndDate.Text) == true)
            {
                MessageBox.Show("Invalid Date", "GL");
                txtEndDate.Focus();
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (new ClsValidation().emptytxt (cbortprint.Text))
            {
                MessageBox.Show("Please complete your entry", "GL");
                cbortprint.Focus();
            }
            else if (new ClsValidation().emptytxt(cboPC.Text))
            {
                MessageBox.Show("Please complete your entry", "GL");
                cboPC.Focus();
            }
            else if (txtBeginDate.Text == "  /  /")
            {
                MessageBox.Show("Please complete your entry", "GL");
                txtBeginDate.Focus();
            }
            else if (txtEndDate.Text == "  /  /")
            {
                MessageBox.Show("Please complete your entry", "GL");
                txtEndDate.Focus();
            }
            else if (Convert.ToDateTime(txtBeginDate.Text) > Convert.ToDateTime(txtEndDate.Text))
            {
                MessageBox.Show("Beginning date is greater than ending date");
                txtBeginDate.Focus();
            }
            else
            {

                if (cbortprint.Text == "Detailed With RV")
                {
                    SCRV();
                }
                else if (cbortprint.Text == "Detailed With RV - VD")
                {
                    SCRVVD();
                }
            }
        }
                private void SCRV()
                {

                    string sqlstatement;
                    ClsGetConnection1.ClsGetConMSSQL(); myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                    myconnection.Open();

                    sqlstatement = "SELECT TDate, Voucher, ColType, Reference, CustName, PersonnelName, Amount, Remarks FROM ViewPCCashSum ";
                    sqlstatement += "WHERE TDate Between '" + txtBeginDate.Text + "' And  '" + txtEndDate.Text + "' AND PC = '" + cboPC.SelectedValue.ToString() + "'";

                    SqlDataAdapter dscmd = new SqlDataAdapter(sqlstatement, myconnection);
                    dscmd.SelectCommand.CommandTimeout = 600;
                    DSPCCol DSPCCol1 = new DSPCCol();
                    dscmd.Fill(DSPCCol1, "ViewPCCashSum");
                    myconnection.Close();


                    CRSalesmanCollect objRpt = new CRSalesmanCollect();
                    TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
                    vartxtcompany.Text = Form1.glblncompany.Text;

                    TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
                    vartxtaddress.Text = Form1.glbladdress.Text;

                    TextObject varrpttoSalesman = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoSalesman"];
                    varrpttoSalesman.Text = cboPC.Text;

                    TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rptrangedate"];
                    varrpttoenterdate.Text = "From " + txtBeginDate.Text + " To " + txtEndDate.Text;

                    objRpt.SetDataSource(DSPCCol1.Tables[1]);
                    crystalReportViewer1.ReportSource = objRpt;
                    crystalReportViewer1.Refresh();
                }

                private void SCRVVD()
                {

                    string sqlstatement;
                    ClsGetConnection1.ClsGetConMSSQL(); myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                    myconnection.Open();

                    sqlstatement = "SELECT VDate As TDate, Voucher, ColType, Reference, CustName, PersonnelName, Amount, Remarks FROM ViewPCCashSum ";
                    sqlstatement += "WHERE VDate Between '" + txtBeginDate.Text + "' And  '" + txtEndDate.Text + "' AND PC = '" + cboPC.SelectedValue.ToString() + "'";

                    SqlDataAdapter dscmd = new SqlDataAdapter(sqlstatement, myconnection);
                    dscmd.SelectCommand.CommandTimeout = 600;
                    DSPCCol DSPCCol1 = new DSPCCol();
                    dscmd.Fill(DSPCCol1, "ViewPCCashSum");
                    myconnection.Close();


                    CRSalesmanCollect objRpt = new CRSalesmanCollect();
                    TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
                    vartxtcompany.Text = Form1.glblncompany.Text;

                    TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
                    vartxtaddress.Text = Form1.glbladdress.Text;

                    TextObject varrpttoSalesman = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoSalesman"];
                    varrpttoSalesman.Text = cboPC.Text;

                    TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rptrangedate"];
                    varrpttoenterdate.Text = "From " + txtBeginDate.Text + " To " + txtEndDate.Text;

                    objRpt.SetDataSource(DSPCCol1.Tables[1]);
                    crystalReportViewer1.ReportSource = objRpt;
                    crystalReportViewer1.Refresh();
                }

                private void frmrptSalesmanCollect_Load(object sender, EventArgs e)
                {
                    ClsPermission1.ClsObjects(this.Text);
                    if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
                    {
                        MessageBox.Show("You do not have necessary permission to open this file", "GL");
                        this.Close();
                    }
                    else
                    {
                        buildcboSalesman();
                        this.WindowState = FormWindowState.Maximized;
                    }
                }
                private void buildcboSalesman()
                {
                    cboPC.DataSource = null;
                    ClsBuildVoucherComboBox1.ARLSLS.Clear();
                    ClsBuildVoucherComboBox1.ClsBuildSalesman();
                    this.cboPC.DataSource = (ClsBuildVoucherComboBox1.ARLSLS);
                    this.cboPC.DisplayMember = "Display";
                    this.cboPC.ValueMember = "Value";
                }
       
        private void nextfieldenter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboPC_Validating(object sender, CancelEventArgs e)
        {
                if (new ClsValidation().emptytxt(cboPC.Text))
                {
                }
                else if (cboPC.Text != null && cboPC.SelectedValue == null)
                {
                    MessageBox.Show("Not found");
                    cboPC.Focus();
                }
           
        }

      
   
    
    }
}
