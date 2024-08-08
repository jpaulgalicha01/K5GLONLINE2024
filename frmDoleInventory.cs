using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace K5GLONLINE
{
    public partial class frmDoleInventory : Form
    {

        ClsBuildVoucherComboBox ClsBuildVoucherComboBox1 = new ClsBuildVoucherComboBox();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        ClsCompName ClsCompName1 = new ClsCompName();
        SqlConnection myconnection;
        SqlCommand mycommand;
        SqlDataReader SqlDataReader1;
        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();

        public frmDoleInventory()
        {
            InitializeComponent();
        }

        private void frmDoleInventory_Load(object sender, EventArgs e)
        {
            buildcboWHCode();
            buildcboSCode();
            txtAsofDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }

        private void buildcboWHCode()
        {
            cboWHCode.DataSource = null;
            ClsBuildVoucherComboBox1.ARLWHCode.Clear();
            ClsBuildVoucherComboBox1.ClsBuildWarehouse();
            this.cboWHCode.DataSource = (ClsBuildVoucherComboBox1.ARLWHCode);
            this.cboWHCode.DisplayMember = "Display";
            this.cboWHCode.ValueMember = "Value";
        }

        private void buildcboSCode()
        {
            cboSCode.DataSource = null;
            ClsBuildComboBox1.ARCCN.Clear();
            ClsBuildComboBox1.ClsBuildClientControlno("S");
            this.cboSCode.DataSource = (ClsBuildComboBox1.ARCCN);
            this.cboSCode.DisplayMember = "Display";
            this.cboSCode.ValueMember = "Value";

            cboSCode.DataSource = null;
            ClsBuildComboBox1.ARCCN.Clear();
            ClsBuildComboBox1.ClsBuildClientControlno("S");
            this.cboSCode.DataSource = (ClsBuildComboBox1.ARCCN);
            this.cboSCode.DisplayMember = "Display";
            this.cboSCode.ValueMember = "Value";
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {

            if (new ClsValidation().emptytxt(cboWHCode.Text))
            {
                MessageBox.Show("Warehouse is empty", "GL");
                cboWHCode.Focus();
            }
            else if (new ClsValidation().emptytxt(cboSCode.Text))
            {
                MessageBox.Show("Principal is empty", "GL");
                cboSCode.Focus();
            }
            else if (txtAsofDate.Text == "  /  /")
            {
                MessageBox.Show("Please complete your entry", "GL");
                txtAsofDate.Focus();
            }
            else
            {
                DoleInventory();
            }
        }
       

        private void DoleInventory()
        {
            string sqlstatement;
            sqlstatement = "SELECT SFAProductCode, IB, Piece, (SELECT CASE WHEN IB=0 THEN (SUM(ConvertedQty)/Piece) ELSE (SUM(ConvertedQty)/IB)/Piece END AS CSQty) AS CSQty ";
            sqlstatement += "FROM ViewDoleInventory WHERE TDate<='" + txtAsofDate.Text+"' AND WHCode='"+cboWHCode.SelectedValue.ToString()+"' ";
            sqlstatement += "AND ClassCode='"+cboSCode.SelectedValue.ToString()+"' GROUP BY SFAProductCode, IB, Piece";
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
            

            CRDOLEInventory objRpt = new CRDOLEInventory();

            TextObject vartxtClosingDate = (TextObject)objRpt.ReportDefinition.Sections["Section3"].ReportObjects["rpttxtclosingdate"];
            vartxtClosingDate.Text = txtAsofDate.Text;

            objRpt.SetDataSource(DataTable1);

            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }
    }
}
