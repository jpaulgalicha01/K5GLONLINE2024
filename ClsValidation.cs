using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace K5GLONLINE
{
    public class ClsValidation
    {
        SqlConnection myconnection;
        SqlDataReader dr;
        SqlCommand mycommand;
        public string plsoutdate;
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection();
        public string CheckNoTransact;
        public int CountData;
        public bool isNumeric(string val)
        {
            if (isInt(val) || isDouble(val))
                return true;
            else
                return false;
        }

        public bool isInt(string val)
        {
            int num;
            if (int.TryParse(val, out num))
                return false;
            else
                return true;
        }

        public bool isDouble(string val)
        {
            double num;
            if (double.TryParse(val, out num))
                return false;
            else
                return true;
        }
        
        public bool emptytxt(string val)
        {
            if (String.IsNullOrEmpty(val))
                return true;
            else
                return false;
        }

        public bool errordate(string val)
        {
            DateTime num;
            if (val == "  /  /")
                return false;
            if (Convert.ToInt16(val.Length) < 10)
                return true;
            else if (!DateTime.TryParse(val, out num))
                return true;
            else
                return false;
        }

        public void securedatesales(DateTime clsvartdate)
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                {
                        mycommand = new SqlCommand("Select BeginDate, EndDate  FROM tblSecurityDateSales", myconnection);
                        mycommand.CommandTimeout = 600;    
                        dr = mycommand.ExecuteReader();
                        while (dr.Read())
                        {
                            string varstrbd = dr["BeginDate"].ToString();
                            string varstred = dr["EndDate"].ToString();
                            DateTime bd = DateTime.Parse(varstrbd);
                            DateTime ed = DateTime.Parse(varstred);
                            if (clsvartdate < bd || clsvartdate > ed)
                            {
                                plsoutdate = "Yes";
                            }
                            else
                            {
                                plsoutdate = "No";
                            }
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


        public void securedatepoultry(DateTime clsvartdate)
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                {
                        mycommand = new SqlCommand("Select BeginDate, EndDate  FROM tblSecurityDatePoultry", myconnection);
                        mycommand.CommandTimeout = 600;    
                        dr = mycommand.ExecuteReader();
                        while (dr.Read())
                        {
                            string varstrbd = dr["BeginDate"].ToString();
                            string varstred = dr["EndDate"].ToString();
                            DateTime bd = DateTime.Parse(varstrbd);
                            DateTime ed = DateTime.Parse(varstred);
                            if (clsvartdate < bd || clsvartdate > ed)
                            {
                                plsoutdate = "Yes";
                            }
                            else
                            {
                                plsoutdate = "No";
                            }
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


        public void securedateAccounting(DateTime clsvartdate)
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                {
                    mycommand = new SqlCommand("Select Date, EDate  FROM [tbl closing date]", myconnection);
                    mycommand.CommandTimeout = 600;
                    dr = mycommand.ExecuteReader();
                    while (dr.Read())
                    {
                        string varstrbd = dr["Date"].ToString();
                        string varstred = dr["EDate"].ToString();
                        DateTime bd = DateTime.Parse(varstrbd);
                        DateTime ed = DateTime.Parse(varstred);
                        if (clsvartdate < bd || clsvartdate > ed)
                        {
                            plsoutdate = "Yes";
                        }
                        else
                        {
                            plsoutdate = "No";
                        }
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

        public bool ValPhoneNo(string val)
        {
            int strcount = int.Parse(val.Length.ToString());
            if (strcount != 11)
            {
                return true;
            }
            else
            {
                string strd1 = val.Substring(0, 1);
                string strd2 = val.Substring(1, 1);
                string strd3 = val.Substring(2, 1);
                string strd4 = val.Substring(3, 1);
                string strd5 = val.Substring(4, 1);
                string strd6 = val.Substring(5, 1);
                string strd7 = val.Substring(6, 1);
                string strd8 = val.Substring(7, 1);
                string strd9 = val.Substring(8, 1);
                string strd10 = val.Substring(9, 1);
                string strd11 = val.Substring(10, 1);

                if ((new ClsValidation().isInt(strd1) == true) || (new ClsValidation().isInt(strd2) == true)
                    || (new ClsValidation().isInt(strd3) == true) || (new ClsValidation().isInt(strd4) == true)
                    || (new ClsValidation().isInt(strd5) == true) || (new ClsValidation().isInt(strd6) == true)
                    || (new ClsValidation().isInt(strd7) == true) || (new ClsValidation().isInt(strd8) == true)
                    || (new ClsValidation().isInt(strd9) == true) || (new ClsValidation().isInt(strd10) == true)
                    || (new ClsValidation().isInt(strd11) == true))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool DataExist1(string strTableName, string strFieldName, string strCNCode, string strValueFieldName, string strValueCNCode)
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            CheckNoTransact = string.Format("SELECT Count(*) FROM {0} WHERE {1}='" + strValueFieldName + "' AND {2}='" + strValueCNCode + "'", strTableName, strFieldName, strCNCode);
            SqlCommand com = new SqlCommand(CheckNoTransact, myconnection);
            com.CommandTimeout = 900;
            CountData = int.Parse(com.ExecuteScalar().ToString());
            myconnection.Close();
            if (CountData > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DataExist2(string strTableName, string strFieldName, string strValueFieldName)
        {
            ClsGetConnection1.ClsGetConMSSQL();
            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            myconnection.Open();
            CheckNoTransact = string.Format("SELECT Count(*) FROM {0} WHERE {1}='" + strValueFieldName + "'", strTableName, strFieldName);
            SqlCommand com = new SqlCommand(CheckNoTransact, myconnection);
            com.CommandTimeout = 900;
            CountData = int.Parse(com.ExecuteScalar().ToString());
            myconnection.Close();
            if (CountData > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //public bool DataExist3(string strValueFieldName)
        //{
        //    ClsGetConnection1.ClsGetConMSSQL();
        //    myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
        //    myconnection.Open();
        //    CheckNoTransact = string.Format("SELECT Count(*) FROM tblMain1 WHERE Reference='" + strValueFieldName + "'");
        //    SqlCommand com = new SqlCommand(CheckNoTransact, myconnection);
        //    CountData = int.Parse(com.ExecuteScalar().ToString());
        //    myconnection.Close();
        //    if (CountData > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
