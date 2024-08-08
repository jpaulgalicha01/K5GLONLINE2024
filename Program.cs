using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace K5GLONLINE
{
    static class Program
    {
        //public static string mycon;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
          // mycon = "Server = WINSERVER; Database = K5GL_BE; User ID = server2008; Password = Mssqlone1; Trusted_Connection = False;";
          //     mycon = "Server = WINSERVER; Database = K5GL_BE; User ID = server2008; Password = Mssqlone1; Trusted_Connection = True;Connection Timeout=300";
         //    mycon = "Server = 124.105.11.29; Database = K5GL_BE; User ID = server2008; Password = Mssqlone1; Trusted_Connection = False;Connection Timeout=120";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Application.Run(new Form1());
        }
    }
}
