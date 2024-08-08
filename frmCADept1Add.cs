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
    public partial class frmCADept1Add : Form
    {
        SqlConnection myconnection;
        //SqlDataReader dr;
        SqlCommand mycommand;
        BindingSource dbind = new BindingSource();
        ClsAutoNumber ClsAutoNumber1 = new ClsAutoNumber();
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection(); 

        public frmCADept1Add()
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
            if (string.IsNullOrEmpty(txtD1Desc.Text))
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
                ClsAutoNumber1.Dept1AutoNum();
                txtD1Code.Text = (ClsAutoNumber1.plsnumber);
                string sqlstatement;
                sqlstatement = "INSERT INTO tblDept1 (D1Code, D1Desc) Values (@_D1Code, @_D1Desc)";
                mycommand = new SqlCommand(sqlstatement, myconnection);
                mycommand.Parameters.Add("_D1Code", SqlDbType.VarChar).Value = txtD1Code.Text;
                mycommand.Parameters.Add("_D1Desc", SqlDbType.VarChar).Value = txtD1Desc.Text;
                mycommand.CommandTimeout = 600;
                int n2 = mycommand.ExecuteNonQuery();
            
                txtD1Desc.Text = "";
                txtD1Desc.Focus();
                //mycommand = new SqlCommand("SELECT BankCode FROM tblBank ORDER BY BankCode ASC", myconnection);
                //mycommand.CommandTimeout = 600;
                //dr = mycommand.ExecuteReader();
                myconnection.Close();
               // dr.Close();
                ClsAutoNumber1.Dept1AutoNum();
                txtD1Code.Text = (ClsAutoNumber1.plsnumber);

            }
        }

        private void frmCADept1Add_Load(object sender, EventArgs e)
        {
             ClsPermission1.ClsObjects(this.Text);
             if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
             {
                 MessageBox.Show("You do not have necessary permission to open this file", "GL");
                 this.Close();
             }
             else
             {
                 ClsAutoNumber1.Dept1AutoNum();
                 txtD1Code.Text = (ClsAutoNumber1.plsnumber);
             }
        }

        private void txtD1Desc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }

        }

      

     
    
    }
}
