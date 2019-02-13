Imports System.Data
Imports System.IO
Imports System.Data.SqlClient

Partial Class Speaker
    Inherits System.Web.UI.Page

    Private Function getSpeaker(type As String) As DataTable
        Dim dtSpeaker As DataTable = DalSelect.selectQuery("select SpeakerID,SpeakerName,Position,RepresentBy,Photo from tblSpeaker where isnull(IsVisible,0)=1 and isnull(IsDeleted,0)=0 and SpeakerType='" & type & "' order by SpeakerOrder")
        Return dtSpeaker
    End Function

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Request.QueryString("SpeakerType") IsNot Nothing Then
                loadSpeaker(Request.QueryString("SpeakerType").ToString)
            End If
            If Request.QueryString("User") IsNot Nothing AndAlso Request.QueryString("DeviceID") IsNot Nothing Then
                    lblUserName.Text = DalUser.getUserByEmail(Request.QueryString("user")).givenName.ToString
                    Dim PresenterID As Integer = 0
                    If Request.QueryString("PresenterID") IsNot Nothing Then
                        PresenterID = Request.QueryString("PresenterID").ToString
                    End If
                    LoadMenu(Request.QueryString("user").ToString, Request.QueryString("deviceid").ToString, PresenterID)
                End If
        End If
    End Sub

    Private Sub loadSpeaker(type As String)
        Dim dtSpeaker As DataTable = getSpeaker(type)
        Dim speakerHtml As String = ""
        For Each dr As DataRow In dtSpeaker.Rows
            Dim photo As String = dr("Photo").ToString
            If String.IsNullOrEmpty(photo.Trim) OrElse Not File.Exists(Server.MapPath("~/" & dr("Photo").ToString)) Then
                photo = "Upload_s/No Photo.png"
            End If
            speakerHtml &= "<div class='divSpeakerBox' data-id='" & dr("SpeakerID").ToString & "' onclick='showSpeakerTopic(this);'><div class='speakerPhoto' style='background-image:url(" & photo & ")'></div><div class='fb'>" & dr("SpeakerName").ToString & "</div>"
            If Not String.IsNullOrEmpty(dr("Position").ToString) Then
                speakerHtml &= "<div class='fsm mt'>" & dr("Position").ToString & "</div>"
            End If
            If Not String.IsNullOrEmpty(dr("RepresentBy").ToString) Then
                speakerHtml &= "<div class='fsm mt'>" & dr("RepresentBy").ToString & "</div>"
            End If
            speakerHtml &= "<div style='clear: both;'></div></div>"
        Next
        speakerContainer.InnerHtml = speakerHtml
    End Sub

    Private Function getSpeakerTopic(speakerID As Integer) As DataTable
        Dim dtTopic As DataTable = DalSelect.selectQuery("select ConfType,Topic, Description from tblSpeakerTopic where isnull(IsVisible,0)=1 and isnull(IsDeleted,0)=0 and SpeakerID=" & speakerID)
        Return dtTopic
    End Function

    Protected Sub btnSpeakerTopic_Click(sender As Object, e As EventArgs)
        If Not String.IsNullOrEmpty(hidSpeakerID.Value) Then
            Dim dtSpeaker As DataTable = DalSelect.selectQuery("select SpeakerID, SpeakerName, Photo, Position,RepresentBy, SpeakerBio from tblSpeaker where SpeakerID=" & hidSpeakerID.Value)
            If dtSpeaker.Rows.Count < 1 Then Return
            Dim dtTopic As DataTable = getSpeakerTopic(dtSpeaker.Rows(0)("SpeakerID").ToString)
            Dim topicHtml As String = ""
            Dim photo As String = dtSpeaker.Rows(0)("Photo").ToString
            If String.IsNullOrEmpty(photo.Trim) OrElse Not File.Exists(Server.MapPath("~/" & dtSpeaker.Rows(0)("Photo").ToString)) Then
                photo = "Upload_s/No Photo.png"
            End If
            topicHtml &= "<div class='divSpeakerBox'><div class='speakerPhoto' style='background-image:url(" & photo & ")'></div><div class='speakerName'>" & dtSpeaker.Rows(0)("SpeakerName").ToString & "</div>"
            If Not String.IsNullOrEmpty(dtSpeaker.Rows(0)("Position").ToString) Then
                topicHtml &= "<div class='fsm mt'>" & dtSpeaker.Rows(0)("Position").ToString & "</div>"
            End If
            If Not String.IsNullOrEmpty(dtSpeaker.Rows(0)("RepresentBy").ToString) Then
                topicHtml &= "<div class='fsm mt'>" & dtSpeaker.Rows(0)("RepresentBy").ToString & "</div>"
            End If
            topicHtml &= "<div style='clear: both;'></div></div>"
            For Each dr As DataRow In dtTopic.Rows
                topicHtml &= "<div class='speakerTopicBox'>"
                If Not String.IsNullOrEmpty(dr("ConfType")) Then
                    topicHtml &= "<div class='gc fb'>" & dr("ConfType").ToString & "</div>"
                End If
                If Not String.IsNullOrEmpty(dr("Topic")) Then
                    topicHtml &= "<div class='fb mt'>" & dr("Topic").ToString & "</div>"
                End If
                If Not String.IsNullOrEmpty(dr("Description")) Then
                    topicHtml &= "<div class='mt'>" & dr("Description").ToString & "</div>"
                End If
                topicHtml &= "</div>"
            Next
            If Not String.IsNullOrEmpty(dtSpeaker.Rows(0)("SpeakerBio").ToString) Then
                topicHtml &= "<div class='speakerTopicBox'>" & dtSpeaker.Rows(0)("SpeakerBio").ToString & "</div>"
            End If
            popupBodySpeaker.InnerHtml = topicHtml
            ScriptManager.RegisterStartupScript(panelSpeaker, panelSpeaker.GetType, "showPopup", "showPopup('popupBoxSpeaker', 'popupPanelSpeaker');", True)
        End If
    End Sub
    Sub LoadMenu(email As String, deviceid As String, PresenterID As Integer)
        Dim BalGl As New BalGlobal_app

        Dim QueryStringPresenter As String = "&PresenterID=0"
        If PresenterID <> 0 Then
            QueryStringPresenter = "&PresenterID=" & PresenterID
        End If

        Dim dsRightBanner As DataSet
        If PresenterID <> 0 Then
            dsRightBanner = BalGl.getDataFromTable("tblMenu_App_CMS", "*", "MenuOrder", "where Isnull(Visible,0)=1 and Isnull(Deleted,0)=0 and MenuID<>8 and MenuID in (13,19,25,14)", "asc")
        Else
            dsRightBanner = BalGl.getDataFromTable("tblMenu_App_CMS", "*", "MenuOrder", "where Isnull(Visible,0)=1 and Isnull(Deleted,0)=0 and MenuID<>8 and isnull(forPresenter,0)=0 and MenuID in (13,19,25,14)", "asc")
        End If

        Dim dsuser As DataSet = GetUser("isnull(Admin,0) as Admin", "UserID", "where UserEmail='" & email & "'", "asc")
        If dsuser.Tables(0).Rows.Count > 0 Then
            Dim Admin As Boolean = dsuser.Tables(0).Rows(0)("Admin")
            If Admin = True Then
                'dsRightBanner = BalGl.getDataFromTable("tblMenu_App_CMS", "*", "MenuOrder", "where (Isnull(Visible,0)=1 and Isnull(Deleted,0)=0 and MenuID<>8) or MenuID=20 or MenuID=21", "asc")
                dsRightBanner = BalGl.getDataFromTable("tblMenu_App_CMS", "*", "MenuOrder", "where (Isnull(Visible,0)=1 and Isnull(Deleted,0)=0 and MenuID<>8)", "asc")
            End If
        End If

        Dim Code As String = ""
        Dim Code_enrol As String = ""
        Dim dv As DataView = dsRightBanner.Tables(0).DefaultView

        dv.RowFilter = "isParent=1"

        Dim dt1 As DataTable = dv.ToTable()
        Dim iconList As String = "<ul>"
        Dim iconListClass As String = ""
        Dim currentMenuID As String = Nothing
        If Request.QueryString("MenuID") IsNot Nothing Then
            currentMenuID = Request.QueryString("MenuID").ToString
        End If
        Dim bottomMenu As DataSet = BalGl.getDataFromTable("tblMenu_App_CMS", "*", "MenuOrder", "where Isnull(Visible,0)=1 and Isnull(Deleted,0)=0 and MenuID<>8", "asc")
        'Set hyperlinks for default Icons
        hrefHome.HRef = "eace.aspx?MenuID=0&ArticleID=0&user=" & email & "&deviceid=" & deviceid & QueryStringPresenter & "&Static=0"
        hrefBack.HRef = "eace.aspx?MenuID=0&ArticleID=0&user=" & email & "&deviceid=" & deviceid & QueryStringPresenter & "&Static=0"
        hrefPassword.HRef = "http://114.134.189.211:84/resetpwd?AppView&user=" & email & "&deviceid=" & deviceid & QueryStringPresenter & "&Static=0"
        'hrefAccommodation.HRef = "https://camtesol.org/Camtesol/2019%20Conference/Accommodation"
        Dim homeMenuHtml As New StringBuilder
        For i = 0 To dt1.Rows.Count - 1
            If currentMenuID = dt1.Rows(i)("MenuID").ToString Then
                iconListClass = "active"
            Else
                iconListClass = "scroll"
            End If

            Dim menu_name As String = dt1.Rows(i)("MenuName")
            Dim ImagePath As String = ""
            ImagePath = dt1.Rows(i)("Image").ToString
            ImagePath = ImagePath.Replace("\", "/")

            Dim static_page As String = ""
            If IsDBNull(dt1.Rows(i)("Static")) = True Then
                static_page = 1
            Else
                static_page = IIf(dt1.Rows(i)("Static") = True, 1, 0)
            End If

            iconList &= "<li><img width='30px' height='30px' src='" & ImagePath & "' style='float:left;'/><a href='eace.aspx?MenuID=" & dt1.Rows(i)("MenuID").ToString & "&ArticleID=" & dt1.Rows(i)("ArticleID").ToString & "&user=" & email & "&deviceid=" & deviceid & QueryStringPresenter & "&Static=" & static_page & "' class='" & iconListClass & "'>" & menu_name & "</a></li>"

            'hrefHome.HRef = "eace.aspx?MenuID=" & dt1.Rows(i)("MenuID").ToString & "&ArticleID=" & dt1.Rows(i)("ArticleID").ToString & "&user=" & email & "&deviceid=" & deviceid & QueryStringPresenter & "&Static=" & static_page

            'If dt1.Rows(i)("ArticleID") = 108 Then
            '    hrefAboutCamTESOL.HRef = "eace.aspx?MenuID=" & dt1.Rows(i)("MenuID").ToString & "&ArticleID=" & dt1.Rows(i)("ArticleID").ToString & "&user=" & email & "&deviceid=" & deviceid & QueryStringPresenter & "&Static=" & static_page
            'End If
            If dt1.Rows(i)("ArticleID") = 22 Then
                hrefNews.HRef = "/eace.aspx?MenuID=" & dt1.Rows(i)("MenuID").ToString & "&ArticleID=" & dt1.Rows(i)("ArticleID").ToString & "&user=" & email & "&deviceid=" & deviceid & QueryStringPresenter & "&Static=" & static_page
            End If
            If dt1.Rows(i)("ArticleID") = 66 Then
                hrefMyProfile.HRef = "/eace.aspx?MenuID=" & dt1.Rows(i)("MenuID").ToString & "&ArticleID=" & dt1.Rows(i)("ArticleID").ToString & "&user=" & email & "&deviceid=" & deviceid & QueryStringPresenter & "&Static=" & static_page
            End If
            If dt1.Rows(i)("ArticleID") = 68 Then
                hrefPresentation.HRef = "/eace.aspx?MenuID=" & dt1.Rows(i)("MenuID").ToString & "&ArticleID=" & dt1.Rows(i)("ArticleID").ToString & "&user=" & email & "&deviceid=" & deviceid & QueryStringPresenter & "&Static=" & static_page
            End If
            If dt1.Rows(i)("ArticleID") = 110 Then
                hrefSchedule.HRef = "/eace.aspx?MenuID=" & dt1.Rows(i)("MenuID").ToString & "&ArticleID=" & dt1.Rows(i)("ArticleID").ToString & "&user=" & email & "&deviceid=" & deviceid & QueryStringPresenter & "&Static=" & static_page
            End If
            'If dt1.Rows(i)("ArticleID") = 106 Then
            '    hrefRegistration.HRef = "eace.aspx?MenuID=" & dt1.Rows(i)("MenuID").ToString & "&ArticleID=" & dt1.Rows(i)("ArticleID").ToString & "&user=" & email & "&deviceid=" & deviceid & QueryStringPresenter & "&Static=" & static_page
            'End If
            If dt1.Rows(i)("ArticleID") = 0 Then
                hrefLogOut.HRef = "/eace.aspx?MenuID=" & dt1.Rows(i)("MenuID").ToString & "&ArticleID=" & dt1.Rows(i)("ArticleID").ToString & "&user=" & email & "&deviceid=" & deviceid & QueryStringPresenter & "&Static=" & static_page
            End If
            If dt1.Rows(i)("ArticleID") = 56 Then
                'hrefProgram.HRef = "/eace.aspx?MenuID=" & dt1.Rows(i)("MenuID").ToString & "&ArticleID=" & dt1.Rows(i)("ArticleID").ToString & "&user=" & email & "&deviceid=" & deviceid & QueryStringPresenter & "&Static=" & static_page
                hrefProgram.HRef = "/eace.aspx?MenuID=0&ArticleID=109&user=" & email & "&deviceid=" & deviceid & QueryStringPresenter & "&Static=" & static_page
            End If

            'If dt1.Rows(i)("ArticleID") = 109 Then
            '    hrefPlenarySpeaker.HRef = "eace.aspx?MenuID=" & dt1.Rows(i)("MenuID").ToString & "&ArticleID=" & dt1.Rows(i)("ArticleID").ToString & "&user=" & email & "&deviceid=" & deviceid & QueryStringPresenter & "&Static=" & static_page
            'End If
            'If dt1.Rows(i)("ArticleID") = 11 Then
            '    hrefVenue.HRef = "eace.aspx?MenuID=" & dt1.Rows(i)("MenuID").ToString & "&ArticleID=" & dt1.Rows(i)("ArticleID").ToString & "&user=" & email & "&deviceid=" & deviceid & QueryStringPresenter & "&Static=" & static_page
            'End If
            'If dt1.Rows(i)("ArticleID") = 20 Then
            '    hrefContactUs.HRef = "eace.aspx?MenuID=" & dt1.Rows(i)("MenuID").ToString & "&ArticleID=" & dt1.Rows(i)("ArticleID").ToString & "&user=" & email & "&deviceid=" & deviceid & QueryStringPresenter & "&Static=" & static_page
            'End If
            'If dt1.Rows(i)("ArticleID") = 105 Then
            '    hrefSponsor.HRef = "eace.aspx?MenuID=" & dt1.Rows(i)("MenuID").ToString & "&ArticleID=" & dt1.Rows(i)("ArticleID").ToString & "&user=" & email & "&deviceid=" & deviceid & QueryStringPresenter & "&Static=" & static_page
            'End If

            '--------Set Home Links-----------
            'homeMenuHtml.Append("<div id='divHome' style='margin-top: 35px;'>")
            'homeMenuHtml.Append("<div style='margin:auto;max-width: 470px;text-align: center;'>")
            'homeMenuHtml.Append("<div>")
            'homeMenuHtml.Append("<div>")
            'homeMenuHtml.Append("</div>")
            '--------End Home Links-----------

            If i Mod 2 = 0 Then

                'If dt1.Rows(i)("MenuName") = "Map" Then
                '    Code = Code + "<div class='div_menu_with_4'><div class='divprevious_issue_middle'>" & _
                '    "<img data-toggle='modal' data-target='#myModal' src='" & ImagePath & "' style='width:100%' class='magazine-image' />" & _
                '    "</div>"
                'Else
                Code = Code + "<div class='div_menu_with_4'><div class='divprevious_issue_middle'><a href ='eace.aspx?MenuID=" & dt1.Rows(i)("MenuID").ToString & "&ArticleID=" & dt1.Rows(i)("ArticleID").ToString & "&user=" & email & "&deviceid=" & deviceid & QueryStringPresenter & "&Static=" & static_page & "'>" & _
                "" & _
                "<img src='" & ImagePath & "' style='width:100%' class='magazine-image' /></a>" & _
                "</div>"
                'End If
            Else

                'If dt1.Rows(i)("MenuName") = "Map" Then
                '    Code = Code + "<div class='divprevious_issue_begin'>" & _
                '    "<img data-toggle='modal' data-target='#myModal' src='" & ImagePath & "' style='width:100%' class='magazine-image' />" & _
                '    "</div></div>"
                'Else
                Code = Code + "<div class='divprevious_issue_begin'><a href ='eace.aspx?MenuID=" & dt1.Rows(i)("MenuID").ToString & "&ArticleID=" & dt1.Rows(i)("ArticleID") & "&user=" & ID & "&deviceid=" & deviceid & QueryStringPresenter & "&Static=" & static_page & "'>" & _
                "<img src='" & ImagePath & "' style='width:100%' class='magazine-image' /></a>" & _
                "</div></div>"

                'End If


            End If
        Next
        If Request.QueryString("deviceID") IsNot Nothing AndAlso Request.QueryString("user") IsNot Nothing Then
            Dim dsu As DataSet = GetUser("UserID", "UserID", "where UserEmail='" & Request.QueryString("user").ToString & "'", "asc")
            If dsu.Tables(0).Rows.Count > 0 Then
                Dim query As String = "?DeviceID=" & Request.QueryString("DeviceID").ToString & "&user=" & Request.QueryString("user").ToString
                If Request.QueryString("PresenterID") IsNot Nothing Then query &= "&PresenterID=" & Request.QueryString("PresenterID").ToString
                query &= "&UserID=" & dsu.Tables(0).Rows(0)("UserID")
                hrefProgram.HRef = "/program.aspx" & query
            End If
        End If
        iconList &= "</ul>"
        'icon_List.InnerHtml = iconList
        'dv.RowFilter = "isParent=0"

        'Dim dt2 As DataTable = dv.ToTable()
        'Code_enrol = "<table><tr><td>" & _
        '             "<a href ='eace.aspx?MenuID=" & dt2.Rows(0)("MenuID").ToString & "&ArticleID=" & dt2.Rows(0)("ArticleID") & "'>" & _
        '             "<img src='" & dt2.Rows(0)("Image").Replace("\", "/") & "' style='width:100%' /></a>" & _
        '             "</td>" & _
        '             "<td>" & _
        '             "<a href ='eace.aspx?MenuID=" & dt2.Rows(1)("MenuID").ToString & "&ArticleID=" & dt2.Rows(1)("ArticleID") & "'>" & _
        '             "<img src='" & dt2.Rows(1)("Image").Replace("\", "/") & "' style='width:100%' /></a></td>" & _
        '             "</tr></table>"

        'div_popup_enrolment.InnerHtml = Code_enrol

        'divmenu.InnerHtml = Code
        'LoadProfileButton()

    End Sub

    'Sub LoadMenu(email As String, deviceid As String, PresenterID As Integer)
    '    Dim QueryStringPresenter As String = "&PresenterID=0"
    '    If PresenterID <> 0 Then
    '        QueryStringPresenter = "&PresenterID=" & PresenterID
    '    End If

    '    Dim dsRightBanner As DataTable
    '    If PresenterID <> 0 Then
    '        dsRightBanner = DalSelect.selectQuery("select * from tblMenu_App_CMS where Isnull(Visible,0)=1 and Isnull(Deleted,0)=0 and MenuID<>8 order by MenuOrder")
    '    Else
    '        dsRightBanner = DalSelect.selectQuery("select * from tblMenu_App_CMS where Isnull(Visible,0)=1 and Isnull(Deleted,0)=0 and MenuID<>8 and isnull(forPresenter,0)=0 order by MenuOrder")
    '    End If

    '    Dim dsuser As DataSet = GetUser("isnull(Admin,0) as Admin", "UserID", "where UserEmail='" & email & "'", "asc")
    '    If dsuser.Tables(0).Rows.Count > 0 Then
    '        Dim Admin As Boolean = dsuser.Tables(0).Rows(0)("Admin")
    '        If Admin = True Then
    '            dsRightBanner = DalSelect.selectQuery("select * from tblMenu_App_CMS where (Isnull(Visible,0)=1 and Isnull(Deleted,0)=0 and MenuID<>8) or MenuID=20 or MenuID=21 order by MenuOrder")
    '        End If
    '    End If

    '    Dim Code As String = ""
    '    Dim Code_enrol As String = ""
    '    Dim dv As DataView = dsRightBanner.DefaultView

    '    dv.RowFilter = "isParent=1"

    '    Dim dt1 As DataTable = dv.ToTable()
    '    Dim iconList As String = "<ul style='margin-top:0;padding:0'>"
    '    Dim iconListClass As String = ""
    '    Dim currentMenuID As String = Nothing
    '    If Request.QueryString("MenuID") IsNot Nothing Then
    '        currentMenuID = Request.QueryString("MenuID").ToString
    '    End If

    '    For i = 0 To dt1.Rows.Count - 1

    '        If currentMenuID = dt1.Rows(i)("MenuID").ToString Then
    '            iconListClass = "active"
    '        Else
    '            iconListClass = "scroll"
    '        End If

    '        Dim menu_name As String = dt1.Rows(i)("MenuName")
    '        Dim ImagePath As String = "https://camtesol.org/"
    '        ImagePath &= dt1.Rows(i)("Image").ToString
    '        ImagePath = ImagePath.Replace("\", "/")

    '        Dim static_page As String = ""
    '        If IsDBNull(dt1.Rows(i)("Static")) = True Then
    '            static_page = 1
    '        Else
    '            static_page = IIf(dt1.Rows(i)("Static") = True, 1, 0)
    '        End If

    '        iconList &= "<li><img width='30px' height='30px' src='" & ImagePath & "' style='float:left;'/><a href='http://camtesolapp.acecambodia.org/eace.aspx?MenuID=" & dt1.Rows(i)("MenuID").ToString & "&ArticleID=" & dt1.Rows(i)("ArticleID").ToString & "&user=" & email & "&deviceid=" & deviceid & QueryStringPresenter & "&Static=" & static_page & "' class='" & iconListClass & "'>" & menu_name & "</a></li>"

    '        If i Mod 2 = 0 Then

    '            'If dt1.Rows(i)("MenuName") = "Map" Then
    '            '    Code = Code + "<div class='div_menu_with_4'><div class='divprevious_issue_middle'>" & _
    '            '    "<img data-toggle='modal' data-target='#myModal' src='" & ImagePath & "' style='width:100%' class='magazine-image' />" & _
    '            '    "</div>"
    '            'Else
    '            Code = Code + "<div class='div_menu_with_4'><div class='divprevious_issue_middle'><a href ='http://camtesolapp.acecambodia.org/eace.aspx?MenuID=" & dt1.Rows(i)("MenuID").ToString & "&ArticleID=" & dt1.Rows(i)("ArticleID").ToString & "&user=" & email & "&deviceid=" & deviceid & QueryStringPresenter & "&Static=" & static_page & "'>" & _
    '            "" & _
    '            "<img src='" & ImagePath & "' style='width:100%' class='magazine-image' /></a>" & _
    '            "</div>"
    '            'End If
    '        Else

    '            'If dt1.Rows(i)("MenuName") = "Map" Then
    '            '    Code = Code + "<div class='divprevious_issue_begin'>" & _
    '            '    "<img data-toggle='modal' data-target='#myModal' src='" & ImagePath & "' style='width:100%' class='magazine-image' />" & _
    '            '    "</div></div>"
    '            'Else
    '            Code = Code + "<div class='divprevious_issue_begin'><a href ='http://camtesolapp.acecambodia.org/eace.aspx?MenuID=" & dt1.Rows(i)("MenuID").ToString & "&ArticleID=" & dt1.Rows(i)("ArticleID") & "&user=" & ID & "&deviceid=" & deviceid & QueryStringPresenter & "&Static=" & static_page & "'>" & _
    '            "<img src='" & ImagePath & "' style='width:100%' class='magazine-image' /></a>" & _
    '            "</div></div>"

    '            'End If


    '        End If
    '    Next

    '    iconList &= "</ul>"
    '    icon_List.InnerHtml = iconList
    'End Sub
    Private Function GetUser(ByVal DisplayFields As String, ByVal SortField As String, ByVal Condition As String, ByVal SortOrder As String) As DataSet

        Dim ds As New DataSet
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim adapter As New SqlDataAdapter
        cn.ConnectionString = "server=114.134.189.211;database=CamTESOL;uid=sa;pwd=ACEidp.99"

        cn.Open()
        cmd.CommandText = "SELECT " & DisplayFields & " FROM tblUserLogin " & Condition & " ORDER BY " & SortField & " " & SortOrder

        cmd.CommandType = CommandType.Text
        cmd.Connection = cn
        adapter.SelectCommand = cmd
        'fill the dataset
        adapter.Fill(ds)
        cn.Close()
        'return the dataset
        Return ds
    End Function
End Class
