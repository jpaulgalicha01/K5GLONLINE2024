using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace K5GLONLINE
{
    class ClsPermission
    {
        private SqlConnection myconnection;
        SqlDataReader dr;
        SqlCommand mycommand;
        public string plstxtObject;
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection(); 

        public void ClsObjects(string varObjectName)
        {
          try
            {
                if (Form1.glblgroupcode.Text == "01")
                {
                    plstxtObject = "01";
                }
                else
                {
                    ClsGetConnection1.ClsGetConMSSQL();
                    myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                    myconnection.Open();
                    mycommand = new SqlCommand("SELECT ObjectName FROM tblPermission WHERE GroupCode='" + Form1.glblgroupcode.Text + "' AND ObjectName = '"+varObjectName +"'", myconnection);
                    mycommand.CommandTimeout = 600;
                    dr = mycommand.ExecuteReader();
                    while (dr.Read())
                    {
                        plstxtObject = dr["ObjectName"].ToString();
                    }

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
              //myconnection.Close();
          }

        }

     }
}
