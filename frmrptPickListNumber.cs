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
//using K5GLONLINE;
//using K5GLV3.FldrClass;
//using K5GLV3.FldrLog;
//using K5GLV3.FldrCrystalReports;

namespace K5GLONLINE
{
    public partial class frmrptPickListNumber : Form
    {
        SqlConnection myconnection;
        //SqlDataReader dr;
        SqlCommand mycommand;
        BindingSource dbind = new BindingSource();
        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();
        ClsBuildVoucherComboBox ClsBuildVoucherComboBox1 = new ClsBuildVoucherComboBox();
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsAutoNumber ClsAutoNumber1 = new ClsAutoNumber();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        string strchoose = "1";

        SqlDataReader SqlDataReader1;
        public frmrptPickListNumber()
        {
            InitializeComponent();
        }

        private void frmrptPickListNumber1_Load(object sender, EventArgs e)
        {
            //ClsPermission1.ClsObjects(this.Text);
            //if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
            //{
            //    MessageBox.Show("You do not have necessary permission to open this file", "GL");
            //    this.Close();
            //}
            //else
            //{
            buildcboCNCode();
            //ClsBuildComboBox1.ClsBuildCompanyList(cboCNCode);
            //cboCNCode.SelectedValue = (ClsDefaultBranch1.plsvardb);
            this.WindowState = FormWindowState.Maximized;
            //}
        }
        private void buildcboCNCode()
        {
            //cboCNCode.DataSource = null;
            //ClsBuildComboBox1.ARBranch.Clear();
            //ClsBuildComboBox1.ClsBuildBranch();
            //this.cboCNCode.DataSource = (ClsBuildComboBox1.ARBranch);
            //this.cboCNCode.DisplayMember = "Display";
            //this.cboCNCode.ValueMember = "Value";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            strchoose = "1";
            PrevPLNew();
        }
        private void PrevPLNew()
        {
            string sqlstatement;
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            string PLNumber = txtDocNum.Text + "01";
            sqlstatement = "SELECT ClassDesc, Names, Warehouse, CustName, Piece, IB, Item AS StockDesc, StockNumber, UserName, SUM(ConvertedQty) As SumConvertedQty, SUM(Amount) AS Amount ";
            sqlstatement += "FROM ViewPickListNumber WHERE PLNum = '" + PLNumber + "' AND CNCode = '01'";
            sqlstatement += "GROUP By ClassDesc, Names, Warehouse, CustName, Piece, IB, Item, StockNumber, UserName";

            string sqlstatementRef;
            sqlstatementRef = "SELECT CustName FROM ViewPickListNumber  WHERE PLNum = '" + PLNumber + "' AND CNCode = '01' GROUP BY CustName";

            SqlDataAdapter dscmd = new SqlDataAdapter(sqlstatement, myconnection);
            DSInvBal DSInvBal1 = new DSInvBal();
            dscmd.Fill(DSInvBal1, "DSPLNumber");


            SqlDataAdapter dscmd1 = new SqlDataAdapter(sqlstatementRef, myconnection);
            DSPickListReference DSPickListReference1 = new DSPickListReference();
            dscmd1.Fill(DSPickListReference1, "DSPickListReference");


            //SqlDataAdapter SqlDA2 = new SqlDataAdapter(sqlstatementCustomer, myconnection);
            //SqlDA2.SelectCommand.CommandTimeout = 600;
            //DSPickListCustName DSPickListCustName1 = new DSPickListCustName();
            //SqlDA2.Fill(DSPickListCustName1, "DSPickListTerritory1");


            myconnection.Close();

            CRPickList objRpt = new CRPickList();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            TextObject varTextDocNum = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextDocNum"];
            varTextDocNum.Text = txtDocNum.Text;

            objRpt.SetDataSource(DSInvBal1.Tables[1]);
            objRpt.Subreports[0].SetDataSource(DSPickListReference1.Tables[1]);

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

            if (strchoose == "1")
            {
                crystalReportViewer1.ReportSource = objRpt;
            }
            else
            {
                objRpt.Refresh();
                objRpt.PrintToPrinter(1, false, 0, 0);
                crystalReportViewer1.ReportSource = objRpt;
            }
        }
        private void cboCName_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().emptytxt(cboCNCode.Text))
            {
            }
            else if (cboCNCode.Text != null && cboCNCode.SelectedValue == null)
            {
                MessageBox.Show("Not found", "GL");
                cboCNCode.Focus();
            }
        }
        private void cbortprint_Validating(object sender, CancelEventArgs e)
        {
            if (cbortprint.Text == "Pick List - SO")
            {
                ClsAutoNumber1.LaterPLNumber("01");
                txtDocNum.Text = ClsAutoNumber1.plsnumber; 
                //txtDocNum.Text = await ClsGetAutoNumber1.GetPLNumber(frmLogin.glbltxtCNCode.Text);
                //ClsAutoNumber1.VoucherLatestNumPL(cboCNCode.SelectedValue.ToString());
                //txtDocNum.Text = (ClsAutoNumber1.plsnumber);
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
        private void CrystalReportPermission()
        {
            //if (new ClsPermission().ClsstrCRObject(Form1.glblgroupcode.Text, cbortprint.Text) == false)
            //{
            //    btnPreview.Enabled = false;
            //    MessageBox.Show("You do not have necessary permission to open this file", "GL");
            //}
            //else
            //{
            //    btnPreview.Enabled = true;
            //}
        }
        private void cbortprint_Leave(object sender, EventArgs e)
        {
            CrystalReportPermission();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            strchoose = "2";
            PrevPLNew();
        }
    }
}
