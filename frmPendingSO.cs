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
    public partial class frmPendingSO : Form
    {
        SqlConnection myconnection;
        SqlCommand mycommand;
        SqlDataReader dr;
        private SqlDataAdapter da;
        private DataTable dataTable = null;
        BindingSource dbind = new BindingSource();
        private BindingSource bindingSource = null;
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection(); 

        public frmPendingSO()
        {
            InitializeComponent();
        }

        private void buildlvpso()
        {
            try
            {
                LVpso.Items.Clear();
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT DocNum, CustName, Reference FROM ViewApprovedPendingSO WHERE (ISNUMERIC(DocNum) = 1) ORDER BY DocNum", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();


                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem(dr["DocNum"].ToString());
                    item.SubItems.Add(dr["CustName"].ToString());
                    item.SubItems.Add(dr["Reference"].ToString());

                    LVpso.Items.Add(item);
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

        private void frmPendingSO_Load(object sender, EventArgs e)
        {
            buildlvpso();
        }

        private void showdgvdata()
        {
            string sql;
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            sql = "SELECT StockNumber, Item, ChickOut, Out, UM, UP, ActDisct, PDisct, VAT, (UP*Out) As Total, Cost, RefforAC FROM ViewSO WHERE DocNum = '" + txtDocNum.Text + "' AND Out<>0 ORDER BY Num";

            da = new SqlDataAdapter(sql, myconnection);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
            da.SelectCommand.CommandTimeout = 600;
            dataTable = new DataTable();
            da.Fill(dataTable);
            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;

            //Adding  dgv2StockNumber TextBox
            DataGridViewTextBoxColumn Columndgv2StockNumber = new DataGridViewTextBoxColumn();
            Columndgv2StockNumber.HeaderText = "Stock Number";
            Columndgv2StockNumber.Width = 100;
            Columndgv2StockNumber.DataPropertyName = "StockNumber";
            Columndgv2StockNumber.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Columndgv2StockNumber.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //ColumnCR.ReadOnly = true;
            frmVoucherCI.glbldgv2.Columns.Add(Columndgv2StockNumber);

            //Adding  dgv2Item TextBox
            DataGridViewTextBoxColumn Columndgv2Item = new DataGridViewTextBoxColumn();
            Columndgv2Item.HeaderText = "Description";
            Columndgv2Item.Width = 165;
            Columndgv2Item.DataPropertyName = "Item";
            Columndgv2Item.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Columndgv2Item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //ColumnCR.ReadOnly = true;
            frmVoucherCI.glbldgv2.Columns.Add(Columndgv2Item);

            //Adding  dgv2ChickOut TextBox
            DataGridViewTextBoxColumn Columndgv2ChickOut = new DataGridViewTextBoxColumn();
            Columndgv2ChickOut.HeaderText = "Qty";
            Columndgv2ChickOut.Width = 70;
            Columndgv2ChickOut.DataPropertyName = "ChickOut";
            Columndgv2ChickOut.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            Columndgv2ChickOut.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //ColumnCR.ReadOnly = true;
            frmVoucherCI.glbldgv2.Columns.Add(Columndgv2ChickOut);

            //Adding  dgv2Out TextBox
            DataGridViewTextBoxColumn Columndgv2Out = new DataGridViewTextBoxColumn();
            Columndgv2Out.HeaderText = "Qty/Weight";
            Columndgv2Out.Width = 70;
            Columndgv2Out.DataPropertyName = "Out";
            Columndgv2Out.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            Columndgv2Out.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //ColumnCR.ReadOnly = true;
            frmVoucherCI.glbldgv2.Columns.Add(Columndgv2Out);

            //Adding  dgv2UM TextBox
            DataGridViewTextBoxColumn Columndgv2UM = new DataGridViewTextBoxColumn();
            Columndgv2UM.HeaderText = "UM";
            Columndgv2UM.Width = 40;
            Columndgv2UM.DataPropertyName = "UM";
            Columndgv2UM.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Columndgv2UM.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //ColumnCR.ReadOnly = true;
            frmVoucherCI.glbldgv2.Columns.Add(Columndgv2UM);

            //Adding  dgv2UP TextBox
            DataGridViewTextBoxColumn Columndgv2UP = new DataGridViewTextBoxColumn();
            Columndgv2UP.HeaderText = "Unit Price";
            Columndgv2UP.Width = 80;
            Columndgv2UP.DataPropertyName = "UP";
            Columndgv2UP.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            Columndgv2UP.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //ColumnCR.ReadOnly = true;
            frmVoucherCI.glbldgv2.Columns.Add(Columndgv2UP);

            //Adding  dgv2ActDisct TextBox
            DataGridViewTextBoxColumn Columndgv2ActDisct = new DataGridViewTextBoxColumn();
            Columndgv2ActDisct.HeaderText = "% Disct";
            Columndgv2ActDisct.Width = 80;
            Columndgv2ActDisct.DataPropertyName = "ActDisct";
            Columndgv2ActDisct.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            Columndgv2ActDisct.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //ColumnCR.ReadOnly = true;
            frmVoucherCI.glbldgv2.Columns.Add(Columndgv2ActDisct);

            //Adding  dgv2PDisct TextBox
            DataGridViewTextBoxColumn Columndgv2PDisct = new DataGridViewTextBoxColumn();
            Columndgv2PDisct.HeaderText = "P Disct";
            Columndgv2PDisct.Width = 80;
            Columndgv2PDisct.DataPropertyName = "PDisct";
            Columndgv2PDisct.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            Columndgv2PDisct.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //ColumnCR.ReadOnly = true;
            frmVoucherCI.glbldgv2.Columns.Add(Columndgv2PDisct);

            //Adding  dgv2VAT TextBox
            DataGridViewTextBoxColumn Columndgv2VAT = new DataGridViewTextBoxColumn();
            Columndgv2VAT.HeaderText = "VAT";
            Columndgv2VAT.Width = 75;
            Columndgv2VAT.DataPropertyName = "VAT";
            Columndgv2VAT.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            Columndgv2VAT.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //ColumnCR.ReadOnly = true;
            frmVoucherCI.glbldgv2.Columns.Add(Columndgv2VAT);

            //Adding  dgv2Total TextBox
            DataGridViewTextBoxColumn Columndgv2Total = new DataGridViewTextBoxColumn();
            Columndgv2Total.HeaderText = "Total";
            Columndgv2Total.Width = 90;
            Columndgv2Total.DataPropertyName = "Total";
            Columndgv2Total.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            Columndgv2Total.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //ColumnCR.ReadOnly = true;
            frmVoucherCI.glbldgv2.Columns.Add(Columndgv2Total);

            //Adding  dgv2Cost TextBox
            DataGridViewTextBoxColumn Columndgv2Cost = new DataGridViewTextBoxColumn();
            Columndgv2Cost.HeaderText = "Cost";
            Columndgv2Cost.Width = 90;
            Columndgv2Cost.DataPropertyName = "Cost";
            Columndgv2Cost.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            Columndgv2Cost.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //ColumnCR.ReadOnly = true;
            frmVoucherCI.glbldgv2.Columns.Add(Columndgv2Cost);

            //// Adding  Num TextBox
            //DataGridViewTextBoxColumn ColumnNum = new DataGridViewTextBoxColumn();
            //ColumnNum.HeaderText = "Num";
            ////ColumnNum.Width = 80;
            //ColumnNum.DataPropertyName = "Num";
            //ColumnNum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //ColumnNum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //ColumnNum.Visible = false;
            //frmVoucherCI.glbldgv2.Columns.Add(ColumnNum);

            // Adding  RefforAC TextBox
            DataGridViewTextBoxColumn ColumnRefforAC = new DataGridViewTextBoxColumn();
            ColumnRefforAC.HeaderText = "RefforAC";
            ColumnRefforAC.Width = 80;
            ColumnRefforAC.DataPropertyName = "RefforAC";
            ColumnRefforAC.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnRefforAC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnRefforAC.Visible = false;
            frmVoucherCI.glbldgv2.Columns.Add(ColumnRefforAC);

            frmVoucherCI.glbldgv2.Columns[0].Name = "StockNumber";
            frmVoucherCI.glbldgv2.Columns[1].Name = "Item";
            frmVoucherCI.glbldgv2.Columns[2].Name = "Qty";
            frmVoucherCI.glbldgv2.Columns[3].Name = "Qty/Weight";
            frmVoucherCI.glbldgv2.Columns[4].Name = "UM";
            frmVoucherCI.glbldgv2.Columns[5].Name = "UP";
            frmVoucherCI.glbldgv2.Columns[6].Name = "ActDisct";
            frmVoucherCI.glbldgv2.Columns[7].Name = "PDisct";
            frmVoucherCI.glbldgv2.Columns[8].Name = "VAT";
            frmVoucherCI.glbldgv2.Columns[9].Name = "Total";
            frmVoucherCI.glbldgv2.Columns[10].Name = "Cost";
            frmVoucherCI.glbldgv2.Columns[11].Name = "RefforAC";

            //Setting Data Source for DataGridView
            frmVoucherCI.glbldgv2.DataSource = bindingSource;
            //            dgv1.AutoResizeColumns();
            //            dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            myconnection.Close();
            //            this.WindowState = FormWindowState.Maximized;
            //            dgv1.AllowUserToAddRows = true;
            frmVoucherCI.glbldgv2.Columns[2].DefaultCellStyle.Format = "N2";
            frmVoucherCI.glbldgv2.Columns[3].DefaultCellStyle.Format = "N2";
            frmVoucherCI.glbldgv2.Columns[5].DefaultCellStyle.Format = "N2";
            frmVoucherCI.glbldgv2.Columns[6].DefaultCellStyle.Format = "N2";
            frmVoucherCI.glbldgv2.Columns[7].DefaultCellStyle.Format = "N2";
            frmVoucherCI.glbldgv2.Columns[8].DefaultCellStyle.Format = "N2";
            frmVoucherCI.glbldgv2.Columns[9].DefaultCellStyle.Format = "N2";
            frmVoucherCI.glbldgv2.Columns[10].DefaultCellStyle.Format = "N2";

        }

        private void LVpso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LVpso.SelectedItems.Count > 0)
            {
                ListViewItem itm = LVpso.SelectedItems[0];
                txtDocNum.Text = itm.SubItems[0].Text;
            }
            transferheadingdata();
            frmVoucherCI.glbldgv2.DataSource = null;
            frmVoucherCI.glbldgv2.Columns.Clear();
            showdgvdata();
            dgv2total();
            foreach (DataGridViewColumn column in frmVoucherCI.glbldgv2.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
   
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void transferheadingdata()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT WHCode, Reference, ControlNo, Term, D1, D2, D3, PC, PONum FROM ViewSO WHERE DocNum = '" + txtDocNum.Text + "'", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    frmVoucherCI.glblcboWHCode.SelectedValue = dr["WHCode"].ToString();
                    //frmVoucherCI.glbltxtreference.Text = dr["Reference"].ToString();
                    frmVoucherCI.glblcboControlNo.SelectedValue = dr["Controlno"].ToString();
                    frmVoucherCI.glbltxtTerm.Text = dr["Term"].ToString();
                    frmVoucherCI.glbltxtD1.Text = Convert.ToDouble(dr["D1"]).ToString("0.0%");
                    frmVoucherCI.glbltxtD2.Text = Convert.ToDouble(dr["D2"]).ToString("0.0%");
                    frmVoucherCI.glbltxtD3.Text = Convert.ToDouble(dr["D3"]).ToString("0.0%");
                    frmVoucherCI.glblcboPC.SelectedValue = dr["PC"].ToString();
                    frmVoucherCI.glbltxtPONum.Text = dr["PONum"].ToString();
                    frmVoucherCI.glblcbSOTransact.Checked = true;
                    frmVoucherCI.glbltxtSODocNum.Text = txtDocNum.Text;
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
        private void dgv2total()
        {
            double vartxttotactdisct = 0.00;
            double vartxttotpdisct = 0.00;
            double vartxttotvat = 0.00;
            double vartxttotsales = 0.00;
            double vartxttotcost = 0.00;

            for (int x = 0; x < frmVoucherCI.glbldgv2.Rows.Count - 1; x++)
            {
                vartxttotactdisct += double.Parse(frmVoucherCI.glbldgv2.Rows[x].Cells[6].FormattedValue.ToString());
            }
            frmVoucherCI.glbltxtTotActDisct.Text = vartxttotactdisct.ToString("n2");

            for (int x = 0; x < frmVoucherCI.glbldgv2.Rows.Count - 1; x++)
            {
                vartxttotpdisct += double.Parse(frmVoucherCI.glbldgv2.Rows[x].Cells[7].FormattedValue.ToString());
            }
            frmVoucherCI.glbltxtTotPDisct.Text = vartxttotpdisct.ToString("n2");

            for (int x = 0; x < frmVoucherCI.glbldgv2.Rows.Count - 1; x++)
            {
                vartxttotvat += double.Parse(frmVoucherCI.glbldgv2.Rows[x].Cells[8].FormattedValue.ToString());
            }
            frmVoucherCI.glbltxtTotVat.Text = vartxttotvat.ToString("n2");

            for (int x = 0; x < frmVoucherCI.glbldgv2.Rows.Count - 1; x++)
            {
                vartxttotsales += double.Parse(frmVoucherCI.glbldgv2.Rows[x].Cells[9].FormattedValue.ToString());
            }
            frmVoucherCI.glbltxtTotSales.Text = vartxttotsales.ToString("n2");

            for (int x = 0; x < frmVoucherCI.glbldgv2.Rows.Count - 1; x++)
            {
                vartxttotcost += double.Parse(frmVoucherCI.glbldgv2.Rows[x].Cells[10].FormattedValue.ToString());
            }
            frmVoucherCI.glbltxtTotCost.Text = vartxttotcost.ToString("n2");
            frmVoucherCI.glbltxtTotNet.Text = (double.Parse(frmVoucherCI.glbltxtTotSales.Text) - (double.Parse(frmVoucherCI.glbltxtTotActDisct.Text) + double.Parse(frmVoucherCI.glbltxtTotPDisct.Text))).ToString("N2");

        }


    }
}
