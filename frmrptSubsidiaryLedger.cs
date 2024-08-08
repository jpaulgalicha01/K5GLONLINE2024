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
    public partial class frmrptSubsidiaryLedger : Form
    {
        SqlConnection myconnection;
       // SqlDataReader dr;
        SqlCommand mycommand;
        BindingSource dbind = new BindingSource();
        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();
        ClsCompName ClsCompName1 = new ClsCompName();
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        SqlDataReader SqlDataReader1;

        public frmrptSubsidiaryLedger()
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
            else if (txtBeginDate.Text=="  /  /")
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

                if (cbortprint.Text == "Subsidiary Ledger - 3")
                {
                    sl3();
                }
                else if (cbortprint.Text == "Subsidiary Ledger - 1")
                {
                    sl1();
                }
            }
        }
                private void sl3()
                {

                    ClsGetConnection1.ClsGetConMSSQL();
                    myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                    myconnection.Open();
                    mycommand = new SqlCommand("usp_subsidiaryledger2", myconnection);
                    mycommand.CommandType = CommandType.StoredProcedure;

                    mycommand.Parameters.Add("@ParamPA2", SqlDbType.VarChar).Value = cboActTitle.SelectedValue.ToString();
                    mycommand.Parameters.Add("@Parambegindate2", SqlDbType.DateTime).Value = txtBeginDate.Text;
                    mycommand.Parameters.Add("@Paramenddate2", SqlDbType.DateTime).Value = txtEndDate.Text;


                    SqlDataAdapter dscmd = new SqlDataAdapter();
                    dscmd.SelectCommand = mycommand;
                    mycommand.CommandTimeout = 600;
                    DSSL1 dssl1 = new DSSL1();
                    dscmd.Fill(dssl1, "viewsubsidiaryledger");
                    myconnection.Close();

                    //mycommand.CommandTimeout = 900;
                    //SqlDataReader1 = mycommand.ExecuteReader();
                    //DataTable DataTable1 = new DataTable();
                    //DataTable1.Load(SqlDataReader1);
                    //myconnection.Close();

                    //if (DataTable1.Rows.Count == 0)
                    //{
                    //    MessageBox.Show("No data found", "GL");
                    //    return;
                    //}

                    CRSubsidiaryLedger objRpt = new CRSubsidiaryLedger();
                    TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
                    vartxtcompany.Text = Form1.glblncompany.Text;

                    TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
                    vartxtaddress.Text = Form1.glbladdress.Text;

                    TextObject varrptAcctTitle = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rptAcctTitle"];
                    varrptAcctTitle.Text = cboActTitle.Text;

                    TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rptrangedate"];
                    varrpttoenterdate.Text = "From " + txtBeginDate.Text + " To " + txtEndDate.Text;

                    objRpt.SetDataSource(dssl1.Tables[1]);
                    crystalReportViewer1.ReportSource = objRpt;
                    crystalReportViewer1.Refresh();
                }

                private void sl1()
                {

                    ClsGetConnection1.ClsGetConMSSQL();
                    myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                    myconnection.Open();
                    mycommand = new SqlCommand("usp_subsidiaryledgerSL2", myconnection);
                    mycommand.CommandType = CommandType.StoredProcedure;

                    mycommand.Parameters.Add("@ParamPA2", SqlDbType.VarChar).Value = cboActTitle.SelectedValue.ToString();
                    mycommand.Parameters.Add("@Parambegindate2", SqlDbType.DateTime).Value = txtBeginDate.Text;
                    mycommand.Parameters.Add("@Paramenddate2", SqlDbType.DateTime).Value = txtEndDate.Text;


                    SqlDataAdapter dscmd = new SqlDataAdapter();
                    dscmd.SelectCommand = mycommand;
                    mycommand.CommandTimeout = 600;
                    DSSL1 dssl1 = new DSSL1 ();
                    dscmd.Fill(dssl1, "viewsubsidiaryledger1");
                    myconnection.Close();

                    //mycommand.CommandTimeout = 900;
                    //SqlDataReader1 = mycommand.ExecuteReader();
                    //DataTable DataTable1 = new DataTable();
                    //DataTable1.Load(SqlDataReader1);
                    //myconnection.Close();

                    //if (DataTable1.Rows.Count == 0)
                    //{
                    //    MessageBox.Show("No data found", "GL");
                    //    return;
                    //}

                    CRSubsidiaryLedger1 objRpt = new CRSubsidiaryLedger1();
                    TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
                    vartxtcompany.Text = Form1.glblncompany.Text;

                    TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
                    vartxtaddress.Text = Form1.glbladdress.Text;

                    TextObject varrptAcctTitle = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rptAcctTitle"];
                    varrptAcctTitle.Text = cboActTitle.Text;

                    TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rptrangedate"];
                    varrpttoenterdate.Text = "From " + txtBeginDate.Text + " To " + txtEndDate.Text;

                    objRpt.SetDataSource(dssl1.Tables[1]);
                    crystalReportViewer1.ReportSource = objRpt;
                    crystalReportViewer1.Refresh();
                }

                private void frmrptSubsidiaryLedger_Load(object sender, EventArgs e)
                {
                    ClsPermission1.ClsObjects(this.Text);
                    if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
                    {
                        MessageBox.Show("You do not have necessary permission to open this file", "GL");
                        this.Close();
                    }
                    else
                    {
                        DateTime dt = DateTime.Today;
                        txtBeginDate.Text = dt.ToString("MM/dd/yyyy");
                        txtEndDate.Text = dt.ToString("MM/dd/yyyy");
                        cbortprint.Items.Add("Subsidiary Ledger - 1");
                        cbortprint.Items.Add("Subsidiary Ledger - 3");
                        buildcboActTitle();
                        this.WindowState = FormWindowState.Maximized;
                    }
                }
        private void buildcboActTitle()
        {
            cboActTitle.DataSource = null;
            ClsBuildComboBox1.ARPA.Clear();
            ClsBuildComboBox1.ClsBuildPA(Convert.ToBoolean(cbAccountNo.CheckState));
            this.cboActTitle.DataSource = ClsBuildComboBox1.ARPA;
            this.cboActTitle.DisplayMember = "Display";
            this.cboActTitle.ValueMember = "Value";
        }

            private void buildcboActnO()
        {
            cboActTitle.DataSource = null;
            ClsBuildComboBox1.ARANPA.Clear();
            ClsBuildComboBox1.ClsBuildAcctNoPA();
            this.cboActTitle.DataSource = ClsBuildComboBox1.ARANPA;
            this.cboActTitle.DisplayMember = "Display";
            this.cboActTitle.ValueMember = "Value";
        }
       
        private void nextfieldenter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboActTitle_Validating(object sender, CancelEventArgs e)
        {
                if (new ClsValidation().emptytxt(cboActTitle.Text))
                {
                }
                else if (cboActTitle.Text != null && cboActTitle.SelectedValue == null)
                {
                    MessageBox.Show("Not found", "GL");
                    cboActTitle.Focus();
                }
        }

        private void cbAccountNo_CheckedChanged(object sender, EventArgs e)
        {
            buildcboActTitle();
        }

        private void cbortprint_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbortprint.Text == "Subsidiary Ledger - 1")
            {
                buildcboActnO();
            }
            else
            {
                buildcboActTitle();
            }
        }
    }
}
