using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace K5GLONLINE
{
    public partial class frmUserAdd : Form
    {
        SqlConnection myconnection;
        SqlDataReader dr;
        SqlCommand mycommand;
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection(); 

        public frmUserAdd()
        {
            InitializeComponent();
        }

        static string getMd5Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showAutNum()
        {
            //try
            //{
            //    while (dr.Read())
            //    {
            //        string no1;
            //        int no2;
            //        no1 = dr[0].ToString();
            //        no2 = (int.Parse(no1)) + 1;
            //        txtUserCode.Text = Convert.ToString(no2).PadLeft(4, '0');
            //    }
            //}
            //catch (Exception ex)
            //{
            //    System.Windows.Forms.MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    dr.Close();
            //    myconnection.Close();
            //}
        }

        private void frmUserAdd_Load(object sender, EventArgs e)
        {
                       ClsPermission1.ClsObjects(this.Text);
            if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
            {
                MessageBox.Show("You do not have necessary permission to open this file", "GL");
                this.Close();
            }
        //    ClsGetConnection1.ClsGetConMSSQL(); myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
        //    myconnection.Open();

        //    if (new Clsexist().RecordExists(ref myconnection, "SELECT Right([UserCode],4) AS NumberCode FROM tblUser ORDER BY Right([UserCode],4) ASC;"))
        //    {
        //        mycommand = new SqlCommand("SELECT TOP 5 Right([UserCode],4) AS NumberCode FROM tblUser ORDER BY Right([UserCode],4) ASC;", myconnection);
        //        dr = mycommand.ExecuteReader();
        //        showAutNum();

        //    }
        //    else
        //    {
        //        txtUserCode.Text = "0001";
        //        myconnection.Close();
        //    }
        }

       

        private void showdatainfo()
        {
            try
            {
                while (dr.Read())
                {
                    string no1;
                    int no2;
                    no1 = dr[0].ToString();
                    no2 = (int.Parse(no1)) + 1;

                    txtUserCode.Text = Convert.ToString(no2).PadLeft(4, '0');
                }
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            ClsGetConnection1.ClsGetConMSSQL(); myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            if (new Clsexist().RecordExists(ref myconnection, "SELECT UserName FROM tblUser WHERE UserName ='" + txtUserName.Text + "'"))
            {
                myconnection.Close();
                MessageBox.Show("Account Name already exist", "FMS");
                txtUserName.Focus();
            }
            else if (string.IsNullOrEmpty (txtUserName.Text))
            {
                myconnection.Close();
                MessageBox.Show("Please complete your entry", "FMS");
                txtUserName.Focus();
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                myconnection.Close();
                MessageBox.Show("Please complete your entry", "FMS");
                txtPassword.Focus();
            }
            else if (string.IsNullOrEmpty(txtVerify.Text))
            {
                myconnection.Close();
                MessageBox.Show("Please complete your entry", "FMS");
                txtVerify.Focus();
            }
            else if (txtPassword.Text != txtVerify.Text)
            {
                myconnection.Close();
                MessageBox.Show("Verify your password by retyping it to Verify Box", "FMS");
                txtVerify.Focus();
            }
            else
            {
                    string sqlstatement;
                    sqlstatement = "INSERT INTO tblUser (UserName, UserCode, PWord, GroupCode) Values (@_UserName, @_UserCode, @_PWord, @_GroupCode)";
                    mycommand = new SqlCommand(sqlstatement, myconnection);
                    mycommand.Parameters.Add("_UserName", SqlDbType.VarChar).Value = txtUserName.Text;
                    mycommand.Parameters.Add("_UserCode", SqlDbType.VarChar).Value = txtUserName.Text;
                    mycommand.Parameters.Add("_PWord", SqlDbType.VarChar).Value = getMd5Hash(txtPassword.Text);
                    mycommand.Parameters.Add("_GroupCode", SqlDbType.VarChar).Value = "01";
                    //mycommand.Parameters.Add("_UserCode", SqlDbType.VarChar).Value = txtUserName.Text;
                    mycommand.CommandTimeout = 600;    
                    int n1 = mycommand.ExecuteNonQuery();

                    //mycommand = new SqlCommand("SELECT TOP 5 Right([UserCode],4) AS NumberCode FROM tblUser ORDER BY Right([UserCode],4) ASC;", myconnection);   
                    //dr = mycommand.ExecuteReader();
                    //showdatainfo();
                    //dr.Close();
                    myconnection.Close();

                    txtUserName.Text="";
                    txtPassword.Text = "";
                    txtVerify.Text = "";
                    txtUserName.Focus();

                
        
            }

        }


    }
}
