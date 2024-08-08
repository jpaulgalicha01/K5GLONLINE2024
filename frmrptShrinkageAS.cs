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
    public partial class frmrptShrinkageAS : Form
    {
        SqlConnection myconnection;
        SqlDataReader SqlDataReader1;
        SqlCommand mycommand;
        BindingSource dbind = new BindingSource();

        //ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();
        //ClsCompName ClsCompName1 = new ClsCompName();
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        ClsGetSomething ClsGetSomething1 = new ClsGetSomething();
        public frmrptShrinkageAS()
        {
            InitializeComponent();
            //cbortprint.DisplayMember = "Text";
            //cbortprint.ValueMember = "Value";
            //cbortprint.SelectedValue = "01";
            cbortprint.DisplayMember = "Text";
            cbortprint.ValueMember = "Value";
            cbortprint.SelectedValue = "01";
            var items = new[]
            { 
             new { Text = "Shrinkage Details in AS", Value = "01" }, 
            };
            cbortprint.DataSource = items;

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (new ClsValidation().emptytxt(cbortprint.Text))
            {
                MessageBox.Show("Please complete your entry", "GL");
                cbortprint.Focus();
            }
            else if (txtBeginDate.Text == "  /  /")
            {
                MessageBox.Show("Please complete your entry", "GL");
                txtBeginDate.Focus();
            }
            else if (txtEndDate.Text == "  /  /")
            {
                MessageBox.Show("Please complete your entry", "GL");
                txtEndDate.Focus();
            }
            else if (Convert.ToDateTime(txtBeginDate.Text) > Convert.ToDateTime(txtEndDate.Text))
            {
                MessageBox.Show("Beginning date is greater than ending date");
                txtBeginDate.Focus();
            }
            else
            {
                //if ((string)listBox1.SelectedItem == "Two")
                //    MessageBox.Show((string)listBox1.SelectedItem);

                // if ((string)cbortprint.SelectedValue=="01")

                if (cbortprint.SelectedValue.ToString() == "01")
                {
                    DetailedShrinkageAS();
                }
            }
        }

        private void DetailedShrinkageAS()
        {
            string sqlstatement = "SELECT StockNumber, Item, PClassDesc, SUM(PIn) AS PIn, SUM(POut) AS POut, ";
            sqlstatement += "SUM(Cost) AS Cost FROM ViewShrinkageDetailsAS WHERE TDate Between '" + txtBeginDate.Text + "' AND '" + txtEndDate.Text + "' ";
            sqlstatement += "GROUP BY StockNumber, Item, PClassDesc";

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
                MessageBox.Show("No data found", "GL");
                return;
            }


            CRShrinkageDetailsAS objRpt = new CRShrinkageDetailsAS();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            TextObject varTextDateRange = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["TextDateRange"];
            varTextDateRange.Text = "From " + txtBeginDate.Text + " To " + txtEndDate.Text;

            objRpt.SetDataSource(DataTable1);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }

        private void frmrptShrinkageAS_Load(object sender, EventArgs e)
        {
            ClsPermission1.ClsObjects(this.Text);
            if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
            {
                MessageBox.Show("You do not have necessary permission to open this file", "GL");
                this.Close();
            }
            else
            {
                ClsGetSomething1.ClsGetDefaultDate();
                txtBeginDate.Text = ClsGetSomething1.plsdefdate;
                txtEndDate.Text = ClsGetSomething1.plsdefdate;

                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void txtBeginDate_Leave(object sender, EventArgs e)
        {
            if (new ClsValidation().errordate(txtBeginDate.Text) == true)
            {
                MessageBox.Show("Invalid Date", "GL");
                txtBeginDate.Focus();
            }
        }

        private void txtEndDate_Leave(object sender, EventArgs e)
        {
            if (new ClsValidation().errordate(txtEndDate.Text) == true)
            {
                MessageBox.Show("Invalid Date", "GL");
                txtEndDate.Focus();
            }
        }

        private void nextfieldenter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
