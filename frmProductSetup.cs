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
    public partial class frmProductSetup : Form
    {

        private SqlDataAdapter da;
        private DataTable dataTable = null;
        private SqlConnection myconnection;
        private BindingSource bindingSource = null;
        BindingSource bsource = new BindingSource();
        BindingSource bs1 = new BindingSource();


        //   DataSet ds = null;
        string sql;
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();
        public frmProductSetup()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ClsPermission1.ClsObjects(this.Text);
            if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
            {
                MessageBox.Show("You do not have necessary permission to open this file", "GL");
                this.Close();
            }
            else
            {
                loadData();
            }
        }

        private void loadData()
        {
            dgv1.DataSource = null;
            dgv1.Columns.Clear();
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            sql = "SELECT StockNumber, Item, IB, Piece, SellCS, SellIB, SellPC, SFAProductCode, FreeGoods, SpecialSKU, PackageKilo, BUMCS, BUMIB, BUMPC FROM tblStocks ORDER  BY Item";

            da = new SqlDataAdapter(sql, myconnection);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);


            dataTable = new DataTable();
            da.Fill(dataTable);
            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;

            DataGridViewTextBoxColumn ColumnStockNumber1 = new DataGridViewTextBoxColumn();
            ColumnStockNumber1.HeaderText = "Stock Number";
            ColumnStockNumber1.Width = 150;
            ColumnStockNumber1.DataPropertyName = "StockNumber";
            ColumnStockNumber1.ReadOnly = true;
            ColumnStockNumber1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnStockNumber1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv1.Columns.Add(ColumnStockNumber1);

            // TYear
            DataGridViewTextBoxColumn ColumnItem = new DataGridViewTextBoxColumn();
            ColumnItem.HeaderText = "Item";
            ColumnItem.Width = 150;
            ColumnItem.DataPropertyName = "Item";
            ColumnItem.ReadOnly = true;
            ColumnItem.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnItem.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnItem.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv1.Columns.Add(ColumnItem);

            DataGridViewTextBoxColumn ColumnIB = new DataGridViewTextBoxColumn();
            ColumnIB.HeaderText = "IB/CS";
            ColumnIB.Width = 60;
            ColumnIB.DataPropertyName = "IB";
            ColumnIB.ReadOnly = false;
            ColumnIB.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnIB.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv1.Columns.Add(ColumnIB);

            DataGridViewTextBoxColumn ColumnPiece = new DataGridViewTextBoxColumn();
            ColumnPiece.HeaderText = "IB/PC";
            ColumnPiece.Width = 60;
            ColumnPiece.DataPropertyName = "Piece";
            ColumnPiece.ReadOnly = false;
            ColumnPiece.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnPiece.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv1.Columns.Add(ColumnPiece);

            DataGridViewCheckBoxColumn ColumnSellCS = new DataGridViewCheckBoxColumn();
            ColumnSellCS.HeaderText = "Sell CS";
            ColumnSellCS.Width = 60;
            ColumnSellCS.DataPropertyName = "SellCS";
            ColumnSellCS.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnSellCS.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv1.Columns.Add(ColumnSellCS);

            DataGridViewCheckBoxColumn ColumnSellIB = new DataGridViewCheckBoxColumn();
            ColumnSellIB.HeaderText = "Sell IB";
            ColumnSellIB.Width = 60;
            ColumnSellIB.DataPropertyName = "SellIB";
            ColumnSellIB.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnSellIB.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv1.Columns.Add(ColumnSellIB);

            DataGridViewCheckBoxColumn ColumnSellPC = new DataGridViewCheckBoxColumn();
            ColumnSellPC.HeaderText = "Sell PC";
            ColumnSellPC.Width = 60;
            ColumnSellPC.DataPropertyName = "SellPC";
            ColumnSellPC.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnSellPC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv1.Columns.Add(ColumnSellPC);

            DataGridViewTextBoxColumn ColumnSFAProductCode = new DataGridViewTextBoxColumn();
            ColumnSFAProductCode.HeaderText = "SFA Product Code";
            ColumnSFAProductCode.Width = 100;
            ColumnSFAProductCode.DataPropertyName = "SFAProductCode";
            ColumnSFAProductCode.ReadOnly = false;
            ColumnSFAProductCode.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnSFAProductCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv1.Columns.Add(ColumnSFAProductCode);

            DataGridViewCheckBoxColumn ColumnFreeGoods = new DataGridViewCheckBoxColumn();
            ColumnFreeGoods.HeaderText = "Free Goods";
            ColumnFreeGoods.Width = 60;
            ColumnFreeGoods.DataPropertyName = "FreeGoods";
            ColumnFreeGoods.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnFreeGoods.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv1.Columns.Add(ColumnFreeGoods);

            DataGridViewCheckBoxColumn ColumnSpecialSKU = new DataGridViewCheckBoxColumn();
            ColumnSpecialSKU.HeaderText = "Special SKU";
            ColumnSpecialSKU.Width = 60;
            ColumnSpecialSKU.DataPropertyName = "SpecialSKU";
            ColumnSpecialSKU.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnSpecialSKU.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv1.Columns.Add(ColumnSpecialSKU);

            DataGridViewTextBoxColumn ColumnPackageKilo = new DataGridViewTextBoxColumn();
            ColumnPackageKilo.HeaderText = "Package Kilo";
            ColumnPackageKilo.Width = 60;
            ColumnPackageKilo.DataPropertyName = "PackageKilo";
            ColumnPackageKilo.ReadOnly = false;
            ColumnPackageKilo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnPackageKilo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv1.Columns.Add(ColumnPackageKilo);

            DataGridViewTextBoxColumn ColumnBUMCS = new DataGridViewTextBoxColumn();
            ColumnBUMCS.HeaderText = "BR UMCS";
            ColumnBUMCS.Width = 50;
            ColumnBUMCS.DataPropertyName = "BUMCS";
            ColumnBUMCS.ReadOnly = false;
            ColumnBUMCS.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnBUMCS.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv1.Columns.Add(ColumnBUMCS);

            DataGridViewTextBoxColumn ColumnBUMIB = new DataGridViewTextBoxColumn();
            ColumnBUMIB.HeaderText = "BR UMIB";
            ColumnBUMIB.Width = 50;
            ColumnBUMIB.DataPropertyName = "BUMIB";
            ColumnBUMIB.ReadOnly = false;
            ColumnBUMIB.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnBUMIB.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv1.Columns.Add(ColumnBUMIB);

            DataGridViewTextBoxColumn ColumnBUMPC = new DataGridViewTextBoxColumn();
            ColumnBUMPC.HeaderText = "BR UMPC";
            ColumnBUMPC.Width = 50;
            ColumnBUMPC.DataPropertyName = "BUMPC";
            ColumnBUMPC.ReadOnly = false;
            ColumnBUMPC.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnBUMPC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv1.Columns.Add(ColumnBUMPC);

            //Setting Data Source for DataGridView
            //dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv1.DataSource = bindingSource;
            dgv1.Columns[10].DefaultCellStyle.Format = "N2";
            //dgv1.Columns[3].DefaultCellStyle.Format = "N2";
            myconnection.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                da.Update(dataTable);
                loadData();
                MessageBox.Show("Saved", "GL");
            }
            catch (Exception exceptionObj)
            {
                MessageBox.Show(exceptionObj.Message.ToString());
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dataTable.DefaultView;

            dv.RowFilter = "StockNumber LIKE '" + txtSearch.Text + "%'";
            dgv1.DataSource = dv;
        }
    }
}
