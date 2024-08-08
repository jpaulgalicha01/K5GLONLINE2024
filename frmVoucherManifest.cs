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
using CrystalDecisions.CrystalReports.Engine;
using System.Threading;
//using K5GLV3.FldrClass;
//using K5GLV3.FldrLog;
using System.Net;
using K5GLONLINE;
//using System.Net.Http;

namespace K5GLONLINE
{
    public partial class frmVoucherManifest : Form
    {
        ClsGetSomethingOthers ClsGetSomethingOthers1 = new ClsGetSomethingOthers();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        ClsBuildVoucherComboBox ClsBuildVoucherComboBox1 = new ClsBuildVoucherComboBox();
        ClsAutoNumber ClsAutoNumber1 = new ClsAutoNumber();
        ClsGetSomething ClsGetSomething1 = new ClsGetSomething();
        DataTable DTTempTable = new DataTable();
        SqlConnection myconnection;

        SqlDataReader SqlDataReader1;
        string strchoose = "1";

        private SqlDataAdapter da;
        private DataTable dataTable = null;
        private BindingSource bindingSource = null;
        SqlCommand mycommand;

        //ClsGetAutoNumber ClsGetAutoNumber1 = new ClsGetAutoNumber();
        //ClsGetSomething ClsGetSomething1 = new ClsGetSomething();
        //ClsGetList ClsGetList1 = new ClsGetList();
        //DataTable DTTempTable = new DataTable();
        //private string pristrIPAddess = new ClsGetSomething().GetIPAddress();

        //ClsBuildComboBox ClsBuildComboBox1 = new ClsBuildComboBox();

        public frmVoucherManifest()
        {
            InitializeComponent();
        }

        private void CreateDTTempTable()
        {
            DTTempTable.Columns.Add("TDate", typeof(DateTime));
            DTTempTable.Columns.Add("Reference", typeof(string));
            DTTempTable.Columns.Add("MNum", typeof(string));
            DTTempTable.Columns.Add("Post", typeof(bool));
            DTTempTable.Columns.Add("IC", typeof(string));

        }
        private void buildcboClsBuildDept()
        {
            cboDVCode.DataSource = null;
            ClsBuildVoucherComboBox1.ARD2Code.Clear();
            ClsBuildVoucherComboBox1.ClsBuildDeliveryVan();
            this.cboDVCode.DataSource = (ClsBuildVoucherComboBox1.ARD2Code);
            this.cboDVCode.DisplayMember = "Display";
            this.cboDVCode.ValueMember = "Value";
        }

        private void ContentLoad()
        {
            dgv1.DataSource = null;
            dgv1.Columns.Clear();
            DTTempTable.Rows.Clear();

            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();

            SqlCommand mycommand = new SqlCommand("usp_manifest", myconnection);
            mycommand.CommandType = CommandType.StoredProcedure;

            mycommand.Parameters.Add("@BeginDate", SqlDbType.DateTime).Value = txtBegDate.Text;
            mycommand.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = txtEndDate.Text;
            mycommand.Parameters.Add("@WHCode", SqlDbType.Char).Value = cboWHCode.SelectedValue.ToString();
            mycommand.CommandTimeout = 900;
            int n1 = mycommand.ExecuteNonQuery();
            //myconnection.Close();

            //string sqlstatement;
            //ClsGetConnection1.ClsGetConMSSQL();
            //myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            //sqlstatement = "SELECT TDate, Reference, MNum, 0 AS Post, IC FROM ViewManifest WHERE (WHCode = '" + cboWHCode.SelectedValue.ToString() + "' AND TDate Between '" + txtBegDate.Text + "' AND '" + txtEndDate.Text + "') OR (WHCodeTF = '" + cboWHCode.SelectedValue.ToString() + "' AND TDate Between '" + txtBegDate.Text + "' AND '" + txtEndDate.Text + "' )";
            //da = new SqlDataAdapter(sqlstatement, myconnection);
            da = new SqlDataAdapter(mycommand);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
            da.SelectCommand.CommandTimeout = 600;
            dataTable = new DataTable();
            da.Fill(dataTable);

            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("No data found", "GL");
                return;
            }

            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;

