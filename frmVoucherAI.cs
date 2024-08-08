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

namespace K5GLONLINE
{
    public partial class frmVoucherAI : Form
    {
        ClsCompName ClsCompName1 = new ClsCompName();
        ClsGetSomething ClsGetSomething1 = new ClsGetSomething();
        SqlConnection myconnection;
        SqlCommand mycommand;
        string varoutdate = "No";

      //  SqlDataReader dr;
        ClsAutoNumber ClsAutoNumber1 = new ClsAutoNumber();
        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();
        ClsBuildVoucherComboBox ClsBuildVoucherComboBox1 = new ClsBuildVoucherComboBox();
        ClsVariousFormula ClsVariousFormula1 = new ClsVariousFormula();
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsValidation ClsValidation1 = new ClsValidation();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection(); 

        private string pvsvaritem = null;

        public frmVoucherAI()
        {
            InitializeComponent();
        }

        private void frmVoucherAI_Load(object sender, EventArgs e)
        {
            ClsPermission1.ClsObjects(this.Text);
            if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
            {
                MessageBox.Show("You do not have necessary permission to open this file", "GL");
                this.Close();
            }
            else
            {

                ClsAutoNumber1.VoucherAutoNumAI();
                txtDocNum.Text = (ClsAutoNumber1.plsnumber);
                buildcboWHCode();
                buildcboSalesman();
                buildcboStocks();
                cboStockNumber.Text = "";
            }
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


   
        private void buildcboSalesman()
        {
            cboPC.DataSource = null;
            ClsBuildVoucherComboBox1.ARLSLS.Clear();
            ClsBuildVoucherComboBox1.ClsBuildSalesman();
            this.cboPC.DataSource = (ClsBuildVoucherComboBox1.ARLSLS);
            this.cboPC.DisplayMember = "Display";
            this.cboPC.ValueMember = "Value";
        }

        private void buildcboStocks()
        {
            cboStockNumber.DataSource = null;
            ClsBuildVoucherComboBox1.ARLSN.Clear();
            ClsBuildVoucherComboBox1.ClsBuildStocks(Convert.ToBoolean(cbSNEncode.CheckState), Convert.ToBoolean(cbPoulty.CheckState));
            this.cboStockNumber.DataSource = (ClsBuildVoucherComboBox1.ARLSN);
            this.cboStockNumber.DisplayMember = "Display";
            this.cboStockNumber.ValueMember = "Value";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AISave()
        {
            try
            {


                ClsAutoNumber1.VoucherAutoNumAI();
                txtDocNum.Text = (ClsAutoNumber1.plsnumber);

                ClsValidation1.securedateAccounting(DateTime.Parse(txtTDate.Text));
                varoutdate = (ClsValidation1.plsoutdate);

                ClsGetConnection1.ClsGetConMSSQL(); myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();

                if (new Clsexist().RecordExists(ref myconnection, "SELECT Reference FROM tblMain4 WHERE Reference ='" + txtreference.Text + "'"))
                {
                    myconnection.Close();
                    MessageBox.Show("Duplicate entry", "GL");
                    txtTDate.Focus();
                }
                
                else if ((txtTDate.Text == "  /  /"))
                {
                    myconnection.Close();
                    MessageBox.Show("Please complete your entry", "GL");
                    txtTDate.Focus();
                }
                else if ((new ClsValidation().emptytxt (cboWHCode.Text))|| (new ClsValidation().emptytxt (txtreference .Text))
                    ||(new ClsValidation().emptytxt (cboPC.Text))||(new ClsValidation().emptytxt (txtRemarks.Text)))
                {
                    myconnection.Close();
                    MessageBox.Show("Please complete your entry", "GL");
                    cboWHCode.Focus();
                }
                else if (varoutdate == "Yes")
                {
                    myconnection.Close();
                    MessageBox.Show("Date is out of range", "GL");
                    txtTDate.Focus();
                }

                else
                {

                    DateTime DT = DateTime.Now;
                    //  txtTStart.Text = DT.ToString();

                    string sqlstatement;
                    sqlstatement = "INSERT INTO tblMain4 (DocNum, UserName, TDate, Reference, PC, Remarks, WHCode, DE)";
                    sqlstatement += " Values (@_DocNum, @_UserName, @_TDate, @_Reference, @_PC, @_Remarks, @_WHCode, @_DE)";
                    string sqlstatementdgv1 = "INSERT INTO tblMain5 (DocNum, StockNumber, AQty, UM, ChickAQty) Values (@_DocNum, @_StockNumber, @_AQty, @_UM, @_ChickAQty)";
                    
                    mycommand = new SqlCommand(sqlstatement, myconnection);
                    mycommand.Parameters.Add("_DocNum", SqlDbType.VarChar).Value = txtDocNum.Text;
                    mycommand.Parameters.Add("_UserName", SqlDbType.VarChar).Value = Form1.glbluc.Text;
                    mycommand.Parameters.Add("_TDate", SqlDbType.DateTime).Value = txtTDate.Text;
                    mycommand.Parameters.Add("_Reference", SqlDbType.VarChar).Value = txtreference.Text;
                    mycommand.Parameters.Add("_PC", SqlDbType.VarChar).Value = cboPC.SelectedValue; ;
                    mycommand.Parameters.Add("_Remarks", SqlDbType.VarChar).Value = txtRemarks.Text;
                    mycommand.Parameters.Add("_WHCode", SqlDbType.VarChar).Value = cboWHCode.SelectedValue; ;
                    mycommand.Parameters.Add("_DE", SqlDbType.DateTime).Value = DT;
                    mycommand.CommandTimeout = 600;
                    int n1 = mycommand.ExecuteNonQuery();

                    DataGridViewRow row = null;
                    for (int x = 0; x < dgv2.Rows.Count - 1; x++)
                    {
                        row = dgv2.Rows[x];
                        mycommand = new SqlCommand(sqlstatementdgv1, myconnection);
                        mycommand.Parameters.Add("_DocNum", SqlDbType.VarChar).Value = txtDocNum.Text;
                        mycommand.Parameters.Add("_StockNumber", SqlDbType.VarChar).Value = row.Cells[0].Value;
                        mycommand.Parameters.Add("_AQty", SqlDbType.SmallMoney).Value = row.Cells[3].Value;
                        mycommand.Parameters.Add("_UM", SqlDbType.VarChar).Value = row.Cells[2].Value;
                        //mycommand.Parameters.Add("_Num", SqlDbType.Int).Value = (Convert.ToInt32(x) + 1).ToString();
                        mycommand.Parameters.Add("_ChickAQty", SqlDbType.Int).Value = row.Cells[4].Value;
                        mycommand.CommandTimeout = 600;
                        int n2 = mycommand.ExecuteNonQuery();
                    }

                    myconnection.Close();
                    //dr.Close();

                    if (cbSP.Checked)
                    {
                        printcurvoucher();
                    }


                    ClsAutoNumber1.VoucherAutoNumAI();
                    txtDocNum.Text = (ClsAutoNumber1.plsnumber);
                    clearscreen();
  
                }
            }
            catch
            {
                MessageBox.Show("Busy, please click OK", "GL");
                AISave();
            }
            finally
            {
                //               dr.Close();
                myconnection.Close();
            }
        }

        private void clearscreen()
        {
            dgv2.Rows.Clear();
            txtreference.Text = "";
            // txtCheckNo.Text = "NA";
            //  txtCAmount.Text = "0.00";
            cboPC.Text = "";
            txtTDate.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AISave();

        }

     

        private void txtTDate_Leave(object sender, EventArgs e)
        {
            if (new ClsValidation().errordate(txtTDate.Text) == true)
            {
                MessageBox.Show("Invalid Date", "GL");
                txtTDate.Focus();
            }
        }

        
    
        private void printcurvoucher()
        {
            string sqlstatement;

            ClsGetConnection1.ClsGetConMSSQL(); myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();

            sqlstatement = "SELECT * FROM viewAI WHERE DocNum ='" + txtDocNum.Text + "'";

            SqlDataAdapter dscmd = new SqlDataAdapter(sqlstatement, myconnection);
            dscmd.SelectCommand.CommandTimeout = 600;
            DSBooks2 DSBooks21 = new DSBooks2();
            dscmd.Fill(DSBooks21, "viewRS");
            myconnection.Close();


            CRprevAS objRpt = new CRprevAS();
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
                    getproductdetails();
                    //getproductBalance();
                    
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
            ClsGetSomething1.ClsGetProductBasicDetails(cboStockNumber.SelectedValue.ToString());
            pvsvaritem = ClsGetSomething1.plsvarItem;
            txtIB.Text = ClsGetSomething1.plvarib;
            txtPiece.Text = ClsGetSomething1.plvarpiece;
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

        
        

        private void txtreference_Validating(object sender, CancelEventArgs e)
        {
            ClsGetConnection1.ClsGetConMSSQL(); myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();

            if (new Clsexist().RecordExists(ref myconnection, "SELECT Reference FROM tblMain4 WHERE Reference ='" + txtreference.Text + "'"))
            {
                MessageBox.Show("Duplicate entry", "GL");
                txtreference.Focus();
            }
            myconnection.Close();

        }

        private void cbPoulty_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPoulty.Checked)
            {
                txtOrdQCS.Enabled = true;
                txtOrdQIB.Enabled = false;
                txtOrdQPC.Enabled = false;
            }
            else
            {
                txtOrdQCS.Enabled = true;
                txtOrdQIB.Enabled = false;
                txtOrdQPC.Enabled = true;
    
            }
            buildcboStocks();

        }

      

        private void cbSNEncode_CheckedChanged(object sender, EventArgs e)
        {
            buildcboStocks();
        }

        private void savetodgv()
        {
            if ((Convert.ToDouble(txtOrdQCS.Text) != 0) && ((cboStockNumber.Text) != ""))
            {
                    dgv2.Rows.Add(cboStockNumber.SelectedValue, pvsvaritem, "CS", txtOrdQCS.Text, txtChickAQty.Text);
                    txtOrdQCS.Text = "0.00";
                    txtChickAQty.Text = "0";
                    cboStockNumber.Text = "";
                    cboStockNumber.Focus();
            }

            else if ((Convert.ToDouble(txtOrdQIB.Text) != 0) && ((cboStockNumber.Text) != ""))
            {
                dgv2.Rows.Add(cboStockNumber.SelectedValue, pvsvaritem, "IB", txtOrdQIB.Text, txtChickAQty.Text);
                txtOrdQIB.Text = "0.00";
                txtChickAQty.Text = "0";
                cboStockNumber.Text = "";
                cboStockNumber.Focus();
            }
            else if ((Convert.ToDouble(txtOrdQPC.Text) != 0) && ((cboStockNumber.Text) != ""))
            {
                dgv2.Rows.Add(cboStockNumber.SelectedValue, pvsvaritem, "PC", txtOrdQPC.Text, txtChickAQty.Text);
                txtOrdQPC.Text = "0.00";
                txtChickAQty.Text = "0";
                cboStockNumber.Text = "";
                cboStockNumber.Focus();
            }
        }

        private void frmVoucherAI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                savetodgv();
            }
        }

        private void txtChickAQty_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().isInt(txtChickAQty.Text) == true)
            {
                MessageBox.Show("Invalid Number", "GL");
                txtChickAQty.Focus();
            }
 
        }
    }
}
