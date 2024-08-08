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
    public partial class frmSMEdit : Form
    {
        private SqlDataAdapter da;
        private DataTable dataTable = null;
        private SqlConnection myconnection;
        private BindingSource bindingSource = null;
        BindingSource bsource = new BindingSource();
        //   DataSet ds = null;
        string sql;
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection(); 

        public frmSMEdit()
        {
            InitializeComponent();
        }

        private void frmNameEdit_Load(object sender, EventArgs e)
        {
            ClsPermission1.ClsObjects(this.Text);
            if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
            {
                MessageBox.Show("You do not have necessary permission to open this file", "GL");
                this.Close();
            }
            else
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                sql = "SELECT SLS, Names, WHCode FROM tblSalesman WHERE Active =1 ORDER BY Names";

                da = new SqlDataAdapter(sql, myconnection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
                da.SelectCommand.CommandTimeout = 600;
                dataTable = new DataTable();
                da.Fill(dataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;

                string selectQueryStringtblWarehouse = "SELECT WHCode, Warehouse FROM tblWarehouse ORDER BY Warehouse";
                SqlDataAdapter sqlDataAdaptertblWarehouse = new SqlDataAdapter(selectQueryStringtblWarehouse, myconnection);
                SqlCommandBuilder sqlCommandBuildertblWarehouse = new SqlCommandBuilder(sqlDataAdaptertblWarehouse);
                DataTable dataTabletblWarehouse = new DataTable();
                sqlDataAdaptertblWarehouse.Fill(dataTabletblWarehouse);
                BindingSource bindingSourcetblWarehouse = new BindingSource();
                bindingSourcetblWarehouse.DataSource = dataTabletblWarehouse;

                //Adding  ControlNo TextBox
                DataGridViewTextBoxColumn ColumnSLS = new DataGridViewTextBoxColumn();
                ColumnSLS.HeaderText = "SLS";
                ColumnSLS.Width = 80;
                ColumnSLS.DataPropertyName = "SLS";
                ColumnSLS.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                ColumnSLS.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                ColumnSLS.Visible = false;
                dgv1.Columns.Add(ColumnSLS);

                //Adding  CustName TextBox
                DataGridViewTextBoxColumn ColumnNames = new DataGridViewTextBoxColumn();
                ColumnNames.HeaderText = "Name";
                ColumnNames.Width = 300;
                ColumnNames.DataPropertyName = "Names";
                ColumnNames.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ColumnNames.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv1.Columns.Add(ColumnNames);

                DataGridViewComboBoxColumn ColumnWHCode = new DataGridViewComboBoxColumn();
                ColumnWHCode.DataPropertyName = "WHCode";
                ColumnWHCode.HeaderText = "Warehouse";
                ColumnWHCode.Width = 200;
                ColumnWHCode.DataSource = bindingSourcetblWarehouse;
                ColumnWHCode.ValueMember = "WHCode";
                ColumnWHCode.DisplayMember = "Warehouse";
                dgv1.Columns.Add(ColumnWHCode);

                //Setting Data Source for DataGridView
                dgv1.DataSource = bindingSource;
                //dgv1.AutoResizeColumns();
                //dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                myconnection.Close();
                //this.WindowState = FormWindowState.Maximized;
                dgv1.AllowUserToAddRows = false;
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                da.Update(dataTable);
                MessageBox.Show("Saved", "GL");
                this.Close();

            }
            catch (Exception exceptionObj)
            {
                MessageBox.Show(exceptionObj.Message.ToString());
            }

        }
    }
}