            DataGridViewTextBoxColumn ColumnTDate = new DataGridViewTextBoxColumn();
            ColumnTDate.HeaderText = "Date";
            ColumnTDate.Width = 100;
            ColumnTDate.DataPropertyName = "TDate";
            ColumnTDate.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnTDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnTDate.ReadOnly = true;
            dgv1.Columns.Add(ColumnTDate);

            DataGridViewTextBoxColumn ColumnReference = new DataGridViewTextBoxColumn();
            ColumnReference.HeaderText = "Reference";
            ColumnReference.Width = 140;
            ColumnReference.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnReference.DataPropertyName = "Reference";
            ColumnReference.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnReference.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnReference.ReadOnly = true;
            dgv1.Columns.Add(ColumnReference);

            DataGridViewTextBoxColumn ColumnMNum = new DataGridViewTextBoxColumn();
            ColumnMNum.HeaderText = "Number";
            ColumnMNum.Width = 140;
            ColumnMNum.DataPropertyName = "MNum";
            ColumnMNum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnMNum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnMNum.ReadOnly = true;
            dgv1.Columns.Add(ColumnMNum);

            DataGridViewCheckBoxColumn cbPost = new DataGridViewCheckBoxColumn();
            cbPost.HeaderText = "Post";
            cbPost.Width = 50;
            cbPost.DataPropertyName = "Post";
            cbPost.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cbPost.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cbPost.ReadOnly = false;
            dgv1.Columns.Add(cbPost);

            DataGridViewTextBoxColumn ColumnIC = new DataGridViewTextBoxColumn();
            ColumnIC.HeaderText = "IC";
            ColumnIC.Width = 140;
            ColumnIC.DataPropertyName = "IC";
            ColumnIC.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnIC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnIC.ReadOnly = true;
            ColumnIC.Visible = false;
            dgv1.Columns.Add(ColumnIC);

            dgv1.DataSource = bindingSource;
            myconnection.Close();
        }
        private void buildcboWHCode()
        {
            ClsBuildVoucherComboBox1.ClsBuildWarehouse();
            this.cboWHCode.DataSource = (ClsBuildVoucherComboBox1.ARLWHCode);
            this.cboWHCode.DisplayMember = "Display";
            this.cboWHCode.ValueMember = "Value";
        }
        private void frmNameEdit_Load(object sender, EventArgs e)
        {
            //CreateDTTempTable();   
            ClsAutoNumber1.VoucherManifest();
            txtMNum.Text = (ClsAutoNumber1.plsnumber);
            ClsGetSomething1.ClsGetDefaultDate();
            txtTDate.Text = ClsGetSomething1.plsdefdate;
            txtBegDate.Text = ClsGetSomething1.plsdefdate;
            txtEndDate.Text = ClsGetSomething1.plsdefdate;
            buildcboWHCode();
            buildcboClsBuildDept();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            string sqlstatement;
            string sqlstatementdgv2;

            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            DataGridViewRow row = null;
            if (new ClsValidation().emptytxt(cboDVCode.Text))
            {
                MessageBox.Show("Please complete your entry, Delivery Van", "GL");
                cboDVCode.Focus();
            }
            else if (new ClsValidation().emptytxt(txtDTDesc.Text))
            {
                MessageBox.Show("Please complete your entry, Delivery Team", "GL");
                txtDTDesc.Focus();
            }
            else if (txtTDate.Text == "  /  /")
            {
                MessageBox.Show("Please complete your entry", "GL");
                txtTDate.Focus();
            }
            else if (dgv2.RowCount == 0)
            {
                MessageBox.Show("Please complete your entry", "GL");
            }
            else
            {
                myconnection.Open();
                DateTime DT = DateTime.Now;
                sqlstatementdgv2 = "INSERT INTO tblManifest (MNum, MDate, DVCode, DTDesc, UserName, DE) ";
                sqlstatementdgv2 += "Values (@_MNum, @_MDate, @_DVCode, @_DTDesc, @_UserName, @_DE)";
                mycommand = new SqlCommand(sqlstatementdgv2, myconnection);
                mycommand.Parameters.Add("_MNum", SqlDbType.Char).Value = txtMNum.Text;
                mycommand.Parameters.Add("_MDate", SqlDbType.SmallDateTime).Value = Convert.ToDateTime(txtTDate.Text);
                mycommand.Parameters.Add("_DVCode", SqlDbType.Char).Value = cboDVCode.SelectedValue.ToString();
                mycommand.Parameters.Add("_DTDesc", SqlDbType.VarChar).Value = txtDTDesc.Text;
                mycommand.Parameters.Add("_UserName", SqlDbType.VarChar).Value = Form1.glbluc.Text;
                mycommand.Parameters.Add("_DE", SqlDbType.SmallDateTime).Value = DT;
                mycommand.CommandTimeout = 600;
                int n2 = mycommand.ExecuteNonQuery();

                myconnection.Close();

                for (int i = 0; i < dgv2.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgv2.Rows[i].Cells[3].Value) == true)
                    {
                        myconnection.Open();
                        row = dgv1.Rows[i];

                        sqlstatement = "UPDATE tblMain1 SET MNum=@_MNum WHERE Reference = '" + dgv2.Rows[i].Cells[1].Value.ToString() + "' ";
                        mycommand = new SqlCommand(sqlstatement, myconnection);
                        mycommand.Parameters.Add("_MNum", SqlDbType.Char).Value = dgv2.Rows[i].Cells[2].Value.ToString();
                        mycommand.CommandTimeout = 600;
                        int n1 = mycommand.ExecuteNonQuery();
                        myconnection.Close();
                    }
                }
                myconnection.Close();

