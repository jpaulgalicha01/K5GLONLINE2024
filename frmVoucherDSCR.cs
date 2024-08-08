using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
//using K5GLV3.FldrClass;
//using K5GLV3.FldrLog;
using System.Net;
using CrystalDecisions.CrystalReports.Engine;
//using K5GLONLINE;
//using System.Net.Http;
using System.Threading;

namespace K5GLONLINE
{
    public partial class frmVoucherDSCR : Form
    {
        private SqlDataAdapter da;
        private DataTable dataTable = null;
        private SqlConnection myconnection;
        private BindingSource bindingSource = null;
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        BindingSource bsource = new BindingSource();
        ClsValidation ClsValidation1 = new ClsValidation();
        ClsBuildVoucherComboBox ClsBuildVoucherComboBox1 = new ClsBuildVoucherComboBox();
        ClsGetSomethingOthers ClsGetSomethingOthers1 = new ClsGetSomethingOthers();
        SqlCommand mycommand, mycommand1;
        string sql;
        int varintTableDoor = 0;
        int number = 0;
        DataTable DTTempTable = new DataTable();
        ClsAutoNumber ClsAutoNumber1 = new ClsAutoNumber();
        ClsGetSomething ClsGetSomething1 = new ClsGetSomething();
        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();
        private string privarstrVoidIC = null;

        public frmVoucherDSCR()
        {
            InitializeComponent();
        }
        private void ContentLoad()
        {
            //====================================================================
            dgv1.DataSource = null;
            dgv1.Rows.Clear();
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            if (cbListCI.Checked == true)
            {
                sql = "SELECT TDate, Reference, CustName, DSCRNum, Amount, Post, IC, UserPost FROM ViewDailySalesCollection WHERE SLS = '" + cboSalesman.SelectedValue.ToString() + "' AND Voucher = 'CI' AND TDate BETWEEN '" + txtBegDate.Text + "' And  '" + txtEndDate.Text + "' ORDER BY TDate";
            }
            else if (cbListRS.Checked == true)
            {
                sql = "SELECT TDate, Reference, CustName, DSCRNum, Amount, Post, IC, UserPost FROM ViewDailySalesCollection WHERE SLS = '" + cboSalesman.SelectedValue.ToString() + "' AND Voucher = 'RS' AND TDate BETWEEN '" + txtBegDate.Text + "' And  '" + txtEndDate.Text + "' ORDER BY TDate";
            }
            da = new SqlDataAdapter(sql, myconnection);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);

            dataTable = new DataTable();
            da.Fill(dataTable);
            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("No more data to be process", "GL");
                return;
            }
            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;

            DataGridViewTextBoxColumn ColumnTDate = new DataGridViewTextBoxColumn();          //0
            ColumnTDate.HeaderText = "Date";
            ColumnTDate.Width = 80;
            ColumnTDate.DataPropertyName = "TDate";
            ColumnTDate.ReadOnly = true;
            ColumnTDate.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnTDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv1.Columns.Add(ColumnTDate);

            DataGridViewTextBoxColumn ColumnReference = new DataGridViewTextBoxColumn();              //1
            ColumnReference.HeaderText = "Reference";
            ColumnReference.Width = 100;
            ColumnReference.DataPropertyName = "Reference";
            ColumnReference.ReadOnly = true;
            ColumnReference.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnReference.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv1.Columns.Add(ColumnReference);

            DataGridViewTextBoxColumn ColumnCustName = new DataGridViewTextBoxColumn();             //2
            ColumnCustName.HeaderText = "CustName";
            //ColumnCustName.Width = 200;
            ColumnCustName.DataPropertyName = "CustName";
            ColumnCustName.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnCustName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnCustName.Visible = true;
            ColumnCustName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv1.Columns.Add(ColumnCustName);

            DataGridViewTextBoxColumn ColumnDSCRNum = new DataGridViewTextBoxColumn();             //3
            ColumnDSCRNum.HeaderText = "DSCRNum";
            ColumnDSCRNum.Width = 80;
            //ColumnPLNum.ReadOnly = true;
            ColumnDSCRNum.DataPropertyName = "DSCRNum";
            ColumnDSCRNum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnDSCRNum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnDSCRNum.Visible = false;
            dgv1.Columns.Add(ColumnDSCRNum);

            DataGridViewTextBoxColumn ColumnAmount = new DataGridViewTextBoxColumn();             //4
            ColumnAmount.HeaderText = "Amount";
            ColumnAmount.Width = 100;
            //ColumnAmount.ReadOnly = true;
            ColumnAmount.DataPropertyName = "Amount";
            ColumnAmount.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnAmount.Visible = true;
            dgv1.Columns.Add(ColumnAmount);

