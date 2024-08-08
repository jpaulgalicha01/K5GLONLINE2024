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
    public partial class frmrptSalesForce : Form
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
        
        public frmrptSalesForce()
        {
            InitializeComponent();
            cbortprint.DisplayMember = "Text";
            cbortprint.ValueMember = "Value";
            cbortprint.SelectedValue = "01";

            var items = new[]
            {
             new { Text = "Sales Force", Value = "01" },
             new { Text = "Sales Force - Others", Value = "02" },
             new { Text = "Sales Force New", Value = "03" },
            };
            cbortprint.DataSource = items;
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


        private void frmrptSalesForce_Load(object sender, EventArgs e)
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
                this.WindowState = FormWindowState.Maximized;
                buildcboSupplier();
                txtEndDate.Text = ClsGetSomething1.plsdefdate;
                cboSupplier.SelectedIndex = -1;
                cbortprint.SelectedValue = "01";
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
        private void nextfieldenter2(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }

        }
        private void buildcboSupplier()
        {
            cboSupplier.DataSource = null;
            ClsBuildComboBox1.ARCCN.Clear();
            ClsBuildComboBox1.ClsBuildClientControlno("S");
            this.cboSupplier.DataSource = (ClsBuildComboBox1.ARCCN);
            this.cboSupplier.DisplayMember = "Display";
            this.cboSupplier.ValueMember = "Value";
        }

        private void btnPreview_Click_1(object sender, EventArgs e)
        {
            if ((new ClsValidation().emptytxt(cbortprint.Text)) || (txtBeginDate.Text == "  /  /") || (txtEndDate.Text == "  /  /") || /*(new ClsValidation().emptytxt(cboSupplierCode.Text)) ||*/ (Convert.ToDateTime(txtBeginDate.Text) > Convert.ToDateTime(txtEndDate.Text)))
            {
                MessageBox.Show("Please complete your entry", "GL");
                cbortprint.Focus();
            }
            else if (Convert.ToDateTime(txtBeginDate.Text) > Convert.ToDateTime(txtEndDate.Text))
            {
                MessageBox.Show("Beginning date is greater than ending date", "GL");
                cbortprint.Focus();
            }
            else if (cbortprint.SelectedValue.ToString() == "01")
            {
                SalesForce();
            }
            else if (cbortprint.SelectedValue.ToString()=="02")
            {
                SalesForceOthers();
            }
            else if (cbortprint.SelectedValue.ToString() == "03")
            {
                SalesForceOthersNew();
            }
        }


        private void SalesForce()
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = new SqlCommand("usp_SalesForceExcel", myconnection);
            mycommand.CommandType = CommandType.StoredProcedure;
            mycommand.Parameters.Add("@ParamSAFANPoultry", SqlDbType.Bit).Value = cbSFAANPoultry.CheckState;
            mycommand.Parameters.Add("@ParamBeginDate", SqlDbType.DateTime).Value = txtBeginDate.Text;
            mycommand.Parameters.Add("@ParamEndDate", SqlDbType.DateTime).Value = txtEndDate.Text;
            mycommand.Parameters.Add("@ParamControlNo", SqlDbType.VarChar).Value = cboSupplier.SelectedValue.ToString();
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

            CRSalesForce objRpt = new CRSalesForce();
            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }

        private void SalesForceOthers()
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = new SqlCommand("usp_SalesForceExcelOthers", myconnection);
            mycommand.CommandType = CommandType.StoredProcedure;
            mycommand.Parameters.Add("@ParamSAFANPoultry", SqlDbType.Bit).Value = cbSFAANPoultry.CheckState;
            mycommand.Parameters.Add("@ParamBeginDate", SqlDbType.DateTime).Value = txtBeginDate.Text;
            mycommand.Parameters.Add("@ParamEndDate", SqlDbType.DateTime).Value = txtEndDate.Text;
            mycommand.Parameters.Add("@ParamControlNo", SqlDbType.VarChar).Value = cboSupplier.SelectedValue.ToString();
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

            CRSalesForceOthers objRpt = new CRSalesForceOthers();
            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }
        private void SalesForceOthersNew()
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = new SqlCommand("usp_SalesForceExcelOthersNew", myconnection);
            mycommand.CommandType = CommandType.StoredProcedure;
            mycommand.Parameters.Add("@ParamSAFANPoultry", SqlDbType.Bit).Value = cbSFAANPoultry.CheckState;
            mycommand.Parameters.Add("@ParamBeginDate", SqlDbType.DateTime).Value = txtBeginDate.Text;
            mycommand.Parameters.Add("@ParamEndDate", SqlDbType.DateTime).Value = txtEndDate.Text;
            mycommand.Parameters.Add("@ParamControlNo", SqlDbType.VarChar).Value = cboSupplier.SelectedValue.ToString();
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

            CRSalesForceOthersNew objRpt = new CRSalesForceOthersNew();
            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }
    }
}

