Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Reflection

Public Class DalEnrollLog_app
    Private Shared EnrollLogInstance As DalEnrollLog_app

    Public Shared ReadOnly Property Instance As DalEnrollLog_app
        Get
            If EnrollLogInstance Is Nothing Then
                EnrollLogInstance = New DalEnrollLog_app
            End If
            Return EnrollLogInstance
        End Get
    End Property

    Public Sub AddEnrollLog(ByVal EnrollLog As ClEnrollLog_app)
        Dim AllField As String = ""
        Dim AllValue As String = ""

        AllField = AllField & "User, "
        AllValue = AllValue & "@User, "

        AllField = AllField & "StudentID, "
        AllValue = AllValue & "@StudentID, "

        AllField = AllField & "ReceiptNo, "
        AllValue = AllValue & "@ReceiptNo, "

        AllField = AllField & "Action, "
        AllValue = AllValue & "@Action, "

        AllField = AllField & "DateStr "
        AllValue = AllValue & "@DateStr "


        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim adapter As New SqlDataAdapter
        cn.ConnectionString = DalConnection_app.IOSConnectionString

        cmd.CommandText = " Insert into tblEnrollLog(" & AllField & ") Values (" & AllValue & "); "
        cmd.Connection = cn 'assign the connection

        'add the parameters
        With EnrollLog
            cmd.Parameters.Add("@User", SqlDbType.Char).Value = .User
            cmd.Parameters.Add("@StudentID", SqlDbType.Int).Value = .StudentID
            cmd.Parameters.Add("@ReceiptNo", SqlDbType.Int).Value = .ReceiptNo
            cmd.Parameters.Add("@Action", SqlDbType.Char).Value = .Action
            cmd.Parameters.Add("@DateStr", SqlDbType.Date).Value = .DateStr
        End With

        'execute the command
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()


    End Sub

    Public Function GetEnrollLog(ByVal EnrollLog As ClEnrollLog_app) As DataSet
        Dim ds As DataSet = DalGlobal_app.Instance.getDataFromTable("tblEnrollLog", "*", "EnrollLogID", "Where User=" & EnrollLog.User, "asc")
        Return ds
    End Function

    Public Sub DeleteEnrollLog(ByVal EnrollLog As ClEnrollLog_app)
        ' find the classid

        DalGlobal_app.Instance.DeleteFromTable("tblEnrollLog", "Where User=" & EnrollLog.User)

    End Sub

    Public Sub UpdateEnrollLog(ByVal EnrollLog As ClEnrollLog_app)
        Dim AllFieldNValue As String = ""

        AllFieldNValue = AllFieldNValue & "User=@User, "

        AllFieldNValue = AllFieldNValue & "StudentID=@StudentID, "

        AllFieldNValue = AllFieldNValue & "ReceiptNo=@ReceiptNo, "

        AllFieldNValue = AllFieldNValue & "Action=@Action, "

        AllFieldNValue = AllFieldNValue & "DateStr=@DateStr "

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim adapter As New SqlDataAdapter
        cn.ConnectionString = DalConnection_app.IOSConnectionString

        cmd.CommandText = " UPDATE tblEnrollLog SET " & AllFieldNValue & " Where User=" & EnrollLog.User
        cmd.Connection = cn 'assign the connection

        'add the parameters
        With EnrollLog
            cmd.Parameters.Add("@User", SqlDbType.Char).Value = .User
            cmd.Parameters.Add("@StudentID", SqlDbType.Int).Value = .StudentID
            cmd.Parameters.Add("@ReceiptNo", SqlDbType.Int).Value = .ReceiptNo
            cmd.Parameters.Add("@Action", SqlDbType.Char).Value = .Action
            cmd.Parameters.Add("@DateStr", SqlDbType.Date).Value = .DateStr

        End With

        'execute the command
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()




    End Sub

End Class
