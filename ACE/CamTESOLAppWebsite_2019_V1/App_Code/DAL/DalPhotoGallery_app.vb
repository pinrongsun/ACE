Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Public Class DalPhotoGallery_app


    Function UpdatePhotoGallery(clPhotoGallery As ClPhotoGallery) As Boolean
        Try
            Dim cn As New SqlConnection
            Dim cmd As New SqlCommand
            cn.ConnectionString = DalConnection_app.EDBConnectionString
            cmd.CommandText = "Update tblPhotoGallery set Name=@A1, Description= @A2, " & _
                                  " Image=@A3, Link=@A4 ,Visible=@A5, Ordering=@A6, GroupPhotoID=@A7 " & _
                                  " where PhotoID=@A8"
            cmd.Connection = cn

            cmd.Parameters.Add("@A1", SqlDbType.NVarChar).Value = clPhotoGallery.Name
            cmd.Parameters.Add("@A2", SqlDbType.NVarChar).Value = clPhotoGallery.Description
            cmd.Parameters.Add("@A3", SqlDbType.NVarChar).Value = clPhotoGallery.Image
            cmd.Parameters.Add("@A4", SqlDbType.NVarChar).Value = clPhotoGallery.Link
            cmd.Parameters.Add("@A5", SqlDbType.Bit).Value = clPhotoGallery.Visible
            cmd.Parameters.Add("@A6", SqlDbType.Int).Value = clPhotoGallery.Ordering
            cmd.Parameters.Add("@A7", SqlDbType.Int).Value = clPhotoGallery.GroupPhotoID
            cmd.Parameters.Add("@A8", SqlDbType.Int).Value = clPhotoGallery.PhotoID

            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            'MsgBox(ex.Message)
            Return True
        End Try

        Return False
    End Function


    Function AddPhotoGallery(clPhotoGallery As ClPhotoGallery, ByRef NewPhotoID As Integer) As Boolean
        Try
            Dim cn As New SqlConnection
            Dim cmd As New SqlCommand
            cn.ConnectionString = DalConnection_app.EDBConnectionString
            cmd.CommandText = "Insert into tblPhotoGallery (Name, Description,Image,Link, Visible, Deleted, GroupPhotoID)" & _
                " Values(@A1, @A2, @A3, @A4, @A5, @A6, @A7)"


            cmd.Connection = cn

            cmd.Parameters.Add("@A1", SqlDbType.NVarChar).Value = clPhotoGallery.Name
            cmd.Parameters.Add("@A2", SqlDbType.NVarChar).Value = clPhotoGallery.Description
            cmd.Parameters.Add("@A3", SqlDbType.NVarChar).Value = clPhotoGallery.Image
            cmd.Parameters.Add("@A4", SqlDbType.NVarChar).Value = clPhotoGallery.Link
            cmd.Parameters.Add("@A5", SqlDbType.Bit).Value = clPhotoGallery.Visible
            cmd.Parameters.Add("@A6", SqlDbType.Bit).Value = 0
            cmd.Parameters.Add("@A7", SqlDbType.Int).Value = clPhotoGallery.GroupPhotoID

            cn.Open()
            cmd.ExecuteNonQuery()

            cmd.CommandText = "SELECT @@IDENTITY"
            Dim obj = cmd.ExecuteScalar

            If Not IsNothing(obj) And Not IsDBNull(obj) Then
                NewPhotoID = CInt(obj.ToString)
            End If

            cn.Close()
        Catch ex As Exception
            'MsgBox(ex.Message)
            Return True
        End Try

        Return False
    End Function

End Class
