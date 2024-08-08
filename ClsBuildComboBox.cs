using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace K5GLONLINE
{
    class ClsBuildComboBox
    {
        public ArrayList T = new ArrayList();
        public ArrayList ARCCN = new ArrayList();
        public ArrayList ARPA = new ArrayList();
        public ArrayList ARPA1 = new ArrayList();
        public ArrayList ARANPA = new ArrayList();
        public ArrayList ARAN = new ArrayList();
        public ArrayList ARD1 = new ArrayList();
        public ArrayList ARD2 = new ArrayList();
        public ArrayList PLALACR = new ArrayList();
        public ArrayList PLALRSRef = new ArrayList();
        public ArrayList PLALASRef = new ArrayList();
        public ArrayList PLALUM = new ArrayList();
        public ArrayList PLAStockClass = new ArrayList();
        public ArrayList PALChannel = new ArrayList();
        public ArrayList PALSalesman = new ArrayList();
        public ArrayList PALRegion = new ArrayList();
        public ArrayList PALSPOption = new ArrayList();
        public ArrayList PALGA = new ArrayList();
        public ArrayList plsnumber = new ArrayList();
        public ArrayList plsnumber1 = new ArrayList();
        SqlConnection myconnection;
        SqlDataReader dr;
        SqlCommand mycommand;
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection(); 

        public void ClsBuildClientControlno(string vartype)
        {
            try
            {

                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT ControlNo, CustName FROM tblCustomer WHERE NType = '"+vartype+"' AND Active =1 ORDER by CustName ", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    ARCCN.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
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

        public void ClsBuildCVControlno()
        {
            try
            {

                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT ControlNo, CustName FROM tblCustomer WHERE Active=1 ORDER by CustName", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    T.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
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

        public void ClsBuildPA(bool bactnumber)
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                if (bactnumber == true)
                {
                    mycommand = new SqlCommand("SELECT PA, PA  +' - '+ AT FROM viewpa ORDER by PA ", myconnection);
                }
                else
                {
                    mycommand = new SqlCommand("SELECT PA, AT FROM viewpa ORDER by AT ", myconnection);
                }
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    ARPA.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));

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
        public void ClsBuildPA1(bool bactnumber)
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                if (bactnumber == true)
                {
                    mycommand = new SqlCommand("SELECT PA, PA  +' - '+ AT FROM viewpa ORDER by PA ", myconnection);
                }
                else
                {
                    mycommand = new SqlCommand("SELECT PA, AT FROM viewpa ORDER by AT ", myconnection);
                }
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    ARPA1.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));

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
           
        
        public void ClsBuildAcctNo()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT AcctNo, TitleAcct FROM tbltitleacct ORDER by TitleAcct", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    ARAN.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));

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

        public void ClsBuildAcctNoPA()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT AcctNo, TitleAcct FROM Viewtbltitleacct ORDER by TitleAcct", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    ARANPA.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
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

        public void ClsBuildD1Code()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT D1Code, D1Desc FROM tbldept1 ORDER by D1Desc", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    ARD1.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
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

        public void ClsBuildD2Code()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT D2Code, D2Desc FROM tbldept2 ORDER by D2Desc", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    ARD2.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
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

 
        public void ClsBuildASRefDeduct(string strControlNo)
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT Refer, Refer +' - '+ CONVERT(varchar(13),(MinDate)) +' - '+CONVERT(varchar(12),(Balance)) AS Details FROM [ViewAP1Aging] WHERE ControlNo='" + strControlNo + "'", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    PLALASRef.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
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

        public void ClsBuildUM(int vartxtIB)
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                if (vartxtIB == 0)
                {
                    mycommand = new SqlCommand("SELECT UM As UM1, UM As UM2 From tblUM1 ORDER BY UM", myconnection);
                }
                else
                {
                    mycommand = new SqlCommand("SELECT UM As UM1, UM As UM2 From tblUM ORDER BY UM", myconnection);
                }
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    PLALUM.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
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

        public void ClsBuildStockClass()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT ClassCode, ClassDesc FROM tblStockClass ORDER by ClassDesc", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    PLAStockClass.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
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
        public void ClsBuildChannel()
        {
            try
            {

                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT CC, Description FROM tblChannel ORDER by Description", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    PALChannel.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
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
                mycommand = new SqlCommand("SELECT SLS, Names FROM tblSalesman WHERE Active= 1 ORDER by Names", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    PALSalesman.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
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

        public void ClsBuildRegion()
        {
            try
            {

                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT RegCode, RegName FROM tblRegion ORDER by RegName", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    PALRegion.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
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

        public void ClsBuildSPOption()
        {
            try
            {

                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT SPCode, SPDesc FROM tblSPOption ORDER by SPDesc", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    PALSPOption.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
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

        public void ClsBuildGA()
        {
            try
            {

                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT GA, GeogArea FROM tblGA ORDER by GeogArea", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    PALGA.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
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

        public void ClsCboSelect(string strURIVoucher)
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL(); myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();

                if (strURIVoucher == "tblMain4")
                {

                    string CheckNoTransact = string.Format("SELECT Count(*) FROM tblManifest");
                    SqlCommand com = new SqlCommand(CheckNoTransact, myconnection);
                    int CountData = int.Parse(com.ExecuteScalar().ToString());

                    mycommand = new SqlCommand("SELECT DocNum,UserName FROM " + strURIVoucher+ " WHERE(ISNUMERIC(DocNum) = 1) ORDER BY DocNum DESC", myconnection);
                    mycommand.CommandTimeout = 600;
                    dr = mycommand.ExecuteReader();
                    while (dr.Read())
                    {
                        plsnumber.Add(new Clsaddvalue(dr.GetString(0), dr.GetString(0)));
                        plsnumber1.Add(new Clsaddvalue(dr.GetString(0), dr.GetString(0)));
                    }
                    dr.Close();


                } 
                else if (strURIVoucher == "tblManifest")
                {
                    ClsGetConnection1.ClsGetConMSSQL(); myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                    myconnection.Open();
                    mycommand = new SqlCommand("SELECT Top 50 MNum,DTDesc FROM tblManifest WHERE (ISNUMERIC(MNum) = 1) ORDER BY MNum DESC", myconnection);
                    mycommand.CommandTimeout = 600;
                    dr = mycommand.ExecuteReader();
                    while (dr.Read())
                    {
                        plsnumber.Add(new Clsaddvalue(dr.GetString(0), dr.GetString(0)));
                        plsnumber1.Add(new Clsaddvalue(dr.GetString(0), dr.GetString(0)));
                    }

                    dr.Close();
                }
                else if (strURIVoucher == "tblDailySalesCollection")
                {
                    mycommand = new SqlCommand("SELECT Top 50 DSCRNum, DocNum FROM tblDailySalesCollection WHERE (ISNUMERIC(DocNum) = 1) ORDER BY DocNum DESC", myconnection);
                    mycommand.CommandTimeout = 600;
                    dr = mycommand.ExecuteReader();
                    while (dr.Read())
                    {
                        plsnumber.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(1)));
                        plsnumber1.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(1)));
                    }

                    dr.Close();
                }
                else
                {
                    mycommand = new SqlCommand("SELECT Top 50 IC,DocNum FROM tblMain1 WHERE  Voucher = '" + strURIVoucher + "' AND Void=0 AND (ISNUMERIC(DocNum) = 1) ORDER BY DocNum DESC", myconnection);
                    mycommand.CommandTimeout = 600;
                    dr = mycommand.ExecuteReader();
                    while (dr.Read())
                    {
                        plsnumber.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(1)));
                        plsnumber1.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(1)));
                    }
                    dr.Close();
                }
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

     }
}
