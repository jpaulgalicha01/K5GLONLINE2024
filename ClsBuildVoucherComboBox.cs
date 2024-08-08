using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace K5GLONLINE
{
    class ClsBuildVoucherComboBox
    {
        public ArrayList ARLWHCode = new ArrayList();
        public ArrayList ARLDestWHCode = new ArrayList();
        public ArrayList ARLSLS = new ArrayList();
        public ArrayList ARLSPC = new ArrayList();
        public ArrayList ARD2Code = new ArrayList();
        public ArrayList ARMonth = new ArrayList();
        public ArrayList ARLSN = new ArrayList();
        public ArrayList ARLSNPD = new ArrayList();
        public ArrayList ARYear = new ArrayList();
        public ArrayList ARLRemarks1 = new ArrayList();
        public ArrayList ARLReturnIndCode = new ArrayList();
        //public string PDate;
        SqlConnection myconnection;
        SqlDataReader dr;
        SqlCommand mycommand;
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();

        public void ClsBuildYearClaims(string strD2desc)
        {
            try
            {
                string Year = "";
                //DateTime PDate;
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT Year FROM ViewBookClaims WHERE D2Code='" + strD2desc + "' ORDER by Year DESC, Month DESC", myconnection);
                //Get Max Date Query , (SELECT MAX(DatePrepared) AS Date FROM ViewBookClaims WHERE D2Code='" + strD2desc + "') AS Date 
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    if (Year != dr.GetString(0))
                    {
                        ARYear.Add(new Clsaddvalue(dr.GetString(0), dr.GetString(0)));
                    }

                    Year = dr.GetString(0);
                    //DateTime VarToday = Convert.ToDateTime(dr.GetString(1));
                    //PDate = String.Format("{0:MM/dd/yyyy}", VarToday);

                    //PDate = dr["Date"].ToString();
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

        public void ClsBuildRemarks1()
        {
            try
            {

                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT RemarksCode, Remarks FROM tblRemarks ORDER by RemarksCode ", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    ARLRemarks1.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
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

        public void ClsBuildReason()
        {
            try
            {

                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT ReturnIndCode, ReturnIndicator FROM tblReturnInd ORDER by ReturnIndCode ", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    ARLReturnIndCode.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
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

        public void ClsBuildWarehouse()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT WHCode, Warehouse FROM tblWarehouse WHERE Active = 1  ORDER by Warehouse ", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    ARLWHCode.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
                    ARLDestWHCode.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
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


        public void ClsBuildSalesman()
        {
            try
            {

                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT Sls, Names FROM tblSalesman WHERE Active = 1 ORDER by Names ", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    ARLSLS.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
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

        public void ClsBuildPC()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT PC, PersonnelName FROM tblPersonnel WHERE Active = '1' ORDER BY PersonnelName", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    ARLSPC.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
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

        public void ClsBuildDept()
        {
            try
            {
                string D2Code = "";
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT D2Code, D2Desc FROM ViewBookClaims ORDER by D2Desc", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    if (D2Code != dr.GetString(0))
                    {
                        ARD2Code.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
                    }
                    D2Code = dr.GetString(0);
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
       
        public void ClsBuildMonthClaims(string strD2desc)
        {
            try
            {
                string Month = "";
                //DateTime PDate;
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT FldMonth FROM ViewBookClaims WHERE D2Code='" + strD2desc + "' ORDER by Year DESC, Month DESC", myconnection);
                //Get Max Date Query , (SELECT MAX(DatePrepared) AS Date FROM ViewBookClaims WHERE D2Code='" + strD2desc + "') AS Date 
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    if (Month != dr.GetString(0))
                    {
                        ARMonth.Add(new Clsaddvalue(dr.GetString(0), dr.GetString(0)));
                    }

                    Month = dr.GetString(0);
                    //DateTime VarToday = Convert.ToDateTime(dr.GetString(1));
                    //PDate = String.Format("{0:MM/dd/yyyy}", VarToday);

                    //PDate = dr["Date"].ToString();
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

        public void ClsBuildStocks(bool varbstockNumber, bool varbPoultryProd)
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                if (varbstockNumber == true && varbPoultryProd == true)
                {
                    mycommand = new SqlCommand("SELECT StockNumber, StockNumber As SN2 FROM tblStocks  WHERE Active = 1 AND CatCode ='028' ORDER by StockNumber ", myconnection);
                }
                else if (varbstockNumber == true && varbPoultryProd == false)
                {
                    mycommand = new SqlCommand("SELECT StockNumber, StockNumber As SN2 FROM tblStocks  WHERE Active = 1 AND CatCode <>'028' ORDER by StockNumber ", myconnection);

                }
                else if (varbstockNumber == false && varbPoultryProd == true)
                {
                    mycommand = new SqlCommand("SELECT StockNumber, Item FROM tblStocks  WHERE Active = 1 AND CatCode='028' ORDER by Item ", myconnection);
                }
                else if (varbstockNumber == false && varbPoultryProd == false)
                {
                    mycommand = new SqlCommand("SELECT StockNumber, Item FROM tblStocks  WHERE Active = 1 AND CatCode <>'028' ORDER by Item ", myconnection);
                }
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    ARLSN.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
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
        
        public void ClsBuildStocksPerCust(bool varbstockNumber, bool varbPoultryProd, string ControlNo)
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                //if (varbstockNumber == true && varbPoultryProd == true)
                //{
                //    mycommand = new SqlCommand("SELECT StockNumber, StockNumber As SN2 FROM tblStockBlock WHERE AND ControlNo ='"+ControlNo+"' ORDER by StockNumber ", myconnection);
                //}
                //else if (varbstockNumber == true && varbPoultryProd == false)
                //{
                //    mycommand = new SqlCommand("SELECT StockNumber, StockNumber As SN2 FROM tblStockBlock WHERE AND ControlNo ='" + ControlNo + "' ORDER by StockNumber ", myconnection);

                //}
                //else if (varbstockNumber == false && varbPoultryProd == true)
                //{
                //    mycommand = new SqlCommand("SELECT StockNumber, Item FROM tblStockBlock WHERE AND ControlNo ='" + ControlNo + "' ORDER by Item ", myconnection);
                //}
                //else if (varbstockNumber == false && varbPoultryProd == false)
                //{
                    mycommand = new SqlCommand("SELECT StockNumber, Item FROM tblStockBlock WHERE ControlNo ='" + ControlNo + "' ORDER by Item", myconnection);
                //}
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ARLSN.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
                    }
                    dr.Close();
                }
                else
                {
                    ClsGetConnection1.ClsGetConMSSQL();
                    myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                    myconnection.Open();
                    if (varbstockNumber == true && varbPoultryProd == true)
                    {
                        mycommand = new SqlCommand("SELECT StockNumber, StockNumber As SN2 FROM tblStocks  WHERE Active = 1 AND CatCode ='028' ORDER by StockNumber ", myconnection);
                    }
                    else if (varbstockNumber == true && varbPoultryProd == false)
                    {
                        mycommand = new SqlCommand("SELECT StockNumber, StockNumber As SN2 FROM tblStocks  WHERE Active = 1 AND CatCode <>'028' ORDER by StockNumber ", myconnection);

                    }
                    else if (varbstockNumber == false && varbPoultryProd == true)
                    {
                        mycommand = new SqlCommand("SELECT StockNumber, Item FROM tblStocks  WHERE Active = 1 AND CatCode='028' ORDER by Item ", myconnection);
                    }
                    else if (varbstockNumber == false && varbPoultryProd == false)
                    {
                        mycommand = new SqlCommand("SELECT StockNumber, Item FROM tblStocks  WHERE Active = 1 AND CatCode <>'028' ORDER by Item ", myconnection);
                    }
                    mycommand.CommandTimeout = 600;
                    dr = mycommand.ExecuteReader();

                    while (dr.Read())
                    {
                        ARLSN.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
                    }
                    dr.Close();
                }
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
        
        public void ClsBuildStocksPD(bool varbstockNumber, bool varbPoultryProd, string varControlNo)
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                if (varbstockNumber == true && varbPoultryProd == true)
                {
                    mycommand = new SqlCommand("SELECT StockNumber, StockNumber As SN2 FROM tblStocks  WHERE Active = 1 AND CatCode ='028' AND ClassCode = '" + varControlNo + "' ORDER by StockNumber ", myconnection);
                }
                else if (varbstockNumber == true && varbPoultryProd == false)
                {
                    mycommand = new SqlCommand("SELECT StockNumber, StockNumber As SN2 FROM tblStocks  WHERE Active = 1 AND CatCode <>'028' AND ClassCode = '" + varControlNo + "' ORDER by StockNumber ", myconnection);

                }
                else if (varbstockNumber == false && varbPoultryProd == true)
                {
                    mycommand = new SqlCommand("SELECT StockNumber, Item FROM tblStocks  WHERE Active = 1 AND CatCode='028' AND ClassCode = '" + varControlNo + "' ORDER by Item ", myconnection);
                }
                else if (varbstockNumber == false && varbPoultryProd == false)
                {
                    mycommand = new SqlCommand("SELECT StockNumber, Item FROM tblStocks  WHERE Active = 1 AND CatCode <>'028' AND ClassCode = '" + varControlNo + "'  ORDER by Item ", myconnection);
                }
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    ARLSNPD.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
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

        public void ClsBuildDeliveryVan()
        {
            try
            {
                string D2Code = "";
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT DVCode, DVDesc FROM tblDeliveryVan ORDER by DVDesc", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    if (D2Code != dr.GetString(0))
                    {
                        ARD2Code.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
                    }
                    D2Code = dr.GetString(0);
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
    }
}
