Imports System.Data
Imports System.Data.SqlClient

Partial Class nametag
    Inherits System.Web.UI.Page

    Private Sub ClearData()
        txtFamilyName.Text = ""
        txtGivenName.Text = ""
        txtPosition.Text = ""
        txtWorkplace.Text = ""
        rdoStandard.Checked = True
        txtEmail.Text = ""
        txtPhone.Text = ""
        dplNationality.SelectedValue = ""
        dplCountry.SelectedValue = ""
        rdoHard.Checked = True
        dplParticipantType.SelectedValue = "Participant"
        chkRS.Checked = False
        chkLeadership.Checked = False
        chkDinner.Checked = False
        chkSat.Checked = False
        chkSun.Checked = False
        chkPaid.Checked = False
        txtPaidDate.Text = ""
        chkPrinted.Checked = False

    End Sub
    Protected Sub txtRegNo_TextChanged(sender As Object, e As EventArgs) Handles txtRegNo.TextChanged
        If IsNumeric(txtRegNo.Text.Trim) = False Then
           
                lblNotice.Text = "Invalid! Please enter number only!"
                div_detail.Visible = False
                div_more.Visible = False
            btnSubmit.Visible = False
        Else

            If Request.Url.ToString.Contains("admin") Then
                If Val(txtRegNo.Text) = 0 Then
                    div_detail.Visible = True
                    div_more.Visible = True
                    Call ClearData()
                    btnSubmit.Visible = True
                    Exit Sub
                End If
            End If

            Dim SelectedField As String = "RegistrationID,familyName_tag, GivenName_Tag, Position_Tag, Employer_Tag, ParticipantType" & _
                                                         ",dietary, isnull(ResearchSymposiumRate,0) as RS, isnull(LeadershipForum,0) as LeadershipForum, WelcomeReception, SelectedConfDay, CertificateType," & _
                                                         "Nationality, CountryofResidence, PrimaryEmail, PrimaryPhone, " & _
                                                         "Attended, AttendedDate, AttendedLeadershipForum, AttendedLeadershipForumDate," & _
