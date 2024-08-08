using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace K5GLONLINE
{
    class Clsexist
    {
        public bool RecordExists(ref System.Data.SqlClient.SqlConnection _SqlConnection, string _Sql)
        {
            System.Data.SqlClient.SqlDataReader _SqlDataReader = null;
            try
            {
                // Pass the connection to a command object  

                System.Data.SqlClient.SqlCommand _SqlCommand

                        = new System.Data.SqlClient.SqlCommand(_Sql, _SqlConnection);
                // get query results  
                _SqlDataReader = _SqlCommand.ExecuteReader();
            }

            catch (Exception)
            {
                return false;
            }

            if (_SqlDataReader != null && _SqlDataReader.Read())
            {
                // close Sql reader before exit  

                if (_SqlDataReader != null)
                {
                    _SqlDataReader.Close();

                    _SqlDataReader.Dispose();

                }

                // record found  

                return true;
            }
            else
            {
                // close Sql reader before exit  

                if (_SqlDataReader != null)
                {
                    _SqlDataReader.Close();

                    _SqlDataReader.Dispose();
                }

                // record not found  
                return false;
            }


        }

    }
}
