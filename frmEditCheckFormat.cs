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
    public partial class frmEditCheckFormat : Form
    {
        frmCheckSettings frmCheckSettings1;
        ClsPermission ClsPermission1 = new ClsPermission();
        SqlConnection myconnection;
        SqlCommand mycommand;
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        //ClsLogData ClsLogData1 = new ClsLogData();
        //private string pristrIPAddress = new ClsGetIPAddress().GetIPAddress();

        public frmEditCheckFormat(frmCheckSettings frmCheckSettings)
        {
            frmCheckSettings1 = frmCheckSettings;
            InitializeComponent();
        }
        private void frmEditCheckFormat_Load(object sender, EventArgs e)
        {
            ClsPermission1.ClsObjects(this.Text);
            if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
            {
                MessageBox.Show("You do not have necessary permission to open this file", "GL");
                this.Close();
            }
            else
            {
                loadNumbers();
                PanelDisplayss();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

            PanelDisplayss();

            //double dddd = 105.0f + 105.0F * .133333;
            //double dddd2 = 65.0f + 65.0F * .133333;
            //SolidBrush solidBrush = new SolidBrush(Color.Black);
            //Graphics gpanel = panelpaper.CreateGraphics();
            //System.Drawing.Font fonts = new System.Drawing.Font("Times New Roman", 14);
            //gpanel.DrawString(lblName.Text.ToString(), fonts, solidBrush, float.Parse(dddd.ToString()), float.Parse(dddd2.ToString())); ;

        }

        private void loadNumbers()
        {
            txtBankCode.Text = frmCheckSettings1.dgv1.CurrentRow.Cells[0].Value.ToString();
            txtBankName.Text = frmCheckSettings1.dgv1.CurrentRow.Cells[1].Value.ToString();

            txtDateX.Value = int.Parse(frmCheckSettings1.dgv1.CurrentRow.Cells[2].Value.ToString());
            txtDateY.Value = int.Parse(frmCheckSettings1.dgv1.CurrentRow.Cells[3].Value.ToString());

            txtNameX.Value = int.Parse(frmCheckSettings1.dgv1.CurrentRow.Cells[4].Value.ToString());
            txtNameY.Value = int.Parse(frmCheckSettings1.dgv1.CurrentRow.Cells[5].Value.ToString());

            txtAmountX.Value = int.Parse(frmCheckSettings1.dgv1.CurrentRow.Cells[6].Value.ToString());
            txtAmountY.Value = int.Parse(frmCheckSettings1.dgv1.CurrentRow.Cells[7].Value.ToString());

            txtWordsX.Value = int.Parse(frmCheckSettings1.dgv1.CurrentRow.Cells[8].Value.ToString());
            txtWordsY.Value = int.Parse(frmCheckSettings1.dgv1.CurrentRow.Cells[9].Value.ToString());

            txtDocX.Value = int.Parse(frmCheckSettings1.dgv1.CurrentRow.Cells[11].Value.ToString());
            txtDocY.Value = int.Parse(frmCheckSettings1.dgv1.CurrentRow.Cells[12].Value.ToString());
            PanelDisplayss();
        }

        private void PanelDisplayss()
        {

            double fontpercent = .133333;

            double namex = int.Parse(txtNameX.Value.ToString()) + int.Parse(txtNameX.Value.ToString()) * fontpercent;
            double namey = int.Parse(txtNameY.Value.ToString()) + int.Parse(txtNameY.Value.ToString()) * fontpercent;
            this.lblName.Location = new Point(Convert.ToInt32(namex), Convert.ToInt32(namey));


            double datex = int.Parse(txtDateX.Value.ToString()) + int.Parse(txtDateX.Value.ToString()) * fontpercent;
            double datey = int.Parse(txtDateY.Value.ToString()) + int.Parse(txtDateY.Value.ToString()) * fontpercent;
            this.lblDate.Location = new Point(Convert.ToInt32(datex), Convert.ToInt32(datey));


            double amountx = int.Parse(txtAmountX.Value.ToString()) + int.Parse(txtAmountX.Value.ToString()) * fontpercent;
            double amounty = int.Parse(txtAmountY.Value.ToString()) + int.Parse(txtAmountY.Value.ToString()) * fontpercent;
            this.lblTotal.Location = new Point(Convert.ToInt32(amountx), Convert.ToInt32(amounty));


            double wordsx = int.Parse(txtWordsX.Value.ToString()) + int.Parse(txtWordsX.Value.ToString()) * fontpercent;
            double wordsy = int.Parse(txtWordsY.Value.ToString()) + int.Parse(txtWordsY.Value.ToString()) * fontpercent;
            this.lblTotalWords.Location = new Point(Convert.ToInt32(wordsx), Convert.ToInt32(wordsy));


            double docux = int.Parse(txtDocX.Value.ToString()) + int.Parse(txtDocX.Value.ToString()) * fontpercent;
            double docuy = int.Parse(txtDocY.Value.ToString()) + int.Parse(txtDocY.Value.ToString()) * fontpercent;
            this.lblDocNum.Location = new Point(Convert.ToInt32(docux), Convert.ToInt32(docuy));

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtBankName.Text))
            {
                MessageBox.Show("Please complete your entry!", "Bank Name.");
                txtBankName.Focus();
            }
            else if (string.IsNullOrEmpty(txtDateX.Text) || int.Parse(txtDateX.Text) < 1)
            {
                MessageBox.Show("Please complete your entry!", "X-Date.");
                txtDateX.Focus();
            }
            else if (string.IsNullOrEmpty(txtDateY.Text) || int.Parse(txtDateY.Text) < 1)
            {
                MessageBox.Show("Please complete your entry!", "Y-Date.");
                txtDateY.Focus();
            }
            else if (string.IsNullOrEmpty(txtNameX.Text) || int.Parse(txtNameX.Text) < 1)
            {
                MessageBox.Show("Please complete your entry!", "X-Customer Name.");
                txtNameX.Focus();
            }
            else if (string.IsNullOrEmpty(txtNameY.Text) || int.Parse(txtNameY.Text) < 1)
            {
                MessageBox.Show("Please complete your entry!", "X-Customer Name.");
                txtNameY.Focus();
            }
            else if (string.IsNullOrEmpty(txtAmountX.Text) || int.Parse(txtAmountX.Text) < 1)
            {
                MessageBox.Show("Please complete your entry!", "X-Amount.");
                txtAmountX.Focus();
            }
            else if (string.IsNullOrEmpty(txtAmountY.Text) || int.Parse(txtAmountY.Text) < 1)
            {
                MessageBox.Show("Please complete your entry!", "Y-Amount.");
                txtAmountY.Focus();
            }
            else if (string.IsNullOrEmpty(txtWordsX.Text) || int.Parse(txtWordsX.Text) < 1)
            {
                MessageBox.Show("Please complete your entry!", "X-Amount in Words.");
                txtWordsX.Focus();
            }
            else if (string.IsNullOrEmpty(txtWordsY.Text) || int.Parse(txtWordsY.Text) < 1)
            {
                MessageBox.Show("Please complete your entry!", "Y-Amount in Words.");
                txtWordsY.Focus();
            }
            else if (string.IsNullOrEmpty(txtDocX.Text) || int.Parse(txtDocX.Text) < 1)
            {
                MessageBox.Show("Please complete your entry!", "X-Comp Doc.");
                txtDocX.Focus();
            }
            else if (string.IsNullOrEmpty(txtDocY.Text) || int.Parse(txtDocY.Text) < 1)
            {
                MessageBox.Show("Please complete your entry!", "Y-Comp Doc.");
                txtDocY.Focus();
            }
            else
            {
                UpdateCheckSettings();
            }
        }

        public void UpdateCheckSettings()
        {

            //ModeltblCheckWriterSetup ModeltblCheckWriterSetup1 = new ModeltblCheckWriterSetup()
            //{

            //    BankCode = txtBankCode.Text,
            //    BankName = txtBankName.Text,
            //    XDate = int.Parse(txtDateX.Value.ToString()),
            //    YDate = int.Parse(txtDateY.Value.ToString()),
            //    XCustName = int.Parse(txtNameX.Value.ToString()),
            //    YCustName = int.Parse(txtNameY.Value.ToString()),
            //    XCAmount = int.Parse(txtAmountX.Value.ToString()),
            //    YCAmount = int.Parse(txtAmountY.Value.ToString()),
            //    XAmtInWord = int.Parse(txtWordsX.Value.ToString()),
            //    YAmtInWord = int.Parse(txtWordsY.Value.ToString()),
            //    //SizeFont = int.Parse(txtFontSize.Value.ToString()),
            //    XCompDoc = int.Parse(txtDocX.Value.ToString()),
            //    YCompDoc = int.Parse(txtDocY.Value.ToString()),
            //};
            //var json = JsonConvert.SerializeObject(ModeltblCheckWriterSetup1);
            //var content = new StringContent(json, Encoding.UTF8, "application/json");
            //HttpClient client = new HttpClient();
            //var result = await client.PutAsync($"{pristrIPAddress}/API/WEBAPIMFCGL/Entry/UpdateCheckWriterSetup", content);
            //if (result.IsSuccessStatusCode)
            //{
            //    frmCheckSettings1.dgv1.DataSource = null;
            //    frmCheckSettings1.dgv1.Columns.Clear();
            //    frmCheckSettings1.DepositCheckSetUp();
            //    this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("Something Error from Update", "MFCGL");

            //}
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            string SqlStatement = "UPDATE tblCheckWriterSetup SET BankName = @_BankName, XDate = @_XDate, YDate = @_YDate, XCustName = @_XCustName, YCustName = @_YCustName, XCAmount = @_XCAmount, YCAmount = @_YCAmount, XAmtInWord = @_XAmtInWord, YAmtInWord = @_YAmtInWord, XCompDoc = @_XCompDoc, YCompDoc = @_YCompDoc WHERE BankCode= '"+txtBankCode.Text+"'";
            myconnection.Open();
            mycommand = new SqlCommand(SqlStatement, myconnection);
            mycommand.Parameters.Add("_BankName", SqlDbType.VarChar).Value = txtBankName.Text;
            mycommand.Parameters.Add("_XDate", SqlDbType.SmallInt).Value = txtDateX.Value;
            mycommand.Parameters.Add("_YDate", SqlDbType.SmallInt).Value = txtDateY.Value;
            mycommand.Parameters.Add("_XCustName", SqlDbType.SmallInt).Value = txtNameX.Value;
            mycommand.Parameters.Add("_YCustName", SqlDbType.SmallInt).Value = txtNameY.Value;
            mycommand.Parameters.Add("_XCAmount", SqlDbType.SmallInt).Value = txtAmountX.Value;
            mycommand.Parameters.Add("_YCAmount", SqlDbType.SmallInt).Value = txtAmountY.Value;
            mycommand.Parameters.Add("_XAmtInWord", SqlDbType.SmallInt).Value = txtWordsX.Value;
            mycommand.Parameters.Add("_YAmtInWord", SqlDbType.SmallInt).Value = txtWordsY.Value;
            mycommand.Parameters.Add("_XCompDoc", SqlDbType.SmallInt).Value = txtDocX.Value;
            mycommand.Parameters.Add("_YCompDoc", SqlDbType.SmallInt).Value = txtDocY.Value;
            mycommand.ExecuteNonQuery();
            myconnection.Close();

            MessageBox.Show("Saved!", "GL");
        }

        private void txtUpDown_ValueChanged(object sender, EventArgs e)
        {
            PanelDisplayss();
        }

       
    }
}
