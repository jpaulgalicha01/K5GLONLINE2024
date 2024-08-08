using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
//using K5GLONLINE.FldrClass;

namespace K5GLONLINE
{
    public partial class frmUpdates : Form
    {
        private SqlDataAdapter da;
        private DataTable dataTable = null;
        private SqlConnection myconnection;
        private BindingSource bindingSource = null;
        private SqlDataReader dr;
        BindingSource bsource = new BindingSource();
        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();
        ClsGetSomething ClsGetSomething1 = new ClsGetSomething();
        //ClsDefaultBranch ClsDefaultBranch1 = new ClsDefaultBranch();
        ClsPermission ClsPermission1 = new ClsPermission();
        private string psnum;
        private bool boolreconciled;
        SqlCommand mycommand;
        string sql;
        public static TextBox glbltxtBookBalance, glbltxtBankBalance, glblTxtReport, glbltxtSumDR, glbltxtSumCR;
        public static MaskedTextBox glbltxtTDate;
        public static ComboBox glblcboBank;
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection(); 

        public frmUpdates()
        {
            InitializeComponent();
        }

        //private void buildcboBank()
        //{
        //    cboBank.DataSource = null;
        //    ClsBuildComboBox1.ARCABN.Clear();
        //    ClsBuildComboBox1.ClsBuildCABN();
        //    this.cboBank.DataSource = (ClsBuildComboBox1.ARCABN);
        //    this.cboBank.DisplayMember = "Display";
        //    this.cboBank.ValueMember = "Value";
        //}

        //private void showTransaction()
        //{

        //    if (cbHideReconTransact.Checked)
        //    {
        //        sql = "SELECT TDate, CNumber, Reference, CheckNo, Debit, ";
        //        sql += "Credit, Reconciled, RowNum ";
        //        sql += "FROM ViewBankReconTransact WHERE TDate<='" + txtTDate.Text + "' AND PA = '" + cboBank.SelectedValue.ToString() + "' AND CNCode = '" + (ClsDefaultBranch1.plsvardb) + "' AND Reconciled = 0";

        //    }
        //    else
        //    {
        //        sql = "SELECT TDate, CNumber, Reference, CheckNo, Debit, ";
        //        sql += "Credit, Reconciled, RowNum ";
        //        sql += "FROM ViewBankReconTransact WHERE TDate<='" + txtTDate.Text + "' AND PA = '" + cboBank.SelectedValue.ToString() + "' AND CNCode = '" + (ClsDefaultBranch1.plsvardb) + "'";
        //    }

        //    ClsGetConnection1.ClsGetConMSSQL();
        //    myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
        //    myconnection.Open();
        //    da = new SqlDataAdapter(sql, myconnection);
        //    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);

        //    dataTable = new DataTable();
        //    da.Fill(dataTable);
        //    bindingSource = new BindingSource();
        //    bindingSource.DataSource = dataTable;

        //    //Adding  Date TextBox
        //    DataGridViewTextBoxColumn ColumnDate = new DataGridViewTextBoxColumn();
        //    ColumnDate.HeaderText = "Date";
        //    ColumnDate.Width = 100;
        //    ColumnDate.DataPropertyName = "TDate";
        //    ColumnDate.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    ColumnDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        //    //ColumnDate.Visible = false;
        //    ColumnDate.ReadOnly = true;
        //    dgv1.Columns.Add(ColumnDate);

        //    //Adding  CNumber TextBox
        //    DataGridViewTextBoxColumn ColumnCNumber = new DataGridViewTextBoxColumn();
        //    ColumnCNumber.HeaderText = "Series";
        //    ColumnCNumber.Width = 120;
        //    ColumnCNumber.DataPropertyName = "CNumber";
        //    ColumnCNumber.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    ColumnCNumber.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        //    ColumnCNumber.Visible = true;
        //    ColumnCNumber.ReadOnly = true;
        //    dgv1.Columns.Add(ColumnCNumber);

