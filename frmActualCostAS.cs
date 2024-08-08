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
    public partial class frmActualCostAS : Form
    {

        SqlConnection myconnection;
        SqlCommand mycommand;
        SqlDataReader dr;
        BindingSource dbind = new BindingSource();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection(); 

        public frmActualCostAS()
        {
            InitializeComponent();
        }

        private void buildlvActCost()
        {
            try
            {
                LVActCost.Items.Clear();
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT RefforAC, MaxTDate, SumBal, MaxActualCost FROM ViewActualCostProducts2 WHERE StockNumber = '"+frmVoucherAS.glblcboStockNumber.SelectedValue.ToString()+"'", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();


                while (dr.Read())
                {
                    DateTime varMaxTDate1 = Convert.ToDateTime(dr["MaxTDate"]);
                    string varMaxTDate2 = String.Format("{0:MM/dd/yyyy}", varMaxTDate1);
                    double varSumBal = Convert.ToDouble(dr["SumBal"]);
                    double varMaxActualCost = Convert.ToDouble(dr["MaxActualCost"]);
                    ListViewItem item = new ListViewItem(dr["RefforAC"].ToString());
                    item.SubItems.Add(varMaxTDate2);
                    item.SubItems.Add(varSumBal.ToString("N2"));
                    item.SubItems.Add(varMaxActualCost.ToString("N2"));

                    LVActCost.Items.Add(item);
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

        private void frmActualCostAS_Load(object sender, EventArgs e)
        {
            buildlvActCost();
        }

        
        private void LVpso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LVActCost.SelectedItems.Count > 0)
            {
                ListViewItem itm = LVActCost.SelectedItems[0];
                txtRefforAC.Text = itm.SubItems[0].Text;
                frmVoucherAS.glbltxtCostRef.Text = itm.SubItems[0].Text;
                string varActCost = itm.SubItems[3].Text;
                frmVoucherAS.glbltxtUPCS.Text = varActCost;

                if (Int32.Parse(frmVoucherAS.glbltxtIB.Text) == 0)
                {
                    frmVoucherAS.glbltxtUPIB.Text = "0.00";
                    frmVoucherAS.glbltxtUPPC.Text = (Convert.ToDouble(varActCost) / Convert.ToInt32(frmVoucherAS.glbltxtPiece.Text)).ToString("N2");
                }
                else
                {
                    frmVoucherAS.glbltxtUPIB.Text = (Convert.ToDouble(frmVoucherAS.glbltxtUPCS.Text) / Convert.ToInt32(frmVoucherAS.glbltxtIB.Text)).ToString("N2");
                    frmVoucherAS.glbltxtUPPC.Text = ((Convert.ToDouble(frmVoucherAS.glbltxtUPCS.Text) / Convert.ToInt32(frmVoucherAS.glbltxtIB.Text)) / Convert.ToInt32(frmVoucherAS.glbltxtPiece.Text)).ToString("N2");
                }

                
            }
        }
   
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (new ClsValidation().emptytxt(txtRefforAC.Text))
            {
                MessageBox.Show("Please complete your entry", "GL");
                LVActCost.Focus();
            }
            else
            {
                this.Close();
            }
        }

        
    }
}
