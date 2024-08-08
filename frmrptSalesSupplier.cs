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
    public partial class frmrptSalesSupplier : Form
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

        public frmrptSalesSupplier()
        {
            InitializeComponent();
            cbortprint.DisplayMember = "Text";
            cbortprint.ValueMember = "Value";
            cbortprint.SelectedValue = "01";
            var items = new[]
            { 
             new { Text = "Detailed All - SKU", Value = "01" }, 
             new { Text = "Detailed All - Group by Customer", Value = "02" }, 
             new { Text = "Detailed All - SKU - Region", Value = "03" }, 
             new { Text = "Detailed All - SKU - Detailed", Value = "04" },
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
                if ((new ClsValidation().emptytxt(cbortprint.Text)) || (txtBeginDate.Text == "  /  /") || (txtEndDate.Text == "  /  /") || (new ClsValidation().emptytxt(cboSupplierCode.Text)))
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
                    SalesSupplierDetails();
                }
            }

            else if (cbortprint.SelectedValue.ToString() == "02")
            {
                if ((new ClsValidation().emptytxt(cbortprint.Text)) || (txtBeginDate.Text == "  /  /") || (txtEndDate.Text == "  /  /") || (new ClsValidation().emptytxt(cboSupplierCode.Text)))
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
                    SalesSupplierDetailsGroupCustomer();
                }
            }

            else if (cbortprint.SelectedValue.ToString() == "03")
            {
                if ((new ClsValidation().emptytxt(cbortprint.Text)) || (txtBeginDate.Text == "  /  /") || (txtEndDate.Text == "  /  /")
                    || (new ClsValidation().emptytxt(cboSupplierCode.Text)) || (new ClsValidation().emptytxt(cboRegCode.Text)))
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
                    SalesSupplierDetails();
                }
            }
            else if (cbortprint.SelectedValue.ToString() == "04")
            {
                if ((new ClsValidation().emptytxt(cbortprint.Text)) || (txtBeginDate.Text == "  /  /") || (txtEndDate.Text == "  /  /") || (new ClsValidation().emptytxt(cboSupplierCode.Text)))
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
                    SalesSupplierDetailsRef();
                }
            }
        }
        
        private void SalesSupplierDetails()
        {
            if (cbortprint.SelectedValue.ToString() == "01")
            {
                sqlstatement1 = "SELECT PClassDesc, Category, StockNumber, Item, SUM(ConvertedQty) As SumConvertedQty, SUM(TotVAT) As SumTotVAT, SUM(TotSales) As SumTotSales, SUM(TotDisct) As SumTotDisct, SUM(Vol2) As SumVol2 ";
                sqlstatement1 += "FROM ViewGP  WHERE ClassCode = '" + cboSupplierCode.SelectedValue.ToString() + "' AND TDate BETWEEN '" + txtBeginDate.Text + "' And  '" + txtEndDate.Text + "'";
                sqlstatement1 += "GROUP By PClassDesc, Category, StockNumber, Item ";
            }
            else if (cbortprint.SelectedValue.ToString()=="03")
            {
                sqlstatement1 = "SELECT PClassDesc, Category, StockNumber, Item, SUM(ConvertedQty) As SumConvertedQty, SUM(TotVAT) As SumTotVAT, SUM(TotSales) As SumTotSales, SUM(TotDisct) As SumTotDisct, SUM(Vol2) As SumVol2 ";
                sqlstatement1 += "FROM ViewGP  WHERE ClassCode = '" + cboSupplierCode.SelectedValue.ToString() + "' AND TDate BETWEEN '" + txtBeginDate.Text + "' And  '" + txtEndDate.Text + "' AND ";
                sqlstatement1 += "RegCode='"+cboRegCode.SelectedValue+"' GROUP By PClassDesc, Category, StockNumber, Item ";

            }
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = myconnection.CreateCommand();
            mycommand.CommandText = sqlstatement1;
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
            CRSalesSupplierDetailedAllSKU objRpt = new CRSalesSupplierDetailedAllSKU();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            ClsCompName1.ClsCompNameMain();
            vartxtcompany.Text = ClsCompName1.varcn;

            //ClsCompName1.ClsCompNamebranchAddress(cboCNCode.SelectedValue.ToString());
            //TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            //vartxtaddress.Text = ClsCompName1.plsCRaddress;

            //TextObject varTextSalesman = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextSalesman"];
            //varTextSalesman.Text = cboSalesman.Text;

            TextObject varTextSupplier = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextSupplier"];
            varTextSupplier.Text = cboSupplierCode.Text;

            TextObject varTextDateRange = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextDateRange"];
            varTextDateRange.Text = "From " + txtBeginDate.Text + " To " + txtEndDate.Text;

            if (cbortprint.SelectedValue.ToString() == "03")
            {
                TextObject varTextRegion = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextRegion"];
                varTextRegion.Text = cboRegCode.Text;
            }
    
            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }

        private void SalesSupplierDetailsRef()
        {

            sqlstatement1 = "SELECT PClassDesc, Category, StockNumber, Item, SUM(ConvertedQty) As SumConvertedQty, SUM(TotVAT) As SumTotVAT, SUM(TotSales) As SumTotSales, SUM(TotDisct) As SumTotDisct, SUM(Vol2) As SumVol2, Reference ";
            sqlstatement1 += "FROM ViewGP  WHERE ClassCode = '" + cboSupplierCode.SelectedValue.ToString() + "' AND TDate BETWEEN '" + txtBeginDate.Text + "' And  '" + txtEndDate.Text + "'";
            sqlstatement1 += "GROUP By PClassDesc, Category, StockNumber, Item, Reference ";

            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = myconnection.CreateCommand();
            mycommand.CommandText = sqlstatement1;
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
            CRSalesSupplierDetailedAllSKURef objRpt = new CRSalesSupplierDetailedAllSKURef();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            ClsCompName1.ClsCompNameMain();
            vartxtcompany.Text = ClsCompName1.varcn;

            //ClsCompName1.ClsCompNamebranchAddress(cboCNCode.SelectedValue.ToString());
            //TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            //vartxtaddress.Text = ClsCompName1.plsCRaddress;

            //TextObject varTextSalesman = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextSalesman"];
            //varTextSalesman.Text = cboSalesman.Text;

            TextObject varTextSupplier = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextSupplier"];
            varTextSupplier.Text = cboSupplierCode.Text;

            TextObject varTextDateRange = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextDateRange"];
            varTextDateRange.Text = "From " + txtBeginDate.Text + " To " + txtEndDate.Text;

            if (cbortprint.SelectedValue.ToString() == "03")
            {
                TextObject varTextRegion = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextRegion"];
                varTextRegion.Text = cboRegCode.Text;
            }

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }

        private void SalesSupplierDetailsGroupCustomer()
        {
            string sqlstatement;
            sqlstatement = "SELECT CustName, PersonnelName, Description, StockNumber, Item, SUM(ConvertedQty) As SumConvertedQty, SUM(TotVAT) As SumTotVAT, SUM(TotSales) As SumTotSales, SUM(TotDisct) As SumTotDisct, ";
            sqlstatement += "IB, Piece FROM ViewGP  WHERE ClassCode = '" + cboSupplierCode.SelectedValue.ToString() + "' AND TDate BETWEEN '" + txtBeginDate.Text + "' And  '" + txtEndDate.Text + "'";
            sqlstatement += "GROUP By CustName, PersonnelName, Description, StockNumber, Item, IB, Piece ";
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
            CRSalesSupplierGroupCustomer objRpt = new CRSalesSupplierGroupCustomer();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            ClsCompName1.ClsCompNameMain();
            vartxtcompany.Text = ClsCompName1.varcn;

            //ClsCompName1.ClsCompNamebranchAddress(cboCNCode.SelectedValue.ToString());
            //TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            //vartxtaddress.Text = ClsCompName1.plsCRaddress;

            //TextObject varTextSalesman = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextSalesman"];
            //varTextSalesman.Text = cboSalesman.Text;

            TextObject varTextSupplier = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextSupplier"];
            varTextSupplier.Text = cboSupplierCode.Text;

            TextObject varTextDateRange = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextDateRange"];
            varTextDateRange.Text = "From " + txtBeginDate.Text + " To " + txtEndDate.Text;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }

        private void frmrptSalesSupplier_Load(object sender, EventArgs e)
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
                buildcboPrinCode();
                buildcboRegCode();
                cboSupplierCode.SelectedValue = "";
                cboRegCode.SelectedValue = "";
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

        private void buildcboRegCode()
        {
            cboRegCode.DataSource = null;
            ClsBuildEntryComboBox1.ARRegCode.Clear();
            ClsBuildEntryComboBox1.ClsBuildRegCode();
            this.cboRegCode.DataSource = (ClsBuildEntryComboBox1.ARRegCode);
            this.cboRegCode.DisplayMember = "Display";
            this.cboRegCode.ValueMember = "Value";
        }

        private void cbortprint_Validating(object sender, CancelEventArgs e)
        {
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

        private void cbortprint_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbortprint.SelectedValue.ToString() == "01" || cbortprint.SelectedValue.ToString() == "04")
            {
                cboRegCode.Enabled = false;
            }
            else if (cbortprint.SelectedValue.ToString()=="02")
            {
                cboRegCode.Enabled = false;
            }
            else if (cbortprint.SelectedValue.ToString()=="03")
            {
                cboRegCode.Enabled = true;
            }
        }

        private void cboRegCode_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().emptytxt(cboRegCode.Text))
            {
            }
            else if (cboRegCode.Text != null && cboRegCode.SelectedValue == null)
            {
                MessageBox.Show("Not found", "GL");
                cboRegCode.Focus();
            }
        }

      
       

    }
}
