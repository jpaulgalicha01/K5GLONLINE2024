using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace K5GLONLINE
{
    public partial class frmShowSO : Form
    {
        private SqlDataAdapter da;
        SqlDataReader dr;
        private BindingSource bindingSource = null;
        private DataTable dataTable = null;
        ClsGetSomething ClsGetSomething1 = new ClsGetSomething();
        ClsVariousFormula ClsVariousFormula1 = new ClsVariousFormula();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        SqlConnection myconnection;
        SqlCommand mycommand;
        double varqtypiece;
        string varTotPCBal, pristrDocNum;
        public static ComboBox glblcboWHCode, glblcboPC, glblcboControlNo;

        public frmShowSO()
        {
            InitializeComponent();
        }

        private void frmShowSO_Load(object sender, EventArgs e)
        {
            LoadDataLatestProg(dgv1);
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dgv1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //LoadData(dgv2, dgv1.CurrentRow.Cells[0].Value.ToString());
            pristrDocNum = dgv1.CurrentRow.Cells[0].Value.ToString();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            frmVoucherSO.glblcboPC.SelectedValue = dgv1.CurrentRow.Cells[6].Value.ToString();
            frmVoucherSO.glblcboControlNo.SelectedValue = dgv1.CurrentRow.Cells[5].Value.ToString();
            frmVoucherSO.glbltxtPONum.Text = dgv1.CurrentRow.Cells[3].Value.ToString();
            frmVoucherSO.glbltxtFldGuid.Text = dgv1.CurrentRow.Cells[0].Value.ToString();
            getproductdetails();
            this.Close();
        }
        public void getproductdetails()
        {
            frmVoucherSO.glbldgv2.Rows.Clear();
            DataGridViewRow row1 = null;
            for (int x = 0; x < dgv2.Rows.Count; x++)
            {
                row1 = dgv2.Rows[x];
                ClsGetSomething1.ClsGetCustData(dgv1.CurrentRow.Cells[5].Value.ToString());
                ClsGetSomething1.ClsGetProductDetails(row1.Cells[1].Value.ToString(), ClsGetSomething1.plsSPO);
                ClsGetSomething1.ClsGetAveCost(Convert.ToDateTime(dgv1.CurrentRow.Cells[1].Value.ToString()), row1.Cells[1].Value.ToString(), false, ClsGetSomething1.plvarCostMethod);
                string varCost = Convert.ToDouble(ClsGetSomething1.plsAveUC).ToString("N2");
                ClsGetSomething1.ClsGetPieceBal(frmVoucherSO.glblcboWHCode.SelectedValue.ToString(), row1.Cells[1].Value.ToString());
                double varprodbal1 = Convert.ToDouble(ClsGetSomething1.plvarbalance);
                ClsGetSomething1.ClsGetPieceBalunserve(frmVoucherSO.glblcboWHCode.SelectedValue.ToString(), row1.Cells[1].Value.ToString());
                double varprodbal2 = Convert.ToDouble(ClsGetSomething1.plvarbalanceunserve);
                varTotPCBal = (varprodbal1 - varprodbal2).ToString("N2");
                varqtypiece = 0.00;

                ClsGetSomething1.ClsGetConvertedPieceBal(double.Parse(varTotPCBal), int.Parse(ClsGetSomething1.plvarib), int.Parse(ClsGetSomething1.plvarpiece));
                string strPCBalance = Convert.ToDouble(ClsGetSomething1.plvarpiecebal).ToString("N2");
                string strIBBalance = Convert.ToDouble(ClsGetSomething1.plvaribbal).ToString("N2");
                string strCSBalance = Convert.ToDouble(ClsGetSomething1.plvarcsbal).ToString("N2");
               
                if ((int.Parse(row1.Cells[3].Value.ToString())) != 0)//CS
                {
                    if (int.Parse(ClsGetSomething1.plvarib) == 0)
                    {
                        varqtypiece = double.Parse(row1.Cells[3].Value.ToString()) * double.Parse(ClsGetSomething1.plvarpiece);
                    }
                    else
                    {
                        varqtypiece = (double.Parse(row1.Cells[3].Value.ToString()) * double.Parse(ClsGetSomething1.plvarib)) * double.Parse(ClsGetSomething1.plvarpiece);
                    }

                    if (varqtypiece <= double.Parse(varTotPCBal))
                    {
                        double vargrosssales = ((int.Parse(row1.Cells[3].Value.ToString())) * Convert.ToDouble(row1.Cells[6].Value.ToString()));
                        ClsGetSomething1.ClsGetVATRate();
                        ClsVariousFormula1.getVATAmt(Convert.ToBoolean(row1.Cells[7].Value), Convert.ToDouble(ClsGetSomething1.plsVATRate), vargrosssales);
                        string transactVATAmt = Convert.ToDouble(ClsVariousFormula1.pldbVAT).ToString("N2");

                        double douqtyorder = (double.Parse(row1.Cells[3].Value.ToString()));
                        double varTotalCost = (Convert.ToDouble((int.Parse(row1.Cells[3].Value.ToString())) * Convert.ToDouble(varCost)));
                        frmVoucherSO.glbldgv2.Rows.Add(row1.Cells[1].Value.ToString(), row1.Cells[2].Value.ToString(), douqtyorder, douqtyorder, "CS", double.Parse(row1.Cells[6].Value.ToString()).ToString("N2"), "0.00", "0.00", transactVATAmt, vargrosssales.ToString("N2"), varTotalCost.ToString("N2"));
                    }
                    else
                    {
                        double vargrosssales = double.Parse(strCSBalance) * Convert.ToDouble(row1.Cells[6].Value.ToString());
                        ClsGetSomething1.ClsGetVATRate();
                        ClsVariousFormula1.getVATAmt(Convert.ToBoolean(row1.Cells[7].Value), Convert.ToDouble(ClsGetSomething1.plsVATRate), vargrosssales);
                        string transactVATAmt = Convert.ToDouble(ClsVariousFormula1.pldbVAT).ToString("N2");

                        double douqtyorder = (double.Parse(row1.Cells[3].Value.ToString()));
                        double varTotalCost = Convert.ToDouble(double.Parse(strCSBalance) * Convert.ToDouble(varCost));
                        frmVoucherSO.glbldgv2.Rows.Add(row1.Cells[1].Value.ToString(), row1.Cells[2].Value.ToString(), douqtyorder, strCSBalance, "CS", double.Parse(row1.Cells[6].Value.ToString()).ToString("N2"), "0.00", "0.00", transactVATAmt, vargrosssales.ToString("N2"), varTotalCost.ToString("N2"));
                    }
                }
                else if ((int.Parse(row1.Cells[4].Value.ToString())) != 0)//IB
                {
                    varqtypiece = double.Parse(row1.Cells[4].Value.ToString()) * double.Parse(ClsGetSomething1.plvarpiece);
                    if (varqtypiece <= double.Parse(varTotPCBal))
                    {
                        double vargrosssales = int.Parse(row1.Cells[4].Value.ToString()) * Convert.ToDouble(row1.Cells[6].Value.ToString());
                        ClsGetSomething1.ClsGetVATRate();
                        ClsVariousFormula1.getVATAmt(Convert.ToBoolean(row1.Cells[7].Value), Convert.ToDouble(ClsGetSomething1.plsVATRate), vargrosssales);
                        string transactVATAmt = Convert.ToDouble(ClsVariousFormula1.pldbVAT).ToString("N2");

                        double douqtyorder = (double.Parse(row1.Cells[4].Value.ToString()));
                        double varTotalCost = (Convert.ToDouble((int.Parse(row1.Cells[4].Value.ToString())) * Convert.ToDouble(varCost)) / Convert.ToInt32(ClsGetSomething1.plvarib));
                        frmVoucherSO.glbldgv2.Rows.Add(row1.Cells[1].Value.ToString(), row1.Cells[2].Value.ToString(), douqtyorder, douqtyorder, "IB", double.Parse(row1.Cells[6].Value.ToString()).ToString("N2"), "0.00", "0.00", transactVATAmt, vargrosssales.ToString("N2"), varTotalCost.ToString("N2"));
                    }
                    else
                    {
                        double vargrosssales = double.Parse(strIBBalance) * Convert.ToDouble(row1.Cells[6].Value.ToString());
                        ClsGetSomething1.ClsGetVATRate();
                        ClsVariousFormula1.getVATAmt(Convert.ToBoolean(row1.Cells[7].Value), Convert.ToDouble(ClsGetSomething1.plsVATRate), vargrosssales);
                        string transactVATAmt = Convert.ToDouble(ClsVariousFormula1.pldbVAT).ToString("N2");

                        double douqtyorder = (double.Parse(row1.Cells[4].Value.ToString()));
                        double varTotalCost = Convert.ToDouble(double.Parse(strIBBalance) * Convert.ToDouble(varCost) / Convert.ToInt32(ClsGetSomething1.plvarib));
                        frmVoucherSO.glbldgv2.Rows.Add(row1.Cells[1].Value.ToString(), row1.Cells[2].Value.ToString(), douqtyorder, strIBBalance, "IB", double.Parse(row1.Cells[6].Value.ToString()).ToString("N2"), "0.00", "0.00", transactVATAmt, vargrosssales.ToString("N2"), varTotalCost.ToString("N2"));

                    }
                }
                else if ((int.Parse(row1.Cells[5].Value.ToString())) != 0)//PC
                {
                    double varucost;
                    if (Convert.ToInt32(ClsGetSomething1.plvarib) == 0)
                    {
                        varucost = Convert.ToDouble(varCost) / Convert.ToInt32(ClsGetSomething1.plvarpiece);
                    }
                    else
                    {
                        varucost = (Convert.ToDouble(varCost) / Convert.ToInt32(ClsGetSomething1.plvarib)) / Convert.ToInt32(ClsGetSomething1.plvarpiece);
                    }

                    varqtypiece = int.Parse(row1.Cells[5].Value.ToString());
                    if (varqtypiece <= double.Parse(varTotPCBal))
                    {
                        double vargrosssales = int.Parse(row1.Cells[5].Value.ToString()) * Convert.ToDouble(row1.Cells[6].Value.ToString());
                        ClsGetSomething1.ClsGetVATRate();
                        ClsVariousFormula1.getVATAmt(Convert.ToBoolean(row1.Cells[7].Value), Convert.ToDouble(ClsGetSomething1.plsVATRate), vargrosssales);
                        string transactVATAmt = Convert.ToDouble(ClsVariousFormula1.pldbVAT).ToString("N2");

                        double douqtyorder = (double.Parse(row1.Cells[5].Value.ToString()));
                        double varTotalCost = (Convert.ToDouble((int.Parse(row1.Cells[5].Value.ToString()))) * varucost);
                        frmVoucherSO.glbldgv2.Rows.Add(row1.Cells[1].Value.ToString(), row1.Cells[2].Value.ToString(), douqtyorder, douqtyorder, "PC", double.Parse(row1.Cells[6].Value.ToString()).ToString("N2"), "0.00", "0.00", transactVATAmt, vargrosssales.ToString("N2"), varTotalCost.ToString("N2"));
                    }
                    else
                    {
                        double vargrosssales = double.Parse(strPCBalance) * Convert.ToDouble(row1.Cells[6].Value.ToString());
                        ClsGetSomething1.ClsGetVATRate();
                        ClsVariousFormula1.getVATAmt(Convert.ToBoolean(row1.Cells[7].Value), Convert.ToDouble(ClsGetSomething1.plsVATRate), vargrosssales);
                        string transactVATAmt = Convert.ToDouble(ClsVariousFormula1.pldbVAT).ToString("N2");

                        double douqtyorder = (double.Parse(row1.Cells[5].Value.ToString()));
                        double varTotalCost = Convert.ToDouble(double.Parse(strPCBalance) * varucost);
                        frmVoucherSO.glbldgv2.Rows.Add(row1.Cells[1].Value.ToString(), row1.Cells[2].Value.ToString(), douqtyorder, strPCBalance, "PC", double.Parse(row1.Cells[6].Value.ToString()).ToString("N2"), "0.00", "0.00", transactVATAmt, vargrosssales.ToString("N2"), varTotalCost.ToString("N2"));
                    }
                }
            }

            dgv2total();
        }
       
        private void dgv2total()
        {
            double vartxttotactdisct = 0.00;
            double vartxttotpdisct = 0.00;
            double vartxttotvat = 0.00;
            double vartxttotsales = 0.00;
            double vartxttotcost = 0.00;

            for (int x = 0; x < frmVoucherSO.glbldgv2.Rows.Count - 1; x++)
            {
                vartxttotactdisct += double.Parse(frmVoucherSO.glbldgv2.Rows[x].Cells[6].FormattedValue.ToString());
            }
            frmVoucherSO.glbltxtTotActDisct.Text = vartxttotactdisct.ToString("n2");

            for (int x = 0; x < frmVoucherSO.glbldgv2.Rows.Count - 1; x++)
            {
                vartxttotpdisct += double.Parse(frmVoucherSO.glbldgv2.Rows[x].Cells[7].FormattedValue.ToString());
            }
            frmVoucherSO.glbltxtTotPDisct.Text = vartxttotpdisct.ToString("n2");

            for (int x = 0; x < frmVoucherSO.glbldgv2.Rows.Count - 1; x++)
            {
                vartxttotvat += double.Parse(frmVoucherSO.glbldgv2.Rows[x].Cells[8].FormattedValue.ToString());
            }
            frmVoucherSO.glbltxtTotVat.Text = vartxttotvat.ToString("n2");

            for (int x = 0; x < frmVoucherSO.glbldgv2.Rows.Count - 1; x++)
            {
                vartxttotsales += double.Parse(frmVoucherSO.glbldgv2.Rows[x].Cells[9].FormattedValue.ToString());
            }
            frmVoucherSO.glbltxtTotSales.Text = vartxttotsales.ToString("n2");

            for (int x = 0; x < frmVoucherSO.glbldgv2.Rows.Count - 1; x++)
            {
                vartxttotcost += double.Parse(frmVoucherSO.glbldgv2.Rows[x].Cells[10].FormattedValue.ToString());
            }
            frmVoucherSO.glbltxtTotCost.Text = vartxttotcost.ToString("n2");
            frmVoucherSO.glbltxtTotNet.Text = (double.Parse(frmVoucherSO.glbltxtTotSales.Text) - (double.Parse(frmVoucherSO.glbltxtTotActDisct.Text) + double.Parse(frmVoucherSO.glbltxtTotPDisct.Text))).ToString("N2");
        }

        private void dgv1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            transferData();
            DisplayDetailsSO();

            DataGridViewRow row1 = null;
            for (int x = 0; x < dgv2.Rows.Count; x++)
            {
                string F0 = dgv2.Rows[x].Cells[0].FormattedValue.ToString();
                string F1 = dgv2.Rows[x].Cells[1].FormattedValue.ToString();
                string F2 = dgv2.Rows[x].Cells[2].FormattedValue.ToString();
                string F3 = dgv2.Rows[x].Cells[3].FormattedValue.ToString();
                string F4 = dgv2.Rows[x].Cells[4].FormattedValue.ToString();
                string F5 = dgv2.Rows[x].Cells[5].FormattedValue.ToString();
                string F6 = dgv2.Rows[x].Cells[6].FormattedValue.ToString();
                string F7 = dgv2.Rows[x].Cells[7].FormattedValue.ToString();
                string F8 = dgv2.Rows[x].Cells[8].FormattedValue.ToString();
                string F9 = dgv2.Rows[x].Cells[9].FormattedValue.ToString();
                string F10 = dgv2.Rows[x].Cells[10].FormattedValue.ToString();
                string F11 = dgv2.Rows[x].Cells[11].FormattedValue.ToString();
                //string F12 = dgv2.Rows[x].Cells[12].FormattedValue.ToString();
                //string F13 = dgv2.Rows[x].Cells[13].FormattedValue.ToString();
                //string F14 = dgv2.Rows[x].Cells[14].FormattedValue.ToString();
                //string F15 = dgv2.Rows[x].Cells[15].FormattedValue.ToString();
                row1 = dgv2.Rows[x];
                if (int.Parse(F3) != 0)
                {
                    frmVoucherSOEdit.glbldgv2.Rows.Add(F0, F1, F2, F3, F4, F5, F6, F7, F8, F9, F10, F11/*, F12, F13, F14, F15*/);
                }
            }
            SOEditdgv1total();
            this.Close();
        }

        private void transferData()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT * FROM ViewSOEdit WHERE DocNum = '" + pristrDocNum + "'", myconnection);


                dr = mycommand.ExecuteReader();
                while (dr.Read())
                {
                    frmVoucherSOEdit.glblcboWHCode.SelectedValue = dr["WHCode"].ToString();
                    frmVoucherSOEdit.glbltxtTDate.Text = DateTime.Parse(dr["OrderDate"].ToString()).ToString();
                    frmVoucherSOEdit.glbltxtreference.Text = dr["Reference"].ToString();
                    frmVoucherSOEdit.glblcboControlNo.SelectedValue = dr["Controlno"].ToString();
                    string term = dr["Term"].ToString();
                    //MessageBox.Show(term);
                    frmVoucherSOEdit.glbltxtRemarks.Text = dr["Remarks"].ToString();
                    frmVoucherSOEdit.glbltxtTerm.Text = dr["Term"].ToString();
                    frmVoucherSOEdit.glblcboPC.SelectedValue = dr["PC"].ToString();
                    frmVoucherSOEdit.glbltxtDocNum.Text = pristrDocNum;
                }
                ClsGetSomething1.ClsGetCustData(frmVoucherSOEdit.glblcboControlNo.SelectedValue.ToString());

                frmVoucherSOEdit.glbltxtSPO.Text = ClsGetSomething1.plsSPO;
                //frmVoucherSOEdit.glbltxtAddress.Text = ClsGetSomething1.plsvarCustNameAdress;
                frmVoucherSOEdit.glblcboPC.SelectedValue = ClsGetSomething1.plsSLS;
                //frmVoucherSOEdit.glbltxtTerm.Text = ClsGetSomething1.plsTerm;

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
        private void DisplayDetailsSO()
        {
            dgv2.DataSource = null;
            dgv2.Columns.Clear();

            string sql;
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            sql = "SELECT StockNumber, Item, OrderQty, Out, UM, UP, ActDisct, PDisct, VAT, GrossAmt, Cost, RefforAC FROM ViewDetailsBookSOUnserved WHERE DocNum = '" + pristrDocNum + "'";

            da = new SqlDataAdapter(sql, myconnection);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);

            dataTable = new DataTable();
            da.Fill(dataTable);
            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;

            //Adding  dgv2StockNumber TextBox
            DataGridViewTextBoxColumn Columndgv2StockNumber = new DataGridViewTextBoxColumn();
            Columndgv2StockNumber.HeaderText = "Stock Number";
            Columndgv2StockNumber.Width = 120;
            Columndgv2StockNumber.DataPropertyName = "StockNumber";
            Columndgv2StockNumber.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Columndgv2StockNumber.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //ColumnCR.ReadOnly = true;
            dgv2.Columns.Add(Columndgv2StockNumber);

            //Adding  dgv2StockDesc TextBox
            DataGridViewTextBoxColumn Columndgv2StockDesc = new DataGridViewTextBoxColumn();
            Columndgv2StockDesc.HeaderText = "Description";
            Columndgv2StockDesc.Width = 293;
            Columndgv2StockDesc.DataPropertyName = "Item";
            Columndgv2StockDesc.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Columndgv2StockDesc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Columndgv2StockDesc.ReadOnly = true;
            dgv2.Columns.Add(Columndgv2StockDesc);

            //Adding  dgv2OrderQty TextBox
            DataGridViewTextBoxColumn Columndgv2OrderQty = new DataGridViewTextBoxColumn();
            Columndgv2OrderQty.HeaderText = "OrderQty";
            Columndgv2OrderQty.Width = 100;
            Columndgv2OrderQty.DataPropertyName = "OrderQty";
            Columndgv2OrderQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Columndgv2OrderQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Columndgv2OrderQty.Visible = false;
            dgv2.Columns.Add(Columndgv2OrderQty);

            //Adding  dgv2POut TextBox
            DataGridViewTextBoxColumn Columndgv2POut = new DataGridViewTextBoxColumn();
            Columndgv2POut.HeaderText = "Qty";
            Columndgv2POut.Width = 50;
            Columndgv2POut.DataPropertyName = "Out";
            Columndgv2POut.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            Columndgv2POut.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //Columndgv2POut.ReadOnly = true;
            dgv2.Columns.Add(Columndgv2POut);

            //Adding  dgv2UM TextBox
            DataGridViewTextBoxColumn Columndgv2UM = new DataGridViewTextBoxColumn();
            Columndgv2UM.HeaderText = "UM";
            Columndgv2UM.Width = 50;
            Columndgv2UM.DataPropertyName = "UM";
            Columndgv2UM.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Columndgv2UM.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //ColumnCR.ReadOnly = true;
            dgv2.Columns.Add(Columndgv2UM);

            //Adding  dgv2UP TextBox
            DataGridViewTextBoxColumn Columndgv2UP = new DataGridViewTextBoxColumn();
            Columndgv2UP.HeaderText = "Unit Price";
            Columndgv2UP.Width = 90;
            Columndgv2UP.DataPropertyName = "UP";
            Columndgv2UP.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            Columndgv2UP.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //ColumnCR.ReadOnly = true;
            dgv2.Columns.Add(Columndgv2UP);

            //Adding  dgv2ActDisct TextBox
            DataGridViewTextBoxColumn Columndgv2ActDisct = new DataGridViewTextBoxColumn();
            Columndgv2ActDisct.HeaderText = "% Disct";
            Columndgv2ActDisct.Width = 75;
            Columndgv2ActDisct.DataPropertyName = "ActDisct";
            Columndgv2ActDisct.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            Columndgv2ActDisct.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //ColumnCR.ReadOnly = true;
            dgv2.Columns.Add(Columndgv2ActDisct);

            //Adding  dgv2PDisct TextBox
            DataGridViewTextBoxColumn Columndgv2PDisct = new DataGridViewTextBoxColumn();
            Columndgv2PDisct.HeaderText = "P Disct";
            Columndgv2PDisct.Width = 75;
            Columndgv2PDisct.DataPropertyName = "PDisct";
            Columndgv2PDisct.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            Columndgv2PDisct.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //ColumnCR.ReadOnly = true;
            dgv2.Columns.Add(Columndgv2PDisct);

            //Adding  dgv2VAT TextBox
            DataGridViewTextBoxColumn Columndgv2VAT = new DataGridViewTextBoxColumn();
            Columndgv2VAT.HeaderText = "VAT";
            Columndgv2VAT.Width = 70;
            Columndgv2VAT.DataPropertyName = "VAT";
            Columndgv2VAT.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            Columndgv2VAT.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //ColumnCR.ReadOnly = true;
            dgv2.Columns.Add(Columndgv2VAT);

            //Adding  dgv2Total TextBox
            DataGridViewTextBoxColumn Columndgv2Total = new DataGridViewTextBoxColumn();
            Columndgv2Total.HeaderText = "Total";
            Columndgv2Total.Width = 90;
            Columndgv2Total.DataPropertyName = "GrossAmt";
            Columndgv2Total.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            Columndgv2Total.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //ColumnCR.ReadOnly = true;
            dgv2.Columns.Add(Columndgv2Total);

            //Adding  dgv2Cost TextBox
            DataGridViewTextBoxColumn Columndgv2Cost = new DataGridViewTextBoxColumn();
            Columndgv2Cost.HeaderText = "Cost";
            Columndgv2Cost.Width = 90;
            Columndgv2Cost.DataPropertyName = "Cost";
            Columndgv2Cost.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            Columndgv2Cost.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //ColumnCR.ReadOnly = true;
            dgv2.Columns.Add(Columndgv2Cost);

            //Adding  Columndgv2RefforAC TextBox
            DataGridViewTextBoxColumn Columndgv2RefforAC = new DataGridViewTextBoxColumn();
            Columndgv2RefforAC.HeaderText = "RefforAC";
            Columndgv2RefforAC.Width = 100;
            Columndgv2RefforAC.DataPropertyName = "RefforAC";
            Columndgv2RefforAC.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Columndgv2RefforAC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Columndgv2RefforAC.Visible = false;
            dgv2.Columns.Add(Columndgv2RefforAC);
            
            ////Adding  dgv2D1 TextBox
            //DataGridViewTextBoxColumn Columndgv2D1 = new DataGridViewTextBoxColumn();
            //Columndgv2D1.HeaderText = "D1";
            //Columndgv2D1.Width = 100;
            //Columndgv2D1.DataPropertyName = "D1";
            //Columndgv2D1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //Columndgv2D1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //Columndgv2D1.Visible = false;
            //dgv2.Columns.Add(Columndgv2D1);

            ////Adding  dgv2D2 TextBox
            //DataGridViewTextBoxColumn Columndgv2D2 = new DataGridViewTextBoxColumn();
            //Columndgv2D2.HeaderText = "D2";
            //Columndgv2D2.Width = 100;
            //Columndgv2D2.DataPropertyName = "D2";
            //Columndgv2D2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //Columndgv2D2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //Columndgv2D2.Visible = false;
            //dgv2.Columns.Add(Columndgv2D2);

            ////Adding  dgv2D3 TextBox
            //DataGridViewTextBoxColumn Columndgv2D3 = new DataGridViewTextBoxColumn();
            //Columndgv2D3.HeaderText = "D3";
            //Columndgv2D3.Width = 100;
            //Columndgv2D3.DataPropertyName = "D3";
            //Columndgv2D3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //Columndgv2D3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //Columndgv2D3.Visible = false;
            //dgv2.Columns.Add(Columndgv2D3);


            ////Adding  dgv2BatchNo TextBox
            //DataGridViewTextBoxColumn Columndgv2BatchNo = new DataGridViewTextBoxColumn();
            //Columndgv2BatchNo.HeaderText = "Batch No.";
            //Columndgv2BatchNo.Width = 80;
            //Columndgv2BatchNo.DataPropertyName = "BatchNo";
            //Columndgv2BatchNo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //Columndgv2BatchNo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //Columndgv2BatchNo.Visible = true;
            //dgv2.Columns.Add(Columndgv2BatchNo);

            ////Adding  dgv2ExpDate TextBox
            //DataGridViewTextBoxColumn Columndgv2ExpDate = new DataGridViewTextBoxColumn();
            //Columndgv2ExpDate.HeaderText = "Exp. Date";
            //Columndgv2ExpDate.Width = 80;
            //Columndgv2ExpDate.DataPropertyName = "ExpDate";
            //Columndgv2ExpDate.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //Columndgv2ExpDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //Columndgv2ExpDate.Visible = true;
            //dgv2.Columns.Add(Columndgv2ExpDate);

            //Setting Data Source for DataGridView
            dgv2.DataSource = bindingSource;
            //            dgv1.AutoResizeColumns();
            //            dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            myconnection.Close();
            //            this.WindowState = FormWindowState.Maximized;
            //            dgv1.AllowUserToAddRows = true;
            dgv2.Columns[5].DefaultCellStyle.Format = "N2";
            dgv2.Columns[6].DefaultCellStyle.Format = "N2";
            dgv2.Columns[7].DefaultCellStyle.Format = "N2";
            dgv2.Columns[8].DefaultCellStyle.Format = "N2";
            dgv2.Columns[9].DefaultCellStyle.Format = "N2";
            dgv2.Columns[10].DefaultCellStyle.Format = "N2";
            //dgv2.Columns[14].DefaultCellStyle.Format = "MM/dd/yyyy";
        }

        private void SOEditdgv1total()
        {
            double vartxtTotCost = 0.00;
            double vartxtTotNet = 0.00;
            double vartxtTotDisct = 0.00;
            double vartxtTotVAT = 0;
            double vartxtActDsct = 0;
            double vartxtPDsct = 0;
            {
                for (int x = 0; x < frmVoucherSOEdit.glbldgv2.Rows.Count-1; x++)
                {
                    vartxtTotCost += double.Parse(frmVoucherSOEdit.glbldgv2.Rows[x].Cells[10].FormattedValue.ToString());
                }

                for (int x = 0; x < frmVoucherSOEdit.glbldgv2.Rows.Count-1; x++)
                {
                    vartxtTotNet += double.Parse(frmVoucherSOEdit.glbldgv2.Rows[x].Cells[9].FormattedValue.ToString());
                }

                for (int x = 0; x < frmVoucherSOEdit.glbldgv2.Rows.Count-1; x++)
                {
                    string vartxtD1 = frmVoucherSOEdit.glbldgv2.Rows[x].Cells[6].FormattedValue.ToString();
                    string vartxtD2 = frmVoucherSOEdit.glbldgv2.Rows[x].Cells[7].FormattedValue.ToString();
                    vartxtTotDisct += double.Parse(vartxtD1) + double.Parse(vartxtD2);
                    vartxtActDsct += double.Parse(frmVoucherSOEdit.glbldgv2.Rows[x].Cells[6].FormattedValue.ToString());
                    vartxtPDsct += double.Parse(frmVoucherSOEdit.glbldgv2.Rows[x].Cells[7].FormattedValue.ToString());
                }

                for (int x = 0; x < frmVoucherSOEdit.glbldgv2.Rows.Count-1; x++)
                {
                    vartxtTotVAT += double.Parse(frmVoucherSOEdit.glbldgv2.Rows[x].Cells[8].FormattedValue.ToString());
                }

                frmVoucherSOEdit.glbltxtTotCost.Text = vartxtTotCost.ToString("N2");
                //frmVoucherSOEdit.glbltxtTotNet.Text = vartxtTotNet.ToString("N2");
                //frmVoucherSOEdit.glbltxtTotDisct.Text = vartxtTotDisct.ToString("N2");
                frmVoucherSOEdit.glbltxtTotVAT.Text = vartxtTotVAT.ToString("N2");
                frmVoucherSOEdit.glbltxtTotActDisct.Text = vartxtActDsct.ToString("N2");
                frmVoucherSOEdit.glbltxtTotPDisct.Text = vartxtPDsct.ToString("N2");
                frmVoucherSOEdit.glbltxtTotSales.Text = vartxtTotNet.ToString("N2");
                frmVoucherSOEdit.glbltxtTotNet.Text = (vartxtTotNet -(vartxtActDsct+ vartxtPDsct)).ToString("N2");
            }
        }

        public void LoadDataLatestProg(DataGridView dgv)
        {
            dgv.DataSource = null;
            dgv.Columns.Clear();

            string sql = "SELECT DocNum, OrderDate, CustName FROM ViewSOEdit ORDER BY DocNum";

            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            mycommand = myconnection.CreateCommand();
            mycommand.CommandText = sql;
            mycommand.CommandTimeout = 900;
            SqlDataReader dr = mycommand.ExecuteReader();
            DataTable DataTable1 = new DataTable();
            DataTable1.Load(dr);
            myconnection.Close();

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = DataTable1;

            if (DataTable1.Rows.Count == 0)
            {
                MessageBox.Show("No data found", "GL");
                return;
            }

            DataGridViewTextBoxColumn ColumnPONumber = new DataGridViewTextBoxColumn();
            ColumnPONumber.HeaderText = "Number";
            ColumnPONumber.Width = 150;
            ColumnPONumber.DataPropertyName = "DocNum";
            ColumnPONumber.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnPONumber.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns.Add(ColumnPONumber);

            DataGridViewTextBoxColumn ColumnOrderDate = new DataGridViewTextBoxColumn();
            ColumnOrderDate.HeaderText = "Date";
            ColumnOrderDate.Width = 100;
            ColumnOrderDate.DataPropertyName = "OrderDate";
            ColumnOrderDate.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnOrderDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns.Add(ColumnOrderDate);


            DataGridViewTextBoxColumn ColumnCustName = new DataGridViewTextBoxColumn();
            ColumnCustName.HeaderText = "Name";
            ColumnCustName.Width = 150;
            ColumnCustName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnCustName.DataPropertyName = "CustName";
            ColumnCustName.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnCustName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns.Add(ColumnCustName);

            //DataGridViewTextBoxColumn ColumnSMDesc = new DataGridViewTextBoxColumn();
            //ColumnSMDesc.HeaderText = "Personnel";
            //ColumnSMDesc.Width = 150;
            //ColumnSMDesc.DataPropertyName = "PersonnelName";
            //ColumnSMDesc.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //ColumnSMDesc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //dgv.Columns.Add(ColumnSMDesc);

            //DataGridViewTextBoxColumn ColumnControlNo = new DataGridViewTextBoxColumn();
            //ColumnControlNo.HeaderText = "ControlNo";
            //ColumnControlNo.Width = 150;
            //ColumnControlNo.DataPropertyName = "ControlNo";
            //ColumnControlNo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //ColumnControlNo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //ColumnControlNo.Visible = false;
            //dgv.Columns.Add(ColumnControlNo);

            //DataGridViewTextBoxColumn ColumnSMCode = new DataGridViewTextBoxColumn();
            //ColumnSMCode.HeaderText = "PC";
            //ColumnSMCode.Width = 150;
            //ColumnSMCode.DataPropertyName = "PC";
            //ColumnSMCode.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //ColumnSMCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //ColumnSMCode.Visible = false;
            //dgv.Columns.Add(ColumnSMCode);

            dgv.DataSource = bindingSource;
            dgv.Columns[1].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgv.AllowUserToAddRows = false;
        }

        public void LoadData(DataGridView dgv, string strFldGuid)
        {

            dgv.DataSource = null;
            dgv.Columns.Clear();
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            string sql = "SELECT DocNum, StockNumber, Item, OrderQty, UP, VAT FROM ViewPendingSO WHERE FldGuid = '" + strFldGuid + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, myconnection);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;

            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("No data found", "GL");
                return;
            }

            DataGridViewTextBoxColumn ColumnDocNum = new DataGridViewTextBoxColumn();
            ColumnDocNum.HeaderText = "DocNum";
            ColumnDocNum.Width = 100;
            ColumnDocNum.Visible = false;
            ColumnDocNum.ReadOnly = true;
            ColumnDocNum.DataPropertyName = "DocNum";
            ColumnDocNum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnDocNum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns.Add(ColumnDocNum);

            DataGridViewTextBoxColumn ColumnProductCode = new DataGridViewTextBoxColumn();
            ColumnProductCode.HeaderText = "Product Code";
            ColumnProductCode.Width = 100;
            ColumnProductCode.ReadOnly = true;
            ColumnProductCode.DataPropertyName = "ProductCode";
            ColumnProductCode.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnProductCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns.Add(ColumnProductCode);

            DataGridViewTextBoxColumn ColumnProductName = new DataGridViewTextBoxColumn();
            ColumnProductName.HeaderText = "ProductName";
            ColumnProductName.Width = 150;
            ColumnProductName.ReadOnly = true;
            ColumnProductName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnProductName.DataPropertyName = "ProductName";
            ColumnProductName.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnProductName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns.Add(ColumnProductName);

            DataGridViewTextBoxColumn ColumnCS = new DataGridViewTextBoxColumn();
            ColumnCS.HeaderText = "CS";
            ColumnCS.Width = 80;
            ColumnCS.DataPropertyName = "CS";
            ColumnCS.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnCS.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnCS.ReadOnly = true;
            dgv.Columns.Add(ColumnCS);

            DataGridViewTextBoxColumn ColumnIB = new DataGridViewTextBoxColumn();
            ColumnIB.HeaderText = "IB";
            ColumnIB.Width = 80;
            ColumnIB.DataPropertyName = "IB";
            ColumnIB.ReadOnly = true;
            ColumnIB.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnIB.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns.Add(ColumnIB);

            DataGridViewTextBoxColumn ColumnPC = new DataGridViewTextBoxColumn();
            ColumnPC.HeaderText = "PC";
            ColumnPC.Width = 80;
            ColumnPC.DataPropertyName = "PC";
            ColumnPC.ReadOnly = true;
            ColumnPC.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnPC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns.Add(ColumnPC);

            DataGridViewTextBoxColumn ColumnSellingPrice = new DataGridViewTextBoxColumn();
            ColumnSellingPrice.HeaderText = "Selling Price";
            ColumnSellingPrice.Width = 100;
            ColumnSellingPrice.DataPropertyName = "SellingPrice";
            ColumnSellingPrice.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnSellingPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnSellingPrice.ReadOnly = false;
            dgv.Columns.Add(ColumnSellingPrice);

            DataGridViewCheckBoxColumn ColumnVAT = new DataGridViewCheckBoxColumn();
            ColumnVAT.HeaderText = "VAT";
            ColumnVAT.Width = 50;
            ColumnVAT.DataPropertyName = "VAT";
            ColumnVAT.FalseValue = false;
            ColumnVAT.ReadOnly = false;
            ColumnVAT.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnVAT.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns.Add(ColumnVAT);
            dgv.DataSource = bindingSource;
            myconnection.Close();
            dgv.Columns[6].DefaultCellStyle.Format = "N2";
        }
    }
}
