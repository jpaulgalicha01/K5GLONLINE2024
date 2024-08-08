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
    public partial class frmCustomerNameEdit : Form
    {
        private SqlDataAdapter da;
        private DataTable dataTable = null;
        private SqlConnection myconnection;
        private BindingSource bindingSource = null;
        BindingSource bsource = new BindingSource();
        //   DataSet ds = null;
        string sql;
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        public static Button glblbtnsave;
        public static DataGridView glbldgv1;
        public string origData { get; set; }

        public frmCustomerNameEdit()
        {
            InitializeComponent();
        }

        private void frmNameEdit_Load(object sender, EventArgs e)
        {
            LoadData();
            glblbtnsave = btnsave;
            glbldgv1 = dgv1;
        }
    
        private void LoadData()
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);

            sql = "SELECT ControlNo, CustName, ContactNo, Address, BusinessAddress, BusinessType, CC, GA, SLS, ";
            sql += "Term, CreditLimit, ContactPerson, TIN, SPO, RegCode, OTCode, SFAAccountNo, SFAAccountNoPoultry, BRID, ";
            sql += "UserAdd as UserCodeAdd, 0 AS UserEdit, IndicatorCode, ExternalID ";
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

            //Indicator Data Source
            string selectQueryStringtblIndicator = "SELECT IndicatorCode, Indicator FROM tblIndicator ORDER BY Indicator";
            SqlDataAdapter sqlDataAdaptertblIndicator = new SqlDataAdapter(selectQueryStringtblIndicator, myconnection);
            SqlCommandBuilder sqlCommandBuildertblIndicator = new SqlCommandBuilder(sqlDataAdaptertblIndicator);
            DataTable dataTabletblIndicator = new DataTable();
            sqlDataAdaptertblIndicator.Fill(dataTabletblIndicator);
            BindingSource bindingSourcetblIndicator = new BindingSource();
            bindingSourcetblIndicator.DataSource = dataTabletblIndicator;
            
            //string selectQueryStringtblUser = "SELECT UserCode, UserName FROM tblUser";
            //SqlDataAdapter sqlDataAdaptertblUser = new SqlDataAdapter(selectQueryStringtblUser, myconnection);
            //SqlCommandBuilder sqlCommandBuildertblUser = new SqlCommandBuilder(sqlDataAdaptertblUser);
            //DataTable dataTabletblUser = new DataTable();
            //sqlDataAdaptertblUser.Fill(dataTabletblUser);
            //BindingSource bindingSourcetblUser = new BindingSource();
            //bindingSourcetblUser.DataSource = dataTabletblUser;
            
            string selectQueryStringtblRegion = "SELECT RegCode, RegName FROM tblRegion ORDER BY RegName";
            SqlDataAdapter sqlDataAdaptertblRegion = new SqlDataAdapter(selectQueryStringtblRegion, myconnection);
            SqlCommandBuilder sqlCommandBuildertblRegion = new SqlCommandBuilder(sqlDataAdaptertblRegion);
            DataTable dataTabletblRegion = new DataTable();
            sqlDataAdaptertblRegion.Fill(dataTabletblRegion);
            BindingSource bindingSourcetblRegion = new BindingSource();
            bindingSourcetblRegion.DataSource = dataTabletblRegion;

            string selectQueryStringtblOT = "SELECT OTCode, OTDesc FROM tblOutletType ORDER BY OTDesc";
            SqlDataAdapter sqlDataAdaptertblOT = new SqlDataAdapter(selectQueryStringtblOT, myconnection);
            SqlCommandBuilder sqlCommandBuildertblOT = new SqlCommandBuilder(sqlDataAdaptertblOT);
            DataTable dataTabletblOT = new DataTable();
            sqlDataAdaptertblOT.Fill(dataTabletblOT);
            BindingSource bindingSourcetblOT = new BindingSource();
            bindingSourcetblOT.DataSource = dataTabletblOT;

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

            //SPOption Data Source
            string selectQueryStringtblSPOption = "SELECT SPCode, SPDesc FROM tblSPOption ORDER BY SPDesc";
            SqlDataAdapter sqlDataAdaptertblSPOption = new SqlDataAdapter(selectQueryStringtblSPOption, myconnection);
            SqlCommandBuilder sqlCommandBuildertblSPOption = new SqlCommandBuilder(sqlDataAdaptertblSPOption);
            DataTable dataTabletblSPOption = new DataTable();
            sqlDataAdaptertblSPOption.Fill(dataTabletblSPOption);
            BindingSource bindingSourcetblSPOption = new BindingSource();
            bindingSourcetblSPOption.DataSource = dataTabletblSPOption;

            //Adding  ControlNo TextBox
            DataGridViewTextBoxColumn ColumnControlNo = new DataGridViewTextBoxColumn();
            ColumnControlNo.HeaderText = "Code";
            ColumnControlNo.Width = 50;
            ColumnControlNo.DataPropertyName = "ControlNo";
            ColumnControlNo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnControlNo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnControlNo.Visible = true;
            ColumnControlNo.ReadOnly = true;
            dgv1.Columns.Add(ColumnControlNo);

            //Adding  CustName TextBox
            DataGridViewTextBoxColumn ColumnCustName = new DataGridViewTextBoxColumn();
            ColumnCustName.HeaderText = "Name";
            ColumnCustName.Width = 200;
            ColumnCustName.DataPropertyName = "CustName";
            ColumnCustName.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnCustName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv1.Columns.Add(ColumnCustName);

            //Adding  ContactNo TextBox
            DataGridViewTextBoxColumn ColumnContactNo = new DataGridViewTextBoxColumn();
            ColumnContactNo.HeaderText = "Contact Number";
            ColumnContactNo.Width = 150;
            ColumnContactNo.DataPropertyName = "ContactNo";
            ColumnContactNo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnContactNo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv1.Columns.Add(ColumnContactNo);

            //Adding  Address TextBox
            DataGridViewTextBoxColumn ColumnAddress = new DataGridViewTextBoxColumn();
            ColumnAddress.HeaderText = "Address";
            ColumnAddress.Width = 250;
            ColumnAddress.DataPropertyName = "Address";
            ColumnAddress.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnAddress.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv1.Columns.Add(ColumnAddress);

            DataGridViewTextBoxColumn ColumnBusAddress = new DataGridViewTextBoxColumn();
            ColumnBusAddress.HeaderText = "Business Address";
            ColumnBusAddress.Width = 250;
            ColumnBusAddress.DataPropertyName = "BusinessAddress";
            ColumnBusAddress.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnBusAddress.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv1.Columns.Add(ColumnBusAddress);

            DataGridViewTextBoxColumn ColumnBusinessType = new DataGridViewTextBoxColumn();
            ColumnBusinessType.HeaderText = "Business Type";
            ColumnBusinessType.Width = 250;
            ColumnBusinessType.DataPropertyName = "BusinessType";
            ColumnBusinessType.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnBusinessType.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv1.Columns.Add(ColumnBusinessType);

            //Adding  CC Combo
            DataGridViewComboBoxColumn ColumnCC = new DataGridViewComboBoxColumn();
            ColumnCC.DataPropertyName = "CC";
            ColumnCC.HeaderText = "Channel";
            ColumnCC.Width = 120;
            ColumnCC.DataSource = bindingSourcetblChannel;
            ColumnCC.ValueMember = "CC";
            ColumnCC.DisplayMember = "Description";
            dgv1.Columns.Add(ColumnCC);

            //Adding  ChannelCode Combo
            DataGridViewComboBoxColumn ColumnGA = new DataGridViewComboBoxColumn();
            ColumnGA.DataPropertyName = "GA";
            ColumnGA.HeaderText = "Area";
            ColumnGA.Width = 120;
            ColumnGA.DataSource = bindingSourcetblGeogArea;
            ColumnGA.ValueMember = "GA";
            ColumnGA.DisplayMember = "GeogArea";
            dgv1.Columns.Add(ColumnGA);

            //Adding  SLS Combo
            DataGridViewComboBoxColumn ColumnSLS = new DataGridViewComboBoxColumn();
            ColumnSLS.DataPropertyName = "SLS";
            ColumnSLS.HeaderText = "Salesman";
            ColumnSLS.Width = 120;
            ColumnSLS.DataSource = bindingSourcetblSalesman;
            ColumnSLS.ValueMember = "SLS";
            ColumnSLS.DisplayMember = "Names";
            dgv1.Columns.Add(ColumnSLS);

            //Adding  Term TextBox
            DataGridViewTextBoxColumn ColumnTerm = new DataGridViewTextBoxColumn();
            ColumnTerm.HeaderText = "Term";
            ColumnTerm.Width = 80;
            ColumnTerm.DataPropertyName = "Term";
            ColumnTerm.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnTerm.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv1.Columns.Add(ColumnTerm);

            //Adding  CreditLimit TextBox
            DataGridViewTextBoxColumn ColumnCreditLimit = new DataGridViewTextBoxColumn();
            ColumnCreditLimit.HeaderText = "CreditLimit";
            ColumnCreditLimit.Width = 80;
            ColumnCreditLimit.DataPropertyName = "CreditLimit";
            ColumnCreditLimit.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnCreditLimit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv1.Columns.Add(ColumnCreditLimit);

            //Adding  ContactPerson TextBox
            DataGridViewTextBoxColumn ColumnContactPerson = new DataGridViewTextBoxColumn();
            ColumnContactPerson.HeaderText = "Contact Person";
            ColumnContactPerson.Width = 120;
            ColumnContactPerson.DataPropertyName = "ContactPerson";
            ColumnContactPerson.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnContactPerson.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv1.Columns.Add(ColumnContactPerson);

            //Adding  TIN TextBox
            DataGridViewTextBoxColumn ColumnTIN = new DataGridViewTextBoxColumn();
            ColumnTIN.HeaderText = "TIN";
            ColumnTIN.Width = 120;
            ColumnTIN.DataPropertyName = "TIN";
            ColumnTIN.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnTIN.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv1.Columns.Add(ColumnTIN);

            //Adding  SPO Combo
            DataGridViewComboBoxColumn ColumnSPO = new DataGridViewComboBoxColumn();
            ColumnSPO.DataPropertyName = "SPO";
            ColumnSPO.HeaderText = "SP Option";
            ColumnSPO.Width = 120;
            ColumnSPO.DataSource = bindingSourcetblSPOption;
            ColumnSPO.ValueMember = "SPCode";
            ColumnSPO.DisplayMember = "SPDesc";
            dgv1.Columns.Add(ColumnSPO);

            DataGridViewComboBoxColumn ColumnRegCode = new DataGridViewComboBoxColumn();
            ColumnRegCode.DataPropertyName = "RegCode";
            ColumnRegCode.HeaderText = "Region";
            ColumnRegCode.Width = 120;
            ColumnRegCode.DataSource = bindingSourcetblRegion;
            ColumnRegCode.ValueMember = "RegCode";
            ColumnRegCode.DisplayMember = "RegName";
            dgv1.Columns.Add(ColumnRegCode);

            DataGridViewComboBoxColumn ColumnOTCode = new DataGridViewComboBoxColumn();
            ColumnOTCode.DataPropertyName = "OTCode";
            ColumnOTCode.HeaderText = "Outlet";
            ColumnOTCode.Width = 120;
            ColumnOTCode.DataSource = bindingSourcetblOT;
            ColumnOTCode.ValueMember = "OTCode";
            ColumnOTCode.DisplayMember = "OTDesc";
            dgv1.Columns.Add(ColumnOTCode);

            DataGridViewTextBoxColumn ColumnSFAAccountNo = new DataGridViewTextBoxColumn();
            ColumnSFAAccountNo.HeaderText = "SFA AccountNo";
            ColumnSFAAccountNo.Width = 150;
            ColumnSFAAccountNo.DataPropertyName = "SFAAccountNo";
            ColumnSFAAccountNo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnSFAAccountNo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv1.Columns.Add(ColumnSFAAccountNo);

            DataGridViewTextBoxColumn ColumnSFAAccountNoPoultry = new DataGridViewTextBoxColumn();
            ColumnSFAAccountNoPoultry.HeaderText = "SFA AccountNo Poultry";
            ColumnSFAAccountNoPoultry.Width = 150;
            ColumnSFAAccountNoPoultry.DataPropertyName = "SFAAccountNoPoultry";
            ColumnSFAAccountNoPoultry.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnSFAAccountNoPoultry.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv1.Columns.Add(ColumnSFAAccountNoPoultry);
            
            DataGridViewTextBoxColumn ColumnBRID = new DataGridViewTextBoxColumn();
            ColumnBRID.HeaderText = "BRID";
            ColumnBRID.Width = 150;
            ColumnBRID.DataPropertyName = "BRID";
            ColumnBRID.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnBRID.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv1.Columns.Add(ColumnBRID);
            
            DataGridViewTextBoxColumn ColumnUserAdd = new DataGridViewTextBoxColumn();
            ColumnUserAdd.HeaderText = "User Add";
            ColumnUserAdd.Width = 120;
            ColumnUserAdd.DataPropertyName = "UserCodeAdd";
            ColumnUserAdd.ReadOnly = true;
            ColumnUserAdd.Visible = false;
            ColumnUserAdd.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnUserAdd.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv1.Columns.Add(ColumnUserAdd);
            
            DataGridViewCheckBoxColumn ColumnUserEdit = new DataGridViewCheckBoxColumn();
            ColumnUserEdit.HeaderText = "User Edit";
            ColumnUserEdit.Width = 120;
            ColumnUserEdit.DataPropertyName = "UserCodeEdit";
            ColumnUserEdit.ReadOnly = true;
            ColumnUserEdit.Visible = false;
            ColumnUserEdit.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnUserEdit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv1.Columns.Add(ColumnUserEdit);

            //Adding  TCode Combo
            DataGridViewComboBoxColumn ColumnTCode = new DataGridViewComboBoxColumn();
            ColumnTCode.DataPropertyName = "IndicatorCode";
            ColumnTCode.HeaderText = "Territory";
            ColumnTCode.Width = 120;
            ColumnTCode.DataSource = bindingSourcetblIndicator;
            ColumnTCode.ValueMember = "IndicatorCode";
            ColumnTCode.DisplayMember = "Indicator";
            ColumnTCode.ReadOnly = false;
            dgv1.Columns.Add(ColumnTCode);

            DataGridViewTextBoxColumn ColumnExternalID = new DataGridViewTextBoxColumn();
            ColumnExternalID.HeaderText = "External ID";
            ColumnExternalID.Width = 120;
            ColumnExternalID.DataPropertyName = "ExternalID";
            ColumnExternalID.ReadOnly = false;
            ColumnExternalID.Visible = true;
            ColumnExternalID.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnExternalID.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv1.Columns.Add(ColumnExternalID);

            //Setting Data Source for DataGridView
            dgv1.DataSource = bindingSource;
            //dgv1.AutoResizeColumns();
            //dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            myconnection.Close();
            this.WindowState = FormWindowState.Maximized;
            dgv1.AllowUserToAddRows = false;

            dgv1.Columns[10].DefaultCellStyle.Format = "N2";
            lblUserEdit.Text = dgv1.CurrentRow.Cells[18].Value.ToString();
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
                LoadData();
            }
            catch (Exception exceptionObj)
            {
                MessageBox.Show(exceptionObj.Message.ToString());
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dataTable.DefaultView;
            dv.RowFilter = "CustName LIKE '%" + txtSearch.Text + "%' OR ContactNo LIKE '%" + txtSearch.Text + "%' OR Address LIKE '%" + txtSearch.Text + "%' OR BusinessAddress LIKE '%" + txtSearch.Text + "%' OR ContactPerson LIKE '%" + txtSearch.Text + "%' OR TIN LIKE '%" + txtSearch.Text + "%' OR SFAAccountNo LIKE '%" + txtSearch.Text + "%' OR SFAAccountNoPoultry LIKE '%" + txtSearch.Text + "%' ";
            dgv1.DataSource = dv;
        }

        private void dgv1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //dgv1.CurrentRow.Cells[18].Value = Form1.glbluc.Text;
        }

        private void dgv1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 5 || e.ColumnIndex == 6 || e.ColumnIndex == 7 || e.ColumnIndex == 8 || e.ColumnIndex == 9 || e.ColumnIndex == 10 || e.ColumnIndex == 11 || e.ColumnIndex == 12 || e.ColumnIndex == 13 || e.ColumnIndex == 14 || e.ColumnIndex == 15 || e.ColumnIndex == 16 || e.ColumnIndex == 17 || e.ColumnIndex == 18 || e.ColumnIndex == 19)
                origData = dgv1[e.ColumnIndex, e.RowIndex].EditedFormattedValue.ToString().Trim(); //Get the original data
                lblUserEdit.Text = dgv1.CurrentRow.Cells[20].Value.ToString();
        }

        private void dgv1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (origData != dgv1[e.ColumnIndex, e.RowIndex].EditedFormattedValue.ToString().Trim()) //If not equal to original data will trigger
            {
                //MessageBox.Show(origData.ToString());
                dgv1.CurrentRow.Cells[20].Value = 1;//Do stuff
                lblUserEdit.Text = dgv1.CurrentRow.Cells[20].Value.ToString();
            }
        }
    }
}
