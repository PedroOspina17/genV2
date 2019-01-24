Imports System
Imports System.Collections.Generic
Imports System.Text
Imports Comfama.Objetos
Imports System.Data
Imports System.Data.SqlClient

Namespace Comfama.Datos
    Public Class Datos
        Public Function Crear(ByVal oObjetos As Objetos.Objetos) As Integer
            Dim command As New SqlCommand()
            Dim con As SqlConnection '= ConexionBd.obtenerConexion()
            Dim nId As Integer = 0
            Try

                con.Open()
                command.Connection = con
                command.CommandType = CommandType.StoredProcedure
                command.CommandText = "spRegistroUsuarios"
                command.Parameters.Add("sOperacion", SqlDbType.VarChar, 5).Value = "I"

                'command.Parameters.Add("reg_id", SqlDbType.Int).Value = oObjetos.Reg_id
                command.Parameters.Add("reg_tid_id", SqlDbType.Int, 22).Value = oObjetos.Reg_id


                Dim id As Object = command.ExecuteScalar()
                If id <> Nothing Then
                    nId = Convert.ToInt32(id)
                End If

            Catch ex As Exception
                Throw ex
            Finally
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
            End Try

            Return nId
        End Function

        Public Sub Actualizar(ByVal oObjetos As Objetos.Objetos)
            Dim command As New SqlCommand()
            Dim con As SqlConnection '= ConexionBd.obtenerConexion()
            Dim nId As Integer = 0
            Try
                con.Open()
                command.Connection = con
                command.CommandType = CommandType.StoredProcedure
                command.CommandText = "spRegistroUsuarios"
                command.Parameters.Add("sOperacion", SqlDbType.VarChar, 5).Value = "U"
                command.Parameters.Add("reg_tid_id", SqlDbType.Int, 22).Value = oObjetos.Reg_id
                command.ExecuteNonQuery()
            Catch ex As Exception
                Throw ex
            Finally
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
            End Try

        End Sub

        Public Function Consultar(ByVal id As Integer) As DataTable
            Dim command As New SqlCommand()
            Dim con As SqlConnection '= ConexionBd.obtenerConexion()
            Dim da As New SqlDataAdapter()
            Dim dt As New DataTable()
            Try
                con.Open()
                command.Connection = con
                command.CommandType = CommandType.StoredProcedure
                command.CommandText = "spRegistroUsuarios"
                command.Parameters.Add("sOperacion", SqlDbType.VarChar, 5).Value = "S"
                command.Parameters.Add("reg_id", SqlDbType.Int).Value = id
                command.ExecuteNonQuery()
                da.SelectCommand = command
                da.Fill(dt)
            Catch ex As Exception
                Throw ex
            Finally
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
            End Try
            Return dt
        End Function

        Public Function Listar() As DataTable
            Dim command As New SqlCommand()
            Dim con As SqlConnection '= ConexionBd.obtenerConexion()
            Dim da As New SqlDataAdapter()
            Dim dt As New DataTable()
            Try
                con.Open()
                command.Connection = con
                command.CommandType = CommandType.StoredProcedure
                command.CommandText = "spRegistroUsuarios"
                command.Parameters.Add("sOperacion", SqlDbType.VarChar, 5).Value = "L"
                command.ExecuteNonQuery()
                da.SelectCommand = command
                da.Fill(dt)
            Catch ex As Exception
                Throw ex
            Finally
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
            End Try
            Return dt
        End Function

        Public Sub Retirar(ByVal id As Integer)
            Dim command As New SqlCommand()
            Dim con As SqlConnection '= ConexionBd.obtenerConexion()
            Dim nId As Integer = 0
            Try
                con.Open()
                command.Connection = con
                command.CommandType = CommandType.StoredProcedure
                command.CommandText = "spRegistroUsuarios"
                command.Parameters.Add("sOperacion", SqlDbType.VarChar, 5).Value = "D"
                command.Parameters.Add("reg_tid_id", SqlDbType.Int, 22).Value = id
                command.ExecuteNonQuery()
            Catch ex As Exception
                Throw ex
            Finally
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
            End Try
        End Sub
    End Class
End Namespace
