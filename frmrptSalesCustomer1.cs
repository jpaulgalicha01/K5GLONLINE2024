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
    public partial class frmrptSalesCustomer1 : Form
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
        public frmrptSalesCustomer1()
        {
            InitializeComponent();
            cbortprint.DisplayMember = "Text";
            cbortprint.ValueMember = "Value";
            cbortprint.SelectedValue = "01";
            var items = new[]
            { 
             new { Text = "Detailed All - With Supplier", Value = "01" }, 

            };
            cbortprint.DataSource = items;
        }

        private void buildcboASMCode()
        {
            cboPC.DataSource = null;
            ClsBuildVoucherComboBox1.ARLSLS.Clear();
            ClsBuildVoucherComboBox1.ClsBuildSalesman();
            this.cboPC.DataSource = (ClsBuildVoucherComboBox1.ARLSLS);
            this.cboPC.DisplayMember = "Display";
            this.cboPC.ValueMember = "Value";
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
                if ((new ClsValidation().emptytxt(cbortprint.Text)) || (txtBeginDate.Text == "  /  /") || (txtEndDate.Text == "  /  /"))
                {
                    MessageBox.Show("Please complete your entry", "GL");
                    cbortprint.Focus();
                }
                else if (new ClsValidation().emptytxt(cboPC.Text))
                {
                    MessageBox.Show("Please enter salesamn", "GL");
                    cboPC.Focus();
                }
                else if (Convert.ToDateTime(txtBeginDate.Text) > Convert.ToDateTime(txtEndDate.Text))
                {
                    MessageBox.Show("Beginning date is greater than ending date", "GL");
                    cbortprint.Focus();
                }
                else
                {
                    SalesWithSupplier();
                }
            }
        }

        private void SalesWithSupplier()
        {
            string sqlstatement;
            sqlstatement = "SELECT ControlNo, CustName, OTDesc, StockNumber, Item, ClassDesc, Address, SUM(ConvertedQty) As SumConvertedQty, SUM(TotVAT) As SumTotVAT, SUM(TotSales) As SumTotSales, SUM(TotDisct) As SumTotDisct, ";
            sqlstatement += "SUM(Vol2) As SUMVol2, IB, Piece FROM ViewGP  WHERE TDate BETWEEN '" + txtBeginDate.Text + "' And  '" + txtEndDate.Text + "' AND PC ='" + cboPC.SelectedValue.ToString() + "' ";
            sqlstatement += "GROUP By ControlNo, CustName, OTDesc, StockNumber, Item, ClassDesc, Address, IB, Piece ";
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
            CRSalesCustomerwithSupplier objRpt = new CRSalesCustomerwithSupplier();

            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            ClsCompName1.ClsCompNameMain();
            vartxtcompany.Text = ClsCompName1.varcn;

            ClsCompName1.ClsCompNameMain();
            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = ClsCompName1.varaddress;

            TextObject varTextSalesman = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextSalesman"];
            varTextSalesman.Text = cboPC.Text;


            TextObject varTextDateRange = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextDateRange"];
            varTextDateRange.Text = "From " + txtBeginDate.Text + " To " + txtEndDate.Text;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }

        private void frmrptSalesCustomer_Load(object sender, EventArgs e)
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
                buildcboASMCode();
                cboPC.SelectedValue = "";
                this.WindowState = FormWindowState.Maximized;
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

        private void cboPC_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().emptytxt(cboPC.Text))
            {
            }
            else if (cboPC.Text != null && cboPC.SelectedValue == null)
            {
                MessageBox.Show("Not found", "GL");
                cboPC.Focus();
            }

        }

        private void cbortprint_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().emptytxt(cbortprint.Text))
            {
            }
            else if (cbortprint.Text != null && cbortprint.SelectedValue == null)
            {
                MessageBox.Show("Not found", "GL");
                cbortprint.Focus();
            }

        }
    }
}
