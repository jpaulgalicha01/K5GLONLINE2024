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
    public partial class frmrptDoleSales : Form
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
        
        public frmrptDoleSales()
        {
            InitializeComponent();
            cbortprint.DisplayMember = "Text";
            cbortprint.ValueMember = "Value";
            cbortprint.SelectedValue = "01";

            var items = new[]
            {
             new { Text = "Dole Sales", Value = "01" },
             new { Text = "Dole Customer", Value = "02" },
             new { Text = "Dole SKU", Value = "03" },
             new { Text = "Dole Purchases", Value = "04" },
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

        private void DOleSales()
        {
            string sqlstatement;
            sqlstatement = "SELECT * FROM ViewDoleSales WHERE TDate BETWEEN '" + txtBeginDate.Text + "' AND '" + txtEndDate.Text + "' AND ClassCode = '" + cboSupplier.SelectedValue.ToString() + "' ORDER BY CustName";
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

            CRDoleSales objRpt = new CRDoleSales();
            //TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            //ClsCompName1.ClsCompNameMain();
            //vartxtcompany.Text = ClsCompName1.varcn;

            //TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            //vartxtaddress.Text = ClsCompName1.varaddress;

            //TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextDateRange"];
            //varrpttoenterdate.Text = "From:" + txtBeginDate.Text + "To:" + txtEndDate.Text;

            objRpt.SetDataSource(DataTable1);

            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }
        
        private void DOleCustomer()
        {
            string sqlstatement;
            sqlstatement = "SELECT * FROM ViewDoleCustomer ORDER BY CustName";
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

            CRDoleCustomer objRpt = new CRDoleCustomer();
            //TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            //ClsCompName1.ClsCompNameMain();
            //vartxtcompany.Text = ClsCompName1.varcn;

            //TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            //vartxtaddress.Text = ClsCompName1.varaddress;

            //TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextDateRange"];
            //varrpttoenterdate.Text = "From:" + txtBeginDate.Text + "To:" + txtEndDate.Text;

            objRpt.SetDataSource(DataTable1);

            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }
        
        private void DOleSKU()
        {
            string sqlstatement;
            sqlstatement = "SELECT * FROM ViewDoleSKU WHERE ControlNo = '"+cboSupplier.SelectedValue.ToString()+"' ORDER BY CustName";
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

            CRDoleSKU objRpt = new CRDoleSKU();
            //TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            //ClsCompName1.ClsCompNameMain();
            //vartxtcompany.Text = ClsCompName1.varcn;

            //TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            //vartxtaddress.Text = ClsCompName1.varaddress;

            //TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextDateRange"];
            //varrpttoenterdate.Text = "From:" + txtBeginDate.Text + "To:" + txtEndDate.Text;

            objRpt.SetDataSource(DataTable1);

            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }
        

        private void frmrptDoleSales_Load(object sender, EventArgs e)
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
                cboSupplier.SelectedValue = "";
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
                DOleSales();
            }
            else if (cbortprint.SelectedValue.ToString() == "02")
            {
                DOleCustomer();
            }
            else if (cbortprint.SelectedValue.ToString() == "03")
            {
                DOleSKU();
            }
            else if (cbortprint.SelectedValue.ToString() == "04")
            {
                DolePurchases();
            }
            //else if (cbortprint.SelectedValue.ToString() == "04")
            //{
            //    DOleInventory();
            //}

            //    string sqlstatement = "";
            //    btnExport.Visible = true;
            //    if (cbortprint.SelectedValue.ToString() == "01")
            //    {
            //        if ((new ClsValidation().emptytxt(cbortprint.Text)) || (txtBeginDate.Text == "  /  /") || (txtEndDate.Text == "  /  /") || /*(new ClsValidation().emptytxt(cboSupplierCode.Text)) ||*/ (Convert.ToDateTime(txtBeginDate.Text) > Convert.ToDateTime(txtEndDate.Text)))
            //        {
            //            MessageBox.Show("Please complete your entry", "GL");
            //            cbortprint.Focus();
            //        }
            //        else if (Convert.ToDateTime(txtBeginDate.Text) > Convert.ToDateTime(txtEndDate.Text))
            //        {
            //            MessageBox.Show("Beginning date is greater than ending date", "GL");
            //            cbortprint.Focus();
            //        }
            //        else
            //        {
            //            sqlstatement = "SELECT K5, Dist, NA, PHP, Good, TDate, Reference, ControlNo, PersonnelName, RegName, Description, OTDesc, SFAProductCode, Voucher, CustName, Qty, Volume, UnitSales, InvoiceNetPriceWithoutVAT, InvoiceNetPriceWithVAT, DE, Warehouse ";
            //            sqlstatement += "FROM ViewDoleSales WHERE TDate BETWEEN '" + txtBeginDate.Text + "' AND '" + txtEndDate.Text + "' AND ClassCode = '" + cboSupplier.SelectedValue.ToString() + "' ";
            //            sqlstatement += "ORDER BY CustName";
            //        }

            //        ClsGetConnection1.ClsGetConMSSQL();
            //        myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            //        myconnection.Open();
            //        mycommand = myconnection.CreateCommand();
            //        mycommand.CommandText = sqlstatement;
            //        mycommand.CommandTimeout = 900;
            //        SqlDataReader1 = mycommand.ExecuteReader();
            //        DataTable DataTable1 = new DataTable();
            //        DataTable1.Load(SqlDataReader1);
            //        myconnection.Close();


            //        if (DataTable1.Rows.Count == 0)
            //        {
            //            MessageBox.Show("No Data Found!", "Warning");
            //            return;
            //        }
            //        else
            //        {
            //            dgv2.DataSource = null;
            //            dgv2.Rows.Clear();

            //            DataRow row = null;
            //            for (int x = 1; x < DataTable1.Rows.Count; x++)
            //            {
            //                dgv2.Columns[2].DefaultCellStyle.Format = "MM/dd/yyyy";
            //                dgv2.Columns[22].DefaultCellStyle.Format = "MM/dd/yyyy";
            //                dgv2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //                dgv2.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //                dgv2.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //                dgv2.Columns[14].DefaultCellStyle.Format = "N2";
            //                dgv2.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //                dgv2.Columns[15].DefaultCellStyle.Format = "N2";
            //                dgv2.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //                dgv2.Columns[17].DefaultCellStyle.Format = "N2";
            //                dgv2.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //                dgv2.Columns[18].DefaultCellStyle.Format = "N2";
            //                dgv2.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //                dgv2.Columns[20].DefaultCellStyle.Format = "N2";

            //                row = DataTable1.Rows[x];
            //                dgv2.Rows.Add(row["K5"], row["Dist"], row["TDate"], row["Reference"], row["NA"], row["ControlNo"], row["PersonnelName"], row["RegName"], row["Description"], row["OTDesc"], row["NA"], row["SFAProductCode"], row["Voucher"], row["CustName"], row["Qty"], row["Volume"], row["UnitSales"], row["Volume"], row["InvoiceNetPriceWithoutVAT"], row["PHP"], row["InvoiceNetPriceWithVAT"], row["PHP"], row["DE"], row["Warehouse"], row["Good"]);
            //            }
            //        }
            //    }
        }

    private void btnExport_Click(object sender, EventArgs e)
        {


            //    label2.Visible = true;
            //    PBProgressBar1.Visible = true;

            //    PBProgressBar1.Maximum = dgv2.Rows.Count;
            //    PBProgressBar1.Step = 1;
            //    PBProgressBar1.Value = 0;

            //    //Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            //    //Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            //    //Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            //    Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            //    excel.Visible = false; // to hide the processing 
            //    Excel.Workbook wb = excel.Workbooks.Add(Type.Missing);
            //    //Excel.Worksheet sh = null;
            //    Excel.Worksheet sh = (Microsoft.Office.Interop.Excel.Worksheet)wb.Sheets["Sheet1"];

            //    //sh = wb.ActiveSheet;
            //    sh.Name = "Billing(Sales)";

            //    int cellRowIndex = 1;
            //    int cellColumnIndex = 1;
            //    for (int x = -1; x < dgv2.Rows.Count; x++)
            //    {
            //        PBProgressBar1.Value = x+1;
            //        for (int j = 0; j < dgv2.Columns.Count; j++)
            //        {
            //            if (x == -1)
            //            {
            //                sh.Cells[cellRowIndex, cellColumnIndex] = dgv2.Columns[j].HeaderText;
            //            }
            //            else
            //            {
            //                sh.Cells[cellRowIndex, cellColumnIndex] = dgv2.Rows[x].Cells[j].Value.ToString();
            //            }
            //            cellColumnIndex++;
            //        }
            //        cellColumnIndex = 1;
            //        cellRowIndex++;
            //    }
            //    SaveFileDialog saveDialog = new SaveFileDialog();
            //    saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            //    saveDialog.FilterIndex = 2;

            //    if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //    {
            //        wb.SaveAs(saveDialog.FileName);
            //        MessageBox.Show("Export Successful");
            //    }
        }


        private void DolePurchases()
        {
            string sqlstatement;
            sqlstatement = "SELECT TDate, Reference, SFAProductCode, Qty, UM, Warehouse, Item, Category, ClassDesc, QtyinPC, Amount, VAT, supplier, NetAmount ";
            sqlstatement += "FROM ViewDolePurchases WHERE TDate BETWEEN '" + txtBeginDate.Text + "' AND '" + txtEndDate.Text + "' AND ClassCode = '" + cboSupplier.SelectedValue.ToString() + "'";

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


            CRDolePurchases objRpt = new CRDolePurchases();

            //TextObject vartxtClosingDate = (TextObject)objRpt.ReportDefinition.Sections["Section3"].ReportObjects["rpttxtclosingdate"];
            //vartxtClosingDate.Text = txtAsofDate.Text;

            objRpt.SetDataSource(DataTable1);

            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }

        private void cbortprint_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbortprint.SelectedValue.ToString() == "01")
            {
                cboSupplier.Enabled = true;
                txtBeginDate.Enabled = true;
                txtEndDate.Enabled = true;
            }
            else if (cbortprint.SelectedValue.ToString() == "02")
            {
                cboSupplier.Enabled = false;
                txtBeginDate.Enabled = false;
                txtEndDate.Enabled = false;
            }
            else if (cbortprint.SelectedValue.ToString() == "03")
            {
                cboSupplier.Enabled = true;
                txtBeginDate.Enabled = false;
                txtEndDate.Enabled = false;
            }
        }
    }
}

