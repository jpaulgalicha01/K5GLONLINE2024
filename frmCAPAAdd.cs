using System;
using System.Collections;
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
    public partial class frmCAPAAdd : Form
    {
        SqlConnection myconnection;
        //SqlDataReader dr;
        SqlCommand mycommand;
        BindingSource dbind = new BindingSource();
        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection(); 

        public frmCAPAAdd()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
 

        private void buildcboAcctNo()
        {
            cboAcctNo.DataSource = null;
            ClsBuildComboBox1.ARAN.Clear();
            ClsBuildComboBox1.ClsBuildAcctNo();
            this.cboAcctNo.DataSource = (ClsBuildComboBox1.ARAN);
            this.cboAcctNo.DisplayMember = "Display";
            this.cboAcctNo.ValueMember = "Value";
        }

        private void buildcboD1Code()
        {
            cboD1Code.DataSource = null;
            ClsBuildComboBox1.ARD1.Clear();
            ClsBuildComboBox1.ClsBuildD1Code();
            this.cboD1Code.DataSource = (ClsBuildComboBox1.ARD1);
            this.cboD1Code.DisplayMember = "Display";
            this.cboD1Code.ValueMember = "Value";
        }

        private void buildcboD2Code()
        {
            cboD2Code.DataSource = null;
            ClsBuildComboBox1.ARD2.Clear();
            ClsBuildComboBox1.ClsBuildD2Code();
            this.cboD2Code.DataSource = (ClsBuildComboBox1.ARD2);
            this.cboD2Code.DisplayMember = "Display";
            this.cboD2Code.ValueMember = "Value";
        }

        private void frmCAPAAdd_Load(object sender, EventArgs e)
        {
            ClsPermission1.ClsObjects(this.Text);
            if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
            {
                MessageBox.Show("You do not have necessary permission to open this file", "GL");
                this.Close();
            }
            else
            {

                buildcboAcctNo();
                buildcboD1Code();
                buildcboD2Code();
                cboAcctNo.Text = "";
                cboD1Code.Text = "";
                cboD2Code.Text = "";
            }
        }
        private void cboAcctNo_Validating(object sender, CancelEventArgs e)
        {
            try
            {

                if (new ClsValidation().emptytxt(cboAcctNo.Text))
                {
                }
                else if (cboAcctNo.Text != null && cboAcctNo.SelectedValue == null)
                {
                    MessageBox.Show("Not found");
                    cboAcctNo.Focus();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {

            }

        }
        private void cboD1Code_Validating(object sender, CancelEventArgs e)
        {
            try
            {

                if (new ClsValidation().emptytxt(cboD1Code.Text))
                {
                }
                else if (cboD1Code.Text != null && cboD1Code.SelectedValue == null)
                {
                    MessageBox.Show("Not found");
                    cboD1Code.Focus();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void cboD2Code_Validating(object sender, CancelEventArgs e)
        {
            try
            {

                if (new ClsValidation().emptytxt(cboD2Code.Text))
                {
                }
                else if (cboD2Code.Text != null && cboD2Code.SelectedValue == null)
                {
                    MessageBox.Show("Not found");
                    cboD2Code.Focus();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {

            }

        }

        private void btnsave_Click(object sender, EventArgs e)
        {

            string varpa = cboAcctNo.SelectedValue +""+ cboD1Code.SelectedValue +""+ cboD2Code.SelectedValue;

            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            if (new Clsexist().RecordExists(ref myconnection, "SELECT PA FROM tblpa WHERE PA ='" + varpa + "'"))
            {
                myconnection.Close();
                MessageBox.Show("Duplicate entry", "GL");
                cboAcctNo.Focus();
            }
            else if (new ClsValidation().emptytxt(cboAcctNo.Text))
            {
                myconnection.Close();
                MessageBox.Show("Please complete your entry", "GL");
                cboAcctNo.Focus();
            }
            else if (new ClsValidation().emptytxt(cboD1Code.Text))
            {
                myconnection.Close();
                MessageBox.Show("Please complete your entry", "GL");
                cboD1Code.Focus();
            }
            else if (new ClsValidation().emptytxt(cboD2Code.Text))
            {
                myconnection.Close();
                MessageBox.Show("Please complete your entry", "GL");
                cboD2Code.Focus();
            }
            else
            {
                string sqlstatement;
                sqlstatement = "INSERT INTO tblpa (PA, AcctNo, D1Code, D2Code) Values (@_PA, @_AcctNo, @_D1Code, @_D2Code)";
                mycommand = new SqlCommand(sqlstatement, myconnection);
                mycommand.Parameters.Add("_PA", SqlDbType.VarChar).Value = cboAcctNo.SelectedValue +""+ cboD1Code.SelectedValue +""+ cboD2Code.SelectedValue;
                mycommand.Parameters.Add("_AcctNo", SqlDbType.VarChar).Value = cboAcctNo.SelectedValue;
                mycommand.Parameters.Add("_D1Code", SqlDbType.VarChar).Value = cboD1Code.SelectedValue;
                mycommand.Parameters.Add("_D2Code", SqlDbType.VarChar).Value = cboD2Code.SelectedValue;
                mycommand.CommandTimeout = 600;
                int n1 = mycommand.ExecuteNonQuery();
                myconnection.Close();
               // dr.Close();
                cboAcctNo.Text = "";
                cboD1Code.Text = "";
                cboD2Code.Text = "";
                MessageBox.Show("Finished", "GL");
            }
        }
     
    }
}
