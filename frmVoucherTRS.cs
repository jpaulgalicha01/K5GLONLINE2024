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
    public partial class frmVoucherTRS : Form
    {
        public static TextBox glbldocnum, glbltxtUnpdRefer;
        public static MaskedTextBox glbltxtTDate;
        public static TextBox glbltxtCostRef, glbltxtCost, glbltxtDeductDoc;
        public static ComboBox glblcboStockNumber, glblcboControlNo, glblcboAcctNo;
        string varoutdate = "No";
        ClsCompName ClsCompName1 = new ClsCompName();
        ClsGetSomething ClsGetSomething1 = new ClsGetSomething();
        SqlConnection myconnection;
        SqlCommand mycommand;
        SqlCommand mycommanddgv2;
        ClsAutoNumber ClsAutoNumber1 = new ClsAutoNumber();
        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();
        ClsBuildVoucherComboBox ClsBuildVoucherComboBox1 = new ClsBuildVoucherComboBox();
        ClsVariousFormula ClsVariousFormula1 = new ClsVariousFormula();
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsValidation ClsValidation1 = new ClsValidation();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        string dgvdata = null;
        private string pvsvaritem = null;
        ClsGetSomethingOthers ClsGetSomethingOthers1 = new ClsGetSomethingOthers();
        int varintTableDoor = 0;
        int number = 0;
        private string privarstrVoidIC = null;

        public frmVoucherTRS()
        {
            InitializeComponent();
            {
                ClsGetSomethingOthers1.ClsGetVoidRef("RTS");
                privarstrVoidIC = ClsGetSomethingOthers1.plsVoidIC;
                if (new ClsValidation().emptytxt(privarstrVoidIC))
                { }
                else
                {
                    ClsGetSomethingOthers1.ClsDeleteErrorTransaction("RTS");
                }
            }
        }

        private void frmVoucherTRS_Load(object sender, EventArgs e)
        {
            ClsPermission1.ClsObjects(this.Text);
            if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
            {
                MessageBox.Show("You do not have necessary permission to open this file", "GL");
                this.Close();
            }
            else
            {

                ClsAutoNumber1.VoucherAutoNum("RTS");
                txtDocNum.Text = (ClsAutoNumber1.plsnumber);
                buildcboWHCode();
                buildcboControlNo();
                buildcboAcctNo();
                buildcboSalesman();
                buildcboStocks();
                buildcboPA();
                ClsGetSomething1.ClsGetDefaultDate();
                txtTDate.Text = ClsGetSomething1.plsdefdate;
                txtVDate.Text = ClsGetSomething1.plsdefdate;
                cboAcctNo.SelectedValue = "3000000";
                glbltxtCost = txtCost;
                glbltxtCostRef = txtCostRef;
                glblcboStockNumber = cboStockNumber;
                glblcboControlNo = cboControlNo;
                glblcboAcctNo = cboAcctNo;
                glbltxtTDate = txtTDate;
                //glbltxtUnpdRefer = txtUnpdRefer;
                glbltxtDeductDoc = txtUnpdRefer;
                privarstrVoidIC = null;
                ClsGetSomethingOthers1.ClsGetVoidRef("RTS");
                privarstrVoidIC = ClsGetSomethingOthers1.plsVoidIC;
                if (new ClsValidation().emptytxt(privarstrVoidIC))
                { }
                else
                {
                    ClsGetSomethingOthers1.ClsDeleteErrorTransaction("RTS");
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
            ClsBuildComboBox1.ClsBuildClientControlno("S");
            this.cboControlNo.DataSource = (ClsBuildComboBox1.ARCCN);
            this.cboControlNo.DisplayMember = "Display";
            this.cboControlNo.ValueMember = "Value";
        }

        private void buildcboPA()
        {
            cboPA.DataSource = null;
            ClsBuildComboBox1.ARPA.Clear();
            ClsBuildComboBox1.ClsBuildPA(Convert.ToBoolean(cbAccountNo.CheckState));
            this.cboPA.DataSource = (ClsBuildComboBox1.ARPA);
            this.cboPA.DisplayMember = "Display";
            this.cboPA.ValueMember = "Value";
            this.cboPA.DropDownWidth = 450;
        }

        private void buildcboAcctNo()
        {
            cboAcctNo.DataSource = null;
            ClsBuildComboBox1.ARPA.Clear();
            ClsBuildComboBox1.ClsBuildPA(Convert.ToBoolean(cbAccountNo.CheckState));
            this.cboAcctNo.DataSource = (ClsBuildComboBox1.ARPA);
            this.cboAcctNo.DisplayMember = "Display";
            this.cboAcctNo.ValueMember = "Value";
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
            ClsBuildVoucherComboBox1.ARLSNPD.Clear();
            ClsBuildVoucherComboBox1.ClsBuildStocksPD(Convert.ToBoolean(cbSNEncode.CheckState), Convert.ToBoolean(cbPoulty.CheckState), cboControlNo.SelectedValue.ToString());
            this.cboStockNumber.DataSource = (ClsBuildVoucherComboBox1.ARLSNPD);
            this.cboStockNumber.DisplayMember = "Display";
            this.cboStockNumber.ValueMember = "Value";
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
                    buildcboStocks();
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

        private void dgv1total()
        {
            double vartxtdr = 0.00;
            double vartxtcr = 0.00;
            double vartxtdiff = 0.00;

            for (int x = 0; x < dgv1.Rows.Count - 1; x++)
            {
                vartxtdr += double.Parse(dgv1.Rows[x].Cells[2].FormattedValue.ToString());
            }

            for (int x = 0; x < dgv1.Rows.Count - 1; x++)
            {
                vartxtcr += double.Parse(dgv1.Rows[x].Cells[3].FormattedValue.ToString());
            }
            txtdrtot.Text = vartxtdr.ToString("n2");
            txtcrtot.Text = vartxtcr.ToString("n2");
            vartxtdiff = Convert.ToDouble(txtdrtot.Text) - Convert.ToDouble(txtcrtot.Text);
            txtDifference.Text = vartxtdiff.ToString("n2");
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

        private void dgv1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Clear the row error in case the user presses ESC.   
            dgv1.Rows[e.RowIndex].ErrorText = String.Empty;

            if (e.ColumnIndex == dgv1.Columns["cbopa"].Index)
            {
                string[] values = new string[1];
                DataGridViewRow row = dgv1.Rows[e.RowIndex];

                dgv1.CurrentRow.Cells[1].Value = txtreference.Text;

                dgv1.CurrentRow.Cells[2].Value = 0.00;
                dgv1.CurrentRow.Cells[3].Value = 0.00;
                dgv1total();
            }
            else if (e.ColumnIndex == dgv1.Columns["txtdr"].Index)
            {
                dgv1total();
            }

            else if (e.ColumnIndex == dgv1.Columns["txtcr"].Index)
            {
                dgv1total();
            }

        }

        private void trimValues(int rowIndex)
        {
            DataGridViewRow row = dgv1.Rows[rowIndex];

            row.Cells[2].Value = double.Parse(row.Cells[2].FormattedValue.ToString().Trim()).ToString("n2");
            row.Cells[3].Value = double.Parse(row.Cells[3].FormattedValue.ToString().Trim()).ToString("n2");
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

        private void dgv1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgv1.IsCurrentCellDirty)
            {
                dgv1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgv1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgv1.Columns["txtDR"].Index)  //this is our numeric column
            {
                if (String.IsNullOrEmpty(e.FormattedValue.ToString()))// &&
                //dgv1[e.ColumnIndex, e.RowIndex].IsInEditMode)
                {
                    e.Cancel = false;

                }

                else
                {
                    double i;
                    if (!double.TryParse(Convert.ToString(e.FormattedValue), out i))
                    {
                        e.Cancel = true;
                        MessageBox.Show("Numeric only");
                    }
                    else
                    {
                        trimValues(e.RowIndex);
                    }
                }
            }


            else if (e.ColumnIndex == dgv1.Columns["txtCR"].Index)  //this is our numeric column
            {
                if (String.IsNullOrEmpty(e.FormattedValue.ToString()))// &&
                //dgv1[e.ColumnIndex, e.RowIndex].IsInEditMode)
                {
                    e.Cancel = false;

                }

                else
                {
                    double i;
                    if (!double.TryParse(Convert.ToString(e.FormattedValue), out i))
                    {
                        e.Cancel = true;
                        MessageBox.Show("Numeric only");
                    }
                }
            }
        }

        private void dgv1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            string[] values = new string[4];
            DataGridViewRow row = dgv1.Rows[e.RowIndex];
            ClsValidatorforma ClsValidatorforma1 = null;

            values[0] = row.Cells[0].FormattedValue.ToString().Trim();
            values[1] = row.Cells[1].FormattedValue.ToString();
            values[2] = row.Cells[2].FormattedValue.ToString();
            values[3] = row.Cells[3].FormattedValue.ToString();

            if (!String.IsNullOrEmpty(values[0]) || !String.IsNullOrEmpty(values[1]) ||
       !String.IsNullOrEmpty(values[2]) || !String.IsNullOrEmpty(values[3])) 
            {

                ClsValidatorforma1 = new ClsValidatorforma(dgv1);

                ClsValidatorforma1.values(values);

                if (!ClsValidatorforma1.validate())
                    e.Cancel = true;
                else
                    trimValues(e.RowIndex);

            }

        }

        private void RSSave()
        {
            try
            {
                    ClsAutoNumber1.VoucherAutoNum("RTS");
                    txtDocNum.Text = (ClsAutoNumber1.plsnumber);
 
                    DateTime DT = DateTime.Now;
                    //  txtTStart.Text = DT.ToString();
                    string numStringD1 = txtD1.Text.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "");
                    float varfloatD1 = (float)(System.Convert.ToDouble(numStringD1) / 100);

                    string numStringD2 = txtD2.Text.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "");
                    float varfloatD2 = (float)(System.Convert.ToDouble(numStringD2) / 100);

                    string numStringD3 = txtD3.Text.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "");
                    float varfloatD3 = (float)(System.Convert.ToDouble(numStringD3) / 100);

                    ClsGetConnection1.ClsGetConMSSQL(); myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                    myconnection.Open();

                    string sqlstatement;
                    string sqlstatementdgv2;
                    sqlstatement = "INSERT INTO tblmain1 (IC, DocNum, Voucher, UserName, TDate, VDate, Reference, ControlNo, Remarks,  Term, Check#, CAmount, PC, DE, SONumber, PONum, CreditSales, CheckPayment, D1, D2, D3, RIVTransact, Void)";
                    sqlstatement += " Values (@_IC, @_DocNum, @_Voucher, @_UserName, @_TDate, @_VDate, @_Reference, @_ControlNo, @_Remarks,  @_Term, @_Check#, @_CAmount, @_PC, @_DE, @_SONumber, @_PONum, @_CreditSales, @_CheckPayment, @_D1, @_D2, @_D3, @_RIVTransact, @_Void)";
                    string sqlstatementdgv1 = "INSERT INTO tblmain3 (IC, Refer, ActRemarks, Debit, Credit, PA, RVRefer) Values (@_IC, @_Refer, @_ActRemarks, @_Debit, @_Credit, @_PA, @_RVRefer)";
                    sqlstatementdgv2 = "INSERT INTO tblmain2 (IC, StockNumber,  [In], Out, UP, Cost, VAT, ActDisct, PDisct, UM, WHCode, Num, OrderQty, ChickIn, ChickOut, RefforAC)";
                    sqlstatementdgv2 += "Values (@_IC, @_StockNumber,  @_In, @_Out, @_UP, @_Cost, @_VAT, @_ActDisct, @_PDisct, @_UM, @_WHCode, @_Num, @_OrderQty, @_ChickIn, @_ChickOut, @_RefforAC)";

                    mycommand = new SqlCommand(sqlstatement, myconnection);
                    mycommand.Parameters.Add("_IC", SqlDbType.VarChar).Value = "RTS" + Form1.glbluc.Text;
                    mycommand.Parameters.Add("_DocNum", SqlDbType.VarChar).Value = Form1.glbluc.Text;
                    mycommand.Parameters.Add("_Voucher", SqlDbType.VarChar).Value = "RTS";
                    mycommand.Parameters.Add("_UserName", SqlDbType.VarChar).Value = Form1.glbluc.Text;
                    mycommand.Parameters.Add("_TDate", SqlDbType.DateTime).Value = txtTDate.Text;
                    mycommand.Parameters.Add("_VDate", SqlDbType.DateTime).Value = txtVDate.Text;
                    mycommand.Parameters.Add("_Reference", SqlDbType.VarChar).Value = txtreference.Text;
                    mycommand.Parameters.Add("_ControlNo", SqlDbType.VarChar).Value = cboControlNo.SelectedValue;
                    mycommand.Parameters.Add("_Remarks", SqlDbType.VarChar).Value = txtRemarks.Text;
                    mycommand.Parameters.Add("_Term", SqlDbType.Int).Value = txtTerm.Text;
                    mycommand.Parameters.Add("_Check#", SqlDbType.VarChar).Value = "NA";
                    mycommand.Parameters.Add("_CAmount", SqlDbType.Decimal).Value = 0;
                    mycommand.Parameters.Add("_PC", SqlDbType.VarChar).Value = cboPC.SelectedValue; ;
                    mycommand.Parameters.Add("_DE", SqlDbType.DateTime).Value = DT;
                    mycommand.Parameters.Add("_SONumber", SqlDbType.VarChar).Value = "RTS" + txtDocNum.Text;
                    mycommand.Parameters.Add("_PONum", SqlDbType.VarChar).Value = "NA";
                    mycommand.Parameters.Add("_CreditSales", SqlDbType.Bit).Value = 0;
                    mycommand.Parameters.Add("_CheckPayment", SqlDbType.Bit).Value = 1;
                    mycommand.Parameters.Add("_D1", SqlDbType.Decimal).Value = varfloatD1;
                    mycommand.Parameters.Add("_D2", SqlDbType.Decimal).Value = varfloatD2;
                    mycommand.Parameters.Add("_D3", SqlDbType.Decimal).Value = varfloatD3;
                    mycommand.Parameters.Add("_RIVTransact", SqlDbType.Bit).Value = 0;
                    mycommand.Parameters.Add("_Void", SqlDbType.Bit).Value = 1;
                    mycommand.CommandTimeout = 600;
                    int n1 = mycommand.ExecuteNonQuery();

                    DataGridViewRow row = null;
                    for (int x = 0; x < dgv1.Rows.Count - 1; x++)
                    {
                        row = dgv1.Rows[x];

                        mycommand = new SqlCommand(sqlstatementdgv1, myconnection);
                        mycommand.Parameters.Add("_IC", SqlDbType.VarChar).Value = "RTS" + Form1.glbluc.Text;
                        mycommand.Parameters.Add("_Refer", SqlDbType.VarChar).Value = row.Cells[1].Value;
                        mycommand.Parameters.Add("_ActRemarks", SqlDbType.VarChar).Value = "NA";
                        mycommand.Parameters.Add("_Debit", SqlDbType.Decimal).Value = row.Cells[2].Value;
                        mycommand.Parameters.Add("_Credit", SqlDbType.Decimal).Value = row.Cells[3].Value;
                        mycommand.Parameters.Add("_PA", SqlDbType.VarChar).Value = row.Cells[0].Value;
                        mycommand.Parameters.Add("_RVRefer", SqlDbType.VarChar).Value = "NA";
                        mycommand.CommandTimeout = 600;
                        int n2 = mycommand.ExecuteNonQuery();
                    }

                    DataGridViewRow row1 = null;
                    for (int x = 0; x < dgv2.Rows.Count - 1; x++)
                    {
                        row1 = dgv2.Rows[x];
                        mycommanddgv2 = new SqlCommand(sqlstatementdgv2, myconnection);
                        mycommanddgv2.Parameters.Add("_IC", SqlDbType.VarChar).Value = "RTS" + Form1.glbluc.Text;
                        mycommanddgv2.Parameters.Add("_StockNumber", SqlDbType.VarChar).Value = row1.Cells[0].Value;
                        mycommanddgv2.Parameters.Add("_In", SqlDbType.Decimal).Value = row1.Cells[3].Value;
                        mycommanddgv2.Parameters.Add("_Out", SqlDbType.Decimal).Value = "0";
                        mycommanddgv2.Parameters.Add("_UP", SqlDbType.Decimal).Value = row1.Cells[5].Value;
                        mycommanddgv2.Parameters.Add("_Cost", SqlDbType.Decimal).Value = row1.Cells[10].Value;
                        mycommanddgv2.Parameters.Add("_VAT", SqlDbType.Decimal).Value = row1.Cells[8].Value;
                        mycommanddgv2.Parameters.Add("_ActDisct", SqlDbType.Decimal).Value = row1.Cells[6].Value;
                        mycommanddgv2.Parameters.Add("_PDisct", SqlDbType.Decimal).Value = row1.Cells[7].Value;
                        mycommanddgv2.Parameters.Add("_UM", SqlDbType.VarChar).Value = row1.Cells[4].Value;
                        mycommanddgv2.Parameters.Add("_WHCode", SqlDbType.VarChar).Value = cboWHCode.SelectedValue;
                        mycommanddgv2.Parameters.Add("_Num", SqlDbType.Int).Value = (Convert.ToInt64(x) + 1).ToString();
                        mycommanddgv2.Parameters.Add("_OrderQty", SqlDbType.Decimal).Value = "0";
                        mycommanddgv2.Parameters.Add("_ChickIn", SqlDbType.Decimal).Value = row1.Cells[2].Value;
                        mycommanddgv2.Parameters.Add("_ChickOut", SqlDbType.Decimal).Value = "0";
                        mycommanddgv2.Parameters.Add("_RefforAC", SqlDbType.VarChar).Value = row1.Cells[11].Value;
                        mycommanddgv2.CommandTimeout = 600;
                        int n3 = mycommanddgv2.ExecuteNonQuery();
                    }

                    myconnection.Close();
                    ClsGetSomethingOthers1.ClsFinalize("RTS", txtDocNum.Text);

                    if (cbSP.Checked)
                    {
                        printcurvoucher();
                    }

                    ClsAutoNumber1.VoucherAutoNum("RTS");
                    txtDocNum.Text = (ClsAutoNumber1.plsnumber);
                    clearscreen();
            }
            catch
            {
                MessageBox.Show("Error, please click OK", "GL");
                this.Close();
            }
            finally
            {
                //               dr.Close();
                myconnection.Close();
            }
        }

        private void clearscreen()
        {
            dgv1.Rows.Clear();
            dgv2.Rows.Clear();
            txtreference.Text = "";
            cboControlNo.Text = "";
            // txtCheckNo.Text = "NA";
            //  txtCAmount.Text = "0.00";
            txtTerm.Text = "0";
            txtD1.Text = "0.0%";
            txtD2.Text = "0.0%";
            txtD3.Text = "0.0%";
            cboAcctNo.SelectedValue = "1500000";
            cboPC.Text = "";
            txtCostRef.Text = "";
            txtRemarks.Text = "Return";
            txtTDate.Focus();
            txtdrtot.Text = "0.00";
            txtcrtot.Text = "0.00";
            txtDifference.Text = "0.00";
            txtTotSales.Text = "0.00";
            txtTotCost.Text = "0.00";
            txtTotVat.Text = "0.00";
            txtTotActDisct.Text = "0.00";
            txtTotPDisct.Text = "0.00";
            txtUnpdRefer.Text = "";
            txtQty.Text = "0";
            dgvdata = null;
            ClsGetSomething1.ClsGetDefaultDate();
            txtTDate.Text = ClsGetSomething1.plsdefdate;
            txtVDate.Text = ClsGetSomething1.plsdefdate;

        }
        private void getAcctEntry()
        {
            double vartotalDisct = Convert.ToDouble (txtTotActDisct.Text)+ Convert.ToDouble(txtTotPDisct.Text);
            double vartotalReceive = Convert.ToDouble(txtTotSales.Text) -  vartotalDisct;
            double vartotalSales = Convert.ToDouble(txtTotSales.Text) -  Convert.ToDouble(txtTotVat.Text);
            
            double vartotalVAT = Convert.ToDouble(txtTotVat.Text);
            double vartotalcost = Convert.ToDouble(txtTotCost.Text);

            //Receivable
            dgv1.Rows.Add(cboAcctNo.SelectedValue, txtUnpdRefer.Text, "0.00", vartotalReceive.ToString("N2"));
            //Vat Output
            dgv1.Rows.Add("2550000", txtreference.Text, "0.00", vartotalVAT.ToString("N2"));
            //Merchandise Inventory
            dgv1.Rows.Add("1850000", txtreference.Text, "0.00", vartotalcost.ToString("N2"));
            dgv1total();
        }

        private void dgv1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            dgv1total();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
                double vartxtdrtot = double.Parse((txtdrtot.Text).ToString());
                double vartxtcrtot = double.Parse((txtcrtot.Text).ToString());

                 for (int x = 0; x < dgv2.Rows.Count-1; x++)
                {
                dgvdata = (dgv2.Rows[x].Cells[0].FormattedValue.ToString());
                }

                if (cbPoulty.Checked)
                {
                    ClsValidation1.securedatepoultry(DateTime.Parse(txtTDate.Text));
                    varoutdate = (ClsValidation1.plsoutdate);
                }
                else
                {
                    ClsValidation1.securedatesales(DateTime.Parse(txtTDate.Text));
                    varoutdate = (ClsValidation1.plsoutdate);
                }


                dgv1.Rows.Clear();
                getAcctEntry();
                if (new Clsexist().RecordExists(ref myconnection, "SELECT Reference FROM tblmain1 WHERE Reference ='" + txtreference.Text + "'"))
                {
                    myconnection.Close();
                    dgv1.Rows.Clear();
                    MessageBox.Show("Duplicate entry", "GL");
                    txtTDate.Focus();
                }
                
                else if ((txtTDate.Text == "  /  /")|| (txtVDate.Text == "  /  /"))
                {
                    myconnection.Close();
                    dgv1.Rows.Clear();
                    MessageBox.Show("Please complete your entry", "GL");
                    txtTDate.Focus();
                }
                else if ((new ClsValidation().emptytxt (cboWHCode.Text))|| (new ClsValidation().emptytxt (txtreference .Text))||
                    (new ClsValidation().emptytxt(cboControlNo.Text))
                    || (new ClsValidation().emptytxt(cboAcctNo.Text)) || (new ClsValidation().emptytxt(txtUnpdRefer.Text))
                    ||(new ClsValidation().emptytxt (cboPC.Text))
                    ||(new ClsValidation().emptytxt (txtRemarks.Text)))
                {
                    myconnection.Close();
                    dgv1.Rows.Clear();
                    MessageBox.Show("Please complete your entry", "GL");
                    cboWHCode.Focus();
                }
              else if (Convert.ToDouble (txtDifference.Text)!=0)
                {
                    myconnection.Close();
                    dgv1.Rows.Clear();
                    MessageBox.Show("Not balance", "GL");
                    txtRemarks.Focus();
                }
                else if (varoutdate == "Yes")
                {
                    myconnection.Close();
                    dgv1.Rows.Clear();
                    MessageBox.Show("Date is out of range", "GL");
                    txtTDate.Focus();
                }
                else if (new ClsValidation().emptytxt(dgvdata))
                {
                    MessageBox.Show("Incomplete Record", "GL");
                    cboStockNumber.Focus();
                }
                else
                 {
                     myconnection.Close();
                    privarstrVoidIC = null;
                    ClsGetSomethingOthers1.ClsGetTDoor("RTS");
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

                        ClsGetSomethingOthers1.ClsGetVoidRef("RTS");
                        privarstrVoidIC = ClsGetSomethingOthers1.plsVoidIC;
                        if (new ClsValidation().emptytxt(privarstrVoidIC))
                        {
                            ClsGetSomethingOthers1.ClsOneTheDoor("RTS");
                            RSSave();
                            ClsGetSomethingOthers1.ClsZeroTheDoor("RTS");
                        }
                        else
                        {
                            ClsGetSomethingOthers1.ClsDeleteErrorTransaction("RTS");
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
            else
            {
                txtVDate.Text = txtTDate.Text;
            }
        }

        private void txtTerm_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().isInt (txtTerm.Text)==true )
            {
                MessageBox.Show("Invalid Number", "GL");
                txtTerm.Focus();
            }
        }

    
        private void printcurvoucher()
        {
            string sqlstatement;

            ClsGetConnection1.ClsGetConMSSQL(); myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();

            sqlstatement = "SELECT * FROM viewRS WHERE DocNum ='" + txtDocNum.Text + "'";

            SqlDataAdapter dscmd = new SqlDataAdapter(sqlstatement, myconnection);
            dscmd.SelectCommand.CommandTimeout = 600;
            DSBooks2 DSBooks21 = new DSBooks2();
            dscmd.Fill(DSBooks21, "viewRS");
            myconnection.Close();


            CRprevRS objRpt = new CRprevRS();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            objRpt.SetDataSource(DSBooks21.Tables[1]);

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
            double varfloatD1 = (float)(System.Convert.ToDouble(numStringD1)/100 );
        
            if (new ClsValidation().isDouble(numStringD1) == true)
            {
                MessageBox.Show("Invalid Number", "GL");
                txtD1.Focus();
            }
            else
            {
                txtD1.Text = Convert.ToDouble(varfloatD1).ToString("0.0%");
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

        private void cboAcctNo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (new ClsValidation().emptytxt(cboAcctNo.Text))
                {
                }
                else if (cboAcctNo.Text != null && cboAcctNo.SelectedValue == null)
                {
                    MessageBox.Show("Not found");
                    cboAcctNo.Focus();
                }
                else
                {
                    if (new ClsValidation().emptytxt(cboControlNo.Text))
                    {
                        MessageBox.Show("Name is empty", "GL");
                        cboControlNo.Focus();
                    }
                    else if (cboAcctNo.SelectedValue.ToString() == "1500000")
                    {
                        txtUnpdRefer.Text = "";
                        frmUnpaidARRS frmUnpaidARRS1 = new frmUnpaidARRS();
                        frmUnpaidARRS1.Show();
                    }
                    else
                    {
                        txtUnpdRefer.Text = txtreference.Text;
                    }
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
                    MessageBox.Show("Not found","GL");
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
                    txtQty.Text = "0";
                    getproductdetails();
                    getproductBalance();
                    ClsGetSomething1.ClsGetAveCost(Convert.ToDateTime(txtTDate.Text), cboStockNumber.SelectedValue.ToString(), Convert.ToBoolean(cbPoulty.CheckState), txtCostMethod.Text);
                    txtCost.Text = Convert.ToDouble (ClsGetSomething1.plsAveUC).ToString("N2");
                    if (cbPoulty.Checked && txtCostMethod.Text == "2")
                    {
                        frmActualCostRS frmActualCostRS1 = new frmActualCostRS();
                        frmActualCostRS1.Show(); 
                        txtCostRef.Text = "";
                    }
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
            if (Int32.Parse (txtIB.Text) == 0)
            {
                txtOrdQIB.Enabled = false;

                txtOrdQCS.Enabled = true;
                txtOrdQPC.Enabled = true;
            }
            else
            {
                txtOrdQIB.Enabled = true;

                txtOrdQCS.Enabled = true;
                txtOrdQPC.Enabled = true;

            }
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
        private void txtVDate_Leave(object sender, EventArgs e)
        {
            if (new ClsValidation().errordate(txtVDate.Text) == true)
            {
                MessageBox.Show("Invalid Date", "GL");
                txtVDate.Focus();
            }
        }

        private void txtD2_Validating(object sender, CancelEventArgs e)
        {
            string numStringD2 = txtD2.Text.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "");
            double varfloatD2 = (float)(System.Convert.ToDouble(numStringD2)/100);

            if (new ClsValidation().isDouble(numStringD2) == true)
            {
                MessageBox.Show("Invalid Number", "GL");
                txtD2.Focus();
            }
            else
            {
                txtD2.Text = Convert.ToDouble(varfloatD2).ToString("0.0%");
            }
        }

        private void txtD3_Validating(object sender, CancelEventArgs e)
        {
            string numStringD3 = txtD3.Text.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "");
            double varfloatD3 = (float)(System.Convert.ToDouble(numStringD3)/100);

            if (new ClsValidation().isDouble(numStringD3) == true)
            {
                MessageBox.Show("Invalid Number", "GL");
                txtD3.Focus();
            }
            else
            {
                txtD3.Text = Convert.ToDouble(varfloatD3).ToString("0.0%");
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
            if (new ClsValidation().isInt(txtQty.Text) == true)
            {
                MessageBox.Show("Invalid Number", "GL");
                txtQty.Focus();
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

        private void txtreference_Validating(object sender, CancelEventArgs e)
        {
            ClsGetConnection1.ClsGetConMSSQL(); myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();

            if (new Clsexist().RecordExists(ref myconnection, "SELECT Reference FROM tblmain1 WHERE Reference ='" + txtreference.Text + "'"))
            {
                MessageBox.Show("Duplicate entry", "GL");
                txtreference.Focus();
            }
            else
            {
                
            }
            myconnection.Close();
            
        }

        private void cbPoulty_CheckedChanged(object sender, EventArgs e)
        {
            //if (cbPoulty.Checked)
            //{
            //    txtOrdQCS.Enabled = true;
            //    txtOrdQIB.Enabled = false;
            //    txtOrdQPC.Enabled = false;
            //    txtUPCS.Enabled = true;
            //    txtUPIB.Enabled = true;
            //    txtUPPC.Enabled = true;
            //}
            //else
            //{
            //    txtOrdQCS.Enabled = true;
            //    txtOrdQIB.Enabled = false;
            //    txtOrdQPC.Enabled = true;
            //    txtUPCS.Enabled = false;
            //    txtUPIB.Enabled = false;
            //    txtUPPC.Enabled = false;

            //}
            if(cbPoulty.Checked == true)
            {
                txtUPCS.Enabled = true;
                //txtUPIB.Enabled = true;
                //txtUPPC.Enabled = true;
            }
            else
            {
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
            if (double.Parse(txtCost.Text) == 0)
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
                    float varfloatD1 = (float)(System.Convert.ToDouble(numStringD1) / 100);
                    string numStringD2 = txtD2.Text.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "");
                    float varfloatD2 = (float)(System.Convert.ToDouble(numStringD2) / 100);
                    string numStringD3 = txtD3.Text.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "");
                    float varfloatD3 = (float)(System.Convert.ToDouble(numStringD3) / 100);
                    double vargrosssales = (Convert.ToDouble(txtOrdQCS.Text) * Convert.ToDouble(txtUPCS.Text));
                    double varTotalCost = (Convert.ToDouble(txtOrdQCS.Text) * Convert.ToDouble(txtCost.Text));
                    ClsVariousFormula1.getActDisct(vargrosssales, varfloatD1, varfloatD2, varfloatD3);
                    txtActDisct.Text = Convert.ToDouble(ClsVariousFormula1.pldtotalactdisc).ToString("N2");
                    ClsGetSomething1.ClsGetVATRate();
                    ClsVariousFormula1.getVATAmt(Convert.ToBoolean(cbVAT.CheckState), Convert.ToDouble(ClsGetSomething1.plsVATRate), vargrosssales - (Convert.ToDouble(txtActDisct.Text) + Convert.ToDouble(txtPDisct.Text)));
                    string transactVATAmt = Convert.ToDouble(ClsVariousFormula1.pldbVAT).ToString("N2");
                    dgv2.Rows.Add(cboStockNumber.SelectedValue, pvsvaritem, txtQty.Text, txtOrdQCS.Text, "CS", txtUPCS.Text, txtActDisct.Text, txtPDisct.Text, transactVATAmt, vargrosssales.ToString("N2"), varTotalCost.ToString("N2"), txtCostRef.Text);
                    txtOrdQCS.Text = "0.00";
                    cboStockNumber.Text = "";
                    cboStockNumber.Focus();
                    dgv2total();
            }

            else if ((Convert.ToDouble(txtOrdQIB.Text) != 0) && ((cboStockNumber.Text) != ""))
            {
                txtCost.Text = (Convert.ToDouble(txtCost.Text) / Convert.ToInt32(txtIB.Text)).ToString("N2");
                string numStringD1 = txtD1.Text.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "");
                float varfloatD1 = (float)(System.Convert.ToDouble(numStringD1) / 100);
                string numStringD2 = txtD2.Text.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "");
                float varfloatD2 = (float)(System.Convert.ToDouble(numStringD2) / 100);
                string numStringD3 = txtD3.Text.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "");
                float varfloatD3 = (float)(System.Convert.ToDouble(numStringD3) / 100);
                double vargrosssales = (Convert.ToDouble(txtOrdQIB.Text) * Convert.ToDouble(txtUPIB.Text));
                double varTotalCost = (Convert.ToDouble(txtOrdQIB.Text) * Convert.ToDouble(txtCost.Text));
                ClsVariousFormula1.getActDisct(vargrosssales, varfloatD1, varfloatD2, varfloatD3);
                txtActDisct.Text = Convert.ToDouble(ClsVariousFormula1.pldtotalactdisc).ToString("N2");
                ClsGetSomething1.ClsGetVATRate();
                ClsVariousFormula1.getVATAmt(Convert.ToBoolean(cbVAT.CheckState), Convert.ToDouble(ClsGetSomething1.plsVATRate), vargrosssales - (Convert.ToDouble(txtActDisct.Text) + Convert.ToDouble(txtPDisct.Text)));
                string transactVATAmt = Convert.ToDouble(ClsVariousFormula1.pldbVAT).ToString("N2");
                dgv2.Rows.Add(cboStockNumber.SelectedValue, pvsvaritem, txtQty.Text, txtOrdQIB.Text, "IB", txtUPIB.Text, txtActDisct.Text, txtPDisct.Text, transactVATAmt, vargrosssales.ToString("N2"), varTotalCost.ToString("N2"), txtCostRef.Text);
                txtOrdQIB.Text = "0.00";
                cboStockNumber.Text = "";
                cboStockNumber.Focus();
                dgv2total();
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
                float varfloatD1 = (float)(System.Convert.ToDouble(numStringD1) / 100);
                string numStringD2 = txtD2.Text.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "");
                float varfloatD2 = (float)(System.Convert.ToDouble(numStringD2) / 100);
                string numStringD3 = txtD3.Text.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "");
                float varfloatD3 = (float)(System.Convert.ToDouble(numStringD3) / 100);
                double vargrosssales = (Convert.ToDouble(txtOrdQPC.Text) * Convert.ToDouble(txtUPPC.Text));
                double varTotalCost = (Convert.ToDouble(txtOrdQPC.Text) * varucost);
                ClsVariousFormula1.getActDisct(vargrosssales, varfloatD1, varfloatD2, varfloatD3);
                txtActDisct.Text = Convert.ToDouble(ClsVariousFormula1.pldtotalactdisc).ToString("N2");
                ClsGetSomething1.ClsGetVATRate();
                ClsVariousFormula1.getVATAmt(Convert.ToBoolean(cbVAT.CheckState), Convert.ToDouble(ClsGetSomething1.plsVATRate), vargrosssales - (Convert.ToDouble(txtActDisct.Text) + Convert.ToDouble(txtPDisct.Text)));
                string transactVATAmt = Convert.ToDouble(ClsVariousFormula1.pldbVAT).ToString("N2");
                dgv2.Rows.Add(cboStockNumber.SelectedValue, pvsvaritem, txtQty.Text, txtOrdQPC.Text, "PC", txtUPPC.Text, txtActDisct.Text, txtPDisct.Text, transactVATAmt, vargrosssales.ToString("N2"), varTotalCost.ToString("N2"), txtCostRef.Text);
                txtOrdQPC.Text = "0.00";
                cboStockNumber.Text = "";
                cboStockNumber.Focus();
                dgv2total();
            }
            txtQty.Text = "0";
        }

        private void frmVoucherTRS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                savetodgv();
            }
        }

        private void btnListAP_Click(object sender, EventArgs e)
        {
            frmIndPayablesRTS frmIndPayablesRTS1 = new frmIndPayablesRTS();
            frmIndPayablesRTS1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAcctEntry();
        }


     
      

        
    }
}
