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
    public partial class frmCheckSearch : Form
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
        public frmCheckSearch()
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
            sql = "SELECT Check#, CAmount, TDate, CustName, DocNum, D2Desc, Remarks FROM ViewCheckWriter ORDER  BY TDate";

            da = new SqlDataAdapter(sql, myconnection);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);


            dataTable = new DataTable();
            da.Fill(dataTable);
            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;

            DataGridViewTextBoxColumn ColumnCheckNo = new DataGridViewTextBoxColumn();
            ColumnCheckNo.HeaderText = "Check #";
            ColumnCheckNo.Width = 150;
            ColumnCheckNo.DataPropertyName = "Check#";
            ColumnCheckNo.ReadOnly = true;
            ColumnCheckNo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnCheckNo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv1.Columns.Add(ColumnCheckNo);

            // TYear
            DataGridViewTextBoxColumn ColumnCAmount = new DataGridViewTextBoxColumn();
            ColumnCAmount.HeaderText = "Amount";
            ColumnCAmount.Width = 150;
            ColumnCAmount.DataPropertyName = "CAmount";
            ColumnCAmount.ReadOnly = true;
            ColumnCAmount.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnCAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv1.Columns.Add(ColumnCAmount);

            DataGridViewTextBoxColumn ColumnTDate = new DataGridViewTextBoxColumn();
            ColumnTDate.HeaderText = "Date";
            ColumnTDate.Width = 80;
            ColumnTDate.DataPropertyName = "TDate";
            ColumnTDate.ReadOnly = true;
            ColumnTDate.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnTDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv1.Columns.Add(ColumnTDate);

            DataGridViewTextBoxColumn ColumnCustName = new DataGridViewTextBoxColumn();
            ColumnCustName.HeaderText = "Payee";
            ColumnCustName.Width = 100;
            ColumnCustName.DataPropertyName = "CustName";
            ColumnCustName.ReadOnly = true;
            ColumnCustName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnCustName.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnCustName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv1.Columns.Add(ColumnCustName);

            DataGridViewTextBoxColumn ColumnDocNum = new DataGridViewTextBoxColumn();
            ColumnDocNum.HeaderText = "CV No.";
            ColumnDocNum.Width = 100;
            ColumnDocNum.DataPropertyName = "DocNum";
            ColumnDocNum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnDocNum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv1.Columns.Add(ColumnDocNum);

            DataGridViewTextBoxColumn ColumnD2Desc = new DataGridViewTextBoxColumn();
            ColumnD2Desc.HeaderText = "Bank";
            ColumnD2Desc.Width = 150;
            ColumnD2Desc.DataPropertyName = "D2Desc";
            ColumnD2Desc.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnD2Desc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv1.Columns.Add(ColumnD2Desc);

            DataGridViewTextBoxColumn ColumnRemarks = new DataGridViewTextBoxColumn();
            ColumnRemarks.HeaderText = "Remarks";
            ColumnRemarks.Width = 350;
            ColumnRemarks.DataPropertyName = "Remarks";
            ColumnRemarks.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnRemarks.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv1.Columns.Add(ColumnRemarks);

            //DataGridViewTextBoxColumn ColumnSFAProductCode = new DataGridViewTextBoxColumn();
            //ColumnSFAProductCode.HeaderText = "SFA Product Code";
            //ColumnSFAProductCode.Width = 100;
            //ColumnSFAProductCode.DataPropertyName = "SFAProductCode";
            //ColumnSFAProductCode.ReadOnly = false;
            //ColumnSFAProductCode.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //ColumnSFAProductCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgv1.Columns.Add(ColumnSFAProductCode);

            //DataGridViewCheckBoxColumn ColumnFreeGoods = new DataGridViewCheckBoxColumn();
            //ColumnFreeGoods.HeaderText = "Free Goods";
            //ColumnFreeGoods.Width = 80;
            //ColumnFreeGoods.DataPropertyName = "FreeGoods";
            //ColumnFreeGoods.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //ColumnFreeGoods.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgv1.Columns.Add(ColumnFreeGoods);
            
            //DataGridViewCheckBoxColumn ColumnSpecialSKU = new DataGridViewCheckBoxColumn();
            //ColumnSpecialSKU.HeaderText = "Special SKU";
            //ColumnSpecialSKU.Width = 80;
            //ColumnSpecialSKU.DataPropertyName = "SpecialSKU";
            //ColumnSpecialSKU.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //ColumnSpecialSKU.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgv1.Columns.Add(ColumnSpecialSKU);

            //DataGridViewTextBoxColumn ColumnPackageKilo = new DataGridViewTextBoxColumn();
            //ColumnPackageKilo.HeaderText = "Package Kilo";
            //ColumnPackageKilo.Width = 100;
            //ColumnPackageKilo.DataPropertyName = "PackageKilo";
            //ColumnPackageKilo.ReadOnly = false;
            //ColumnPackageKilo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //ColumnPackageKilo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgv1.Columns.Add(ColumnPackageKilo);

            //DataGridViewTextBoxColumn ColumnBUMCS = new DataGridViewTextBoxColumn();
            //ColumnBUMCS.HeaderText = "BR UMCS";
            //ColumnBUMCS.Width = 50;
            //ColumnBUMCS.DataPropertyName = "BUMCS";
            //ColumnBUMCS.ReadOnly = false;
            //ColumnBUMCS.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //ColumnBUMCS.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgv1.Columns.Add(ColumnBUMCS);

            //DataGridViewTextBoxColumn ColumnBUMIB = new DataGridViewTextBoxColumn();
            //ColumnBUMIB.HeaderText = "BR UMIB";
            //ColumnBUMIB.Width = 50;
            //ColumnBUMIB.DataPropertyName = "BUMIB";
            //ColumnBUMIB.ReadOnly = false;
            //ColumnBUMIB.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //ColumnBUMIB.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgv1.Columns.Add(ColumnBUMIB);

            //DataGridViewTextBoxColumn ColumnBUMPC = new DataGridViewTextBoxColumn();
            //ColumnBUMPC.HeaderText = "BR UMPC";
            //ColumnBUMPC.Width = 50;
            //ColumnBUMPC.DataPropertyName = "BUMPC";
            //ColumnBUMPC.ReadOnly = false;
            //ColumnBUMPC.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //ColumnBUMPC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgv1.Columns.Add(ColumnBUMPC);

            //Setting Data Source for DataGridView
            //dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv1.DataSource = bindingSource;
            dgv1.Columns[1].DefaultCellStyle.Format = "N2";
            //dgv1.Columns[3].DefaultCellStyle.Format = "N4";
            //dgv1.Columns[10].DefaultCellStyle.Format = "N2";
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

            dv.RowFilter = "CustName LIKE '" + txtSearch.Text + "%' OR Remarks LIKE '" + txtSearch.Text + "%'";
            dgv1.DataSource = dv;
        }
    }
}
