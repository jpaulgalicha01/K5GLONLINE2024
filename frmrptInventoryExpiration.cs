using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace K5GLONLINE
{
    public partial class frmrptInventoryExpiration : Form
    {
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsBuildVoucherComboBox ClsBuildVoucherComboBox1 = new ClsBuildVoucherComboBox();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        SqlConnection myconnection;
        SqlCommand mycommand;
        SqlDataReader SqlDataReader1;
        BindingSource bindingSource = null;
        public static TextBox glbltxtStockNumber, glbltxtConvertedQty;
        ClsGetSomething ClsGetSomething1 = new ClsGetSomething();
        private string pristrIB, pristrpiece, strExpDate;
        public frmrptInventoryExpiration()
        {
            InitializeComponent();
        }

        private void frmrptInventoryExpiration_Load(object sender, EventArgs e)
        {
            ClsPermission1.ClsObjects(this.Text);
            if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
            {
                MessageBox.Show("You do not have necessary permission to open this file", "GL");
                this.Close();
            }
            else
            {

                //this.WindowState = FormWindowState.Maximized;
                buildcboWHCode();
                glbltxtStockNumber = txtStockNumber;
                glbltxtConvertedQty = txtConvertedQty;
                cboWHCode.SelectedValue = "000";
                createcolumn();
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

        private void cboWHCode_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().emptytxt(cboWHCode.Text))
            {
            }
            else if (cboWHCode.Text != null && cboWHCode.SelectedValue == null)
            {
                MessageBox.Show("Not found", "GL");
                cboWHCode.Focus();
            }
        }

        private void LoadInvExpDgv3()
        {
            dgv3.DataSource = null;
            dgv3.Columns.Clear();

            //string sqlstatement = "SELECT StockNumber, Item, ";
            //sqlstatement += "CAST(SUM(ConvertedQty) AS int) % Piece AS QtyPC, (SELECT CASE WHEN IB <> 0 THEN CAST(((SUM(ConvertedQty) - (CAST(SUM(ConvertedQty) AS int) % Piece)) / Piece) AS int) % IB ELSE 0 END) AS QtyIB,";
            //sqlstatement += "(SELECT  CASE WHEN IB = 0 THEN ((Sum(ConvertedQty))-CAST(SUM(ConvertedQty)  AS int) % Piece) /Piece ";
            //sqlstatement += "ELSE (((Sum(ConvertedQty)-CAST(SUM(ConvertedQty) AS int) % Piece)/Piece)-(CAST(((SUM(ConvertedQty) - (CAST(SUM(ConvertedQty) AS int) % Piece)) / Piece) AS int) % IB))/IB END) AS QtyCS, ";
            //sqlstatement += "Sum(ConvertedQty) AS SumConvertedQty ";
            //sqlstatement += "FROM ViewInvBalance WHERE WHCode = '" + cboWHCode.SelectedValue.ToString() + "' AND TDate<='" + dtpDateToday.Text + "'";
            //sqlstatement += "GROUP By Piece, IB, Item, ClassDesc, PClassDesc, StockNumber HAVING SUM(ConvertedQty)<>0";

            string sqlstatement = "SELECT StockNumber, Item, ";
            sqlstatement += "(SELECT  CASE WHEN IB = 0 THEN ((Sum(ConvertedQty))-CAST(SUM(ConvertedQty)  AS int) % Piece) /Piece ";
            sqlstatement += "ELSE (((Sum(ConvertedQty)-CAST(SUM(ConvertedQty) AS int) % Piece)/Piece)-(CAST(((SUM(ConvertedQty) - (CAST(SUM(ConvertedQty) AS int) % Piece)) / Piece) AS int) % IB))/IB END) AS QtyCS, ";
            sqlstatement += "(SELECT CASE WHEN IB <> 0 THEN CAST(((SUM(ConvertedQty) - (CAST(SUM(ConvertedQty) AS int) % Piece)) / Piece) AS int) % IB ELSE 0 END) AS QtyIB,";
            sqlstatement += "CAST(SUM(ConvertedQty) AS int) % Piece AS QtyPC, ";
            sqlstatement += "Sum(ConvertedQty) AS SumConvertedQty ";
            sqlstatement += "FROM ViewInvBalance WHERE WHCode = '" + cboWHCode.SelectedValue.ToString() + "' AND TDate<='" + dtpDateToday.Text + "'";
            sqlstatement += "GROUP By Piece, IB, Item, ClassDesc, PClassDesc, StockNumber HAVING SUM(ConvertedQty)<>0";

            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = myconnection.CreateCommand();
            mycommand.CommandText = sqlstatement;
            mycommand.CommandTimeout = 900;
            SqlDataReader1 = mycommand.ExecuteReader();
            DataTable DataTable1 = new DataTable();
            DataTable1.Load(SqlDataReader1);
            myconnection.Close();

            bindingSource = new BindingSource();
            bindingSource.DataSource = DataTable1;

            if (DataTable1.Rows.Count == 0)
            {
                MessageBox.Show("No data found", "GL");
                return;
            }


            DataGridViewTextBoxColumn ColumnStockNumber = new DataGridViewTextBoxColumn();
            ColumnStockNumber.HeaderText = "StockNumber";
            ColumnStockNumber.Width = 200;
            ColumnStockNumber.DataPropertyName = "StockNumber";
            ColumnStockNumber.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnStockNumber.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnStockNumber.Visible = true;
            ColumnStockNumber.ReadOnly = true;
            dgv3.Columns.Add(ColumnStockNumber);

            DataGridViewTextBoxColumn ColumnItem = new DataGridViewTextBoxColumn();
            ColumnItem.HeaderText = "Description";
            ColumnItem.Width = 300;
            ColumnItem.DataPropertyName = "Item";
            ColumnItem.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnItem.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnItem.Visible = true;
            ColumnItem.ReadOnly = true;
            dgv3.Columns.Add(ColumnItem);

            DataGridViewTextBoxColumn ColumnQtyCS = new DataGridViewTextBoxColumn();
            ColumnQtyCS.HeaderText = "CS";
            ColumnQtyCS.Width = 100;
            ColumnQtyCS.DataPropertyName = "QtyCS";
            ColumnQtyCS.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnQtyCS.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnQtyCS.Visible = true;
            ColumnQtyCS.ReadOnly = true;
            dgv3.Columns.Add(ColumnQtyCS);

            DataGridViewTextBoxColumn ColumnQtyIB = new DataGridViewTextBoxColumn();
            ColumnQtyIB.HeaderText = "IB";
            ColumnQtyIB.Width = 100;
            ColumnQtyIB.DataPropertyName = "QtyIB";
            ColumnQtyIB.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnQtyIB.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnQtyIB.Visible = true;
            ColumnQtyIB.ReadOnly = true;
            dgv3.Columns.Add(ColumnQtyIB);

            DataGridViewTextBoxColumn ColumnQtyPC = new DataGridViewTextBoxColumn();
            ColumnQtyPC.HeaderText = "PC";
            ColumnQtyPC.Width = 100;
            ColumnQtyPC.DataPropertyName = "QtyPC";
            ColumnQtyPC.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnQtyPC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnQtyPC.Visible = true;
            ColumnQtyPC.ReadOnly = true;
            dgv3.Columns.Add(ColumnQtyPC);

            DataGridViewTextBoxColumn ColumnConvertedQty = new DataGridViewTextBoxColumn();
            ColumnConvertedQty.HeaderText = "ConvertQty";
            ColumnConvertedQty.Width = 100;
            ColumnConvertedQty.DataPropertyName = "SumConvertedQty";
            ColumnConvertedQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnConvertedQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnConvertedQty.Visible = true;
            ColumnConvertedQty.ReadOnly = true;
            dgv3.Columns.Add(ColumnConvertedQty);

            //Setting Data Source for DataGridView
            dgv3.DataSource = bindingSource;

            dgv3.Columns[2].DefaultCellStyle.Format = "N0";
            dgv3.Columns[3].DefaultCellStyle.Format = "N0";
            dgv3.Columns[4].DefaultCellStyle.Format = "N0";
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboWHCode.Text))
            {
                MessageBox.Show("Please complete your entry", "GL");
                cboWHCode.Focus();
            }
            else
            {
                dgv1.DataSource = null;
                dgv1.Columns.Clear();
                createcolumn();
                LoadInvExpDgv3();
                for (int x = 0; x < dgv3.Rows.Count; x++)
                {
                    dgv1.Rows.Add(dgv3.Rows[x].Cells[0].Value.ToString(), dgv3.Rows[x].Cells[1].Value.ToString(),
                        double.Parse(dgv3.Rows[x].Cells[2].Value.ToString()).ToString("N0"), double.Parse(dgv3.Rows[x].Cells[3].Value.ToString()).ToString("N0"),
                        double.Parse(dgv3.Rows[x].Cells[4].Value.ToString()).ToString("N0"), dgv3.Rows[x].Cells[5].Value.ToString());
                }
                dgv1.AllowUserToAddRows = false;
                PostExpiration();
            }
        }

        private void dgv1_DoubleClick(object sender, EventArgs e)
        {

            frmrptInvExpDetails frmrptInvExpDetails1 = new frmrptInvExpDetails();
            frmrptInvExpDetails1.Show();
        }

        private void dgv1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgv1.Rows[e.RowIndex];
            txtStockNumber.Text = row.Cells[0].FormattedValue.ToString();
            double douConvertedQty = double.Parse(row.Cells[5].FormattedValue.ToString());
            txtConvertedQty.Text = douConvertedQty.ToString("N0");
        }

        private void createcolumn()
        {
            var ColColumnStockNumber = new DataGridViewTextBoxColumn();
            var ColColumnItem = new DataGridViewTextBoxColumn();
            var ColColumnQtyCS = new DataGridViewTextBoxColumn();
            var ColColumnQtyIB = new DataGridViewTextBoxColumn();
            var ColColumnQtyPC = new DataGridViewTextBoxColumn();
            var ColColumnConvertedQty = new DataGridViewTextBoxColumn();
            var ColColumnExpDate = new DataGridViewTextBoxColumn();


            ColColumnStockNumber.HeaderText = "Stock Number";
            ColColumnStockNumber.Name = "ColumnStockNumber";
            ColColumnStockNumber.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColColumnStockNumber.Width = 200;
            ColColumnStockNumber.ReadOnly = true;

            ColColumnItem.HeaderText = "Description";
            ColColumnItem.Name = "ColumnItem";
            ColColumnItem.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColColumnItem.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColColumnItem.Width = 300;
            ColColumnItem.ReadOnly = true;

            ColColumnQtyCS.HeaderText = "CS";
            ColColumnQtyCS.Name = "ColumnCS";
            ColColumnQtyCS.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColColumnQtyCS.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColColumnQtyCS.Width = 100;
            ColColumnQtyCS.ReadOnly = true;

            ColColumnQtyIB.HeaderText = "IB";
            ColColumnQtyIB.Name = "ColumnIB";
            ColColumnQtyIB.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColColumnQtyIB.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColColumnQtyIB.Width = 100;
            ColColumnQtyIB.ReadOnly = true;

            ColColumnQtyPC.HeaderText = "PC";
            ColColumnQtyPC.Name = "ColumnPC";
            ColColumnQtyPC.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColColumnQtyPC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColColumnQtyPC.Width = 100;
            ColColumnQtyPC.ReadOnly = true;

            ColColumnConvertedQty.HeaderText = "ConvertedQty";
            ColColumnConvertedQty.Name = "ColColumnConvertedQty";
            ColColumnConvertedQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColColumnConvertedQty.Width = 100;
            ColColumnConvertedQty.Visible = false;
            ColColumnConvertedQty.ReadOnly = true;

            ColColumnExpDate.HeaderText = "Exp. Date";
            ColColumnExpDate.Name = "ColumnExpDate";
            ColColumnExpDate.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColColumnExpDate.Width = 85;

            dgv1.Columns.AddRange(new DataGridViewColumn[] { ColColumnStockNumber, ColColumnItem, ColColumnQtyCS, ColColumnQtyIB, ColColumnQtyPC, ColColumnConvertedQty, ColColumnExpDate });

        }

        private void PostExpiration()
        {
            for (int x = 0; x < dgv1.Rows.Count; x++)
            {
                LoadPDExp(dgv1.Rows[x].Cells[0].Value.ToString());
                DetermineExp(dgv1.Rows[x].Cells[5].Value.ToString());
                dgv1.Rows[x].Cells[6].Value = strExpDate;
            }
        }



        private void LoadPDExp(string strStockNumber)
        {
            ClsGetSomething1.ClsGetProductDetails(strStockNumber, "01");
            pristrIB = ClsGetSomething1.plvarib;
            pristrpiece = ClsGetSomething1.plvarpiece;

            dgv2.DataSource = null;
            dgv2.Columns.Clear();

            string sqlstatement = "SELECT TDate, ConvertedQty, ExpDate FROM ViewPDExpiration WHERE StockNumber = '" + strStockNumber + "' ORDER BY ExpDate DESC";

            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = myconnection.CreateCommand();
            mycommand.CommandText = sqlstatement;
            mycommand.CommandTimeout = 900;
            SqlDataReader1 = mycommand.ExecuteReader();
            DataTable DataTable1 = new DataTable();
            DataTable1.Load(SqlDataReader1);
            myconnection.Close();

            bindingSource = new BindingSource();
            bindingSource.DataSource = DataTable1;

            //if (DataTable1.Rows.Count == 0)
            //{
            //    MessageBox.Show("No data found", "GL");
            //    return;
            //}


            //Adding  Date TextBox
            DataGridViewTextBoxColumn ColumnTDate = new DataGridViewTextBoxColumn();
            ColumnTDate.HeaderText = "Date";
            ColumnTDate.Width = 75;
            ColumnTDate.DataPropertyName = "TDate";
            ColumnTDate.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnTDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //ColumnTDate.Visible = false;
            ColumnTDate.ReadOnly = true;
            dgv2.Columns.Add(ColumnTDate);


            DataGridViewTextBoxColumn ColumnConvertedQty = new DataGridViewTextBoxColumn();
            ColumnConvertedQty.HeaderText = "ConvertedQty";
            ColumnConvertedQty.Width = 100;
            ColumnConvertedQty.DataPropertyName = "ConvertedQty";
            ColumnConvertedQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnConvertedQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnConvertedQty.Visible = true;
            dgv2.Columns.Add(ColumnConvertedQty);

            //Adding  Date TextBox
            DataGridViewTextBoxColumn ColumnExpDate = new DataGridViewTextBoxColumn();
            ColumnExpDate.HeaderText = "Date";
            ColumnExpDate.Width = 75;
            ColumnExpDate.DataPropertyName = "ExpDate";
            ColumnExpDate.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnExpDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //ColumnExpDate.Visible = false;
            ColumnExpDate.ReadOnly = true;
            dgv2.Columns.Add(ColumnExpDate);



            //Setting Data Source for DataGridView
            dgv2.DataSource = bindingSource;
            //dgv1.AutoResizeColumns();
            //dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgv2.Columns[1].DefaultCellStyle.Format = "N0";
            //dgv2.Columns[2].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgv2.Columns[2].DefaultCellStyle.Format = "yyyy/MM/dd";
        }

        private void DetermineExp(string strConvertedQty)
        {
            double douCounter = 0;
            double douConvertQtyBal = double.Parse(strConvertedQty);
            douCounter = douConvertQtyBal;

            DataGridViewRow row = null;
            for (int x = 0; x < dgv2.Rows.Count; x++)
            {
                row = dgv2.Rows[x];
                if (douCounter == 0)
                {

                }
                else if (douCounter <= double.Parse(row.Cells[1].FormattedValue.ToString()))
                {
                    strExpDate = row.Cells[2].FormattedValue.ToString();
                    douCounter = 0;
                }
                else if (douCounter > double.Parse(row.Cells[1].FormattedValue.ToString()))
                {
                    strExpDate = row.Cells[2].FormattedValue.ToString();
                    douCounter = douCounter - double.Parse(row.Cells[1].FormattedValue.ToString());
                }
            }
        }
    }
}
