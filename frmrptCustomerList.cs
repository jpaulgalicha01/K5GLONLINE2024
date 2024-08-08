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
    public partial class frmrptCustomerList : Form
    {
        SqlConnection myconnection;
        //SqlCommand mycommand;
        BindingSource dbind = new BindingSource();
        //SqlDataReader dr;
        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();
        ClsCompName ClsCompName1 = new ClsCompName();
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        ClsAutoNumber ClsAutoNumber1 = new ClsAutoNumber();
        SqlCommand mycommand;
        SqlDataReader SqlDataReader1;
        private string strchoose = "1";

        public frmrptCustomerList()
        {
            InitializeComponent();
//Accounts Payable Voucher
//Accounts Receivable Voucher
//Check Voucher
//Journal Voucher
//Remittance Voucher
//Purchase Delivery
//Transfer Form
//Return Slip
//Adjustment Slip
//Charge Invoice - DIS
//Charge Invoice - SO
//Official Receipt
//Cash Sales
            cbortprint.DisplayMember = "Text";
            cbortprint.ValueMember = "Value";
            cbortprint.SelectedValue = "APV";
            var items = new[]
            { 
             new { Text = "List of Customer", Value = "01" }, 
             };
            cbortprint.DataSource = items;
        }

        private void frmrptCustomerList_Load(object sender, EventArgs e)
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
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            strchoose = "1";
            prevprint();

        }

        private void prevprint()
        {
            if (string.IsNullOrEmpty(cbortprint.Text))
            {
                MessageBox.Show("Please complete your entry", "GL");
                cbortprint.Focus();
            }
            else
            {
                if (cbortprint.SelectedValue.ToString() == "01")
                {
                    ListOfCustomer();
                }
                

            }
        }
        private void ListOfCustomer()
        {
            string sqlstatement = "SELECT * FROM ViewCustomerList";

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
                MessageBox.Show("No data found", "GL");
                return;
            }

            CRCustomerList objRpt = new CRCustomerList();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();

            //System.Drawing.Printing.PrintDocument doctoprint = new System.Drawing.Printing.PrintDocument();
            ////  doctoprint.PrinterSettings.PrinterName = "EPSON LX-300+ /II";
            //int rawKind = 0;
            //for (int i = 0; i <= doctoprint.PrinterSettings.PaperSizes.Count - 1; i++)
            //{
            //    if (doctoprint.PrinterSettings.PaperSizes[i].PaperName == "C1-HalfShort")
            //    {
            //        rawKind = Convert.ToInt32(doctoprint.PrinterSettings.PaperSizes[i].GetType().GetField("kind",
            //        System.Reflection.BindingFlags.Instance |
            //        System.Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes[i]));
            //        break; // TODO: might not be correct. Was : Exit For
            //    }
            //}
            //objRpt.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
            ////CrystalDecisions.Shared.PageMargins pMargin = new CrystalDecisions.Shared.PageMargins(0, 0, 0, 0);
            ////objRpt.PrintOptions.ApplyPageMargins(pMargin);
            //if (strchoose == "1")
            //{
            //    crystalReportViewer1.ReportSource = objRpt;
            //}
            //else
            //{
            //    objRpt.Refresh();
            //    objRpt.PrintToPrinter(1, false, 0, 0);
            //}
        }

        private void nextfieldenter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cbortprint_Validating(object sender, CancelEventArgs e)
        {
            
            

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            prevprint();
        }
    }
}
