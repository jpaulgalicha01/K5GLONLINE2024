using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using System.Threading;

namespace K5GLONLINE
{
    public partial class frmVoucherSOEdit : Form
    {
        public static DataGridView glbldgv2;
        public static TextBox glbltxtRemarks, glbldocnum, glbltxtPONum, glbltxtFldGuid, glbltxtTotNet, glbltxtPDisct, glbltxtTotVAT, glbltxtTotCost, glbltxtTotVat, glbltxtSPO, glbltxtTotActDisct, glbltxtDocNum, glbltxtTotPDisct, glbltxtTotSales, glbltxtreference, glbltxtTerm;
        public static ComboBox glblcboWHCode, glblcboPC, glblcboControlNo;
        public static MaskedTextBox glbltxtTDate;

        string varoutdate = "No";

        ClsCompName ClsCompName1 = new ClsCompName();
        ClsGetSomething ClsGetSomething1 = new ClsGetSomething();
        SqlConnection myconnection;
        SqlCommand mycommand;
        SqlCommand mycommanddgv2;
        SqlCommand mycommand3;

        ClsAutoNumber ClsAutoNumber1 = new ClsAutoNumber();
        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();
        ClsBuildVoucherComboBox ClsBuildVoucherComboBox1 = new ClsBuildVoucherComboBox();
        ClsVariousFormula ClsVariousFormula1 = new ClsVariousFormula();
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsValidation ClsValidation1 = new ClsValidation();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        ClsGetSomethingSO ClsGetSomethingSO1 = new ClsGetSomethingSO();
        ClsGetSomethingOthers ClsGetSomethingOthers1 = new ClsGetSomethingOthers();
        private string privarstrVoidIC = null;
        private string pvsvaritem = null;
        int varintTableDoor = 0;
        int number = 0;

        public frmVoucherSOEdit()
        {
            InitializeComponent();
            {
                ClsGetSomethingSO1.ClsGetVoidRef();
                privarstrVoidIC = ClsGetSomethingSO1.plsVoidIC;
                if (new ClsValidation().emptytxt(privarstrVoidIC))
                { }
                else
                {
                    ClsGetSomethingSO1.ClsDeleteErrorTransaction();
                }
            }
        }


        private void frmVoucherSOEdit_Load(object sender, EventArgs e)
        {
            ClsPermission1.ClsObjects(this.Text);
            if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
            {
                MessageBox.Show("You do not have necessary permission to open this file", "GL");
                this.Close();
            }
            else
            {
                glbldgv2 = dgv2;
                glblcboControlNo = cboControlNo;
                glblcboWHCode = cboWHCode;
                glblcboPC = cboPC;
                glbltxtPONum = txtPONum;
                glbltxtFldGuid = txtFldGuid;
                glbltxtTotNet = txtTotNet;
                glbltxtTotCost = txtTotCost;
                glbltxtTotVat = txtTotVat;
                glbltxtTotPDisct = txtPDisct;
                glbltxtTotActDisct = txtActDisct;
                glbltxtTotSales = txtTotSales;
                ClsGetSomething1.ClsGetDefaultDate();
                txtTDate.Text = ClsGetSomething1.plsdefdate;
                glbltxtTDate = txtTDate;
                glbltxtreference = txtreference;
                glbltxtTerm = txtTerm;
                glbltxtDocNum = txtDocNum;
                glbltxtSPO = txtSPO;
                glbltxtTotVAT = txtTotVat;
                glbltxtRemarks = txtRemarks;

                ClsAutoNumber1.VoucherAutoNumSO();
                txtDocNum.Text = (ClsAutoNumber1.plsnumber);
                buildcboWHCode();
                buildcboControlNo();
                buildcboSalesman();
                buildcboStocks();
                //cboStockNumber.SelectedValue = "";
                cboControlNo.SelectedValue = "";
                cboWHCode.SelectedValue = "000";
                privarstrVoidIC = null;
                ClsGetSomethingSO1.ClsGetVoidRef();
                privarstrVoidIC = ClsGetSomethingSO1.plsVoidIC;
                if (new ClsValidation().emptytxt(privarstrVoidIC))
                { }
                else
                {
                    ClsGetSomethingSO1.ClsDeleteErrorTransaction();
                    privarstrVoidIC = null;
                }
            }

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
            cboControlNo.DataSource = null;
            ClsBuildComboBox1.ARCCN.Clear();
            ClsBuildComboBox1.ClsBuildClientControlno("C");
            this.cboControlNo.DataSource = (ClsBuildComboBox1.ARCCN);
            this.cboControlNo.DisplayMember = "Display";
            this.cboControlNo.ValueMember = "Value";
        }


        private void buildcboSalesman()
        {
            ClsBuildVoucherComboBox1.ClsBuildSalesman();
            this.cboPC.DataSource = (ClsBuildVoucherComboBox1.ARLSLS);
            this.cboPC.DisplayMember = "Display";
            this.cboPC.ValueMember = "Value";
        }

