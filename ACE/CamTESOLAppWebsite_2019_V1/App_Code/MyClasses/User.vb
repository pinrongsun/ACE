Imports Microsoft.VisualBasic

Public Class User
    Private _UserID As Integer
    Private _familyName As String
    Private _givenName As String
    Private _userEmail As String
    Private _Password As String
    Private _streamCode As String


    Public Sub New(UserID As Integer, familyName As String, givenName As String, userEmail As String, password As String, streamCode As String)
        _UserID = UserID
        _familyName = familyName
        _givenName = givenName
        _userEmail = userEmail
        _streamCode = streamCode
    End Sub

    Public Property UserID As Integer
        Get
            Return _UserID
        End Get
        Set(value As Integer)
            _UserID = value
        End Set
    End Property

    Public Property familyName As String
        Get
            Return _familyName
        End Get
        Set(value As String)
            _familyName = value
        End Set
    End Property
    Public Property givenName As String
        Get
            Return _givenName
        End Get
        Set(value As String)
            _givenName = value
        End Set
    End Property

    Public Property userEmail As String
        Get
            Return _userEmail
        End Get
        Set(value As String)
            _userEmail = value
        End Set
    End Property

    Public Property Password As String
        Get
            Return _Password
        End Get
        Set(value As String)
            _Password = value
        End Set
    End Property

    Public Property streamCode As String
        Get
            Return _streamCode
        End Get
        Set(value As String)
            _streamCode = value
        End Set
    End Property
End Class
