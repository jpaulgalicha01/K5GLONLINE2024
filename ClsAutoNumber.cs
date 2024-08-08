using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace K5GLONLINE
{
    class ClsAutoNumber
    {
        SqlConnection myconnection;
        SqlCommand mycommand;
        SqlDataReader dr;
        public string plsnumber;
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();

        public void CustomerNameAdd()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();

                mycommand = new SqlCommand("SELECT ControlNo AS ControlNo FROM ViewCustTopControlNo", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();
                while (dr.Read())
                {
                    string no1;
                    int no2;
                    no1 = dr[0].ToString();
                    no2 = (int.Parse(no1)) + 1;
                    plsnumber = Convert.ToString(no2).PadLeft(5, '0');

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

        public void GetBankCheckAddAutoNum()
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            string CheckNoTransact = string.Format("SELECT Count(*) FROM tblCheckWriterSetup");
            SqlCommand com = new SqlCommand(CheckNoTransact, myconnection);
            int CountData = int.Parse(com.ExecuteScalar().ToString());

            if (CountData > 0)
            {
                mycommand = new SqlCommand("SELECT TOP 1 BankCode FROM tblCheckWriterSetup ORDER BY BankCode DESC;", myconnection);
                dr = mycommand.ExecuteReader();
                dr.Read();
                string no1;
                int no2;
                no1 = dr["BankCode"].ToString();
                no2 = (int.Parse(no1)) + 1;
                plsnumber = Convert.ToString(no2).PadLeft(2, '0');
            }
            else
            {
                plsnumber = "01";
            }
            myconnection.Close();
        }


        public void OtherNameAdd()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                if (new Clsexist().RecordExists(ref myconnection, "SELECT CustCode FROM tblCustomer WHERE  NType = 'O' ORDER BY CustCode DESC"))
                {

                    mycommand = new SqlCommand("SELECT Top 1 CustCode FROM tblCustomer WHERE NType = 'O' ORDER BY CustCode DESC", myconnection);
                    mycommand.CommandTimeout = 600;
                    dr = mycommand.ExecuteReader();
                    while (dr.Read())
                    {
                        string no1;
                        int no2;
                        no1 = dr[0].ToString();
                        no2 = (int.Parse(no1)) + 1;
                        plsnumber = Convert.ToString(no2).PadLeft(5, '0');

                    }
                }
                else
                {
                    plsnumber = "00001";
                }
                if (plsnumber == "00001")
                {
                    myconnection.Close();
                }
                else
                {
                    dr.Close();
                    myconnection.Close();
                }


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


        public void VoucherAutoNum(string argvoucher)
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                if (new Clsexist().RecordExists(ref myconnection, "SELECT Top 1 DocNum FROM tblMain1 WHERE  Voucher ='" + argvoucher + "' AND (ISNUMERIC(DocNum) = 1)"))
                {
                    mycommand = new SqlCommand("SELECT Top 1 DocNum FROM tblMain1 WHERE  Voucher = '" + argvoucher + "' AND (ISNUMERIC(DocNum) = 1)  ORDER BY DocNum DESC", myconnection);
                    mycommand.CommandTimeout = 600;
                    dr = mycommand.ExecuteReader();
                    while (dr.Read())
                    {
                        string no1 = null;
                        int no2;
                        no1 = dr["DocNum"].ToString();
                        no2 = (int.Parse(no1)) + 1;
                        plsnumber = Convert.ToString(no2).PadLeft(7, '0');
                    }
                }
                else
                {
                    plsnumber = "0000001";
                }
                if (plsnumber == "0000001")
                {
                    myconnection.Close();
                }
                else
                {
                    dr.Close();
                    myconnection.Close();
                }
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

        public void VoucherAutoNumPark(string argvoucher)
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                if (new Clsexist().RecordExists(ref myconnection, "SELECT Top 1 DocNum FROM tblMainPark1 WHERE  Voucher ='" + argvoucher + "' AND (ISNUMERIC(DocNum) = 1)"))
                {
                    mycommand = new SqlCommand("SELECT Top 1 DocNum FROM tblMainPark1 WHERE  Voucher = '" + argvoucher + "' AND (ISNUMERIC(DocNum) = 1)  ORDER BY DocNum DESC", myconnection);
                    mycommand.CommandTimeout = 600;
                    dr = mycommand.ExecuteReader();
                    while (dr.Read())
                    {
                        string no1 = null;
                        int no2;
                        no1 = dr["DocNum"].ToString();
                        no2 = (int.Parse(no1)) + 1;
                        plsnumber = Convert.ToString(no2).PadLeft(7, '0');
                    }
                }
                else
                {
                    plsnumber = "0000001";
                }
                if (plsnumber == "0000001")
                {
                    myconnection.Close();
                }
                else
                {
                    dr.Close();
                    myconnection.Close();
                }
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

        public void VoucherAutoNumSO()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                if (new Clsexist().RecordExists(ref myconnection, "SELECT Top 1 DocNum FROM tblMain6 WHERE (ISNUMERIC(DocNum) = 1)"))
                {
                    mycommand = new SqlCommand("SELECT Top 1 DocNum FROM tblMain6 WHERE (ISNUMERIC(DocNum) = 1)  ORDER BY DocNum DESC", myconnection);
                    mycommand.CommandTimeout = 600;
                    dr = mycommand.ExecuteReader();
                    while (dr.Read())
                    {
                        string no1 = null;
                        int no2;
                        no1 = dr["DocNum"].ToString();
                        no2 = (int.Parse(no1)) + 1;
                        plsnumber = Convert.ToString(no2).PadLeft(7, '0');
                    }
                }
                else
                {
                    plsnumber = "0000001";
                }
                if (plsnumber == "0000001")
                {
                    myconnection.Close();
                }
                else
                {
                    dr.Close();
                    myconnection.Close();
                }
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


        public void VoucherAutoNumAI()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                if (new Clsexist().RecordExists(ref myconnection, "SELECT Top 1 DocNum FROM tblMain4 WHERE (ISNUMERIC(DocNum) = 1)"))
                {
                    mycommand = new SqlCommand("SELECT Top 1 DocNum FROM tblMain4 WHERE (ISNUMERIC(DocNum) = 1)  ORDER BY DocNum DESC", myconnection);
                    mycommand.CommandTimeout = 600;
                    dr = mycommand.ExecuteReader();
                    while (dr.Read())
                    {
                        string no1 = null;
                        int no2;
                        no1 = dr["DocNum"].ToString();
                        no2 = (int.Parse(no1)) + 1;
                        plsnumber = Convert.ToString(no2).PadLeft(7, '0');
                    }
                }
                else
                {
                    plsnumber = "0000001";
                }
                if (plsnumber == "0000001")
                {
                    myconnection.Close();
                }
                else
                {
                    dr.Close();
                    myconnection.Close();
                }
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

        public void BranchAutoNum()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                if (new Clsexist().RecordExists(ref myconnection, "SELECT BranchCode FROM tblBranch"))
                {
                    mycommand = new SqlCommand("SELECT Top 1 BranchCode FROM tblBranch ORDER BY BranchCode DESC", myconnection);
                    mycommand.CommandTimeout = 600;
                    dr = mycommand.ExecuteReader();
                    while (dr.Read())
                    {
                        string no1 = null;
                        int no2;
                        no1 = dr["BranchCode"].ToString();
                        no2 = (int.Parse(no1)) + 1;
                        plsnumber = Convert.ToString(no2).PadLeft(2, '0');
                    }
                }
                else
                {
                    plsnumber = "01";
                }
                if (plsnumber == "01")
                {
                    myconnection.Close();
                }
                else
                {
                    dr.Close();
                    myconnection.Close();
                }
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


        public void Dept1AutoNum()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                if (new Clsexist().RecordExists(ref myconnection, "SELECT D1Code FROM tblDept1"))
                {
                    mycommand = new SqlCommand("SELECT Top 1 D1Code FROM tblDept1 ORDER BY D1Code DESC", myconnection);
                    mycommand.CommandTimeout = 600;
                    dr = mycommand.ExecuteReader();
                    while (dr.Read())
                    {
                        string no1 = null;
                        int no2;
                        no1 = dr["D1Code"].ToString();
                        no2 = (int.Parse(no1)) + 1;
                        plsnumber = Convert.ToString(no2).PadLeft(4, '0');
                    }
                }
                else
                {
                    plsnumber = "0001";
                }
                if (plsnumber == "0001")
                {
                    myconnection.Close();
                }
                else
                {
                    dr.Close();
                    myconnection.Close();
                }
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

        public void Dept2AutoNum()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                if (new Clsexist().RecordExists(ref myconnection, "SELECT D2Code FROM tblDept2"))
                {
                    mycommand = new SqlCommand("SELECT Top 1 D2Code FROM tblDept2 ORDER BY D2Code DESC", myconnection);
                    mycommand.CommandTimeout = 600;
                    dr = mycommand.ExecuteReader();
                    while (dr.Read())
                    {
                        string no1 = null;
                        int no2;
                        no1 = dr["D2Code"].ToString();
                        no2 = (int.Parse(no1)) + 1;
                        plsnumber = Convert.ToString(no2).PadLeft(4, '0');
                    }
                }
                else
                {
                    plsnumber = "0001";
                }
                if (plsnumber == "0001")
                {
                    myconnection.Close();
                }
                else
                {
                    dr.Close();
                    myconnection.Close();
                }
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

        public void AgentAutoNum()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                if (new Clsexist().RecordExists(ref myconnection, "SELECT AgentCode FROM tblAgent"))
                {
                    mycommand = new SqlCommand("SELECT Top 1 AgentCode FROM tblAgent ORDER BY AgentCode DESC", myconnection);
                    mycommand.CommandTimeout = 600;
                    dr = mycommand.ExecuteReader();
                    while (dr.Read())
                    {
                        string no1 = null;
                        int no2;
                        no1 = dr["AgentCode"].ToString();
                        no2 = (int.Parse(no1)) + 1;
                        plsnumber = Convert.ToString(no2).PadLeft(3, '0');
                    }
                }
                else
                {
                    plsnumber = "001";
                }
                if (plsnumber == "001")
                {
                    myconnection.Close();
                }
                else
                {
                    dr.Close();
                    myconnection.Close();
                }
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


        public void ProductAdd()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                if (new Clsexist().RecordExists(ref myconnection, "SELECT ProductCode FROM tblProducts  ORDER BY ProductCode DESC"))
                {

                    mycommand = new SqlCommand("SELECT Top 1 ProductCode FROM tblProducts  ORDER BY ProductCode DESC", myconnection);
                    mycommand.CommandTimeout = 600;
                    dr = mycommand.ExecuteReader();
                    while (dr.Read())
                    {
                        string no1;
                        int no2;
                        no1 = dr[0].ToString();
                        no2 = (int.Parse(no1)) + 1;
                        plsnumber = Convert.ToString(no2).PadLeft(5, '0');
                    }
                }
                else
                {
                    plsnumber = "00001";
                }
                if (plsnumber == "00001")
                {
                    myconnection.Close();
                }
                else
                {
                    dr.Close();
                    myconnection.Close();
                }
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

        public void VoucherLatestNum(string argvoucher)
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL(); myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT Top 1 DocNum FROM tblMain1 WHERE  Voucher = '" + argvoucher + "' AND Void=0 AND (ISNUMERIC(DocNum) = 1) ORDER BY DocNum DESC", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();
                while (dr.Read())
                {
                    plsnumber = dr["DocNum"].ToString();
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

        public void VoucherManifestLatest()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL(); myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT Top 1 MNum FROM tblManifest WHERE (ISNUMERIC(MNum) = 1) ORDER BY MNum DESC", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();
                while (dr.Read())
                {
                    plsnumber = dr["MNum"].ToString();
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

        public void VoucherDailySalesLatest()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL(); myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT Top 1 DocNum FROM tblDailySalesCollection WHERE (ISNUMERIC(DocNum) = 1) ORDER BY DocNum DESC", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();
                while (dr.Read())
                {
                    plsnumber = dr["DocNum"].ToString();
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

        public void VoucherLatestNumAI()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL(); 
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                string CheckNoTransact = string.Format("SELECT Count(*) FROM tblManifest");
                SqlCommand com = new SqlCommand(CheckNoTransact, myconnection);
                int CountData = int.Parse(com.ExecuteScalar().ToString());

                mycommand = new SqlCommand("SELECT Top 1 DocNum FROM tblMain4 WHERE(ISNUMERIC(DocNum) = 1) ORDER BY DocNum DESC", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();
                while (dr.Read())
                {
                    plsnumber = dr["DocNum"].ToString();
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

        public void VoucherManifest()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL(); myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();

                string CheckNoTransact = string.Format("SELECT Count(*) FROM tblManifest");
                SqlCommand com = new SqlCommand(CheckNoTransact, myconnection);
                int CountData = int.Parse(com.ExecuteScalar().ToString());

                if (CountData > 0)
                {
                    mycommand = new SqlCommand("SELECT Top 1 MNum FROM tblManifest ORDER BY MNum DESC", myconnection);
                    dr = mycommand.ExecuteReader();
                    dr.Read();
                    string no1 = null;
                    int no2;
                    no1 = dr["MNum"].ToString();
                    no2 = (int.Parse(no1)) + 1;
                    plsnumber = Convert.ToString(no2).PadLeft(7, '0');
                }
                else
                {
                    plsnumber = "0000001";
                }

                //dr.Close();
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

        public void VoucherAutoNumPLNumber(string strCNCode)
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL(); myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();

                string CheckNoTransact = string.Format("SELECT Count(PLNum) FROM tblPLNumber");
                SqlCommand com = new SqlCommand(CheckNoTransact, myconnection);
                int CountData = int.Parse(com.ExecuteScalar().ToString());

                if (CountData > 0)
                {
                    mycommand = new SqlCommand("SELECT Top 1 DocNum FROM tblPLNumber ORDER BY DocNum DESC", myconnection);
                    dr = mycommand.ExecuteReader();
                    dr.Read();
                    string no1 = null;
                    int no2;
                    no1 = dr["DocNum"].ToString();
                    no2 = (int.Parse(no1)) + 1;
                    plsnumber = Convert.ToString(no2).PadLeft(7, '0');
                    dr.Close();
                }
                else
                {
                    plsnumber = "0000001";
                }
                myconnection.Close();
                //return pristrNumber;
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

        public void VoucherAutoNumDSCRNumber(string strCNCode)
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL(); myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();

                string CheckNoTransact = string.Format("SELECT Count(DocNum) FROM tblDailySalesCollection");
                SqlCommand com = new SqlCommand(CheckNoTransact, myconnection);
                int CountData = int.Parse(com.ExecuteScalar().ToString());

                if (CountData > 0)
                {
                    mycommand = new SqlCommand("SELECT Top 1 DocNum FROM tblDailySalesCollection ORDER BY DocNum DESC", myconnection);
                    dr = mycommand.ExecuteReader();
                    dr.Read();
                    string no1 = null;
                    int no2;
                    no1 = dr["DocNum"].ToString();
                    no2 = (int.Parse(no1)) + 1;
                    plsnumber = Convert.ToString(no2).PadLeft(7, '0');
                    dr.Close();
                }
                else
                {
                    plsnumber = "0000001";
                }
                myconnection.Close();
                //return pristrNumber;
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

        public void LaterPLNumber(string CNCode)
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL(); myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT Top 1 DocNum FROM ViewPickListNumber WHERE  CNCode = '" + CNCode + "' AND (ISNUMERIC(DocNum) = 1) ORDER BY DocNum DESC", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();
                while (dr.Read())
                {
                    plsnumber = dr["DocNum"].ToString();
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

        public void LaterDSCRNumber(string CNCode)
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL(); myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT Top 1 DSCRNum FROM ViewDSCRNumber WHERE  CNCode = '" + CNCode + "' ORDER BY DocNum DESC", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();
                while (dr.Read())
                {
                    plsnumber = dr["DocNum"].ToString();
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
    }
}
