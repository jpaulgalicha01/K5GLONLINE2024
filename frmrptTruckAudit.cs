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

    public partial class frmrptTruckAudit : Form
    {
        SqlConnection myconnection;
        BindingSource dbind = new BindingSource();
        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();
        ClsCompName ClsCompName1 = new ClsCompName();
        ClsGetSomething ClsGetSomething1 = new ClsGetSomething(); 
        ClsBuildVoucherComboBox ClsBuildVoucherComboBox1 = new ClsBuildVoucherComboBox();
        ClsPermission ClsPermission1 = new ClsPermission();
        SqlCommand mycommand;
        SqlDataReader SqlDataReader1;
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection(); 

        public frmrptTruckAudit()
        {
            InitializeComponent();
            cbortprint.DisplayMember = "Text";
            cbortprint.ValueMember = "Value";
            cbortprint.SelectedValue = "01";
            var items = new[]
            { 
             new { Text = "Van Audit", Value = "01" },
            };
            cbortprint.DataSource = items;
        }


        private void frmrptIndividualLedger_Load(object sender, EventArgs e)
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
                ClsGetSomething1.ClsGetDefaultDate();
                txtBeginDate.Text = ClsGetSomething1.plsdefdate;
                txtEndDate.Text = ClsGetSomething1.plsdefdate;
                txtLastWeekDate.Text = ClsGetSomething1.plsdefdate;
                txtThisWeekDate.Text = ClsGetSomething1.plsdefdate;
                buildcboWHCode();
            }
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
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (cbortprint.SelectedValue.ToString() == "01")
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
                    VanAudit();
                }
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

        private void VanAudit()
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = new SqlCommand("usp_VanAuditPost", myconnection);
            mycommand.CommandType = CommandType.StoredProcedure;
   
            mycommand.Parameters.Add("@ParamBeginDate2", SqlDbType.DateTime).Value = txtBeginDate.Text;
            mycommand.Parameters.Add("@ParamEndDate2", SqlDbType.DateTime).Value = txtEndDate.Text;
            mycommand.Parameters.Add("@ParamThisWeekDate2", SqlDbType.DateTime).Value = txtThisWeekDate.Text;
            mycommand.Parameters.Add("@ParamLastWeekDate2", SqlDbType.DateTime).Value = txtLastWeekDate.Text;
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

            CRVanAudit objRpt = new CRVanAudit();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            ClsCompName1.ClsCompNameMain();
            vartxtcompany.Text = ClsCompName1.varcn;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = ClsCompName1.varaddress;

            TextObject varTextWHCode = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextWHCode"];
            varTextWHCode.Text = cboWHCode.Text;

            TextObject varTextRangeDate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextRangeDate"];
            varTextRangeDate.Text = "Loading Date: " + txtBeginDate.Text + " Date Counted: " + txtEndDate.Text;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }
    
        private void nextfieldenter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
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


        private void txtBeginDate_Leave(object sender, EventArgs e)
        {
            if (new ClsValidation().errordate(txtBeginDate.Text) == true)
            {
                MessageBox.Show("Invalid Date", "GL");
                txtBeginDate.Focus();
            }
        }

        private void txtLastWeekDate_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().errordate(txtLastWeekDate.Text) == true)
            {
                MessageBox.Show("Invalid Date", "GL");
                txtLastWeekDate.Focus();
            }
        }

        private void txtThisWeekDate_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().errordate(txtThisWeekDate.Text) == true)
            {
                MessageBox.Show("Invalid Date", "GL");
                txtThisWeekDate.Focus();
            }
        }

        private void nextfieldenter2(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

  
    }
}