                if (cbPrint.Checked)
                {
                    printcurvoucher();
                } 
                ContentLoad();
                dgv2.Rows.Clear();
                ClsAutoNumber1.VoucherManifest();
                txtMNum.Text = (ClsAutoNumber1.plsnumber);
                ClsGetSomething1.ClsGetDefaultDate();
                cboDVCode.SelectedValue = "";
                txtDTDesc.Text = "";
                txtTDate.Text = ClsGetSomething1.plsdefdate;
                buildcboClsBuildDept();
            }

        }


        private void nextfieldenter2(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }

        }

        private void btnpreview_Click(object sender, EventArgs e)
        {

            DTTempTable.Columns.Clear();
            DTTempTable.Rows.Clear();
            CreateDTTempTable();

            ContentLoad();
        }

        private void printcurvoucher()
        {
            string sqlstatement = "SELECT DVDesc, DTDesc, MNum, MAX(MDate) AS MDate, CustName, PersonnelName, Reference, MAX(TDate) AS TDate, SUM(GrossAmt) AS GrossAmt, UserName ";
            sqlstatement += "FROM ViewBookManifest WHERE MNum ='" + txtMNum.Text + "' GROUP BY DVDesc, DTDesc, MNum, CustName, PersonnelName, Reference, UserName ORDER BY CUSTNAME ASC";
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = myconnection.CreateCommand();
            mycommand.CommandText = sqlstatement;
            mycommand.CommandTimeout = 900;
            SqlDataReader1 = mycommand.ExecuteReader();
            DataTable DataTable1 = new DataTable();
            DataTable1.Load(SqlDataReader1);
            myconnection.Close();
            if (DataTable1.Rows.Count == 0)
            {
                MessageBox.Show("No data found", "GL");
                return;
            }
            CRprevManifest objRpt = new CRprevManifest();
            TextObject vartxtcompany = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtcompany"];
            vartxtcompany.Text = Form1.glblncompany.Text;

            TextObject vartxtaddress = (TextObject)objRpt.ReportDefinition.Sections["Section1"].ReportObjects["rpttxtaddress"];
            vartxtaddress.Text = Form1.glbladdress.Text;

            objRpt.SetDataSource(DataTable1);
            //crystalReportViewer1.ReportSource = objRpt;
            //crystalReportViewer1.Refresh();

            System.Drawing.Printing.PrintDocument doctoprint = new System.Drawing.Printing.PrintDocument();
            //  doctoprint.PrinterSettings.PrinterName = "EPSON LX-300+ /II";
            int rawKind = 0;
            for (int i = 0; i <= doctoprint.PrinterSettings.PaperSizes.Count - 1; i++)
            {
                if (doctoprint.PrinterSettings.PaperSizes[i].PaperName == "C1-HalfShort")
                {
                    rawKind = Convert.ToInt32(doctoprint.PrinterSettings.PaperSizes[i].GetType().GetField("kind",
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes[i]));
                    break; // TODO: might not be correct. Was : Exit For
                }
            }
            objRpt.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
            //CrystalDecisions.Shared.PageMargins pMargin = new CrystalDecisions.Shared.PageMargins(0, 0, 0, 0);
            //objRpt.PrintOptions.ApplyPageMargins(pMargin);
            objRpt.Refresh();
            objRpt.PrintToPrinter(1, false, 0, 0);

        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDTDesc.Focus();
                //try
            //{
            //    if (String.IsNullOrEmpty(e.ColumnIndex.ToString()))
            //    {
            //    }
            //    else
            //    {
            //        if (e.ColumnIndex == 3)
            //        {
            //            //if (new ClsValidation().emptytxt(cboDVCode.Text))
            //            //{
            //            //    MessageBox.Show("Please complete your entry, Delivery Van", "GL");
            //            //    cboDVCode.Focus();
            //            //}
            //            //else 
            //            if (new ClsValidation().emptytxt(txtDTDesc.Text))
            //            {
            //                MessageBox.Show("Please complete your entry, Delivery Team", "GL");
            //                txtDTDesc.Focus();
            //            }
            //            else if (txtTDate.Text == "  /  /")
            //            {
            //                MessageBox.Show("Please complete your entry", "GL");
            //                txtTDate.Focus();
            //            }
            //            else
            //            {
            //                if (dgv1.RowCount != 0)
            //                {
            //                    if (Convert.ToBoolean(this.dgv1.Rows[e.RowIndex].Cells[3].Value) == false)
            //                    {
            //                        this.dgv1.Rows[e.RowIndex].Cells[3].Value = true;
            //                        this.dgv1.Rows[e.RowIndex].Cells[2].Value = txtMNum.Text;
            //                        dgv2.Rows.Add(this.dgv1.Rows[e.RowIndex].Cells[0].Value.ToString(), this.dgv1.Rows[e.RowIndex].Cells[1].Value.ToString(), this.dgv1.Rows[e.RowIndex].Cells[2].Value.ToString(), Convert.ToBoolean(this.dgv1.Rows[e.RowIndex].Cells[3].Value), e.RowIndex, this.dgv1.Rows[e.RowIndex].Cells[4].Value.ToString());
            //                    }
            //                    else
            //                    {
            //                        for (int i = 0; i < dgv2.Rows.Count; i++)
            //                        {
            //                            if (int.Parse(dgv2.Rows[i].Cells[4].Value.ToString()) == e.RowIndex)
            //                            {
            //                                dgv2.Rows.RemoveAt(dgv2.Rows[i].Index);
            //                            }
            //                        }
            //                        this.dgv1.Rows[e.RowIndex].Cells[3].Value = false;
            //                        this.dgv1.Rows[e.RowIndex].Cells[2].Value = "";
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (Exception)
            //{
            //}
        }

        private void dgv1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgv1.CurrentRow.Index;
            MessageBox.Show(index.ToString());
            dgv2.Rows.RemoveAt(dgv2.Rows[index].Index);
            dgv1.CurrentRow.Cells[3].Value = 0;
            dgv1.CurrentRow.Cells[2].Value = null;
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(this.dgv1.Rows[e.RowIndex].Cells[3].Value) == false)
            {
                this.dgv1.Rows[e.RowIndex].Cells[3].Value = 1;
                this.dgv1.Rows[e.RowIndex].Cells[2].Value = txtMNum.Text;
                dgv2.Rows.Add(this.dgv1.Rows[e.RowIndex].Cells[0].Value.ToString(), this.dgv1.Rows[e.RowIndex].Cells[1].Value.ToString(), this.dgv1.Rows[e.RowIndex].Cells[2].Value.ToString(), Convert.ToBoolean(this.dgv1.Rows[e.RowIndex].Cells[3].Value), e.RowIndex, this.dgv1.Rows[e.RowIndex].Cells[4].Value.ToString());
            }
            else
            {}
        }
    }
}
            

                    
    
                
    

