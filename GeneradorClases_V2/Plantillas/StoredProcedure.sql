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
		WHERE <PrimaryKeyField> = @<PrimaryKeyField>
	END ELSE IF	@sOperacion = 'S' BEGIN -- CONSULTAR
		SELECT <Fields><FieldName>,
		</Fields>
		FROM <RealTableName>
		WHERE <PrimaryKeyField> = @<PrimaryKeyField>
	END ELSE IF	@sOperacion = 'L' BEGIN -- LISTAR.
		SELECT <Fields><FieldName>,</Fields>
		FROM <RealTableName>
	END /*ELSE IF	@sOperacion = 'D' BEGIN -- RETIRAR
		UPDATE <RealTableName> SET reg_estado = 0 -- INACTIVAR
		WHERE <PrimaryKeyField> = @<PrimaryKeyField>
	END */
END