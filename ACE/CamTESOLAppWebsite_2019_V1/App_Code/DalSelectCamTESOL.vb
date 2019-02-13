Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class DalSelectCamTESOL

    Public Shared Function selectQuery(command As String) As DataTable

        Try
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim con As New SqlConnection(DalConnection.EDBConnectionString)
            Dim com As New SqlCommand
            com.Connection = con
            com.CommandText = command

            con.Open()
            da.SelectCommand = com
            da.Fill(dt)

            con.Close()
            Return dt
        Catch ex As Exception
            Return New DataTable
        End Try
    End Function

End Class
