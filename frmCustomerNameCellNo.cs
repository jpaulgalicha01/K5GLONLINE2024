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
    public partial class frmCustomerNameCellNo : Form
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
        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();
        ClsBuildVoucherComboBox ClsBuildVoucherComboBox1 = new ClsBuildVoucherComboBox();
        ClsBuildEntryComboBox ClsBuildEntryComboBox1 = new ClsBuildEntryComboBox();
        private string strSearchData;
        string strShowData = "1"; //if ShowData is 0 then False else true
        public frmCustomerNameCellNo()
        {
            InitializeComponent();
            cboSearchCriteria.DisplayMember = "Text";
            cboSearchCriteria.ValueMember = "Value";
            cboSearchCriteria.SelectedValue = "05";
            var items = new[]
            {
                //new { Text = "Channel", Value = "03" },
                //new { Text = "Area", Value = "04" },
                new { Text = "Salesman", Value = "05" },
                //new { Text = "Region", Value = "06" },
            };

            cboSearchCriteria.DataSource = items;
        }
        private void buildcboASMCode()
        {
            cboVariousCombo.DataSource = null;
            ClsBuildVoucherComboBox1.ARLSLS.Clear();
            ClsBuildVoucherComboBox1.ClsBuildSalesman();
            this.cboVariousCombo.DataSource = (ClsBuildVoucherComboBox1.ARLSLS);
            this.cboVariousCombo.DisplayMember = "Display";
            this.cboVariousCombo.ValueMember = "Value";
        }
        private void buildcboChannelCode()
        {
            cboVariousCombo.DataSource = null;
            ClsBuildEntryComboBox1.ARChannelCode.Clear();
            ClsBuildEntryComboBox1.ClsBuildChannelCode();
            this.cboVariousCombo.DataSource = (ClsBuildEntryComboBox1.ARChannelCode);
            this.cboVariousCombo.DisplayMember = "Display";
            this.cboVariousCombo.ValueMember = "Value";
        }
        private void buildcboRegCode()
        {
            cboVariousCombo.DataSource = null;
            ClsBuildEntryComboBox1.ARRegCode.Clear();
            ClsBuildEntryComboBox1.ClsBuildRegCode();
            this.cboVariousCombo.DataSource = (ClsBuildEntryComboBox1.ARRegCode);
            this.cboVariousCombo.DisplayMember = "Display";
            this.cboVariousCombo.ValueMember = "Value";
        }
       
        private void buildcboGACode()
        {
            cboVariousCombo.DataSource = null;
            ClsBuildEntryComboBox1.ARGACode.Clear();
            ClsBuildEntryComboBox1.ClsBuildGACode();
            this.cboVariousCombo.DataSource = (ClsBuildEntryComboBox1.ARGACode);
            this.cboVariousCombo.DisplayMember = "Display";
            this.cboVariousCombo.ValueMember = "Value";
        }
        private void frmCustomerNameCellNo_Load(object sender, EventArgs e)
        {
            ClsPermission1.ClsObjects(this.Text);
            if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
            {
                MessageBox.Show("You do not have necessary permission to open this file", "GL");
                this.Close();
            }
            else
            {
                LoadData();
            }
 
        }

        private void LoadData()
        {
            dgv1.DataSource = null;
            dgv1.Columns.Clear();

            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);

            //sql = "SELECT ControlNo, CustName, CellphoneNumber, CC, GA, SLS, ";
            //sql += "RegCode, 1 As ShowData ";
            //sql += "FROM tblCustomer WHERE NType ='C'";  
            
            sql = "SELECT ControlNo, CustName, CellphoneNumber, SendText, SendOR, SendCI, SendCS, CC, GA, SLS, ";
            sql += "RegCode, 1 As ShowData ";
            sql += "FROM tblCustomer WHERE NType ='C'";

            da = new SqlDataAdapter(sql, myconnection);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);

            dataTable = new DataTable();
            da.Fill(dataTable);
            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;

            //Channel Data Source
            string selectQueryStringtblChannel = "SELECT CC, Description FROM tblChannel ORDER BY Description";
            SqlDataAdapter sqlDataAdaptertblChannel = new SqlDataAdapter(selectQueryStringtblChannel, myconnection);
            SqlCommandBuilder sqlCommandBuildertblChannel = new SqlCommandBuilder(sqlDataAdaptertblChannel);
            DataTable dataTabletblChannel = new DataTable();
            sqlDataAdaptertblChannel.Fill(dataTabletblChannel);
            BindingSource bindingSourcetblChannel = new BindingSource();
            bindingSourcetblChannel.DataSource = dataTabletblChannel;

            //GeogArea Data Source
            string selectQueryStringtblGeogArea = "SELECT GA, GeogArea FROM tblGA ORDER BY GeogArea";
            SqlDataAdapter sqlDataAdaptertblGeogArea = new SqlDataAdapter(selectQueryStringtblGeogArea, myconnection);
            SqlCommandBuilder sqlCommandBuildertblGeogArea = new SqlCommandBuilder(sqlDataAdaptertblGeogArea);
            DataTable dataTabletblGeogArea = new DataTable();
            sqlDataAdaptertblGeogArea.Fill(dataTabletblGeogArea);
            BindingSource bindingSourcetblGeogArea = new BindingSource();
            bindingSourcetblGeogArea.DataSource = dataTabletblGeogArea;

            //Salesman Data Source
            string selectQueryStringtblSalesman = "SELECT SLS, Names FROM tblSalesman ORDER BY Names";
            SqlDataAdapter sqlDataAdaptertblSalesman = new SqlDataAdapter(selectQueryStringtblSalesman, myconnection);
            SqlCommandBuilder sqlCommandBuildertblSalesman = new SqlCommandBuilder(sqlDataAdaptertblSalesman);
            DataTable dataTabletblSalesman = new DataTable();
            sqlDataAdaptertblSalesman.Fill(dataTabletblSalesman);
            BindingSource bindingSourcetblSalesman = new BindingSource();
            bindingSourcetblSalesman.DataSource = dataTabletblSalesman;

            string selectQueryStringtblRegion = "SELECT RegCode, RegName FROM tblRegion ORDER BY RegName";
            SqlDataAdapter sqlDataAdaptertblRegion = new SqlDataAdapter(selectQueryStringtblRegion, myconnection);
            SqlCommandBuilder sqlCommandBuildertblRegion = new SqlCommandBuilder(sqlDataAdaptertblRegion);
            DataTable dataTabletblRegion = new DataTable();
            sqlDataAdaptertblRegion.Fill(dataTabletblRegion);
            BindingSource bindingSourcetblRegion = new BindingSource();
            bindingSourcetblRegion.DataSource = dataTabletblRegion;

            //Adding  ControlNo TextBox
            DataGridViewTextBoxColumn ColumnControlNo = new DataGridViewTextBoxColumn();
            ColumnControlNo.HeaderText = "Code";
            ColumnControlNo.Width = 50;
            ColumnControlNo.DataPropertyName = "ControlNo";
            ColumnControlNo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnControlNo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnControlNo.Visible = false;
            dgv1.Columns.Add(ColumnControlNo);

            //Adding  CustName TextBox
            DataGridViewTextBoxColumn ColumnCustName = new DataGridViewTextBoxColumn();
            ColumnCustName.HeaderText = "Name";
            ColumnCustName.Width = 300;
            ColumnCustName.DataPropertyName = "CustName";
            ColumnCustName.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnCustName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnCustName.ReadOnly = true;
            dgv1.Columns.Add(ColumnCustName);

            //Adding  ContactNo TextBox
            DataGridViewTextBoxColumn ColumnContactNo = new DataGridViewTextBoxColumn();
            ColumnContactNo.HeaderText = "Cell Number";
            ColumnContactNo.Width = 100;
            ColumnContactNo.DataPropertyName = "CellphoneNumber";
            ColumnContactNo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnContactNo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv1.Columns.Add(ColumnContactNo);

            DataGridViewCheckBoxColumn ColumnSendText = new DataGridViewCheckBoxColumn();
            ColumnSendText.HeaderText = "Cell SendText";
            ColumnSendText.Width = 80;
            ColumnSendText.DataPropertyName = "SendText";
            ColumnSendText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnSendText.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv1.Columns.Add(ColumnSendText);
            
            DataGridViewCheckBoxColumn ColumnSendOR = new DataGridViewCheckBoxColumn();
            ColumnSendOR.HeaderText = "Cell SendOR";
            ColumnSendOR.Width = 80;
            ColumnSendOR.DataPropertyName = "SendOR";
            ColumnSendOR.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnSendOR.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv1.Columns.Add(ColumnSendOR);
            
            DataGridViewCheckBoxColumn ColumnSendCI = new DataGridViewCheckBoxColumn();
            ColumnSendCI.HeaderText = "SendCI";
            ColumnSendCI.Width = 80;
            ColumnSendCI.DataPropertyName = "SendCI";
            ColumnSendCI.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnSendCI.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv1.Columns.Add(ColumnSendCI);
            
            DataGridViewCheckBoxColumn ColumnSendCS = new DataGridViewCheckBoxColumn();
            ColumnSendCS.HeaderText = "SendCS";
            ColumnSendCS.Width = 80;
            ColumnSendCS.DataPropertyName = "SendCS";
            ColumnSendCS.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnSendCS.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv1.Columns.Add(ColumnSendCS);

            //Adding  ChannelCode Combo
            DataGridViewComboBoxColumn ColumnChannelCode = new DataGridViewComboBoxColumn();
            ColumnChannelCode.DataPropertyName = "CC";
            ColumnChannelCode.HeaderText = "Channel";
            ColumnChannelCode.Width = 200;
            ColumnChannelCode.DataSource = bindingSourcetblChannel;
            ColumnChannelCode.ValueMember = "CC";
            ColumnChannelCode.DisplayMember = "Description";
            ColumnChannelCode.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnChannelCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnChannelCode.ReadOnly = true;
            dgv1.Columns.Add(ColumnChannelCode);

            //Adding  GA Combo
            DataGridViewComboBoxColumn ColumnGACode = new DataGridViewComboBoxColumn();
            ColumnGACode.DataPropertyName = "GA";
            ColumnGACode.HeaderText = "Area";
            ColumnGACode.Width = 200;
            ColumnGACode.DataSource = bindingSourcetblGeogArea;
            ColumnGACode.ValueMember = "GA";
            ColumnGACode.DisplayMember = "GeogArea";
            ColumnGACode.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnGACode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnGACode.ReadOnly = true;
            dgv1.Columns.Add(ColumnGACode);

            //Adding  SMCode Combo
            DataGridViewComboBoxColumn ColumnSMCode = new DataGridViewComboBoxColumn();
            ColumnSMCode.DataPropertyName = "SLS";
            ColumnSMCode.HeaderText = "Salesman";
            ColumnSMCode.Width = 200;
            ColumnSMCode.DataSource = bindingSourcetblSalesman;
            ColumnSMCode.ValueMember = "SLS";
            ColumnSMCode.DisplayMember = "Names";
            ColumnSMCode.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnSMCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnSMCode.ReadOnly = true;
            dgv1.Columns.Add(ColumnSMCode);

            DataGridViewComboBoxColumn ColumnRegCode = new DataGridViewComboBoxColumn();
            ColumnRegCode.DataPropertyName = "RegCode";
            ColumnRegCode.HeaderText = "Region";
            ColumnRegCode.Width = 200;
            ColumnRegCode.DataSource = bindingSourcetblRegion;
            ColumnRegCode.ValueMember = "RegCode";
            ColumnRegCode.DisplayMember = "RegName";
            ColumnRegCode.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnRegCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnRegCode.ReadOnly = true;
            dgv1.Columns.Add(ColumnRegCode);
            
            //Adding  ShowData TextBox
            DataGridViewTextBoxColumn ColumnShowData = new DataGridViewTextBoxColumn();
            ColumnShowData.HeaderText = "ShowData";
            ColumnShowData.Width = 80;
            ColumnShowData.DataPropertyName = "ShowData";
            ColumnShowData.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnShowData.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnShowData.Visible = false;
            dgv1.Columns.Add(ColumnShowData);

            dgv1.Columns[2].Name = "CellphoneNumber";

            //Setting Data Source for DataGridView
            dgv1.DataSource = bindingSource;
            //dgv1.AutoResizeColumns();
            //dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            myconnection.Close();
            this.WindowState = FormWindowState.Maximized;
            dgv1.AllowUserToAddRows = false;
            refreshdgv1();
        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                da.Update(dataTable);
                MessageBox.Show("Saved", "GL");

            }
            catch (Exception exceptionObj)
            {
                MessageBox.Show(exceptionObj.Message.ToString());
            }

        }

        private void cboVariousCombo_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().emptytxt(cboVariousCombo.Text))
            {
            }
            else if (cboVariousCombo.Text != null && cboVariousCombo.SelectedValue == null)
            {
                MessageBox.Show(cboVariousCombo.Text + " " + "Not Found", "K5");
                cboVariousCombo.Focus();
            }
        }
        private void PrivateSearch(String strcboSearchCriteria)
        {
            switch (strcboSearchCriteria)
            {
                case "01":
                    
                    break;
                case "02":
                    
                    break;
                case "03":
                    buildcboChannelCode();
                    break;
                case "04":
                    buildcboGACode();
                    break;
                case "05":
                    buildcboASMCode();
                    break;
                case "06":
                    buildcboRegCode();
                    break;
            }
            cboVariousCombo.SelectedValue = "";
        }
        private void EliminateData(string strcboSearchCriteria)
        {
            DataGridViewRow row = null;
            for (int x = 0; x < dgv1.Rows.Count; x++)
            {
                row = dgv1.Rows[x];
                switch (strcboSearchCriteria)
                {
                    case "01":
                        //strSearchData = row.Cells[15].Value.ToString();
                        break;
                    case "02":
                        //strSearchData = row.Cells[16].Value.ToString();
                        break;
                    case "03":
                        strSearchData = row.Cells[6].Value.ToString();
                        break;
                    case "04":
                        strSearchData = row.Cells[7].Value.ToString();
                        break;
                    case "05":
                        strSearchData = row.Cells[5].Value.ToString();
                        break;
                    case "06":
                        strSearchData = row.Cells[14].Value.ToString();
                        break;
                    case "07":
                        strSearchData = row.Cells[15].Value.ToString();
                        break;

                    default:
                        break;
                }
                if (cboVariousCombo.SelectedValue.ToString() != strSearchData)
                {
                    row.Cells[7].Value = "0";
                }

            }
        }
        
        private void btnView_Click(object sender, EventArgs e)
        {
            EliminateData(cboSearchCriteria.SelectedValue.ToString());

            CheckDataGrid(cboSearchCriteria.SelectedValue.ToString());
            while (strShowData == "0")
            {
                EliminateData(cboSearchCriteria.SelectedValue.ToString());
                refreshdgv1();
                strShowData = "1";
                CheckDataGrid(cboSearchCriteria.SelectedValue.ToString());
            }
        }

        private void btnLoadAll_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cboSearchCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrivateSearch(cboSearchCriteria.SelectedValue.ToString());     
        }

        
        
        
        //private void RemoveToDataGrid()
        //{
        //    DataGridViewRow row = null;
        //    for (int x = 0; x < dgv1.Rows.Count; x++)
        //    {
        //        row = dgv1.Rows[x];
        //        string stringElimData = row.Cells[17].Value.ToString();
        //        if (stringElimData.ToString() == "0")
        //        {
        //            dgv1.Rows.RemoveAt(x);
        //        }
        //    }
        //}

        private void CheckDataGrid(string strcboSearchCriteria)
        {
            DataGridViewRow row = null;
            for (int x = 0; x < dgv1.Rows.Count; x++)
            {
                row = dgv1.Rows[x];
                switch (strcboSearchCriteria)
                {
                    case "01":
                        //strSearchData = row.Cells[15].Value.ToString();
                        break;
                    case "02":
                        //strSearchData = row.Cells[16].Value.ToString();
                        break;
                    case "03":
                        strSearchData = row.Cells[6].Value.ToString();
                        break;
                    case "04":
                        strSearchData = row.Cells[7].Value.ToString();
                        break;
                    case "05":
                        strSearchData = row.Cells[5].Value.ToString();
                        break;
                    case "06":
                        strSearchData = row.Cells[14].Value.ToString();
                        break;
                    case "07":
                        strSearchData = row.Cells[15].Value.ToString();
                        break;

                    default:
                        break;
                }
                if (cboVariousCombo.SelectedValue.ToString() != strSearchData)
                {
                    strShowData = "0";
                    break;
                    
                }
               
            }
        }

        private void nextfieldenter2(object sender, KeyEventArgs e)
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
            dgv1.DataSource = bs;
            bs.Filter = "ShowData = '1'";
            dgv1.DataSource = bs;
        }

        private void dgv1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridViewRow row = dgv1.Rows[e.RowIndex];
            {
                if (e.ColumnIndex == dgv1.Columns["CellphoneNumber"].Index)
                {
                    if (String.IsNullOrEmpty(e.FormattedValue.ToString()))// &&
                    //dgv1[e.ColumnIndex, e.RowIndex].IsInEditMode)
                    {
                        e.Cancel = true;
                        MessageBox.Show("Empty", "GL");
                    }
                    else if (new ClsValidation().ValPhoneNo(e.FormattedValue.ToString()))
                    {
                        e.Cancel = true;
                        MessageBox.Show("Cellphone number error", "GL");
                    }
                }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //DataView dv = DTTempTable.DefaultView;
            BindingSource bs = new BindingSource();
            bs.DataSource = dgv1.DataSource;
            dgv1.DataSource = bs;
            bs.Filter = "CustName LIKE '%" + txtSearch.Text + "%'";
            dgv1.DataSource = bs;
        }
    }
}
