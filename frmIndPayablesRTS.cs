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
    public partial class frmIndPayablesRTS : Form
    {
        private SqlDataAdapter da;
        private DataTable dataTable = null;
        private SqlConnection myconnection;
        private BindingSource bindingSource = null;
        BindingSource bsource = new BindingSource();
        //   DataSet ds = null;
        string sql;
        private string pristrRefer;
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        public frmIndPayablesRTS()
        {
            InitializeComponent();
        }

        private void ListReceive()
        {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                sql = "SELECT MinTDate, Refer, Balance FROM ViewBalanceActRTS WHERE ControlNo='" + frmVoucherTRS.glblcboControlNo.SelectedValue.ToString() + "' AND PA='" + frmVoucherTRS.glblcboAcctNo.SelectedValue.ToString() + "' AND Balance > 0";

                da = new SqlDataAdapter(sql, myconnection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
                dataTable = new DataTable();
                da.Fill(dataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;

                

                //Adding  TDate TextBox
                DataGridViewTextBoxColumn ColumnTDate = new DataGridViewTextBoxColumn();
                ColumnTDate.HeaderText = "Date";
                ColumnTDate.Width = 100;
                ColumnTDate.DataPropertyName = "MinTDate";
                ColumnTDate.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                ColumnTDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv1.Columns.Add(ColumnTDate);

                //Adding  Refer TextBox
                DataGridViewTextBoxColumn ColumnRefer = new DataGridViewTextBoxColumn();
                ColumnRefer.HeaderText = "Reference";
                ColumnRefer.Width = 100;
                ColumnRefer.DataPropertyName = "Refer";
                ColumnRefer.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                ColumnRefer.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv1.Columns.Add(ColumnRefer);

                 //Adding  Bal TextBox
                DataGridViewTextBoxColumn ColumnBal = new DataGridViewTextBoxColumn();
                ColumnBal.HeaderText = "Balance";
                ColumnBal.Width = 100;
                ColumnBal.DataPropertyName = "Balance";
                ColumnBal.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                ColumnBal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv1.Columns.Add(ColumnBal);

                //Setting Data Source for DataGridView
                dgv1.DataSource = bindingSource;
                //dgv1.AutoResizeColumns();
               // dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                myconnection.Close();
                //this.WindowState = FormWindowState.Maximized;
                dgv1.AllowUserToAddRows = false;
                dgv1.Columns[0].DefaultCellStyle.Format = "MM/dd/yyyy";
                dgv1.Columns[2].DefaultCellStyle.Format = "N2";
            }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEntryReceivableBalance_Load(object sender, EventArgs e)
        {
            ListReceive();
        }

        private void dgv1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgv1.Rows[e.RowIndex];
            pristrRefer = row.Cells[1].FormattedValue.ToString();
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            EnterDoc();
        }

        private void frmEntryReceivableBalance_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                EnterDoc();
            }
        }
        private void EnterDoc()
        {
            frmVoucherTRS.glbltxtDeductDoc.Text = pristrRefer;
            this.Close();
        }
    }
}