        private void buildcboStocks()
        {
            cboStockNumber.DataSource = null;
            ClsBuildVoucherComboBox1.ARLSN.Clear();
            ClsBuildVoucherComboBox1.ClsBuildStocks(Convert.ToBoolean(cbSNEncode.CheckState), Convert.ToBoolean(cbPoulty.CheckState));
            this.cboStockNumber.DataSource = (ClsBuildVoucherComboBox1.ARLSN);
            this.cboStockNumber.DisplayMember = "Display";
            this.cboStockNumber.ValueMember = "Value";
            this.cboStockNumber.SelectedValue = "JCGG 360ml";
        }

        private void cboControlNo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (new ClsValidation().emptytxt(cboControlNo.Text))
                {
                }
                else if (cboControlNo.Text != null && cboControlNo.SelectedValue == null)
                {
                    MessageBox.Show("Not found");
                    cboControlNo.Focus();
                }
                else
                {
                    ClsGetSomething1.ClsGetCustData(cboControlNo.SelectedValue.ToString());
                    cboPC.SelectedValue = ClsGetSomething1.plsSLS;
                    txtTerm.Text = ClsGetSomething1.plsTerm;
                    txtSPO.Text = ClsGetSomething1.plsSPO;
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



        private void dgv2total()
        {
            double vartxttotactdisct = 0.00;
            double vartxttotpdisct = 0.00;
            double vartxttotvat = 0.00;
            double vartxttotsales = 0.00;
            double vartxttotcost = 0.00;

            for (int x = 0; x < dgv2.Rows.Count - 1; x++)
            {
                vartxttotactdisct += double.Parse(dgv2.Rows[x].Cells[6].FormattedValue.ToString());
            }
            txtTotActDisct.Text = vartxttotactdisct.ToString("n2");

            for (int x = 0; x < dgv2.Rows.Count - 1; x++)
            {
                vartxttotpdisct += double.Parse(dgv2.Rows[x].Cells[7].FormattedValue.ToString());
            }
            txtTotPDisct.Text = vartxttotpdisct.ToString("n2");

            for (int x = 0; x < dgv2.Rows.Count - 1; x++)
            {
                vartxttotvat += double.Parse(dgv2.Rows[x].Cells[8].FormattedValue.ToString());
            }
            txtTotVat.Text = vartxttotvat.ToString("n2");

            for (int x = 0; x < dgv2.Rows.Count - 1; x++)
            {
                vartxttotsales += double.Parse(dgv2.Rows[x].Cells[9].FormattedValue.ToString());
            }
            txtTotSales.Text = vartxttotsales.ToString("n2");

            for (int x = 0; x < dgv2.Rows.Count - 1; x++)
            {
                vartxttotcost += double.Parse(dgv2.Rows[x].Cells[10].FormattedValue.ToString());
            }
            txtTotCost.Text = vartxttotcost.ToString("n2");
            txtTotNet.Text = (double.Parse(txtTotSales.Text) - (double.Parse(txtTotActDisct.Text) + double.Parse(txtTotPDisct.Text))).ToString("N2");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void dgv1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            }

        }


