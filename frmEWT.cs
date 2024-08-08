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
using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;

namespace K5GLONLINE
{
    public partial class frmEWT : Form
    {
        //private SqlDataAdapter da;
        //private DataTable dataTable = null;
        private BindingSource bindingSource = null;
        BindingSource bsource = new BindingSource();
     
        SqlConnection myconnection;
        SqlCommand mycommand;
        SqlDataReader SqlDataReader1;
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        ClsValidation ClsValidation1 = new ClsValidation();
        ClsGetSomething ClsGetSomething1 = new ClsGetSomething();
        string sql;
        private string pristrTDate, pristrCustName, pristrTIN, pristrAddress, pristrPrincipal, pristrTax;
        private string pristrTIN1, pristrTIN2, pristrTIN3, pristrTIN4, pristrTIN5, pristrTIN6, pristrTIN7, pristrTIN8, pristrTIN9, pristrTIN10, pristrTIN11, pristrTIN12;
        string strPath;
        public frmEWT()
        {
            InitializeComponent();
            cboQuarter.DisplayMember = "Text";
            cboQuarter.ValueMember = "Value";
            cboQuarter.SelectedValue = "1";
            var items = new[]
            { 
             new { Text = "First Quarter", Value = "1" }, 
             new { Text = "Second Quarter", Value = "2" }, 
             new { Text = "Third Quarter", Value = "3" }, 
             };
            cboQuarter.DataSource = items;

        }

  
        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
      
      
       
        private void frmEWT_Load(object sender, EventArgs e)
        {

            ClsPermission1.ClsObjects(this.Text);
            if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
            {
                MessageBox.Show("You do not have necessary permission to open this file", "GL");
                this.Close();
            }
            else
            {
                ClsGetSomething1.ClsGetDefaultDate();
                txtBeginDate.Text = ClsGetSomething1.plsdefdate;
                txtEndDate.Text =  ClsGetSomething1.plsdefdate;
                txtFTPFrom.Text = ClsGetSomething1.plsdefdate;
                txtFTPTo.Text = ClsGetSomething1.plsdefdate;
                TableLoad();  
            }
        }

        private void TableLoad()
        {
            dgv1.DataSource = null;
            dgv1.Columns.Clear();
            sql = " Select Voucher, DocNum, TDate, Custname, TIN, Address, Principal, Tax FROM viewEWT2 WHERE TDate BETWEEN '" + txtBeginDate.Text + "' AND '" + txtEndDate.Text + "'  ";
        
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = myconnection.CreateCommand();
            mycommand.CommandText = sql;
            mycommand.CommandTimeout = 900;

            SqlDataReader1 = mycommand.ExecuteReader();



            DataTable DataTable1 = new DataTable();
            DataTable1.Load(SqlDataReader1);
            myconnection.Close();
            bindingSource = new BindingSource();
            bindingSource.DataSource = DataTable1;
         

            DataGridViewTextBoxColumn ColumnVoucher = new DataGridViewTextBoxColumn();
            ColumnVoucher.Visible = true;
            ColumnVoucher.HeaderText = "Voucher";
            ColumnVoucher.Width = 50;
            ColumnVoucher.DataPropertyName = "Voucher";
            ColumnVoucher.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnVoucher.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv1.Columns.Add(ColumnVoucher);

            DataGridViewTextBoxColumn ColumnDocNum = new DataGridViewTextBoxColumn();
            ColumnDocNum.Visible = true;
            ColumnDocNum.HeaderText = "DocNum";
            ColumnDocNum.Width = 70;
            ColumnDocNum.DataPropertyName = "DocNum";
            ColumnDocNum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnDocNum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv1.Columns.Add(ColumnDocNum);

            DataGridViewTextBoxColumn ColumnTdate = new DataGridViewTextBoxColumn();
            ColumnTdate.Visible = true;
            ColumnTdate.HeaderText = "Date";
            ColumnTdate.Width = 80;
            ColumnTdate.DataPropertyName = "TDate";
            ColumnTdate.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnTdate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv1.Columns.Add(ColumnTdate);

            DataGridViewTextBoxColumn ColumnCustname = new DataGridViewTextBoxColumn();
            ColumnCustname.Visible = true;
            ColumnCustname.HeaderText = "Name";
            ColumnCustname.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnCustname.DataPropertyName = "Custname";
            ColumnCustname.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnCustname.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv1.Columns.Add(ColumnCustname);

            DataGridViewTextBoxColumn ColumnTIN = new DataGridViewTextBoxColumn();
            ColumnTIN.Visible = true;
            ColumnTIN.HeaderText = "TIN";
            ColumnTIN.Width = 100;
            ColumnTIN.DataPropertyName = "TIN";
            ColumnTIN.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnTIN.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv1.Columns.Add(ColumnTIN);

            DataGridViewTextBoxColumn ColumnAddress = new DataGridViewTextBoxColumn();
            ColumnAddress.Visible = true;
            ColumnAddress.HeaderText = "Address";
            ColumnAddress.Width = 120;
            ColumnAddress.DataPropertyName = "Address";
            ColumnAddress.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnAddress.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv1.Columns.Add(ColumnAddress);


            DataGridViewTextBoxColumn ColumnPrincipal = new DataGridViewTextBoxColumn();
            ColumnPrincipal.Visible = true;
            ColumnPrincipal.HeaderText = "Principal";
            ColumnPrincipal.Width = 100;
            ColumnPrincipal.DataPropertyName = "Principal";
            ColumnPrincipal.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnPrincipal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv1.Columns.Add(ColumnPrincipal);


            DataGridViewTextBoxColumn ColumnTAX = new DataGridViewTextBoxColumn();
            ColumnTAX.Visible = true;
            ColumnTAX.HeaderText = "Tax";
            ColumnTAX.Width = 100;
            ColumnTAX.DataPropertyName = "Tax";
            ColumnTAX.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnTAX.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv1.Columns.Add(ColumnTAX);

            dgv1.DataSource = bindingSource;
            dgv1.Columns[6].DefaultCellStyle.Format = "N2";
            dgv1.Columns[7].DefaultCellStyle.Format = "N2";
            dgv1.Columns[2].DefaultCellStyle.Format = "MM/dd/yyyy";

            //dgv1.AllowUserToAddRows = false;



        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (txtBeginDate.Text == "  /  /")
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
               TableLoad();
                if (dgv1.Rows.Count == 0)
                {
                  MessageBox.Show("No data found", "GL");
                  return;     
                }
                else
                {
                    btnOpenEWT.Enabled = true;
                }
            }
        }

   
       

