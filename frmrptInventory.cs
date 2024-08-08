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

    public partial class frmrptInventory : Form
    {
        SqlConnection myconnection;
        BindingSource dbind = new BindingSource();
        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();
        ClsCompName ClsCompName1 = new ClsCompName();
        ClsGetSomething ClsGetSomething1 = new ClsGetSomething();
        ClsBuildVoucherComboBox ClsBuildVoucherComboBox1 = new ClsBuildVoucherComboBox();
        ClsPermission ClsPermission1 = new ClsPermission();
        SqlCommand mycommand;
        SqlDataReader SqlDataReader1;
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();

        public frmrptInventory()
        {
            InitializeComponent();
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
                //cbortprint.Items.Add("Individual Warehouse");
                this.WindowState = FormWindowState.Maximized;
                ClsGetSomething1.ClsGetDefaultDate();
                txtBeginDate.Text = ClsGetSomething1.plsdefdate;
                txtEndDate.Text = ClsGetSomething1.plsdefdate;
                buildcboWHCode();
                buildcboStocks();
                cboSPO.Text = "01";
            }
        }

        private void buildcboPrincipal()
        {
            cboStockNumber.DataSource = null;
            ClsBuildComboBox1.ARCCN.Clear();
            ClsBuildComboBox1.ClsBuildClientControlno("S");
            this.cboStockNumber.DataSource = (ClsBuildComboBox1.ARCCN);
            this.cboStockNumber.DisplayMember = "Display";
            this.cboStockNumber.ValueMember = "Value";
        }

        private void buildcboWHCode()
        {
            cboWHCode.DataSource = null;
            ClsBuildVoucherComboBox1.ARLWHCode.Clear();
            ClsBuildVoucherComboBox1.ClsBuildWarehouse();
            this.cboWHCode.DataSource = (ClsBuildVoucherComboBox1.ARLWHCode);
            this.cboWHCode.DisplayMember = "Display";
            this.cboWHCode.ValueMember = "Value";
        }

        private void buildcboStocks()
        {
            cboStockNumber.DataSource = null;
            ClsBuildVoucherComboBox1.ARLSN.Clear();
            ClsBuildVoucherComboBox1.ClsBuildStocks(Convert.ToBoolean(cbSNEncode.CheckState), Convert.ToBoolean(cbPoulty.CheckState));
            this.cboStockNumber.DataSource = (ClsBuildVoucherComboBox1.ARLSN);
            this.cboStockNumber.DisplayMember = "Display";
            this.cboStockNumber.ValueMember = "Value";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (cbortprint.Text == "Individual Warehouse")
            {
                if ((new ClsValidation().emptytxt(cbortprint.Text)) || (new ClsValidation().emptytxt(cboWHCode.Text)) || (txtEndDate.Text == "  /  /"))
                {
                    MessageBox.Show("Please complete your entry", "GL");
                    cbortprint.Focus();
                }
                else
                {
                    InventorySumWarehouse();
                }
            }
            else if (cbortprint.Text == "All Warehouse")
            {
                if ((new ClsValidation().emptytxt(cbortprint.Text)) || (txtEndDate.Text == "  /  /"))
                {
                    MessageBox.Show("Please complete your entry", "GL");
                    cbortprint.Focus();
                }
                else
                {
                    InventorySumAllWarehouse();
                }
            }
            else if (cbortprint.Text == "Inventory per Principal")
            {
                if ((new ClsValidation().emptytxt(cbortprint.Text)) || (new ClsValidation().emptytxt(cboWHCode.Text)) || (txtEndDate.Text == "  /  /"))
                {
                    MessageBox.Show("Please complete your entry", "GL");
                    cbortprint.Focus();
                }
                else
                {
                    InventoryperPrincipal();
                }
            }

            else if (cbortprint.Text == "Descripancy - Poultry")
            {
                if ((new ClsValidation().emptytxt(cbortprint.Text)) || (new ClsValidation().emptytxt(cboWHCode.Text)) || (txtEndDate.Text == "  /  /"))
                {
                    MessageBox.Show("Please complete your entry", "GL");
                    cbortprint.Focus();
                }
                else
                {
                    Descripancy();
                }
            }

            else if (cbortprint.Text == "Descripancy - SMIS")
            {
                if ((new ClsValidation().emptytxt(cbortprint.Text)) || (new ClsValidation().emptytxt(cboWHCode.Text)) || (txtEndDate.Text == "  /  /"))
                {
                    MessageBox.Show("Please complete your entry", "GL");
                    cbortprint.Focus();
                }
                else
                {
                    DescripancySMIS();
                }
            }


            else if (cbortprint.Text == "Stock Card - Poultry")
            {
                if ((new ClsValidation().emptytxt(cbortprint.Text)) || (new ClsValidation().emptytxt(cboWHCode.Text)) || (txtEndDate.Text == "  /  /"))
                {
                    MessageBox.Show("Please complete your entry", "GL");
                    cbortprint.Focus();
                }
                else
                {
                    StockCardPoulty();
                }
            }
            else if (cbortprint.Text == "Stock Card - SMIS")
            {
                if ((new ClsValidation().emptytxt(cbortprint.Text)) || (new ClsValidation().emptytxt(cboWHCode.Text)) || (txtBeginDate.Text == "  /  /") || (txtEndDate.Text == "  /  /"))
                {
                    MessageBox.Show("Please complete your entry", "GL");
                    cbortprint.Focus();
                }
                else if (Convert.ToDateTime(txtBeginDate.Text) > Convert.ToDateTime(txtEndDate.Text))
                {
                    MessageBox.Show("Beginning date is greater than ending date");
                    txtBeginDate.Focus();
                }
                else
                {
                    StockCardSMIS();
                }
            }
        }

        private void cboWHCode_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().emptytxt(cboWHCode.Text))
            {
            }
            else if (cboWHCode.Text != null && cboWHCode.SelectedValue == null)
            {
                MessageBox.Show("Not found", "GL");
                cboWHCode.Focus();
            }

        }


        private void InventorySumWarehouse()
        {
            string sqlstatement;
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            sqlstatement = "SELECT Piece, IB, Item, ClassDesc, PClassDesc, StockNumber, Sum(Vol) As SVol, Sum(AmtIn)-Sum(AmtOut) As AveCost, ";
            sqlstatement += "CAST(SUM(ConvertedQty) AS int) % Piece AS QtyPC, (SELECT CASE WHEN IB <> 0 THEN CAST(((SUM(ConvertedQty) - (CAST(SUM(ConvertedQty) AS int) % Piece)) / Piece) AS int) % IB ELSE 0 END) AS QtyIB,";
            sqlstatement += "(SELECT  CASE WHEN IB = 0 THEN ((Sum(ConvertedQty))-CAST(SUM(ConvertedQty)  AS int) % Piece) /Piece ";
            sqlstatement += "ELSE (((Sum(ConvertedQty)-CAST(SUM(ConvertedQty) AS int) % Piece)/Piece)-(CAST(((SUM(ConvertedQty) - (CAST(SUM(ConvertedQty) AS int) % Piece)) / Piece) AS int) % IB))/IB END) AS QtyCS ";
            sqlstatement += "FROM ViewInvBalance  WHERE WHCode = '" + cboWHCode.SelectedValue.ToString() + "' AND TDate<='" + txtEndDate.Text + "'";
            sqlstatement += "GROUP By Piece, IB, Item, ClassDesc, PClassDesc, StockNumber ORDER BY Item ASC";

            //sqlstatement = "SELECT Piece, IB, Item, ClassDesc, PClassDesc, StockNumber, Sum(Vol) As SVol, Sum(AmtIn)-Sum(AmtOut) As AveCost, ";
            //sqlstatement += "CAST(SUM(ConvertedQty) AS int) % Piece AS QtyPC, (SELECT CASE WHEN IB <> 0 THEN CAST(((SUM(ConvertedQty) - (CAST(SUM(ConvertedQty) AS int) % Piece)) / Piece) AS int) % IB ELSE 0 END) AS QtyIB,";
            //sqlstatement += "(SELECT  CASE WHEN IB = 0 THEN ((Sum(ConvertedQty))-CAST(SUM(ConvertedQty)  AS int) % Piece) /Piece ";
            //sqlstatement += "ELSE (((Sum(ConvertedQty)-CAST(SUM(ConvertedQty) AS int) % Piece)/Piece)-(CAST(((SUM(ConvertedQty) - (CAST(SUM(ConvertedQty) AS int) % Piece)) / Piece) AS int) % IB))/IB END) AS QtyCS ";
            //sqlstatement += "FROM ViewInvBalance GROUP By Piece, IB, Item, ClassDesc, PClassDesc, StockNumber, TDate, WHCode ";
            //sqlstatement += "HAVING WHCode = '" + cboWHCode.SelectedValue.ToString() + "' AND TDate<='" + txtEndDate.Text + "' AND SUM(ConvertedQty)<>0";

            SqlDataAdapter dscmd = new SqlDataAdapter(sqlstatement, myconnection);
            dscmd.SelectCommand.CommandTimeout = 600;
            DSPickList DSPickList1 = new DSPickList();
            dscmd.Fill(DSPickList1, "ViewInventory");
            myconnection.Close();

            CRInvSumIndWarehouse objRpt = new CRInvSumIndWarehouse();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoenterdate"];
            varrpttoenterdate.Text = "As of " + txtEndDate.Text;

            TextObject varrpttoWarehouse = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoWarehouse"];
            varrpttoWarehouse.Text = cboWHCode.Text;

            objRpt.SetDataSource(DSPickList1.Tables[1]);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }

        private void InventorySumAllWarehouse()
        {
            string sqlstatement;
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            sqlstatement = "SELECT Piece, IB, Item, ClassDesc, PClassDesc, StockNumber, Sum(Vol) As SVol, Sum(AmtIn)-Sum(AmtOut) As AveCost, Warehouse, ";
            sqlstatement += "CAST(SUM(ConvertedQty) AS int) % Piece AS QtyPC, (SELECT CASE WHEN IB <> 0 THEN CAST(((SUM(ConvertedQty) - (CAST(SUM(ConvertedQty) AS int) % Piece)) / Piece) AS int) % IB ELSE 0 END) AS QtyIB,";
            sqlstatement += "(SELECT  CASE WHEN IB = 0 THEN ((Sum(ConvertedQty))-CAST(SUM(ConvertedQty)  AS int) % Piece) /Piece ";
            sqlstatement += "ELSE (((Sum(ConvertedQty)-CAST(SUM(ConvertedQty) AS int) % Piece)/Piece)-(CAST(((SUM(ConvertedQty) - (CAST(SUM(ConvertedQty) AS int) % Piece)) / Piece) AS int) % IB))/IB END) AS QtyCS ";
            sqlstatement += "FROM ViewInvBalance  WHERE TDate<='" + txtEndDate.Text + "'";
            sqlstatement += "GROUP By Piece, IB, Item, ClassDesc, PClassDesc, StockNumber, Warehouse ORDER BY Item ASC";

            //sqlstatement = "SELECT Piece, IB, Item, ClassDesc, PClassDesc, StockNumber, Sum(Vol) As SVol, Sum(AmtIn)-Sum(AmtOut) As AveCost, ";
            //sqlstatement += "CAST(SUM(ConvertedQty) AS int) % Piece AS QtyPC, (SELECT CASE WHEN IB <> 0 THEN CAST(((SUM(ConvertedQty) - (CAST(SUM(ConvertedQty) AS int) % Piece)) / Piece) AS int) % IB ELSE 0 END) AS QtyIB,";
            //sqlstatement += "(SELECT  CASE WHEN IB = 0 THEN ((Sum(ConvertedQty))-CAST(SUM(ConvertedQty)  AS int) % Piece) /Piece ";
            //sqlstatement += "ELSE (((Sum(ConvertedQty)-CAST(SUM(ConvertedQty) AS int) % Piece)/Piece)-(CAST(((SUM(ConvertedQty) - (CAST(SUM(ConvertedQty) AS int) % Piece)) / Piece) AS int) % IB))/IB END) AS QtyCS ";
            //sqlstatement += "FROM ViewInvBalance GROUP By Piece, IB, Item, ClassDesc, PClassDesc, StockNumber, TDate, WHCode ";
            //sqlstatement += "HAVING WHCode = '" + cboWHCode.SelectedValue.ToString() + "' AND TDate<='" + txtEndDate.Text + "' AND SUM(ConvertedQty)<>0";

            SqlDataAdapter dscmd = new SqlDataAdapter(sqlstatement, myconnection);
            dscmd.SelectCommand.CommandTimeout = 600;
            DSPickList DSPickList1 = new DSPickList();
            dscmd.Fill(DSPickList1, "ViewInventory");
            myconnection.Close();

            CRInvSumIndWarehouseAll objRpt = new CRInvSumIndWarehouseAll();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoenterdate"];
            varrpttoenterdate.Text = "As of " + txtEndDate.Text;

            objRpt.SetDataSource(DSPickList1.Tables[1]);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }

        private void InventoryperPrincipal()
        {
            string sqlstatement;
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();

            sqlstatement = "SELECT SFAProductCode, Barcode, Piece, IB, Item, ClassDesc, PClassDesc, StockNumber, Sum(Vol) As SVol, Sum(AmtIn)-Sum(AmtOut) As AveCost, ";
            sqlstatement += "CAST(SUM(ConvertedQty) AS int) % Piece AS QtyPC, (SELECT CASE WHEN IB <> 0 THEN CAST(((SUM(ConvertedQty) - (CAST(SUM(ConvertedQty) AS int) % Piece)) / Piece) AS int) % IB ELSE 0 END) AS QtyIB,";
            sqlstatement += "(SELECT  CASE WHEN IB = 0 THEN ((Sum(ConvertedQty))-CAST(SUM(ConvertedQty)  AS int) % Piece) /Piece ";
            sqlstatement += "ELSE (((Sum(ConvertedQty)-CAST(SUM(ConvertedQty) AS int) % Piece)/Piece)-(CAST(((SUM(ConvertedQty) - (CAST(SUM(ConvertedQty) AS int) % Piece)) / Piece) AS int) % IB))/IB END) AS QtyCS ";
            sqlstatement += "FROM ViewInvBalance WHERE WHCode = '" + cboWHCode.SelectedValue.ToString() + "' AND ClassCode = '" + cboStockNumber.SelectedValue.ToString() + "' AND TDate<='" + txtEndDate.Text + "' ";
            sqlstatement += "GROUP By SFAProductCode, Barcode, Piece, IB, Item, ClassDesc, PClassDesc, StockNumber ";
            sqlstatement += "ORDER BY Item ASC ";

            //sqlstatement = "SELECT Piece, IB, Item, ClassDesc, PClassDesc, StockNumber, Sum(Vol) As SVol, Sum(AmtIn)-Sum(AmtOut) As AveCost, ";
            //sqlstatement += "CAST(SUM(ConvertedQty) AS int) % Piece AS QtyPC, (SELECT CASE WHEN IB <> 0 THEN CAST(((SUM(ConvertedQty) - (CAST(SUM(ConvertedQty) AS int) % Piece)) / Piece) AS int) % IB ELSE 0 END) AS QtyIB,";
            //sqlstatement += "(SELECT  CASE WHEN IB = 0 THEN ((Sum(ConvertedQty))-CAST(SUM(ConvertedQty)  AS int) % Piece) /Piece ";
            //sqlstatement += "ELSE (((Sum(ConvertedQty)-CAST(SUM(ConvertedQty) AS int) % Piece)/Piece)-(CAST(((SUM(ConvertedQty) - (CAST(SUM(ConvertedQty) AS int) % Piece)) / Piece) AS int) % IB))/IB END) AS QtyCS ";
            //sqlstatement += "FROM ViewInvBalance GROUP By Piece, IB, Item, ClassDesc, PClassDesc, StockNumber, TDate, WHCode ";
            //sqlstatement += "HAVING WHCode = '" + cboWHCode.SelectedValue.ToString() + "' AND TDate<='" + txtEndDate.Text + "' AND SUM(ConvertedQty)<>0";

            SqlDataAdapter dscmd = new SqlDataAdapter(sqlstatement, myconnection);
            dscmd.SelectCommand.CommandTimeout = 600;
            DSPickList DSPickList1 = new DSPickList();
            dscmd.Fill(DSPickList1, "ViewInventory");
            myconnection.Close();

            CRInvSumIndPrincipal objRpt = new CRInvSumIndPrincipal();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoenterdate"];
            varrpttoenterdate.Text = "As of " + txtEndDate.Text;

            TextObject varrpttoWarehouse = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoWarehouse"];
            varrpttoWarehouse.Text = cboWHCode.Text;

            TextObject varrpttoPrincipal = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoPrincipal"];
            varrpttoPrincipal.Text = cboStockNumber.Text;

            objRpt.SetDataSource(DSPickList1.Tables[1]);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }

        private void Descripancy()
        {
            string sqlstatement;
            ClsGetConnection1.ClsGetConMSSQL(); myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            sqlstatement = "SELECT  StockNumber, Item, Sum(AmtIn)-Sum(AmtOut) As AveCost, ";
            sqlstatement += "Sum([In])-Sum(Out) As Kilo,";
            sqlstatement += "Sum(ChickIn)-Sum(ChickOut) As Qty ";
            sqlstatement += "FROM ViewInvBalance  WHERE WHCode = '" + cboWHCode.SelectedValue.ToString() + "' AND TDate<='" + txtEndDate.Text + "'";
            sqlstatement += "GROUP By StockNumber, Item HAVING (SUM([In]) - SUM(Out) <> 0)";

            SqlDataAdapter dscmd = new SqlDataAdapter(sqlstatement, myconnection);
            dscmd.SelectCommand.CommandTimeout = 600;
            DSPickList DSPickList1 = new DSPickList();
            dscmd.Fill(DSPickList1, "ViewInventory");
            myconnection.Close();

            CRInvSumDescripancy objRpt = new CRInvSumDescripancy();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoenterdate"];
            varrpttoenterdate.Text = "As of " + txtEndDate.Text;

            TextObject varrpttoWarehouse = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoWarehouse"];
            varrpttoWarehouse.Text = cboWHCode.Text;

            objRpt.SetDataSource(DSPickList1.Tables[1]);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }

        private void StockCardPoulty()
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();

            mycommand = new SqlCommand("usp_stockcardPoultry2", myconnection);
            mycommand.CommandType = CommandType.StoredProcedure;
            mycommand.Parameters.Add("@Parambegindate2", SqlDbType.DateTime).Value = txtBeginDate.Text;
            mycommand.Parameters.Add("@Paramenddate2", SqlDbType.DateTime).Value = txtEndDate.Text;
            mycommand.Parameters.Add("@ParamStockNumber2", SqlDbType.VarChar).Value = cboStockNumber.SelectedValue.ToString();
            mycommand.Parameters.Add("@ParamWHCode2", SqlDbType.VarChar).Value = cboWHCode.SelectedValue.ToString();

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

            CRInvSumStockCardPoultry objRpt = new CRInvSumStockCardPoultry();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            ClsCompName1.ClsCompNameMain();
            vartxtcompany.Text = ClsCompName1.varcn;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextRangeDate"];
            varrpttoenterdate.Text = txtBeginDate.Text + " to " + txtEndDate.Text;

            TextObject varTextStockNumber = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextStockNumber"];
            varTextStockNumber.Text = cboStockNumber.Text;

            TextObject varrpttoWarehouse = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoWarehouse"];
            varrpttoWarehouse.Text = cboWHCode.Text;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
            //string sqlstatement;
            //ClsGetConnection1.ClsGetConMSSQL(); myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            //myconnection.Open();
            //sqlstatement = "SELECT TDate, CSeries, Reference, CustName, UP, [In], Out, ChickIn, ChickOut, (AmtIn-AmtOut) As TCost ";
            //sqlstatement += "FROM ViewInvBalance  WHERE WHCode = '" + cboWHCode.SelectedValue.ToString() + "' AND TDate  BETWEEN  '" + txtBeginDate.Text + "' And '" + txtEndDate.Text + "' AND StockNumber = '" + cboStockNumber.SelectedValue.ToString() + "' ORDER BY TDate";

            //SqlDataAdapter dscmd = new SqlDataAdapter(sqlstatement, myconnection);
            //dscmd.SelectCommand.CommandTimeout = 600;
            //DSStockCard DSStockCard1 = new DSStockCard();
            //dscmd.Fill(DSStockCard1, "ViewInventory");
            //myconnection.Close();

            //CRInvSumStockCard objRpt = new CRInvSumStockCard();
            //TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            //vartxtcompany.Text = Form1.glblncompany.Text;

            //TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            //vartxtaddress.Text = Form1.glbladdress.Text;

            //TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoenterdate"];
            //varrpttoenterdate.Text = txtBeginDate.Text + " to " + txtEndDate.Text;

            //TextObject varrpttoWarehouse = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoWarehouse"];
            //varrpttoWarehouse.Text = cboWHCode.Text;

            //TextObject varrpttoStockNumber = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoStockNumber"];
            //varrpttoStockNumber.Text = cboStockNumber.Text;

            //objRpt.SetDataSource(DSStockCard1.Tables[1]);
            //crystalReportViewer1.ReportSource = objRpt;
            //crystalReportViewer1.Refresh();
        }

        private void StockCardSMIS()
        {
            ClsGetConnection1.ClsGetConMSSQL(); myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = new SqlCommand("usp_stockcard2", myconnection);
            mycommand.CommandType = CommandType.StoredProcedure;

            mycommand.Parameters.Add("@Parambegindate2", SqlDbType.DateTime).Value = txtBeginDate.Text;
            mycommand.Parameters.Add("@Paramenddate2", SqlDbType.DateTime).Value = txtEndDate.Text;
            mycommand.Parameters.Add("@ParamStockNumber2", SqlDbType.VarChar).Value = cboStockNumber.SelectedValue;
            mycommand.Parameters.Add("@ParamWHCode2", SqlDbType.VarChar).Value = cboWHCode.SelectedValue;

            SqlDataAdapter dscmd = new SqlDataAdapter();
            dscmd.SelectCommand = mycommand;
            mycommand.CommandTimeout = 600;
            DSStockCardSMIS DSStockCardSMIS1 = new DSStockCardSMIS();
            dscmd.Fill(DSStockCardSMIS1, "usp_stockcard2");
            myconnection.Close();

            CRInvSumStockCardSMIS objRpt = new CRInvSumStockCardSMIS();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            TextObject varTextWHCode = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextWHCode"];
            varTextWHCode.Text = cboWHCode.Text;

            TextObject varTextStockNumber = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextStockNumber"];
            varTextStockNumber.Text = cboStockNumber.Text;

            TextObject varTextrangedate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["Textrangedate"];
            varTextrangedate.Text = "From " + txtBeginDate.Text + " To " + txtEndDate.Text;

            objRpt.SetDataSource(DSStockCardSMIS1.Tables[1]);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }

        private void DescripancySMIS()
        {
            ClsGetConnection1.ClsGetConMSSQL(); myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = new SqlCommand("usp_AVRPost", myconnection);
            mycommand.CommandType = CommandType.StoredProcedure;

            mycommand.Parameters.Add("@Paramenddate2", SqlDbType.DateTime).Value = txtEndDate.Text;
            mycommand.Parameters.Add("@ParamSPO2", SqlDbType.VarChar).Value = cboSPO.Text;
            mycommand.Parameters.Add("@ParamWHCode2", SqlDbType.VarChar).Value = cboWHCode.SelectedValue;

            SqlDataAdapter dscmd = new SqlDataAdapter();
            dscmd.SelectCommand = mycommand;
            mycommand.CommandTimeout = 600;
            DSAVR DSAVR1 = new DSAVR();
            dscmd.Fill(DSAVR1, "usp_AVRPost");
            myconnection.Close();

            CRInvSumDescripancySMIS objRpt = new CRInvSumDescripancySMIS();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            TextObject varTextWHCode = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextWHCode"];
            varTextWHCode.Text = cboWHCode.Text;


            TextObject varTextrangedate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["Textrangedate"];
            varTextrangedate.Text = "From " + txtBeginDate.Text + " To " + txtEndDate.Text;

            objRpt.SetDataSource(DSAVR1.Tables[1]);
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

        private void txtEndDate_Leave(object sender, EventArgs e)
        {
            if (new ClsValidation().errordate(txtEndDate.Text) == true)
            {
                MessageBox.Show("Invalid Date", "GL");
                txtEndDate.Focus();
            }
        }

        private void cbortprint_Validating(object sender, CancelEventArgs e)
        {

            if (cbortprint.Text == "Individual Warehouse")
            {
                cboStockNumber.Enabled = false;
                txtBeginDate.Visible = false;
                lblBeginDate.Visible = false;
                lblEndDate.Text = "Date";
                cboSPO.Enabled = false;
            }

            else if (cbortprint.Text == "Inventory per Principal")
            {
                cboStockNumber.Enabled = true;
                txtBeginDate.Visible = false;
                lblBeginDate.Visible = false;
                lblEndDate.Text = "Date";
                cboSPO.Enabled = false;
                label2.Text = "Principal";
                buildcboPrincipal();
                cboSPO.Visible = false;
                label3.Visible = false;
            }

            else if (cbortprint.Text == "Descripancy - Poultry")
            {
                cboStockNumber.Enabled = false;
                txtBeginDate.Visible = true;
                lblBeginDate.Visible = true;
                lblEndDate.Text = "Ending Date";
                cboSPO.Enabled = false;
            }

            else if (cbortprint.Text == "Descripancy - SMIS")
            {
                cboStockNumber.Enabled = false;
                txtBeginDate.Visible = true;
                lblBeginDate.Visible = true;
                lblEndDate.Text = "Ending Date";
                cboSPO.Enabled = false;
            }

            else if (cbortprint.Text == "Stock Card - Poultry")
            {
                buildcboStocks();
                label2.Text = "Product";
                cboStockNumber.Enabled = true;
                txtBeginDate.Visible = true;
                lblBeginDate.Visible = true;
                lblEndDate.Text = "Ending Date";
                cboSPO.Enabled = false;
                //cboStockNumber.Enabled = true;
                //txtBeginDate.Visible = false;
                //lblBeginDate.Visible = false;
                //lblEndDate.Text = "Date";
                //cboSPO.Enabled = false;
            }
            else if (cbortprint.Text == "Stock Card - SMIS")
            {
                buildcboStocks();
                label2.Text = "Product";
                cboStockNumber.Enabled = true;
                txtBeginDate.Visible = true;
                lblBeginDate.Visible = true;
                lblEndDate.Text = "Ending Date";
                cboSPO.Enabled = false;
            }
            else if (cbortprint.Text == "All Warehouse")
            {
                cboStockNumber.Enabled = false;
                txtBeginDate.Visible = false;
                lblBeginDate.Visible = false;
                lblEndDate.Text = "Date";
                cboSPO.Enabled = false;
                cboWHCode.Enabled = false;
            }
        }

        private void cbSNEncode_CheckedChanged(object sender, EventArgs e)
        {
            buildcboStocks();
        }

        private void cbPoulty_CheckedChanged(object sender, EventArgs e)
        {
            buildcboStocks();
        }

        private void cboStockNumber_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().emptytxt(cboStockNumber.Text))
            {
            }
            else if (cboStockNumber.Text != null && cboStockNumber.SelectedValue == null)
            {
                MessageBox.Show("Not found", "GL");
                cboStockNumber.Focus();
            }
        }

        private void txtBeginDate_Leave(object sender, EventArgs e)
        {
            if (new ClsValidation().errordate(txtBeginDate.Text) == true)
            {
                MessageBox.Show("Invalid Date", "GL");
                txtBeginDate.Focus();
            }

        }
    }
}
