Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class DalProgramMonitor

    Function updateCheckedTime(isVisible As Integer, id As Integer) As Boolean
        Try
            Dim con As New SqlConnection(DalConnection.EDBConnectionString)
            Dim com As New SqlCommand
            com.Connection = con
            com.CommandText = "update tblCamTESOLConferenceProgram_Session set isVisible=@isVisible where Sessionid=@id"
            com.Parameters.AddWithValue("@isVisible", SqlDbType.Bit).Value = isVisible
            com.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id

            con.Open()
            com.ExecuteNonQuery()
            con.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function updateCancelledProgram(isCancel As Integer, id As Integer) As Boolean
        Try
            Dim con As New SqlConnection(DalConnection.EDBConnectionString)
            Dim com As New SqlCommand
            com.Connection = con
            com.CommandText = "update tblCamTESOLConferenceProgram_AbstractDetail set isCancel=@isCancelled where PresentationID=@id"
            com.Parameters.AddWithValue("@isCancelled", SqlDbType.Bit).Value = isCancel
            com.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id

            con.Open()
            com.ExecuteNonQuery()
            con.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