        //    //Adding  Reference TextBox
        //    DataGridViewTextBoxColumn ColumnReference = new DataGridViewTextBoxColumn();
        //    ColumnReference.HeaderText = "Reference";
        //    ColumnReference.Width = 120;
        //    ColumnReference.DataPropertyName = "Reference";
        //    ColumnReference.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    ColumnReference.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        //    ColumnReference.ReadOnly = true;
        //    dgv1.Columns.Add(ColumnReference);


        //    //Adding  CheckNo TextBox
        //    DataGridViewTextBoxColumn ColumnCheckNo = new DataGridViewTextBoxColumn();
        //    ColumnCheckNo.HeaderText = "Check #";
        //    ColumnCheckNo.Width = 120;
        //    ColumnCheckNo.DataPropertyName = "CheckNo";
        //    ColumnCheckNo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    ColumnCheckNo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        //    ColumnCheckNo.ReadOnly = true;
        //    dgv1.Columns.Add(ColumnCheckNo);

        //    //Adding  Debit TextBox
        //    DataGridViewTextBoxColumn ColumnDebit = new DataGridViewTextBoxColumn();
        //    ColumnDebit.HeaderText = "Debit";
        //    ColumnDebit.Width = 100;
        //    ColumnDebit.DataPropertyName = "Debit";
        //    ColumnDebit.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    ColumnDebit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        //    ColumnDebit.ReadOnly = true;
        //    dgv1.Columns.Add(ColumnDebit);

        //    //Adding  Credit TextBox
        //    DataGridViewTextBoxColumn ColumnCredit = new DataGridViewTextBoxColumn();
        //    ColumnCredit.HeaderText = "Credit";
        //    ColumnCredit.Width = 100;
        //    ColumnCredit.DataPropertyName = "Credit";
        //    ColumnCredit.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    ColumnCredit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        //    ColumnCredit.ReadOnly = true;
        //    dgv1.Columns.Add(ColumnCredit);

        //    //Adding  Reconciled checkbox
        //    DataGridViewCheckBoxColumn ColumnReconciled = new DataGridViewCheckBoxColumn();
        //    ColumnReconciled.HeaderText = "Reconciled";
        //    ColumnReconciled.Width = 80;
        //    ColumnReconciled.DataPropertyName = "Reconciled";
        //    ColumnReconciled.FalseValue = 0;
        //    ColumnReconciled.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    ColumnReconciled.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    dgv1.Columns.Add(ColumnReconciled);

        //    //Adding  Num TextBox
        //    DataGridViewTextBoxColumn ColumnNum = new DataGridViewTextBoxColumn();
        //    ColumnNum.HeaderText = "Num";
        //    ColumnNum.Width = 100;
        //    ColumnNum.DataPropertyName = "RowNum";
        //    ColumnNum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    ColumnNum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        //    ColumnNum.ReadOnly = true;
        //    ColumnNum.Visible = false;
        //    dgv1.Columns.Add(ColumnNum);

        //    //Setting Data Source for DataGridView
        //    dgv1.DataSource = bindingSource;
        //    //dgv1.AutoResizeColumns();
        //    //dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        //    myconnection.Close();
        //    //this.WindowState = FormWindowState.Maximized;
        //    dgv1.AllowUserToAddRows = false;
        //    dgv1.Columns[0].DefaultCellStyle.Format = "MM/dd/yyyy";
        //    dgv1.Columns[4].DefaultCellStyle.Format = "N2";
        //    dgv1.Columns[5].DefaultCellStyle.Format = "N2";
        //}

        private void frmUpdates_Load(object sender, EventArgs e)
        {
            ClsPermission1.ClsObjects(this.Text);
            if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
            {
                MessageBox.Show("You do not have necessary permission to open this file", "GL");
                this.Close();
            }
            else
            {
                //ClsGetSomething1.ClsGetDefaultDate();
                //txtTDate.Text = ClsGetSomething1.plsdefdate;
                //buildcboBank();
                //glblcboBank = cboBank;
                //glbltxtTDate = txtTDate;
                //glbltxtBankBalance = txtBankBalance;
                //glbltxtBookBalance = txtBookBalance;
                //glblTxtReport = txtReport;
                //glbltxtSumDR = txtSumDR;
                //glbltxtSumCR = txtSumCR;
            }
        }

