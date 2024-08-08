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
    public partial class frmGAEdit : Form
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

        public frmGAEdit()
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
            dgv1.DataSource = null;
            dgv1.Columns.Clear();
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);

            sql = "SELECT GA, GeogArea, TCode, KilometerRead FROM tblGA";

            da = new SqlDataAdapter(sql, myconnection);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);

            dataTable = new DataTable();
            da.Fill(dataTable);
            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;
            
            string selectQueryStringtblTerritory = "SELECT TCode, TDesc FROM tblTerritory ORDER BY TDesc";
            SqlDataAdapter sqlDataAdaptertblTerritory = new SqlDataAdapter(selectQueryStringtblTerritory, myconnection);
            SqlCommandBuilder sqlCommandBuildertblTerritory = new SqlCommandBuilder(sqlDataAdaptertblTerritory);
            DataTable dataTabletblTerritory = new DataTable();
            sqlDataAdaptertblTerritory.Fill(dataTabletblTerritory);
            BindingSource bindingSourcetblTerritory = new BindingSource();
            bindingSourcetblTerritory.DataSource = dataTabletblTerritory;

            //Adding  GA TextBox
            DataGridViewTextBoxColumn ColumnGA = new DataGridViewTextBoxColumn();
            ColumnGA.HeaderText = "Code";
            ColumnGA.Width = 50;
            ColumnGA.DataPropertyName = "GA";
            ColumnGA.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnGA.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnGA.Visible = true;
            ColumnGA.ReadOnly = true;
            dgv1.Columns.Add(ColumnGA);

            //Adding  GeaoArea TextBox
            DataGridViewTextBoxColumn ColumnGeogArea = new DataGridViewTextBoxColumn();
            ColumnGeogArea.HeaderText = "Area";
            ColumnGeogArea.Width = 200;
            ColumnGeogArea.DataPropertyName = "GeogArea";
            ColumnGeogArea.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnGeogArea.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnGeogArea.ReadOnly = true;
            dgv1.Columns.Add(ColumnGeogArea);

            //Adding  TCode Combo
            DataGridViewComboBoxColumn ColumnTCode = new DataGridViewComboBoxColumn();
            ColumnTCode.DataPropertyName = "TCode";
            ColumnTCode.HeaderText = "Territory";
            ColumnTCode.Width = 200;
            ColumnTCode.DataSource = bindingSourcetblTerritory;
            ColumnTCode.ValueMember = "TCode";
            ColumnTCode.DisplayMember = "TDesc";
            dgv1.Columns.Add(ColumnTCode);

            //Adding  KilometerRead TextBox
            DataGridViewTextBoxColumn ColumnKilometerRead = new DataGridViewTextBoxColumn();
            ColumnKilometerRead.HeaderText = "Kilometer Read";
            ColumnKilometerRead.Width = 80;
            ColumnKilometerRead.DataPropertyName = "KilometerRead";
            ColumnKilometerRead.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnKilometerRead.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnKilometerRead.ReadOnly = true;
            dgv1.Columns.Add(ColumnKilometerRead);

            //Setting Data Source for DataGridView
            dgv1.DataSource = bindingSource;
            //dgv1.AutoResizeColumns();
            this.dgv1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            myconnection.Close();
            //this.WindowState = FormWindowState.Maximized;
            dgv1.AllowUserToAddRows = false;
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
    }
}
