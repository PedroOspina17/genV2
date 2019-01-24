using System;
using System.Collections.Generic;
using System.Text;

namespace <Namespace>
{
	public class <TableName> : Objetos.IObjetos
    {
		
        <Fields>
        private <FieldType> _<FieldName> = <DefaultValue>;
        </Fields>
			
		// Campos
        <Fields>
        public <FieldType> <FieldName>
        {
            get { return _<FieldName>; }
            set { _<FieldName> = value; }
        }
        </Fields>
			
		//Referencias
		<ForeignKeys>
		private <ReferencedTable> _<ReferencedTable>;
		</ForeignKeys>
		<ForeignKeys>
		public <ReferencedTable> <ReferencedTable>
        {
            get { return _<ReferencedTable>;}			
        }        
        </ForeignKeys>
			
		public void IObjetos.CrearReferencias()
		{
			<ForeignKeys>
			if(<ParentColumn> != 0)
			{
				_<ReferencedTable> = new ReglasNegocio.<ReferencedTable>().ConsultarPorPK(<ParentColumn>);
			}
			else
			{
				throw new Exception("debe asignarle primero un valor a la entidad para poder consultar las referencias");
			}
			</ForeignKeys>
		}

    }
}
