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
    public partial class frmrptReceivableStatus : Form
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
        public frmrptReceivableStatus()
        {
            InitializeComponent();
            cbortprint.DisplayMember = "Text";
            cbortprint.ValueMember = "Value";
            cbortprint.SelectedValue = "01";

            var items = new[]
            {
             new { Text = "Receivable Status", Value = "01" },
             new { Text = "Receivable Status - Detailed", Value = "02" },
             new { Text = "Receivable Status - As of", Value = "03" },
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

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (cbortprint.SelectedValue.ToString() == "01")
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
                else
                {
                    ReceivableStatus();
                }
            }
            else if (cbortprint.SelectedValue.ToString() == "02")
            {
                if ((new ClsValidation().emptytxt(cbortprint.Text)) || (txtBeginDate.Text == "  /  /") || (txtEndDate.Text == "  /  /") || (new ClsValidation().emptytxt(cboSalesman.Text)) || (Convert.ToDateTime(txtBeginDate.Text) > Convert.ToDateTime(txtEndDate.Text)))
                {
                    MessageBox.Show("Please complete your entry", "GL");
                    cbortprint.Focus();
                }
                else if (Convert.ToDateTime(txtBeginDate.Text) > Convert.ToDateTime(txtEndDate.Text))
                {
                    MessageBox.Show("Beginning date is greater than ending date", "GL");
                    cbortprint.Focus();
                }
                else
                {
                    ReceivableStatusDetailedBetween();
                }
            }

            else if (cbortprint.SelectedValue.ToString() == "03")
            {
                if (new ClsValidation().emptytxt(cbortprint.Text))
                {
                    MessageBox.Show("Please complete your entry", "GL");
                    cbortprint.Focus();
                }
                else if (txtBeginDate.Text == "  /  /")
                {
                    MessageBox.Show("Please complete your entry", "GL");
                    cbortprint.Focus();
                }
                else if (txtEndDate.Text == "  /  /")
                {
                    MessageBox.Show("Please complete your entry", "GL");
                    cbortprint.Focus();
                }
                else if (new ClsValidation().emptytxt(cboSalesman.Text))
                {
                    MessageBox.Show("Please complete your entry", "GL");
                    cbortprint.Focus();
                }
                else if (Convert.ToDateTime(txtBeginDate.Text) > Convert.ToDateTime(txtEndDate.Text))
                {
                    MessageBox.Show("Beginning date is greater than ending date", "GL");
                    cbortprint.Focus();
                }
                else
                {
                    ReceivableStatusDetailedasof();
                }
            }
        }

            private void ReceivableStatus()
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("usp_ReceivableStatus2", myconnection);
                mycommand.CommandType = CommandType.StoredProcedure;

                mycommand.Parameters.Add("@Parambegindate1", SqlDbType.DateTime).Value = txtBeginDate.Text;
                mycommand.Parameters.Add("@Paramenddate1", SqlDbType.DateTime).Value = txtEndDate.Text;

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

                CRReceivableStatus objRpt = new CRReceivableStatus();

                TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
                ClsCompName1.ClsCompNameMain();
                vartxtcompany.Text = ClsCompName1.varcn;

                TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
                vartxtaddress.Text = ClsCompName1.varaddress;

                TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextDateRange"];
                varrpttoenterdate.Text = "From: " + txtBeginDate.Text + " To: " + txtEndDate.Text;

                TextObject varrpttxtObjectTitle = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["txtObjectTitle"];
                varrpttxtObjectTitle.Text = "Receivable Status";

                objRpt.SetDataSource(DataTable1);
                crystalReportViewer1.ReportSource = objRpt;
                crystalReportViewer1.Refresh();
            }

            private void ReceivableStatusDetailedBetween()
            {
                string sqlstatement;
                sqlstatement = "SELECT CustName, Refer, MAX(Term) As MaxTerm, MIN(TDate) As MinTDate, SUM(TotalInvoice) As SumTotalInvoice, SUM(TotalPayment) As SumTotalPayment ";
                sqlstatement += "FROM ViewReceivableStatusDetailed1  GROUP BY CustName, Refer ";
            sqlstatement += "HAVING MIN(TDate) BETWEEN '" + txtBeginDate.Text + "' And  '" + txtEndDate.Text + "' AND (SUBSTRING(MIN(FirstPC), 9, 3)) = '" + cboSalesman.SelectedValue.ToString() + "' AND (SUM(TotalInvoice)-SUM(TotalPayment))<>0 ORDER BY CustName, MinTDate";
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

                CRReceivableStatusDetailed objRpt = new CRReceivableStatusDetailed();
                TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
                ClsCompName1.ClsCompNameMain();
                vartxtcompany.Text = ClsCompName1.varcn;

                TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
                vartxtaddress.Text = ClsCompName1.varaddress;

                TextObject varTextSalesman = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextSalesman"];
                varTextSalesman.Text = cboSalesman.Text;

                TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextDateRange"];
                varrpttoenterdate.Text = "From:" + txtBeginDate.Text + "To:" + txtEndDate.Text;

                TextObject varrpttxtObjectTitle = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["txtObjectTitle"];
                varrpttxtObjectTitle.Text = "Receivable Status";

                objRpt.SetDataSource(DataTable1);

                crystalReportViewer1.ReportSource = objRpt;
                crystalReportViewer1.Refresh();
            }
        

        private void ReceivableStatusDetailedasof()
        {

            //ClsGetConnection1.ClsGetConMSSQL();
            //myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            //myconnection.Open();
            //mycommand = new SqlCommand("usp_ReceivableStatusASof", myconnection);
            //mycommand.CommandType = CommandType.StoredProcedure;

            //mycommand.Parameters.Add("@Paramdate1", SqlDbType.DateTime).Value = txtEndDate.Text;
            //mycommand.Parameters.Add("@ParamPC1", SqlDbType.VarChar).Value = cboSalesman.SelectedValue.ToString();
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
            //    CRReceivableStatusDetailed objRpt = new CRReceivableStatusDetailed();

            //    TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            //    ClsCompName1.ClsCompNameMain();
            //    vartxtcompany.Text = ClsCompName1.varcn;

            //    TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            //    vartxtaddress.Text = ClsCompName1.varaddress;

            //    TextObject varTextSalesman = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextSalesman"];
            //    varTextSalesman.Text = cboSalesman.Text;

            //    TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextDateRange"];
            //    varrpttoenterdate.Text = "AS of " + txtEndDate.Text;

            //    TextObject varrpttxtObjectTitle = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["txtObjectTitle"];
            //    varrpttxtObjectTitle.Text = "Receivable Status";

            //    objRpt.SetDataSource(DataTable1);

            //    crystalReportViewer1.ReportSource = objRpt;
            //    crystalReportViewer1.Refresh();
            string sqlstatement;
            sqlstatement = "SELECT CustName, Refer, MAX(Term) As MaxTerm, MIN(TDate) As MinTDate, SUM(TotalInvoice) As SumTotalInvoice, SUM(TotalPayment) As SumTotalPayment ";
            sqlstatement += "FROM ViewReceivableStatusDetailed1  WHERE TDate <= '" + txtEndDate.Text + "' GROUP BY CustName, Refer ";
            sqlstatement += "HAVING (SUBSTRING(MIN(FirstPC), 9, 3)) = '" + cboSalesman.SelectedValue.ToString() + "' AND (SUM(TotalInvoice)-SUM(TotalPayment))<>0 ORDER BY MinTDate";
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

            CRReceivableStatusDetailed objRpt = new CRReceivableStatusDetailed();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            ClsCompName1.ClsCompNameMain();
            vartxtcompany.Text = ClsCompName1.varcn;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = ClsCompName1.varaddress;

            TextObject varTextSalesman = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextSalesman"];
            varTextSalesman.Text = cboSalesman.Text;

            TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextDateRange"];
            varrpttoenterdate.Text = "From:" + txtBeginDate.Text + "To:" + txtEndDate.Text;

            TextObject varrpttxtObjectTitle = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["txtObjectTitle"];
            varrpttxtObjectTitle.Text = "Receivable Status";

            objRpt.SetDataSource(DataTable1);

            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }
        
        private void frmrptReceivableStatus_Load(object sender, EventArgs e)
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
                buildcboASMCode();
                txtEndDate.Text = ClsGetSomething1.plsdefdate;
                cboSalesman.SelectedValue = "";
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
        private void buildcboASMCode()
        {
            cboSalesman.DataSource = null;
            ClsBuildVoucherComboBox1.ARLSLS.Clear();
            ClsBuildVoucherComboBox1.ClsBuildSalesman();
            this.cboSalesman.DataSource = (ClsBuildVoucherComboBox1.ARLSLS);
            this.cboSalesman.DisplayMember = "Display";
            this.cboSalesman.ValueMember = "Value";
        }
        private void cbortprint_Validating(object sender, CancelEventArgs e)
        {

        }

        private void cbortprint_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbortprint.SelectedValue.ToString() == "01")
            {
                lblBeginDate.Visible = true;
                lblEndDate.Visible = true;
                txtBeginDate.Visible = true;
                txtEndDate.Visible = true;
                cboSalesman.Enabled = false;
                lblEndDate.Text = "End Date";
            }

            else if (cbortprint.SelectedValue.ToString() == "02")
            {
                lblBeginDate.Visible = true;
                lblEndDate.Visible = true;
                txtBeginDate.Visible = true;
                txtEndDate.Visible = true;
                cboSalesman.Enabled = true;
                lblSalesman.Enabled = true;
                lblEndDate.Text = "End Date";
            }

            else if (cbortprint.SelectedValue.ToString() == "03")
            {
                lblBeginDate.Visible = false;
                lblEndDate.Visible = true;
                txtBeginDate.Visible = false;
                txtEndDate.Visible = true;
                cboSalesman.Enabled = true;
                lblEndDate.Text = "As of";

            }
        }
    }
}

