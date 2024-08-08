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
    public partial class frmOtherNameEdit : Form
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

        public frmOtherNameEdit()
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
                sql = "SELECT ControlNo,  CustName, ContactNo, TIN, Address FROM tblCustomer WHERE NType ='O' ORDER BY CustName";

                da = new SqlDataAdapter(sql, myconnection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
                da.SelectCommand.CommandTimeout = 600;
                dataTable = new DataTable();
                da.Fill(dataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;

                //Adding  ControlNo TextBox
                DataGridViewTextBoxColumn ColumnControlNo = new DataGridViewTextBoxColumn();
                ColumnControlNo.HeaderText = "Code";
                ColumnControlNo.Width = 80;
                ColumnControlNo.DataPropertyName = "ControlNo";
                ColumnControlNo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                ColumnControlNo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                ColumnControlNo.Visible = false;
                dgv1.Columns.Add(ColumnControlNo);

                ////Adding  CustCode TextBox
                //DataGridViewTextBoxColumn ColumnCustCode = new DataGridViewTextBoxColumn();
                //ColumnCustCode.HeaderText = "Code";
                ////ColumnIB.Width = 80;
                //ColumnCustCode.DataPropertyName = "CustCode";
                //ColumnCustCode.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                //ColumnCustCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                //ColumnCustCode.ReadOnly = true;
                //dgv1.Columns.Add(ColumnCustCode);

                //Adding  CustName TextBox
                DataGridViewTextBoxColumn ColumnCustName = new DataGridViewTextBoxColumn();
                ColumnCustName.HeaderText = "Name";
                ColumnCustName.Width = 300;
                ColumnCustName.DataPropertyName = "CustName";
                ColumnCustName.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ColumnCustName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv1.Columns.Add(ColumnCustName);

                //Adding  ContactNo TextBox
                DataGridViewTextBoxColumn ColumnContactNo = new DataGridViewTextBoxColumn();
                ColumnContactNo.HeaderText = "Contact Number";
                ColumnContactNo.Width = 120;
                ColumnContactNo.DataPropertyName = "ContactNo";
                ColumnContactNo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ColumnContactNo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv1.Columns.Add(ColumnContactNo);

                //Adding  TIN TextBox
                DataGridViewTextBoxColumn ColumnTIN = new DataGridViewTextBoxColumn();
                ColumnTIN.HeaderText = "TIN";
                ColumnTIN.Width = 130;
                ColumnTIN.DataPropertyName = "TIN";
                ColumnTIN.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ColumnTIN.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv1.Columns.Add(ColumnTIN);

                //Adding  Address TextBox
                DataGridViewTextBoxColumn ColumnAddress = new DataGridViewTextBoxColumn();
                ColumnAddress.HeaderText = "Address";
                ColumnAddress.Width = 300;
                ColumnAddress.DataPropertyName = "Address";
                ColumnAddress.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ColumnAddress.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv1.Columns.Add(ColumnAddress);

                //Setting Data Source for DataGridView
                dgv1.DataSource = bindingSource;
                //dgv1.AutoResizeColumns();
                //dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                myconnection.Close();
                this.WindowState = FormWindowState.Maximized;
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
