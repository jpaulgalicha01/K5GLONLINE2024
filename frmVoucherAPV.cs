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
    public partial class frmVoucherAPV : Form
    {
        public static TextBox glbldocnum;
        ClsCompName ClsCompName1 = new ClsCompName();
        public static DataGridView glbldgv1;
        public static TextBox glbltxtdrtot, glbltxtcrtot, glbltxtDifference;
        string varoutdate = "No";

        SqlConnection myconnection;
        SqlCommand mycommand;
       // SqlDataReader dr;
        ClsAutoNumber ClsAutoNumber1 = new ClsAutoNumber();
        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();
        ClsBuildVoucherComboBox ClsBuildVoucherComboBox1 = new ClsBuildVoucherComboBox();
        ClsGetSomething ClsGetSomething1 = new ClsGetSomething();
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        ClsValidation ClsValidation1 = new ClsValidation();
        string dgvdata = null;
        ClsGetSomethingOthers ClsGetSomethingOthers1 = new ClsGetSomethingOthers();
        int varintTableDoor = 0;
        int number = 0;
        private string privarstrVoidIC = null;

        public frmVoucherAPV()
        {
            InitializeComponent();
            {
                ClsGetSomethingOthers1.ClsGetVoidRef("APV");
                privarstrVoidIC = ClsGetSomethingOthers1.plsVoidIC;
                if (new ClsValidation().emptytxt(privarstrVoidIC))
                { }
                else
                {
                    ClsGetSomethingOthers1.ClsDeleteErrorTransaction("APV");
                }
            }

        }

        private void frmVoucherAPV_Load(object sender, EventArgs e)
        {
            ClsPermission1.ClsObjects(this.Text);
            if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
            {
                MessageBox.Show("You do not have necessary permission to open this file", "GL");
                this.Close();
            }
            else
            {

                ClsAutoNumber1.VoucherAutoNum("APV");
                txtDocNum.Text = (ClsAutoNumber1.plsnumber);
                buildcboControlNo();
                buildcboPA();
                buildcboSalesman();
                glbldgv1 = dgv1;
                glbltxtdrtot = txtdrtot;
                glbltxtcrtot = txtcrtot;
                glbltxtDifference = txtDifference;
                ClsGetSomething1.ClsGetDefaultDate();
                txtTDate.Text = ClsGetSomething1.plsdefdate;
                txtVDate.Text = ClsGetSomething1.plsdefdate;
                privarstrVoidIC = null;
                ClsGetSomethingOthers1.ClsGetVoidRef("APV");
                privarstrVoidIC = ClsGetSomethingOthers1.plsVoidIC;
                if (new ClsValidation().emptytxt(privarstrVoidIC))
                { }
                else
                {
                    ClsGetSomethingOthers1.ClsDeleteErrorTransaction("APV");
                    privarstrVoidIC = null;
                }

            }
        }
        private void buildcboControlNo()
        {
            cboControlNo.DataSource = null;
            ClsBuildComboBox1.T.Clear();
            ClsBuildComboBox1.ClsBuildCVControlno();
            this.cboControlNo.DataSource = (ClsBuildComboBox1.T);
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

        private void buildcboSalesman()
        {
            ClsBuildVoucherComboBox1.ClsBuildSalesman();
            this.cboPC.DataSource = (ClsBuildVoucherComboBox1.ARLSLS);
            this.cboPC.DisplayMember = "Display";
            this.cboPC.ValueMember = "Value";
        }

        private void cboControlNo_Validating(object sender, CancelEventArgs e)
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
                }
        }

        private void dgv1total()
        {
            double vartxtdr = 0.00;
            double vartxtcr = 0.00;
            double vartxtdiff = 0.00;

            for (int x = 0; x < dgv1.Rows.Count - 1; x++)
            {
                vartxtdr += double.Parse(dgv1.Rows[x].Cells[4].FormattedValue.ToString());
            }

            for (int x = 0; x < dgv1.Rows.Count - 1; x++)
            {
                vartxtcr += double.Parse(dgv1.Rows[x].Cells[5].FormattedValue.ToString());
            }
            txtdrtot.Text = vartxtdr.ToString("n2");
            txtcrtot.Text = vartxtcr.ToString("n2");
            vartxtdiff = Convert.ToDouble(txtdrtot.Text) - Convert.ToDouble(txtcrtot.Text);
            txtDifference.Text = vartxtdiff.ToString("n2");
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

                ClsGetSomething1.ClsGetAT(row.Cells[0].Value.ToString());
                row.Cells[1].Value = ClsGetSomething1.plsAT;

                dgv1.CurrentRow.Cells[2].Value = txtreference.Text;
                dgv1.CurrentRow.Cells[3].Value = "NA";
                dgv1.CurrentRow.Cells[4].Value = "0.00";
                dgv1.CurrentRow.Cells[5].Value = "0.00";
                dgv1.CurrentRow.Cells[6].Value = 0;
                dgv1total();
            }
            else if (e.ColumnIndex == dgv1.Columns["txtdr"].Index)
            {
                this.dgv1.Rows[e.RowIndex].Cells[4].Value = double.Parse(dgv1.Rows[e.RowIndex].Cells[4].FormattedValue.ToString().Trim()).ToString("N2");
                dgv1total();
            }
            else if (e.ColumnIndex == dgv1.Columns["txtcr"].Index)
            {
                this.dgv1.Rows[e.RowIndex].Cells[5].Value = double.Parse(dgv1.Rows[e.RowIndex].Cells[5].FormattedValue.ToString().Trim()).ToString("N2");
                dgv1total();
            }
        }

     

        private void dgv1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //if (e.Control is DataGridViewComboBoxEditingControl)
            //{
            //    ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
            //    ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
            //    ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            //}
  
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
            if (e.ColumnIndex == dgv1.Columns["txtrefer"].Index)  //this is our numeric column
            {
                if (String.IsNullOrEmpty(e.FormattedValue.ToString()))// &&
                //dgv1[e.ColumnIndex, e.RowIndex].IsInEditMode)
                {
                    e.Cancel = true;
                    MessageBox.Show("Empty", "IS");
                }
            }
            if (e.ColumnIndex == dgv1.Columns["txtActRemarks"].Index)  //this is our numeric column
            {
                if (String.IsNullOrEmpty(e.FormattedValue.ToString()))// &&
                //dgv1[e.ColumnIndex, e.RowIndex].IsInEditMode)
                {
                    e.Cancel = true;
                    MessageBox.Show("Empty", "IS");
                }
            }

            else if (e.ColumnIndex == dgv1.Columns["txtDR"].Index)  //this is our numeric column
            {
                if (String.IsNullOrEmpty(e.FormattedValue.ToString()))// &&
                //dgv1[e.ColumnIndex, e.RowIndex].IsInEditMode)
                {
                    e.Cancel = true;
                    MessageBox.Show("Empty", "IS");
                }
                else
                {
                    double i;
                    if (!double.TryParse(Convert.ToString(e.FormattedValue), out i))
                    {
                        e.Cancel = true;
                        MessageBox.Show("Numeric only", "IS");
                    }
                }
            }

            else if (e.ColumnIndex == dgv1.Columns["txtCR"].Index)  //this is our numeric column
            {
                if (String.IsNullOrEmpty(e.FormattedValue.ToString()))// &&
                //dgv1[e.ColumnIndex, e.RowIndex].IsInEditMode)
                {
                    e.Cancel = true;
                    MessageBox.Show("Empty", "IS");
                }
                else
                {
                    double i;
                    if (!double.TryParse(Convert.ToString(e.FormattedValue), out i))
                    {
                        e.Cancel = true;
                        MessageBox.Show("Numeric only", "IS");
                    }
                }
            }
        }

        private void APVSave()
        {
            try
            {
                    ClsAutoNumber1.VoucherAutoNum("APV");
                    txtDocNum.Text = (ClsAutoNumber1.plsnumber);

                    string sqlstatement;
                    DateTime DT = DateTime.Now;
                    //  txtTStart.Text = DT.ToString();
                    sqlstatement = "INSERT INTO tblmain1 (IC, DocNum, Voucher, UserName, TDate, VDate, Reference, ControlNo, Remarks,  Term, Check#, CAmount, PC, DE, SONumber, PONum, CreditSales, CheckPayment, D1, D2, D3, RIVTransact, Void)";
                    sqlstatement += " Values (@_IC, @_DocNum, @_Voucher, @_UserName, @_TDate, @_VDate, @_Reference, @_ControlNo, @_Remarks,  @_Term, @_Check#, @_CAmount, @_PC, @_DE, @_SONumber, @_PONum, @_CreditSales, @_CheckPayment, @_D1, @_D2, @_D3, @_RIVTransact, @_Void)";
                    string sqlstatementdgv1 = "INSERT INTO tblmain3 (IC, Refer, ActRemarks, Debit, Credit, PA, RVRefer, SIT) Values (@_IC, @_Refer, @_ActRemarks, @_Debit, @_Credit, @_PA, @_RVRefer, @_SIT)";

                    ClsGetConnection1.ClsGetConMSSQL();
                    myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                    myconnection.Open();
                    
                    mycommand = new SqlCommand(sqlstatement, myconnection);
                    mycommand.Parameters.Add("_IC", SqlDbType.VarChar).Value = "APV" + Form1.glbluc.Text;
                    mycommand.Parameters.Add("_DocNum", SqlDbType.VarChar).Value = Form1.glbluc.Text;
                    mycommand.Parameters.Add("_Voucher", SqlDbType.VarChar).Value = "APV";
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
                    mycommand.Parameters.Add("_SONumber", SqlDbType.VarChar).Value = "APV" + txtDocNum.Text;
                    mycommand.Parameters.Add("_PONum", SqlDbType.VarChar).Value = "NA";
                    mycommand.Parameters.Add("_CreditSales", SqlDbType.Bit).Value = 0;
                    mycommand.Parameters.Add("_CheckPayment", SqlDbType.Bit).Value = 1;
                    mycommand.Parameters.Add("_D1", SqlDbType.Decimal).Value = 0;
                    mycommand.Parameters.Add("_D2", SqlDbType.Decimal).Value = 0;
                    mycommand.Parameters.Add("_D3", SqlDbType.Decimal).Value = 0;
                    mycommand.Parameters.Add("_RIVTransact", SqlDbType.Bit).Value = 0;
                    mycommand.Parameters.Add("_Void", SqlDbType.Bit).Value = 1;
                    mycommand.CommandTimeout = 600;    
                    int n1 = mycommand.ExecuteNonQuery();

                    DataGridViewRow row = null;
                    for (int x = 0; x < dgv1.Rows.Count - 1; x++)
                    {
                        row = dgv1.Rows[x];

                        mycommand = new SqlCommand(sqlstatementdgv1, myconnection);
                        mycommand.Parameters.Add("_IC", SqlDbType.VarChar).Value = "APV" + Form1.glbluc.Text;
                        mycommand.Parameters.Add("_Refer", SqlDbType.VarChar).Value = row.Cells[2].Value;
                        mycommand.Parameters.Add("_ActRemarks", SqlDbType.VarChar).Value = row.Cells[3].Value;
                        mycommand.Parameters.Add("_Debit", SqlDbType.Decimal).Value = row.Cells[4].Value;
                        mycommand.Parameters.Add("_Credit", SqlDbType.Decimal).Value = row.Cells[5].Value;
                        mycommand.Parameters.Add("_PA", SqlDbType.VarChar).Value = row.Cells[0].Value;
                        mycommand.Parameters.Add("_RVRefer", SqlDbType.VarChar).Value = "NA";
                        mycommand.Parameters.Add("_SIT", SqlDbType.Bit).Value = row.Cells[6].Value;
                        mycommand.CommandTimeout = 600;
                        int n2 = mycommand.ExecuteNonQuery();
                    }
                    myconnection.Close();
                    ClsGetSomethingOthers1.ClsFinalize("APV", txtDocNum.Text);
                    

                    if (cbSP.Checked)
                    {
                        printcurvoucher();
                    }


                    ClsAutoNumber1.VoucherAutoNum("APV");
                    txtDocNum.Text = (ClsAutoNumber1.plsnumber);

                    dgv1.Rows.Clear();
                    txtreference.Text = "";
                    cboControlNo.Text = "";
                    cboPC.Text = "";
                    txtTerm.Text = "0";
                    txtRemarks.Text = "";
                    txtTDate.Focus();
                    txtdrtot.Text = "0.00";
                    txtcrtot.Text = "0.00";
                    txtDifference.Text = "0.00";
                    dgvdata = null;
                    ClsGetSomething1.ClsGetDefaultDate();
                    txtTDate.Text = ClsGetSomething1.plsdefdate;
                    txtVDate.Text = ClsGetSomething1.plsdefdate;

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


        private void dgv1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            dgv1total();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
                double vartxtdrtot = double.Parse((txtdrtot.Text).ToString());
                double vartxtcrtot = double.Parse((txtcrtot.Text).ToString());

                for (int x = 0; x < dgv1.Rows.Count - 1; x++)
                {
                    dgvdata = (dgv1.Rows[x].Cells[0].FormattedValue.ToString());
                }

                ClsValidation1.securedateAccounting(DateTime.Parse(txtTDate.Text));
                varoutdate = (ClsValidation1.plsoutdate);

                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();

                if (new Clsexist().RecordExists(ref myconnection, "SELECT Reference FROM tblmain1 WHERE Reference ='" + txtreference.Text + "'"))
                {
                    myconnection.Close();
                    MessageBox.Show("Duplicate entry", "GL");
                    txtTDate.Focus();
                }
                else if (txtTDate.Text == "  /  /")
                {
                    MessageBox.Show("Please complete your entry", "GL");
                    txtTDate.Focus();
                }
                else if (txtVDate.Text == "  /  /")
                {
                    MessageBox.Show("Please complete your entry", "GL");
                    txtTDate.Focus();
                }

                else if (new ClsValidation().emptytxt (txtreference .Text))
                {
                    MessageBox.Show("Please complete your entry", "GL");
                    txtreference.Focus();
                }
           
                 else if (new ClsValidation().emptytxt(cboControlNo.Text))
                {
                    MessageBox.Show("Please complete your entry", "GL");
                    cboControlNo.Focus();
                }
                else if (new ClsValidation().emptytxt(txtRemarks.Text))
                {
                    MessageBox.Show("Please complete your entry", "GL");
                    txtRemarks.Focus();
                }
                else if (varoutdate == "Yes")
                {
                    myconnection.Close();
                    MessageBox.Show("Date is out of range", "GL");
                    txtTDate.Focus();
                }
                else if (vartxtdrtot != vartxtcrtot)
                {
                    MessageBox.Show("Not balance", "GL");
                    txtRemarks.Focus();
                }
                else if (new ClsValidation().emptytxt(dgvdata))
                {
                    MessageBox.Show("Incomplete Record", "GL");
                    txtTDate.Focus();
                }

                else
                {
                    myconnection.Close();
                    privarstrVoidIC = null;
                    ClsGetSomethingOthers1.ClsGetTDoor("APV");
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

                        ClsGetSomethingOthers1.ClsGetVoidRef("APV");
                        privarstrVoidIC = ClsGetSomethingOthers1.plsVoidIC;
                        if (new ClsValidation().emptytxt(privarstrVoidIC))
                        {
                            ClsGetSomethingOthers1.ClsOneTheDoor("APV");
                            APVSave();
                            ClsGetSomethingOthers1.ClsZeroTheDoor("APV");
                        }
                        else
                        {
                            ClsGetSomethingOthers1.ClsDeleteErrorTransaction("APV");
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
        private void printcurvoucher()
        {
            string sqlstatement;

            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();

            sqlstatement = "SELECT CustName, Reference, DocNum, TDate, Term, PA, TitleAcct, Debit, Credit, UserName, Remarks FROM viewbookapv WHERE DocNum ='" + txtDocNum.Text + "'";

            SqlDataAdapter dscmd = new SqlDataAdapter(sqlstatement, myconnection);
            dscmd.SelectCommand.CommandTimeout = 600;
            DSBooks dsplrv = new DSBooks();
            dscmd.Fill(dsplrv, "viewbookapv");
            myconnection.Close();


            CRprevapv objRpt = new CRprevapv();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            objRpt.SetDataSource(dsplrv.Tables[1]);
            //crystalReportViewer1.ReportSource = objRpt;
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

        private void nextfiledenter(object sender, KeyEventArgs e)
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
                    MessageBox.Show("Not found");
                    cboPC.Focus();
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

        private void txtreference_Validating(object sender, CancelEventArgs e)
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();

            if (new Clsexist().RecordExists(ref myconnection, "SELECT Reference FROM tblmain1 WHERE Reference ='" + txtreference.Text + "'"))
            {
                MessageBox.Show("Duplicate entry", "GL");
                txtreference.Focus();
            }
            myconnection.Close();

        }

        private void btnActGroup_Click(object sender, EventArgs e)
        {
            frmActGroupJV frmActGroupJV1 = new frmActGroupJV();
            frmActGroupJV1.Show();
            frmActGroupJV.glbltxtVoucher.Text = "APV";

        }

        private void btnVAT_Click(object sender, EventArgs e)
        {
            if (new ClsValidation().emptytxt (txtreference.Text))
            {
                MessageBox.Show("Please enter reference", "GL");
                txtreference.Focus();
            }
            else
            {
            frmVATEntry frmVATEntry1 = new frmVATEntry();
            frmVATEntry1.Show();
            frmVATEntry.glbltxtVoucher.Text = "APV";
            frmVATEntry.glbltxtrefer.Text = txtreference.Text;
            }
        }

        private void cbAccountNo_CheckedChanged(object sender, EventArgs e)
        {
            buildcboPA();
        }
       
    }
}