        private void txtBookBalance_TextChanged(object sender, EventArgs e)
        {

        }

        //private void dgv1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{

        //    DataGridViewRow row = dgv1.Rows[e.RowIndex];
        //    psnum = row.Cells[7].FormattedValue.ToString();
        //    boolreconciled = Convert.ToBoolean(row.Cells[6].FormattedValue.ToString());

        //}

        //private void btnClose_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}



        //private void txtTDate_Validating(object sender, CancelEventArgs e)
        //{
        //    if (new ClsValidation().errordate(txtTDate.Text) == true)
        //    {
        //        MessageBox.Show("Invalid Date", "GL");
        //        txtTDate.Focus();
        //    }

        //}

        //private void txtBookBalance_Validating(object sender, CancelEventArgs e)
        //{
        //    if (new ClsValidation().isDouble(txtBookBalance.Text) == true)
        //    {
        //        MessageBox.Show("Invalid Number", "GL");
        //        txtBookBalance.Focus();
        //    }
        //    else
        //    {
        //        txtBookBalance.Text = Convert.ToDouble(txtBookBalance.Text).ToString("N2");
        //    }

        //}

        //private void txtBankBalance_Validating(object sender, CancelEventArgs e)
        //{
        //    if (new ClsValidation().isDouble(txtBankBalance.Text) == true)
        //    {
        //        MessageBox.Show("Invalid Number", "GL");
        //        txtBankBalance.Focus();
        //    }
        //    else
        //    {
        //        txtBankBalance.Text = Convert.ToDouble(txtBankBalance.Text).ToString("N2");
        //    }
        //}

        //private void btnTransaction_Click(object sender, EventArgs e)
        //{
        //    dgv1.DataSource = null;
        //    dgv1.Columns.Clear();
        //    showTransaction();
        //    GetBookBal();
        //}

        //private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    txtTDate.Focus();
        //    string sqlstatement;
        //    sqlstatement = "UPDATE tblMain3 set Reconciled=@_Reconciled  WHERE RowNum ='" + psnum + "'";

        //    ClsGetConnection1.ClsGetConMSSQL();
        //    myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
        //    myconnection.Open();
        //    mycommand = new SqlCommand(sqlstatement, myconnection);
        //    mycommand.Parameters.Add("_Reconciled", SqlDbType.Bit).Value = boolreconciled;
        //    int n1 = mycommand.ExecuteNonQuery();
        //    myconnection.Close();
        //}

        //private void GetBookBal()
        //{
        //    try
        //    {
        //        ClsGetConnection1.ClsGetConMSSQL();
        //        myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
        //        myconnection.Open();
        //        if (new Clsexist().RecordExists(ref myconnection, "SELECT Sum(Balance) As SumBalance FROM ViewBankReconTransact WHERE TDate<='" + txtTDate.Text + "' AND PA = '" + cboBank.SelectedValue.ToString() + "' AND CNCode = '" + (ClsDefaultBranch1.plsvardb) + "'"))
        //        {

        //            mycommand = new SqlCommand("SELECT Sum(Balance) As SumBalance FROM ViewBankReconTransact WHERE TDate<='" + txtTDate.Text + "' AND PA = '" + cboBank.SelectedValue.ToString() + "' AND CNCode = '" + (ClsDefaultBranch1.plsvardb) + "'", myconnection);
        //            dr = mycommand.ExecuteReader();
        //            while (dr.Read())
        //            {
        //                double doubbookbal = 0;
        //                doubbookbal = double.Parse((dr["SumBalance"]).ToString());
        //                txtBookBalance.Text = doubbookbal.ToString("N2");
        //            }
        //        }
        //        else
        //        {
        //            txtBookBalance.Text = "0.00";
        //        }
        //        if (double.Parse(txtBookBalance.Text) == 0)
        //        {
        //            myconnection.Close();
        //        }
        //        else
        //        {
        //            dr.Close();
        //            myconnection.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        //dr.Close();
        //        myconnection.Close();
        //    }
        //}