        private void SaveTransact()
        {
            try
            {
                string sqlstatement;
                string sqlstatementdgv2;
                sqlstatement = "UPDATE tblMain6 SET Remarks = @_Remarks";
                sqlstatement += " WHERE DocNum = '" + txtDocNum.Text + "'";
                sqlstatementdgv2 = "INSERT INTO tblMain7 (DocNum, StockNumber,  Out, UP, Cost, VAT, ActDisct, PDisct, UM, Num, OrderQty)";
                sqlstatementdgv2 += "Values (@_DocNum, @_StockNumber,  @_Out, @_UP, @_Cost, @_VAT, @_ActDisct, @_PDisct, @_UM, @_Num, @_OrderQty)";

                string sqldel = "DELETE FROM tblMain7 WHERE DocNum = '" + txtDocNum.Text + "'";

                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();

                mycommand = new SqlCommand(sqlstatement, myconnection);
                //mycommand.Parameters.Add("_ControlNo", SqlDbType.VarChar).Value = cboControlNo.SelectedValue.ToString();
                mycommand.Parameters.Add("_Remarks", SqlDbType.VarChar).Value = txtRemarks.Text;
                //mycommand.Parameters.Add("_PONum", SqlDbType.VarChar).Value = txtPONum.Text;
                int n1 = mycommand.ExecuteNonQuery();

                mycommand = new SqlCommand(sqldel, myconnection);
                int nmsg1 = mycommand.ExecuteNonQuery();

                DataGridViewRow row1 = null;
                for (int x = 0; x < dgv2.Rows.Count-1; x++)
                {
                    row1 = dgv2.Rows[x];
                    mycommanddgv2 = new SqlCommand(sqlstatementdgv2, myconnection);
                    mycommanddgv2.Parameters.Add("_DocNum", SqlDbType.VarChar).Value = txtDocNum.Text;
                    mycommanddgv2.Parameters.Add("_StockNumber", SqlDbType.VarChar).Value = row1.Cells[0].Value;
                    mycommanddgv2.Parameters.Add("_Out", SqlDbType.Decimal).Value = row1.Cells[3].Value;
                    mycommanddgv2.Parameters.Add("_UP", SqlDbType.Decimal).Value = row1.Cells[5].Value;
                    mycommanddgv2.Parameters.Add("_Cost", SqlDbType.Decimal).Value = row1.Cells[10].Value;
                    mycommanddgv2.Parameters.Add("_VAT", SqlDbType.Decimal).Value = row1.Cells[8].Value;
                    mycommanddgv2.Parameters.Add("_ActDisct", SqlDbType.Decimal).Value = row1.Cells[6].Value;
                    mycommanddgv2.Parameters.Add("_PDisct", SqlDbType.Decimal).Value = row1.Cells[7].Value;
                    mycommanddgv2.Parameters.Add("_UM", SqlDbType.VarChar).Value = row1.Cells[4].Value;
                    mycommanddgv2.Parameters.Add("_Num", SqlDbType.Int).Value = (Convert.ToInt32(x) + 1).ToString();
                    mycommanddgv2.Parameters.Add("_OrderQty", SqlDbType.Decimal).Value = row1.Cells[2].Value;
                    int n2 = mycommanddgv2.ExecuteNonQuery();
                }
                myconnection.Close();
                clearscreen();
            }
            catch
            {
                MessageBox.Show("Error, please click OK", "GL");
                this.Close();
            }
            finally
            {
                myconnection.Close();
            }
        }

        private void clearscreen()
        {
            dgv2.Rows.Clear();
            txtreference.Text = "";
            cboControlNo.SelectedValue = "";
            txtTerm.Text = "0";
            txtD1.Text = "0.0%";
            txtD2.Text = "0.0%";
            txtD3.Text = "0.0%";
            cboPC.SelectedValue = "";
            txtRemarks.Text = "Sales on Account";
            txtTDate.Focus();
            txtTotSales.Text = "0.00";
            txtTotCost.Text = "0.00";
            txtTotVat.Text = "0.00";
            txtTotActDisct.Text = "0.00";
            txtTotPDisct.Text = "0.00";
            txtOQty.Text = "0";
            txtPONum.Text = "";
            cboWHCode.SelectedValue = "000";
            cboWHCode.Enabled = true;
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            ClsValidation1.securedatesales(DateTime.Parse(txtTDate.Text));
            varoutdate = (ClsValidation1.plsoutdate);
            if (dgv2.Rows.Count == 0)
            {
                myconnection.Close();
                MessageBox.Show("Incomplete product entry", "IS");
                txtTDate.Focus();
            }
            else
            {
                privarstrVoidIC = null;
                ClsGetSomethingOthers1.ClsGetTDoor("SO");
                varintTableDoor = int.Parse(ClsGetSomethingOthers1.plsTableDoor);
                number = 0;
                while (varintTableDoor == 1 && number <= 20)
                {
                    number = number + 1;
                    Thread.Sleep(200);
                    varintTableDoor = int.Parse(ClsGetSomethingOthers1.plsTableDoor);
                }

                if (varintTableDoor == 0 && number <= 20)
                {

                    ClsGetSomethingSO1.ClsGetVoidRef();
                    privarstrVoidIC = ClsGetSomethingSO1.plsVoidIC;
                    if (new ClsValidation().emptytxt(privarstrVoidIC))
                    {
                        ClsGetSomethingOthers1.ClsOneTheDoor("SO");
                        SaveTransact();
                        ClsGetSomethingOthers1.ClsZeroTheDoor("SO");
                    }
                    else
                    {
                        ClsGetSomethingSO1.ClsDeleteErrorTransaction();
                        MessageBox.Show("Transaction not saved", "GL");
                    }
                }
                else if (varintTableDoor == 1 && number == 21)
                {
                    MessageBox.Show("Contact your adminnistrator", "GL");
                }
            }
        }



        private void txtTDate_Leave(object sender, EventArgs e)
        {
            if (new ClsValidation().errordate(txtTDate.Text) == true)
            {
                MessageBox.Show("Invalid Date", "GL");
                txtTDate.Focus();
            }

        }

