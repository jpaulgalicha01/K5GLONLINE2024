using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace K5GLONLINE
{
    class ClsGetSomethingOthers
    {
        ClsAutoNumber ClsAutoNumber1 = new ClsAutoNumber();
        public string plsTableDoor, plsVoidIC;
        SqlConnection myconnection;
        SqlDataReader dr;
        SqlCommand mycommand;
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection(); 

        public void ClsGetTDoor(string varstrVoucher)
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("Select TableDoor FROM tblTDoor WHERE Voucher='"+varstrVoucher+"'", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();
                while (dr.Read())
                {
                    plsTableDoor = dr["TableDoor"].ToString();
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

        public void ClsOneTheDoor(string varstrVoucher)
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();

                string sqlstatement;
                sqlstatement = "UPDATE tblTDoor SET TableDoor=@_TableDoor WHERE Voucher ='"+varstrVoucher+"'";
                mycommand = new SqlCommand(sqlstatement, myconnection);
                mycommand.Parameters.Add("_TableDoor", SqlDbType.Int).Value = 1;
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

        public void ClsZeroTheDoor(string varstrVoucher)
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();

                string sqlstatement;
                sqlstatement = "UPDATE tblTDoor SET TableDoor=@_TableDoor WHERE Voucher ='" + varstrVoucher + "'";
                mycommand = new SqlCommand(sqlstatement, myconnection);
                mycommand.Parameters.Add("_TableDoor", SqlDbType.Int).Value = 0;
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

        public void ClsDeleteErrorTransaction1(string varstrVoucher)
        {
            try
            {
                string sqldel1 = "DELETE FROM ViewVoidtblMain3 WHERE IC='" + varstrVoucher + "'+'" + Form1.glbluc.Text + "'";
                string sqldel2 = "DELETE FROM ViewVoidtblMain2 WHERE IC='" + varstrVoucher + "'+'" + Form1.glbluc.Text + "'";
                string sqldel3 = "DELETE FROM ViewVoidtblMain1 WHERE IC='" + varstrVoucher + "'+'" + Form1.glbluc.Text + "'";

                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand(sqldel1, myconnection);
                mycommand.CommandTimeout = 600;
                int nmsg1 = mycommand.ExecuteNonQuery();

                mycommand = new SqlCommand(sqldel2, myconnection);
                mycommand.CommandTimeout = 600;
                int nmsg2 = mycommand.ExecuteNonQuery();

                mycommand = new SqlCommand(sqldel3, myconnection);
                mycommand.CommandTimeout = 600;
                int nmsg3 = mycommand.ExecuteNonQuery();

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
        public void ClsDeleteErrorTransaction(string varstrVoucher)
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();

                SqlCommand mycommand = new SqlCommand("usp_DelVoid", myconnection);
                mycommand.CommandType = CommandType.StoredProcedure;

                mycommand.Parameters.Add("@ParamVoucher", SqlDbType.VarChar).Value = varstrVoucher;
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

        public void ClsFinalize(string varstrVoucher, string varstrDocNum)
                    
        {
            try
            {
                ClsAutoNumber1.VoucherAutoNum(varstrVoucher);

                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();

                string sqlstatement;
                sqlstatement = "UPDATE ViewOnlineEditNumber SET IC=@_IC, DocNum=@_DocNum, Void=@_Void WHERE Voucher ='" + varstrVoucher + "' AND DocNum='" + Form1.glbluc.Text + "'";
                //sqlstatement = "UPDATE tblMain1 SET IC=@_IC, DocNum=@_DocNum, Void=@_Void WHERE Voucher ='" + varstrVoucher + "' AND DocNum='" + Form1.glbluc.Text + "'";
                mycommand = new SqlCommand(sqlstatement, myconnection);
                mycommand.Parameters.Add("_IC", SqlDbType.VarChar).Value = varstrVoucher + ClsAutoNumber1.plsnumber;
                mycommand.Parameters.Add("_DocNum", SqlDbType.VarChar).Value = ClsAutoNumber1.plsnumber;
                mycommand.Parameters.Add("_Void", SqlDbType.Bit).Value = 0;
                mycommand.CommandTimeout = 900;
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
        
        public void ClsGetVoidRef(string varstrVoucher)
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("Select IC FROM tblMain1 WHERE IC='" + varstrVoucher + "'+'" + Form1.glbluc.Text + "'", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();
                while (dr.Read())
                {
                    plsVoidIC = dr["IC"].ToString();
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
