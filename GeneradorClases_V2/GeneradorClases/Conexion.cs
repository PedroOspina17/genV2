using System;
using System.Collections.Generic;
using System.Text;

namespace GeneradorClases
{
    public class Conexion
    {
        public Conexion()
        {
            this.sConnectionString = "";
        }

        public Conexion(string sConnectionString)
        {
            this.sConnectionString = sConnectionString;
        }

        private string sConnectionString;
        public string ConnectionString
        {
            get { return this.sConnectionString; }
            set { this.sConnectionString = value; }
        }
    }
}