        private void txtTerm_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().isInt(txtTerm.Text) == true)
            {
                MessageBox.Show("Invalid Number", "GL");
                txtTerm.Focus();
            }
        }


        private void printcurvoucher()
        {
            //string sqlstatement;

            //ClsGetConnection1.ClsGetConMSSQL(); myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            //myconnection.Open();

            //sqlstatement = "SELECT DocNum, TDate, CustName, Term, Principal, IntRate, IntAmt, ProcessFee, Insurance, ServiceFee,";
            //sqlstatement += "Rebate, UserName, CheckNo, CAmount FROM ViewBookLOT WHERE DocNum ='" + frmVoucherLRV.glbldocnum.Text + "' AND CNCode = '" + (ClsDefaultBranch1.plsvardb) + "'";


            //SqlDataAdapter dscmd = new SqlDataAdapter(sqlstatement, myconnection);
            //dscmd.SelectCommand.CommandTimeout = 600;
            //DSBooks dsplot = new DSBooks();
            //dscmd.Fill(dsplot, "viewbooklot");
            //myconnection.Close();

            //CRprevlot objRpt = new CRprevlot();
            //TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            //vartxtcompany.Text = Form1.glblncompany.Text;

            //TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            ////vartxtaddress.Text = Form1.glbladdress.Text;
            //ClsCompName1.ClsCompNamebranch();
            //vartxtaddress.Text = (ClsCompName1.plsaddress);

            //objRpt.SetDataSource(dsplot.Tables[1]);
            //// objRpt.Refresh();
            ////  objRpt.PrintToPrinter(1, true, 0, 0);


            //System.Drawing.Printing.PrintDocument doctoprint = new System.Drawing.Printing.PrintDocument();
            ////doctoprint.PrinterSettings.PrinterName = "EPSON LX-300+ /II";
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
            //objRpt.Refresh();
            //objRpt.PrintToPrinter(1, false, 0, 0);

        }

        private void nextfieldenter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }



        private void txtLess1_Validating(object sender, CancelEventArgs e)
        {
            string numStringD1 = txtD1.Text.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "");
            double varfloatD1 = (double)(System.Convert.ToDouble(numStringD1) / 100);

            if (new ClsValidation().isDouble(numStringD1) == true)
            {
                MessageBox.Show("Invalid Number", "GL");
                txtD1.Focus();
            }
            else
            {
                txtD1.Text = Convert.ToDouble(varfloatD1).ToString("0.00%");
            }
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



        private void cboPC_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (new ClsValidation().emptytxt(cboPC.Text))
                {
                }
                else if (cboPC.Text != null && cboPC.SelectedValue == null)
                {
                    MessageBox.Show("Not found");
                    cboPC.Focus();
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

        private void cboStockNumber_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (new ClsValidation().emptytxt(cboStockNumber.Text))
                {
                }
                else if (cboStockNumber.Text != null && cboStockNumber.SelectedValue == null)
                {
                    MessageBox.Show("Not found", "GL");
                    cboStockNumber.Focus();
                }
                else if (new ClsValidation().emptytxt(cboWHCode.Text))
                {
                    MessageBox.Show("Warehouse is empty", "GL");
                    cboWHCode.Focus();
                }
                else
                {
                    txtOrdQCS.Text = "0.00";
                    txtOrdQIB.Text = "0.00";
                    txtOrdQPC.Text = "0.00";
                    txtOQty.Text = "0";
                    getproductdetails();
                    getproductBalance();
                    ClsGetSomething1.ClsGetAveCost(Convert.ToDateTime(txtTDate.Text), cboStockNumber.SelectedValue.ToString(), Convert.ToBoolean(cbPoulty.CheckState), txtCostMethod.Text);
                    txtCost.Text = Convert.ToDouble(ClsGetSomething1.plsAveUC).ToString("N2");
                    cboWHCode.Enabled = false;
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

        private void getproductdetails()
        {
            ClsGetSomething1.ClsGetProductDetails(cboStockNumber.SelectedValue.ToString(), txtSPO.Text);
            pvsvaritem = ClsGetSomething1.plsvarItem;
            txtIB.Text = ClsGetSomething1.plvarib;
            txtPiece.Text = ClsGetSomething1.plvarpiece;
            txtUPCS.Text = Convert.ToDouble(ClsGetSomething1.plvarSPPC).ToString("N2");
            txtUPIB.Text = Convert.ToDouble(ClsGetSomething1.plvarSPPI).ToString("N2");
            txtUPPC.Text = Convert.ToDouble(ClsGetSomething1.plvarSPPP).ToString("N2");
            txtCost.Text = Convert.ToDouble(ClsGetSomething1.plvarLC).ToString("N2");
            txtCostMethod.Text = ClsGetSomething1.plvarCostMethod;
            //if (Int32.Parse (txtIB.Text) == 0)
            //{
            //    txtOrdQIB.Enabled = false;
            //    txtOrdQCS.Enabled = true;
            //    txtOrdQPC.Enabled = true;
            //}
            //else
            //{
            //    txtOrdQIB.Enabled = true;
            //    txtOrdQCS.Enabled = true;
            //    txtOrdQPC.Enabled = true;
            //}
            //if (ClsGetSomething1.plbSellCS==false)
            //{
            //    txtOrdQCS.Enabled = false;
            //}
            //if (ClsGetSomething1.plbSellIB == false)
            //{
            //    txtOrdQIB.Enabled = false;
            //}
            //if (ClsGetSomething1.plbSellPC == false)
            //{
            //    txtOrdQPC.Enabled = false;
            //}

        }
        private void getproductBalance()
        {

            ClsGetSomething1.ClsGetPieceBal(cboWHCode.SelectedValue.ToString(), cboStockNumber.SelectedValue.ToString());
            double varprodbal1 = Convert.ToDouble(ClsGetSomething1.plvarbalance);
            ClsGetSomething1.ClsGetPieceBalunserve(cboWHCode.SelectedValue.ToString(), cboStockNumber.SelectedValue.ToString());
            double varprodbal2 = Convert.ToDouble(ClsGetSomething1.plvarbalanceunserve);
            txtTotPCBal.Text = (varprodbal1 - varprodbal2).ToString("N2");
            ClsGetSomething1.ClsGetConvertedPieceBal(double.Parse(txtTotPCBal.Text), int.Parse(txtIB.Text), int.Parse(txtPiece.Text));
            txtPCBalance.Text = Convert.ToDouble(ClsGetSomething1.plvarpiecebal).ToString("N2");
            txtIBBalance.Text = Convert.ToDouble(ClsGetSomething1.plvaribbal).ToString("N2");
            txtCSBalance.Text = Convert.ToDouble(ClsGetSomething1.plvarcsbal).ToString("N2");
        }

        private void dgv2_DoubleClick(object sender, EventArgs e)
        {
            if (dgv2.Rows.Count == 0) { }
            else
            {
                buildcboStocks();
                txtOQty.Enabled = true;
                cboStockNumber.SelectedValue = dgv2.CurrentRow.Cells[0].Value.ToString();
                if (dgv2.CurrentRow.Cells[4].Value.ToString() == "CS")
                {
                    txtOrdQCS.Text = dgv2.CurrentRow.Cells[3].Value.ToString();
                    txtOrdQCS.Enabled = true;
                }
                else if (dgv2.CurrentRow.Cells[4].Value.ToString() == "IB")
                {
                    txtOrdQIB.Text = dgv2.CurrentRow.Cells[3].Value.ToString();
                    txtOrdQIB.Enabled = true;
                }
                else if (dgv2.CurrentRow.Cells[4].Value.ToString() == "PC")
                {
                    txtOrdQPC.Text = dgv2.CurrentRow.Cells[3].Value.ToString();
                    txtOrdQPC.Enabled = true;
                }
                txtOQty.Text = dgv2.CurrentRow.Cells[2].Value.ToString();
                txtPDisct.Text = dgv2.CurrentRow.Cells[7].Value.ToString();
                getproductdetails();
                getproductBalance();
                ClsGetSomething1.ClsGetAveCost(Convert.ToDateTime(txtTDate.Text), cboStockNumber.SelectedValue.ToString(), Convert.ToBoolean(cbPoulty.CheckState), txtCostMethod.Text);
                txtCost.Text = Convert.ToDouble(ClsGetSomething1.plsAveUC).ToString("N2");
            }
        }

        private void cboStockNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            //getproductdetails();
            //getproductBalance();
            //ClsGetSomething1.ClsGetAveCost(Convert.ToDateTime(txtTDate.Text), cboStockNumber.SelectedValue.ToString(), Convert.ToBoolean(cbPoulty.CheckState), txtCostMethod.Text);
            //txtCost.Text = Convert.ToDouble(ClsGetSomething1.plsAveUC).ToString("N2");
        }

        private void cboStockNumber_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void txtD2_Validating(object sender, CancelEventArgs e)
        {
            string numStringD2 = txtD2.Text.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "");
            double varfloatD2 = (double)(System.Convert.ToDouble(numStringD2) / 100);

            if (new ClsValidation().isDouble(numStringD2) == true)
            {
                MessageBox.Show("Invalid Number", "GL");
                txtD2.Focus();
            }
            else
            {
                txtD2.Text = Convert.ToDouble(varfloatD2).ToString("0.00%");
            }
        }

        private void txtD3_Validating(object sender, CancelEventArgs e)
        {
            string numStringD3 = txtD3.Text.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "");
            double varfloatD3 = (double)(System.Convert.ToDouble(numStringD3) / 100);

            if (new ClsValidation().isDouble(numStringD3) == true)
            {
                MessageBox.Show("Invalid Number", "GL");
                txtD3.Focus();
            }
            else
            {
                txtD3.Text = Convert.ToDouble(varfloatD3).ToString("0.00%");
            }
        }

        private void txtOrdQCS_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().isDouble(txtOrdQCS.Text) == true)
            {
                MessageBox.Show("Invalid Number", "GL");
                txtOrdQCS.Focus();
            }
            else
            {
                txtOrdQCS.Text = Convert.ToDouble(txtOrdQCS.Text).ToString("N2");
                ClsGetSomething1.ClsGetConvertedToPieceQty(double.Parse(txtOrdQCS.Text), double.Parse(txtOrdQIB.Text), double.Parse(txtOrdQPC.Text), int.Parse(txtIB.Text), int.Parse(txtPiece.Text));
                txtTotalPCOrdered.Text = ClsGetSomething1.plsTotalPCOrdered;
            }

        }

        private void txtOrdQIB_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().isDouble(txtOrdQIB.Text) == true)
            {
                MessageBox.Show("Invalid Number", "GL");
                txtOrdQIB.Focus();
            }
            else
            {
                txtOrdQIB.Text = Convert.ToDouble(txtOrdQIB.Text).ToString("N2");
                ClsGetSomething1.ClsGetConvertedToPieceQty(double.Parse(txtOrdQCS.Text), double.Parse(txtOrdQIB.Text), double.Parse(txtOrdQPC.Text), int.Parse(txtIB.Text), int.Parse(txtPiece.Text));
                txtTotalPCOrdered.Text = ClsGetSomething1.plsTotalPCOrdered;

            }

        }

        private void txtORDQPC_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().isDouble(txtOrdQPC.Text) == true)
            {
                MessageBox.Show("Invalid Number", "GL");
                txtOrdQPC.Focus();
            }

            else
            {
                txtOrdQPC.Text = Convert.ToDouble(txtOrdQPC.Text).ToString("N2");
                ClsGetSomething1.ClsGetConvertedToPieceQty(double.Parse(txtOrdQCS.Text), double.Parse(txtOrdQIB.Text), double.Parse(txtOrdQPC.Text), int.Parse(txtIB.Text), int.Parse(txtPiece.Text));
                txtTotalPCOrdered.Text = ClsGetSomething1.plsTotalPCOrdered;

            }

        }

        private void txtUPPC_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().isDouble(txtUPPC.Text) == true)
            {
                MessageBox.Show("Invalid Number", "GL");
                txtUPPC.Focus();
            }
            else
            {
                txtUPPC.Text = Convert.ToDouble(txtUPPC.Text).ToString("N2");
            }
        }

        private void txtQty_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().isInt(txtOQty.Text) == true)
            {
                MessageBox.Show("Invalid Number", "GL");
                txtOQty.Focus();
            }
        }

        private void txtPDisct_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().isDouble(txtPDisct.Text) == true)
            {
                MessageBox.Show("Invalid Number", "GL");
                txtPDisct.Focus();
            }
            else
            {
                txtPDisct.Text = Convert.ToDouble(txtPDisct.Text).ToString("N2");
            }
        }

        private void txtUPCS_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().isDouble(txtUPCS.Text) == true)
            {
                MessageBox.Show("Invalid Number", "GL");
                txtUPCS.Focus();
            }
            else
            {
                txtUPCS.Text = Convert.ToDouble(txtUPCS.Text).ToString("N2");
            }
        }

        private void txtUPIB_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().isDouble(txtUPIB.Text) == true)
            {
                MessageBox.Show("Invalid Number", "GL");
                txtUPIB.Focus();
            }
            else
            {
                txtUPIB.Text = Convert.ToDouble(txtUPIB.Text).ToString("N2");
            }
        }



        private void dgv2_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            dgv2total();
        }


        private void cbPoulty_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPoulty.Checked)
            {
                txtOrdQCS.Enabled = true;
                txtOrdQIB.Enabled = false;
                txtOrdQPC.Enabled = false;
                txtUPCS.Enabled = true;
                txtUPIB.Enabled = true;
                txtUPPC.Enabled = true;
            }
            else
            {
                //txtOrdQCS.Enabled = true;
                txtOrdQCS.Enabled = false;
                txtOrdQIB.Enabled = false;
                //txtOrdQPC.Enabled = true;
                txtOrdQPC.Enabled = false;
                txtUPCS.Enabled = false;
                txtUPIB.Enabled = false;
                txtUPPC.Enabled = false;

            }
            buildcboStocks();

        }


        private void cbSNEncode_CheckedChanged(object sender, EventArgs e)
        {
            buildcboStocks();
        }

        private void savetodgv()
        {
            if (double.Parse(txtTotPCBal.Text) < double.Parse(txtTotalPCOrdered.Text))
            {
                MessageBox.Show("Quantity ordered is greater than inventory balance", "GL");
                cboStockNumber.Focus();
            }
            else if (double.Parse(txtCost.Text) == 0)
            {
                MessageBox.Show("Cost is zero", "GL");
                cboStockNumber.Focus();
            }
            else if (double.Parse(txtUPCS.Text) == 0 && double.Parse(txtOrdQCS.Text) != 0)
            {
                MessageBox.Show("Please check selling price CS", "GL");
                cboStockNumber.Focus();
            }

            else if (double.Parse(txtUPIB.Text) == 0 && double.Parse(txtOrdQIB.Text) != 0)
            {
                MessageBox.Show("Please check selling price IB", "GL");
                cboStockNumber.Focus();
            }

            else if (double.Parse(txtUPPC.Text) == 0 && double.Parse(txtOrdQPC.Text) != 0)
            {
                MessageBox.Show("Please check selling price PC", "GL");
                cboStockNumber.Focus();
            }

            else if ((Convert.ToDouble(txtOrdQCS.Text) != 0) && ((cboStockNumber.Text) != ""))
            {
                string numStringD1 = txtD1.Text.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "");
                double varfloatD1 = (double)(System.Convert.ToDouble(numStringD1) / 100);
                string numStringD2 = txtD2.Text.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "");
                double varfloatD2 = (double)(System.Convert.ToDouble(numStringD2) / 100);
                string numStringD3 = txtD3.Text.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "");
                double varfloatD3 = (double)(System.Convert.ToDouble(numStringD3) / 100);
                double vargrosssales = (Convert.ToDouble(txtOrdQCS.Text) * Convert.ToDouble(txtUPCS.Text));
                double varTotalCost = (Convert.ToDouble(txtOrdQCS.Text) * Convert.ToDouble(txtCost.Text));
                ClsVariousFormula1.getActDisct(vargrosssales, varfloatD1, varfloatD2, varfloatD3);
                txtActDisct.Text = Convert.ToDouble(ClsVariousFormula1.pldtotalactdisc).ToString("N2");
                ClsGetSomething1.ClsGetVATRate();
                ClsVariousFormula1.getVATAmt(Convert.ToBoolean(cbVAT.CheckState), Convert.ToDouble(ClsGetSomething1.plsVATRate), vargrosssales - (Convert.ToDouble(txtActDisct.Text) + Convert.ToDouble(txtPDisct.Text)));
                string transactVATAmt = Convert.ToDouble(ClsVariousFormula1.pldbVAT).ToString("N2");
                //dgv2.Rows.Add(cboStockNumber.SelectedValue, pvsvaritem, txtOQty.Text, txtOrdQCS.Text, "CS", txtUPCS.Text, txtActDisct.Text, txtPDisct.Text, transactVATAmt, vargrosssales.ToString("N2"), varTotalCost.ToString("N2"));
                //cboStockNumber.Focus();
                dgv2.CurrentRow.Cells[2].Value = txtOQty.Text;
                dgv2.CurrentRow.Cells[3].Value = txtOrdQCS.Text;
                dgv2.CurrentRow.Cells[6].Value = txtActDisct.Text;
                dgv2.CurrentRow.Cells[7].Value = txtPDisct.Text;
                dgv2.CurrentRow.Cells[8].Value = transactVATAmt;
                dgv2.CurrentRow.Cells[9].Value = vargrosssales.ToString("N2");
                dgv2.CurrentRow.Cells[10].Value = varTotalCost.ToString("N2");
                dgv2total();
                txtOrdQCS.Text = "0.00";
                cboStockNumber.Text = "";
            }

            else if ((Convert.ToDouble(txtOrdQIB.Text) != 0) && ((cboStockNumber.Text) != ""))
            {
                txtCost.Text = (Convert.ToDouble(txtCost.Text) / Convert.ToInt32(txtIB.Text)).ToString("N2");
                string numStringD1 = txtD1.Text.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "");
                double varfloatD1 = (double)(System.Convert.ToDouble(numStringD1) / 100);
                string numStringD2 = txtD2.Text.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "");
                double varfloatD2 = (double)(System.Convert.ToDouble(numStringD2) / 100);
                string numStringD3 = txtD3.Text.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "");
                double varfloatD3 = (double)(System.Convert.ToDouble(numStringD3) / 100);
                double vargrosssales = (Convert.ToDouble(txtOrdQIB.Text) * Convert.ToDouble(txtUPIB.Text));
                double varTotalCost = (Convert.ToDouble(txtOrdQIB.Text) * Convert.ToDouble(txtCost.Text));
                ClsVariousFormula1.getActDisct(vargrosssales, varfloatD1, varfloatD2, varfloatD3);
                txtActDisct.Text = Convert.ToDouble(ClsVariousFormula1.pldtotalactdisc).ToString("N2");
                ClsGetSomething1.ClsGetVATRate();
                ClsVariousFormula1.getVATAmt(Convert.ToBoolean(cbVAT.CheckState), Convert.ToDouble(ClsGetSomething1.plsVATRate), vargrosssales - (Convert.ToDouble(txtActDisct.Text) + Convert.ToDouble(txtPDisct.Text)));
                string transactVATAmt = Convert.ToDouble(ClsVariousFormula1.pldbVAT).ToString("N2");
                //dgv2.Rows.Add(cboStockNumber.SelectedValue, pvsvaritem, txtOQty.Text, txtOrdQIB.Text, "IB", txtUPIB.Text, txtActDisct.Text, txtPDisct.Text, transactVATAmt, vargrosssales.ToString("N2"), varTotalCost.ToString("N2"));

                //cboStockNumber.Focus();
                //dgv2total();
                dgv2.CurrentRow.Cells[2].Value = txtOQty.Text;
                dgv2.CurrentRow.Cells[3].Value = txtOrdQIB.Text;
                dgv2.CurrentRow.Cells[6].Value = txtActDisct.Text;
                dgv2.CurrentRow.Cells[7].Value = txtPDisct.Text;
                dgv2.CurrentRow.Cells[8].Value = transactVATAmt;
                dgv2.CurrentRow.Cells[9].Value = vargrosssales.ToString();
                dgv2.CurrentRow.Cells[10].Value = varTotalCost.ToString();
                dgv2total();
                txtOrdQIB.Text = "0.00";
                cboStockNumber.Text = "";
            }
            else if ((Convert.ToDouble(txtOrdQPC.Text) != 0) && ((cboStockNumber.Text) != ""))
            {
                double varucost;
                if (Convert.ToInt32(txtIB.Text) == 0)
                {
                    varucost = Convert.ToDouble(txtCost.Text) / Convert.ToInt32(txtPiece.Text);
                }
                else
                {
                    varucost = (Convert.ToDouble(txtCost.Text) / Convert.ToInt32(txtIB.Text)) / Convert.ToInt32(txtPiece.Text);
                }

                string numStringD1 = txtD1.Text.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "");
                double varfloatD1 = (double)(System.Convert.ToDouble(numStringD1) / 100);
                string numStringD2 = txtD2.Text.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "");
                double varfloatD2 = (double)(System.Convert.ToDouble(numStringD2) / 100);
                string numStringD3 = txtD3.Text.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "");
                double varfloatD3 = (double)(System.Convert.ToDouble(numStringD3) / 100);
                double vargrosssales = (Convert.ToDouble(txtOrdQPC.Text) * Convert.ToDouble(txtUPPC.Text));
                double varTotalCost = (Convert.ToDouble(txtOrdQPC.Text) * varucost);
                ClsVariousFormula1.getActDisct(vargrosssales, varfloatD1, varfloatD2, varfloatD3);
                txtActDisct.Text = Convert.ToDouble(ClsVariousFormula1.pldtotalactdisc).ToString("N2");
                ClsGetSomething1.ClsGetVATRate();
                ClsVariousFormula1.getVATAmt(Convert.ToBoolean(cbVAT.CheckState), Convert.ToDouble(ClsGetSomething1.plsVATRate), vargrosssales - (Convert.ToDouble(txtActDisct.Text) + Convert.ToDouble(txtPDisct.Text)));
                string transactVATAmt = Convert.ToDouble(ClsVariousFormula1.pldbVAT).ToString("N2");
                //dgv2.Rows.Add(cboStockNumber.SelectedValue, pvsvaritem, txtOQty.Text, txtOrdQPC.Text, "PC", txtUPPC.Text, txtActDisct.Text, txtPDisct.Text, transactVATAmt, vargrosssales.ToString("N2"), varTotalCost.ToString("N2"));

                //cboStockNumber.Focus();
                //dgv2total();
                dgv2.CurrentRow.Cells[2].Value = txtOQty.Text;
                dgv2.CurrentRow.Cells[3].Value = txtOrdQPC.Text;
                dgv2.CurrentRow.Cells[6].Value = txtActDisct.Text;
                dgv2.CurrentRow.Cells[7].Value = txtPDisct.Text;
                dgv2.CurrentRow.Cells[8].Value = transactVATAmt;
                dgv2.CurrentRow.Cells[9].Value = vargrosssales.ToString();
                dgv2.CurrentRow.Cells[10].Value = varTotalCost.ToString();
                dgv2total();
                txtOrdQPC.Text = "0.00";
                cboStockNumber.Text = "";
            }
            txtOQty.Text = "0";
            foreach (DataGridViewColumn column in dgv2.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void frmVoucherSOEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                savetodgv();
            }
        }

        private void btnSPTransct_Click(object sender, EventArgs e)
        {
            if (cboWHCode.SelectedValue == null)
            {
                MessageBox.Show("Please Select Warehouse!");
                cboWHCode.Focus();
            }
            else
            {
                dgv2.Rows.Clear();
                new frmShowSO().Show();
            }
        }
    }
}