        //private void cbHideReconTransact_CheckedChanged(object sender, EventArgs e)
        //{
        //    dgv1.DataSource = null;
        //    dgv1.Columns.Clear();
        //    showTransaction();
        //    GetBookBal();

        //}

        //private void btnReconReport_Click(object sender, EventArgs e)
        //{
        //    txtReport.Text = "1";
        //    GetUnreconciledBal();
        //    frmrptBankRecon frmrptBankRecon1 = new frmrptBankRecon();
        //    frmrptBankRecon1.Show();

        //}

        //private void btnDetailedRep_Click(object sender, EventArgs e)
        //{
        //    txtReport.Text = "2";
        //    frmrptBankRecon frmrptBankRecon1 = new frmrptBankRecon();
        //    frmrptBankRecon1.Show();
        //}

        //private void GetUnreconciledBal()
        //{
        //    try
        //    {
        //        ClsGetConnection1.ClsGetConMSSQL();
        //        myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
        //        myconnection.Open();
        //        if (new Clsexist().RecordExists(ref myconnection, "SELECT Sum(Debit) As SumDebit FROM ViewBankReconTransact WHERE TDate<='" + txtTDate.Text + "' AND PA = '" + cboBank.SelectedValue.ToString() + "' AND CNCode = '" + (ClsDefaultBranch1.plsvardb) + "' AND Reconciled = 0"))
        //        {
        //            mycommand = new SqlCommand("SELECT Sum(Debit) As SumDebit, Sum(Credit) As SumCredit FROM ViewBankReconTransact WHERE TDate<='" + txtTDate.Text + "' AND PA = '" + cboBank.SelectedValue.ToString() + "' AND CNCode = '" + (ClsDefaultBranch1.plsvardb) + "' AND Reconciled = 0", myconnection);
        //            dr = mycommand.ExecuteReader();
        //            while (dr.Read())
        //            {
        //                double sumdr = 0;
        //                double sumcr = 0;
        //                if (dr["SumDebit"].ToString() == "")
        //                {
        //                    sumdr = 0;
        //                }
        //                else
        //                {
        //                    sumdr = double.Parse((dr["SumDebit"]).ToString());
        //                }
        //                if (dr["SumCredit"].ToString() == "")
        //                {
        //                    sumcr = 0;
        //                }
        //                else
        //                {
        //                    sumcr = double.Parse((dr["SumDebit"]).ToString());
        //                }
        //                //sumdr = double.Parse((dr["SumDebit"]).ToString());
        //                //sumcr = double.Parse((dr["SumCredit"]).ToString());

        //                txtSumDR.Text = sumdr.ToString("N2");
        //                txtSumCR.Text = sumcr.ToString("N2");
        //            }
        //        }
        //        else
        //        {
        //            txtSumDR.Text = "0.00";
        //            txtSumCR.Text = "0.00";
        //        }
        //        if (double.Parse(txtSumDR.Text) == 0)
        //        {
        //            myconnection.Close();
        //        }
        //        else
        //        {
        //            dr.Close();
        //            myconnection.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        //dr.Close();
        //        myconnection.Close();
        //    }
        //}

        //private void nextfieldenter1(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode.Equals(Keys.Enter))
        //    {
        //        SendKeys.Send("{TAB}");
        //    }
        //    else if ((e.KeyCode.Equals(Keys.Up)) || (e.KeyCode.Equals(Keys.Left)))
        //    {
        //        SendKeys.Send("+{TAB}");
        //    }
        //    else if ((e.KeyCode.Equals(Keys.Down)) || (e.KeyCode.Equals(Keys.Right)))
        //    {
        //        SendKeys.Send("{TAB}");
        //    }

        //}

        //private void nextfieldenter2(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode.Equals(Keys.Enter))
        //    {
        //        SendKeys.Send("{TAB}");
        //    }
        //}
    }
}
