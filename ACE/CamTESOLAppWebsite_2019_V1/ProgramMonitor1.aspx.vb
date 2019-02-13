Imports System.Data
Imports System.Data.SqlClient

Partial Class Program
    Inherits System.Web.UI.Page

    Protected Sub lnkSaturday_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub lnkFriday_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub lnkSunday_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnPopupInfo_Click(sender As Object, e As EventArgs)

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
        'If Request.QueryString("deviceID") IsNot Nothing AndAlso Request.QueryString("user") IsNot Nothing Then
        '    Dim dsu As DataSet = GetUser("UserID", "UserID", "where UserEmail='" & Request.QueryString("user").ToString & "'", "asc")
        '    If dsu.Tables(0).Rows.Count > 0 Then
        '        Dim query As String = "?DeviceID=" & Request.QueryString("DeviceID").ToString & "&user=" & Request.QueryString("user").ToString
        '        If Request.QueryString("PresenterID") IsNot Nothing Then query &= "&PresenterID=" & Request.QueryString("PresenterID").ToString
        '        query &= "&UserID=" & dsu.Tables(0).Rows(0)("UserID")
        '        hrefProgram.Href = "program.aspx" & query
        '    End If
        'End If
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
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Request.QueryString("User") IsNot Nothing AndAlso Request.QueryString("DeviceID") IsNot Nothing Then
                lblUserName.Text = DalUser.getUserByEmail(Request.QueryString("user")).givenName.ToString
                Dim PresenterID As Integer = 0
                If Request.QueryString("PresenterID") IsNot Nothing Then
                    PresenterID = Request.QueryString("PresenterID").ToString
                End If
                LoadMenu(Request.QueryString("user").ToString, Request.QueryString("deviceid").ToString, PresenterID)
                imgNews.Style.Add("background", "#fff")
                imgProgram.Style.Add("background", "#72ccf7")
                imgHome.Style.Add("background", "#fff")
            End If
            If Session("confDayActive") Is Nothing Then
            Else
                If Session("conferenceType") IsNot Nothing Then
                    hidConferenceType.Value = Session("conferenceType")
                    Session.Remove("conferenceType")
                End If
                If Session("confDayActive") IsNot Nothing Then
                    hidConfDayActive.Value = Session("confDayActive")
                    Session.Remove("confDayActive")
                End If
                If Session("timeBoxActive") IsNot Nothing Then
                    hidTimeBoxActive.Value = Session("timeBoxActive")
                    Session.Remove("timeBoxActive")
                End If
                If Session("programScrollTop") IsNot Nothing Then
                    hidProgramContainerVPos.Value = Session("programScrollTop")
                    Session.Remove("programScrollTop")
                End If
                If Session("searchKeyword") IsNot Nothing Then
                    txtSearch.Text = Session("searchKeyword")
                    Session.Remove("searchKeyword")
                End If
                If Session("searchConfDay") IsNot Nothing Then
                    ddlConfDay.SelectedIndex = Session("searchConfDay")
                    Session.Remove("searchConfDay")
                End If
                bindDdlConfDay()
                bindDdlStream()
                If ddlConfDay.SelectedIndex = 0 AndAlso hidConferenceType.Value = "MC" Then
                    bindDdlConfTime()
                Else
                    bindDdlConfTime(ddlConfDay.SelectedValue)
                End If
                If Session("searchConfTime") IsNot Nothing Then
                    ddlConfTime.SelectedIndex = Session("searchConfTime")
                    Session.Remove("searchConfTime")
                End If
                If Session("searchStream") IsNot Nothing Then
                    ddlStream.SelectedIndex = Session("searchStream")
                    Session.Remove("searchStream")
                End If
                If Session("searchBookmark") IsNot Nothing Then
                    If Session("searchBookmark") = "True" Then
                        chkOnlyBookmark.Checked = True
                    Else
                        chkOnlyBookmark.Checked = False
                    End If
                    Session.Remove("searchBookmark")
                End If
                If hidConferenceType.Value = "RS" Then
                    lnkSaturday.Visible = False : lnkSunday.Visible = False : lnkFriday.Visible = True
                    lnkSaturday.CssClass = "dateBoxHeader" : lnkSunday.CssClass = "dateBoxHeader"
                    lnkFriday.CssClass = "dateBoxHeader dateBoxHeaderActive"
                Else
                    lnkFriday.Visible = False : lnkSaturday.Visible = True : lnkSunday.Visible = True
                    lnkSaturday.CssClass = "dateBoxHeader dateBoxHeaderActive"
                    lnkFriday.CssClass = "dateBoxHeader" : lnkSunday.CssClass = "dateBoxHeader"
                End If
                searchProgram()
                mulViewMain.SetActiveView(viewProgram)
                ScriptManager.RegisterStartupScript(panelProgram, panelProgram.GetType, "scrollProgram", "$('#" & divProgramContainer.ClientID & "').scrollLeft(" & hidConfDayActive.Value & " * $('#" & divProgramContainer.ClientID & "').width());", True)
                ScriptManager.RegisterStartupScript(panelProgram, panelProgram.GetType, "timeBoxActive", "$('.programContainer').eq(" & hidConfDayActive.Value & ").children('.programTimeBox[data-no=""" & hidTimeBoxActive.Value & """]').children('.programBoxLink').css('display', 'block');", True)
                ScriptManager.RegisterStartupScript(panelProgram, panelProgram.GetType, "setScrollPos", "$('.programContainer').eq($('#" & hidConfDayActive.ClientID & "').val()).scrollTop($('#" & hidProgramContainerVPos.ClientID & "').val());", True)
            End If
        Else
            If hidPopupBoxSearch.Value = "1" Then
                popupPanel.Style("display") = "block"
                popupBoxSearch.Style("display") = "block"
                hidPopupPostBack.Value = "1"
            Else
                popupPanel.Style("display") = "none"
                popupBoxSearch.Style("display") = "none"
                hidPopupPostBack.Value = "0"
            End If
            If hidConfDayActive.Value = "0" Then
                If hidConferenceType.Value = "RS" Then
                    lnkFriday.CssClass = "dateBoxHeader dateBoxHeaderActive"
                    lnkSaturday.CssClass = "dateBoxHeader"
                    lnkSunday.CssClass = "dateBoxHeader"
                Else
                    lnkFriday.CssClass = "dateBoxHeader"
                    lnkSaturday.CssClass = "dateBoxHeader dateBoxHeaderActive"
                    lnkSunday.CssClass = "dateBoxHeader"
                End If
            ElseIf hidConfDayActive.Value = "1" Then
                lnkFriday.CssClass = "dateBoxHeader"
                lnkSaturday.CssClass = "dateBoxHeader"
                lnkSunday.CssClass = "dateBoxHeader dateBoxHeaderActive"
            End If

            If hidReload.Value = "1" Then
                txtSearch.Text = ""
                If ddlConfDay.SelectedIndex <> 0 Then
                    ddlConfDay.SelectedIndex = 0
                    bindDdlConfTime()
                Else
                    If ddlConfTime.SelectedIndex <> 0 Then
                        ddlConfTime.SelectedIndex = 0
                    End If
                End If
                If ddlStream.SelectedIndex <> 0 Then
                    ddlStream.SelectedIndex = 0
                End If
                chkOnlyBookmark.Checked = False
                hidReload.Value = "0"
                searchProgram()
            End If
            'searchAllProgramByTime()
            ScriptManager.RegisterStartupScript(panelProgram, panelProgram.GetType, "scrollProgram", "$(document).ready(function(){scrollProgram(" & hidConfDayActive.Value & ");timeBoxActive(" & hidConfDayActive.Value & ", " & hidTimeBoxActive.Value & ");setScrollPos();});", True)
        End If
    End Sub

    Protected Sub Page_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete
        mainContainer.Style("visibility") = "visible"
    End Sub

    Private Function getProgram(confDay As String, Optional confTime As String = "", Optional stream As String = "", Optional search As String = "") As DataTable
        Dim selectedField As String = "a.TitleOfPresentation, a.FocusArea1, d.RoomNumber, s.SessionID, s.SessionTime, d.SessionID, d.PresentationID, a.Combine_Speakers, isnull(a.IsCancel,0) as IsCancel"
        Dim condition As String = "where a.AbstractStatus='Registered' and d.PresentationID<>0 and d.IsEmpty=0 and s.SessionDate='" & confDay & "'"
        If Not String.IsNullOrEmpty(confTime) Then condition &= " and s.SessionTime='" & confTime & "'"
        If Not String.IsNullOrEmpty(stream) Then condition &= " and a.FocusArea1='" & stream & "'"
        If Not String.IsNullOrEmpty(search) Then condition &= " and (Combine_Speakers like '%" & search & "%' or TitleOfPresentation like '%" & search & "%')"

        Return DalSelectCamTESOL.selectQuery("select " & selectedField & " from tblCamTESOLConferenceProgram_SessionDetail d inner join tblCamTESOLConferenceProgram_Session s on d.SessionID=s.SessionID inner join tblCamTESOLConferenceProgram_Room r on r.RoomID=d.RoomID inner join tblCamTESOLConferenceProgram_AbstractDetail a on a.PresentationID=d.PresentationID " & condition & " order by s.SessionNo, r.RoomOrder")
    End Function

    Private Function getAllProgramByTime(confDay As String, Optional confTime As String = "", Optional stream As String = "", Optional search As String = "") As DataTable
        Dim selectedField As String = "a.TitleOfPresentation, a.FocusArea1, d.RoomNumber, s.SessionID, s.SessionTime, d.SessionID, d.PresentationID, a.Combine_Speakers, isnull(a.IsCancel,0) as IsCancel"
        Dim condition As String = "where a.AbstractStatus='Registered' and d.PresentationID<>0 and d.IsEmpty=0 "
        'and s.SessionDate='" & confDay & "'"
        ' If Not String.IsNullOrEmpty(confTime) Then condition &= " and s.SessionTime='" & confTime & "'"
        ' If Not String.IsNullOrEmpty(stream) Then condition &= " and a.FocusArea1='" & stream & "'"
        ' If Not String.IsNullOrEmpty(search) Then condition &= " and (Combine_Speakers like '%" & search & "%' or TitleOfPresentation like '%" & search & "%')"

        Return DalSelectCamTESOL.selectQuery("select " & selectedField & " from tblCamTESOLConferenceProgram_SessionDetail d inner join tblCamTESOLConferenceProgram_Session s on d.SessionID=s.SessionID inner join tblCamTESOLConferenceProgram_Room r on r.RoomID=d.RoomID inner join tblCamTESOLConferenceProgram_AbstractDetail a on a.PresentationID=d.PresentationID " & condition & " order by s.SessionNo, r.RoomOrder")
    End Function

    Private Function getProgramPoster(Optional stream As String = "", Optional search As String = "") As DataTable
        Dim selectedField As String = "a.TitleOfPresentation, a.FocusArea1, 'Building A' as RoomNumber, '15:25-17:05' as SessionTime, '-1' as SessionID, a.PresentationID, a.Combine_Speakers, isnull(a.IsCancel,0) as IsCancel"
        Dim condition As String = "where a.AbstractStatus='Registered' and PreferenceTypeOfSession like '%poster%' and [Conference Type]='Main Conf'"
        If Not String.IsNullOrEmpty(stream) Then condition &= " and a.FocusArea1='" & stream & "'"
        If Not String.IsNullOrEmpty(search) Then condition &= " and (Combine_Speakers like '%" & search & "%' or TitleOfPresentation like '%" & search & "%')"

        Return DalSelectCamTESOL.selectQuery("select " & selectedField & " from tblCamTESOLConferenceProgram_AbstractDetail a " & condition & " order by StreamCodeSortLetter, StreamCodeSortNo")
    End Function
    Private Function getAllProgramHTMLByTime(confDay As String, confDayNo As Integer, lstBookmark As List(Of Integer), lstFeatured As List(Of Integer), Optional showOnlyBookmark As Boolean = False, Optional confTime As String = "", Optional stream As String = "", Optional search As String = "") As String
        Dim dtProgram As DataTable = getAllProgramByTime(confDay, confTime, stream, search)
        Dim programHTML As String = "<div class='all-program-by-time' style='left: " & 100 * confDayNo & "%'>"
        Dim programTime As String = "", programTimeBoxNo As Integer = -1, bookmarkCSS As String = ""


        If showOnlyBookmark Then
            Dim hasBookmark As Boolean = False
            For Each drProgram As DataRow In dtProgram.Rows
                If lstBookmark.Contains(drProgram("PresentationID").ToString) Then
                    hasBookmark = True
                    If programTime <> drProgram("SessionTime").ToString Then
                        If Not String.IsNullOrEmpty(programTime) Then programHTML &= "</div></div>"
                        programTimeBoxNo += 1
                        programTime = drProgram("SessionTime").ToString
                        Dim featuredText As String = ""
                        If lstFeatured.Contains(drProgram("SessionID").ToString) Then featuredText = "<span class='featuredText'>Featured Session Available</span>"
                        programHTML &= "<div class='programTimeBox' data-no='" & programTimeBoxNo & "'><p class='programTime'><span class='timeIcon'></span><span class='timeValue'>" & programTime & "</span>" & featuredText & "</p><div class='programBoxLink'>"
                    End If
                    If lstBookmark.Contains(drProgram("PresentationID").ToString) Then
                        bookmarkCSS = "bookmarkIcon bookmarkIconActive"
                    Else
                        bookmarkCSS = "bookmarkIcon"
                    End If
                    Dim programBoxStyle As String = ""
                    If drProgram("FocusArea1").ToString = "Featured Session" Then
                        programBoxStyle = " style='background-color:#fff7ed;' "
                    End If
                    programHTML &= "<div class='programBox'" & programBoxStyle & "data-programid='" & drProgram("PresentationID").ToString & "' data-sessionid='" & drProgram("SessionID").ToString & "'><span class='" & bookmarkCSS & "' onclick='bookmarkClick(this,event);'></span><span class='programRoom'><span class='locationIcon'></span><span class='locationValue'>" & drProgram("RoomNumber").ToString & "</span></span><p class='programTitle'>Title: " & drProgram("TitleOfPresentation").ToString & "</p>"
                    If Not String.IsNullOrEmpty(drProgram("FocusArea1").ToString) Then
                        programHTML &= "<p class='programFocusArea'>Stream: " & drProgram("FocusArea1").ToString & "</p>"
                    End If
                    If Not String.IsNullOrEmpty(drProgram("Combine_Speakers").ToString) Then
                        programHTML &= "<p class='programSpeaker'>Speaker(s): " & drProgram("Combine_Speakers").ToString & "</p>"
                    End If
                    If drProgram("IsCancel").ToString = "True" Then
                        programHTML &= "<p style='text-align: center; color: red; font-weight: bold;'>Cancelled</p>"
                    End If
                    programHTML &= "</div>"
                End If
            Next
            If hasBookmark Then
                programHTML &= "</div></div>"
            End If

            If confDayNo = 0 AndAlso hidConferenceType.Value = "MC" AndAlso (ddlConfTime.SelectedIndex = 0 OrElse ddlConfTime.SelectedValue = "15:25-17:05") Then
                hasBookmark = False
                Dim dtPoster As DataTable = getProgramPoster(stream, search)
                For Each drPoster As DataRow In dtPoster.Rows
                    If lstBookmark.Contains(drPoster("PresentationID").ToString) Then
                        hasBookmark = True
                        If programTime <> drPoster("SessionTime").ToString Then
                            programTimeBoxNo += 1
                            programTime = drPoster("SessionTime").ToString
                            programHTML &= "<div class='programTimeBox' data-no='" & programTimeBoxNo & "'><p class='programTime'><span class='timeIcon'></span><span class='timeValue'>" & programTime & "</span></p><div class='programBoxLink'>"
                        End If
                        If lstBookmark.Contains(drPoster("PresentationID").ToString) Then
                            bookmarkCSS = "bookmarkIcon bookmarkIconActive"
                        Else
                            bookmarkCSS = "bookmarkIcon"
                        End If
                        programHTML &= "<div class='programBox' data-programid='" & drPoster("PresentationID").ToString & "' data-sessionid='" & drPoster("SessionID").ToString & "'><span class='" & bookmarkCSS & "' onclick='bookmarkClick(this,event);'></span><span class='programRoom'><span class='locationIcon'></span><span class='locationValue'>" & drPoster("RoomNumber").ToString & "</span></span><p class='programTitle'>Title: " & drPoster("TitleOfPresentation").ToString & "</p>"
                        If Not String.IsNullOrEmpty(drPoster("FocusArea1").ToString) Then
                            programHTML &= "<p class='programFocusArea'>Stream: " & drPoster("FocusArea1").ToString & "</p>"
                        End If
                        If Not String.IsNullOrEmpty(drPoster("Combine_Speakers").ToString) Then
                            programHTML &= "<p class='programSpeaker'>Speaker(s): " & drPoster("Combine_Speakers").ToString & "</p>"
                        End If
                        If drPoster("IsCancel").ToString = "True" Then
                            programHTML &= "<p style='text-align: center; color: red; font-weight: bold;'>Cancelled</p>"
                        End If
                        programHTML &= "</div>"
                    End If
                Next
                If hasBookmark Then
                    programHTML &= "</div></div>"
                End If
            End If
        Else
            For Each drProgram As DataRow In dtProgram.Rows
                If programTime <> drProgram("SessionTime").ToString Then
                    If Not String.IsNullOrEmpty(programTime) Then programHTML &= "</div></div>"
                    programTimeBoxNo += 1
                    programTime = drProgram("SessionTime").ToString
                    Dim featuredText As String = ""
                    If lstFeatured.Contains(drProgram("SessionID").ToString) Then featuredText = "<span class='featuredText'>Featured Session Available</span>"
                    programHTML &= "<div class='programTimeBox' data-no='" & programTimeBoxNo & "'><p class='programTime'><span class='timeIcon'></span><span class='timeValue'>" & programTime & "</span>" & featuredText & "</p><div class='programBoxLink'>"
                End If
                If lstBookmark.Contains(drProgram("PresentationID").ToString) Then
                    bookmarkCSS = "bookmarkIcon bookmarkIconActive"
                Else
                    bookmarkCSS = "bookmarkIcon"
                End If
                Dim programBoxStyle As String = ""
                If drProgram("FocusArea1").ToString = "Featured Session" Then
                    programBoxStyle = " style='background-color:#fff7ed;' "
                End If
                programHTML &= "<div class='programBox'" & programBoxStyle & "data-programid='" & drProgram("PresentationID").ToString & "' data-sessionid='" & drProgram("SessionID").ToString & "'><span class='" & bookmarkCSS & "' onclick='bookmarkClick(this,event);'></span><span class='programRoom'><span class='locationIcon'></span><span class='locationValue'>" & drProgram("RoomNumber").ToString & "</span></span><p class='programTitle'>Title: " & drProgram("TitleOfPresentation").ToString & "</p>"
                If Not String.IsNullOrEmpty(drProgram("FocusArea1").ToString) Then
                    programHTML &= "<p class='programFocusArea'>Stream: " & drProgram("FocusArea1").ToString & "</p>"
                End If
                If Not String.IsNullOrEmpty(drProgram("Combine_Speakers").ToString) Then
                    programHTML &= "<p class='programSpeaker'>Speaker(s): " & drProgram("Combine_Speakers").ToString & "</p>"
                End If
                If drProgram("IsCancel").ToString = "True" Then
                    programHTML &= "<p style='text-align: center; color: red; font-weight: bold;'>Cancelled</p>"
                End If
                programHTML &= "</div>"
            Next

            If dtProgram.Rows.Count > 0 Then
                programHTML &= "</div></div>"
            End If

            If confDayNo = 0 AndAlso hidConferenceType.Value = "MC" AndAlso (ddlConfTime.SelectedIndex = 0 OrElse ddlConfTime.SelectedValue = "15:25-17:05") Then
                Dim dtPoster As DataTable = getProgramPoster(stream, search)
                For Each drPoster As DataRow In dtPoster.Rows
                    If programTime <> drPoster("SessionTime").ToString Then
                        programTimeBoxNo += 1
                        programTime = drPoster("SessionTime").ToString
                        programHTML &= "<div class='programTimeBox' data-no='" & programTimeBoxNo & "'><p class='programTime'><span class='timeIcon'></span><span class='timeValue'>" & programTime & "</span></p><div class='programBoxLink'>"
                    End If
                    If lstBookmark.Contains(drPoster("PresentationID").ToString) Then
                        bookmarkCSS = "bookmarkIcon bookmarkIconActive"
                    Else
                        bookmarkCSS = "bookmarkIcon"
                    End If
                    programHTML &= "<div class='programBox' data-programid='" & drPoster("PresentationID").ToString & "' data-sessionid='" & drPoster("SessionID").ToString & "'><span class='" & bookmarkCSS & "' onclick='bookmarkClick(this,event);'></span><span class='programRoom'><span class='locationIcon'></span><span class='locationValue'>" & drPoster("RoomNumber").ToString & "</span></span><p class='programTitle'>Title: " & drPoster("TitleOfPresentation").ToString & "</p>"
                    If Not String.IsNullOrEmpty(drPoster("FocusArea1").ToString) Then
                        programHTML &= "<p class='programFocusArea'>Stream: " & drPoster("FocusArea1").ToString & "</p>"
                    End If
                    If Not String.IsNullOrEmpty(drPoster("Combine_Speakers").ToString) Then
                        programHTML &= "<p class='programSpeaker'>Speaker(s): " & drPoster("Combine_Speakers").ToString & "</p>"
                    End If
                    If drPoster("IsCancel").ToString = "True" Then
                        programHTML &= "<p style='text-align: center; color: red; font-weight: bold;'>Cancelled</p>"
                    End If
                    programHTML &= "</div>"
                Next

                If dtPoster.Rows.Count > 0 Then
                    programHTML &= "</div></div>"
                End If
            End If
        End If

        programHTML &= "</div>"
        Return programHTML
    End Function


    Private Function getProgramHTML(confDay As String, confDayNo As Integer, lstBookmark As List(Of Integer), lstFeatured As List(Of Integer), Optional showOnlyBookmark As Boolean = False, Optional confTime As String = "", Optional stream As String = "", Optional search As String = "") As String
        Dim dtProgram As DataTable = getProgram(confDay, confTime, stream, search)
        Dim programHTML As String = "<div class='programContainer' style='left: " & 100 * confDayNo & "%'>"
        Dim programTime As String = "", programTimeBoxNo As Integer = -1, bookmarkCSS As String = ""

        If hidConferenceType.Value = "RS" Then
            Dim opening As String = "<div>" & _
            "<p class=""programTime""><span class=""timeIcon""></span><span class=""timeValue"">08:30-08:40</span>" & _
            "<span class=""featuredText"">Opening Ceremony</span></p></div>" & _
            "<div class=""programTimeBox"">" & _
            "<p class=""programTime""><span class=""timeIcon""></span><span class=""timeValue"">08:40-09:25</span>" & _
            "<span class=""featuredText"">OPENING PLENARY SESSION (Symposium Hall)</span></p></div>"
            programHTML &= opening
        ElseIf hidConferenceType.Value = "MC" AndAlso confDayNo = 0 Then
            Dim opening As String = "<div>" & _
            "<p class=""programTime""><span class=""timeIcon""></span><span class=""timeValue"">08:15-08:30</span>" & _
            "<span class=""featuredText"">Arrival of VIPS</span></p></div>" &
            "<div class=""programTimeBox"">" & _
            "<p class=""programTime""><span class=""timeIcon""></span><span class=""timeValue"">08:30-09:30</span>" & _
            "<span class=""featuredText"">OPENING PLENARY SESSION (Conference Hall)</span></p></div>"
            programHTML &= opening
        End If
        If showOnlyBookmark Then
            Dim hasBookmark As Boolean = False
            For Each drProgram As DataRow In dtProgram.Rows
                If lstBookmark.Contains(drProgram("PresentationID").ToString) Then
                    hasBookmark = True
                    If programTime <> drProgram("SessionTime").ToString Then
                        If Not String.IsNullOrEmpty(programTime) Then programHTML &= "</div></div>"
                        programTimeBoxNo += 1
                        programTime = drProgram("SessionTime").ToString
                        Dim featuredText As String = ""
                        If lstFeatured.Contains(drProgram("SessionID").ToString) Then featuredText = "<span class='featuredText'>Featured Session Available</span>"
                        programHTML &= "<div class='programTimeBox' data-no='" & programTimeBoxNo & "'><p class='programTime'><span class='timeIcon'></span><span class='timeValue'>" & programTime & "</span>" & featuredText & "</p><div class='programBoxLink'>"
                    End If
                    If lstBookmark.Contains(drProgram("PresentationID").ToString) Then
                        bookmarkCSS = "bookmarkIcon bookmarkIconActive"
                    Else
                        bookmarkCSS = "bookmarkIcon"
                    End If
                    Dim programBoxStyle As String = ""
                    If drProgram("FocusArea1").ToString = "Featured Session" Then
                        programBoxStyle = " style='background-color:#fff7ed;' "
                    End If
                    programHTML &= "<div class='programBox'" & programBoxStyle & "data-programid='" & drProgram("PresentationID").ToString & "' data-sessionid='" & drProgram("SessionID").ToString & "'><span class='" & bookmarkCSS & "' onclick='bookmarkClick(this,event);'></span><span class='programRoom'><span class='locationIcon'></span><span class='locationValue'>" & drProgram("RoomNumber").ToString & "</span></span><p class='programTitle'>Title: " & drProgram("TitleOfPresentation").ToString & "</p>"
                    If Not String.IsNullOrEmpty(drProgram("FocusArea1").ToString) Then
                        programHTML &= "<p class='programFocusArea'>Stream: " & drProgram("FocusArea1").ToString & "</p>"
                    End If
                    If Not String.IsNullOrEmpty(drProgram("Combine_Speakers").ToString) Then
                        programHTML &= "<p class='programSpeaker'>Speaker(s): " & drProgram("Combine_Speakers").ToString & "</p>"
                    End If
                    If drProgram("IsCancel").ToString = "True" Then
                        programHTML &= "<p style='text-align: center; color: red; font-weight: bold;'>Cancelled</p>"
                    End If
                    programHTML &= "</div>"
                End If
            Next
            If hasBookmark Then
                programHTML &= "</div></div>"
            End If

            If confDayNo = 0 AndAlso hidConferenceType.Value = "MC" AndAlso (ddlConfTime.SelectedIndex = 0 OrElse ddlConfTime.SelectedValue = "15:25-17:05") Then
                hasBookmark = False
                Dim dtPoster As DataTable = getProgramPoster(stream, search)
                For Each drPoster As DataRow In dtPoster.Rows
                    If lstBookmark.Contains(drPoster("PresentationID").ToString) Then
                        hasBookmark = True
                        If programTime <> drPoster("SessionTime").ToString Then
                            programTimeBoxNo += 1
                            programTime = drPoster("SessionTime").ToString
                            programHTML &= "<div class='programTimeBox' data-no='" & programTimeBoxNo & "'><p class='programTime'><span class='timeIcon'></span><span class='timeValue'>" & programTime & "</span></p><div class='programBoxLink'>"
                        End If
                        If lstBookmark.Contains(drPoster("PresentationID").ToString) Then
                            bookmarkCSS = "bookmarkIcon bookmarkIconActive"
                        Else
                            bookmarkCSS = "bookmarkIcon"
                        End If
                        programHTML &= "<div class='programBox' data-programid='" & drPoster("PresentationID").ToString & "' data-sessionid='" & drPoster("SessionID").ToString & "'><span class='" & bookmarkCSS & "' onclick='bookmarkClick(this,event);'></span><span class='programRoom'><span class='locationIcon'></span><span class='locationValue'>" & drPoster("RoomNumber").ToString & "</span></span><p class='programTitle'>Title: " & drPoster("TitleOfPresentation").ToString & "</p>"
                        If Not String.IsNullOrEmpty(drPoster("FocusArea1").ToString) Then
                            programHTML &= "<p class='programFocusArea'>Stream: " & drPoster("FocusArea1").ToString & "</p>"
                        End If
                        If Not String.IsNullOrEmpty(drPoster("Combine_Speakers").ToString) Then
                            programHTML &= "<p class='programSpeaker'>Speaker(s): " & drPoster("Combine_Speakers").ToString & "</p>"
                        End If
                        If drPoster("IsCancel").ToString = "True" Then
                            programHTML &= "<p style='text-align: center; color: red; font-weight: bold;'>Cancelled</p>"
                        End If
                        programHTML &= "</div>"
                    End If
                Next
                If hasBookmark Then
                    programHTML &= "</div></div>"
                End If
            End If
        Else
            For Each drProgram As DataRow In dtProgram.Rows
                If programTime <> drProgram("SessionTime").ToString Then
                    If Not String.IsNullOrEmpty(programTime) Then programHTML &= "</div></div>"
                    programTimeBoxNo += 1
                    programTime = drProgram("SessionTime").ToString
                    Dim featuredText As String = ""
                    If lstFeatured.Contains(drProgram("SessionID").ToString) Then featuredText = "<span class='featuredText'>Featured Session Available</span>"
                    programHTML &= "<div class='programTimeBox' data-no='" & programTimeBoxNo & "'><p class='programTime'><span class='timeIcon'></span><span class='timeValue'>" & programTime & "</span>" & featuredText & "</p><div class='programBoxLink'>"
                End If
                If lstBookmark.Contains(drProgram("PresentationID").ToString) Then
                    bookmarkCSS = "bookmarkIcon bookmarkIconActive"
                Else
                    bookmarkCSS = "bookmarkIcon"
                End If
                Dim programBoxStyle As String = ""
                If drProgram("FocusArea1").ToString = "Featured Session" Then
                    programBoxStyle = " style='background-color:#fff7ed;' "
                End If
                programHTML &= "<div class='programBox'" & programBoxStyle & "data-programid='" & drProgram("PresentationID").ToString & "' data-sessionid='" & drProgram("SessionID").ToString & "'><span class='" & bookmarkCSS & "' onclick='bookmarkClick(this,event);'></span><span class='programRoom'><span class='locationIcon'></span><span class='locationValue'>" & drProgram("RoomNumber").ToString & "</span></span><p class='programTitle'>Title: " & drProgram("TitleOfPresentation").ToString & "</p>"
                If Not String.IsNullOrEmpty(drProgram("FocusArea1").ToString) Then
                    programHTML &= "<p class='programFocusArea'>Stream: " & drProgram("FocusArea1").ToString & "</p>"
                End If
                If Not String.IsNullOrEmpty(drProgram("Combine_Speakers").ToString) Then
                    programHTML &= "<p class='programSpeaker'>Speaker(s): " & drProgram("Combine_Speakers").ToString & "</p>"
                End If
                If drProgram("IsCancel").ToString = "True" Then
                    programHTML &= "<p style='text-align: center; color: red; font-weight: bold;'>Cancelled</p>"
                End If
                programHTML &= "</div>"
            Next

            If dtProgram.Rows.Count > 0 Then
                programHTML &= "</div></div>"
            End If

            If confDayNo = 0 AndAlso hidConferenceType.Value = "MC" AndAlso (ddlConfTime.SelectedIndex = 0 OrElse ddlConfTime.SelectedValue = "15:25-17:05") Then
                Dim dtPoster As DataTable = getProgramPoster(stream, search)
                For Each drPoster As DataRow In dtPoster.Rows
                    If programTime <> drPoster("SessionTime").ToString Then
                        programTimeBoxNo += 1
                        programTime = drPoster("SessionTime").ToString
                        programHTML &= "<div class='programTimeBox' data-no='" & programTimeBoxNo & "'><p class='programTime'><span class='timeIcon'></span><span class='timeValue'>" & programTime & "</span></p><div class='programBoxLink'>"
                    End If
                    If lstBookmark.Contains(drPoster("PresentationID").ToString) Then
                        bookmarkCSS = "bookmarkIcon bookmarkIconActive"
                    Else
                        bookmarkCSS = "bookmarkIcon"
                    End If
                    programHTML &= "<div class='programBox' data-programid='" & drPoster("PresentationID").ToString & "' data-sessionid='" & drPoster("SessionID").ToString & "'><span class='" & bookmarkCSS & "' onclick='bookmarkClick(this,event);'></span><span class='programRoom'><span class='locationIcon'></span><span class='locationValue'>" & drPoster("RoomNumber").ToString & "</span></span><p class='programTitle'>Title: " & drPoster("TitleOfPresentation").ToString & "</p>"
                    If Not String.IsNullOrEmpty(drPoster("FocusArea1").ToString) Then
                        programHTML &= "<p class='programFocusArea'>Stream: " & drPoster("FocusArea1").ToString & "</p>"
                    End If
                    If Not String.IsNullOrEmpty(drPoster("Combine_Speakers").ToString) Then
                        programHTML &= "<p class='programSpeaker'>Speaker(s): " & drPoster("Combine_Speakers").ToString & "</p>"
                    End If
                    If drPoster("IsCancel").ToString = "True" Then
                        programHTML &= "<p style='text-align: center; color: red; font-weight: bold;'>Cancelled</p>"
                    End If
                    programHTML &= "</div>"
                Next

                If dtPoster.Rows.Count > 0 Then
                    programHTML &= "</div></div>"
                End If
            End If
        End If

        programHTML &= "</div>"
        Return programHTML
    End Function

    Private Sub bindProgram(program1 As String, Optional program2 As String = "", Optional program3 As String = "")
        If hidConferenceType.Value = "RS" Then
            Dim opening As String = "<div>" & _
            "<p class=""programTime""><span class=""timeIcon""></span><span class=""timeValue"">08:30-08:40</span>" & _
            "<span class=""featuredText"">Opening Ceremony</span></p></div>" & _
            "<div class=""programTimeBox"">" & _
            "<p class=""programTime""><span class=""timeIcon""></span><span class=""timeValue"">08:40-09:25</span>" & _
            "<span class=""featuredText"">OPENING PLENARY SESSION (Symposium Hall)</span></p></div>"
            divProgramContainer.InnerHtml = program1 & program2 & program3

        Else
            divProgramContainer.InnerHtml = program1 & program2 & program3
        End If

    End Sub

    Protected Sub btnBack_Click(sender As Object, e As EventArgs)
        If Request.QueryString("DeviceID") IsNot Nothing Then
            Response.Redirect("http://camtesolapp.acecambodia.org/login.aspx?deviceid=" & Request.QueryString("DeviceID").ToString())
        End If
    End Sub

    Private Sub bindDdlConfDay()
        Dim dt As DataTable = DalSelectCamTESOL.selectQuery("select distinct convert(varchar, SessionDate) As SessionDate from tblCamTESOLConferenceProgram_Session where SessionType='" & hidConferenceType.Value & "' order by SessionDate")
        If hidConferenceType.Value = "MC" Then
            Dim newRow As DataRow = dt.NewRow
            newRow("SessionDate") = "Any Day"
            dt.Rows.InsertAt(newRow, 0)
        End If
        ddlConfDay.DataSource = dt
        ddlConfDay.DataValueField = "SessionDate"
        ddlConfDay.DataTextField = "SessionDate"
        ddlConfDay.DataBind()
    End Sub

    Private Function getConfTime(Optional confDay As Date = Nothing) As DataTable
        Dim condition As String = ""
        If confDay <> Nothing Then
            condition = "where SessionDate='" & confDay.ToString("yyyy-MM-dd") & "'"
        Else
            If hidConferenceType.Value = "MC" Then
                condition = "where SessionType='MC'"
            End If
        End If
        Dim dt As DataTable = DalSelectCamTESOL.selectQuery("select distinct SessionTime from tblCamTESOLConferenceProgram_Session " & condition & " order by SessionTime")
        Return dt
    End Function

    Private Sub bindDdlConfTime(Optional confDay As Date = Nothing)
        Dim dt As DataTable = getConfTime(confDay)
        Dim newRow As DataRow = dt.NewRow
        newRow("SessionTime") = "Any Time"
        dt.Rows.InsertAt(newRow, 0)
        If hidConferenceType.Value = "MC" AndAlso (ddlConfDay.SelectedIndex = 0 OrElse ddlConfDay.SelectedIndex = 1) Then
            Dim posterRow As DataRow = dt.NewRow
            posterRow("SessionTime") = "15:25-17:05"
            dt.Rows.Add(posterRow)
        End If
        ddlConfTime.DataSource = dt
        ddlConfTime.DataValueField = "SessionTime"
        ddlConfTime.DataTextField = "SessionTime"
        ddlConfTime.DataBind()
    End Sub

    Protected Sub ddlConfDay_SelectedIndexChanged(sender As Object, e As EventArgs)
        If ddlConfDay.SelectedIndex = 0 AndAlso hidConferenceType.Value = "MC" Then
            bindDdlConfTime()
        Else
            bindDdlConfTime(ddlConfDay.SelectedValue)
        End If
        bindDdlStream()
    End Sub

    Protected Sub btnPopupNoSearch_Click(sender As Object, e As EventArgs)
        popupPanel.Style("display") = "none"
        popupBoxSearch.Style("display") = "none"

        ScriptManager.RegisterStartupScript(panelProgram, panelProgram.GetType, "fadeOut", "fadeOut('" & popupBoxSearch.ClientID & "')", True)
        hidPopupPostBack.Value = "0"
        hidPopupBoxSearch.Value = "0"
    End Sub

    Private Function getStream(conferenceType As String) As DataTable
        Return DalSelectCamTESOL.selectQuery("select distinct FocusArea1 from tblCamTESOLConferenceProgram_AbstractDetail where AbstractStatus='Registered' and [Conference Type] like '%" & conferenceType & "%'")
    End Function

    Private Sub bindDdlStream()
        Dim conferenceType As String = ""
        If hidConferenceType.Value = "MC" Then
            conferenceType = "Main Conf"
        ElseIf hidConferenceType.Value = "RS" Then
            conferenceType = "Research"
        End If
        Dim dt As DataTable = getStream(conferenceType)
        Dim newRow As DataRow = dt.NewRow
        newRow("FocusArea1") = "Any Stream"
        dt.Rows.InsertAt(newRow, 0)
        ddlStream.DataSource = dt
        ddlStream.DataValueField = "FocusArea1"
        ddlStream.DataTextField = "FocusArea1"
        ddlStream.DataBind()
    End Sub
    Protected Function getWelcomeReception() As String
        Dim opening As String = "<div>" & _
        "<p class=""programTime""><span class=""timeIcon""></span><span class=""timeValue"">17:00-17:30</span>" & _
        "<span class=""featuredText"">Guests arrive - Registration and Conference Bag Collection</span></p></div>" & _
        "<div class=""programTimeBox"">" & _
        "<p class=""programTime""><span class=""timeIcon""></span><span class=""timeValue"">17:30-17:40</span>" & _
        "<span class=""featuredText"">National Anthem and Blessing Dance</span></p></div>" & _
        "<div class=""programTimeBox"">" & _
        "<p class=""programTime""><span class=""timeIcon""></span><span class=""timeValue"">17:40-18:20</span>" & _
        "<span class=""featuredText"">" & _
        " Remarks - IDP Education Country Director and CamTESOL Convenor</span><br> <span class=""subText"">Remarks - US Ambassador (TBC)</span><br> <span class=""subText"">Remarks - Australian Ambassador</span><br> <span class=""subText"">Remarks - Minister of Education, Youth and Sport</span></p></div>" & _
        "<div class=""programTimeBox"">" & _
        "<p class=""programTime""><span class=""timeIcon""></span><span class=""timeValue"">18:20-20:30</span>" & _
        "<span class=""featuredText"">" & _
        " Food and drinks, cultural performances and networking</span></p></div>"
        Return opening
    End Function

    Private Sub searchProgram()
        Dim program1 As String = "", program2 As String = "", program3 As String = ""
        Dim confTime As String = "", stream As String = "", search As String = ""
        If ddlConfTime.SelectedIndex <> 0 Then confTime = ddlConfTime.SelectedValue
        If ddlStream.SelectedIndex <> 0 Then stream = ddlStream.SelectedValue
        search = txtSearch.Text.Trim
        Dim showOnlyBookmark As Boolean = chkOnlyBookmark.Checked
        Dim lstBookmark As List(Of Integer) = getBookmark()
        Dim lstFeatured As List(Of Integer) = getFeaturedSession()
        If ddlConfDay.SelectedIndex = 0 Then
            If hidConferenceType.Value = "RS" Then
                program1 = getProgramHTML(ddlConfDay.Items(0).Text, 0, lstBookmark, lstFeatured, showOnlyBookmark, confTime, stream, search)
            Else
                program2 = getProgramHTML(ddlConfDay.Items(1).Text, 0, lstBookmark, lstFeatured, showOnlyBookmark, confTime, stream, search)
                program3 = getProgramHTML(ddlConfDay.Items(2).Text, 1, lstBookmark, lstFeatured, showOnlyBookmark, confTime, stream, search)
            End If
        ElseIf ddlConfDay.SelectedIndex = 1 Then
            If hidConferenceType.Value = "RS" Then
                program1 = getProgramHTML(ddlConfDay.Items(0).Text, 0, lstBookmark, lstFeatured, showOnlyBookmark, confTime, stream, search)
            Else
                program2 = getProgramHTML(ddlConfDay.Items(1).Text, 0, lstBookmark, lstFeatured, showOnlyBookmark, confTime, stream, search)
                program3 = getProgramHTML(ddlConfDay.Items(2).Text, 1, lstBookmark, lstFeatured)
            End If
        ElseIf ddlConfDay.SelectedIndex = 2 Then
            If hidConferenceType.Value = "RS" Then
                program1 = getProgramHTML(ddlConfDay.Items(0).Text, 0, lstBookmark, lstFeatured)
            Else
                program2 = getProgramHTML(ddlConfDay.Items(1).Text, 0, lstBookmark, lstFeatured)
                program3 = getProgramHTML(ddlConfDay.Items(2).Text, 1, lstBookmark, lstFeatured, showOnlyBookmark, confTime, stream, search)
            End If
        End If
        bindProgram(program1, program2, program3)

        If ddlConfDay.SelectedIndex <> 0 AndAlso Page.IsPostBack Then
            ScriptManager.RegisterStartupScript(panelProgram, panelProgram.GetType, "scrollAnimateProgram", "scrollAnimateProgram(" & ddlConfDay.SelectedIndex - 1 & ")", True)
        End If
    End Sub
    Private Sub searchAllProgramByTime()
        Dim program1 As String = "", program2 As String = "", program3 As String = ""
        Dim confTime As String = "", stream As String = "", search As String = ""
        If ddlConfTime.SelectedIndex <> 0 Then confTime = ddlConfTime.SelectedValue
        If ddlStream.SelectedIndex <> 0 Then stream = ddlStream.SelectedValue
        search = txtSearch.Text.Trim
        Dim showOnlyBookmark As Boolean = chkOnlyBookmark.Checked
        Dim lstBookmark As List(Of Integer) = getBookmark()
        Dim lstFeatured As List(Of Integer) = getFeaturedSession()

        program1 = getProgramHTML(ddlConfDay.Items(0).Text, 0, lstBookmark, lstFeatured, showOnlyBookmark, confTime, stream, search)
        divAllProgramByTime.InnerHtml = program1


    End Sub
    Protected Sub btnPopupYesSearch_Click(sender As Object, e As EventArgs)
        searchProgram()
    End Sub

    Protected Sub btnBookmark_Click(sender As Object, e As EventArgs)
        If Request.QueryString("UserID") IsNot Nothing AndAlso Not String.IsNullOrEmpty(hidPresentationID.Value) Then
            Dim bookmark As New ClsBookmark, dalBookmark As New DalBookmark
            Dim dtBookmark As DataTable = DalSelectCamTESOL.selectQuery("select IsDeleted from tblBookmark where UserID=" & Request.QueryString("UserID").ToString & " and PresentationID=" & hidPresentationID.Value)
            bookmark.userID = Request.QueryString("UserID").ToString
            bookmark.presentationID = hidPresentationID.Value
            If dtBookmark.Rows.Count > 0 Then
                If hidIsBookmark.Value = "1" Then
                    bookmark.isDeleted = 0
                Else
                    bookmark.isDeleted = 1
                End If
                dalBookmark.updateBookmark(bookmark)
            Else
                bookmark.isDeleted = 0
                bookmark.createdDate = Now
                dalBookmark.addBookmark(bookmark)
            End If
            searchProgram()
        End If
    End Sub

    Private Function getBookmark() As List(Of Integer)
        Dim lst As New List(Of Integer)
        If Request.QueryString("UserID") IsNot Nothing Then
            Dim dt As DataTable = DalSelectCamTESOL.selectQuery("select PresentationID from tblBookmark where isnull(IsDeleted, 0)=0 and UserID=" & Request.QueryString("UserID").ToString)
            For Each dr As DataRow In dt.Rows
                lst.Add(dr("PresentationID").ToString)
            Next
        End If
        Return lst
    End Function

    Protected Sub btnProgramDetail_Click(sender As Object, e As EventArgs)
        If Not String.IsNullOrEmpty(hidPresentationID.Value) Then
            Session("conferenceType") = hidConferenceType.Value
            Session("confDayActive") = hidConfDayActive.Value
            Session("timeBoxActive") = hidTimeBoxActive.Value
            Session("programScrollTop") = hidProgramContainerVPos.Value
            Session("searchKeyword") = txtSearch.Text
            Session("searchConfDay") = ddlConfDay.SelectedIndex
            Session("searchConfTime") = ddlConfTime.SelectedIndex
            Session("searchStream") = ddlStream.SelectedIndex
            Session("searchBookmark") = chkOnlyBookmark.Checked

            Dim query As String = "?PresentationID=" & hidPresentationID.Value & "&SessionID=" & hidSessionID.Value
            If Request.QueryString("UserID") IsNot Nothing Then query &= "&UserID=" & Request.QueryString("UserID").ToString
            If Request.QueryString("user") IsNot Nothing Then query &= "&user=" & Request.QueryString("user").ToString
            If Request.QueryString("DeviceID") IsNot Nothing Then query &= "&DeviceID=" & Request.QueryString("DeviceID").ToString
            If Request.QueryString("PresenterID") IsNot Nothing Then query &= "&PresenterID=" & Request.QueryString("PresenterID").ToString

            Response.Redirect("~/ProgramDetail.aspx" & query)
        End If
    End Sub

    Protected Sub btnConferenceType_Click(sender As Object, e As EventArgs)
        If hidConferenceType.Value = "RS" Then
            lnkSaturday.Visible = False : lnkSunday.Visible = False : lnkFriday.Visible = True
            lnkSaturday.CssClass = "dateBoxHeader" : lnkSunday.CssClass = "dateBoxHeader"
            lnkFriday.CssClass = "dateBoxHeader dateBoxHeaderActive"
        ElseIf hidConferenceType.Value = "WR" Then
            lnkSaturday.Visible = False : lnkSunday.Visible = False : lnkFriday.Visible = True
            lnkSaturday.CssClass = "dateBoxHeader" : lnkSunday.CssClass = "dateBoxHeader"
            lnkFriday.CssClass = "dateBoxHeader dateBoxHeaderActive"
            divProgramContainer.InnerHtml=getWelcomeReception.ToString
            mulViewMain.SetActiveView(viewProgram)
            Exit Sub
        Else
            lnkFriday.Visible = False : lnkSaturday.Visible = True : lnkSunday.Visible = True
            lnkSaturday.CssClass = "dateBoxHeader dateBoxHeaderActive"
            lnkFriday.CssClass = "dateBoxHeader" : lnkSunday.CssClass = "dateBoxHeader"
        End If
            bindDdlConfDay()
            bindDdlStream()
            If ddlConfDay.SelectedIndex = 0 AndAlso hidConferenceType.Value = "MC" Then
                bindDdlConfTime()
            Else
                bindDdlConfTime(ddlConfDay.SelectedValue)
            End If
            searchProgram()
            mulViewMain.SetActiveView(viewProgram)
    End Sub

    Protected Sub lnkBack_Click(sender As Object, e As EventArgs)
        hidPopupBoxSearch.Value = "0" : hidConfDayActive.Value = "0" : hidPresentationID.Value = "0" : hidSessionID.Value = "0" : hidIsBookmark.Value = "0"
        hidTimeBoxActive.Value = "-1" : hidProgramContainerVPos.Value = "0" : chkOnlyBookmark.Checked = False : txtSearch.Text = ""
        mulViewMain.SetActiveView(viewMain)
    End Sub

    Private Function getFeaturedSession() As List(Of Integer)
        Dim lstFeatured As New List(Of Integer)
        Dim dtFeatured As DataTable = DalSelectCamTESOL.selectQuery("select distinct s.SessionID from tblCamTESOLConferenceProgram_SessionDetail d inner join tblCamTESOLConferenceProgram_Session s on d.SessionID=s.SessionID inner join tblCamTESOLConferenceProgram_AbstractDetail a on d.PresentationID=a.PresentationID where isnull(IsEmpty,0)=0 and d.PresentationID<>0 and AbstractStatus='Registered' and FocusArea1='Featured Session'")
        For Each dr As DataRow In dtFeatured.Rows
            lstFeatured.Add(dr("SessionID").ToString)
        Next
        Return lstFeatured
    End Function
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

    Protected Sub hrefBack_ServerClick(sender As Object, e As EventArgs)
        If mulViewMain.GetActiveView Is viewProgram Then
            mulViewMain.SetActiveView(viewMain)
        ElseIf mulViewMain.GetActiveView Is viewMain Then
            If Request.QueryString("DeviceID") IsNot Nothing Then
                Response.Redirect("http://camtesolapp.acecambodia.org/login.aspx?deviceid=" & Request.QueryString("DeviceID").ToString)
            End If
        End If
    End Sub
End Class
