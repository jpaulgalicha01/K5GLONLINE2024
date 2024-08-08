using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections;

namespace K5GLONLINE
{
    class ClsBuildEntryComboBox
    {
        public ArrayList ARBankCode = new ArrayList();
        public ArrayList ARWHCode = new ArrayList();
        public ArrayList ARDestWHCode = new ArrayList();
        public ArrayList ARTCode = new ArrayList();
        public ArrayList ARChannelCode = new ArrayList();
        public ArrayList ARGACode = new ArrayList();
        public ArrayList ARSPCode = new ArrayList();
        public ArrayList ARSMCode = new ArrayList();
        public ArrayList ARCatCode = new ArrayList();
        public ArrayList ARRegCode = new ArrayList();
        public ArrayList ARClassCode = new ArrayList();
        public ArrayList ARLUM = new ArrayList();
        SqlConnection myconnection;
        SqlDataReader dr;
        SqlCommand mycommand;
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();

        public void ClsBuildWHCode()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT WHCode, Warehouse FROM tblWarehouse ORDER by Warehouse", myconnection);
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    ARWHCode.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
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

        public void ClsBuildBankCode()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT BankCode, BankName FROM tblCheckWriterSetup ORDER BY BankName", myconnection);
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    ARBankCode.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
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

        public void ClsBuildDestWHCode()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT WHCode, WHDesc FROM tblWarehouse ORDER by WHDesc", myconnection);
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    ARDestWHCode.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
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
                mycommand = new SqlCommand("SELECT SMCode, SMDesc FROM tblSalesman ORDER by SMDesc ", myconnection);
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    ARSMCode.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
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
        public void ClsBuildTCode()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT TCode, TDesc FROM tblTerritory ORDER by TDesc", myconnection);
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    ARTCode.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
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

        public void ClsBuildChannelCode()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT CC, Description FROM tblChannel ORDER by Description", myconnection);
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    ARChannelCode.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
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

        public void ClsBuildGACode()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT GACode, GADesc FROM tblGeogArea ORDER by GADesc", myconnection);
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    ARGACode.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
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
        public void ClsBuildSPCode()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT SPCode, SPDesc FROM tblSPOption ORDER by SPDesc", myconnection);
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    ARSPCode.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
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

        public void ClsBuildCatCode()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT CatCode, CatDesc FROM tblCategory ORDER by CatDesc", myconnection);
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    ARCatCode.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
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


        public void ClsBuildRegCode()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT RegCode, RegName FROM tblRegion ORDER by RegName", myconnection);
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    ARRegCode.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
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

        public void ClsBuildPClassCode()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT PClassCode, PClassDesc FROM tblClass ORDER by PClassDesc", myconnection);
                dr = mycommand.ExecuteReader();

                while (dr.Read())
                {
                    ARClassCode.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
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

        public void ClsBuildUM(int varintIB)
        {

            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            if (varintIB == 0)
            {
                string sqlstatement = "SELECT UM As UM1, UM As UM2 FROM tblUM1 ";
                mycommand = new SqlCommand(sqlstatement, myconnection);
            }
            else
            {
                string sqlstatement = "SELECT UM As UM1, UM As UM2 FROM tblUM";
                mycommand = new SqlCommand(sqlstatement, myconnection);

            }

            dr = mycommand.ExecuteReader();
            while (dr.Read())
            {
                ARLUM.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
            }
            dr.Close();
            myconnection.Close();
        }
    }
}
