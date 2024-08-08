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
    public partial class frmOtherNameAdd : Form
    {
        SqlConnection myconnection;
        SqlCommand mycommand;
        //BindingSource dbind = new BindingSource();
        ClsAutoNumber ClsAutoNumber1 = new ClsAutoNumber();
        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection(); 

        public frmOtherNameAdd()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

                ClsAutoNumber1.OtherNameAdd();
                txtCustCode.Text = (ClsAutoNumber1.plsnumber);
            }
        }

     



        private void savedata()
        {
            try
            {

            ClsAutoNumber1.OtherNameAdd();
            txtCustCode.Text = (ClsAutoNumber1.plsnumber);

            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            
                if (new Clsexist().RecordExists(ref myconnection, "SELECT CustName FROM tblCustomer WHERE CustName = '" + txtCustName.Text + "'"))
                {
                    myconnection.Close();
                    MessageBox.Show("Duplicate entry", "GL");
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

                else
                {
                    ClsAutoNumber1.OtherNameAdd();
                    txtCustCode.Text = (ClsAutoNumber1.plsnumber);
   
                    string sqlstatement;
                    sqlstatement = "INSERT INTO tblCustomer (ControlNo, CustName, ContactNo, Address, NType)";
                    sqlstatement += "Values (@_ControlNo, @_CustName, @_ContactNo, @_Address, @_NType)";

                    mycommand = new SqlCommand(sqlstatement, myconnection);
                    mycommand.Parameters.Add("_ControlNo", SqlDbType.VarChar).Value = txtCustCode.Text;
                    mycommand.Parameters.Add("_CustCode", SqlDbType.VarChar).Value = txtCustCode.Text;
                    mycommand.Parameters.Add("_CustName", SqlDbType.VarChar).Value = txtCustName.Text;
                    mycommand.Parameters.Add("_ContactNo", SqlDbType.VarChar).Value = txtContactNo.Text;
                    mycommand.Parameters.Add("_Address", SqlDbType.VarChar).Value = txtAddress.Text;
                    mycommand.Parameters.Add("_NType", SqlDbType.VarChar).Value = "O";
                    mycommand.CommandTimeout = 600;
                    int n1 = mycommand.ExecuteNonQuery();

                    ClsAutoNumber1.OtherNameAdd();
                    txtCustCode.Text = (ClsAutoNumber1.plsnumber);
                    myconnection.Close();

                    txtCustName.Clear();
                    txtContactNo.Text = "NA";
                    txtAddress.Text = "NA";
                    txtCustName.Focus();
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

       
      
    }
}
