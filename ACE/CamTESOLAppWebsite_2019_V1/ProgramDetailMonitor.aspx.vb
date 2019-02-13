Imports System.Data
Imports System.Data.SqlClient

Partial Class ProgramDetail
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Request.QueryString("User") IsNot Nothing AndAlso Request.QueryString("DeviceID") IsNot Nothing Then
                lblUserName.Text = DalUser.getUserByEmail(Request.QueryString("user")).givenName.ToString
                Dim PresenterID As Integer = 0
                If Request.QueryString("PresenterID") IsNot Nothing Then
                    PresenterID = Request.QueryString("PresenterID").ToString
                End If
                LoadMenu(Request.QueryString("user").ToString, Request.QueryString("deviceid").ToString, PresenterID)
            End If
            If Session("conferenceType") IsNot Nothing Then hidConferenceType.Value = Session("conferenceType")
            If Session("confDayActive") IsNot Nothing Then hidConfDayActive.Value = Session("confDayActive")
            If Session("timeBoxActive") IsNot Nothing Then hidTimeBoxActive.Value = Session("timeBoxActive")
            If Session("programScrollTop") IsNot Nothing Then hidProgramScrollTop.Value = Session("programScrollTop")
            If Session("searchKeyword") IsNot Nothing Then hidSearch.Value = Session("searchKeyword")
            If Session("searchConfDay") IsNot Nothing Then hidSearchConfDay.Value = Session("searchConfDay")
            If Session("searchConfTime") IsNot Nothing Then hidSearchConfTime.Value = Session("searchConfTime")
            If Session("searchStream") IsNot Nothing Then hidSearchStream.Value = Session("searchStream")
            If Session("searchBookmark") IsNot Nothing Then hidSearchBookmark.Value = Session("searchBookmark")

            If Request.QueryString("SessionID") IsNot Nothing AndAlso Request.QueryString("PresentationID") IsNot Nothing Then
                divProgramContainer.InnerHtml = getDetailHTML(Request.QueryString("PresentationID").ToString, Request.QueryString("SessionID").ToString)
            End If
        End If
    End Sub

    Protected Sub Page_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete
        mainContainer.Style("visibility") = "visible"
    End Sub


    Private Function getProgramDetail(presentationID As Integer, sessionID As Integer) As DataTable
        Dim dt As DataTable
        If sessionID <> -1 Then
            Dim selectedField As String = "a.TitleOfPresentation, a.Abstract, a.FocusArea1, a.Combine_Speakers, d.RoomNumber, s.SessionTime, isnull(a.IsCancel,0) as IsCancel"
            Dim condition As String = "where a.AbstractStatus='Registered' and isnull(d.IsEmpty,0)=0 and a.PresentationID=" & presentationID & " and d.SessionID=" & sessionID
            dt = DalSelectCamTESOL.selectQuery("select " & selectedField & " from tblCamTESOLConferenceProgram_AbstractDetail a inner join tblCamTESOLConferenceProgram_SessionDetail d on a.PresentationID=d.PresentationID inner join tblCamTESOLConferenceProgram_Session s on d.SessionID=s.SessionID " & condition)
        Else
            Dim selectedField As String = "TitleOfPresentation, Abstract, FocusArea1, Combine_Speakers, 'Building A' as RoomNumber, '15:25-17:05' as SessionTime, isnull(IsCancel,0) as IsCancel"
            dt = DalSelectCamTESOL.selectQuery("select " & selectedField & " from tblCamTESOLConferenceProgram_AbstractDetail where PresentationID=" & presentationID)
        End If
        Return dt
    End Function

    Private Function getProgramSpeaker(presentationID As Integer, sessionID As Integer) As DataTable
        Dim dt As DataTable
        If sessionID <> -1 Then
            Dim selectedField As String = "s.ContactID, s.Title, s.FamilyName, s.GivenName, s.Position, s.EmployerFull, a.TitleOfPresentation, a.FocusArea1, a.Combine_Speakers, d.RoomNumber, isnull(a.IsCancel,0) as IsCancel"
            Dim condition As String = "where a.AbstractStatus='Registered' and isnull(d.IsEmpty,0)=0 and a.PresentationID=" & presentationID & " and d.SessionID=" & sessionID
            dt = DalSelectCamTESOL.selectQuery("select " & selectedField & " from tblCamTESOLConferenceProgram_AbstractDetail_AllSpeakers s inner join tblCamTESOLConferenceProgram_AbstractDetail a on s.PresentationID=a.PresentationID inner join tblCamTESOLConferenceProgram_SessionDetail d on a.PresentationID=d.PresentationID " & condition & " order by s.ContactID")
        Else
            Dim selectedField As String = "s.ContactID, s.Title, s.FamilyName, s.GivenName, s.Position, s.EmployerFull, a.TitleOfPresentation, a.FocusArea1, a.Combine_Speakers, 'Building A' as RoomNumber, isnull(a.IsCancel,0) as IsCancel"
            Dim condition As String = "where a.AbstractStatus='Registered' and a.PresentationID=" & presentationID
            dt = DalSelectCamTESOL.selectQuery("select " & selectedField & " from tblCamTESOLConferenceProgram_AbstractDetail_AllSpeakers s inner join tblCamTESOLConferenceProgram_AbstractDetail a on s.PresentationID=a.PresentationID " & condition & " order by s.ContactID")
        End If
        Return dt
    End Function

    Private Function getDetailHTML(presentationID As Integer, sessionID As Integer) As String
        Dim detailHTML As String = ""
        Dim dtProgramDetail As DataTable = getProgramDetail(presentationID, sessionID)
        If dtProgramDetail.Rows.Count > 0 Then
            Dim bookmarkCSS As String = "bookmarkIcon"
            If Request.QueryString("UserID") IsNot Nothing AndAlso Request.QueryString("PresentationID") IsNot Nothing Then
                Dim dtBookmark As DataTable = DalSelectCamTESOL.selectQuery("select IsDeleted from tblBookmark where isnull(IsDeleted, 0)=0 and UserID=" & Request.QueryString("UserID").ToString & " and PresentationID=" & Request.QueryString("PresentationID").ToString)
                If dtBookmark.Rows.Count > 0 Then
                    bookmarkCSS &= " bookmarkIconActive"
                End If
            End If
            detailHTML &= "<div class='programDetailBox'><span class='" & bookmarkCSS & "'></span><span class='programRoomTime'><span class='programRoomSection'><span class='locationIcon'></span><span class='locationValue'>" & dtProgramDetail.Rows(0)("RoomNumber").ToString & "</span></span><span class='programTimeSection'><span class='timeIcon'></span><span class='timeValue'>" & dtProgramDetail.Rows(0)("SessionTime").ToString & "</span></span></span><p class='programTitle'>Title: " & dtProgramDetail.Rows(0)("TitleOfPresentation").ToString & _
                          "</p>"
            If Not String.IsNullOrEmpty(dtProgramDetail.Rows(0)("FocusArea1").ToString) Then
                detailHTML &= "<p class='programFocusArea'>Stream: " & dtProgramDetail.Rows(0)("FocusArea1").ToString & "</p>"
            End If
            detailHTML &= "<p class='programSpeaker'>Speaker(s): " & dtProgramDetail.Rows(0)("Combine_Speakers").ToString & "</p>"
            If dtProgramDetail.Rows(0)("IsCancel").ToString = "True" Then
                detailHTML &= "<p style='text-align: center; color: red; font-weight: bold;'>Cancelled</p>"
            End If
            detailHTML &= "</div>"
            If Not String.IsNullOrEmpty(dtProgramDetail.Rows(0)("Abstract").ToString) Then
                detailHTML &= "<div class='programDetailBox' style='border-left: none;'><p>" & dtProgramDetail.Rows(0)("Abstract").ToString & "</p></div>"
            End If
        End If

        Dim dtProgramSpeaker As DataTable = getProgramSpeaker(presentationID, sessionID)
        If dtProgramSpeaker.Rows.Count > 0 Then
            detailHTML &= "<div class='programSpeakerBox'>"
            For Each drSpeaker As DataRow In dtProgramSpeaker.Rows
                detailHTML &= "<div class='speakerBox' data-speakerid='" & drSpeaker("ContactID").ToString & "'><img src='img/profile.png' class='speakerPhoto'/><p class='speakerName'>" & drSpeaker("Title").ToString & " " & drSpeaker("GivenName").ToString & " " & drSpeaker("FamilyName").ToString.ToUpper & "</p>"
                If Not String.IsNullOrEmpty(drSpeaker("Position").ToString) Then
                    detailHTML &= "<p class='speakerPosition'>" & drSpeaker("Position").ToString & "</p>"
                End If
                If Not String.IsNullOrEmpty(drSpeaker("EmployerFull").ToString) Then
                    detailHTML &= "<p class='speakerEmployer'>" & drSpeaker("EmployerFull").ToString & "</p>"
                End If
                detailHTML &= "<div style='clear: both'></div></div>"
            Next
            detailHTML &= "</div>"
        End If
        Return detailHTML
    End Function

    Protected Sub btnBookmark_Click(sender As Object, e As EventArgs)
        If Request.QueryString("PresentationID") IsNot Nothing AndAlso Request.QueryString("UserID") IsNot Nothing AndAlso Not String.IsNullOrEmpty(hidIsBookmark.Value) Then
            Dim bookmark As New ClsBookmark, dalBookmark As New DalBookmark
            Dim dtBookmark As DataTable = DalSelectCamTESOL.selectQuery("select IsDeleted from tblBookmark where UserID=" & Request.QueryString("UserID").ToString & " and PresentationID=" & Request.QueryString("PresentationID").ToString)
            bookmark.userID = Request.QueryString("UserID").ToString
            bookmark.presentationID = Request.QueryString("PresentationID").ToString
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
            If Request.QueryString("SessionID") IsNot Nothing Then
                divProgramContainer.InnerHtml = getDetailHTML(Request.QueryString("PresentationID").ToString, Request.QueryString("SessionID").ToString)
            End If
        End If
    End Sub

    Protected Sub btnPopupNoSpeakerInfo_Click(sender As Object, e As EventArgs)

    End Sub

    Private Function getProgramBySpeaker(speakerID As Integer) As DataTable
        Dim selectedField As String = "s.Title, s.FamilyName, s.BioData, s.GivenName, s.Position, s.EmployerFull, a.TitleOfPresentation, a.FocusArea1, a.Combine_Speakers, d.RoomNumber, ss.SessionTime, isnull(a.IsCancel,0) as IsCancel"
        Dim condition As String = "where a.AbstractStatus='Registered' and isnull(d.IsEmpty,0)=0 and s.ContactID=" & speakerID
        Return DalSelectCamTESOL.selectQuery("select " & selectedField & " from tblCamTESOLConferenceProgram_AbstractDetail_AllSpeakers s inner join tblCamTESOLConferenceProgram_AbstractDetail a on s.PresentationID=a.PresentationID inner join tblCamTESOLConferenceProgram_SessionDetail d on a.PresentationID=d.PresentationID inner join tblCamTESOLConferenceProgram_Session ss on d.SessionID=ss.SessionID " & condition & " order by ss.SessionNo")
    End Function

    Private Function getProgramPosterBySpeaker(speakerID As Integer) As DataTable
        Dim selectedField As String = "s.ContactID, s.Title, s.BioData, s.FamilyName, s.GivenName, s.Position, s.EmployerFull, a.TitleOfPresentation, a.FocusArea1, a.Combine_Speakers, 'Building A' as RoomNumber, '15:25-17:05' as SessionTime, isnull(a.IsCancel,0) as IsCancel"
        Dim condition As String = "where a.AbstractStatus='Registered' and PreferenceTypeOfSession like '%poster%' and s.ContactID=" & speakerID
        Return DalSelectCamTESOL.selectQuery("select " & selectedField & " from tblCamTESOLConferenceProgram_AbstractDetail_AllSpeakers s inner join tblCamTESOLConferenceProgram_AbstractDetail a on s.PresentationID=a.PresentationID " & condition & " order by s.ContactID")
    End Function

    Protected Sub btnSpeakerInfo_Click(sender As Object, e As EventArgs)
        If Not String.IsNullOrEmpty(hidSpeakerID.Value) AndAlso hidSpeakerID.Value <> "0" Then
            Dim speakerInfoHTML As String = ""
            Dim sessionID As Integer = 0

            Dim dtProgram As DataTable = getProgramBySpeaker(hidSpeakerID.Value)
            If dtProgram.Rows.Count > 0 Then
                speakerInfoHTML &= "<div class='programSpeakerBox' style='margin: 10px 10px 20px 10px;'>"
                speakerInfoHTML &= "<img src='img/profile.png' class='speakerPhoto'/><p class='speakerName'>" & dtProgram.Rows(0)("Title").ToString & " " & dtProgram.Rows(0)("GivenName").ToString & " " & dtProgram.Rows(0)("FamilyName").ToString.ToUpper & "</p>"
                If Not String.IsNullOrEmpty(dtProgram.Rows(0)("Position").ToString) Then
                    speakerInfoHTML &= "<p class='speakerPosition'>" & dtProgram.Rows(0)("Position").ToString & "</p>"
                End If
                If Not String.IsNullOrEmpty(dtProgram.Rows(0)("EmployerFull").ToString) Then
                    speakerInfoHTML &= "<p class='speakerEmployer'>" & dtProgram.Rows(0)("EmployerFull").ToString & "</p>"
                End If
                speakerInfoHTML &= "<div style='clear: both'></div></div>"
                If Not String.IsNullOrEmpty(dtProgram.Rows(0)("BioData").ToString) Then
                    speakerInfoHTML &= "<div class='programSpeakerBox' style='margin: 10px 10px 20px 10px;'><p>" & dtProgram.Rows(0)("BioData").ToString & "</p>"
                    speakerInfoHTML &= "<div style='clear: both'></div></div>"
                End If

                For Each drProgram As DataRow In dtProgram.Rows
                    speakerInfoHTML &= "<div class='programDetailBox' style='margin: 10px 10px 20px 10px;'><span class='programRoomTime'><span class='programRoomSection'><span class='locationIcon'></span><span class='locationValue'>" & drProgram("RoomNumber").ToString & "</span></span><span class='programTimeSection'><span class='timeIcon'></span><span class='timeValue'>" & drProgram("SessionTime").ToString & "</span></span></span><p class='programTitle'>Title: " & drProgram("TitleOfPresentation").ToString & _
                          "</p>"
                    If Not String.IsNullOrEmpty(drProgram("FocusArea1").ToString) Then
                        speakerInfoHTML &= "<p class='programFocusArea'>Stream: " & drProgram("FocusArea1").ToString & "</p>"
                    End If
                    speakerInfoHTML &= "<p class='programSpeaker'>Speaker(s): " & drProgram("Combine_Speakers").ToString & "</p>"
                    If drProgram("IsCancel").ToString = "True" Then
                        speakerInfoHTML &= "<p style='text-align: center; color: red; font-weight: bold;'>Cancelled</p>"
                    End If
                    speakerInfoHTML &= "</div>"
                Next
            End If
            If Request.QueryString("SessionID") IsNot Nothing Then
                Dim dtProgramPoster As DataTable = getProgramPosterBySpeaker(hidSpeakerID.Value)
                If dtProgramPoster.Rows.Count > 0 Then
                    If String.IsNullOrEmpty(speakerInfoHTML) Then
                        speakerInfoHTML &= "<div class='programSpeakerBox' style='margin: 10px 10px 20px 10px;'>"
                        speakerInfoHTML &= "<img src='img/profile.png' class='speakerPhoto'/><p class='speakerName'>" & dtProgramPoster.Rows(0)("Title").ToString & " " & dtProgramPoster.Rows(0)("GivenName").ToString & " " & dtProgramPoster.Rows(0)("FamilyName").ToString.ToUpper & "</p>"
                        If Not String.IsNullOrEmpty(dtProgramPoster.Rows(0)("Position").ToString) Then
                            speakerInfoHTML &= "<p class='speakerPosition'>" & dtProgramPoster.Rows(0)("Position").ToString & "</p>"
                        End If
                        If Not String.IsNullOrEmpty(dtProgramPoster.Rows(0)("EmployerFull").ToString) Then
                            speakerInfoHTML &= "<p class='speakerEmployer'>" & dtProgramPoster.Rows(0)("EmployerFull").ToString & "</p>"
                        End If
                        speakerInfoHTML &= "<div style='clear: both'></div></div>"

                        If Not String.IsNullOrEmpty(dtProgramPoster.Rows(0)("BioData").ToString) Then
                            speakerInfoHTML &= "<div class='programSpeakerBox' style='margin: 10px 10px 20px 10px;'><p>" & dtProgramPoster.Rows(0)("BioData").ToString & "</p>"
                            speakerInfoHTML &= "<div style='clear: both'></div></div>"
                        End If
                    End If
                    For Each drProgram As DataRow In dtProgramPoster.Rows
                        speakerInfoHTML &= "<div class='programDetailBox' style='margin: 10px 10px 20px 10px;'><span class='programRoomTime'><span class='programRoomSection'><span class='locationIcon'></span><span class='locationValue'>" & drProgram("RoomNumber").ToString & "</span></span><span class='programTimeSection'><span class='timeIcon'></span><span class='timeValue'>" & drProgram("SessionTime").ToString & "</span></span></span><p class='programTitle'>Title: " & drProgram("TitleOfPresentation").ToString & _
                              "</p>"
                        If Not String.IsNullOrEmpty(drProgram("FocusArea1").ToString) Then
                            speakerInfoHTML &= "<p class='programFocusArea'>Stream: " & drProgram("FocusArea1").ToString & "</p>"
                        End If
                        speakerInfoHTML &= "<p class='programSpeaker'>Speaker(s): " & drProgram("Combine_Speakers").ToString & "</p>"
                        If drProgram("IsCancel").ToString = "True" Then
                            speakerInfoHTML &= "<p style='text-align: center; color: red; font-weight: bold;'>Cancelled</p>"
                        End If
                        speakerInfoHTML &= "</div>"
                    Next
                End If
            End If

            popupContentSpeakerInfo.InnerHtml = speakerInfoHTML
            ScriptManager.RegisterStartupScript(panelProgram, panelProgram.GetType, "fadeIn", "fadeIn('" & popupBoxSpeakerInfo.ClientID & "')", True)
        End If
    End Sub

    Protected Sub lnkBack_Click(sender As Object, e As EventArgs)
        If Request.QueryString("UserID") IsNot Nothing Then
            Session("conferenceType") = hidConferenceType.Value
            Session("confDayActive") = hidConfDayActive.Value
            Session("timeBoxActive") = hidTimeBoxActive.Value
            Session("programScrollTop") = hidProgramScrollTop.Value
            Session("searchKeyword") = hidSearch.Value
            Session("searchConfDay") = hidSearchConfDay.Value
            Session("searchConfTime") = hidSearchConfTime.Value
            Session("searchStream") = hidSearchStream.Value
            Session("searchBookmark") = hidSearchBookmark.Value

            Dim query As String = "?UserID=" & Request.QueryString("UserID").ToString()
            If Request.QueryString("DeviceID") IsNot Nothing Then
                query &= "&DeviceID=" & Request.QueryString("DeviceID").ToString()
            End If

            Response.Redirect("~/ProgramMonitor.aspx" & query)
        End If
    End Sub
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
    Protected Sub hrefBack_ServerClick(sender As Object, e As EventArgs)
        If Request.QueryString("UserID") IsNot Nothing Then
            Session("conferenceType") = hidConferenceType.Value
            Session("confDayActive") = hidConfDayActive.Value
            Session("timeBoxActive") = hidTimeBoxActive.Value
            Session("programScrollTop") = hidProgramScrollTop.Value
            Session("searchKeyword") = hidSearch.Value
            Session("searchConfDay") = hidSearchConfDay.Value
            Session("searchConfTime") = hidSearchConfTime.Value
            Session("searchStream") = hidSearchStream.Value
            Session("searchBookmark") = hidSearchBookmark.Value

            Dim query As String = "?UserID=" & Request.QueryString("UserID").ToString()
            If Request.QueryString("user") IsNot Nothing Then
                query &= "&user=" & Request.QueryString("user").ToString()
            End If
            If Request.QueryString("DeviceID") IsNot Nothing Then
                query &= "&DeviceID=" & Request.QueryString("DeviceID").ToString()
            End If
            If Request.QueryString("PresenterID") IsNot Nothing Then query &= "&PresenterID=" & Request.QueryString("PresenterID").ToString

            Response.Redirect("~/ProgramMonitor.aspx" & query)
        End If
    End Sub
End Class
