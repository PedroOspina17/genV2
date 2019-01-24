using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Datos
{
    class dbConectionSQL
    {
        private static String CadenaConexion;

        public static SqlConnection Get()
        {
            CadenaConexion = LeerCadenaConexion();
            return new SqlConnection(CadenaConexion);
        }

        private static string LeerCadenaConexion()
        {
            string cadenaCon;
            try
            {
                cadenaCon = System.Configuration.ConfigurationManager.ConnectionStrings["connectionSQL"].ConnectionString;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return cadenaCon;
        }
    }
}



