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
    public partial class frmCustomerNameAdd : Form
    {
        SqlConnection myconnection;
        SqlCommand mycommand;
        //BindingSource dbind = new BindingSource();
        ClsAutoNumber ClsAutoNumber1 = new ClsAutoNumber();
        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();

        public frmCustomerNameAdd()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buildcboChannel()
        {
            ClsBuildComboBox1.ClsBuildChannel();
            this.cboChannel.DataSource = (ClsBuildComboBox1.PALChannel);
            this.cboChannel.DisplayMember = "Display";
            this.cboChannel.ValueMember = "Value";
        }

        private void buildcboSalesman()
        {
            ClsBuildComboBox1.ClsBuildSalesman();
            this.cboSalesman.DataSource = (ClsBuildComboBox1.PALSalesman);
            this.cboSalesman.DisplayMember = "Display";
            this.cboSalesman.ValueMember = "Value";
        }

        private void buildcboRegion()
        {
            ClsBuildComboBox1.ClsBuildRegion();
            this.cboRegion.DataSource = (ClsBuildComboBox1.PALRegion);
            this.cboRegion.DisplayMember = "Display";
            this.cboRegion.ValueMember = "Value";
        }

        private void buildcboSP()
        {
            ClsBuildComboBox1.ClsBuildSPOption();
            this.cboSellingPrice.DataSource = (ClsBuildComboBox1.PALSPOption);
            this.cboSellingPrice.DisplayMember = "Display";
            this.cboSellingPrice.ValueMember = "Value";

        }
        private void buildcboGA()
        {
            ClsBuildComboBox1.ClsBuildGA();
            this.cboGeographical.DataSource = (ClsBuildComboBox1.PALGA);
            this.cboGeographical.DisplayMember = "Display";
            this.cboGeographical.ValueMember = "Value";
        }

        private void frmNameAdd_Load(object sender, EventArgs e)
        {
            ClsPermission1.ClsObjects(this.Text);
            if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
            {
                MessageBox.Show("You do not have necessary permission to open this file", "GL");
                this.Close();
            }
            else
            {

                ClsAutoNumber1.CustomerNameAdd();
                txtCustCode.Text = (ClsAutoNumber1.plsnumber);
                buildcboChannel();
                cboChannel.SelectedValue = "";
                buildcboSalesman();
                cboSalesman.SelectedValue = "";
                buildcboRegion();
                cboRegion.SelectedValue = "";
                buildcboSP();
                cboSellingPrice.SelectedValue = "";
                buildcboGA();
                cboGeographical.SelectedValue = "";
            }
        }

        private void savedata()
        {
            try
            {

                //ClsAutoNumber1.CustomerNameAdd();
                //txtCustCode.Text = (ClsAutoNumber1.plsnumber);

                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();

                if (new Clsexist().RecordExists(ref myconnection, "SELECT CustName FROM tblCustomer WHERE CustName = '" + txtCustName.Text + "'"))
                {
                    myconnection.Close();
                    MessageBox.Show("Duplicate customer name", "GL");
                    txtCustName.Focus();
                }
                else if (new ClsValidation().emptytxt(txtCustName.Text))
                {
                    myconnection.Close();
                    MessageBox.Show("Please complete your entry", "GL");
                    txtCustName.Focus();
                }
                else if (new ClsValidation().emptytxt(txtContactNo.Text))
                {
                    myconnection.Close();
                    MessageBox.Show("Please complete your entry", "GL");
                    txtContactNo.Focus();
                }
                else if (new ClsValidation().emptytxt(txtAddress.Text))
                {
                    myconnection.Close();
                    MessageBox.Show("Please complete your entry", "GL");
                    txtAddress.Focus();
                }
                else if (new ClsValidation().emptytxt(cboChannel.Text) || new ClsValidation().emptytxt(cboGeographical.Text) || new ClsValidation().emptytxt(cboRegion.Text)
                    || new ClsValidation().emptytxt(cboSalesman.Text) || new ClsValidation().emptytxt(cboSellingPrice.Text))
                {
                    myconnection.Close();
                    MessageBox.Show("Please complete your entry", "GL");
                    txtAddress.Focus();
                }
                else
                {
                    ClsAutoNumber1.CustomerNameAdd();
                    txtCustCode.Text = (ClsAutoNumber1.plsnumber);

                    string sqlstatement;
                    sqlstatement = "INSERT INTO tblCustomer (ControlNo, CustName, ContactNo, Address, NType, CC, GA, SLS, RegCode, TIN, Term, CreditLimit, ContactPerson, SPO, UserAdd, BusinessType)";
                    sqlstatement += "Values (@_ControlNo, @_CustName, @_ContactNo, @_Address, @_NType, @_CC, @_GA, @_SLS, @_RegCode, @_TIN, @_Term, @_CreditLimit, @_ContactPerson, @_SPO, @_UserAdd, @_BusinessType)";
                    //myconnection = new SqlConnection(new ClsGetConnection().plsMyConMSSQL);

                    //    selectSQL = "SELECT * FROM Authors ";
                    //    selectSQL += "WHERE au_id='" + lstAuthor.SelectedItem.Value + "'";
                    //CustomerID, BankCode, PensionAmount, Birthdate, SSSNumber, Spouse, ContactNo, BranchCode, AgentCode
                    mycommand = new SqlCommand(sqlstatement, myconnection);
                    mycommand.Parameters.Add("_ControlNo", SqlDbType.VarChar).Value = txtCustCode.Text;
                    mycommand.Parameters.Add("_CustName", SqlDbType.VarChar).Value = txtCustName.Text;
                    mycommand.Parameters.Add("_ContactNo", SqlDbType.VarChar).Value = txtContactNo.Text;
                    //mycommand.Parameters.Add("_CNCode", SqlDbType.VarChar).Value = ()
                    mycommand.Parameters.Add("_Address", SqlDbType.VarChar).Value = txtAddress.Text;
                    mycommand.Parameters.Add("_NType", SqlDbType.VarChar).Value = "C";
                    mycommand.Parameters.Add("_CC", SqlDbType.VarChar).Value = cboChannel.SelectedValue.ToString();
                    mycommand.Parameters.Add("_GA", SqlDbType.VarChar).Value = cboGeographical.SelectedValue.ToString();
                    mycommand.Parameters.Add("_SLS", SqlDbType.VarChar).Value = cboSalesman.SelectedValue.ToString();
                    mycommand.Parameters.Add("_RegCode", SqlDbType.VarChar).Value = cboRegion.SelectedValue.ToString();
                    mycommand.Parameters.Add("_TIN", SqlDbType.VarChar).Value = txtTIN.Text;
                    mycommand.Parameters.Add("_Term", SqlDbType.VarChar).Value = txtTerm.Text;
                    mycommand.Parameters.Add("_CreditLimit", SqlDbType.Money).Value = txtCreditLimit.Text;
                    mycommand.Parameters.Add("_ContactPerson", SqlDbType.VarChar).Value = txtContactPerson.Text;
                    mycommand.Parameters.Add("_SPO", SqlDbType.VarChar).Value = cboSellingPrice.SelectedValue.ToString();
                    mycommand.Parameters.Add("_UserAdd", SqlDbType.VarChar).Value = Form1.glbluc.Text;
                    mycommand.Parameters.Add("_BusinessType", SqlDbType.VarChar).Value = txtBusinessType.Text;
                    //mycommand.Parameters.Add("_UserCodeEdit", SqlDbType.VarChar).Value = null;
                    mycommand.CommandTimeout = 600;
                    int n1 = mycommand.ExecuteNonQuery();

                    ClsAutoNumber1.CustomerNameAdd();
                    txtCustCode.Text = (ClsAutoNumber1.plsnumber);
                    myconnection.Close();

                    txtCustName.Clear();
                    txtContactNo.Text = "NA";
                    txtAddress.Text = "NA";
                    txtCustName.Focus();
                    cboChannel.SelectedValue = "";
                    cboGeographical.SelectedValue = "";
                    cboRegion.SelectedValue = "";
                    cboSalesman.SelectedValue = "";
                    cboSellingPrice.SelectedValue = "";
                    txtBusinessType.Text = "NA";
                    MessageBox.Show("Saved", "GL");
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                //  dr.Close();
                myconnection.Close();
            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            savedata();
        }



        private void nextfieldenter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }

        }

        private void txtTerm_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().isInt(txtTerm.Text) == true)
            {
                MessageBox.Show("Invalid Number", "GL");
                txtTerm.Focus();
            }
        }

        private void txtCreditLimit_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().isDouble(txtCreditLimit.Text) == true)
            {
                MessageBox.Show("Invalid Number", "GL");
                txtCreditLimit.Focus();
            }
            else
            {
                txtCreditLimit.Text = Convert.ToDouble(txtCreditLimit.Text).ToString("N2");
            }
        }

        private void cboChannel_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().emptytxt(cboChannel.Text))
            {
            }
            else if (cboChannel.Text != null && cboChannel.SelectedValue == null)
            {
                MessageBox.Show("Not found", "GL");
                cboChannel.Focus();
            }
        }

        private void cboGeographical_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().emptytxt(cboGeographical.Text))
            {
            }
            else if (cboGeographical.Text != null && cboGeographical.SelectedValue == null)
            {
                MessageBox.Show("Not found", "GL");
                cboGeographical.Focus();
            }
        }

        private void cboSalesman_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().emptytxt(cboSalesman.Text))
            {
            }
            else if (cboSalesman.Text != null && cboSalesman.SelectedValue == null)
            {
                MessageBox.Show("Not found", "GL");
                cboSalesman.Focus();
            }
        }

        private void cboRegion_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().emptytxt(cboRegion.Text))
            {
            }
            else if (cboRegion.Text != null && cboRegion.SelectedValue == null)
            {
                MessageBox.Show("Not found", "GL");
                cboRegion.Focus();
            }
        }

        private void cboSellingPrice_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().emptytxt(cboSellingPrice.Text))
            {
            }
            else if (cboSellingPrice.Text != null && cboSellingPrice.SelectedValue == null)
            {
                MessageBox.Show("Not found", "GL");
                cboSellingPrice.Focus();
            }
        }




    }
}