        private void dgv1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgv1.Rows[e.RowIndex];
        
            pristrTDate = row.Cells[2].FormattedValue.ToString();
            pristrCustName = row.Cells[3].FormattedValue.ToString();
            pristrTIN = row.Cells[4].FormattedValue.ToString();
            pristrAddress = row.Cells[5].FormattedValue.ToString();
            pristrPrincipal = row.Cells[6].FormattedValue.ToString();
            pristrTax = row.Cells[7].FormattedValue.ToString();

            int pristrCount = int.Parse(pristrTIN.Length.ToString());
            if (pristrCount == 11)
            {

                pristrTIN1 = pristrTIN.Substring(0, 1);
                pristrTIN2 = pristrTIN.Substring(1, 1);
                pristrTIN3 = pristrTIN.Substring(2, 1);
                pristrTIN4 = pristrTIN.Substring(4, 1);
                pristrTIN5 = pristrTIN.Substring(5, 1);
                pristrTIN6 = pristrTIN.Substring(6, 1);
                pristrTIN7 = pristrTIN.Substring(8, 1);
                pristrTIN8 = pristrTIN.Substring(9, 1);
                pristrTIN9 = pristrTIN.Substring(10, 1);

                pristrTIN10 = "0";
                pristrTIN11 = "0";
                pristrTIN12 = "0";        
            }
            else if (pristrCount == 15)
            {
                pristrTIN1 = pristrTIN.Substring(0, 1);
                pristrTIN2 = pristrTIN.Substring(1, 1);
                pristrTIN3 = pristrTIN.Substring(2, 1);
                pristrTIN4 = pristrTIN.Substring(4, 1);
                pristrTIN5 = pristrTIN.Substring(5, 1);
                pristrTIN6 = pristrTIN.Substring(6, 1);
                pristrTIN7 = pristrTIN.Substring(8, 1);
                pristrTIN8 = pristrTIN.Substring(9, 1);
                pristrTIN9 = pristrTIN.Substring(10, 1);
                pristrTIN10 = pristrTIN.Substring(12, 1);
                pristrTIN11 = pristrTIN.Substring(13, 1);
                pristrTIN12 = pristrTIN.Substring(14, 1);
            
            }
            else
            {
                pristrTIN1 = null;
                pristrTIN2 = null;
                pristrTIN3 = null;
                pristrTIN4 = null;
                pristrTIN5 = null;
                pristrTIN6 = null;
                pristrTIN7 = null;
                pristrTIN8 = null;
                pristrTIN9 = null;
                pristrTIN10 = null;
                pristrTIN11 = null;
                pristrTIN12 = null;
             }
        }

        private void btnPostExcel_Click(object sender, EventArgs e)
        {
        }

        private void dgv1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            btnPostExcel.Enabled = true;
        }

        private void btnOpenEWT_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.Filter = "xlsx(*.xlsx)|*.xlsx|xls(*.xls)|*.xls";
            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                strPath = OpenFileDialog1.FileName;
                btnPostExcel.Enabled = true;
                dgv1.Focus();
                btnOpenEWT.Enabled = false;
            }
                
        }

        private void txtBeginDate_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().errordate(txtBeginDate.Text) == true)
            {
                MessageBox.Show("Invalid Date", "GL");
                txtBeginDate.Focus();
            }
        }

        private void txtEndDate_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().errordate(txtEndDate.Text) == true)
            {
                MessageBox.Show("Invalid Date", "GL");
                txtEndDate.Focus();
            }

        }

        private void txtFTPFrom_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().errordate(txtFTPFrom.Text) == true)
            {
                MessageBox.Show("Invalid Date", "GL");
                txtFTPFrom.Focus();
            }

        }

        private void txtFTPTo_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().errordate(txtFTPTo.Text) == true)
            {
                MessageBox.Show("Invalid Date", "GL");
                txtFTPTo.Focus();
            }

        }

       

        private void nextfieldenter2(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }

        }

        
        private void PosttoExcel()
        {
            if (new ClsValidation().emptytxt(strPath))
            {
                MessageBox.Show("Original EWT form is closed", "GL");
                btnOpenEWT.Focus();
            }
            else
            {
                Excel.Application excelApp = new Excel.Application();
                excelApp.Workbooks.Open(strPath);

                excelApp.Cells[17, 2] = pristrCustName; //Date from table
                excelApp.Cells[20, 2] = pristrAddress; //Address from table
                excelApp.Cells[14, 9] = pristrTIN1; // TIN from table 
                excelApp.Cells[14, 10] = pristrTIN2; // TIN from table 
                excelApp.Cells[14, 11] = pristrTIN3; // TIN from table 
                excelApp.Cells[14, 13] = pristrTIN4; // TIN from table 
                excelApp.Cells[14, 14] = pristrTIN5; // TIN from table 
                excelApp.Cells[14, 15] = pristrTIN6; // TIN from table 
                excelApp.Cells[14, 17] = pristrTIN7; // TIN from table 
                excelApp.Cells[14, 18] = pristrTIN8; // TIN from table 
                excelApp.Cells[14, 19] = pristrTIN9; // TIN from table 
                excelApp.Cells[14, 21] = pristrTIN10; // TIN from table 
                excelApp.Cells[14, 22] = pristrTIN11; // TIN from table 
                excelApp.Cells[14, 23] = pristrTIN12; // TIN from table 
                excelApp.Cells[11, 10] = "" + DateTime.Parse(txtFTPFrom.Text).ToString("MM/dd/yy").Substring(0, 1);
                excelApp.Cells[11, 11] = "" + DateTime.Parse(txtFTPFrom.Text).ToString("MM/dd/yy").Substring(1, 1);
                excelApp.Cells[11, 12] = "" + DateTime.Parse(txtFTPFrom.Text).ToString("MM/dd/yy").Substring(3, 1);
                excelApp.Cells[11, 13] = "" + DateTime.Parse(txtFTPFrom.Text).ToString("MM/dd/yy").Substring(4, 1);
                excelApp.Cells[11, 14] = "" + DateTime.Parse(txtFTPFrom.Text).ToString("MM/dd/yy").Substring(6, 1);
                excelApp.Cells[11, 15] = "" + DateTime.Parse(txtFTPFrom.Text).ToString("MM/dd/yy").Substring(7, 1);
                excelApp.Cells[11, 16] = "" + DateTime.Parse(txtFTPFrom.Text).ToString("MM/dd/yyyy").Substring(8, 1);
                excelApp.Cells[11, 17] = "" + DateTime.Parse(txtFTPFrom.Text).ToString("MM/dd/yyyy").Substring(9, 1);
                excelApp.Cells[11, 27] = "'" + DateTime.Parse(txtFTPTo.Text).ToString("MM/dd/yy").Substring(0, 1);
                excelApp.Cells[11, 28] = "" + DateTime.Parse(txtFTPFrom.Text).ToString("MM/dd/yy").Substring(1, 1);
                excelApp.Cells[11, 29] = "" + DateTime.Parse(txtFTPFrom.Text).ToString("MM/dd/yy").Substring(3, 1);
                excelApp.Cells[11, 30] = "" + DateTime.Parse(txtFTPFrom.Text).ToString("MM/dd/yy").Substring(4, 1);
                excelApp.Cells[11, 31] = "" + DateTime.Parse(txtFTPFrom.Text).ToString("MM/dd/yy").Substring(6, 1);
                excelApp.Cells[11, 32] = "" + DateTime.Parse(txtFTPFrom.Text).ToString("MM/dd/yy").Substring(7, 1);
                excelApp.Cells[11, 33] = "" + DateTime.Parse(txtFTPFrom.Text).ToString("MM/dd/yyyy").Substring(8, 1);
                excelApp.Cells[11, 34] = "" + DateTime.Parse(txtFTPFrom.Text).ToString("MM/dd/yyyy").Substring(9, 1);
                if (cboQuarter.SelectedValue.ToString() == "1")
                {
                    excelApp.Cells[38, 15] = pristrPrincipal;
                }
                else if (cboQuarter.SelectedValue.ToString() == "2")
                {
                    excelApp.Cells[38, 20] = pristrPrincipal;
                }
                else if (cboQuarter.SelectedValue.ToString() == "3")
                {
                    excelApp.Cells[38, 25] = pristrPrincipal;
                }
                excelApp.Cells[38, 30] = pristrPrincipal;
                excelApp.Cells[38, 35] = pristrTax;

                btnPostExcel.Enabled = false;
                excelApp.Visible = true;
            }

        }

        private void dgv1_DoubleClick(object sender, EventArgs e)
        {
            PosttoExcel();
        }
       
    }
}
