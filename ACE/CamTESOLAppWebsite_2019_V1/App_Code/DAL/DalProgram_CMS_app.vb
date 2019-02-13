Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Public Class DalProgram_CMS_app
    Function UpdateProgram(clProgram As clProgram_CMS) As Boolean
        Try
            Dim cn As New SqlConnection
            Dim cmd As New SqlCommand
            cn.ConnectionString = DalConnection_app.EDBConnectionString
            cmd.CommandText = "Update tblCourse_CMS set Name=@A1, Image= @A2, " & _
                                  " Visible=@A5 " & _
                                  " where ProgramID=@A7"
            cmd.Connection = cn

            cmd.Parameters.Add("@A1", SqlDbType.NVarChar).Value = clProgram.Title
            cmd.Parameters.Add("@A2", SqlDbType.NVarChar).Value = clProgram.Image
            cmd.Parameters.Add("@A5", SqlDbType.Bit).Value = clProgram.Visible

            cmd.Parameters.Add("@A7", SqlDbType.Int).Value = clProgram.ProgramID

            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            'MsgBox(ex.Message)
            Return True
        End Try

        Return False
    End Function

    Function AddProgram(clProgram As clProgram_CMS, ByRef NewProgramID As Integer) As Boolean
        Try
            Dim cn As New SqlConnection
            Dim cmd As New SqlCommand
            cn.ConnectionString = DalConnection_app.EDBConnectionString
            cmd.CommandText = "Insert into tblCourse_CMS (Name,Image,Visible, Deleted)" & _
                " Values(@A1, @A2, @A3, @A4)"


            cmd.Connection = cn

            cmd.Parameters.Add("@A1", SqlDbType.NVarChar).Value = clProgram.Title
            cmd.Parameters.Add("@A2", SqlDbType.NVarChar).Value = clProgram.Image
            cmd.Parameters.Add("@A3", SqlDbType.Bit).Value = clProgram.Visible
            cmd.Parameters.Add("@A4", SqlDbType.Bit).Value = 0




            cn.Open()
            cmd.ExecuteNonQuery()

            cmd.CommandText = "SELECT @@IDENTITY"
            Dim obj = cmd.ExecuteScalar

            If Not IsNothing(obj) And Not IsDBNull(obj) Then
                NewProgramID = CInt(obj.ToString)
            End If

            cn.Close()
        Catch ex As Exception
            'MsgBox(ex.Message)
            Return True
        End Try

        Return False
    End Function


End Class
