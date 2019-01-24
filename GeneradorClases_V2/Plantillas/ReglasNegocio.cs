using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace <Namespace>
{
    public class <TableName>
    {
        Datos.<TableName> d<TableName>;

        public <TableName>()
        {
            d<TableName> = new Datos.<TableName>();
        }

        public int Crear(Objetos.<TableName> o<TableName>)
        {
            return d<TableName>.Crear(o<TableName>);
        }

        public void Actualizar(Objetos.<TableName> o<TableName>)
        {
            d<TableName>.Actualizar(o<TableName>);
        }

        public Objetos.<TableName> Consultar(int id)
        {
            return ConvertirDesdeDataTable(d<TableName>.Consultar(id)); 
        }

        public DataTable Listar()
        {
            return d<TableName>.Listar();
        }

        public void Retirar(int id)
        {
            d<TableName>.Retirar(id); 
        }
		
		public Objetos.<TableName> ConvertirDesdeDataTable(DataTable dt<TableName>)
        {
            Objetos.<TableName> o<TableName> = null;
            if (dt<TableName>.Rows.Count > 0)
            {
                o<TableName> = new Objetos.<TableName>();
                System.Reflection.PropertyInfo[] Campos = o<TableName>.GetType().GetProperties();
                for (int i = 0; i < Campos.Length; i++)
                {
					try{
						Campos[i].SetValue(o<TableName>, dt<TableName>.Rows[0][Campos[i].Name], null);
					}catch(Exception ex){}
                }
            }
            return o<TableName>;
        }
    }
}
