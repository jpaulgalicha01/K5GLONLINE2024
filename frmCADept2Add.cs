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
    public partial class frmCADept2 : Form
    {
        SqlConnection myconnection;
        //SqlDataReader dr;
        SqlCommand mycommand;
        BindingSource dbind = new BindingSource();
        ClsAutoNumber ClsAutoNumber1 = new ClsAutoNumber();
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection(); 

        public frmCADept2()
        {
            InitializeComponent();
        }
   
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            if (string.IsNullOrEmpty(txtD2Desc.Text))
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
                ClsAutoNumber1.Dept2AutoNum();
                txtD2Code.Text = (ClsAutoNumber1.plsnumber);
                string sqlstatement;
                sqlstatement = "INSERT INTO tblDept2 (D2Code, D2Desc) Values (@_D2Code, @_D2Desc)";
                mycommand = new SqlCommand(sqlstatement, myconnection);
                mycommand.Parameters.Add("_D2Code", SqlDbType.VarChar).Value = txtD2Code.Text;
                mycommand.Parameters.Add("_D2Desc", SqlDbType.VarChar).Value = txtD2Desc.Text;
                mycommand.CommandTimeout = 600;
                int n2 = mycommand.ExecuteNonQuery();
            
                txtD2Desc.Text = "";
                txtD2Desc.Focus();
                //mycommand = new SqlCommand("SELECT BankCode FROM tblBank ORDER BY BankCode ASC", myconnection);
                //dr = mycommand.ExecuteReader();
                myconnection.Close();
               // dr.Close();
                ClsAutoNumber1.Dept2AutoNum();
                txtD2Code.Text = (ClsAutoNumber1.plsnumber);

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

                ClsAutoNumber1.Dept2AutoNum();
                txtD2Code.Text = (ClsAutoNumber1.plsnumber);
            }
        }
        private void txtD2Desc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }

        }

     
    
    }
}
