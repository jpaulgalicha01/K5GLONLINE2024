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
    public partial class frmrptIndLedger : Form
    {
        SqlConnection myconnection;
       // SqlDataReader dr;
        SqlCommand mycommand;
        BindingSource dbind = new BindingSource();
        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();
        ClsCompName ClsCompName1 = new ClsCompName();
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        ClsGetSomething ClsGetSomething1 = new ClsGetSomething();
        SqlDataReader SqlDataReader1;
        public frmrptIndLedger()
        {
            InitializeComponent();
            cbortprint.DisplayMember = "Text";
            cbortprint.ValueMember = "Value";
            cbortprint.SelectedValue = "01";
            var items = new[]
            {
             new { Text = "Accounts Receivable - Ledger", Value = "01" },
            // new { Text = "Accounts Receivable - Group Ledger Sort by Date", Value = "02" },
             new { Text = "Accounts Receivable - Group Ledger Sort by Invoice", Value = "02-1" },
             new { Text = "Miscellaneous Liability", Value = "03" },
             new { Text = "Miscellaneous Liability - Group Ledger", Value = "04" },
             new { Text = "Accounts Payable - Ledger", Value = "05" },

            };
            cbortprint.DataSource = items;
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
            if (new ClsValidation().emptytxt(cbortprint.Text))
            {
                MessageBox.Show("Please complete your entry", "GL");
                cbortprint.Focus();
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
                if (cbortprint.SelectedValue.ToString() == "01")//Accounts Receivable - Ledger
                {
                    ARLedger();
                }
                else if (cbortprint.SelectedValue.ToString() == "02")//Accounts Receivable - Group Ledger 1
                {
                    ARLedgerGroup1();
                }
                else if (cbortprint.SelectedValue.ToString() == "02-1")//Accounts Receivable - Group Ledger 2
                {
                    ARLedgerGroup2();
                }
                else if (cbortprint.SelectedValue.ToString() == "03")//Miscellaneous Liability
                {
                    MiscLiab();
                }
                else if (cbortprint.SelectedValue.ToString() == "04")//Miscellaneous Liability
                {
                    MiscLiabGroup();
                }
                else if (cbortprint.SelectedValue.ToString() == "05")//Payables Ledger
                {
                    APLedger();
                }

            }
        }
        private void ARLedger()
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = new SqlCommand("usp_IndLedCust2", myconnection);
            mycommand.CommandType = CommandType.StoredProcedure;

            mycommand.Parameters.Add("@ParamControlNo1", SqlDbType.VarChar).Value = cboControlNo.SelectedValue;
            mycommand.Parameters.Add("@Parambegindate1", SqlDbType.DateTime).Value = txtBeginDate.Text;
            mycommand.Parameters.Add("@Paramenddate1", SqlDbType.DateTime).Value = txtEndDate.Text;
            mycommand.Parameters.Add("@ParamUsage1", SqlDbType.VarChar).Value = "02";

            mycommand.CommandTimeout = 900;
            SqlDataReader1 = mycommand.ExecuteReader();
            DataTable DataTable1 = new DataTable();
            DataTable1.Load(SqlDataReader1);
            myconnection.Close();

            if (DataTable1.Rows.Count == 0)
            {
                MessageBox.Show("No data found", "GL");
                return;
            }

            CRIndLedgerCust objRpt = new CRIndLedgerCust();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject varTextReportTitle = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextReportTitle"];
            varTextReportTitle.Text = "SUBSIDIARY LEDGER";

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            TextObject varrptAcctTitle = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rptAcctTitle"];
            varrptAcctTitle.Text = cboControlNo.Text;

            TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rptrangedate"];
            varrpttoenterdate.Text = "From " + txtBeginDate.Text + " To " + txtEndDate.Text;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }
        
        private void APLedger()
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = new SqlCommand("usp_IndLedCust2", myconnection);
            mycommand.CommandType = CommandType.StoredProcedure;

            mycommand.Parameters.Add("@ParamControlNo1", SqlDbType.VarChar).Value = cboControlNo.SelectedValue;
            mycommand.Parameters.Add("@Parambegindate1", SqlDbType.DateTime).Value = txtBeginDate.Text;
            mycommand.Parameters.Add("@Paramenddate1", SqlDbType.DateTime).Value = txtEndDate.Text;
            mycommand.Parameters.Add("@ParamUsage1", SqlDbType.VarChar).Value = "03";

            mycommand.CommandTimeout = 900;
            SqlDataReader1 = mycommand.ExecuteReader();
            DataTable DataTable1 = new DataTable();
            DataTable1.Load(SqlDataReader1);
            myconnection.Close();

            if (DataTable1.Rows.Count == 0)
            {
                MessageBox.Show("No data found", "GL");
                return;
            }

            CRIndLedgerCust objRpt = new CRIndLedgerCust();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject varTextReportTitle = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextReportTitle"];
            varTextReportTitle.Text = "SUBSIDIARY LEDGER";

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            TextObject varrptAcctTitle = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rptAcctTitle"];
            varrptAcctTitle.Text = cboControlNo.Text;

            TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rptrangedate"];
            varrpttoenterdate.Text = "From " + txtBeginDate.Text + " To " + txtEndDate.Text;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }

        private void ARLedgerGroup1()
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = new SqlCommand("usp_IndLedCust21", myconnection);
            mycommand.CommandType = CommandType.StoredProcedure;

            mycommand.Parameters.Add("@ParamControlNo1", SqlDbType.VarChar).Value = cboControlNo.SelectedValue;
            mycommand.Parameters.Add("@Parambegindate1", SqlDbType.DateTime).Value = txtBeginDate.Text;
            mycommand.Parameters.Add("@Paramenddate1", SqlDbType.DateTime).Value = txtEndDate.Text;
            mycommand.Parameters.Add("@ParamUsage1", SqlDbType.VarChar).Value = "02";

            SqlDataAdapter dscmd = new SqlDataAdapter();
            dscmd.SelectCommand = mycommand;
            mycommand.CommandTimeout = 600;
            DSIndLedger DSIndLedger1 = new DSIndLedger();
            dscmd.Fill(DSIndLedger1, "viewInLedger");
            myconnection.Close();

            CRIndLedgerCustGroup1 objRpt = new CRIndLedgerCustGroup1();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject varTextReportTitle = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextReportTitle"];
            varTextReportTitle.Text = "SUBSIDIARY LEDGER";

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            TextObject varrptAcctTitle = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rptAcctTitle"];
            varrptAcctTitle.Text = cboControlNo.Text;

            TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rptrangedate"];
            varrpttoenterdate.Text = "From " + txtBeginDate.Text + " To " + txtEndDate.Text;

            objRpt.SetDataSource(DSIndLedger1.Tables[1]);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }


        private void ARLedgerGroup2()
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = new SqlCommand("usp_IndLedCust2", myconnection);
            mycommand.CommandType = CommandType.StoredProcedure;

            mycommand.Parameters.Add("@ParamControlNo1", SqlDbType.VarChar).Value = cboControlNo.SelectedValue;
            mycommand.Parameters.Add("@Parambegindate1", SqlDbType.DateTime).Value = txtBeginDate.Text;
            mycommand.Parameters.Add("@Paramenddate1", SqlDbType.DateTime).Value = txtEndDate.Text;
            mycommand.Parameters.Add("@ParamUsage1", SqlDbType.VarChar).Value = "02";

            SqlDataAdapter dscmd = new SqlDataAdapter();
            dscmd.SelectCommand = mycommand;
            mycommand.CommandTimeout = 600;
            DSIndLedger DSIndLedger1 = new DSIndLedger();
            dscmd.Fill(DSIndLedger1, "viewInLedger");
            myconnection.Close();

            CRIndLedgerCustGroup2 objRpt = new CRIndLedgerCustGroup2();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject varTextReportTitle = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextReportTitle"];
            varTextReportTitle.Text = "SUBSIDIARY LEDGER";

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            TextObject varrptAcctTitle = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rptAcctTitle"];
            varrptAcctTitle.Text = cboControlNo.Text;

            TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rptrangedate"];
            varrpttoenterdate.Text = "From " + txtBeginDate.Text + " To " + txtEndDate.Text;

            objRpt.SetDataSource(DSIndLedger1.Tables[1]);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }
        private void MiscLiab()
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = new SqlCommand("usp_MiscLiablilty2", myconnection);
            mycommand.CommandType = CommandType.StoredProcedure;

            mycommand.Parameters.Add("@ParamControlNo1", SqlDbType.VarChar).Value = cboControlNo.SelectedValue;
            mycommand.Parameters.Add("@Parambegindate1", SqlDbType.DateTime).Value = txtBeginDate.Text;
            mycommand.Parameters.Add("@Paramenddate1", SqlDbType.DateTime).Value = txtEndDate.Text;

            mycommand.CommandTimeout = 900;
            SqlDataReader1 = mycommand.ExecuteReader();
            DataTable DataTable1 = new DataTable();
            DataTable1.Load(SqlDataReader1);
            myconnection.Close();

            if (DataTable1.Rows.Count == 0)
            {
                MessageBox.Show("No data found", "GL");
                return;
            }

            CRIndLedgerCust objRpt = new CRIndLedgerCust();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject varTextReportTitle = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextReportTitle"];
            varTextReportTitle.Text = "MISCELANEOUS LIABILITY";

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            TextObject varrptAcctTitle = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rptAcctTitle"];
            varrptAcctTitle.Text = cboControlNo.Text;

            TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rptrangedate"];
            varrpttoenterdate.Text = "From " + txtBeginDate.Text + " To " + txtEndDate.Text;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }

        private void MiscLiabGroup()
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = new SqlCommand("usp_MiscLiablilty2", myconnection);
            mycommand.CommandType = CommandType.StoredProcedure;

            mycommand.Parameters.Add("@ParamControlNo1", SqlDbType.VarChar).Value = cboControlNo.SelectedValue;
            mycommand.Parameters.Add("@Parambegindate1", SqlDbType.DateTime).Value = txtBeginDate.Text;
            mycommand.Parameters.Add("@Paramenddate1", SqlDbType.DateTime).Value = txtEndDate.Text;

            mycommand.CommandTimeout = 900;
            SqlDataReader1 = mycommand.ExecuteReader();
            
            DataTable DataTable1 = new DataTable();
            DataTable1.Load(SqlDataReader1);
            myconnection.Close();

            if (DataTable1.Rows.Count == 0)
            {
                MessageBox.Show("No data found", "GL");
                return;
            }

            CRIndLedgerCustGroup2 objRpt = new CRIndLedgerCustGroup2();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject varTextReportTitle = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextReportTitle"];
            varTextReportTitle.Text = "MISCELANEOUS LIABILITY";

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            TextObject varrptAcctTitle = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rptAcctTitle"];
            varrptAcctTitle.Text = cboControlNo.Text;

            TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rptrangedate"];
            varrpttoenterdate.Text = "From " + txtBeginDate.Text + " To " + txtEndDate.Text;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();

            
        }

        private void frmrptIndLedger_Load(object sender, EventArgs e)
        {
            ClsPermission1.ClsObjects(this.Text);
            if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
            {
                MessageBox.Show("You do not have necessary permission to open this file", "GL");
                this.Close();
            }
            else
            {
                //buildcboControlNo();
                //buildcboControlNoSupp();
                ClsGetSomething1.ClsGetDefaultDate();
                txtBeginDate.Text = ClsGetSomething1.plsdefdate;
                txtEndDate.Text = ClsGetSomething1.plsdefdate;
                this.WindowState = FormWindowState.Maximized;
            }
        }
        private void buildcboControlNo()
        {
            cboControlNo.DataSource = null;
            ClsBuildComboBox1.ARCCN.Clear();
            ClsBuildComboBox1.ClsBuildClientControlno("C");
            this.cboControlNo.DataSource = (ClsBuildComboBox1.ARCCN);
            this.cboControlNo.DisplayMember = "Display";
            this.cboControlNo.ValueMember = "Value";
        }
        private void buildcboControlNoSupp()
        {
            cboControlNo.DataSource = null;
            ClsBuildComboBox1.ARCCN.Clear();
            ClsBuildComboBox1.ClsBuildClientControlno("S");
            this.cboControlNo.DataSource = (ClsBuildComboBox1.ARCCN);
            this.cboControlNo.DisplayMember = "Display";
            this.cboControlNo.ValueMember = "Value";
        }
       
        private void nextfieldenter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboControlNo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (new ClsValidation().emptytxt(cboControlNo.Text))
                {
                }
                else if (cboControlNo.Text != null && cboControlNo.SelectedValue == null)
                {
                    MessageBox.Show("Not found");
                    cboControlNo.Focus();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void cbortprint_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbortprint.SelectedValue.ToString() == "01" || cbortprint.SelectedValue.ToString() == "02-1" || cbortprint.SelectedValue.ToString() == "03" || cbortprint.SelectedValue.ToString() == "04")
            {
                buildcboControlNo();
            }
            else if (cbortprint.SelectedValue.ToString() == "05")
            {
                buildcboControlNoSupp();
            }
        }
    }
}
