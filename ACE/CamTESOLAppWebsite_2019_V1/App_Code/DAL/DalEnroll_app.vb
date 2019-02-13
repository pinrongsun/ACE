Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Reflection

Public Class DalEnroll_app
    Private Shared EnrollInstance As DalEnroll_app

    Public Shared ReadOnly Property Instance As DalEnroll_app
        Get
            If EnrollInstance Is Nothing Then
                EnrollInstance = New DalEnroll_app
            End If
            Return EnrollInstance
        End Get
    End Property

    Public Sub AddEnroll(ByVal Enroll As ClEnroll_app)
        Dim AllField As String = ""
        Dim AllValue As String = ""

        AllField = AllField & "NoClass, "
        AllValue = AllValue & "@NoClass, "

        AllField = AllField & "Deleted, "
        AllValue = AllValue & "@Deleted, "

        AllField = AllField & "EnrollID, "
        AllValue = AllValue & "@EnrollID, "

        AllField = AllField & "ContactID, "
        AllValue = AllValue & "@ContactID, "

        AllField = AllField & "StudentName, "
        AllValue = AllValue & "@StudentName, "

        AllField = AllField & "Term, "
        AllValue = AllValue & "@Term, "

        AllField = AllField & "TermID, "
        AllValue = AllValue & "@TermID, "

        AllField = AllField & "Program, "
        AllValue = AllValue & "@Program, "

        AllField = AllField & "CourseID, "
        AllValue = AllValue & "@CourseID, "

        AllField = AllField & "CourseName, "
        AllValue = AllValue & "@CourseName, "

        AllField = AllField & "ClassID, "
        AllValue = AllValue & "@ClassID, "

        AllField = AllField & "ClassDays, "
        AllValue = AllValue & "@ClassDays, "

        AllField = AllField & "ClassDaysID, "
        AllValue = AllValue & "@ClassDaysID, "

        AllField = AllField & "ClassTime, "
        AllValue = AllValue & "@ClassTime, "

        AllField = AllField & "StaffName, "
        AllValue = AllValue & "@StaffName, "

        AllField = AllField & "SecondStaffName, "
        AllValue = AllValue & "@SecondStaffName, "

        AllField = AllField & "Room, "
        AllValue = AllValue & "@Room, "

        AllField = AllField & "CourseCost, "
        AllValue = AllValue & "@CourseCost, "

        AllField = AllField & "Credit, "
        AllValue = AllValue & "@Credit, "

        AllField = AllField & "Discount, "
        AllValue = AllValue & "@Discount, "

        AllField = AllField & "Total, "
        AllValue = AllValue & "@Total, "

        AllField = AllField & "Sponsored, "
        AllValue = AllValue & "@Sponsored, "

        AllField = AllField & "StaffSponsor, "
        AllValue = AllValue & "@StaffSponsor, "

        AllField = AllField & "SponsorID, "
        AllValue = AllValue & "@SponsorID, "

        AllField = AllField & "SponsorName, "
        AllValue = AllValue & "@SponsorName, "

        AllField = AllField & "FlipFlop, "
        AllValue = AllValue & "@FlipFlop, "

        AllField = AllField & "BookPurchased, "
        AllValue = AllValue & "@BookPurchased, "

        AllField = AllField & "BookCost, "
        AllValue = AllValue & "@BookCost, "

        AllField = AllField & "WorkBookPurchased, "
        AllValue = AllValue & "@WorkBookPurchased, "

        AllField = AllField & "WorkBookCost, "
        AllValue = AllValue & "@WorkBookCost, "

        AllField = AllField & "CDPurchased, "
        AllValue = AllValue & "@CDPurchased, "

        AllField = AllField & "CDCost, "
        AllValue = AllValue & "@CDCost, "

        AllField = AllField & "CreatedDate, "
        AllValue = AllValue & "@CreatedDate, "

        AllField = AllField & "CreatedBy"
        AllValue = AllValue & "@CreatedBy"



        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim adapter As New SqlDataAdapter
        cn.ConnectionString = DalConnection_app.IOSConnectionString

        cmd.CommandText = " Insert into tblEnroll(" & AllField & ") Values (" & AllValue & "); "
        cmd.Connection = cn 'assign the connection

        'add the parameters
        With Enroll
            cmd.Parameters.Add("@NoClass", SqlDbType.Bit).Value = .NoClass
            cmd.Parameters.Add("@Deleted", SqlDbType.Bit).Value = .Deleted
            cmd.Parameters.Add("@EnrollID", SqlDbType.Char).Value = .EnrollID
            cmd.Parameters.Add("@ContactID", SqlDbType.Int).Value = .ContactID
            cmd.Parameters.Add("@StudentName", SqlDbType.Char).Value = .StudentName
            cmd.Parameters.Add("@Term", SqlDbType.Char).Value = .Term
            cmd.Parameters.Add("@TermID", SqlDbType.Int).Value = .TermID
            cmd.Parameters.Add("@Program", SqlDbType.Char).Value = .Program
            cmd.Parameters.Add("@CourseID", SqlDbType.Int).Value = .CourseID
            cmd.Parameters.Add("@CourseName", SqlDbType.Char).Value = .CourseName
            cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = .ClassID
            cmd.Parameters.Add("@ClassDays", SqlDbType.Char).Value = .ClassDays
            cmd.Parameters.Add("@ClassDaysID", SqlDbType.Int).Value = .ClassDaysID
            cmd.Parameters.Add("@ClassTime", SqlDbType.Char).Value = .ClassTime
            cmd.Parameters.Add("@StaffName", SqlDbType.Char).Value = .StaffName
            cmd.Parameters.Add("@SecondStaffName", SqlDbType.Char).Value = .SecondStaffName
            cmd.Parameters.Add("@Room", SqlDbType.Char).Value = .Room
            cmd.Parameters.Add("@CourseCost", SqlDbType.Money).Value = .CourseCost
            cmd.Parameters.Add("@Credit", SqlDbType.Money).Value = .Credit
            cmd.Parameters.Add("@Discount", SqlDbType.Money).Value = .Discount
            cmd.Parameters.Add("@Total", SqlDbType.Money).Value = .Total
            cmd.Parameters.Add("@Sponsored", SqlDbType.Char).Value = .Sponsored
            cmd.Parameters.Add("@StaffSponsor", SqlDbType.Bit).Value = .StaffSponsor
            cmd.Parameters.Add("@SponsorID", SqlDbType.Int).Value = .SponsorID
            cmd.Parameters.Add("@SponsorName", SqlDbType.Char).Value = .SponsorName
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = .CreatedDate
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Char).Value = .CreatedBy
            cmd.Parameters.Add("@FlipFlop", SqlDbType.Bit).Value = .FlipFlop
            cmd.Parameters.Add("@BookPurchased", SqlDbType.Bit).Value = .BookPurchased
            cmd.Parameters.Add("@BookCost", SqlDbType.Float).Value = .BookCost
            cmd.Parameters.Add("@WorkBookPurchased", SqlDbType.Bit).Value = .WorkBookPurchased
            cmd.Parameters.Add("@WorkBookCost", SqlDbType.Float).Value = .WorkBookCost
            cmd.Parameters.Add("@CDPurchased", SqlDbType.Bit).Value = .CDPurchased
            cmd.Parameters.Add("@CDCost", SqlDbType.Float).Value = .CDCost


        End With

        'execute the command
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

    End Sub

    Public Function GetEnroll(ByVal Enroll As ClEnroll_app) As DataSet
        Dim ds As DataSet = DalGlobal_app.Instance.getDataFromTable("tblEnroll", "*", "EnrollID", "Where EnrollID='" & Enroll.EnrollID & "'", "asc")
        Return ds
    End Function

    Public Sub DeleteEnroll(ByVal Enroll As ClEnroll_app)
        ' find the classid

        DalGlobal_app.Instance.DeleteFromTable("tblEnroll", "Where EnrollID=" & Enroll.EnrollID)

    End Sub

    Public Sub UpdateEnroll(ByVal Enroll As ClEnroll_app)
        Dim AllFieldNValue As String = ""

        AllFieldNValue = AllFieldNValue & "EnrollID=@EnrollID, "
        AllFieldNValue = AllFieldNValue & "NoClass=@NoClass, "
        AllFieldNValue = AllFieldNValue & "Deleted=@Deleted, "
        AllFieldNValue = AllFieldNValue & "ContactID=@ContactID, "
        AllFieldNValue = AllFieldNValue & "StudentName=@StudentName, "
        AllFieldNValue = AllFieldNValue & "Term=@Term, "
        AllFieldNValue = AllFieldNValue & "TermID=@TermID, "
        AllFieldNValue = AllFieldNValue & "Program=@Program, "
        AllFieldNValue = AllFieldNValue & "CourseID=@CourseID, "
        AllFieldNValue = AllFieldNValue & "CourseName=@CourseName, "
        AllFieldNValue = AllFieldNValue & "ClassID=@ClassID, "
        AllFieldNValue = AllFieldNValue & "Room=@Room, "
        AllFieldNValue = AllFieldNValue & "Sponsored=@Sponsored, "
        AllFieldNValue = AllFieldNValue & "StaffSponsor=@StaffSponsor, "
        AllFieldNValue = AllFieldNValue & "SponsorID=@SponsorID, "
        AllFieldNValue = AllFieldNValue & "SponsorName=@SponsorName, "
        AllFieldNValue = AllFieldNValue & "CourseCost=@CourseCost, "
        AllFieldNValue = AllFieldNValue & "Credit=@Credit, "
        AllFieldNValue = AllFieldNValue & "Discount=@Discount, "
        AllFieldNValue = AllFieldNValue & "Total=@Total, "
        AllFieldNValue = AllFieldNValue & "CreatedDate=@CreatedDate, "
        AllFieldNValue = AllFieldNValue & "CreatedBy=@CreatedBy, "
        AllFieldNValue = AllFieldNValue & "ClassDays=@ClassDays, "
        AllFieldNValue = AllFieldNValue & "ClassDaysID=@ClassDaysID, "
        AllFieldNValue = AllFieldNValue & "ClassTime=@ClassTime, "
        AllFieldNValue = AllFieldNValue & "StaffName=@StaffName, "
        AllFieldNValue = AllFieldNValue & "FlipFlop=@FlipFlop, "
        AllFieldNValue = AllFieldNValue & "BookPurchased=@BookPurchased, "
        AllFieldNValue = AllFieldNValue & "BookCost=@BookCost, "
        AllFieldNValue = AllFieldNValue & "WorkBookPurchased=@WorkBookPurchased, "
        AllFieldNValue = AllFieldNValue & "WorkBookCost=@WorkBookCost, "
        AllFieldNValue = AllFieldNValue & "CDPurchased=@CDPurchased, "
        AllFieldNValue = AllFieldNValue & "CDCost=@CDCost, "
        AllFieldNValue = AllFieldNValue & "SecondStaffName=@SecondStaffName "

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim adapter As New SqlDataAdapter
        cn.ConnectionString = DalConnection_app.IOSConnectionString

        cmd.CommandText = " UPDATE tblEnroll SET " & AllFieldNValue & " Where ClassID=" & Enroll.ClassID
        cmd.Connection = cn 'assign the connection

        'add the parameters
        With Enroll
            cmd.Parameters.Add("@NoClass", SqlDbType.Bit).Value = .NoClass
            cmd.Parameters.Add("@Deleted", SqlDbType.Bit).Value = .Deleted
            cmd.Parameters.Add("@EnrollID", SqlDbType.Char).Value = .EnrollID
            cmd.Parameters.Add("@ContactID", SqlDbType.Int).Value = .ContactID
            cmd.Parameters.Add("@StudentName", SqlDbType.Char).Value = .StudentName
            cmd.Parameters.Add("@Term", SqlDbType.Char).Value = .Term
            cmd.Parameters.Add("@TermID", SqlDbType.Int).Value = .TermID
            cmd.Parameters.Add("@Program", SqlDbType.Char).Value = .Program
            cmd.Parameters.Add("@CourseID", SqlDbType.Int).Value = .CourseID
            cmd.Parameters.Add("@CourseName", SqlDbType.Char).Value = .CourseName
            cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = .ClassID
            cmd.Parameters.Add("@ClassDays", SqlDbType.Char).Value = .ClassDays
            cmd.Parameters.Add("@ClassDaysID", SqlDbType.Int).Value = .ClassDaysID
            cmd.Parameters.Add("@ClassTime", SqlDbType.Char).Value = .ClassTime
            cmd.Parameters.Add("@StaffName", SqlDbType.Char).Value = .StaffName
            cmd.Parameters.Add("@SecondStaffName", SqlDbType.Char).Value = .SecondStaffName
            cmd.Parameters.Add("@Room", SqlDbType.Char).Value = .Room
            cmd.Parameters.Add("@CourseCost", SqlDbType.Money).Value = .CourseCost
            cmd.Parameters.Add("@Credit", SqlDbType.Money).Value = .Credit
            cmd.Parameters.Add("@Discount", SqlDbType.Money).Value = .Discount
            cmd.Parameters.Add("@Total", SqlDbType.Money).Value = .Total
            cmd.Parameters.Add("@Sponsored", SqlDbType.Char).Value = .Sponsored
            cmd.Parameters.Add("@StaffSponsor", SqlDbType.Bit).Value = .StaffSponsor
            cmd.Parameters.Add("@SponsorID", SqlDbType.Int).Value = .SponsorID
            cmd.Parameters.Add("@SponsorName", SqlDbType.Char).Value = .SponsorName
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = .CreatedDate
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Char).Value = .CreatedBy
            cmd.Parameters.Add("@FlipFlop", SqlDbType.Bit).Value = .FlipFlop
            cmd.Parameters.Add("@BookPurchased", SqlDbType.Bit).Value = .BookPurchased
            cmd.Parameters.Add("@BookCost", SqlDbType.Float).Value = .BookCost
            cmd.Parameters.Add("@WorkBookPurchased", SqlDbType.Bit).Value = .WorkBookPurchased
            cmd.Parameters.Add("@WorkBookCost", SqlDbType.Float).Value = .WorkBookCost
            cmd.Parameters.Add("@CDPurchased", SqlDbType.Bit).Value = .CDPurchased
            cmd.Parameters.Add("@CDCost", SqlDbType.Float).Value = .CDCost

        End With

        'execute the command
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()


    End Sub





End Class