            DataGridViewCheckBoxColumn cbPost = new DataGridViewCheckBoxColumn();             //5
            cbPost.HeaderText = "Post";
            cbPost.Width = 70;
            cbPost.DataPropertyName = "Post";
            cbPost.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cbPost.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
            cbPost.ReadOnly = true;
            dgv1.Columns.Add(cbPost);

            DataGridViewTextBoxColumn ColumnIC = new DataGridViewTextBoxColumn();             //6
            ColumnIC.HeaderText = "IC";
            ColumnIC.Width = 70;
            ColumnIC.DataPropertyName = "IC";
            ColumnIC.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnIC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnIC.Visible = false;
            dgv1.Columns.Add(ColumnIC);

            DataGridViewTextBoxColumn ColumnUserCode = new DataGridViewTextBoxColumn();             //7
            ColumnUserCode.HeaderText = "UserPost";
            ColumnUserCode.Width = 100;
            ColumnUserCode.DataPropertyName = "UserPost";
            ColumnUserCode.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnUserCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnUserCode.Visible = true;
            dgv1.Columns.Add(ColumnUserCode);          


            //Setting Data Source for DataGridView
            dgv1.DataSource = bindingSource;
            //dgv1.AutoResizeColumns();
            //dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            myconnection.Close();
            //this.WindowState = FormWindowState.Maximized;
            dgv1.AllowUserToAddRows = false;
            dgv1.Columns[4].DefaultCellStyle.Format = "N2";

