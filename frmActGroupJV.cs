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
        
    public partial class frmActGroupJV : Form
    {
        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();
        ClsGetSomething ClsGetSomething1 = new ClsGetSomething(); 
        SqlConnection myconnection;
        private SqlDataAdapter da;
        private DataTable dataTable = null;
        BindingSource dbind = new BindingSource();
        private BindingSource bindingSource = null;
        private string psrefer, psdate, psbal, psNormalBal;
        public static TextBox glbltxtVoucher;
        //DataSet ds = new DataSet();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection(); 

        public frmActGroupJV()
        {
            InitializeComponent();
        }

        private void frmActGroupJV_Load(object sender, EventArgs e)
        {
            glbltxtVoucher = txtVoucher;
            buildcboPA();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDebit_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().isDouble(txtDebit.Text) == true)
            {
                MessageBox.Show("Invalid Number", "GL");
                txtDebit.Focus();
            }
            else
            {
                txtDebit.Text = Convert.ToDouble(txtDebit.Text).ToString("N2");
            }
        }

        private void txtCredit_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().isDouble(txtCredit.Text) == true)
            {
                MessageBox.Show("Invalid Number", "GL");
                txtCredit.Focus();
            }
            else
            {
                txtCredit.Text = Convert.ToDouble(txtCredit.Text).ToString("N2");
            }
 
        }

        private void cboPA_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().emptytxt(cboPA.Text))
            {
            }
            else if (cboPA.Text != null && cboPA.SelectedValue == null)
            {
                MessageBox.Show("Not found", "GL");
                cboPA.Focus();
            }
            else
            {
                dgv1.DataSource = null;
                dgv1.Columns.Clear();
                showsearchdata();
                ClsGetSomething1.ClsGetNormalBal(cboPA.SelectedValue.ToString());
                psNormalBal = ClsGetSomething1.plsNormalBal;
                refreshdgv1();
            }
        
        }

        private void showsearchdata()
        {
            string sqlstatement;
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            sqlstatement = "SELECT Refer, Min(MinDate) as MinDate, sum(Bal) as Bal FROM ViewActGroup WHERE  PA='" + cboPA.SelectedValue.ToString() + "'  Group By Refer  Having (sum(Bal) <> 0)  ORDER BY MinDate DESC";
            da = new SqlDataAdapter(sqlstatement, myconnection);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
            da.SelectCommand.CommandTimeout = 600;

            dataTable = new DataTable();
            da.Fill(dataTable);
            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;

            //Adding  Refer TextBox
            DataGridViewTextBoxColumn ColumnRefer = new DataGridViewTextBoxColumn();
            ColumnRefer.HeaderText = "Reference";
            ColumnRefer.Width = 130;
            ColumnRefer.DataPropertyName = "Refer";
            ColumnRefer.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnRefer.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //ColumnRefer.Visible = false;
            ColumnRefer.ReadOnly = true;
            dgv1.Columns.Add(ColumnRefer);

            //Adding  Date TextBox
            DataGridViewTextBoxColumn ColumnDate = new DataGridViewTextBoxColumn();
            ColumnDate.HeaderText = "Date";
            ColumnDate.Width = 100;
            ColumnDate.DataPropertyName = "MinDate";
            ColumnDate.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //ColumnDate.Visible = false;
            ColumnDate.ReadOnly = true;
            dgv1.Columns.Add(ColumnDate);

            //Adding  Amount TextBox
            DataGridViewTextBoxColumn ColumnAmount = new DataGridViewTextBoxColumn();
            ColumnAmount.HeaderText = "Amount";
            ColumnAmount.Width = 100;
            ColumnAmount.DataPropertyName = "Bal";
            ColumnAmount.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnAmount.ReadOnly = true;
            dgv1.Columns.Add(ColumnAmount);
         
            dgv1.Columns[0].Name = "Refer";
            dgv1.Columns[1].Name = "MinDate";
            dgv1.Columns[2].Name = "Bal";
            //Setting Data Source for DataGridView
            dgv1.DataSource = bindingSource;
            //            dgv1.AutoResizeColumns();
            //            dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            myconnection.Close();
            //            this.WindowState = FormWindowState.Maximized;
            dgv1.AllowUserToAddRows = true;
            dgv1.Columns[2].DefaultCellStyle.Format = "N4";
            dgv1.Columns[1].DefaultCellStyle.Format = "MM/dd/yyyy"; 
        }

        private void dgv1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgv1.Rows[e.RowIndex];
            psrefer = row.Cells[0].FormattedValue.ToString();
            txtrefer.Text = row.Cells[0].FormattedValue.ToString();
            psdate = row.Cells[1].FormattedValue.ToString();
            psbal = row.Cells[2].FormattedValue.ToString();
            if (psNormalBal == "D")
            {
                txtCredit.Text = row.Cells[2].FormattedValue.ToString();
                txtDebit.Text = "0.00";
            }
            else
            {
                txtDebit.Text = row.Cells[2].FormattedValue.ToString();
                txtCredit.Text = "0.00";
            }
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            if (new ClsValidation().emptytxt(txtrefer.Text))
            {
                MessageBox.Show("Please complete your entry", "GL");
                dgv1.Focus();
            }
            else
            {
                ClsGetSomething1.ClsGetAT(cboPA.SelectedValue.ToString());
                if (txtVoucher.Text == "JV")
                {
                    frmVoucherJV.glbldgv1.Rows.Add(cboPA.SelectedValue.ToString(), ClsGetSomething1.plsAT, psrefer, "NA", txtDebit.Text, txtCredit.Text, 0);
                }
                else if (txtVoucher.Text == "CV")
                {
                    frmVoucherCV.glbldgv1.Rows.Add(cboPA.SelectedValue.ToString(), ClsGetSomething1.plsAT, psrefer, "NA", txtDebit.Text, txtCredit.Text, 0);
                }
                else if (txtVoucher.Text == "RV")
                {
                    frmVoucherRV.glbldgv1.Rows.Add(cboPA.SelectedValue.ToString(), ClsGetSomething1.plsAT, psrefer, "NA", txtDebit.Text, txtCredit.Text, 0);
                }
  
                else if (txtVoucher.Text == "APV")
                {
                    frmVoucherAPV.glbldgv1.Rows.Add(cboPA.SelectedValue.ToString(), ClsGetSomething1.plsAT, psrefer, "NA", txtDebit.Text, txtCredit.Text, 0);
                }

                else if (txtVoucher.Text == "ARV")
                {
                    frmVoucherARV.glbldgv1.Rows.Add(cboPA.SelectedValue.ToString(), ClsGetSomething1.plsAT, psrefer, "NA", txtDebit.Text, txtCredit.Text, 0);
                }

                double A = Convert.ToDouble(dgv1.CurrentRow.Cells[2].Value);
                double B = Convert.ToDouble(txtCredit.Text);
                double C = Convert.ToDouble(txtDebit.Text);
                if (psNormalBal == "D")
                {
                    dgv1.CurrentRow.Cells[2].Value = (A + C) - B;
                }
                else
                {
                    dgv1.CurrentRow.Cells[2].Value = (A - C) + B;
                }
                
                dgv1.Focus();
                txtrefer.Text = "";
                txtDebit.Text = "0.00";
                txtCredit.Text = "0.00";
                //refreshdgv1();
                dgv1total();
            }
        }

        private void nextfieldenter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void refreshdgv1()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dgv1.DataSource;
            bs.Filter = "Bal <> '0.00'";
            dgv1.DataSource = bs;
        }


        private void dgv1total()
        {
            double vartxtdr = 0.00;
            double vartxtcr = 0.00;
            double vartxtdiff = 0.00;

            if (txtVoucher.Text == "JV")
            {
                for (int x = 0; x < frmVoucherJV.glbldgv1.Rows.Count - 1; x++)
                {
                    vartxtdr += double.Parse(frmVoucherJV.glbldgv1.Rows[x].Cells[4].FormattedValue.ToString());
                }

                for (int x = 0; x < frmVoucherJV.glbldgv1.Rows.Count - 1; x++)
                {
                    vartxtcr += double.Parse(frmVoucherJV.glbldgv1.Rows[x].Cells[5].FormattedValue.ToString());
                }
                frmVoucherJV.glbltxtdrtot.Text = vartxtdr.ToString("n2");
                frmVoucherJV.glbltxtcrtot.Text = vartxtcr.ToString("n2");
                vartxtdiff = Convert.ToDouble(frmVoucherJV.glbltxtdrtot.Text) - Convert.ToDouble(frmVoucherJV.glbltxtcrtot.Text);
                frmVoucherJV.glbltxtDifference.Text = vartxtdiff.ToString("n2");
            }
            else if (txtVoucher.Text == "CV")
            {
                for (int x = 0; x < frmVoucherCV.glbldgv1.Rows.Count - 1; x++)
                {
                    vartxtdr += double.Parse(frmVoucherCV.glbldgv1.Rows[x].Cells[4].FormattedValue.ToString());
                }

                for (int x = 0; x < frmVoucherCV.glbldgv1.Rows.Count - 1; x++)
                {
                    vartxtcr += double.Parse(frmVoucherCV.glbldgv1.Rows[x].Cells[5].FormattedValue.ToString());
                }
                frmVoucherCV.glbltxtdrtot.Text = vartxtdr.ToString("n2");
                frmVoucherCV.glbltxtcrtot.Text = vartxtcr.ToString("n2");
                vartxtdiff = Convert.ToDouble(frmVoucherCV.glbltxtdrtot.Text) - Convert.ToDouble(frmVoucherCV.glbltxtcrtot.Text);
                frmVoucherCV.glbltxtDifference.Text = vartxtdiff.ToString("n2");
            }
            else if (txtVoucher.Text == "RV")
            {
                for (int x = 0; x < frmVoucherRV.glbldgv1.Rows.Count - 1; x++)
                {
                    vartxtdr += double.Parse(frmVoucherRV.glbldgv1.Rows[x].Cells[4].FormattedValue.ToString());
                }

                for (int x = 0; x < frmVoucherRV.glbldgv1.Rows.Count - 1; x++)
                {
                    vartxtcr += double.Parse(frmVoucherRV.glbldgv1.Rows[x].Cells[5].FormattedValue.ToString());
                }
                frmVoucherRV.glbltxtdrtot.Text = vartxtdr.ToString("n2");
                frmVoucherRV.glbltxtcrtot.Text = vartxtcr.ToString("n2");
                vartxtdiff = Convert.ToDouble(frmVoucherRV.glbltxtdrtot.Text) - Convert.ToDouble(frmVoucherRV.glbltxtcrtot.Text);
                frmVoucherRV.glbltxtDifference.Text = vartxtdiff.ToString("n2");
            }


            else if (txtVoucher.Text == "APV")
            {
                for (int x = 0; x < frmVoucherAPV.glbldgv1.Rows.Count - 1; x++)
                {
                    vartxtdr += double.Parse(frmVoucherAPV.glbldgv1.Rows[x].Cells[4].FormattedValue.ToString());
                }

                for (int x = 0; x < frmVoucherAPV.glbldgv1.Rows.Count - 1; x++)
                {
                    vartxtcr += double.Parse(frmVoucherAPV.glbldgv1.Rows[x].Cells[5].FormattedValue.ToString());
                }
                frmVoucherAPV.glbltxtdrtot.Text = vartxtdr.ToString("n2");
                frmVoucherAPV.glbltxtcrtot.Text = vartxtcr.ToString("n2");
                vartxtdiff = Convert.ToDouble(frmVoucherAPV.glbltxtdrtot.Text) - Convert.ToDouble(frmVoucherAPV.glbltxtcrtot.Text);
                frmVoucherAPV.glbltxtDifference.Text = vartxtdiff.ToString("n2");
            }

            else if (txtVoucher.Text == "ARV")
            {
                for (int x = 0; x < frmVoucherARV.glbldgv1.Rows.Count - 1; x++)
                {
                    vartxtdr += double.Parse(frmVoucherARV.glbldgv1.Rows[x].Cells[4].FormattedValue.ToString());
                }

                for (int x = 0; x < frmVoucherARV.glbldgv1.Rows.Count - 1; x++)
                {
                    vartxtcr += double.Parse(frmVoucherARV.glbldgv1.Rows[x].Cells[5].FormattedValue.ToString());
                }
                frmVoucherARV.glbltxtdrtot.Text = vartxtdr.ToString("n2");
                frmVoucherARV.glbltxtcrtot.Text = vartxtcr.ToString("n2");
                vartxtdiff = Convert.ToDouble(frmVoucherARV.glbltxtdrtot.Text) - Convert.ToDouble(frmVoucherARV.glbltxtcrtot.Text);
                frmVoucherARV.glbltxtDifference.Text = vartxtdiff.ToString("n2");
            }

        }

        private void cbAccountNo_CheckedChanged(object sender, EventArgs e)
        {
            buildcboPA();
        }

    }
}
