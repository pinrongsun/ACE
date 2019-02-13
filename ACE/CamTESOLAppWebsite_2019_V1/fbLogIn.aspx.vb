Imports System.Net.Mail
Imports System.Data

Partial Class Default2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            MultiView1.ActiveViewIndex = 0
            If Request.Url.ToString.Contains("deviceid=") Then
                Dim BalGl As New BalGlobal_app
                Dim ds As DataSet = BalGl.getDataFromTable("tblDeviceLogin", "*", "email", "Where deviceid='" & Request.QueryString("deviceid") & "'", "asc")
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim email As String = ds.Tables(0).Rows(0)("email").ToString
                    Response.Redirect("eace.aspx?MenuID=10&ArticleID=22&user=" & email & "&deviceid=" & Request.QueryString("deviceid"))
                End If

            End If
        End If
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As System.EventArgs) Handles LinkButton1.Click
        MultiView1.ActiveViewIndex = 1
    End Sub

    Private Function send_password(StudentName As String, password As String, RecipientEmail As String) As Boolean
        Try

            Dim FN As String = StudentName

            Dim Subject As String = "CamTESOL App Account – forget password"
            Dim Body As String = ""
            Body = Body & vbCrLf & "Dear " & "<font color= blue>" & "<b>" & FN & "</b>" & "</font>" & "<br>" & "<br>"
            Body = Body & vbCrLf & "Your CamTESOL app account password is:" & "<br>" & "<br>"
            'Body = Body & vbCrLf & "Your ID: " & "<font color=Blue>" & "<b>" & ContactID & "</b>" & "</font>" & "<br>"
            Body = Body & vbCrLf & " " & "<font color=blue>" & "<b>" & password & "</b>" & "</font>" & "<br>" & "<br>"
            'Body = Body & vbCrLf & "<a href='http://acecambodia.org'>Click here to log-in to your account (www.acecambodia.org).</a>" & "<br>" & "<br>"
            Body = Body & vbCrLf & "Thanks, "

            Dim isSent As Boolean = MySendEmail(Subject, Body, RecipientEmail, "")
            Return isSent
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function MySendEmail(ByVal Subject As String, ByVal Body As String, ByVal Recipient As String, ByVal AttachmentPath As String) As Boolean

        Dim mail As MailMessage = New MailMessage()
        'Dim cc As New MailAddress("Database-Support@acecambodia.org")
        'Dim cc1 As New MailAddress("chanpheakdey.vong@acecambodia.org")
        mail.To.Add(Recipient)
        mail.From = New MailAddress("camtesol.noreply@acecambodia.org")
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
            smtp.Credentials = New System.Net.NetworkCredential("camtesol.noreply@acecambodia.org", "ipadTNE.92")
            smtp.EnableSsl = True
            smtp.Port = 587

            smtp.Send(mail)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function


    Private Function send_activate_link(StudentName As String, verifycode As String, RecipientEmail As String) As Boolean
        Try

            Dim FN As String = StudentName

            Dim Subject As String = "CamTESOL App – Activation Code"
            Dim Body As String = ""
            Body = Body & vbCrLf & "Dear " & "<font color= blue>" & "<b>" & FN & "</b>" & "</font>" & "<br>" & "<br>"
            Body = Body & vbCrLf & "Please find your activation code below:" & "<br>" & "<br>"
            'Body = Body & vbCrLf & "Your ID: " & "<font color=Blue>" & "<b>" & ContactID & "</b>" & "</font>" & "<br>"
            'Body = Body & vbCrLf & "Password: " & "<font color=blue>" & "<b>" & password & "</b>" & "</font>" & "<br>" & "<br>"
            Body = Body & vbCrLf & "<b>" & verifycode & "</b><br>" & "<br>"
            Body = Body & vbCrLf & "Thanks, "

            Dim isSent As Boolean = MySendEmail(Subject, Body, RecipientEmail, "")
            Return isSent
        Catch ex As Exception
            Return False
        End Try
    End Function

    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
        lblinfo.Text = ""
        lblinfo.ForeColor = Drawing.Color.Red
        If txtfullname.Text.Trim = "" Then
            lblinfo.Text = "Plese input your full name."
            Exit Sub
        ElseIf txtemail.Text = "" Then
            lblinfo.Text = "Plese input your email address."
            Exit Sub
        ElseIf txtpassword_create.Text.Trim = "" Then
            lblinfo.Text = "Plese input your prefered password."
            Exit Sub
        ElseIf Len(txtpassword_create.Text.Trim) <= 4 Then
            lblinfo.Text = "Password must be more than 4 character."
            Exit Sub
        ElseIf txtemail.Text.Trim <> txtretype.Text.Trim Then
            lblinfo.Text = "Your confirm email is not match."
            Exit Sub
        End If


        Dim rand As New Random()
        Dim RandomNumber As Integer
        RandomNumber = rand.[Next](100000, 999999)

        Dim BalGl As New BalGlobal_app
        Dim RegisterCode As Integer = BalGl.InsertToTable("tblUser", "Name, Email, Password, Country, InUse, Locked, Attempts, VerifyCode, CreatedDate, CreatedBy, Verified",
"'" & txtfullname.Text.Trim & "','" & txtemail.Text.Trim & "','" & txtpassword_create.Text & "','" & dplCountry.SelectedValue & "',0,0,0,'" & RandomNumber & "','" & Now.ToString("yyyy-MM-dd H:mm") & "','',0")

        Call send_activate_link(txtfullname.Text.Trim, RandomNumber, txtemail.Text)
        txtemail.ToolTip = txtemail.Text
        MultiView1.ActiveViewIndex = 6

    End Sub

    Protected Sub LinkButton3_Click(sender As Object, e As System.EventArgs) Handles LinkButton3.Click
        MultiView1.ActiveViewIndex = 0
    End Sub



    Protected Sub btnLogin_Click(sender As Object, e As System.EventArgs) Handles btnLogin.Click
        lblVerify.Text = ""
        lblVerify.ForeColor = Drawing.Color.Red
        If txtusername.Text.Trim = "" Then
            lblVerify.Text = "Please input your email."
            Exit Sub
        End If

        If txtpassword.Text.Trim = "" Then
            lblVerify.Text = "Please input your password."
            Exit Sub
        End If

        Dim BalGl As New BalGlobal_app
        Dim dsLogin As Data.DataSet = BalGl.getDataFromTable("tblUser", "*", "Email", "Where Email='" & txtusername.Text.Trim & "'", "asc")


        If dsLogin.Tables(0).Rows.Count > 0 Then
            Dim Verified As Boolean = dsLogin.Tables(0).Rows(0)("Verified")
            If Verified = False Then
                'lblVerify.Text = "Your account is not actived yet, please check your mail-inbox."
                txtemail.ToolTip = txtusername.Text
                MultiView1.ActiveViewIndex = 6
                Exit Sub
            End If
            Dim Locked As Boolean = dsLogin.Tables(0).Rows(0)("Locked")
            If Locked = True Then
                lblVerify.Text = "Account Locked! Please contact us."
                Exit Sub
            End If
            If dsLogin.Tables(0).Rows(0)("Password").ToString <> txtpassword.Text.Trim Then
                lblVerify.Text = "Invalid password!"
                Dim Attempts As Integer = dsLogin.Tables(0).Rows(0)("Attempts")
                If Attempts >= 5 Then
                    BalGl.UpdateValueInTable("tblUser", "Locked=1", "Where Email='" & txtusername.Text & "'")
                Else
                    BalGl.UpdateValueInTable("tblUser", "Attempts=Attempts+1", "Where Email='" & txtusername.Text & "'")
                End If
                Exit Sub
            End If
            Dim NowString As String = Now.ToString("yyyy-MM-dd H:mm:ss")
            If Request.QueryString("deviceid").ToString <> "" Then
                BalGl.InsertToTable("tblDeviceLogin", "DeviceID,Email,LoginDate", "'" & Request.QueryString("deviceid") & "','" & txtusername.Text.Trim & "','" & NowString & "'")
            End If

            Response.Redirect("eace.aspx?MenuID=10&ArticleID=22&user=" & txtusername.Text & "&deviceid=" & Request.QueryString("deviceid"))
        Else
            lblVerify.Text = "Invalid Email or Password"
        End If

    End Sub

    Protected Sub btnResetPassword_Click(sender As Object, e As System.EventArgs) Handles btnResetPassword.Click
        Dim BalGl As New BalGlobal_app
        Dim dsLogin As Data.DataSet = BalGl.getDataFromTable("tblUser", "*", "Email", "Where Email='" & txtEmail_Password.Text.Trim & "'", "asc")

        lblNoteForgetPassword.Text = ""
        lblNoteForgetPassword.ForeColor = Drawing.Color.Red
        If dsLogin.Tables(0).Rows.Count > 0 Then
            Dim Verified As Boolean = dsLogin.Tables(0).Rows(0)("Verified")
            If Verified = False Then
                lblNoteForgetPassword.Text = "Your account is not actived yet, please check your mail-inbox."
                Exit Sub
            End If
            Dim Locked As Boolean = dsLogin.Tables(0).Rows(0)("Locked")
            If Locked = True Then
                lblNoteForgetPassword.Text = "Account Locked! Please contact us."
                Exit Sub
            End If

        Else
            lblNoteForgetPassword.Text = "This email is not exist in CamTESOL app account."
            Exit Sub
        End If
        Dim FullName As String = dsLogin.Tables(0).Rows(0)("Name").ToString
        Dim Password As String = dsLogin.Tables(0).Rows(0)("Password").ToString
        Dim sendPassword As Boolean = send_password(FullName, Password, txtEmail_Password.Text.Trim)
        MultiView1.ActiveViewIndex = 5
    End Sub

    Protected Sub LinkButton6_Click(sender As Object, e As System.EventArgs) Handles LinkButton6.Click
        MultiView1.ActiveViewIndex = 4
    End Sub

    Protected Sub lnkExisting0_Click(sender As Object, e As System.EventArgs) Handles lnkExisting0.Click
        MultiView1.ActiveViewIndex = 0
    End Sub

    Protected Sub LinkButton7_Click(sender As Object, e As System.EventArgs) Handles LinkButton7.Click
        MultiView1.ActiveViewIndex = 0
    End Sub

    Protected Function checkAccessToken() As Boolean
        If Request.QueryString("access_token") IsNot Nothing Then
            Return True
        End If

        Return False
    End Function

    Protected Sub LinkButton5_Click(sender As Object, e As System.EventArgs) Handles LinkButton5.Click
        MultiView1.ActiveViewIndex = 0
    End Sub

    Protected Sub txtActivatecode_TextChanged(sender As Object, e As System.EventArgs) Handles txtActivatecode.TextChanged

    End Sub

    Protected Sub lnkExisting1_Click(sender As Object, e As System.EventArgs) Handles lnkExisting1.Click
        MultiView1.ActiveViewIndex = 0
    End Sub

    Protected Sub btnResetPassword0_Click(sender As Object, e As System.EventArgs) Handles btnActivateAccount.Click

        Dim verifyID As String = txtActivatecode.Text
        Dim email As String = txtemail.ToolTip
        lblInfoActivation.Text = ""
        lblInfoActivation.ForeColor = Drawing.Color.Red

        Dim BalGl As New BalGlobal_app
        Dim dsUser As DataSet = BalGl.getDataFromTable("tblUser", "*", "Email", "Where Email='" & email & "'", "asc")
        If dsUser.Tables(0).Rows.Count <= 0 Then
            lblInfoActivation.Text = "This email is not registered yet!"
            Exit Sub
        End If
        Dim ActivateCode As String = dsUser.Tables(0).Rows(0)("VerifyCode").ToString
        If verifyID <> ActivateCode Then
            lblInfoActivation.Text = "Invalid activate code!"
            Exit Sub
        End If

        BalGl.UpdateValueInTable("tblUser", "Verified=1", "Where VerifyCode ='" & verifyID & "' And Email='" & email & "'")
        Response.Redirect("eace.aspx?MenuID=10&ArticleID=22&user=" & email)

    End Sub

    Protected Sub txtfullname_TextChanged(sender As Object, e As System.EventArgs) Handles txtfullname.TextChanged

    End Sub
End Class
