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
    public partial class frmEntrySMProductBlocking : Form
    {
        private SqlDataAdapter da;
        private DataTable dataTable = null;
        private SqlConnection myconnection;
        private BindingSource bindingSource = null;
        BindingSource bindingSourcetblSupplier = new BindingSource();
        BindingSource bindingSourcetblSPOption = new BindingSource();
        BindingSource bsource = new BindingSource();
        string sql;
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        ClsBuildEntryComboBox ClsBuildEntryComboBox1 = new ClsBuildEntryComboBox();
        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();
        SqlCommand mycommand;
        public frmEntrySMProductBlocking()
        {
            InitializeComponent();
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
        
        private void buildcboSM()
        {
            cboControlNo.DataSource = null;
            ClsBuildComboBox1.PALSalesman.Clear();
            ClsBuildComboBox1.ClsBuildSalesman();
            this.cboControlNo.DataSource = (ClsBuildComboBox1.PALSalesman);
            this.cboControlNo.DisplayMember = "Display";
            this.cboControlNo.ValueMember = "Value";
        }

        private void LoadData(string strControlNo)
        {
            dgv1.DataSource = null;
            dgv1.Columns.Clear();

            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);

            sql = "SELECT SMCode, StockNumber, Item, Qty FROM tblSMStockBlock WHERE SMCode = '" + strControlNo + "'";
            da = new SqlDataAdapter(sql, myconnection);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
            dataTable = new DataTable();
            da.Fill(dataTable);
            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;

            ////Supplier Data Source
            //string selectQueryStringtblSupplier = "SELECT ControlNo, CustName FROM tblCustomer WHERE ORDER BY CustName ";
            //SqlDataAdapter sqlDataAdaptertblSupplier = new SqlDataAdapter(selectQueryStringtblSupplier, myconnection);
            //SqlCommandBuilder sqlCommandBuildertblSupplier = new SqlCommandBuilder(sqlDataAdaptertblSupplier);
            //DataTable dataTabletblSupplier = new DataTable();
            //sqlDataAdaptertblSupplier.Fill(dataTabletblSupplier);
            //bindingSourcetblSupplier.DataSource = dataTabletblSupplier;


            string selectQueryStringtblStocks = "SELECT StockNumber, Item FROM tblStocks ORDER BY Item";
            SqlDataAdapter sqlDataAdaptertblStocks = new SqlDataAdapter(selectQueryStringtblStocks, myconnection);
            SqlCommandBuilder sqlCommandBuildertblStocks = new SqlCommandBuilder(sqlDataAdaptertblStocks);
            DataTable dataTabletblStocks = new DataTable();
            sqlDataAdaptertblStocks.Fill(dataTabletblStocks);
            BindingSource bindingSourcetblStocks = new BindingSource();
            bindingSourcetblStocks.DataSource = dataTabletblStocks;
            
            //string selectQueryStringtblWHCode = "SELECT WHCode, Warehouse FROM tblWarehouse ORDER BY Warehouse";
            //SqlDataAdapter sqlDataAdaptertblWHCode = new SqlDataAdapter(selectQueryStringtblWHCode, myconnection);
            //SqlCommandBuilder sqlCommandBuildertblWHCode = new SqlCommandBuilder(sqlDataAdaptertblWHCode);
            //DataTable dataTabletblWHCode = new DataTable();
            //sqlDataAdaptertblWHCode.Fill(dataTabletblWHCode);
            //BindingSource bindingSourcetblWHCode = new BindingSource();
            //bindingSourcetblWHCode.DataSource = dataTabletblWHCode;

            ////Adding  PKCode TextBox
            //DataGridViewTextBoxColumn ColumnPKCode = new DataGridViewTextBoxColumn();
            //ColumnPKCode.HeaderText = "PKCode";
            //ColumnPKCode.Width = 80;
            //ColumnPKCode.DataPropertyName = "PKCode";
            //ColumnPKCode.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //ColumnPKCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //ColumnPKCode.Visible = false;
            //dgv1.Columns.Add(ColumnPKCode);

            ////Adding  ControlNo TextBox
            //DataGridViewTextBoxColumn ColumnControlNo = new DataGridViewTextBoxColumn();
            //ColumnControlNo.HeaderText = "ControlNo";
            //ColumnControlNo.Width = 80;
            //ColumnControlNo.DataPropertyName = "ControlNo";
            //ColumnControlNo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //ColumnControlNo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //ColumnControlNo.Visible = false;
            //dgv1.Columns.Add(ColumnControlNo);

            DataGridViewTextBoxColumn ColumnControlNo = new DataGridViewTextBoxColumn();
            ColumnControlNo.HeaderText = "SMCode";
            ColumnControlNo.Width = 100;
            ColumnControlNo.DataPropertyName = "SMCode";
            ColumnControlNo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnControlNo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnControlNo.Visible = false;
            ColumnControlNo.ReadOnly = true;
            dgv1.Columns.Add(ColumnControlNo);

            //Adding  SuppCode Combo
            DataGridViewComboBoxColumn ColumnItem = new DataGridViewComboBoxColumn();
            ColumnItem.DataPropertyName = "StockNumber";
            ColumnItem.HeaderText = "StockNumber";
            ColumnItem.Width = 250;
            ColumnItem.DataSource = bindingSourcetblStocks;
            ColumnItem.ValueMember = "StockNumber";
            ColumnItem.DisplayMember = "Item";
            ColumnItem.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnItem.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnItem.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnItem.ReadOnly = false;
            dgv1.Columns.Add(ColumnItem);

            DataGridViewTextBoxColumn ColumnStockNumber = new DataGridViewTextBoxColumn();
            ColumnStockNumber.HeaderText = "Item";
            ColumnStockNumber.Width = 200;
            ColumnStockNumber.DataPropertyName = "Item";
            ColumnStockNumber.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnStockNumber.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnStockNumber.ReadOnly = true;
            ColumnStockNumber.Visible = false;
            dgv1.Columns.Add(ColumnStockNumber);

            DataGridViewTextBoxColumn ColumnQty = new DataGridViewTextBoxColumn();
            ColumnQty.HeaderText = "Qty";
            ColumnQty.Width = 100;
            ColumnQty.DataPropertyName = "Qty";
            ColumnQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnQty.ReadOnly = false;
            ColumnQty.Visible = false;
            dgv1.Columns.Add(ColumnQty);

            ////Adding  SuppCode Combo
            //DataGridViewComboBoxColumn ColumnWHCode = new DataGridViewComboBoxColumn();
            //ColumnWHCode.DataPropertyName = "WHCode";
            //ColumnWHCode.HeaderText = "Warehouse";
            //ColumnWHCode.Width = 250;
            //ColumnWHCode.DataSource = bindingSourcetblWHCode;
            //ColumnWHCode.ValueMember = "WHCode";
            //ColumnWHCode.DisplayMember = "Warehouse";
            //ColumnWHCode.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //ColumnWHCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ////ColumnWHCode.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //ColumnWHCode.ReadOnly = false;
            //dgv1.Columns.Add(ColumnWHCode);

            //Setting Data Source for DataGridView
            dgv1.DataSource = bindingSource;
            //dgv1.AutoResizeColumns();
            //dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            myconnection.Close();
            //this.WindowState = FormWindowState.Maximized;
            // dgv1.AllowUserToAddRows = false;
            dgv1.Columns[1].Name = "StockNumber";
        }

        private void frmProductEditDatasheet_Load(object sender, EventArgs e)
        {
            ClsPermission1.ClsObjects(this.Text);
            if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
            {
                MessageBox.Show("You do not have necessary permission to open this file", "GL");
                this.Close();
            }
            else
            {
                buildcboSM();
                cboControlNo.SelectedValue = "";
            }

        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (new ClsValidation().emptytxt(cboControlNo.Text))
            {
                MessageBox.Show("Please choose customer", "GL");
                cboControlNo.Focus();
            }
            else
            {
                try
                {
                    da.Update(dataTable);
                    MessageBox.Show("Saved", "GL");
                }
                catch (Exception exceptionObj)
                {
                    MessageBox.Show(exceptionObj.Message.ToString());
                }
            }
        }

        private void cboVariousCombo_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().emptytxt(cboControlNo.Text))
            {
            }
            else if (cboControlNo.Text != null && cboControlNo.SelectedValue == null)
            {
                MessageBox.Show(cboControlNo.Text + " " + "Not Found", "GL");
                cboControlNo.Focus();
            }
            else
            {
                LoadData(cboControlNo.SelectedValue.ToString());
            }
        }


        private void dgv1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //Clear the row error in case the user presses ESC.   
            dgv1.Rows[e.RowIndex].ErrorText = String.Empty;

            DataGridViewRow row1 = dgv1.Rows[e.RowIndex];
            if (new ClsValidation().emptytxt(row1.Cells[1].FormattedValue.ToString()))
            {
            }
            else
            {
                if (e.ColumnIndex == dgv1.Columns["StockNumber"].Index)
                {
                    string[] values = new string[1];
                    DataGridViewRow row = dgv1.Rows[e.RowIndex];
                    row.Cells[0].Value = cboControlNo.SelectedValue.ToString();
                    row.Cells[2].Value = row.Cells[1].FormattedValue.ToString();
                }
            }
        }

        private void nextfieldenter2(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dgv1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox)
            {
                //SendKeys.Send("{F4}");
                SendKeys.Send("%{Down}");
            }
            //ComboBox cboPA = e.Control as ComboBox;
            //if (cboPA != null)
            //{
            //    cboPA.IntegralHeight = false;
            //    cboPA.MaxDropDownItems = 12;
            //}

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (new ClsValidation().emptytxt(cboControlNo.Text))
            {
                MessageBox.Show("Please choose customer", "GL");
                cboControlNo.Focus();
            }
            else
            {
                foreach (DataGridViewRow row in dgv1.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[7].Value) == true)
                    {
                        string strPKCode = row.Cells[0].Value.ToString();
                        string sqldel = "DELETE FROM tblCustomerSPOption WHERE PKCode='" + strPKCode + "'";
                        ClsGetConnection1.ClsGetConMSSQL();
                        myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                        myconnection.Open();
                        mycommand = new SqlCommand(sqldel, myconnection);
                        int nmsg1 = mycommand.ExecuteNonQuery();
                        myconnection.Close();
                    }
                }
                LoadData(cboControlNo.SelectedValue.ToString());
            }
        }

        private void ShowAllSupplier()
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            SqlCommand SqlCommand1 = myconnection.CreateCommand();
            string sqlStatement = "SELECT StockNumber FROM tblStockBlock ORDER BY StockNumber ";

            SqlCommand1.CommandText = sqlStatement;
            SqlDataReader SqlDataReader1;
            myconnection.Open();
            SqlDataReader1 = SqlCommand1.ExecuteReader();
            DataTable DataTable1 = new DataTable();
            DataTable1.Load(SqlDataReader1);
            string Sqlstatement = "INSERT INTO tblStockBlock (ControlNo, StockNumber, Item, Qty) Values (@_ControlNo, @_StockNumber, @_Item, @_Qty)";
            foreach (DataRow row in DataTable1.Rows)
            {
                mycommand = new SqlCommand(Sqlstatement, myconnection);
                mycommand.Parameters.Add("_ControlNo", SqlDbType.VarChar).Value = cboControlNo.SelectedValue.ToString();
                mycommand.Parameters.Add("_StockNumber", SqlDbType.VarChar).Value = row["StockNumber"].ToString();
                mycommand.Parameters.Add("_Item", SqlDbType.VarChar).Value = row["StockNumber"].ToString();
                mycommand.Parameters.Add("_Qty", SqlDbType.Int).Value = row["Qty"].ToString();
                mycommand.ExecuteNonQuery();
            }
            myconnection.Close();
            LoadData(cboControlNo.SelectedValue.ToString());
        }

        private void btnPostAllSupplier_Click(object sender, EventArgs e)
        {
            if (dgv1.Rows.Count > 1)
            {
                MessageBox.Show("Cannot post all item", "GL");
            }
            else if (string.IsNullOrEmpty(cboControlNo.Text))
            {
                MessageBox.Show("Customer is empty", "GL");
                cboControlNo.Focus();
            }
            else
            {
                ShowAllSupplier();
            }
        }
    }
}