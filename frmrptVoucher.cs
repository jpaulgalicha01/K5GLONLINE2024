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
    public partial class frmrptVoucher : Form
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
        ClsGetSomething ClsGetSomething1 = new ClsGetSomething();
        SqlCommand mycommand;
        SqlDataReader SqlDataReader1;
        string strchoose = "1",checking = "";
        public string plsdefdate;

        public frmrptVoucher()
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
             new { Text = "Accounts Payable Voucher", Value = "APV" },
             new { Text = "Accounts Receivable Voucher", Value = "ARV" },
             new { Text = "Check Voucher", Value = "CV" },
             new { Text = "Journal Voucher", Value = "JV" },
             new { Text = "Remittance Voucher", Value = "RV" },
             new { Text = "Purchase Delivery", Value = "PD" },
             new { Text = "Purchase Delivery Entry", Value = "PDAE" },
             new { Text = "Transfer Form", Value = "TF" },
             new { Text = "Return Slip", Value = "RS" },
             new { Text = "Adjustment Slip", Value = "AS" },
             new { Text = "Charge Invoice - DIS1", Value = "CIDIS" },
             new { Text = "Charge Invoice - DIS2", Value = "CIDIS2" },
             new { Text = "Charge Invoice", Value = "CISO" },
             new { Text = "Charge Invoice Poultry", Value = "CISOPoultry" },
             new { Text = "Official Receipt", Value = "OR" },
             new { Text = "Cash Sales", Value = "CS" },
             new { Text = "Actual Inventory", Value = "AI" },
             new { Text = "Return to Supplier", Value = "RTS" },
             new { Text = "Return to Supplier Entry", Value = "RTSAE" },
             new { Text = "Charge Invoice - New", Value = "CISONew" },
             new { Text = "Manifest", Value = "Manifest" },
             new { Text = "Daily Sales and Collection", Value = "DSCR" },
             };
            cbortprint.DataSource = items;
        }

        private void frmrptVoucher_Load(object sender, EventArgs e)
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
            if (string.IsNullOrEmpty(cboFrom.Text))
            {
                MessageBox.Show("Please complete your entry", "GL");
                cboFrom.Focus();
            }
              
            else if(string.IsNullOrEmpty(cboTo.Text) && checking == "" )
            {
                MessageBox.Show("Please complete your entry", "GL");
                cboTo.Focus();
            }
            else if (string.IsNullOrEmpty(cbortprint.Text))
            {
                MessageBox.Show("Please complete your entry", "GL");
                cbortprint.Focus();
            }
            else
            {
                if (cbortprint.SelectedValue.ToString() == "APV")
                {
                    prevapv();
                }
                else if (cbortprint.SelectedValue.ToString() == "ARV")
                {
                    prevarv();
                }

                else if (cbortprint.SelectedValue.ToString() == "CV")
                {
                    prevcv();
                }

                else if (cbortprint.SelectedValue.ToString() == "JV")
                {
                    prevjv();
                }
                else if (cbortprint.SelectedValue.ToString() == "RV")
                {
                    prevrv();
                }
                else if (cbortprint.SelectedValue.ToString() == "PD")
                {
                    prevpd();
                }
                else if (cbortprint.SelectedValue.ToString() == "PDAE")
                {
                    prevpdae();
                }
                else if (cbortprint.SelectedValue.ToString() == "TF")
                {
                    prevtf();
                }
                else if (cbortprint.SelectedValue.ToString() == "RS")
                {
                    prevrs();
                }
                else if (cbortprint.SelectedValue.ToString() == "AS")
                {
                    prevas();
                }
                else if (cbortprint.SelectedValue.ToString() == "CIDIS" || (cbortprint.SelectedValue.ToString() == "CIDIS2"))
                {
                    prevCIDIS();
                }

                else if (cbortprint.SelectedValue.ToString() == "CISO")
                {
                    prevCISO();
                }
                else if (cbortprint.SelectedValue.ToString() == "CISOPoultry")
                {
                    prevCISOPoultry();
                }
                else if (cbortprint.SelectedValue.ToString() == "OR")
                {
                    prevor();
                }
                else if (cbortprint.SelectedValue.ToString() == "CS")
                {
                    prevCS();
                }
                else if (cbortprint.SelectedValue.ToString() == "AI")
                {
                    PrevAI();
                }
                else if (cbortprint.SelectedValue.ToString() == "RTS")
                {
                    prevRTS();
                }
                else if (cbortprint.SelectedValue.ToString() == "RTSAE")
                {
                    prevRTSAE();
                }
                else if (cbortprint.SelectedValue.ToString() == "CISONew")
                {
                    prevCISO();
                }
                else if (cbortprint.SelectedValue.ToString() == "Manifest")
                {
                    PrevManifest();
                }
                else if (cbortprint.SelectedValue.ToString() == "DSCR")
                {
                    PrevDSCR();
                }
            }
        }
        private void prevapv()
        {
            string sqlstatement = "SELECT * FROM viewbookapv WHERE DocNum BETWEEN '" + cboFrom.Text + "' AND  '" + cboTo.Text + "' ";

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

            CRprevapv_try objRpt = new CRprevapv_try();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            //crystalReportViewer1.Refresh();

            System.Drawing.Printing.PrintDocument doctoprint = new System.Drawing.Printing.PrintDocument();
            //  doctoprint.PrinterSettings.PrinterName = "EPSON LX-300+ /II";
            int rawKind = 0;
            for (int i = 0; i <= doctoprint.PrinterSettings.PaperSizes.Count - 1; i++)
            {
                if (doctoprint.PrinterSettings.PaperSizes[i].PaperName == "C1-HalfShort")
                {
                    rawKind = Convert.ToInt32(doctoprint.PrinterSettings.PaperSizes[i].GetType().GetField("kind",
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes[i]));
                    break; // TODO: might not be correct. Was : Exit For
                }
            }
            objRpt.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
            //CrystalDecisions.Shared.PageMargins pMargin = new CrystalDecisions.Shared.PageMargins(0, 0, 0, 0);
            //objRpt.PrintOptions.ApplyPageMargins(pMargin);
            if (strchoose == "1")
            {
                crystalReportViewer1.ReportSource = objRpt;
            }
            else
            {
                objRpt.Refresh();
                objRpt.PrintToPrinter(1, false, 0, 0);
            }
        }




        private void prevarv()
        {
            string sqlstatement = "SELECT * FROM viewbookarv WHERE DocNum BETWEEN '" + cboFrom.Text + "' AND  '" + cboTo.Text + "' ORDER BY DocNum ";
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
            CRprevarv objRpt = new CRprevarv();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            //vartxtaddress.Text = Form1.glbladdress.Text;
            vartxtaddress.Text = Form1.glbladdress.Text;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            //crystalReportViewer1.Refresh();

            System.Drawing.Printing.PrintDocument doctoprint = new System.Drawing.Printing.PrintDocument();
            //  doctoprint.PrinterSettings.PrinterName = "EPSON LX-300+ /II";
            int rawKind = 0;
            for (int i = 0; i <= doctoprint.PrinterSettings.PaperSizes.Count - 1; i++)
            {
                if (doctoprint.PrinterSettings.PaperSizes[i].PaperName == "C1-HalfShort")
                {
                    rawKind = Convert.ToInt32(doctoprint.PrinterSettings.PaperSizes[i].GetType().GetField("kind",
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes[i]));
                    break; // TODO: might not be correct. Was : Exit For
                }
            }
            objRpt.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
            //CrystalDecisions.Shared.PageMargins pMargin = new CrystalDecisions.Shared.PageMargins(0, 0, 0, 0);
            //objRpt.PrintOptions.ApplyPageMargins(pMargin);
            if (strchoose == "1")
            {
                crystalReportViewer1.ReportSource = objRpt;
            }
            else
            {
                objRpt.Refresh();
                objRpt.PrintToPrinter(1, false, 0, 0);
            }
        }


        private void prevcv()
        {
            string sqlstatement = "SELECT * FROM viewbookcv WHERE DocNum BETWEEN '" + cboFrom.Text + "' AND  '" + cboTo.Text + "' ORDER BY DocNum  ";
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
            CRprevcv objRpt = new CRprevcv();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            //crystalReportViewer1.Refresh();

            System.Drawing.Printing.PrintDocument doctoprint = new System.Drawing.Printing.PrintDocument();
            //  doctoprint.PrinterSettings.PrinterName = "EPSON LX-300+ /II";
            int rawKind = 0;
            for (int i = 0; i <= doctoprint.PrinterSettings.PaperSizes.Count - 1; i++)
            {
                if (doctoprint.PrinterSettings.PaperSizes[i].PaperName == "C1-HalfShort")
                {
                    rawKind = Convert.ToInt32(doctoprint.PrinterSettings.PaperSizes[i].GetType().GetField("kind",
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes[i]));
                    break; // TODO: might not be correct. Was : Exit For
                }
            }
            objRpt.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
            //CrystalDecisions.Shared.PageMargins pMargin = new CrystalDecisions.Shared.PageMargins(0, 0, 0, 0);
            //objRpt.PrintOptions.ApplyPageMargins(pMargin);
            if (strchoose == "1")
            {
                crystalReportViewer1.ReportSource = objRpt;
            }
            else
            {
                objRpt.Refresh();
                objRpt.PrintToPrinter(1, false, 0, 0);
            }

        }

        private void prevjv()
        {
            string sqlstatement = "SELECT * FROM viewbookjv WHERE DocNum BETWEEN '" + cboFrom.Text + "' AND  '" + cboTo.Text + "' ";
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
            CRprevjv objRpt = new CRprevjv();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            //crystalReportViewer1.Refresh();

            System.Drawing.Printing.PrintDocument doctoprint = new System.Drawing.Printing.PrintDocument();
            //  doctoprint.PrinterSettings.PrinterName = "EPSON LX-300+ /II";
            int rawKind = 0;
            for (int i = 0; i <= doctoprint.PrinterSettings.PaperSizes.Count - 1; i++)
            {
                if (doctoprint.PrinterSettings.PaperSizes[i].PaperName == "C1-HalfShort")
                {
                    rawKind = Convert.ToInt32(doctoprint.PrinterSettings.PaperSizes[i].GetType().GetField("kind",
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes[i]));
                    break; // TODO: might not be correct. Was : Exit For
                }
            }
            objRpt.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
            //CrystalDecisions.Shared.PageMargins pMargin = new CrystalDecisions.Shared.PageMargins(0, 0, 0, 0);
            //objRpt.PrintOptions.ApplyPageMargins(pMargin);
            if (strchoose == "1")
            {
                crystalReportViewer1.ReportSource = objRpt;
            }
            else
            {
                objRpt.Refresh();
                objRpt.PrintToPrinter(1, false, 0, 0);
            }

        }

        private void prevrv()
        {
            string sqlstatement = "SELECT * FROM ViewBookRV WHERE DocNum BETWEEN '" + cboFrom.Text + "' AND  '" + cboTo.Text + "' ";
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
            CRprevrv objRpt = new CRprevrv();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            //crystalReportViewer1.Refresh();

            System.Drawing.Printing.PrintDocument doctoprint = new System.Drawing.Printing.PrintDocument();
            //  doctoprint.PrinterSettings.PrinterName = "EPSON LX-300+ /II";
            int rawKind = 0;
            for (int i = 0; i <= doctoprint.PrinterSettings.PaperSizes.Count - 1; i++)
            {
                if (doctoprint.PrinterSettings.PaperSizes[i].PaperName == "C1-HalfShort")
                {
                    rawKind = Convert.ToInt32(doctoprint.PrinterSettings.PaperSizes[i].GetType().GetField("kind",
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes[i]));
                    break; // TODO: might not be correct. Was : Exit For
                }
            }
            objRpt.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
            //CrystalDecisions.Shared.PageMargins pMargin = new CrystalDecisions.Shared.PageMargins(0, 0, 0, 0);
            //objRpt.PrintOptions.ApplyPageMargins(pMargin);
            if (strchoose == "1")
            {
                crystalReportViewer1.ReportSource = objRpt;
            }
            else
            {
                objRpt.Refresh();
                objRpt.PrintToPrinter(1, false, 0, 0);
            }
        }

        private void prevpd()
        {
            string sqlstatement = "SELECT * FROM viewPD WHERE DocNum BETWEEN '" + cboFrom.Text + "' AND  '" + cboTo.Text + "' ";
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
            CRprevPD objRpt = new CRprevPD();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            ClsCompName1.ClsCompNameMain();
            vartxtcompany.Text = ClsCompName1.varcn;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            ClsCompName1.ClsCompNameMain();
            vartxtaddress.Text = ClsCompName1.varaddress;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            //crystalReportViewer1.Refresh();

            System.Drawing.Printing.PrintDocument doctoprint = new System.Drawing.Printing.PrintDocument();
            //  doctoprint.PrinterSettings.PrinterName = "EPSON LX-300+ /II";
            int rawKind = 0;
            for (int i = 0; i <= doctoprint.PrinterSettings.PaperSizes.Count - 1; i++)
            {
                if (doctoprint.PrinterSettings.PaperSizes[i].PaperName == "C1-HalfShort")
                {
                    rawKind = Convert.ToInt32(doctoprint.PrinterSettings.PaperSizes[i].GetType().GetField("kind",
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes[i]));
                    break; // TODO: might not be correct. Was : Exit For
                }
            }
            objRpt.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
            //CrystalDecisions.Shared.PageMargins pMargin = new CrystalDecisions.Shared.PageMargins(0, 0, 0, 0);
            //objRpt.PrintOptions.ApplyPageMargins(pMargin);
            if (strchoose == "1")
            {
                crystalReportViewer1.ReportSource = objRpt;
            }
            else
            {
                objRpt.Refresh();
                objRpt.PrintToPrinter(1, false, 0, 0);
            }
        }
        
        private void prevpdae()
        {
            string sqlstatement = "SELECT * FROM ViewBookPD WHERE DocNum BETWEEN '" + cboFrom.Text + "' AND  '" + cboTo.Text + "' ";
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
            CRPrevPDAE objRpt = new CRPrevPDAE();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            ClsCompName1.ClsCompNameMain();
            vartxtcompany.Text = ClsCompName1.varcn;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            ClsCompName1.ClsCompNameMain();
            vartxtaddress.Text = ClsCompName1.varaddress;

            TextObject vartxtrptTitle = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["txtrptTitle"];
            vartxtrptTitle.Text = "PURCHASE DELIVERY";

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            //crystalReportViewer1.Refresh();

            System.Drawing.Printing.PrintDocument doctoprint = new System.Drawing.Printing.PrintDocument();
            //  doctoprint.PrinterSettings.PrinterName = "EPSON LX-300+ /II";
            int rawKind = 0;
            for (int i = 0; i <= doctoprint.PrinterSettings.PaperSizes.Count - 1; i++)
            {
                if (doctoprint.PrinterSettings.PaperSizes[i].PaperName == "C1-HalfShort")
                {
                    rawKind = Convert.ToInt32(doctoprint.PrinterSettings.PaperSizes[i].GetType().GetField("kind",
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes[i]));
                    break; // TODO: might not be correct. Was : Exit For
                }
            }
            objRpt.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
            //CrystalDecisions.Shared.PageMargins pMargin = new CrystalDecisions.Shared.PageMargins(0, 0, 0, 0);
            //objRpt.PrintOptions.ApplyPageMargins(pMargin);
            if (strchoose == "1")
            {
                crystalReportViewer1.ReportSource = objRpt;
            }
            else
            {
                objRpt.Refresh();
                objRpt.PrintToPrinter(1, false, 0, 0);
            }
        }

        private void prevtf()
        {

            string sqlstatement = "SELECT * FROM viewTF WHERE DocNum BETWEEN '" + cboFrom.Text + "' AND  '" + cboTo.Text + "' ";
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


            CRprevTF objRpt = new CRprevTF();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            ClsCompName1.ClsCompNameMain();
            vartxtcompany.Text = ClsCompName1.varcn;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            ClsCompName1.ClsCompNameMain();
            vartxtaddress.Text = ClsCompName1.varaddress;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            //crystalReportViewer1.Refresh();

            System.Drawing.Printing.PrintDocument doctoprint = new System.Drawing.Printing.PrintDocument();
            //  doctoprint.PrinterSettings.PrinterName = "EPSON LX-300+ /II";
            int rawKind = 0;
            for (int i = 0; i <= doctoprint.PrinterSettings.PaperSizes.Count - 1; i++)
            {
                if (doctoprint.PrinterSettings.PaperSizes[i].PaperName == "C1-HalfShort")
                {
                    rawKind = Convert.ToInt32(doctoprint.PrinterSettings.PaperSizes[i].GetType().GetField("kind",
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes[i]));
                    break; // TODO: might not be correct. Was : Exit For
                }
            }
            objRpt.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
            //CrystalDecisions.Shared.PageMargins pMargin = new CrystalDecisions.Shared.PageMargins(0, 0, 0, 0);
            //objRpt.PrintOptions.ApplyPageMargins(pMargin);
            if (strchoose == "1")
            {
                crystalReportViewer1.ReportSource = objRpt;
            }
            else
            {
                objRpt.Refresh();
                objRpt.PrintToPrinter(1, false, 0, 0);
            }
        }
        
        private void prevrs()
        {

            string sqlstatement = "SELECT * FROM viewRS WHERE DocNum BETWEEN '" + cboFrom.Text + "' AND  '" + cboTo.Text + "' ORDER BY Num  ";

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
            CRprevRS objRpt = new CRprevRS();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            //crystalReportViewer1.Refresh();

            System.Drawing.Printing.PrintDocument doctoprint = new System.Drawing.Printing.PrintDocument();
            //  doctoprint.PrinterSettings.PrinterName = "EPSON LX-300+ /II";
            int rawKind = 0;
            for (int i = 0; i <= doctoprint.PrinterSettings.PaperSizes.Count - 1; i++)
            {
                if (doctoprint.PrinterSettings.PaperSizes[i].PaperName == "C1-HalfShort")
                {
                    rawKind = Convert.ToInt32(doctoprint.PrinterSettings.PaperSizes[i].GetType().GetField("kind",
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes[i]));
                    break; // TODO: might not be correct. Was : Exit For
                }
            }
            objRpt.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
            //CrystalDecisions.Shared.PageMargins pMargin = new CrystalDecisions.Shared.PageMargins(0, 0, 0, 0);
            //objRpt.PrintOptions.ApplyPageMargins(pMargin);
            if (strchoose == "1")
            {
                crystalReportViewer1.ReportSource = objRpt;
            }
            else
            {
                objRpt.Refresh();
                objRpt.PrintToPrinter(1, false, 0, 0);
            }
        }

        private void prevas()
        {
            string sqlstatement = "SELECT * FROM viewAS WHERE DocNum BETWEEN '" + cboFrom.Text + "' AND  '" + cboTo.Text + "' ";
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
            CRprevAS objRpt = new CRprevAS();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            //crystalReportViewer1.Refresh();

            System.Drawing.Printing.PrintDocument doctoprint = new System.Drawing.Printing.PrintDocument();
            //  doctoprint.PrinterSettings.PrinterName = "EPSON LX-300+ /II";
            int rawKind = 0;
            for (int i = 0; i <= doctoprint.PrinterSettings.PaperSizes.Count - 1; i++)
            {
                if (doctoprint.PrinterSettings.PaperSizes[i].PaperName == "C1-HalfShort")
                {
                    rawKind = Convert.ToInt32(doctoprint.PrinterSettings.PaperSizes[i].GetType().GetField("kind",
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes[i]));
                    break; // TODO: might not be correct. Was : Exit For
                }
            }
            objRpt.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
            //CrystalDecisions.Shared.PageMargins pMargin = new CrystalDecisions.Shared.PageMargins(0, 0, 0, 0);
            //objRpt.PrintOptions.ApplyPageMargins(pMargin);
            if (strchoose == "1")
            {
                crystalReportViewer1.ReportSource = objRpt;
            }
            else
            {
                objRpt.Refresh();
                objRpt.PrintToPrinter(1, false, 0, 0);
            }
        }

        private void prevCIDIS()
        {

            string sqlstatement = "SELECT * FROM viewCI WHERE DocNum BETWEEN '" + cboFrom.Text + "' AND  '" + cboTo.Text + "' ORDER BY DocNum ";

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

            if (cbortprint.SelectedValue.ToString() == "CIDIS")
            {
                CRprevCI1 objRpt = new CRprevCI1();
                TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
                vartxtcompany.Text = Form1.glblncompany.Text;

                TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
                vartxtaddress.Text = Form1.glbladdress.Text;

                objRpt.SetDataSource(DataTable1);
                crystalReportViewer1.ReportSource = objRpt;
                crystalReportViewer1.Refresh();
            }
            else
            {
                CRprevCI2 objRpt = new CRprevCI2();
                TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
                vartxtcompany.Text = Form1.glblncompany.Text;

                TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
                vartxtaddress.Text = Form1.glbladdress.Text;

                objRpt.SetDataSource(DataTable1);
                crystalReportViewer1.ReportSource = objRpt;
                crystalReportViewer1.Refresh();
            }
        }
        //private void prevCIDISP()
        //{

        //    string sqlstatement = "SELECT * FROM viewCI WHERE DocNum ='" + txtDocNum.Text + "'";

        //    ClsGetConnection1.ClsGetConMSSQL();
        //    myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
        //    myconnection.Open();
        //    mycommand = myconnection.CreateCommand();
        //    mycommand.CommandText = sqlstatement;
        //    mycommand.CommandTimeout = 900;
        //    SqlDataReader1 = mycommand.ExecuteReader();
        //    DataTable DataTable1 = new DataTable();
        //    DataTable1.Load(SqlDataReader1);
        //    myconnection.Close();

        //    if (DataTable1.Rows.Count == 0)
        //    {
        //        MessageBox.Show("No data found", "GL");
        //        return;
        //    }
        //    CRprevCI1 objRpt = new CRprevCI1();
        //    TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
        //    vartxtcompany.Text = Form1.glblncompany.Text;

        //    TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
        //    vartxtaddress.Text = Form1.glbladdress.Text;

        //    objRpt.SetDataSource(DataTable1);
        //    crystalReportViewer1.ReportSource = objRpt;
        //    crystalReportViewer1.Refresh();



        //}

        private void prevCISO()
        {
            string sqlstatement = "SELECT * FROM viewCI WHERE DocNum BETWEEN '" + cboFrom.Text + "' AND  '" + cboTo.Text + "' ORDER BY DocNum";
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

            if (cbortprint.SelectedValue.ToString() == "CISO")
            {
                CRprevCISO objRpt = new CRprevCISO();
                objRpt.SetDataSource(DataTable1);
                crystalReportViewer1.ReportSource = objRpt;
                crystalReportViewer1.Refresh();
            }
            else
            {
                CRprevCISONew objRpt = new CRprevCISONew();
                objRpt.SetDataSource(DataTable1);
                crystalReportViewer1.ReportSource = objRpt;
                crystalReportViewer1.Refresh();

            }
            //TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            //vartxtcompany.Text = Form1.glblncompany.Text;

            //TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            //vartxtaddress.Text = Form1.glbladdress.Text;




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
            //crystalReportViewer1.ReportSource = objRpt;
        }

        private void PrevManifest()
        {
            string sqlstatement = "SELECT DVDesc, DTDesc, MNum, MAX(MDate) AS MDate, CustName, PersonnelName, Reference, MAX(TDate) AS TDate, SUM(GrossAmt) AS GrossAmt, UserName ";
            sqlstatement += "FROM ViewBookManifest WHERE MNum BETWEEN '" + cboFrom.Text + "' AND  '" + cboTo.Text + "' GROUP BY DVDesc, DTDesc, MNum, CustName, PersonnelName, Reference, UserName ORDER BY CUSTNAME ASC";
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
            CRprevManifest objRpt = new CRprevManifest();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            //crystalReportViewer1.Refresh();

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
            //CrystalDecisions.Shared.PageMargins pMargin = new CrystalDecisions.Shared.PageMargins(0, 0, 0, 0);
            //objRpt.PrintOptions.ApplyPageMargins(pMargin);
            if (strchoose == "1")
            {
                crystalReportViewer1.ReportSource = objRpt;
            }
            else
            {
                objRpt.Refresh();
                objRpt.PrintToPrinter(1, false, 0, 0);
            }
        }

        private void PrevDSCR()
        {
            string sqlstatement = "SELECT TDate, CustName, Amount, Reference, UserName FROM ViewDSCRDetails WHERE DSCRNum = '" + cboFrom.Text + "' ";
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
            CRprevDSCR objRpt = new CRprevDSCR();

            TextObject vartxtSalesman = (TextObject)objRpt.ReportDefinition.Sections["Section2"].ReportObjects["rpttxtSalesman"];
            ClsGetSomething1.ClsGetDCRData(cboFrom.Text); 
            vartxtSalesman.Text = ClsGetSomething1.plsSalesman;

            TextObject vartxtRemarks = (TextObject)objRpt.ReportDefinition.Sections["Section2"].ReportObjects["rpttxtRemarks"];
            ClsGetSomething1.ClsGetDCRData(cboFrom.Text);
            vartxtRemarks.Text = ClsGetSomething1.plsRemarks;
            
            TextObject vartxtRepDate = (TextObject)objRpt.ReportDefinition.Sections["Section2"].ReportObjects["rpttxtRepDate"];
            ClsGetSomething1.ClsGetDCRData(cboFrom.Text);            
            vartxtRepDate.Text = Convert.ToDateTime(ClsGetSomething1.plsDcrDate).ToString("MM/dd/yyyy");

            TextObject vartxtdocnum = (TextObject)objRpt.ReportDefinition.Sections["Section2"].ReportObjects["rpttxtdocnum"];
            vartxtdocnum.Text = ClsGetSomething1.plsDocNum;

           
            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            //crystalReportViewer1.Refresh();

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
            //CrystalDecisions.Shared.PageMargins pMargin = new CrystalDecisions.Shared.PageMargins(0, 0, 0, 0);
            //objRpt.PrintOptions.ApplyPageMargins(pMargin);
            if (strchoose == "1")
            {
                crystalReportViewer1.ReportSource = objRpt;
            }
            else
            {
                objRpt.Refresh();
                objRpt.PrintToPrinter(1, false, 0, 0);
            }
        }

        private void prevCISOPoultry()
        {
            string sqlstatement = "SELECT * FROM viewCI WHERE DocNum BETWEEN '" + cboFrom.Text + "' AND  '" + cboTo.Text + "' ";
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
            CRprevCISOPoultry objRpt = new CRprevCISOPoultry();
            //TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            //vartxtcompany.Text = Form1.glblncompany.Text;

            //TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            //vartxtaddress.Text = Form1.glbladdress.Text;


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
            //crystalReportViewer1.ReportSource = objRpt;

        }
        private void prevCS()
        {
            string sqlstatement = "SELECT * FROM viewCS WHERE DocNum BETWEEN '" + cboFrom.Text + "' AND  '" + cboTo.Text + "' ";
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
            CRprevCS objRpt = new CRprevCS();
            //TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            //vartxtcompany.Text = Form1.glblncompany.Text;

            //TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            //vartxtaddress.Text = Form1.glbladdress.Text;


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
            //crystalReportViewer1.ReportSource = objRpt;

        }

        private void prevor()
        {
            string sqlstatement = "SELECT * FROM viewbookor WHERE DocNum BETWEEN '" + cboFrom.Text + "' AND  '" + cboTo.Text + "' ";
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
            CRprevOR objRpt = new CRprevOR();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            //crystalReportViewer1.Refresh();

            System.Drawing.Printing.PrintDocument doctoprint = new System.Drawing.Printing.PrintDocument();
            //  doctoprint.PrinterSettings.PrinterName = "EPSON LX-300+ /II";
            int rawKind = 0;
            for (int i = 0; i <= doctoprint.PrinterSettings.PaperSizes.Count - 1; i++)
            {
                if (doctoprint.PrinterSettings.PaperSizes[i].PaperName == "C1-HalfShort")
                {
                    rawKind = Convert.ToInt32(doctoprint.PrinterSettings.PaperSizes[i].GetType().GetField("kind",
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes[i]));
                    break; // TODO: might not be correct. Was : Exit For
                }
            }
            objRpt.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
            //CrystalDecisions.Shared.PageMargins pMargin = new CrystalDecisions.Shared.PageMargins(0, 0, 0, 0);
            //objRpt.PrintOptions.ApplyPageMargins(pMargin);
            if (strchoose == "1")
            {
                crystalReportViewer1.ReportSource = objRpt;
            }
            else
            {
                objRpt.Refresh();
                objRpt.PrintToPrinter(1, false, 0, 0);
            }

        }

        private void PrevAI()
        {
            string sqlstatement = "SELECT * FROM ViewAI WHERE DocNum BETWEEN '" + cboFrom.Text + "' AND  '" + cboTo.Text + "' ORDER BY DocNum Desc";
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
            CRprevAI objRpt = new CRprevAI();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }

        private void prevRTS()
        {

            string sqlstatement = "SELECT * FROM viewRTS WHERE DocNum BETWEEN '" + cboFrom.Text + "' AND  '" + cboTo.Text + "' ";
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
            
            CRprevRTS objRpt = new CRprevRTS();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            ClsCompName1.ClsCompNameMain();
            vartxtcompany.Text = ClsCompName1.varcn;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            ClsCompName1.ClsCompNameMain();
            vartxtaddress.Text = ClsCompName1.varaddress;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            //crystalReportViewer1.Refresh();

            System.Drawing.Printing.PrintDocument doctoprint = new System.Drawing.Printing.PrintDocument();
            //  doctoprint.PrinterSettings.PrinterName = "EPSON LX-300+ /II";
            int rawKind = 0;
            for (int i = 0; i <= doctoprint.PrinterSettings.PaperSizes.Count - 1; i++)
            {
                if (doctoprint.PrinterSettings.PaperSizes[i].PaperName == "C1-HalfShort")
                {
                    rawKind = Convert.ToInt32(doctoprint.PrinterSettings.PaperSizes[i].GetType().GetField("kind",
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes[i]));
                    break; // TODO: might not be correct. Was : Exit For
                }
            }
            objRpt.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
            //CrystalDecisions.Shared.PageMargins pMargin = new CrystalDecisions.Shared.PageMargins(0, 0, 0, 0);
            //objRpt.PrintOptions.ApplyPageMargins(pMargin);
            if (strchoose == "1")
            {
                crystalReportViewer1.ReportSource = objRpt;
            }
            else
            {
                objRpt.Refresh();
                objRpt.PrintToPrinter(1, false, 0, 0);
            }
        }
        
        private void prevRTSAE()
        {
            string sqlstatement = "SELECT * FROM ViewBookRTS WHERE DocNum BETWEEN '" + cboFrom.Text + "' AND  '" + cboTo.Text + "' ";
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

            CRprevRTSAE objRpt = new CRprevRTSAE();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            ClsCompName1.ClsCompNameMain();
            vartxtcompany.Text = ClsCompName1.varcn;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            ClsCompName1.ClsCompNameMain();
            vartxtaddress.Text = ClsCompName1.varaddress;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            //crystalReportViewer1.Refresh();

            System.Drawing.Printing.PrintDocument doctoprint = new System.Drawing.Printing.PrintDocument();
            //  doctoprint.PrinterSettings.PrinterName = "EPSON LX-300+ /II";
            int rawKind = 0;
            for (int i = 0; i <= doctoprint.PrinterSettings.PaperSizes.Count - 1; i++)
            {
                if (doctoprint.PrinterSettings.PaperSizes[i].PaperName == "C1-HalfShort")
                {
                    rawKind = Convert.ToInt32(doctoprint.PrinterSettings.PaperSizes[i].GetType().GetField("kind",
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes[i]));
                    break; // TODO: might not be correct. Was : Exit For
                }
            }
            objRpt.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
            //CrystalDecisions.Shared.PageMargins pMargin = new CrystalDecisions.Shared.PageMargins(0, 0, 0, 0);
            //objRpt.PrintOptions.ApplyPageMargins(pMargin);
            if (strchoose == "1")
            {
                crystalReportViewer1.ReportSource = objRpt;
            }
            else
            {
                objRpt.Refresh();
                objRpt.PrintToPrinter(1, false, 0, 0);
            }
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
            cboFrom.DataSource = null;
            cboTo.DataSource = null;
            label3.Visible = true;
            cboTo.Visible = true;
            label2.Text = "From :";
            checking = "";
            if (cbortprint.SelectedValue.ToString() == "APV")
            {
                if(ClsGetSomething1.clsChecking("APV") == "0")
                {
                    MessageBox.Show("No Data Found", "GL");
                    return;
                }
                buildcboFrom("APV");
                buildcboTo("APV");

            }
            else if (cbortprint.SelectedValue.ToString() == "ARV")
            {
                ClsAutoNumber1.VoucherLatestNum("ARV");
                //txtDocNum.Text = (ClsAutoNumber1.plsnumber);
                if (ClsGetSomething1.clsChecking("ARV") == "0")
                {
                    MessageBox.Show("No Data Found", "GL");
                    return;
                }
                buildcboFrom("ARV");
                buildcboTo("ARV");
            }
            else if (cbortprint.SelectedValue.ToString() == "CV")
            {
                //ClsAutoNumber1.VoucherLatestNum("CV");
                //txtDocNum.Text = (ClsAutoNumber1.plsnumber);
                if (ClsGetSomething1.clsChecking("CV") == "0")
                {
                    MessageBox.Show("No Data Found", "GL");
                    return;
                }
                buildcboFrom("CV");
                buildcboTo("CV");
            }
            else if (cbortprint.SelectedValue.ToString() == "JV")
            {
                //ClsAutoNumber1.VoucherLatestNum("JV");
                //txtDocNum.Text = (ClsAutoNumber1.plsnumber);
                if (ClsGetSomething1.clsChecking("JV") == "0")
                {
                    MessageBox.Show("No Data Found", "GL");
                    return;
                }
                buildcboFrom("JV");
                buildcboTo("JV");
            }
            else if (cbortprint.SelectedValue.ToString() == "RV")
            {
                //ClsAutoNumber1.VoucherLatestNum("RV");
                //txtDocNum.Text = (ClsAutoNumber1.plsnumber);
                if (ClsGetSomething1.clsChecking("RV") == "0")
                {
                    MessageBox.Show("No Data Found", "GL");
                    return;
                }
                buildcboFrom("RV");
                buildcboTo("RV");
            }
            else if (cbortprint.SelectedValue.ToString() == "PD" || cbortprint.SelectedValue.ToString() == "PDAE")
            {
                //ClsAutoNumber1.VoucherLatestNum("PD");
                //txtDocNum.Text = (ClsAutoNumber1.plsnumber);
                if (ClsGetSomething1.clsChecking("PD") == "0")
                {
                    MessageBox.Show("No Data Found", "GL");
                    return;
                }
                buildcboFrom("PD");
                buildcboTo("PD");
            }
            else if (cbortprint.SelectedValue.ToString() == "TF")
            {
                //ClsAutoNumber1.VoucherLatestNum("TF");
                //txtDocNum.Text = (ClsAutoNumber1.plsnumber);
                if (ClsGetSomething1.clsChecking("TF") == "0")
                {
                    MessageBox.Show("No Data Found", "GL");
                    return;
                }
                buildcboFrom("TF");
                buildcboTo("TF");
            }
            else if (cbortprint.SelectedValue.ToString() == "RS")
            {
                //ClsAutoNumber1.VoucherLatestNum("RS");
                //txtDocNum.Text = (ClsAutoNumber1.plsnumber);
                if (ClsGetSomething1.clsChecking("RS") == "0")
                {
                    MessageBox.Show("No Data Found", "GL");
                    return;
                }
                buildcboFrom("RS");
                buildcboTo("RS");
            }
            else if (cbortprint.SelectedValue.ToString() == "AS")
            {
                //ClsAutoNumber1.VoucherLatestNum("AS");
                //txtDocNum.Text = (ClsAutoNumber1.plsnumber);
                if (ClsGetSomething1.clsChecking("AS") == "0")
                {
                    MessageBox.Show("No Data Found", "GL");
                    return;
                }
                buildcboFrom("AS");
                buildcboTo("AS");
            }

            else if (cbortprint.SelectedValue.ToString() == "CIDIS" || cbortprint.SelectedValue.ToString() == "CIDIS2")
            {
                //ClsAutoNumber1.VoucherLatestNum("CI");
                //txtDocNum.Text = (ClsAutoNumber1.plsnumber);
                if (ClsGetSomething1.clsChecking("CI") == "0")
                {
                    MessageBox.Show("No Data Found", "GL");
                    return;
                }
                buildcboFrom("CI");
                buildcboTo("CI");
            }
            else if (cbortprint.SelectedValue.ToString() == "CISO" || cbortprint.SelectedValue.ToString() == "CISONew" || cbortprint.SelectedValue.ToString() == "CISOPoultry")
            {
                //ClsAutoNumber1.VoucherLatestNum("CI");
                //txtDocNum.Text = (ClsAutoNumber1.plsnumber);
                if (ClsGetSomething1.clsChecking("CI") == "0")
                {
                    MessageBox.Show("No Data Found", "GL");
                    return;
                }
                buildcboFrom("CI");
                buildcboTo("CI");
            }
            //else if (cbortprint.SelectedValue.ToString() == "CISOPoultry")
            //{
            //    //ClsAutoNumber1.VoucherLatestNum("CI");
            //    //txtDocNum.Text = (ClsAutoNumber1.plsnumber);
            //    if (ClsGetSomething1.clsChecking("CI") == "0")
            //    {
            //        MessageBox.Show("No Data Found", "GL");
            //        return;
            //    }
            //    buildcboFrom("CI");
            //    buildcboTo("CI");
            //}
            else if (cbortprint.SelectedValue.ToString() == "OR")
            {
                //ClsAutoNumber1.VoucherLatestNum("OR");
                //txtDocNum.Text = (ClsAutoNumber1.plsnumber);
                if (ClsGetSomething1.clsChecking("OR") == "0")
                {
                    MessageBox.Show("No Data Found", "GL");
                    return;
                }
                buildcboFrom("OR");
                buildcboTo("OR");
            }
            else if (cbortprint.SelectedValue.ToString() == "CS")
            {
                //ClsAutoNumber1.VoucherLatestNum("CS");
                //txtDocNum.Text = (ClsAutoNumber1.plsnumber);
                if (ClsGetSomething1.clsChecking("CS") == "0")
                {
                    MessageBox.Show("No Data Found", "GL");
                    return;
                }
                buildcboFrom("CS");
                buildcboTo("CS");
            }
            else if (cbortprint.SelectedValue.ToString() == "AI")
            {
                //ClsAutoNumber1.VoucherLatestNumAI();
                //txtDocNum.Text = (ClsAutoNumber1.plsnumber);
                if (ClsGetSomething1.clsChecking("tblMain4") == "0")
                {
                    MessageBox.Show("No Data Found", "GL");
                    return;
                }
                buildcboFrom("tblMain4");
                buildcboTo("tblMain4");
            }
            else if (cbortprint.SelectedValue.ToString() == "RTS" || cbortprint.SelectedValue.ToString() == "RTSAE")
            {
                //ClsAutoNumber1.VoucherLatestNum("RTS");
                //txtDocNum.Text = (ClsAutoNumber1.plsnumber);
                if (ClsGetSomething1.clsChecking("RTS") == "0")
                {
                    MessageBox.Show("No Data Found", "GL");
                    return;
                }
                buildcboFrom("RTS");
                buildcboTo("RTS");
            }
            else if (cbortprint.SelectedValue.ToString() == "Manifest")
            {
                //ClsAutoNumber1.VoucherManifestLatest();
                //txtDocNum.Text = (ClsAutoNumber1.plsnumber);
                if (ClsGetSomething1.clsChecking("tblManifest") == "0")
                {
                    MessageBox.Show("No Data Found", "GL");
                    return;
                }
                buildcboFrom("tblManifest");
                buildcboTo("tblManifest");
            }
            else if (cbortprint.SelectedValue.ToString() == "DSCR")
            {
                //ClsAutoNumber1.VoucherDailySalesLatest();
                //txtDocNum.Text = (ClsAutoNumber1.plsnumber);
                if (ClsGetSomething1.clsChecking("tblDailySalesCollection") == "0")
                {
                    MessageBox.Show("No Data Found", "GL");
                    return;
                }
                buildcboFrom("tblDailySalesCollection");
                label3.Visible = false;
                cboTo.Visible = false;
                label2.Text = "Number :";
                checking = "False";
                //buildcboTo("tblDailySalesCollection");

            }

        }

        private void buildcboFrom(string strURIVoucher)
        {
            ClsBuildComboBox1.plsnumber.Clear();
            ClsBuildComboBox1.ClsCboSelect(strURIVoucher);
            this.cboFrom.DataSource = (ClsBuildComboBox1.plsnumber);
            this.cboFrom.DisplayMember = "Display";
            this.cboFrom.ValueMember = "Value";
        }
        private void buildcboTo(string strURIVoucher)
        {

            ClsBuildComboBox1.plsnumber1.Clear();
            ClsBuildComboBox1.ClsCboSelect(strURIVoucher);
            this.cboTo.DataSource = (ClsBuildComboBox1.plsnumber1);
            this.cboTo.DisplayMember = "Display";
            this.cboTo.ValueMember = "Value";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            strchoose = "2";
            prevprint();
        }
    }
}
