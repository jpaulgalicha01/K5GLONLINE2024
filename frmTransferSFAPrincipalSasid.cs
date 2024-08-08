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
    public partial class frmTransferSFAPrincipalSasid : Form
    {
        private SqlDataAdapter da;
        private DataTable dataTable = null;
        private SqlConnection myconnection;
        private BindingSource bindingSource = null;
        BindingSource bsource = new BindingSource();
        string sql;
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        public frmTransferSFAPrincipalSasid()
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
                LoadData();
            }
        }

        private void LoadData()
        {
            sql = "SELECT ControlNo, CustName, SuppSalesman, Sasid FROM tblCustomer WHERE Active=1 AND NType='S' ORDER BY CustName";

            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            da = new SqlDataAdapter(sql, myconnection);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
            da.SelectCommand.CommandTimeout = 600;
            dataTable = new DataTable();
            da.Fill(dataTable);
            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;
            myconnection.Close();

            DataGridViewTextBoxColumn ColumnControlNo = new DataGridViewTextBoxColumn();
            ColumnControlNo.HeaderText = "Code";
            ColumnControlNo.Width = 80;
            ColumnControlNo.DataPropertyName = "ControlNo";
            ColumnControlNo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnControlNo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnControlNo.ReadOnly = true;
            ColumnControlNo.Visible = false;
            dgv1.Columns.Add(ColumnControlNo);

            //Adding  CustName TextBox
            DataGridViewTextBoxColumn ColumnCustName = new DataGridViewTextBoxColumn();
            ColumnCustName.HeaderText = "Name";
            ColumnCustName.Width = 120;
            ColumnCustName.DataPropertyName = "CustName";
            ColumnCustName.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnCustName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnCustName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnCustName.ReadOnly = true;
            dgv1.Columns.Add(ColumnCustName);

            //Adding  SuppSalesman TextBox
            DataGridViewTextBoxColumn ColumnSuppSalesman = new DataGridViewTextBoxColumn();
            ColumnSuppSalesman.HeaderText = "Salesman";
            ColumnSuppSalesman.Width = 150;
            ColumnSuppSalesman.DataPropertyName = "SuppSalesman";
            ColumnSuppSalesman.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnSuppSalesman.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //ColumnSuppSalesman.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv1.Columns.Add(ColumnSuppSalesman);

            //Adding  Sasid TextBox
            DataGridViewTextBoxColumn ColumnSasid = new DataGridViewTextBoxColumn();
            ColumnSasid.HeaderText = "Sasid";
            ColumnSasid.Width = 150;
            ColumnSasid.DataPropertyName = "Sasid";
            ColumnSasid.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnSasid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //ColumnSasid.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv1.Columns.Add(ColumnSasid);

            //Setting Data Source for DataGridView
            dgv1.DataSource = bindingSource;
            //dgv1.AutoResizeColumns();
            //dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //this.WindowState = FormWindowState.Normal;
            dgv1.AllowUserToAddRows = false;
            //dgv1.Columns[8].DefaultCellStyle.Format = "N0";
            //dgv1.Columns[2].DefaultCellStyle.Format = "N2";
            //dgv1.Columns[10].DefaultCellStyle.Format = "N2";

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
