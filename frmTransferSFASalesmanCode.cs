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
    public partial class frmTransferSFASalesmanCode : Form
    {
        private SqlDataAdapter da;
        private DataTable dataTable = null;
        private SqlConnection myconnection;
        private BindingSource bindingSource = null;
        BindingSource bsource = new BindingSource();
        string sql;
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        public frmTransferSFASalesmanCode()
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
            sql = "SELECT PC, PersonnelName, SFADSP, SFACode FROM tblPersonnel WHERE Active=1 ORDER BY PersonnelName";

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

            DataGridViewTextBoxColumn ColumnPC = new DataGridViewTextBoxColumn();
            ColumnPC.HeaderText = "Code";
            ColumnPC.Width = 80;
            ColumnPC.DataPropertyName = "PC";
            ColumnPC.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnPC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnPC.ReadOnly = true;
            ColumnPC.Visible = false;
            dgv1.Columns.Add(ColumnPC);

            //Adding  PersonnelName TextBox
            DataGridViewTextBoxColumn ColumnPersonnelName = new DataGridViewTextBoxColumn();
            ColumnPersonnelName.HeaderText = "Name";
            ColumnPersonnelName.Width = 120;
            ColumnPersonnelName.DataPropertyName = "PersonnelName";
            ColumnPersonnelName.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnPersonnelName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnPersonnelName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnPersonnelName.ReadOnly = true;
            dgv1.Columns.Add(ColumnPersonnelName);

            //Adding  SFADSP TextBox
            DataGridViewTextBoxColumn ColumnSFADSP = new DataGridViewTextBoxColumn();
            ColumnSFADSP.HeaderText = "SFADSP";
            ColumnSFADSP.Width = 150;
            ColumnSFADSP.DataPropertyName = "SFADSP";
            ColumnSFADSP.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnSFADSP.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //ColumnSFADSP.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv1.Columns.Add(ColumnSFADSP);

            //Adding  SFACode TextBox
            DataGridViewTextBoxColumn ColumnSFACode = new DataGridViewTextBoxColumn();
            ColumnSFACode.HeaderText = "SFACode";
            ColumnSFACode.Width = 150;
            ColumnSFACode.DataPropertyName = "SFACode";
            ColumnSFACode.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnSFACode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //ColumnSFACode.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv1.Columns.Add(ColumnSFACode);

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
