using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;

namespace K5GLONLINE
{
    public partial class frmrptFS : Form
    {
        SqlConnection myconnection;
        SqlDataReader dr;
        SqlCommand mycommand;
        BindingSource dbind = new BindingSource();
        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();
        ClsCompName ClsCompName1 = new ClsCompName();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        ClsPermission ClsPermission1 = new ClsPermission();
        SqlDataReader SqlDataReader1;
        public frmrptFS()
        {
            InitializeComponent();
            cbortprint.DisplayMember = "Text";
            cbortprint.ValueMember = "Value";
            cbortprint.SelectedValue = "01";
            var items = new[]
            {
             new { Text = "Trial Balance", Value = "01" },
             new { Text = "Balance Sheet", Value = "02" },
             new { Text = "Income Statement", Value = "03" },
            };
            cbortprint.DataSource = items;
        }
   
        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (cbortprint.SelectedValue.ToString() == "01")//Trial Balance
            {
                if (new ClsValidation().emptytxt(cbortprint.Text))
                {
                    MessageBox.Show("Please complete your entry", "GL");
                    cbortprint.Focus();
                }
                else if (txtBeginDate.Text == "  /  /")
                {
                    MessageBox.Show("Please complete your entry", "GL");
                    txtBeginDate.Focus();
                }
                else if (txtEndDate.Text == "  /  /")
                {
                    MessageBox.Show("Please complete your entry", "GL");
                    txtEndDate.Focus();
                }
                else if (Convert.ToDateTime(txtBeginDate.Text) > Convert.ToDateTime(txtEndDate.Text))
                {
                    MessageBox.Show("Beginning date is greater than ending date");
                    txtBeginDate.Focus();
                }
                else
                {
                    openTB();         
                }
            }
            else if (cbortprint.SelectedValue.ToString() == "02")//Balance Sheet
            {
                if (new ClsValidation().emptytxt(cbortprint.Text))
                {
                    MessageBox.Show("Please complete your entry", "GL");
                    cbortprint.Focus();
                }
                else if (txtEnterDate.Text == "  /  /")
                {
                    MessageBox.Show("Please complete your entry", "GL");
                    txtEnterDate.Focus();
                }
                else
                {
                    deletetRE();
                    getNetIncome();
                    openBS();
                }
            }
            else if (cbortprint.SelectedValue.ToString() == "03")//Income Statement
            {
                if (new ClsValidation().emptytxt(cbortprint.Text))
                {
                    MessageBox.Show("Please complete your entry", "GL");
                    cbortprint.Focus();
                }
                else if (txtBeginDate.Text == "  /  /")
                {
                    MessageBox.Show("Please complete your entry", "GL");
                    txtBeginDate.Focus();
                }
                else if (txtEndDate.Text == "  /  /")
                {
                    MessageBox.Show("Please complete your entry", "GL");
                    txtEndDate.Focus();
                }
                else if (Convert.ToDateTime(txtBeginDate.Text) > Convert.ToDateTime(txtEndDate.Text))
                {
                    MessageBox.Show("Beginning date is greater than ending date");
                    txtBeginDate.Focus();
                }
                else
                {
                    openIS();
                }
            }
        }
        private void openTB()
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = new SqlCommand("usp_TrialBalance4", myconnection);
            mycommand.CommandType = CommandType.StoredProcedure;
            mycommand.Parameters.Add("@ParamBeginDate2", SqlDbType.DateTime).Value = txtBeginDate.Text;
            mycommand.Parameters.Add("@ParamEndDate2", SqlDbType.DateTime).Value = txtEndDate.Text;

            mycommand.CommandTimeout = 900;
            SqlDataReader1 = mycommand.ExecuteReader();
            DataTable DataTable1 = new DataTable();
            DataTable1.Load(SqlDataReader1);
            myconnection.Close();

