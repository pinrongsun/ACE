Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class DalGroupPhoto_app
    Function UpdateGroupPhoto(clGroupPhoto As ClGroupPhoto_app) As Boolean
        Try
            Dim cn As New SqlConnection
            Dim cmd As New SqlCommand
            cn.ConnectionString = DalConnection_app.EDBConnectionString
            cmd.CommandText = "Update tblGroupPhoto set Name=@A1, CoverImage= @A2, " & _
                                  " Ordering=@A3,Visible=@A4 " & _
                                  " where GroupPhotoID=@A6"
            cmd.Connection = cn

            cmd.Parameters.Add("@A1", SqlDbType.NVarChar).Value = clGroupPhoto.Name
            cmd.Parameters.Add("@A2", SqlDbType.NVarChar).Value = clGroupPhoto.Image
            cmd.Parameters.Add("@A3", SqlDbType.Int).Value = clGroupPhoto.Ordering
            cmd.Parameters.Add("@A4", SqlDbType.Bit).Value = clGroupPhoto.Visible
            cmd.Parameters.Add("@A6", SqlDbType.Int).Value = clGroupPhoto.GroupPhotoID

            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            'MsgBox(ex.Message)
            Return True
        End Try

        Return False
    End Function


    Function AddGroupPhoto(clGroupPhoto As ClGroupPhoto_app, ByRef NewGroupPhotoID As Integer) As Boolean
        Try
            Dim cn As New SqlConnection
            Dim cmd As New SqlCommand
            cn.ConnectionString = DalConnection_app.EDBConnectionString
            cmd.CommandText = "Insert into tblGroupPhoto (Name,CoverImage,Ordering,Visible, Deleted)" & _
                " Values(@A1, @A2, @A3, @A4, @A5)"


            cmd.Connection = cn

            cmd.Parameters.Add("@A1", SqlDbType.NVarChar).Value = clGroupPhoto.Name
            cmd.Parameters.Add("@A2", SqlDbType.NVarChar).Value = clGroupPhoto.Image
            cmd.Parameters.Add("@A3", SqlDbType.Int).Value = clGroupPhoto.Ordering
            cmd.Parameters.Add("@A4", SqlDbType.Bit).Value = clGroupPhoto.Visible
            cmd.Parameters.Add("@A5", SqlDbType.Bit).Value = 0



            cn.Open()
            cmd.ExecuteNonQuery()

            cmd.CommandText = "SELECT @@IDENTITY"
            Dim obj = cmd.ExecuteScalar

            If Not IsNothing(obj) And Not IsDBNull(obj) Then
                NewGroupPhotoID = CInt(obj.ToString)
            End If

            cn.Close()
        Catch ex As Exception
            'MsgBox(ex.Message)
            Return True
        End Try

        Return False
    End Function


End Class
