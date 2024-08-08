using System;
using System.Collections;
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
    public partial class frmEditVoucherCS : Form
    {
        SqlConnection myconnection;
        private SqlDataAdapter da;
        private DataTable dataTable = null;
        SqlDataReader dr;
        SqlCommand mycommand;
        BindingSource dbind = new BindingSource();
        private BindingSource bindingSource = null;
        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();
        ClsBuildVoucherComboBox ClsBuildVoucherComboBox1 = new ClsBuildVoucherComboBox(); 
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection(); 

        public frmEditVoucherCS()
        {
            InitializeComponent();
        }

        private void buildcboControlNo()
        {
            cboControlNo.DataSource = null;
            ClsBuildComboBox1.T.Clear();
            ClsBuildComboBox1.ClsBuildCVControlno();
            this.cboControlNo.DataSource = (ClsBuildComboBox1.T);
            this.cboControlNo.DisplayMember = "Display";
            this.cboControlNo.ValueMember = "Value";        }
      
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

        private void buildcboSalesman()
        {
            cboPC.DataSource = null;
            ClsBuildVoucherComboBox1.ARLSLS.Clear();
            ClsBuildVoucherComboBox1.ClsBuildSalesman();
            this.cboPC.DataSource = (ClsBuildVoucherComboBox1.ARLSLS);
            this.cboPC.DisplayMember = "Display";
            this.cboPC.ValueMember = "Value";
        }

       
    
        private void frmVoucherJV_Load(object sender, EventArgs e)
        {
            ClsPermission1.ClsObjects(this.Text);
            if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
            {
                MessageBox.Show("You do not have necessary permission to open this file", "GL");
                this.Close();
            }
            else
            {
                buildcboSalesman();
                buildcboControlNo();
                buildcboPA();
            }
        }

       
        private void cboControlNo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (new ClsValidation().emptytxt(cboControlNo.Text))
                {
                }
                else if (cboControlNo.Text != null && cboControlNo.SelectedValue == null)
                {
                    MessageBox.Show("Not found");
                    cboControlNo.Focus();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {

            }

        }

        private void dgv1total()
        {
            double vartxtdr = 0.00;
            double vartxtcr = 0.00;

            for (int x = 0; x < dgv1.Rows.Count ; x++)
            {
                vartxtdr += double.Parse(dgv1.Rows[x].Cells[2].FormattedValue.ToString());
            }

            for (int x = 0; x < dgv1.Rows.Count ; x++)
            {
                vartxtcr += double.Parse(dgv1.Rows[x].Cells[3].FormattedValue.ToString());
            }
            txtdrtot.Text = vartxtdr.ToString("n2");
            txtcrtot.Text = vartxtcr.ToString("n2");

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Clear the row error in case the user presses ESC.   
            dgv1.Rows[e.RowIndex].ErrorText = String.Empty;

            if (e.ColumnIndex == dgv1.Columns["cbopa"].Index)
            {
                string[] values = new string[1];
                DataGridViewRow row = dgv1.Rows[e.RowIndex];

                //dgv1.CurrentRow.Cells[1].Value = txtreference.Text;

                //dgv1.CurrentRow.Cells[2].Value = 0.00;
                //dgv1.CurrentRow.Cells[3].Value = 0.00;

                dgv1total();
            }
            else if (e.ColumnIndex == dgv1.Columns["txtdr"].Index)
            {
                dgv1total();
            }

            else if (e.ColumnIndex == dgv1.Columns["txtcr"].Index)
            {
                dgv1total();
            }

        }

        //private void trimValues(int rowIndex)
        //{
        //    DataGridViewRow row = dgv1.Rows[rowIndex];

        //    row.Cells[3].Value = double.Parse(row.Cells[3].FormattedValue.ToString().Trim()).ToString("n2");
        //    row.Cells[4].Value = double.Parse(row.Cells[4].FormattedValue.ToString().Trim()).ToString("n2");
        //}

        private void dgv1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            }
  
        }

        private void dgv1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgv1.IsCurrentCellDirty)
            {
                dgv1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
   
        }

        private void dgv1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgv1.Columns["txtDR"].Index)  //this is our numeric column
            {
                if (String.IsNullOrEmpty(e.FormattedValue.ToString()))// &&
                //dgv1[e.ColumnIndex, e.RowIndex].IsInEditMode)
                {
                    e.Cancel = false;

                }

                else
                {
                    double i;
                    if (!double.TryParse(Convert.ToString(e.FormattedValue), out i))
                    {
                        e.Cancel = true;
                        MessageBox.Show("Numeric only");
                    }
                }
            }


            else if (e.ColumnIndex == dgv1.Columns["txtCR"].Index)  //this is our numeric column
            {
                if (String.IsNullOrEmpty(e.FormattedValue.ToString()))// &&
                //dgv1[e.ColumnIndex, e.RowIndex].IsInEditMode)
                {
                    e.Cancel = false;

                }

                else
                {
                    double i;
                    if (!double.TryParse(Convert.ToString(e.FormattedValue), out i))
                    {
                        e.Cancel = true;
                        MessageBox.Show("Numeric only");
                    }
                }
            }


        }

        private void dgv1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            string[] values = new string[5];
            DataGridViewRow row = dgv1.Rows[e.RowIndex];
            ClsValidatorformEdit validator = null;

            values[0] = row.Cells[0].FormattedValue.ToString().Trim();
            values[1] = row.Cells[1].FormattedValue.ToString();
            values[2] = row.Cells[2].FormattedValue.ToString();
            values[3] = row.Cells[3].FormattedValue.ToString();
            values[4] = row.Cells[4].FormattedValue.ToString();

            if (!String.IsNullOrEmpty(values[0]) || !String.IsNullOrEmpty(values[1]) || !String.IsNullOrEmpty(values[2]) ||
       !String.IsNullOrEmpty(values[3]) || !String.IsNullOrEmpty(values[4]) || !String.IsNullOrEmpty(values[5]))
            {

                validator = new ClsValidatorformEdit(dgv1);

                validator.values(values);

                if (!validator.validate())
                    e.Cancel = true;
                //else
                //    trimValues(e.RowIndex);

            }

        }

     

        private void txtDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtreference_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboControlNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

 
        private void dgv1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            dgv1total();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (new ClsValidation().emptytxt(txtTDate.Text) || new ClsValidation().emptytxt(cboControlNo.Text) || new ClsValidation().emptytxt(txtRemarks.Text))
                {
                    MessageBox.Show("Please complete your entry", "GL");
                    txtTDate.Focus();
                }
                else
                {
                    ClsGetConnection1.ClsGetConMSSQL();
                    myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                    myconnection.Open();
                    string Sqlstatement;
                    Sqlstatement = "UPDATE tblMain1 SET ControlNo= @_ControlNo, TDate=@_TDate, Remarks=@_Remarks WHERE DocNum ='" + txtDocNum.Text + "' AND Voucher='JV'";

                    mycommand = new SqlCommand(Sqlstatement, myconnection);
                    mycommand.Parameters.Add("_ControlNo", SqlDbType.VarChar).Value = cboControlNo.SelectedValue.ToString();
                    mycommand.Parameters.Add("_TDate", SqlDbType.SmallDateTime).Value = txtTDate.Text;
                    mycommand.Parameters.Add("_Remarks", SqlDbType.VarChar).Value = txtRemarks.Text;
                    mycommand.CommandTimeout = 600;
                    int n1 = mycommand.ExecuteNonQuery();
                    myconnection.Close();

                    da.Update(dataTable);
                    MessageBox.Show("Saved", "GL");
                    //   this.Close();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                dr.Close();
                myconnection.Close();
            }
        }

       

        private void txtTDate_Leave(object sender, EventArgs e)
        {
            if (new ClsValidation().errordate(txtTDate.Text) == true)
            {
                MessageBox.Show("Invalid Date", "GL");
                txtTDate.Focus();
            }
        }

        private void cboAccountCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }

        }

        private void txtSearch_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().emptytxt(txtSearch.Text))
            {
                //    MessageBox.Show("Search is empty", "GL");
            }
            else
            {
                dgv1.DataSource = null;
                dgv1.Columns.Clear();
                showdata();
                showsearchdata();
                dgv1total();
            }
        }

        private void showdata()
        {
            // Define ADO.NET objects.
            string selectSQL;
            selectSQL = "SELECT * FROM ViewBookCS ";
            selectSQL += "WHERE DocNum='" + txtSearch.Text + "'";

            // Try to open database and read information.
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand(selectSQL, myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();
                dr.Read();

                //// Fill the controls.
                DateTime dtTD = Convert.ToDateTime(dr["TDate"].ToString());
                txtTDate.Text = String.Format("{0:MM/dd/yyyy}", dtTD);
                txtDocNum.Text = dr["DocNum"].ToString();
                txtreference.Text = dr["Reference"].ToString();
                cboControlNo.SelectedValue = dr["ControlNo"].ToString();
                cboPC.SelectedValue = dr["PC"].ToString();
                txtRemarks.Text = dr["Remarks"].ToString();
                //chkContract.Checked = (bool)reader["contract"];

                myconnection.Close();
                dr.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Number cannot be found", "GL");
                txtSearch.Focus();
            }
            finally
            {
                myconnection.Close();
            }

        }

        private void showsearchdata()
        {
            string sql;
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            sql = "SELECT PA, Refer, Debit, Credit, Num FROM tblMain3 WHERE IC = 'CS'+'" + txtSearch.Text + "'";

            da = new SqlDataAdapter(sql, myconnection);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
            da.SelectCommand.CommandTimeout = 600;
            dataTable = new DataTable();
            da.Fill(dataTable);
            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;


            //PA Data Source
            string selectQueryStringPA = "SELECT PA, AT FROM viewpa";
            SqlDataAdapter sqlDataAdapterPA = new SqlDataAdapter(selectQueryStringPA, myconnection);
            SqlCommandBuilder sqlCommandBuildergroup = new SqlCommandBuilder(sqlDataAdapterPA);
            DataTable dataTableItem = new DataTable();
            sqlDataAdapterPA.Fill(dataTableItem);
            BindingSource bindingSourcegroup = new BindingSource();
            bindingSourcegroup.DataSource = dataTableItem;

        

            //Adding  PA Combo
            DataGridViewComboBoxColumn ColumnPA = new DataGridViewComboBoxColumn();
            ColumnPA.DataPropertyName = "PA";
            ColumnPA.HeaderText = "Account Title";
            ColumnPA.Width = 425;

            ColumnPA.DataSource = bindingSourcegroup;
            ColumnPA.ValueMember = "PA";
            ColumnPA.DisplayMember = "AT";
            ColumnPA.ReadOnly = true;
            dgv1.Columns.Add(ColumnPA);


            //Adding  Refer TextBox
            DataGridViewTextBoxColumn ColumnRefer = new DataGridViewTextBoxColumn();
            ColumnRefer.HeaderText = "Reference";
            ColumnRefer.Width = 150;
            ColumnRefer.DataPropertyName = "Refer";
            ColumnRefer.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnRefer.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //ColumnRefer.Visible = false;
            ColumnRefer.ReadOnly = true;
            dgv1.Columns.Add(ColumnRefer);

            //Adding  Debit TextBox
            DataGridViewTextBoxColumn ColumnDR = new DataGridViewTextBoxColumn();
            ColumnDR.HeaderText = "Debit";
            ColumnDR.Width = 150;
            ColumnDR.DataPropertyName = "Debit";
            ColumnDR.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnDR.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnDR.ReadOnly = true;
            dgv1.Columns.Add(ColumnDR);

            //Adding  Credit TextBox
            DataGridViewTextBoxColumn ColumnCR = new DataGridViewTextBoxColumn();
            ColumnCR.HeaderText = "Credit";
            ColumnCR.Width = 150;
            ColumnCR.DataPropertyName = "Credit";
            ColumnCR.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnCR.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnCR.ReadOnly = true;
            dgv1.Columns.Add(ColumnCR);

           
            // Adding  Num TextBox
            DataGridViewTextBoxColumn ColumnNum = new DataGridViewTextBoxColumn();
            ColumnNum.HeaderText = "Num";
            //ColumnNum.Width = 80;
            ColumnNum.DataPropertyName = "Num";
            ColumnNum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnNum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnNum.Visible = false;
            dgv1.Columns.Add(ColumnNum);

            dgv1.Columns[0].Name = "cboPA";
            dgv1.Columns[1].Name = "txtrefer";
            dgv1.Columns[2].Name = "txtDR";
            dgv1.Columns[3].Name = "txtCR";
           
            //Setting Data Source for DataGridView
            dgv1.DataSource = bindingSource;
            //            dgv1.AutoResizeColumns();
            //            dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            myconnection.Close();
            //            this.WindowState = FormWindowState.Maximized;
            dgv1.AllowUserToAddRows = false;
            dgv1.Columns[2].DefaultCellStyle.Format = "N2";
            dgv1.Columns[3].DefaultCellStyle.Format = "N2";

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

    }
}
