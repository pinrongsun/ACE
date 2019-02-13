Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports EDBService2
Imports System.Text
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Net
Imports System.Net.Mail
Imports System.Web.Services

Partial Class ACEApp
    Inherits System.Web.UI.Page
    Public OriginalUrl As String
    Public ContactID As Integer
    Public CheckFlipFlop As Boolean = False
    Public ContactIDEncrypt As String
    'Private ACEWebsite As String = "https://acecambodia.org"
    Private ACEWebsite As String = "http://localhost:17770/"
    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init

        'UrlFriendly("ACEApp")

    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            '  iframeRegistration.Attributes("src") = iframeRegistration.Attributes("src").Replace("_user_", Request.QueryString("user").ToString)

            'MultiView1.ActiveViewIndex = 1
            'MultiView2.ActiveViewIndex = 0

            If Request.Url.ToString.Contains("user=") = False Then
                Response.Redirect("login.aspx")
            Else
                lblUserName.Text = DalUser.getUserByEmail(Request.QueryString("user")).givenName.ToString
            End If

            'Response.Cookies.Remove(FormsAuthentication.FormsCookieName)
            'FormsAuthentication.SetAuthCookie(Request.QueryString("user"), False)

            'lstDate.DataSourceID = ""

            'ace_banner.Src = Server.MapPath("img/Banner2017_Resized.jpg")
            'ace_banner.Src = ACEWebsite & "/img/Banner2017_Resized.jpg"

            divArticle.Visible = False

            div_change_password.Visible = False

            Dim PresenterID As Integer = 0
            If Request.Url.ToString.Contains("PresenterID") Then
                PresenterID = Request.QueryString("PresenterID")
            End If

            LoadMenu(Request.QueryString("user"), Request.QueryString("deviceid"), PresenterID)
            LoadNewBreadcrumb("eace.aspx")

        End If

        divNoShow.Visible = False
    End Sub
    Private Sub LoadStream()
        'Dim BalGl As New BalGlobal_app
        Dim camtesol_service As New CamTESOLSchedule.edbserviceSoapClient

        'Dim ds As DataSet = BalGl.getDataFromTable("tblProgram", "*", "FamilyName, GivenName", "Where PresentationID=" & presentationid, "asc")
        Dim dt As DataTable = camtesol_service.camtesol_schedule("tblCamTESOLConferenceProgramView", "distinct FocusArea1 as Stream", "", "Stream", "asc")

        'Dim ds As DataSet = BalGl.getDataFromTable("tblProgram", "distinct FocusArea1 as Stream", "Stream", "", "ASC")
        Dim dr As DataRow = dt.NewRow
        dr("Stream") = ""
        dt.Rows.Add(dr)
        Dim dv As DataView = dt.DefaultView
        dv.Sort = "Stream ASC"

        dplStream.DataSourceID = ""
        dplStream.DataSource = dv.ToTable
        dplStream.DataTextField = "Stream"
        dplStream.DataValueField = "Stream"
        dplStream.DataBind()

    End Sub
    Private Sub LoadTime(Day As String)
        Dim BalGl As New BalGlobal_app
        Dim DayString As String = ""
        If Day = "Friday" OrElse Day = "Fri" Then
            DayString = "2017-02-17"
        ElseIf Day = "Saturday" OrElse Day = "Sat" Then
            DayString = "2017-02-18"
        ElseIf Day = "Sunday" OrElse Day = "Sun" Then
            DayString = "2017-02-19"
        End If
        Dim camtesolservice As New CamTESOLSchedule.edbserviceSoapClient


        Dim ds As New DataSet '= BalGl.getDataFromTable("tblProgram", "distinct SessionTime as Time", "Time", "Where SessionDate='" & DayString & "'", "ASC")
        ds.Tables.Add(camtesolservice.camtesol_schedule("tblCamTESOLConferenceProgramView_SessionDetail", "distinct SessionTime as Time", "Where SessionDate='" & DayString & "'", "Time", "asc"))
        Dim dr As DataRow = ds.Tables(0).NewRow
        dr("Time") = ""
        ds.Tables(0).Rows.Add(dr)

        Dim dv As DataView = ds.Tables(0).DefaultView
        dv.Sort = "Time ASC"
        dplTime.DataSourceID = ""
        dplTime.DataSource = dv
        dplTime.DataTextField = "Time"
        dplTime.DataValueField = "Time"
        dplTime.DataBind()

    End Sub
    Sub LoadBreadscrum(WebsiteName As String)
        Dim Breadscrum As String = ""
        If OriginalUrl <> "" Then
            Dim path() As String
            Dim linkpath As String = "/" & WebsiteName
            path = OriginalUrl.Split("/")

            If path.Count > 0 Then

                For i = 0 To path.Count - 1
                    If path(i).ToString <> "" And path(i).ToString.Contains("eace.aspx") = False Then
                        If path(i).ToString.ToLower = WebsiteName.ToLower Then
                            ' Breadscrum = "<a href='http://acecambodia.org'><Span style='color:white;margin-bottom:15px;font-weight:bold;font-size:16px;font-family:Helvetica'><B>Log out</B></Span></a>"
                            Breadscrum = "<a href='http://acecambodia.org'><Span style='color:white;margin-bottom:15px;font-weight:bold;font-size:16px;font-family:Helvetica'><B>Log out</B></Span></a>"
                        ElseIf path(i).ToString.ToLower = "Home".ToLower Then
                            Breadscrum = Breadscrum
                        Else
                            If i = path.Count - 1 Then
                                'Breadscrum = Breadscrum & " <img style='width:8px'  src='img/breadcrumb_icon.png' /> " & path(i).ToString
                                Breadscrum = Breadscrum & "  " & path(i).ToString
                            Else
                                linkpath = linkpath & "/" & path(i)
                                ' Breadscrum = Breadscrum & " <img style='width:8px'  src='img/breadcrumb_icon.png' /> <a href='" & linkpath & "' style='color:white'>" & path(i).ToString & "</a>"
                                Breadscrum = Breadscrum & "  <a href='" & linkpath & "' style='color:white'>" & path(i).ToString & "</a>"
                            End If

                        End If
                    End If
                Next
            End If
        End If

        If Breadscrum = "" Then
            Div_Breadscrum.InnerHtml = Breadscrum
        Else
            Div_Breadscrum.InnerHtml = "<a href='/" & WebsiteName & "/Home' style='color:white'>Home</a>" & Breadscrum
        End If

    End Sub
    Sub LoadNewBreadcrumb(WebsiteName As String)
        Dim BALG As New BalGlobal_app
        Dim div_breadcrumb As String = ""

        If Request.Url.ToString.Contains("MenuID=") = True And Request.Url.ToString.Contains("ArticleID=") = True Then
            Dim MenuName As String = ""
            Dim dss As New DataSet
            dss = BALG.getDataFromTable("tblMenu_App_CMS", "*", "MenuID", "where MenuID=" & Request.QueryString("MenuID"), "asc")
            If dss.Tables(0).Rows.Count > 0 Then
                'MenuName = dss.Tables(0).Rows(0)("MenuName").ToString
                MenuName = "<a href='eace.aspx?ContactID=" & ContactIDEncrypt & "' style='color: #047bbf;'>Home</a>" & _
                " <img style='width:8px'  src='img/breadcrumb_icon.png' />" & dss.Tables(0).Rows(0)("MenuName").ToString
            End If


            'div_breadcrumb = "<a href='eace.aspx?ContactID=" & ContactIDEncrypt & "' style='color:white'>Home</a>" & _
            '    " <img style='width:8px'  src='img/breadcrumb_icon.png' />" & _
            '    " " & MenuName


            div_breadcrumb = "" & _
                " " & MenuName
        End If

        If Request.Url.ToString.Contains("StudentProfile=Edit") = True Then
            div_breadcrumb = "<a href='eace.aspx?ContactID=" & ContactIDEncrypt & "' style='color:white'>Home</a>" & _
                " <img style='width:8px'  src='img/breadcrumb_icon.png' />" & _
                "<a href='eace.aspx?MenuID=8&ArticleID=0&ContactID=" & ContactIDEncrypt & "' style='color:white'> Profile</a>" & " <img style='width:8px'  src='../../../../img/breadcrumb_icon.png' /> Edit"
        End If

        If Request.Url.ToString.Contains("StudentProfile=Changepassword") = True Then
            div_breadcrumb = "<a href='eace.aspx?ContactID=" & ContactIDEncrypt & "' style='color:white'>Home</a>" & _
                " <img style='width:8px'  src='img/breadcrumb_icon.png' />" & _
                "<a href='eace.aspx?MenuID=8&ArticleID=0&ContactID=" & ContactIDEncrypt & "' style='color:white'> Profile</a>" & " <img style='width:8px'  src='../../../../img/breadcrumb_icon.png' /> Change Password"
        End If


        If Request.Url.ToString.Contains("ProgramID=") = True Then
            Dim MenuName As String = ""
            Dim ArticleID As String = ""
            Dim dss As New DataSet
            dss = BALG.getDataFromTable("tblMenu_CMS", "*", "MenuID", "where MenuID=" & Request.QueryString("MenuID"), "asc")
            If dss.Tables(0).Rows.Count > 0 Then
                MenuName = dss.Tables(0).Rows(0)("MenuName").ToString
                ArticleID = dss.Tables(0).Rows(0)("ArticleID").ToString
            End If


            Dim ProgramID = Request.QueryString("ProgramID")
            Dim ds As New DataSet
            Dim menuid As String = ""
            menuid = Request.QueryString("MenuID")

            ds = BALG.getDataFromTable("tblCourse_CMS", "*", "ProgramID", "where ProgramID=" & ProgramID, "asc")
            If ds.Tables(0).Rows.Count > 0 Then
                div_breadcrumb = "<a href='eace.aspx?ContactID=" & ContactIDEncrypt & "' style='color:white'>Home</a>" & _
                " <img style='width:8px'  src='img/breadcrumb_icon.png' />" & _
                "<a href='" & WebsiteName & "?MenuID=" & menuid & "&ArticleID=" & ArticleID & "&ContactID=" & ContactIDEncrypt & "' style='color:white'>" & " " & MenuName & "</a>" & _
                " <img style='width:8px'  src='img/breadcrumb_icon.png' />" & _
                " " & ds.Tables(0).Rows(0)("Name").ToString
            End If

        End If

        Div_Breadscrum.InnerHtml = div_breadcrumb

    End Sub
    Sub LoadMenu(email As String, deviceid As String, PresenterID As Integer)
        Dim BalGl As New BalGlobal_app

        Dim QueryStringPresenter As String = "&PresenterID=0"
        If PresenterID <> 0 Then
            QueryStringPresenter = "&PresenterID=" & PresenterID
        End If

        Dim dsRightBanner As DataSet
        'If PresenterID <> 0 Then
        '    dsRightBanner = BalGl.getDataFromTable("tblMenu_App_CMS", "*", "MenuOrder", "where Isnull(Visible,0)=1 and Isnull(Deleted,0)=0 and MenuID<>8 and MenuID in (13,19,25,14)", "asc")
        'Else
        '    dsRightBanner = BalGl.getDataFromTable("tblMenu_App_CMS", "*", "MenuOrder", "where Isnull(Visible,0)=1 and Isnull(Deleted,0)=0 and MenuID<>8 and isnull(forPresenter,0)=0 and MenuID in (13,19,25,14)", "asc")
        'End If
        If PresenterID <> 0 Then
            dsRightBanner = BalGl.getDataFromTable("tblMenu_App_CMS", "*", "MenuOrder", "where Isnull(Visible,0)=1 and Isnull(Deleted,0)=0 and MenuID<>8 ", "asc")
        Else
            dsRightBanner = BalGl.getDataFromTable("tblMenu_App_CMS", "*", "MenuOrder", "where Isnull(Visible,0)=1 and Isnull(Deleted,0)=0 and MenuID<>8 ", "asc")
        End If

        'Dim dsuser As DataSet = GetUser("isnull(Admin,0) as Admin", "UserID", "where UserEmail='" & email & "'", "asc")
        'If dsuser.Tables(0).Rows.Count > 0 Then
        '    Dim Admin As Boolean = dsuser.Tables(0).Rows(0)("Admin")
        '    If Admin = True Then
        '        'dsRightBanner = BalGl.getDataFromTable("tblMenu_App_CMS", "*", "MenuOrder", "where (Isnull(Visible,0)=1 and Isnull(Deleted,0)=0 and MenuID<>8) or MenuID=20 or MenuID=21", "asc")
        '        dsRightBanner = BalGl.getDataFromTable("tblMenu_App_CMS", "*", "MenuOrder", "where (Isnull(Visible,0)=1 and Isnull(Deleted,0)=0 and MenuID<>8)", "asc")
        '    End If
        'End If

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
        'hrefAccommodation.HRef = "http://114.134.189.211:84/Camtesol/2019%20Conference/Accommodation"
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

            If dt1.Rows(i)("ArticleID") = 108 Then
                hrefAboutCamTESOL.HRef = "/eace.aspx?MenuID=" & dt1.Rows(i)("MenuID").ToString & "&ArticleID=" & dt1.Rows(i)("ArticleID").ToString & "&user=" & email & "&deviceid=" & deviceid & QueryStringPresenter & "&Static=" & static_page
            End If
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
            If dt1.Rows(i)("ArticleID") = 106 Then
                hrefRegistration.HRef = "/eace.aspx?MenuID=" & dt1.Rows(i)("MenuID").ToString & "&ArticleID=" & dt1.Rows(i)("ArticleID").ToString & "&user=" & email & "&deviceid=" & deviceid & QueryStringPresenter & "&Static=" & static_page
            End If
            If dt1.Rows(i)("ArticleID") = 0 Then
                hrefLogOut.HRef = "/eace.aspx?MenuID=" & dt1.Rows(i)("MenuID").ToString & "&ArticleID=" & dt1.Rows(i)("ArticleID").ToString & "&user=" & email & "&deviceid=" & deviceid & QueryStringPresenter & "&Static=" & static_page
            End If
            If dt1.Rows(i)("ArticleID") = 109 Then
                hrefPlenarySpeaker.HRef = "/eace.aspx?MenuID=" & dt1.Rows(i)("MenuID").ToString & "&ArticleID=" & dt1.Rows(i)("ArticleID").ToString & "&user=" & email & "&deviceid=" & deviceid & QueryStringPresenter & "&Static=" & static_page
            End If
            If dt1.Rows(i)("ArticleID") = 11 Then
                hrefVenue.HRef = "/eace.aspx?MenuID=" & dt1.Rows(i)("MenuID").ToString & "&ArticleID=" & dt1.Rows(i)("ArticleID").ToString & "&user=" & email & "&deviceid=" & deviceid & QueryStringPresenter & "&Static=" & static_page
            End If
            If dt1.Rows(i)("ArticleID") = 20 Then
                hrefContactUs.HRef = "/eace.aspx?MenuID=" & dt1.Rows(i)("MenuID").ToString & "&ArticleID=" & dt1.Rows(i)("ArticleID").ToString & "&user=" & email & "&deviceid=" & deviceid & QueryStringPresenter & "&Static=" & static_page
            End If
            If dt1.Rows(i)("ArticleID") = 105 Then
                hrefSponsor.HRef = "/eace.aspx?MenuID=" & dt1.Rows(i)("MenuID").ToString & "&ArticleID=" & dt1.Rows(i)("ArticleID").ToString & "&user=" & email & "&deviceid=" & deviceid & QueryStringPresenter & "&Static=" & static_page
            End If
            If dt1.Rows(i)("ArticleID") = 125 Then
                hrefAccommodation.HRef = "/eace.aspx?MenuID=" & dt1.Rows(i)("MenuID").ToString & "&ArticleID=" & dt1.Rows(i)("ArticleID").ToString & "&user=" & email & "&deviceid=" & deviceid & QueryStringPresenter & "&Static=" & static_page
            End If
            If dt1.Rows(i)("ArticleID") = 56 Then
                'hrefProgram.HRef = "/eace.aspx?MenuID=" & dt1.Rows(i)("MenuID").ToString & "&ArticleID=" & dt1.Rows(i)("ArticleID").ToString & "&user=" & email & "&deviceid=" & deviceid & QueryStringPresenter & "&Static=" & static_page
                hrefProgram.HRef = "/eace.aspx?MenuID=0&ArticleID=109&user=" & email & "&deviceid=" & deviceid & QueryStringPresenter & "&Static=" & static_page
            End If
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
				hrefProgram.Href = "program.aspx" & query
            End If
		End If

        iconList &= "</ul>"
        icon_List.InnerHtml = iconList
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

        div_popup_enrolment.InnerHtml = Code_enrol

        divmenu.InnerHtml = Code
        'LoadProfileButton()

    End Sub

    Private Function GetUser(ByVal DisplayFields As String, ByVal SortField As String, ByVal Condition As String, ByVal SortOrder As String) As DataSet

        Dim ds As New DataSet
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim adapter As New SqlDataAdapter
        'cn.ConnectionString = "server=192.168.3.3;database=CamTESOL;uid=sa;pwd=ACEidp.99"
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

    Public Sub ExportToPDF(ByVal ReportPath As String, UserName As String, dt As DataTable, path As String)
        'Dim BalGlobal_app As New BalGlobal_app
        ''Dim NewFolderName As String = "Email"
        ''System.IO.Directory.CreateDirectory("C:\\" & NewFolderName)
        'Dim crReportDocument As New ReportDocument()
        'crReportDocument = DalReport_app.Instance.GetReport(crReportDocument.GetType())
        'Dim rptPath As String
        'rptPath = ReportPath
        'crReportDocument.Load(rptPath)

        ''Dim dt As DataSet = BalGlobal_app.getDataFromTable("ViewRegister", "*", "UserName", "Where UserName='" & UserName & "'", "asc")

        ''dv.RowFilter = "StudentName=" & dt.Rows(i)("StudentName")
        'crReportDocument.SetDataSource(dt)


        'Dim pdfName As String
        'pdfName = UserName   'dv(0)("StudentName")
        ''pdfName = dv(0)("ContactID")
        'pdfName = Replace(pdfName, "'", " ")
        'pdfName = Replace(pdfName, ",", " ")
        'pdfName = Replace(pdfName, ";", " ")
        'pdfName = Replace(pdfName, "\", " ")
        'pdfName = Replace(pdfName, "/", " ")
        'pdfName = Replace(pdfName, ":", " ")
        'pdfName = Replace(pdfName, "*", " ")
        'pdfName = Replace(pdfName, "?", " ")
        'pdfName = Replace(pdfName, "<", " ")
        'pdfName = Replace(pdfName, ">", " ")
        'pdfName = Replace(pdfName, "|", " ")


        'Dim crExportOptions As New ExportOptions
        'Dim crDiskFileDestinationOptions As New DiskFileDestinationOptions()

        'crDiskFileDestinationOptions.DiskFileName = path & "\\Receipt" & "\\" & pdfName & ".pdf"

        'crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
        'crExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat
        'crExportOptions.ExportDestinationOptions = crDiskFileDestinationOptions
        'crReportDocument.Export(crExportOptions)
        'CrystalReportViewer1.ReportSource = Nothing

    End Sub

    Function CutMapPath() As String
        Dim path() As String
        Dim pat As String = ""
        Dim orignal As String = ""

        orignal = Server.MapPath("CrystalReport.rpt")

        path = orignal.Split("\")

        Dim count As Integer = path.Count

        For i = 0 To path.Count - 1
            If i < path.Count - 1 Then
                pat = pat & path(i).ToString & "\"
            End If
        Next

        Return pat

    End Function

    Private Function Get_output_html(url As String) As String
        ' We'll use WebClient class for reading HTML of web page
        Dim MyWebClient As WebClient = New WebClient()

        ' Read web page HTML to byte array
        Dim PageHTMLBytes() As Byte
        If url <> "" Then
            PageHTMLBytes = MyWebClient.DownloadData(url)

            ' Convert result from byte array to string
            ' and display it in TextBox txtPageHTML
            Dim oUTF8 As UTF8Encoding = New UTF8Encoding()
            Return oUTF8.GetString(PageHTMLBytes)
        Else
            Return ""
        End If

    End Function

    Public Shared Function getHtmlFeed(dsContent As DataSet, page As Integer, AndroidID As String, deviceid As String, PresenterID As String) As String
        'Dim html As String = ""
        Dim BalArticle As New BalGlobal_app
        Dim html_content As String = ""
        If dsContent.Tables(0).Rows.Count > 0 Then
            For i = 0 To dsContent.Tables(0).Rows.Count - 1
                Dim FeedID As Integer = dsContent.Tables(0).Rows(i)("FeedID").ToString
                Dim PostDate As String = CDate(dsContent.Tables(0).Rows(i)("PostDate")).ToString("dd/MM/yyyy H:mm")
                Dim dsFeedDetail As DataSet = BalArticle.getDataFromTable("tblFeedDetail", "FeedID", "FeedID", "Where FeedID=" & FeedID & " And AndroidID='" & AndroidID & "'", "asc")
                If dsFeedDetail.Tables(0).Rows.Count = 0 Then
                    BalArticle.InsertToTable("tblFeedDetail", "FeedID, AndroidID, ViewDate", FeedID & ",'" & AndroidID & "','" & Now.ToString("yyyy-MM-dd H:mm") & "'")
                End If
                Dim html_content_each As String = "<div style='margin-top:50px;margin-right: 20px;'>" & dsContent.Tables(0).Rows(i)("ArticleContent").ToString.Replace("?PostDate", PostDate).Replace("_AndroidID_", AndroidID) & "</div>"
                html_content_each = html_content_each.Replace("Upload_s\", "Upload_s/").Replace("Upload_s", "http://camtesolapp.acecambodia.org/Upload_s")
                html_content = html_content & html_content_each
            Next

            Dim dtUserID2 As DataTable = selectQuery("select u.UserID from tblUserlogin u inner join tblRegisterContact c on c.ContactID=u.ContactID where isnull(c.Deleted,0)=0 and lower(UserEmail)='" & AndroidID.ToString.Trim.ToLower & "'")
            If dtUserID2.Rows.Count > 0 Then
                html_content = html_content.Replace("_userid_", dtUserID2.Rows(0)("UserID").ToString)
            Else
                html_content = html_content.Replace("_userid_", "0")
            End If
            html_content = html_content.Replace("_user_", AndroidID).Replace("_deviceid_", deviceid).Replace("_PresenterID_", PresenterID)
            html_content = html_content & "<div style='text-align: center;'><input class='btn btn-default' id='button" & page & "' type='button' value='Load More' onclick='loaddata()' style='color: black;border-color: blue;'/></div>"
        End If
        
        '<div style="text-align: center;"><input class="btn btn-default" id="button0" type="button" value="Load More" onclick="loaddata()" style="color: black;border-color: blue;"></div>
        Return html_content
    End Function

    <System.Web.Services.WebMethod()> _
    Public Shared Function LoadFeed(page As Integer, AndroidID As String, deviceid As String, PresenterID As String) As String
        Dim balGl As New BalGlobal_app
        Dim StartIndex As Integer = page * 5 + 1
        Dim EndIndex As Integer = StartIndex + (5 - 1)
        Dim tbl As String = "(select Row_Number() over (order by PostDate desc) as RowIndex, * from ViewFeeds Where (isnull(Visible,0) = 1 and PostDate<=getdate()) ) as t"
        Dim ds As DataSet = balGl.getDataFromTable(tbl, "t.*", "t.RowIndex", "Where t.RowIndex >= " & StartIndex & " and t.RowIndex <= " & EndIndex, "asc")


        Return getHtmlFeed(ds, page, AndroidID, deviceid, PresenterID)

    End Function
    Protected Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim ArticleID As Integer = 0

        If Request.Url.ToString.Contains("Program_MenuID=") = True Then
            Dim Program_MenuID = Request.QueryString("Program_MenuID")
            Dim ds As New DataSet
            Dim BALG As New BalGlobal_app

            ds = BALG.getDataFromTable("tblMenu_CMS", "*", "MenuID", "where MenuID=" & Program_MenuID, "asc")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim ace_website As String = "http://smwks015:82"
                'http://smwks015:82/ACEWebsite/English%20Programs/Childrens%20Programs%20%28CP%29
                Dim program As String = ds.Tables(0).Rows(0)("MenuName").ToString.Replace("'", "").Replace(":", "").Replace("?", "").Replace("/", "")

                Exit Sub
            End If
        End If

        MultiView1.Visible = True
        div_fullprogram.Visible = False

        If Request.Url.ToString.Contains("MenuID=") = True Then
            Dim BalGlobal As New BalGlobal_app

            BalGlobal.InsertToTable("tblTransactionLog", "UserName, Action, Entity, ContactID, EntityMainID, TransactionDate", _
                                    "'" & Request.QueryString("user") & "','" & "Access Menu ID'" & _
                                    ",'tblMenu_App_CMS'," & 0 & "," & Request.QueryString("MenuID") & "," & "CONVERT(DATETIME, '" & Now.ToString("yyyy/MM/dd HH:mm:ss") & "', 102)")
        End If
		
		If Request.QueryString("MenuID") IsNot Nothing Then
			If Request.QueryString("MenuID").ToString = "19" Then
				Dim presID as Integer = 0
				If Request.QueryString("PresenterID") IsNot Nothing Then presID = Request.QueryString("PresenterID").ToString
                Response.Redirect("http://114.134.189.211:84/MyCamTESOL?AppView=AbstractSub&user=" & Request.QueryString("user") & "&deviceid=" & Request.QueryString("deviceid") & "&PresenterID=" & presID)
				Exit Sub
			ElseIf Request.QueryString("MenuID").ToString = "24" Then
				Dim presID as Integer = 0
				If Request.QueryString("PresenterID") IsNot Nothing Then presID = Request.QueryString("PresenterID").ToString
				Response.Redirect("~/Speaker.aspx?speakertype=featured&user=" & Request.QueryString("user").ToString & "&deviceid=" & Request.QueryString("deviceid").ToString & "&PresenterID=" & presID)
				Exit Sub
			End If
        End If
        If Request.QueryString("MenuID") IsNot Nothing Then
            If Request.QueryString("MenuID").ToString = "23" Then
                Response.Redirect("http://114.134.189.211:84/MyCamTESOL?AppView=Registration&user=" & Request.QueryString("user") & "&deviceid=" & Request.QueryString("deviceid"))
                Exit Sub
            End If
        End If

        If Request.Url.ToString.Contains("MenuID=10") = True Then
            imgNews.Style.Add("background", "#72ccf7")
            imgProgram.Style.Add("background", "#fff")
            imgHome.Style.Add("background", "#fff")

            Dim BalArticle As New BalGlobal_app
            Dim dsContent As New DataSet
            divArticle.Visible = True
            divNoShow.Visible = False
            Session("search_program") = 0
            divmenu.Visible = False
            Div_Breadscrum.Visible = True
            hrefBack.Visible = True
            Dim AndroidID As String = Request.QueryString("user")


            'dsContent = BalArticle.getDataFromTable("ViewFeeds", "*", "PostDate", "Where (isnull(Visible,0) = 1)", "desc")
            'Dim html_content As String = ""
            'If dsContent.Tables(0).Rows.Count > 0 Then
            '    For i = 0 To dsContent.Tables(0).Rows.Count - 1
            '        Dim FeedID As Integer = dsContent.Tables(0).Rows(i)("FeedID").ToString
            '        Dim PostDate As String = CDate(dsContent.Tables(0).Rows(i)("PostDate")).ToString("dd/MM/yyyy H:mm")
            '        Dim dsFeedDetail As DataSet = BalArticle.getDataFromTable("tblFeedDetail", "FeedID", "FeedID", "Where FeedID=" & FeedID & " And AndroidID='" & AndroidID & "'", "asc")
            '        If dsFeedDetail.Tables(0).Rows.Count = 0 Then
            '            BalArticle.InsertToTable("tblFeedDetail", "FeedID, AndroidID, ViewDate", FeedID & ",'" & AndroidID & "','" & Now.ToString("yyyy-MM-dd H:mm") & "'")
            '        End If
            '        Dim html_content_each As String = "<div style='margin-top:50px;margin-right: 20px;'>" & dsContent.Tables(0).Rows(i)("ArticleContent").ToString.Replace("?PostDate", PostDate).Replace("_AndroidID_", AndroidID) & "</div>"
            '        html_content_each = html_content_each.Replace("Upload_s\", "Upload_s/").Replace("Upload_s", ACEWebsite & "/Upload_s")
            '        html_content = html_content & html_content_each
            '    Next
            'End If
            'Dim dtUserID2 As DataTable = selectQuery("select u.UserID from tblUserlogin u inner join tblRegisterContact c on c.ContactID=u.ContactID where isnull(c.Deleted,0)=0 and lower(UserEmail)='" & Request.QueryString("user").ToString.Trim.ToLower & "'")
            'If dtUserID2.Rows.Count > 0 Then
            '    html_content = html_content.Replace("_userid_", dtUserID2.Rows(0)("UserID").ToString)
            'Else
            '    html_content = html_content.Replace("_userid_", "0")
            'End If
            'divArticle.InnerHtml = html_content.Replace("_user_", Request.QueryString("user")).Replace("_deviceid_", Request.QueryString("deviceid")).Replace("_PresenterID_", Request.QueryString("PresenterID"))
            Exit Sub

        ElseIf Request.Url.ToString.Contains("MenuID=14") Then
            Dim BalGl As New BalGlobal_app
            BalGl.UpdateValueInTable("tblDeviceLogin", "LogoutDate='" & BalGl.GetServerCurrentDate.ToString("yyyy-MM-dd HH:mm:ss") & "'", "Where email='" & Request.QueryString("user") & "' and deviceid='" & Request.QueryString("deviceid") & "'")
            Response.Redirect("http://114.134.189.211:84/Login.aspx?AppView=LogOut&deviceid=" & Request.QueryString("deviceid"))
            'ElseIf Request.Url.ToString.Contains("MenuID=1") = True Then
            '    If Request.QueryString("MenuID") = 1 Then
            '        divNoShow.Visible = True
            '        divArticle.Visible = False


            '        Session("search_program") = 1
            '        Exit Sub
            '    End If
        ElseIf Request.Url.ToString.Contains("MenuID=18") Then
            Dim PresenterID As Integer = Request.QueryString("PresenterID")
            Call LoadAbstract(PresenterID)
            Exit Sub

        ElseIf Request.Url.ToString.Contains("MenuID=16") Then
            Dim PresenterID As Integer = Request.QueryString("PresenterID")
            divArticle.Visible = False
            iframeRegistration.Visible = True
            'Call LoadRegistration(PresenterID)
            Exit Sub
        ElseIf Request.QueryString("MenuID") IsNot Nothing AndAlso (Request.QueryString("MenuID") = "1" OrElse Request.QueryString("MenuID") = "9") Then
            Dim dtUserID As DataTable = selectQuery("select u.UserID from tblUserlogin u inner join tblRegisterContact c on c.ContactID=u.ContactID where isnull(c.Deleted,0)=0 and lower(UserEmail)='" & Request.QueryString("user").ToString & "'")
            If dtUserID.Rows.Count > 0 Then
                If Request.QueryString("MenuID") = "1" Then
                    Response.Redirect("http://114.134.189.211:2020/Program.aspx?UserID=" & dtUserID.Rows(0)("UserID").ToString() & "&deviceid=" & Request.QueryString("deviceid").ToString)
                ElseIf Request.QueryString("MenuID") = "9" Then
                    Response.Redirect("http://114.134.189.211:2020/Bookmark.aspx?UserID=" & dtUserID.Rows(0)("UserID").ToString() & "&deviceid=" & Request.QueryString("deviceid").ToString)
                End If
            End If
        ElseIf Request.Url.ToString.Contains("MenuID=20") Then
            'user=chanpheakdey.vong@idp.com&deviceid=123&PresenterID=3
            Response.Redirect("http://app.camtesol.org/Messenger.aspx?user=" & Request.QueryString("user") & "&deviceid=" & Request.QueryString("deviceid") & "&PresenterID=" & Request.QueryString("PresenterID"))
            Exit Sub
        ElseIf Request.Url.ToString.Contains("MenuID=21") Then
            'user=chanpheakdey.vong@idp.com&deviceid=123&PresenterID=3
            Response.Redirect("http://app.camtesol.org/SearchParticipant.aspx?user=" & Request.QueryString("user") & "&deviceid=" & Request.QueryString("deviceid") & "&PresenterID=" & Request.QueryString("PresenterID"))
            Exit Sub
        ElseIf Request.Url.ToString.Contains("MenuID=9") Then

            'MultiView1.Visible = False
            Try

                div_fullprogram.Visible = False
                divArticle.Visible = False
                divNoShow.Visible = True
                'Dim BalGl As New BalGlobal_app
                'BalGl.DeleteFromTable("tblPresentationSelected_Temp", "Where Email='" & Request.QueryString("user") & "'")
                'Call Load_SelectedPresentation_Temp(Request.QueryString("user"))
                Dim padding As String = "<div style=""width:100%; margin-left: 10px; margin-bottom: 10px;margin-top: 0px;""><div style=""margin-top:10px;margin-right: 20px;""><p>"
                Dim close_padding As String = "</p></div></div>"
                div_search_result.InnerHtml = padding & "The full presentation program for <b>Regional ELT Research Symposium</b> and <b>Main Conference</b> of the 14th Annual CamTESOL Conference will be available on <b>22 January 2018</b>. " & close_padding
                'load_search(Request.QueryString("user"), "", 5)
                MultiView1.Visible = False
            Catch ex As Exception

            End Try

            Exit Sub
        ElseIf Request.Url.ToString.Contains("MenuID=0") Then
            imgNews.Style.Add("background", "#fff")
            imgProgram.Style.Add("background", "#fff")
            imgHome.Style.Add("background", "#72ccf7")
        End If

        Session("search_program") = 0

        If Request.Url.ToString.Contains("EnrolmentHistory") = True Then

            If Request.Url.ToString.Contains("PrintID=") = True Then
                Dim test As String
                Dim edb As New EDBService.edbserviceSoapClient
                test = edb.Decrypt(Request.QueryString("PrintID").ToString)

                Dim path As String = CutMapPath()


                ExportToPDF(path & "CrystalReport.rpt", test, Session(test), path)

                Response.ContentType = "application/pdf"
                Response.AppendHeader("Content-Disposition", "attachment; filename=" & test & ".pdf")
                Response.TransmitFile("~/Receipt/" & test & ".pdf")
                Response.End()

                'End If
            End If
        End If

        If Request.Url.ToString.Contains("ArticleID=") = True Then
            ArticleID = Request.QueryString("ArticleID")
        Else
            ArticleID = 16
        End If

        If ArticleID <> 0 Then
            Dim BalArticle As New BalGlobal_app
            Dim dsContent As New DataSet

            divmenu.Visible = False
            Div_Breadscrum.Visible = True
            If ArticleID = 11 Then
                hrefBack.Visible = True
            ElseIf ArticleID = 125 Then
                hrefBack.Visible = True
            ElseIf ArticleID = 20 Then
                hrefBack.Visible = True
            ElseIf ArticleID = 108 Then
                hrefBack.Visible = True
            ElseIf ArticleID = 105 Then
                hrefBack.Visible = True
            End If
            If ArticleID = 6 Then
                divNoShow.Visible = True
                divArticle.Visible = False

                Dim BalGlDate As New BalGlobal_app
                Dim BalGl As New BalGlobal_app
                Dim dsTimetable_Date As New DataSet
                Dim dsTimetable_Time As New DataSet
                Dim dsTimetable_Room As New DataSet

                dsTimetable_Date = BalGl.getDataFromTable("tblTimetable", "distinct datename(dw, date)+', '+convert(varchar(11), date, 106) as Date, Date as ShortDate", "ShortDate", "where (convert(date, date) > convert(date, getdate()) or (convert(date, date)=convert(date, getdate()) and substring(Time, charindex('-', Time)+1, LEN(Time)) >= convert(varchar(5), getdate(), 108))) and IsCancelled=1", "asc")

                If dsTimetable_Date.Tables(0).Rows().Count > 0 Then
                    'lstDate.Visible = True

                    'lstDate.DataSource = dsTimetable_Date
                    'lstDate.DataBind()
                End If
            ElseIf ArticleID = 9 Then
                divArticle.Visible = False
                divNoShow.Visible = True
                Dim BalGl As New BalGlobal_app
                BalGl.DeleteFromTable("tblPresentationSelected_Temp", "Where Email='" & Request.QueryString("user") & "'")
                Call Load_SelectedPresentation_Temp(Request.QueryString("user"))
                div_search_result.InnerHtml = load_search(Request.QueryString("user"), "", 5)
                Session("search_program") = 2
                Exit Sub
            ElseIf ArticleID = 24 Then
                'CamTESOL to be updated
                divArticle.Visible = False
                divNoShow.Visible = True
                Dim BalGl As New BalGlobal_app
                ' div_search_result.InnerHtml = load_search(Request.QueryString("user"), "", 5)
                Dim dsUser As DataSet = BalGl.getDataFromTable("tblUser", "*", "Email", "Where Email='" & Request.QueryString("user") & "'", "asc")
                Dim FullName As String = dsUser.Tables(0).Rows(0)("Name").ToString
                Dim Email As String = dsUser.Tables(0).Rows(0)("Email").ToString
                Dim Position As String = dsUser.Tables(0).Rows(0)("Position").ToString
                Dim Employer As String = dsUser.Tables(0).Rows(0)("Employer").ToString
                Dim Country As String = dsUser.Tables(0).Rows(0)("Country").ToString
                Dim Password As String = dsUser.Tables(0).Rows(0)("Password").ToString

                txtFullName.Text = FullName
                txtEmailProfile.Text = Email
                txtPosition.Text = Position
                txtEmployer.Text = Employer
                txtCountry.Text = Country
                txtPasswordProfile.Text = Password
                txtConfirmPasswordProfile.Text = Password


                MultiView1.ActiveViewIndex = 3
                Session("search_program") = 2
                Exit Sub
            ElseIf ArticleID = 20 Then

                Dim BalGl As New BalGlobal_app
                MultiView1.ActiveViewIndex = 2

                divNoShow.Visible = True
                divArticle.Visible = False

                dsContent = BalArticle.getDataFromTable("tblArticle_CMS", "*", "ArticleID", "Where ArticleID=" & ArticleID & " AND (isnull(Visible,0) = 1)", "asc")
                If dsContent.Tables(0).Rows.Count > 0 Then
                    Dim html_content As String = "<div style='margin-top:10px;margin-right: 20px;'>" & dsContent.Tables(0).Rows(0)("ArticleContent").ToString & "</div>"
                    'html_content = html_content.Replace("Upload_s\", "Upload_s/").Replace("Upload_s", Server.MapPath("Upload_s"))
                    html_content = html_content.Replace("Upload_s\", "Upload_s/")
                    div_search_result.InnerHtml = html_content.Replace("_user", Request.QueryString("user"))
                End If


                Session("search_program") = 2
                Exit Sub
            Else
                divArticle.Visible = True
                divNoShow.Visible = False

                dsContent = BalArticle.getDataFromTable("tblArticle_CMS", "*", "ArticleID", "Where ArticleID=" & ArticleID & " AND (isnull(Visible,0) = 1)", "asc")
                If dsContent.Tables(0).Rows.Count > 0 Then
                    Dim html_content As String = "<div style='margin-top:10px;margin-right: 20px;'>" & dsContent.Tables(0).Rows(0)("ArticleContent").ToString & "</div>"
                    'html_content = html_content.Replace("Upload_s\", "Upload_s/").Replace("Upload_s", Server.MapPath("Upload_s"))
                    html_content = html_content.Replace("Upload_s\", "Upload_s/").Replace("_user_", Request.QueryString("user")).Replace("_deviceid_", Request.QueryString("deviceid")).Replace("_PresenterID_", Request.QueryString("PresenterID"))
                    Dim dtUserID2 As DataTable = selectQuery("select u.UserID from tblUserlogin u inner join tblRegisterContact c on c.ContactID=u.ContactID where isnull(c.Deleted,0)=0 and lower(UserEmail)='" & Request.QueryString("user").ToString & "'")
                    If dtUserID2.Rows.Count > 0 Then
                        html_content = html_content.Replace("_userid_", dtUserID2.Rows(0)("UserID").ToString)
                    Else
                        html_content = html_content.Replace("_userid_", "0")
                    End If
                    divArticle.InnerHtml = html_content.Replace("_user_", Request.QueryString("user"))
                End If
            End If
           
        Else
            divArticle.Visible = False
            divHome.Visible = True
        End If

        If Request.QueryString.Count < 2 Then
            Div_B.Visible = False
        End If

        'HH 31092016

        'If Session("UserID") <> Nothing Then
        '    Dim user As ClUser = DalUser.getUserByID(CInt(DalEncrypt_app.DescriptSpam(Session("UserID"))))

        '    If user IsNot Nothing Then
        '        If Session(user.username & ";LogIn") = "LogTrue" Then
        '            btnLogin.Text = "Log Out"
        '        End If
        '    End If
        'End If
    End Sub

    Private Sub LoadRegistration(PresenterID As Integer)

        '        Dim ds As New DataSet
        '        Dim cn As New SqlConnection
        '        Dim cmd As New SqlCommand
        '        Dim adapter As New SqlDataAdapter
        '        cn.ConnectionString = "Data Source=192.168.3.3;Initial Catalog=CamTESOL;Min Pool Size=5;Max Pool Size=60000;Connect Timeout=60;User Id=sa;Password=ACEidp.99;"
        '        cn.Open()
        '        Dim Fields As String = "c.SessionTitle, c.MainFocus , s1.FamilyName as FN1, s1.GivenName as GN1, s2.FamilyName as FN2, s2.GivenName as GN2, s3.FamilyName as FN3, s3.GivenName as GN3"
        '        Dim tbl As String = "tblCallforPaper c" & vbCrLf & _
        '"left outer join tblSpeakerCallforPaper s1" & vbCrLf & _
        '"on c.FirstSpeakerID = s1.SpeakerID" & vbCrLf & _
        '"left outer join tblSpeakerCallforPaper s2" & vbCrLf & _
        '"on c.SecondSpeakerID = s2.SpeakerID" & vbCrLf & _
        '"left outer join tblSpeakerCallforPaper s3" & vbCrLf & _
        '"on c.ThirdSpeakerID = s3.SpeakerID"

        '        cmd.CommandText = "SELECT " & Fields & " FROM " & tbl & " Where c.FirstSpeakerID=" & PresenterID & " Or c.SecondSpeakerID=" & PresenterID & " Or c.ThirdSpeakerID=" & PresenterID

        '        cmd.CommandType = CommandType.Text
        '        cmd.Connection = cn
        '        adapter.SelectCommand = cmd
        '        'fill the dataset
        '        adapter.Fill(ds)
        '        cn.Close()

        divArticle.Visible = True
        divNoShow.Visible = False

        Dim BalArticle As New BalGlobal_app
        Dim ArticleID As Integer = 0
        If PresenterID = 0 Then
            ArticleID = 60
        Else
            ArticleID = 60
        End If
        Dim dsContent As DataSet = BalArticle.getDataFromTable("tblArticle_CMS", "*", "ArticleID", "Where ArticleID=" & ArticleID & " AND (isnull(Visible,0) = 1)", "asc")
        If dsContent.Tables(0).Rows.Count > 0 Then
            Dim html_content As String = "<div style='margin-top:10px;margin-right: 20px;'>" & dsContent.Tables(0).Rows(0)("ArticleContent").ToString & "</div>"
            html_content = html_content.Replace("Upload_s\", "Upload_s/").Replace("Upload_s", Server.MapPath("Upload_s"))
            'html_content = html_content.Replace("Upload_s\", "Upload_s/").Replace("_user_", Request.QueryString("user")).Replace("_deviceid_", Request.QueryString("deviceid"))
            'html_content = html_content.Replace("$Title$", ds.Tables(0).Rows(0)("SessionTitle").ToString)
            'html_content = html_content.Replace("$Stream$", ds.Tables(0).Rows(0)("MainFocus").ToString)
            'Dim CoPresenter As String = ""
            'If IsDBNull(ds.Tables(0).Rows(0)("FN1")) = False Then
            '    CoPresenter = CoPresenter & ds.Tables(0).Rows(0)("FN1").ToString.ToUpper & " " & ds.Tables(0).Rows(0)("GN1").ToString
            'End If

            'If IsDBNull(ds.Tables(0).Rows(0)("FN2")) = False Then
            '    CoPresenter = CoPresenter & ", " & ds.Tables(0).Rows(0)("FN2").ToString.ToUpper & " " & ds.Tables(0).Rows(0)("GN2").ToString
            'End If

            'If IsDBNull(ds.Tables(0).Rows(0)("FN3")) = False Then
            '    CoPresenter = CoPresenter & ", " & ds.Tables(0).Rows(0)("FN3").ToString.ToUpper & " " & ds.Tables(0).Rows(0)("GN3").ToString
            'End If

            'html_content = html_content.Replace("$Co-Presenter$", CoPresenter)

            divArticle.InnerHtml = html_content.Replace("_user", Request.QueryString("user"))
        End If


    End Sub
    Private Sub LoadAbstract(PresenterID As Integer)

        Dim ds As New DataSet
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim adapter As New SqlDataAdapter
        cn.ConnectionString = "Data Source=192.168.3.3;Initial Catalog=CamTESOL;Min Pool Size=5;Max Pool Size=60000;Connect Timeout=60;User Id=sa;Password=ACEidp.99;"
        cn.Open()
        Dim Fields As String = "c.SessionTitle, c.MainFocus , s1.FamilyName as FN1, s1.GivenName as GN1, s2.FamilyName as FN2, s2.GivenName as GN2, s3.FamilyName as FN3, s3.GivenName as GN3"
        Dim tbl As String = "tblCallforPaper c" & vbCrLf & _
"left outer join tblSpeakerCallforPaper s1" & vbCrLf & _
"on c.FirstSpeakerID = s1.SpeakerID" & vbCrLf & _
"left outer join tblSpeakerCallforPaper s2" & vbCrLf & _
"on c.SecondSpeakerID = s2.SpeakerID" & vbCrLf & _
"left outer join tblSpeakerCallforPaper s3" & vbCrLf & _
"on c.ThirdSpeakerID = s3.SpeakerID"

        cmd.CommandText = "SELECT " & Fields & " FROM " & tbl & " Where c.FirstSpeakerID=" & PresenterID & " Or c.SecondSpeakerID=" & PresenterID & " Or c.ThirdSpeakerID=" & PresenterID

        cmd.CommandType = CommandType.Text
        cmd.Connection = cn
        adapter.SelectCommand = cmd
        'fill the dataset
        adapter.Fill(ds)
        cn.Close()

        divArticle.Visible = True
        divNoShow.Visible = False

        Dim BalArticle As New BalGlobal_app
        Dim dsContent As DataSet = BalArticle.getDataFromTable("tblArticle_CMS", "*", "ArticleID", "Where ArticleID=" & 58 & " AND (isnull(Visible,0) = 1)", "asc")
        If dsContent.Tables(0).Rows.Count > 0 Then
            Dim html_content As String = "<div style='margin-top:10px;margin-right: 20px;'>" & dsContent.Tables(0).Rows(0)("ArticleContent").ToString & "</div>"
            'html_content = html_content.Replace("Upload_s\", "Upload_s/").Replace("Upload_s", Server.MapPath("Upload_s"))
            html_content = html_content.Replace("Upload_s\", "Upload_s/").Replace("_user_", Request.QueryString("user")).Replace("_deviceid_", Request.QueryString("deviceid"))
            html_content = html_content.Replace("$Title$", ds.Tables(0).Rows(0)("SessionTitle").ToString)
            html_content = html_content.Replace("$Stream$", ds.Tables(0).Rows(0)("MainFocus").ToString)
            Dim CoPresenter As String = ""
            If IsDBNull(ds.Tables(0).Rows(0)("FN1")) = False Then
                CoPresenter = CoPresenter & ds.Tables(0).Rows(0)("FN1").ToString.ToUpper & " " & ds.Tables(0).Rows(0)("GN1").ToString
            End If

            If IsDBNull(ds.Tables(0).Rows(0)("FN2")) = False Then
                CoPresenter = CoPresenter & ", " & ds.Tables(0).Rows(0)("FN2").ToString.ToUpper & " " & ds.Tables(0).Rows(0)("GN2").ToString
            End If

            If IsDBNull(ds.Tables(0).Rows(0)("FN3")) = False Then
                CoPresenter = CoPresenter & ", " & ds.Tables(0).Rows(0)("FN3").ToString.ToUpper & " " & ds.Tables(0).Rows(0)("GN3").ToString
            End If

            html_content = html_content.Replace("$Co-Presenter$", CoPresenter)

            divArticle.InnerHtml = html_content.Replace("_user", Request.QueryString("user"))
        End If


    End Sub
    Sub Visible_Div()
        divArticle.Visible = False
        divmenu.Visible = False
        div_change_password.Visible = False
    End Sub

    'Protected Sub btnLogin_Click(sender As Object, e As EventArgs)
    '    If btnLogin.Text = "Log In" Then
    '        blockPanel.Style("display") = "block"
    '        loginPanel.Style("display") = "block"
    '    Else
    '        btnLogin.Text = "Log In"
    '        Session.Clear()
    '    End If
    'End Sub

    Protected Sub closeLoginPanel_Click(sender As Object, e As ImageClickEventArgs)
        loginPanel.Style("display") = "none"
        blockPanel.Style("display") = "none"
        lblMessage.Text = ""
    End Sub

    Protected Sub btnCheckLogin_Click(sender As Object, e As EventArgs)
        Dim user As ClUser = DalUser.getUserFromLogin(txtUsername.Text.Trim, txtPassword.Text.Trim)
        If user IsNot Nothing Then
            lblMessage.Text = ""

            Session("UserID") = DalEncrypt_app.EnscriptSpam(user.id)
            Session(user.username & ";LogIn") = "LogTrue"

            'btnLogin.Text = "Log Out"

            loginPanel.Style("display") = "none"
            blockPanel.Style("display") = "none"
        Else
            lblMessage.Text = "Invalid Username and Password."
        End If
    End Sub

    'Protected Sub btnUpdateCancel_Click(sender As Object, e As EventArgs)
    '    For i = 0 To lstDate.Items.Count - 1
    '        If lst1.Items(i).ItemType = ListViewItemType.DataItem Then
    '            Dim c As CheckBox = CType(lst1.Items(i).FindControl("CheckBox1"), CheckBox)
    '            Dim id As Integer = lst1.DataKeys(i).Value

    '            DalTimetable.updateIsCancel(id, c.Checked)
    '        End If
    '    Next
    'End Sub

    'Protected Sub DropDownListDate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListDate.SelectedIndexChanged
    '    Dim BalGl As New BalGlobal_app
    '    Dim dsTimetable_Time As New DataSet
    '    If DropDownListDate.Text = Now.Date Then
    '        dsTimetable_Time = BalGl.getDataFromTable("tblTimetable", "DISTINCT Time", "Time", "WHERE CONVERT(date, Date)='" & Format(DateValue(Me.DropDownListDate.Text), "yyyy-MM-dd") & "' and SUBSTRING(Time, 0, CHARINDEX('-', Time)) >= format(getdate(), 'hh:mm')", "asc")
    '    Else
    '        dsTimetable_Time = BalGl.getDataFromTable("tblTimetable", "DISTINCT Time", "Time", "WHERE CONVERT(date, Date)='" & Format(DateValue(Me.DropDownListDate.Text), "yyyy-MM-dd") & "'", "asc")
    '    End If

    '    If dsTimetable_Time.Tables(0).Rows.Count > 0 Then
    '        DropDownListTime.DataTextField = "Time"
    '        DropDownListTime.DataValueField = "Time"
    '        DropDownListTime.DataSource = dsTimetable_Time

    '        DropDownListTime.DataBind()
    '    Else
    '        DropDownListTime.DataSource = Nothing
    '        DropDownListTime.Items.Clear()
    '        DropDownListTime.Items.Add("No Data")
    '    End If
    'End Sub

    'Protected Sub DropDownListTime_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListTime.SelectedIndexChanged
    '    If DropDownListTime.SelectedItem.ToString <> "No Data" Then
    '        Dim BalGl As New BalGlobal_app
    '        Dim dsTimetable_Room As New DataSet
    '        dsTimetable_Room = BalGl.getDataFromTable("tblTimetable", "ID, RoomNo as Room, IsCancelled", "RoomNo", "WHERE CONVERT(date, Date)='" & Format(DateValue(Me.DropDownListDate.Text), "yyyy-MM-dd") & "' and Time='" & Me.DropDownListTime.SelectedValue.ToString() & "'", "asc")

    '        If dsTimetable_Room.Tables(0).Rows.Count > 0 Then
    '            lst1.Visible = True

    '            lst1.DataSourceID = ""
    '            lst1.DataSource = dsTimetable_Room
    '            lst1.DataBind()


    '            Dim alink As String
    '            For i = 0 To dsTimetable_Room.Tables(0).Rows.Count - 1

    '                alink = "<a href='eace.aspx'>" & dsTimetable_Room.Tables(0).Rows(i).Item("Room").ToString() & "</a>"
    '                ''"<a href ='eace.aspx?MenuID=" & dt2.Rows(0)("MenuID").ToString & "&ArticleID=" & dt2.Rows(0)("ArticleID") & "'>" & _
    '            Next
    '        End If
    '    Else
    '        lst1.DataSource = Nothing
    '        lst1.Visible = False
    '    End If
    'End Sub

    'Protected Sub lstRoom_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    Dim lstRoom As ListView = sender

    '    Dim ID As Integer = lstRoom.SelectedValue

    '    'HH 29082016
    '    Dim BalGl As New BalGlobal_app
    '    Dim dsTimetable_Room As New DataSet
    '    dsTimetable_Room = BalGl.getDataFromTable("tblTimetable", "MainFocus, TypeofSession, TitleOfPresentation, MainFocusCode, FirstSpeaker, SecondSpeaker, ThirdSpeaker", "RoomNo", "WHERE ID=" & ID, "")

    '    Dim Code_Presentation As String
    '    If dsTimetable_Room.Tables(0).Rows.Count > 0 Then
    '        Code_Presentation = "<table>" & _
    '                            "<tr>" & _
    '                            "<td>" & dsTimetable_Room.Tables(0).Rows(0).Item("TitleOfPresentation").ToString() & "</td>" & _
    '                            "</tr>" & _
    '                            "</table>"

    '        div_popup_enrolment2.InnerHtml = Code_Presentation
    '    End If

    '    'Open Popup Menu
    '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "openModal();", True)
    'End Sub

    'Protected Sub lstRoom_SelectedIndexChanging(sender As Object, e As ListViewSelectEventArgs)

    'End Sub

    'Protected Sub lstDate_PreRender(sender As Object, e As EventArgs) Handles lstDate.PreRender
    '    Dim BalGl As New BalGlobal_app
    '    Dim dsTimetable_Time As New DataSet

    '    'For Each dateItem As ListViewItem In lstDate.Items
    '    '    Dim lstTime As ListView = CType(dateItem.FindControl("lstTime"), ListView)
    '    '    Dim dateGroup As Label = CType(dateItem.FindControl("dateGroup"), Label)
    '    '    Dim dateFromDateGroup As String = dateGroup.Text.Substring(dateGroup.Text.IndexOf(",") + 2)

    '    '    If Date.Parse(dateFromDateGroup).ToString("yyyy-MM-dd") = Now.Date.ToString("yyyy-MM-dd") Then
    '    '        dsTimetable_Time = BalGl.getDataFromTable("tblTimetable", "distinct Time", "Time", "where convert(date, date)=convert(date, '" & dateFromDateGroup & "') and substring(Time, charindex('-', Time)+1, LEN(Time)) >= convert(varchar(5), GETDATE(), 108) and IsCancelled=1", "asc")
    '    '    Else
    '    '        dsTimetable_Time = BalGl.getDataFromTable("tblTimetable", "distinct Time", "Time", "where convert(date, date)=convert(date, '" & dateFromDateGroup & "') and IsCancelled=1", "asc")
    '    '    End If

    '    '    lstTime.Visible = True
    '    '    lstTime.DataSource = dsTimetable_Time
    '    '    lstTime.DataBind()
    '    'Next
    'End Sub

    Protected Sub lstTime_PreRender(sender As Object, e As EventArgs)
        Dim BalGl As New BalGlobal_app
        Dim dsTimetable_Room As New DataSet
        'For Each dateItem As ListViewItem In lstDate.Items
        '    Dim lstTime As ListView = CType(dateItem.FindControl("lstTime"), ListView)
        '    Dim dateGroup As Label = CType(dateItem.FindControl("dateGroup"), Label)
        '    Dim dateFromDateGroup As String = dateGroup.Text.Substring(dateGroup.Text.IndexOf(",") + 2)

        '    For Each timeItem As ListViewItem In lstTime.Items
        '        Dim lstRoom As ListView = CType(timeItem.FindControl("lstRoom"), ListView)
        '        Dim timeGroup As Label = CType(timeItem.FindControl("timeGroup"), Label)

        '        dsTimetable_Room = BalGl.getDataFromTable("tblTimetable", "ID, RoomNo as Room, TitleOfPresentation as Title, MainFocusCode, IsCancelled", "RoomNo", "where Date=convert(date, '" & dateFromDateGroup & "') and Time='" & timeGroup.Text & "' and IsCancelled=1", "")

        '        lstRoom.Visible = True
        '        lstRoom.DataSource = dsTimetable_Room
        '        lstRoom.DataBind()
        '    Next
        'Next
    End Sub

    Protected Sub lnkByTitle_Click(sender As Object, e As System.EventArgs) Handles lnkByTitle.Click
        MultiView1.ActiveViewIndex = 1
        MultiView2.ActiveViewIndex = 0
        divNoShow.Visible = True
        divArticle.Visible = False
    End Sub

    Protected Sub MultiView1_ActiveViewChanged(sender As Object, e As System.EventArgs) Handles MultiView1.ActiveViewChanged

    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As System.EventArgs) Handles btnSearch.Click
        div_search_result.InnerHtml = load_search(Request.QueryString("user"), txtKeywordTitle.Text.Trim, 1)
        divNoShow.Visible = True
        divArticle.Visible = False
        Session("search_program") = 2
    End Sub


    <System.Web.Services.WebMethod()>
    Public Shared Function add_selected(ByVal presentationid As String, email As String, keyword As String, searchtype As Integer) As String

        Dim BalGl As New BalGlobal_app
        Dim NowString As String = Now.ToString("yyyy-MM-dd H:mm")
        BalGl.InsertToTable("tblPresentationSelected", "Email, PresentationID, CreatedDate", "'" & email & "'," & presentationid & ",'" & NowString & "'")

        Return load_search(email, keyword, searchtype)

    End Function

    <System.Web.Services.WebMethod()>
    Public Shared Function delete_selected(ByVal presentationid As String, email As String, keyword As String, searchtype As Integer) As String

        Dim BalGl As New BalGlobal_app

        BalGl.DeleteFromTable("tblPresentationSelected", "Where Email='" & email & "' And PresentationID=" & presentationid)

        Return load_search(email, keyword, searchtype)

    End Function

    <System.Web.Services.WebMethod()>
    Public Shared Function show_profile(ByVal presentationid As String, email As String, keyword As String, searchtype As Integer) As String

        Dim BalGl As New BalGlobal_app
        Dim camtesol_service As New CamTESOLSchedule.edbserviceSoapClient

        'Dim ds As DataSet = BalGl.getDataFromTable("tblProgram", "*", "FamilyName, GivenName", "Where PresentationID=" & presentationid, "asc")
        Dim dt As DataTable = camtesol_service.camtesol_schedule("tblCamTESOLConferenceProgramView", "*", "Where PresentationID=" & presentationid, "FamilyName, GivenName", "asc")
        Dim html As String = ""
        For i = 0 To dt.Rows.Count - 1
            Dim FullName As String = dt.Rows(i)("Title").ToString & " " & dt.Rows(i)("GivenName").ToString & " " & dt.Rows(i)("FamilyName").ToString
            Dim Bio As String = dt.Rows(i)("BioData").ToString
            html = html & "<div style='font-size: medium; padding: 0px 0px; font-weight: bold;'>" & FullName & "</div>"
            html = html & "<div style='padding: 10px 0px;'>" & Bio & "</div><hr>"
        Next

        Return html

    End Function

    <System.Web.Services.WebMethod()>
    Public Shared Function show_abstract(ByVal presentationid As String, email As String, keyword As String, searchtype As Integer) As String

        'Dim BalGl As New BalGlobal_app

        'Dim ds As DataSet = BalGl.getDataFromTable("tblProgram", "*", "FamilyName, GivenName", "Where PresentationID=" & presentationid, "asc")
        Dim camtesol_service As New CamTESOLSchedule.edbserviceSoapClient

        'Dim ds As DataSet = BalGl.getDataFromTable("tblProgram", "*", "FamilyName, GivenName", "Where PresentationID=" & presentationid, "asc")
        Dim dt As DataTable = camtesol_service.camtesol_schedule("tblCamTESOLConferenceProgramView", "*", "Where PresentationID=" & presentationid, "FamilyName, GivenName", "asc")

        Dim html As String = ""
        For i = 0 To 0
            Dim FullName As String = dt.Rows(i)("TitleofPresentation").ToString
            Dim abstract As String = dt.Rows(i)("abstract").ToString
            html = html & "<div style='font-size: medium; padding: 0px 0px; font-weight: bold;'>" & FullName & "</div>"
            html = html & "<div style='padding: 10px 0px;'>" & abstract & "</div><hr>"
        Next

        Return html

    End Function

    Public Shared Function load_search(email As String, keyword As String, searchtype As Integer) As String
        Dim BalGl As New BalGlobal_app

        Dim camtesolservice As New CamTESOLSchedule.edbserviceSoapClient

        Dim dsProgram As New DataTable

        If searchtype = 1 Then
            'dsProgram = BalGl.getDataFromTable("tbl", "*", "SessionDate, SessionTime, RoomName", "Where TitleofPresentation like '%" & keyword & "%'", "asc")
            dsProgram = camtesolservice.camtesol_schedule("tblCamTESOLConferenceProgramView_SessionDetail", "*", "Where TitleofPresentation like '%" & keyword & "%'", "SessionDate, SessionTime, RoomName", "asc")
        ElseIf searchtype = 2 Then
            'dsProgram = BalGl.getDataFromTable("tblProgram", "*", "SessionDate, SessionTime, RoomName", "Where FocusArea1 = '" & keyword & "'", "asc")
            'dsProgram = camtesolservice.camtesol_schedule("tblCamTESOLConferenceProgramView", "*", "Where FocusArea1 = '" & keyword & "'", "SessionDate, SessionTime, RoomName", "asc")
            dsProgram = camtesolservice.camtesol_schedule("tblCamTESOLConferenceProgramView_SessionDetail", "*", "Where FocusArea1 = '" & keyword & "'", "SessionDate, SessionTime, RoomName", "asc")
        ElseIf searchtype = 3 Then
            Dim arr_keyword As String() = keyword.Split("/")
            Dim DayString As String = ""
            Dim day As String = arr_keyword(0)
            Dim Time As String = arr_keyword(1)

            If day = "Friday" OrElse day = "Fri" Then
                DayString = "2017-02-17"
            ElseIf day = "Saturday" OrElse day = "Sat" Then
                DayString = "2017-02-18"
            ElseIf day = "Sunday" OrElse day = "Sun" Then
                DayString = "2017-02-19"
            End If

            'dsProgram = BalGl.getDataFromTable("tblProgram", "*", "SessionDate, SessionTime, RoomName", "Where SessionDate = '" & DayString & "' And SessionTime='" & Time & "'", "asc")
            dsProgram = camtesolservice.camtesol_schedule("tblCamTESOLConferenceProgramView_SessionDetail", "*", "Where SessionDate = '" & DayString & "' And SessionTime='" & Time & "'", "SessionDate, SessionTime, RoomName", "asc")
        ElseIf searchtype = 4 Then
            'dsProgram = BalGl.getDataFromTable("tblProgram", "*", "SessionDate, SessionTime, RoomName", "Where (GivenName + ' ' + FamilyName) = '" & keyword & "'", "asc")
            dsProgram = camtesolservice.camtesol_schedule("tblCamTESOLConferenceProgramView_SessionDetail", "*", "Where (GivenName + ' ' + FamilyName) like '%" & keyword & "%'", "SessionDate, SessionTime, RoomName", "asc")
        ElseIf searchtype = 5 Then
            Dim ds_Selected_temp As DataSet = BalGl.getDataFromTable("tblPresentationSelected_temp", "PresentationID", "CreatedDate", "Where Email='" & email & "'", "asc")
            Dim PresentaionID_Range As String = ""
            For i = 0 To ds_Selected_temp.Tables(0).Rows.Count - 1
                If i = ds_Selected_temp.Tables(0).Rows.Count - 1 Then
                    PresentaionID_Range = PresentaionID_Range & ds_Selected_temp.Tables(0).Rows(i)("PresentationID").ToString
                Else
                    PresentaionID_Range = PresentaionID_Range & ds_Selected_temp.Tables(0).Rows(i)("PresentationID").ToString & ","
                End If
            Next

            dsProgram = camtesolservice.camtesol_schedule("tblCamTESOLConferenceProgramView_SessionDetail", "*", "Where PresentationID in (" & PresentaionID_Range & ")", "SessionDate, SessionTime, RoomName", "asc")
        End If
        Dim html_for_div As String = "<div class='headertext_large'>Results</div><hr>"
        If searchtype = 5 Then
            html_for_div = ""
        End If
        Dim pre_day As String = ""
        Dim pre_time As String = ""
        Dim pre_presentationid As Integer = 0
        If dsProgram.Rows.Count = 0 Then
            html_for_div = html_for_div & "<div>No record was found.</div>"
        End If
        For i = 0 To dsProgram.Rows.Count - 1
            Dim innerhtml As String = ""
            Dim innerhtml_daytime As String = ""

            Dim L0_PresentationID As Integer = dsProgram.Rows(i)("PresentationID").ToString
            Dim L1_Date As String '= CDate(dsProgram.Rows(i)("SessionDate")).ToString("ddd")
            If IsDBNull(dsProgram.Rows(i)("SessionDate")) = True Then
                L1_Date = ""
            Else
                L1_Date = CDate(dsProgram.Rows(i)("SessionDate")).ToString("ddd")
            End If

            Dim L2_Time As String = dsProgram.Rows(i)("SessionTime").ToString

            Dim L3_Room As String = dsProgram.Rows(i)("RoomName").ToString
            Dim L3_FocusArea1 As String = dsProgram.Rows(i)("FocusArea1").ToString
            Dim IsNoShow As Boolean = dsProgram.Rows(i)("IsNoShow")

            Dim L3_Title As String = dsProgram.Rows(i)("TitleofPresentation").ToString
            Dim Presenter As String = dsProgram.Rows(i)("Title").ToString & " " & dsProgram.Rows(i)("GivenName").ToString & " " & dsProgram.Rows(i)("FamilyName").ToString

            If i >= 1 Then
                If IsDBNull(dsProgram.Rows(i - 1)("SessionDate")) = True Then
                    pre_day = ""
                Else
                    pre_day = CDate(dsProgram.Rows(i - 1)("SessionDate")).ToString("ddd")
                End If

                pre_time = dsProgram.Rows(i - 1)("SessionTime").ToString
                pre_presentationid = dsProgram.Rows(i - 1)("PresentationID").ToString
            End If
            If pre_day <> L1_Date Then
                innerhtml_daytime = innerhtml_daytime & "<div style='font-size: large; text-align: center; background-color: lightgray; padding: 10px;'>" & L1_Date & "</div>"
            End If
            If pre_time <> L2_Time Then
                innerhtml_daytime = innerhtml_daytime & "<div style='font-weight: bold; text-align: center;'>" & L2_Time & "</div>"
            End If

            Dim div_profile As String = "<div style='width:25%;float:left;color: rgb(50, 182, 174);padding-top:10px;'><input style='border: medium none; color: rgb(50, 182, 174);background-color: transparent;' id='btnprofile' type='button' value='Profile' onclick=""showprofile('"
            If pre_presentationid <> L0_PresentationID Then
                If IsNoShow = True Then
                    innerhtml = innerhtml & "<div style=' text-align: left;font-weight:bold; background-color:red;'>Room: " & L3_Room & " (Canceled)</div>"
                Else
                    innerhtml = innerhtml & "<div style=' text-align: left;font-weight:bold;'>Room: " & L3_Room & "</div>"
                End If

                innerhtml = innerhtml & "<div style=' text-align: left;'>" & L3_FocusArea1 & "</div>"
                innerhtml = innerhtml & "<div style='font-style:Italic'>" & L3_Title & "</div>"
                innerhtml = innerhtml & "<div>" & Presenter & "</div>"
                innerhtml = innerhtml & div_profile & L0_PresentationID & "','" & email & "','" & keyword & "'," & searchtype & ")""/></div>"
                innerhtml = innerhtml & "<div style='width:25%;float:left;color: rgb(50, 182, 174);text-align:center;padding-top:10px;'><input style='border: medium none; color: rgb(50, 182, 174);background-color: transparent;' id='btnAbstract' type='button' value='Abstract' onclick=""showabstract('" & L0_PresentationID & "','" & email & "','" & keyword & "'," & searchtype & ")""/></div>"
                Dim ds_selected As DataSet = BalGl.getDataFromTable("tblPresentationSelected", "*", "Email", "Where Email='" & email & "' And PresentationID=" & L0_PresentationID, "asc")
                If ds_selected.Tables(0).Rows.Count > 0 Then
                    innerhtml = innerhtml & "<div style='width:50%;float:left;text-align:right;padding-top:10px;'> <input style='border: medium none; color: green;font-size:large;background-color: transparent;' id='btndeselect0' type='button' value='&#x2611;' onclick=""deselected('" & L0_PresentationID & "','" & email & "','" & keyword & "'," & searchtype & ")""/><input style='border: medium none; color: green;background-color: transparent;' id='btndeselect' type='button' value=' Add to my schedule' onclick=""deselected('" & L0_PresentationID & "','" & email & "','" & keyword & "'," & searchtype & ")""/></div> <hr> "
                Else
                    innerhtml = innerhtml & "<div style='width:50%;float:left;text-align:right;padding-top:10px;'> <input style='border: medium none; color: rgb(50, 182, 174);font-size:large;background-color: transparent;' id='btnselect0' type='button' value='&#x2610;' onclick=""markas_selected('" & L0_PresentationID & "','" & email & "','" & keyword & "'," & searchtype & ")""/> <input style='border: medium none; color: rgb(50, 182, 174);background-color: transparent;' id='btnselect' type='button' value=' Add to my schedule' onclick=""markas_selected('" & L0_PresentationID & "','" & email & "','" & keyword & "'," & searchtype & ")""/></div> <hr> "
                End If

            Else
                html_for_div = html_for_div.Replace(div_profile & L0_PresentationID & "','" & email & "','" & keyword & "')""/></div>", "<div>" & Presenter & "</div>" & div_profile & L0_PresentationID & "','" & email & "','" & keyword & "')""/></div>")
            End If
            If i Mod 2 = 0 Then
                html_for_div = html_for_div & innerhtml_daytime & "<div style='padding: 15px; background-color: rgb(244, 244, 244); border-style: solid; border-width: 1px; border-color: rgb(242, 242, 242); '>" & innerhtml & "</div>"
            Else
                html_for_div = html_for_div & innerhtml_daytime & "<div style='padding: 15px; background-color: rgb(254, 254, 254); border-style: solid; border-width: 1px; border-color: rgb(242, 242, 242); '>" & innerhtml & "</div>"
            End If

        Next


        Return html_for_div
    End Function

    Private Sub Load_SelectedPresentation_Temp(Email As String)

        Dim conn As SqlConnection = New SqlConnection
        conn.ConnectionString = DalConnection_app.EDBConnectionString
        Dim cmd As SqlCommand = New SqlCommand

        cmd.CommandText = "insert into tblPresentationSelected_Temp(Email,PresentationID, CreatedDate)" & _
        "select Email,PresentationID, CreatedDate from tblPresentationSelected where Email='" & Email & "'"

        cmd.Connection = conn
        conn.Open()
        cmd.ExecuteNonQuery()
        conn.Close()

    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As System.EventArgs) Handles LinkButton1.Click
        MultiView1.ActiveViewIndex = 1
        MultiView2.ActiveViewIndex = 1
        Call LoadStream()
        divNoShow.Visible = True
        divArticle.Visible = False
    End Sub

    Protected Sub dplStream_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles dplStream.SelectedIndexChanged
        div_search_result.InnerHtml = load_search(Request.QueryString("user"), dplStream.SelectedValue, 2)
        divNoShow.Visible = True
        divArticle.Visible = False
        Session("search_program") = 2
    End Sub

    <System.Web.Script.Services.ScriptMethod(), _
   System.Web.Services.WebMethod()> _
    Public Shared Function LoadPresenter(ByVal prefixText As String, ByVal count As Integer) As List(Of String)

        'Dim conn As SqlConnection = New SqlConnection
        'conn.ConnectionString = DalConnection_app.EDBConnectionString
        'Dim cmd As SqlCommand = New SqlCommand

        'cmd.CommandText = "SELECT DISTINCT TOP(@nrows) GivenName + ' ' + FamilyName as FullName  FROM tblProgram where" & _
        '" (GivenName + ' ' + FamilyName) like '%' + @SearchText + '%'"
        'cmd.Parameters.AddWithValue("@SearchText", prefixText)
        'cmd.Parameters.AddWithValue("nrows", count)
        'cmd.Connection = conn
        'conn.Open()
        Dim customers As List(Of String) = New List(Of String)
        'Dim sdr As SqlDataReader = cmd.ExecuteReader
        'While sdr.Read
        '    Dim item As String = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(sdr("FullName").ToString, sdr("FullName").ToString)
        '    customers.Add(item)
        'End While
        'conn.Close()

        Dim myservice As New CamTESOLSchedule.edbserviceSoapClient
        Dim dt As DataTable = myservice.camtesol_schedule("tblCamTESOLConferenceProgramView", "*", "Where TitleofPresentation like '%" & prefixText & "%'", "TitleofPresentation", "asc")
        For i = 0 To dt.Rows.Count - 1
            Dim item As String = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(dt.Rows(i)("FullName").ToString, dt.Rows(i)("FullName").ToString)
            customers.Add(item)
        Next

        Return customers
    End Function

    <System.Web.Script.Services.ScriptMethod(), _
   System.Web.Services.WebMethod()> _
    Public Shared Function LoadTitle(ByVal prefixText As String, ByVal count As Integer) As List(Of String)

        'Dim conn As SqlConnection = New SqlConnection
        'conn.ConnectionString = DalConnection_app.EDBConnectionString
        'Dim cmd As SqlCommand = New SqlCommand

        'cmd.CommandText = "SELECT DISTINCT TOP(@nrows) TitleofPresentation  FROM tblProgram where" & _
        '" (TitleofPresentation) like '%' + @SearchText + '%'"
        'cmd.Parameters.AddWithValue("@SearchText", prefixText)
        'cmd.Parameters.AddWithValue("nrows", count)
        'cmd.Connection = conn
        'conn.Open()
        Dim customers As List(Of String) = New List(Of String)
        'Dim sdr As SqlDataReader = cmd.ExecuteReader

        Dim myservice As New CamTESOLSchedule.edbserviceSoapClient
        Dim dt As DataTable = myservice.camtesol_schedule("tblCamTESOLConferenceProgramView", "distinct TitleofPresentation", "Where TitleofPresentation like '%" & prefixText & "%'", "TitleofPresentation", "asc")
        For i = 0 To dt.Rows.Count - 1
            Dim item As String = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(dt.Rows(i)("TitleofPresentation").ToString, dt.Rows(i)("TitleofPresentation").ToString)
            customers.Add(item)
        Next
        'While sdr.Read
        '    Dim item As String = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(sdr("TitleofPresentation").ToString, sdr("TitleofPresentation").ToString)
        '    customers.Add(item)
        'End While
        'conn.Close()
        Return customers
    End Function


    Protected Sub LinkButton2_Click(sender As Object, e As System.EventArgs) Handles LinkButton2.Click
        MultiView1.ActiveViewIndex = 1
        MultiView2.ActiveViewIndex = 2
        Call LoadTime(dplDay.SelectedValue)
        divNoShow.Visible = True
        divArticle.Visible = False
    End Sub

    Protected Sub dplStream0_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles dplDay.SelectedIndexChanged

        LoadTime(dplDay.SelectedValue)

        divNoShow.Visible = True
        divArticle.Visible = False
        'div_search_result.InnerHtml = load_search(Request.QueryString("user"), dplDay.SelectedValue & "/" & dplTime.SelectedValue, 3)
        div_search_result.InnerHtml = ""
        Session("search_program") = 2
    End Sub

    Protected Sub dplTime_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles dplTime.SelectedIndexChanged

        div_search_result.InnerHtml = load_search(Request.QueryString("user"), dplDay.SelectedValue & "/" & dplTime.SelectedValue, 3)
        divNoShow.Visible = True
        divArticle.Visible = False
        Session("search_program") = 2

    End Sub



    Protected Sub LinkButton3_Click(sender As Object, e As System.EventArgs) Handles LinkButton3.Click
        MultiView1.ActiveViewIndex = 1
        MultiView2.ActiveViewIndex = 3
        'Call LoadTime(dplDay.SelectedValue)
        divNoShow.Visible = True
        divArticle.Visible = False
    End Sub


    Protected Sub txtPresenter_TextChanged(sender As Object, e As System.EventArgs) Handles txtPresenter.TextChanged

        div_search_result.InnerHtml = load_search(Request.QueryString("user"), txtPresenter.Text.Trim, 4)
        divNoShow.Visible = True
        divArticle.Visible = False
        Session("search_program") = 2
    End Sub

    Protected Sub txtKeywordTitle_TextChanged(sender As Object, e As System.EventArgs) Handles txtKeywordTitle.TextChanged
        div_search_result.InnerHtml = load_search(Request.QueryString("user"), txtKeywordTitle.Text.Trim, 1)
        divNoShow.Visible = True
        divArticle.Visible = False
        Session("search_program") = 2
    End Sub

    Protected Sub btnSearch0_Click(sender As Object, e As System.EventArgs) Handles btnSearch0.Click
        lblinfoEmail.Text = ""
        lblinfoEmail.ForeColor = Drawing.Color.Red
        If txtSubject.Text = "" Then
            lblinfoEmail.Text = "Please enter subject."
            Exit Sub
        End If
        If txtMessage.Text = "" Then
            lblinfoEmail.Text = "Please enter your message."
            Exit Sub
        End If
        Call send_enquiry(txtSubject.Text, txtMessage.Text, Request.QueryString("user"))
        txtSubject.Text = ""
        txtMessage.Text = ""
    End Sub

    Private Function send_enquiry(Subject As String, Message As String, UserEmail As String) As Boolean
        Try

            Dim Body As String = "From: " & "<font color= blue>" & "<b>" & UserEmail & "</b>" & "</font>" & "<br>" & "<br>"
            Body = Body & vbCrLf & "From: " & "Subject:" & Subject & "<br>" & "<br>"
            Body = Body & vbCrLf & "Enquiry:" & "<br>" & "<br>"
            'Body = Body & vbCrLf & "Your ID: " & "<font color=Blue>" & "<b>" & ContactID & "</b>" & "</font>" & "<br>"
            Body = Body & vbCrLf & " " & Message & "<br>" & "<br>"
            Dim isSent As Boolean = MySendEmail(Subject, Body, "secretariat@camtesol.org", "")
            lblinfoEmail.Text = "Your message was sent."
            lblinfoEmail.ForeColor = Drawing.Color.Green
            Return isSent

        Catch ex As Exception
            lblinfoEmail.Text = "Sending eror."
            lblinfoEmail.ForeColor = Drawing.Color.Red

            Return False
        End Try
    End Function

    Private Function MySendEmail(ByVal Subject As String, ByVal Body As String, ByVal Recipient As String, ByVal AttachmentPath As String) As Boolean

        Dim mail As MailMessage = New MailMessage()
        'Dim cc As New MailAddress("Database-Support@acecambodia.org")
        'Dim cc1 As New MailAddress("chanpheakdey.vong@acecambodia.org")
        mail.To.Add(Recipient)
        mail.From = New MailAddress("secretariat@camtesol.org")
        'mail.CC.Add(cc)
        'mail.CC.Add(cc1)
        mail.Subject = Subject
        mail.Body = Body
        mail.IsBodyHtml = True
        Dim smtp As SmtpClient = New SmtpClient()

        'Mdaemon
        'smtp.Host = "203.217.170.20"
        'smtp.Host = "192.168.0.253"
        'smtp.Credentials = New System.Net.NetworkCredential("ace.edb@acecambodia.org", "pass$1234")
        'smtp.EnableSsl = False
        'smtp.Port = 25

        'Integrate Gmail
        Try

            smtp.Host = "smtp.gmail.com"
            smtp.Credentials = New System.Net.NetworkCredential("secretariat@camtesol.org", "SVsmp.14")
            smtp.EnableSsl = True
            smtp.Port = 587

            smtp.Send(mail)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Protected Sub btnSaveProfile_Click(sender As Object, e As System.EventArgs) Handles btnSaveProfile.Click
        lblInfoProfile.Text = ""
        lblInfoProfile.ForeColor = Drawing.Color.Red
        If txtFullName.Text.Trim = "" Then
            lblInfoProfile.Text = "Please enter your fullname."
            Exit Sub
        End If


        If (txtPasswordProfile.Text.Trim <> txtConfirmPasswordProfile.Text.Trim) Then
            lblInfoProfile.Text = "Passwords do not match."
            Exit Sub
        End If

        If txtPasswordProfile.Text.Trim.Length < 5 Then
            lblInfoProfile.Text = "Password must be more than or equal 5 charaters."
            Exit Sub
        End If

        Dim BalGl As New BalGlobal_app
        BalGl.UpdateValueInTable("tblUser", "Name='" & txtFullName.Text.Trim & "',Position='" & txtPosition.Text.Trim & "',Employer='" & txtEmployer.Text.Trim & "',Country='" & txtCountry.Text.Trim & "',Password='" & txtPasswordProfile.Text.Trim & "'", "Where Email='" & Request.QueryString("user") & "'")
        lblInfoProfile.Text = "Records are saved."
        lblInfoProfile.ForeColor = Drawing.Color.Green
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles dplSearchField.SelectedIndexChanged

        MultiView2.ActiveViewIndex = dplSearchField.SelectedIndex
        If dplSearchField.SelectedIndex = 1 Then
            Call LoadStream()
        ElseIf dplSearchField.SelectedIndex = 2 Then
            Call LoadTime(dplDay.SelectedValue)
        ElseIf dplSearchField.SelectedIndex = 3 Then

        End If
    End Sub

    Protected Sub imgPDF0_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgPDF0.Click
        Response.Redirect("https://drive.google.com/file/d/0B43FTKvVdRW8ZW1MZ3BZRTExd1E/view?usp=sharing")
        'Response.Redirect("http://camtesolapp.acecambodia.org/Upload_s/13th_CamTESOL_Research_Symposium_Conference_Program_V1.pdf")
    End Sub

    Protected Sub imgPDF1_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles imgPDF1.Click
        Response.Redirect("https://drive.google.com/file/d/0B43FTKvVdRW8dXBDX25obFNXTFU/view?usp=sharing")
    End Sub

    Private Shared DBConnectionStringAjax As String = "Data Source=114.134.189.211;Initial Catalog=CamTESOL_Messenger;Min Pool Size=5;Max Pool Size=60000;Connect Timeout=60;User Id=sa;Password=ACEidp.99;"
    Public Shared DBConnectionString As String = "Data Source=114.134.189.211;Initial Catalog=CamTESOL;Min Pool Size=5;Max Pool Size=60000;Connect Timeout=60;User Id=sa;Password=ACEidp.99;"

    Protected Sub btnViewNewMessage_Click(sender As Object, e As EventArgs)
        If Request.QueryString("user") IsNot Nothing AndAlso Request.QueryString("deviceid") IsNot Nothing Then
            Dim queryString As String = "?user=" & Request.QueryString("user").ToString & "&deviceid=" & Request.QueryString("deviceid").ToString & "&PresenterID="
            If Request.QueryString("PresenterID") IsNot Nothing Then
                queryString &= Request.QueryString("PresenterID").ToString
            Else
                queryString &= "0"
            End If
            Response.Redirect("http://app.camtesol.org/Messenger.aspx" & queryString)
        End If
    End Sub

    <WebMethod>
    Public Shared Function checkHasNewMessage(user As String, deviceID As String, presenterID As String) As Integer
        If Not String.IsNullOrEmpty(user) Then
            Dim dtUser = getUserInfoAjax(user)
            If dtUser.Rows.Count > 0 Then
                Dim serverProperties() As String = dtUser.Rows(0)("ServerProperties").ToString.Split(":")
                Dim tick As Long = 0
                If serverProperties.Length > 1 Then
                    tick = serverProperties(1)
                Else
                    Return -1
                End If
                Dim hasMessage As Boolean = hasNewMessageAjax(user, New Date(tick).ToString("yyyy-MM-dd HH':'mm':'ss.fff"))
                If hasMessage Then
                    Return 1
                Else
                    Return 0
                End If
            Else
                Return -1
            End If
        Else
            Return -1
        End If
    End Function

    Private Shared Function getUserInfoAjax(email As String) As DataTable
        Return selectQueryAjax("select * from CuteChat4_User where UserId='User:" & email & "'")
    End Function

    Public Shared Function selectQuery(command As String) As DataTable
        Try
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim con As New SqlConnection(DBConnectionString)
            Dim com As New SqlCommand
            com.Connection = con
            com.CommandText = command

            con.Open()
            da.SelectCommand = com
            da.Fill(dt)

            con.Close()
            Return dt
        Catch ex As Exception
            Return New DataTable
        End Try
    End Function

    Private Shared Function selectQueryAjax(command As String) As DataTable
        Try
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim con As New SqlConnection(DBConnectionStringAjax)
            Dim com As New SqlCommand
            com.Connection = con
            com.CommandText = command

            con.Open()
            da.SelectCommand = com
            da.Fill(dt)

            con.Close()
            Return dt
        Catch ex As Exception
            Return New DataTable
        End Try
    End Function

    Private Shared Function hasNewMessageAjax(email As String, lastLogin As String) As Boolean
        Dim dt As DataTable = selectQueryAjax("select MsgTime from CuteChat4_InstantMessage where TargetId='User:" & email & "' and convert(datetime, MsgTime, 126)>convert(varchar, '" & lastLogin & "', 126)")
        If dt.Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function
End Class
