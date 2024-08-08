using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace K5GLONLINE
{
    public partial class frmrptSalesmanCustom : Form
    {
        SqlConnection myconnection;
        private SqlDataAdapter da;
        private DataTable dataTable = null;
        private BindingSource bindingSource = null;
        BindingSource dbind = new BindingSource();
        ClsCompName ClsCompName1 = new ClsCompName();
        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();
        ClsBuildEntryComboBox ClsBuildEntryComboBox1 = new ClsBuildEntryComboBox();
        ClsGetSomething ClsGetSomething1 = new ClsGetSomething();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsBuildVoucherComboBox ClsBuildVoucherComboBox1 = new ClsBuildVoucherComboBox();
        SqlDataReader SqlDataReader1;
        SqlCommand mycommand;
        string sqlstatement;
        Array principal;

        public frmrptSalesmanCustom()
        {
            InitializeComponent();
            cbortprint.DisplayMember = "Text";
            cbortprint.ValueMember = "Value";
            cbortprint.SelectedValue = "01";

            var items = new[]
            {
             new { Text = "All Principal", Value = "01" },
             new { Text = "Selected Principal", Value = "02" },
            };
            cbortprint.DataSource = items;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBeginDate_Leave(object sender, EventArgs e)
        {
            if (new ClsValidation().errordate(txtBeginDate.Text) == true)
            {
                MessageBox.Show("Invalid Date", "GL");
                txtBeginDate.Focus();
            }
        }

        private void txtEndDate_Leave(object sender, EventArgs e)
        {
            if (new ClsValidation().errordate(txtEndDate.Text) == true)
            {
                MessageBox.Show("Invalid Date", "GL");
                txtEndDate.Focus();
            }
        }

        private void AllPrincipal()
        {
            if (cbortprint.SelectedValue.ToString() == "01")
            {
                sqlstatement = "SELECT Item, ClassDesc, CustName, SUM(SalesAmount) AS SalesAmount, SUM(ReturnsAmount) AS ReturnsAmount FROM ViewSalesCustom WHERE TDate BETWEEN '" + txtBeginDate.Text + "' AND '" + txtEndDate.Text + "' AND PC = '" + cboSalesman.SelectedValue.ToString() + "' AND WHCode = '"+ cboWHCode.SelectedValue.ToString() + "' GROUP BY Item, ClassDesc, CustName ORDER BY ClassDesc";
            }
            else
            {
                sqlstatement = "SELECT Item, ClassDesc, CustName, SUM(SalesAmount) AS SalesAmount, SUM(ReturnsAmount) AS ReturnsAmount FROM ViewSalesCustom WHERE TDate BETWEEN '" + txtBeginDate.Text + "' AND '" + txtEndDate.Text + "' AND PC = '" + cboSalesman.SelectedValue.ToString() + "' AND ShowSalesmanCustom=1 AND WHCode = '" + cboWHCode.SelectedValue.ToString() + "' GROUP BY Item, ClassDesc, CustName ORDER BY ClassDesc";
            }
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = myconnection.CreateCommand();
            mycommand.CommandText = sqlstatement;
            mycommand.CommandTimeout = 900;
            SqlDataReader1 = mycommand.ExecuteReader();
            DataTable DataTable1 = new DataTable();
            DataTable1.Load(SqlDataReader1);
            myconnection.Close();

            if (DataTable1.Rows.Count == 0)
            {
                MessageBox.Show("No Data Found!", "Warning");
                return;
            }

            CRSalesmanCustom objRpt = new CRSalesmanCustom();
            //TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            //ClsCompName1.ClsCompNameMain();
            //vartxtcompany.Text = ClsCompName1.varcn;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["txtSalesman"];
            vartxtaddress.Text = cboSalesman.Text;

            TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["txtTDate"];
            varrpttoenterdate.Text = "From: " + txtBeginDate.Text + " To: " + txtEndDate.Text;

            objRpt.SetDataSource(DataTable1);

            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }

        private void frmrptSalesmanCustom_Load(object sender, EventArgs e)
        {
            ClsPermission1.ClsObjects(this.Text);
            if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
            {
                MessageBox.Show("You do not have necessary permission to open this file", "GL");
                this.Close();
            }
            else
            {
                ClsGetSomething1.ClsGetDefaultDate();
                txtBeginDate.Text = ClsGetSomething1.plsdefdate;
                txtEndDate.Text = ClsGetSomething1.plsdefdate;
                this.WindowState = FormWindowState.Maximized;
                buildcboSalesman();
                buildcboWHcode();
                txtEndDate.Text = ClsGetSomething1.plsdefdate;
                cboWHCode.SelectedValue = "000";
                cbortprint.SelectedValue = "01";
            }
        }

        private void txtBeginDate_Leave_1(object sender, EventArgs e)
        {
            if (new ClsValidation().errordate(txtBeginDate.Text) == true)
            {
                MessageBox.Show("Invalid Date", "GL");
                txtBeginDate.Focus();
            }
        }
        private void txtEndDate_Leave_1(object sender, EventArgs e)
        {
            if (new ClsValidation().errordate(txtEndDate.Text) == true)
            {
                MessageBox.Show("Invalid Date", "GL");
                txtEndDate.Focus();
            }
        }
        private void nextfieldenter2(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }

        }
        private void buildcboWHcode()
        {
            cboWHCode.DataSource = null;
            ClsBuildEntryComboBox1.ARWHCode.Clear();
            ClsBuildEntryComboBox1.ClsBuildWHCode();
            this.cboWHCode.DataSource = (ClsBuildEntryComboBox1.ARWHCode);
            this.cboWHCode.DisplayMember = "Display";
            this.cboWHCode.ValueMember = "Value";
        }

        private void buildcboSalesman()
        {
            cboSalesman.DataSource = null;
            ClsBuildComboBox1.PALSalesman.Clear();
            ClsBuildComboBox1.ClsBuildSalesman();
            this.cboSalesman.DataSource = (ClsBuildComboBox1.PALSalesman);
            this.cboSalesman.DisplayMember = "Display";
            this.cboSalesman.ValueMember = "Value";
        }

        private void btnPreview_Click_1(object sender, EventArgs e)
        {
            if ((new ClsValidation().emptytxt(cbortprint.Text)) || (txtBeginDate.Text == "  /  /") || (txtEndDate.Text == "  /  /") || /*(new ClsValidation().emptytxt(cboSupplierCode.Text)) ||*/ (Convert.ToDateTime(txtBeginDate.Text) > Convert.ToDateTime(txtEndDate.Text)))
            {
                MessageBox.Show("Please complete your entry", "GL");
                cbortprint.Focus();
            }
            else if (Convert.ToDateTime(txtBeginDate.Text) > Convert.ToDateTime(txtEndDate.Text))
            {
                MessageBox.Show("Beginning date is greater than ending date", "GL");
                cbortprint.Focus();
            }
            else
            {
                dgv1.Visible = false;
                crystalReportViewer1.Visible = true;
                AllPrincipal();
            }
        }

        private void cbortprint_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbortprint.SelectedValue.ToString() == "01")
            {
                crystalReportViewer1.Visible = true;
                dgv1.Visible = false;
            }
            else
            {
                dgv1.DataSource = null;
                UpdateStockClass();
                showPrincipal();
                crystalReportViewer1.Visible = false;
                dgv1.Visible = true;
            }
        }

        private void showPrincipal()
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);

            sqlstatement = "Select ClassCode, ClassDesc, ShowSalesmanCustom FROM tblStockClass ORDER BY ClassDesc";

            da = new SqlDataAdapter(sqlstatement, myconnection);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);

            dataTable = new DataTable();
            da.Fill(dataTable);
            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;

            //Adding ClassCode TextBox
            DataGridViewTextBoxColumn ColumnTerm = new DataGridViewTextBoxColumn();
            ColumnTerm.HeaderText = "Code";
            ColumnTerm.Width = 80;
            ColumnTerm.DataPropertyName = "ClassCode";
            ColumnTerm.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnTerm.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnTerm.Visible = false;
            dgv1.Columns.Add(ColumnTerm);

            //Adding  ClassDesc TextBox
            DataGridViewTextBoxColumn ColumnCreditLimit = new DataGridViewTextBoxColumn();
            ColumnCreditLimit.HeaderText = "Description";
            ColumnCreditLimit.Width = 300;
            ColumnCreditLimit.DataPropertyName = "ClassDesc";
            ColumnCreditLimit.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnCreditLimit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnCreditLimit.ReadOnly = true;
            dgv1.Columns.Add(ColumnCreditLimit);

            //Adding  ShowSalesmanCustom TextBox
            DataGridViewCheckBoxColumn ColumnShowSalesmanCustom = new DataGridViewCheckBoxColumn();
            ColumnShowSalesmanCustom.HeaderText = "";
            ColumnShowSalesmanCustom.Width = 50;
            ColumnShowSalesmanCustom.DataPropertyName = "ShowSalesmanCustom";
            ColumnShowSalesmanCustom.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnShowSalesmanCustom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv1.Columns.Add(ColumnShowSalesmanCustom);

            dgv1.DataSource = bindingSource;
            myconnection.Close();
            this.WindowState = FormWindowState.Maximized;
            dgv1.AllowUserToAddRows = false;
        }

        private void UpdateStockClass()
        {
            sqlstatement = "UPDATE tblStockClass SET ShowSalesmanCustom=0";

            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = myconnection.CreateCommand();
            mycommand.CommandText = sqlstatement;
            mycommand.CommandTimeout = 900;
            SqlDataReader1 = mycommand.ExecuteReader();
            DataTable DataTable1 = new DataTable();
            DataTable1.Load(SqlDataReader1);
            myconnection.Close();
        }

        private void dgv1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow Row in dgv1.Rows)
            {
                if (Row.Cells[2].Value.ToString() == "True")
                {
                    sqlstatement = "UPDATE tblStockClass SET ShowSalesmanCustom=1 WHERE ClassCode = '" + Row.Cells[0].Value.ToString() + "'";
                }
                else
                {
                    sqlstatement = "UPDATE tblStockClass SET ShowSalesmanCustom=0 WHERE ClassCode = '" + Row.Cells[0].Value.ToString() + "'";
                }
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = myconnection.CreateCommand();
                mycommand.CommandText = sqlstatement;
                mycommand.CommandTimeout = 900;
                SqlDataReader1 = mycommand.ExecuteReader();
                DataTable DataTable1 = new DataTable();
                DataTable1.Load(SqlDataReader1);
                myconnection.Close();
            }
        }
    }
}