"AttendedProvincialTeacher, AttendedProvincialTeacherDate, AttendedDinner, AttendedDinnerDate," & _
"AttendedTour, AttendedTourDate, AttendedSat, AttendedSatDate, AttendedSun, AttendedSunDate, Paid, PaidDate, isnull(cardprinted,0) as cardprinted, isnull(Deleted,0) as Deleted"
            Dim ds As DataSet = getDataFromTableCamTESOL("tblRegistrationCamTESOL", _
                                                         SelectedField, "RegistrationID", "where RegistrationID=" & txtRegNo.Text.Trim, "asc")
            If ds.Tables(0).Rows.Count = 0 Then
                lblNotice.Text = "Record not found!"
                div_detail.Visible = False
                div_more.Visible = False
            Else
                btnSubmit.Visible = True
                lblNotice.Text = ""
                Dim familyName_tag As String = ds.Tables(0).Rows(0)("familyName_tag").ToString
                Dim GivenName_Tag As String = ds.Tables(0).Rows(0)("GivenName_Tag").ToString

                Dim Position_Tag As String = ds.Tables(0).Rows(0)("Position_Tag").ToString
                Dim Employer_Tag As String = ds.Tables(0).Rows(0)("Employer_Tag").ToString
                txtFamilyName.ToolTip = familyName_tag
                txtGivenName.ToolTip = GivenName_Tag
                txtPosition.ToolTip = Position_Tag
                txtWorkplace.ToolTip = Employer_Tag

                Dim ParticipantType As String = ds.Tables(0).Rows(0)("ParticipantType").ToString

                Dim dietary As String = ds.Tables(0).Rows(0)("dietary").ToString
                Dim ResearchSymposium As Boolean = ds.Tables(0).Rows(0)("RS")
                Dim WelcomeReception As Boolean = ds.Tables(0).Rows(0)("WelcomeReception")
                Dim cardprinted As Boolean = ds.Tables(0).Rows(0)("cardprinted")
                Dim Deleted As Boolean = ds.Tables(0).Rows(0)("Deleted")

                Dim LeadershipForum As Boolean = ds.Tables(0).Rows(0)("LeadershipForum")
                Dim SelectedConfDay As String = ds.Tables(0).Rows(0)("SelectedConfDay").ToString
                Dim CertificateType As String = ds.Tables(0).Rows(0)("CertificateType").ToString
                Dim Nationality As String = ds.Tables(0).Rows(0)("Nationality").ToString
                Dim CountryofResidence As String = ds.Tables(0).Rows(0)("CountryofResidence").ToString
                Dim PrimaryEmail As String = ds.Tables(0).Rows(0)("PrimaryEmail").ToString
                Dim PrimaryPhone As String = ds.Tables(0).Rows(0)("PrimaryPhone").ToString
                txtRS0.Text = "" : txtLeadership0.Text = "" : txtProvincialTeacher0.Text = "" : txtTour0.Text = "" : txtDinner0.Text = ""
                txtSat0.Text = "" : txtSun0.Text = "" : txtPaidDate.Text = ""
                chkRS0.Checked = False : chkLeadership0.Checked = False : chkProvincialTeacher0.Checked = False : chkTour0.Checked = False : chkDinner0.Checked = False
                chkSat0.Checked = False : chkSun0.Checked = False : chkPaid.Checked = False : chkPrinted.Checked = False : chkDeleted.Checked = False

                Dim Att_RS As Boolean = False
                Dim Att_RS_Date As Date
                If IsDBNull(ds.Tables(0).Rows(0)("Attended")) = False Then
                    Att_RS = ds.Tables(0).Rows(0)("Attended")
                    If Att_RS = True Then
                        chkRS0.Checked = True
                        Att_RS_Date = ds.Tables(0).Rows(0)("AttendedDate")
                        txtRS0.Text = Att_RS_Date.ToString("dd/MM/yyyy HH:mm:ss")
                    End If
                End If
                Dim Att_LeaderShipF As Boolean = False
                Dim Att_LeaderShipF_Date As Date
                If IsDBNull(ds.Tables(0).Rows(0)("AttendedLeadershipForum")) = False Then
                    Att_LeaderShipF = ds.Tables(0).Rows(0)("AttendedLeadershipForum")
                    If Att_LeaderShipF = True Then
                        chkLeadership0.Checked = True
                        Att_LeaderShipF_Date = ds.Tables(0).Rows(0)("AttendedLeadershipForumDate")
                        txtLeadership0.Text = Att_LeaderShipF_Date.ToString("dd/MM/yyyy HH:mm:ss")
                    End If
                End If
                Dim Att_ProvincialTeacher As Boolean = False
                Dim Att_ProvincialTeacher_Date As Date
                If IsDBNull(ds.Tables(0).Rows(0)("AttendedProvincialTeacher")) = False Then
                    Att_ProvincialTeacher = ds.Tables(0).Rows(0)("AttendedProvincialTeacher")
                    If Att_ProvincialTeacher = True Then
                        chkProvincialTeacher0.Checked = True
                        Att_ProvincialTeacher_Date = ds.Tables(0).Rows(0)("AttendedProvincialTeacherDate")
                        txtProvincialTeacher0.Text = Att_ProvincialTeacher_Date.ToString("dd/MM/yyyy HH:mm:ss")
                    End If
                End If
                Dim Att_Dinner As Boolean = False
                Dim Att_Dinner_Date As Date
                If IsDBNull(ds.Tables(0).Rows(0)("AttendedDinner")) = False Then
                    Att_Dinner = ds.Tables(0).Rows(0)("AttendedDinner")
                    If Att_Dinner = True Then
                        chkDinner0.Checked = True
                        Att_Dinner_Date = ds.Tables(0).Rows(0)("AttendedDinnerDate")
                        txtDinner0.Text = Att_Dinner_Date.ToString("dd/MM/yyyy HH:mm:ss")
                    End If
                End If
                Dim Att_Tour As Boolean = False
                Dim Att_Tour_Date As Date
                If IsDBNull(ds.Tables(0).Rows(0)("AttendedTour")) = False Then
                    Att_Tour = ds.Tables(0).Rows(0)("AttendedTour")
                    If Att_Tour = True Then
                        chkTour0.Checked = True
                        Att_Tour_Date = ds.Tables(0).Rows(0)("AttendedDinnerDate")
                        txtTour0.Text = Att_Tour_Date.ToString("dd/MM/yyyy HH:mm:ss")
                    End If
                End If
                Dim Att_Sat As Boolean = False
                Dim Att_Sat_Date As Date
                If IsDBNull(ds.Tables(0).Rows(0)("AttendedSat")) = False Then
                    Att_Sat = ds.Tables(0).Rows(0)("AttendedSat")
                    If Att_Sat = True Then
                        chkSat0.Checked = True
                        Att_Sat_Date = ds.Tables(0).Rows(0)("AttendedSatDate")
                        txtSat0.Text = Att_Sat_Date.ToString("dd/MM/yyyy HH:mm:ss")
                    End If
                End If

                Dim Att_Sun As Boolean = False
                Dim Att_Sun_Date As Date
                If IsDBNull(ds.Tables(0).Rows(0)("AttendedSun")) = False Then
                    Att_Sun = ds.Tables(0).Rows(0)("AttendedSun")
                    If Att_Sun = True Then
                        chkSun0.Checked = True
                        Att_Sun_Date = ds.Tables(0).Rows(0)("AttendedSunDate")
                        txtSun0.Text = Att_Sun_Date.ToString("dd/MM/yyyy HH:mm:ss")
                    End If
                End If

                Dim Paid As Boolean = False
                Dim Paid_Date As Date
                If IsDBNull(ds.Tables(0).Rows(0)("Paid")) = False Then
                    Paid = ds.Tables(0).Rows(0)("Paid")
                    chkPaid.Checked = Paid
                    If Paid = True Then
                        Paid_Date = ds.Tables(0).Rows(0)("PaidDate")
                        txtPaidDate.Text = Paid_Date.ToString("dd/MM/yyyy HH:mm:ss")
                    End If
                End If

                txtFamilyName.Text = familyName_tag
                txtGivenName.Text = GivenName_Tag
                txtPosition.Text = Position_Tag
                txtWorkplace.Text = Employer_Tag
                rdoStandard.Checked = False
                rdoHalal.Checked = False
                rdoVegetarian.Checked = False

                If dietary = "Standard" Then
                    rdoStandard.Checked = True
                ElseIf dietary = "Halal" Then
                    rdoHalal.Checked = True
                ElseIf dietary = "Vegetarian" Then
                    rdoVegetarian.Checked = True
                Else
                    rdoStandard.Checked = False
                    rdoHalal.Checked = False
                    rdoVegetarian.Checked = False
                End If
                txtEmail.Text = PrimaryEmail
                txtPhone.Text = PrimaryPhone

                dplNationality.Text = Nationality
                dplCountry.Text = CountryofResidence

                dplParticipantType.Text = ParticipantType

                rdoHard.Checked = False
                rdoSoft.Checked = False
                If CertificateType = "Hard copy" Then
                    rdoHard.Checked = True
                ElseIf CertificateType = "Soft copy" Then
                    rdoSoft.Checked = True
                Else
                    rdoHard.Checked = False
                    rdoSoft.Checked = False
                End If
                chkRS.Checked = ResearchSymposium
                chkLeadership.Checked = LeadershipForum
                chkDinner.Checked = WelcomeReception
                chkPrinted.Checked = cardprinted
                chkDeleted.Checked = Deleted

                If SelectedConfDay = "1 day: Saturday (16 February)" Then
                    chkSat.Checked = True
                    chkSun.Checked = False
                ElseIf SelectedConfDay = "1 day: Sunday (17 February)" Then
                    chkSat.Checked = False
                    chkSun.Checked = True
                ElseIf SelectedConfDay = "2 days: Saturday and Sunday (16-17 February)" Then
                    chkSat.Checked = True
                    chkSun.Checked = True
                Else
                    chkSat.Checked = False
                    chkSun.Checked = False

                End If

                If Request.Url.ToString.Contains("admin") Then
                    div_detail.Visible = True
                    div_more.Visible = True
                Else
                    div_detail.Visible = True
                    div_more.Visible = False
                End If
            End If
        End If

    End Sub

    Private Sub BoundToCboNew(ByVal ddl As AjaxControlToolkit.ComboBox, ByVal TableName As String, ByVal DisplayField As String, ByVal ValueField As String, ByVal Condition As String, ByVal SortOrder As String)

        ddl.DataSource = getDataFromTableCamTESOL(TableName, "distinct " & DisplayField, ValueField, Condition, SortOrder).Tables(0)
        ddl.DataTextField = DisplayField
        ddl.DataBind()
        ddl.SelectedIndex = 0

    End Sub
    Private Function getDataFromTableCamTESOL(ByVal TableName As String, ByVal DisplayFields As String, ByVal SortField As String, ByVal Condition As String, ByVal SortOrder As String) As DataSet

        Dim ds As New DataSet
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim adapter As New SqlDataAdapter
        cn.ConnectionString = DalConnection_app.EDBConnectionString
        cn.Open()
        cmd.CommandText = "SELECT " & DisplayFields & " FROM " & TableName & " " & Condition & " ORDER BY " & SortField & " " & SortOrder

        cmd.CommandType = CommandType.Text
        cmd.Connection = cn
        adapter.SelectCommand = cmd
        'fill the dataset
        adapter.Fill(ds)
        cn.Close()
        'return the dataset
        Return ds
    End Function

    Protected Sub btnAdmin_Click(sender As Object, e As EventArgs) Handles btnAdmin.Click
        If txtAdminPassword.Text = "it2019" And txtUserName.Text = "admin" Then
            lblpasswordNotice.Text = ""
            pnRegistration.Enabled = True
            dplParticipantType.Enabled = True
            lnkAttendance.Visible = True
            MultiView1.ActiveViewIndex = 0
        Else
            pnRegistration.Enabled = False
            dplParticipantType.Enabled = False
            lblpasswordNotice.Text = "Incorrent password!"
        End If
    End Sub

    Protected Sub txtAdminPassword_TextChanged(sender As Object, e As EventArgs) Handles txtAdminPassword.TextChanged
        Call btnAdmin_Click(sender, e)
    End Sub

    Protected Sub btnSubmit1_Click(sender As Object, e As EventArgs) Handles btnSubmit1.Click
        MultiView1.ActiveViewIndex = 0
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            MultiView1.ActiveViewIndex = 0
            Call BoundToCboNew(dplNationality, "RefTblCountry", "Nationality", "Nationality", "", "Asc")
            Call BoundToCboNew(dplCountry, "RefTblCountry", "Countryname", "Countryname", "", "Asc")
            If Request.Url.ToString.Contains("admin") Then
                MultiView1.ActiveViewIndex = 1
            End If
        End If
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim familyName_tag As String = txtFamilyName.Text.Trim
        Dim GivenName_Tag As String = txtGivenName.Text.Trim

        Dim Position_Tag As String = txtPosition.Text.Trim
        Dim Employer_Tag As String = txtWorkplace.Text.Trim
        Dim ParticipantType As String = dplParticipantType.SelectedValue

        Dim dietary As String = ""
        If rdoStandard.Checked = True Then
            dietary = "Standard"
        ElseIf rdoHalal.Checked = True Then
            dietary = "Halal"
        ElseIf rdoVegetarian.Checked = True Then
            dietary = "Vegetarian"
        End If

        Dim ResearchSymposium As Boolean = chkRS.Checked
        Dim WelcomeReception As Boolean = chkDinner.Checked
        Dim cardprinted As Boolean = chkPrinted.Checked

        Dim LeadershipForum As Boolean = chkLeadership.Checked
        Dim SelectedConfDay As String = ""
        If chkSat.Checked = True AndAlso chkSun.Checked = False Then
            SelectedConfDay = "1 day: Saturday (16 February)"
        ElseIf chkSat.Checked = False AndAlso chkSun.Checked = True Then
            SelectedConfDay = "1 day: Sunday (17 February)"
        ElseIf chkSat.Checked = True AndAlso chkSun.Checked = True Then
            SelectedConfDay = "2 days: Saturday and Sunday (16-17 February)"
        End If

        Dim CertificateType As String = ""
        If rdoHard.Checked = True Then
            CertificateType = "Hard copy"
        ElseIf rdoSoft.Checked = True Then
            CertificateType = "Soft copy"
        End If
        Dim Nationality As String = dplNationality.SelectedValue
        Dim CountryofResidence As String = dplCountry.SelectedValue
        Dim PrimaryEmail As String = txtEmail.Text.Trim
        Dim PrimaryPhone As String = txtPhone.Text.Trim

        Dim UpdatedFeilds As String = ""
        Dim RecordsChange As Boolean = False
        If txtFamilyName.Text.Trim <> txtFamilyName.ToolTip Then
            UpdatedFeilds &= "FamilyName"
            RecordsChange = True
        End If

        If txtGivenName.Text.Trim <> txtGivenName.ToolTip Then
            If UpdatedFeilds = "" Then
                UpdatedFeilds &= "GivenName"
            Else
                UpdatedFeilds &= ",GivenName"
            End If
            RecordsChange = True
        End If

        If txtPosition.Text.Trim <> txtPosition.ToolTip Then
            If UpdatedFeilds = "" Then
                UpdatedFeilds &= "Position"
            Else
                UpdatedFeilds &= ",Position"
            End If
            RecordsChange = True
        End If

        If txtWorkplace.Text.Trim <> txtWorkplace.ToolTip Then
            If UpdatedFeilds = "" Then
                UpdatedFeilds &= "Employer"
            Else
                UpdatedFeilds &= ",Employer"
            End If
            RecordsChange = True
        End If

        If RecordsChange = True Then
            InsertToTable_CamTESOL("tblInfoLog", "RegistrationID, FamilyName, GivenName, Position, Employer, CreatedDate, UpdatedFields", _
                               txtRegNo.Text.Trim & ",'" & familyName_tag & "','" & GivenName_Tag & "','" & Position_Tag & "','" & Employer_Tag & "','" & Now.ToString("yyyy-MM-dd HH:mm:ss") & "','" & UpdatedFeilds & "'")
        End If

        Dim RecordChange_SQL As String = ""
        If RecordsChange = True Then
            RecordChange_SQL = ", RecordChanged=" & IIf(RecordsChange = True, 1, 0)
        End If
        Dim UpdatedSQL As String = "FamilyName_Tag='" & familyName_tag & "', GivenName_Tag='" & GivenName_Tag & "', Position_Tag='" & Position_Tag & "', Employer_Tag='" & Employer_Tag & "'" & _
