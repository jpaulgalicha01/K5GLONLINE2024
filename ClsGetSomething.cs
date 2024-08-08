using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace K5GLONLINE
{
    class ClsGetSomething
    {
        public string plvarbalance, plvarpiecebal, plvarcsbal, plvaribbal, plsvarItem, plsvarQty;
        public string plvarbalanceunserve;
        public string plvarib, plvarpiece, plvarSPPC, plvarSPPI, plvarSPPP, plvarLC, plvarVC, plvarCostMethod;
        public string plsSLS, plsTerm, plsSPO, plsAddress, plsBusAddress;
        public string plsVATRate;
        public string plsAveUC;
        public string plsActualCost;
        public string plsTotalPCOrdered;
        public string plsNormalBal, plsdefdate;
        public string plsVersionGo, plsAT, plsDocNum, plsVersion, plsNewVersion;
        public string plsUCost, plsUVAT, plsDcrDate, plsSalesman, plsRemarks, plsBusinessType;
        public bool plbSellCS, plbSellIB, plbSellPC, plbUMControl, plvarFreeGoods;
        SqlConnection myconnection;
        SqlDataReader dr;
        SqlCommand mycommand;
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();

        public void ClsGetProductDetails(string strStockNumber, string strSPO)
        {
            try
            {

                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("Select * FROM tblStocks WHERE StockNumber ='" + strStockNumber + "'", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();
                while (dr.Read())
                {
                    plsvarItem = dr["Item"].ToString();
                    plvarib = dr["IB"].ToString();
                    plvarpiece = dr["Piece"].ToString();
                    plvarLC = dr["LC"].ToString();
                    plvarVC = dr["VC"].ToString();
                    plvarCostMethod = dr["CostMethod"].ToString();
                    plbSellCS = (bool)dr["SellCS"];
                    plbSellIB = (bool)dr["SellIB"];
                    plbSellPC = (bool)dr["SellPC"];
                    switch (strSPO)
                    {
                        case "01":
                            plvarSPPC = dr["SPPC1"].ToString();
                            plvarSPPI = dr["SPPI1"].ToString();
                            plvarSPPP = dr["SPPP1"].ToString();
                            break;
                        case "02":
                            plvarSPPC = dr["SPPC2"].ToString();
                            plvarSPPI = dr["SPPI2"].ToString();
                            plvarSPPP = dr["SPPP2"].ToString();
                            break;
                        case "03":
                            plvarSPPC = dr["SPPC3"].ToString();
                            plvarSPPI = dr["SPPI3"].ToString();
                            plvarSPPP = dr["SPPP3"].ToString();
                            break;
                        case "04":
                            plvarSPPC = dr["SPPC4"].ToString();
                            plvarSPPI = dr["SPPI4"].ToString();
                            plvarSPPP = dr["SPPP4"].ToString();
                            break;
                        case "05":
                            plvarSPPC = dr["SPPC5"].ToString();
                            plvarSPPI = dr["SPPI5"].ToString();
                            plvarSPPP = dr["SPPP5"].ToString();
                            break;
                        case "06":
                            plvarSPPC = dr["SPPC6"].ToString();
                            plvarSPPI = dr["SPPI6"].ToString();
                            plvarSPPP = dr["SPPP6"].ToString();
                            break;
                        case "07":
                            plvarSPPC = dr["SPPC7"].ToString();
                            plvarSPPI = dr["SPPI7"].ToString();
                            plvarSPPP = dr["SPPP7"].ToString();
                            break;
                        case "08":
                            plvarSPPC = dr["SPPC8"].ToString();
                            plvarSPPI = dr["SPPI8"].ToString();
                            plvarSPPP = dr["SPPP8"].ToString();
                            break;
                        case "09":
                            plvarSPPC = dr["SPPC9"].ToString();
                            plvarSPPI = dr["SPPI9"].ToString();
                            plvarSPPP = dr["SPPP9"].ToString();
                            break;
                        case "10":
                            plvarSPPC = dr["SPPC10"].ToString();
                            plvarSPPI = dr["SPPI10"].ToString();
                            plvarSPPP = dr["SPPP10"].ToString();
                            break;
                        case "11":
                            plvarSPPC = dr["SPPC11"].ToString();
                            plvarSPPI = dr["SPPI11"].ToString();
                            plvarSPPP = dr["SPPP11"].ToString();
                            break;
                        case "12":
                            plvarSPPC = dr["SPPC12"].ToString();
                            plvarSPPI = dr["SPPI12"].ToString();
                            plvarSPPP = dr["SPPP12"].ToString();
                            break;
                        case "13":
                            plvarSPPC = dr["SPPC13"].ToString();
                            plvarSPPI = dr["SPPI13"].ToString();
                            plvarSPPP = dr["SPPP13"].ToString();
                            break;
                        case "14":
                            plvarSPPC = dr["SPPC14"].ToString();
                            plvarSPPI = dr["SPPI14"].ToString();
                            plvarSPPP = dr["SPPP14"].ToString();
                            break;
                        case "15":
                            plvarSPPC = dr["SPPC15"].ToString();
                            plvarSPPI = dr["SPPI15"].ToString();
                            plvarSPPP = dr["SPPP15"].ToString();
                            break;
                        case "16":
                            plvarSPPC = dr["SPPC16"].ToString();
                            plvarSPPI = dr["SPPI16"].ToString();
                            plvarSPPP = dr["SPPP16"].ToString();
                            break;
                        case "17":
                            plvarSPPC = dr["SPPC17"].ToString();
                            plvarSPPI = dr["SPPI17"].ToString();
                            plvarSPPP = dr["SPPP17"].ToString();
                            break;
                        case "18":
                            plvarSPPC = dr["SPPC18"].ToString();
                            plvarSPPI = dr["SPPI18"].ToString();
                            plvarSPPP = dr["SPPP18"].ToString();
                            break;
                        case "19":
                            plvarSPPC = dr["SPPC19"].ToString();
                            plvarSPPI = dr["SPPI19"].ToString();
                            plvarSPPP = dr["SPPP19"].ToString();
                            break;
                        case "20":
                            plvarSPPC = dr["SPPC20"].ToString();
                            plvarSPPI = dr["SPPI20"].ToString();
                            plvarSPPP = dr["SPPP20"].ToString();
                            break;
                        case "21":
                            plvarSPPC = dr["SPPC21"].ToString();
                            plvarSPPI = dr["SPPI21"].ToString();
                            plvarSPPP = dr["SPPP21"].ToString();
                            break;
                        case "22":
                            plvarSPPC = dr["SPPC22"].ToString();
                            plvarSPPI = dr["SPPI22"].ToString();
                            plvarSPPP = dr["SPPP22"].ToString();
                            break;
                        case "23":
                            plvarSPPC = dr["SPPC23"].ToString();
                            plvarSPPI = dr["SPPI23"].ToString();
                            plvarSPPP = dr["SPPP23"].ToString();
                            break;
                        case "24":
                            plvarSPPC = dr["SPPC24"].ToString();
                            plvarSPPI = dr["SPPI24"].ToString();
                            plvarSPPP = dr["SPPP24"].ToString();
                            break;
                        case "25":
                            plvarSPPC = dr["SPPC25"].ToString();
                            plvarSPPI = dr["SPPI25"].ToString();
                            plvarSPPP = dr["SPPP25"].ToString();
                            break;
                        default:
                            plvarSPPC = dr["SPPC1"].ToString();
                            plvarSPPI = dr["SPPI1"].ToString();
                            plvarSPPP = dr["SPPP1"].ToString();
                            break;
                    }
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
                //dr.Close();
                myconnection.Close();
            }
        }

        public void ClsGetProductBasicDetails(string strStockNumber)
        {
            try
            {

                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("Select *  FROM tblStocks WHERE StockNumber ='" + strStockNumber + "'", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();
                while (dr.Read())
                {
                    plsvarItem = dr["Item"].ToString();
                    plvarib = dr["IB"].ToString();
                    plvarpiece = dr["Piece"].ToString();
                    plvarLC = dr["LC"].ToString();
                    plvarVC = dr["VC"].ToString();
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
                //dr.Close();
                myconnection.Close();
            }
        }

        public void ClsGetProductQty(string strStockNumber)
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("Select Qty FROM tblStockBlock WHERE StockNumber ='" + strStockNumber + "'", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        plsvarQty = dr["Qty"].ToString();
                    }
                }
                else
                {
                    plsvarQty = "";
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
                //dr.Close();
                myconnection.Close();
            }
        }

        public void ClsGetPieceBal(string strWHCode, string strStockNumber)
        {
            try
            {

                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                if (new Clsexist().RecordExists(ref myconnection, "SELECT StockNumber FROM ViewProductBalance WHERE  WHCode = '" + strWHCode + "' AND StockNumber ='" + strStockNumber + "'"))
                {
                    mycommand = new SqlCommand("Select Sum(BalPiece) As SumBalPiece, IB, Piece  FROM ViewProductBalance WHERE WHCode = '" + strWHCode + "' AND StockNumber ='" + strStockNumber + "' GROUP BY  IB, Piece, WHCode, StockNumber", myconnection);
                    mycommand.CommandTimeout = 600;
                    dr = mycommand.ExecuteReader();
                    while (dr.Read())
                    {
                        int varPiece = Convert.ToInt32(dr["Piece"]);
                        int varIB = Convert.ToInt32(dr["IB"]);
                        double varbalance = Convert.ToDouble(dr["SumBalPiece"]);
                        plvarbalance = varbalance.ToString();
                    }
                }
                else
                {
                    plvarbalance = "0.00";
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

        public void ClsGetFreeGoods(string strStockNumber)
        {
            try
            {

                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();

                mycommand = new SqlCommand("Select FreeGoods FROM tblStocks WHERE StockNumber ='" + strStockNumber + "'", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();
                while (dr.Read())
                {
                    plvarFreeGoods = Convert.ToBoolean(dr["FreeGoods"]);
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

        public void ClsGetPieceBalunserve(string strWHCode, string strStockNumber)
        {
            try
            {

                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                if (new Clsexist().RecordExists(ref myconnection, "SELECT StockNumber FROM ViewProductBalanceUnserve WHERE  WHCode = '" + strWHCode + "' AND StockNumber ='" + strStockNumber + "'"))
                {
                    mycommand = new SqlCommand("Select Sum(BalPiece) As SumBalPiece, IB, Piece  FROM ViewProductBalanceUnserve WHERE WHCode = '" + strWHCode + "' AND StockNumber ='" + strStockNumber + "' GROUP BY  IB, Piece, WHCode, StockNumber", myconnection);
                    mycommand.CommandTimeout = 600;
                    dr = mycommand.ExecuteReader();
                    while (dr.Read())
                    {
                        int varPiece = Convert.ToInt32(dr["Piece"]);
                        int varIB = Convert.ToInt32(dr["IB"]);
                        double varbalance = Convert.ToDouble(dr["SumBalPiece"]);
                        plvarbalanceunserve = varbalance.ToString();
                    }
                }
                else
                {
                    plvarbalanceunserve = "0.00";
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

        public void ClsGetConvertedPieceBal(double varpcbalance, int varIB, int varPiece)
        {
            try
            {
                double piecebal = varpcbalance % varPiece;
                plvarpiecebal = piecebal.ToString();
                //IB Total Converted
                if (varIB == 0)
                {
                    plvaribbal = "0.00";
                }
                else
                {
                    double SIB = varpcbalance - piecebal;
                    double DPC = SIB / varPiece;
                    double ibbal = (DPC % varIB);
                    plvaribbal = ibbal.ToString();
                }
                //CS Total Converted
                int divBy;
                double CaseQ;
                double CSIB = varpcbalance - piecebal;
                double CDPC = CSIB / varPiece;
                if (varIB == 0)
                {
                    divBy = varPiece;
                    CaseQ = CSIB;
                }
                else
                {
                    divBy = varIB;
                    CaseQ = CDPC - Convert.ToDouble(plvaribbal);
                }
                plvarcsbal = (CaseQ / divBy).ToString();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
            }
        }

        public void ClsGetCustData(string strControlNo)
        {
            try
            {

                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("Select SLS, Term, SPO, Address, BusinessAddress, BusinessType FROM tblCustomer WHERE ControlNo = '" + strControlNo + "'", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();
                while (dr.Read())
                {
                    plsSLS = dr["SLS"].ToString();
                    plsTerm = dr["Term"].ToString();
                    plsSPO = dr["SPO"].ToString();
                    plsAddress = dr["Address"].ToString();
                    plsBusAddress = dr["BusinessAddress"].ToString();
                    plsBusinessType = dr["BusinessType"].ToString();
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
                //dr.Close();
                myconnection.Close();
            }
        }

        public void ClsGetVATRate()
        {
            try
            {

                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("Select VAT FROM tblVat", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();
                while (dr.Read())
                {
                    plsVATRate = (Convert.ToDouble(dr["VAT"]) + 1).ToString();

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
                //dr.Close();
                myconnection.Close();
            }
        }

        public void ClsGetAveCost(DateTime dtTDate, string strStockNumber, bool boolcbPoulty, string strCostMethod)
        {
            try
            {
                //If Forms![frmVoucher CIVan1]![CT] = -1 And [CostMethod] = "1" Then
                //     Varcpc = DLookup("[UCost]", "qryPoultryCostCIVan", "[StockNumber]=Forms![frmOrderCIVan]![StockNumber]")
                //     If IsNull(Varcpc) Then
                //        [cpc] = Val(Format(DLookup("[LC]", "tblStocks", "[StockNumber]=Forms![frmOrderCIVan]![StockNumber]"), "#.##"))
                //     Else
                //        [cpc] = Val(Format(Varcpc, "#.##"))
                //     End If

                //ElseIf Forms![frmVoucher CIVan1]![CT] = -1 And [CostMethod] = "2" Then
                //        [cpc] = Me.CostRef.Column(3)

                //Else
                //        [cpc] = Val(Format([LC], "#.##"))
                //End If
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                if (boolcbPoulty = true && strCostMethod == "1")
                {
                    if (new Clsexist().RecordExists(ref myconnection, "SELECT StockNumber FROM ViewPoultryCost WHERE  TDate = '" + dtTDate + "' AND StockNumber = '" + strStockNumber + "'"))
                    {
                        mycommand = new SqlCommand("Select StockNumber, Sum(UCost1)/Sum(Qty) AS UCost, LC FROM ViewPoultryCost  WHERE TDate = '" + dtTDate + "' AND StockNumber = '" + strStockNumber + "' GROUP BY StockNumber, TDate, LC", myconnection);
                        mycommand.CommandTimeout = 600;
                        dr = mycommand.ExecuteReader();
                        while (dr.Read())
                        {
                            plsAveUC = dr["UCost"].ToString();
                        }
                    }
                    else
                    {
                        mycommand = new SqlCommand("Select LC  FROM tblStocks WHERE StockNumber ='" + strStockNumber + "'", myconnection);
                        mycommand.CommandTimeout = 600;
                        dr = mycommand.ExecuteReader();
                        while (dr.Read())
                        {
                            plsAveUC = dr["LC"].ToString();
                        }
                    }
                    dr.Close();
                    myconnection.Close();

                }
                else
                {
                    mycommand = new SqlCommand("Select LC  FROM tblStocks WHERE StockNumber ='" + strStockNumber + "'", myconnection);
                    mycommand.CommandTimeout = 600;
                    dr = mycommand.ExecuteReader();
                    while (dr.Read())
                    {
                        plsAveUC = dr["LC"].ToString();
                    }

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

        public void ClsGetActualCost(string strRefforAC)
        {
            try
            {

                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("Select MaxActualCost FROM ViewActualCostProducts2 WHERE RefforAC = '" + strRefforAC + "'", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();
                while (dr.Read())
                {
                    plsActualCost = dr["MaxActualCost"].ToString();
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
                //dr.Close();
                myconnection.Close();
            }
        }

        public void ClsGetConvertedToPieceQty(double vardtxtORDCS, double vardtxtORDIB, double vardtxtORDPC, int varinttxtIB, int varinttxtPiece)
        {
            try
            {

                double convertedCS, convertedIB;
                double convertedPC = vardtxtORDPC;
                if (varinttxtIB == 0)
                {
                    convertedCS = vardtxtORDCS * varinttxtPiece;
                    convertedIB = 0;
                }
                else
                {
                    convertedCS = (vardtxtORDCS * varinttxtIB) * varinttxtPiece;
                    convertedIB = vardtxtORDIB * varinttxtPiece;
                }
                plsTotalPCOrdered = (convertedCS + convertedIB + convertedPC).ToString("N2");

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                //dr.Close();
                myconnection.Close();
            }
        }

        public void ClsGetNormalBal(string strvarPA)
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("Select NormalBal FROM ViewPA WHERE PA = '" + strvarPA + "'", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();
                while (dr.Read())
                {
                    plsNormalBal = dr["NormalBal"].ToString();
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
                //dr.Close();
                myconnection.Close();
            }
        }

        public void ClsGetDefaultDate()
        {
            DateTime VarToday = DateTime.Today;
            plsdefdate = String.Format("{0:MM/dd/yyyy}", VarToday);
        }

        public void ClsConfirmVersionNum(string strVersion)
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("Select COUNT(*) FROM tblNewCover WHERE Version='" + strVersion + "'", myconnection);
                mycommand.CommandTimeout = 600;
                int count = (int)mycommand.ExecuteScalar();
                if (count == 1)
                {
                    plsVersionGo = "Yes";
                }
                else
                {
                    plsVersionGo = "No";
                }
                myconnection.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                //dr.Close();
                myconnection.Close();
            }
        }

        public void ClsNewVersion(string strVersion)
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("Select Top(1) Version FROM tblNewCover ORDER BY Version DESC", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();
                dr.Read();
                
                if(dr["Version"].ToString() != strVersion)
                {
                    plsNewVersion = "Yes";
                }   
               
                myconnection.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                //dr.Close();
                myconnection.Close();
            }
        }

        public void ClsGetAT(string strPA)
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();

                mycommand = new SqlCommand("SELECT AT FROM ViewPA WHERE PA='" + strPA + "'", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();
                while (dr.Read())
                {
                    plsAT = dr["AT"].ToString();
                }
                myconnection.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                //dr.Close();
                myconnection.Close();
            }
        }


        public void ClsPDUCost(string strUM, double dblTotalCost, double dbltotalVAT, double dblPIn, int intIB, int intPiece)
        {
            double dblUCost = dblTotalCost / dblPIn;
            double dblUVAT = dbltotalVAT / dblPIn;
            if (strUM == "CS")
            {
                plsUCost = dblUCost.ToString("N2");
                plsUVAT = dblUVAT.ToString("N2");
            }
            else if (strUM == "IB")
            {
                plsUCost = (dblUCost * intIB).ToString("N2");
                plsUVAT = (dblUVAT * intIB).ToString("N2");
            }
            else if (strUM == "PC" && intIB == 0)
            {
                plsUCost = (dblUCost * intPiece).ToString("N2");
                plsUVAT = (dblUVAT * intPiece).ToString("N2");
            }
            else if (strUM == "PC" && intIB != 0)
            {
                plsUCost = ((dblUCost * intPiece) * intIB).ToString("N2");
                plsUVAT = ((dblUVAT * intPiece) * intPiece).ToString("N2");
            }

        }

        public void ClsGetUMControl(string strWHCode)
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT UMControl FROM tblWarehouse WHERE WHCode='" + strWHCode + "'", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();
                dr.Read();
                plbUMControl = (bool)dr["UMControl"];
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

        public void ClsGetDCRData(string strDocNum)
        {
            try
            {

                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("Select DSCRDate, Salesman, Remarks, DocNum  FROM ViewDCRList WHERE DocNum = '" + strDocNum + "'", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();
                while (dr.Read())
                {
                    plsDcrDate = dr["DSCRDate"].ToString();
                    plsSalesman = dr["Salesman"].ToString();
                    plsRemarks = dr["Remarks"].ToString();
                    plsDocNum = dr["DocNum"].ToString();

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
                //dr.Close();
                myconnection.Close();
            }
        }

        public string clsChecking(string strURICheck)
        {
            string res = "";
            int count = 1;
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();

            if (strURICheck == "tblMain4")
            {
                mycommand = new SqlCommand("SELECT COUNT(*) FROM tblMain4", myconnection);
                count = int.Parse(mycommand.ExecuteScalar().ToString());

                if (count == 0)
                    res = "0";
            }
            else if(strURICheck == "tblManifest")
            {
                mycommand = new SqlCommand("SELECT COUNT(*) FROM tblManifest", myconnection);
                count = int.Parse(mycommand.ExecuteScalar().ToString());

                if (count == 0)
                    res = "0";
            }
            else if(strURICheck == "tblDailySalesCollection")
            {
                mycommand = new SqlCommand("SELECT COUNT(*) FROM tblDailySalesCollection", myconnection);
                count = int.Parse(mycommand.ExecuteScalar().ToString());

                if (count == 0)
                    res = "0";
            }
            else
            {
                mycommand = new SqlCommand("SELECT COUNT(*) FROM tblMain1 WHERE Voucher = '" + strURICheck + "' ", myconnection);
                count = int.Parse(mycommand.ExecuteScalar().ToString());

                if (count == 0)
                    res = "0";
            }
            myconnection.Close();
            return res;
        }





    }
}
