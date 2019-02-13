Imports Microsoft.VisualBasic

Public Class ClUser

    Private _id As Integer
    Private _username As String
    Private _password As String

    Public Sub New(id As String, username As String)
        _id = id
        _username = username
    End Sub

    Public Property id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property username As String
        Get
            Return _username
        End Get
        Set(value As String)
            _username = value
        End Set
    End Property

    Public Property password As String
        Get
            Return _password
        End Get
        Set(value As String)
            _password = value
        End Set
    End Property
End Class
