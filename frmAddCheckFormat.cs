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
    public partial class frmAddCheckFormat : Form
    {
        ClsAutoNumber ClsAutoNumber1 = new ClsAutoNumber();
        //ClsLogData ClsLogData1 = new ClsLogData();
        //private string pristrIPAddess = new ClsGetIPAddress().GetIPAddress();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        ClsPermission ClsPermission1 = new ClsPermission();
        readonly frmCheckSettings frmCheckSettings1;
        SqlConnection myconnection;
        SqlCommand mycommand;
        public frmAddCheckFormat(frmCheckSettings frmCheckSettings)
        {
            frmCheckSettings1 = frmCheckSettings;
            InitializeComponent();
        }
        private void frmAddCheckFormat_Load(object sender, EventArgs e)
        {
            ClsPermission1.ClsObjects(this.Text);
            if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
            {
                MessageBox.Show("You do not have necessary permission to open this file", "GL");
                this.Close();
            }
            else
            {
                ClsAutoNumber1.GetBankCheckAddAutoNum();
                txtBankCode.Text = (ClsAutoNumber1.plsnumber);
            }

        }
        private void GetAutoNum()
        {
            //txtBankCode.Text = await ClsAutoNumber2.BankCheckAddAutoNum();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CellNextEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            ValidateNewCheckFormat();
        }
        private void ValidateNewCheckFormat()
        {
            if (string.IsNullOrEmpty(txtBankName.Text))
            {
                MessageBox.Show("Please complete your entry!", "Bank Name.");
                txtBankName.Focus();
            }
            else if (string.IsNullOrEmpty(txtFontSize.Text) || int.Parse(txtFontSize.Text) < 1)
            {
                MessageBox.Show("Please complete your entry!", "Font size.");
                txtFontSize.Focus();
            }
            else if (string.IsNullOrEmpty(txtXDate.Text) || int.Parse(txtXDate.Text) < 1)
            {
                MessageBox.Show("Please complete your entry!", "X-Date.");
                txtXDate.Focus();
            }
            else if (string.IsNullOrEmpty(txtYDate.Text) || int.Parse(txtYDate.Text) < 1)
            {
                MessageBox.Show("Please complete your entry!", "Y-Date.");
                txtYDate.Focus();
            }
            else if (string.IsNullOrEmpty(txtXCustName.Text) || int.Parse(txtXCustName.Text) < 1)
            {
                MessageBox.Show("Please complete your entry!", "X-Customer Name.");
                txtXCustName.Focus();
            }
            else if (string.IsNullOrEmpty(txtYCustName.Text) || int.Parse(txtYCustName.Text) < 1)
            {
                MessageBox.Show("Please complete your entry!", "X-Customer Name.");
                txtYCustName.Focus();
            }
            else if (string.IsNullOrEmpty(txtXAmount.Text) || int.Parse(txtXAmount.Text) < 1)
            {
                MessageBox.Show("Please complete your entry!", "X-Amount.");
                txtXAmount.Focus();
            }
            else if (string.IsNullOrEmpty(txtYAmount.Text) || int.Parse(txtYAmount.Text) < 1)
            {
                MessageBox.Show("Please complete your entry!", "Y-Amount.");
                txtYAmount.Focus();
            }
            else if (string.IsNullOrEmpty(txtXAmountWords.Text) || int.Parse(txtXAmountWords.Text) < 1)
            {
                MessageBox.Show("Please complete your entry!", "X-Amount in Words.");
                txtXAmountWords.Focus();
            }
            else if (string.IsNullOrEmpty(txtYAmountWords.Text) || int.Parse(txtYAmountWords.Text) < 1)
            {
                MessageBox.Show("Please complete your entry!", "Y-Amount in Words.");
                txtYAmountWords.Focus();
            }
            else if (string.IsNullOrEmpty(txtXCompDoc.Text) || int.Parse(txtXCompDoc.Text) < 1)
            {
                MessageBox.Show("Please complete your entry!", "X-Comp Doc.");
                txtXCompDoc.Focus();
            }
            else if (string.IsNullOrEmpty(txtYCompDoc.Text) || int.Parse(txtYCompDoc.Text) < 1)
            {
                MessageBox.Show("Please complete your entry!", "Y-Comp Doc.");
                txtYCompDoc.Focus();
            }
            else
            {
                SaveNewFormat();
            }
        }

        private void SaveNewFormat()
        {
            //ModeltblCheckWriterSetup ModeltblCheckWriterSetup1 = new ModeltblCheckWriterSetup()
            //{

            //    BankName = txtBankName.Text,
            //    XDate = int.Parse(txtXDate.Value.ToString()),
            //    YDate = int.Parse(txtYDate.Value.ToString()),
            //    XCustName = int.Parse(txtXCustName.Value.ToString()),
            //    YCustName = int.Parse(txtYCustName.Value.ToString()),
            //    XCAmount = int.Parse(txtXAmount.Value.ToString()),
            //    YCAmount = int.Parse(txtYAmount.Value.ToString()),
            //    XAmtInWord = int.Parse(txtXAmountWords.Value.ToString()),
            //    YAmtInWord = int.Parse(txtYAmountWords.Value.ToString()),
            //    SizeFont = int.Parse(txtFontSize.Value.ToString()),
            //    XCompDoc = int.Parse(txtXCompDoc.Value.ToString()),
            //    YCompDoc = int.Parse(txtYCompDoc.Value.ToString()),
            //};

            //var json = JsonConvert.SerializeObject(ModeltblCheckWriterSetup1);
            //var content = new StringContent(json, Encoding.UTF8, "application/json");
            //HttpClient client = new HttpClient();
            //var result = await client.PostAsync($"{pristrIPAddess}/API/WEBAPIMFCGL/Entry/InsertNewCheckFormat", content);
            //if (result.IsSuccessStatusCode)
            //{
            //    MessageBox.Show("Saved", "MFCGL");

            //    frmCheckSettings1.dgv1.DataSource = null;
            //    frmCheckSettings1.dgv1.Columns.Clear();
            //    frmCheckSettings1.DepositCheckSetUp();
            //    this.Close();
            //}
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);

                string SqlStatement = "INSERT INTO tblCheckWriterSetup (BankCode, BankName, XDate, YDate, XCustName, YCustName, XCAmount, YCAmount, XAmtInWord, YAmtInWord, SizeFont, XCompDoc, YCompDoc )";
                SqlStatement += "Values (@_BankCode, @_BankName, @_XDate, @_YDate, @_XCustName, @_YCustName, @_XCAmount, @_YCAmount, @_XAmtInWord, @_YAmtInWord, @_SizeFont, @_XCompDoc, @_YCompDoc)";
                myconnection.Open();
                mycommand = new SqlCommand(SqlStatement, myconnection);
                mycommand.Parameters.Add("_BankCode", SqlDbType.Char).Value = txtBankCode.Text;
                mycommand.Parameters.Add("_BankName", SqlDbType.VarChar).Value = txtBankName.Text;
                mycommand.Parameters.Add("_XDate", SqlDbType.SmallInt).Value = txtXDate.Value;
                mycommand.Parameters.Add("_YDate", SqlDbType.SmallInt).Value = txtYDate.Value;
                mycommand.Parameters.Add("_XCustName", SqlDbType.SmallInt).Value = txtXCustName.Value;
                mycommand.Parameters.Add("_YCustName", SqlDbType.SmallInt).Value = txtYCustName.Value;
                mycommand.Parameters.Add("_XCAmount", SqlDbType.SmallInt).Value = txtXAmount.Value;
                mycommand.Parameters.Add("_YCAmount", SqlDbType.SmallInt).Value = txtYAmount.Value;
                mycommand.Parameters.Add("_XAmtInWord", SqlDbType.SmallInt).Value = txtXAmountWords.Value;
                mycommand.Parameters.Add("_YAmtInWord", SqlDbType.SmallInt).Value = txtYAmountWords.Value;
                mycommand.Parameters.Add("_SizeFont", SqlDbType.SmallInt).Value = txtFontSize.Value;
                mycommand.Parameters.Add("_XCompDoc", SqlDbType.SmallInt).Value = txtXCompDoc.Value;
                mycommand.Parameters.Add("_YCompDoc", SqlDbType.SmallInt).Value = txtYCompDoc.Value;
                int n2 = mycommand.ExecuteNonQuery();
                myconnection.Close();

                MessageBox.Show("Saved", "GL");
            }
            catch (Exception exceptionObj)
            {
                MessageBox.Show(exceptionObj.Message.ToString());
            }
        }

    }
}
