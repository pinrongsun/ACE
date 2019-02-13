Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Reflection

Public Class DalCreditLog_app
    Private Shared CreditLogInstance As DalCreditLog_app

    Public Shared ReadOnly Property Instance As DalCreditLog_app
        Get
            If CreditLogInstance Is Nothing Then
                CreditLogInstance = New DalCreditLog_app
            End If
            Return CreditLogInstance
        End Get
    End Property

    Public Sub AddCreditLog(ByVal CreditLog As ClCreditLog_app)
        Dim AllField As String = ""
        Dim AllValue As String = ""

        AllField = AllField & "LogID, "
        AllValue = AllValue & "@LogID, "

        AllField = AllField & "Deleted, "
        AllValue = AllValue & "@Deleted, "

        AllField = AllField & "CreditReceiptNo, "
        AllValue = AllValue & "@CreditReceiptNo, "

        AllField = AllField & "WithdrawReceiptNo, "
        AllValue = AllValue & "@WithdrawReceiptNo, "

        AllField = AllField & "ContactID, "
        AllValue = AllValue & "@ContactID, "

        AllField = AllField & "Action, "
        AllValue = AllValue & "@Action, "

        AllField = AllField & "ReceiptNo, "
        AllValue = AllValue & "@ReceiptNo, "

        AllField = AllField & "InitialCredit, "
        AllValue = AllValue & "@InitialCredit, "

        AllField = AllField & "Amount,"
        AllValue = AllValue & "@Amount,"

        AllField = AllField & "Term,"
        AllValue = AllValue & "@Term,"

        AllField = AllField & "Notes,"
        AllValue = AllValue & "@Notes,"

        AllField = AllField & "CreatedDate,"
        AllValue = AllValue & "@CreatedDate,"

        AllField = AllField & "CreatedBy,"
        AllValue = AllValue & "@CreatedBy,"

        AllField = AllField & "RunOut"
        AllValue = AllValue & "@RunOut"


        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim adapter As New SqlDataAdapter
        cn.ConnectionString = DalConnection_app.IOSConnectionString

        cmd.CommandText = " Insert into tblCreditLog(" & AllField & ") Values (" & AllValue & "); "
        cmd.Connection = cn 'assign the connection

        'add the parameters
        With CreditLog
            cmd.Parameters.Add("@LogID", SqlDbType.Int).Value = .LogID
            cmd.Parameters.Add("@Deleted", SqlDbType.Bit).Value = .Deleted
            cmd.Parameters.Add("@CreditReceiptNo", SqlDbType.Char).Value = .CreditReceiptNo
            cmd.Parameters.Add("@WithdrawReceiptNo", SqlDbType.Char).Value = .WithdrawReceiptNo
            cmd.Parameters.Add("@ContactID", SqlDbType.Int).Value = .ContactID
            cmd.Parameters.Add("@Action", SqlDbType.Char).Value = .Action
            cmd.Parameters.Add("@ReceiptNo", SqlDbType.Char).Value = .ReceiptNo
            cmd.Parameters.Add("@InitialCredit", SqlDbType.Float).Value = .InitialCredit
            cmd.Parameters.Add("@Amount", SqlDbType.Float).Value = .Amount
            cmd.Parameters.Add("@Term", SqlDbType.Char).Value = .Term
            cmd.Parameters.Add("@Notes", SqlDbType.Char).Value = .Notes
            cmd.Parameters.Add("@CreatedDate", SqlDbType.Date).Value = .CreatedDate
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Char).Value = .CreatedBy
            cmd.Parameters.Add("@RunOut", SqlDbType.Bit).Value = .RunOut

        End With

        'execute the command
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()



    End Sub

    Public Function GetCreditLog(ByVal CreditLog As ClCreditLog_app) As DataSet
        Dim ds As DataSet = DalGlobal_app.Instance.getDataFromTable("tblCreditLog", "*", "CreditLogID", "Where LogID=" & CreditLog.LogID, "asc")
        Return ds
    End Function

    Public Sub DeleteCreditLog(ByVal CreditLog As ClCreditLog_app)
        ' find the classid

        DalGlobal_app.Instance.DeleteFromTable("tblCreditLog", "Where LogID=" & CreditLog.LogID)

    End Sub

    Public Sub UpdateCreditLog(ByVal CreditLog As ClCreditLog_app)

        Dim AllFieldNValue As String = ""

        AllFieldNValue = AllFieldNValue & "LogID=@LogID, "
        AllFieldNValue = AllFieldNValue & "Deleted=@Deleted, "
        AllFieldNValue = AllFieldNValue & "CreditReceiptNo=@CreditReceiptNo, "
        AllFieldNValue = AllFieldNValue & "WithdrawReceiptNo=@WithdrawReceiptNo, "
        AllFieldNValue = AllFieldNValue & "ContactID=@ContactID, "
        AllFieldNValue = AllFieldNValue & "Action=@Action, "
        AllFieldNValue = AllFieldNValue & "ReceiptNo=@ReceiptNo, "
        AllFieldNValue = AllFieldNValue & "InitialCredit=@InitialCredit, "
        AllFieldNValue = AllFieldNValue & "Amount=@Amount, "
        AllFieldNValue = AllFieldNValue & "Term=@Term, "
        AllFieldNValue = AllFieldNValue & "Notes=@Notes, "
        AllFieldNValue = AllFieldNValue & "CreatedDate=@CreatedDate, "
        AllFieldNValue = AllFieldNValue & "CreatedBy=@CreatedBy, "
        AllFieldNValue = AllFieldNValue & "RunOut=@RunOut "

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim adapter As New SqlDataAdapter
        cn.ConnectionString = DalConnection_app.IOSConnectionString

        cmd.CommandText = " UPDATE tblCreditLog SET " & AllFieldNValue & " Where LogID=" & CreditLog.LogID
        cmd.Connection = cn 'assign the connection

        'add the parameters
        With CreditLog
            cmd.Parameters.Add("@LogID", SqlDbType.Int).Value = .LogID
            cmd.Parameters.Add("@Deleted", SqlDbType.Bit).Value = .Deleted
            cmd.Parameters.Add("@CreditReceiptNo", SqlDbType.Char).Value = .CreditReceiptNo
            cmd.Parameters.Add("@WithdrawReceiptNo", SqlDbType.Char).Value = .WithdrawReceiptNo
            cmd.Parameters.Add("@ContactID", SqlDbType.Int).Value = .ContactID
            cmd.Parameters.Add("@Action", SqlDbType.Char).Value = .Action
            cmd.Parameters.Add("@ReceiptNo", SqlDbType.Char).Value = .ReceiptNo
            cmd.Parameters.Add("@InitialCredit", SqlDbType.Float).Value = .InitialCredit
            cmd.Parameters.Add("@Amount", SqlDbType.Float).Value = .Amount
            cmd.Parameters.Add("@Term", SqlDbType.Char).Value = .Term
            cmd.Parameters.Add("@Notes", SqlDbType.Char).Value = .Notes
            cmd.Parameters.Add("@CreatedDate", SqlDbType.Date).Value = .CreatedDate
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Char).Value = .CreatedBy
            cmd.Parameters.Add("@RunOut", SqlDbType.Bit).Value = .RunOut

        End With

        'execute the command
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()


    End Sub

End Class
