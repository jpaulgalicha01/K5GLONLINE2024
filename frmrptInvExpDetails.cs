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
    public partial class frmrptInvExpDetails : Form
    {
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        ClsGetSomething ClsGetSomething1 = new ClsGetSomething();
        SqlConnection myconnection;
        SqlCommand mycommand;
        SqlDataReader SqlDataReader1;
        BindingSource bindingSource = null;
        public static DataGridView glbldgvED;
        private string pristrIB, pristrpiece;
        public frmrptInvExpDetails()
        {
            InitializeComponent();
        }

        public void LoadPDExp()
        {
            ClsGetSomething1.ClsGetProductDetails(frmrptInventoryExpiration.glbltxtStockNumber.Text, "01");
            pristrIB = ClsGetSomething1.plvarib;
            pristrpiece = ClsGetSomething1.plvarpiece;
            
            dgv2.DataSource = null;
            dgv2.Columns.Clear();

            string sqlstatement = "SELECT TDate, ConvertedQty, ExpDate, IC, Num, StockNumber FROM ViewPDExpiration WHERE StockNumber = '" + frmrptInventoryExpiration.glbltxtStockNumber.Text+ "' ORDER BY ExpDate DESC";

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


            //Adding  Date TextBox
            DataGridViewTextBoxColumn ColumnTDate = new DataGridViewTextBoxColumn();
            ColumnTDate.HeaderText = "Date";
            ColumnTDate.Width = 75;
            ColumnTDate.DataPropertyName = "TDate";
            ColumnTDate.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnTDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnTDate.Visible = false;
            ColumnTDate.ReadOnly = true;
            dgv2.Columns.Add(ColumnTDate);



            DataGridViewTextBoxColumn ColumnConvertedQty = new DataGridViewTextBoxColumn();
            ColumnConvertedQty.HeaderText = "ConvertedQty";
            ColumnConvertedQty.Width = 100;
            ColumnConvertedQty.DataPropertyName = "ConvertedQty";
            ColumnConvertedQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnConvertedQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //ColumnConvertedQty.Visible = true;
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

            DataGridViewTextBoxColumn ColumnIC= new DataGridViewTextBoxColumn();
            ColumnIC.HeaderText = "IC";
            ColumnIC.Width = 75;
            ColumnIC.DataPropertyName = "IC";
            ColumnIC.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnIC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnExpDate.Visible = false;
            ColumnIC.ReadOnly = true;
            dgv2.Columns.Add(ColumnIC);

            DataGridViewTextBoxColumn ColumnNum = new DataGridViewTextBoxColumn();
            ColumnNum.HeaderText = "Num";
            ColumnNum.Width = 75;
            ColumnNum.DataPropertyName = "Num";
            ColumnNum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnNum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnExpDate.Visible = false;
            ColumnNum.ReadOnly = true;
            dgv2.Columns.Add(ColumnNum);

             DataGridViewTextBoxColumn ColumnStockNumber = new DataGridViewTextBoxColumn();
            ColumnStockNumber.HeaderText = "StockNumber";
            ColumnStockNumber.Width = 75;
            ColumnStockNumber.DataPropertyName = "StockNumber";
            ColumnStockNumber.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnStockNumber.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnStockNumber.Visible = false;
            ColumnStockNumber.ReadOnly = true;
            dgv2.Columns.Add(ColumnStockNumber);

            //Setting Data Source for DataGridView
            dgv2.DataSource = bindingSource;
            //dgv1.AutoResizeColumns();
            //dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgv2.Columns[1].DefaultCellStyle.Format = "N0";
            dgv2.Columns[2].DefaultCellStyle.Format = "MM/dd/yyyy";
        }

        private void frmrptInvExpDetails_Load(object sender, EventArgs e)
        {
            glbldgvED = dgv1;
            LoadPDExp();
            DetermineExp();
        }
        private void dgv1_DoubleClick(object sender, EventArgs e)
        {
            frmrptInvExpDetailsEdit frmrptInventoryExpiration1 = new frmrptInvExpDetailsEdit();
            frmrptInventoryExpiration1.Show();
        }
        private void DetermineExp()
        {
            double douCounter = 0;
            double douConvertQtyBal = double.Parse(frmrptInventoryExpiration.glbltxtConvertedQty.Text);
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
                    string strConvertCS;
                    if (int.Parse(pristrIB) == 0)
                    {
                        strConvertCS = (douCounter / int.Parse(pristrpiece)).ToString("N2");
                    }
                    else
                    {
                        strConvertCS = ((douCounter / int.Parse(pristrIB)) / int.Parse(pristrpiece)).ToString("N2");
                    }

                    dgv1.Rows.Add(strConvertCS, row.Cells[2].FormattedValue.ToString(), row.Cells[3].FormattedValue.ToString(), row.Cells[4].FormattedValue.ToString(), row.Cells[5].FormattedValue.ToString());
                    douCounter = 0;
                }
                else if (douCounter > double.Parse(row.Cells[1].FormattedValue.ToString()))
                {
                    string strConvertCS;
                    if (int.Parse(pristrIB) == 0)
                    {
                        strConvertCS = (double.Parse(row.Cells[1].FormattedValue.ToString()) / int.Parse(pristrpiece)).ToString("N2");
                    }
                    else
                    {
                        strConvertCS = (((double.Parse(row.Cells[1].FormattedValue.ToString()) / int.Parse(pristrIB)) / int.Parse(pristrpiece)).ToString("N2"));
                    }
                    dgv1.Rows.Add(strConvertCS, row.Cells[2].FormattedValue.ToString(), row.Cells[3].FormattedValue.ToString(), row.Cells[4].FormattedValue.ToString(), row.Cells[5].FormattedValue.ToString());
                    douCounter = douCounter - double.Parse(row.Cells[1].FormattedValue.ToString());
                }
            }
        }
    }
}
