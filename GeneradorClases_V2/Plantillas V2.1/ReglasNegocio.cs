using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Utils;
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

        public Objetos.<TableName> ConsultarPorPK(<PrimaryKeys> <FieldType> <FieldName>,
    </PrimaryKeys> )
        {
            return Generico.CrearDTO<Objetos.<TableName>>(d<TableName>.ConsultarPorPK(<PrimaryKeys> <FieldName>,
    </PrimaryKeys> )); 
        }

        public List<Objetos.<TableName>> Listar()
        {
            return Generico.CrearDTO<Objetos.<TableName>>(d<TableName>.Listar());
        }

        public void Retirar(<PrimaryKeys> <FieldType> <FieldName>,
    </PrimaryKeys> )
        {
            d<TableName>.Retirar(<PrimaryKeys> <FieldName>,
    </PrimaryKeys> ); 
        }
		
    }
}
