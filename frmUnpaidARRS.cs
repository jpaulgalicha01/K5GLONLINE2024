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
    public partial class frmUnpaidARRS : Form
    {

        SqlConnection myconnection;
        SqlCommand mycommand;
        SqlDataReader dr;
        BindingSource dbind = new BindingSource();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection(); 

        public frmUnpaidARRS()
        {
            InitializeComponent();
        }

        private void buildlvUnpaidAR()
        {
            try
            {
                LVUnpaidAR.Items.Clear();
                ClsGetConnection1.ClsGetConMSSQL(); myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT Refer, Min(MinDate) As TransactDate, Sum(Balance) AS SumBal FROM [View Aging] GROUP BY Refer, ControlNo HAVING Min(MinDate) <= '" + frmVoucherRS.glbltxtTDate.Text + "' AND Sum(Balance)>0 AND ControlNo='" + frmVoucherRS.glblcboControlNo .SelectedValue.ToString() + "'", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();
                while (dr.Read())
                {
                    DateTime varMaxTDate1 = Convert.ToDateTime(dr["TransactDate"]);
                    string varMaxTDate2 = String.Format("{0:MM/dd/yyyy}", varMaxTDate1);
                    double varSumBal = Convert.ToDouble(dr["SumBal"]);
                    ListViewItem item = new ListViewItem(dr["Refer"].ToString());
                    item.SubItems.Add(varMaxTDate2);
                    item.SubItems.Add(varSumBal.ToString("N2"));
                    LVUnpaidAR.Items.Add(item);
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

        private void frmUnpaidARRS_Load(object sender, EventArgs e)
        {
            buildlvUnpaidAR();
        }

        
        private void LVpso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LVUnpaidAR.SelectedItems.Count > 0)
            {
                ListViewItem itm = LVUnpaidAR.SelectedItems[0];
                txtRefer.Text = itm.SubItems[0].Text;

            }
        }
   
        private void btnPost_Click(object sender, EventArgs e)
        {
            if (new ClsValidation().emptytxt(txtRefer.Text))
            {
                MessageBox.Show("Please complete your entry", "GL");
                LVUnpaidAR.Focus();
            }
            else
            {
                frmVoucherRS.glbltxtUnpdRefer.Text = txtRefer.Text;
                this.Close();
            }
        }

        
    }
}
