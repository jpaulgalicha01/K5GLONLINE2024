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
using System.IO;
using System.Diagnostics;
namespace K5GLONLINE
{
    public partial class Form1 : Form
    {
        public static TextBox glbluc;
        public static TextBox glblncompany;
        public static TextBox glbladdress;
        public static TextBox glblgroupcode;
        public static TextBox glblservername;
        public static TextBox glblcn;
        public static CheckBox glblcbConnectMode;
        public static Label glblLblVer;

        SqlConnection myconnection;
        SqlCommand mycommand;
        //BindingSource dbind = new BindingSource();
        SqlDataReader dr;
        ClsGetSomething ClsGetSomething1 = new ClsGetSomething();
        //private string varpsopenmsg;
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            okenter();
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

        static bool verifyMd5Hash(string input, string hash)
        {
            // Hash the input.
            string hashOfInput = getMd5Hash(input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void okenter()
        {
            try
            {
                ClsGetSomething1.ClsNewVersion(lblVersion.Text);
                usernameexist();
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();


                if (string.IsNullOrEmpty(txtUserName.Text))
                {
                    MessageBox.Show("Name is empty", "GL");
                    txtUserName.Focus();
                    myconnection.Close();
                }
                else if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("Password is empty", "GL");
                    txtPassword.Focus();
                    myconnection.Close();
                }
                else if (string.IsNullOrEmpty(txtUserExist.Text))
                {
                    MessageBox.Show("User Name does not exist", "GL");
                    txtUserName.Focus();
                    myconnection.Close();
                }

                else if (ClsGetSomething1.plsNewVersion == "Yes")
                {
                    DialogResult result = MessageBox.Show("New Version Available. Do you want to update?", "GL", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        string strFileName = "CbytesInstaller.exe";
                        string strFilePath = Environment.CurrentDirectory + "\\" + strFileName;

                        if (!File.Exists(strFilePath))
                        {
                            MessageBox.Show("Updating Installer Not Exist. Please Contact The Developer", "GL");
                            Application.Exit();
                        }
                        else
                        {
                            System.Diagnostics.Process.Start(strFilePath);
                            Application.Exit();
                        }
                    }
                    else
                    {
                        nextproceed();
                    }

                }
                else
                {
                    nextproceed();
                }

                myconnection.Close();

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                myconnection.Close();
            }

        }

        private void nextproceed()
        {
            ClsGetSomething1.ClsConfirmVersionNum(lblVersion.Text);
            if (ClsGetSomething1.plsVersionGo != "Yes")
            {
                MessageBox.Show("Your current version is not available. Please install new version");
                string strFileName = "CbytesInstaller.exe";
                string strFilePath = Environment.CurrentDirectory + "\\" + strFileName;

                if (!File.Exists(strFilePath))
                {
                    MessageBox.Show("Updating Installer Not Exist. Please Contact The Developer", "GL");
                    Application.Exit();
                }
                else
                {
                    myconnection.Close();
                    System.Diagnostics.Process.Start(strFilePath);
                    Application.Exit();
                }
            }

            else
            {

                if (verifyMd5Hash(txtPassword.Text, txtPasswordExist.Text))
                {
                    this.Hide();
                    frmMain fm = new frmMain();
                    fm.Show();
                }
                else
                {
                    MessageBox.Show("Password is invalid", "GL");
                    txtPassword.Focus();
                }

            }
        }

        private void usernameexist()
        {
            try
            {
                txtUserExist.Clear();
                txtPasswordExist.Clear();
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();

                mycommand = new SqlCommand("SELECT UserName, PWord, GroupCode, UserCode, CNCode FROM tblUser WHERE UserName='" + txtUserName.Text.Trim() + "'", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();
                while (dr.Read())
                {
                    txtUserExist.Text = dr["UserName"].ToString();
                    txtPasswordExist.Text = dr["PWord"].ToString();
                    txtGroupCode.Text = dr["GroupCode"].ToString();
                    txtUserCode.Text = dr["UserCode"].ToString();
                    txtCNCode.Text = dr["CNCode"].ToString();
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

        private void ncompany()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();

                mycommand = new SqlCommand("SELECT Company, Address FROM tblCompany", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();
                while (dr.Read())
                {
                    txtCompany.Text = dr["Company"].ToString();
                    txtaddress.Text = dr["Address"].ToString();
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

        private void Form1_Load(object sender, EventArgs e)
        {

            glbluc = txtUserName;
            glblcn = txtCNCode;
            glblncompany = txtCompany;
            glbladdress = txtaddress;
            glblgroupcode = txtGroupCode;
            glblservername = txtServerName;
            glblcbConnectMode = cbConnectMode;
            glblLblVer = lblVersion;
            // ncompany();

            //checkingNewVer();
        }
        //private void checkingNewVer()
        //{
        //    ClsGetSomething1.ClsNewVersion(lblVersion.Text);
        //    if (ClsGetSomething1.plsVersionGo == "Yes")
        //    {
        //        linkLabel1.Visible = true;
        //    }
        //}
        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                okenter();
            }

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                okenter();
            }

        }

        private void txtaddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbConnectMode_CheckedChanged(object sender, EventArgs e)
        {
            if (cbConnectMode.Checked)
            {
                rbPLDT.Visible = true;
                rbGLOBE.Visible = true;
                rbPLDT.Checked = true;
                //txtServerName.Text = "122.3.37.162";//new IP
                //txtServerName.Text = "124.6.165.160";//temporary
                //txtServerName.Text = "49.145.38.164";
            }
            else
            {
                rbPLDT.Visible = false;
                rbGLOBE.Visible = false;
                txtServerName.Text = "WINSERVER";
                //txtServerName.Text = "WINSERVER\\SQLEXPRESS";
                //txtServerName.Text = "WINSERVER\\MSSQLSERVER2012";
            }
        }

        private void rbPLDT_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPLDT.Checked)
            {
                txtServerName.Text = "122.3.37.162";//new IP PLDT
            }
            else { }
        }

        private void rbGLOBE_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGLOBE.Checked)
            {
                txtServerName.Text = "124.6.165.160";//temporary GLOBE
            }
            else { }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string strFileName = "CbytesInstaller.exe";
            string strFilePath = Environment.CurrentDirectory + "\\" + strFileName;

            if (!File.Exists(strFilePath))
            {
                MessageBox.Show("Updating Installer Not Exist. Please Contact The Developer", "GL");
                Application.Exit();
            }
            else
            {
                System.Diagnostics.Process.Start(strFilePath);
                Application.Exit();
            }
        }
    }
}
