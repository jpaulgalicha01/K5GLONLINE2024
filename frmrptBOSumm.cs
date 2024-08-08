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
    public partial class frmrptBOSumm : Form
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
        public frmrptBOSumm()
        {
            InitializeComponent();
            cbortprint.DisplayMember = "Text";
            cbortprint.ValueMember = "Value";
            cbortprint.SelectedValue = "01";

            var items = new[]
            { 
             new { Text = "BO Summary", Value = "01" }, 
             //new { Text = "Sales - Salesman - Detailed", Value = "02" }, 
             //new { Text = "Salesman Sales and BO - All Customer", Value = "03" }, 
             //new { Text = "Salesman Sales and BO - Supplier", Value = "04" }, 
             //new { Text = "Salesman Sales and BO - Customer", Value = "05" }, 
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
                //if ((new ClsValidation().emptytxt(cbortprint.Text)) || (txtBeginDate.Text == "  /  /") || (txtEndDate.Text == "  /  /") || (new ClsValidation().emptytxt(cboSalesman.Text)) || (new ClsValidation().emptytxt(cboSupplierCode.Text)) || (Convert.ToDateTime(txtBeginDate.Text) > Convert.ToDateTime(txtEndDate.Text)))
                //{
                //    MessageBox.Show("Please complete your entry", "GL");
                //    cbortprint.Focus();
                //}
                /*else*/ if (Convert.ToDateTime(txtBeginDate.Text) > Convert.ToDateTime(txtEndDate.Text))
                {
                    MessageBox.Show("Beginning date is greater than ending date", "GL");
                    cbortprint.Focus();
                }
                else
                {
                    SalesSupplierSummary();
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
                    SalesSalesmanDetailed();
                }
            }

            else if (cbortprint.SelectedValue.ToString() == "03")
            {
                if (new ClsValidation().emptytxt(cbortprint.Text)) 
                {
                    MessageBox.Show("Please complete your entry", "GL");
                    cbortprint.Focus();
                }
                else if  (txtBeginDate.Text == "  /  /") 
                {
                    MessageBox.Show("Please complete your entry", "GL");
                    cbortprint.Focus();
                }
                else if  (txtEndDate.Text == "  /  /") 
                {
                    MessageBox.Show("Please complete your entry", "GL");
                    cbortprint.Focus();
                }
                else if  (new ClsValidation().emptytxt(cboSalesman.Text)) 
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
                    SalesmanSalesBOCol();
                }
            }

            else if (cbortprint.SelectedValue.ToString() == "04")//Sales BO Salesman and Supplier param
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
                else if (new ClsValidation().emptytxt(cboSupplierCode.Text))
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
                    SalesmanSalesBOSupplier();
                }
            }

            else if (cbortprint.SelectedValue.ToString() == "05")//Sales BO Customer
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
                else if (new ClsValidation().emptytxt(cboControlNo.Text))
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
                    CustomerSalesBO();
                }
            }

        }
        
        private void SalesSupplierSummary()
        {
            string sqlstatement;
            sqlstatement = "SELECT * FROM ViewBOSumm WHERE TDate BETWEEN '"+txtBeginDate.Text+ "' AND '" + txtEndDate.Text + "'";
            
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

            
            CRBOSumm objRpt = new CRBOSumm();

            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            ClsCompName1.ClsCompNameMain();
            vartxtcompany.Text = ClsCompName1.varcn;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = ClsCompName1.varaddress;

            //TextObject varTextSalesman = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextSalesman"];
            //varTextSalesman.Text = cboSalesman.Text;

            //TextObject varTextSupplier = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextSupplier"];
            //varTextSupplier.Text = cboSupplierCode.Text;

            TextObject varTextDateRange = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextDateRange"];
            varTextDateRange.Text = "From " + txtBeginDate.Text + " To " + txtEndDate.Text;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }
        private void SalesSalesmanDetailed()
        {
            string sqlstatement;
            sqlstatement = "SELECT SupplierName, PClassDesc, CatDesc, StockCode, StockDesc,  SUM(Volume) As Volume, SUM(ConvertedQty) As ConvertedQty, SUM(VAT) As VAT, SUM(GrossAmt) As GrossAmt, SUM(Discount) As Discount ";
            sqlstatement += "FROM ViewSalesSalesman WHERE PC = '" + cboSalesman.SelectedValue.ToString() + "' AND TDate BETWEEN '" + txtBeginDate.Text + "' And  '" + txtEndDate.Text + "'";
            sqlstatement += "GROUP By SupplierName, PClassDesc, CatDesc, StockCode, StockDesc ";


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

            CRSalesmanDetailed objRpt = new CRSalesmanDetailed();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            ClsCompName1.ClsCompNameMain();
            vartxtcompany.Text = ClsCompName1.varcn;

            //ClsCompName1.ClsCompNamebranchAddress(cboCNCode.SelectedValue.ToString());
            //TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            //vartxtaddress.Text = ClsCompName1.plsCRaddress;

            TextObject varTextSalesman = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextSalesman"];
            varTextSalesman.Text = cboSalesman.Text;

            TextObject varTextDateRange = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextDateRange"];
            varTextDateRange.Text = "From " + txtBeginDate.Text + " To " + txtEndDate.Text;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }

        private void SalesmanSalesBOCol()
        {

            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = new SqlCommand("usp_SalesmanSalesColBO", myconnection);
            mycommand.CommandType = CommandType.StoredProcedure;

            mycommand.Parameters.Add("@Parambegindate2", SqlDbType.DateTime).Value = txtBeginDate.Text;
            mycommand.Parameters.Add("@Paramenddate2", SqlDbType.DateTime).Value = txtEndDate.Text;
            mycommand.Parameters.Add("@ParamPC2", SqlDbType.VarChar).Value = cboSalesman.SelectedValue.ToString();

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

            CRSalesmanSalesColBO objRpt = new CRSalesmanSalesColBO();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            ClsCompName1.ClsCompNameMain();
            vartxtcompany.Text = ClsCompName1.varcn;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = ClsCompName1.varaddress;

            TextObject varTextSalesman = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextSalesman"];
            varTextSalesman.Text = cboSalesman.Text;

            TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rptrangedate"];
            varrpttoenterdate.Text = "From " + txtBeginDate.Text + " To " + txtEndDate.Text;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }

        private void SalesmanSalesBOSupplier()
        {

            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = new SqlCommand("usp_SalesmanSalesBOSupplier", myconnection);
            mycommand.CommandType = CommandType.StoredProcedure;

            mycommand.Parameters.Add("@Parambegindate2", SqlDbType.DateTime).Value = txtBeginDate.Text;
            mycommand.Parameters.Add("@Paramenddate2", SqlDbType.DateTime).Value = txtEndDate.Text;
            mycommand.Parameters.Add("@ParamPC2", SqlDbType.VarChar).Value = cboSalesman.SelectedValue.ToString();
            mycommand.Parameters.Add("@ParamClassCode2", SqlDbType.VarChar).Value = cboSupplierCode.SelectedValue.ToString();

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

            CRSalesmanSalesColBO objRpt = new CRSalesmanSalesColBO();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            ClsCompName1.ClsCompNameMain();
            vartxtcompany.Text = ClsCompName1.varcn;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = ClsCompName1.varaddress;

            TextObject varTextSalesman = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextSalesman"];
            varTextSalesman.Text = cboSalesman.Text;

            TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rptrangedate"];
            varrpttoenterdate.Text = "From " + txtBeginDate.Text + " To " + txtEndDate.Text;

            TextObject varTextSupplierName = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextSupplierName"];
            varTextSupplierName.Text = cboSupplierCode.Text;
            
            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }

        private void CustomerSalesBO()
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = new SqlCommand("usp_CustomerSalesBO", myconnection);
            mycommand.CommandType = CommandType.StoredProcedure;

            mycommand.Parameters.Add("@Parambegindate2", SqlDbType.DateTime).Value = txtBeginDate.Text;
            mycommand.Parameters.Add("@Paramenddate2", SqlDbType.DateTime).Value = txtEndDate.Text;
            mycommand.Parameters.Add("@ParamControlNo2", SqlDbType.VarChar).Value = cboControlNo.SelectedValue.ToString();

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

            CRCustomerSalesBO objRpt = new CRCustomerSalesBO();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            ClsCompName1.ClsCompNameMain();
            vartxtcompany.Text = ClsCompName1.varcn;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = ClsCompName1.varaddress;

            TextObject varTextCustomer = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextCustomer"];
            varTextCustomer.Text = cboControlNo.Text;

            TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rptrangedate"];
            varrpttoenterdate.Text = "From " + txtBeginDate.Text + " To " + txtEndDate.Text;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }

        private void frmrptBOSumm_Load(object sender, EventArgs e)
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
                //cboCNCode.SelectedValue = (ClsDefaultBranch1.plsvardb);
                this.WindowState = FormWindowState.Maximized;
                buildcboASMCode();
                buildcboPrinCode();
                buildcboCustCode();
                cboSalesman.SelectedValue = "";
                cboSupplierCode.SelectedValue = "";
                cboControlNo.SelectedValue = "";
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
        private void buildcboCustCode()
        {
            cboControlNo.DataSource = null;
            ClsBuildComboBox1.ARCCN.Clear();
            ClsBuildComboBox1.ClsBuildClientControlno("C");
            this.cboControlNo.DataSource = (ClsBuildComboBox1.ARCCN);
            this.cboControlNo.DisplayMember = "Display";
            this.cboControlNo.ValueMember = "Value";
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

        private void cbortprint_Validating(object sender, CancelEventArgs e)
        {
           
        }

        private void cbortprint_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbortprint.SelectedValue.ToString() == "01")
            //{
            //    cboSalesman.Enabled = true;
            //    cboSupplierCode.Enabled = true;
            //    cboControlNo.Enabled = false;
            //}

            //else if (cbortprint.SelectedValue.ToString() == "02")
            //{
            //    cboSalesman.Enabled = true;
            //    cboSupplierCode.Enabled = false;
            //    cboControlNo.Enabled = false;
            //}

            //else if (cbortprint.SelectedValue.ToString() == "03")
            //{
            //    cboSalesman.Enabled = true;
            //    cboSupplierCode.Enabled = false;
            //    cboControlNo.Enabled = false;
            //}
            //else if (cbortprint.SelectedValue.ToString() == "04")
            //{
            //    cboSalesman.Enabled = true;
            //    cboSupplierCode.Enabled = true;
            //    cboControlNo.Enabled = false;
            //}
            //else if (cbortprint.SelectedValue.ToString() == "05")
            //{
            //    cboSalesman.Enabled = false;
            //    cboSupplierCode.Enabled = false;
            //    cboControlNo.Enabled = true;
            //}
        }
    }
}
