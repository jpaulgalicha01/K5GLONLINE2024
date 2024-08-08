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

    public partial class frmrptPickList : Form
    {
        SqlConnection myconnection;
        BindingSource dbind = new BindingSource();
        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();
        ClsBuildVoucherComboBox ClsBuildVoucherComboBox1 = new ClsBuildVoucherComboBox();
        ClsCompName ClsCompName1 = new ClsCompName();
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        public frmrptPickList()
        {
            InitializeComponent();
        }
        private void buildcboWHCode()
        {
            ClsBuildVoucherComboBox1.ClsBuildWarehouse();
            this.cboWHCode.DataSource = (ClsBuildVoucherComboBox1.ARLWHCode);
            this.cboWHCode.DisplayMember = "Display";
            this.cboWHCode.ValueMember = "Value";
        }
        private void buildcboControlNo()
        {
            cboListing.DataSource = null;
            ClsBuildComboBox1.ARCCN.Clear();
            ClsBuildComboBox1.ClsBuildClientControlno("C");
            this.cboListing.DataSource = (ClsBuildComboBox1.ARCCN);
            this.cboListing.DisplayMember = "Display";
            this.cboListing.ValueMember = "Value";
        }
        private void buildcboSalesman()
        {
            cboListing.DataSource = null;
            ClsBuildVoucherComboBox1.ARLSLS.Clear();
            ClsBuildVoucherComboBox1.ClsBuildSalesman();
            this.cboListing.DataSource = (ClsBuildVoucherComboBox1.ARLSLS);
            this.cboListing.DisplayMember = "Display";
            this.cboListing.ValueMember = "Value";
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
                buildcboWHCode();
                this.WindowState = FormWindowState.Maximized;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (new ClsValidation().emptytxt(cbortprint.Text))
            {
                MessageBox.Show("Please complete your entry", "GL");
                cbortprint.Focus();
            }
            else if (new ClsValidation().emptytxt(cboListing.Text))
            {
                MessageBox.Show("Please complete your entry", "GL");
                cboListing.Focus();
            }
            else if (new ClsValidation().emptytxt(cboWHCode.Text))
            {
                MessageBox.Show("Please complete your entry", "GL");
                cboWHCode.Focus();
            }
            else
            {
                //if ((string)listBox1.SelectedItem == "Two")
                //    MessageBox.Show((string)listBox1.SelectedItem);

                // if ((string)cbortprint.SelectedValue=="01")
                if (cbortprint.Text == "Salesman")
                {
                    picklistSalesman();
                }
                else if (cbortprint.Text == "Customer")
                {
                    picklistCustomer();
                }

                else if (cbortprint.Text == "Salesman Customer")
                {
                    Listcustomer();
                }
            }
        }
        private void picklistCustomer()
        {
            string sqlstatement = "";
            ClsGetConnection1.ClsGetConMSSQL(); myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            sqlstatement = "SELECT Piece, IB, Item, ClassDesc, StockNumber, Sum(SalesAmt) As SAmt,";
            sqlstatement += "CAST(SUM(ConvertedQty) AS int) % Piece AS QtyPC, (SELECT CASE WHEN IB <> 0 THEN CAST(((SUM(ConvertedQty) - (CAST(SUM(ConvertedQty) AS int) % Piece)) / Piece) AS int) % IB ELSE 0 END) AS QtyIB,";
            sqlstatement += "(SELECT  CASE WHEN IB = 0 THEN ((Sum(ConvertedQty))-CAST(SUM(ConvertedQty)  AS int) % Piece) /Piece ";
            sqlstatement += "ELSE (((Sum(ConvertedQty)-CAST(SUM(ConvertedQty) AS int) % Piece)/Piece)-(CAST(((SUM(ConvertedQty) - (CAST(SUM(ConvertedQty) AS int) % Piece)) / Piece) AS int) % IB))/IB END) AS QtyCS ";
            sqlstatement += "FROM ViewPickListTerritory  WHERE WHCode = '" + cboWHCode.SelectedValue.ToString() + "' AND ControlNo ='" + cboListing.SelectedValue.ToString() + "'";
            sqlstatement += "GROUP By Piece, IB, Item, ClassDesc, StockNumber";

            SqlDataAdapter dscmd = new SqlDataAdapter(sqlstatement, myconnection);
            dscmd.SelectCommand.CommandTimeout = 600;
            DSPickList DSPickList1 = new DSPickList();
            dscmd.Fill(DSPickList1, "ViewPickList");
            myconnection.Close();

            CRPickListSalesman objRpt = new CRPickListSalesman();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            TextObject varrpttoSalesman = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoSalesman"];
            varrpttoSalesman.Text = cboListing.Text;

            TextObject varrpttoWarehouse = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoWarehouse"];
            varrpttoWarehouse.Text = cboWHCode.Text;

            objRpt.SetDataSource(DSPickList1.Tables[1]);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }
        private void picklistSalesman()
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();

            string sqlstatement = "";
            sqlstatement = "SELECT Piece, IB, Item, ClassDesc, StockNumber, Sum(SalesAmt) As SAmt,";
            sqlstatement += "CAST(SUM(ConvertedQty) AS int) % Piece AS QtyPC, (SELECT CASE WHEN IB <> 0 THEN CAST(((SUM(ConvertedQty) - (CAST(SUM(ConvertedQty) AS int) % Piece)) / Piece) AS int) % IB ELSE 0 END) AS QtyIB,";
            sqlstatement += "(SELECT  CASE WHEN IB = 0 THEN ((Sum(ConvertedQty))-CAST(SUM(ConvertedQty)  AS int) % Piece) /Piece ";
            sqlstatement += "ELSE (((Sum(ConvertedQty)-CAST(SUM(ConvertedQty) AS int) % Piece)/Piece)-(CAST(((SUM(ConvertedQty) - (CAST(SUM(ConvertedQty) AS int) % Piece)) / Piece) AS int) % IB))/IB END) AS QtyCS ";
            sqlstatement += "FROM ViewPickListTerritory  WHERE WHCode = '" + cboWHCode.SelectedValue.ToString() + "' AND PC ='" + cboListing.SelectedValue.ToString() + "'";
            sqlstatement += "GROUP By Piece, IB, Item, ClassDesc, StockNumber";

            string sqlstatementCustomer = "";
            sqlstatementCustomer = "SELECT CustName FROM ViewPickListTerritory WHERE WHCode = '" + cboWHCode.SelectedValue.ToString() + "' AND PC ='" + cboListing.SelectedValue.ToString() + "' GROUP BY CustName";

            //SqlDataAdapter dscmd = new SqlDataAdapter(sqlstatement, myconnection);
            //dscmd.SelectCommand.CommandTimeout = 600;
            //DSPickList DSPickList1 = new DSPickList();
            //dscmd.Fill(DSPickList1, "ViewPickList");
            //myconnection.Close();
            SqlDataAdapter SqlDA1 = new SqlDataAdapter(sqlstatement, myconnection);
            SqlDA1.SelectCommand.CommandTimeout = 600;
            DSPickList DSPickList1 = new DSPickList();
            SqlDA1.Fill(DSPickList1, "DSPickListTerritory1");

            SqlDataAdapter SqlDA2 = new SqlDataAdapter(sqlstatementCustomer, myconnection);
            SqlDA2.SelectCommand.CommandTimeout = 600;
            DSPickListCustName DSPickListCustName1 = new DSPickListCustName();
            SqlDA2.Fill(DSPickListCustName1, "DSPickListTerritory1");
            myconnection.Close();


            CRPickListSalesman objRpt = new CRPickListSalesman();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            TextObject varrpttoSalesman = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoSalesman"];
            varrpttoSalesman.Text = cboListing.Text;

            TextObject varrpttoWarehouse = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoWarehouse"];
            varrpttoWarehouse.Text = cboWHCode.Text;

            objRpt.SetDataSource(DSPickList1.Tables[1]);
            objRpt.Subreports[0].SetDataSource(DSPickListCustName1.Tables[1]);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }
        private void Listcustomer()
        {
            string sqlstatement = "";
            ClsGetConnection1.ClsGetConMSSQL(); myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            sqlstatement = "SELECT CustName ";
            sqlstatement += "FROM ViewPickListTerritory  WHERE WHCode = '" + cboWHCode.SelectedValue.ToString() + "' AND PC ='" + cboListing.SelectedValue.ToString() + "'";
            sqlstatement += "GROUP By CustName";

            SqlDataAdapter dscmd = new SqlDataAdapter(sqlstatement, myconnection);
            dscmd.SelectCommand.CommandTimeout = 600;
            DSPickList DSPickList1 = new DSPickList();
            dscmd.Fill(DSPickList1, "ViewPickList");
            myconnection.Close();

            CRPickListSalesmanCustomer objRpt = new CRPickListSalesmanCustomer();
            objRpt.SetDataSource(DSPickList1.Tables[1]);
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
        private void cbortprintchange()
        {
            if (cbortprint.Text == "Customer")
            {
                buildcboControlNo();
            }
            else if (cbortprint.Text == "Salesman")
            {
                buildcboSalesman();
            }
            else if (cbortprint.Text == "Salesman Customer")
            {
                buildcboSalesman();
            }
        }
        private void cbortprint_DropDownClosed(object sender, EventArgs e)
        {
            cbortprintchange();

        }
        private void cboWHCode_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (new ClsValidation().emptytxt(cboWHCode.Text))
                {
                }
                else if (cboWHCode.Text != null && cboWHCode.SelectedValue == null)
                {
                    MessageBox.Show("Not found");
                    cboWHCode.Focus();
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
        private void cboListing_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (new ClsValidation().emptytxt(cboListing.Text))
                {
                }
                else if (cboListing.Text != null && cboListing.SelectedValue == null)
                {
                    MessageBox.Show("Not found");
                    cboListing.Focus();
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
    }
}
