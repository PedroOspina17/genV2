USE <DataBase>
GO

CREATE PROCEDURE sp<TableName>(
	<Fields>@<FieldName> <FieldDbType><FieldPrecision><FieldScale> = NULL,
	</Fields>
	,@sOperacion VARCHAR(5) = NULL
)AS
BEGIN
	IF 	@sOperacion = 'I' BEGIN -- CREAR
		INSERT INTO <RealTableName>
			  (<Fields><FieldName>,
			   </Fields>)
		VALUES (<Fields>@<FieldName>,
			   </Fields>)
		SELECT @@IDENTITY ID
	END ELSE IF	@sOperacion = 'U' BEGIN -- ACTUALIZAR
		UPDATE <RealTableName> SET
			   <Fields><FieldName> = @<FieldName>,
			   </Fields>
		WHERE  <PrimaryKeys> <PrimaryKeyFieldName> = @<PrimaryKeyFieldName> AND
		</PrimaryKeys>
	END ELSE IF	@sOperacion = 'SPK' BEGIN -- CONSULTAR POR PRIMARY KEY
		SELECT <Fields><FieldName>,
		</Fields>
		FROM <RealTableName>
		WHERE <PrimaryKeys> <PrimaryKeyFieldName> = @<PrimaryKeyFieldName> AND
		</PrimaryKeys>
	END ELSE IF	@sOperacion = 'L' BEGIN -- LISTAR.
		SELECT <Fields><FieldName>,
		</Fields>
		FROM <RealTableName>
	END ELSE IF	@sOperacion = 'B' BEGIN -- Borrar
		DELETE FROM <RealTableName> 
		WHERE <PrimaryKeys> <PrimaryKeyFieldName> = @<PrimaryKeyFieldName> AND
		</PrimaryKeys>
	END 
END