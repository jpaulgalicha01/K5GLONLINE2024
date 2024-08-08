using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace K5GLONLINE
{
    public partial class frmProductAFS : Form
    {

        private SqlDataAdapter da;
        private DataTable dataTable = null;
        private SqlConnection myconnection;
        private BindingSource bindingSource = null;
        BindingSource bsource = new BindingSource();
        ClsBuildVoucherComboBox ClsBuildVoucherComboBox1 = new ClsBuildVoucherComboBox();
        ClsGetSomething ClsGetSomething1 = new ClsGetSomething();
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        private string pvsvaritem = null;
        string sql;
        public frmProductAFS()
        {
            InitializeComponent();
        }

        private void frmProductAFS_Load(object sender, EventArgs e)
        {

            ClsPermission1.ClsObjects(this.Text);
            if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
            {
                MessageBox.Show("You do not have necessary permission to open this file", "GL");
                this.Close();
            }
            else
            {
                buildcboWHCode();
                buildcboStocks();
                cboStockNumber.SelectedValue = "";
             
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
            this.cboWHCode.SelectedValue = "000";
        }
        private void buildcboStocks()
        {
            cboStockNumber.DataSource = null;
            ClsBuildVoucherComboBox1.ARLSN.Clear();
            ClsBuildVoucherComboBox1.ClsBuildStocks(Convert.ToBoolean(cbSNEncode.CheckState), false);
            this.cboStockNumber.DataSource = (ClsBuildVoucherComboBox1.ARLSN);
            this.cboStockNumber.DisplayMember = "Display";
            this.cboStockNumber.ValueMember = "Value";
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
                    MessageBox.Show("Not found", "GL");
                    cboStockNumber.Focus();
                }
                else if (new ClsValidation().emptytxt(cboWHCode.Text))
                {
                    MessageBox.Show("Warehouse is empty", "GL");
                    cboWHCode.Focus();
                }
                else
                {
                    txtOrdQCS.Text = "0.00";
                    txtOrdQIB.Text = "0.00";
                    txtOrdQPC.Text = "0.00";
                    txtCStotal.Text = "0.00";
                    txtIBtotal.Text = "0.00";
                    txtPCtotal.Text = "0.00";
                    getproductdetails();
                    
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
            ClsGetSomething1.ClsGetProductDetails(cboStockNumber.SelectedValue.ToString(), txtSPO.Text);
            pvsvaritem = ClsGetSomething1.plsvarItem;
            txtIB.Text = ClsGetSomething1.plvarib;
            txtPiece.Text = ClsGetSomething1.plvarpiece;
            if (Int32.Parse(txtIB.Text) == 0)
            {
                txtOrdQIB.Enabled = false;

                txtOrdQCS.Enabled = false;
                txtOrdQPC.Enabled = false;
            }
            else
            {
                txtOrdQIB.Enabled = false;

                txtOrdQCS.Enabled = false;
                txtOrdQPC.Enabled = false;

            }

            ClsGetSomething1.ClsGetPieceBal(cboWHCode.SelectedValue.ToString(), cboStockNumber.SelectedValue.ToString());
            double varprodbal1 = Convert.ToDouble(ClsGetSomething1.plvarbalance);
            ClsGetSomething1.ClsGetPieceBalunserve(cboWHCode.SelectedValue.ToString(), cboStockNumber.SelectedValue.ToString());
            double varprodbal2 = Convert.ToDouble(ClsGetSomething1.plvarbalanceunserve);
            string strTotPCBal = (varprodbal1 - varprodbal2).ToString("N2");
            ClsGetSomething1.ClsGetConvertedPieceBal(double.Parse(strTotPCBal), int.Parse(txtIB.Text), int.Parse(txtPiece.Text));
            txtOrdQPC.Text = Convert.ToDouble(ClsGetSomething1.plvarpiecebal).ToString("N0");
            txtOrdQIB.Text = Convert.ToDouble(ClsGetSomething1.plvaribbal).ToString("N0");
            txtOrdQCS.Text = Convert.ToDouble(ClsGetSomething1.plvarcsbal).ToString("N0");
        }

        private void cbSNEncode_CheckedChanged(object sender, EventArgs e)
        {
            buildcboStocks();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SODetails();
            int sum = 0;
            int sum1 = 0;
            int sum2 = 0;
            for (int x = 0; x < dgv1.Rows.Count; x++)
            {
                sum += int.Parse(dgv1.Rows[x].Cells[2].Value.ToString());
                sum1 += int.Parse(dgv1.Rows[x].Cells[3].Value.ToString());
                sum2 += int.Parse(dgv1.Rows[x].Cells[4].Value.ToString());
            }
            //int totalcs = int.Parse(txtOrdQCS.Text) + sum;
            txtotalcs.Text = sum.ToString();
            string totalcs = (int.Parse(txtOrdQCS.Text) + int.Parse(txtotalcs.Text)).ToString();
            txtCStotal.Text = totalcs;

            txtTotalbi.Text = sum1.ToString();
            int totalbi = int.Parse(txtOrdQIB.Text) + int.Parse(txtTotalbi.Text);
            txtIBtotal.Text = totalbi.ToString();

            txtTotalpc.Text = sum2.ToString();
            int totalpc = int.Parse(txtOrdQPC.Text) + int.Parse(txtTotalpc.Text);
            txtPCtotal.Text = totalpc.ToString();
        }

        private void SODetails()
        {
            dgv1.DataSource = null;
            dgv1.Rows.Clear();
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);

            sql = "SELECT DocNum, CustName, QtyCS, QtyIB, QtyPC FROM ViewUnServerProductSO WHERE  StockNumber = '" + cboStockNumber.SelectedValue.ToString() + "' AND WHCode = '" + cboWHCode.SelectedValue.ToString()+ "'  ";
            da = new SqlDataAdapter(sql, myconnection);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
            dataTable = new DataTable();
            da.Fill(dataTable);
            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;

            //if (dataTable.Rows.Count == 0)
            //{
            //    MessageBox.Show("No Data Found!", "Warning");
            //    return;
            //}

            //Adding  Control number TextBox
            DataGridViewTextBoxColumn ColumnDucnum = new DataGridViewTextBoxColumn();
            ColumnDucnum.HeaderText = "Number";
            ColumnDucnum.Width = 80;
            ColumnDucnum.DataPropertyName = "DocNum";
            ColumnDucnum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnDucnum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnDucnum.ReadOnly = false;
            ColumnDucnum.Visible = true;
            dgv1.Columns.Add(ColumnDucnum);

            //Adding  SuppCustCode TextBox
            DataGridViewTextBoxColumn ColumnCustName = new DataGridViewTextBoxColumn();
            ColumnCustName.HeaderText = "Name";
            ColumnCustName.Width = 250;
            ColumnCustName.DataPropertyName = "CustName";
            ColumnCustName.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnCustName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnCustName.ReadOnly = false;
            dgv1.Columns.Add(ColumnCustName);

            DataGridViewTextBoxColumn ColumnQtyCS = new DataGridViewTextBoxColumn();
            ColumnQtyCS.HeaderText = "CS";
            ColumnQtyCS.Width = 80;
            ColumnQtyCS.DataPropertyName = "QtyCS";
            ColumnQtyCS.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnQtyCS.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv1.Columns.Add(ColumnQtyCS);

            DataGridViewTextBoxColumn ColumnQtyIB = new DataGridViewTextBoxColumn();
            ColumnQtyIB.HeaderText = "IB";
            ColumnQtyIB.Width = 80;
            ColumnQtyIB.DataPropertyName = "QtyIB";
            ColumnQtyIB.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnQtyIB.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv1.Columns.Add(ColumnQtyIB);

            DataGridViewTextBoxColumn ColumnQtyPC = new DataGridViewTextBoxColumn();
            ColumnQtyPC.HeaderText = "PC";
            ColumnQtyPC.Width = 80;
            ColumnQtyPC.DataPropertyName = "QtyPC";
            ColumnQtyPC.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnQtyPC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv1.Columns.Add(ColumnQtyPC);
          
            //Setting Data Source for DataGridView
            dgv1.DataSource = bindingSource;
            //dgv1.AutoResizeColumns();
            //dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            myconnection.Close();
            //this.WindowState = FormWindowState.Minimized;
            dgv1.AllowUserToAddRows = false;
            //dgv1.Columns[5].DefaultCellStyle.Format = "N2";
          //  dgv1.Columns[6].DefaultCellStyle.Format = "N2";
          //  dgv1.Columns[7].DefaultCellStyle.Format = "N2";

            //Setting Data Source for DataGridView
            dgv1.DataSource = bindingSource;
            myconnection.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
