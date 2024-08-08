using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace K5GLONLINE
{
    class ClsCompName
    {
        public string varcn, varaddress;
        SqlConnection myconnection;
        SqlDataReader dr;
        SqlCommand mycommand;
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection(); 

        public void ClsCompNameMain()
        {
            try
            {

                ClsGetConnection1.ClsGetConMSSQL();
                myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("Select Company,Address from tblCompany", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();
                while (dr.Read())
                {
                    varcn = dr["Company"].ToString();
                    varaddress = dr["Address"].ToString();
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
