Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Reflection

Public Class DalDays_app
    Private Shared DaysInstance As DalDays_app

    Public Shared ReadOnly Property Instance As DalDays_app
        Get
            If DaysInstance Is Nothing Then
                DaysInstance = New DalDays_app
            End If
            Return DaysInstance
        End Get
    End Property

    Public Sub AddDays(ByVal Days As ClDays_app)
        Dim AllField As String = ""
        Dim AllValue As String = ""

        AllField = AllField & "DaysID, "
        AllValue = AllValue & "@DaysID, "

        AllField = AllField & "DaysBin, "
        AllValue = AllValue & "@DaysBin, "

        AllField = AllField & "Days, "
        AllValue = AllValue & "@Days, "

        AllField = AllField & "DaysShort, "
        AllValue = AllValue & "@DaysShort, "

        AllField = AllField & "DaysLong, "
        AllValue = AllValue & "@DaysLong, "

        AllField = AllField & "DaysCount, "
        AllValue = AllValue & "@DaysCount, "

        AllField = AllField & "DayPerc, "
        AllValue = AllValue & "@DayPerc, "

        AllField = AllField & "StartDate, "
        AllValue = AllValue & "@StartDate, "

        AllField = AllField & "EndStart"
        AllValue = AllValue & "@EndStart"


        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim adapter As New SqlDataAdapter
        cn.ConnectionString = DalConnection_app.IOSConnectionString

        cmd.CommandText = " Insert into tblDays(" & AllField & ") Values (" & AllValue & "); "
        cmd.Connection = cn 'assign the connection

        'add the parameters
        With Days
            cmd.Parameters.Add("@DaysID", SqlDbType.Int).Value = .DaysID
            cmd.Parameters.Add("@DaysBin", SqlDbType.Int).Value = .DaysBin
            cmd.Parameters.Add("@Days", SqlDbType.Char).Value = .Days

            cmd.Parameters.Add("@DaysShort", SqlDbType.Char).Value = .DaysShort
            cmd.Parameters.Add("@DaysLong", SqlDbType.Char).Value = .DaysLong
            cmd.Parameters.Add("@DaysCount", SqlDbType.Int).Value = .DaysCount
            cmd.Parameters.Add("@DayPerc", SqlDbType.Int).Value = .DayPerc
            cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = .StartDate
            cmd.Parameters.Add("@EndStart", SqlDbType.Date).Value = .EndStart


        End With

        'execute the command
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()



    End Sub

    Public Function GetDays(ByVal Days As ClDays_app) As DataSet
        Dim ds As DataSet = DalGlobal_app.Instance.getDataFromTable("tblDays", "*", "DaysID", "Where DaysID=" & Days.DaysID, "asc")
        Return ds
    End Function

    Public Sub DeleteDays(ByVal Days As ClDays_app)
        ' find the classid

        DalGlobal_app.Instance.DeleteFromTable("tblDays", "Where DaysID=" & Days.DaysID)

    End Sub

    Public Sub UpdateDays(ByVal Days As ClDays_app)
        Dim AllFieldNValue As String = ""

        AllFieldNValue = AllFieldNValue & "DaysID=@DaysID, "

        AllFieldNValue = AllFieldNValue & "DaysBin=@DaysBin, "

        AllFieldNValue = AllFieldNValue & "Days=@Days, "

        AllFieldNValue = AllFieldNValue & "DaysShort=@DaysShort, "

        AllFieldNValue = AllFieldNValue & "DaysLong=@DaysLong, "

        AllFieldNValue = AllFieldNValue & "DaysCount=@DaysCount, "

        AllFieldNValue = AllFieldNValue & "DayPerc=@DayPerc, "

        AllFieldNValue = AllFieldNValue & "StartDate=@StartDate, "

        AllFieldNValue = AllFieldNValue & "EndStart=@EndStart "


        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim adapter As New SqlDataAdapter
        cn.ConnectionString = DalConnection_app.IOSConnectionString

        cmd.CommandText = " UPDATE tblDays SET " & AllFieldNValue & " Where DaysID=" & Days.DaysID
        cmd.Connection = cn 'assign the connection

        'add the parameters
        With Days
            cmd.Parameters.Add("@DaysID", SqlDbType.Int).Value = .DaysID
            cmd.Parameters.Add("@DaysBin", SqlDbType.Int).Value = .DaysBin
            cmd.Parameters.Add("@Days", SqlDbType.Char).Value = .Days

            cmd.Parameters.Add("@DaysShort", SqlDbType.Char).Value = .DaysShort
            cmd.Parameters.Add("@DaysLong", SqlDbType.Char).Value = .DaysLong
            cmd.Parameters.Add("@DaysCount", SqlDbType.Int).Value = .DaysCount
            cmd.Parameters.Add("@DayPerc", SqlDbType.Int).Value = .DayPerc
            cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = .StartDate
            cmd.Parameters.Add("@EndStart", SqlDbType.Date).Value = .EndStart


        End With

        'execute the command
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()




    End Sub

End Class
