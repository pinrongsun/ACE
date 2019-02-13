Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class DalTimetable

    Shared Function updateIsCancelled(code As String, isCancelled As Boolean) As Boolean
        Try
            Dim cn As New SqlConnection
            Dim cmd As New SqlCommand

            cn.ConnectionString = DalConnection_app.EDBConnectionString
            cmd.CommandText = "update tblTimetable set IsCancelled=@isCancelled where lower(MainFocusCode)=lower(@code)"
            cmd.Connection = cn

            cmd.Parameters.Add("@isCancelled", SqlDbType.Bit).Value = isCancelled
            cmd.Parameters.Add("@code", SqlDbType.NVarChar).Value = code

            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Return True
        Catch ex As Exception

            Return False
        End Try
    End Function

End Class
