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
    public partial class frmCAPAEdit : Form
    {
        SqlConnection myconnection;
        SqlDataReader dr;
        SqlCommand mycommand;
        BindingSource dbind = new BindingSource();
        ClsBuildCOAComboBox ClsBuildCOAComboBox1 = new ClsBuildCOAComboBox();
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection(); 

        public frmCAPAEdit()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buildcboAcctNo()
        {
            ClsBuildCOAComboBox1.ClsbuildCboActCode();
            this.cboAcctNo.DataSource = (ClsBuildCOAComboBox1.ARcboactcode);
            this.cboAcctNo.DisplayMember = "Display";
            this.cboAcctNo.ValueMember = "Value";
        }

        private void buildcboD1Code()
        {
            ClsBuildCOAComboBox1.ClsbuildCboD1Code();
            this.cboD1Code.DataSource = (ClsBuildCOAComboBox1.ARcboD1Code);
            this.cboD1Code.DisplayMember = "Display";
            this.cboD1Code.ValueMember = "Value";
        }

        private void buildcboD2Code()
        {
            ClsBuildCOAComboBox1.ClsbuildCboD2Code();
            this.cboD2Code.DataSource = (ClsBuildCOAComboBox1.ARcboD2Code);
            this.cboD2Code.DisplayMember = "Display";
            this.cboD2Code.ValueMember = "Value";
        }

        private void buildcboSearchPA()
        {
            ClsBuildCOAComboBox1.ClsbuildCboSearchPA();
            this.cboSearchPA.DataSource = (ClsBuildCOAComboBox1.ARcboSearchPA);
            this.cboSearchPA.DisplayMember = "Display";
            this.cboSearchPA.ValueMember = "Value";
        }

        private void getCOADetails()
        {
            try
            {
                string sql;
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                sql = "SELECT AcctNo, D1Code, D2Code From tblPA WHERE PA = '" + cboSearchPA.SelectedValue + "'";
                mycommand = new SqlCommand(sql, myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    cboAcctNo.SelectedValue = dr["AcctNo"].ToString();
                    cboD1Code.SelectedValue  = dr["D1Code"].ToString();
                    cboD2Code.SelectedValue = dr["D2Code"].ToString();
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

                buildcboSearchPA();
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
            string varpa = cboAcctNo.SelectedValue + "" + cboD1Code.SelectedValue + "" + cboD2Code.SelectedValue;
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();

            if (new Clsexist().RecordExists(ref myconnection, "SELECT PA FROM tblpa WHERE PA ='" + varpa + "'"))
            {
                myconnection.Close();
                MessageBox.Show("Duplicate entry", "GL");
                cboAcctNo.Focus();
            }
            else if (new ClsValidation().emptytxt(cboSearchPA.Text))
            {
                myconnection.Close();
                MessageBox.Show("Please complete your entry", "GL");
                cboSearchPA.Focus();
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
                sqlstatement = "UPDATE tblPA set PA=@_PA, AcctNo=@_AcctNo, D1Code=@_D1Code, D2Code=@_D2Code WHERE PA= '" + cboSearchPA.SelectedValue + "'";
                mycommand = new SqlCommand(sqlstatement, myconnection);
                mycommand.Parameters.Add("_PA", SqlDbType.VarChar).Value = cboAcctNo.SelectedValue + "" + cboD1Code.SelectedValue + "" + cboD2Code.SelectedValue;
                mycommand.Parameters.Add("_AcctNo", SqlDbType.VarChar).Value = cboAcctNo.SelectedValue;
                mycommand.Parameters.Add("_D1Code", SqlDbType.VarChar).Value = cboD1Code.SelectedValue;
                mycommand.Parameters.Add("_D2Code", SqlDbType.VarChar).Value = cboD2Code.SelectedValue;
                mycommand.CommandTimeout = 600;
                int n1 = mycommand.ExecuteNonQuery();
                myconnection.Close();
                //dr.Close();
                cboAcctNo.Text = "";
                cboD1Code.Text = "";
                cboD2Code.Text = "";
                //cboSearchPA.DataSource = null;
                //ClsBuildCOAComboBox1.ARcboSearchPA.Clear();
                //buildcboSearchPA();
                MessageBox.Show("Finished", "GL");
                this.Close();
            }
        }

        private void cboSearchPA_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (new ClsValidation().emptytxt(cboSearchPA.Text))
                {
                }
                else if (cboSearchPA.Text != null && cboSearchPA.SelectedValue == null)
                {
                    MessageBox.Show("Not found");
                    cboSearchPA.Focus();
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

        private void cboSearchPA_SelectedIndexChanged(object sender, EventArgs e)
        {
            getCOADetails();
        }
     
    }
}
