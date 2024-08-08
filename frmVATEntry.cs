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
        
    public partial class frmVATEntry : Form
    {
        ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();
        ClsGetSomething ClsGetSomething1 = new ClsGetSomething(); 
        SqlConnection myconnection;
        SqlCommand mycommand;
        SqlDataReader dr;
        //private SqlDataAdapter da;
        //private DataTable dataTable = null;
        BindingSource dbind = new BindingSource();
        //private BindingSource bindingSource = null;
        //private string psrefer, psdate, psbal, psNormalBal;
        public static TextBox glbltxtVoucher, glbltxtrefer;
        private string varpa, varnet;
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection(); 

        //DataSet ds = new DataSet();
        public frmVATEntry()
        {
            InitializeComponent();
        }

        private void frmVATEntry_Load(object sender, EventArgs e)
        {
            glbltxtVoucher = txtVoucher;
            glbltxtrefer = txtrefer;
            buildcboPA();
            buildcboPAVAT();
        }

        private void buildcboPA()
        {
            cboPAVAT.DataSource = null;
            ClsBuildComboBox1.ARPA.Clear();
            ClsBuildComboBox1.ClsBuildPA(Convert.ToBoolean(cbAccountNo.CheckState));
            this.cboPA.DataSource = (ClsBuildComboBox1.ARPA);
            this.cboPA.DisplayMember = "Display";
            this.cboPA.ValueMember = "Value";
            this.cboPA.DropDownWidth = 450;
        }

        private void buildcboPAVAT()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL(); myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT PA, AT FROM viewpa WHERE Usage='05' OR Usage='06' OR Usage='15'OR Usage='16' ORDER by AT", myconnection);
                ArrayList T = new ArrayList();
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    T.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
                }
                dr.Close();
                myconnection.Close();

                this.cboPAVAT.DataSource = T;
                this.cboPAVAT.DisplayMember = "Display";
                this.cboPAVAT.ValueMember = "Value";
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
 
 
        private void btnRecord_Click(object sender, EventArgs e)
        {
            if (new ClsValidation().emptytxt(txtrefer.Text))
            {
                MessageBox.Show("Please complete your entry", "GL");
                dgv1.Focus();
            }
            else
            {
                
                if (txtVoucher.Text == "JV")
                {
                    DataGridViewRow row = null;
                    for (int x = 0; x < dgv1.Rows.Count - 1; x++)
                    {
                        row = dgv1.Rows[x];
                        this.dgv1.CurrentCell = this.dgv1[1, x];
                        ClsGetSomething1.ClsGetAT(varpa);
                        frmVoucherJV.glbldgv1.Rows.Add(varpa, ClsGetSomething1.plsAT, txtrefer.Text, "NA", varnet, "0.00", 1);
                    }
                    ClsGetSomething1.ClsGetAT(cboPAVAT.SelectedValue.ToString());
                    frmVoucherJV.glbldgv1.Rows.Add(cboPAVAT.SelectedValue, ClsGetSomething1.plsAT, txtrefer.Text, "NA", txtTVAT.Text, "0.00", 1);
                }
                else if (txtVoucher.Text == "CV")
                {
                    DataGridViewRow row = null;
                    for (int x = 0; x < dgv1.Rows.Count - 1; x++)
                    {
                        row = dgv1.Rows[x];
                        this.dgv1.CurrentCell = this.dgv1[1, x];
                        ClsGetSomething1.ClsGetAT(varpa);
                        frmVoucherCV.glbldgv1.Rows.Add(varpa, ClsGetSomething1.plsAT, txtrefer.Text, "NA", varnet, "0.00", 1);
                    }
                    ClsGetSomething1.ClsGetAT(cboPAVAT.SelectedValue.ToString());
                    frmVoucherCV.glbldgv1.Rows.Add(cboPAVAT.SelectedValue, ClsGetSomething1.plsAT, txtrefer.Text, "NA", txtTVAT.Text, "0.00", 1);
                }
                else if (txtVoucher.Text == "RV")
                {
                    DataGridViewRow row = null;
                    for (int x = 0; x < dgv1.Rows.Count - 1; x++)
                    {
                        row = dgv1.Rows[x];
                        this.dgv1.CurrentCell = this.dgv1[1, x];
                        ClsGetSomething1.ClsGetAT(varpa);
                        frmVoucherRV.glbldgv1.Rows.Add(varpa, ClsGetSomething1.plsAT, txtrefer.Text, "NA", varnet, "0.00", 1);
                    }
                    ClsGetSomething1.ClsGetAT(cboPAVAT.SelectedValue.ToString());
                    frmVoucherRV.glbldgv1.Rows.Add(cboPAVAT.SelectedValue, ClsGetSomething1.plsAT, txtrefer.Text, "NA", txtTVAT.Text, "0.00", 1);
                }
                else if (txtVoucher.Text == "APV")
                {
                    DataGridViewRow row = null;
                    for (int x = 0; x < dgv1.Rows.Count - 1; x++)
                    {
                        row = dgv1.Rows[x];
                        this.dgv1.CurrentCell = this.dgv1[1, x];
                        ClsGetSomething1.ClsGetAT(varpa);
                        frmVoucherAPV.glbldgv1.Rows.Add(varpa, ClsGetSomething1.plsAT, txtrefer.Text, "NA", varnet, "0.00", 1);
                     }
                    ClsGetSomething1.ClsGetAT(cboPAVAT.SelectedValue.ToString());
                    frmVoucherAPV.glbldgv1.Rows.Add(cboPAVAT.SelectedValue, ClsGetSomething1.plsAT, txtrefer.Text, "NA", txtTVAT.Text, "0.00", 1);
                }

                else if (txtVoucher.Text == "ARV")
                {
                     DataGridViewRow row = null;
                     for (int x = 0; x < dgv1.Rows.Count - 1; x++)
                     {
                         row = dgv1.Rows[x];
                         this.dgv1.CurrentCell = this.dgv1[1, x];
                         ClsGetSomething1.ClsGetAT(varpa);
                         frmVoucherARV.glbldgv1.Rows.Add(varpa, ClsGetSomething1.plsAT, txtrefer.Text, "NA", varnet, "0.00", 1);
                     }
                     ClsGetSomething1.ClsGetAT(cboPAVAT.SelectedValue.ToString());
                     frmVoucherARV.glbldgv1.Rows.Add(cboPAVAT.SelectedValue, ClsGetSomething1.plsAT, txtrefer.Text, "NA", txtTVAT.Text, "0.00", 1);
                }
                glbldgv1total();
                this.Close();
            }
        }

        private void nextfieldenter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

 

        private void dgv1total()
        {
            double vartxtgross = 0.00;
            double vartxtvat = 0.00;
            double vartxtnet = 0.00;

                for (int x = 0; x < dgv1.Rows.Count - 1; x++)
                {
                    vartxtgross += double.Parse(dgv1.Rows[x].Cells[2].FormattedValue.ToString());
                    vartxtvat += double.Parse(dgv1.Rows[x].Cells[3].FormattedValue.ToString());
                    vartxtnet += double.Parse(dgv1.Rows[x].Cells[4].FormattedValue.ToString());
                }
                txtTGross.Text = vartxtgross.ToString("N2");
                txtTVAT.Text = vartxtvat.ToString("N2");
                txtTNet.Text = vartxtnet.ToString("N2");

        }

        private void cboPAVAT_Validating(object sender, CancelEventArgs e)
        {
            if (new ClsValidation().emptytxt(cboPAVAT.Text))
            {
            }
            else if (cboPAVAT.Text != null && cboPAVAT.SelectedValue == null)
            {
                MessageBox.Show("Not found", "GL");
                cboPAVAT.Focus();
            }
 
        }

        private void dgv1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            dgv1total();
        }

        private void dgv1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            string[] values = new string[5];
            DataGridViewRow row = dgv1.Rows[e.RowIndex];
            ClsValidatorformVAT ClsValidatorformVAT = null;

            values[0] = row.Cells[0].FormattedValue.ToString().Trim();
            values[1] = row.Cells[1].FormattedValue.ToString();
            values[2] = row.Cells[2].FormattedValue.ToString();
            values[3] = row.Cells[3].FormattedValue.ToString();
            values[4] = row.Cells[4].FormattedValue.ToString();

            if (!String.IsNullOrEmpty(values[0]) || !String.IsNullOrEmpty(values[1]) ||
       !String.IsNullOrEmpty(values[2]) || !String.IsNullOrEmpty(values[3]) || !String.IsNullOrEmpty(values[4]))
            {
                ClsValidatorformVAT = new ClsValidatorformVAT(dgv1);
                ClsValidatorformVAT.values(values);
                if (!ClsValidatorformVAT.validate())
                    e.Cancel = true;
                //else
                //    trimValues(e.RowIndex);

            }
        }

        private void dgv1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            }
 
        }

        private void dgv1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgv1.IsCurrentCellDirty)
            {
                dgv1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }

        }

        private void dgv1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgv1.Columns["txtGross"].Index)  //this is our numeric column
            {
                if (String.IsNullOrEmpty(e.FormattedValue.ToString()))// &&
                //dgv1[e.ColumnIndex, e.RowIndex].IsInEditMode)
                {
                    e.Cancel = false;
                }
                else
                {
                    double i;
                    if (!double.TryParse(Convert.ToString(e.FormattedValue), out i))
                    {
                        e.Cancel = true;
                        MessageBox.Show("Numeric only");
                    }
                }
            }
            else if (e.ColumnIndex == dgv1.Columns["txtVAT"].Index)  //this is our numeric column
            {
                if (String.IsNullOrEmpty(e.FormattedValue.ToString()))// &&
                //dgv1[e.ColumnIndex, e.RowIndex].IsInEditMode)
                {
                    e.Cancel = false;
                }
                else
                {
                    double i;
                    if (!double.TryParse(Convert.ToString(e.FormattedValue), out i))
                    {
                        e.Cancel = true;
                        MessageBox.Show("Numeric only");
                    }
                }
            }

            else if (e.ColumnIndex == dgv1.Columns["txtNet"].Index)  //this is our numeric column
            {
                if (String.IsNullOrEmpty(e.FormattedValue.ToString()))// &&
                //dgv1[e.ColumnIndex, e.RowIndex].IsInEditMode)
                {
                    e.Cancel = false;
                }
                else
                {
                    double i;
                    if (!double.TryParse(Convert.ToString(e.FormattedValue), out i))
                    {
                        e.Cancel = true;
                        MessageBox.Show("Numeric only");
                    }
                }
            }


        }

        private void dgv1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Clear the row error in case the user presses ESC.   
            dgv1.Rows[e.RowIndex].ErrorText = String.Empty;

            if (e.ColumnIndex == dgv1.Columns["cbopa"].Index)
            {
                string[] values = new string[1];
                DataGridViewRow row = dgv1.Rows[e.RowIndex];

                dgv1.CurrentRow.Cells[2].Value = "0.00";
                dgv1.CurrentRow.Cells[3].Value = "0.00";
                dgv1.CurrentRow.Cells[4].Value = "0.00";
                dgv1.CurrentRow.Cells[0].Value = row.Cells[1].Value.ToString();
          
                
                dgv1total();
            }
            else if (e.ColumnIndex == dgv1.Columns["txtGross"].Index)
            {
                this.dgv1.Rows[e.RowIndex].Cells[2].Value = double.Parse(dgv1.Rows[e.RowIndex].Cells[2].FormattedValue.ToString().Trim()).ToString("N2");
                ClsGetSomething1.ClsGetVATRate();
                double VATRate = double.Parse(ClsGetSomething1.plsVATRate);

                double A = Convert.ToDouble(dgv1.CurrentRow.Cells[2].Value);
                dgv1.CurrentRow.Cells[4].Value = (A / VATRate).ToString("N2");
                dgv1.CurrentRow.Cells[3].Value = (A-(A / VATRate)).ToString("N2");
                //double B = Convert.ToDouble(txtTVAT.Text);
                //double C = Convert.ToDouble(txtTGross.Text);
                //    dgv1.CurrentRow.Cells[2].Value = (A + C) - B;
                dgv1total();
            }

            else if (e.ColumnIndex == dgv1.Columns["txtVAT"].Index)
            {
                this.dgv1.Rows[e.RowIndex].Cells[3].Value = double.Parse(dgv1.Rows[e.RowIndex].Cells[3].FormattedValue.ToString().Trim()).ToString("N2");
                dgv1total();
            }

            else if (e.ColumnIndex == dgv1.Columns["txtNet"].Index)
            {
                this.dgv1.Rows[e.RowIndex].Cells[4].Value = double.Parse(dgv1.Rows[e.RowIndex].Cells[4].FormattedValue.ToString().Trim()).ToString("N2");
                dgv1total();
            }

        }

        private void dgv1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgv1.Rows[e.RowIndex];

            varpa = row.Cells[0].FormattedValue.ToString();
            varnet = row.Cells[4].FormattedValue.ToString();
        }

        private void glbldgv1total()
        {
            double vartxtdr = 0.00;
            double vartxtcr = 0.00;
            double vartxtdiff = 0.00;

            if (txtVoucher.Text == "JV")
            {
                for (int x = 0; x < frmVoucherJV.glbldgv1.Rows.Count - 1; x++)
                {
                    vartxtdr += double.Parse(frmVoucherJV.glbldgv1.Rows[x].Cells[4].FormattedValue.ToString());
                }

                for (int x = 0; x < frmVoucherJV.glbldgv1.Rows.Count - 1; x++)
                {
                    vartxtcr += double.Parse(frmVoucherJV.glbldgv1.Rows[x].Cells[5].FormattedValue.ToString());
                }
                frmVoucherJV.glbltxtdrtot.Text = vartxtdr.ToString("n2");
                frmVoucherJV.glbltxtcrtot.Text = vartxtcr.ToString("n2");
                vartxtdiff = Convert.ToDouble(frmVoucherJV.glbltxtdrtot.Text) - Convert.ToDouble(frmVoucherJV.glbltxtcrtot.Text);
                frmVoucherJV.glbltxtDifference.Text = vartxtdiff.ToString("n2");
            }
            else if (txtVoucher.Text == "CV")
            {
                for (int x = 0; x < frmVoucherCV.glbldgv1.Rows.Count - 1; x++)
                {
                    vartxtdr += double.Parse(frmVoucherCV.glbldgv1.Rows[x].Cells[4].FormattedValue.ToString());
                }

                for (int x = 0; x < frmVoucherCV.glbldgv1.Rows.Count - 1; x++)
                {
                    vartxtcr += double.Parse(frmVoucherCV.glbldgv1.Rows[x].Cells[5].FormattedValue.ToString());
                }
                frmVoucherCV.glbltxtdrtot.Text = vartxtdr.ToString("n2");
                frmVoucherCV.glbltxtcrtot.Text = vartxtcr.ToString("n2");
                vartxtdiff = Convert.ToDouble(frmVoucherCV.glbltxtdrtot.Text) - Convert.ToDouble(frmVoucherCV.glbltxtcrtot.Text);
                frmVoucherCV.glbltxtDifference.Text = vartxtdiff.ToString("n2");
            }
            else if (txtVoucher.Text == "RV")
            {
                for (int x = 0; x < frmVoucherRV.glbldgv1.Rows.Count - 1; x++)
                {
                    vartxtdr += double.Parse(frmVoucherRV.glbldgv1.Rows[x].Cells[4].FormattedValue.ToString());
                }

                for (int x = 0; x < frmVoucherRV.glbldgv1.Rows.Count - 1; x++)
                {
                    vartxtcr += double.Parse(frmVoucherRV.glbldgv1.Rows[x].Cells[5].FormattedValue.ToString());
                }
                frmVoucherRV.glbltxtdrtot.Text = vartxtdr.ToString("n2");
                frmVoucherRV.glbltxtcrtot.Text = vartxtcr.ToString("n2");
                vartxtdiff = Convert.ToDouble(frmVoucherRV.glbltxtdrtot.Text) - Convert.ToDouble(frmVoucherRV.glbltxtcrtot.Text);
                frmVoucherRV.glbltxtDifference.Text = vartxtdiff.ToString("n2");
            }

 
            else if (txtVoucher.Text == "APV")
            {
                for (int x = 0; x < frmVoucherAPV.glbldgv1.Rows.Count - 1; x++)
                {
                    vartxtdr += double.Parse(frmVoucherAPV.glbldgv1.Rows[x].Cells[4].FormattedValue.ToString());
                }

                for (int x = 0; x < frmVoucherAPV.glbldgv1.Rows.Count - 1; x++)
                {
                    vartxtcr += double.Parse(frmVoucherAPV.glbldgv1.Rows[x].Cells[5].FormattedValue.ToString());
                }
                frmVoucherAPV.glbltxtdrtot.Text = vartxtdr.ToString("n2");
                frmVoucherAPV.glbltxtcrtot.Text = vartxtcr.ToString("n2");
                vartxtdiff = Convert.ToDouble(frmVoucherAPV.glbltxtdrtot.Text) - Convert.ToDouble(frmVoucherAPV.glbltxtcrtot.Text);
                frmVoucherAPV.glbltxtDifference.Text = vartxtdiff.ToString("n2");
            }

            else if (txtVoucher.Text == "ARV")
            {
                for (int x = 0; x < frmVoucherARV.glbldgv1.Rows.Count - 1; x++)
                {
                    vartxtdr += double.Parse(frmVoucherARV.glbldgv1.Rows[x].Cells[4].FormattedValue.ToString());
                }

                for (int x = 0; x < frmVoucherARV.glbldgv1.Rows.Count - 1; x++)
                {
                    vartxtcr += double.Parse(frmVoucherARV.glbldgv1.Rows[x].Cells[5].FormattedValue.ToString());
                }
                frmVoucherARV.glbltxtdrtot.Text = vartxtdr.ToString("n2");
                frmVoucherARV.glbltxtcrtot.Text = vartxtcr.ToString("n2");
                vartxtdiff = Convert.ToDouble(frmVoucherARV.glbltxtdrtot.Text) - Convert.ToDouble(frmVoucherARV.glbltxtcrtot.Text);
                frmVoucherARV.glbltxtDifference.Text = vartxtdiff.ToString("n2");
            }

        }

        private void cbAccountNo_CheckedChanged(object sender, EventArgs e)
        {
            buildcboPA();
        }

     

    }
}
