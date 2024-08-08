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
//using K5GLV3.FldrReports;

namespace K5GLONLINE
{
    public partial class frmRemittanceApply : Form
    {
        SqlConnection myconnection;
        private SqlDataAdapter da;
        private DataTable dataTable = null;
        private BindingSource bindingSource = null;
        SqlCommand mycommand;
        ClsBuildVoucherComboBox ClsBuildVoucherComboBox1 = new ClsBuildVoucherComboBox();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        public static ComboBox glblcboPC;

        public frmRemittanceApply()
        {
            InitializeComponent();
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

        private void frmRemittanceApply_Load(object sender, EventArgs e)
        {
            buildcboSalesman();
            glblcboPC = cboPC;
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
                ShowPcdatadgv2();
                refreshdgv2();
                //dgv2.Focus();
                //dgv2.Rows.OfType<DataGridViewRow>().Last().Selected = true;
                //dgv2.CurrentCell = dgv2.Rows.OfType<DataGridViewRow>().Last().Cells.OfType<DataGridViewCell>().First(); // if first wanted

            }

        }
        private void ShowPcdatadgv1()
        {
            dgv1.DataSource = null;
            dgv1.Columns.Clear();

            string sqlstatement;
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            sqlstatement = "SELECT RVRefer, MaxDate AS TDate, RemitAmt AS Balance  FROM ViewPersonnelRB WHERE PC='" + cboPC.SelectedValue.ToString() + "' ORDER BY TDate";
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
            dgv1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void ShowPcdatadgv2()
        {
            dgv2.DataSource = null;
            dgv2.Columns.Clear();

            string sqlstatement;
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            sqlstatement = "SELECT TDate As TDate1, Refer, ORAmt, Tapply, Num  FROM ViewPersonnelOR WHERE PC='" + cboPC.SelectedValue.ToString() + "' ORDER BY TDate";

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
            ColumnORAmt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnORAmt.ReadOnly = true;
            dgv2.Columns.Add(ColumnORAmt);

            //Adding  TApply checkbox
            DataGridViewCheckBoxColumn ColumnTApply = new DataGridViewCheckBoxColumn();
            ColumnTApply.HeaderText = "Apply";
            ColumnTApply.Width = 50;
            ColumnTApply.DataPropertyName = "TApply";
            ColumnTApply.FalseValue = 0;
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

            dgv2.Columns[0].Name = "Refer";
            dgv2.Columns[1].Name = "TDate1";
            dgv2.Columns[2].Name = "ORAmt";
            dgv2.Columns[3].Name = "TApply";
            dgv2.Columns[4].Name = "Num";

            //Setting Data Source for DataGridView
            dgv2.DataSource = bindingSource;
            //            dgv2.AutoResizeColumns();
            //            dgv2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            myconnection.Close();
            //            this.WindowState = FormWindowState.Maximized;
            //dgv2.AllowUserToAddRows = true;
            dgv2.Columns[0].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgv2.Columns[2].DefaultCellStyle.Format = "N2";
            dgv2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dgv3total()
        {
            double varORamt1 = 0;
            for (int i = 0; i < dgv3.Rows.Count; i++)
            {
                varORamt1 += Convert.ToDouble(dgv3.Rows[i].Cells[1].Value);
            }
            txtAppliedTotal.Text = varORamt1.ToString("N2");
            txtDiffer.Text = (double.Parse(txtRemitAmt.Text) - double.Parse(txtAppliedTotal.Text)).ToString("N2");
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
            for (int i = 0; i < dgv3.Rows.Count; i++)
            {
                row = dgv3.Rows[i];
                string psnum = dgv3.Rows[i].Cells[2].Value.ToString();
                string Reference = dgv3.Rows[i].Cells[0].Value.ToString();

                sqlstatement = "UPDATE tblMain3 set RVRefer=@_RVRefer  WHERE Num ='" + psnum + "' ";
                //Tapply UPdate Check 
                mycommand = new SqlCommand(sqlstatement, myconnection);
                mycommand.Parameters.Add("_RVRefer", SqlDbType.VarChar).Value = txtRVRefer.Text;
                mycommand.CommandTimeout = 600;
                int n1 = mycommand.ExecuteNonQuery();
            }
            myconnection.Close();
            dgv3.Rows.Clear();
            ShowPcdatadgv1();
            ShowPcdatadgv2();


        }

        private void dgv2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewRow row = dgv2.Rows[e.RowIndex];
            //if (e.ColumnIndex == dgv2.Columns["Tapply"].Index)
            //{
            //    dgv3.Rows.Add(dgv2.CurrentRow.Cells[1].Value, dgv2.CurrentRow.Cells[2].Value, dgv2.CurrentRow.Cells[4].Value);
            //}


        }


        private void dgv3_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            dgv3total();
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
            BindingSource bs = new BindingSource();
            bs.DataSource = dgv2.DataSource;
            bs.Filter = "TApply = 0";
            dgv2.DataSource = bs;
        }


        private void dgv2_Click(object sender, EventArgs e)
        {
            if (dgv2.Rows.Count == 0)
            {

            }
            else if (dgv2.CurrentRow.Cells[1].Value == null || dgv2.CurrentRow.Cells[2].Value == null || dgv2.CurrentRow.Cells[4].Value == null)
            {

            }
            else
            {
                dgv3.Rows.Add(dgv2.CurrentRow.Cells[1].Value, dgv2.CurrentRow.Cells[2].Value, dgv2.CurrentRow.Cells[4].Value);
                dgv3total();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (new ClsValidation().emptytxt(cboPC.Text))
            { }
            else if (cboPC.Text != null && cboPC.SelectedValue == null)
            {
                MessageBox.Show("Not found");
                cboPC.Focus();
            }
            else
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form EntryForm = Application.OpenForms["frmRemittanceApplyRev"];
            if (EntryForm != null)
            {
                Application.OpenForms["frmRemittanceApplyRev"].BringToFront();
            }
            else
            {
                new frmRemittanceApplyRev().Show();
            }
        }
    }
}
