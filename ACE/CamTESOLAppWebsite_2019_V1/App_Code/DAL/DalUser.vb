Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class DalUser

    Shared Function getUserFromLogin(username As String, password As String) As ClUser

        Try
            Dim cn As New SqlConnection
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim user As ClUser = Nothing

            cn.ConnectionString = DalConnection_app.EDBConnectionString
            cmd.CommandText = "select * from tblUser where lower(UserName)=lower(@username) and Password=@password"
            cmd.Connection = cn

            cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = username
            cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = password

            cn.Open()
            reader = cmd.ExecuteReader

            If reader.Read Then
                user = New ClUser(reader.GetValue(reader.GetOrdinal("AutoID")), reader.GetValue(reader.GetOrdinal("UserName")))
            End If
            cn.Close()
            Return user

        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Shared Function getUserByID(id As Integer) As ClUser
        Try
            Dim cn As New SqlConnection
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim user As ClUser = Nothing

            cn.ConnectionString = DalConnection_app.EDBConnectionString
            cmd.CommandText = "select * from tblUser where AutoID=@id"
            cmd.Connection = cn

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id

            cn.Open()
            reader = cmd.ExecuteReader

            If reader.Read Then
                user = New ClUser(reader.GetValue(reader.GetOrdinal("AutoID")), reader.GetValue(reader.GetOrdinal("UserName")))
            End If
            cn.Close()
            Return user

        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Shared Function getUserByEmail(email As String) As User
        Try
            Dim cn As New SqlConnection
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim user As User = Nothing

            Dim sql As String = "select * from tblUserLogin u inner join tblRegisterContact c on c.ContactID=u.ContactID where lower(UserEmail)='" & email.ToLower & "'"

            cmd.Connection = cn
            cmd.CommandText = sql

            'cmd.Parameters.AddWithValue("@A", SqlDbType.Int).Value = email

            cn.ConnectionString = DalConnection_app.EDBConnectionString
            cn.Open()
            reader = cmd.ExecuteReader

            If reader.Read Then
                user = New User(reader.Item("UserID").ToString, reader.Item("FamilyName").ToString, reader.Item("GivenName").ToString, reader.Item("UserEmail").ToString, reader.Item("Password").ToString, reader.Item("StreamCode").ToString)
            End If

            cn.Close()
            Return user
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Class
