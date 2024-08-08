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
    public partial class frmVoucherOR : Form
    {
        public static TextBox glbldocnum;
        ClsCompName ClsCompName1 = new ClsCompName();
        
        SqlConnection myconnection;
        SqlCommand mycommand;
        //SqlDataReader dr;
        string varoutdate = "No";
        private SqlDataAdapter da;
        private DataTable dataTable = null;
        private BindingSource bindingSource = null;
        string dgvdata = null;
        ClsAutoNumber ClsAutoNumber1 = new ClsAutoNumber();
        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsValidation ClsValidation1 = new ClsValidation();
        ClsGetSomething ClsGetSomething1 = new ClsGetSomething();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        ClsBuildVoucherComboBox ClsBuildVoucherComboBox1 = new ClsBuildVoucherComboBox();
        ClsGetSomethingOthers ClsGetSomethingOthers1 = new ClsGetSomethingOthers();
        int varintTableDoor = 0;
        int number = 0;
        //private string pvsvaritem = null;
        private string privarstrVoidIC = null;

        public frmVoucherOR()
        {
            InitializeComponent();
            {
                ClsGetSomethingOthers1.ClsGetVoidRef("OR");
                privarstrVoidIC = ClsGetSomethingOthers1.plsVoidIC;
                if (new ClsValidation().emptytxt(privarstrVoidIC))
                { }
                else
                {
                    ClsGetSomethingOthers1.ClsDeleteErrorTransaction("OR");
                }
            }
        }

        private void frmVoucherOR_Load(object sender, EventArgs e)
        {
            ClsPermission1.ClsObjects(this.Text);
            if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
            {
                MessageBox.Show("You do not have necessary permission to open this file", "GL");
                this.Close();
            }
            else
            {

                ClsAutoNumber1.VoucherAutoNum("OR");
                txtDocNum.Text = (ClsAutoNumber1.plsnumber);
                ClsGetSomething1.ClsGetDefaultDate();
                txtTDate.Text = ClsGetSomething1.plsdefdate;
                txtVDate.Text = ClsGetSomething1.plsdefdate;
                buildcboControlNo();
                buildcboPA();
                buildcboSalesman();
                privarstrVoidIC = null;
                ClsGetSomethingOthers1.ClsGetVoidRef("OR");
                privarstrVoidIC = ClsGetSomethingOthers1.plsVoidIC;
                if (new ClsValidation().emptytxt(privarstrVoidIC))
                { }
                else
                {
                    ClsGetSomethingOthers1.ClsDeleteErrorTransaction("OR");
                    privarstrVoidIC = null;
                }

            }
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
            cboPC.DataSource = null;
            ClsBuildVoucherComboBox1.ARLSLS.Clear();
            ClsBuildVoucherComboBox1.ClsBuildSalesman();
            this.cboPC.DataSource = (ClsBuildVoucherComboBox1.ARLSLS);
            this.cboPC.DisplayMember = "Display";
            this.cboPC.ValueMember = "Value";

        }
        private void buildShowCustBalance()
        {
            dgvListReceive.DataSource = null;
            dgvListReceive.Columns.Clear();

            string sqlstatement;
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            sqlstatement = "SELECT Refer, MinDate, Bal FROM ViewIndAccount WHERE MinDate <= '" + txtTDate.Text + "' AND  ControlNo='" + cboControlNo.SelectedValue.ToString() + "'";
            
            da = new SqlDataAdapter(sqlstatement, myconnection);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
            da.SelectCommand.CommandTimeout = 600;
            dataTable = new DataTable();
            da.Fill(dataTable);
            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;

            //Adding  Reference TextBox
            DataGridViewTextBoxColumn ColumnReference = new DataGridViewTextBoxColumn();
            ColumnReference.HeaderText = "Reference";
            ColumnReference.Width = 150;
            ColumnReference.DataPropertyName = "Refer";
            ColumnReference.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //ColumnReference.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //ColumnReference.Visible = false;
            ColumnReference.ReadOnly = true;
            dgvListReceive.Columns.Add(ColumnReference);

            //Adding  TDate TextBox
            DataGridViewTextBoxColumn ColumnTDate = new DataGridViewTextBoxColumn();
            ColumnTDate.HeaderText = "Date";
            ColumnTDate.Width = 150;
            ColumnTDate.DataPropertyName = "MinDate";
            //ColumnTDate.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //ColumnTDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //ColumnTDate.Visible = false;
            ColumnTDate.ReadOnly = true;
            dgvListReceive.Columns.Add(ColumnTDate);

            //Adding  Balance TextBox
            DataGridViewTextBoxColumn ColumnBalance = new DataGridViewTextBoxColumn();
            ColumnBalance.HeaderText = "Balance";
            ColumnBalance.Width = 150;
            ColumnBalance.DataPropertyName = "Bal";
            //ColumnBalance.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnBalance.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnBalance.ReadOnly = true;
            dgvListReceive.Columns.Add(ColumnBalance);

            //dgvListReceive.Columns[0].Name = "RVRefer";
            //dgvListReceive.Columns[1].Name = "TDate";
            //dgvListReceive.Columns[2].Name = "Balance";
            //Setting Data Source for DataGridView
            dgvListReceive.DataSource = bindingSource;
            //            dgvListReceive.AutoResizeColumns();
            //            dgvListReceive.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            myconnection.Close();
            //            this.WindowState = FormWindowState.Maximized;
            //dgvListReceive.AllowUserToAddRows = false;
            dgvListReceive.Columns[2].DefaultCellStyle.Format = "N2";
            dgvListReceive.Columns[1].DefaultCellStyle.Format = "MM/dd/yyyy";
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
                    cboControlNo.Enabled = false;
                    dgv1.Rows.Clear();
                    buildShowCustBalance();
                    //buildlv();
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
                vartxtdr += double.Parse(dgv1.Rows[x].Cells[3].FormattedValue.ToString());
            }

            for (int x = 0; x < dgv1.Rows.Count - 1; x++)
            {
                vartxtcr += double.Parse(dgv1.Rows[x].Cells[4].FormattedValue.ToString());
            }
            txtdrtot.Text = vartxtdr.ToString("n2");
            txtcrtot.Text = vartxtcr.ToString("n2");
            vartxtdiff = Convert.ToDouble(txtdrtot.Text) - Convert.ToDouble(txtcrtot.Text);
            txtDifference.Text = vartxtdiff.ToString("n2");
            txtCDiff.Text = ((double.Parse(txtDifference.Text)*-1) - double.Parse(txtCAmount.Text)).ToString("N2");

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
                dgv1.CurrentRow.Cells[3].Value = "0.00";
                dgv1.CurrentRow.Cells[4].Value = "0.00";
                dgv1.CurrentRow.Cells[5].Value = 0;
                dgv1total();
            }
            else if (e.ColumnIndex == dgv1.Columns["txtdr"].Index)
            {
                this.dgv1.Rows[e.RowIndex].Cells[3].Value = double.Parse(dgv1.Rows[e.RowIndex].Cells[3].FormattedValue.ToString().Trim()).ToString("N2");
                dgv1total();
            }

            else if (e.ColumnIndex == dgv1.Columns["txtcr"].Index)
            {
                this.dgv1.Rows[e.RowIndex].Cells[4].Value = double.Parse(dgv1.Rows[e.RowIndex].Cells[4].FormattedValue.ToString().Trim()).ToString("N2");
                dgv1total();
            }


        }

        //private void trimValues(int rowIndex)
        //{
        //    DataGridViewRow row = dgv1.Rows[rowIndex];

        //    row.Cells[4].Value = double.Parse(row.Cells[2].FormattedValue.ToString().Trim()).ToString("n2");
        //    row.Cells[3].Value = double.Parse(row.Cells[3].FormattedValue.ToString().Trim()).ToString("n2");
        //}

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
            string[] values = new string[5];
            DataGridViewRow row = dgv1.Rows[e.RowIndex];
            ClsValidatorforma ClsValidatorforma1 = null;

            values[0] = row.Cells[0].FormattedValue.ToString().Trim();
            values[1] = row.Cells[1].FormattedValue.ToString();
            values[2] = row.Cells[2].FormattedValue.ToString();
            values[3] = row.Cells[3].FormattedValue.ToString();
            values[4] = row.Cells[4].FormattedValue.ToString();

            if (!String.IsNullOrEmpty(values[0]) || !String.IsNullOrEmpty(values[1]) ||
       !String.IsNullOrEmpty(values[2]) || !String.IsNullOrEmpty(values[3]) || !String.IsNullOrEmpty(values[4])) 
            {

                ClsValidatorforma1 = new ClsValidatorforma(dgv1);

                ClsValidatorforma1.values(values);

                if (!ClsValidatorforma1.validate())
                    e.Cancel = true;
                //else
                //    trimValues(e.RowIndex);

            }

        }

        private void getSLSEntry()
        {
           // double varslsCollection = Convert.ToDouble(txtDifference.Text)*-1;
            
            //Salesman Collection
            ClsGetSomething1.ClsGetAT("1150000");
            dgv1.Rows.Add("1150000", ClsGetSomething1.plsAT, txtreference.Text, txtCAmount.Text, "0.00", 0);
            dgv1total();

        }





        private void ORSave()
        {
            try
            {
                ClsAutoNumber1.VoucherAutoNum("OR");
                txtDocNum.Text = (ClsAutoNumber1.plsnumber);
                string sqlstatement;
                DateTime DT = DateTime.Now;
                //  txtTStart.Text = DT.ToString();
                sqlstatement = "INSERT INTO tblmain1 (IC, DocNum, Voucher, UserName, TDate, VDate, Reference, ControlNo, Remarks,  Term, Check#, CAmount, PC, DE, SONumber, PONum, CreditSales, CheckPayment, D1, D2, D3, RIVTransact, PoultryTransact, Void)";
                sqlstatement += " Values (@_IC, @_DocNum, @_Voucher, @_UserName, @_TDate, @_VDate, @_Reference, @_ControlNo, @_Remarks,  @_Term, @_Check#, @_CAmount, @_PC, @_DE, @_SONumber, @_PONum, @_CreditSales, @_CheckPayment, @_D1, @_D2, @_D3, @_RIVTransact, @_PoultryTransact, @_Void)";
                string sqlstatementdgv1 = "INSERT INTO tblmain3 (IC, Refer, ActRemarks, Debit, Credit, PA, RVRefer) Values (@_IC, @_Refer, @_ActRemarks, @_Debit, @_Credit, @_PA, @_RVRefer)";

                ClsGetConnection1.ClsGetConMSSQL(); myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();

                mycommand = new SqlCommand(sqlstatement, myconnection);
                mycommand.Parameters.Add("_IC", SqlDbType.VarChar).Value = "OR" + Form1.glbluc.Text;
                mycommand.Parameters.Add("_DocNum", SqlDbType.VarChar).Value = Form1.glbluc.Text;
                mycommand.Parameters.Add("_Voucher", SqlDbType.VarChar).Value = "OR";
                mycommand.Parameters.Add("_UserName", SqlDbType.VarChar).Value = Form1.glbluc.Text;
                mycommand.Parameters.Add("_TDate", SqlDbType.DateTime).Value = txtTDate.Text;
                mycommand.Parameters.Add("_VDate", SqlDbType.DateTime).Value = txtVDate.Text;
                mycommand.Parameters.Add("_Reference", SqlDbType.VarChar).Value = txtreference.Text;
                mycommand.Parameters.Add("_ControlNo", SqlDbType.VarChar).Value = cboControlNo.SelectedValue;
                mycommand.Parameters.Add("_Remarks", SqlDbType.VarChar).Value = txtRemarks.Text;
                mycommand.Parameters.Add("_Term", SqlDbType.Int).Value = 0;
                mycommand.Parameters.Add("_Check#", SqlDbType.VarChar).Value = txtCheckNo.Text;
                mycommand.Parameters.Add("_CAmount", SqlDbType.Decimal).Value = txtCAmount.Text;
                mycommand.Parameters.Add("_PC", SqlDbType.VarChar).Value = cboPC.SelectedValue; ;
                mycommand.Parameters.Add("_DE", SqlDbType.DateTime).Value = DT;
                mycommand.Parameters.Add("_SONumber", SqlDbType.VarChar).Value = "OR" + txtDocNum.Text;
                mycommand.Parameters.Add("_PONum", SqlDbType.VarChar).Value = "NA";
                mycommand.Parameters.Add("_CreditSales", SqlDbType.Bit).Value = 0;
                mycommand.Parameters.Add("_CheckPayment", SqlDbType.Bit).Value = cbCPay.CheckState;
                mycommand.Parameters.Add("_D1", SqlDbType.Decimal).Value = 0;
                mycommand.Parameters.Add("_D2", SqlDbType.Decimal).Value = 0;
                mycommand.Parameters.Add("_D3", SqlDbType.Decimal).Value = 0;
                mycommand.Parameters.Add("_RIVTransact", SqlDbType.Bit).Value = 0;
                mycommand.Parameters.Add("_PoultryTransact", SqlDbType.Bit).Value = 0;
                mycommand.Parameters.Add("_Void", SqlDbType.Bit).Value = 1;
                mycommand.CommandTimeout = 600;
                int n1 = mycommand.ExecuteNonQuery();

                DataGridViewRow row = null;
                for (int x = 0; x < dgv1.Rows.Count - 1; x++)
                {
                    row = dgv1.Rows[x];
                    mycommand = new SqlCommand(sqlstatementdgv1, myconnection);
                    mycommand.Parameters.Add("_IC", SqlDbType.VarChar).Value = "OR" + Form1.glbluc.Text;
                    mycommand.Parameters.Add("_Refer", SqlDbType.VarChar).Value = row.Cells[2].Value;
                    mycommand.Parameters.Add("_ActRemarks", SqlDbType.VarChar).Value = "NA";
                    mycommand.Parameters.Add("_Debit", SqlDbType.Decimal).Value = row.Cells[3].Value;
                    mycommand.Parameters.Add("_Credit", SqlDbType.Decimal).Value = row.Cells[4].Value;
                    mycommand.Parameters.Add("_PA", SqlDbType.VarChar).Value = row.Cells[0].Value;
                    mycommand.Parameters.Add("_RVRefer", SqlDbType.VarChar).Value = "NA";
                    mycommand.CommandTimeout = 600;
                    int n2 = mycommand.ExecuteNonQuery();

                }
                myconnection.Close();
                ClsGetSomethingOthers1.ClsFinalize("OR", txtDocNum.Text);
                    
                if (cbSP.Checked)
                {
                    printcurvoucher();
                }


                ClsAutoNumber1.VoucherAutoNum("OR");
                txtDocNum.Text = (ClsAutoNumber1.plsnumber);

                dgv1.Rows.Clear();
                txtreference.Text = "";
                txtCheckNo.Text = "";
                txtCAmount.Text = "0.00";
                cboControlNo.Text = "";
                cboPC.Text = "";
                txtRemarks.Text = "Collection";
                txtTDate.Focus();
                txtdrtot.Text = "0.00";
                txtcrtot.Text = "0.00";
                txtDifference.Text = "0.00";
                cboControlNo.Enabled = true;
                dgvListReceive.DataSource = null;
                dgvListReceive.Columns.Clear();
                creatcolumn();
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

        private void creatcolumn()
        {
            var ColReference = new DataGridViewTextBoxColumn();
            var ColTDate = new DataGridViewTextBoxColumn();
            var ColBal = new DataGridViewTextBoxColumn();
            
            ColReference.HeaderText = "Reference";
            ColReference.Name = "ColumnReference";
            ColReference.Width = 150;

            ColTDate.HeaderText = "Date";
            ColTDate.Name = "ColumnTDate";
            ColTDate.Width = 150;

            ColBal.HeaderText = "Balance";
            ColBal.Name = "ColumnBalance";
            ColBal.Width = 150;

            dgvListReceive.Columns.AddRange(new DataGridViewColumn[] { ColReference, ColTDate, ColBal });

        }
        private void dgv1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            dgv1total();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
                getSLSEntry();
                double vartxtdrtot = double.Parse((txtdrtot.Text).ToString());
                double vartxtcrtot = double.Parse((txtcrtot.Text).ToString());

                for (int x = 0; x < dgv1.Rows.Count-1; x++)
                {
                    dgvdata = (dgv1.Rows[x].Cells[0].FormattedValue.ToString());
                }

                 ClsValidation1.securedateAccounting(DateTime.Parse(txtTDate.Text));
                varoutdate = (ClsValidation1.plsoutdate);


                ClsGetConnection1.ClsGetConMSSQL(); myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();


                if (new Clsexist().RecordExists(ref myconnection, "SELECT Reference FROM tblmain1 WHERE Reference ='" + txtreference.Text + "'"))
                {
                    myconnection.Close();
                    MessageBox.Show("Duplicate entry", "GL");
                    txtTDate.Focus();
                }

                else if ((txtTDate.Text == "  /  /") || (txtVDate.Text == "  /  /"))
                {
                    MessageBox.Show("Please complete your entry", "GL");
                    txtTDate.Focus();
                }
                else if (new ClsValidation().emptytxt(txtreference.Text))
                {
                    MessageBox.Show("Please complete your entry", "GL");
                    txtreference.Focus();
                }
                else if (new ClsValidation().emptytxt(txtCheckNo.Text))
                {
                    MessageBox.Show("Please complete your entry", "GL");
                    txtCheckNo.Focus();
                }

                else if (new ClsValidation().emptytxt(txtCAmount.Text))
                {
                    MessageBox.Show("Please complete your entry", "GL");
                    txtCAmount.Focus();
                }

                else if (new ClsValidation().emptytxt(cboControlNo.Text))
                {
                    MessageBox.Show("Please complete your entry", "GL");
                    cboControlNo.Focus();
                }
                else if (new ClsValidation().emptytxt(cboPC.Text))
                {
                    MessageBox.Show("Please complete your entry", "GL");
                    cboPC.Focus();
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
                //else if (double.Parse(txtCDiff .Text) != 0)
                {
                    MessageBox.Show("Not balance", "GL");
                    txtRemarks.Focus();
                }
                else if (new ClsValidation().emptytxt(dgvdata))
                {
                    MessageBox.Show("Incomplete Record", "IS");
                    txtTDate.Focus();
                }

                else
                {
                    return;
                    myconnection.Close();
                    privarstrVoidIC = null;
                    ClsGetSomethingOthers1.ClsGetTDoor("OR");
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

                        ClsGetSomethingOthers1.ClsGetVoidRef("OR");
                        privarstrVoidIC = ClsGetSomethingOthers1.plsVoidIC;
                        if (new ClsValidation().emptytxt(privarstrVoidIC))
                        {
                            ClsGetSomethingOthers1.ClsOneTheDoor("OR");
                            ORSave();
                            ClsGetSomethingOthers1.ClsZeroTheDoor("OR");
                        }
                        else
                        {
                            ClsGetSomethingOthers1.ClsDeleteErrorTransaction("OR");
                            MessageBox.Show("Transaction not saved", "GL");
                        }

                    }
                    else if (varintTableDoor == 1 && number == 21)
                    {
                        MessageBox.Show("Contact your adminnistrator", "GL");
                    }
                }

        }

        private void txtCAmount_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().isDouble(txtCAmount.Text) == true)
            {
                MessageBox.Show("Invalid Number", "GL");
                txtCAmount.Focus();
            }
            else
            {
                txtCAmount.Text = Convert.ToDouble(txtCAmount.Text).ToString("N2");
                dgv1total();
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
            //string sqlstatement;

            //myconnection = new SqlConnection(Program.mycon);
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

        private void nextfiledenter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
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

   

        private void btnRecord_Click(object sender, EventArgs e)
        {
            if (new ClsValidation().emptytxt(txtLORRefer.Text))
            {
                MessageBox.Show("Please select list of receivable", "GL");
                dgvListReceive.Focus();

            }
            else
            {
               
                double varreceiveamt = double.Parse(txtReceiveAmt.Text);
                //Accounts Receivable
                ClsGetSomething1.ClsGetAT("1500000");
                dgv1.Rows.Add("1500000", ClsGetSomething1.plsAT, txtLORRefer.Text, "0.00", varreceiveamt.ToString("N2"), 0);

           
                
                double A = Convert.ToDouble(dgvListReceive.CurrentRow.Cells[2].Value);
                double B = Convert.ToDouble(txtReceiveAmt.Text);
                {
                    dgvListReceive.CurrentRow.Cells[2].Value = (A - B);
                }
                dgvListReceive.Focus();
                txtReceiveAmt.Text = "0.00";
                txtLORRefer.Text = null;
                dgv1total();
                refreshdgvListReceive();
            }

        }

        private void refreshdgvListReceive()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dgvListReceive.DataSource;
            bs.Filter = "Bal <> '0.00'";
            dgvListReceive.DataSource = bs;
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

        private void dgvListReceive_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtLORRefer.Text = dgvListReceive .CurrentRow.Cells[0].Value.ToString();
            double varamt = Convert.ToDouble(dgvListReceive.CurrentRow.Cells[2].Value);
            txtReceiveAmt.Text = varamt.ToString("N2");
         
        }

        private void txtReceiveAmt_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().isDouble(txtReceiveAmt.Text) == true)
            {
                MessageBox.Show("Invalid Number", "GL");
                txtReceiveAmt.Focus();
            }
            else
            {
                txtReceiveAmt.Text = Convert.ToDouble(txtReceiveAmt.Text).ToString("N2");
            }

        }

        private void txtVDate_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().errordate(txtVDate.Text) == true)
            {
                MessageBox.Show("Invalid Date", "GL");
                txtVDate.Focus();
            }
        }

        private void cbAccountNo_CheckedChanged(object sender, EventArgs e)
        {
            buildcboPA();
        }

       
        
    }
}
