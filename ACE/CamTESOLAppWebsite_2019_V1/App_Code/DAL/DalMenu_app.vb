Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class DalMenu_app

    Function UpdateMenu(clMenu As ClMenu_app) As Boolean
        Try
            Dim cn As New SqlConnection
            Dim cmd As New SqlCommand
            cn.ConnectionString = DalConnection_app.EDBConnectionString
            cmd.CommandText = "Update tblMenu_App_CMS set MenuName=@A1,MenuOrder= @A2, " & _
                                  " Visible=@A3 , Deleted=@A4, ArticleID=@A5 , MenuName_KH=@A6 , MenuParentID=@A7 , IsParent=@A8, MenuTop=@A10 " & _
                                  " where MenuID=@A9"
            cmd.Connection = cn

            cmd.Parameters.Add("@A1", SqlDbType.NVarChar).Value = clMenu.MenuName
            cmd.Parameters.Add("@A2", SqlDbType.Int).Value = clMenu.MenuOrder
            cmd.Parameters.Add("@A3", SqlDbType.Bit).Value = clMenu.MenuVisible
            cmd.Parameters.Add("@A4", SqlDbType.Bit).Value = clMenu.MenuDeleted
            cmd.Parameters.Add("@A5", SqlDbType.Int).Value = clMenu.ArticleID
            cmd.Parameters.Add("@A6", SqlDbType.NVarChar).Value = clMenu.MenuName_KH
            cmd.Parameters.Add("@A7", SqlDbType.Int).Value = clMenu.MenuParentID
            cmd.Parameters.Add("@A8", SqlDbType.Bit).Value = clMenu.IsParent
            cmd.Parameters.Add("@A9", SqlDbType.Int).Value = clMenu.MenuID
            cmd.Parameters.Add("@A10", SqlDbType.Bit).Value = clMenu.MenuTop

            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            'MsgBox(ex.Message)
            Return True
        End Try

        Return False
    End Function

    Function AddMenu(clMenu As ClMenu_app, ByRef NewMenuID As Integer) As Boolean
        Try
            Dim cn As New SqlConnection
            Dim cmd As New SqlCommand
            cn.ConnectionString = DalConnection_app.EDBConnectionString
            cmd.CommandText = "Insert into tblMenu_App_CMS (MenuName, MenuOrder, Visible, Deleted, Comment, WebsiteID, ArticleID, MenuName_KH, MenuParentID, IsParent, MenuTop)" & _
                " Values(@A1, @A2, @A3, @A4, @A5, @A6, @A7, @A8, @A9, @A10,@A11)"


            cmd.Connection = cn

            cmd.Parameters.Add("@A1", SqlDbType.NVarChar).Value = clMenu.MenuName
            cmd.Parameters.Add("@A2", SqlDbType.Int).Value = clMenu.MenuOrder
            cmd.Parameters.Add("@A3", SqlDbType.Bit).Value = clMenu.MenuVisible
            cmd.Parameters.Add("@A4", SqlDbType.Bit).Value = clMenu.MenuDeleted
            cmd.Parameters.Add("@A5", SqlDbType.NVarChar).Value = clMenu.Comment
            cmd.Parameters.Add("@A6", SqlDbType.Int).Value = clMenu.WebsiteID
            cmd.Parameters.Add("@A7", SqlDbType.Int).Value = clMenu.ArticleID
            cmd.Parameters.Add("@A8", SqlDbType.NVarChar).Value = clMenu.MenuName_KH
            cmd.Parameters.Add("@A9", SqlDbType.Int).Value = clMenu.MenuParentID
            cmd.Parameters.Add("@A10", SqlDbType.Bit).Value = clMenu.IsParent
            cmd.Parameters.Add("@A11", SqlDbType.Bit).Value = clMenu.MenuTop


            cn.Open()
            cmd.ExecuteNonQuery()

            cmd.CommandText = "SELECT @@IDENTITY"
            Dim obj = cmd.ExecuteScalar

            If Not IsNothing(obj) And Not IsDBNull(obj) Then
                NewMenuID = CInt(obj.ToString)
            End If


            cn.Close()
        Catch ex As Exception
            'MsgBox(ex.Message)
            Return True
        End Try

        Return False
    End Function

End Class
