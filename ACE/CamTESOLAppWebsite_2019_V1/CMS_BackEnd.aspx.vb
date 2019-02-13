Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class CMS_BackEnd
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Page.IsPostBack = False Then
            MultiView1.ActiveViewIndex = 0
            GridView1.DataSourceID = ""
            LoadArticleGrid()
            LoadMenuParent()
            If Request.Url.ToString.Contains("type=") = True Then
                If Request.QueryString("type") = "clearmenu" Then
                    cboParent.Text = ""
                End If
            End If

        End If

    End Sub

    Protected Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete


        If Request.Url.ToString.Contains("type=") = True Then
            If Request.QueryString("type") = "menu" Then
                LoadMenuManager(1, "CMS_BackEnd.aspx")
                container_middle_menudetail.Visible = False
                container_middle_contentdetail.Visible = False
                container__content.Visible = True
                container_middle_media.Visible = False
                'div_middle_banner.Visible = False
                div_middle_photogallery.Visible = False
                div_middle_groupphoto.Visible = False
                noShowContent.Visible = False
                cmdNew_Item.Text = "New Menu"
                cmdNew_Item.Visible = True
            ElseIf Request.QueryString("type") = "content" Then
                LoadContentManager(1, "CMS_BackEnd.aspx")
                container_middle_menudetail.Visible = False
                container_middle_contentdetail.Visible = False
                container__content.Visible = True
                container_middle_media.Visible = False
                'div_middle_banner.Visible = False
                div_middle_photogallery.Visible = False
                div_middle_groupphoto.Visible = False
                noShowContent.Visible = False
                cmdNew_Item.Text = "New Content"
                cmdNew_Item.Visible = True
            ElseIf Request.QueryString("type") = "media" Then
                container_middle_menudetail.Visible = False
                container_middle_contentdetail.Visible = False
                container__content.Visible = False
                div_middle_photogallery.Visible = False
                div_middle_groupphoto.Visible = False
                noShowContent.Visible =False
                'div_middle_banner.Visible = False
                Dim projectpath As String = HttpContext.Current.Request.PhysicalApplicationPath

                LoadFileName("Upload_s")
                If Not IsPostBack Then

                    cboFolder.Items.Add("Upload_s")

                    For Each d As String In IO.Directory.GetDirectories(projectpath & "Upload_s")
                        'IO.Path.GetFileName
                        'The characters after the last directory character in path.
                        cboFolder.Items.Add(Replace(d, projectpath, ""))

                        For Each dd As String In IO.Directory.GetDirectories(projectpath & Replace(d, projectpath, ""))
                            cboFolder.Items.Add(Replace(dd, projectpath, ""))
                        Next
                    Next

                End If
            ElseIf Request.QueryString("type") = "noShow" Then
                container__content.Visible = False
                container_middle_contentdetail.Visible = False
                container_middle_media.Visible = False
                div_middle_photogallery.Visible = False
                div_middle_groupphoto.Visible = False
                noShowContent.Visible = True
                refreshLstNoShow()

            ElseIf Request.QueryString("type") = "program" Then
                LoadBannerManager(1, "CMS_BackEnd.aspx")
                container_middle_menudetail.Visible = False
                container_middle_contentdetail.Visible = False
                container__content.Visible = True
                container_middle_media.Visible = False
                'div_middle_banner.Visible = False
                div_middle_photogallery.Visible = False
                div_middle_groupphoto.Visible = False
                cmdNew_Item.Text = "New Program"
                cmdNew_Item.Visible = True

            ElseIf Request.QueryString("type") = "photogallery" Then
                LoadPhotoGallery("CMS_BackEnd.aspx")
                container_middle_menudetail.Visible = False
                container_middle_contentdetail.Visible = False
                container__content.Visible = True
                container_middle_media.Visible = False
                'div_middle_banner.Visible = False
                div_middle_photogallery.Visible = False
                div_middle_groupphoto.Visible = False
                cmdNew_Item.Text = "New Photo"
                cmdNew_Item.Visible = True

            ElseIf Request.QueryString("type") = "groupphoto" Then
                LoadGroupPhoto("CMS_BackEnd.aspx")
                container_middle_menudetail.Visible = False
                container_middle_contentdetail.Visible = False
                container__content.Visible = True
                container_middle_media.Visible = False
                'div_middle_banner.Visible = False
                div_middle_photogallery.Visible = False
                div_middle_groupphoto.Visible = False
                cmdNew_Item.Text = "New Group"
                cmdNew_Item.Visible = True

            ElseIf Request.QueryString("type") = "clearmenu" Then
                container_middle_menudetail.Visible = True
                container_middle_contentdetail.Visible = False
                container__content.Visible = False
                container_middle_media.Visible = False
                div_middle_photogallery.Visible = False
                'div_middle_banner.Visible = False
                div_middle_groupphoto.Visible = False
                LoadFolderImage(cboFolder_Menu)
                Exit Sub
            ElseIf Request.QueryString("type") = "cleararticle" Then
                container_middle_menudetail.Visible = False
                container_middle_contentdetail.Visible = True
                container__content.Visible = False
                container_middle_media.Visible = False
                div_middle_photogallery.Visible = False
                'div_middle_banner.Visible = False
                div_middle_groupphoto.Visible = False
                LoadFolderImage(cboFolder_Subcontent)
                Exit Sub
            ElseIf Request.QueryString("type") = "clearphotogallery" Then
                container_middle_menudetail.Visible = False
                container_middle_contentdetail.Visible = False
                container__content.Visible = False
                container_middle_media.Visible = False
                div_middle_photogallery.Visible = True
                'div_middle_banner.Visible = False
                div_middle_groupphoto.Visible = False
                LoadFolderImage(cboFolder_PhotoGallery)
                LoadGroupPhoto()
                Exit Sub

            ElseIf Request.QueryString("type") = "cleargroupphoto" Then
                container_middle_menudetail.Visible = False
                container_middle_contentdetail.Visible = False
                container__content.Visible = False
                container_middle_media.Visible = False
                div_middle_photogallery.Visible = False
                'div_middle_banner.Visible = False
                div_middle_groupphoto.Visible = False
                div_middle_groupphoto.Visible = True
                LoadFolderImage(cboFolder_GroupPhoto)
                Exit Sub

                'ElseIf Request.QueryString("type") = "clearprogram" Then
                '    container_middle_menudetail.Visible = False
                '    container_middle_contentdetail.Visible = False
                '    container__content.Visible = False
                '    container_middle_media.Visible = False
                '    div_middle_photogallery.Visible = False
                '    'div_middle_banner.Visible = True
                '    div_middle_groupphoto.Visible = False
                '    LoadFolderImage(cboFolder_ImageProgram)
                '    Exit Sub
            End If
        Else
            If Page.IsPostBack = False Then
                container_middle_menudetail.Visible = False
                container_middle_contentdetail.Visible = False
                container_middle_media.Visible = False
                div_middle_photogallery.Visible = False
                'div_middle_banner.Visible = False
                cmdNew_Item.Visible = False
                div_middle_groupphoto.Visible = False
                noShowContent.Visible = False
            End If
        End If


        If Request.Url.ToString.Contains("articleid=") = True Then
            container_middle_contentdetail.Visible = True
            container_middle_menudetail.Visible = False
            container_middle_media.Visible = False
            div_middle_photogallery.Visible = False
            container__content.Visible = False
            'div_middle_banner.Visible = False
            div_middle_groupphoto.Visible = False





            If Not IsPostBack Then
                LoadContentManagerDetail(Request.QueryString("articleid").ToString, "CMS_BackEnd.aspx")
            End If

            LoadFolderImage(cboFolder_Subcontent)


        ElseIf Request.Url.ToString.Contains("menuid=") = True Then
            container_middle_menudetail.Visible = True
            container_middle_contentdetail.Visible = False
            container_middle_media.Visible = False
            div_middle_photogallery.Visible = False
            container__content.Visible = False
            'div_middle_banner.Visible = False
            div_middle_groupphoto.Visible = False
            If Page.IsPostBack = False Then
                LoadMenuDetail(Request.QueryString("menuid").ToString, "CMS_BackEnd.aspx")
            End If
            LoadFolderImage(cboFolder_Menu)

            'ElseIf Request.Url.ToString.Contains("programid=") = True Then
            '    container_middle_menudetail.Visible = False
            '    container_middle_contentdetail.Visible = False
            '    container_middle_media.Visible = False
            '    container__content.Visible = False
            '    div_middle_photogallery.Visible = False
            '    'div_middle_banner.Visible = True
            '    div_middle_groupphoto.Visible = False


            '    If Not IsPostBack Then
            '        LoadBannerDetail(Request.QueryString("programid"), "CMS_BackEnd.aspx")
            '    End If

            '    LoadFolderImage(cboFolder_ImageProgram)

        ElseIf Request.Url.ToString.Contains("photogalleryid=") = True Then

            If Not IsPostBack Then
                LoadGroupPhoto()
                LoadPhotoGalleryDetail(Request.QueryString("photogalleryid"), "CMS_BackEnd.aspx")

            End If

            container_middle_menudetail.Visible = False
            container_middle_contentdetail.Visible = False
            container_middle_media.Visible = False
            container__content.Visible = False
            div_middle_photogallery.Visible = True
            'div_middle_banner.Visible = False
            div_middle_groupphoto.Visible = False

            LoadFolderImage(cboFolder_PhotoGallery)


        ElseIf Request.Url.ToString.Contains("groupphotoid=") = True Then

            If Not IsPostBack Then
                LoadGroupPhotoDetail(Request.QueryString("groupphotoid"), "CMS_BackEnd.aspx")
            End If

            container_middle_menudetail.Visible = False
            container_middle_contentdetail.Visible = False
            container_middle_media.Visible = False
            container__content.Visible = False
            div_middle_photogallery.Visible = False
            div_middle_groupphoto.Visible = True
            'div_middle_banner.Visible = False

            LoadFolderImage(cboFolder_GroupPhoto)

        End If


    End Sub


    Sub LoadFolderImage(cboFolder As DropDownList)
        Dim projectpath As String = HttpContext.Current.Request.PhysicalApplicationPath

        Dim pathImageShare As String = ""
        If cboFolder.Text = "" Then
            pathImageShare = "Upload_s"
        Else
            pathImageShare = cboFolder.Text
        End If
        'LoadFileName2(pathImageShare, GridView7, "PhotoGallery")

        If Not IsPostBack Then


            cboFolder.Items.Add("Upload_s")

            For Each d As String In IO.Directory.GetDirectories(projectpath & "Upload_s")
                'IO.Path.GetFileName
                'The characters after the last directory character in path.
                cboFolder.Items.Add(Replace(d, projectpath, ""))

                For Each dd As String In IO.Directory.GetDirectories(projectpath & Replace(d, projectpath, ""))
                    cboFolder.Items.Add(Replace(dd, projectpath, ""))
                Next
            Next

        End If
    End Sub


    Sub LoadFileName(pathfolder As String)
        Dim filePaths() As String = Directory.GetFiles(Server.MapPath("~/" & pathfolder & "/"))
        Dim files As List(Of ListItem) = New List(Of ListItem)
        For Each filePath As String In filePaths
            files.Add(New ListItem(Path.GetFileName(filePath), filePath))
        Next
        GridView2.DataSource = files
        GridView2.DataBind()

        Session("fileds") = files
    End Sub

    Sub LoadGroupPhoto()
        Dim BalGl As New BalGlobal_app

        Dim dsGroupPhoto As DataSet = BalGl.getDataFromTable("tblGroupPhoto", "*", "Name", "where Isnull(Deleted,0)=0 and Isnull(Visible,0)=1 ", "asc")

        If dsGroupPhoto.Tables(0).Rows.Count > 0 Then
            cboGroupPhotoGallery.DataSource = dsGroupPhoto.Tables(0)
            cboGroupPhotoGallery.DataTextField = "Name"
            cboGroupPhotoGallery.DataValueField = "GroupPhotoID"
            cboGroupPhotoGallery.DataBind()

        End If

    End Sub

    Sub LoadGroupPhoto(hdWebSite As String)
        Dim BalGl As New BalGlobal_app

        Dim dsMenu As DataSet = BalGl.getDataFromTable("tblGroupPhoto", "*", "Name", "where Isnull(Deleted,0)=0 and Isnull(Visible,0)=1 ", "asc")

        Dim Menustring As String = ""

        Menustring = "<div style='font-size:18px;color:#0090CC;margin-bottom:20px'>Group Photo Gallery Manager</div>"

        Menustring = Menustring & "<table style='border:1px solid #adadad;width:94%' cellspacing='0'>"

        Menustring = Menustring & "<tr>"
        Menustring = Menustring & "<td align='center' style='border-right:1px solid #dddddd;border-bottom:1px solid #adadad;background-color:#F4F4F4'>No</td>"
        Menustring = Menustring & "<td style='border-right:1px solid #dddddd;padding-left:10px;border-bottom:1px solid #adadad;background-color:#F4F4F4'>Title</td>"
        Menustring = Menustring & "<td align='center' style='border-right:1px solid #dddddd;border-bottom:1px solid #adadad;background-color:#F4F4F4'>Visible</td>"
        Menustring = Menustring & "<td align='center' style='border-right:1px solid #dddddd;border-bottom:1px solid #adadad;background-color:#F4F4F4'>Ordering</td>"
        Menustring = Menustring & "<td style='padding-left:10px;border-bottom:1px solid #adadad;background-color:#F4F4F4'>ID</td>"
        Menustring = Menustring & "</tr>"

        For i = 0 To dsMenu.Tables(0).Rows.Count - 1

            Menustring = Menustring & "<tr style='border:1px solid #adadad'>"
            Menustring = Menustring & "<td align='center' style='border-right:1px solid #dddddd;;border-bottom:1px solid #dddddd;'>" & i + 1 & "</td>"
            Menustring = Menustring & "<td style='border-right:1px solid #dddddd;padding-left:10px;border-bottom:1px solid #dddddd;'><a href='" & hdWebSite & "?groupphotoid=" & dsMenu.Tables(0).Rows(i)("GroupPhotoID") & "' style='color:black'>" & dsMenu.Tables(0).Rows(i)("Name") & "</a></td>"
            Menustring = Menustring & "<td align='center' style='border-right:1px solid #dddddd;border-bottom:1px solid #dddddd;'>" & dsMenu.Tables(0).Rows(i)("Visible") & "</td>"
            Menustring = Menustring & "<td align='center' style='border-right:1px solid #dddddd;border-bottom:1px solid #dddddd;'>" & dsMenu.Tables(0).Rows(i)("Ordering") & "</td>"
            Menustring = Menustring & "<td style='padding-left:10px;border-bottom:1px solid #dddddd;'>" & dsMenu.Tables(0).Rows(i)("GroupPhotoID") & "</td>"
            Menustring = Menustring & "</tr>"
        Next

        Menustring = Menustring & "</table>"

        container_middle_content.InnerHtml = Menustring
    End Sub


    Sub LoadPhotoGallery(hdWebSite As String)
        Dim BalGl As New BalGlobal_app

        Dim dsMenu As DataSet = BalGl.getDataFromTable("tblPhotoGallery", "*", "Name", "where Isnull(Deleted,0)=0 and Isnull(Visible,0)=1 ", "asc")

        Dim Menustring As String = ""

        Menustring = "<div style='font-size:18px;color:#0090CC;margin-bottom:20px'>Photo Gallery Manager</div>"

        Menustring = Menustring & "<table style='border:1px solid #adadad;width:94%' cellspacing='0'>"

        Menustring = Menustring & "<tr>"
        Menustring = Menustring & "<td align='center' style='border-right:1px solid #dddddd;border-bottom:1px solid #adadad;background-color:#F4F4F4'>No</td>"
        Menustring = Menustring & "<td style='border-right:1px solid #dddddd;padding-left:10px;border-bottom:1px solid #adadad;background-color:#F4F4F4'>Title</td>"
        Menustring = Menustring & "<td align='center' style='border-right:1px solid #dddddd;border-bottom:1px solid #adadad;background-color:#F4F4F4'>Visible</td>"
        Menustring = Menustring & "<td align='center' style='border-right:1px solid #dddddd;border-bottom:1px solid #adadad;background-color:#F4F4F4'>Group</td>"
        Menustring = Menustring & "<td style='padding-left:10px;border-bottom:1px solid #adadad;background-color:#F4F4F4'>ID</td>"
        Menustring = Menustring & "</tr>"

        For i = 0 To dsMenu.Tables(0).Rows.Count - 1

            Menustring = Menustring & "<tr style='border:1px solid #adadad'>"
            Menustring = Menustring & "<td align='center' style='border-right:1px solid #dddddd;;border-bottom:1px solid #dddddd;'>" & i + 1 & "</td>"
            Menustring = Menustring & "<td style='border-right:1px solid #dddddd;padding-left:10px;border-bottom:1px solid #dddddd;'><a href='" & hdWebSite & "?photogalleryid=" & dsMenu.Tables(0).Rows(i)("PhotoID") & "' style='color:black'>" & dsMenu.Tables(0).Rows(i)("Name") & "</a></td>"
            Menustring = Menustring & "<td align='center' style='border-right:1px solid #dddddd;border-bottom:1px solid #dddddd;'>" & dsMenu.Tables(0).Rows(i)("Visible") & "</td>"
            Menustring = Menustring & "<td align='center' style='border-right:1px solid #dddddd;border-bottom:1px solid #dddddd;'>" & dsMenu.Tables(0).Rows(i)("GroupPhotoID") & "</td>"
            Menustring = Menustring & "<td style='padding-left:10px;border-bottom:1px solid #dddddd;'>" & dsMenu.Tables(0).Rows(i)("PhotoID") & "</td>"
            Menustring = Menustring & "</tr>"
        Next

        Menustring = Menustring & "</table>"

        container_middle_content.InnerHtml = Menustring
    End Sub

    Private Sub LoadBannerManager(websiteID As Integer, hdWebSite As String)
        Dim BalGl As New BalGlobal_app

        Dim dsMenu As DataSet = BalGl.getDataFromTable("tblCourse_CMS", "*", "ProgramID", "where Isnull(Deleted,0)=0 ", "asc")

        Dim Menustring As String = ""

        Menustring = "<div style='font-size:18px;color:#0090CC;margin-bottom:20px'>Program Manager</div>"

        Menustring = Menustring & "<table style='border:1px solid #adadad;width:94%' cellspacing='0'>"

        Menustring = Menustring & "<tr>"
        Menustring = Menustring & "<td align='center' style='border-right:1px solid #dddddd;border-bottom:1px solid #adadad;background-color:#F4F4F4'>No</td>"
        Menustring = Menustring & "<td style='border-right:1px solid #dddddd;padding-left:10px;border-bottom:1px solid #adadad;background-color:#F4F4F4'>Title</td>"
        Menustring = Menustring & "<td align='center' style='border-right:1px solid #dddddd;border-bottom:1px solid #adadad;background-color:#F4F4F4'>Visible</td>"
        Menustring = Menustring & "<td style='padding-left:10px;border-bottom:1px solid #adadad;background-color:#F4F4F4'>ID</td>"
        Menustring = Menustring & "</tr>"

        For i = 0 To dsMenu.Tables(0).Rows.Count - 1

            Menustring = Menustring & "<tr style='border:1px solid #adadad'>"
            Menustring = Menustring & "<td align='center' style='border-right:1px solid #dddddd;;border-bottom:1px solid #dddddd;'>" & i + 1 & "</td>"
            Menustring = Menustring & "<td style='border-right:1px solid #dddddd;padding-left:10px;border-bottom:1px solid #dddddd;'><a href='" & hdWebSite & "?programid=" & dsMenu.Tables(0).Rows(i)("ProgramID") & "' style='color:black'>" & dsMenu.Tables(0).Rows(i)("Name") & "</a></td>"
            Menustring = Menustring & "<td align='center' style='border-right:1px solid #dddddd;border-bottom:1px solid #dddddd;'>" & dsMenu.Tables(0).Rows(i)("Visible") & "</td>"
            Menustring = Menustring & "<td style='padding-left:10px;border-bottom:1px solid #dddddd;'>" & dsMenu.Tables(0).Rows(i)("ProgramID") & "</td>"
            Menustring = Menustring & "</tr>"
        Next

        Menustring = Menustring & "</table>"

        container_middle_content.InnerHtml = Menustring

    End Sub

    Private Sub LoadMenuManager(websiteID As Integer, hdWebSite As String)
        Dim BalGl As New BalGlobal_app

        Dim dsMenu As DataSet = BalGl.getDataFromTable("tblMenu_App_CMS m left join tblArticle_CMS a on m.ArticleID=a.ArticleID", "m.*,a.ArticleTitle,Isnull(a.Visible,0) as VisibleArticle,'" & hdWebSite & "?ArticleID=' + Convert(Varchar(10),Isnull(a.ArticleID,'')) as PostBackUrl", "MenuOrder", "where m.Deleted=0 and Isnull(m.MenuParentID,0)=0 ", "asc")

        Dim Menustring As String = ""

        Menustring = "<div style='font-size:18px;color:#0090CC;margin-bottom:20px'>Menu Manager</div>"

        Menustring = Menustring & "<table style='border:1px solid #adadad;width:94%' cellspacing='0'>"

        Menustring = Menustring & "<tr>"
        Menustring = Menustring & "<td align='center' style='border-right:1px solid #dddddd;border-bottom:1px solid #adadad;background-color:#F4F4F4'>No</td>"
        Menustring = Menustring & "<td style='border-right:1px solid #dddddd;padding-left:10px;border-bottom:1px solid #adadad;background-color:#F4F4F4'>Title</td>"
        Menustring = Menustring & "<td align='center' style='border-right:1px solid #dddddd;border-bottom:1px solid #adadad;background-color:#F4F4F4'>Visible</td>"
        Menustring = Menustring & "<td align='center' style='border-right:1px solid #dddddd;border-bottom:1px solid #adadad;background-color:#F4F4F4'>Ordering</td>"
        Menustring = Menustring & "<td style='padding-left:10px;border-bottom:1px solid #adadad;background-color:#F4F4F4'>Article</td>"
        Menustring = Menustring & "</tr>"

        For i = 0 To dsMenu.Tables(0).Rows.Count - 1

            Menustring = Menustring & "<tr style='border:1px solid #adadad'>"
            Menustring = Menustring & "<td align='center' style='border-right:1px solid #dddddd;;border-bottom:1px solid #dddddd;'>" & i + 1 & "</td>"
            Menustring = Menustring & "<td style='border-right:1px solid #dddddd;padding-left:10px;border-bottom:1px solid #dddddd;'><a href='" & hdWebSite & "?menuid=" & dsMenu.Tables(0).Rows(i)("MenuID") & "' style='color:black'>" & dsMenu.Tables(0).Rows(i)("MenuName") & "</a></td>"
            Menustring = Menustring & "<td align='center' style='border-right:1px solid #dddddd;border-bottom:1px solid #dddddd;'>" & dsMenu.Tables(0).Rows(i)("Visible") & "</td>"
            Menustring = Menustring & "<td align='center' style='border-right:1px solid #dddddd;border-bottom:1px solid #dddddd;'>" & dsMenu.Tables(0).Rows(i)("MenuOrder") & "</td>"
            Menustring = Menustring & "<td style='padding-left:10px;border-bottom:1px solid #dddddd;'>" & dsMenu.Tables(0).Rows(i)("ArticleTitle") & "</td>"
            Menustring = Menustring & "</tr>"

            Dim MainMenuID As Integer = dsMenu.Tables(0).Rows(i)("MenuID")
            'Dim dsSubMenu As DataSet = BalGl.getDataFromTable("tblSubMenu_CMS s left join tblArticle_CMS m on s.ArticleID=m.ArticleID", "s.*,m.ArticleTitle as Article,Isnull(s.Visible,0) as VisibleArticle,'" & hdWebSite & "?ArticleID=' + Convert(Varchar(10),Isnull(s.ArticleID,'')) as PostBackUrl", "SubMenuOrder", "where s.MenuID=" & MainContentID & " and s.Deleted=0", "asc")
            Dim dsSubMenu As DataSet = BalGl.getDataFromTable("tblMenu_App_CMS m left join tblArticle_CMS a on m.ArticleID=a.ArticleID", "m.*,a.ArticleTitle,Isnull(a.Visible,0) as VisibleArticle,'" & hdWebSite & "?ArticleID=' + Convert(Varchar(10),Isnull(a.ArticleID,'')) as PostBackUrl", "MenuOrder", "where isnull(m.WebsiteID,'')=" & websiteID & " and Isnull(m.Deleted,0)=0 and isnull(m.MenuParentID,0)=" & MainMenuID, "asc")

            Dim match As Integer = 0
            If dsSubMenu.Tables(0).Rows.Count > 0 Then
                Dim SubMenuString As String = ""

                For j = 0 To dsSubMenu.Tables(0).Rows.Count - 1
                    SubMenuString = SubMenuString & "<tr>"
                    SubMenuString = SubMenuString & "<td style='border-right:1px solid #dddddd;border-bottom:1px solid #dddddd;'></td>"
                    SubMenuString = SubMenuString & "<td style='border-right:1px solid #dddddd;padding-left:10px;border-bottom:1px solid #dddddd;'>" & j + 1 & ". <a href='" & hdWebSite & "?menuid=" & dsSubMenu.Tables(0).Rows(j)("MenuID") & "' style='color:black'>" & dsSubMenu.Tables(0).Rows(j)("MenuName") & "</td>"
                    SubMenuString = SubMenuString & "<td align='center' style='border-right:1px solid #dddddd;border-bottom:1px solid #dddddd;'>" & dsSubMenu.Tables(0).Rows(j)("Visible") & "</td>"
                    SubMenuString = SubMenuString & "<td align='center' style='border-right:1px solid #dddddd;border-bottom:1px solid #dddddd;'>" & dsSubMenu.Tables(0).Rows(j)("MenuOrder") & "</td>"
                    SubMenuString = SubMenuString & "<td style='padding-left:10px;border-bottom:1px solid #dddddd;'>" & dsSubMenu.Tables(0).Rows(j)("ArticleTitle") & "</td>"
                    SubMenuString = SubMenuString & "</tr>"
                Next

                Menustring = Menustring & SubMenuString
            End If
        Next

        Menustring = Menustring & "</table>"

        container_middle_content.InnerHtml = Menustring

    End Sub

    Private Sub LoadContentManager(websiteID As Integer, hdWebSite As String)
        Dim BalGl As New BalGlobal_app

        Dim dsMenu As DataSet = BalGl.getDataFromTable("tblArticle_CMS a left join tblMenu_App_CMS m on a.ArticleID=m.ArticleID", "a.*,m.MenuName,'" & hdWebSite & "?ArticleID=' + Convert(Varchar(10),Isnull(a.ArticleID,'')) as PostBackUrl", "a.ArticleTitle", "where a.WebsiteID=" & websiteID & " and a.Deleted=0 and Isnull(m.Deleted,0)=0 ", "asc")

        Dim Menustring As String = ""

        Menustring = "<div style='font-size:18px;color:#0090CC;margin-bottom:20px'>Content Manager</div>"

        Menustring = Menustring & "<table style='border:1px solid #adadad;width:94%' cellspacing='0'>"

        Menustring = Menustring & "<tr>"
        Menustring = Menustring & "<td align='center' style='border-right:1px solid #dddddd;border-bottom:1px solid #adadad;background-color:#F4F4F4'>No</td>"
        Menustring = Menustring & "<td style='border-right:1px solid #dddddd;padding-left:10px;border-bottom:1px solid #adadad;background-color:#F4F4F4'>Title</td>"
        Menustring = Menustring & "<td style='padding-left:10px;border-right:1px solid #dddddd;border-bottom:1px solid #adadad;background-color:#F4F4F4'>Title Khmer</td>"
        Menustring = Menustring & "<td align='center' style='border-right:1px solid #dddddd;border-bottom:1px solid #adadad;background-color:#F4F4F4'>Visible</td>"
        Menustring = Menustring & "<td style='border-right:1px solid #dddddd;padding-left:10px;border-bottom:1px solid #adadad;background-color:#F4F4F4'>Linked Menu</td>"
        Menustring = Menustring & "<td align='center' style='padding-left:10px;border-bottom:1px solid #adadad;background-color:#F4F4F4'>ID</td>"
        Menustring = Menustring & "</tr>"

        For i = 0 To dsMenu.Tables(0).Rows.Count - 1

            Menustring = Menustring & "<tr style='border:1px solid #adadad'>"
            Menustring = Menustring & "<td align='center' style='border-right:1px solid #dddddd;;border-bottom:1px solid #dddddd;'>" & i + 1 & "</td>"
            Menustring = Menustring & "<td style='border-right:1px solid #dddddd;padding-left:10px;border-bottom:1px solid #dddddd;'><a href='" & hdWebSite & "?articleid=" & dsMenu.Tables(0).Rows(i)("ArticleID") & "' style='color:black'>" & dsMenu.Tables(0).Rows(i)("ArticleTitle") & "</a></td>"
            Menustring = Menustring & "<td align='center' style='border-right:1px solid #dddddd;border-bottom:1px solid #dddddd;'>" & dsMenu.Tables(0).Rows(i)("ArticleTitle_KH") & "</td>"
            Menustring = Menustring & "<td align='center' style='border-right:1px solid #dddddd;border-bottom:1px solid #dddddd;'>" & dsMenu.Tables(0).Rows(i)("Visible") & "</td>"
            Menustring = Menustring & "<td style='border-right:1px solid #dddddd;padding-left:10px;border-bottom:1px solid #dddddd;'>" & dsMenu.Tables(0).Rows(i)("MenuName") & "</td>"
            Menustring = Menustring & "<td align='center' style='border-right:1px solid #dddddd;border-bottom:1px solid #dddddd;'>" & dsMenu.Tables(0).Rows(i)("ArticleID") & "</td>"
            'Menustring = Menustring & "<td style='padding-left:10px;border-bottom:1px solid #dddddd;'>" & dsMenu.Tables(0).Rows(i)("ArticleTitle") & "</td>"
            Menustring = Menustring & "</tr>"

            Dim MainMenuID As Integer = dsMenu.Tables(0).Rows(i)("ArticleID")
            'Dim dsSubMenu As DataSet = BalGl.getDataFromTable("tblSubMenu_CMS s left join tblArticle_CMS m on s.ArticleID=m.ArticleID", "s.*,m.ArticleTitle as Article,Isnull(s.Visible,0) as VisibleArticle,'" & hdWebSite & "?ArticleID=' + Convert(Varchar(10),Isnull(s.ArticleID,'')) as PostBackUrl", "SubMenuOrder", "where s.MenuID=" & MainContentID & " and s.Deleted=0", "asc")
            'Dim dsSubMenu As DataSet = BalGl.getDataFromTable("tblMenu_CMS m left join tblArticle_CMS a on m.ArticleID=a.ArticleID", "m.*,a.ArticleTitle,Isnull(a.Visible,0) as VisibleArticle,'" & hdWebSite & "?ArticleID=' + Convert(Varchar(10),Isnull(a.ArticleID,'')) as PostBackUrl", "MenuOrder", "where isnull(m.WebsiteID,'')=" & websiteID & " and Isnull(m.Deleted,0)=0 and isnull(m.MenuParentID,0)=" & MainMenuID, "asc")

            'Dim match As Integer = 0
            'If dsSubMenu.Tables(0).Rows.Count > 0 Then
            '    Dim SubMenuString As String = ""
            '    SubMenuString = "<tr>"
            '    For j = 0 To dsSubMenu.Tables(0).Rows.Count - 1
            '        SubMenuString = SubMenuString & "<td style='border-right:1px solid #dddddd;border-bottom:1px solid #dddddd;'></td>"
            '        SubMenuString = SubMenuString & "<td style='border-right:1px solid #dddddd;padding-left:10px;border-bottom:1px solid #dddddd;'>" & j + 1 & ". <a href='" & hdWebSite & "?menuid=" & dsSubMenu.Tables(0).Rows(j)("MenuID") & "'>" & dsSubMenu.Tables(0).Rows(j)("MenuName") & "</td>"
            '        SubMenuString = SubMenuString & "<td align='center' style='border-right:1px solid #dddddd;border-bottom:1px solid #dddddd;'>" & dsSubMenu.Tables(0).Rows(j)("Visible") & "</td>"
            '        SubMenuString = SubMenuString & "<td align='center' style='border-right:1px solid #dddddd;border-bottom:1px solid #dddddd;'>" & dsSubMenu.Tables(0).Rows(j)("MenuOrder") & "</td>"
            '        SubMenuString = SubMenuString & "<td style='padding-left:10px;border-bottom:1px solid #dddddd;'>" & dsSubMenu.Tables(0).Rows(j)("ArticleTitle") & "</td>"
            '    Next
            '    SubMenuString = SubMenuString & "</tr>"
            '    Menustring = Menustring & SubMenuString
            'End If
        Next

        Menustring = Menustring & "</table>"

        container_middle_content.InnerHtml = Menustring

    End Sub

    Sub LoadGroupPhotoDetail(ID As Integer, hdwebsite As String)
        Dim BalGl As New BalGlobal_app
        Dim dsPhoto As DataSet = BalGl.getDataFromTable("tblGroupPhoto", "*", "GroupPhotoID", "where GroupPhotoID=" & ID, "asc")

        If dsPhoto.Tables(0).Rows.Count > 0 Then
            txtGroupPhotoID.Text = dsPhoto.Tables(0).Rows(0)("GroupPhotoID").ToString

            txtTitle_GroupPhoto.Text = dsPhoto.Tables(0).Rows(0)("Name").ToString

            txtImage_GroupPhoto.Text = dsPhoto.Tables(0).Rows(0)("CoverImage").ToString

            If dsPhoto.Tables(0).Rows(0)("Visible").ToString <> "" Then
                If dsPhoto.Tables(0).Rows(0)("Visible").ToString = True Then
                    cboVisible_GroupPhoto.Text = "Yes"
                Else
                    cboVisible_GroupPhoto.Text = "No"
                End If
            End If

            txtOrdering_GroupPhoto.Text = dsPhoto.Tables(0).Rows(0)("Ordering").ToString

        End If

    End Sub

    Sub LoadPhotoGalleryDetail(ID As Integer, hdwebsite As String)
        Dim BalGl As New BalGlobal_app
        Dim dsPhoto As DataSet = BalGl.getDataFromTable("tblPhotoGallery p left join tblGroupPhoto g on p.GroupPhotoID=g.GroupPhotoID", "p.*,g.Name as GroupName", "PhotoID", "where PhotoID=" & ID, "asc")

        If dsPhoto.Tables(0).Rows.Count > 0 Then
            txtPhotoGalleryID.Text = dsPhoto.Tables(0).Rows(0)("PhotoID").ToString

            txtTitle_PhotoGallery.Text = dsPhoto.Tables(0).Rows(0)("Name").ToString

            txtImage_PhotoGallery.Text = dsPhoto.Tables(0).Rows(0)("Image").ToString

            If dsPhoto.Tables(0).Rows(0)("Visible").ToString <> "" Then
                If dsPhoto.Tables(0).Rows(0)("Visible").ToString = True Then
                    cboVisible_PhotoGallery.Text = "Yes"
                Else
                    cboVisible_PhotoGallery.Text = "No"
                End If
            End If

            txtDescription.Text = dsPhoto.Tables(0).Rows(0)("Description").ToString

            txtLinkReadMore_PhotoGallery.Text = dsPhoto.Tables(0).Rows(0)("Link").ToString

            txtOrdering_PhotoGallery.Text = dsPhoto.Tables(0).Rows(0)("Ordering").ToString

            cboGroupPhotoGallery.SelectedValue = dsPhoto.Tables(0).Rows(0)("GroupPhotoID").ToString
            hdGroupPhotoID.Value = dsPhoto.Tables(0).Rows(0)("GroupPhotoID").ToString

        End If

    End Sub

    'Private Sub LoadBannerDetail(ID As Integer, hdwebsite As String)
    '    Dim BalGl As New BalGlobal_app

    '    Dim dsBanner As DataSet = BalGl.getDataFromTable("tblCourse_CMS", "*", "ProgramID", "where ProgramID=" & ID, "asc")


    '    If dsBanner.Tables(0).Rows.Count > 0 Then

    '        txtProgramID.Text = dsBanner.Tables(0).Rows(0)("ProgramID").ToString

    '        txtTitle_Program.Text = dsBanner.Tables(0).Rows(0)("Name").ToString

    '        txtImage_Program.Text = dsBanner.Tables(0).Rows(0)("Image").ToString

    '        If dsBanner.Tables(0).Rows(0)("Visible").ToString = True Then
    '            cboVisible_Program.Text = "Yes"
    '        Else
    '            cboVisible_Program.Text = "No"
    '        End If


    '    End If
    'End Sub

    Private Sub LoadMenuDetail(ID As Integer, hdwebsite As String)
        Dim BalGl As New BalGlobal_app

        Dim dsMenu As DataSet = BalGl.getDataFromTable("tblMenu_App_CMS m left join tblArticle_CMS a on m.ArticleID=a.ArticleID ", "m.*,a.ArticleTitle,Isnull(a.Visible,0) as VisibleArticle,'" & hdwebsite & "?ArticleID=' + Convert(Varchar(10),Isnull(a.ArticleID,'')) as PostBackUrl", "MenuOrder", "where m.MenuID=" & ID, "asc")

        Dim match As Integer = 0
        If dsMenu.Tables(0).Rows.Count > 0 Then
            Dim MenuDetailString As String = ""
            MenuDetailString = "<table>"
            If dsMenu.Tables(0).Rows.Count > 0 Then
                txtMenuID.Text = dsMenu.Tables(0).Rows(0)("MenuID")
                txtMenuTitle.Text = dsMenu.Tables(0).Rows(0)("MenuName")
                If dsMenu.Tables(0).Rows(0)("Visible") = True Then
                    cboVisible.Text = "Yes"
                Else
                    cboVisible.Text = "No"
                End If

                txtOrdering.Text = dsMenu.Tables(0).Rows(0)("MenuOrder")

                If IsDBNull(dsMenu.Tables(0).Rows(0)("MenuParentID")) = True Then
                    cboParent.SelectedValue = dsMenu.Tables(0).Rows(0)("MenuID")
                ElseIf dsMenu.Tables(0).Rows(0)("MenuParentID") = 0 Then
                    cboParent.SelectedValue = dsMenu.Tables(0).Rows(0)("MenuID")
                Else
                    cboParent.SelectedValue = dsMenu.Tables(0).Rows(0)("MenuParentID")
                End If

                If IsDBNull(dsMenu.Tables(0).Rows(0)("ArticleTitle")) = True Then
                    txtArticle.Text = ""
                Else
                    txtArticle.Text = dsMenu.Tables(0).Rows(0)("ArticleTitle")
                End If

                If IsDBNull(dsMenu.Tables(0).Rows(0)("ArticleID")) = True Then
                    hdArticleID.Value = 0
                Else
                    hdArticleID.Value = dsMenu.Tables(0).Rows(0)("ArticleID")
                End If

                If IsDBNull(dsMenu.Tables(0).Rows(0)("MenuTop")) = True Then
                    cboMenutop.Text = "No"
                Else
                    If dsMenu.Tables(0).Rows(0)("MenuTop") = True Then
                        cboMenutop.Text = "Yes"
                    Else
                        cboMenutop.Text = "No"
                    End If

                End If


                If IsDBNull(dsMenu.Tables(0).Rows(0)("MenuName_KH")) = True Then
                    txtMenuTitle_KH.Text = ""
                Else
                    txtMenuTitle_KH.Text = dsMenu.Tables(0).Rows(0)("MenuName_KH").ToString
                End If

                txtImage_Menu.Text = dsMenu.Tables(0).Rows(0)("Image").ToString

            End If
        End If
    End Sub

    Private Sub LoadContentManagerDetail(ID As Integer, hdwebsite As String)
        Dim BalGl As New BalGlobal_app

        Dim dsArticle As DataSet = BalGl.getDataFromTable("tblArticle_CMS", "*", "ArticleID", "where ArticleID=" & ID, "asc")

        Dim match As Integer = 0
        If dsArticle.Tables(0).Rows.Count > 0 Then
            Dim MenuDetailString As String = ""
            MenuDetailString = "<table>"
            If dsArticle.Tables(0).Rows.Count > 0 Then
                txtArticleID.Text = dsArticle.Tables(0).Rows(0)("ArticleID")
                txtArticleTitle.Text = dsArticle.Tables(0).Rows(0)("ArticleTitle")

                If IsDBNull(dsArticle.Tables(0).Rows(0)("ArticleTitle_KH")) = True Then
                    txtArticle_Title_KH.Text = ""
                Else
                    txtArticle_Title_KH.Text = dsArticle.Tables(0).Rows(0)("ArticleTitle_KH")
                End If

                If IsDBNull(dsArticle.Tables(0).Rows(0)("ArticleBreadcrum")) = True Then
                    txtArticle_Breadcrum.Text = ""
                Else
                    txtArticle_Breadcrum.Text = dsArticle.Tables(0).Rows(0)("ArticleBreadcrum")
                End If


                If IsDBNull(dsArticle.Tables(0).Rows(0)("ArticleBreadcrum_KH")) = True Then
                    txtArticle_Breadcrum_KH.Text = ""
                Else
                    txtArticle_Breadcrum_KH.Text = dsArticle.Tables(0).Rows(0)("ArticleBreadcrum_KH")
                End If


                If dsArticle.Tables(0).Rows(0)("Visible") = True Then
                    cboVisible.Text = "Yes"
                Else
                    cboVisible.Text = "No"
                End If

                If IsDBNull(dsArticle.Tables(0).Rows(0)("ImageShare")) = True Then
                    txtImageShare_SubContent.Text = ""
                Else
                    txtImageShare_SubContent.Text = dsArticle.Tables(0).Rows(0)("ImageShare")
                End If


                If IsDBNull(dsArticle.Tables(0).Rows(0)("ArticleContent")) = True Then
                    Editor_ArticleContent.Text = ""
                Else
                    Editor_ArticleContent.Text = dsArticle.Tables(0).Rows(0)("ArticleContent")
                End If

                If IsDBNull(dsArticle.Tables(0).Rows(0)("ArticleContent_KH")) = True Then
                    Editor_ArticleContent_KH.Text = ""
                Else
                    Editor_ArticleContent_KH.Text = dsArticle.Tables(0).Rows(0)("ArticleContent_KH")
                End If

                txtFeedID.Text = dsArticle.Tables(0).Rows(0)("FeedID").ToString

            End If
        End If
    End Sub

    Private Sub LoadMenuParent()

        Dim BalGl As New BalGlobal_app

        Dim dsMenu As DataSet = BalGl.getDataFromTable("tblMenu_App_CMS", "*", "MenuName", "where deleted=0 and WebsiteID=1", "asc")

        cboParent.DataSource = dsMenu.Tables(0)
        cboParent.DataTextField = "MenuName"
        cboParent.DataValueField = "MenuID"
        cboParent.DataBind()

        cboParent.Items.Add("")
    End Sub

    Protected Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim DalMenu As New DalMenu_app

        Dim clMenu As New ClMenu_app

        clMenu = SetValueMenu()

        Dim result As Boolean

        If txtMenuID.Text <> "" Then
            result = DalMenu.UpdateMenu(clMenu)
        Else
            Dim NewMenuID As Integer = 0
            result = DalMenu.AddMenu(clMenu, NewMenuID)
            txtMenuID.Text = NewMenuID
        End If


        If result = False Then
            lblResult.Text = "Save successful."
        Else
            lblResult.Text = "Save not successful"
        End If


    End Sub

    Protected Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Response.Redirect("CMS_BackEnd.aspx?type=menu")
    End Sub

    Protected Sub cmdSave_Article_Click(sender As Object, e As EventArgs) Handles cmdSave_Article.Click
        Dim DalArticle As New DalArticle_app
        Dim ClArticle As New ClArticle_app

        ClArticle = SetValueArticle()

        Dim Result As Boolean
        If txtArticleID.Text = "" Then
            Dim NewArticleID As Integer = 0
            Result = DalArticle.AddArticle(ClArticle, NewArticleID)
            txtArticleID.Text = NewArticleID
        Else
            Result = DalArticle.UpdateArticle(ClArticle)
        End If

        If Result = False Then
            lblResult_Article.Text = "Save successful"
        Else
            lblResult_Article.Text = "Save not successful"
        End If

    End Sub

    Protected Sub cmdClose_Article_Click(sender As Object, e As EventArgs) Handles cmdClose_Article.Click
        Response.Redirect("CMS_BackEnd.aspx?type=content")
    End Sub

    Protected Sub cmdNew_Click(sender As Object, e As EventArgs) Handles cmdNew.Click

        ClearMenu()
        Response.Redirect("CMS_BackEnd.aspx?type=clearmenu")

    End Sub

    Function SetValueMenu() As ClMenu_app
        Dim ClMenu As New ClMenu_app

        ClMenu.WebsiteID = 1
        ClMenu.Comment = ""

        ClMenu.MenuName = txtMenuTitle.Text
        ClMenu.MenuOrder = txtOrdering.Text

        If cboVisible.Text = "Yes" Then
            ClMenu.MenuVisible = True
        Else
            ClMenu.MenuVisible = False
        End If

        If cboParent.SelectedValue = txtMenuID.Text Then
            ClMenu.MenuParentID = 0
            ClMenu.IsParent = True
        Else
            ClMenu.MenuParentID = 0
            ClMenu.IsParent = False
        End If

        If txtMenuID.Text = "" Then
            ClMenu.MenuID = 0
        Else
            ClMenu.MenuID = txtMenuID.Text
        End If

        If hdArticleID.Value = "" Then
            ClMenu.ArticleID = 0
        Else
            ClMenu.ArticleID = hdArticleID.Value
        End If

        ClMenu.MenuDeleted = False
        ClMenu.MenuName_KH = txtMenuTitle_KH.Text

        If cboMenutop.Text = "Yes" Then
            ClMenu.MenuTop = True
        Else
            ClMenu.MenuTop = False
        End If

        ClMenu.Image = txtImage_Menu.Text


        Return ClMenu

    End Function

    Sub ClearMenu()
        txtMenuID.Text = ""
        txtMenuTitle.Text = ""
        txtMenuTitle_KH.Text = ""

        txtArticle.Text = ""
        cboVisible.Text = "Yes"

        txtOrdering.Text = ""
        cboParent.Text = ""
        hdArticleID.Value = 0

        cboMenutop.Text = "No"

    End Sub

    Sub ClearArticle()
        txtArticleID.Text = ""
        txtArticleTitle.Text = ""
        txtArticle_Title_KH.Text = ""
        txtArticle_Breadcrum.Text = ""
        txtArticle_Breadcrum_KH.Text = ""
        Editor_ArticleContent.Text = ""
        Editor_ArticleContent_KH.Text = ""
        txtImageShare_SubContent.Text = ""
    End Sub

    Sub ClearProgram()
        'txtProgramID.Text = ""
        'txtTitle_Program.Text = ""
        'txtImage_Program.Text = ""
        'txtOrder_Banner.Text = ""
        'txtBoxText_Banner.Text = ""
        'txtLinkReadMore_Banner.Text = ""
        'hdArticleID_Banner.Value = ""
    End Sub

    Protected Sub cmdNewArticle_Click(sender As Object, e As EventArgs) Handles cmdNewArticle.Click
        ClearArticle()
    End Sub

    Function SetValueArticle() As ClArticle_app
        Dim clArticle As New ClArticle_app

        clArticle.ArticleTitle = txtArticleTitle.Text
        clArticle.ArticleTitle_KH = txtArticle_Title_KH.Text

        clArticle.Breadcrum = txtArticle_Breadcrum.Text
        clArticle.Breadcrum_KH = txtArticle_Breadcrum_KH.Text

        If cboVisible.Text = "Yes" Then
            clArticle.Visible = True
        Else
            clArticle.Visible = False
        End If

        clArticle.ArticleContent = Editor_ArticleContent.Text
        clArticle.ArticleContent_KH = Editor_ArticleContent_KH.Text

        If txtArticleID.Text = "" Then
            clArticle.ArticleID = 0
        Else
            clArticle.ArticleID = txtArticleID.Text
        End If

        If txtFeedID.Text = "" Then
            clArticle.FeedID = 0
        Else
            clArticle.FeedID = txtFeedID.Text
        End If

        clArticle.Comment = ""
        clArticle.Visitor = 0

        clArticle.WebsiteID = 1

        clArticle.ImageShare = txtImageShare_SubContent.Text

        Return clArticle
    End Function

    Sub LoadArticleGrid()
        Dim BalArticle As New BalGlobal_app
        Dim dsArticle As New DataSet
        dsArticle = BalArticle.getDataFromTable("tblArticle_CMS", "ArticleID,ArticleTitle, ArticleTitle_KH, Visible", "ArticleTitle", "where WebsiteID=1", "asc")

        GridView1.DataSourceID = ""
        GridView1.DataSource = dsArticle.Tables(0)
        GridView1.DataBind()

    End Sub


    Protected Sub cmdSelectArticle_Click(sender As Object, e As EventArgs) Handles cmdSelectArticle.Click

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Dim row As GridViewRow = GridView1.SelectedRow

        If Request.Url.ToString.Contains("menuid=") = True Then
            txtArticle.Text = Replace(row.Cells(2).Text, "&#39;", "'")
            hdArticleID.Value = row.Cells(1).Text
            'ElseIf Request.Url.ToString.Contains("programid=") = True Then
            'txtLinkReadMore_Banner.Text = Replace(row.Cells(2).Text, "&#39;", "'")
            'hdArticleID_Banner.Value = row.Cells(1).Text
        ElseIf Request.Url.ToString.Contains("photogalleryid=") = True Then
            txtLinkReadMore_PhotoGallery.Text = Replace(row.Cells(2).Text, "&#39;", "'")
            hdArticleID_PhotoGallery.Value = row.Cells(1).Text

        End If

    End Sub

    Protected Sub cmdNew_Item_Click(sender As Object, e As EventArgs) Handles cmdNew_Item.Click
        If cmdNew_Item.Text = "New Menu" Then
            ClearMenu()
            Response.Redirect("CMS_BackEnd.aspx?type=clearmenu")

        ElseIf cmdNew_Item.Text = "New Content" Then
            'ClearArticle()If txtProgramID.Text = "" Then
            Response.Redirect("CMS_BackEnd.aspx?type=cleararticle")

        ElseIf cmdNew_Item.Text = "New Photo" Then
            ClearPhotoGallery()
            Response.Redirect("CMS_BackEnd.aspx?type=clearphotogallery")

        ElseIf cmdNew_Item.Text = "New Program" Then
            ClearProgram()
            Response.Redirect("CMS_BackEnd.aspx?type=clearprogram")

        ElseIf cmdNew_Item.Text = "New Group" Then
            ClearGroupPhoto()
            Response.Redirect("CMS_BackEnd.aspx?type=cleargroupphoto")

        End If
    End Sub

    Sub ClearPhotoGallery()
        txtPhotoGalleryID.Text = ""
        txtTitle_PhotoGallery.Text = ""
        txtDescription.Text = ""
        txtImage_PhotoGallery.Text = ""
        txtLinkReadMore_PhotoGallery.Text = ""
        hdArticleID_PhotoGallery.Value = ""
        hdGroupPhotoID.Value = ""
        txtOrdering_PhotoGallery.Text = ""
    End Sub

    Protected Sub cmdDelete_Click(sender As Object, e As EventArgs) Handles cmdDelete.Click
        Dim balmenu As New BalGlobal_app
        Dim result As Boolean

        result = balmenu.UpdateRecordInTable("tblMenu_App_CMS", "Deleted=1", "Where MenuID=" & txtMenuID.Text)

        If result = False Then
            lblResult.Text = "Delete successful"
        Else
            lblResult.Text = "Delete not successful"
        End If

        Response.Redirect("CMS_BackEnd.aspx?type=menu")

    End Sub

    Protected Sub cmdDelete_Article_Click(sender As Object, e As EventArgs) Handles cmdDelete_Article.Click
        Dim balcontent As New BalGlobal_app
        Dim result As Boolean

        result = balcontent.UpdateRecordInTable("tblArticle_CMS", "Deleted=1", "Where ArticleID=" & txtArticleID.Text)

        If result = False Then
            lblResult.Text = "Delete successful"
            Response.Redirect("CMS_BackEnd.aspx?type=content")
        Else
            lblResult.Text = "Delete not successful"
        End If


    End Sub

    Protected Sub UploadFile(sender As Object, e As EventArgs) Handles btnUpload.Click
        Try

            'Dim fileUpload As FileUpload = form1.FindControl("FileUpload1")
            Dim test As String = FileUpload1.FileName


            If FileUpload1.HasFile = False Then
                'lblInfo.Text = "Please save record first, before upload a photo!"
                'lblInfo.ForeColor = Drawing.Color.Red
                Exit Sub
            Else
                FileUpload1.SaveAs(Server.MapPath("~/" & cboFolder.Text & "/" + FileUpload1.FileName))
                'Img.ImageUrl = "~/Uploads/" + fileUpload.FileName
                'lblInfo.Text = "Uploads/" + fileUpload.FileName
                'lblInfo.ForeColor = Drawing.Color.Blue
            End If

            'Dim fileName As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
            'FileUpload1.PostedFile.SaveAs((Server.MapPath("~/" & cboFolder.Text & "/") + fileName))
            'Response.Redirect(Request.Url.AbsoluteUri)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub DownloadFile(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim filePath As String = CType(sender, LinkButton).CommandArgument
            Response.ContentType = ContentType
            Response.AppendHeader("Content-Disposition", ("attachment; filename=" + Path.GetFileName(filePath)))
            Response.WriteFile(filePath)
            Response.End()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub DeleteFile(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim filePath As String = CType(sender, LinkButton).CommandArgument
            File.Delete(filePath)
            Response.Redirect(Request.Url.AbsoluteUri)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub GridView2_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView2.PageIndexChanging
        GridView2.DataSource = Session("fileds")
        GridView2.PageIndex = e.NewPageIndex
        GridView2.DataBind()
    End Sub

    Protected Sub GridView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView2.SelectedIndexChanged

    End Sub


    Protected Sub cboFolder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFolder.SelectedIndexChanged
        LoadFileName(cboFolder.Text)
    End Sub

    Protected Sub cmdSelectImage_subContent_Click(sender As Object, e As EventArgs) Handles cmdSelectImage_subContent.Click
        div_imageshare_subcontent.Visible = True
        LoadFileName2(cboFolder_Subcontent.Text, GridView5, "content")
    End Sub

    Protected Sub cboFolder_Subcontent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFolder_Subcontent.SelectedIndexChanged
        LoadFileName2(cboFolder_Subcontent.Text, GridView5, "content")
    End Sub

    Sub LoadFileName2(pathfolder As String, grd As GridView, SessionName As String)
        Dim filePaths() As String = Directory.GetFiles(Server.MapPath("~/" & pathfolder & "/"))
        Dim files As List(Of ListItem) = New List(Of ListItem)
        For Each filePath As String In filePaths
            files.Add(New ListItem(Path.GetFileName(filePath), filePath))
        Next
        grd.DataSource = files
        grd.DataBind()

        Session(SessionName) = files
    End Sub

    Protected Sub GridView5_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView5.PageIndexChanging
        GridView5.DataSource = Session("content_imageShare")
        GridView5.DataBind()
        GridView5.PageIndex = e.NewPageIndex
    End Sub

    Protected Sub GridView5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView5.SelectedIndexChanged
        Dim row As GridViewRow = GridView5.SelectedRow

        txtImageShare_SubContent.Text = cboFolder_Subcontent.Text & "\" & Replace(row.Cells(1).Text, "&#39;", "'")

        div_imageshare_subcontent.Visible = False
    End Sub





    Function SetValueProgram() As clProgram_CMS
        'Dim clProgram As New clProgram_CMS
        'If txtProgramID.Text = "" Then
        '    clProgram.ProgramID = 0
        'Else
        '    clProgram.ProgramID = txtProgramID.Text
        'End If

        'clProgram.Title = txtTitle_Program.Text

        'clProgram.Image = txtImage_Program.Text


        'If cboVisible_Program.Text = "Yes" Then
        '    clProgram.Visible = True
        'Else
        '    clProgram.Visible = False
        'End If

        'Return clProgram
    End Function


    'Protected Sub cmdSelectImage_Banner_Click(sender As Object, e As EventArgs) Handles cmdSelectImage_Program.Click
    '    div_image_Banner.Visible = True
    '    LoadFileName2(cboFolder_ImageProgram.Text, GridView7, "program")
    'End Sub

    'Protected Sub UploadFile7(sender As Object, e As EventArgs) Handles Button2.Click
    '    Try

    '        'Dim fileUpload As FileUpload = form1.FindControl("FileUpload1")
    '        Dim test As String = FileUpload7.FileName


    '        If FileUpload7.HasFile = False Then
    '            'lblInfo.Text = "Please save record first, before upload a photo!"
    '            'lblInfo.ForeColor = Drawing.Color.Red
    '            Exit Sub
    '        Else
    '            FileUpload7.SaveAs(Server.MapPath("~/" & cboFolder_ImageProgram.Text & "/" + FileUpload7.FileName))
    '            'Img.ImageUrl = "~/Uploads/" + fileUpload.FileName
    '            'lblInfo.Text = "Uploads/" + fileUpload.FileName
    '            'lblInfo.ForeColor = Drawing.Color.Blue
    '        End If

    '        'Dim fileName As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
    '        'FileUpload1.PostedFile.SaveAs((Server.MapPath("~/" & cboFolder.Text & "/") + fileName))
    '        'Response.Redirect(Request.Url.AbsoluteUri)
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Protected Sub UploadFile3(sender As Object, e As EventArgs) Handles Button3.Click, Button10.Click
        Try

            'Dim fileUpload As FileUpload = form1.FindControl("FileUpload1")
            Dim test As String = FileUpload3.FileName


            If FileUpload3.HasFile = False Then
                'lblInfo.Text = "Please save record first, before upload a photo!"
                'lblInfo.ForeColor = Drawing.Color.Red
                Exit Sub
            Else
                FileUpload3.SaveAs(Server.MapPath("~/" & cboFolder_Subcontent.Text & "/" + FileUpload3.FileName))
                'Img.ImageUrl = "~/Uploads/" + fileUpload.FileName
                'lblInfo.Text = "Uploads/" + fileUpload.FileName
                'lblInfo.ForeColor = Drawing.Color.Blue
            End If

            'Dim fileName As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
            'FileUpload1.PostedFile.SaveAs((Server.MapPath("~/" & cboFolder.Text & "/") + fileName))
            'Response.Redirect(Request.Url.AbsoluteUri)
        Catch ex As Exception

        End Try
    End Sub

    'Protected Sub GridView7_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView7.SelectedIndexChanged
    '    Dim row As GridViewRow = GridView7.SelectedRow

    '    txtImage_Program.Text = cboFolder_ImageProgram.Text & "\" & Replace(row.Cells(1).Text, "&#39;", "'")

    '    div_image_Banner.Visible = False
    'End Sub

    Protected Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Response.Redirect("CMS_BackEnd.aspx?type=photogallery")
    End Sub

    Protected Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim balcontent As New BalGlobal_app
        Dim result As Boolean

        If txtPhotoGalleryID.Text <> "" Then
            result = balcontent.UpdateRecordInTable("tblPhotoGallery", "Deleted=1", "Where PhotoID=" & txtPhotoGalleryID.Text)

            If result = False Then
                lblResult_PhotoGallery.Text = "Delete successful"
                Response.Redirect("CMS_BackEnd.aspx?type=photogallery")
            Else
                lblResult_PhotoGallery.Text = "Delete not successful"
            End If
        End If
    End Sub

    Function SetValuePhotoGallery() As ClPhotoGallery
        Dim clPhotoGallery As New ClPhotoGallery

        clPhotoGallery.Name = txtTitle_PhotoGallery.Text
        clPhotoGallery.Description = txtDescription.Text
        clPhotoGallery.Image = txtImage_PhotoGallery.Text

        If cboVisible_PhotoGallery.Text = "Yes" Then
            clPhotoGallery.Visible = True
        Else
            clPhotoGallery.Visible = False
        End If

        clPhotoGallery.GroupPhotoID = cboGroupPhotoGallery.SelectedValue

        clPhotoGallery.Link = txtLinkReadMore_PhotoGallery.Text

        If txtOrdering_PhotoGallery.Text = "" Then
            clPhotoGallery.Ordering = 0
        Else
            clPhotoGallery.Ordering = txtOrdering_PhotoGallery.Text
        End If

        If txtPhotoGalleryID.Text = "" Then
            clPhotoGallery.PhotoID = 0
        Else
            clPhotoGallery.PhotoID = txtPhotoGalleryID.Text
        End If

        Return clPhotoGallery
    End Function

    Protected Sub cmdSave_PhotoGallery_Click(sender As Object, e As EventArgs) Handles cmdSave_PhotoGallery.Click
        Dim DalPhotoGallery As New DalPhotoGallery_app
        Dim ClPhotoGallery As New ClPhotoGallery

        ClPhotoGallery = SetValuePhotoGallery()

        Dim Result As Boolean
        If txtPhotoGalleryID.Text = "" Then
            Dim NewPhotoGalleryID As Integer = 0
            Result = DalPhotoGallery.AddPhotoGallery(ClPhotoGallery, NewPhotoGalleryID)
            txtPhotoGalleryID.Text = NewPhotoGalleryID
        Else
            Result = DalPhotoGallery.UpdatePhotoGallery(ClPhotoGallery)
        End If

        If Result = False Then
            lblResult_PhotoGallery.Text = "Save successful"
        Else
            lblResult_PhotoGallery.Text = "Save not successful"
        End If
    End Sub

    Protected Sub cmdImage_PhotoGallery_Click(sender As Object, e As EventArgs) Handles cmdImage_PhotoGallery.Click
        div_image_photogallery.Visible = True
        LoadFileName2(cboFolder_PhotoGallery.Text, GridView8, "PhotoGallery")
    End Sub



    Protected Sub cboFolder_PhotoGallery_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFolder_PhotoGallery.SelectedIndexChanged
        LoadFileName2(cboFolder_PhotoGallery.Text, GridView8, "PhotoGallery")
    End Sub

    Protected Sub UploadFile8(sender As Object, e As EventArgs) Handles Button4.Click
        Try

            'Dim fileUpload As FileUpload = form1.FindControl("FileUpload1")
            Dim test As String = FileUpload8.FileName


            If FileUpload8.HasFile = False Then
                'lblInfo.Text = "Please save record first, before upload a photo!"
                'lblInfo.ForeColor = Drawing.Color.Red
                Exit Sub
            Else
                FileUpload8.SaveAs(Server.MapPath("~/" & cboFolder_PhotoGallery.Text & "/" + FileUpload8.FileName))
                'Img.ImageUrl = "~/Uploads/" + fileUpload.FileName
                'lblInfo.Text = "Uploads/" + fileUpload.FileName
                'lblInfo.ForeColor = Drawing.Color.Blue
            End If

            'Dim fileName As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
            'FileUpload1.PostedFile.SaveAs((Server.MapPath("~/" & cboFolder.Text & "/") + fileName))
            'Response.Redirect(Request.Url.AbsoluteUri)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub GridView8_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView8.SelectedIndexChanged
        Dim row As GridViewRow = GridView8.SelectedRow

        txtImage_PhotoGallery.Text = cboFolder_PhotoGallery.Text & "\" & Replace(row.Cells(1).Text, "&#39;", "'")

        div_image_photogallery.Visible = False
    End Sub

    Protected Sub cmdClose_GroupPhoto_Click(sender As Object, e As EventArgs) Handles cmdClose_GroupPhoto.Click
        Response.Redirect("CMS_BackEnd.aspx?type=groupphoto")
    End Sub

    Protected Sub cmdDelete_GroupPhoto_Click(sender As Object, e As EventArgs) Handles cmdDelete_GroupPhoto.Click
        Dim balcontent As New BalGlobal_app
        Dim result As Boolean

        If txtGroupPhotoID.Text <> "" Then
            result = balcontent.UpdateRecordInTable("tblGroupPhoto", "Deleted=1", "Where GroupPhotoID=" & txtGroupPhotoID.Text)

            If result = False Then
                lblResult_GroupPhoto.Text = "Delete successful"
                Response.Redirect("CMS_BackEnd.aspx?type=groupphoto")
            Else
                lblResult_GroupPhoto.Text = "Delete not successful"
            End If
        End If
    End Sub

    Protected Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ClearPhotoGallery()
        Response.Redirect("CMS_BackEnd.aspx?type=clearphotogallery")
    End Sub

    Protected Sub cmdNew_GroupPhoto_Click(sender As Object, e As EventArgs) Handles cmdNew_GroupPhoto.Click
        ClearGroupPhoto()
        Response.Redirect("CMS_BackEnd.aspx?type=cleargroupphoto")
    End Sub

    Sub ClearGroupPhoto()
        txtGroupPhotoID.Text = ""
        txtTitle_GroupPhoto.Text = ""
        txtImage_GroupPhoto.Text = ""
        txtOrdering_GroupPhoto.Text = ""
    End Sub

    Function SetValueGroupPhoto() As ClGroupPhoto_app
        Dim ClGroupPhoto As New ClGroupPhoto_app

        If txtGroupPhotoID.Text = "" Then
            ClGroupPhoto.GroupPhotoID = 0
        Else
            ClGroupPhoto.GroupPhotoID = txtGroupPhotoID.Text
        End If

        ClGroupPhoto.Name = txtTitle_GroupPhoto.Text
        ClGroupPhoto.Image = txtImage_GroupPhoto.Text

        If cboVisible_GroupPhoto.Text = "Yes" Then
            ClGroupPhoto.Visible = True
        Else
            ClGroupPhoto.Visible = False
        End If

        If txtOrdering_GroupPhoto.Text = "" Then
            ClGroupPhoto.Ordering = 0
        Else
            ClGroupPhoto.Ordering = txtOrdering_GroupPhoto.Text
        End If

        Return ClGroupPhoto
    End Function


    Protected Sub cmdSave_GroupPhoto_Click(sender As Object, e As EventArgs) Handles cmdSave_GroupPhoto.Click
        Dim DalGroupPhotoGallery As New DalGroupPhoto_app
        Dim ClGroupPhotoGallery As New ClGroupPhoto_app

        ClGroupPhotoGallery = SetValueGroupPhoto()

        Dim Result As Boolean
        If txtGroupPhotoID.Text = "" Then
            Dim NewGroupPhotoGalleryID As Integer = 0
            Result = DalGroupPhotoGallery.AddGroupPhoto(ClGroupPhotoGallery, NewGroupPhotoGalleryID)
            txtGroupPhotoID.Text = NewGroupPhotoGalleryID
        Else
            Result = DalGroupPhotoGallery.UpdateGroupPhoto(ClGroupPhotoGallery)
        End If

        If Result = False Then
            lblResult_GroupPhoto.Text = "Save successful"
        Else
            lblResult_GroupPhoto.Text = "Save not successful"
        End If
    End Sub

    Protected Sub UploadFile9(sender As Object, e As EventArgs) Handles Button7.Click
        Try


            Dim test As String = FileUpload9.FileName

            If FileUpload9.HasFile = False Then

                Exit Sub
            Else
                FileUpload9.SaveAs(Server.MapPath("~/" & cboFolder_GroupPhoto.Text & "/" + FileUpload9.FileName))

            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cmdSelectImage_GroupPhoto_Click(sender As Object, e As EventArgs) Handles cmdSelectImage_GroupPhoto.Click
        div_Image_GroupPhoto.Visible = True
        LoadFileName2(cboFolder_GroupPhoto.Text, GridView9, "GroupPhoto")
    End Sub

    Protected Sub GridView9_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView9.SelectedIndexChanged
        Dim row As GridViewRow = GridView9.SelectedRow

        txtImage_GroupPhoto.Text = cboFolder_GroupPhoto.Text & "\" & Replace(row.Cells(1).Text, "&#39;", "'")

        div_Image_GroupPhoto.Visible = False
    End Sub

    Protected Sub cboFolder_GroupPhoto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFolder_GroupPhoto.SelectedIndexChanged
        LoadFileName2(cboFolder_GroupPhoto.Text, GridView9, "GroupPhoto")
    End Sub

    'Protected Sub cmdSave_Program_Click(sender As Object, e As EventArgs) Handles cmdSave_Program.Click
    '    Dim DalProgram As New DalProgram_CMS_app
    '    Dim ClProgram As New clProgram_CMS

    '    ClProgram = SetValueProgram()

    '    Dim Result As Boolean
    '    If txtProgramID.Text = "" Then
    '        Dim NewProgramID As Integer = 0
    '        Result = DalProgram.AddProgram(ClProgram, NewProgramID)
    '        txtProgramID.Text = NewProgramID
    '    Else
    '        Result = DalProgram.UpdateProgram(ClProgram)
    '    End If

    '    If Result = False Then
    '        lblResult_Program.Text = "Save successful"
    '    Else
    '        lblResult_Program.Text = "Save not successful"
    '    End If
    'End Sub

    'Protected Sub cmdDelete_Program_Click(sender As Object, e As EventArgs) Handles cmdDelete_Program.Click
    '    Dim balcontent As New BalGlobal_app
    '    Dim result As Boolean

    '    If txtProgramID.Text <> "" Then
    '        result = balcontent.UpdateRecordInTable("tblCourse_CMS", "Deleted=1", "Where ProgramID=" & txtProgramID.Text)

    '        If result = False Then
    '            lblResult_Program.Text = "Delete successful"
    '            Response.Redirect("CMS_BackEnd.aspx?type=program")
    '        Else
    '            lblResult_Program.Text = "Delete not successful"
    '        End If
    '    End If
    'End Sub

    'Protected Sub cmdNew_Program_Click(sender As Object, e As EventArgs) Handles cmdNew_Program.Click
    '    ClearProgram()
    '    Response.Redirect("CMS_BackEnd.aspx?type=clearprogram")
    'End Sub

    'Protected Sub cmdClose_Program_Click(sender As Object, e As EventArgs) Handles cmdClose_Program.Click
    '    Response.Redirect("CMS_BackEnd.aspx?type=program")
    'End Sub

    'Protected Sub cboFolder_ImageProgram_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFolder_ImageProgram.SelectedIndexChanged
    '    LoadFileName2(cboFolder_ImageProgram.Text, GridView7, "Banner")
    'End Sub

    Protected Sub cmdSelectImage_Menu_Click(sender As Object, e As EventArgs) Handles cmdSelectImage_Menu.Click
        div_Image_Menu.Visible = True
        LoadFileName2(cboFolder_Menu.Text, grdMenu, "menu")
    End Sub

    Protected Sub cboFolder_Menu_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFolder_Menu.SelectedIndexChanged
        LoadFileName2(cboFolder_Menu.Text, grdMenu, "menu")
    End Sub

    Protected Sub UploadFile_Menu(sender As Object, e As EventArgs) Handles Button10.Click
        Try

            'Dim fileUpload As FileUpload = form1.FindControl("FileUpload1")
            Dim test As String = FileUpload_Menu.FileName


            If FileUpload_Menu.HasFile = False Then
                'lblInfo.Text = "Please save record first, before upload a photo!"
                'lblInfo.ForeColor = Drawing.Color.Red
                Exit Sub
            Else
                FileUpload_Menu.SaveAs(Server.MapPath("~/" & cboFolder_Menu.Text & "/" + FileUpload_Menu.FileName))
                'Img.ImageUrl = "~/Uploads/" + fileUpload.FileName
                'lblInfo.Text = "Uploads/" + fileUpload.FileName
                'lblInfo.ForeColor = Drawing.Color.Blue
            End If

            'Dim fileName As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
            'FileUpload1.PostedFile.SaveAs((Server.MapPath("~/" & cboFolder.Text & "/") + fileName))
            'Response.Redirect(Request.Url.AbsoluteUri)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub grdMenu_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdMenu.SelectedIndexChanged
        Dim row As GridViewRow = grdMenu.SelectedRow

        txtImage_Menu.Text = cboFolder_Menu.Text & "\" & Replace(row.Cells(1).Text, "&#39;", "'")

        div_Image_Menu.Visible = False
    End Sub

    Protected Sub refreshLstNoShow()
        Dim BalGl As New BalGlobal_app
        Dim dslstNoShow As New DataSet

        dslstNoShow = BalGl.getDataFromTable("tblTimetable", "MainFocusCode, RoomNo as Room, TitleOfPresentation as Title, format(Date, 'yyyy-MM-dd') as Date, Time", "Date, Time, Room", "where isCancelled=1", "asc")

        If dslstNoShow.Tables(0).Rows.Count > 0 Then
            lstNoShow.DataSource = dslstNoShow
            lstNoShow.DataBind()
        Else
            lstNoShow.DataSource = Nothing
        End If
    End Sub

    Protected Sub btnAddNoShow_Click(sender As Object, e As EventArgs) Handles btnAddNoShow.Click
        Dim code As String = txtMainFocusCode.Value.Trim
        If code <> "" Then
            DalTimetable.updateIsCancelled(code, 1)
            refreshLstNoShow()
        End If
    End Sub

    Protected Sub btnRemoveNoShow_Click(sender As Object, e As EventArgs) Handles btnRemoveNoShow.Click
        Dim code As String = txtMainFocusCode.Value.Trim
        If code <> "" Then
            DalTimetable.updateIsCancelled(code, 0)
            refreshLstNoShow()
        End If
    End Sub

    Protected Sub Button11_Click(sender As Object, e As System.EventArgs) Handles Button11.Click
        MultiView1.ActiveViewIndex = 1
        If txtFeedID.Text = "" OrElse txtFeedID.Text = "0" Then

        Else
            Dim BalGl As New BalGlobal_app

            Dim dsFeed As DataSet = BalGl.getDataFromTable("tblFeeds", "*", "FeedID", "where FeedID=" & txtFeedID.Text, "asc")
            txtFeedID0.Text = txtFeedID.Text
            txtFeedTitle.Text = dsFeed.Tables(0).Rows(0)("FeedTitle").ToString
            txtFeedCreatedBy.Text = dsFeed.Tables(0).Rows(0)("CreatedBy").ToString
            txtFeedPostDate.Text = CDate(dsFeed.Tables(0).Rows(0)("PostDate")).ToString("dd/MM/yyyy H:mm")


        End If
    End Sub

    Protected Sub Button13_Click(sender As Object, e As System.EventArgs) Handles Button13.Click
        If txtFeedTitle.Text = "" Then
            Exit Sub
        End If
        Dim DalArticle_app As New DalArticle_app
        If txtFeedID0.Text = "" OrElse txtFeedID0.Text = "0" Then
            Dim FeedID As Integer = DalArticle_app.AddFeed(txtFeedTitle.Text, Now, "")
            txtFeedID.Text = FeedID
            MultiView1.ActiveViewIndex = 0
        Else
            Dim BalGl As New BalGlobal_app
            BalGl.UpdateValueInTable("tblFeeds", "FeedTitle='" & txtFeedTitle.Text & "'", "Where FeedID=" & txtFeedID0.Text)
        End If
    End Sub

    Protected Sub Button12_Click(sender As Object, e As System.EventArgs) Handles Button12.Click
        Dim BalGl As New BalGlobal_app
        BalGl.DeleteFromTable("tblFeeds", "Where FeedID=" & txtFeedID0.Text)
        MultiView1.ActiveViewIndex = 0
    End Sub

    Protected Sub Button14_Click(sender As Object, e As System.EventArgs) Handles Button14.Click
        MultiView1.ActiveViewIndex = 0
    End Sub
End Class
