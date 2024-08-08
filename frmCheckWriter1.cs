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
    public partial class frmCheckWriter1 : Form
    {

        SqlConnection myconnection;
        SqlDataReader dr;
        SqlCommand mycommand;
        //ClsCompName ClsCompName1 = new ClsCompName();
        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection(); 

        public frmCheckWriter1()
        {
            InitializeComponent();
        }

        private void buildlv()
        {
            DateTime todaysDate;
            try
            {
                DateTime varbdate1 = Convert.ToDateTime(txtBeginDate.Text);
                DateTime varedate1 = Convert.ToDateTime(txtEndDate.Text);
                string varbegindate = String.Format("{0:yyyy/MM/dd}", varbdate1);
                string varenddate = String.Format("{0:yyyy/MM/dd}", varedate1);
                lvvoucherslist.Items.Clear();
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT DocNum, Voucher, TDate, CheckNo, CustName, CAmount FROM viewcheckwriter WHERE TDate BETWEEN '" + varbegindate + "' And  '" + varenddate + "'", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();

            
                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem(dr["DocNum"].ToString());
                    item.SubItems.Add(dr["CustName"].ToString());
                    item.SubItems.Add(dr["CheckNo"].ToString());
                    item.SubItems.Add(dr["TDate"].ToString());
                    todaysDate = Convert.ToDateTime(item.SubItems[3].Text);
                    txtMonth.Text = Convert.ToString(todaysDate.Month).PadLeft(2, '0');
                    txtDay.Text = Convert.ToString(todaysDate.Day).PadLeft(2, '0');
                    txtYear.Text = (todaysDate.Year).ToString();
                    item.SubItems.Add(dr["CAmount"].ToString());
                    item.SubItems.Add(dr["Voucher"].ToString());

                    lvvoucherslist.Items.Add(item);
                }
                dr.Close();
                myconnection.Close();


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
    
     

        private void lvvoucherslist_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lvvoucherslist.SelectedItems.Count > 0)
            {
                ListViewItem itm = lvvoucherslist.SelectedItems[0];
                txtdocnum.Text = itm.SubItems[0].Text;
                txtCustName.Text = itm.SubItems[1].Text;
                txtcheckno.Text = itm.SubItems[2].Text;
                txtdate.Text = itm.SubItems[3].Text;
                txtcamount.Text = itm.SubItems[4].Text;
                txtvoucher.Text = itm.SubItems[5].Text;

                double waa = double.Parse(txtcamount.Text);
                int wab = (int)waa;

                string wac = (decamout.Calculateamount(waa, wab)).ToString();
                string damtcent = Convert.ToDouble(wac).ToString("N2");
                convertcents cvcnts = new convertcents();
                string dwordcent = cvcnts.getconvertcents(damtcent);

                double a = double.Parse(txtcamount.Text);
                int b = (int)a;
                NumberToWordsConvertor ntwc = new NumberToWordsConvertor();
                string trimdamt = ntwc.NumberToWords(b);
                txtamtinwords.Text = trimdamt.Trim() + " Pesos And " + dwordcent;
                
            }
        }
        private void refreshlist()
        {
            if (txtBeginDate.Text == "  /  /")
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
                buildlv();
            }
        }
        private void btnrefresh_Click(object sender, EventArgs e)
        {
            refreshlist();           
            
        }

        private void frmCheckWriter_Load(object sender, EventArgs e)
        {
            ClsPermission1.ClsObjects(this.Text);
            if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
            {
                MessageBox.Show("You do not have necessary permission to open this file", "GL");
                this.Close();
            }
            else
            {

                String varDate1 = DateTime.Today.ToShortDateString();
                DateTime varDate2 = Convert.ToDateTime(varDate1);
                txtBeginDate.Text = String.Format("{0:MM/dd/yyyy}", varDate2);
                txtEndDate.Text = String.Format("{0:MM/dd/yyyy}", varDate2);
                buildlv();
            }
        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtmetrobank_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtcamount.Text))
            {
                MessageBox.Show("Please select transaction number", "GL");
                lvvoucherslist.Focus();
            }
            else
            {
                CRCheckMetrobank objRpt = new CRCheckMetrobank();
                TextObject varrptxtCustName = (TextObject)objRpt.ReportDefinition.Sections["Section3"].ReportObjects["rpttxtCustName"];
                varrptxtCustName.Text = txtCustName.Text;

                TextObject varrptxtdate = (TextObject)objRpt.ReportDefinition.Sections["Section3"].ReportObjects["rpttxtdate"];
                varrptxtdate.Text = txtMonth.Text + " " + txtDay.Text + " " + txtYear.Text;

                TextObject varrptxtcamount = (TextObject)objRpt.ReportDefinition.Sections["Section3"].ReportObjects["rpttxtamt"];
                varrptxtcamount.Text = txtcamount.Text;

                TextObject varrptxtamtinwords = (TextObject)objRpt.ReportDefinition.Sections["Section3"].ReportObjects["rpttxtamtinwords"];
                varrptxtamtinwords.Text = txtamtinwords.Text;

                objRpt.Refresh();
                objRpt.PrintToPrinter(1, true, 0, 0);
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

        private void txtMetrobank2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtcamount.Text))
            {
                MessageBox.Show("Please select transaction number", "GL");
                lvvoucherslist.Focus();
            }
            else
            {
                CRCheckMetrobankLong objRpt = new CRCheckMetrobankLong();
                TextObject varrptxtCustName = (TextObject)objRpt.ReportDefinition.Sections["Section3"].ReportObjects["rpttxtCustName"];
                varrptxtCustName.Text = txtCustName.Text;

                TextObject varrptxtdate = (TextObject)objRpt.ReportDefinition.Sections["Section3"].ReportObjects["rpttxtdate"];
                varrptxtdate.Text = txtMonth.Text + " " + txtDay.Text + " " + txtYear.Text;

                TextObject varrptxtcamount = (TextObject)objRpt.ReportDefinition.Sections["Section3"].ReportObjects["rpttxtamt"];
                varrptxtcamount.Text = txtcamount.Text;

                TextObject varrptxtamtinwords = (TextObject)objRpt.ReportDefinition.Sections["Section3"].ReportObjects["rpttxtamtinwords"];
                varrptxtamtinwords.Text = txtamtinwords.Text;

                objRpt.Refresh();
                objRpt.PrintToPrinter(1, true, 0, 0);
            }

        }

        private void nextfieldenter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboCName_Validated(object sender, EventArgs e)
        {
            refreshlist();
        }

      
    }
}
