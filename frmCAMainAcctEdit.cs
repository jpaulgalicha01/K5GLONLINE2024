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
    public partial class frmCAMainAcctEdit : Form
    {
        SqlConnection myconnection;
        SqlDataReader dr;
        SqlCommand mycommand;
        BindingSource dbind = new BindingSource();
        ClsBuildCOAComboBox ClsBuildCOAComboBox1 = new ClsBuildCOAComboBox();
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();

        public frmCAMainAcctEdit()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buildcboBI()
        {
            ClsBuildCOAComboBox1.ClsbuildARBI();
            this.cboBSIS.DataSource = (ClsBuildCOAComboBox1.ARBI);
            this.cboBSIS.DisplayMember = "Display";
            this.cboBSIS.ValueMember = "Value";
        }

        private void buildcboUsage()
        {
            ClsBuildCOAComboBox1.ClsbuildUsage();
            this.cboUsage.DataSource = (ClsBuildCOAComboBox1.ARUsage);
            this.cboUsage.DisplayMember = "Display";
            this.cboUsage.ValueMember = "Value";
        }

        private void buildcboDC()
        {
            ClsBuildCOAComboBox1.ClsbuildDC();
            this.cboDRCR.DataSource = (ClsBuildCOAComboBox1.ARDC);
            this.cboDRCR.DisplayMember = "Display";
            this.cboDRCR.ValueMember = "Value";
        }

        private void buildcboBS()
        {
            ClsBuildCOAComboBox1.ClsbuildBS();
            this.cboBSClass.DataSource = (ClsBuildCOAComboBox1.ARBS);
            this.cboBSClass.DisplayMember = "Display";
            this.cboBSClass.ValueMember = "Value";
        }

        private void buildcboALC()
        {
            ClsBuildCOAComboBox1.ClsbuildALC();
            this.cboALC.DataSource = (ClsBuildCOAComboBox1.ARALC);
            this.cboALC.DisplayMember = "Display";
            this.cboALC.ValueMember = "Value";
        }

        //private void buildcboFSClass()
        //{
        //    ClsBuildCOAComboBox1.ClsbuildCOAG1();
        //    this.cboFSClass.DataSource = (ClsBuildCOAComboBox1.ARCOAG1);
        //    this.cboFSClass.DisplayMember = "Display";
        //    this.cboFSClass.ValueMember = "Value";
        //}

        //private void buildcboNormalBal()
        //{
        //    ClsBuildCOAComboBox1.ClsbuildCOAG2();
        //    this.cboNormalBal.DataSource = (ClsBuildCOAComboBox1.ARCOAG2);
        //    this.cboNormalBal.DisplayMember = "Display";
        //    this.cboNormalBal.ValueMember = "Value";
        //}

        //private void buildcboFCCode()
        //{
        //    ClsBuildCOAComboBox1.ClsbuildFirstCaption();
        //    this.cboFCCode.DataSource = (ClsBuildCOAComboBox1.ARFCCode);
        //    this.cboFCCode.DisplayMember = "Display";
        //    this.cboFCCode.ValueMember = "Value";
        //}
        //private void buildcboSCCode()
        //{
        //    ClsBuildCOAComboBox1.ClsbuildSecondCaption();
        //    this.cboSCCode.DataSource = (ClsBuildCOAComboBox1.ARSCCode);
        //    this.cboSCCode.DisplayMember = "Display";
        //    this.cboSCCode.ValueMember = "Value";
        //}

        //private void buildcboUsageCode()
        //{
        //    ClsBuildCOAComboBox1.ClsbuildUsage();
        //    this.cboUsageCode.DataSource = (ClsBuildCOAComboBox1.ARUsage);
        //    this.cboUsageCode.DisplayMember = "Display";
        //    this.cboUsageCode.ValueMember = "Value";
        //}

        private void buildcboSearchActNo()
        {
            ClsBuildCOAComboBox1.ClsbuildCboSearchAN1();
            this.cboSearchActNo.DataSource = (ClsBuildCOAComboBox1.ARcboSearchAN1);
            this.cboSearchActNo.DisplayMember = "Display";
            this.cboSearchActNo.ValueMember = "Value";
        }

        private void getCOADetails()
        {
            //try
            //{
                string sql;
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                sql = "SELECT AcctNo, TitleAcct, BI, Classification, BS, DC, Usage From Viewtbltitleacct1 WHERE AcctNo = '" + cboSearchActNo.SelectedValue + "'";
                mycommand = new SqlCommand(sql, myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    txtAcctNo.Text = dr["AcctNo"].ToString();
                    txtTitleAcct.Text = dr["TitleAcct"].ToString();
                    cboBSIS.SelectedValue = dr["BI"].ToString();
                    cboALC.SelectedValue = dr["Classification"].ToString();
                    cboBSClass.SelectedValue = dr["BS"].ToString();
                    cboDRCR.SelectedValue = dr["DC"].ToString();
                    cboUsage.SelectedValue = dr["Usage"].ToString();
                }
                dr.Close();
                myconnection.Close();

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

                buildcboSearchActNo();
                //buildcboFSClass();
                //buildcboNormalBal();
                //buildcboFCCode();
                //buildcboSCCode();
                //buildcboUsageCode();
                buildcboALC();
                buildcboBI();
                buildcboBS();
                buildcboDC();
                buildcboUsage();
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            //try
            //{

                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();

                //if (new Clsexist().RecordExists(ref myconnection, "SELECT AcctNo FROM tblTitleAcct WHERE AcctNo ='" + txtAcctNo.Text + "'"))
                //{
                //    myconnection.Close();
                //    MessageBox.Show("Duplicate entry", "GL");
                //    txtAcctNo.Focus();
                //}

                //else if (new Clsexist().RecordExists(ref myconnection, "SELECT TitleAcct FROM tblTitleAcct WHERE TitleAcct ='" + txtTitleAcct.Text + "'"))
                //{
                //    myconnection.Close();
                //    MessageBox.Show("Duplicate entry", "GL");
                //    txtTitleAcct.Focus();
                //}

                if (new ClsValidation().emptytxt(cboSearchActNo.Text))
                {
                    myconnection.Close();
                    MessageBox.Show("Please complete your entry", "GL");
                    cboSearchActNo.Focus();
                }

                else if (new ClsValidation().emptytxt(txtAcctNo.Text))
                {
                    myconnection.Close();
                    MessageBox.Show("Please complete your entry", "GL");
                    txtAcctNo.Focus();
                }
                else if (new ClsValidation().emptytxt(txtTitleAcct.Text))
                {
                    myconnection.Close();
                    MessageBox.Show("Please complete your entry", "GL");
                    txtTitleAcct.Focus();
                }
                else if (new ClsValidation().emptytxt(cboALC.Text))
                {
                    myconnection.Close();
                    MessageBox.Show("Please complete your entry", "GL");
                    cboALC.Focus();
                }
                else if (new ClsValidation().emptytxt(cboBSClass.Text))
                {
                    myconnection.Close();
                    MessageBox.Show("Please complete your entry", "GL");
                    cboBSClass.Focus();
                }
                else if (new ClsValidation().emptytxt(cboBSIS.Text))
                {
                    myconnection.Close();
                    MessageBox.Show("Please complete your entry", "GL");
                    cboBSIS.Focus();
                }
                else if (new ClsValidation().emptytxt(cboDRCR.Text))
                {
                    myconnection.Close();
                    MessageBox.Show("Please complete your entry", "GL");
                    cboDRCR.Focus();
                }
                else if (new ClsValidation().emptytxt(cboUsage.Text))
                {
                    myconnection.Close();
                    MessageBox.Show("Please complete your entry", "GL");
                    cboUsage.Focus();
                }
                else
                {
                    string sqlstatement;
                    sqlstatement = "UPDATE Viewtbltitleacct1 set AcctNo=@_AcctNo, TitleAcct=@_TitleAcct, BI=@_BI, Classification=@_Classification, BS=@_BS, DC=@_DC, Usage=@_Usage WHERE AcctNo= '" + cboSearchActNo.SelectedValue + "'";
                    mycommand = new SqlCommand(sqlstatement, myconnection);
                    mycommand.Parameters.Add("_AcctNo", SqlDbType.VarChar).Value = txtAcctNo.Text;
                    mycommand.Parameters.Add("_TitleAcct", SqlDbType.VarChar).Value = txtTitleAcct.Text;
                    mycommand.Parameters.Add("_BI", SqlDbType.VarChar).Value = cboBSIS.SelectedValue;
                    mycommand.Parameters.Add("_Classification", SqlDbType.VarChar).Value = cboALC.SelectedValue;
                    mycommand.Parameters.Add("_BS", SqlDbType.VarChar).Value = cboBSClass.SelectedValue;
                    mycommand.Parameters.Add("_DC", SqlDbType.VarChar).Value = cboDRCR.SelectedValue;
                    mycommand.Parameters.Add("_Usage", SqlDbType.VarChar).Value = cboUsage.SelectedValue;
                    mycommand.CommandTimeout = 600;
                    int n1 = mycommand.ExecuteNonQuery();
                    myconnection.Close();
                    //dr.Close();

                    MessageBox.Show("Finished", "GL");
                    this.Close();
                }
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

        private void cboFSClass_Validating(object sender, CancelEventArgs e)
        {
            //try
            //{
            //    if (new ClsValidation().emptytxt(cboFSClass.Text))
            //    {
            //    }
            //    else if (cboFSClass.Text != null && cboFSClass.SelectedValue == null)
            //    {
            //        MessageBox.Show("Not found");
            //        cboFSClass.Focus();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    System.Windows.Forms.MessageBox.Show(ex.Message);
            //}
            //finally
            //{

            //}
        }

        private void cboFCCode_Validating(object sender, CancelEventArgs e)
        {
            //try
            //{
            //    if (new ClsValidation().emptytxt(cboFCCode.Text))
            //    {
            //    }
            //    else if (cboFCCode.Text != null && cboFCCode.SelectedValue == null)
            //    {
            //        MessageBox.Show("Not found");
            //        cboFCCode.Focus();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    System.Windows.Forms.MessageBox.Show(ex.Message);
            //}
            //finally
            //{

            //}
        }

        private void cboSCCode_Validating(object sender, CancelEventArgs e)
        {
            //try
            //{
            //    if (new ClsValidation().emptytxt(cboSCCode.Text))
            //    {
            //    }
            //    else if (cboSCCode.Text != null && cboSCCode.SelectedValue == null)
            //    {
            //        MessageBox.Show("Not found");
            //        cboSCCode.Focus();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    System.Windows.Forms.MessageBox.Show(ex.Message);
            //}
            //finally
            //{

            //}
        }

        private void cboNormalBal_Validating(object sender, CancelEventArgs e)
        {
            //try
            //{
            //    if (new ClsValidation().emptytxt(cboNormalBal.Text))
            //    {
            //    }
            //    else if (cboNormalBal.Text != null && cboNormalBal.SelectedValue == null)
            //    {
            //        MessageBox.Show("Not found");
            //        cboNormalBal.Focus();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    System.Windows.Forms.MessageBox.Show(ex.Message);
            //}
            //finally
            //{

            //}
        }

        private void cboUsageCode_Validating(object sender, CancelEventArgs e)
        {
            //try
            //{
            //    if (new ClsValidation().emptytxt(cboUsageCode.Text))
            //    {
            //    }
            //    else if (cboUsageCode.Text != null && cboUsageCode.SelectedValue == null)
            //    {
            //        MessageBox.Show("Not found");
            //        cboUsageCode.Focus();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    System.Windows.Forms.MessageBox.Show(ex.Message);
            //}
            //finally
            //{

            //}
        }

        private void txtAcctNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtTitleAcct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboFSClass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboFCCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboSCCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboNormalBal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboUsageCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboSearchActNo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (new ClsValidation().emptytxt(cboSearchActNo.Text))
                {
                }
                else if (cboSearchActNo.Text != null && cboSearchActNo.SelectedValue == null)
                {
                    MessageBox.Show("Not found");
                    cboSearchActNo.Focus();
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

        private void cboSearchActNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            getCOADetails();
        }

        private void cboDRCR_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboBSIS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboDRCR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboUsage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboBSClass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboALC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
