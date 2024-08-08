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
    public partial class frmWarehouseEdit : Form
    {
        private SqlDataAdapter da;
        private DataTable dataTable = null;
        private SqlConnection myconnection;
        private BindingSource bindingSource = null;
        BindingSource bsource = new BindingSource();
        string sql;
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection(); 

        public frmWarehouseEdit()
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
                sql = "SELECT WHCode,  Warehouse, UMControl, Active FROM tblWarehouse  ORDER BY WHCode";

                da = new SqlDataAdapter(sql, myconnection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
                da.SelectCommand.CommandTimeout = 600;
                dataTable = new DataTable();
                da.Fill(dataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;

                //Adding  WHCode TextBox
                DataGridViewTextBoxColumn ColumnWHCode = new DataGridViewTextBoxColumn();
                ColumnWHCode.HeaderText = "Code";
                ColumnWHCode.Width = 100;
                ColumnWHCode.DataPropertyName = "WHCode";
                ColumnWHCode.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ColumnWHCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ColumnWHCode.Visible = true;
                ColumnWHCode.ReadOnly = true;
                dgv1.Columns.Add(ColumnWHCode);

                //Adding  Warehouse TextBox
                DataGridViewTextBoxColumn ColumnWarehouse = new DataGridViewTextBoxColumn();
                ColumnWarehouse.HeaderText = "Name";
                ColumnWarehouse.Width = 300;
                ColumnWarehouse.DataPropertyName = "Warehouse";
                ColumnWarehouse.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ColumnWarehouse.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                ColumnWarehouse.ReadOnly = true;
                dgv1.Columns.Add(ColumnWarehouse);

                //Adding  UMControl checkbox
                DataGridViewCheckBoxColumn ColumnUMControl = new DataGridViewCheckBoxColumn();
                ColumnUMControl.HeaderText = "UM Control";
                ColumnUMControl.Width = 100;
                ColumnUMControl.DataPropertyName = "UMControl";
                ColumnUMControl.FalseValue = 0;
                ColumnUMControl.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ColumnUMControl.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv1.Columns.Add(ColumnUMControl);

                //Adding  UMControl checkbox
                DataGridViewCheckBoxColumn ColumnActive = new DataGridViewCheckBoxColumn();
                ColumnActive.HeaderText = "Active";
                ColumnActive.Width = 100;
                ColumnActive.DataPropertyName = "Active";
                ColumnActive.FalseValue = 0;
                ColumnActive.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ColumnActive.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv1.Columns.Add(ColumnActive);
                
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
