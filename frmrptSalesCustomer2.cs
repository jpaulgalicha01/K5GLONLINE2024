using System;
using System.Collections;
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
    public partial class frmrptSalesCustomer2 : Form
    {
        //SqlDataAdapter da;
        DataTable DataTable1;
            
        BindingSource bindingSource = null;
        SqlConnection myconnection;
        BindingSource dbind = new BindingSource();
        ClsCompName ClsCompName1 = new ClsCompName();
        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();
        ClsGetSomething ClsGetSomething1 = new ClsGetSomething();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsBuildVoucherComboBox ClsBuildVoucherComboBox1 = new ClsBuildVoucherComboBox();
        //SqlDataReader SqlDataReader1;
        SqlCommand mycommand;
        public frmrptSalesCustomer2()
        {
            InitializeComponent();
            cbortprint.DisplayMember = "Text";
            cbortprint.ValueMember = "Value";
            cbortprint.SelectedValue = "01";
            var items = new[]
            { 
             new { Text = "Sales By Customer Detailed", Value = "01" }, 

            };
            cbortprint.DataSource = items;
        }
        private void buildcboControlNo()
        {
            cboControlNo.DataSource = null;
            ClsBuildComboBox1.ARCCN.Clear();
            ClsBuildComboBox1.ClsBuildClientControlno("C");
            this.cboControlNo.DataSource = (ClsBuildComboBox1.ARCCN);
            this.cboControlNo.DisplayMember = "Display";
            this.cboControlNo.ValueMember = "Value";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnPreview_Click(object sender, EventArgs e)
        {
        
            if (cbortprint.SelectedValue.ToString() == "01")
            {
                if ((new ClsValidation().emptytxt(cbortprint.Text)) || (txtBeginDate.Text == "  /  /") || (txtEndDate.Text == "  /  /"))
                {
                    MessageBox.Show("Please complete your entry", "GL");
                    cbortprint.Focus();
                }
               
                else if (Convert.ToDateTime(txtBeginDate.Text) > Convert.ToDateTime(txtEndDate.Text))
                {
                    MessageBox.Show("Beginning date is greater than ending date", "GL");
                    cbortprint.Focus();
                }
                else
                {
                    dgv1.Visible = true;
                    SalesByCustomerDetailed();
                }
            }
        }

        private void SalesByCustomerDetailed()
        {
            dgv1.DataSource = null;
            dgv1.Columns.Clear();

            string sqlstatement = "SELECT Reference, TDate, StockNumber, Item, ClassDesc, ";
            sqlstatement += "CAST(SUM(ConvertedQty) AS int) % Piece AS QtyPC, (SELECT CASE WHEN IB <> 0 THEN CAST(((SUM(ConvertedQty) - (CAST(SUM(ConvertedQty) AS int) % Piece)) / Piece) AS int) % IB ELSE 0 END AS Expr1) AS QtyIB, ";
            sqlstatement += "(SELECT CASE WHEN IB = 0 THEN ((SUM(ConvertedQty)) - CAST(SUM(ConvertedQty) AS int) % Piece) / Piece ";
            sqlstatement += "ELSE (((SUM(ConvertedQty) - CAST(SUM(ConvertedQty) AS int) % Piece) / Piece) - (CAST(((SUM(ConvertedQty) - (CAST(SUM(ConvertedQty) AS int) % Piece)) / Piece) AS int) % IB)) / IB END AS Expr1) AS QtyCS, ";
            sqlstatement += "TotVAT, TotSales, TotDisct, Piece, IB, SUM(TotSales - TotDisct) AS NetSales ";
            sqlstatement += "FROM ViewGP WHERE TDate BETWEEN '" + txtBeginDate.Text + "' And  '" + txtEndDate.Text + "' AND ControlNo ='" + cboControlNo.SelectedValue.ToString() + "' ";
            sqlstatement += "GROUP BY Reference, TDate, StockNumber, Item, ClassDesc, TotVAT, TotSales, TotDisct, Piece, IB ORDER BY TDate DESC, Item";

            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = myconnection.CreateCommand();
            mycommand.CommandText = sqlstatement;
            mycommand.CommandTimeout = 900;
            SqlDataReader dr = mycommand.ExecuteReader();
            DataTable1 = new DataTable();
            
            DataTable1.Load(dr);
            myconnection.Close();
            bindingSource = new BindingSource();
            bindingSource.DataSource = DataTable1;

            if (DataTable1.Rows.Count == 0)
            {
                MessageBox.Show("No Data Found!", "Warning");
                return;
            }

            //0
            DataGridViewTextBoxColumn ColumnReference = new DataGridViewTextBoxColumn();
            ColumnReference.HeaderText = "Reference";
            ColumnReference.Width = 80;
            ColumnReference.DataPropertyName = "Reference";
            ColumnReference.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnReference.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv1.Columns.Add(ColumnReference);

            //1
            DataGridViewTextBoxColumn ColumnTDate = new DataGridViewTextBoxColumn();
            ColumnTDate.HeaderText = "Date";
            ColumnTDate.Width = 80;
            ColumnTDate.DataPropertyName = "TDate";
            ColumnTDate.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnTDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv1.Columns.Add(ColumnTDate);

            //2
            DataGridViewTextBoxColumn ColumnStockNumber = new DataGridViewTextBoxColumn();
            ColumnStockNumber.HeaderText = "Code";
            ColumnStockNumber.Width = 200;
            ColumnStockNumber.DataPropertyName = "StockNumber";
            ColumnStockNumber.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnStockNumber.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv1.Columns.Add(ColumnStockNumber);

            //3
            DataGridViewTextBoxColumn ColumnIB = new DataGridViewTextBoxColumn();
            ColumnIB.HeaderText = "Item";
            ColumnIB.Width = 320;
            ColumnIB.DataPropertyName = "Item";
            ColumnIB.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnIB.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv1.Columns.Add(ColumnIB);

            //4
            DataGridViewTextBoxColumn ColumnClassDesc = new DataGridViewTextBoxColumn();
            ColumnClassDesc.HeaderText = "Supplier";
            ColumnClassDesc.Width = 230;
            ColumnClassDesc.DataPropertyName = "ClassDesc";
            ColumnClassDesc.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnClassDesc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv1.Columns.Add(ColumnClassDesc);
            
            //5 CS
            DataGridViewTextBoxColumn ColumnQtyCS = new DataGridViewTextBoxColumn();
            ColumnQtyCS.HeaderText = "CS";
            ColumnQtyCS.Width = 50;
            ColumnQtyCS.DataPropertyName = "QtyCS";
            ColumnQtyCS.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnQtyCS.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv1.Columns.Add(ColumnQtyCS);
            
            //6 Piece
            DataGridViewTextBoxColumn ColumnQtyPC = new DataGridViewTextBoxColumn();
            ColumnQtyPC.HeaderText = "PC";
            ColumnQtyPC.Width = 50;
            ColumnQtyPC.DataPropertyName = "QtyPC";
            ColumnQtyPC.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnQtyPC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv1.Columns.Add(ColumnQtyPC);

            //7 IB
            DataGridViewTextBoxColumn ColumnQtyIB = new DataGridViewTextBoxColumn();
            ColumnQtyIB.HeaderText = "IB";
            ColumnQtyIB.Width = 50;
            ColumnQtyIB.DataPropertyName = "QtyIB";
            ColumnQtyIB.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnQtyIB.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv1.Columns.Add(ColumnQtyIB);

            //8 TotVAT
            DataGridViewTextBoxColumn ColumnTotVAT = new DataGridViewTextBoxColumn();
            ColumnTotVAT.HeaderText = "VAT";
            ColumnTotVAT.Width = 80;
            ColumnTotVAT.DataPropertyName = "TotVAT";
            ColumnTotVAT.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnTotVAT.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv1.Columns.Add(ColumnTotVAT);

            //9 TotSales
            DataGridViewTextBoxColumn ColumnTotSales = new DataGridViewTextBoxColumn();
            ColumnTotSales.HeaderText = "Gross Sales";
            ColumnTotSales.Width = 80;
            ColumnTotSales.DataPropertyName = "TotSales";
            ColumnTotSales.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnTotSales.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv1.Columns.Add(ColumnTotSales);

            //10 TotDisct
            DataGridViewTextBoxColumn ColumnTotDisct = new DataGridViewTextBoxColumn();
            ColumnTotDisct.HeaderText = "Disc";
            ColumnTotDisct.Width = 80;
            ColumnTotDisct.DataPropertyName = "TotDisct";
            ColumnTotDisct.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnTotDisct.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv1.Columns.Add(ColumnTotDisct);

            //11 NetSales
            DataGridViewTextBoxColumn ColumnNetSales = new DataGridViewTextBoxColumn();
            ColumnNetSales.HeaderText = "Net Sales";
            ColumnNetSales.Width = 80;
            ColumnNetSales.DataPropertyName = "NetSales";
            ColumnNetSales.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnNetSales.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnNetSales.DefaultCellStyle.Format = "N2";
            dgv1.Columns.Add(ColumnNetSales);
            
            //Piece
            DataGridViewTextBoxColumn ColumnPiece = new DataGridViewTextBoxColumn();
            ColumnPiece.DataPropertyName = "Piece";
            ColumnPiece.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnPiece.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnPiece.Visible = false;
            dgv1.Columns.Add(ColumnPiece);

            //IB
            DataGridViewTextBoxColumn ColumnIB1 = new DataGridViewTextBoxColumn();
            ColumnIB1.DataPropertyName = "IB";
            ColumnIB1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnIB1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnIB1.Visible = false;
            dgv1.Columns.Add(ColumnIB1);

            dgv1.DataSource = bindingSource;
            dgv1.Columns[1].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgv1.Columns[5].DefaultCellStyle.Format = "N0";
            dgv1.Columns[6].DefaultCellStyle.Format = "N0";
            dgv1.Columns[7].DefaultCellStyle.Format = "N0";
            dgv1.Columns[8].DefaultCellStyle.Format = "N2";
            dgv1.Columns[9].DefaultCellStyle.Format = "N2";
            dgv1.Columns[10].DefaultCellStyle.Format = "N2";
            dgv1.AllowUserToAddRows = false;

        }
        private void frmrptSalesCustomer2_Load(object sender, EventArgs e)
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
                txtEndDate.Text = ClsGetSomething1.plsdefdate;
                buildcboControlNo();
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void txtBeginDate_Leave_1(object sender, EventArgs e)
        {
            if (new ClsValidation().errordate(txtBeginDate.Text) == true)
            {
                MessageBox.Show("Invalid Date", "GL");
                txtBeginDate.Focus();
            }
        }

        private void txtEndDate_Leave_1(object sender, EventArgs e)
        {
            if (new ClsValidation().errordate(txtEndDate.Text) == true)
            {
                MessageBox.Show("Invalid Date", "GL");
                txtEndDate.Focus();
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


        private void cbortprint_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().emptytxt(cbortprint.Text))
            {
            }
            else if (cbortprint.Text != null && cbortprint.SelectedValue == null)
            {
                MessageBox.Show("Not found", "GL");
                cbortprint.Focus();
            }

        }


        private void cboControlNo_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().emptytxt(cboControlNo.Text))
            {
            }
            else if (cboControlNo.Text != null && cboControlNo.SelectedValue == null)
            {
                MessageBox.Show("Not found", "GL");
                cboControlNo.Focus();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView dv = DataTable1.DefaultView;
            //SMDesc LIKE '%" + txtSearchSMCode.Text + "%' "
            dv.RowFilter = "Item LIKE '%" + txtSearch.Text + "%'";
            dgv1.DataSource = dv;
        }

      

    }
}
