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
    public partial class frmCADept1Edit : Form
    {
        SqlConnection myconnection;
        //SqlDataReader dr;
        SqlCommand mycommand;
        BindingSource dbind = new BindingSource();
        ClsBuildCOAComboBox ClsBuildCOAComboBox1 = new ClsBuildCOAComboBox();
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection(); 

        public frmCADept1Edit()
        {
            InitializeComponent();
        }
   
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buildcboD1Code()
        {
            ClsBuildCOAComboBox1.ClsbuildCboD1Code();
            this.cboD1Code.DataSource = (ClsBuildCOAComboBox1.ARcboD1Code);
            this.cboD1Code.DisplayMember = "Display";
            this.cboD1Code.ValueMember = "Value";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            if (new ClsValidation().emptytxt(cboD1Code.Text))
            {
                myconnection.Close();
                MessageBox.Show("Please complete your entry", "GL");
                cboD1Code.Focus();
            }

            else if (new ClsValidation().emptytxt(txtD1Desc.Text))
            {
                myconnection.Close();
                MessageBox.Show("Please complete your entry", "GL");
                txtD1Desc.Focus();
            }

            else if (new Clsexist().RecordExists(ref myconnection, "SELECT D1Desc FROM tblDept1 WHERE D1Desc ='" + txtD1Desc.Text + "'"))
            {
                myconnection.Close();
                MessageBox.Show("Duplicate entry", "GL");
                txtD1Desc.Focus();
            }

            else
            {
                string sqlstatement;
                sqlstatement = "UPDATE tblDept1 set D1Desc=@_D1Desc  WHERE D1Code ='" + cboD1Code.SelectedValue + "'";
                mycommand = new SqlCommand(sqlstatement, myconnection);
                mycommand.Parameters.Add("_D1Desc", SqlDbType.VarChar).Value = txtD1Desc.Text;
                mycommand.CommandTimeout = 600;
                int n2 = mycommand.ExecuteNonQuery();

                cboD1Code.Text = "";
                txtD1Desc.Text = "";
                txtD1Desc.Focus();
                myconnection.Close();
                cboD1Code.DataSource = null;
                ClsBuildCOAComboBox1.ARcboD1Code.Clear();
                buildcboD1Code();
               // dr.Close();
            
            }
        }

        private void frmCADept1_Load(object sender, EventArgs e)
        {
            ClsPermission1.ClsObjects(this.Text);
            if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
            {
                MessageBox.Show("You do not have necessary permission to open this file", "GL");
                this.Close();
            }
            else
            {

                buildcboD1Code();
            }
        }
        private void txtD1Desc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
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

        private void cboD1Code_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtD1Desc.Text = cboD1Code.Text;
        }

      

     
    
    }
}
