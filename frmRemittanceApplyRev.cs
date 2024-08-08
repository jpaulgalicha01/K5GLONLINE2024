using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using k5GLONLINE;
//using K5GLV3.FldrClass;
//using System.Net.Http;

namespace K5GLONLINE
{
    public partial class frmRemittanceApplyRev : Form
    {
        SqlConnection myconnection;
        private SqlDataAdapter da;
        private DataTable dataTable = null;
        private BindingSource bindingSource = null;
        SqlCommand mycommand;
        ClsBuildVoucherComboBox ClsBuildVoucherComboBox1 = new ClsBuildVoucherComboBox();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        public static ComboBox glblcboPC;

        public frmRemittanceApplyRev()
        {
            InitializeComponent();
        }

        private void frmRemittanceApplyRev_Load(object sender, EventArgs e)
        {
            //CreateDTTempTable1();
            //var varList = await ClsGetList1.GetSalesman1();
            //foreach (var listLoop in varList)
            //{
            //    DTTempTable.Rows.Add(listLoop.SMCode, listLoop.SMDesc);
            //}
            //CreateDTTempTable();
            //ClsBuildComboBox1.ClsBuildSalesmanList(cboPC);
            //buildcboSalesman();
            buildcboSalesman();
        }

        private void cboPC_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().emptytxt(cboPC.Text))
            {
            }
            else if (cboPC.Text != null && cboPC.SelectedValue == null)
            {
                MessageBox.Show("Not found", "GL");
                cboPC.Focus();
            }
            else
            {
                ShowPcdatadgv1();
                refreshdgv2();
            }

        }
      
        private void buildcboSalesman()
        {
            cboPC.DataSource = null;
            ClsBuildVoucherComboBox1.ARLSLS.Clear();
            ClsBuildVoucherComboBox1.ClsBuildSalesman();
            this.cboPC.DataSource = (ClsBuildVoucherComboBox1.ARLSLS);
            this.cboPC.DisplayMember = "Display";
            this.cboPC.ValueMember = "Value";
        }
        private void ShowPcdatadgv1()
        {
            dgv1.DataSource = null;
            dgv1.Columns.Clear();

            string sqlstatement;
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            //ViewPersonnelRBRev
            //string sql = "SELECT RVRefer, MAX(MaxDate) AS TDate, SUM(RemitAmt) AS Balance, ASMCode FROM ViewPersonnelRBRev WHERE ASMCode='" + strURISMCode + "' GROUP BY RVRefer, MaxDate, ASMCode, RVrefer HAVING (SUM(RemitAmt)<>0) ORDER BY TDate, RVRefer Desc";

            //sqlstatement = "SELECT RVRefer, MaxDate AS TDate, RemitAmt AS Balance  FROM ViewPersonnelRB WHERE PC='" + cboPC.SelectedValue.ToString() + "' ORDER BY TDate";
            sqlstatement = "SELECT RVRefer, MAX(MaxDate) AS TDate, SUM(RemitAmt) AS Balance FROM ViewPersonnelRBRev WHERE PC='" + cboPC.SelectedValue.ToString() + "' GROUP BY RVRefer HAVING (SUM(RemitAmt)<>0) ORDER BY TDate, RVRefer Desc";
            da = new SqlDataAdapter(sqlstatement, myconnection);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
            da.SelectCommand.CommandTimeout = 600;
            dataTable = new DataTable();
            da.Fill(dataTable);
            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;

            //Adding  RVRefer TextBox
            DataGridViewTextBoxColumn ColumnRVRefer = new DataGridViewTextBoxColumn();
            ColumnRVRefer.HeaderText = "Remittance #";
            ColumnRVRefer.Width = 100;
            ColumnRVRefer.DataPropertyName = "RVRefer";
            ColumnRVRefer.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnRVRefer.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnRVRefer.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //ColumnRVRefer.Visible = false;
            ColumnRVRefer.ReadOnly = true;
            dgv1.Columns.Add(ColumnRVRefer);

            //Adding  TDate TextBox
            DataGridViewTextBoxColumn ColumnTDate = new DataGridViewTextBoxColumn();
            ColumnTDate.HeaderText = "Date";
            ColumnTDate.Width = 75;
            ColumnTDate.DataPropertyName = "TDate";
            ColumnTDate.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnTDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //ColumnTDate.Visible = false;
            ColumnTDate.ReadOnly = true;
            dgv1.Columns.Add(ColumnTDate);

            //Adding  Balance TextBox
            DataGridViewTextBoxColumn ColumnBalance = new DataGridViewTextBoxColumn();
            ColumnBalance.HeaderText = "Balance";
            ColumnBalance.Width = 80;
            ColumnBalance.DataPropertyName = "Balance";
            ColumnBalance.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnBalance.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnBalance.ReadOnly = true;
            dgv1.Columns.Add(ColumnBalance);

            dgv1.Columns[0].Name = "RVRefer";
            dgv1.Columns[1].Name = "TDate";
            dgv1.Columns[2].Name = "Balance";
            //Setting Data Source for DataGridView
            dgv1.DataSource = bindingSource;
            //            dgv1.AutoResizeColumns();
            //            dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            myconnection.Close();
            //            this.WindowState = FormWindowState.Maximized;
            //dgv1.AllowUserToAddRows = true;
            dgv1.Columns[2].DefaultCellStyle.Format = "N2";
            dgv1.Columns[1].DefaultCellStyle.Format = "MM/dd/yyyy";
        }

        private void ShowPcdatadgv2(string RVRefer)
        {
            dgv2.DataSource = null;
            dgv2.Columns.Clear();

            string sqlstatement;
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            sqlstatement = "SELECT TDate As TDate1, Refer, ORAmt, Tapply, Num, IC, RVrefer FROM ViewPersonnelORRev WHERE PC='" + cboPC.SelectedValue.ToString() + "' AND RVRefer='" + RVRefer + "' ORDER BY TDate";
            //TDate As TDate1, Refer, ORAmt, Tapply, RowNum, IC, RVrefer

            da = new SqlDataAdapter(sqlstatement, myconnection);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
            da.SelectCommand.CommandTimeout = 600;
            dataTable = new DataTable();
            da.Fill(dataTable);
            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;

            //Adding  TDate1 TextBox
            DataGridViewTextBoxColumn ColumnTDate1 = new DataGridViewTextBoxColumn();
            ColumnTDate1.HeaderText = "Date";
            ColumnTDate1.Width = 75;
            ColumnTDate1.DataPropertyName = "TDate1";
            ColumnTDate1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnTDate1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //ColumnTDate1.Visible = false;
            ColumnTDate1.ReadOnly = true;
            dgv2.Columns.Add(ColumnTDate1);

            //Adding  Refer TextBox
            DataGridViewTextBoxColumn ColumnRefer = new DataGridViewTextBoxColumn();
            ColumnRefer.HeaderText = "Reference";
            ColumnRefer.Width = 130;
            ColumnRefer.DataPropertyName = "Refer";
            ColumnRefer.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnRefer.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnRefer.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //ColumnRefer.Visible = false;
            ColumnRefer.ReadOnly = true;
            dgv2.Columns.Add(ColumnRefer);


            //Adding  ORAmt TextBox
            DataGridViewTextBoxColumn ColumnORAmt = new DataGridViewTextBoxColumn();
            ColumnORAmt.HeaderText = "Amount";
            ColumnORAmt.Width = 80;
            ColumnORAmt.DataPropertyName = "ORAmt";
            ColumnORAmt.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnORAmt.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnORAmt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnORAmt.ReadOnly = true;
            dgv2.Columns.Add(ColumnORAmt);

            //Adding  TApply checkbox
            DataGridViewCheckBoxColumn ColumnTApply = new DataGridViewCheckBoxColumn();
            ColumnTApply.HeaderText = "Apply";
            ColumnTApply.Width = 50;
            ColumnTApply.DataPropertyName = "TApply";
            //ColumnTApply.FalseValue = 0;
            ColumnTApply.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnTApply.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv2.Columns.Add(ColumnTApply);

            //Adding  Num TextBox
            DataGridViewTextBoxColumn ColumnNum = new DataGridViewTextBoxColumn();
            ColumnNum.HeaderText = "Num";
            ColumnNum.Width = 25;
            ColumnNum.DataPropertyName = "Num";
            ColumnNum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnNum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnNum.ReadOnly = true;
            ColumnNum.Visible = false;
            dgv2.Columns.Add(ColumnNum);


            //---------------

            DataGridViewTextBoxColumn ColumnIC = new DataGridViewTextBoxColumn();
            ColumnIC.HeaderText = "IC";
            ColumnIC.Width = 80;
            ColumnIC.DataPropertyName = "IC";
            ColumnIC.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnIC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //ColumnIC.ReadOnly = true;
            ColumnIC.Visible = false;
            dgv2.Columns.Add(ColumnIC);


            DataGridViewTextBoxColumn ColumnRVrefer = new DataGridViewTextBoxColumn();
            ColumnRVrefer.HeaderText = "RVrefer";
            ColumnRVrefer.Width = 100;
            ColumnRVrefer.DataPropertyName = "RVrefer";
            ColumnRVrefer.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnRVrefer.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //ColumnIC.ReadOnly = true;
            ColumnRVrefer.Visible = false;
            dgv2.Columns.Add(ColumnRVrefer);
           

            dgv2.Columns[0].Name = "TDate1";
            dgv2.Columns[1].Name = "Refer";
            dgv2.Columns[2].Name = "ORAmt";
            dgv2.Columns[3].Name = "TApply";
            dgv2.Columns[4].Name = "Num";
            dgv2.Columns[5].Name = "IC";
            dgv2.Columns[6].Name = "RVrefer";

            //Setting Data Source for DataGridView
            dgv2.DataSource = bindingSource;
            //            dgv2.AutoResizeColumns();
            //            dgv2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            myconnection.Close();
            //            this.WindowState = FormWindowState.Maximized;
            //dgv2.AllowUserToAddRows = true;
            dgv2.Columns[0].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgv2.Columns[2].DefaultCellStyle.Format = "N2";
        }

        private void dgv3total()
        {
            double varORamt1 = 0;
            for (int i = 0; i < dgv2.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgv2.Rows[i].Cells[3].Value) == false)
                {
                    varORamt1 += Convert.ToDouble(dgv2.Rows[i].Cells[2].Value);
                }
            }
            txtAppliedTotal.Text = varORamt1.ToString("N2");
            txtDiffer.Text = varORamt1.ToString("n2");
        }

        private void nextfieldenter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            string sqlstatement;

            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();

            DataGridViewRow row = null;
            for (int i = 0; i < dgv2.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgv2.Rows[i].Cells[3].Value.ToString()) == true)
                {
                    sqlstatement = "UPDATE tblMain3 set RVRefer=@_RVRefer WHERE Num = '" + dgv2.Rows[i].Cells[4].Value.ToString() + "' AND Refer='" + dgv2.Rows[i].Cells[1].Value.ToString() + "' ";
                    mycommand = new SqlCommand(sqlstatement, myconnection);
                    mycommand.CommandTimeout = 600;
                    mycommand.Parameters.Add("_RVRefer", SqlDbType.VarChar).Value = "NA";

                    int n1 = mycommand.ExecuteNonQuery();
                }
            }
            myconnection.Close();
            dgv2.Columns.Clear();
            ShowPcdatadgv1();
        }

        private void dgv1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtRVRefer.Text = dgv1.CurrentRow.Cells[0].Value.ToString();
            double varremitamt = Convert.ToDouble(dgv1.CurrentRow.Cells[2].Value);
            txtRemitAmt.Text = varremitamt.ToString("N2");
            dgv3total();
        }

        private void refreshdgv2()
        {

            //BindingSource bs = new BindingSource();
            //bs.DataSource = dgv2.DataSource;
            //bs.Filter = "TApply = 1";
            //dgv2.DataSource = bs;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form EntryForm = Application.OpenForms["frmrptRemittanceRpt"];
            if (EntryForm != null)
            {
                Application.OpenForms["frmrptRemittanceRpt"].BringToFront();
            }
            else
            {
                new frmrptRemittanceRpt(cboPC.SelectedValue.ToString()).Show();
            }
        }

        private void dgv2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgv2.Rows[e.RowIndex];
            if (e.ColumnIndex == dgv2.Columns["Tapply"].Index)
            {
                if (Convert.ToBoolean(this.dgv2.Rows[e.RowIndex].Cells[3].Value.ToString()) == true)
                {
                    string RVRefer = this.dgv2.Rows[e.RowIndex].Cells[6].Value.ToString();
                    if (RVRefer == txtRVRefer.Text)
                    {

                    }
                    else
                    {
                        ShowPcdatadgv1();
                    }
                    //dgv3total();
                }
            }

        }

        private void dgv1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewRow row = dgv2.Rows[e.RowIndex];
            //MessageBox.Show(this.dgv1.Rows[e.RowIndex].Cells[0].Value.ToString());
            //ShowPcdatadgv2(this.dgv1.Rows[e.RowIndex].Cells[0].Value.ToString());
        }
        private void dgv1_DoubleClick(object sender, EventArgs e)
        {
           
            ShowPcdatadgv2(dgv1.CurrentRow.Cells[0].Value.ToString());
            //RevRmt
        }
    }
}
