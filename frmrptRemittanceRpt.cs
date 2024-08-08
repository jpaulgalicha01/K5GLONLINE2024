using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using K5GLONLINE;
//using System.Data.SqlClient;
//using K5GLV3.FldrClass;
//using K5GLV3.FldrCrystalReports;
//using K5GLV3.FldrLog;
//using K5GLV3.FldrDataSet;

namespace k5GLONLINE
{
    public partial class frmrptRemittanceRpt : Form
    {
        //ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();
        //ClsComboBoxCOA ClsComboBoxCOA1 = new ClsComboBoxCOA();
        //ClsPermission ClsPermission1 = new ClsPermission();
        //DataTable data = new DataTable();
        //GetSomething ClsGetSomething1 = new GetSomething();
        ////string companyName;
        //ClsGetList ClsGetList1 = new ClsGetList();


        SqlConnection myconnection;
        //private SqlDataAdapter da;
        //private DataTable dataTable = null;
        //private BindingSource bindingSource = null;
        SqlCommand mycommand;
        ClsBuildVoucherComboBox ClsBuildVoucherComboBox1 = new ClsBuildVoucherComboBox();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        SqlDataReader SqlDataReader1;
        public string glblcboSalesman;

        public frmrptRemittanceRpt(string cboSalesman)
        {
            glblcboSalesman = cboSalesman;
            InitializeComponent();
        }
        private void frmrptRemittanceRpt_Load(object sender, EventArgs e)
        {
            DateTime VarToday = DateTime.Today;
            txtBeginDate.Text = String.Format("{0:MM/dd/yyyy}", VarToday);
            txtEndDate.Text = String.Format("{0:MM/dd/yyyy}", VarToday);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = new SqlCommand("usp_ApplyRemitRpt2", myconnection);
            mycommand.CommandType = CommandType.StoredProcedure;

            mycommand.Parameters.Add("@SMDesc1", SqlDbType.VarChar).Value = glblcboSalesman;
            mycommand.Parameters.Add("@Parambegindate1", SqlDbType.DateTime).Value = txtBeginDate.Text;
            mycommand.Parameters.Add("@Paramenddate1", SqlDbType.DateTime).Value = txtEndDate.Text;

            mycommand.CommandTimeout = 900;
            SqlDataReader1 = mycommand.ExecuteReader();
            DataTable DataTable1 = new DataTable();
            DataTable1.Load(SqlDataReader1);
            myconnection.Close();

            if (DataTable1.Rows.Count == 0)
            {
                MessageBox.Show("No data found", "GL");
                return;
            }

            CRRemittanceRpt objRpt = new CRRemittanceRpt();

            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject varTextReportTitle = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextReportTitle"];
            varTextReportTitle.Text = "Remmitance Report";

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            TextObject varrptAcctTitle = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rptAcctTitle"];
            varrptAcctTitle.Text = "Salesman Collection";

            DateTime VarToday = DateTime.Today;
            TextObject varrpttoenterdate = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rptrangedate"];
            varrpttoenterdate.Text = String.Format("{0:MM/dd/yyyy}", VarToday);

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }
    }
}