", dietary='" & dietary & "', PrimaryEmail='" & PrimaryEmail & "', PrimaryPhone='" & PrimaryPhone & "', Nationality='" & Nationality & "'," & _
"CountryofResidence='" & CountryofResidence & "', CertificateType='" & CertificateType & "', ParticipantType='" & ParticipantType & "'," & _
"ResearchSymposiumRate=" & IIf(ResearchSymposium = True, 1, 0) & ", LeadershipForum=" & IIf(LeadershipForum = True, 1, 0) & ", WelcomeReception=" & IIf(WelcomeReception = True, 1, 0) & "," & _
"SelectedConfDay='" & SelectedConfDay & "',cardprinted=" & IIf(cardprinted = True, 1, 0) & RecordChange_SQL

        If Request.Url.ToString.Contains("admin") Then
            If Val(txtRegNo.Text) = 0 Then
                Dim Paid As Boolean = chkPaid.Checked
                Dim Paid_int As Integer = 0
                Dim PaidDate_String As String = ""
                If Paid = True Then
                    Paid_int = 1
                    Dim PaidDateString As String = Left(txtPaidDate.Text.Trim, 10)
                    Dim PaidTime As String = Right(txtPaidDate.Text.Trim, 8)
                    Dim PaidDate As Date
                    If PaidDateString = "" Then
                        PaidDate = Now
                        PaidTime = Now.ToString("HH:mm:ss")
                    Else
                        PaidDate = DateSerial(Val(Right(PaidDateString, 4)), Val(Mid(PaidDateString, 4, 2)), Val(Left(PaidDateString, 2))).Date
                    End If
                    PaidDate_String = PaidDate.ToString("yyyy-MM-dd") & " " & PaidTime
                Else
                    Paid_int = 0
                    PaidDate_String = "NULL"
                End If
                txtRegNo.Text = InsertToTable_CamTESOL("tblRegistrationCamTESOL", "FamilyName, GivenName, Position, Employer, " & _
                                       "FamilyName_Tag, GivenName_Tag, Position_Tag, Employer_Tag, " & _
                                       "dietary, PrimaryEmail, PrimaryPhone, Nationality, CountryofResidence, CertificateType," & _
                                       "ParticipantType, ResearchSymposiumRate, LeadershipForum, WelcomeReception, SelectedConfDay, cardprinted, Paid, PaidDate, RecordChanged", _
                                       "'" & familyName_tag & "','" & GivenName_Tag & "','" & Position_Tag & "','" & Employer_Tag & "'," & _
                                       "'" & familyName_tag & "','" & GivenName_Tag & "','" & Position_Tag & "','" & Employer_Tag & "'," & _
                                       "'" & dietary & "','" & PrimaryEmail & "','" & PrimaryPhone & "','" & Nationality & "','" & CountryofResidence & "','" & CertificateType & "'," & _
                                       "'" & ParticipantType & "'," & IIf(ResearchSymposium = True, 1, 0) & "," & IIf(LeadershipForum = True, 1, 0) & "," & IIf(WelcomeReception = True, 1, 0) & ",'" & SelectedConfDay & "'," & IIf(cardprinted = True, 1, 0) & "," & Paid_int & "," & IIf(Paid = True, "'" & PaidDate_String & "'", "NULL") & ", 1")
            Else
                UpdateValueInTable_CamTESOL("tblRegistrationCamTESOL", _
                            UpdatedSQL, "Where RegistrationID=" & txtRegNo.Text.Trim)
            End If
        Else
            UpdateValueInTable_CamTESOL("tblRegistrationCamTESOL", _
                                        UpdatedSQL, "Where RegistrationID=" & txtRegNo.Text.Trim)
        End If

       
        
        'pnRegistration.Enabled = False
        'dplParticipantType.Enabled = False
        div_detail.Visible = False
        div_more.Visible = False

        btnSubmit.Visible = False

        Dim url2 As String = "print.aspx?Date=" & Now & "&RegistrationID=" & txtRegNo.Text.Trim

        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "openpopup", "window.open('" & url2 & "','OpenChildWindowUsingUpdatePanel','height = 500, width = 800,status=no,location=no,directories=no, resizable = 1, scrollbars=yes, left=75, top=75');", True)
        txtRegNo.Text = ""
    End Sub

    Private Function InsertToTable_CamTESOL(ByVal TableName As String, ByVal FieldsName As String, ByVal Values As String) As Integer

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim adapter As New SqlDataAdapter
        cn.ConnectionString = DalConnection_app.EDBConnectionString
        cn.Open()
        cmd.CommandText = " INSERT INTO " & TableName & " ( " & FieldsName & " ) Values (" & Values & ") SELECT SCOPE_IDENTITY();"

        cmd.Connection = cn 'assign the connection


        'execute the command

        ''cmd.ExecuteNonQuery()
        Dim obj = cmd.ExecuteScalar()

        If Not IsNothing(obj) And Not IsDBNull(obj) Then
            Return CInt(obj.ToString)
        Else
            Return 0
        End If
        cn.Close()

    End Function
    Protected Sub lnkAdmin_Click(sender As Object, e As EventArgs) Handles lnkAdmin.Click
        MultiView1.ActiveViewIndex = 1
        txtAdminPassword.Text = ""
    End Sub

    Protected Sub lnkAttendance_Click(sender As Object, e As EventArgs) Handles lnkAttendance.Click
        MultiView1.ActiveViewIndex = 2
    End Sub

    Protected Sub btnSubmit2_Click(sender As Object, e As EventArgs) Handles btnSubmit2.Click
        MultiView1.ActiveViewIndex = 0
    End Sub

    Protected Sub chkPaid_CheckedChanged(sender As Object, e As EventArgs) Handles chkPaid.CheckedChanged
        If chkPaid.Checked = True Then
            Dim PaidDateString As String = Left(txtPaidDate.Text.Trim, 10)
            Dim PaidTime As String = Right(txtPaidDate.Text.Trim, 8)
            Dim PaidDate As Date
            If PaidDateString = "" Then
                PaidDate = Now
                PaidTime = Now.ToString("HH:mm:ss")
            Else
                PaidDate = DateSerial(Val(Right(PaidDateString, 4)), Val(Mid(PaidDateString, 4, 2)), Val(Left(PaidDateString, 2))).Date
            End If
            UpdateValueInTable_CamTESOL("tblRegistrationCamTESOL", "Paid=1, PaidDate='" & PaidDate.ToString("yyyy-MM-dd") & " " & PaidTime & "'", "Where RegistrationID=" & txtRegNo.Text.Trim)
            txtPaidDate.Text = PaidDate.ToString("yyyy-MM-dd") & " " & PaidTime
        Else
            UpdateValueInTable_CamTESOL("tblRegistrationCamTESOL", "Paid=0, PaidDate=NULL", "Where RegistrationID=" & txtRegNo.Text.Trim)
            txtPaidDate.Text = ""
        End If
    End Sub


    Private Sub UpdateValueInTable_CamTESOL(ByVal TableName As String, ByVal UpdatingFieldNValue As String, ByVal Condition As String)

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim adapter As New SqlDataAdapter
        cn.ConnectionString = DalConnection_app.EDBConnectionString

        cmd.CommandText = " UPDATE " & TableName & " SET " & UpdatingFieldNValue & " " & Condition

        cmd.Connection = cn 'assign the connection

        'execute the command
        cn.Open()
        'Try
        cmd.ExecuteNonQuery()
        'Catch ex As Exception
        '    MsgBox(cmd.CommandText)
        'End Try
        cn.Close()

    End Sub

    Protected Sub txtPaidDate_TextChanged(sender As Object, e As EventArgs) Handles txtPaidDate.TextChanged
        Call chkPaid_CheckedChanged(sender, e)
    End Sub

    Protected Sub chkRS0_CheckedChanged(sender As Object, e As EventArgs) Handles chkRS0.CheckedChanged
        Dim chk As CheckBox = chkRS0
        Dim txt As TextBox = txtRS0
        Dim AttendedField As String = "Attended"
        Dim AttendedDateField As String = "AttendedDate"

        If chk.Checked = True Then
            Dim Att_DateString As String = Left(txt.Text.Trim, 10)
            Dim Att_Time As String = Right(txt.Text.Trim, 8)
            Dim Att_Date As Date
            If Att_DateString = "" Then
                Att_Date = Now
                Att_Time = Now.ToString("HH:mm:ss")
            Else
                Att_Date = DateSerial(Val(Right(Att_DateString, 4)), Val(Mid(Att_DateString, 4, 2)), Val(Left(Att_DateString, 2))).Date
            End If
            UpdateValueInTable_CamTESOL("tblRegistrationCamTESOL", AttendedField & "=1, " & AttendedDateField & "='" & Att_Date.ToString("yyyy-MM-dd") & " " & Att_Time & "'", "Where RegistrationID=" & txtRegNo.Text.Trim)
            txt.Text = Att_Date.ToString("dd/MM/yyyy") & " " & Att_Time
        Else
            UpdateValueInTable_CamTESOL("tblRegistrationCamTESOL", AttendedField & "=0, " & AttendedDateField & "=NULL", "Where RegistrationID=" & txtRegNo.Text.Trim)
            txt.Text = ""
        End If
    End Sub

    Protected Sub txtRS0_TextChanged(sender As Object, e As EventArgs) Handles txtRS0.TextChanged
        Call chkRS0_CheckedChanged(sender, e)
    End Sub

    Protected Sub chkLeadership0_CheckedChanged(sender As Object, e As EventArgs) Handles chkLeadership0.CheckedChanged
        Dim chk As CheckBox = chkLeadership0
        Dim txt As TextBox = txtLeadership0
        Dim AttendedField As String = "AttendedLeadershipForum"
        Dim AttendedDateField As String = "AttendedLeadershipForumDate"

        If chk.Checked = True Then
            Dim Att_DateString As String = Left(txt.Text.Trim, 10)
            Dim Att_Time As String = Right(txt.Text.Trim, 8)
            Dim Att_Date As Date
            If Att_DateString = "" Then
                Att_Date = Now
                Att_Time = Now.ToString("HH:mm:ss")
            Else
                Att_Date = DateSerial(Val(Right(Att_DateString, 4)), Val(Mid(Att_DateString, 4, 2)), Val(Left(Att_DateString, 2))).Date
            End If
            UpdateValueInTable_CamTESOL("tblRegistrationCamTESOL", AttendedField & "=1, " & AttendedDateField & "='" & Att_Date.ToString("yyyy-MM-dd") & " " & Att_Time & "'", "Where RegistrationID=" & txtRegNo.Text.Trim)
            txt.Text = Att_Date.ToString("dd/MM/yyyy") & " " & Att_Time
        Else
            UpdateValueInTable_CamTESOL("tblRegistrationCamTESOL", AttendedField & "=0, " & AttendedDateField & "=NULL", "Where RegistrationID=" & txtRegNo.Text.Trim)
            txt.Text = ""
        End If
    End Sub

    Protected Sub txtLeadership0_TextChanged(sender As Object, e As EventArgs) Handles txtLeadership0.TextChanged
        Call chkLeadership0_CheckedChanged(sender, e)
    End Sub

    Protected Sub chkProvincialTeacher0_CheckedChanged(sender As Object, e As EventArgs) Handles chkProvincialTeacher0.CheckedChanged
        Dim chk As CheckBox = chkProvincialTeacher0
        Dim txt As TextBox = txtProvincialTeacher0
        Dim AttendedField As String = "AttendedProvincialTeacher"
        Dim AttendedDateField As String = "AttendedProvincialTeacherDate"

        If chk.Checked = True Then
            Dim Att_DateString As String = Left(txt.Text.Trim, 10)
            Dim Att_Time As String = Right(txt.Text.Trim, 8)
            Dim Att_Date As Date
            If Att_DateString = "" Then
                Att_Date = Now
                Att_Time = Now.ToString("HH:mm:ss")
            Else
                Att_Date = DateSerial(Val(Right(Att_DateString, 4)), Val(Mid(Att_DateString, 4, 2)), Val(Left(Att_DateString, 2))).Date
            End If
            UpdateValueInTable_CamTESOL("tblRegistrationCamTESOL", AttendedField & "=1, " & AttendedDateField & "='" & Att_Date.ToString("yyyy-MM-dd") & " " & Att_Time & "'", "Where RegistrationID=" & txtRegNo.Text.Trim)
            txt.Text = Att_Date.ToString("dd/MM/yyyy") & " " & Att_Time
        Else
            UpdateValueInTable_CamTESOL("tblRegistrationCamTESOL", AttendedField & "=0, " & AttendedDateField & "=NULL", "Where RegistrationID=" & txtRegNo.Text.Trim)
            txt.Text = ""
        End If
    End Sub

    Protected Sub txtProvincialTeacher0_TextChanged(sender As Object, e As EventArgs) Handles txtProvincialTeacher0.TextChanged
        Call chkProvincialTeacher0_CheckedChanged(sender, e)
    End Sub

    Protected Sub chkDinner0_CheckedChanged(sender As Object, e As EventArgs) Handles chkDinner0.CheckedChanged
        Dim chk As CheckBox = chkDinner0
        Dim txt As TextBox = txtDinner0
        Dim AttendedField As String = "AttendedDinner"
        Dim AttendedDateField As String = "AttendedDinnerDate"

        If chk.Checked = True Then
            Dim Att_DateString As String = Left(txt.Text.Trim, 10)
            Dim Att_Time As String = Right(txt.Text.Trim, 8)
            Dim Att_Date As Date
            If Att_DateString = "" Then
                Att_Date = Now
                Att_Time = Now.ToString("HH:mm:ss")
            Else
                Att_Date = DateSerial(Val(Right(Att_DateString, 4)), Val(Mid(Att_DateString, 4, 2)), Val(Left(Att_DateString, 2))).Date
            End If
            UpdateValueInTable_CamTESOL("tblRegistrationCamTESOL", AttendedField & "=1, " & AttendedDateField & "='" & Att_Date.ToString("yyyy-MM-dd") & " " & Att_Time & "'", "Where RegistrationID=" & txtRegNo.Text.Trim)
            txt.Text = Att_Date.ToString("dd/MM/yyyy") & " " & Att_Time
        Else
            UpdateValueInTable_CamTESOL("tblRegistrationCamTESOL", AttendedField & "=0, " & AttendedDateField & "=NULL", "Where RegistrationID=" & txtRegNo.Text.Trim)
            txt.Text = ""
        End If
    End Sub

    Protected Sub txtDinner0_TextChanged(sender As Object, e As EventArgs) Handles txtDinner0.TextChanged
        Call chkDinner0_CheckedChanged(sender, e)
    End Sub

    Protected Sub chkTour0_CheckedChanged(sender As Object, e As EventArgs) Handles chkTour0.CheckedChanged
        Dim chk As CheckBox = chkTour0
        Dim txt As TextBox = txtTour0
        Dim AttendedField As String = "AttendedTour"
        Dim AttendedDateField As String = "AttendedTourDate"

        If chk.Checked = True Then
            Dim Att_DateString As String = Left(txt.Text.Trim, 10)
            Dim Att_Time As String = Right(txt.Text.Trim, 8)
            Dim Att_Date As Date
            If Att_DateString = "" Then
                Att_Date = Now
                Att_Time = Now.ToString("HH:mm:ss")
            Else
                Att_Date = DateSerial(Val(Right(Att_DateString, 4)), Val(Mid(Att_DateString, 4, 2)), Val(Left(Att_DateString, 2))).Date
            End If
            UpdateValueInTable_CamTESOL("tblRegistrationCamTESOL", AttendedField & "=1, " & AttendedDateField & "='" & Att_Date.ToString("yyyy-MM-dd") & " " & Att_Time & "'", "Where RegistrationID=" & txtRegNo.Text.Trim)
            txt.Text = Att_Date.ToString("dd/MM/yyyy") & " " & Att_Time
        Else
            UpdateValueInTable_CamTESOL("tblRegistrationCamTESOL", AttendedField & "=0, " & AttendedDateField & "=NULL", "Where RegistrationID=" & txtRegNo.Text.Trim)
            txt.Text = ""
        End If
    End Sub

    Protected Sub txtTour0_TextChanged(sender As Object, e As EventArgs) Handles txtTour0.TextChanged
        Call chkTour0_CheckedChanged(sender, e)
    End Sub

    Protected Sub chkSat0_CheckedChanged(sender As Object, e As EventArgs) Handles chkSat0.CheckedChanged
        Dim chk As CheckBox = chkSat0
        Dim txt As TextBox = txtSat0
        Dim AttendedField As String = "AttendedSat"
        Dim AttendedDateField As String = "AttendedSatDate"

        If chk.Checked = True Then
            Dim Att_DateString As String = Left(txt.Text.Trim, 10)
            Dim Att_Time As String = Right(txt.Text.Trim, 8)
            Dim Att_Date As Date
            If Att_DateString = "" Then
                Att_Date = Now
                Att_Time = Now.ToString("HH:mm:ss")
            Else
                Att_Date = DateSerial(Val(Right(Att_DateString, 4)), Val(Mid(Att_DateString, 4, 2)), Val(Left(Att_DateString, 2))).Date
            End If
            UpdateValueInTable_CamTESOL("tblRegistrationCamTESOL", AttendedField & "=1, " & AttendedDateField & "='" & Att_Date.ToString("yyyy-MM-dd") & " " & Att_Time & "'", "Where RegistrationID=" & txtRegNo.Text.Trim)
            txt.Text = Att_Date.ToString("dd/MM/yyyy") & " " & Att_Time
        Else
            UpdateValueInTable_CamTESOL("tblRegistrationCamTESOL", AttendedField & "=0, " & AttendedDateField & "=NULL", "Where RegistrationID=" & txtRegNo.Text.Trim)
            txt.Text = ""
        End If
    End Sub

    Protected Sub txtSat0_TextChanged(sender As Object, e As EventArgs) Handles txtSat0.TextChanged
        Call chkSat0_CheckedChanged(sender, e)
    End Sub

    Protected Sub chkSun0_CheckedChanged(sender As Object, e As EventArgs) Handles chkSun0.CheckedChanged
        Dim chk As CheckBox = chkSun0
        Dim txt As TextBox = txtSun0
        Dim AttendedField As String = "AttendedSun"
        Dim AttendedDateField As String = "AttendedSunDate"

        If chk.Checked = True Then
            Dim Att_DateString As String = Left(txt.Text.Trim, 10)
            Dim Att_Time As String = Right(txt.Text.Trim, 8)
            Dim Att_Date As Date
            If Att_DateString = "" Then
                Att_Date = Now
                Att_Time = Now.ToString("HH:mm:ss")
            Else
                Att_Date = DateSerial(Val(Right(Att_DateString, 4)), Val(Mid(Att_DateString, 4, 2)), Val(Left(Att_DateString, 2))).Date
            End If
            UpdateValueInTable_CamTESOL("tblRegistrationCamTESOL", AttendedField & "=1, " & AttendedDateField & "='" & Att_Date.ToString("yyyy-MM-dd") & " " & Att_Time & "'", "Where RegistrationID=" & txtRegNo.Text.Trim)
            txt.Text = Att_Date.ToString("dd/MM/yyyy") & " " & Att_Time
        Else
            UpdateValueInTable_CamTESOL("tblRegistrationCamTESOL", AttendedField & "=0, " & AttendedDateField & "=NULL", "Where RegistrationID=" & txtRegNo.Text.Trim)
            txt.Text = ""
        End If
    End Sub

    Protected Sub txtSun0_TextChanged(sender As Object, e As EventArgs) Handles txtSun0.TextChanged
        Call chkSun0_CheckedChanged(sender, e)
    End Sub

    Protected Sub chkPrinted_CheckedChanged(sender As Object, e As EventArgs) Handles chkPrinted.CheckedChanged
        If chkPrinted.Checked = True Then
           
            UpdateValueInTable_CamTESOL("tblRegistrationCamTESOL", "cardprinted=1", "Where RegistrationID=" & txtRegNo.Text.Trim)
        Else
            UpdateValueInTable_CamTESOL("tblRegistrationCamTESOL", "cardprinted=0", "Where RegistrationID=" & txtRegNo.Text.Trim)

        End If
    End Sub

    Protected Sub chkDeleted_CheckedChanged(sender As Object, e As EventArgs) Handles chkDeleted.CheckedChanged
        If chkDeleted.Checked = True Then

            UpdateValueInTable_CamTESOL("tblRegistrationCamTESOL", "Deleted=1", "Where RegistrationID=" & txtRegNo.Text.Trim)
        Else
            UpdateValueInTable_CamTESOL("tblRegistrationCamTESOL", "Deleted=0", "Where RegistrationID=" & txtRegNo.Text.Trim)

        End If
    End Sub
End Class
