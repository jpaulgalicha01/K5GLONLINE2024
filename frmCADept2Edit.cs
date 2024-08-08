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
    public partial class frmCADept2Edit : Form
    {
        SqlConnection myconnection;
        //SqlDataReader dr;
        SqlCommand mycommand;
        BindingSource dbind = new BindingSource();
        ClsBuildCOAComboBox ClsBuildCOAComboBox1 = new ClsBuildCOAComboBox();
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection(); 

        public frmCADept2Edit()
        {
            InitializeComponent();
        }
   
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buildcboD2Code()
        {
            ClsBuildCOAComboBox1.ClsbuildCboD2Code();
            this.cboD2Code.DataSource = (ClsBuildCOAComboBox1.ARcboD2Code);
            this.cboD2Code.DisplayMember = "Display";
            this.cboD2Code.ValueMember = "Value";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            if (new ClsValidation().emptytxt(cboD2Code.Text))
            {
                myconnection.Close();
                MessageBox.Show("Please complete your entry", "GL");
                cboD2Code.Focus();
            }

            else if (new ClsValidation().emptytxt(txtD2Desc.Text))
            {
                myconnection.Close();
                MessageBox.Show("Please complete your entry", "GL");
                txtD2Desc.Focus();
            }

            else if (new Clsexist().RecordExists(ref myconnection, "SELECT D2Desc FROM tblDept2 WHERE D2Desc ='" + txtD2Desc.Text + "'"))
            {
                myconnection.Close();
                MessageBox.Show("Duplicate entry", "GL");
                txtD2Desc.Focus();
            }

            else
            {
                string sqlstatement;
                sqlstatement = "UPDATE tblDept2 set D2Desc=@_D2Desc  WHERE D2Code ='" + cboD2Code.SelectedValue + "'";
                mycommand = new SqlCommand(sqlstatement, myconnection);
                mycommand.Parameters.Add("_D2Desc", SqlDbType.VarChar).Value = txtD2Desc.Text;
                mycommand.CommandTimeout = 600;
                int n2 = mycommand.ExecuteNonQuery();

                cboD2Code.Text = "";
                txtD2Desc.Text = "";
                txtD2Desc.Focus();
                myconnection.Close();
                cboD2Code.DataSource = null;
                ClsBuildCOAComboBox1.ARcboD2Code.Clear();
                buildcboD2Code();
               // dr.Close();
            
            }
        }

        private void frmCADept2_Load(object sender, EventArgs e)
        {
            ClsPermission1.ClsObjects(this.Text);
            if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
            {
                MessageBox.Show("You do not have necessary permission to open this file", "GL");
                this.Close();
            }
            else
            {

                buildcboD2Code();
            }
        }
        private void txtD2Desc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
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

        private void cboD2Code_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtD2Desc.Text = cboD2Code.Text;
        }

      

     
    
    }
}
