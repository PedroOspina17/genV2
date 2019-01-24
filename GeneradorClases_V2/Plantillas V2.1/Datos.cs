using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace <Namespace>
{
    public class <TableName>
    {
        public <TableName>()
        {
        }

        public int Crear(Objetos.<TableName> o<TableName>)
        {
            SqlCommand command = new SqlCommand();
            int nId = 0;
            try
            {
                command.Connection = dbConectionSQL.Get();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp<TableName>";
                if (command.Connection.State == ConnectionState.Closed)
                    command.Connection.Open();
                command.Parameters.Add("@sOperacion", SqlDbType.VarChar, 5).Value = "I";
                <Fields>command.Parameters.Add("@<FieldName>", SqlDbType.<FieldDbType><FieldPrecision2>).Value = o<TableName>.<FieldName>;
                </Fields>
                
                object id = command.ExecuteScalar();
                if (id != DBNull.Value)
                {
                    nId = Convert.ToInt32(id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (command.Connection.State == ConnectionState.Open)
                {
                    command.Connection.Close();
                }
            }
            return nId;
        }

        public void Actualizar(Objetos.<TableName> o<TableName>)
        {
            SqlCommand command = new SqlCommand();           
            try
            {
                command.Connection = dbConectionSQL.Get();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp<TableName>";
                if (command.Connection.State == ConnectionState.Closed)
                    command.Connection.Open();
                command.Parameters.Add("@sOperacion", SqlDbType.VarChar, 5).Value = "U";
                <Fields>command.Parameters.Add("@<FieldName>", SqlDbType.<FieldDbType><FieldPrecision2>).Value = o<TableName>.<FieldName>;
                </Fields>

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (command.Connection.State == ConnectionState.Open)
                {
                    command.Connection.Close();
                }
            }
        }

        public DataRow ConsultarPorPK(<PrimaryKeys> <FieldType> <FieldName>,
    </PrimaryKeys> )
        {
            SqlCommand command = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                command.Connection = dbConectionSQL.Get();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp<TableName>";
                if (command.Connection.State == ConnectionState.Closed)
                    command.Connection.Open();
                command.Parameters.Add("@sOperacion", SqlDbType.VarChar, 5).Value = "SPK";
                <PrimaryKeys>command.Parameters.Add("@<FieldName>", SqlDbType.<FieldDbType><FieldPrecision2>).Value = <FieldName>;
</PrimaryKeys>
                da.SelectCommand = command;
                da.Fill(dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (command.Connection.State == ConnectionState.Open)
                {
                    command.Connection.Close();
                }
            }			
            return dt.Rows.Count>0 ? dt.Rows[0] : dt.NewRow();
        }

        public DataTable Listar()
        {
            SqlCommand command = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                command.Connection = dbConectionSQL.Get();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp<TableName>";
                if (command.Connection.State == ConnectionState.Closed)
                    command.Connection.Open();
                command.Parameters.Add("@sOperacion", SqlDbType.VarChar, 5).Value = "L";
                da.SelectCommand = command;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (command.Connection.State == ConnectionState.Open)
                {
                    command.Connection.Close();
                }
            }
            return dt;
        }

        public void Retirar(<PrimaryKeys> <FieldType> <FieldName>,
    </PrimaryKeys> )
        {
            SqlCommand command = new SqlCommand();
            try
            {
                command.Connection = dbConectionSQL.Get();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp<TableName>";
                if (command.Connection.State == ConnectionState.Closed)
                    command.Connection.Open();
                command.Parameters.Add("@sOperacion", SqlDbType.VarChar, 5).Value = "D";
                <PrimaryKeys>command.Parameters.Add("@<FieldName>", SqlDbType.<FieldDbType><FieldPrecision2>).Value = <FieldName>;
</PrimaryKeys>
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (command.Connection.State == ConnectionState.Open)
                {
                    command.Connection.Close();
                }
            }
        }
    }
}
