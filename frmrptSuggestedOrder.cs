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
    public partial class frmrptSuggestedOrder : Form
    {
        SqlConnection myconnection;
        BindingSource dbind = new BindingSource();
        ClsCompName ClsCompName1 = new ClsCompName();
        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();
        ClsGetSomething ClsGetSomething1 = new ClsGetSomething();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsBuildVoucherComboBox ClsBuildVoucherComboBox1 = new ClsBuildVoucherComboBox();
        ClsBuildEntryComboBox ClsBuildEntryComboBox1 = new ClsBuildEntryComboBox();
        SqlDataReader SqlDataReader1;
        SqlCommand mycommand;
        string sqlstatement1;

        public frmrptSuggestedOrder()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
            if (txtBeginDate.Text == "  /  /")
            {
                MessageBox.Show("Beginning date is empty", "GL");
                txtBeginDate.Focus();
            }
            else if (txtEndDate.Text == "  /  /")
            {
                MessageBox.Show("Ending date is empty", "GL");
                txtEndDate.Focus();
            }
            else if (txtEnterDate.Text == "  /  /")
            {
                MessageBox.Show("As of date is empty", "GL");
                txtEnterDate.Focus();
            }
            else if (string.IsNullOrEmpty(cboSupplierCode.Text))
            {
                MessageBox.Show("Principal is empty", "GL");
                cboSupplierCode.Focus();
            }
            else if (string.IsNullOrEmpty(cboWHCode.Text))
            {
                MessageBox.Show("Warehouse is empty", "GL");
                cboWHCode.Focus();
            }

            else if (Convert.ToDateTime(txtBeginDate.Text) > Convert.ToDateTime(txtEndDate.Text))
            {
                MessageBox.Show("Beginning date is greater than ending date", "GL");
                txtBeginDate.Focus();
            }
            else
            {
                SuggestedOrder();
            }
        }

        private void SuggestedOrder()
        {
            int intNoMonth = new ClsDateDiff().GetMonths(DateTime.Parse(txtBeginDate.Text), DateTime.Parse(txtEndDate.Text));

            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();

            mycommand = new SqlCommand("usp_Suggested3", myconnection);
            mycommand.CommandType = CommandType.StoredProcedure;
            mycommand.Parameters.Add("@Parambegindate2", SqlDbType.DateTime).Value = txtBeginDate.Text;
            mycommand.Parameters.Add("@Paramenddate2", SqlDbType.DateTime).Value = txtEndDate.Text;
            mycommand.Parameters.Add("@ParamClassCode2", SqlDbType.VarChar).Value = cboSupplierCode.SelectedValue.ToString();
            mycommand.Parameters.Add("@ParamNOM2", SqlDbType.Int).Value = intNoMonth;
            mycommand.Parameters.Add("@Paramenterdate2", SqlDbType.DateTime).Value = txtEnterDate.Text;
            mycommand.Parameters.Add("@ParamWHCode2", SqlDbType.VarChar).Value = cboWHCode.SelectedValue.ToString();

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

            CRSuggestedOrder objRpt = new CRSuggestedOrder();

            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            ClsCompName1.ClsCompNameMain();
            vartxtcompany.Text = ClsCompName1.varcn;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            TextObject varTextReportTitle = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextReportTitle"];
            varTextReportTitle.Text = "SUGGESTED ORDER";

            TextObject varTextAsOfDate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextAsOfDate"];
            varTextAsOfDate.Text = "As of "+txtEnterDate.Text;

            TextObject varrptrangedate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rptrangedate"];
            varrptrangedate.Text = "From: "+txtBeginDate.Text + " To: " + txtEndDate.Text;

            TextObject varTextWarehouse = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextWarehouse"];
            varTextWarehouse.Text = cboWHCode.Text;

            TextObject varTextPrincipal = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextPrincipal"];
            varTextPrincipal.Text = cboSupplierCode.Text;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }
        private void frmrptSuggestedOrder_Load(object sender, EventArgs e)
        {
            ClsPermission1.ClsObjects(this.Text);
            if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
            {
                MessageBox.Show("You do not have necessary permission to open this file", "GL");
                this.Close();
            }
            else
            {
                ClsGetSomething1.ClsGetDefaultDate();
                txtBeginDate.Text = ClsGetSomething1.plsdefdate;
                txtEndDate.Text = ClsGetSomething1.plsdefdate;
                txtEnterDate.Text = ClsGetSomething1.plsdefdate;
                this.WindowState = FormWindowState.Maximized;
                buildcboPrinCode();
                buildcboWHCode();
                cboSupplierCode.SelectedValue = "";
                cboWHCode.SelectedValue = "";
            }
        }

       

        private void txtBeginDate_Leave_1(object sender, EventArgs e)
        {
            if (new ClsValidation().errordate(txtBeginDate.Text) == true)
            {
                MessageBox.Show("Invalid Date", "GL");
                txtBeginDate.Focus();
            }
        }

        private void txtEndDate_Leave_1(object sender, EventArgs e)
        {
            if (new ClsValidation().errordate(txtEndDate.Text) == true)
            {
                MessageBox.Show("Invalid Date", "GL");
                txtEndDate.Focus();
            }
        }

        private void nextfieldenter1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
            else if ((e.KeyCode.Equals(Keys.Up)) || (e.KeyCode.Equals(Keys.Left)))
            {
                SendKeys.Send("+{TAB}");
            }
            else if ((e.KeyCode.Equals(Keys.Down)) || (e.KeyCode.Equals(Keys.Right)))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void nextfieldenter2(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }

        }
        private void buildcboPrinCode()
        {
            cboSupplierCode.DataSource = null;
            ClsBuildComboBox1.PLAStockClass.Clear();
            ClsBuildComboBox1.ClsBuildStockClass();
            this.cboSupplierCode.DataSource = (ClsBuildComboBox1.PLAStockClass);
            this.cboSupplierCode.DisplayMember = "Display";
            this.cboSupplierCode.ValueMember = "Value";
        }

        private void buildcboWHCode()
        {
            cboWHCode.DataSource = null;
            ClsBuildVoucherComboBox1.ARLWHCode.Clear();
            ClsBuildVoucherComboBox1.ClsBuildWarehouse();
            this.cboWHCode.DataSource = (ClsBuildVoucherComboBox1.ARLWHCode);
            this.cboWHCode.DisplayMember = "Display";
            this.cboWHCode.ValueMember = "Value";
        }


        private void cboSupplierCode_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().emptytxt(cboSupplierCode.Text))
            {
            }
            else if (cboSupplierCode.Text != null && cboSupplierCode.SelectedValue == null)
            {
                MessageBox.Show("Not found", "GL");
                cboSupplierCode.Focus();
            }
        }

        private void txtEnterDate_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().errordate(txtEnterDate.Text) == true)
            {
                MessageBox.Show("Invalid Date", "GL");
                txtEnterDate.Focus();
            }
        }

        private void cboWHCode_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().emptytxt(cboWHCode.Text))
            {
            }
            else if (cboWHCode.Text != null && cboWHCode.SelectedValue == null)
            {
                MessageBox.Show("Not found", "GL");
                cboWHCode.Focus();
            }
        }
    }
}
