using CrystalDecisions.CrystalReports.Engine;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace K5GLONLINE
{
    public partial class frmprptUnserveRepo : Form
    {
        string sqlstament;
        SqlConnection myconnection;
        SqlCommand mycommand;
        SqlDataReader SqlDataReader1;
        SqlDataAdapter da;
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsGetSomething ClsGetSomething1 = new ClsGetSomething();
        ClsCompName ClsCompName1 = new ClsCompName();


        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        public frmprptUnserveRepo()
        {
            InitializeComponent();
        }

        private void frmprptUnserveRepo_Load(object sender, EventArgs e)
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
                txtDateFrom.Text = ClsGetSomething1.plsdefdate;
                txtDateTo.Text = ClsGetSomething1.plsdefdate;
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DSUnservdReport.ViewUnservedProducts' table. You can move, or remove it, as needed.

            //DSUnservdReport dsDataSet = new DSUnservdReport();

            //sqlstament = "SELECT * FROM ViewUnservedProducts WHERE OrderDate BETWEEN '" + txtDateFrom.Text + "' AND '" + txtDateTo.Text + "' ";

            //ClsGetConnection1.ClsGetConMSSQL();
            //myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            //myconnection.Open();


            //da = new SqlDataAdapter(sqlstament, myconnection);
            //da.Fill(dsDataSet, dsDataSet.Tables[0].TableName);

            //this.ViewUnservedProductsTableAdapter.Fill(this.DSUnservdReport.ViewUnservedProducts);
            //ReportDataSource rds = new ReportDataSource("DSUnservedReport", dsDataSet.Tables[0]);
            //this.reportViewer1.LocalReport.DataSources.Clear();
            //this.reportViewer1.LocalReport.DataSources.Add(rds);
            //this.reportViewer1.Refresh();

            ////Parameters 
            //ClsCompName1.ClsCompNameMain();
            //ReportParameter cName = new ReportParameter("CName", ClsCompName1.varcn);
            //this.reportViewer1.LocalReport.SetParameters(cName);

            //ReportParameter cAddress = new ReportParameter("CAddress", ClsCompName1.varaddress);
            //this.reportViewer1.LocalReport.SetParameters(cAddress);

            //ReportParameter rptData = new ReportParameter("RptDate", "From " + txtDateFrom.Text +" To "+ txtDateTo.Text +" ");
            //this.reportViewer1.LocalReport.SetParameters(rptData);

            //ReportParameter rptTitle = new ReportParameter("RptTitle", "Unserved Report");
            //this.reportViewer1.LocalReport.SetParameters(rptTitle);

            //this.reportViewer1.RefreshReport();

            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            sqlstament = "SELECT * FROM ViewUnservedProducts WHERE OrderDate BETWEEN '" + txtDateFrom.Text + "' AND '" + txtDateTo.Text + "' ";

            SqlDataAdapter dscmd = new SqlDataAdapter( sqlstament, myconnection);
            DSUnserveRepo dsplrv = new DSUnserveRepo();
            dscmd.Fill(dsplrv,"ViewUnservedProducts");
            myconnection.Close();

            ClsCompName1.ClsCompNameMain();
            CRUnservedReports objRpt = new CRUnservedReports();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["txtcompname"];
            vartxtcompany.Text = ClsCompName1.varcn;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["txtcompaddress"];
            vartxtaddress.Text = ClsCompName1.varaddress;

            TextObject vartxtdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["txtdate"];
            vartxtdate.Text = "From " + txtDateFrom.Text + " To " + txtDateTo.Text + " ";

            TextObject vartxtreporttitle = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["txtreporttitle"];
            vartxtreporttitle.Text = "Unserved Report";

            objRpt.SetDataSource(dsplrv.Tables[1]);
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
            objRpt.Refresh();
            objRpt.PrintToPrinter(1, false, 0, 0);

        }
    }
}
