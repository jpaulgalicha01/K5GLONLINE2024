using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;

namespace K5GLONLINE
{
    public partial class frmrptCAMainAccount : Form
    {
        SqlConnection myconnection;
        //SqlCommand mycommand;
        BindingSource dbind = new BindingSource();
        ClsCompName ClsCompName1 = new ClsCompName();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection(); 

        public frmrptCAMainAccount()
        {
            InitializeComponent();
        }

        private void frmrptLoanBalances_Load(object sender, EventArgs e)
        {
            CAMainAccount();
            this.WindowState = FormWindowState.Maximized;
        }

        private void CAMainAccount()
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();

            string sqlstatement;

            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            sqlstatement = "SELECT AcctNo, TitleAcct, FSClass, FCCode, SCCode, NormalBal, UsageCode ";
            sqlstatement += "FROM tblTitleAcct ORDER BY AcctNo";

            SqlDataAdapter dscmd = new SqlDataAdapter(sqlstatement, myconnection);
            dscmd.SelectCommand.CommandTimeout = 600;
            DSCAMainAccount dsca = new DSCAMainAccount();
            dscmd.Fill(dsca, "tblTitleAcct");
            myconnection.Close();

            CRCAMainAccount objRpt = new CRCAMainAccount();
            TextObject varrpttocompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            ClsCompName1.ClsCompNameMain();
            varrpttocompany.Text = ClsCompName1.varcn;

            TextObject varrpttoaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            varrpttoaddress.Text = Form1.glbladdress.Text;

            objRpt.SetDataSource(dsca.Tables[1]);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }
    }
}
