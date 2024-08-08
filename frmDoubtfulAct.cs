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
        
    public partial class frmDoubtfulAct : Form
    {
        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();
        ClsGetSomething ClsGetSomething1 = new ClsGetSomething(); 
        SqlConnection myconnection;
        private SqlDataAdapter da;
        private DataTable dataTable = null;
        BindingSource dbind = new BindingSource();
        private BindingSource bindingSource = null;
        private string psrefer;
        //DataSet ds = new DataSet();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection(); 

        public frmDoubtfulAct()
        {
            InitializeComponent();
        }

        private void frmDoubtfulAct_Load(object sender, EventArgs e)
        {
            showsearchdata();
        }
 

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showsearchdata()
        {
            //SELECT [View Aging].Refer, Min([View Aging].MinDate) AS MinOfMinDate, Sum(Val(Format([Balance],"#.##"))) AS Bal
            //FROM [View Aging]
            //GROUP BY [View Aging].Refer, [View Aging].ControlNo
            //HAVING (((Min([View Aging].MinDate))<=[Forms]![frmVoucher JV1]![TDate]) AND ((Sum(Val(Format([Balance],"#.##"))))<>0) AND (([View Aging].ControlNo)=[Forms]![frmVoucher JV1]![ControlNo]));
            //string varstrtd = frmVoucherJV.glbltxtTDate.Text;
            //DateTime td = DateTime.Parse(varstrtd);
            dgv1.DataSource = null;
            dgv1.Columns.Clear();

            string sqlstatement;
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            sqlstatement = "SELECT Refer, Min(MinDate) As MinMinDate, Sum(Balance) As Bal FROM [View Aging] ";
            sqlstatement +="GROUP BY Refer, ControlNo HAVING Min(MinDate)<='" + frmVoucherJV.glbltxtTDate .Text + "' AND ControlNo = '"+frmVoucherJV.glblcboControlNo.SelectedValue.ToString()+"' AND Sum(Balance)<>0 ORDER BY MinMinDate";
            //sqlstatement = "SELECT Refer, Min(MinDate) As MinMinDate, Sum(Balance) As Bal FROM [View Aging] WHERE MinDate<='" + frmVoucherJV.glbltxtTDate .Text + "' AND ControlNo = '"+frmVoucherJV.glblcboControlNo.SelectedValue.ToString()+"' AND Bal<>0 GROUP BY Refer";
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
            ColumnDate.DataPropertyName = "MinMinDate";
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
            dgv1.Columns[1].Name = "MinMinDate";
            dgv1.Columns[2].Name = "Bal";
            //Setting Data Source for DataGridView
            dgv1.DataSource = bindingSource;
            //            dgv1.AutoResizeColumns();
            //            dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            myconnection.Close();
            //            this.WindowState = FormWindowState.Maximized;
            dgv1.AllowUserToAddRows = true;
            dgv1.Columns[2].DefaultCellStyle.Format = "N2";
            dgv1.Columns[1].DefaultCellStyle.Format = "MM/dd/yyyy"; 
        }

        private void dgv1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgv1.Rows[e.RowIndex];
            psrefer = row.Cells[0].FormattedValue.ToString();
            txtrefer.Text = row.Cells[0].FormattedValue.ToString();
            //psdate = row.Cells[1].FormattedValue.ToString();
            //psbal = row.Cells[2].FormattedValue.ToString();
            string stramt1 = row.Cells[2].FormattedValue.ToString();
            if (new ClsValidation().emptytxt(stramt1))
            {
                txtAmount.Text = "0.00";
            }
            else
            {
                txtAmount.Text = (double.Parse (stramt1)*-1).ToString("N2");
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

        private void txtAmount_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().isDouble(txtAmount.Text) == true)
            {
                MessageBox.Show("Invalid Number", "GL");
                txtAmount.Focus();
            }
            else
            {
                txtAmount.Text = Convert.ToDouble(txtAmount.Text).ToString("N2");
            }
        }

        private void btnOI_Click(object sender, EventArgs e)
        {
            if (new ClsValidation().emptytxt(txtrefer.Text))
            {
                MessageBox.Show("Please complete your entry", "GL");
                dgv1.Focus();
            }
            else
            {
                {
                    ClsGetSomething1.ClsGetAT("1500000");
                    frmVoucherJV.glbldgv1.Rows.Add("1500000", ClsGetSomething1.plsAT, psrefer, "NA", txtAmount.Text, "0.00", 0);
                    ClsGetSomething1.ClsGetAT("5250000");
                    frmVoucherJV.glbldgv1.Rows.Add("5250000", ClsGetSomething1.plsAT, psrefer, "NA", "0.00", txtAmount.Text, 0);
                }
                double A = Convert.ToDouble(dgv1.CurrentRow.Cells[2].Value);
                double B = Convert.ToDouble(txtAmount.Text);
                dgv1.CurrentRow.Cells[2].Value = (A - B);
                dgv1.Focus();
                txtrefer.Text = "";
                txtAmount.Text = "0.00";
                refreshdgv1();
                dgv1total();
            }

        }

        private void btnDA_Click(object sender, EventArgs e)
        {
            if (new ClsValidation().emptytxt(txtrefer.Text))
            {
                MessageBox.Show("Please complete your entry", "GL");
                dgv1.Focus();
            }
            else
            {
                {
                    ClsGetSomething1.ClsGetAT("1510000");
                    frmVoucherJV.glbldgv1.Rows.Add("1510000", ClsGetSomething1.plsAT, psrefer, "NA", txtAmount.Text, "0.00", 0);
                    ClsGetSomething1.ClsGetAT("1500000");
                    frmVoucherJV.glbldgv1.Rows.Add("1500000", ClsGetSomething1.plsAT, psrefer, "NA", "0.00", txtAmount.Text, 0);
                }
                double A = Convert.ToDouble(dgv1.CurrentRow.Cells[2].Value);
                double B = Convert.ToDouble(txtAmount.Text);
                dgv1.CurrentRow.Cells[2].Value = (A - B);
                dgv1.Focus();
                txtrefer.Text = "";
                txtAmount.Text = "0.00";
                refreshdgv1();
                dgv1total();
            }
        }
    }
}
