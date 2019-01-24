Namespace Comfama.Objetos
    Public Class Objetos
        Dim _reg_id As Integer
        Public Property Reg_id() As Integer
            Get
                Return _reg_id
            End Get
            Set(ByVal value As Integer)
                _reg_id = value
            End Set
        End Property
    End Class
End Namespace