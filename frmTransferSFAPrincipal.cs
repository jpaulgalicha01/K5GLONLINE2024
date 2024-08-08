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
    public partial class frmTransferSFAPrincipal : Form
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
        public frmTransferSFAPrincipal()
        {
            InitializeComponent();
        }

        private void frmStock_Load(object sender, EventArgs e)
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
                //sql = "SELECT StockNumber, Item, MCode, CatCode, SCode, MRCode, RN  FROM tblStocks";
                sql = "SELECT ClassCode, ClassDesc, TransferSFA, PoultryPrincipal FROM tblStockClass";

                da = new SqlDataAdapter(sql, myconnection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
                dataTable = new DataTable();
                da.Fill(dataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;


                DataGridViewTextBoxColumn ColumnClassCode = new DataGridViewTextBoxColumn();
                ColumnClassCode.HeaderText = "Class Code";
                ColumnClassCode.Width = 80;
                ColumnClassCode.DataPropertyName = "ClassCode";
                ColumnClassCode.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ColumnClassCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                ColumnClassCode.ReadOnly = true;
                ColumnClassCode.Visible = false;
                dgv1.Columns.Add(ColumnClassCode);

                //Adding  CustName TextBox
                DataGridViewTextBoxColumn ColumnClassDesc = new DataGridViewTextBoxColumn();
                ColumnClassDesc.HeaderText = "Principal";
                ColumnClassDesc.Width = 220;
                ColumnClassDesc.DataPropertyName = "ClassDesc";
                ColumnClassDesc.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ColumnClassDesc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                ColumnClassDesc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                ColumnClassDesc.ReadOnly = true;
                dgv1.Columns.Add(ColumnClassDesc);

                DataGridViewCheckBoxColumn ColumnTransferSFA = new DataGridViewCheckBoxColumn();
                ColumnTransferSFA.HeaderText = "Transfer to SFA";
                ColumnTransferSFA.Width = 100;
                ColumnTransferSFA.DataPropertyName = "TransferSFA";
                ColumnTransferSFA.FalseValue = 0;
                ColumnTransferSFA.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ColumnTransferSFA.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv1.Columns.Add(ColumnTransferSFA);


                DataGridViewCheckBoxColumn ColumnPoultryPrincipal = new DataGridViewCheckBoxColumn();
                ColumnPoultryPrincipal.HeaderText = "Poultry Principal";
                ColumnPoultryPrincipal.Width = 100;
                ColumnPoultryPrincipal.DataPropertyName = "PoultryPrincipal";
                ColumnPoultryPrincipal.FalseValue = 0;
                ColumnPoultryPrincipal.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ColumnPoultryPrincipal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv1.Columns.Add(ColumnPoultryPrincipal);

                //Setting Data Source for DataGridView
                dgv1.DataSource = bindingSource;
                //dgv1.AutoResizeColumns();
                //dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                myconnection.Close();
                this.WindowState = FormWindowState.Normal;
                dgv1.AllowUserToAddRows = false;
                //dgv1.Columns[8].DefaultCellStyle.Format = "N0";
                //dgv1.Columns[2].DefaultCellStyle.Format = "N2";
                //dgv1.Columns[10].DefaultCellStyle.Format = "N2";

            }
        }

        private void btnsave_Click(object sender, EventArgs e)
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

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
