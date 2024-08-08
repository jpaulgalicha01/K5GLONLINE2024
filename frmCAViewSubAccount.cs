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
    public partial class frmCAViewSubAccount : Form
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

        public frmCAViewSubAccount()
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
                sql = "SELECT PA, AcctNo, TitleAcct, D1Code, D1Desc, D2Code, D2Desc ";
                sql += "FROM ViewSubAccountTitle ORDER BY PA";

                da = new SqlDataAdapter(sql, myconnection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
                da.SelectCommand.CommandTimeout = 600;
                dataTable = new DataTable();
                da.Fill(dataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;

                //Adding  PA TextBox
                DataGridViewTextBoxColumn ColumnPA = new DataGridViewTextBoxColumn();
                ColumnPA.HeaderText = "Posting No.";
                //ColumnPA.Width = 80;
                ColumnPA.DataPropertyName = "PA";
                ColumnPA.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                ColumnPA.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                ColumnPA.Visible = true;
                dgv1.Columns.Add(ColumnPA);

                //Adding  AcctNo TextBox
                DataGridViewTextBoxColumn ColumnAcctNo = new DataGridViewTextBoxColumn();
                ColumnAcctNo.HeaderText = "Account No.";
                //ColumnIB.Width = 80;
                ColumnAcctNo.DataPropertyName = "AcctNo";
                ColumnAcctNo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                ColumnAcctNo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                ColumnAcctNo.ReadOnly = true;
                dgv1.Columns.Add(ColumnAcctNo);

                //Adding  TitleAcct TextBox
                DataGridViewTextBoxColumn ColumnTitleAcct = new DataGridViewTextBoxColumn();
                ColumnTitleAcct.HeaderText = "Account Title";
                //ColumnIB.Width = 80;
                ColumnTitleAcct.DataPropertyName = "TitleAcct";
                ColumnTitleAcct.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                ColumnTitleAcct.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv1.Columns.Add(ColumnTitleAcct);

                //Adding  D1Code TextBox
                DataGridViewTextBoxColumn ColumnD1Code = new DataGridViewTextBoxColumn();
                ColumnD1Code.HeaderText = "Dept1 Code";
                //ColumnIB.Width = 80;
                ColumnD1Code.DataPropertyName = "D1Code";
                ColumnD1Code.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                ColumnD1Code.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv1.Columns.Add(ColumnD1Code);

                //Adding  D1Desc TextBox
                DataGridViewTextBoxColumn ColumnD1Desc = new DataGridViewTextBoxColumn();
                ColumnD1Desc.HeaderText = "Dept1 Desc";
                //ColumnIB.Width = 80;
                ColumnD1Desc.DataPropertyName = "D1Desc";
                ColumnD1Desc.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                ColumnD1Desc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv1.Columns.Add(ColumnD1Desc);

                //Adding  D2Code TextBox
                DataGridViewTextBoxColumn ColumnD2Code = new DataGridViewTextBoxColumn();
                ColumnD2Code.HeaderText = "Dept2 Code";
                //ColumnIB.Width = 80;
                ColumnD2Code.DataPropertyName = "D2Code";
                ColumnD2Code.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                ColumnD2Code.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv1.Columns.Add(ColumnD2Code);

                //Adding  D2Desc TextBox
                DataGridViewTextBoxColumn ColumnD2Desc = new DataGridViewTextBoxColumn();
                ColumnD2Desc.HeaderText = "Dept2 Desc";
                //ColumnIB.Width = 80;
                ColumnD2Desc.DataPropertyName = "D2Desc";
                ColumnD2Desc.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                ColumnD2Desc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv1.Columns.Add(ColumnD2Desc);

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