            myconnection.Close();

        }
        private void frmNameEdit_Load(object sender, EventArgs e)
        {
            ClsAutoNumber1.VoucherAutoNumDSCRNumber("01");
            txtDocNum.Text = ClsAutoNumber1.plsnumber;
            ClsGetSomething1.ClsGetDefaultDate();
            txtTDate.Text = ClsGetSomething1.plsdefdate;
            txtBegDate.Text = ClsGetSomething1.plsdefdate;
            txtEndDate.Text = ClsGetSomething1.plsdefdate;
            buildcboGA();
            buildcboSalesman();
        }
        private void buildcboGA()
        {
            cboRoute.DataSource = null;
            ClsBuildComboBox1.PALGA.Clear();
            ClsBuildComboBox1.ClsBuildGA();
            this.cboRoute.DataSource = (ClsBuildComboBox1.PALGA);
            this.cboRoute.DisplayMember = "Display";
            this.cboRoute.ValueMember = "Value";
        }
        private void buildcboSalesman()
        {
            cboSalesman.DataSource = null;
            ClsBuildVoucherComboBox1.ARLSLS.Clear();
            ClsBuildVoucherComboBox1.ClsBuildSalesman();
            this.cboSalesman.DataSource = (ClsBuildVoucherComboBox1.ARLSLS);
            this.cboSalesman.DisplayMember = "Display";
            this.cboSalesman.ValueMember = "Value";
        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            myconnection.Open();
            if (new Clsexist().RecordExists(ref myconnection, "SELECT DSCRNum FROM tblDailySalesCollection WHERE DSCRNum ='" + txtDocNum.Text + "'"))
            {
                myconnection.Close();
                MessageBox.Show("Duplicate entry", "GL");
                txtRemarks.Focus();
            }
            else if (new ClsValidation().emptytxt(txtTDate.Text))
            {
                MessageBox.Show("Please complete your entry", "GL");
                txtTDate.Focus();
            }
            else if (new ClsValidation().emptytxt(txtRemarks.Text))
            {
                MessageBox.Show("Please complete your entry", "GL");
                txtRemarks.Focus();
            }
            else if (new ClsValidation().emptytxt(txtBegDate.Text))
            {
                MessageBox.Show("Please complete your entry", "GL");
                txtBegDate.Focus();
            }
            else if (new ClsValidation().emptytxt(txtEndDate.Text))
            {
                MessageBox.Show("Please complete your entry", "GL");
                txtEndDate.Focus();
            }
            //else if (new ClsValidation().emptytxt(cboRoute.Text))
            //{
            //    MessageBox.Show("Please complete your entry", "GL");
            //    cboRoute.Focus();
            //}
            else if (new ClsValidation().emptytxt(cboSalesman.Text))
            {
                MessageBox.Show("Please complete your entry", "GL");
                cboSalesman.Focus();
            }
            else
            {
                myconnection.Close();
                privarstrVoidIC = null;
                ClsGetSomethingOthers1.ClsGetTDoor("DSCR");
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

                    ClsGetSomethingOthers1.ClsGetVoidRef("DSCR");
                    privarstrVoidIC = ClsGetSomethingOthers1.plsVoidIC;
                    if (new ClsValidation().emptytxt(privarstrVoidIC))
                    {
                        ClsGetSomethingOthers1.ClsOneTheDoor("DSCR");
                        SaveDSCRNo();
                        ClsGetSomethingOthers1.ClsZeroTheDoor("DSCR");
                    }
                    else
                    {
                        ClsGetSomethingOthers1.ClsDeleteErrorTransaction("DSCR");
                        MessageBox.Show("Transaction not saved", "GL");
                    }

                }
                else if (varintTableDoor == 1 && number == 21)
                {
                    MessageBox.Show("Contact your adminnistrator", "GL");
                }
            }
        }

        public void SaveDSCRNo()
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();

            ClsAutoNumber1.VoucherAutoNumDSCRNumber("01");
            txtDocNum.Text = ClsAutoNumber1.plsnumber;

            DataGridViewRow row1 = null;
            for (int x = 0; x < dgv1.Rows.Count; x++)
            {
                if (dgv1.Rows[x].Cells[7].Value.ToString() == Form1.glbluc.Text)
                {
                    row1 = dgv1.Rows[x];
                    string SqlStatement = "UPDATE tblMain1 SET Post=@_Post, DSCRNum=@_DSCRNum, UserPost = @_UserPost WHERE IC = '"+ dgv1.Rows[x].Cells[6].Value.ToString() + "'";
                    mycommand1 = new SqlCommand(SqlStatement, myconnection);
                    mycommand1.Parameters.Add("_Post", SqlDbType.Bit).Value = dgv1.Rows[x].Cells[5].Value.ToString();
                    mycommand1.Parameters.Add("_DSCRNum", SqlDbType.VarChar).Value = txtDocNum.Text; // dgv1.Rows[x].Cells[3].Value.ToString();
                    mycommand1.Parameters.Add("_UserPost", SqlDbType.VarChar).Value =dgv1.Rows[x].Cells[7].Value.ToString();
                    int n1 = mycommand1.ExecuteNonQuery();                    
                }
            }

            DateTime DT = DateTime.Now;

            string sqlstatement = "INSERT INTO tblDailySalesCollection (DSCRNum, DocNum, DSCRDate, UserCode, Remarks, CNCode, DE, SLS, Route)";
            sqlstatement += "Values (@_DSCRNum, @_DocNum, @_DSCRDate, @_UserCode, @_Remarks, @_CNCode, @_DE, @_SLS, @_Route)";
            mycommand = new SqlCommand(sqlstatement, myconnection);
            mycommand.Parameters.Add("_DSCRNum", SqlDbType.VarChar).Value = txtDocNum.Text + "01";
            mycommand.Parameters.Add("_DocNum", SqlDbType.VarChar).Value = txtDocNum.Text;
            mycommand.Parameters.Add("_DSCRDate", SqlDbType.SmallDateTime).Value = txtTDate.Text;
            mycommand.Parameters.Add("_UserCode", SqlDbType.Char).Value = Form1.glbluc.Text;
            mycommand.Parameters.Add("_Remarks", SqlDbType.VarChar).Value = txtRemarks.Text;
            mycommand.Parameters.Add("_CNCode", SqlDbType.Char).Value = "01";
            mycommand.Parameters.Add("_DE", SqlDbType.SmallDateTime).Value = DT;
            mycommand.Parameters.Add("_SLS", SqlDbType.Char).Value = cboSalesman.SelectedValue.ToString();
            mycommand.Parameters.Add("_Route", SqlDbType.Char).Value = cboRoute.SelectedValue.ToString();
            mycommand.CommandTimeout = 600;
            int n2 = mycommand.ExecuteNonQuery();

            MessageBox.Show("Saved!", "GL");
            // saveData();
            myconnection.Close();

            if (cbSP.Checked)
            {
                printcurvoucher();
            }
            clearScreen();
        }

        private void saveData()
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            DateTime DT = DateTime.Now;
            
            string sqlstatement = "INSERT INTO tblDailySalesCollection (DSCRNum, DocNum, DSCRDate, UserCode, Remarks, CNCode, DE, SLS, Route)";
            sqlstatement += "Values (@_DSCRNum, @_DocNum, @_DSCRDate, @_UserCode, @_Remarks, @_CNCode, @_DE, @_SLS, @_Route)";
            mycommand = new SqlCommand(sqlstatement, myconnection);
            mycommand.Parameters.Add("_DSCRNum", SqlDbType.VarChar).Value = txtDocNum.Text +"01";
            mycommand.Parameters.Add("_DocNum", SqlDbType.VarChar).Value = txtDocNum.Text;
            mycommand.Parameters.Add("_DSCRDate", SqlDbType.SmallDateTime).Value = txtTDate.Text;
            mycommand.Parameters.Add("_UserCode", SqlDbType.Char).Value = Form1.glbluc.Text;
            mycommand.Parameters.Add("_Remarks", SqlDbType.VarChar).Value = txtRemarks.Text;       
            mycommand.Parameters.Add("_CNCode", SqlDbType.Char).Value = "01";
            mycommand.Parameters.Add("_DE", SqlDbType.SmallDateTime).Value = DT;
            mycommand.Parameters.Add("_SLS", SqlDbType.Char).Value = cboSalesman.SelectedValue.ToString();
            mycommand.Parameters.Add("_Route", SqlDbType.Char).Value = cboRoute.SelectedValue.ToString();
            mycommand.CommandTimeout = 600;
            int n1 = mycommand.ExecuteNonQuery();
            myconnection.Close();
        }


        public void clearScreen()
        {  
            ClsAutoNumber1.VoucherAutoNumDSCRNumber("01");
            txtDocNum.Text = ClsAutoNumber1.plsnumber;

            ClsGetSomething1.ClsGetDefaultDate();
            txtTDate.Text = ClsGetSomething1.plsdefdate;

            buildcboGA();
            buildcboSalesman();
            txtBegDate.Text = ClsGetSomething1.plsdefdate;
            txtEndDate.Text = ClsGetSomething1.plsdefdate;
            cboRoute.SelectedValue = "";
            cboSalesman.SelectedValue = "";
            txtRemarks.Text = "NA";
            txtTotalItem.Text = "0";
            dgv1.DataSource = null;
            dgv1.Rows.Clear();
           // ContentLoad();
        }

        public void printcurvoucher()
        {
            
            string sqlstatement;

            ClsGetConnection1.ClsGetConMSSQL(); myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();

            sqlstatement = "SELECT TDate, CustName, Amount, Reference, UserName FROM ViewDSCRDetails WHERE DSCRNum = '" + txtDocNum.Text + "'";

            SqlDataAdapter dscmd = new SqlDataAdapter(sqlstatement, myconnection);
            dscmd.SelectCommand.CommandTimeout = 600;
            DSDSCR dsdscr1 = new DSDSCR();
            dscmd.Fill(dsdscr1, "ViewDSCRDetails");
            myconnection.Close();


            CRprevDSCR objRpt = new CRprevDSCR();

            TextObject vartxtSalesman = (TextObject)objRpt.ReportDefinition.Sections["Section2"].ReportObjects["rpttxtSalesman"];
            ClsGetSomething1.ClsGetDCRData(txtDocNum.Text);
            vartxtSalesman.Text = ClsGetSomething1.plsSalesman;

            TextObject vartxtRemarks = (TextObject)objRpt.ReportDefinition.Sections["Section2"].ReportObjects["rpttxtRemarks"];
            ClsGetSomething1.ClsGetDCRData(txtDocNum.Text);
            vartxtRemarks.Text = ClsGetSomething1.plsRemarks;

            TextObject vartxtRepDate = (TextObject)objRpt.ReportDefinition.Sections["Section2"].ReportObjects["rpttxtRepDate"];
            ClsGetSomething1.ClsGetDCRData(txtDocNum.Text);
            vartxtRepDate.Text = Convert.ToDateTime(ClsGetSomething1.plsDcrDate).ToString("MM/dd/yyyy");

            TextObject vartxtdocnum = (TextObject)objRpt.ReportDefinition.Sections["Section2"].ReportObjects["rpttxtdocnum"];
            vartxtdocnum.Text = ClsGetSomething1.plsDocNum;

            objRpt.SetDataSource(dsdscr1.Tables[1]);

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
       

      
        private void nextfieldenter2(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }

        }

        private void btnpreview_Click(object sender, EventArgs e)
        {
            ContentLoad();
        }

        private void dgv1_Click(object sender, EventArgs e)
        {
            
            dgv1.CurrentRow.Cells[3].Value = txtDocNum.Text;
            dgv1.CurrentRow.Cells[5].Value = 1;
            dgv1.CurrentRow.Cells[7].Value = Form1.glbluc.Text;

            DGVCount();            

           

        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtRemarks.Focus();
        }

        private void dgv1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgv1.CurrentRow.Cells[3].Value = null;
            dgv1.CurrentRow.Cells[5].Value = 0;
            dgv1.CurrentRow.Cells[7].Value = null;
            DGVCount();
        }

        private void DGVCount()
        {
            double dcount = 0.00;
            for (int x = 0; x < dgv1.Rows.Count; x++)
            {
               
                if (dgv1.Rows[x].Cells[5].Value.ToString() == "True")
                {
                    dcount += 1;
                }               
            }
            txtTotalItem.Text = dcount.ToString();
        }

      

        private void cbListRS_CheckedChanged(object sender, EventArgs e)
        {
            dgv1.DataSource = null;
            dgv1.Rows.Clear();
            cbListCI.Checked = false;
            
        }

        private void cbListCI_CheckedChanged(object sender, EventArgs e)
        {
            dgv1.DataSource = null;
            dgv1.Rows.Clear();
            cbListRS.Checked = false;
        }

       
      
    }
}
