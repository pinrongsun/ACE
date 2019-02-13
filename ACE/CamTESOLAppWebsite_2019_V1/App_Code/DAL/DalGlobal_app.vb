Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.StateBag
Imports System.Net.Mail
Imports System.Net.NetworkCredential
Imports System.Web.UI.WebControls
Imports System

Public Class DalGlobal_app
    Private Shared GlobalInstance As DalGlobal_app


    Public Shared ReadOnly Property Instance As DalGlobal_app
        Get
            If GlobalInstance Is Nothing Then
                GlobalInstance = New DalGlobal_app
            End If
            Return GlobalInstance
        End Get
    End Property


    Public Function ChangeToDate(ByVal DD_MM_YYYY As String) As Date
        Dim FormatDate As Date = DateSerial(Mid(DD_MM_YYYY, 7, 4), Mid(DD_MM_YYYY, 4, 2), Mid(DD_MM_YYYY, 1, 2))
        Return FormatDate
    End Function


    Public Function Seach(ByVal TableName As String, ByVal Field As String, ByVal Keyword As String, ByVal Choice As Integer, ByVal AdditionalCondition As String, ByVal DisplayFields As String) As DataSet
        Dim cn As New SqlConnection
        cn.ConnectionString = DalConnection_app.IOSConnectionString
        cn.Open()
        Dim ds As New DataSet
        Dim condition As String = ""
        If Choice = 0 Then
            If Keyword = "*" Then
                condition = " where " & Field & " is not null " & AdditionalCondition
            Else
                condition = " where " & Field & " like '%" & Keyword & "%' " & AdditionalCondition
            End If

        ElseIf Choice = 1 Then
            If Keyword = "*" Then
                condition = " where " & Field & " is not null " & AdditionalCondition
            Else
                condition = " where " & Field & " like '" & Keyword & "%' " & AdditionalCondition
            End If

        ElseIf Choice = 2 Then
            If Keyword = "*" Then
                condition = " where " & Field & " is not null " & AdditionalCondition
            Else
                condition = " where " & Field & " like '%" & Keyword & "' " & AdditionalCondition
            End If

        Else
            If Field = "ContactID" Or Field = "ClassID" Or Field = "SponsorID" Then
                If IsNumeric(Keyword) = False Then
                    Return Nothing
                    Exit Function
                End If

                condition = " where " & Field & " = " & Keyword & " " & AdditionalCondition
            Else
                If Keyword = "*" Then
                    condition = " where " & Field & " is not null " & AdditionalCondition
                Else
                    condition = " where " & Field & " = '" & Keyword & "' " & AdditionalCondition
                End If

            End If

        End If

        Dim daa As New SqlDataAdapter("select " & DisplayFields & " from " & TableName & condition, cn)

        daa.Fill(ds)

        cn.Close()
        Return ds
    End Function

    Public Function GenerateID(ByVal TableName As String, ByVal Field As String) As Integer
        Dim cn As New SqlConnection
        cn.ConnectionString = DalConnection_app.IOSConnectionString
        cn.Open()
        Dim ds As New DataSet

        Dim daa As New SqlDataAdapter("select Max(" & Field & ") as ExistingID from " & TableName, cn)
        daa.Fill(ds)

        Dim ID As Integer
        If ds.Tables(0).Rows.Count = 0 Then
            ID = 1
        Else
            If Not IsNumeric(ds.Tables(0).Rows(0)(0)) Then
                ID = 1
            Else
                ID = CInt(ds.Tables(0).Rows(0)(0)) + 1
            End If

        End If
        Return ID
        cn.Close()
    End Function

    Public Sub UpdateID(ByVal Field As String, ByVal NewID As Integer)

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim adapter As New SqlDataAdapter
        cn.ConnectionString = DalConnection_app.IOSConnectionString
        '' ''... reset testid if it exceed 8999
        ''If NewID >= 9000 Then
        ''    NewID = 1000
        ''End If

        cmd.CommandText = " UPDATE tblReference SET " & Field & "=" & NewID

        cmd.Connection = cn 'assign the connection

        'execute the command
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

    End Sub

    Public Sub UpdateValueInTable(ByVal TableName As String, ByVal UpdatingFieldNValue As String, ByVal Condition As String)

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim adapter As New SqlDataAdapter
        cn.ConnectionString = DalConnection_app.IOSConnectionString

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


    Public Function getBoundData(ByVal TableName As String, ByVal DisplayField As String, ByVal ValueField As String, ByVal NumberofRecords As Integer, ByVal Condition As String, ByVal SortOrder As String) As DataSet

        Dim ds As New DataSet
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim adapter As New SqlDataAdapter
        cn.ConnectionString = DalConnection_app.IOSConnectionString
        cn.Open()
        Dim RecordNumber As String
        If NumberofRecords = 0 Then
            RecordNumber = " "
        Else
            RecordNumber = "Top(" & NumberofRecords & ") "
        End If

        cmd.CommandText = "SELECT Distinct " & RecordNumber & DisplayField & ", " & ValueField & " FROM " & TableName & " " & Condition & " ORDER BY " & DisplayField & " " & SortOrder


        cmd.CommandType = CommandType.Text
        cmd.Connection = cn
        adapter.SelectCommand = cmd
        'fill the dataset
        adapter.Fill(ds)
        'Add blank record to the datatable
        Dim dr As DataRow
        dr = ds.Tables(0).NewRow
        dr(DisplayField) = ""
        dr(ValueField) = 0
        ds.Tables(0).Rows.InsertAt(dr, 0)

        'return the dataset
        Return ds
        cn.Close()
    End Function

    Public Function getBoundDataFlexibleSortField(ByVal TableName As String, ByVal DisplayField As String, ByVal ValueField As String, ByVal NumberofRecords As Integer, ByVal Condition As String, ByVal SortField As String, ByVal SortOrder As String) As DataSet

        Dim ds As New DataSet
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim adapter As New SqlDataAdapter
        cn.ConnectionString = DalConnection_app.IOSConnectionString
        cn.Open()
        Dim RecordNumber As String
        If NumberofRecords = 0 Then
            RecordNumber = " "
        Else
            RecordNumber = "Top(" & NumberofRecords & ") "
        End If

        cmd.CommandText = "SELECT Distinct " & RecordNumber & DisplayField & ", " & ValueField & ", " & SortField & " FROM " & TableName & " " & Condition & " ORDER BY " & SortField & " " & SortOrder


        cmd.CommandType = CommandType.Text
        cmd.Connection = cn
        adapter.SelectCommand = cmd
        'fill the dataset
        adapter.Fill(ds)
        'Add blank record to the datatable
        Dim dr As DataRow
        dr = ds.Tables(0).NewRow
        dr(DisplayField) = ""
        dr(ValueField) = 0
        ds.Tables(0).Rows.InsertAt(dr, 0)

        'return the dataset
        Return ds
        cn.Close()
    End Function

    Public Function getDataFromTable(ByVal TableName As String, ByVal DisplayFields As String, ByVal SortField As String, ByVal Condition As String, ByVal SortOrder As String) As DataSet

        Dim ds As New DataSet
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim adapter As New SqlDataAdapter
        cn.ConnectionString = DalConnection_app.IOSConnectionString
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

    Public Function UpdateRecordInTable(ByVal TableName As String, ByVal UpdatingFieldNValue As String, ByVal Condition As String) As Boolean

        Try

            Dim cn As New SqlConnection
            Dim cmd As New SqlCommand
            Dim adapter As New SqlDataAdapter
            cn.ConnectionString = DalConnection_app.IOSConnectionString

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
        Catch ex As Exception
            Return True
        End Try

        Return False
    End Function

    Public Function DeleteRecord(ByVal TableName As String, ByVal Condition As String) As Boolean

        Try


            Dim cn As New SqlConnection
            Dim cmd As New SqlCommand
            Dim adapter As New SqlDataAdapter
            cn.ConnectionString = DalConnection_app.IOSConnectionString
            cn.Open()
            cmd.CommandText = " DELETE FROM " & TableName & "  " & Condition
            cmd.Connection = cn 'assign the connection

            'execute the command

            cmd.ExecuteNonQuery()
            cn.Close()

        Catch ex As Exception
            Return True
        End Try
        Return False
    End Function

    Public Function ConvertStringToNumber(ByVal obj As Object) As String
        If Not IsNumeric(obj) Then
            Return 0
        Else
            Return obj
        End If
    End Function
    ''.. this function is for breaking a string into fragments based on a defined separator, and then put them into an array
    Public Function Cut_String_into_Array(ByVal MainString As String, ByVal Separator As String) As Array
        Dim StrArray(0) As String
        Dim ind As Integer
        Dim i As Integer = 1
        Dim j As Integer = 0
        Do While i = 1
            ind = InStr(MainString, Separator, CompareMethod.Text)
            ReDim Preserve StrArray(j)
            If ind = 0 Then
                StrArray(j) = MainString
                i = 0 ''.. to leave the loop
            Else
                StrArray(j) = MainString.Substring(0, ind - 1)
                MainString = MainString.Substring(ind, MainString.Length - ind)
            End If
            j = j + 1
        Loop

        Return StrArray
    End Function
    ''.. this function is to sort datatable based on the assinged columnkey and its sort order
    Public Function AlphabeticSort(ByVal dtTable As DataTable, ByVal columnkey As String, ByVal sortOrder As Integer) As DataTable
        Dim dsSorted As New DataSet
        Dim sortDirection As String = ""
        Dim sortFormat As String = "{0} {1}"
        Select Case sortOrder
            Case 0
                sortDirection = "ASC"
            Case 1
                sortDirection = "DESC"
            Case Else
                sortDirection = "ASC"
        End Select
        dtTable.DefaultView.Sort = String.Format(sortFormat, columnkey, sortDirection)
        Return dtTable.DefaultView.Table
    End Function

    Public Function InsertToTable(ByVal TableName As String, ByVal FieldsName As String, ByVal Values As String) As Integer

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim adapter As New SqlDataAdapter
        cn.ConnectionString = DalConnection_app.IOSConnectionString
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

    Public Sub DeleteFromTable(ByVal TableName As String, ByVal Condition As String)
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim adapter As New SqlDataAdapter
        cn.ConnectionString = DalConnection_app.IOSConnectionString
        cn.Open()
        cmd.CommandText = " DELETE FROM " & TableName & "  " & Condition
        cmd.Connection = cn 'assign the connection

        'execute the command

        cmd.ExecuteNonQuery()
        cn.Close()


    End Sub
    Public Function ValidPhone(ByVal PhoneNumber As String) As Boolean
        Try
            Dim dsPrefix As DataSet = getDataFromTable("tlkpEmailNPhone", "Prefix", "Prefix", "Where Type='Phone'", "ASC")


            Dim isValid As Boolean = False
            For i As Integer = 0 To dsPrefix.Tables(0).Rows.Count - 1
                Dim Suffix As String = dsPrefix.Tables(0).Rows(i)("Prefix")
                Dim LenString As Integer = Len(Suffix)
                If Left(PhoneNumber, LenString) = Suffix Then
                    If PhoneNumber.ToString.Length = 6 + 3 OrElse PhoneNumber.ToString.Length = 7 + 3 Then
                        isValid = True
                        Return isValid
                        Exit Function
                    End If
                End If
            Next

            Return isValid
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function ValidEmail(ByVal Email As String) As Boolean
        Try
            Dim dsSuffix As DataSet = getDataFromTable("tlkpEmailNPhone", "Suffix", "Suffix", "Where Type='Email'", "ASC")


            Dim isValid As Boolean = False
            For i As Integer = 0 To dsSuffix.Tables(0).Rows.Count - 1
                Dim Suffix As String = dsSuffix.Tables(0).Rows(i)("Suffix")
                Dim LenString As Integer = Len(Suffix)
                If Right(Email, LenString) = Suffix Then
                    If Email.ToString.Contains("@") = True Then
                        isValid = True
                        Return isValid
                        Exit Function
                    End If
                End If
            Next

            Return isValid
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function EnscriptSpam(ByVal Spam As String) As String
        Try
            Spam = Spam.Replace("a", "XXXkstXXX")
            Spam = Spam.Replace("u", "YYYmnsYYY")
            Spam = Spam.Replace("o", "||||||||||")
            Spam = Spam.Replace("i", "$$$$$$$$$$")
            Spam = Spam.Replace("e", "__________")
            Spam = Spam.Replace(".", "%%%%%Kg*****")

            Return Spam
        Catch ex As Exception
            Return ""
        End Try

    End Function

    Public Function DescriptSpam(ByVal Spam As String) As String
        Try
            Spam = Spam.Replace("XXXkstXXX", "a")
            Spam = Spam.Replace("YYYmnsYYY", "u")
            Spam = Spam.Replace("||||||||||", "o")
            Spam = Spam.Replace("$$$$$$$$$$", "i")
            Spam = Spam.Replace("__________", "e")
            Spam = Spam.Replace("%%%%%Kg*****", ".")
            Return Spam
        Catch ex As Exception
            Return ""
        End Try

    End Function


    Public Function SendEMailIDP(ByVal Subject As String, ByVal Body As String, ByVal RecipientEmail As String, _
                                 HasAttachment As Boolean, ByVal AttachmentPath As String, FileName As String, CC As Boolean) As Boolean



        Try

            Dim Smtp_Server As New SmtpClient

            Dim e_mail As New MailMessage()

            Smtp_Server.UseDefaultCredentials = False

            Smtp_Server.Credentials = New Net.NetworkCredential("annamaria.nugent@idp.com", "Welcome@1")

            Smtp_Server.Port = 25

            Smtp_Server.EnableSsl = False

            Smtp_Server.Host = "cluster8out.us.messagelabs.com"



            Smtp_Server.DeliveryMethod = SmtpDeliveryMethod.Network

            e_mail = New MailMessage()

            e_mail.From = New MailAddress("annamaria.nugent@idp.com")

            e_mail.To.Add(RecipientEmail)

            If CC = True Then
                e_mail.CC.Add("annamaria.nugent@idp.com")

                e_mail.CC.Add("janine.seng@idp.com")

            End If

            e_mail.Subject = Subject

            e_mail.IsBodyHtml = True

            e_mail.Body = Body

            If HasAttachment = True Then
                If System.IO.File.Exists(AttachmentPath & "\\" & FileName & ".pdf") = True Then
                    Dim attachFile As New Attachment(AttachmentPath & "\\" & FileName & ".pdf")
                    e_mail.Attachments.Add(attachFile)
                End If
            End If

            Smtp_Server.Send(e_mail)

            Return True



        Catch ex As Exception
            Return False


        End Try



    End Function
    Public Sub MySendEmail(ByVal Subject As String, ByVal Body As String, ByVal Recipient As String, ByVal AttachmentPath As String)
        ''Dim mail As MailMessage = New MailMessage()
        ''mail.To.Add(Recipient)
        ''mail.From = New MailAddress("ace.notification@gmail.com")
        ''mail.Subject = Subject
        ''mail.Body = Body
        ''If AttachmentPath <> "" Then
        ''    Dim att As New Attachment(AttachmentPath)
        ''    mail.Attachments.Add(att)
        ''End If

        ''mail.IsBodyHtml = True
        ''Dim smtp As SmtpClient = New SmtpClient()
        ''smtp.Host = "smtp.gmail.com"
        ''smtp.Credentials = New System.Net.NetworkCredential("ace.notification@gmail.com", "pass$1234")
        ''smtp.EnableSsl = True
        ''smtp.Port = 587
        ''smtp.EnableSsl = True
        ''smtp.Send(mail)



        Dim mail As MailMessage = New MailMessage()
        Dim cc As New MailAddress("sopheak.nuon@acecambodia.org")
        Dim cc1 As New MailAddress("chanpheakdey.vong@acecambodia.org")
        mail.To.Add(Recipient)
        mail.From = New MailAddress("ace.edb@acecambodia.org")
        mail.CC.Add(cc)
        'mail.CC.Add("sopheak.nuon@acecambodia.org")
        mail.CC.Add(cc1)
        mail.Subject = Subject
        mail.Body = Body
        mail.IsBodyHtml = True
        Dim smtp As SmtpClient = New SmtpClient()
        'smtp.Host = "203.217.170.20"
        smtp.Host = "192.168.0.253"
        smtp.Credentials = New System.Net.NetworkCredential("ace.edb@acecambodia.org", "pass$1234")
        smtp.EnableSsl = False
        smtp.Port = 25
        ''smtp.EnableSsl = True
        smtp.Send(mail)



        ''Dim mail As MailMessage = New MailMessage()
        ''mail.To.Add(Recipient)
        ''mail.From = New MailAddress("sothea.korng@acecambodia.org")
        ''mail.Subject = Subject
        ''mail.Body = Body
        ''mail.IsBodyHtml = True
        ''Dim smtp As SmtpClient = New SmtpClient()
        ''smtp.Host = "192.168.0.253"
        ''smtp.Credentials = New System.Net.NetworkCredential("sothea.korng@acecambodia.org", "pass$1234")
        ''smtp.EnableSsl = True
        ''smtp.Port = 25
        ''smtp.EnableSsl = True
        ''smtp.Send(mail)
    End Sub



    Public Sub RemoveSubMenu(ByVal TargetMenu As Menu, ByVal MainMenu As String, ByVal SubMenu As String)
        Dim valuePath1 As String = MainMenu
        Dim musicMenuItem As MenuItem = TargetMenu.FindItem(valuePath1)
        If musicMenuItem IsNot Nothing Then
            Dim valuePath2 As String = SubMenu
            Dim item As MenuItem = TargetMenu.FindItem(valuePath2)
            If item IsNot Nothing Then
                musicMenuItem.ChildItems.Remove(item)
            End If
        End If
    End Sub

    Public Function DefaultPass(ByVal input As String) As String

        Dim TempPassword As String
        Dim CurrentMinute As String = Minute(Now())
        Dim CurrentHour As String = Hour(Now())
        TempPassword = LCase(Left(input, 1) & Right(input, 1) & CurrentMinute & Left(input, 2) & "." & CurrentHour)

        Return TempPassword


    End Function

