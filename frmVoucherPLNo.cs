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

namespace K5GLONLINE
{
    public partial class frmVoucherPLNo : Form
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
        DataTable DTTempTable = new DataTable();
        ClsAutoNumber ClsAutoNumber1 = new ClsAutoNumber();
        ClsGetSomething ClsGetSomething1 = new ClsGetSomething();

        public frmVoucherPLNo()
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
            sql = "SELECT WHCode, ControlNo, PC, OrderDate, Reference, PLNum, Post, DocNum FROM ViewPickList WHERE WHCode = '" + cboWHCode.SelectedValue.ToString() + "' AND  PC = '" + cboPC.SelectedValue.ToString() + "' AND OrderDate BETWEEN '" + txtBegDate.Text + "' And  '" + txtEndDate.Text + "' ";
            da = new SqlDataAdapter(sql, myconnection);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);

            dataTable = new DataTable();
            da.Fill(dataTable);
            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("No data found", "GL");
                return;
            }
            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;

            string selectQueryStringtblWarehouse = "SELECT WHCode, Warehouse FROM tblWarehouse ORDER BY Warehouse";
            SqlDataAdapter sqlDataAdaptertblWarehouse = new SqlDataAdapter(selectQueryStringtblWarehouse, myconnection);
            SqlCommandBuilder sqlCommandBuildertblWarehouse = new SqlCommandBuilder(sqlDataAdaptertblWarehouse);
            DataTable dataTabletblWarehouse = new DataTable();
            sqlDataAdaptertblWarehouse.Fill(dataTabletblWarehouse);
            BindingSource bindingSourcedataTabletblWarehouse = new BindingSource();
            bindingSourcedataTabletblWarehouse.DataSource = dataTabletblWarehouse;

            DataGridViewComboBoxColumn ColumnWHCode = new DataGridViewComboBoxColumn();
            ColumnWHCode.DataPropertyName = "WHCode";
            ColumnWHCode.HeaderText = "Warehouse";
            ColumnWHCode.Width = 300;
            ColumnWHCode.DataSource = bindingSourcedataTabletblWarehouse;
            ColumnWHCode.ValueMember = "WHCode";
            ColumnWHCode.ReadOnly = true;
            ColumnWHCode.DisplayMember = "Warehouse";
            dgv1.Columns.Add(ColumnWHCode);

            string selectQueryStringtblCustomer = "SELECT ControlNo, CustName FROM tblCustomer ORDER BY CustName";
            SqlDataAdapter sqlDataAdaptertblCustomer = new SqlDataAdapter(selectQueryStringtblCustomer, myconnection);
            SqlCommandBuilder sqlCommandBuildertblCustomer = new SqlCommandBuilder(sqlDataAdaptertblCustomer);
            DataTable dataTabletblCustomer = new DataTable();
            sqlDataAdaptertblCustomer.Fill(dataTabletblCustomer);
            BindingSource bindingSourcetblCustomer = new BindingSource();
            bindingSourcetblCustomer.DataSource = dataTabletblCustomer;

            DataGridViewComboBoxColumn ColumnControlNo = new DataGridViewComboBoxColumn();
            ColumnControlNo.DataPropertyName = "ControlNo";
            ColumnControlNo.HeaderText = "Customer";
            ColumnControlNo.Width = 120;
            ColumnControlNo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnControlNo.DataSource = bindingSourcetblCustomer;
            ColumnControlNo.ValueMember = "ControlNo";
            ColumnControlNo.ReadOnly = true;
            ColumnControlNo.DisplayMember = "CustName";
            dgv1.Columns.Add(ColumnControlNo);

            string selectQueryStringtblPersonnel = "SELECT PC, PersonnelName FROM tblPersonnel ORDER BY PersonnelName";
            SqlDataAdapter sqlDataAdaptertblPersonnel = new SqlDataAdapter(selectQueryStringtblPersonnel, myconnection);
            SqlCommandBuilder sqlCommandBuildertblPersonnel = new SqlCommandBuilder(sqlDataAdaptertblPersonnel);
            DataTable dataTabletblPersonnel = new DataTable();
            sqlDataAdaptertblPersonnel.Fill(dataTabletblPersonnel);
            BindingSource bindingSourcetblPersonnel = new BindingSource();
            bindingSourcetblPersonnel.DataSource = dataTabletblPersonnel;

            DataGridViewComboBoxColumn ColumnPC = new DataGridViewComboBoxColumn();
            ColumnPC.DataPropertyName = "PC";
            ColumnPC.HeaderText = "Salesman";
            ColumnPC.Width = 120;
            ColumnPC.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnPC.DataSource = bindingSourcetblPersonnel;
            ColumnPC.ValueMember = "PC";
            ColumnPC.ReadOnly = true;
            ColumnPC.DisplayMember = "PersonnelName";
            dgv1.Columns.Add(ColumnPC);

            DataGridViewTextBoxColumn ColumnTDate = new DataGridViewTextBoxColumn();
            ColumnTDate.HeaderText = "Date";
            ColumnTDate.Width = 80;
            ColumnTDate.DataPropertyName = "OrderDate";
            ColumnTDate.ReadOnly = true;
            ColumnTDate.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnTDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv1.Columns.Add(ColumnTDate);

            DataGridViewTextBoxColumn ColumnReference = new DataGridViewTextBoxColumn();
            ColumnReference.HeaderText = "Reference";
            ColumnReference.Width = 120;
            ColumnReference.DataPropertyName = "Reference";
            ColumnReference.ReadOnly = true;
            ColumnReference.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnReference.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv1.Columns.Add(ColumnReference);

            DataGridViewTextBoxColumn ColumnPLNum = new DataGridViewTextBoxColumn();
            ColumnPLNum.HeaderText = "PLNum";
            ColumnPLNum.Width = 150;
            //ColumnPLNum.ReadOnly = true;
            ColumnPLNum.DataPropertyName = "PLNum";
            ColumnPLNum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnPLNum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnPLNum.Visible = false;
            dgv1.Columns.Add(ColumnPLNum);

            DataGridViewCheckBoxColumn cbPost = new DataGridViewCheckBoxColumn();
            cbPost.HeaderText = "Post";
            cbPost.Width = 50;
            cbPost.DataPropertyName = "Post";
            cbPost.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cbPost.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cbPost.ReadOnly = false;
            dgv1.Columns.Add(cbPost);

            DataGridViewTextBoxColumn ColumnDocNum = new DataGridViewTextBoxColumn();
            ColumnDocNum.HeaderText = "DocNum";
            ColumnDocNum.Width = 150;
            ColumnDocNum.DataPropertyName = "DocNum";
            ColumnDocNum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnDocNum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnDocNum.Visible = false;
            dgv1.Columns.Add(ColumnDocNum);

            //Setting Data Source for DataGridView
            dgv1.DataSource = bindingSource;
            //dgv1.AutoResizeColumns();
            //dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            myconnection.Close();
            //this.WindowState = FormWindowState.Maximized;
            dgv1.AllowUserToAddRows = false;
            //dgv1.Columns[9].DefaultCellStyle.Format = "N2";

        }
        private void frmNameEdit_Load(object sender, EventArgs e)
        {
            ClsAutoNumber1.VoucherAutoNumPLNumber("01");
            txtDocNum.Text = ClsAutoNumber1.plsnumber;
            ClsGetSomething1.ClsGetDefaultDate();
            txtTDate.Text = ClsGetSomething1.plsdefdate;
            txtBegDate.Text = ClsGetSomething1.plsdefdate;
            txtEndDate.Text = ClsGetSomething1.plsdefdate;
            buildcboWHCode();
            buildcboPCCode();
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
        private void buildcboPCCode()
        {
            cboPC.DataSource = null;
            ClsBuildVoucherComboBox1.ARLSPC.Clear();
            ClsBuildVoucherComboBox1.ClsBuildPC();
            this.cboPC.DataSource = (ClsBuildVoucherComboBox1.ARLSPC);
            this.cboPC.DisplayMember = "Display";
            this.cboPC.ValueMember = "Value";
        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            myconnection.Open();
            if (new Clsexist().RecordExists(ref myconnection, "SELECT PLNum FROM tblPLNumber WHERE PLNum ='" + txtDocNum.Text + "'"))
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
            else if (new ClsValidation().emptytxt(cboWHCode.Text))
            {
                MessageBox.Show("Please complete your entry", "GL");
                cboWHCode.Focus();
            }
            else if (new ClsValidation().emptytxt(cboPC.Text))
            {
                MessageBox.Show("Please complete your entry", "GL");
                cboPC.Focus();
            }
            else
            {
                myconnection.Close();
                SavePLNo();
            }
        }
        public void SavePLNo()
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();

            DateTime DT = DateTime.Now;
            ClsAutoNumber1.VoucherAutoNumPLNumber("01");
            string DocNumPL = ClsAutoNumber1.plsnumber;
            string sqlstatement = "INSERT INTO tblPLNumber (PLNum, DocNum, PLDate, UserCode, Remarks, DE, CNCode)";
            sqlstatement += "Values (@_PLNum, @_DocNum, @_PLDate, @_UserCode, @_Remarks, @_DE, @_CNCode)";
            mycommand = new SqlCommand(sqlstatement, myconnection);
            mycommand.Parameters.Add("_PLNum", SqlDbType.VarChar).Value = DocNumPL + "01";
            mycommand.Parameters.Add("_DocNum", SqlDbType.VarChar).Value = DocNumPL;
            mycommand.Parameters.Add("_PLDate", SqlDbType.SmallDateTime).Value = txtTDate.Text;
            mycommand.Parameters.Add("_UserCode", SqlDbType.Char).Value = Form1.glbluc.Text;
            mycommand.Parameters.Add("_Remarks", SqlDbType.VarChar).Value = txtRemarks.Text;
            mycommand.Parameters.Add("_DE", SqlDbType.DateTime).Value = DT;
            mycommand.Parameters.Add("_CNCode", SqlDbType.Char).Value = "01";
            mycommand.CommandTimeout = 600;
            int n1 = mycommand.ExecuteNonQuery();
            //DataGridViewRow row = null;
            for (int x = 0; x < dgv1.Rows.Count; x++)
            {
                if (Convert.ToBoolean(dgv1.Rows[x].Cells[6].Value.ToString()) == true)
                {
                    string SqlStatement = "UPDATE tblMain6 SET Post=@_Post, PLNum=@_PLNum WHERE DocNum= '" + dgv1.Rows[x].Cells[7].Value.ToString() + "'";
                    mycommand1 = new SqlCommand(SqlStatement, myconnection);
                    mycommand1.Parameters.Add("_Post", SqlDbType.Bit).Value = Convert.ToBoolean(dgv1.Rows[x].Cells[6].Value.ToString());
                    mycommand1.Parameters.Add("_PLNum", SqlDbType.VarChar).Value = DocNumPL + "01";
                    int n2 = mycommand1.ExecuteNonQuery();
                }
            }
            myconnection.Close();
            if (cbSP.Checked)
            {
                printcurvoucher();
            }

            clearScreen();
        }
        public void printcurvoucher()
        {
            string sqlstatement;
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            string PLNumber = txtDocNum.Text + "01";
            sqlstatement = "SELECT CustName, Piece, IB, Item AS StockDesc, StockNumber, UserName, SUM(ConvertedQty) As SumConvertedQty ";
            sqlstatement += "FROM ViewPickListNumber  WHERE PLNum = '" + PLNumber + "' AND CNCode = '01'";
            sqlstatement += "GROUP By CustName, Piece, IB, Item, StockNumber, UserName";

            string sqlstatementRef;
            sqlstatementRef = "SELECT Reference FROM ViewPickListNumber  WHERE PLNum = '" + PLNumber + "' AND CNCode = '01' GROUP BY Reference";

            SqlDataAdapter dscmd = new SqlDataAdapter(sqlstatement, myconnection);
            DSInvBal DSInvBal1 = new DSInvBal();
            dscmd.Fill(DSInvBal1, "ViewPickListNumber");


            SqlDataAdapter dscmd1 = new SqlDataAdapter(sqlstatementRef, myconnection);
            DSPickListReference DSPickListReference1 = new DSPickListReference();
            dscmd1.Fill(DSPickListReference1, "ViewPickListNumberRef");
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
            //if (strchoose == "1")
            //{

            //    crystalReportViewer1.ReportSource = objRpt;
            //    crystalReportViewer1.Refresh();
            //}
            //else
            //{
            objRpt.Refresh();
                objRpt.PrintToPrinter(1, false, 0, 0);
            //}
        }
        public void clearScreen()
        {
            dgv1.Rows.Clear();
            ContentLoad();
            ClsAutoNumber1.VoucherAutoNumPLNumber("01");
            txtDocNum.Text = ClsAutoNumber1.plsnumber;
            ClsGetSomething1.ClsGetDefaultDate();
            txtTDate.Text = ClsGetSomething1.plsdefdate;
            cboWHCode.SelectedValue = "";
            cboPC.SelectedValue = "";
        }

        private void dgv1_Click(object sender, EventArgs e)
        {
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

        private void dgv1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgv1.CurrentRow.Cells[5].Value = null;
            dgv1.CurrentRow.Cells[6].Value = 0;
        }
    }
}
