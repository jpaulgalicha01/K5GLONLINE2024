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

    public partial class frmrptAging : Form
    {
        SqlConnection myconnection;
        BindingSource dbind = new BindingSource();
        SqlCommand mycommand;
        ClsBuildVoucherComboBox ClsBuildVoucherComboBox1 = new ClsBuildVoucherComboBox();
        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox(); 
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        ClsGetSomething ClsGetSomething1 = new ClsGetSomething();
        SqlDataReader SqlDataReader1;
        ClsCompName ClsCompName1 = new ClsCompName();
        DataTable dt = new DataTable();
        public frmrptAging()
        {
            InitializeComponent();
            cbortprint.DisplayMember = "Text";
            cbortprint.ValueMember = "Value";
            cbortprint.SelectedValue = "01";

            var items = new[]
            { 
             new { Text = "Aging of Accounts Receivable-All", Value = "01" }, 
             new { Text = "Aging of Accounts Receivable-Current", Value = "02" }, 
             new { Text = "Aging of A/R - Salesman", Value = "03" }, 
             new { Text = "Statement of Accounts-Salesman", Value = "04" }, 
             new { Text = "Statement of Accounts-Customer", Value = "05" }, 
             new { Text = "Statement of Accounts-Customer-Poultry", Value = "06" }, 
             new { Text = "Statement of Accounts-Group Salesman", Value = "07" }, 
             new { Text = "COD Aging", Value = "08" },
             new { Text = "Aging of Accounts Payable-All", Value = "09" },
             new { Text = "Aging of Accounts Receivable-Current", Value = "10" },
             new { Text = "Aging of A/P - Salesman", Value = "11" },

            };
            cbortprint.DataSource = items;
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
        private void buildcboControlNo()
        {
            cboPC.DataSource = null;
            ClsBuildComboBox1.ARCCN.Clear();
            ClsBuildComboBox1.ClsBuildClientControlno("C");
            this.cboPC.DataSource = (ClsBuildComboBox1.ARCCN);
            this.cboPC.DisplayMember = "Display";
            this.cboPC.ValueMember = "Value";
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
                ClsGetSomething1.ClsGetDefaultDate();
                txtEnterDate.Text = ClsGetSomething1.plsdefdate;
                txtBeginDate.Text = ClsGetSomething1.plsdefdate;
                txtASD.Text = ClsGetSomething1.plsdefdate;
                this.WindowState = FormWindowState.Maximized;
            }
        }     

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (new ClsValidation().emptytxt(cbortprint .Text))
            {
                MessageBox.Show("Please complete your entry", "GL");
                cbortprint.Focus();
            }
            else
            {
                if (cbortprint.SelectedValue.ToString() == "01")//Aging of Accounts Receivable-All
                {
                    AgingARAll();
                }
                else if (cbortprint.SelectedValue.ToString() == "02")//Aging of Accounts Receivable-Current
                {
                    AgingARCurrent();
                }
                else if (cbortprint.SelectedValue.ToString() == "03")//Aging of A/R - Salesman
                {
                    if (new ClsValidation().emptytxt(cboPC.Text))
                    {
                        MessageBox.Show("Salesman is empty", "GL");
                    }
                    else
                    {
                        AgingARSLS();
                    }
                }
                else if (cbortprint.SelectedValue.ToString() == "04")//Statement of Accounts-Salesman
                {
                    if (new ClsValidation().emptytxt(cboPC.Text))
                    {
                        MessageBox.Show("Saleman is empty", "GL");
                    }
                    else
                    {
                        AgingSOASLS();
                    }
                }
                else if (cbortprint.SelectedValue.ToString() == "05")//Statement of Accounts-Customer
                {
                    if (new ClsValidation().emptytxt(cboPC.Text))
                    {
                        MessageBox.Show("Customer is empty", "GL");
                    }
                    else
                    {
                        AgingSOA();
                    }
                }
                else if (cbortprint.SelectedValue.ToString() == "06")//Statement of Accounts-Customer-Poultry
                {
                    if (new ClsValidation().emptytxt(cboPC.Text))
                    {
                        MessageBox.Show("Customer is empty", "GL");
                    }
                    else
                    {
                        AgingSOAPoultry();
                    }
                }
                else if (cbortprint.SelectedValue.ToString() == "07")//Statement of Accounts-Group Salesman
                {
                    if (new ClsValidation().emptytxt(cboPC.Text))
                    {
                        MessageBox.Show("Customer is empty", "GL");
                    }
                    else
                    {
                        AgingSOAGroupSLS();
                    }
                }
                else if (cbortprint.SelectedValue.ToString() == "08")//COD Aging
                {
                    CODAging();
                }
                else if (cbortprint.SelectedValue.ToString() == "09")//Aging of Accounts Payable-All
                {
                    AgingAPAll();
                }
                else if (cbortprint.SelectedValue.ToString() == "10")//Aging of Accounts Payable-Current
                {
                    AgingAPCurrent();
                }
                else if (cbortprint.SelectedValue.ToString() == "11")//Aging of A/P - Salesman
                {
                    if (new ClsValidation().emptytxt(cboPC.Text))
                    {
                        MessageBox.Show("Salesman is empty", "GL");
                    }
                    else
                    {
                        AgingAPSLS();
                    }
                }
            }
        }
        private void CODAging()
        {
            string sqlstatement;
            sqlstatement = "SELECT PersonnelName, TDate, Reference, SUM(Balance) As Balance, DATEDIFF(d, Min(TDate), '" + txtASD.Text + "') As NOD, Term, CustName ";
            sqlstatement += "FROM ViewCODAging1  WHERE TDate BETWEEN '" + txtBeginDate.Text + "' And  '" + txtEnterDate.Text + "'";
            sqlstatement += "GROUP By PersonnelName, TDate, Reference, Term, CustName ORDER BY CustName, TDate";
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
            CRCODAging objRpt = new CRCODAging();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            ClsCompName1.ClsCompNameMain();
            vartxtcompany.Text = ClsCompName1.varcn;

            //ClsCompName1.ClsCompNamebranchAddress(cboCNCode.SelectedValue.ToString());
            //TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            //vartxtaddress.Text = ClsCompName1.plsCRaddress;

            TextObject varTextDateRange = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextDateRange"];
            varTextDateRange.Text = "From " + txtBeginDate.Text + " To " + txtEnterDate.Text;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }
    
      
        private void AgingARAll()
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                    myconnection.Open();
                    mycommand = new SqlCommand("usp_aging", myconnection);
                    mycommand.CommandType = CommandType.StoredProcedure;
                    mycommand.Parameters.Add("@Paramenterdate", SqlDbType.DateTime).Value = txtEnterDate.Text;

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

                    CRagingofar objRpt = new CRagingofar();
                    TextObject varrpttocompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoCompany"];
                    varrpttocompany.Text = Form1.glblncompany.Text;

                    TextObject varrpttoaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoaddress"];
                    varrpttoaddress.Text = Form1.glbladdress.Text;

                    TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoenterdate"];
                    varrpttoenterdate.Text = "As of "+txtEnterDate.Text;

                    objRpt.SetDataSource(DataTable1);
                    crystalReportViewer1.ReportSource = objRpt;
                    crystalReportViewer1.Refresh();
            }
        
        private void AgingAPAll()
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                    myconnection.Open();
                    mycommand = new SqlCommand("usp_agingAP", myconnection);
                    mycommand.CommandType = CommandType.StoredProcedure;
                    mycommand.Parameters.Add("@Paramenterdate", SqlDbType.DateTime).Value = txtEnterDate.Text;

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

                    CRagingofar objRpt = new CRagingofar();
                    TextObject varrpttocompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoCompany"];
                    varrpttocompany.Text = Form1.glblncompany.Text;

                    TextObject varrpttoaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoaddress"];
                    varrpttoaddress.Text = Form1.glbladdress.Text;

                    TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoenterdate"];
                    varrpttoenterdate.Text = "As of "+txtEnterDate.Text;

                    objRpt.SetDataSource(DataTable1);
                    crystalReportViewer1.ReportSource = objRpt;
                    crystalReportViewer1.Refresh();
            }

        private void AgingARCurrent()
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = new SqlCommand("usp_agingcurrent", myconnection);
            mycommand.CommandType = CommandType.StoredProcedure;
            mycommand.Parameters.Add("@Paramenterdate", SqlDbType.DateTime).Value = txtEnterDate.Text;
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

            CRagingofar objRpt = new CRagingofar();
            TextObject varrpttocompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoCompany"];
            varrpttocompany.Text = Form1.glblncompany.Text;

            TextObject varrpttoaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoaddress"];
            varrpttoaddress.Text = Form1.glbladdress.Text;

            TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoenterdate"];
            varrpttoenterdate.Text = "As of " + txtEnterDate.Text;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();

        }
        
        private void AgingAPCurrent()
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = new SqlCommand("usp_agingAPcurrent", myconnection);
            mycommand.CommandType = CommandType.StoredProcedure;
            mycommand.Parameters.Add("@Paramenterdate", SqlDbType.DateTime).Value = txtEnterDate.Text;
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

            CRagingofar objRpt = new CRagingofar();
            TextObject varrpttocompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoCompany"];
            varrpttocompany.Text = Form1.glblncompany.Text;

            TextObject varrpttoaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoaddress"];
            varrpttoaddress.Text = Form1.glbladdress.Text;

            TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoenterdate"];
            varrpttoenterdate.Text = "As of " + txtEnterDate.Text;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();

        }

        private void AgingARSLS()
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = new SqlCommand("usp_agingSLS", myconnection);
            mycommand.CommandType = CommandType.StoredProcedure;
            mycommand.Parameters.Add("@Paramenterdate", SqlDbType.DateTime).Value = txtEnterDate.Text;
            mycommand.Parameters.Add("@ParamSLS", SqlDbType.VarChar).Value = cboPC.SelectedValue.ToString();
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

            CRagingofar objRpt = new CRagingofar();
            TextObject varrpttocompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoCompany"];
            varrpttocompany.Text = Form1.glblncompany.Text;

            TextObject varrpttoaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoaddress"];
            varrpttoaddress.Text = Form1.glbladdress.Text;

            TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoenterdate"];
            varrpttoenterdate.Text = "As of " + txtEnterDate.Text;

            TextObject varrpttoSalesman = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoSalesman"];
            varrpttoSalesman.Text = cboPC.Text;


            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();

        }
        
        private void AgingAPSLS()
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = new SqlCommand("usp_agingAPSLS", myconnection);
            mycommand.CommandType = CommandType.StoredProcedure;
            mycommand.Parameters.Add("@Paramenterdate", SqlDbType.DateTime).Value = txtEnterDate.Text;
            mycommand.Parameters.Add("@ParamSLS", SqlDbType.VarChar).Value = cboPC.SelectedValue.ToString();
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

            CRagingofar objRpt = new CRagingofar();
            TextObject varrpttocompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoCompany"];
            varrpttocompany.Text = Form1.glblncompany.Text;

            TextObject varrpttoaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoaddress"];
            varrpttoaddress.Text = Form1.glbladdress.Text;

            TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoenterdate"];
            varrpttoenterdate.Text = "As of " + txtEnterDate.Text;

            TextObject varrpttoSalesman = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoSalesman"];
            varrpttoSalesman.Text = cboPC.Text;


            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();

        }

        private void AgingSOA()
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = new SqlCommand("usp_agingCustomer", myconnection);
            mycommand.CommandType = CommandType.StoredProcedure;
            mycommand.Parameters.Add("@Paramenterdate", SqlDbType.DateTime).Value = txtEnterDate.Text;
            mycommand.Parameters.Add("@ParamControlNo", SqlDbType.VarChar).Value = cboPC.SelectedValue.ToString();

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

            CRAgingStatement objRpt = new CRAgingStatement();
            TextObject varrpttocompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoCompany"];
            varrpttocompany.Text = Form1.glblncompany.Text;

            TextObject varrpttoaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoaddress"];
            varrpttoaddress.Text = Form1.glbladdress.Text;

            TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoenterdate"];
            varrpttoenterdate.Text = "As of " + txtEnterDate.Text;

            TextObject varrpttoCustName = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoCustName"];
            varrpttoCustName.Text = cboPC.Text;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }

        private void AgingSOAPoultry()
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = new SqlCommand("usp_agingCustomerseparate", myconnection);
            mycommand.CommandType = CommandType.StoredProcedure;
            mycommand.Parameters.Add("@Paramenterdate", SqlDbType.DateTime).Value = txtEnterDate.Text;
            mycommand.Parameters.Add("@ParamControlNo", SqlDbType.VarChar).Value = cboPC.SelectedValue.ToString();
            mycommand.Parameters.Add("@ParamTransact", SqlDbType.VarChar).Value = "1";

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
            CRAgingStatement objRpt = new CRAgingStatement();
            TextObject varrpttocompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoCompany"];
            varrpttocompany.Text = Form1.glblncompany.Text;

            TextObject varrpttoaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoaddress"];
            varrpttoaddress.Text = Form1.glbladdress.Text;

            TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoenterdate"];
            varrpttoenterdate.Text = "As of " + txtEnterDate.Text;

            TextObject varrpttoCustName = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoCustName"];
            varrpttoCustName.Text = cboPC.Text;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }

        private void AgingSOAGroupSLS()
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = new SqlCommand("usp_agingCustomer", myconnection);
            mycommand.CommandType = CommandType.StoredProcedure;
            mycommand.Parameters.Add("@Paramenterdate", SqlDbType.DateTime).Value = txtEnterDate.Text;
            mycommand.Parameters.Add("@ParamControlNo", SqlDbType.VarChar).Value = cboPC.SelectedValue.ToString();

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

            CRAgingStatementGroupSLS objRpt = new CRAgingStatementGroupSLS();
            TextObject varrpttocompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoCompany"];
            varrpttocompany.Text = Form1.glblncompany.Text;

            TextObject varrpttoaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoaddress"];
            varrpttoaddress.Text = Form1.glbladdress.Text;

            TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoenterdate"];
            varrpttoenterdate.Text = "As of " + txtEnterDate.Text;

            TextObject varrpttoCustName = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoCustName"];
            varrpttoCustName.Text = cboPC.Text;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }

        private void AgingSOASLS()
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = new SqlCommand("usp_agingcurrentsls", myconnection);
            mycommand.CommandType = CommandType.StoredProcedure;
            mycommand.Parameters.Add("@Paramenterdate", SqlDbType.DateTime).Value = txtEnterDate.Text;
            mycommand.Parameters.Add("@ParamSLS", SqlDbType.VarChar).Value = cboPC.SelectedValue.ToString();
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

            CRAgingStatementSLS objRpt = new CRAgingStatementSLS();
            TextObject varrpttocompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoCompany"];
            varrpttocompany.Text = Form1.glblncompany.Text;

            TextObject varrpttoaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoaddress"];
            varrpttoaddress.Text = Form1.glbladdress.Text;

            TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoenterdate"];
            varrpttoenterdate.Text = "As of " + txtEnterDate.Text;

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

        private void txtEnterDate_Leave(object sender, EventArgs e)
        {
            if (new ClsValidation().errordate(txtEnterDate.Text) == true)
            {
                MessageBox.Show("Invalid Date", "GL");
                txtEnterDate.Focus();
            }
        }

        private void cboPC_Validating(object sender, CancelEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

    

        private void cbortprint_Validating(object sender, CancelEventArgs e)
        {

            if (cbortprint.SelectedValue.ToString() == "01" || cbortprint.SelectedValue.ToString() == "09")//Aging of Accounts Receivable-All and AP
            {
                cboPC.Enabled = false;
                txtEnterDate.Visible = true;
                lblEnterDate.Visible = true;
                lblEnterDate.Text = "Date:";

                lblBeginDate.Visible = false;
                txtBeginDate.Visible = false;
                lblASD.Visible = false;
                txtASD.Visible = false;
            }
            else if (cbortprint.SelectedValue.ToString() == "02" || cbortprint.SelectedValue.ToString() == "10")//Aging of Accounts Receivable-Current and AP
            {
                cboPC.Enabled = false;
                txtEnterDate.Visible = true;
                lblEnterDate.Visible = true;
                lblEnterDate.Text = "Date:";

                lblBeginDate.Visible = false;
                txtBeginDate.Visible = false;
                lblASD.Visible = false;
                txtASD.Visible = false;
            }

            else if (cbortprint.SelectedValue.ToString() == "03" || cbortprint.SelectedValue.ToString() == "11")//Aging of A/R - Salesman and AP
            {
                buildcboSalesman();
                cboPC.Enabled = true;
                label2.Text = "Salesman";
                txtEnterDate.Visible = true;
                lblEnterDate.Visible = true;
                lblEnterDate.Text = "Date:";

                lblBeginDate.Visible = false;
                txtBeginDate.Visible = false;
                lblASD.Visible = false;
                txtASD.Visible = false;
            }
            else if (cbortprint.SelectedValue.ToString() == "04")//Statement of Accounts-Salesman
            {
                buildcboSalesman();
                cboPC.Enabled = true;
                label2.Text = "Salesman";
                txtEnterDate.Visible = true;
                lblEnterDate.Visible = true;
                lblEnterDate.Text = "Date:";

                lblBeginDate.Visible = false;
                txtBeginDate.Visible = false;
                lblASD.Visible = false;
                txtASD.Visible = false;
            }


            else if (cbortprint.SelectedValue.ToString() == "05" ||//Statement of Accounts-Customer
                cbortprint.SelectedValue.ToString() == "06" ||//Statement of Accounts-Customer-Poultry
                cbortprint.SelectedValue.ToString() == "07")//Statement of Accounts-Group Salesman
            {
                buildcboControlNo();
                label2.Text = "Customer";
                cboPC.Enabled = true;
                lblEnterDate.Visible = true;
                lblEnterDate.Text = "Date:";

                lblBeginDate.Visible = false;
                txtBeginDate.Visible = false;
                lblASD.Visible = false;
                txtASD.Visible = false;
            }

            else if (cbortprint.SelectedValue.ToString() == "08") 
            {
                cboPC.Enabled = false;
                txtEnterDate.Visible = true;
                lblEnterDate.Visible = true;
                lblEnterDate.Text = "End Date:";

                lblBeginDate.Visible = true;
                txtBeginDate.Visible = true;
                lblASD.Visible = true;
                txtASD.Visible = true;
            }

        }
    }
}
