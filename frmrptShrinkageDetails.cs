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
using Excel = Microsoft.Office.Interop.Excel;

namespace K5GLONLINE
{
    public partial class frmrptShrinkageDetails : Form
    {
        SqlConnection myconnection;
        SqlDataReader SqlDataReader1;
        BindingSource bindingSource = null;

        SqlCommand mycommand;
        BindingSource dbind = new BindingSource();
        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();
        ClsBuildVoucherComboBox ClsBuildVoucherComboBox1 = new ClsBuildVoucherComboBox();
        ClsCompName ClsCompName1 = new ClsCompName();
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        ClsGetSomething ClsGetSomething1 = new ClsGetSomething();
        int intcountBeg = 0;
        int intcountPD = 0;
        int intcountSales = 0;
        int intcountTotal = 0;
        string strTotalWeight, strTotalQty, strStockNumber;
        SqlDataReader dr;
        double douSumWeight = 0;
        double douSumQty = 0;
        public frmrptShrinkageDetails()
        {
            InitializeComponent();
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
            if (new ClsValidation().emptytxt(cboPC.Text))
            {
                MessageBox.Show("Salesman is empty", "GL");
                cboPC.Focus();
            }
            else if (string.IsNullOrEmpty(cboWHCode.Text))
            {
                MessageBox.Show("Warehouse is empty", "GL");
                cboWHCode.Focus();
            }
            else if (txtBeginDate.Text == "  /  /")
            {
                MessageBox.Show("Please complete your entry", "GL");
                txtBeginDate.Focus();
            }
            else if (txtEndDate.Text == "  /  /")
            {
                MessageBox.Show("Please complete your entry", "GL");
                txtEndDate.Focus();
            }
            else if (Convert.ToDateTime(txtBeginDate.Text) > Convert.ToDateTime(txtEndDate.Text))
            {
                MessageBox.Show("Beginning date is greater than ending date");
                txtBeginDate.Focus();
            }
            else
            {
                DeleteAll();
                BegBal();
                Purchases();
                Sales();
                Total();
                TotalSales();
                TotalPercent();

                LoaddReport();
                //btnExcel.Enabled = true;
            }
        }

