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
    public partial class frmCAViewMainAccount : Form
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

        public frmCAViewMainAccount()
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
                sql = "SELECT AcctNo, TitleAcct, FSClass, FCCode, SCCode, NormalBal, UsageCode ";
                sql += "FROM tblTitleAcct ORDER BY AcctNo";

                da = new SqlDataAdapter(sql, myconnection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
                da.SelectCommand.CommandTimeout = 600;

                dataTable = new DataTable();
                da.Fill(dataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;

                //Adding  AcctNo TextBox
                DataGridViewTextBoxColumn ColumnActNo = new DataGridViewTextBoxColumn();
                ColumnActNo.HeaderText = "Account No.";
                //ColumnActNo.Width = 80;
                ColumnActNo.DataPropertyName = "AcctNo";
                ColumnActNo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                ColumnActNo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                ColumnActNo.Visible = true;
                dgv1.Columns.Add(ColumnActNo);

                //Adding  TitleAcct TextBox
                DataGridViewTextBoxColumn ColumnTitleAcct = new DataGridViewTextBoxColumn();
                ColumnTitleAcct.HeaderText = "Account Title";
                //ColumnIB.Width = 80;
                ColumnTitleAcct.DataPropertyName = "TitleAcct";
                ColumnTitleAcct.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                ColumnTitleAcct.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                ColumnTitleAcct.ReadOnly = true;
                dgv1.Columns.Add(ColumnTitleAcct);

                //Adding  FSClass TextBox
                DataGridViewTextBoxColumn ColumnFSClass = new DataGridViewTextBoxColumn();
                ColumnFSClass.HeaderText = "Classification";
                //ColumnIB.Width = 80;
                ColumnFSClass.DataPropertyName = "FSClass";
                ColumnFSClass.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                ColumnFSClass.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv1.Columns.Add(ColumnFSClass);

                //Adding  FCCode TextBox
                DataGridViewTextBoxColumn ColumnFCCode = new DataGridViewTextBoxColumn();
                ColumnFCCode.HeaderText = "First Caption";
                //ColumnIB.Width = 80;
                ColumnFCCode.DataPropertyName = "FCCode";
                ColumnFCCode.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                ColumnFCCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv1.Columns.Add(ColumnFCCode);

                //Adding  SCCode TextBox
                DataGridViewTextBoxColumn ColumnSCCode = new DataGridViewTextBoxColumn();
                ColumnSCCode.HeaderText = "Second Caption";
                //ColumnIB.Width = 80;
                ColumnSCCode.DataPropertyName = "SCCode";
                ColumnSCCode.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                ColumnSCCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv1.Columns.Add(ColumnSCCode);

                //Adding  NormalBal TextBox
                DataGridViewTextBoxColumn ColumnNormalBal = new DataGridViewTextBoxColumn();
                ColumnNormalBal.HeaderText = "Normal Balance";
                //ColumnIB.Width = 80;
                ColumnNormalBal.DataPropertyName = "NormalBal";
                ColumnNormalBal.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                ColumnNormalBal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv1.Columns.Add(ColumnNormalBal);

                //Adding  UsageCode TextBox
                DataGridViewTextBoxColumn ColumnUsageCode = new DataGridViewTextBoxColumn();
                ColumnUsageCode.HeaderText = "Usage";
                //ColumnIB.Width = 80;
                ColumnUsageCode.DataPropertyName = "UsageCode";
                ColumnUsageCode.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                ColumnUsageCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv1.Columns.Add(ColumnUsageCode);

                //Setting Data Source for DataGridView
                dgv1.DataSource = bindingSource;
                dgv1.AutoResizeColumns();
                dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                myconnection.Close();
                this.WindowState = FormWindowState.Maximized;
                dgv1.AllowUserToAddRows = false;

            }



        }     
    }
}
