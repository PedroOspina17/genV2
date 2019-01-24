using System;
using System.Collections.Generic;
using System.Text;

namespace <Namespace>
{
	public class <TableName> 
    {
		
        <Fields>
        private <FieldType>? _<FieldName>;
        </Fields>
			
		// Campos
        <Fields>
        public <FieldType>? <FieldName>
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
			set { _<ReferencedTable> = value;}		
            get { return _<ReferencedTable>;}			
        }        
        </ForeignKeys>
			

    }
}
