Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class DalArticle_app
    Function UpdateArticle(clArticle As ClArticle_app) As Boolean
        Try
            Dim cn As New SqlConnection
            Dim cmd As New SqlCommand
            cn.ConnectionString = DalConnection_app.IOSConnectionString
            cmd.CommandText = "Update tblArticle_CMS set ArticleTitle=@A1, ArticleTitle_KH= @A2, " & _
                                  " ArticleBreadcrum=@A3, ArticleBreadcrum_KH=@A4 ,Visible=@A5, ArticleContent=@A6, ArticleContent_KH=@A7, ImageShare=@A9 , FeedID=@A10" & _
                                  " where ArticleID=@A8"
            cmd.Connection = cn

            cmd.Parameters.Add("@A1", SqlDbType.NVarChar).Value = clArticle.ArticleTitle
            cmd.Parameters.Add("@A2", SqlDbType.NVarChar).Value = clArticle.ArticleTitle_KH
            cmd.Parameters.Add("@A3", SqlDbType.NVarChar).Value = clArticle.Breadcrum
            cmd.Parameters.Add("@A4", SqlDbType.NVarChar).Value = clArticle.Breadcrum_KH
            cmd.Parameters.Add("@A5", SqlDbType.Bit).Value = clArticle.Visible
            cmd.Parameters.Add("@A6", SqlDbType.NVarChar).Value = clArticle.ArticleContent
            cmd.Parameters.Add("@A7", SqlDbType.NVarChar).Value = clArticle.ArticleContent_KH
            cmd.Parameters.Add("@A8", SqlDbType.Int).Value = clArticle.ArticleID
            cmd.Parameters.Add("@A9", SqlDbType.NVarChar).Value = clArticle.ImageShare
            cmd.Parameters.Add("@A10", SqlDbType.Int).Value = clArticle.FeedID
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            'MsgBox(ex.Message)
            Return True
        End Try

        Return False
    End Function

    Function AddFeed(FeedTitle As String, PostDate As Date, CreatedBy As String) As Integer
        Try
            Dim cn As New SqlConnection
            Dim cmd As New SqlCommand
            cn.ConnectionString = DalConnection_app.EDBConnectionString
            cmd.CommandText = "Insert into tblFeeds (FeedTitle, PostDate, CreatedBy)" & _
                " Values(@A1, @A2, @A3)"


            cmd.Connection = cn

            cmd.Parameters.Add("@A1", SqlDbType.NVarChar).Value = FeedTitle
            cmd.Parameters.Add("@A2", SqlDbType.DateTime).Value = PostDate
            cmd.Parameters.Add("@A3", SqlDbType.NVarChar).Value = CreatedBy

            cn.Open()
            cmd.ExecuteNonQuery()

            cmd.CommandText = "SELECT @@IDENTITY"
            Dim obj = cmd.ExecuteScalar

            Dim NewFeedID As Integer
            If Not IsNothing(obj) And Not IsDBNull(obj) Then
                NewFeedID = CInt(obj.ToString)
            End If

            cn.Close()
            Return NewFeedID
        Catch ex As Exception
            'MsgBox(ex.Message)
            Return 0
        End Try

        Return False
    End Function

    Function AddArticle(clArticle As ClArticle_app, ByRef NewArticleID As Integer) As Boolean
        Try
            Dim cn As New SqlConnection
            Dim cmd As New SqlCommand
            cn.ConnectionString = DalConnection_app.IOSConnectionString
            cmd.CommandText = "Insert into tblArticle_CMS (WebsiteID, ArticleTitle,ArticleBreadcrum,ArticleContent,Visitor, Visible, Deleted, Comment, ArticleTitle_KH, ArticleBreadcrum_KH, ArticleContent_KH,ImageShare,FeedID)" & _
                " Values(@A1, @A2, @A3, @A4, @A5, @A6, @A7, @A8, @A9, @A10,@A11,@A12,@A13)"


            cmd.Connection = cn

            cmd.Parameters.Add("@A1", SqlDbType.Int).Value = clArticle.WebsiteID
            cmd.Parameters.Add("@A2", SqlDbType.NVarChar).Value = clArticle.ArticleTitle
            cmd.Parameters.Add("@A3", SqlDbType.NVarChar).Value = clArticle.Breadcrum
            cmd.Parameters.Add("@A4", SqlDbType.NVarChar).Value = clArticle.ArticleContent
            cmd.Parameters.Add("@A5", SqlDbType.Int).Value = clArticle.Visitor
            cmd.Parameters.Add("@A6", SqlDbType.Bit).Value = clArticle.Visible
            cmd.Parameters.Add("@A7", SqlDbType.Bit).Value = clArticle.Deleted
            cmd.Parameters.Add("@A8", SqlDbType.NVarChar).Value = clArticle.Comment
            cmd.Parameters.Add("@A9", SqlDbType.NVarChar).Value = clArticle.ArticleTitle_KH
            cmd.Parameters.Add("@A10", SqlDbType.NVarChar).Value = clArticle.Breadcrum_KH
            cmd.Parameters.Add("@A11", SqlDbType.NVarChar).Value = clArticle.ArticleContent_KH
            cmd.Parameters.Add("@A12", SqlDbType.NVarChar).Value = clArticle.ImageShare
            cmd.Parameters.Add("@A13", SqlDbType.Int).Value = clArticle.FeedID
            cn.Open()
            cmd.ExecuteNonQuery()

            cmd.CommandText = "SELECT @@IDENTITY"
            Dim obj = cmd.ExecuteScalar

            If Not IsNothing(obj) And Not IsDBNull(obj) Then
                NewArticleID = CInt(obj.ToString)
            End If

            cn.Close()
        Catch ex As Exception
            'MsgBox(ex.Message)
            Return True
        End Try

        Return False
    End Function


End Class
