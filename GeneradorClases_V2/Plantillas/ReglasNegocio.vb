Imports System
Imports System.Text
Imports System.Data
Imports Comfama.Objetos
Imports Comfama.Datos

Namespace Comfama.ReglasNegocio
    Public Class ReglasNegocio
        Public Function Crear(ByVal oObjetos As Objetos.Objetos) As Integer
            Dim dObjets As New Datos.Datos
            dObjets.Crear(oObjetos)
        End Function

        Public Sub Actualizar(ByVal oObjetos As Objetos.Objetos)
            Dim dObjets As New Datos.Datos
            dObjets.Actualizar(oObjetos)
        End Sub

        Public Function Consultar(ByVal id As Integer) As DataTable
            Dim dObjets As New Datos.Datos
            dObjets.Consultar(id)
        End Function

        Public Function Listar() As DataTable
            Dim dObjets As New Datos.Datos
            dObjets.Listar()
        End Function

        Public Sub Retirar(ByVal id As Integer)
            Dim dObjets As New Datos.Datos
            dObjets.Retirar(id)
        End Sub
    End Class
End Namespace