        private void frmrptShrinkageDetails_Load(object sender, EventArgs e)
        {
            ClsPermission1.ClsObjects(this.Text);
            if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
            {
                MessageBox.Show("You do not have necessary permission to open this file", "GL");
                this.Close();
            }
            else
            {
                buildcboSalesman();
                buildcboWHCode();
                cboPC.SelectedValue = "";
                cboWHCode.SelectedValue = "";
                ClsGetSomething1.ClsGetDefaultDate();
                txtBeginDate.Text = ClsGetSomething1.plsdefdate;
                txtEndDate.Text = ClsGetSomething1.plsdefdate;
                this.WindowState = FormWindowState.Maximized;
            }
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

        private void buildcboWHCode()
        {
            cboWHCode.DataSource = null;
            ClsBuildVoucherComboBox1.ARLWHCode.Clear();
            ClsBuildVoucherComboBox1.ClsBuildWarehouse();
            this.cboWHCode.DataSource = (ClsBuildVoucherComboBox1.ARLWHCode);
            this.cboWHCode.DisplayMember = "Display";
            this.cboWHCode.ValueMember = "Value";
        }

        private void nextfieldenter(object sender, KeyEventArgs e)
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

        public void DeleteAll()
        {
            string sqldel1 = "DELETE FROM tblShrinkageDetails";

            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = new SqlCommand(sqldel1, myconnection);
            mycommand.CommandTimeout = 600;
            int nmsg1 = mycommand.ExecuteNonQuery();
            myconnection.Close();
        }


        private void BegBal()
        {
            //try
            //{
                intcountBeg = 0;
            string sqlStatementBeg = "SELECT StockNumber, SUM(BalanceWeight) AS SUMBegBal, SUM(BalQty) AS SUMBalQty FROM ViewShrinkageDetailsBegBal ";
            sqlStatementBeg += "WHERE WHCode='" + cboWHCode.SelectedValue.ToString() + "' AND TDate<'" + txtBeginDate.Text + "' GROUP BY StockNumber HAVING SUM(BalanceWeight)<>0";
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            SqlCommand SqlCommand1 = myconnection.CreateCommand();
            SqlCommand1.CommandText = sqlStatementBeg;
            SqlDataReader SqlDataReader1;
            myconnection.Open();
            SqlDataReader1 = SqlCommand1.ExecuteReader();
            DataTable DataTable1 = new DataTable();
            DataTable1.Load(SqlDataReader1);
            int CountData = DataTable1.Rows.Count; //int proces = dgvPurgeTransact.Rows.Count;
            if (CountData > 0)
            {
                string sqlstatementinsert = "INSERT INTO tblShrinkageDetails (PKRowNum, SortHeading, Reference, Weight, QtyPiece, StockNumber)";
                sqlstatementinsert += " Values (@_PKRowNum, @_SortHeading, @_Reference, @_Weight, @_QtyPiece, @_StockNumber)";

                foreach (DataRow row in DataTable1.Rows)
                {
                    intcountBeg = intcountBeg + 1;
                    mycommand = new SqlCommand(sqlstatementinsert, myconnection);
                    mycommand.Parameters.Add("_PKRowNum", SqlDbType.Int).Value = intcountBeg;
                    mycommand.Parameters.Add("_SortHeading", SqlDbType.Int).Value = 1;
                    //mycommand.Parameters.Add("_ControlNo", SqlDbType.VarChar).Value = "";
                    mycommand.Parameters.Add("_Reference", SqlDbType.VarChar).Value = "Beg. Bal";
                    mycommand.Parameters.Add("_Weight", SqlDbType.Money).Value = row["SUMBegBal"].ToString();
                    mycommand.Parameters.Add("_QtyPiece", SqlDbType.Money).Value = row["SUMBalQty"].ToString();
                    mycommand.Parameters.Add("_StockNumber", SqlDbType.VarChar).Value = row["StockNumber"].ToString();
                    mycommand.CommandTimeout = 600;
                    int n1 = mycommand.ExecuteNonQuery();
                }
                myconnection.Close();
            }
            //}
            //catch
            //{
            //    MessageBox.Show("Something went wrong. Possible error in connection", "Payroll");
            //}
        }

        private void Purchases()
        {
            //try
            //{
                intcountPD = 0;
            string sqlStatementPD = "SELECT StockNumber, SUM([In]) AS SUMIn, SUM(ChickIn) AS SUMChickIn FROM ViewShrinkageDetailsPD ";
            sqlStatementPD += "WHERE WHCode='" + cboWHCode.SelectedValue.ToString() + "' ";
            sqlStatementPD += "AND TDate Between'" + txtBeginDate.Text + "' AND '" + txtEndDate.Text + "' GROUP BY StockNumber";
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            SqlCommand SqlCommand1 = myconnection.CreateCommand();
            SqlCommand1.CommandText = sqlStatementPD;
            SqlDataReader SqlDataReader1;
            myconnection.Open();
            SqlDataReader1 = SqlCommand1.ExecuteReader();
            DataTable DataTable1 = new DataTable();
            DataTable1.Load(SqlDataReader1);
            int CountData = DataTable1.Rows.Count; //int proces = dgvPurgeTransact.Rows.Count;
            if (CountData > 0)
            {
                string sqlstatementinsert = "INSERT INTO tblShrinkageDetails (PKRowNum, SortHeading, Reference, Weight, QtyPiece, StockNumber)";
                sqlstatementinsert += " Values (@_PKRowNum, @_SortHeading, @_Reference, @_Weight, @_QtyPiece, @_StockNumber)";

                foreach (DataRow row in DataTable1.Rows)
                {
                    intcountPD = intcountPD + 1;
                    mycommand = new SqlCommand(sqlstatementinsert, myconnection);
                    mycommand.Parameters.Add("_PKRowNum", SqlDbType.Int).Value = intcountPD;
                    mycommand.Parameters.Add("_SortHeading", SqlDbType.Int).Value = 2;
                    //mycommand.Parameters.Add("_ControlNo", SqlDbType.VarChar).Value = "";
                    mycommand.Parameters.Add("_Reference", SqlDbType.VarChar).Value = "Purchases/Transfer";
                    mycommand.Parameters.Add("_Weight", SqlDbType.Money).Value = row["SUMIn"].ToString();
                    mycommand.Parameters.Add("_QtyPiece", SqlDbType.Money).Value = row["SUMChickIn"].ToString();
                    mycommand.Parameters.Add("_StockNumber", SqlDbType.VarChar).Value = row["StockNumber"].ToString();
                    mycommand.CommandTimeout = 600;
                    int n1 = mycommand.ExecuteNonQuery();
                }
                myconnection.Close();
            }
            //}
            //catch
            //{
            //    MessageBox.Show("Something went wrong. Possible error in connection", "Payroll");
            //}
        }

        private void Sales()
        {
            //try
            //{
                intcountSales = 0;
            string sqlStatementPD = "SELECT StockNumber, ControlNo, Reference, SWeight AS Out, SQty AS ChickOut FROM ViewShrinkageDetailsSales ";
            sqlStatementPD += "WHERE WHCode='" + cboWHCode.SelectedValue.ToString() + "' AND PC='" + cboPC.SelectedValue.ToString() + "' ";
            sqlStatementPD += "AND TDate Between'" + txtBeginDate.Text + "' AND '" + txtEndDate.Text + "'";
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            SqlCommand SqlCommand1 = myconnection.CreateCommand();
            SqlCommand1.CommandText = sqlStatementPD;
            SqlDataReader SqlDataReader1;
            myconnection.Open();
            SqlDataReader1 = SqlCommand1.ExecuteReader();
            DataTable DataTable1 = new DataTable();
            DataTable1.Load(SqlDataReader1);
            int CountData = DataTable1.Rows.Count; //int proces = dgvPurgeTransact.Rows.Count;
            if (CountData > 0)
            {
                string sqlstatementinsert = "INSERT INTO tblShrinkageDetails (PKRowNum, SortHeading, ControlNo, Reference, Weight, QtyPiece, StockNumber)";
                sqlstatementinsert += " Values (@_PKRowNum, @_SortHeading, @_ControlNo, @_Reference, @_Weight, @_QtyPiece, @_StockNumber)";

                foreach (DataRow row in DataTable1.Rows)
                {
                    intcountSales = intcountSales + 1;
                    mycommand = new SqlCommand(sqlstatementinsert, myconnection);
                    mycommand.Parameters.Add("_PKRowNum", SqlDbType.Int).Value = intcountSales;
                    mycommand.Parameters.Add("_SortHeading", SqlDbType.Int).Value = 3;
                    mycommand.Parameters.Add("_ControlNo", SqlDbType.VarChar).Value = row["ControlNo"].ToString();
                    mycommand.Parameters.Add("_Reference", SqlDbType.VarChar).Value = row["Reference"].ToString();
                    mycommand.Parameters.Add("_Weight", SqlDbType.Money).Value = row["Out"].ToString();
                    mycommand.Parameters.Add("_QtyPiece", SqlDbType.Money).Value = row["ChickOut"].ToString();
                    mycommand.Parameters.Add("_StockNumber", SqlDbType.VarChar).Value = row["StockNumber"].ToString();
                    mycommand.CommandTimeout = 600;
                    int n1 = mycommand.ExecuteNonQuery();
                }
                myconnection.Close();
            }
            //}
            //catch
            //{
            //    MessageBox.Show("Something went wrong. Possible error in connection", "Payroll");
            //}
        }

        private void TotalSales()
        {
            //try
            //{
                intcountTotal = 0;
                string sql = "SELECT SUM(ACUWeight) AS ACUWeight, SUM(ACUQty) AS ACUQty, SUM(BBRWeight) AS BBRWeight, SUM(BBRQty) AS BBRQty, SUM(BDRWeight) AS BDRWeight, ";
                sql += "SUM(BDRQty) AS BDRQty,  SUM(BLOODMWeight) AS BLOODMWeight, SUM(BLOODMQty) AS BLOODMQty, SUM(BTHWeight) AS BTHWeight, SUM(BTHQty) AS BTHQty, SUM(BWBWeight) AS BWBWeight, ";
                sql += "SUM(BWBQty) AS BWBQty, SUM(BWGWeight) AS BWGWeight, SUM(BWGQty) AS BWGQty, SUM(BWTWeight) AS BWTWeight, SUM(BWTQty) AS BWTQty, SUM(CROPMWeight) AS CROPMWeight, ";
                sql += "SUM(CROPMQty) AS CROPMQty, SUM(CROPSWeight) AS CROPSWeight, SUM(CROPSQty) AS CROPSQty, SUM(DBLWeight) AS DBLWeight, SUM(DBLQty) AS DBLQty, SUM(FATSMWeight) AS FATSMWeight, ";
                sql += "SUM(FATSMQty) AS FATSMQty, SUM(FBBK5Weight) AS FBBK5Weight, SUM(FBBK5Qty) AS FBBK5Qty, SUM(FBLVWeight) AS FBLVWeight, SUM(FBLVQty) AS FBLVQty, SUM(FBNK5Weight) AS FBNK5Weight, ";
                sql += "SUM(FBNK5Qty) AS FBNK5Qty, SUM(FC1Weight) AS FC1Weight, SUM(FC1Qty) AS FC1Qty, SUM(FC2Weight) AS FC2Weight, SUM(FC2Qty) AS FC2Qty, SUM(FeetMWeight) AS FeetMWeight, ";
                sql += "SUM(FeetMQty) AS FeetMQty, SUM(FeetSWeight) AS FeetSWeight, SUM(FeetSQty) AS FeetSQty, SUM(FMBBWeight) AS FMBBWeight, SUM(FMBBQty) AS FMBBQty, SUM(FMWCWeight) AS FMWCWeight, ";
                sql += "SUM(FMWCQty) AS FMWCQty, SUM(FRCVWeight) AS FRCVWeight, SUM(FRCVQty) AS FRCVQty, SUM(FSQWeight) AS FSQWeight, SUM(FSQQty) AS FSQQty, SUM(FYRWeight) AS FYRWeight, ";
                sql += "SUM(FYRQty) AS FYRQty, SUM(HeadMWeight) AS HeadMWeight, SUM(HeadMQty) AS HeadMQty, SUM(HeadSWeight) AS HeadSWeight, SUM(HeadSQty) AS HeadSQty, SUM(LINTMWeight) AS LINTMWeight, ";
                sql += "SUM(LINTMQty) AS LINTMQty, SUM(LINTSWeight) AS LINTSWeight, SUM(LINTSQty) AS LINTSQty, SUM(LUNGSMWeight) AS LUNGSMWeight, SUM(LUNGSMQty) AS LUNGSMQty, ";
                sql += "SUM(MCUWeight) AS MCUWeight, SUM(MCUQty) AS MCUQty, SUM(MFCWeight) AS MFCWeight, SUM(MFCQty) AS MFCQty, SUM(MFCAWeight) AS MFCAWeight, SUM(MFCAQty) AS MFCAQty, ";
                sql += "SUM(MSCWeight) AS MSCWeight, SUM(MSCQty) AS MSCQty, SUM(PROVMWeight) AS PROVMWeight, SUM(PROVMQty) AS PROVMQty, SUM(PROVSWeight) AS PROVSWeight, SUM(PROVSQty) AS PROVSQty, ";
                sql += "SUM(SINTMWeight) AS SINTMWeight, SUM(SINTMQty) AS SINTMQty, SUM(SINTSWeight) AS SINTSWeight, SUM(SINTSQty) AS SINTSQty, SUM(SpleenSWeight) AS SpleenSWeight, SUM(SpleenSQty) AS SpleenSQty, ";
                sql += "SUM(UBKWeight) AS UBKWeight, SUM(UBKQty) AS UBKQty, SUM(UBRWeight) AS UBRWeight, SUM(UBRQty) AS UBRQty, SUM(UDRWeight) AS UDRWeight, SUM(UDRQty) AS UDRQty, ";
                sql += "SUM(UGZWeight) AS UGZWeight, SUM(UGZQty) AS UGZQty, SUM(UNKWeight) AS UNKWeight, SUM(UNKQty) AS UNKQty, SUM(UTHWeight) AS UTHWeight, SUM(UTHQty) AS UTHQty, ";
                sql += "SUM(UWGWeight) AS UWGWeight, SUM(UWGQty) AS UWGQty FROM ViewShrinkageDetailsTotalSales";
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                SqlCommand SqlCommand1 = myconnection.CreateCommand();
                SqlCommand1.CommandText = sql;
                SqlDataReader SqlDataReader1;
                myconnection.Open();
                SqlDataReader1 = SqlCommand1.ExecuteReader();
                DataTable DataTable1 = new DataTable();
                DataTable1.Load(SqlDataReader1);
                int CountData = DataTable1.Rows.Count; //int proces = dgvPurgeTransact.Rows.Count;
                if (CountData > 0)
                {
                    string sqlstatementinsert = "INSERT INTO tblShrinkageDetails (PKRowNum, SortHeading, Reference, Weight, QtyPiece, StockNumber)";
                    sqlstatementinsert += " Values (@_PKRowNum, @_SortHeading, @_Reference, @_Weight, @_QtyPiece, @_StockNumber)";

                    foreach (DataRow row in DataTable1.Rows)
                    {

                        for (int x = 0; x < 46; x++)
                        {

                            intcountTotal = intcountTotal + 1;
                            if (intcountTotal == 1)
                            {
                                strTotalWeight = row["ACUWeight"].ToString();
                                strTotalQty = row["ACUQty"].ToString();
                                strStockNumber = "ACU";
                            }
                            else if (intcountTotal == 2)
                            {
                                strTotalWeight = row["BBRWeight"].ToString();
                                strTotalQty = row["BBRQty"].ToString();
                                strStockNumber = "BBR";
                            }
                            else if (intcountTotal == 3)
                            {
                                strTotalWeight = row["BDRWeight"].ToString();
                                strTotalQty = row["BDRQty"].ToString();
                                strStockNumber = "BDR";
                            }
                            else if (intcountTotal == 4)
                            {
                                strTotalWeight = row["BLOODMWeight"].ToString();
                                strTotalQty = row["BLOODMQty"].ToString();
                                strStockNumber = "BLOOD-M";
                            }
                            else if (intcountTotal == 5)
                            {
                                strTotalWeight = row["BTHWeight"].ToString();
                                strTotalQty = row["BTHQty"].ToString();
                                strStockNumber = "BTH";
                            }
                            else if (intcountTotal == 6)
                            {
                                strTotalWeight = row["BWBWeight"].ToString();
                                strTotalQty = row["BWBQty"].ToString();
                                strStockNumber = "BWB";
                            }
                            else if (intcountTotal == 7)
                            {
                                strTotalWeight = row["BWGWeight"].ToString();
                                strTotalQty = row["BWGQty"].ToString();
                                strStockNumber = "BWG";
                            }
                            else if (intcountTotal == 8)
                            {
                                strTotalWeight = row["BWTWeight"].ToString();
                                strTotalQty = row["BWTQty"].ToString();
                                strStockNumber = "BWT";
                            }
                            else if (intcountTotal == 9)
                            {
                                strTotalWeight = row["CROPMWeight"].ToString();
                                strTotalQty = row["CROPMQty"].ToString();
                                strStockNumber = "CROP-M";
                            }
                            else if (intcountTotal == 10)
                            {
                                strTotalWeight = row["CROPSWeight"].ToString();
                                strTotalQty = row["CROPSQty"].ToString();
                                strStockNumber = "CROP-S";

                            }
                            else if (intcountTotal == 11)
                            {
                                strTotalWeight = row["DBLWeight"].ToString();
                                strTotalQty = row["DBLQty"].ToString();
                                strStockNumber = "DBL";
                            }
                            else if (intcountTotal == 12)
                            {
                                strTotalWeight = row["DBLWeight"].ToString();
                                strTotalQty = row["DBLQty"].ToString();
                                strStockNumber = "DBL";
                            }
                            else if (intcountTotal == 13)
                            {
                                strTotalWeight = row["FATSMWeight"].ToString();
                                strTotalQty = row["FATSMQty"].ToString();
                                strStockNumber = "FATS-M";
                            }
                            else if (intcountTotal == 14)
                            {
                                strTotalWeight = row["FBBK5Weight"].ToString();
                                strTotalQty = row["FBBK5Qty"].ToString();
                                strStockNumber = "FBBK5";
                            }
                            else if (intcountTotal == 15)
                            {
                                strTotalWeight = row["FBLVWeight"].ToString();
                                strTotalQty = row["FBLVQty"].ToString();
                                strStockNumber = "FBLV";
                            }
                            else if (intcountTotal == 16)
                            {
                                strTotalWeight = row["FBNK5Weight"].ToString();
                                strTotalQty = row["FBNK5Qty"].ToString();
                                strStockNumber = "FBNK5";
                            }
                            else if (intcountTotal == 17)
                            {
                                strTotalWeight = row["FC1Weight"].ToString();
                                strTotalQty = row["FC1Qty"].ToString();
                                strStockNumber = "FC1";
                            }
                            else if (intcountTotal == 18)
                            {
                                strTotalWeight = row["FC2Weight"].ToString();
                                strTotalQty = row["FC2Qty"].ToString();
                                strStockNumber = "FC2";
                            }
                            else if (intcountTotal == 19)
                            {
                                strTotalWeight = row["FeetMWeight"].ToString();
                                strTotalQty = row["FeetMQty"].ToString();
                                strStockNumber = "Feet-M";
                            }
                            else if (intcountTotal == 20)
                            {
                                strTotalWeight = row["FeetSWeight"].ToString();
                                strTotalQty = row["FeetSQty"].ToString();
                                strStockNumber = "Feet-S";
                            }
                            else if (intcountTotal == 21)
                            {
                                strTotalWeight = row["FMBBWeight"].ToString();
                                strTotalQty = row["FMBBQty"].ToString();
                                strStockNumber = "FMBB";
                            }
                            else if (intcountTotal == 22)
                            {
                                strTotalWeight = row["FMWCWeight"].ToString();
                                strTotalQty = row["FMWCQty"].ToString();
                                strStockNumber = "FMWC";
                            }
                            else if (intcountTotal == 23)
                            {
                                strTotalWeight = row["FRCVWeight"].ToString();
                                strTotalQty = row["FRCVQty"].ToString();
                                strStockNumber = "FRCV";
                            }
                            else if (intcountTotal == 24)
                            {
                                strTotalWeight = row["FSQWeight"].ToString();
                                strTotalQty = row["FSQQty"].ToString();
                                strStockNumber = "FSQ";
                            }
                            else if (intcountTotal == 25)
                            {
                                strTotalWeight = row["FYRWeight"].ToString();
                                strTotalQty = row["FYRQty"].ToString();
                                strStockNumber = "FYR";
                            }
                            else if (intcountTotal == 26)
                            {
                                strTotalWeight = row["HeadMWeight"].ToString();
                                strTotalQty = row["HeadMQty"].ToString();
                                strStockNumber = "Head-M";
                            }
                            else if (intcountTotal == 27)
                            {
                                strTotalWeight = row["HeadSWeight"].ToString();
                                strTotalQty = row["HeadSQty"].ToString();
                                strStockNumber = "Head-S";
                            }
                            else if (intcountTotal == 28)
                            {
                                strTotalWeight = row["LINTMWeight"].ToString();
                                strTotalQty = row["LINTMQty"].ToString();
                                strStockNumber = "LINT-M";
                            }
                            else if (intcountTotal == 29)
                            {
                                strTotalWeight = row["LINTSWeight"].ToString();
                                strTotalQty = row["LINTSQty"].ToString();
                                strStockNumber = "LINT-S";
                            }
                            else if (intcountTotal == 30)
                            {
                                strTotalWeight = row["LUNGSMWeight"].ToString();
                                strTotalQty = row["LUNGSMQty"].ToString();
                                strStockNumber = "LUNGS-M";
                            }
                            else if (intcountTotal == 31)
                            {
                                strTotalWeight = row["MCUWeight"].ToString();
                                strTotalQty = row["MCUQty"].ToString();
                                strStockNumber = "MCU";
                            }
                            else if (intcountTotal == 32)
                            {
                                strTotalWeight = row["MFCWeight"].ToString();
                                strTotalQty = row["MFCQty"].ToString();
                                strStockNumber = "MFC";
                            }
                            else if (intcountTotal == 33)
                            {
                                strTotalWeight = row["MFCAWeight"].ToString();
                                strTotalQty = row["MFCAQty"].ToString();
                                strStockNumber = "MFCA";
                            }
                            else if (intcountTotal == 34)
                            {
                                strTotalWeight = row["MSCWeight"].ToString();
                                strTotalQty = row["MSCQty"].ToString();
                                strStockNumber = "MSC";
                            }
                            else if (intcountTotal == 35)
                            {
                                strTotalWeight = row["PROVMWeight"].ToString();
                                strTotalQty = row["PROVMQty"].ToString();
                                strStockNumber = "PROV-M";
                            }
                            else if (intcountTotal == 36)
                            {
                                strTotalWeight = row["PROVSWeight"].ToString();
                                strTotalQty = row["PROVSQty"].ToString();
                                strStockNumber = "PROV-S";
                            }
                            else if (intcountTotal == 37)
                            {
                                strTotalWeight = row["SINTMWeight"].ToString();
                                strTotalQty = row["SINTMQty"].ToString();
                                strStockNumber = "SINT-M";
                            }
                            else if (intcountTotal == 38)
                            {
                                strTotalWeight = row["SINTSWeight"].ToString();
                                strTotalQty = row["SINTSQty"].ToString();
                                strStockNumber = "SINT-S";
                            }
                            else if (intcountTotal == 39)
                            {
                                strTotalWeight = row["SpleenSWeight"].ToString();
                                strTotalQty = row["SpleenSQty"].ToString();
                                strStockNumber = "Spleen-S";
                            }
                            else if (intcountTotal == 40)
                            {
                                strTotalWeight = row["UBKWeight"].ToString();
                                strTotalQty = row["UBKQty"].ToString();
                                strStockNumber = "UBK";
                            }
                            else if (intcountTotal == 41)
                            {
                                strTotalWeight = row["UBRWeight"].ToString();
                                strTotalQty = row["UBRQty"].ToString();
                                strStockNumber = "UBR";
                            }
                            else if (intcountTotal == 42)
                            {
                                strTotalWeight = row["UDRWeight"].ToString();
                                strTotalQty = row["UDRQty"].ToString();
                                strStockNumber = "UDR";
                            }
                            else if (intcountTotal == 43)
                            {
                                strTotalWeight = row["UGZWeight"].ToString();
                                strTotalQty = row["UGZQty"].ToString();
                                strStockNumber = "UGZ";
                            }
                            else if (intcountTotal == 44)
                            {
                                strTotalWeight = row["UNKWeight"].ToString();
                                strTotalQty = row["UNKQty"].ToString();
                                strStockNumber = "UNK";
                            }
                            else if (intcountTotal == 45)
                            {
                                strTotalWeight = row["UTHWeight"].ToString();
                                strTotalQty = row["UTHQty"].ToString();
                                strStockNumber = "UTH";
                            }
                            else if (intcountTotal == 46)
                            {
                                strTotalWeight = row["UWGWeight"].ToString();
                                strTotalQty = row["UWGQty"].ToString();
                                strStockNumber = "UWG";
                            }

                            mycommand = new SqlCommand(sqlstatementinsert, myconnection);
                            mycommand.Parameters.Add("_PKRowNum", SqlDbType.Int).Value = intcountTotal;
                            mycommand.Parameters.Add("_SortHeading", SqlDbType.Int).Value = 4;
                            //mycommand.Parameters.Add("_ControlNo", SqlDbType.VarChar).Value = "";
                            mycommand.Parameters.Add("_Reference", SqlDbType.VarChar).Value = "Total Sales";
                            mycommand.Parameters.Add("_Weight", SqlDbType.Money).Value = strTotalWeight;
                            mycommand.Parameters.Add("_QtyPiece", SqlDbType.Money).Value = strTotalQty;
                            mycommand.Parameters.Add("_StockNumber", SqlDbType.VarChar).Value = strStockNumber;
                            mycommand.CommandTimeout = 600;
                            int n1 = mycommand.ExecuteNonQuery();
                        }
                    }
                    myconnection.Close();
                }
            //}
            //catch
            //{
            //    MessageBox.Show("Something went wrong. Possible error in connection", "Payroll");
            //}
        }

        private void Total()
        {
            //try
            //{
            intcountTotal = 0;
            string sql = "SELECT SUM(ACUWeight) AS ACUWeight, SUM(ACUQty) AS ACUQty, SUM(BBRWeight) AS BBRWeight, SUM(BBRQty) AS BBRQty, SUM(BDRWeight) AS BDRWeight, ";
            sql += "SUM(BDRQty) AS BDRQty,  SUM(BLOODMWeight) AS BLOODMWeight, SUM(BLOODMQty) AS BLOODMQty, SUM(BTHWeight) AS BTHWeight, SUM(BTHQty) AS BTHQty, SUM(BWBWeight) AS BWBWeight, ";
            sql += "SUM(BWBQty) AS BWBQty, SUM(BWGWeight) AS BWGWeight, SUM(BWGQty) AS BWGQty, SUM(BWTWeight) AS BWTWeight, SUM(BWTQty) AS BWTQty, SUM(CROPMWeight) AS CROPMWeight, ";
            sql += "SUM(CROPMQty) AS CROPMQty, SUM(CROPSWeight) AS CROPSWeight, SUM(CROPSQty) AS CROPSQty, SUM(DBLWeight) AS DBLWeight, SUM(DBLQty) AS DBLQty, SUM(FATSMWeight) AS FATSMWeight, ";
            sql += "SUM(FATSMQty) AS FATSMQty, SUM(FBBK5Weight) AS FBBK5Weight, SUM(FBBK5Qty) AS FBBK5Qty, SUM(FBLVWeight) AS FBLVWeight, SUM(FBLVQty) AS FBLVQty, SUM(FBNK5Weight) AS FBNK5Weight, ";
            sql += "SUM(FBNK5Qty) AS FBNK5Qty, SUM(FC1Weight) AS FC1Weight, SUM(FC1Qty) AS FC1Qty, SUM(FC2Weight) AS FC2Weight, SUM(FC2Qty) AS FC2Qty, SUM(FeetMWeight) AS FeetMWeight, ";
            sql += "SUM(FeetMQty) AS FeetMQty, SUM(FeetSWeight) AS FeetSWeight, SUM(FeetSQty) AS FeetSQty, SUM(FMBBWeight) AS FMBBWeight, SUM(FMBBQty) AS FMBBQty, SUM(FMWCWeight) AS FMWCWeight, ";
            sql += "SUM(FMWCQty) AS FMWCQty, SUM(FRCVWeight) AS FRCVWeight, SUM(FRCVQty) AS FRCVQty, SUM(FSQWeight) AS FSQWeight, SUM(FSQQty) AS FSQQty, SUM(FYRWeight) AS FYRWeight, ";
            sql += "SUM(FYRQty) AS FYRQty, SUM(HeadMWeight) AS HeadMWeight, SUM(HeadMQty) AS HeadMQty, SUM(HeadSWeight) AS HeadSWeight, SUM(HeadSQty) AS HeadSQty, SUM(LINTMWeight) AS LINTMWeight, ";
            sql += "SUM(LINTMQty) AS LINTMQty, SUM(LINTSWeight) AS LINTSWeight, SUM(LINTSQty) AS LINTSQty, SUM(LUNGSMWeight) AS LUNGSMWeight, SUM(LUNGSMQty) AS LUNGSMQty, ";
            sql += "SUM(MCUWeight) AS MCUWeight, SUM(MCUQty) AS MCUQty, SUM(MFCWeight) AS MFCWeight, SUM(MFCQty) AS MFCQty, SUM(MFCAWeight) AS MFCAWeight, SUM(MFCAQty) AS MFCAQty, ";
            sql += "SUM(MSCWeight) AS MSCWeight, SUM(MSCQty) AS MSCQty, SUM(PROVMWeight) AS PROVMWeight, SUM(PROVMQty) AS PROVMQty, SUM(PROVSWeight) AS PROVSWeight, SUM(PROVSQty) AS PROVSQty, ";
            sql += "SUM(SINTMWeight) AS SINTMWeight, SUM(SINTMQty) AS SINTMQty, SUM(SINTSWeight) AS SINTSWeight, SUM(SINTSQty) AS SINTSQty, SUM(SpleenSWeight) AS SpleenSWeight, SUM(SpleenSQty) AS SpleenSQty, ";
            sql += "SUM(UBKWeight) AS UBKWeight, SUM(UBKQty) AS UBKQty, SUM(UBRWeight) AS UBRWeight, SUM(UBRQty) AS UBRQty, SUM(UDRWeight) AS UDRWeight, SUM(UDRQty) AS UDRQty, ";
            sql += "SUM(UGZWeight) AS UGZWeight, SUM(UGZQty) AS UGZQty, SUM(UNKWeight) AS UNKWeight, SUM(UNKQty) AS UNKQty, SUM(UTHWeight) AS UTHWeight, SUM(UTHQty) AS UTHQty, ";
            sql += "SUM(UWGWeight) AS UWGWeight, SUM(UWGQty) AS UWGQty FROM ViewShrinkageDetailsReport3";

            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            SqlCommand SqlCommand1 = myconnection.CreateCommand();
            SqlCommand1.CommandText = sql;
            SqlDataReader SqlDataReader1;
            myconnection.Open();
            SqlDataReader1 = SqlCommand1.ExecuteReader();
            DataTable DataTable1 = new DataTable();
            DataTable1.Load(SqlDataReader1);
            int CountData = DataTable1.Rows.Count; //int proces = dgvPurgeTransact.Rows.Count;
            if (CountData > 0)
            {
                string sqlstatementinsert = "INSERT INTO tblShrinkageDetails (PKRowNum, SortHeading, Reference, Weight, QtyPiece, StockNumber)";
                sqlstatementinsert += " Values (@_PKRowNum, @_SortHeading, @_Reference, @_Weight, @_QtyPiece, @_StockNumber)";

                foreach (DataRow row in DataTable1.Rows)
                {

                    for (int x = 0; x < 46; x++)
                    {

                        intcountTotal = intcountTotal + 1;
                        if (intcountTotal == 1)
                        {
                            strTotalWeight = row["ACUWeight"].ToString();
                            strTotalQty = row["ACUQty"].ToString();
                            strStockNumber = "ACU";
                        }
                        else if (intcountTotal == 2)
                        {
                            strTotalWeight = row["BBRWeight"].ToString();
                            strTotalQty = row["BBRQty"].ToString();
                            strStockNumber = "BBR";
                        }
                        else if (intcountTotal == 3)
                        {
                            strTotalWeight = row["BDRWeight"].ToString();
                            strTotalQty = row["BDRQty"].ToString();
                            strStockNumber = "BDR";
                        }
                        else if (intcountTotal == 4)
                        {
                            strTotalWeight = row["BLOODMWeight"].ToString();
                            strTotalQty = row["BLOODMQty"].ToString();
                            strStockNumber = "BLOOD-M";
                        }
                        else if (intcountTotal == 5)
                        {
                            strTotalWeight = row["BTHWeight"].ToString();
                            strTotalQty = row["BTHQty"].ToString();
                            strStockNumber = "BTH";
                        }
                        else if (intcountTotal == 6)
                        {
                            strTotalWeight = row["BWBWeight"].ToString();
                            strTotalQty = row["BWBQty"].ToString();
                            strStockNumber = "BWB";
                        }
                        else if (intcountTotal == 7)
                        {
                            strTotalWeight = row["BWGWeight"].ToString();
                            strTotalQty = row["BWGQty"].ToString();
                            strStockNumber = "BWG";
                        }
                        else if (intcountTotal == 8)
                        {
                            strTotalWeight = row["BWTWeight"].ToString();
                            strTotalQty = row["BWTQty"].ToString();
                            strStockNumber = "BWT";
                        }
                        else if (intcountTotal == 9)
                        {
                            strTotalWeight = row["CROPMWeight"].ToString();
                            strTotalQty = row["CROPMQty"].ToString();
                            strStockNumber = "CROP-M";
                        }
                        else if (intcountTotal == 10)
                        {
                            strTotalWeight = row["CROPSWeight"].ToString();
                            strTotalQty = row["CROPSQty"].ToString();
                            strStockNumber = "CROP-S";

                        }
                        else if (intcountTotal == 11)
                        {
                            strTotalWeight = row["DBLWeight"].ToString();
                            strTotalQty = row["DBLQty"].ToString();
                            strStockNumber = "DBL";
                        }
                        else if (intcountTotal == 12)
                        {
                            strTotalWeight = row["DBLWeight"].ToString();
                            strTotalQty = row["DBLQty"].ToString();
                            strStockNumber = "DBL";
                        }
                        else if (intcountTotal == 13)
                        {
                            strTotalWeight = row["FATSMWeight"].ToString();
                            strTotalQty = row["FATSMQty"].ToString();
                            strStockNumber = "FATS-M";
                        }
                        else if (intcountTotal == 14)
                        {
                            strTotalWeight = row["FBBK5Weight"].ToString();
                            strTotalQty = row["FBBK5Qty"].ToString();
                            strStockNumber = "FBBK5";
                        }
                        else if (intcountTotal == 15)
                        {
                            strTotalWeight = row["FBLVWeight"].ToString();
                            strTotalQty = row["FBLVQty"].ToString();
                            strStockNumber = "FBLV";
                        }
                        else if (intcountTotal == 16)
                        {
                            strTotalWeight = row["FBNK5Weight"].ToString();
                            strTotalQty = row["FBNK5Qty"].ToString();
                            strStockNumber = "FBNK5";
                        }
                        else if (intcountTotal == 17)
                        {
                            strTotalWeight = row["FC1Weight"].ToString();
                            strTotalQty = row["FC1Qty"].ToString();
                            strStockNumber = "FC1";
                        }
                        else if (intcountTotal == 18)
                        {
                            strTotalWeight = row["FC2Weight"].ToString();
                            strTotalQty = row["FC2Qty"].ToString();
                            strStockNumber = "FC2";
                        }
                        else if (intcountTotal == 19)
                        {
                            strTotalWeight = row["FeetMWeight"].ToString();
                            strTotalQty = row["FeetMQty"].ToString();
                            strStockNumber = "Feet-M";
                        }
                        else if (intcountTotal == 20)
                        {
                            strTotalWeight = row["FeetSWeight"].ToString();
                            strTotalQty = row["FeetSQty"].ToString();
                            strStockNumber = "Feet-S";
                        }
                        else if (intcountTotal == 21)
                        {
                            strTotalWeight = row["FMBBWeight"].ToString();
                            strTotalQty = row["FMBBQty"].ToString();
                            strStockNumber = "FMBB";
                        }
                        else if (intcountTotal == 22)
                        {
                            strTotalWeight = row["FMWCWeight"].ToString();
                            strTotalQty = row["FMWCQty"].ToString();
                            strStockNumber = "FMWC";
                        }
                        else if (intcountTotal == 23)
                        {
                            strTotalWeight = row["FRCVWeight"].ToString();
                            strTotalQty = row["FRCVQty"].ToString();
                            strStockNumber = "FRCV";
                        }
                        else if (intcountTotal == 24)
                        {
                            strTotalWeight = row["FSQWeight"].ToString();
                            strTotalQty = row["FSQQty"].ToString();
                            strStockNumber = "FSQ";
                        }
                        else if (intcountTotal == 25)
                        {
                            strTotalWeight = row["FYRWeight"].ToString();
                            strTotalQty = row["FYRQty"].ToString();
                            strStockNumber = "FYR";
                        }
                        else if (intcountTotal == 26)
                        {
                            strTotalWeight = row["HeadMWeight"].ToString();
                            strTotalQty = row["HeadMQty"].ToString();
                            strStockNumber = "Head-M";
                        }
                        else if (intcountTotal == 27)
                        {
                            strTotalWeight = row["HeadSWeight"].ToString();
                            strTotalQty = row["HeadSQty"].ToString();
                            strStockNumber = "Head-S";
                        }
                        else if (intcountTotal == 28)
                        {
                            strTotalWeight = row["LINTMWeight"].ToString();
                            strTotalQty = row["LINTMQty"].ToString();
                            strStockNumber = "LINT-M";
                        }
                        else if (intcountTotal == 29)
                        {
                            strTotalWeight = row["LINTSWeight"].ToString();
                            strTotalQty = row["LINTSQty"].ToString();
                            strStockNumber = "LINT-S";
                        }
                        else if (intcountTotal == 30)
                        {
                            strTotalWeight = row["LUNGSMWeight"].ToString();
                            strTotalQty = row["LUNGSMQty"].ToString();
                            strStockNumber = "LUNGS-M";
                        }
                        else if (intcountTotal == 31)
                        {
                            strTotalWeight = row["MCUWeight"].ToString();
                            strTotalQty = row["MCUQty"].ToString();
                            strStockNumber = "MCU";
                        }
                        else if (intcountTotal == 32)
                        {
                            strTotalWeight = row["MFCWeight"].ToString();
                            strTotalQty = row["MFCQty"].ToString();
                            strStockNumber = "MFC";
                        }
                        else if (intcountTotal == 33)
                        {
                            strTotalWeight = row["MFCAWeight"].ToString();
                            strTotalQty = row["MFCAQty"].ToString();
                            strStockNumber = "MFCA";
                        }
                        else if (intcountTotal == 34)
                        {
                            strTotalWeight = row["MSCWeight"].ToString();
                            strTotalQty = row["MSCQty"].ToString();
                            strStockNumber = "MSC";

                        }
                        else if (intcountTotal == 35)
                        {
                            strTotalWeight = row["PROVMWeight"].ToString();
                            strTotalQty = row["PROVMQty"].ToString();
                            strStockNumber = "PROV-M";

                        }
                        else if (intcountTotal == 36)
                        {
                            strTotalWeight = row["PROVSWeight"].ToString();
                            strTotalQty = row["PROVSQty"].ToString();
                            strStockNumber = "PROV-S";
                        }
                        else if (intcountTotal == 37)
                        {
                            strTotalWeight = row["SINTMWeight"].ToString();
                            strTotalQty = row["SINTMQty"].ToString();
                            strStockNumber = "SINT-M";
                        }
                        else if (intcountTotal == 38)
                        {
                            strTotalWeight = row["SINTSWeight"].ToString();
                            strTotalQty = row["SINTSQty"].ToString();
                            strStockNumber = "SINT-S";
                        }
                        else if (intcountTotal == 39)
                        {
                            strTotalWeight = row["SpleenSWeight"].ToString();
                            strTotalQty = row["SpleenSQty"].ToString();
                            strStockNumber = "Spleen-S";
                        }
                        else if (intcountTotal == 40)
                        {
                            strTotalWeight = row["UBKWeight"].ToString();
                            strTotalQty = row["UBKQty"].ToString();
                            strStockNumber = "UBK";
                        }
                        else if (intcountTotal == 41)
                        {
                            strTotalWeight = row["UBRWeight"].ToString();
                            strTotalQty = row["UBRQty"].ToString();
                            strStockNumber = "UBR";
                        }
                        else if (intcountTotal == 42)
                        {
                            strTotalWeight = row["UDRWeight"].ToString();
                            strTotalQty = row["UDRQty"].ToString();
                            strStockNumber = "UDR";
                        }
                        else if (intcountTotal == 43)
                        {
                            strTotalWeight = row["UGZWeight"].ToString();
                            strTotalQty = row["UGZQty"].ToString();
                            strStockNumber = "UGZ";
                        }
                        else if (intcountTotal == 44)
                        {
                            strTotalWeight = row["UNKWeight"].ToString();
                            strTotalQty = row["UNKQty"].ToString();
                            strStockNumber = "UNK";
                        }
                        else if (intcountTotal == 45)
                        {
                            strTotalWeight = row["UTHWeight"].ToString();
                            strTotalQty = row["UTHQty"].ToString();
                            strStockNumber = "UTH";
                        }
                        else if (intcountTotal == 46)
                        {
                            strTotalWeight = row["UWGWeight"].ToString();
                            strTotalQty = row["UWGQty"].ToString();
                            strStockNumber = "UWG";
                        }
                        mycommand = new SqlCommand(sqlstatementinsert, myconnection);
                        mycommand.Parameters.Add("_PKRowNum", SqlDbType.Int).Value = intcountTotal;
                        mycommand.Parameters.Add("_SortHeading", SqlDbType.Int).Value = 5;
                        //mycommand.Parameters.Add("_ControlNo", SqlDbType.VarChar).Value = "";
                        mycommand.Parameters.Add("_Reference", SqlDbType.VarChar).Value = "Total";
                        mycommand.Parameters.Add("_Weight", SqlDbType.Money).Value = strTotalWeight;
                        mycommand.Parameters.Add("_QtyPiece", SqlDbType.Money).Value = strTotalQty;
                        mycommand.Parameters.Add("_StockNumber", SqlDbType.VarChar).Value = strStockNumber;
                        mycommand.CommandTimeout = 600;
                        int n1 = mycommand.ExecuteNonQuery();
                    }
                }
                myconnection.Close();
            }
            //}
            //catch
            //{
            //    MessageBox.Show("Something went wrong. Possible error in connection", "Payroll");
            //}
        }

        private void TotalPercent()
        {
            //try
            //{

            intcountTotal = 0;
            string sql = "SELECT (SELECT CASE WHEN ACUWeight5=0 OR ACUWeight2=0 THEN 0 ELSE ACUWeight5/ACUWeight2 END AS A) AS ACUWeight, ";
            sql += "(SELECT CASE WHEN ACUQty5=0 OR ACUQty2=0 THEN 0 ELSE ACUQty5/ACUQty2 END AS A) AS ACUQty, ";
            sql += "(SELECT CASE WHEN BBRWeight5=0 OR BBRWeight2=0 THEN 0 ELSE BBRWeight5/BBRWeight2 END AS A) AS BBRWeight,";
            sql += "(SELECT CASE WHEN BBRQty5=0 OR BBRQty2=0 THEN 0 ELSE BBRQty5/BBRQty2 END AS A) AS BBRQty, ";
            sql += "(SELECT CASE WHEN BDRWeight5=0 OR BDRWeight2=0 THEN 0 ELSE BDRWeight5/BDRWeight2 END AS A) AS BDRWeight, ";
            sql += "(SELECT CASE WHEN BDRQty5=0 OR BDRQty2=0 THEN 0 ELSE BDRQty5/BDRQty2 END AS A) AS BDRQty, ";
            sql += "(SELECT CASE WHEN BLOODMWeight5=0 OR BLOODMWeight2=0 THEN 0 ELSE BLOODMWeight5/BLOODMWeight2 END AS A) AS BLOODMWeight, ";
            sql += "(SELECT CASE WHEN BLOODMQty5=0 OR BLOODMQty2=0 THEN 0 ELSE BLOODMQty5/BLOODMQty2 END AS A) AS BLOODMQty, ";
            sql += "(SELECT CASE WHEN BTHWeight5=0 OR BTHWeight2=0 THEN 0 ELSE BTHWeight5/BTHWeight2 END AS A) AS BTHWeight, ";
            sql += "(SELECT CASE WHEN BTHQty5=0 OR BTHQty2=0 THEN 0 ELSE BTHQty5/BTHQty2 END AS A) AS BTHQty, ";
            sql += "(SELECT CASE WHEN BWBWeight5=0 OR BWBWeight2=0 THEN 0 ELSE BWBWeight5/BWBWeight2 END AS A) AS BWBWeight, ";
            sql += "(SELECT CASE WHEN BWBQty5=0 OR BWBQty2=0 THEN 0 ELSE BWBQty5/BWBQty2 END AS A) AS BWBQty, ";
            sql += "(SELECT CASE WHEN BWGWeight5=0 OR BWGWeight2=0 THEN 0 ELSE BWGWeight5/BWGWeight2 END AS A) AS BWGWeight, ";
            sql += "(SELECT CASE WHEN BWGQty5=0 OR BWGQty2=0 THEN 0 ELSE BWGQty5/BWGQty2 END AS A) AS BWGQty, ";
            sql += "(SELECT CASE WHEN BWTWeight5=0 OR BWTWeight2=0 THEN 0 ELSE BWTWeight5/BWTWeight2 END AS A) AS BWTWeight, ";
            sql += "(SELECT CASE WHEN BWTQty5=0 OR BWTQty2=0 THEN 0 ELSE BWTQty5/BWTQty2 END AS A) AS BWTQty, ";
            sql += "(SELECT CASE WHEN CROPMWeight5=0 OR CROPMWeight2=0 THEN 0 ELSE CROPMWeight5/CROPMWeight2 END AS A) AS CROPMWeight, ";
            sql += "(SELECT CASE WHEN CROPMQty5=0 OR CROPMQty2=0 THEN 0 ELSE CROPMQty5/CROPMQty2 END AS A) AS CROPMQty, ";
            sql += "(SELECT CASE WHEN CROPSWeight5=0 OR CROPSWeight2=0 THEN 0 ELSE CROPSWeight5/CROPSWeight2 END AS A) AS CROPSWeight, ";
            sql += "(SELECT CASE WHEN CROPSQty5=0 OR CROPSQty2=0 THEN 0 ELSE CROPSQty5/CROPSQty2 END AS A) AS CROPSQty, ";
            sql += "(SELECT CASE WHEN DBLWeight5=0 OR DBLWeight2=0 THEN 0 ELSE DBLWeight5/DBLWeight2 END AS A) AS DBLWeight, ";
            sql += "(SELECT CASE WHEN DBLQty5=0 OR DBLQty2=0 THEN 0 ELSE DBLQty5/DBLQty2 END AS A) AS DBLQty, ";
            sql += "(SELECT CASE WHEN FATSMWeight5=0 OR FATSMWeight2=0 THEN 0 ELSE FATSMWeight5/FATSMWeight2 END AS A) AS FATSMWeight, ";
            sql += "(SELECT CASE WHEN FATSMQty5=0 OR FATSMQty2=0 THEN 0 ELSE FATSMQty5/FATSMQty2 END AS A) AS FATSMQty, ";
            sql += "(SELECT CASE WHEN FBBK5Weight5=0 OR FBBK5Weight2=0 THEN 0 ELSE FBBK5Weight5/FBBK5Weight2 END AS A) AS FBBK5Weight, ";
            sql += "(SELECT CASE WHEN FBBK5Qty5=0 OR FBBK5Qty2=0 THEN 0 ELSE FBBK5Qty5/FBBK5Qty2 END AS A) AS FBBK5Qty, ";
            sql += "(SELECT CASE WHEN FBLVWeight5=0 OR FBLVWeight2=0 THEN 0 ELSE FBLVWeight5/FBLVWeight2 END AS A) AS FBLVWeight, ";
            sql += "(SELECT CASE WHEN FBLVQty5=0 OR FBLVQty2=0 THEN 0 ELSE FBLVQty5/FBLVQty2 END AS A) AS FBLVQty, ";
            sql += "(SELECT CASE WHEN FBNK5Weight5=0 OR FBNK5Weight2=0 THEN 0 ELSE FBNK5Weight5/FBNK5Weight2 END AS A) AS FBNK5Weight, ";
            sql += "(SELECT CASE WHEN FBNK5Qty5=0 OR FBNK5Qty2=0 THEN 0 ELSE FBNK5Qty5/FBNK5Qty2 END AS A) AS FBNK5Qty, ";
            sql += "(SELECT CASE WHEN FC1Weight5=0 OR FC1Weight2=0 THEN 0 ELSE FC1Weight5/FC1Weight2 END AS A) AS FC1Weight, ";
            sql += "(SELECT CASE WHEN FC1Qty5=0 OR FC1Qty2=0 THEN 0 ELSE FC1Qty5/FC1Qty2 END AS A) AS FC1Qty, ";
            sql += "(SELECT CASE WHEN FC2Weight5=0 OR FC2Weight2=0 THEN 0 ELSE FC2Weight5/FC2Weight2 END AS A) AS FC2Weight, ";
            sql += "(SELECT CASE WHEN FC2Qty5 =0 OR FC2Qty2=0 THEN 0 ELSE FC2Qty5/FC2Qty2 END AS A) AS FC2Qty, ";
            sql += "(SELECT CASE WHEN FeetMWeight5=0 OR FeetMWeight2=0 THEN 0 ELSE FeetMWeight5/FeetMWeight2 END AS A) AS FeetMWeight, ";
            sql += "(SELECT CASE WHEN FeetMQty5=0 OR FeetMQty2=0 THEN 0 ELSE FeetMQty5/FeetMQty2 END AS A) AS FeetMQty, ";
            sql += "(SELECT CASE WHEN FeetSWeight5=0 OR FeetSWeight2=0 THEN 0 ELSE FeetSWeight5/FeetSWeight2 END AS A) AS FeetSWeight, ";
            sql += "(SELECT CASE WHEN FeetSQty5=0 OR FeetSQty2=0 THEN 0 ELSE FeetSQty5/FeetSQty2 END AS A) AS FeetSQty, ";
            sql += "(SELECT CASE WHEN FMBBWeight5=0 OR FMBBWeight2=0 THEN 0 ELSE FMBBWeight5/FMBBWeight2 END AS A) AS FMBBWeight, ";
            sql += "(SELECT CASE WHEN FMBBQty5=0 OR FMBBQty2=0 THEN 0 ELSE FMBBQty5/FMBBQty2 END AS A) AS FMBBQty, ";
            sql += "(SELECT CASE WHEN FMWCWeight5=0 OR FMWCWeight2=0 THEN 0 ELSE FMWCWeight5/FMWCWeight2 END AS A) AS FMWCWeight, ";
            sql += "(SELECT CASE WHEN FMWCQty5=0 OR FMWCQty2=0 THEN 0 ELSE FMWCQty5/FMWCQty2 END AS A) AS FMWCQty, ";
            sql += "(SELECT CASE WHEN FRCVWeight5=0 OR FRCVWeight2=0 THEN 0 ELSE FRCVWeight5/FRCVWeight2 END AS A) AS FRCVWeight,";
            sql += "(SELECT CASE WHEN FRCVQty5=0 OR FRCVQty2=0 THEN 0 ELSE FRCVQty5/FRCVQty2 END AS A) AS FRCVQty, ";
            sql += "(SELECT CASE WHEN FSQWeight5=0 OR FSQWeight2=0 THEN 0 ELSE FSQWeight5/FSQWeight2 END AS A) AS FSQWeight, ";
            sql += "(SELECT CASE WHEN FSQQty5=0 OR FSQQty2=0 THEN 0 ELSE FSQQty5/FSQQty2 END AS A) AS FSQQty, ";
            sql += "(SELECT CASE WHEN FYRWeight5=0 OR FYRWeight2=0 THEN 0 ELSE FYRWeight5/FYRWeight2 END AS A) AS FYRWeight, ";
            sql += "(SELECT CASE WHEN FYRQty5=0 OR FYRQty2=0 THEN 0 ELSE FYRQty5/FYRQty2 END AS A) AS FYRQty, ";
            sql += "(SELECT CASE WHEN HeadMWeight5=0 OR HeadMWeight2=0 THEN 0 ELSE HeadMWeight5/HeadMWeight2 END AS A) AS HeadMWeight, ";
            sql += "(SELECT CASE WHEN HeadMQty5=0 OR HeadMQty2=0 THEN 0 ELSE HeadMQty5/HeadMQty2 END AS A) AS HeadMQty, ";
            sql += "(SELECT CASE WHEN HeadSWeight5=0 OR HeadSWeight2=0 THEN 0 ELSE HeadSWeight5/HeadSWeight2 END AS A) AS HeadSWeight, ";
            sql += "(SELECT CASE WHEN HeadSQty5=0 OR HeadSQty2=0 THEN 0 ELSE HeadSQty5/HeadSQty2 END AS A) AS HeadSQty, ";
            sql += "(SELECT CASE WHEN LINTMWeight5=0 OR LINTMWeight2=0 THEN 0 ELSE LINTMWeight5/LINTMWeight2 END AS A) AS LINTMWeight, ";
            sql += "(SELECT CASE WHEN LINTMQty5=0 OR LINTMQty2=0 THEN 0 ELSE LINTMQty5/LINTMQty2 END AS A) AS LINTMQty, ";
            sql += "(SELECT CASE WHEN LINTSWeight5=0 OR LINTSWeight2=0 THEN 0 ELSE LINTSWeight5/LINTSWeight2 END AS A) AS LINTSWeight, ";
            sql += "(SELECT CASE WHEN LINTSQty5=0 OR LINTSQty2=0 THEN 0 ELSE LINTSQty5/LINTSQty2 END AS A) AS LINTSQty, ";
            sql += "(SELECT CASE WHEN LUNGSMWeight5=0 OR LUNGSMWeight2=0 THEN 0 ELSE LUNGSMWeight5/LUNGSMWeight2 END AS A) AS LUNGSMWeight, ";
            sql += "(SELECT CASE WHEN LUNGSMQty5=0 OR LUNGSMQty2=0 THEN 0 ELSE LUNGSMQty5/LUNGSMQty2 END AS A) AS LUNGSMQty, ";
            sql += "(SELECT CASE WHEN MCUWeight5=0 OR MCUWeight2=0 THEN 0 ELSE MCUWeight5/MCUWeight2 END AS A) AS MCUWeight, ";
            sql += "(SELECT CASE WHEN MCUQty5=0 OR MCUQty2=0 THEN 0 ELSE MCUQty5/MCUQty2 END AS A) AS MCUQty, ";
            sql += "(SELECT CASE WHEN MFCWeight5=0 OR MFCWeight2=0 THEN 0 ELSE MFCWeight5/MFCWeight2 END AS A) AS MFCWeight, ";
            sql += "(SELECT CASE WHEN MFCQty5=0 OR MFCQty2=0 THEN 0 ELSE MFCQty5/MFCQty2 END AS A) AS MFCQty, ";
            sql += "(SELECT CASE WHEN MFCAWeight5=0 OR MFCAWeight2=0 THEN 0 ELSE MFCAWeight5/MFCAWeight2 END AS A) AS MFCAWeight, ";
            sql += "(SELECT CASE WHEN MFCAQty5=0 OR MFCAQty2=0 THEN 0 ELSE MFCAQty5/MFCAQty2 END AS A) AS MFCAQty, ";
            sql += "(SELECT CASE WHEN MSCWeight5=0 OR MSCWeight2=0 THEN 0 ELSE MSCWeight5/MSCWeight2 END AS A) AS MSCWeight, ";
            sql += "(SELECT CASE WHEN MSCQty5=0 OR MSCQty2=0 THEN 0 ELSE MSCQty5/MSCQty2 END AS A) AS MSCQty, ";
            sql += "(SELECT CASE WHEN PROVMWeight5=0 OR PROVMWeight2=0 THEN 0 ELSE PROVMWeight5/PROVMWeight2 END AS A) AS PROVMWeight, ";
            sql += "(SELECT CASE WHEN PROVMQty5=0 OR PROVMQty2=0 THEN 0 ELSE PROVMQty5/PROVMQty2 END AS A) AS PROVMQty, ";
            sql += "(SELECT CASE WHEN PROVSWeight5=0 OR PROVSWeight2=0 THEN 0 ELSE PROVSWeight5/PROVSWeight2 END AS A) AS PROVSWeight, ";
            sql += "(SELECT CASE WHEN PROVSQty5=0 OR PROVSQty2=0 THEN 0 ELSE PROVSQty5/PROVSQty2 END AS A) AS PROVSQty, ";
            sql += "(SELECT CASE WHEN SINTMWeight5=0 OR SINTMWeight2=0 THEN 0 ELSE SINTMWeight5/SINTMWeight2 END AS A) AS SINTMWeight, ";
            sql += "(SELECT CASE WHEN SINTMQty5=0 OR SINTMQty2=0 THEN 0 ELSE SINTMQty5/SINTMQty2 END AS A) AS SINTMQty, ";
            sql += "(SELECT CASE WHEN SINTSWeight5=0 OR SINTSWeight2=0 THEN 0 ELSE SINTSWeight5/SINTSWeight2 END AS A) AS SINTSWeight, ";
            sql += "(SELECT CASE WHEN SINTSQty5=0 OR SINTSQty2=0 THEN 0 ELSE SINTSQty5/SINTSQty2 END AS A) AS SINTSQty, ";
            sql += "(SELECT CASE WHEN SpleenSWeight5=0 OR SpleenSWeight2=0 THEN 0 ELSE SpleenSWeight5/SpleenSWeight2 END AS A) AS SpleenSWeight, ";
            sql += "(SELECT CASE WHEN SpleenSQty5=0 OR SpleenSQty2=0 THEN 0 ELSE SpleenSQty5/SpleenSQty2 END AS A) AS SpleenSQty, ";
            sql += "(SELECT CASE WHEN UBKWeight5=0 OR UBKWeight2=0 THEN 0 ELSE UBKWeight5/UBKWeight2 END AS A) AS UBKWeight, ";
            sql += "(SELECT CASE WHEN UBKQty5=0 OR UBKQty2=0 THEN 0 ELSE UBKQty5/UBKQty2 END AS A) AS UBKQty, ";
            sql += "(SELECT CASE WHEN UBRWeight5=0 OR UBRWeight2=0 THEN 0 ELSE UBRWeight5/UBRWeight2 END AS A) AS UBRWeight, ";
            sql += "(SELECT CASE WHEN UBRQty5=0 OR UBRQty2=0 THEN 0 ELSE UBRQty5/UBRQty2 END AS A) AS UBRQty, ";
            sql += "(SELECT CASE WHEN UDRWeight5=0 OR UDRWeight2=0 THEN 0 ELSE UDRWeight5/UDRWeight2 END AS A) AS UDRWeight, ";
            sql += "(SELECT CASE WHEN UDRQty5=0 OR UDRQty2=0 THEN 0 ELSE UDRQty5/UDRQty2 END AS A) AS UDRQty, ";
            sql += "(SELECT CASE WHEN UGZWeight5=0 OR UGZWeight2=0 THEN 0 ELSE UGZWeight5/UGZWeight2 END AS A) AS UGZWeight, ";
            sql += "(SELECT CASE WHEN UGZQty5=0 OR UGZQty2=0 THEN 0 ELSE UGZQty5/UGZQty2 END AS A) AS UGZQty, ";
            sql += "(SELECT CASE WHEN UNKWeight5=0 OR UNKWeight2=0 THEN 0 ELSE UNKWeight5/UNKWeight2 END AS A) AS UNKWeight, ";
            sql += "(SELECT CASE WHEN UNKQty5=0 OR UNKQty2=0 THEN 0 ELSE UNKQty5/UNKQty2 END AS A) AS UNKQty, ";
            sql += "(SELECT CASE WHEN UTHWeight5=0 OR UTHWeight2=0 THEN 0 ELSE UTHWeight5/UTHWeight2 END AS A) AS UTHWeight, ";
            sql += "(SELECT CASE WHEN UTHQty5=0 OR UTHQty2=0 THEN 0 ELSE UTHQty5/UTHQty2 END AS A) AS UTHQty, ";
            sql += "(SELECT CASE WHEN UWGWeight5=0 OR UWGWeight2=0 THEN 0 ELSE UWGWeight5/UWGWeight2 END AS A) AS UWGWeight, ";
            sql += "(SELECT CASE WHEN UWGQty5=0 OR UWGQty2=0 THEN 0 ELSE UWGQty5/UWGQty2 END AS A) AS UWGQty, FMWCQty5, FMWCQty2  FROM ViewShrinkageDetailsPercent2";


            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            SqlCommand SqlCommand1 = myconnection.CreateCommand();
            SqlCommand1.CommandText = sql;
            SqlDataReader SqlDataReader1;
            myconnection.Open();
            SqlDataReader1 = SqlCommand1.ExecuteReader();
            DataTable DataTable1 = new DataTable();
            DataTable1.Load(SqlDataReader1);
            int CountData = DataTable1.Rows.Count; //int proces = dgvPurgeTransact.Rows.Count;
            if (CountData > 0)
            {
                string sqlstatementinsert = "INSERT INTO tblShrinkageDetails (PKRowNum, SortHeading, Reference, Weight, QtyPiece, StockNumber)";
                sqlstatementinsert += " Values (@_PKRowNum, @_SortHeading, @_Reference, @_Weight, @_QtyPiece, @_StockNumber)";

                foreach (DataRow row in DataTable1.Rows)
                {

                    for (int x = 0; x < 46; x++)
                    {

                        intcountTotal = intcountTotal + 1;
                        if (intcountTotal == 1)
                        {
                            strTotalWeight = row["ACUWeight"].ToString();
                            strTotalQty = row["ACUQty"].ToString();
                            strStockNumber = "ACU";
                        }
                        else if (intcountTotal == 2)
                        {
                            strTotalWeight = row["BBRWeight"].ToString();
                            strTotalQty = row["BBRQty"].ToString();
                            strStockNumber = "BBR";
                        }
                        else if (intcountTotal == 3)
                        {
                            strTotalWeight = row["BDRWeight"].ToString();
                            strTotalQty = row["BDRQty"].ToString();
                            strStockNumber = "BDR";
                        }
                        else if (intcountTotal == 4)
                        {
                            strTotalWeight = row["BLOODMWeight"].ToString();
                            strTotalQty = row["BLOODMQty"].ToString();
                            strStockNumber = "BLOOD-M";
                        }
                        else if (intcountTotal == 5)
                        {
                            strTotalWeight = row["BTHWeight"].ToString();
                            strTotalQty = row["BTHQty"].ToString();
                            strStockNumber = "BTH";
                        }
                        else if (intcountTotal == 6)
                        {
                            strTotalWeight = row["BWBWeight"].ToString();
                            strTotalQty = row["BWBQty"].ToString();
                            strStockNumber = "BWB";
                        }
                        else if (intcountTotal == 7)
                        {
                            strTotalWeight = row["BWGWeight"].ToString();
                            strTotalQty = row["BWGQty"].ToString();
                            strStockNumber = "BWG";
                        }
                        else if (intcountTotal == 8)
                        {
                            strTotalWeight = row["BWTWeight"].ToString();
                            strTotalQty = row["BWTQty"].ToString();
                            strStockNumber = "BWT";
                        }
                        else if (intcountTotal == 9)
                        {
                            strTotalWeight = row["CROPMWeight"].ToString();
                            strTotalQty = row["CROPMQty"].ToString();
                            strStockNumber = "CROP-M";
                        }
                        else if (intcountTotal == 10)
                        {
                            strTotalWeight = row["CROPSWeight"].ToString();
                            strTotalQty = row["CROPSQty"].ToString();
                            strStockNumber = "CROP-S";

                        }
                        else if (intcountTotal == 11)
                        {
                            strTotalWeight = row["DBLWeight"].ToString();
                            strTotalQty = row["DBLQty"].ToString();
                            strStockNumber = "DBL";
                        }
                        else if (intcountTotal == 12)
                        {
                            strTotalWeight = row["DBLWeight"].ToString();
                            strTotalQty = row["DBLQty"].ToString();
                            strStockNumber = "DBL";
                        }
                        else if (intcountTotal == 13)
                        {
                            strTotalWeight = row["FATSMWeight"].ToString();
                            strTotalQty = row["FATSMQty"].ToString();
                            strStockNumber = "FATS-M";
                        }
                        else if (intcountTotal == 14)
                        {
                            strTotalWeight = row["FBBK5Weight"].ToString();
                            strTotalQty = row["FBBK5Qty"].ToString();
                            strStockNumber = "FBBK5";
                        }
                        else if (intcountTotal == 15)
                        {
                            strTotalWeight = row["FBLVWeight"].ToString();
                            strTotalQty = row["FBLVQty"].ToString();
                            strStockNumber = "FBLV";
                        }
                        else if (intcountTotal == 16)
                        {
                            strTotalWeight = row["FBNK5Weight"].ToString();
                            strTotalQty = row["FBNK5Qty"].ToString();
                            strStockNumber = "FBNK5";
                        }
                        else if (intcountTotal == 17)
                        {
                            strTotalWeight = row["FC1Weight"].ToString();
                            strTotalQty = row["FC1Qty"].ToString();
                            strStockNumber = "FC1";
                        }
                        else if (intcountTotal == 18)
                        {
                            strTotalWeight = row["FC2Weight"].ToString();
                            strTotalQty = row["FC2Qty"].ToString();
                            strStockNumber = "FC2";
                        }
                        else if (intcountTotal == 19)
                        {
                            strTotalWeight = row["FeetMWeight"].ToString();
                            strTotalQty = row["FeetMQty"].ToString();
                            strStockNumber = "Feet-M";
                        }
                        else if (intcountTotal == 20)
                        {
                            strTotalWeight = row["FeetSWeight"].ToString();
                            strTotalQty = row["FeetSQty"].ToString();
                            strStockNumber = "Feet-S";
                        }
                        else if (intcountTotal == 21)
                        {
                            strTotalWeight = row["FMBBWeight"].ToString();
                            strTotalQty = row["FMBBQty"].ToString();
                            strStockNumber = "FMBB";
                        }
                        else if (intcountTotal == 22)
                        {
                            strTotalWeight = row["FMWCWeight"].ToString();
                            strTotalQty = row["FMWCQty"].ToString();
                            strStockNumber = "FMWC";
                        }
                        else if (intcountTotal == 23)
                        {
                            strTotalWeight = row["FRCVWeight"].ToString();
                            strTotalQty = row["FRCVQty"].ToString();
                            strStockNumber = "FRCV";
                        }
                        else if (intcountTotal == 24)
                        {
                            strTotalWeight = row["FSQWeight"].ToString();
                            strTotalQty = row["FSQQty"].ToString();
                            strStockNumber = "FSQ";
                        }
                        else if (intcountTotal == 25)
                        {
                            strTotalWeight = row["FYRWeight"].ToString();
                            strTotalQty = row["FYRQty"].ToString();
                            strStockNumber = "FYR";
                        }
                        else if (intcountTotal == 26)
                        {
                            strTotalWeight = row["HeadMWeight"].ToString();
                            strTotalQty = row["HeadMQty"].ToString();
                            strStockNumber = "Head-M";
                        }
                        else if (intcountTotal == 27)
                        {
                            strTotalWeight = row["HeadSWeight"].ToString();
                            strTotalQty = row["HeadSQty"].ToString();
                            strStockNumber = "Head-S";
                        }
                        else if (intcountTotal == 28)
                        {
                            strTotalWeight = row["LINTMWeight"].ToString();
                            strTotalQty = row["LINTMQty"].ToString();
                            strStockNumber = "LINT-M";
                        }
                        else if (intcountTotal == 29)
                        {
                            strTotalWeight = row["LINTSWeight"].ToString();
                            strTotalQty = row["LINTSQty"].ToString();
                            strStockNumber = "LINT-S";
                        }
                        else if (intcountTotal == 30)
                        {
                            strTotalWeight = row["LUNGSMWeight"].ToString();
                            strTotalQty = row["LUNGSMQty"].ToString();
                            strStockNumber = "LUNGS-M";
                        }
                        else if (intcountTotal == 31)
                        {
                            strTotalWeight = row["MCUWeight"].ToString();
                            strTotalQty = row["MCUQty"].ToString();
                            strStockNumber = "MCU";
                        }
                        else if (intcountTotal == 32)
                        {
                            strTotalWeight = row["MFCWeight"].ToString();
                            strTotalQty = row["MFCQty"].ToString();
                            strStockNumber = "MFC";
                        }
                        else if (intcountTotal == 33)
                        {
                            strTotalWeight = row["MFCAWeight"].ToString();
                            strTotalQty = row["MFCAQty"].ToString();
                            strStockNumber = "MFCA";
                        }
                        else if (intcountTotal == 34)
                        {
                            strTotalWeight = row["MSCWeight"].ToString();
                            strTotalQty = row["MSCQty"].ToString();
                            strStockNumber = "MSC";
                        }
                        else if (intcountTotal == 35)
                        {
                            strTotalWeight = row["PROVMWeight"].ToString();
                            strTotalQty = row["PROVMQty"].ToString();
                            strStockNumber = "PROV-M";
                        }
                        else if (intcountTotal == 36)
                        {
                            strTotalWeight = row["PROVSWeight"].ToString();
                            strTotalQty = row["PROVSQty"].ToString();
                            strStockNumber = "PROV-S";
                        }
                        else if (intcountTotal == 37)
                        {
                            strTotalWeight = row["SINTMWeight"].ToString();
                            strTotalQty = row["SINTMQty"].ToString();
                            strStockNumber = "SINT-M";
                        }
                        else if (intcountTotal == 38)
                        {
                            strTotalWeight = row["SINTSWeight"].ToString();
                            strTotalQty = row["SINTSQty"].ToString();
                            strStockNumber = "SINT-S";
                        }
                        else if (intcountTotal == 39)
                        {
                            strTotalWeight = row["SpleenSWeight"].ToString();
                            strTotalQty = row["SpleenSQty"].ToString();
                            strStockNumber = "Spleen-S";
                        }
                        else if (intcountTotal == 40)
                        {
                            strTotalWeight = row["UBKWeight"].ToString();
                            strTotalQty = row["UBKQty"].ToString();
                            strStockNumber = "UBK";
                        }
                        else if (intcountTotal == 41)
                        {
                            strTotalWeight = row["UBRWeight"].ToString();
                            strTotalQty = row["UBRQty"].ToString();
                            strStockNumber = "UBR";
                        }
                        else if (intcountTotal == 42)
                        {
                            strTotalWeight = row["UDRWeight"].ToString();
                            strTotalQty = row["UDRQty"].ToString();
                            strStockNumber = "UDR";
                        }
                        else if (intcountTotal == 43)
                        {
                            strTotalWeight = row["UGZWeight"].ToString();
                            strTotalQty = row["UGZQty"].ToString();
                            strStockNumber = "UGZ";
                        }
                        else if (intcountTotal == 44)
                        {
                            strTotalWeight = row["UNKWeight"].ToString();
                            strTotalQty = row["UNKQty"].ToString();
                            strStockNumber = "UNK";
                        }
                        else if (intcountTotal == 45)
                        {
                            strTotalWeight = row["UTHWeight"].ToString();
                            strTotalQty = row["UTHQty"].ToString();
                            strStockNumber = "UTH";
                        }
                        else if (intcountTotal == 46)
                        {
                            strTotalWeight = row["UWGWeight"].ToString();
                            strTotalQty = row["UWGQty"].ToString();
                            strStockNumber = "UWG";
                        }
                        mycommand = new SqlCommand(sqlstatementinsert, myconnection);
                        mycommand.Parameters.Add("_PKRowNum", SqlDbType.Int).Value = intcountTotal;
                        mycommand.Parameters.Add("_SortHeading", SqlDbType.Int).Value = 6;
                        //mycommand.Parameters.Add("_ControlNo", SqlDbType.VarChar).Value = "";
                        mycommand.Parameters.Add("_Reference", SqlDbType.VarChar).Value = "Shrinkage Percentage";
                        mycommand.Parameters.Add("_Weight", SqlDbType.Money).Value = strTotalWeight;
                        mycommand.Parameters.Add("_QtyPiece", SqlDbType.Money).Value = strTotalQty;
                        mycommand.Parameters.Add("_StockNumber", SqlDbType.VarChar).Value = strStockNumber;
                        mycommand.CommandTimeout = 600;
                        int n1 = mycommand.ExecuteNonQuery();
                    }
                }
                myconnection.Close();
            }
            //}
            //catch
            //{
            //    MessageBox.Show("Something went wrong. Possible error in connection", "Payroll");
            //}
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dgv1.Rows.Count == 0)
            {
                MessageBox.Show("No data to convert", "GL");
            }
            else
            {
                PBProgressBar1.Visible = true;
                lblMsg.Visible = true;
                PBProgressBar1.Maximum = dgv1.Rows.Count + 1;
                PBProgressBar1.Step = 1;
                PBProgressBar1.Value = 0;

                Excel.Application ws = new Excel.Application();

                //Microsoft.Office.Interop.Excel.ApplicationClass ws = new Microsoft.Office.Interop.Excel.ApplicationClass();
                ws.Application.Workbooks.Add(Type.Missing);
                //Row = 1
                //Column=2
                //ws.Cells[1, 2] = "abc";

                for (int i = 1; i < dgv1.Columns.Count-1; i++)
                {
                    ws.Cells[1, i] = dgv1.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < dgv1.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv1.Columns.Count; j++)
                    {
                        ws.Cells[i + 2, j + 1] = dgv1.Rows[i].Cells[j].Value.ToString();
                        PBProgressBar1.Value = i + 2;
                    }
                }
                ws.Visible = true;
                this.Close();
            }
        }

