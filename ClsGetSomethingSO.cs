using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace K5GLONLINE
{
    class ClsGetSomethingSO
    {
        public string plsVoidIC;

        SqlConnection myconnection;
        SqlDataReader dr;
        SqlCommand mycommand;
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection(); 

       
        public void ClsDeleteErrorTransaction()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();

                SqlCommand mycommand = new SqlCommand("usp_DelVoidSO", myconnection);
                mycommand.CommandType = CommandType.StoredProcedure;

                mycommand.Parameters.Add("@ParamUserName", SqlDbType.VarChar).Value = Form1.glbluc.Text;
                mycommand.CommandTimeout = 600;
                int n1 = mycommand.ExecuteNonQuery();
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

        public void ClsFinalize(string varstrDocNum)
                    
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();

                string sqlstatement;
                sqlstatement = "UPDATE ViewOnlineEditNumberSO SET DocNum=@_DocNum, Void=@_Void WHERE DocNum='" + Form1.glbluc.Text + "'";
                //sqlstatement = "UPDATE tblMain1 SET IC=@_IC, DocNum=@_DocNum, Void=@_Void WHERE Voucher ='" + varstrVoucher + "' AND DocNum='" + Form1.glbluc.Text + "'";
                mycommand = new SqlCommand(sqlstatement, myconnection);
                mycommand.Parameters.Add("_DocNum", SqlDbType.VarChar).Value = varstrDocNum;
                mycommand.Parameters.Add("_Void", SqlDbType.Bit).Value = 0;
                mycommand.CommandTimeout = 600;
                int n1 = mycommand.ExecuteNonQuery();
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

        public void ClsGetVoidRef()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("Select DocNum FROM tblMain6 WHERE DocNum = '"+Form1.glbluc.Text + "'", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();
                while (dr.Read())
                {
                    plsVoidIC = dr["DocNum"].ToString();
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