#Region "Get DateTime from sql server"
    ''' <summary>
    ''' Get Current date and time from server
    ''' </summary>
    ''' <param name="sqlTran"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetCurrentDate(ByVal sqlTran As SqlTransaction) As DateTime
        Dim datReturn As New DateTime()
        Dim sqlConn As New SqlConnection
        Try
            Dim strSQL As String = "SELECT GETDATE()" & vbCr
            sqlConn.ConnectionString = DalConnection_app.IOSConnectionString
            Dim sqlcom As SqlCommand = sqlConn.CreateCommand()
            sqlcom.CommandText = strSQL
            sqlcom.Transaction = sqlTran
            Dim obj As Object = sqlcom.ExecuteScalar()
            If obj IsNot Nothing AndAlso Not IsDBNull(obj) Then
                datReturn = DateTime.Parse(obj.ToString())
            End If
        Catch exp As Exception
            Return Now()
        End Try
        Return datReturn
    End Function

    Public Function GetIPAddress() As String
        Dim context As System.Web.HttpContext =
            System.Web.HttpContext.Current
        Dim sIPAddress As String =
            context.Request.ServerVariables("HTTP_X_FORWARDED_FOR")
        If String.IsNullOrEmpty(sIPAddress) Then
            Return context.Request.ServerVariables("REMOTE_ADDR")
        Else
            Dim ipArray As String() = sIPAddress.Split(
                New [Char]() {","c})
            Return ipArray(0)
        End If
    End Function

#End Region

End Class
