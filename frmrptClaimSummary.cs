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
    public partial class frmrptClaimSummary : Form
    {
        SqlConnection myconnection;
        BindingSource dbind = new BindingSource();
        ClsCompName ClsCompName1 = new ClsCompName();
        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();
        ClsGetSomething ClsGetSomething1 = new ClsGetSomething();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsBuildVoucherComboBox ClsBuildVoucherComboBox1 = new ClsBuildVoucherComboBox();
        SqlDataReader SqlDataReader1;
        SqlCommand mycommand;
        public frmrptClaimSummary()
        {
            InitializeComponent();

        }



        private void btnPreview_Click(object sender, EventArgs e)
        {
            if ((new ClsValidation().emptytxt(cboDept.Text)))
            {
                MessageBox.Show("Please complete your entry", "GL");
                cboDept.Focus();
            }
            else if(cbYear.Checked)
            {
                ClaimSUmmaryYear();
            }
            else
            {
                ClaimSUmmary();
            }
        }

        private void ClaimSUmmary()
        {
            string sqlstatement;
            sqlstatement = "SELECT * FROM ViewBookClaims WHERE D2Desc= '" + cboDept.Text + "' AND FldMonth='" + cboMonth.SelectedValue.ToString() + "'";
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = myconnection.CreateCommand();
            mycommand.CommandText = sqlstatement;
            mycommand.CommandTimeout = 900;
            SqlDataReader1 = mycommand.ExecuteReader();
            DataTable DataTable1 = new DataTable();
            DataTable1.Load(SqlDataReader1);
            myconnection.Close();
            if (DataTable1.Rows.Count == 0)
            {
                MessageBox.Show("No Data Found!", "Warning");
                return;
            }
            CRClaimSummary objRpt = new CRClaimSummary();

            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            ClsCompName1.ClsCompNameMain();
            vartxtcompany.Text = ClsCompName1.varcn;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = ClsCompName1.varaddress;

            TextObject varUser = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["User"];
            varUser.Text = Form1.glbluc.Text;

            TextObject vartxtMonthYear = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["txtMonthYear"];
            vartxtMonthYear.Text = "Month";

            TextObject varrpttxtdata = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtdata"];
            varrpttxtdata.Text = cboMonth.Text;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }
        
        private void ClaimSUmmaryYear()
        {
            string sqlstatement;
            sqlstatement = "SELECT * FROM ViewBookClaims WHERE D2Desc= '" + cboDept.Text + "' AND Year='" + cboYear.SelectedValue.ToString() + "'";
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = myconnection.CreateCommand();
            mycommand.CommandText = sqlstatement;
            mycommand.CommandTimeout = 900;
            SqlDataReader1 = mycommand.ExecuteReader();
            DataTable DataTable1 = new DataTable();
            DataTable1.Load(SqlDataReader1);
            myconnection.Close();
            if (DataTable1.Rows.Count == 0)
            {
                MessageBox.Show("No Data Found!", "Warning");
                return;
            }
            CRClaimSummary objRpt = new CRClaimSummary();

            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            ClsCompName1.ClsCompNameMain();
            vartxtcompany.Text = ClsCompName1.varcn;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = ClsCompName1.varaddress;

            TextObject varUser = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["User"];
            varUser.Text = Form1.glbluc.Text;
            
            TextObject vartxtMonthYear = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["txtMonthYear"];
            vartxtMonthYear.Text = "Year";

            TextObject varrpttxtdata = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtdata"]; 
            varrpttxtdata.Text = cboYear.Text;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }

        private void frmrptClaimSummary_Load(object sender, EventArgs e)
        {
            ClsPermission1.ClsObjects(this.Text);
            if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
            {
                MessageBox.Show("You do not have necessary permission to open this file", "GL");
                this.Close();
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                buildcboClsBuildDept();
            }
        }

        private void nextfieldenter2(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }

        }
        private void buildcboClsBuildDept()
        {
            cboDept.DataSource = null;
            ClsBuildVoucherComboBox1.ARD2Code.Clear();
            ClsBuildVoucherComboBox1.ClsBuildDept();
            this.cboDept.DataSource = (ClsBuildVoucherComboBox1.ARD2Code);
            this.cboDept.DisplayMember = "Display";
            this.cboDept.ValueMember = "Value";
        }

        private void buildcboClsMonth()
        {
            cboMonth.DataSource = null;
            ClsBuildVoucherComboBox1.ARMonth.Clear();
            ClsBuildVoucherComboBox1.ClsBuildMonthClaims(cboDept.SelectedValue.ToString());
            this.cboMonth.DataSource = (ClsBuildVoucherComboBox1.ARMonth);
            this.cboMonth.DisplayMember = "Display";
            this.cboMonth.ValueMember = "Value";
            //=================== get max date ==========================
            //txtBeginDate.Text = ClsBuildVoucherComboBox1.PDate;
            //txtEndDate.Text = ClsBuildVoucherComboBox1.PDate;
        }
        
        private void buildcboClsYear()
        {
            cboYear.DataSource = null;
            ClsBuildVoucherComboBox1.ARYear.Clear();
            ClsBuildVoucherComboBox1.ClsBuildYearClaims(cboDept.SelectedValue.ToString());
            this.cboYear.DataSource = (ClsBuildVoucherComboBox1.ARYear);
            this.cboYear.DisplayMember = "Display";
            this.cboYear.ValueMember = "Value";
            //=================== get max date ==========================
            //txtBeginDate.Text = ClsBuildVoucherComboBox1.PDate;
            //txtEndDate.Text = ClsBuildVoucherComboBox1.PDate;
        }

        private void cboDept_Validating(object sender, CancelEventArgs e)
        {
            buildcboClsMonth();
            buildcboClsYear();
        }

        private void cboMonth_Validating(object sender, CancelEventArgs e)
        {


        }

        private void cbYear_CheckedChanged(object sender, EventArgs e)
        {
            if (cbYear.Checked)
            {
                cboYear.Enabled = true;
                cboMonth.Enabled = false;
                buildcboClsYear();
            }
            else
            {
                cboYear.Enabled = false;
                cboMonth.Enabled = true;
                buildcboClsMonth();
            }
        }
    }
}