        public void LoaddReport()
        {
            
            dgv1.DataSource = null;
            dgv1.Columns.Clear();
            string sql = "SELECT SortHeading, NameCustomer, Reference, ACUWeight, ACUQty, BBRWeight, BBRQty, BDRWeight, BDRQty, ";
            sql += "BLOODMWeight, BLOODMQty, BTHWeight, BTHQty, BWBWeight, BWBQty, BWGWeight, BWGQty, BWTWeight, BWTQty, CROPMWeight, CROPMQty, CROPSWeight, CROPSQty, ";
            sql += "DBLWeight, DBLQty, FATSMWeight, FATSMQty, FBBK5Weight, FBBK5Qty, FBLVWeight, FBLVQty, FBNK5Weight, FBNK5Qty, FC1Weight, ";
            sql += "FC1Qty, FC2Weight, FC2Qty, FeetMWeight, FeetMQty, FeetSWeight, FeetSQty, FMBBWeight, FMBBQty, FMWCWeight, FMWCQty, ";
            sql += "FRCVWeight, FRCVQty, FSQWeight, FSQQty, FYRWeight, FYRQty, HeadMWeight, HeadMQty, HeadSWeight, HeadSQty, LINTMWeight, ";
            sql += "LINTMQty, LINTSWeight, LINTSQty, LUNGSMWeight, LUNGSMQty, MCUWeight, MCUQty, MFCWeight, MFCQty, MFCAWeight, MFCAQty, ";
            sql += "MSCWeight, MSCQty, PROVMWeight, PROVMQty, PROVSWeight, PROVSQty, SINTMWeight, SINTSQty, SpleenSWeight, SpleenSQty, UBKWeight, UBKQty,";
            sql += "UBRWeight, UBRQty, UDRWeight, UDRQty, UGZWeight, UGZQty, UNKWeight, UNKQty, UTHWeight, UTHQty, UWGWeight, UWGQty ";
            sql += "FROM ViewShrinkageDetailsReport2 ORDER BY SortHeading";
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = myconnection.CreateCommand();
            mycommand.CommandText = sql;
            mycommand.CommandTimeout = 900;
            SqlDataReader1 = mycommand.ExecuteReader();
            DataTable DataTable1 = new DataTable();
            DataTable1.Load(SqlDataReader1);
            myconnection.Close();

            bindingSource = new BindingSource();
            bindingSource.DataSource = DataTable1;

            if (DataTable1.Rows.Count == 0)
            {
                MessageBox.Show("No data found", "GL");
                return;
            }

            DataGridViewTextBoxColumn ColumnSortHeading = new DataGridViewTextBoxColumn();
            ColumnSortHeading.HeaderText = "SortHeading";
            ColumnSortHeading.Width = 100;
            ColumnSortHeading.DataPropertyName = "SortHeading";
            ColumnSortHeading.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnSortHeading.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnSortHeading.Visible = false;
            dgv1.Columns.Add(ColumnSortHeading);

            DataGridViewTextBoxColumn ColumnNameCustomer = new DataGridViewTextBoxColumn();
            ColumnNameCustomer.HeaderText = "NameCustomer";
            ColumnNameCustomer.Width = 250;
            ColumnNameCustomer.DataPropertyName = "NameCustomer";
            ColumnNameCustomer.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnNameCustomer.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnNameCustomer.Visible = true;
            dgv1.Columns.Add(ColumnNameCustomer);


            DataGridViewTextBoxColumn ColumnReference = new DataGridViewTextBoxColumn();
            ColumnReference.HeaderText = "Reference";
            ColumnReference.Width = 150;
            ColumnReference.DataPropertyName = "Reference";
            ColumnReference.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnReference.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnReference.Visible = true;
            dgv1.Columns.Add(ColumnReference);

            DataGridViewTextBoxColumn ColumnACUWeight = new DataGridViewTextBoxColumn();
            ColumnACUWeight.HeaderText = "ACUWeight";
            ColumnACUWeight.Width = 100;
            ColumnACUWeight.DataPropertyName = "ACUWeight";
            ColumnACUWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnACUWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("ACU");
            if (douSumWeight == 0)
            { ColumnACUWeight.Visible = false; }
            else
            { ColumnACUWeight.Visible = true; }

            dgv1.Columns.Add(ColumnACUWeight);

            DataGridViewTextBoxColumn ColumnACUQty = new DataGridViewTextBoxColumn();
            ColumnACUQty.HeaderText = "ACUQty";
            ColumnACUQty.Width = 100;
            ColumnACUQty.DataPropertyName = "ACUQty";
            ColumnACUQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnACUQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            
            ShowField("ACU");
            if (douSumQty == 0)
            { ColumnACUQty.Visible = false; }
            else
            { ColumnACUQty.Visible = true; }
            dgv1.Columns.Add(ColumnACUQty);

            DataGridViewTextBoxColumn ColumnBBRWeight = new DataGridViewTextBoxColumn();
            ColumnBBRWeight.HeaderText = "BBRWeight";
            ColumnBBRWeight.Width = 100;
            ColumnBBRWeight.DataPropertyName = "BBRWeight";
            ColumnBBRWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnBBRWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("BBR");
            if (douSumWeight == 0)
            { ColumnBBRWeight.Visible = false; }
            else
            { ColumnBBRWeight.Visible = true; }
            dgv1.Columns.Add(ColumnBBRWeight);

            DataGridViewTextBoxColumn ColumnBBRQty = new DataGridViewTextBoxColumn();
            ColumnBBRQty.HeaderText = "BBRQty";
            ColumnBBRQty.Width = 100;
            ColumnBBRQty.DataPropertyName = "BBRQty";
            ColumnBBRQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnBBRQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("BBR");
            if (douSumQty == 0)
            { ColumnBBRQty.Visible = false; }
            else
            { ColumnBBRQty.Visible = true; }
            dgv1.Columns.Add(ColumnBBRQty);

            DataGridViewTextBoxColumn ColumnBDRWeight = new DataGridViewTextBoxColumn();
            ColumnBDRWeight.HeaderText = "BDRWeight";
            ColumnBDRWeight.Width = 100;
            ColumnBDRWeight.DataPropertyName = "BDRWeight";
            ColumnBDRWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnBDRWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("BDR");
            if (douSumWeight == 0)
            { ColumnBDRWeight.Visible = false; }
            else
            { ColumnBDRWeight.Visible = true; }
            dgv1.Columns.Add(ColumnBDRWeight);

            DataGridViewTextBoxColumn ColumnBDRQty = new DataGridViewTextBoxColumn();
            ColumnBDRQty.HeaderText = "BDRQty";
            ColumnBDRQty.Width = 100;
            ColumnBDRQty.DataPropertyName = "BDRQty";
            ColumnBDRQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnBDRQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("BDR");
            if (douSumQty == 0)
            { ColumnBDRQty.Visible = false; }
            else
            { ColumnBDRQty.Visible = true; }
            dgv1.Columns.Add(ColumnBDRQty);

            DataGridViewTextBoxColumn ColumnBLOODMWeight = new DataGridViewTextBoxColumn();
            ColumnBLOODMWeight.HeaderText = "BLOODMWeight";
            ColumnBLOODMWeight.Width = 100;
            ColumnBLOODMWeight.DataPropertyName = "BLOODMWeight";
            ColumnBLOODMWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnBLOODMWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("BLOOD-M");
            if (douSumWeight == 0)
            { ColumnBLOODMWeight.Visible = false; }
            else
            { ColumnBLOODMWeight.Visible = true; }
            dgv1.Columns.Add(ColumnBLOODMWeight);

            DataGridViewTextBoxColumn ColumnBLOODMQty = new DataGridViewTextBoxColumn();
            ColumnBLOODMQty.HeaderText = "BLOODMQty";
            ColumnBLOODMQty.Width = 100;
            ColumnBLOODMQty.DataPropertyName = "BLOODMQty";
            ColumnBLOODMQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnBLOODMQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("BLOOD-M");
            if (douSumQty == 0)
            { ColumnBLOODMQty.Visible = false; }
            else
            { ColumnBLOODMQty.Visible = true; }
            dgv1.Columns.Add(ColumnBLOODMQty);

            DataGridViewTextBoxColumn ColumnBTHWeight = new DataGridViewTextBoxColumn();
            ColumnBTHWeight.HeaderText = "BTHWeight";
            ColumnBTHWeight.Width = 100;
            ColumnBTHWeight.DataPropertyName = "BTHWeight";
            ColumnBTHWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnBTHWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("BTH");
            if (douSumWeight == 0)
            { ColumnBTHWeight.Visible = false; }
            else
            { ColumnBTHWeight.Visible = true; }
            dgv1.Columns.Add(ColumnBTHWeight);

            DataGridViewTextBoxColumn ColumnBTHQty = new DataGridViewTextBoxColumn();
            ColumnBTHQty.HeaderText = "BTHQty";
            ColumnBTHQty.Width = 100;
            ColumnBTHQty.DataPropertyName = "BTHQty";
            ColumnBTHQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnBTHQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("BTH");
            if (douSumQty == 0)
            { ColumnBTHQty.Visible = false; }
            else
            { ColumnBTHQty.Visible = true; }
            dgv1.Columns.Add(ColumnBTHQty);

            DataGridViewTextBoxColumn ColumnBWBWeight = new DataGridViewTextBoxColumn();
            ColumnBWBWeight.HeaderText = "BWBWeight";
            ColumnBWBWeight.Width = 100;
            ColumnBWBWeight.DataPropertyName = "BWBWeight";
            ColumnBWBWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnBWBWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("BWB");
            if (douSumWeight == 0)
            { ColumnBWBWeight.Visible = false; }
            else
            { ColumnBWBWeight.Visible = true; }
            dgv1.Columns.Add(ColumnBWBWeight);

            DataGridViewTextBoxColumn ColumnBWBQty = new DataGridViewTextBoxColumn();
            ColumnBWBQty.HeaderText = "BWBQty";
            ColumnBWBQty.Width = 100;
            ColumnBWBQty.DataPropertyName = "BWBQty";
            ColumnBWBQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnBWBQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("BWB");
            if (douSumQty == 0)
            { ColumnBWBQty.Visible = false; }
            else
            { ColumnBWBQty.Visible = true; }
            dgv1.Columns.Add(ColumnBWBQty);

            DataGridViewTextBoxColumn ColumnBWGWeight = new DataGridViewTextBoxColumn();
            ColumnBWGWeight.HeaderText = "BWGWeight";
            ColumnBWGWeight.Width = 100;
            ColumnBWGWeight.DataPropertyName = "BWGWeight";
            ColumnBWGWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnBWGWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("BWG");
            if (douSumWeight == 0)
            { ColumnBWGWeight.Visible = false; }
            else
            { ColumnBWGWeight.Visible = true; }
            dgv1.Columns.Add(ColumnBWGWeight);

            DataGridViewTextBoxColumn ColumnBWGQty = new DataGridViewTextBoxColumn();
            ColumnBWGQty.HeaderText = "BWGQty";
            ColumnBWGQty.Width = 100;
            ColumnBWGQty.DataPropertyName = "BWGQty";
            ColumnBWGQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnBWGQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("BWG");
            if (douSumQty == 0)
            { ColumnBWGQty.Visible = false; }
            else
            { ColumnBWGQty.Visible = true; }
            dgv1.Columns.Add(ColumnBWGQty);

            DataGridViewTextBoxColumn ColumnBWTWeight = new DataGridViewTextBoxColumn();
            ColumnBWTWeight.HeaderText = "BWTWeight";
            ColumnBWTWeight.Width = 100;
            ColumnBWTWeight.DataPropertyName = "BWTWeight";
            ColumnBWTWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnBWTWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("BWT");
            if (douSumWeight == 0)
            { ColumnBWTWeight.Visible = false; }
            else
            { ColumnBWTWeight.Visible = true; }
            dgv1.Columns.Add(ColumnBWTWeight);

            DataGridViewTextBoxColumn ColumnBWTQty = new DataGridViewTextBoxColumn();
            ColumnBWTQty.HeaderText = "BWTQty";
            ColumnBWTQty.Width = 100;
            ColumnBWTQty.DataPropertyName = "BWTQty";
            ColumnBWTQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnBWTQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("BWT");
            if (douSumQty == 0)
            { ColumnBWTQty.Visible = false; }
            else
            { ColumnBWTQty.Visible = true; }
            dgv1.Columns.Add(ColumnBWTQty);

            DataGridViewTextBoxColumn ColumnCROPMWeight = new DataGridViewTextBoxColumn();
            ColumnCROPMWeight.HeaderText = "CROPMWeight";
            ColumnCROPMWeight.Width = 100;
            ColumnCROPMWeight.DataPropertyName = "CROPMWeight";
            ColumnCROPMWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnCROPMWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("CROP-M");
            if (douSumWeight == 0)
            { ColumnCROPMWeight.Visible = false; }
            else
            { ColumnCROPMWeight.Visible = true; }
            dgv1.Columns.Add(ColumnCROPMWeight);

            DataGridViewTextBoxColumn ColumnCROPMQty = new DataGridViewTextBoxColumn();
            ColumnCROPMQty.HeaderText = "CROPMQty";
            ColumnCROPMQty.Width = 100;
            ColumnCROPMQty.DataPropertyName = "CROPMQty";
            ColumnCROPMQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnCROPMQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("CROP-M");
            if (douSumQty == 0)
            { ColumnCROPMQty.Visible = false; }
            else
            { ColumnCROPMQty.Visible = true; }
            dgv1.Columns.Add(ColumnCROPMQty);

            DataGridViewTextBoxColumn ColumnCROPSWeight = new DataGridViewTextBoxColumn();
            ColumnCROPSWeight.HeaderText = "CROPSWeight";
            ColumnCROPSWeight.Width = 100;
            ColumnCROPSWeight.DataPropertyName = "CROPSWeight";
            ColumnCROPSWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnCROPSWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("CROP-S");
            if (douSumWeight == 0)
            { ColumnCROPSWeight.Visible = false; }
            else
            { ColumnCROPSWeight.Visible = true; }
            dgv1.Columns.Add(ColumnCROPSWeight);

            DataGridViewTextBoxColumn ColumnCROPSQty = new DataGridViewTextBoxColumn();
            ColumnCROPSQty.HeaderText = "CROPSQty";
            ColumnCROPSQty.Width = 100;
            ColumnCROPSQty.DataPropertyName = "CROPSQty";
            ColumnCROPSQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnCROPSQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("CROP-S");
            if (douSumQty == 0)
            { ColumnCROPSQty.Visible = false; }
            else
            { ColumnCROPSQty.Visible = true; }
            dgv1.Columns.Add(ColumnCROPSQty);

            DataGridViewTextBoxColumn ColumnDBLWeight = new DataGridViewTextBoxColumn();
            ColumnDBLWeight.HeaderText = "DBLWeight";
            ColumnDBLWeight.Width = 100;
            ColumnDBLWeight.DataPropertyName = "DBLWeight";
            ColumnDBLWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnDBLWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("DBL");
            if (douSumWeight == 0)
            { ColumnDBLWeight.Visible = false; }
            else
            { ColumnDBLWeight.Visible = true; }
            dgv1.Columns.Add(ColumnDBLWeight);

            DataGridViewTextBoxColumn ColumnDBLQty = new DataGridViewTextBoxColumn();
            ColumnDBLQty.HeaderText = "DBLQty";
            ColumnDBLQty.Width = 100;
            ColumnDBLQty.DataPropertyName = "DBLQty";
            ColumnDBLQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnDBLQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("DBL");
            if (douSumQty == 0)
            { ColumnDBLQty.Visible = false; }
            else
            { ColumnDBLQty.Visible = true; }
            dgv1.Columns.Add(ColumnDBLQty);

            DataGridViewTextBoxColumn ColumnFATSMWeight = new DataGridViewTextBoxColumn();
            ColumnFATSMWeight.HeaderText = "FATSMWeight";
            ColumnFATSMWeight.Width = 100;
            ColumnFATSMWeight.DataPropertyName = "FATSMWeight";
            ColumnFATSMWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnFATSMWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("FATS-M");
            if (douSumWeight == 0)
            { ColumnFATSMWeight.Visible = false; }
            else
            { ColumnFATSMWeight.Visible = true; }
            dgv1.Columns.Add(ColumnFATSMWeight);

            DataGridViewTextBoxColumn ColumnFATSMQty = new DataGridViewTextBoxColumn();
            ColumnFATSMQty.HeaderText = "FATSMQty";
            ColumnFATSMQty.Width = 100;
            ColumnFATSMQty.DataPropertyName = "FATSMQty";
            ColumnFATSMQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnFATSMQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("FATS-M");
            if (douSumQty == 0)
            { ColumnFATSMQty.Visible = false; }
            else
            { ColumnFATSMQty.Visible = true; }
            dgv1.Columns.Add(ColumnFATSMQty);

            DataGridViewTextBoxColumn ColumnFBBK5Weight = new DataGridViewTextBoxColumn();
            ColumnFBBK5Weight.HeaderText = "FBBK5Weight";
            ColumnFBBK5Weight.Width = 100;
            ColumnFBBK5Weight.DataPropertyName = "FBBK5Weight";
            ColumnFBBK5Weight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnFBBK5Weight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("FBBK5");
            if (douSumWeight == 0)
            { ColumnFBBK5Weight.Visible = false; }
            else
            { ColumnFBBK5Weight.Visible = true; }
            dgv1.Columns.Add(ColumnFBBK5Weight);

            DataGridViewTextBoxColumn ColumnFBBK5Qty = new DataGridViewTextBoxColumn();
            ColumnFBBK5Qty.HeaderText = "FBBK5Qty";
            ColumnFBBK5Qty.Width = 100;
            ColumnFBBK5Qty.DataPropertyName = "FBBK5Qty";
            ColumnFBBK5Qty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnFBBK5Qty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("FBBK5");
            if (douSumQty == 0)
            { ColumnFBBK5Qty.Visible = false; }
            else
            { ColumnFBBK5Qty.Visible = true; }
            dgv1.Columns.Add(ColumnFBBK5Qty);

            DataGridViewTextBoxColumn ColumnFBLVWeight = new DataGridViewTextBoxColumn();
            ColumnFBLVWeight.HeaderText = "FBLVWeight";
            ColumnFBLVWeight.Width = 100;
            ColumnFBLVWeight.DataPropertyName = "FBLVWeight";
            ColumnFBLVWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnFBLVWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("FBLV");
            if (douSumWeight == 0)
            { ColumnFBLVWeight.Visible = false; }
            else
            { ColumnFBLVWeight.Visible = true; }
            dgv1.Columns.Add(ColumnFBLVWeight);

            DataGridViewTextBoxColumn ColumnFBLVQty = new DataGridViewTextBoxColumn();
            ColumnFBLVQty.HeaderText = "FBLVQty";
            ColumnFBLVQty.Width = 100;
            ColumnFBLVQty.DataPropertyName = "FBLVQty";
            ColumnFBLVQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnFBLVQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("FBLV");
            if (douSumQty == 0)
            { ColumnFBLVQty.Visible = false; }
            else
            { ColumnFBLVQty.Visible = true; }
            dgv1.Columns.Add(ColumnFBLVQty);

            DataGridViewTextBoxColumn ColumnFBNK5Weight = new DataGridViewTextBoxColumn();
            ColumnFBNK5Weight.HeaderText = "FBNK5Weight";
            ColumnFBNK5Weight.Width = 100;
            ColumnFBNK5Weight.DataPropertyName = "FBNK5Weight";
            ColumnFBNK5Weight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnFBNK5Weight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("FBNK5");
            if (douSumWeight == 0)
            { ColumnFBNK5Weight.Visible = false; }
            else
            { ColumnFBNK5Weight.Visible = true; }
            dgv1.Columns.Add(ColumnFBNK5Weight);

            DataGridViewTextBoxColumn ColumnFBNK5Qty = new DataGridViewTextBoxColumn();
            ColumnFBNK5Qty.HeaderText = "FBNK5Qty";
            ColumnFBNK5Qty.Width = 100;
            ColumnFBNK5Qty.DataPropertyName = "FBNK5Qty";
            ColumnFBNK5Qty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnFBNK5Qty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("FBNK5");
            if (douSumQty == 0)
            { ColumnFBNK5Qty.Visible = false; }
            else
            { ColumnFBNK5Qty.Visible = true; }
            dgv1.Columns.Add(ColumnFBNK5Qty);



            DataGridViewTextBoxColumn ColumnFC1Weight = new DataGridViewTextBoxColumn();
            ColumnFC1Weight.HeaderText = "FC1Weight";
            ColumnFC1Weight.Width = 100;
            ColumnFC1Weight.DataPropertyName = "FC1Weight";
            ColumnFC1Weight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnFC1Weight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("FC1");
            if (douSumWeight == 0)
            { ColumnFC1Weight.Visible = false; }
            else
            { ColumnFC1Weight.Visible = true; }
            dgv1.Columns.Add(ColumnFC1Weight);

            DataGridViewTextBoxColumn ColumnFC1Qty = new DataGridViewTextBoxColumn();
            ColumnFC1Qty.HeaderText = "FC1Qty";
            ColumnFC1Qty.Width = 100;
            ColumnFC1Qty.DataPropertyName = "FC1Qty";
            ColumnFC1Qty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnFC1Qty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("FC1");
            if (douSumQty == 0)
            { ColumnFC1Qty.Visible = false; }
            else
            { ColumnFC1Qty.Visible = true; }
            dgv1.Columns.Add(ColumnFC1Qty);

            DataGridViewTextBoxColumn ColumnFC2Weight = new DataGridViewTextBoxColumn();
            ColumnFC2Weight.HeaderText = "FC2Weight";
            ColumnFC2Weight.Width = 100;
            ColumnFC2Weight.DataPropertyName = "FC2Weight";
            ColumnFC2Weight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnFC2Weight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("FC2");
            if (douSumWeight == 0)
            { ColumnFC2Weight.Visible = false; }
            else
            { ColumnFC2Weight.Visible = true; }
            dgv1.Columns.Add(ColumnFC2Weight);

            DataGridViewTextBoxColumn ColumnFC2Qty = new DataGridViewTextBoxColumn();
            ColumnFC2Qty.HeaderText = "FC2Qty";
            ColumnFC2Qty.Width = 100;
            ColumnFC2Qty.DataPropertyName = "FC2Qty";
            ColumnFC2Qty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnFC2Qty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("FC2");
            if (douSumQty == 0)
            { ColumnFC2Qty.Visible = false; }
            else
            { ColumnFC2Qty.Visible = true; }
            dgv1.Columns.Add(ColumnFC2Qty);

            DataGridViewTextBoxColumn ColumnFeetMWeight = new DataGridViewTextBoxColumn();
            ColumnFeetMWeight.HeaderText = "FeetMWeight";
            ColumnFeetMWeight.Width = 100;
            ColumnFeetMWeight.DataPropertyName = "FeetMWeight";
            ColumnFeetMWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnFeetMWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("Feet-M");
            if (douSumWeight == 0)
            { ColumnFeetMWeight.Visible = false; }
            else
            { ColumnFeetMWeight.Visible = true; }
            dgv1.Columns.Add(ColumnFeetMWeight);

            DataGridViewTextBoxColumn ColumnFeetMQty = new DataGridViewTextBoxColumn();
            ColumnFeetMQty.HeaderText = "FeetMQty";
            ColumnFeetMQty.Width = 100;
            ColumnFeetMQty.DataPropertyName = "FeetMQty";
            ColumnFeetMQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnFeetMQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("Feet-M");
            if (douSumQty == 0)
            { ColumnFeetMQty.Visible = false; }
            else
            { ColumnFeetMQty.Visible = true; }
            dgv1.Columns.Add(ColumnFeetMQty);

            DataGridViewTextBoxColumn ColumnFeetSWeight = new DataGridViewTextBoxColumn();
            ColumnFeetSWeight.HeaderText = "FeetSWeight";
            ColumnFeetSWeight.Width = 100;
            ColumnFeetSWeight.DataPropertyName = "FeetSWeight";
            ColumnFeetSWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnFeetSWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("Feet-S");
            if (douSumWeight == 0)
            { ColumnFeetSWeight.Visible = false; }
            else
            { ColumnFeetSWeight.Visible = true; }
            dgv1.Columns.Add(ColumnFeetSWeight);

            DataGridViewTextBoxColumn ColumnFeetSQty = new DataGridViewTextBoxColumn();
            ColumnFeetSQty.HeaderText = "FeetSQty";
            ColumnFeetSQty.Width = 100;
            ColumnFeetSQty.DataPropertyName = "FeetSQty";
            ColumnFeetSQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnFeetSQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("Feet-S");
            if (douSumQty == 0)
            { ColumnFeetSQty.Visible = false; }
            else
            { ColumnFeetSQty.Visible = true; }
            dgv1.Columns.Add(ColumnFeetSQty);

            DataGridViewTextBoxColumn ColumnFMBBWeight = new DataGridViewTextBoxColumn();
            ColumnFMBBWeight.HeaderText = "FMBBWeight";
            ColumnFMBBWeight.Width = 100;
            ColumnFMBBWeight.DataPropertyName = "FMBBWeight";
            ColumnFMBBWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnFMBBWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("FMBB");
            if (douSumWeight == 0)
            { ColumnFMBBWeight.Visible = false; }
            else
            { ColumnFMBBWeight.Visible = true; }
            dgv1.Columns.Add(ColumnFMBBWeight);

            DataGridViewTextBoxColumn ColumnFMBBQty = new DataGridViewTextBoxColumn();
            ColumnFMBBQty.HeaderText = "FMBBQty";
            ColumnFMBBQty.Width = 100;
            ColumnFMBBQty.DataPropertyName = "FMBBQty";
            ColumnFMBBQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnFMBBQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("FMBB");
            if (douSumQty == 0)
            { ColumnFMBBQty.Visible = false; }
            else
            { ColumnFMBBQty.Visible = true; }
            dgv1.Columns.Add(ColumnFMBBQty);

            DataGridViewTextBoxColumn ColumnFMWCWeight = new DataGridViewTextBoxColumn();
            ColumnFMWCWeight.HeaderText = "FMWCWeight";
            ColumnFMWCWeight.Width = 100;
            ColumnFMWCWeight.DataPropertyName = "FMWCWeight";
            ColumnFMWCWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnFMWCWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("FMWC");
            if (douSumWeight == 0)
            { ColumnFMWCWeight.Visible = false; }
            else
            { ColumnFMWCWeight.Visible = true; }
            dgv1.Columns.Add(ColumnFMWCWeight);

            DataGridViewTextBoxColumn ColumnFMWCQty = new DataGridViewTextBoxColumn();
            ColumnFMWCQty.HeaderText = "FMWCQty";
            ColumnFMWCQty.Width = 100;
            ColumnFMWCQty.DataPropertyName = "FMWCQty";
            ColumnFMWCQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnFMWCQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("FMWC");
            if (douSumQty == 0)
            { ColumnFMWCQty.Visible = false; }
            else
            { ColumnFMWCQty.Visible = true; }
            dgv1.Columns.Add(ColumnFMWCQty);

            DataGridViewTextBoxColumn ColumnFRCVWeight = new DataGridViewTextBoxColumn();
            ColumnFRCVWeight.HeaderText = "FRCVWeight";
            ColumnFRCVWeight.Width = 100;
            ColumnFRCVWeight.DataPropertyName = "FRCVWeight";
            ColumnFRCVWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnFRCVWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("FRCV");
            if (douSumWeight == 0)
            { ColumnFRCVWeight.Visible = false; }
            else
            { ColumnFRCVWeight.Visible = true; }
            dgv1.Columns.Add(ColumnFRCVWeight);

            DataGridViewTextBoxColumn ColumnFRCVQty = new DataGridViewTextBoxColumn();
            ColumnFRCVQty.HeaderText = "FRCVQty";
            ColumnFRCVQty.Width = 100;
            ColumnFRCVQty.DataPropertyName = "FRCVQty";
            ColumnFRCVQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnFRCVQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("FRCV");
            if (douSumQty == 0)
            { ColumnFRCVQty.Visible = false; }
            else
            { ColumnFRCVQty.Visible = true; }
            dgv1.Columns.Add(ColumnFRCVQty);

            DataGridViewTextBoxColumn ColumnFSQWeight = new DataGridViewTextBoxColumn();
            ColumnFSQWeight.HeaderText = "FSQWeight";
            ColumnFSQWeight.Width = 100;
            ColumnFSQWeight.DataPropertyName = "FSQWeight";
            ColumnFSQWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnFSQWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("FSQ");
            if (douSumWeight == 0)
            { ColumnFSQWeight.Visible = false; }
            else
            { ColumnFSQWeight.Visible = true; }
            dgv1.Columns.Add(ColumnFSQWeight);

            DataGridViewTextBoxColumn ColumnFSQQty = new DataGridViewTextBoxColumn();
            ColumnFSQQty.HeaderText = "FSQQty";
            ColumnFSQQty.Width = 100;
            ColumnFSQQty.DataPropertyName = "FSQQty";
            ColumnFSQQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnFSQQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("FSQ");
            if (douSumQty == 0)
            { ColumnFSQQty.Visible = false; }
            else
            { ColumnFSQQty.Visible = true; }
            dgv1.Columns.Add(ColumnFSQQty);

            DataGridViewTextBoxColumn ColumnFYRWeight = new DataGridViewTextBoxColumn();
            ColumnFYRWeight.HeaderText = "FYRWeight";
            ColumnFYRWeight.Width = 100;
            ColumnFYRWeight.DataPropertyName = "FYRWeight";
            ColumnFYRWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnFYRWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("FYR");
            if (douSumWeight == 0)
            { ColumnFYRWeight.Visible = false; }
            else
            { ColumnFYRWeight.Visible = true; }
            dgv1.Columns.Add(ColumnFYRWeight);

            DataGridViewTextBoxColumn ColumnFYRQty = new DataGridViewTextBoxColumn();
            ColumnFYRQty.HeaderText = "FYRQty";
            ColumnFYRQty.Width = 100;
            ColumnFYRQty.DataPropertyName = "FYRQty";
            ColumnFYRQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnFYRQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("FYR");
            if (douSumQty == 0)
            { ColumnFYRQty.Visible = false; }
            else
            { ColumnFYRQty.Visible = true; }
            dgv1.Columns.Add(ColumnFYRQty);

            DataGridViewTextBoxColumn ColumnHeadMWeight = new DataGridViewTextBoxColumn();
            ColumnHeadMWeight.HeaderText = "HeadMWeight";
            ColumnHeadMWeight.Width = 100;
            ColumnHeadMWeight.DataPropertyName = "HeadMWeight";
            ColumnHeadMWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnHeadMWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("Head-M");
            if (douSumWeight == 0)
            { ColumnHeadMWeight.Visible = false; }
            else
            { ColumnHeadMWeight.Visible = true; }
            dgv1.Columns.Add(ColumnHeadMWeight);

            DataGridViewTextBoxColumn ColumnHeadMQty = new DataGridViewTextBoxColumn();
            ColumnHeadMQty.HeaderText = "HeadMQty";
            ColumnHeadMQty.Width = 100;
            ColumnHeadMQty.DataPropertyName = "HeadMQty";
            ColumnHeadMQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnHeadMQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("Head-M");
            if (douSumQty == 0)
            { ColumnHeadMQty.Visible = false; }
            else
            { ColumnHeadMQty.Visible = true; }
            dgv1.Columns.Add(ColumnHeadMQty);

            DataGridViewTextBoxColumn ColumnHeadSWeight = new DataGridViewTextBoxColumn();
            ColumnHeadSWeight.HeaderText = "HeadSWeight";
            ColumnHeadSWeight.Width = 100;
            ColumnHeadSWeight.DataPropertyName = "HeadSWeight";
            ColumnHeadSWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnHeadSWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("Head-S");
            if (douSumWeight == 0)
            { ColumnHeadSWeight.Visible = false; }
            else
            { ColumnHeadSWeight.Visible = true; }
            dgv1.Columns.Add(ColumnHeadSWeight);

            DataGridViewTextBoxColumn ColumnHeadSQty = new DataGridViewTextBoxColumn();
            ColumnHeadSQty.HeaderText = "HeadSQty";
            ColumnHeadSQty.Width = 100;
            ColumnHeadSQty.DataPropertyName = "HeadSQty";
            ColumnHeadSQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnHeadSQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("Head-S");
            if (douSumQty == 0)
            { ColumnHeadSQty.Visible = false; }
            else
            { ColumnHeadSQty.Visible = true; }
            dgv1.Columns.Add(ColumnHeadSQty);

            DataGridViewTextBoxColumn ColumnLINTMWeight = new DataGridViewTextBoxColumn();
            ColumnLINTMWeight.HeaderText = "LINTMWeight";
            ColumnLINTMWeight.Width = 100;
            ColumnLINTMWeight.DataPropertyName = "LINTMWeight";
            ColumnLINTMWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnLINTMWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("LINT-M");
            if (douSumWeight == 0)
            { ColumnLINTMWeight.Visible = false; }
            else
            { ColumnLINTMWeight.Visible = true; }
            dgv1.Columns.Add(ColumnLINTMWeight);

            DataGridViewTextBoxColumn ColumnLINTMQty = new DataGridViewTextBoxColumn();
            ColumnLINTMQty.HeaderText = "LINTMQty";
            ColumnLINTMQty.Width = 100;
            ColumnLINTMQty.DataPropertyName = "LINTMQty";
            ColumnLINTMQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnLINTMQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("LINT-M");
            if (douSumQty == 0)
            { ColumnLINTMQty.Visible = false; }
            else
            { ColumnLINTMQty.Visible = true; }
            dgv1.Columns.Add(ColumnLINTMQty);

            DataGridViewTextBoxColumn ColumnLINTSWeight = new DataGridViewTextBoxColumn();
            ColumnLINTSWeight.HeaderText = "LINTSWeight";
            ColumnLINTSWeight.Width = 100;
            ColumnLINTSWeight.DataPropertyName = "LINTSWeight";
            ColumnLINTSWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnLINTSWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("LINT-S");
            if (douSumWeight == 0)
            { ColumnLINTSWeight.Visible = false; }
            else
            { ColumnLINTSWeight.Visible = true; }
            dgv1.Columns.Add(ColumnLINTSWeight);

            DataGridViewTextBoxColumn ColumnLINTSQty = new DataGridViewTextBoxColumn();
            ColumnLINTSQty.HeaderText = "LINTSQty";
            ColumnLINTSQty.Width = 100;
            ColumnLINTSQty.DataPropertyName = "LINTSQty";
            ColumnLINTSQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnLINTSQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("LINT-S");
            if (douSumQty == 0)
            { ColumnLINTSQty.Visible = false; }
            else
            { ColumnLINTSQty.Visible = true; }
            dgv1.Columns.Add(ColumnLINTSQty);

            DataGridViewTextBoxColumn ColumnLUNGSMWeight = new DataGridViewTextBoxColumn();
            ColumnLUNGSMWeight.HeaderText = "LUNGSMWeight";
            ColumnLUNGSMWeight.Width = 100;
            ColumnLUNGSMWeight.DataPropertyName = "LUNGSMWeight";
            ColumnLUNGSMWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnLUNGSMWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("LUNGS-M");
            if (douSumWeight == 0)
            { ColumnLUNGSMWeight.Visible = false; }
            else
            { ColumnLUNGSMWeight.Visible = true; }
            dgv1.Columns.Add(ColumnLUNGSMWeight);

            DataGridViewTextBoxColumn ColumnLUNGSMQty = new DataGridViewTextBoxColumn();
            ColumnLUNGSMQty.HeaderText = "LUNGSMQty";
            ColumnLUNGSMQty.Width = 100;
            ColumnLUNGSMQty.DataPropertyName = "LUNGSMQty";
            ColumnLUNGSMQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnLUNGSMQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("LUNGS-M");
            if (douSumQty == 0)
            { ColumnLUNGSMQty.Visible = false; }
            else
            { ColumnLUNGSMQty.Visible = true; }
            dgv1.Columns.Add(ColumnLUNGSMQty);

            DataGridViewTextBoxColumn ColumnMCUWeight = new DataGridViewTextBoxColumn();
            ColumnMCUWeight.HeaderText = "MCUWeight";
            ColumnMCUWeight.Width = 100;
            ColumnMCUWeight.DataPropertyName = "MCUWeight";
            ColumnMCUWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnMCUWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("MCU");
            if (douSumWeight == 0)
            { ColumnMCUWeight.Visible = false; }
            else
            { ColumnMCUWeight.Visible = true; }
            dgv1.Columns.Add(ColumnMCUWeight);

            DataGridViewTextBoxColumn ColumnMCUQty = new DataGridViewTextBoxColumn();
            ColumnMCUQty.HeaderText = "MCUQty";
            ColumnMCUQty.Width = 100;
            ColumnMCUQty.DataPropertyName = "MCUQty";
            ColumnMCUQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnMCUQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("MCU");
            if (douSumQty == 0)
            { ColumnMCUQty.Visible = false; }
            else
            { ColumnMCUQty.Visible = true; }
            dgv1.Columns.Add(ColumnMCUQty);

            DataGridViewTextBoxColumn ColumnMFCWeight = new DataGridViewTextBoxColumn();
            ColumnMFCWeight.HeaderText = "MFCWeight";
            ColumnMFCWeight.Width = 100;
            ColumnMFCWeight.DataPropertyName = "MFCWeight";
            ColumnMFCWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnMFCWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("MFC");
            if (douSumWeight == 0)
            { ColumnMFCWeight.Visible = false; }
            else
            { ColumnMFCWeight.Visible = true; }
            dgv1.Columns.Add(ColumnMFCWeight);

            DataGridViewTextBoxColumn ColumnMFCQty = new DataGridViewTextBoxColumn();
            ColumnMFCQty.HeaderText = "MFCQty";
            ColumnMFCQty.Width = 100;
            ColumnMFCQty.DataPropertyName = "MFCQty";
            ColumnMFCQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnMFCQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("MFC");
            if (douSumQty == 0)
            { ColumnMFCQty.Visible = false; }
            else
            { ColumnMFCQty.Visible = true; }
            dgv1.Columns.Add(ColumnMFCQty);

            //start
            DataGridViewTextBoxColumn ColumnMFCAWeight = new DataGridViewTextBoxColumn();
            ColumnMFCAWeight.HeaderText = "MFCAWeight";
            ColumnMFCAWeight.Width = 100;
            ColumnMFCAWeight.DataPropertyName = "MFCAWeight";
            ColumnMFCAWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnMFCAWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("MFCA");
            if (douSumWeight == 0)
            { ColumnMFCAWeight.Visible = false; }
            else
            { ColumnMFCAWeight.Visible = true; }
            dgv1.Columns.Add(ColumnMFCAWeight);

            DataGridViewTextBoxColumn ColumnMFCAQty = new DataGridViewTextBoxColumn();
            ColumnMFCAQty.HeaderText = "MFCAQty";
            ColumnMFCAQty.Width = 100;
            ColumnMFCAQty.DataPropertyName = "MFCAQty";
            ColumnMFCAQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnMFCAQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("MFCA");
            if (douSumQty == 0)
            { ColumnMFCAQty.Visible = false; }
            else
            { ColumnMFCAQty.Visible = true; }
            dgv1.Columns.Add(ColumnMFCAQty);

            DataGridViewTextBoxColumn ColumnMSCWeight = new DataGridViewTextBoxColumn();
            ColumnMSCWeight.HeaderText = "MSCWeight";
            ColumnMSCWeight.Width = 100;
            ColumnMSCWeight.DataPropertyName = "MSCWeight";
            ColumnMSCWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnMSCWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("MSC");
            if (douSumWeight == 0)
            { ColumnMSCWeight.Visible = false; }
            else
            { ColumnMSCWeight.Visible = true; }
            dgv1.Columns.Add(ColumnMSCWeight);

            DataGridViewTextBoxColumn ColumnMSCQty = new DataGridViewTextBoxColumn();
            ColumnMSCQty.HeaderText = "MSCQty";
            ColumnMSCQty.Width = 100;
            ColumnMSCQty.DataPropertyName = "MSCQty";
            ColumnMSCQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnMSCQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("MSC");
            if (douSumQty == 0)
            { ColumnMSCQty.Visible = false; }
            else
            { ColumnMSCQty.Visible = true; }
            dgv1.Columns.Add(ColumnMSCQty);

            DataGridViewTextBoxColumn ColumnPROVMWeight = new DataGridViewTextBoxColumn();
            ColumnPROVMWeight.HeaderText = "PROVMWeight";
            ColumnPROVMWeight.Width = 100;
            ColumnPROVMWeight.DataPropertyName = "PROVMWeight";
            ColumnPROVMWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnPROVMWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("PROV-M");
            if (douSumWeight == 0)
            { ColumnPROVMWeight.Visible = false; }
            else
            { ColumnPROVMWeight.Visible = true; }
            dgv1.Columns.Add(ColumnPROVMWeight);

            DataGridViewTextBoxColumn ColumnPROVMQty = new DataGridViewTextBoxColumn();
            ColumnPROVMQty.HeaderText = "PROVMQty";
            ColumnPROVMQty.Width = 100;
            ColumnPROVMQty.DataPropertyName = "PROVMQty";
            ColumnPROVMQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnPROVMQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("PROV-M");
            if (douSumQty == 0)
            { ColumnPROVMQty.Visible = false; }
            else
            { ColumnPROVMQty.Visible = true; }
            dgv1.Columns.Add(ColumnPROVMQty);

            DataGridViewTextBoxColumn ColumnPROVSWeight = new DataGridViewTextBoxColumn();
            ColumnPROVSWeight.HeaderText = "PROVSWeight";
            ColumnPROVSWeight.Width = 100;
            ColumnPROVSWeight.DataPropertyName = "PROVSWeight";
            ColumnPROVSWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnPROVSWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("PROV-S");
            if (douSumWeight == 0)
            { ColumnPROVSWeight.Visible = false; }
            else
            { ColumnPROVSWeight.Visible = true; }
            dgv1.Columns.Add(ColumnPROVSWeight);

            DataGridViewTextBoxColumn ColumnPROVSQty = new DataGridViewTextBoxColumn();
            ColumnPROVSQty.HeaderText = "PROVSQty";
            ColumnPROVSQty.Width = 100;
            ColumnPROVSQty.DataPropertyName = "PROVSQty";
            ColumnPROVSQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnPROVSQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("PROV-S");
            if (douSumQty == 0)
            { ColumnPROVSQty.Visible = false; }
            else
            { ColumnPROVSQty.Visible = true; }
            dgv1.Columns.Add(ColumnPROVSQty);

            DataGridViewTextBoxColumn ColumnSINTMWeight = new DataGridViewTextBoxColumn();
            ColumnSINTMWeight.HeaderText = "SINTMWeight";
            ColumnSINTMWeight.Width = 100;
            ColumnSINTMWeight.DataPropertyName = "SINTMWeight";
            ColumnSINTMWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnSINTMWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("SINT-M");
            if (douSumWeight == 0)
            { ColumnSINTMWeight.Visible = false; }
            else
            { ColumnSINTMWeight.Visible = true; }
            dgv1.Columns.Add(ColumnSINTMWeight);

            DataGridViewTextBoxColumn ColumnSINTMQty = new DataGridViewTextBoxColumn();
            ColumnSINTMQty.HeaderText = "SINTMQty";
            ColumnSINTMQty.Width = 100;
            ColumnSINTMQty.DataPropertyName = "SINTMQty";
            ColumnSINTMQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnSINTMQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("SINT-M");
            if (douSumQty == 0)
            { ColumnSINTMQty.Visible = false; }
            else
            { ColumnSINTMQty.Visible = true; }
            dgv1.Columns.Add(ColumnSINTMQty);

            DataGridViewTextBoxColumn ColumnSINTSWeight = new DataGridViewTextBoxColumn();
            ColumnSINTSWeight.HeaderText = "SINTSWeight";
            ColumnSINTSWeight.Width = 100;
            ColumnSINTSWeight.DataPropertyName = "SINTSWeight";
            ColumnSINTSWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnSINTSWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("SINT-S");
            if (douSumWeight == 0)
            { ColumnSINTSWeight.Visible = false; }
            else
            { ColumnSINTSWeight.Visible = true; }
            dgv1.Columns.Add(ColumnSINTSWeight);

            DataGridViewTextBoxColumn ColumnSINTSQty = new DataGridViewTextBoxColumn();
            ColumnSINTSQty.HeaderText = "SINTSQty";
            ColumnSINTSQty.Width = 100;
            ColumnSINTSQty.DataPropertyName = "SINTSQty";
            ColumnSINTSQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnSINTSQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("SINT-S");
            if (douSumQty == 0)
            { ColumnSINTSQty.Visible = false; }
            else
            { ColumnSINTSQty.Visible = true; }
            dgv1.Columns.Add(ColumnSINTSQty);

            DataGridViewTextBoxColumn ColumnSpleenSWeight = new DataGridViewTextBoxColumn();
            ColumnSpleenSWeight.HeaderText = "SpleenSWeight";
            ColumnSpleenSWeight.Width = 100;
            ColumnSpleenSWeight.DataPropertyName = "SpleenSWeight";
            ColumnSpleenSWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnSpleenSWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("Spleen-S");
            if (douSumWeight == 0)
            { ColumnSpleenSWeight.Visible = false; }
            else
            { ColumnSpleenSWeight.Visible = true; }
            dgv1.Columns.Add(ColumnSpleenSWeight);

            DataGridViewTextBoxColumn ColumnSpleenSQty = new DataGridViewTextBoxColumn();
            ColumnSpleenSQty.HeaderText = "SpleenSQty";
            ColumnSpleenSQty.Width = 100;
            ColumnSpleenSQty.DataPropertyName = "SpleenSQty";
            ColumnSpleenSQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnSpleenSQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("Spleen-S");
            if (douSumQty == 0)
            { ColumnSpleenSQty.Visible = false; }
            else
            { ColumnSpleenSQty.Visible = true; }
            dgv1.Columns.Add(ColumnSpleenSQty);

            DataGridViewTextBoxColumn ColumnUBKWeight = new DataGridViewTextBoxColumn();
            ColumnUBKWeight.HeaderText = "UBKWeight";
            ColumnUBKWeight.Width = 100;
            ColumnUBKWeight.DataPropertyName = "UBKWeight";
            ColumnUBKWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnUBKWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("UBK");
            if (douSumWeight == 0)
            { ColumnUBKWeight.Visible = false; }
            else
            { ColumnUBKWeight.Visible = true; }
            dgv1.Columns.Add(ColumnUBKWeight);

            DataGridViewTextBoxColumn ColumnUBKQty = new DataGridViewTextBoxColumn();
            ColumnUBKQty.HeaderText = "UBKQty";
            ColumnUBKQty.Width = 100;
            ColumnUBKQty.DataPropertyName = "UBKQty";
            ColumnUBKQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnUBKQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("UBK");
            if (douSumQty == 0)
            { ColumnUBKQty.Visible = false; }
            else
            { ColumnUBKQty.Visible = true; }
            dgv1.Columns.Add(ColumnUBKQty);

            DataGridViewTextBoxColumn ColumnUBRWeight = new DataGridViewTextBoxColumn();
            ColumnUBRWeight.HeaderText = "UBRWeight";
            ColumnUBRWeight.Width = 100;
            ColumnUBRWeight.DataPropertyName = "UBRWeight";
            ColumnUBRWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnUBRWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("UBR");
            if (douSumWeight == 0)
            { ColumnUBRWeight.Visible = false; }
            else
            { ColumnUBRWeight.Visible = true; }
            dgv1.Columns.Add(ColumnUBRWeight);

            DataGridViewTextBoxColumn ColumnUBRQty = new DataGridViewTextBoxColumn();
            ColumnUBRQty.HeaderText = "UBRQty";
            ColumnUBRQty.Width = 100;
            ColumnUBRQty.DataPropertyName = "UBRQty";
            ColumnUBRQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnUBRQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("UBR");
            if (douSumQty == 0)
            { ColumnUBRQty.Visible = false; }
            else
            { ColumnUBRQty.Visible = true; }
            dgv1.Columns.Add(ColumnUBRQty);

            DataGridViewTextBoxColumn ColumnUDRWeight = new DataGridViewTextBoxColumn();
            ColumnUDRWeight.HeaderText = "UDRWeight";
            ColumnUDRWeight.Width = 100;
            ColumnUDRWeight.DataPropertyName = "UDRWeight";
            ColumnUDRWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnUDRWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("UDR");
            if (douSumWeight == 0)
            { ColumnUDRWeight.Visible = false; }
            else
            { ColumnUDRWeight.Visible = true; }
            dgv1.Columns.Add(ColumnUDRWeight);

            DataGridViewTextBoxColumn ColumnUDRQty = new DataGridViewTextBoxColumn();
            ColumnUDRQty.HeaderText = "UDRQty";
            ColumnUDRQty.Width = 100;
            ColumnUDRQty.DataPropertyName = "UDRQty";
            ColumnUDRQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnUDRQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("UDR");
            if (douSumQty == 0)
            { ColumnUDRQty.Visible = false; }
            else
            { ColumnUDRQty.Visible = true; }
            dgv1.Columns.Add(ColumnUDRQty);

            DataGridViewTextBoxColumn ColumnUGZWeight = new DataGridViewTextBoxColumn();
            ColumnUGZWeight.HeaderText = "UGZWeight";
            ColumnUGZWeight.Width = 100;
            ColumnUGZWeight.DataPropertyName = "UGZWeight";
            ColumnUGZWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnUGZWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("UGZ");
            if (douSumWeight == 0)
            { ColumnUGZWeight.Visible = false; }
            else
            { ColumnUGZWeight.Visible = true; }
            dgv1.Columns.Add(ColumnUGZWeight);

            DataGridViewTextBoxColumn ColumnUGZQty = new DataGridViewTextBoxColumn();
            ColumnUGZQty.HeaderText = "UGZQty";
            ColumnUGZQty.Width = 100;
            ColumnUGZQty.DataPropertyName = "UGZQty";
            ColumnUGZQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnUGZQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("UGZ");
            if (douSumQty == 0)
            { ColumnUGZQty.Visible = false; }
            else
            { ColumnUGZQty.Visible = true; }
            dgv1.Columns.Add(ColumnUGZQty);

            DataGridViewTextBoxColumn ColumnUNKWeight = new DataGridViewTextBoxColumn();
            ColumnUNKWeight.HeaderText = "UNKWeight";
            ColumnUNKWeight.Width = 100;
            ColumnUNKWeight.DataPropertyName = "UNKWeight";
            ColumnUNKWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnUNKWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("UNK");
            if (douSumWeight == 0)
            { ColumnUNKWeight.Visible = false; }
            else
            { ColumnUNKWeight.Visible = true; }
            dgv1.Columns.Add(ColumnUNKWeight);

            DataGridViewTextBoxColumn ColumnUNKQty = new DataGridViewTextBoxColumn();
            ColumnUNKQty.HeaderText = "UNKQty";
            ColumnUNKQty.Width = 100;
            ColumnUNKQty.DataPropertyName = "UNKQty";
            ColumnUNKQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnUNKQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("UNK");
            if (douSumQty == 0)
            { ColumnUNKQty.Visible = false; }
            else
            { ColumnUNKQty.Visible = true; }
            dgv1.Columns.Add(ColumnUNKQty);

            DataGridViewTextBoxColumn ColumnUTHWeight = new DataGridViewTextBoxColumn();
            ColumnUTHWeight.HeaderText = "UTHWeight";
            ColumnUTHWeight.Width = 100;
            ColumnUTHWeight.DataPropertyName = "UTHWeight";
            ColumnUTHWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnUTHWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("UTH");
            if (douSumWeight == 0)
            { ColumnUTHWeight.Visible = false; }
            else
            { ColumnUTHWeight.Visible = true; }
            dgv1.Columns.Add(ColumnUTHWeight);

            DataGridViewTextBoxColumn ColumnUTHQty = new DataGridViewTextBoxColumn();
            ColumnUTHQty.HeaderText = "UTHQty";
            ColumnUTHQty.Width = 100;
            ColumnUTHQty.DataPropertyName = "UTHQty";
            ColumnUTHQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnUTHQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("UTH");
            if (douSumQty == 0)
            { ColumnUTHQty.Visible = false; }
            else
            { ColumnUTHQty.Visible = true; }
            dgv1.Columns.Add(ColumnUTHQty);

            DataGridViewTextBoxColumn ColumnUWGWeight = new DataGridViewTextBoxColumn();
            ColumnUWGWeight.HeaderText = "UWGWeight";
            ColumnUWGWeight.Width = 100;
            ColumnUWGWeight.DataPropertyName = "UWGWeight";
            ColumnUWGWeight.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnUWGWeight.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("UWG");
            if (douSumWeight == 0)
            { ColumnUWGWeight.Visible = false; }
            else
            { ColumnUWGWeight.Visible = true; }
            dgv1.Columns.Add(ColumnUWGWeight);

            DataGridViewTextBoxColumn ColumnUWGQty = new DataGridViewTextBoxColumn();
            ColumnUWGQty.HeaderText = "UWGQty";
            ColumnUWGQty.Width = 100;
            ColumnUWGQty.DataPropertyName = "UWGQty";
            ColumnUWGQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnUWGQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ShowField("UWG");
            if (douSumQty == 0)
            { ColumnUWGQty.Visible = false; }
            else
            { ColumnUWGQty.Visible = true; }
            dgv1.Columns.Add(ColumnUWGQty);

            //Setting Data Source for DataGridView
            dgv1.DataSource = bindingSource;

            dgv1.Columns[3].DefaultCellStyle.Format = "N2"; dgv1.Columns[4].DefaultCellStyle.Format = "N2";
            dgv1.Columns[5].DefaultCellStyle.Format = "N2"; dgv1.Columns[6].DefaultCellStyle.Format = "N2";
            dgv1.Columns[7].DefaultCellStyle.Format = "N2"; dgv1.Columns[8].DefaultCellStyle.Format = "N2";
            dgv1.Columns[9].DefaultCellStyle.Format = "N2"; dgv1.Columns[10].DefaultCellStyle.Format = "N2";
            dgv1.Columns[11].DefaultCellStyle.Format = "N2"; dgv1.Columns[12].DefaultCellStyle.Format = "N2";
            dgv1.Columns[13].DefaultCellStyle.Format = "N2"; dgv1.Columns[14].DefaultCellStyle.Format = "N2";
            dgv1.Columns[15].DefaultCellStyle.Format = "N2"; dgv1.Columns[16].DefaultCellStyle.Format = "N2";
            dgv1.Columns[17].DefaultCellStyle.Format = "N2"; dgv1.Columns[18].DefaultCellStyle.Format = "N2";
            dgv1.Columns[19].DefaultCellStyle.Format = "N2"; dgv1.Columns[20].DefaultCellStyle.Format = "N2";
            dgv1.Columns[21].DefaultCellStyle.Format = "N2"; dgv1.Columns[22].DefaultCellStyle.Format = "N2";
            dgv1.Columns[23].DefaultCellStyle.Format = "N2"; dgv1.Columns[24].DefaultCellStyle.Format = "N2";
            dgv1.Columns[25].DefaultCellStyle.Format = "N2"; dgv1.Columns[26].DefaultCellStyle.Format = "N2";
            dgv1.Columns[27].DefaultCellStyle.Format = "N2"; dgv1.Columns[28].DefaultCellStyle.Format = "N2";
            dgv1.Columns[29].DefaultCellStyle.Format = "N2"; dgv1.Columns[30].DefaultCellStyle.Format = "N2";
            dgv1.Columns[31].DefaultCellStyle.Format = "N2"; dgv1.Columns[32].DefaultCellStyle.Format = "N2";
            dgv1.Columns[33].DefaultCellStyle.Format = "N2"; dgv1.Columns[34].DefaultCellStyle.Format = "N2";
            dgv1.Columns[35].DefaultCellStyle.Format = "N2"; dgv1.Columns[36].DefaultCellStyle.Format = "N2";
            dgv1.Columns[37].DefaultCellStyle.Format = "N2"; dgv1.Columns[38].DefaultCellStyle.Format = "N2";
            dgv1.Columns[39].DefaultCellStyle.Format = "N2"; dgv1.Columns[40].DefaultCellStyle.Format = "N2";
            dgv1.Columns[41].DefaultCellStyle.Format = "N2"; dgv1.Columns[42].DefaultCellStyle.Format = "N2";
            dgv1.Columns[43].DefaultCellStyle.Format = "N2"; dgv1.Columns[44].DefaultCellStyle.Format = "N2";
            dgv1.Columns[45].DefaultCellStyle.Format = "N2"; dgv1.Columns[46].DefaultCellStyle.Format = "N2";
            dgv1.Columns[47].DefaultCellStyle.Format = "N2"; dgv1.Columns[48].DefaultCellStyle.Format = "N2";
            dgv1.Columns[49].DefaultCellStyle.Format = "N2"; dgv1.Columns[50].DefaultCellStyle.Format = "N2";
            dgv1.Columns[51].DefaultCellStyle.Format = "N2"; dgv1.Columns[52].DefaultCellStyle.Format = "N2";
            dgv1.Columns[53].DefaultCellStyle.Format = "N2"; dgv1.Columns[54].DefaultCellStyle.Format = "N2";
            dgv1.Columns[55].DefaultCellStyle.Format = "N2"; dgv1.Columns[56].DefaultCellStyle.Format = "N2";
            dgv1.Columns[57].DefaultCellStyle.Format = "N2"; dgv1.Columns[58].DefaultCellStyle.Format = "N2";
            dgv1.Columns[59].DefaultCellStyle.Format = "N2"; dgv1.Columns[60].DefaultCellStyle.Format = "N2";
            dgv1.Columns[61].DefaultCellStyle.Format = "N2"; dgv1.Columns[62].DefaultCellStyle.Format = "N2";
            dgv1.Columns[63].DefaultCellStyle.Format = "N2"; dgv1.Columns[64].DefaultCellStyle.Format = "N2";
            dgv1.Columns[65].DefaultCellStyle.Format = "N2"; dgv1.Columns[66].DefaultCellStyle.Format = "N2";
            dgv1.Columns[67].DefaultCellStyle.Format = "N2"; dgv1.Columns[68].DefaultCellStyle.Format = "N2";
            dgv1.Columns[69].DefaultCellStyle.Format = "N2"; dgv1.Columns[70].DefaultCellStyle.Format = "N2";
            dgv1.Columns[71].DefaultCellStyle.Format = "N2"; dgv1.Columns[72].DefaultCellStyle.Format = "N2";
            dgv1.Columns[73].DefaultCellStyle.Format = "N2"; dgv1.Columns[74].DefaultCellStyle.Format = "N2";
            dgv1.Columns[75].DefaultCellStyle.Format = "N2"; dgv1.Columns[76].DefaultCellStyle.Format = "N2";
            dgv1.Columns[77].DefaultCellStyle.Format = "N2"; dgv1.Columns[78].DefaultCellStyle.Format = "N2";
            dgv1.Columns[79].DefaultCellStyle.Format = "N2"; dgv1.Columns[80].DefaultCellStyle.Format = "N2";
            dgv1.Columns[81].DefaultCellStyle.Format = "N2"; dgv1.Columns[82].DefaultCellStyle.Format = "N2";
            dgv1.Columns[83].DefaultCellStyle.Format = "N2"; dgv1.Columns[84].DefaultCellStyle.Format = "N2";
            dgv1.Columns[85].DefaultCellStyle.Format = "N2"; dgv1.Columns[86].DefaultCellStyle.Format = "N2";
            dgv1.Columns[87].DefaultCellStyle.Format = "N2"; dgv1.Columns[88].DefaultCellStyle.Format = "N2";
            dgv1.Columns[89].DefaultCellStyle.Format = "N2"; dgv1.Columns[90].DefaultCellStyle.Format = "N2";
            dgv1.Columns[91].DefaultCellStyle.Format = "N2"; dgv1.Columns[92].DefaultCellStyle.Format = "N2";

            //dgv1.Columns[0].Frozen = true;
            //dgv1.Columns[1].Frozen = true;
            //dgv1.Columns[2].Frozen = true;

            dgv1.AllowUserToAddRows = false;
        }

        public void ShowField(string strStockNumber)
        {
            try
            {

                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("Select SumWeight, SumQty FROM ViewShrinkageShow WHERE StockNumber='" + strStockNumber + "'", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();
                while (dr.Read())
                {
                    douSumWeight = double.Parse(dr["SumWeight"].ToString());
                    douSumQty = double.Parse(dr["SumQty"].ToString());
                }
                dr.Close();
                myconnection.Close();

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                //dr.Close();
                myconnection.Close();
            }
        }

    }
}
