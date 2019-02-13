Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class DalBookmark

    Function addBookmark(bookmark As ClsBookmark) As Boolean
        Try
            Dim con As New SqlConnection(DalConnection.EDBConnectionString)
            Dim com As New SqlCommand
            com.Connection = con
            com.CommandText = "insert into tblBookmark(PresentationID, UserID, CreatedDate, IsDeleted) values (@presentationID, @userID, @createdDate, @isDeleted)"

            com.Parameters.AddWithValue("@presentationID", SqlDbType.Int).Value = bookmark.presentationID
            com.Parameters.AddWithValue("@userID", SqlDbType.Int).Value = bookmark.userID
            com.Parameters.AddWithValue("@createdDate", SqlDbType.DateTime).Value = bookmark.createdDate
            com.Parameters.AddWithValue("@isDeleted", SqlDbType.Bit).Value = bookmark.isDeleted

            con.Open()
            com.ExecuteNonQuery()
            con.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function updateBookmark(bookmark As ClsBookmark) As Boolean
        Try
            Dim con As New SqlConnection(DalConnection.EDBConnectionString)
            Dim com As New SqlCommand
            com.Connection = con
            com.CommandText = "update tblBookmark set IsDeleted=@isDeleted where PresentationID=@presentationID and UserID=@userID"

            com.Parameters.AddWithValue("@isDeleted", SqlDbType.Bit).Value = bookmark.isDeleted
            com.Parameters.AddWithValue("@presentationID", SqlDbType.Int).Value = bookmark.presentationID
            com.Parameters.AddWithValue("@userID", SqlDbType.Int).Value = bookmark.userID

            con.Open()
            com.ExecuteNonQuery()
            con.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
