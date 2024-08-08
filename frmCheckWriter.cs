using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace K5GLONLINE
{
    public partial class frmCheckWriter : Form
    {

        //ClsLogData ClsLogData1 = new ClsLogData();
        //ClsListEntry ClsListEntry1 = new ClsListEntry();
        SqlConnection myconnection;
        SqlDataReader dr;
        SqlCommand mycommand;
        private SqlDataAdapter da;
        private DataTable dataTable = null;
        private BindingSource bindingSource = null;
        //ClsCompName ClsCompName1 = new ClsCompName();
        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();
        ClsBuildEntryComboBox ClsBuildEntryComboBox1 = new ClsBuildEntryComboBox();
        ClsCompName ClsCompName1 = new ClsCompName();
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        ClsGetSomething ClsGetSomething1 = new ClsGetSomething();
        Font font;
        string pristrDocNum, pristrVoucher, pristrCheckNo, pristrTDate, pristrMonth, pristrDay, pristrYear;
        //private String varDate1 = DateTime.Today.ToShortDateString();
        //private string pristrIPAddess = new ClsGetIPAddress().GetIPAddress();

        int xstrDate = 0;// |
        int ystrDate = 0;// _
        int xstrtxtCustName = 0;// |
        int ystrtxtCustName = 0;// _
        int xstrtxtcamount = 0;// |
        int ystrtxtcamount = 0;// _
        int xstramtinword = 0;// |
        int ystramtinword = 0;// _
        int intsizefont = 0;
        int xstrComputerDoc = 0;//|
        int ystrComputerDoc = 0;//_


        public frmCheckWriter()
        {
            InitializeComponent();
        }

        private void frmCheckWriter_Load(object sender, EventArgs e)
        {

            //DateTime varDate2 = Convert.ToDateTime(varDate1);
            ClsPermission1.ClsObjects(this.Text);
            if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
            {
                MessageBox.Show("You do not have necessary permission to open this file", "GL");
                this.Close();
            }
            else
            {
                //ClsBuildEntryComboBox1.BuildCNCode(cboCNCode);
                //ClsBuildEntryComboBox1.BuildBankCode(cboBankCode);
                buildcboBankCode();
                //await Task.Delay(300);
                ClsCompName1.ClsCompNameMain();
                cboCNCode.Text = ClsCompName1.varcn;
                ClsGetSomething1.ClsGetDefaultDate();
                dtpFrom.Text = ClsGetSomething1.plsdefdate;
                dtpTo.Text = ClsGetSomething1.plsdefdate;
            }
        }

        private void buildcboBankCode()
        {
            cboBankCode.DataSource = null;
            ClsBuildEntryComboBox1.ARBankCode.Clear();
            ClsBuildEntryComboBox1.ClsBuildBankCode();
            this.cboBankCode.DataSource = (ClsBuildEntryComboBox1.ARBankCode);
            this.cboBankCode.DisplayMember = "Display";
            this.cboBankCode.ValueMember = "Value";
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            LoadList();
            cboBankCode.Focus();
        }

        private void dgv1_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow row = dgv1.CurrentRow;

            double varCAmt = double.Parse(row.Cells[6].FormattedValue.ToString());
            pristrDocNum = row.Cells[0].FormattedValue.ToString();
            pristrVoucher = row.Cells[1].FormattedValue.ToString();
            txtCustName.Text = row.Cells[2].FormattedValue.ToString();
            pristrCheckNo = row.Cells[4].FormattedValue.ToString();
            pristrTDate = row.Cells[5].FormattedValue.ToString();
            txtcamount.Text = varCAmt.ToString("N2");

            double waa = double.Parse(txtcamount.Text);

            int wab = (int)waa;

            string wac = (Calculateamount(waa, wab)).ToString();
            string damtcent = Convert.ToDouble(wac).ToString("N2");
            convertcents cvcnts = new convertcents();
            string dwordcent = cvcnts.getconvertcents(damtcent);

            double a = double.Parse(txtcamount.Text);
            int b = (int)a;
            NumberToWordsConvertor ntwc = new NumberToWordsConvertor();
            string trimdamt = ntwc.NumberToWords(b);
            txtamtinwords.Text = trimdamt.Trim() + " Pesos And " + dwordcent;

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            runsearch();
            if (new ClsValidation().emptytxt(txtcamount.Text))
            {
                MessageBox.Show("Please select transaction number", "GL");
                dgv1.Focus();
            }
            else if (new ClsValidation().emptytxt(cboBankCode.Text))
            {
                MessageBox.Show("Please choose bank", "GL");
                cboBankCode.Focus();
                cboBankCode.DroppedDown = true;
            }
            else
            {


                PrintDialog printDialog = new PrintDialog();
                PrintDocument printDocument = new PrintDocument();
                printDialog.Document = printDocument;
                printDocument.PrintPage += new PrintPageEventHandler(printDocumentBank);
                printDocument.Print();
            }
        }

        private void LoadList()
        {
            if (Convert.ToDateTime(dtpFrom.Text) > Convert.ToDateTime(dtpTo.Text))
            {
                MessageBox.Show("Beginning date is greater than ending date");
                dtpTo.Focus();
            }
            else
            {
                showsearchdata();
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmCheckSettings frmCheckSettings1 = new frmCheckSettings();
            frmCheckSettings1.Show();
        }
        private void dgv1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow row = dgv1.CurrentRow;

            double varCAmt = double.Parse(row.Cells[6].FormattedValue.ToString());
            pristrDocNum = row.Cells[0].FormattedValue.ToString();
            pristrVoucher = row.Cells[1].FormattedValue.ToString();
            txtCustName.Text = row.Cells[2].FormattedValue.ToString();
            pristrCheckNo = row.Cells[4].FormattedValue.ToString();
            pristrTDate = row.Cells[5].FormattedValue.ToString();
            //DateTime strDate = Convert.ToDateTime(pristrTDate);
            //pristrMonth = Convert.ToString(strDate.Month).PadLeft(2, '0');
            //pristrDay = Convert.ToString(strDate.Day).PadLeft(2, '0');
            //pristrYear = Convert.ToString(strDate.Year).ToString();
            txtcamount.Text = varCAmt.ToString("N2");

            double waa = double.Parse(txtcamount.Text);
            int wab = (int)waa;

            string wac = (Calculateamount(waa, wab)).ToString();
            string damtcent = Convert.ToDouble(wac).ToString("N2");
            convertcents cvcnts = new convertcents();
            string dwordcent = cvcnts.getconvertcents(damtcent);

            double a = double.Parse(txtcamount.Text);
            int b = (int)a;
            NumberToWordsConvertor ntwc = new NumberToWordsConvertor();
            string trimdamt = ntwc.NumberToWords(b);
            txtamtinwords.Text = trimdamt.Trim() + " Pesos And " + dwordcent;
        }

        public static double Calculateamount(double wamt, int ramt)
        {
            return wamt - ramt;
        }

        private void cboBankCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            runsearch();
        }

        private void showsearchdata()
        {
            dgv1.DataSource = null;
            dgv1.Columns.Clear();
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            //var varList = await ClsListEntry1.GetViewCheckWriterList(dtpFrom.Text, dtpTo.Text, cboCNCode.SelectedValue.ToString());

            string SqlSentenceView;

            SqlSentenceView = "SELECT DocNum, Voucher, CustName, (D2Desc) AS BankActEntry, (Check#) AS CheckNo, TDate, CAmount FROM ViewCheckWriter WHERE TDate BETWEEN '" + dtpFrom.Text + "' AND '" + dtpTo.Text + "' ORDER BY DocNum";
            da = new SqlDataAdapter(SqlSentenceView, myconnection);
            da.SelectCommand.CommandTimeout = 600;
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
            dataTable = new DataTable();
            da.Fill(dataTable);
            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;
            //myconnection = new SqlConnection(new ClsGetConnection().PlsConnect());
            //myconnection.Open();
            //mycommand = new SqlCommand(SqlSentenceView, myconnection);
            //dr = mycommand.ExecuteReader();
            //while (dr.Read())
            //{
            //    ModelViewCheckWriter ModelViewCheckWriter1 = new ModelViewCheckWriter
            //    {

            //        DocNum = dr["DocNum"].ToString(),
            //        Credit = double.Parse(dr["Credit"].ToString()),
            //        AcctNo = dr["AcctNo"].ToString(),
            //        CNCode = dr["CNCode"].ToString(),
            //        BankActEntry = dr["BankActEntry"].ToString(),
            //        CheckNo = dr["CheckNo"].ToString(),
            //        CAmount = double.Parse(dr["CAmount"].ToString()),
            //        TDate = DateTime.Parse(dr["TDate"].ToString()),
            //        CustName = dr["CustName"].ToString(),
            //        Voucher = dr["Voucher"].ToString(),
            //    };
            //    ModelViewCheckWriterMSSQL.Add(ModelViewCheckWriter1);
            //}
            //myconnection.Close();

            DataGridViewTextBoxColumn ColumnNumber = new DataGridViewTextBoxColumn();
            ColumnNumber.HeaderText = "Number";
            ColumnNumber.Width = 65;
            ColumnNumber.DataPropertyName = "DocNum";
            //ColumnNumber.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnNumber.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnNumber.Visible = true;
            dgv1.Columns.Add(ColumnNumber);

            //Adding  Voucher TextBox
            DataGridViewTextBoxColumn ColumnVoucher = new DataGridViewTextBoxColumn();
            ColumnVoucher.HeaderText = "Voucher";
            ColumnVoucher.Width = 60;
            ColumnVoucher.DataPropertyName = "Voucher";
            //ColumnVoucher.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnVoucher.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //ColumnVoucher.Visible = false;
            ColumnVoucher.ReadOnly = true;
            dgv1.Columns.Add(ColumnVoucher);

            // Adding  CustName TextBox
            DataGridViewTextBoxColumn ColumnCustName = new DataGridViewTextBoxColumn();
            ColumnCustName.HeaderText = "Name";
            ColumnCustName.Width = 225;
            ColumnCustName.DataPropertyName = "CustName";
            ColumnCustName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //ColumnCustName.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnCustName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnCustName.Visible = true;
            dgv1.Columns.Add(ColumnCustName);

            // Adding  BankActEntry TextBox
            DataGridViewTextBoxColumn ColumnBankActEntry = new DataGridViewTextBoxColumn();
            ColumnBankActEntry.HeaderText = "Bank";
            ColumnBankActEntry.Width = 180;
            ColumnBankActEntry.DataPropertyName = "BankActEntry";
            //ColumnBankActEntry.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnBankActEntry.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnBankActEntry.Visible = true;
            dgv1.Columns.Add(ColumnBankActEntry);

            // Adding  CheckNo TextBox
            DataGridViewTextBoxColumn ColumnCheckNo = new DataGridViewTextBoxColumn();
            ColumnCheckNo.HeaderText = "Check No.";
            ColumnCheckNo.Width = 126;
            ColumnCheckNo.DataPropertyName = "CheckNo";
            //ColumnCheckNo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnCheckNo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnCheckNo.Visible = true;
            dgv1.Columns.Add(ColumnCheckNo);

            //Adding  Date TextBox
            DataGridViewTextBoxColumn ColumnTDate = new DataGridViewTextBoxColumn();
            ColumnTDate.HeaderText = "Date";
            ColumnTDate.Width = 75;
            ColumnTDate.DataPropertyName = "TDate";
            //ColumnTDate.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnTDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //ColumnTDate.Visible = false;
            ColumnTDate.ReadOnly = true;
            dgv1.Columns.Add(ColumnTDate);

            //Adding  Credit TextBox
            DataGridViewTextBoxColumn ColumnCredit = new DataGridViewTextBoxColumn();
            ColumnCredit.HeaderText = "Amount";
            ColumnCredit.Width = 100;
            ColumnCredit.DataPropertyName = "CAmount";
            //ColumnCredit.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnCredit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnCredit.ReadOnly = true;
            dgv1.Columns.Add(ColumnCredit);

            dgv1.DataSource = bindingSource;
            myconnection.Close();

            //dgv1.DataSource = varList;
            dgv1.Columns[6].DefaultCellStyle.Format = "N2";
            dgv1.Columns[5].DefaultCellStyle.Format = "MM/dd/yyyy";

        }
        public void runsearch()
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            string SqlSentenceView = "SELECT BankCode, BankName, XDate, YDate, XCustName, YCustName, XCAmount, YCAmount, XAmtInWord, YAmtInWord, SizeFont, XCompDoc, YCompDoc FROM tblCheckWriterSetup WHERE BankCode='"+cboBankCode.SelectedValue.ToString()+"'";
            myconnection.Open();
            mycommand = new SqlCommand(SqlSentenceView, myconnection);
            dr = mycommand.ExecuteReader();
            while (dr.Read())
            {
                //BankCode = dr["BankCode"].ToString();
                //BankName = dr["BankName"].ToString();
                xstrDate = int.Parse(dr["XDate"].ToString());
                ystrDate = int.Parse(dr["YDate"].ToString());
                xstrtxtCustName = int.Parse(dr["XCustName"].ToString());
                ystrtxtCustName = int.Parse(dr["YCustName"].ToString());
                xstrtxtcamount = int.Parse(dr["XCAmount"].ToString());
                ystrtxtcamount = int.Parse(dr["YCAmount"].ToString());
                xstramtinword = int.Parse(dr["XAmtInWord"].ToString());
                ystramtinword = int.Parse(dr["YAmtInWord"].ToString());
                xstrComputerDoc = int.Parse(dr["XCompDoc"].ToString());
                ystrComputerDoc = int.Parse(dr["YCompDoc"].ToString());
                intsizefont = int.Parse(dr["SizeFont"].ToString());
            }
            myconnection.Close();
        }
        public void printDocumentBank(object sender, PrintPageEventArgs e)
        {
            // 0pristrDocNum, 1pristrVoucher, 2pristrCustName,  4pristrCheckNo, 5pristrTDate, 6pristrCredit;

            Graphics graphic = e.Graphics;
            string strDate = pristrTDate;
            string strtxtCustName = txtCustName.Text;
            string strtxtcamount = txtcamount.Text;
            string stramtinword = txtamtinwords.Text;
            string strComputerDoc = pristrVoucher + pristrDocNum;


            //changing formate of TDate
            string transformedDate = "";
            foreach (char c in strDate)
            {
                transformedDate += c + "  ";
            }
            transformedDate = transformedDate.Replace("/", "");
            transformedDate = transformedDate.Trim();

            //ClsGetSomething1.ClsGetCheckWriterCheckUp(cboBankCode.SelectedValue.ToString());
            graphic.DrawString(transformedDate, new Font("Times New Roman", 14), new SolidBrush(Color.Black), xstrDate, ystrDate);
            graphic.DrawString(strtxtCustName, new Font("Times New Roman", intsizefont), new SolidBrush(Color.Black), xstrtxtCustName, ystrtxtCustName);
            graphic.DrawString(strtxtcamount, new Font("Times New Roman", intsizefont), new SolidBrush(Color.Black), xstrtxtcamount, ystrtxtcamount);
            graphic.DrawString(stramtinword, new Font("Times New Roman", intsizefont), new SolidBrush(Color.Black), xstramtinword, ystramtinword);
            graphic.DrawString(strComputerDoc, new Font("Times New Roman", intsizefont), new SolidBrush(Color.Black), xstrComputerDoc, ystrComputerDoc);
            //          offset = offset + 20;

        }

        private void cboBankCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            runsearch();
        }
    }
}