            if (DataTable1.Rows.Count == 0)
            {
                MessageBox.Show("No data found", "GL");
                return;
            }
            CRFSTrialBalance objRpt = new CRFSTrialBalance();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            ClsCompName1.ClsCompNameMain();
            vartxtcompany.Text = ClsCompName1.varcn;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoenterdate"];
            varrpttoenterdate.Text = "From " + txtBeginDate.Text + " To " + txtEndDate.Text;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }

        private void openIS()
        {
            string sqlstatement;

            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            sqlstatement = "SELECT	AcctNo, FCDesc, FCSort, FCGIGroup, TitleAcct, SUM(TotAmt) AS  SumTotAmt, SUM(TotNetAmt) AS  SumTotNetAmt FROM ViewIncomeStatementNew  WHERE TDate BETWEEN '" + txtBeginDate.Text + "' And  '" + txtEndDate.Text + "' GROUP BY AcctNo, FCDesc, FCSort, FCGIGroup, TitleAcct ORDER BY AcctNo";

            mycommand = myconnection.CreateCommand();
            mycommand.CommandText = sqlstatement;
            mycommand.CommandTimeout = 900;
            SqlDataReader1 = mycommand.ExecuteReader();
            DataTable DataTable1 = new DataTable();
            DataTable1.Load(SqlDataReader1);
            myconnection.Close();
            CRFSIncomeStatement objRpt = new CRFSIncomeStatement();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            ClsCompName1.ClsCompNameMain();
            vartxtcompany.Text = ClsCompName1.varcn;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoenterdate"];
            varrpttoenterdate.Text = "From " + txtBeginDate.Text + " To " + txtEndDate.Text;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();

        }

        private void openBS()
        {
            string sqlstatement;
            string sqlstatement1 = "INSERT INTO tblmain1 (IC, DocNum, Voucher, UserName, TDate, VDate, Reference, ";
            sqlstatement1 +="ControlNo, Remarks, Check#, PC, DE, SONumber, PONum, Void) Values (@_IC, @_DocNum, @_Voucher, ";
            sqlstatement1 +="@_UserName, @_TDate, @_VDate, @_Reference, @_ControlNo, @_Remarks, @_Check#, @_PC, @_DE, @_SONumber, @_PONum, @_Void)";

            string sqlstatement2 = "INSERT INTO tblmain3 (IC, Refer, ActRemarks, Debit, Credit, PA) Values (@_IC, @_Refer, @_ActRemarks, @_Debit, @_Credit, @_PA)";
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = new SqlCommand(sqlstatement1, myconnection);
            mycommand.Parameters.Add("_IC", SqlDbType.VarChar).Value = "RET";
            mycommand.Parameters.Add("_DocNum", SqlDbType.VarChar).Value = "RET";
            mycommand.Parameters.Add("_Voucher", SqlDbType.VarChar).Value = "RET";
            mycommand.Parameters.Add("_UserName", SqlDbType.VarChar).Value = Form1.glbluc.Text;
            mycommand.Parameters.Add("_TDate", SqlDbType.DateTime).Value = txtEnterDate.Text;
            mycommand.Parameters.Add("_VDate", SqlDbType.DateTime).Value = txtEnterDate.Text;
            mycommand.Parameters.Add("_Reference", SqlDbType.VarChar).Value = "A@*,^)5[K";
            mycommand.Parameters.Add("_ControlNo", SqlDbType.VarChar).Value = txtControNo.Text;
            mycommand.Parameters.Add("_Remarks", SqlDbType.VarChar).Value = "NA";
            mycommand.Parameters.Add("_Check#", SqlDbType.VarChar).Value = "NA";
            mycommand.Parameters.Add("_PC", SqlDbType.VarChar).Value = "001";
            mycommand.Parameters.Add("_DE", SqlDbType.DateTime).Value = txtEndDate.Text;
            mycommand.Parameters.Add("_SONumber", SqlDbType.VarChar).Value = "NA@#$";
            mycommand.Parameters.Add("_PONum", SqlDbType.VarChar).Value = "NA@#$%^";
            mycommand.Parameters.Add("_Void", SqlDbType.Bit).Value = 0;
            int n1 = mycommand.ExecuteNonQuery();

            mycommand = new SqlCommand(sqlstatement2, myconnection);
            mycommand.Parameters.Add("_IC", SqlDbType.VarChar).Value = "RET";
            mycommand.Parameters.Add("_Refer", SqlDbType.VarChar).Value = "RET";
            mycommand.Parameters.Add("_ActRemarks", SqlDbType.VarChar).Value = "RET";
            mycommand.Parameters.Add("_Debit", SqlDbType.Decimal).Value = 0;
            mycommand.Parameters.Add("_Credit", SqlDbType.Decimal).Value = txtNetIncome.Text;
            mycommand.Parameters.Add("_PA", SqlDbType.VarChar).Value = "4100000";
            int n2 = mycommand.ExecuteNonQuery();

            sqlstatement = "SELECT	FCDesc, FCSort, TitleAcct, Description, Number, SUM(TotAmt) AS  SumTotAmt, SUM(TotLOAmt) AS SumTotLOAmt FROM ViewBSNew  WHERE TDate <= '" + txtEnterDate.Text + "' GROUP BY FCDesc, FCSort, TitleAcct, Description, Number";
            mycommand = myconnection.CreateCommand();
            mycommand.CommandText = sqlstatement;
            mycommand.CommandTimeout = 900;
            SqlDataReader1 = mycommand.ExecuteReader();
            DataTable DataTable1 = new DataTable();
            DataTable1.Load(SqlDataReader1);
            myconnection.Close();

            if (DataTable1.Rows.Count == 0)
            {
                MessageBox.Show("No data found", "GL");
                return;
            }

            CRFSBalanceSheet objRpt = new CRFSBalanceSheet();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            ClsCompName1.ClsCompNameMain();
            vartxtcompany.Text = ClsCompName1.varcn;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttoenterdate"];
            varrpttoenterdate.Text = "As of " + txtEnterDate.Text;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
            deletetRE();
        }

        private void deletetRE()
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            string sqldelete1 = "DELETE FROM tblMain3 WHERE IC='RET'";
            string sqldelete2 = "DELETE FROM tblMain1 WHERE IC='RET'";

            mycommand = new SqlCommand(sqldelete1, myconnection);
            int n1 = mycommand.ExecuteNonQuery();
            mycommand = new SqlCommand(sqldelete2, myconnection);
            int n2 = mycommand.ExecuteNonQuery();
            myconnection.Close();

        }
       private void getControlNo()
        {
            try
            {
                string sql;
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                sql = "SELECT ControlNo From tblCustomer";
                mycommand = new SqlCommand(sql, myconnection);
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    txtControNo.Text = dr["ControlNo"].ToString();
                }
                dr.Close();
                myconnection.Close();

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                dr.Close();
                myconnection.Close();
            }

        }

       private void getNetIncome()
       {
           try
           {
               string sql;
               ClsGetConnection1.ClsGetConMSSQL();
               myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
               myconnection.Open();
               sql = "SELECT SUM(TotNetAmt) AS  SumTotNetAmt FROM ViewIncomeStatementNew  WHERE TDate <= '" + txtEnterDate.Text + "'";

               mycommand = new SqlCommand(sql, myconnection);
               dr = mycommand.ExecuteReader();

               while (dr.Read())
               {
                   string varnetincome1 = dr["SumTotNetAmt"].ToString();
                   if (new ClsValidation().emptytxt(varnetincome1))
                   {
                       txtNetIncome.Text = "0";
                   }
                   else
                   {
                       double varnetincome2 = Convert.ToDouble (varnetincome1.ToString());
                       txtNetIncome.Text = varnetincome2.ToString("N2");
                   }

                  // double varnetincome = Convert.ToDouble (dr["SumTotNetAmt"].ToString());
                  // txtNetIncome.Text = varnetincome.ToString("N2");
                  

               }
               dr.Close();
               myconnection.Close();

           }
           catch (Exception ex)
           {
               System.Windows.Forms.MessageBox.Show(ex.Message);
           }
           finally
           {
               dr.Close();
               myconnection.Close();
           }

       }

       private void frmrptFS_Load(object sender, EventArgs e)
       {
           ClsPermission1.ClsObjects(this.Text);
           if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
           {
               MessageBox.Show("You do not have necessary permission to open this file", "GL");
               this.Close();
           }
           else
           {
               getControlNo();
               DateTime VarToday = DateTime.Today;
               txtBeginDate.Text = String.Format("{0:MM/dd/yyyy}", VarToday);
               txtEndDate.Text = String.Format("{0:MM/dd/yyyy}", VarToday);
               txtEnterDate.Text = String.Format("{0:MM/dd/yyyy}", VarToday);
               this.WindowState = FormWindowState.Maximized;
           }
       }
 
        private void txtBeginDate_Leave(object sender, EventArgs e)
        {
            if (new ClsValidation().errordate(txtBeginDate.Text) == true)
            {
                MessageBox.Show("Invalid Date", "GL");
                txtBeginDate.Focus();
            }
        }

        private void txtEndDate_Leave(object sender, EventArgs e)
        {
            if (new ClsValidation().errordate(txtEndDate.Text) == true)
            {
                MessageBox.Show("Invalid Date", "GL");
                txtEndDate.Focus();
            }
        }

        private void txtEnterDate_Leave(object sender, EventArgs e)
        {
            if (new ClsValidation().errordate(txtEnterDate.Text) == true)
            {
                MessageBox.Show("Invalid Date", "GL");
                txtEnterDate.Focus();
            }
        }

        private void cbortprint_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbortprint.SelectedValue.ToString() == "01")//Trial Balance
            {
                txtBeginDate.Visible = true;
                txtEndDate.Visible = true;
                txtEnterDate.Visible = false;

                lblBeginDate.Visible = true;
                lblEndDate.Visible = true;
                lblEnterDate.Visible = false;
            }
            else if (cbortprint.SelectedValue.ToString() == "02")//Balance Sheet
            {
                txtBeginDate.Visible = false;
                txtEndDate.Visible = false;
                txtEnterDate.Visible = true;

                lblBeginDate.Visible = false;
                lblEndDate.Visible = false;
                lblEnterDate.Visible = true;
 
            }
            else if (cbortprint.SelectedValue.ToString() == "03")//Income Statement
            {
                txtBeginDate.Visible = true;
                txtEndDate.Visible = true;
                txtEnterDate.Visible = false;

                lblBeginDate.Visible = true;
                lblEndDate.Visible = true;
                lblEnterDate.Visible = false;
            }
        }

        private void nextfieldenter1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
            else if ((e.KeyCode.Equals(Keys.Up)) || (e.KeyCode.Equals(Keys.Left)))
            {
                SendKeys.Send("+{TAB}");
            }
            else if ((e.KeyCode.Equals(Keys.Down)) || (e.KeyCode.Equals(Keys.Right)))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void nextfieldenter2(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
