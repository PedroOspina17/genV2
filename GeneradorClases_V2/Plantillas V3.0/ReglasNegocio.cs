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
            
            Objetos.<TableName> o<TableName> = null;
            DataTable dt = d<TableName>.ConsultarPorPK(<PrimaryKeys> <FieldName>,
    </PrimaryKeys> );
            if (dt != null && dt.Rows.Count > 0)
            {
                o<TableName> = CrearDTO(dt.Rows[0]);
                CrearReferencias(ref o<TableName>);
            }
            return o<TableName>;

        }

        public List<Objetos.<TableName>> ConsultarVarios(String Filtro)
        {

            List<Objetos.<TableName>> l = CrearDTO(d<TableName>.ConsultarVarios(Filtro)); 
			CrearReferencias(ref l);
            return l;

        }

        public List<Objetos.<TableName>> Listar()
        {
			List<Objetos.<TableName>> l = Generico.CrearDTO<Objetos.<TableName>>(d<TableName>.Listar());
			CrearReferencias(ref l);
            return l;
        }

        public void Retirar(<PrimaryKeys> <FieldType> <FieldName>,
    </PrimaryKeys> )
        {
            d<TableName>.Retirar(<PrimaryKeys> <FieldName>,
    </PrimaryKeys> ); 
        }
		
		
		public void CrearReferencias(ref List<Objetos.<TableName>> list)
		{
			<ForeignKeys>
			foreach(Objetos.<TableName> o in list)
			{
				CrearReferencias(ref o);
			}			
			</ForeignKeys>
		}
		public void CrearReferencias(ref Objetos.<TableName> o)
		{
			<ForeignKeys>
			
			if(o.<ParentColumn> != 0)
			{
				o.<ReferencedTable> = new ReglasNegocio.<ReferencedTable>().ConsultarPorPK(<ParentColumn>);
			}
			else
			{
				throw new Exception("debe asignarle primero un valor a la entidad para poder consultar las referencias");
			}
			</ForeignKeys>
		}


        public Objetos.<TableName> CrearDTO(DataRow dr)        
        {
            Objetos.<TableName> o<TableName> = null;
            if (dr != null)
            {
                o<TableName> = new Objetos.DiasFestivos();
                <Fields>o<TableName>.<FieldName> = Convert.To<FieldType>(dr["<FieldName>"]);
                </Fields>               
            }
            return o<TableName>;
        }

        public List<Objetos.<TableName>> CrearDTO(DataTable dt)
        {
            List<Objetos.<TableName>> l<TableName> = new List<Objetos.<TableName>>();
            foreach (DataRow dr in dt.Rows)
            {
                l<TableName>.Add(CrearDTO(dr));
            }
            return l<TableName>;
        }


    }
}
