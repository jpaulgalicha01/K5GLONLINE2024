using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace K5GLONLINE
{
    public partial class frmCheckSettings : Form
    {
        //ClsLogData ClsLogData1 = new ClsLogData();
        //ClsListEntry ClsListEntry1 = new ClsListEntry();
        ClsGetSomething ClsGetSomething1 = new ClsGetSomething();
        ClsBuildComboBox ClsBuildEntryComboBox1 = new ClsBuildComboBox();
        public DataTable DTTempTable = new DataTable();
        SqlConnection myconnection;
        SqlDataReader dr;
        private SqlDataAdapter da;
        private DataTable dataTable = null;
        private BindingSource bindingSource = null;
        SqlCommand mycommand;
        //ClsCompName ClsCompName1 = new ClsCompName();
        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();

        //string pristrDocNum, pristrVoucher, pristrCheckNo, pristrTDate;

        private String varDate1 = DateTime.Today.ToShortDateString();
        //private string pristrIPAddess = new ClsGetIPAddress().GetIPAddress();
        public frmCheckSettings()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCheckSettings_Load(object sender, EventArgs e)
        {
            ClsPermission1.ClsObjects(this.Text);
            if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
            {
                MessageBox.Show("You do not have necessary permission to open this file", "GL");
                this.Close();
            }
            else
            {
                CreateDTTempTable();
                DepositCheckSetUp();
            }
        }

        public void CreateDTTempTable()
        {
            DTTempTable.Columns.Add("BankCode", typeof(string));
            DTTempTable.Columns.Add("BankName", typeof(string));
            DTTempTable.Columns.Add("XDate", typeof(int));
            DTTempTable.Columns.Add("YDate", typeof(int));
            DTTempTable.Columns.Add("XCustName", typeof(int));
            DTTempTable.Columns.Add("YCustName", typeof(int));
            DTTempTable.Columns.Add("XCAmount", typeof(int));
            DTTempTable.Columns.Add("YCAmount", typeof(int));
            DTTempTable.Columns.Add("XAmtInWord", typeof(int));
            DTTempTable.Columns.Add("YAmtInWord", typeof(int));
            DTTempTable.Columns.Add("SizeFont", typeof(int));
            DTTempTable.Columns.Add("XCompDoc", typeof(int));
            DTTempTable.Columns.Add("YCompDoc", typeof(int));
        }


        public void DepositCheckSetUp()
        {
            //dgv1.DataSource = null;
            //dgv1.Columns.Clear();
            //DTTempTable.Rows.Clear();

            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);

            string SqlSentenceView;
            SqlSentenceView = "SELECT BankCode, BankName, XDate, YDate, XCustName, YCustName, XCAmount, YCAmount, XAmtInWord, YAmtInWord, SizeFont, XCompDoc, YCompDoc FROM tblCheckWriterSetup ORDER BY BankCode";

            da = new SqlDataAdapter(SqlSentenceView, myconnection);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);

            dataTable = new DataTable();
            da.Fill(dataTable);
            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;

            DataGridViewTextBoxColumn ColumnBankCode = new DataGridViewTextBoxColumn();
            ColumnBankCode.HeaderText = "Bank Code";
            ColumnBankCode.Width = 56;
            ColumnBankCode.DataPropertyName = "BankCode";
            ColumnBankCode.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnBankCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnBankCode.ReadOnly = false;
            ColumnBankCode.Visible = true;
            dgv1.Columns.Add(ColumnBankCode);

            DataGridViewTextBoxColumn ColumnBank = new DataGridViewTextBoxColumn();
            ColumnBank.HeaderText = "Bank";
            ColumnBank.Width = 155;
            ColumnBank.DataPropertyName = "BankName";
            ColumnBank.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnBank.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnBank.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnBank.ReadOnly = false;
            dgv1.Columns.Add(ColumnBank);

            DataGridViewTextBoxColumn ColumnXDate = new DataGridViewTextBoxColumn();
            ColumnXDate.HeaderText = "Column Date";
            ColumnXDate.Width = 73;
            ColumnXDate.DataPropertyName = "XDate";
            ColumnXDate.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnXDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv1.Columns.Add(ColumnXDate);


            //Adding  StockNumber TextBox
            DataGridViewTextBoxColumn ColumnYDate = new DataGridViewTextBoxColumn();
            ColumnYDate.HeaderText = "Row Date";
            ColumnYDate.Width = 72;
            ColumnYDate.DataPropertyName = "YDate";
            ColumnYDate.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnYDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnYDate.ReadOnly = false;
            ColumnYDate.Visible = true;
            dgv1.Columns.Add(ColumnYDate);

            DataGridViewTextBoxColumn ColumnXPName = new DataGridViewTextBoxColumn();
            ColumnXPName.HeaderText = "Column Name";
            ColumnXPName.Width = 72;
            ColumnXPName.DataPropertyName = "XCustName";
            ColumnXPName.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnXPName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnXPName.ReadOnly = false;
            ColumnXPName.Visible = true;
            dgv1.Columns.Add(ColumnXPName);


            //Adding  BarCode TextBox
            DataGridViewTextBoxColumn ColumnYPName = new DataGridViewTextBoxColumn();
            ColumnYPName.HeaderText = "Row Name";
            ColumnYPName.Width = 72;
            ColumnYPName.DataPropertyName = "YCustName";
            ColumnYPName.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnYPName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnYPName.ReadOnly = false;
            ColumnYPName.Visible = true;
            dgv1.Columns.Add(ColumnYPName);

            DataGridViewTextBoxColumn ColumnXCAmount = new DataGridViewTextBoxColumn();
            ColumnXCAmount.HeaderText = "Column Cash Amt";
            ColumnXCAmount.Width = 72;
            ColumnXCAmount.DataPropertyName = "XCAmount";
            ColumnXCAmount.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnXCAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnXCAmount.ReadOnly = false;
            ColumnXCAmount.Visible = true;
            dgv1.Columns.Add(ColumnXCAmount);

            DataGridViewTextBoxColumn ColumnYCAmount = new DataGridViewTextBoxColumn();
            ColumnYCAmount.HeaderText = "Row Cash Amt";
            ColumnYCAmount.Width = 72;
            ColumnYCAmount.DataPropertyName = "YCAmount";
            ColumnYCAmount.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnYCAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnYCAmount.ReadOnly = false;
            ColumnYCAmount.Visible = true;
            dgv1.Columns.Add(ColumnYCAmount);

            DataGridViewTextBoxColumn ColumnXAmtInWord = new DataGridViewTextBoxColumn();
            ColumnXAmtInWord.HeaderText = "Column Amt In Word";
            ColumnXAmtInWord.Width = 72;
            ColumnXAmtInWord.DataPropertyName = "XAmtInWord";
            ColumnXAmtInWord.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnXAmtInWord.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnXAmtInWord.ReadOnly = false;
            ColumnXAmtInWord.Visible = true;
            dgv1.Columns.Add(ColumnXAmtInWord);

            DataGridViewTextBoxColumn ColumnYAmtInWord = new DataGridViewTextBoxColumn();
            ColumnYAmtInWord.HeaderText = "Row Amt In Word";
            ColumnYAmtInWord.Width = 73;
            ColumnYAmtInWord.DataPropertyName = "YAmtInWord";
            ColumnYAmtInWord.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnYAmtInWord.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnYAmtInWord.ReadOnly = false;
            ColumnYAmtInWord.Visible = true;
            dgv1.Columns.Add(ColumnYAmtInWord);

            DataGridViewTextBoxColumn ColumnSizeFont = new DataGridViewTextBoxColumn();
            ColumnSizeFont.HeaderText = "Size Font";
            ColumnSizeFont.Width = 72;
            ColumnSizeFont.DataPropertyName = "SizeFont";
            ColumnSizeFont.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnSizeFont.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnSizeFont.ReadOnly = false;
            ColumnSizeFont.Visible = true;
            dgv1.Columns.Add(ColumnSizeFont);

            DataGridViewTextBoxColumn ColumnXCompDoc = new DataGridViewTextBoxColumn();
            ColumnXCompDoc.HeaderText = "Column Document";
            ColumnXCompDoc.Width = 73;
            ColumnXCompDoc.DataPropertyName = "XCompDoc";
            ColumnXCompDoc.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnXCompDoc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnXCompDoc.ReadOnly = false;
            ColumnXCompDoc.Visible = true;
            dgv1.Columns.Add(ColumnXCompDoc);

            DataGridViewTextBoxColumn ColumnYCompDoc = new DataGridViewTextBoxColumn();
            ColumnYCompDoc.HeaderText = "Row Document";
            ColumnYCompDoc.Width = 73;
            ColumnYCompDoc.DataPropertyName = "YCompDoc";
            ColumnYCompDoc.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnYCompDoc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnYCompDoc.ReadOnly = false;
            ColumnYCompDoc.Visible = true;
            dgv1.Columns.Add(ColumnYCompDoc);

            //dgv1.DataSource = DTTempTable;
            dgv1.DataSource = bindingSource;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmAddCheckFormat frmAddCheckFormat1 = new frmAddCheckFormat(this);
            frmAddCheckFormat1.Show();
        }

       
        private void dgv1_DoubleClick(object sender, EventArgs e)
        {
            frmEditCheckFormat frmEditCheckFormat1 = new frmEditCheckFormat(this);
            frmEditCheckFormat1.Show();
        }

    }
}




//private void btnSave_Click(object sender, EventArgs e)
//{
//    bool emptycell = false;

//    for (int i = 0; i < dgv1.Rows.Count; i++)
//    {
//        for (int x = 0; x < dgv1.ColumnCount - 1; x++)
//        {
//            if (dgv1.Rows[i].Cells[x].Value.ToString() == "")
//            {
//                dgv1.CurrentCell = dgv1.Rows[i].Cells[x];
//                dgv1.BeginEdit(true);
//                emptycell = true;
//                break;
//            }

//        }
//    }
//    if (emptycell == true)
//    {
//        MessageBox.Show("Please fill all cells!", "MFCGL");
//    }
//    else
//    {
//        MessageBox.Show("POST ALL");
//    }

//}
