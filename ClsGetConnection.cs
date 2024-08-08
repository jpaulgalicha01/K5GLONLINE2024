using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace K5GLONLINE
{
    class ClsGetConnection
    {
        //SqlConnection myconnection;
        //public string plsMyCon;

        //public void ClsGetCon()
        //{
        //    //if (myConnection != null && myConnection.State == ConnectionState.Closed)
        //    {
        //        // do something
        //        // ...
        //    }
        //    //plsMyCon = "Server = 124.105.11.29; Database = K5GL_BE; User ID = server2008; Password = Mssqlone1; Trusted_Connection = False;Connection Timeout=300";
            
        //    plsMyCon = "Server = WINSERVER; Database = K5GL_BE; User ID = server2008; Password = Mssqlone1; Trusted_Connection = False;Connection Timeout=120";
        //    myconnection = new SqlConnection(plsMyCon);
        //}

       // SqlConnection myconnectionMSSQL;
        public string plsMyConMSSQL, plsMyConMSSQLMW;

        public void ClsGetConMSSQL()
        {
            //plsMyConMSSQL = "Server = '" + Form1.glblservername.Text + "'; Database = K5GL_BE; User ID = server2008; Password = Mssqlone1; Trusted_Connection = False;;Connection Timeout=180";
            plsMyConMSSQL = "Server = '" + Form1.glblservername.Text + "'; Database = K5GL_BE; User ID = server2008; Password = Mssqlone1; Trusted_Connection = False;";
            //plsMyConMSSQL = "Data Source=DESKTOP-7TUO7EH\\SQLEXPRESS01; Initial Catalog=K5GL_BE; Integrated Security=SSPI; TrustServerCertificate=True;";
            //plsMyConMSSQL = "Server = WINSERVER; Database = MCLCGLV7_BE; User ID = server2008; Password = Mssqlone1; Trusted_Connection = False;";
            //myconnectionMSSQL = new SqlConnection(plsMyConMSSQL);
            //plsMyConMSSQLMW = "Server = skyfi-db-intance-1.cbyctat6u9gj.ap-northeast-2.rds.amazonaws.com,1433; Database = K5GLMW_BE; User ID = skyfiadmin2020; Password = Skyfi123; Trusted_Connection = False;";

        }
    }
   

}
