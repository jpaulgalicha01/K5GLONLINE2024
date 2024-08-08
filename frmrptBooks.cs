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
    public partial class frmrptBooks : Form
    {
        SqlConnection myconnection;
        //      SqlDataReader dr;
        //      SqlCommand mycommand;
        BindingSource dbind = new BindingSource();

        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();
        ClsCompName ClsCompName1 = new ClsCompName();
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        ClsGetSomething ClsGetSomething1 = new ClsGetSomething();
        public frmrptBooks()
        {
            InitializeComponent();
            cbortprint.DisplayMember = "Text";
            cbortprint.ValueMember = "Value";
            cbortprint.SelectedValue = "01";
            var items = new[]{
            new{Text = "Accounts Receivable Voucher", Value = "01" },
            new{Text = "Accounts Payable Voucher", Value = "02" },
            new{Text = "Charge Invoice", Value = "03" },
            new{Text = "Check Voucher", Value = "04" },
            new{Text = "Journal Voucher", Value = "05" },
            new{Text = "Transfer Form", Value = "06" },
            new{Text = "Purchases By Vendor Summary", Value = "07" },
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

                if (cbortprint.SelectedValue.ToString() == "01")//Accounts Receivable Voucher
                {
                    bookarv();
                }
                else if (cbortprint.SelectedValue.ToString() == "02")//Accounts Payable Voucher
                {
                    bookapv();
                }
                else if (cbortprint.SelectedValue.ToString() == "03")//Charge Invoice
                {
                    bookci();
                }
                else if (cbortprint.SelectedValue.ToString() == "04")//Check Voucher
                {
                    bookcv();
                }

                else if (cbortprint.SelectedValue.ToString() == "05")//Journal Voucher
                {
                    bookjv();
                }
                else if (cbortprint.SelectedValue.ToString() == "06")//Transfer Form
                {
                    booktf();
                }
                else if (cbortprint.SelectedValue.ToString() == "07")//Purchases by vendor summ
                {
                    bookpvs();
                }

            }
        }

        private void bookpd()
        {
            string sqlstatement;

            DateTime varbdate1 = Convert.ToDateTime(txtBeginDate.Text);
            DateTime varedate1 = Convert.ToDateTime(txtEndDate.Text);
            string varbegindate = String.Format("{0:yyyy/MM/dd}", varbdate1);
            string varenddate = String.Format("{0:yyyy/MM/dd}", varedate1);

            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();

            sqlstatement = "SELECT * FROM viewbookpd WHERE TDate BETWEEN '" + varbegindate + "' And  '" + varenddate + "'";

            SqlDataAdapter dscmd = new SqlDataAdapter(sqlstatement, myconnection);
            dscmd.SelectCommand.CommandTimeout = 600;
            DSBooks dsplrv = new DSBooks();
            dscmd.Fill(dsplrv, "viewbookpd");
            myconnection.Close();


            CRBookPD objRpt = new CRBookPD();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            objRpt.SetDataSource(dsplrv.Tables[1]);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }

        private void bookapv()
        {
            string sqlstatement;

            DateTime varbdate1 = Convert.ToDateTime(txtBeginDate.Text);
            DateTime varedate1 = Convert.ToDateTime(txtEndDate.Text);
            string varbegindate = String.Format("{0:yyyy/MM/dd}", varbdate1);
            string varenddate = String.Format("{0:yyyy/MM/dd}", varedate1);

            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();

            sqlstatement = "SELECT * FROM viewbookapv WHERE TDate BETWEEN '" + varbegindate + "' And  '" + varenddate + "'";

            SqlDataAdapter dscmd = new SqlDataAdapter(sqlstatement, myconnection);
            dscmd.SelectCommand.CommandTimeout = 600;
            DSBooks dsplrv = new DSBooks();
            dscmd.Fill(dsplrv, "viewbookapv");
            myconnection.Close();


            CRBookAPV objRpt = new CRBookAPV();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            objRpt.SetDataSource(dsplrv.Tables[1]);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }

        private void bookci()
        {
            string sqlstatement;

            DateTime varbdate1 = Convert.ToDateTime(txtBeginDate.Text);
            DateTime varedate1 = Convert.ToDateTime(txtEndDate.Text);
            string varbegindate = String.Format("{0:yyyy/MM/dd}", varbdate1);
            string varenddate = String.Format("{0:yyyy/MM/dd}", varedate1);

            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();

            sqlstatement = "SELECT * FROM viewbookci WHERE TDate BETWEEN '" + varbegindate + "' And  '" + varenddate + "'";

            SqlDataAdapter dscmd = new SqlDataAdapter(sqlstatement, myconnection);
            dscmd.SelectCommand.CommandTimeout = 600;
            DSBooks dsplrv = new DSBooks();
            dscmd.Fill(dsplrv, "viewbookci");
            myconnection.Close();


            CRBookCI objRpt = new CRBookCI();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            objRpt.SetDataSource(dsplrv.Tables[1]);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }

        private void bookarv()
        {
            string sqlstatement;

            DateTime varbdate1 = Convert.ToDateTime(txtBeginDate.Text);
            DateTime varedate1 = Convert.ToDateTime(txtEndDate.Text);
            string varbegindate = String.Format("{0:yyyy/MM/dd}", varbdate1);
            string varenddate = String.Format("{0:yyyy/MM/dd}", varedate1);

            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();

            sqlstatement = "SELECT * FROM viewbookarv WHERE TDate BETWEEN '" + varbegindate + "' And  '" + varenddate + "'";

            SqlDataAdapter dscmd = new SqlDataAdapter(sqlstatement, myconnection);
            dscmd.SelectCommand.CommandTimeout = 600;
            DSBooks dsplrv = new DSBooks();
            dscmd.Fill(dsplrv, "viewbookarv");
            myconnection.Close();


            CRBookARV objRpt = new CRBookARV();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            objRpt.SetDataSource(dsplrv.Tables[1]);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();

        }



        private void bookcrv()

        {
            string sqlstatement;

            DateTime varbdate1 = Convert.ToDateTime(txtBeginDate.Text);
            DateTime varedate1 = Convert.ToDateTime(txtEndDate.Text);
            string varbegindate = String.Format("{0:yyyy/MM/dd}", varbdate1);
            string varenddate = String.Format("{0:yyyy/MM/dd}", varedate1);

            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();

            sqlstatement = "SELECT * FROM viewbookcrv WHERE TDate BETWEEN '" + varbegindate + "' And  '" + varenddate + "'";

            SqlDataAdapter dscmd = new SqlDataAdapter(sqlstatement, myconnection);
            dscmd.SelectCommand.CommandTimeout = 600;
            DSBooks dsplrv = new DSBooks();
            dscmd.Fill(dsplrv, "viewbookcrv");
            myconnection.Close();


            CRBookCRV objRpt = new CRBookCRV();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            objRpt.SetDataSource(dsplrv.Tables[1]);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }

        private void bookcv()
        {
            string sqlstatement;

            DateTime varbdate1 = Convert.ToDateTime(txtBeginDate.Text);
            DateTime varedate1 = Convert.ToDateTime(txtEndDate.Text);
            string varbegindate = String.Format("{0:yyyy/MM/dd}", varbdate1);
            string varenddate = String.Format("{0:yyyy/MM/dd}", varedate1);

            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();

            sqlstatement = "SELECT * FROM viewbookcv WHERE TDate BETWEEN '" + varbegindate + "' And  '" + varenddate + "'";

            SqlDataAdapter dscmd = new SqlDataAdapter(sqlstatement, myconnection);
            dscmd.SelectCommand.CommandTimeout = 600;
            DSBooks dsplrv = new DSBooks();
            dscmd.Fill(dsplrv, "viewbookcv");
            myconnection.Close();


            CRBookCV objRpt = new CRBookCV();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            objRpt.SetDataSource(dsplrv.Tables[1]);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }

        private void bookjv()
        {
            string sqlstatement;

            DateTime varbdate1 = Convert.ToDateTime(txtBeginDate.Text);
            DateTime varedate1 = Convert.ToDateTime(txtEndDate.Text);
            string varbegindate = String.Format("{0:yyyy/MM/dd}", varbdate1);
            string varenddate = String.Format("{0:yyyy/MM/dd}", varedate1);

            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();

            sqlstatement = "SELECT * FROM viewbookjv WHERE TDate BETWEEN '" + varbegindate + "' And  '" + varenddate + "'";

            SqlDataAdapter dscmd = new SqlDataAdapter(sqlstatement, myconnection);
            dscmd.SelectCommand.CommandTimeout = 600;
            DSBooks dsplrv = new DSBooks();
            dscmd.Fill(dsplrv, "viewbookjv");
            myconnection.Close();


            CRBookJV objRpt = new CRBookJV();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            objRpt.SetDataSource(dsplrv.Tables[1]);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }

        private void booktf()
        {
            string sqlstatement;

            DateTime varbdate1 = Convert.ToDateTime(txtBeginDate.Text);
            DateTime varedate1 = Convert.ToDateTime(txtEndDate.Text);
            string varbegindate = String.Format("{0:yyyy/MM/dd}", varbdate1);
            string varenddate = String.Format("{0:yyyy/MM/dd}", varedate1);

            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();

            sqlstatement = "SELECT * FROM viewTF WHERE TDate BETWEEN '" + varbegindate + "' And  '" + varenddate + "'";

            SqlDataAdapter dscmd = new SqlDataAdapter(sqlstatement, myconnection);
            dscmd.SelectCommand.CommandTimeout = 600;
            DSBooks dsplrv = new DSBooks();
            dscmd.Fill(dsplrv, "viewbookjv");
            myconnection.Close();


            CRBookTF objRpt = new CRBookTF();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            objRpt.SetDataSource(dsplrv.Tables[1]);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }
        
        private void bookpvs()
        {
            string sqlstatement;

            DateTime varbdate1 = Convert.ToDateTime(txtBeginDate.Text);
            DateTime varedate1 = Convert.ToDateTime(txtEndDate.Text);
            string varbegindate = String.Format("{0:yyyy/MM/dd}", varbdate1);
            string varenddate = String.Format("{0:yyyy/MM/dd}", varedate1);

            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();

            sqlstatement = "SELECT CustName, SUM(VAT) as VAT, SUM(Cost)AS Cost FROM ViewPDVendor WHERE TDate BETWEEN '" + varbegindate + "' And  '" + varenddate + "' Group by CustName";

            SqlDataAdapter dscmd = new SqlDataAdapter(sqlstatement, myconnection);
            dscmd.SelectCommand.CommandTimeout = 600;
            DSBooks dsplrv = new DSBooks();
            dscmd.Fill(dsplrv, "viewpd");
            myconnection.Close();

            CRBookPDVendor objRpt = new CRBookPDVendor();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            ClsCompName1.ClsCompNameMain();
            vartxtcompany.Text = ClsCompName1.varcn;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            ClsCompName1.ClsCompNameMain();
            vartxtaddress.Text = ClsCompName1.varaddress;

            TextObject vartxtdaterange = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["txtdaterange"];
            vartxtdaterange.Text = "From: " + txtBeginDate.Text + " To: " + txtEndDate.Text;

            objRpt.SetDataSource(dsplrv.Tables[1]);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }

        private void frmrptBooks_Load(object sender, EventArgs e)
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
