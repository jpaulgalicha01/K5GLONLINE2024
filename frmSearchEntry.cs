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
    public partial class frmSearchEntry : Form
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
        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();

        public frmSearchEntry()
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
                buildcboPA();
            }
        }

        private void buildcboPA()
        {
            cboPA.DataSource = null;
            ClsBuildComboBox1.ARPA.Clear();
            ClsBuildComboBox1.ClsBuildPA(Convert.ToBoolean(cbAccountNo.CheckState));
            this.cboPA.DataSource = (ClsBuildComboBox1.ARPA);
            this.cboPA.DisplayMember = "Display";
            this.cboPA.ValueMember = "Value";
            this.cboPA.DropDownWidth = 450;
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

        private void View()
        {
            dgv1.DataSource = null;
            dgv1.Columns.Clear();
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            sql = "SELECT CONVERT(VARCHAR, TDate, 120) AS TDate, IC, Refer, Remarks, CONVERT(VARCHAR, Debit, 120)AS Debit, CONVERT(VARCHAR, Credit, 120)AS Credit FROM ViewSearchEntry WHERE PA='" + cboPA.SelectedValue.ToString() + "' AND TDate>'01/01/2023' ORDER BY TDate";

            da = new SqlDataAdapter(sql, myconnection);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
            da.SelectCommand.CommandTimeout = 600;
            dataTable = new DataTable();
            da.Fill(dataTable);
            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;

            //Adding  TDate TextBox
            DataGridViewTextBoxColumn ColumnTDate = new DataGridViewTextBoxColumn();
            ColumnTDate.HeaderText = "Date";
            ColumnTDate.Width = 80;
            ColumnTDate.DataPropertyName = "TDate";
            ColumnTDate.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnTDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnTDate.Visible = true;
            dgv1.Columns.Add(ColumnTDate);

            //Adding  IC TextBox
            DataGridViewTextBoxColumn ColumnIC = new DataGridViewTextBoxColumn();
            ColumnIC.HeaderText = "IC";
            ColumnIC.Width = 80;
            ColumnIC.DataPropertyName = "IC";
            ColumnIC.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnIC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv1.Columns.Add(ColumnIC);

            //Adding Refer TextBox
            DataGridViewTextBoxColumn ColumnRefer = new DataGridViewTextBoxColumn();
            ColumnRefer.HeaderText = "Refer";
            ColumnRefer.Width = 80;
            ColumnRefer.DataPropertyName = "Refer";
            ColumnRefer.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnRefer.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv1.Columns.Add(ColumnRefer);

            //Adding  Remarks TextBox
            DataGridViewTextBoxColumn ColumnRemarks = new DataGridViewTextBoxColumn();
            ColumnRemarks.HeaderText = "Remarks";
            ColumnRemarks.Width = 300;
            ColumnRemarks.DataPropertyName = "Remarks";
            ColumnRemarks.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnRemarks.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv1.Columns.Add(ColumnRemarks);

            //Adding  Debit TextBox
            DataGridViewTextBoxColumn ColumnDebit = new DataGridViewTextBoxColumn();
            ColumnDebit.HeaderText = "Debit";
            ColumnDebit.Width = 100;
            ColumnDebit.DataPropertyName = "Debit";
            ColumnDebit.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnDebit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv1.Columns.Add(ColumnDebit);

            //Adding  Credit TextBox
            DataGridViewTextBoxColumn ColumnCredit = new DataGridViewTextBoxColumn();
            ColumnCredit.HeaderText = "Credit";
            ColumnCredit.Width = 100;
            ColumnCredit.DataPropertyName = "Credit";
            ColumnCredit.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnCredit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv1.Columns.Add(ColumnCredit);

            //Setting Data Source for DataGridView
            dgv1.DataSource = bindingSource;
            //dgv1.AutoResizeColumns();
            //dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            myconnection.Close();
            //this.WindowState = FormWindowState.Maximized;
            dgv1.AllowUserToAddRows = false;
            dgv1.Columns[4].DefaultCellStyle.Format = "N2";
            dgv1.Columns[5].DefaultCellStyle.Format = "N2";
            dgv1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            View();
        }

        private void txtSearch_Validating(object sender, CancelEventArgs e)
        {
            DataView dv = dataTable.DefaultView;
            if (rbTDate.Checked)
            {
                dv.RowFilter = "TDate LIKE '%" +txtSearch.Text + "%'";
            }
            else if (rbIC.Checked)
            {
                dv.RowFilter = "IC LIKE '%" + txtSearch.Text + "%'";
            }
            else if (rbRefer.Checked)
            {
                dv.RowFilter = "Refer LIKE '%" + txtSearch.Text + "%'";
            }
            else if (rbDebit.Checked)
            {
                dv.RowFilter = "Debit LIKE '%" + txtSearch.Text + "%'";
            }
            else if (rbCredit.Checked)
            {
                dv.RowFilter = "Credit LIKE '%" + txtSearch.Text + "%'";
            }
            else if (rbRemarks.Checked)
            {
                dv.RowFilter = "Remarks LIKE '%" + txtSearch.Text + "%'";
            }
            dgv1.DataSource = dv;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //DataView dv = dataTable.DefaultView;
            //if (rbTDate.Checked)
            //{
            //    dv.RowFilter = "TDate LIKE '%" + Convert.ToDateTime(txtSearch.Text) + "%'";
            //}
            //else if (rbIC.Checked)
            //{
            //    dv.RowFilter = "IC LIKE '%" + txtSearch.Text + "%'";
            //}
            //else if (rbRefer.Checked)
            //{
            //    dv.RowFilter = "Refer LIKE '%" + txtSearch.Text + "%'";
            //}
            //else if (rbDebit.Checked)
            //{
            //    dv.RowFilter = "Debit LIKE '%" + txtSearch.Text + "%'";
            //}
            //else if (rbCredit.Checked)
            //{
            //    dv.RowFilter = "Credit LIKE '%" + txtSearch.Text + "%'";
            //}
            //else if (rbRemarks.Checked)
            //{
            //    dv.RowFilter = "Remarks LIKE '%" + txtSearch.Text + "%'";
            //}
            //dgv1.DataSource = dv;
        }

        private void cbAccountNo_CheckedChanged(object sender, EventArgs e)
        {
            buildcboPA();
        }
    }
}
