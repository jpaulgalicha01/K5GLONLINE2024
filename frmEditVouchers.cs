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
    public partial class frmEditVouchers : Form
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

        public frmEditVouchers()
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
            this.cboControlNo.ValueMember = "Value";
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
            if (Form1.glblgroupcode.Text != "01")
            {
                btnSave.Enabled = false;
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

            for (int x = 0; x < dgv1.Rows.Count; x++)
            {
                vartxtdr += double.Parse(dgv1.Rows[x].Cells[2].FormattedValue.ToString());
            }

            for (int x = 0; x < dgv1.Rows.Count; x++)
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
                    if (cboVoucher.Text == "RV")
                    {
                        Sqlstatement = "UPDATE tblMain1 SET Void= @_Void, UserSearch=@_UserSearch, Reference=@_Reference, Remarks=@_Remarks, VDate=@_VDate, PC=@_PC, EDate=@_EDate WHERE DocNum ='" + txtDocNum.Text + "' AND Voucher='" + cboVoucher.Text + "'";
                    }
                    else
                    {
                        Sqlstatement = "UPDATE tblMain1 SET Void= @_Void, UserSearch=@_UserSearch, Reference=@_Reference, Remarks=@_Remarks, EDate=@_EDate WHERE DocNum ='" + txtDocNum.Text + "' AND Voucher='" + cboVoucher.Text + "'";
                    }

                    mycommand = new SqlCommand(Sqlstatement, myconnection);
                    ////mycommand.Parameters.Add("_ControlNo", SqlDbType.VarChar).Value = cboControlNo.SelectedValue.ToString();
                    //mycommand.Parameters.Add("_Remarks", SqlDbType.VarChar).Value = txtRemarks.Text;
                    mycommand.Parameters.Add("_Void", SqlDbType.Bit).Value = cbVoid.CheckState;
                    mycommand.Parameters.Add("_UserSearch", SqlDbType.VarChar).Value = Form1.glbluc.Text;
                    mycommand.Parameters.Add("_Reference", SqlDbType.VarChar).Value = txtreference.Text;
                    mycommand.Parameters.Add("_Remarks", SqlDbType.VarChar).Value = txtRemarks.Text;
                    if (cboVoucher.Text == "RV")
                    {
                        mycommand.Parameters.Add("_VDate", SqlDbType.SmallDateTime).Value = txtVDate.Text;
                        mycommand.Parameters.Add("_PC", SqlDbType.VarChar).Value = cboPC.SelectedValue.ToString();
                    }
                    else { }
                    mycommand.Parameters.Add("_EDate", SqlDbType.SmallDateTime).Value = DateTime.Today;
                    mycommand.CommandTimeout = 600;
                    int n1 = mycommand.ExecuteNonQuery();

                    DataGridViewRow row3 = null;
                    if (cboVoucher.Text == "TF")
                    { }
                    else
                    {
                        for (int x = 0; x < dgv1.Rows.Count; x++)
                        {
                            row3 = dgv1.Rows[x];
                            //string sqlstatementupdate = "UPDATE tblMain3 set  Refer=@_Refer WHERE IC =  '" + txtIC.Text + "' AND PA <> '13101' AND RowNum = '" + row3.Cells[7].FormattedValue.ToString() + "' ";
                            string sqlstatementupdate = "UPDATE tblMain3 set Refer=@_Refer WHERE IC =  '" + txtIC.Text + "' AND Num = '" + row3.Cells[4].FormattedValue.ToString() + "'";
                            mycommand = new SqlCommand(sqlstatementupdate, myconnection);
                            mycommand.Parameters.Add("_Refer", SqlDbType.VarChar).Value = row3.Cells[1].FormattedValue.ToString();
                            mycommand.ExecuteNonQuery();
                        }
                    }

                    myconnection.Close();

                    //da.Update(dataTable);
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
            //if (new ClsValidation().emptytxt(txtSearch.Text))
            //{
            //    //    MessageBox.Show("Search is empty", "GL");
            //}
            //else
            //{
            //    dgv1.DataSource = null;
            //    dgv1.Columns.Clear();
            //    showdata();
            //    showsearchdata();
            //    dgv1total();
            //}

            showreference();
        }

        private void showdata()
        {
            
            // Try to open database and read information.
            try
            {
                // Define ADO.NET objects.
                string selectSQL;
                if (cboVoucher.Text == "APV")
                {
                    selectSQL = "SELECT * FROM ViewBookAPV ";
                    selectSQL += "WHERE Reference='" + txtSearch.Text + "'";
                }
                else if (cboVoucher.Text == "ARV")
                {
                    selectSQL = "SELECT * FROM ViewBookARV ";
                    selectSQL += "WHERE Reference='" + txtSearch.Text + "'";
                }
                else if (cboVoucher.Text == "JV")
                {
                    selectSQL = "SELECT * FROM ViewBookJV ";
                    selectSQL += "WHERE Reference='" + txtSearch.Text + "'";
                }
                else if (cboVoucher.Text == "CV")
                {
                    selectSQL = "SELECT * FROM ViewBookCV ";
                    selectSQL += "WHERE Reference='" + txtSearch.Text + "'";
                }
                else if (cboVoucher.Text == "OR")
                {
                    selectSQL = "SELECT * FROM ViewBookOR ";
                    selectSQL += "WHERE Reference='" + txtSearch.Text + "'";
                }
                else if (cboVoucher.Text == "CS")
                {
                    selectSQL = "SELECT * FROM ViewBookCS ";
                    selectSQL += "WHERE Reference='" + txtSearch.Text + "'";
                }
                else if (cboVoucher.Text == "CI")
                {
                    selectSQL = "SELECT * FROM ViewBookCI ";
                    selectSQL += "WHERE Reference='" + txtSearch.Text + "'";
                }
                else if (cboVoucher.Text == "RS")
                {
                    selectSQL = "SELECT * FROM ViewBookRS ";
                    selectSQL += "WHERE Reference='" + txtSearch.Text + "'";
                }
                else if (cboVoucher.Text == "PD")
                {
                    selectSQL = "SELECT * FROM ViewBookPD ";
                    selectSQL += "WHERE Reference='" + txtSearch.Text + "'";
                }
                else if (cboVoucher.Text == "AS")
                {
                    selectSQL = "SELECT * FROM ViewBookAS ";
                    selectSQL += "WHERE Reference='" + txtSearch.Text + "'";
                }
                else if (cboVoucher.Text == "RV")
                {
                    selectSQL = "SELECT * FROM ViewBookRV ";
                    selectSQL += "WHERE Reference='" + txtSearch.Text + "'";
                }
                else 
                {
                    selectSQL = "SELECT * FROM ViewTF ";
                    selectSQL += "WHERE Reference='" + txtSearch.Text + "'";
                }

                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand(selectSQL, myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();
                dr.Read();

                // Fill the controls.
                DateTime dtTD = Convert.ToDateTime(dr["TDate"].ToString());
                txtTDate.Text = String.Format("{0:MM/dd/yyyy}", dtTD);
                if (cboVoucher.Text == "RV")
                {
                    DateTime dtVD = Convert.ToDateTime(dr["VDate"].ToString());
                    txtVDate.Text = String.Format("{0:MM/dd/yyyy}", dtVD);
                    cboControlNo.SelectedValue = dr["ControlNo"].ToString();
                    cboPC.SelectedValue = dr["PC"].ToString();

                    txtDE.Text = dr["DE"].ToString();
                    txtreference.Text = dr["Reference"].ToString();
                    txtRemarks.Text = dr["Remarks"].ToString();
                }
                else
                {
                    txtDocNum.Text = dr["DocNum"].ToString();
                    txtreference.Text = dr["Reference"].ToString();
                    cboControlNo.SelectedValue = dr["ControlNo"].ToString();
                    cboPC.SelectedValue = dr["PC"].ToString();
                    txtRemarks.Text = dr["Remarks"].ToString();
                    if (cboVoucher.Text != "TF")
                    {
                        txtIC.Text = dr["IC"].ToString();

                    }
                    txtDE.Text = dr["DE"].ToString();

                }
              
                //chkContract.Checked = (bool)reader["contract"];

                myconnection.Close();
                dr.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Number cannot be found", "GL");
                cboVoucher.Focus();
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
            sql = null;
            if (cboVoucher.Text == "APV")
            {
                sql = "SELECT PA, Refer, Debit, Credit, Num FROM ViewBookAPV WHERE Reference = '" + txtSearch.Text + "'";
            }
            else if (cboVoucher.Text == "ARV")
            {
                sql = "SELECT PA, Refer, Debit, Credit, Num FROM ViewBookARV WHERE Reference = '" + txtSearch.Text + "'";
            }
            else if (cboVoucher.Text == "JV")
            {
                sql = "SELECT PA, Refer, Debit, Credit, Num FROM ViewBookJV WHERE Reference = '" + txtSearch.Text + "'";
            }
            else if (cboVoucher.Text == "CV")
            {
                sql = "SELECT PA, Refer, Debit, Credit, Num FROM ViewBookCV WHERE Reference = '" + txtSearch.Text + "'";
            }
            else if (cboVoucher.Text == "OR")
            {
                sql = "SELECT PA, Refer, Debit, Credit, Num FROM ViewBookOR WHERE Reference = '" + txtSearch.Text + "'";
            }
            else if (cboVoucher.Text == "CS")
            {
                sql = "SELECT PA, Refer, Debit, Credit, Num FROM ViewBookCS WHERE Reference = '" + txtSearch.Text + "'";
            }
            else if (cboVoucher.Text == "CI")
            {
                sql = "SELECT PA, Refer, Debit, Credit, Num FROM ViewBookCI WHERE Reference = '" + txtSearch.Text + "'";
            }
            else if (cboVoucher.Text == "RS")
            {
                sql = "SELECT PA, Refer, Debit, Credit, Num FROM ViewBookRS WHERE Reference = '" + txtSearch.Text + "'";
            }
            else if (cboVoucher.Text == "PD")
            {
                sql = "SELECT PA, Refer, Debit, Credit, Num FROM ViewBookPD WHERE Reference = '" + txtSearch.Text + "'";
            }
            else if (cboVoucher.Text == "AS")
            {
                sql = "SELECT PA, Refer, Debit, Credit, Num FROM ViewBookAS WHERE Reference = '" + txtSearch.Text + "'";
            }
            else if (cboVoucher.Text == "RV")
            {
                sql = "SELECT PA, Refer, Debit, Credit, Num FROM ViewBookRV WHERE Reference = '" + txtSearch.Text + "'";
            }


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
            ColumnPA.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv1.Columns.Add(ColumnPA);


            //Adding  Refer TextBox
            DataGridViewTextBoxColumn ColumnRefer = new DataGridViewTextBoxColumn();
            ColumnRefer.HeaderText = "Reference";
            ColumnRefer.Width = 150;
            ColumnRefer.DataPropertyName = "Refer";
            ColumnRefer.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnRefer.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //ColumnRefer.Visible = false;
            ColumnRefer.ReadOnly = false;
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

        private void showreference()
        {
            dgvSearch.DataSource = null;
            dgvSearch.Columns.Clear();
            string sql;
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            sql = "SELECT Reference FROM tblMain1 WHERE Voucher = '" + cboVoucher.Text + "' AND Reference like '%' + '" + txtSearch.Text + "' + '%' AND Void=0 ORDER BY TDate DESC";
            da = new SqlDataAdapter(sql, myconnection);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
            da.SelectCommand.CommandTimeout = 600;
            dataTable = new DataTable();
            da.Fill(dataTable);
            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;

            //Adding  Reference TextBox
            DataGridViewTextBoxColumn ColumnReference = new DataGridViewTextBoxColumn();
            ColumnReference.HeaderText = "Reference";
            ColumnReference.Width = 150;
            ColumnReference.DataPropertyName = "Reference";
            ColumnReference.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnReference.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //ColumnReference.Visible = false;
            ColumnReference.ReadOnly = true;
            dgvSearch.Columns.Add(ColumnReference);

            //Setting Data Source for DataGridView
            dgvSearch.DataSource = bindingSource;
            //            dgv1.AutoResizeColumns();
            //            dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            myconnection.Close();

        }
        private void showtblMain2()
        {
            string sql = null;
            dgv2.DataSource = null;
            dgv2.Columns.Clear();
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);

            if (cboVoucher.Text == "TF")
            {
                sql = "SELECT StockNumber, Item, Qty, Qty AS Qty, UM,  UP, ActDisct, PDisct, 0.00 AS VAT, ((Qty * UP) - (ActDisct+PDisct)) AS Total, Cost FROM ViewTF WHERE Reference = '" + txtSearch.Text + "' ";
            }
            else if (cboVoucher.Text == "CS")
            {
                sql = "SELECT StockNumber, Item, Out AS Qty, Out AS Qty1, UnitM AS UM,  UP, ActDisct, PDisct, VAT, GrossAmt AS Total, Cost FROM ViewCS WHERE Reference = '" + txtSearch.Text + "' AND Voucher = '" + cboVoucher.Text + "' ";
            }
            else if (cboVoucher.Text == "CI")
            {
                sql = "SELECT StockNumber, Item, Out AS Qty, Out AS Qty1, UM,  UP, ActDisct, PDisct, VAT, ((Out * UP) - (ActDisct+PDisct)) AS Total, Cost FROM ViewCI WHERE Reference = '" + txtSearch.Text + "' AND Voucher = '" + cboVoucher.Text + "' ";
            }
            else if (cboVoucher.Text == "PD")
            {
                sql = "SELECT StockNumber, Item, [In] AS Qty, [In] AS Qty1, UM,  UP, ActDisct, PDisct, VAT, (([In] * UP) - (ActDisct+PDisct)) AS Total, Cost FROM ViewPD WHERE Reference = '" + txtSearch.Text + "' AND Voucher = '" + cboVoucher.Text + "' ";
            }
            else if (cboVoucher.Text == "AS")
            {
                sql = "SELECT StockNumber, Item, Qty, (ChickIn - ChickOut) AS Qty1, UM,  UP, 0.00 AS ActDisct, 0.00 AS PDisct, 0.00 AS VAT, (Qty * UP) AS Total, Cost FROM ViewAS WHERE Reference = '" + txtSearch.Text + "' AND Voucher = '" + cboVoucher.Text + "' ";
            }
            else if (cboVoucher.Text == "RS")
            {
                sql = "SELECT StockNumber, Item, [In] AS Qty, [In] AS Qty1, UM,  UP, ActDisct, PDisct, VAT, (([In] * UP) - (ActDisct+PDisct)) AS Total, Cost FROM viewRS WHERE Reference = '" + txtSearch.Text + "' AND Voucher = '" + cboVoucher.Text + "' ";
            }

            da = new SqlDataAdapter(sql, myconnection);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
            da.SelectCommand.CommandTimeout = 600;
            dataTable = new DataTable();
            da.Fill(dataTable);
            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;

            DataGridViewTextBoxColumn ColumnStockNumber = new DataGridViewTextBoxColumn();
            ColumnStockNumber.HeaderText = "StockNumber";
            ColumnStockNumber.Width = 120;
            ColumnStockNumber.DataPropertyName = "StockNumber";
            ColumnStockNumber.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnStockNumber.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnStockNumber.ReadOnly = true;
            dgv2.Columns.Add(ColumnStockNumber);

            DataGridViewTextBoxColumn ColumnIB = new DataGridViewTextBoxColumn();
            ColumnIB.HeaderText = "Item";
            ColumnIB.Width = 120;
            ColumnIB.DataPropertyName = "Item";
            ColumnIB.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnIB.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnIB.ReadOnly = true;
            dgv2.Columns.Add(ColumnIB);

            DataGridViewTextBoxColumn ColumnQty = new DataGridViewTextBoxColumn();
            ColumnQty.HeaderText = "Qty";
            ColumnQty.Width = 80;
            ColumnQty.DataPropertyName = "Qty1";
            ColumnQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnQty.ReadOnly = true;
            dgv2.Columns.Add(ColumnQty);

            DataGridViewTextBoxColumn ColumnQty1 = new DataGridViewTextBoxColumn();
            ColumnQty1.HeaderText = "Weight";
            ColumnQty1.Width = 80;
            ColumnQty1.DataPropertyName = "Qty";
            ColumnQty1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnQty1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnQty1.ReadOnly = true;
            dgv2.Columns.Add(ColumnQty1);


            DataGridViewTextBoxColumn ColumnUM = new DataGridViewTextBoxColumn();
            ColumnUM.HeaderText = "Unit Measure";
            ColumnUM.Width = 80;
            ColumnUM.DataPropertyName = "UM";
            ColumnUM.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnUM.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnUM.ReadOnly = true;
            dgv2.Columns.Add(ColumnUM);

            DataGridViewTextBoxColumn ColumnUP = new DataGridViewTextBoxColumn();
            ColumnUP.HeaderText = "Unit Price";
            ColumnUP.Width = 100;
            ColumnUP.DataPropertyName = "UP";
            ColumnUP.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnUP.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnUP.ReadOnly = true;
            dgv2.Columns.Add(ColumnUP);

            DataGridViewTextBoxColumn ColumnActDisct = new DataGridViewTextBoxColumn();
            ColumnActDisct.HeaderText = "%Disct Value";
            ColumnActDisct.Width = 100;
            ColumnActDisct.DataPropertyName = "ActDisct";
            ColumnActDisct.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnActDisct.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnActDisct.ReadOnly = true;
            dgv2.Columns.Add(ColumnActDisct);

            DataGridViewTextBoxColumn ColumnPDisct = new DataGridViewTextBoxColumn();
            ColumnPDisct.HeaderText = "Peso Disct";
            ColumnPDisct.Width = 100;
            ColumnPDisct.DataPropertyName = "PDisct";
            ColumnPDisct.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnPDisct.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnPDisct.ReadOnly = true;
            dgv2.Columns.Add(ColumnPDisct);

            DataGridViewTextBoxColumn ColumnVAT = new DataGridViewTextBoxColumn();
            ColumnVAT.HeaderText = "VAT";
            ColumnVAT.Width = 100;
            ColumnVAT.DataPropertyName = "VAT";
            ColumnVAT.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnVAT.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnVAT.ReadOnly = true;
            dgv2.Columns.Add(ColumnVAT);

            DataGridViewTextBoxColumn ColumnTotal = new DataGridViewTextBoxColumn();
            ColumnTotal.HeaderText = "Total";
            ColumnTotal.Width = 100;
            ColumnTotal.DataPropertyName = "Total";
            ColumnTotal.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnTotal.ReadOnly = true;
            dgv2.Columns.Add(ColumnTotal);

            DataGridViewTextBoxColumn ColumnCost = new DataGridViewTextBoxColumn();
            ColumnCost.HeaderText = "Cost";
            ColumnCost.Width = 100;
            ColumnCost.DataPropertyName = "Cost";
            ColumnCost.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnCost.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnCost.ReadOnly = true;
            dgv2.Columns.Add(ColumnCost);
            dgv2.DataSource = bindingSource;

            dgv2.Columns[2].DefaultCellStyle.Format = "N2";
            dgv2.Columns[3].DefaultCellStyle.Format = "N2";
            dgv2.Columns[5].DefaultCellStyle.Format = "N2";
            dgv2.Columns[6].DefaultCellStyle.Format = "N2";
            dgv2.Columns[7].DefaultCellStyle.Format = "N2";
            dgv2.Columns[9].DefaultCellStyle.Format = "N2";
            dgv2.Columns[10].DefaultCellStyle.Format = "N2";

            myconnection.Close();
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dgvSearch_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvSearch.Rows[e.RowIndex];
            txtSearch.Text = row.Cells[0].FormattedValue.ToString();
        }

        private void dgvSearch_DoubleClick(object sender, EventArgs e)
        {
            showdata();
            dgv1.DataSource = null;
            dgv1.Columns.Clear();
            //cboVoucher.Enabled = false;
            if (cboVoucher.Text == "RV")
            {
                txtVDate.Enabled = true;
                label8.Visible = true;
                txtVDate.Visible = true;
                cboPC.Enabled = true;
            }
            else
            {
                txtTDate.Enabled = false;
                label8.Visible = false;
                txtVDate.Visible = false;
                cboPC.Enabled = false;
            }


            //-----------------------------------------------------//


            if (cboVoucher.Text == "APV" || cboVoucher.Text == "ARV" || cboVoucher.Text == "RV" || cboVoucher.Text == "CV" || cboVoucher.Text == "OR" || cboVoucher.Text == "JV")
            { }
            else
            {
                showWarehouse();
            }

            if (cboVoucher.Text == "TF")
            {
                showtblMain2();
                //showsearchdata();
                //dgv1total();
            }
            else if (cboVoucher.Text == "CS" || cboVoucher.Text == "CI" || cboVoucher.Text == "AS" || cboVoucher.Text == "PD" || cboVoucher.Text == "RS")
            {
                showtblMain2();
                showsearchdata();
                dgv1total();
            }
            else
            {
                showsearchdata();
                dgv1total();
            }

        }

        private void showWarehouse()
        {
            string selectSQL;
            selectSQL = "A";

            selectSQL = "SELECT Warehouse, Reference FROM ViewWH ";
            selectSQL += "WHERE Reference='" + txtSearch.Text + "'";

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

                txtWarehouse.Text = dr["Warehouse"].ToString();

                myconnection.Close();
                dr.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Warehouse cannot be found", "GL");
                cboVoucher.Focus();
            }
            finally
            {
                myconnection.Close();
            }
        }

        private void cboVoucher_Validating(object sender, CancelEventArgs e)
        {
            //dgvSearch.DataSource = null;
            //dgvSearch.Columns.Clear();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (new ClsValidation().emptytxt(cboVoucher.Text) || (new ClsValidation().emptytxt(txtDocNum.Text)))
            {
                MessageBox.Show("Please complete the process", "GL");
                cboVoucher.Focus();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to delete this transaction?", "GL", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    string sqldel1 = "A";
                    string sqldel2 = "A";

                    if (cboVoucher.Text == "APV")
                    {
                        sqldel1 = "DELETE FROM tblMain3 WHERE IC='APV'+'" + txtDocNum.Text + "'";
                        sqldel2 = "DELETE FROM tblMain2 WHERE IC='APV'+'" + txtDocNum.Text + "'";
                    }
                    else if (cboVoucher.Text == "ARV")
                    {
                        sqldel1 = "DELETE FROM tblMain3 WHERE IC='ARV'+'" + txtDocNum.Text + "'";
                        sqldel2 = "DELETE FROM tblMain2 WHERE IC='ARV'+'" + txtDocNum.Text + "'";
                    }
                    else if (cboVoucher.Text == "JV")
                    {
                        sqldel1 = "DELETE FROM tblMain3 WHERE IC='JV'+'" + txtDocNum.Text + "'";
                        sqldel2 = "DELETE FROM tblMain2 WHERE IC='JV'+'" + txtDocNum.Text + "'";
                    }
                    else if (cboVoucher.Text == "CV")
                    {
                        sqldel1 = "DELETE FROM tblMain3 WHERE IC='CV'+'" + txtDocNum.Text + "'";
                        sqldel2 = "DELETE FROM tblMain2 WHERE IC='CV'+'" + txtDocNum.Text + "'";
                    }
                    else if (cboVoucher.Text == "OR")
                    {
                        sqldel1 = "DELETE FROM tblMain3 WHERE IC='OR'+'" + txtDocNum.Text + "'";
                        sqldel2 = "DELETE FROM tblMain2 WHERE IC='OR'+'" + txtDocNum.Text + "'";
                    }
                    else if (cboVoucher.Text == "CS")
                    {
                        sqldel1 = "DELETE FROM tblMain3 WHERE IC='CS'+'" + txtDocNum.Text + "'";
                        sqldel2 = "DELETE FROM tblMain2 WHERE IC='CS'+'" + txtDocNum.Text + "'";
                    }
                    else if (cboVoucher.Text == "CI")
                    {
                        sqldel1 = "DELETE FROM tblMain3 WHERE IC='CI'+'" + txtDocNum.Text + "'";
                        sqldel2 = "DELETE FROM tblMain2 WHERE IC='CI'+'" + txtDocNum.Text + "'";
                    }
                    else if (cboVoucher.Text == "RS")
                    {
                        sqldel1 = "DELETE FROM tblMain3 WHERE IC='RS'+'" + txtDocNum.Text + "'";
                        sqldel2 = "DELETE FROM tblMain2 WHERE IC='RS'+'" + txtDocNum.Text + "'";
                    }
                    else if (cboVoucher.Text == "PD")
                    {
                        sqldel1 = "DELETE FROM tblMain3 WHERE IC='PD'+'" + txtDocNum.Text + "'";
                        sqldel2 = "DELETE FROM tblMain2 WHERE IC='PD'+'" + txtDocNum.Text + "'";
                    }
                    else if (cboVoucher.Text == "AS")
                    {
                        sqldel1 = "DELETE FROM tblMain3 WHERE IC='AS'+'" + txtDocNum.Text + "'";
                        sqldel2 = "DELETE FROM tblMain2 WHERE IC='AS'+'" + txtDocNum.Text + "'";
                    }


                    ClsGetConnection1.ClsGetConMSSQL();
                    myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                    myconnection.Open();
                    mycommand = new SqlCommand(sqldel1, myconnection);
                    mycommand.CommandTimeout = 600;
                    int nmsg1 = mycommand.ExecuteNonQuery();

                    mycommand = new SqlCommand(sqldel2, myconnection);
                    mycommand.CommandTimeout = 600;
                    int nmsg2 = mycommand.ExecuteNonQuery();

                    myconnection.Close();
                    showsearchdata();
                }
            }
        }

    }
}
