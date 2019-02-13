Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Reflection

Public Class DalClasses_app
    Private Shared ClassesInstance As DalClasses_app

    Public Shared ReadOnly Property Instance As DalClasses_app
        Get
            If ClassesInstance Is Nothing Then
                ClassesInstance = New DalClasses_app
            End If
            Return ClassesInstance
        End Get
    End Property

    Public Sub AddClasses(ByVal Classes As ClClasses_app)

        Dim AllField As String = ""
        Dim AllValue As String = ""

        AllField = AllField & "ClassID, "
        AllValue = AllValue & "@ClassID, "

        AllField = AllField & "Deleted, "
        AllValue = AllValue & "@Deleted, "

        AllField = AllField & "CourseName, "
        AllValue = AllValue & "@CourseName, "

        AllField = AllField & "CourseBook, "
        AllValue = AllValue & "@CourseBook, "

        AllField = AllField & "ProgramID, "
        AllValue = AllValue & "@ProgramID, "

        AllField = AllField & "Program, "
        AllValue = AllValue & "@Program, "

        AllField = AllField & "CourseID, "
        AllValue = AllValue & "@CourseID, "

        AllField = AllField & "SeqNo, "
        AllValue = AllValue & "@SeqNo, "

        AllField = AllField & "TermID, "
        AllValue = AllValue & "@TermID, "

        AllField = AllField & "Term, "
        AllValue = AllValue & "@Term, "

        AllField = AllField & "ClassDaysID, "
        AllValue = AllValue & "@ClassDaysID, "

        AllField = AllField & "ClassDays, "
        AllValue = AllValue & "@ClassDays, "

        AllField = AllField & "DayCount, "
        AllValue = AllValue & "@DayCount, "

        AllField = AllField & "DaysMask, "
        AllValue = AllValue & "@DaysMask, "

        AllField = AllField & "TimeID, "
        AllValue = AllValue & "@TimeID, "

        AllField = AllField & "Time, "
        AllValue = AllValue & "@Time, "

        AllField = AllField & "RoomID, "
        AllValue = AllValue & "@RoomID, "

        AllField = AllField & "Room, "
        AllValue = AllValue & "@Room, "

        AllField = AllField & "CurrentStudents, "
        AllValue = AllValue & "@CurrentStudents, "

        AllField = AllField & "MaxStudents, "
        AllValue = AllValue & "@MaxStudents, "

        AllField = AllField & "Pass, "
        AllValue = AllValue & "@Pass, "

        AllField = AllField & "NextLevel, "
        AllValue = AllValue & "@NextLevel, "

        AllField = AllField & "ResultFormat, "
        AllValue = AllValue & "@ResultFormat, "

        AllField = AllField & "Location, "
        AllValue = AllValue & "@Location, "

        AllField = AllField & "StaffID, "
        AllValue = AllValue & "@StaffID, "

        AllField = AllField & "StaffName, "
        AllValue = AllValue & "@StaffName, "

        AllField = AllField & "StaffDaysID,"
        AllValue = AllValue & "@StaffDaysID,"

        AllField = AllField & "StaffDays,"
        AllValue = AllValue & "@StaffDays,"

        AllField = AllField & "Hours,"
        AllValue = AllValue & "@Hours,"

        AllField = AllField & "SecondStaffID,"
        AllValue = AllValue & "@SecondStaffID,"

        AllField = AllField & "SecondStaffName,"
        AllValue = AllValue & "@SecondStaffName,"

        AllField = AllField & "SecondStaffDaysID,"
        AllValue = AllValue & "@SecondStaffDaysID,"

        AllField = AllField & "SecondStaffDays,"
        AllValue = AllValue & "@SecondStaffDays,"

        AllField = AllField & "SecondStaffHours,"
        AllValue = AllValue & "@SecondStaffHours,"

        AllField = AllField & "MidTermComplete,"
        AllValue = AllValue & "@MidTermComplete,"

        AllField = AllField & "EndTermComplete,"
        AllValue = AllValue & "@EndTermComplete,"

        AllField = AllField & "Printed,"
        AllValue = AllValue & "@Printed,"

        AllField = AllField & "CreatedDate,"
        AllValue = AllValue & "@CreatedDate,"

        AllField = AllField & "CreatedBy,"
        AllValue = AllValue & "@CreatedBy,"

        AllField = AllField & "Young,"
        AllValue = AllValue & "@Young,"

        AllField = AllField & "ClassStartDate,"
        AllValue = AllValue & "@ClassStartDate,"

        AllField = AllField & "ClassEndDate"
        AllValue = AllValue & "@ClassEndDate"




        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim adapter As New SqlDataAdapter
        cn.ConnectionString = DalConnection_app.IOSConnectionString

        cmd.CommandText = " Insert into tblClasses(" & AllField & ") Values (" & AllValue & "); "
        cmd.Connection = cn 'assign the connection

        'add the parameters
        With Classes
            cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = .ClassID
            cmd.Parameters.Add("@Deleted", SqlDbType.Bit).Value = .Deleted
            cmd.Parameters.Add("@CourseName", SqlDbType.Char).Value = .CourseName
            cmd.Parameters.Add("@CourseBook", SqlDbType.Char).Value = .CourseBook
            cmd.Parameters.Add("@ProgramID", SqlDbType.Int).Value = .ProgramID
            cmd.Parameters.Add("@Program", SqlDbType.Char).Value = .Program
            cmd.Parameters.Add("@CourseID", SqlDbType.Int).Value = .CourseID
            cmd.Parameters.Add("@SeqNo", SqlDbType.Int).Value = .SeqNo
            cmd.Parameters.Add("@Term", SqlDbType.Char).Value = .Term
            cmd.Parameters.Add("@TermID", SqlDbType.Int).Value = .TermID
            cmd.Parameters.Add("@ClassDaysID", SqlDbType.Int).Value = .ClassDaysID
            cmd.Parameters.Add("@ClassDays", SqlDbType.Char).Value = .ClassDays
            cmd.Parameters.Add("@DayCount", SqlDbType.Int).Value = .DayCount
            cmd.Parameters.Add("@DaysMask", SqlDbType.Int).Value = .DaysMask
            cmd.Parameters.Add("@Time", SqlDbType.Char).Value = .Time
            cmd.Parameters.Add("@TimeID", SqlDbType.Int).Value = .TimeID
            cmd.Parameters.Add("@RoomID", SqlDbType.Int).Value = .RoomID
            cmd.Parameters.Add("@Room", SqlDbType.Char).Value = .Room
            cmd.Parameters.Add("@CurrentStudents", SqlDbType.Int).Value = .CurrentStudents
            cmd.Parameters.Add("@MaxStudents", SqlDbType.Int).Value = .MaxStudents
            cmd.Parameters.Add("@Pass", SqlDbType.Int).Value = .Pass
            cmd.Parameters.Add("@NextLevel", SqlDbType.Int).Value = .NextLevel
            cmd.Parameters.Add("@ResultFormat", SqlDbType.Int).Value = .ResultFormat
            cmd.Parameters.Add("@Location", SqlDbType.Char).Value = .Location
            cmd.Parameters.Add("@StaffID", SqlDbType.Int).Value = .StaffID
            cmd.Parameters.Add("@StaffName", SqlDbType.Char).Value = .StaffName
            cmd.Parameters.Add("@StaffDaysID", SqlDbType.Int).Value = .StaffDaysID
            cmd.Parameters.Add("@StaffDays", SqlDbType.Char).Value = .StaffDays
            cmd.Parameters.Add("@Hours", SqlDbType.Float).Value = .Hours
            cmd.Parameters.Add("@SecondStaffID", SqlDbType.Int).Value = .SecondStaffID
            cmd.Parameters.Add("@SecondStaffName", SqlDbType.Char).Value = .SecondStaffName
            cmd.Parameters.Add("@SecondStaffDaysID", SqlDbType.Int).Value = .SecondStaffDaysID
            cmd.Parameters.Add("@SecondStaffDays", SqlDbType.Char).Value = .SecondStaffDays
            cmd.Parameters.Add("@SecondStaffHours", SqlDbType.Float).Value = .SecondStaffHours
            cmd.Parameters.Add("@MidTermComplete", SqlDbType.Bit).Value = .MidTermComplete
            cmd.Parameters.Add("@EndTermComplete", SqlDbType.Bit).Value = .EndTermComplete
            cmd.Parameters.Add("@Printed", SqlDbType.Bit).Value = .Printed
            cmd.Parameters.Add("@CreatedDate", SqlDbType.Date).Value = .CreatedDate
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Char).Value = .CreatedBy
            cmd.Parameters.Add("@Young", SqlDbType.Bit).Value = .Young
            cmd.Parameters.Add("@ClassStartDate", SqlDbType.Date).Value = .ClassStartDate
            cmd.Parameters.Add("@ClassEndDate", SqlDbType.Date).Value = .ClassEndDate

        End With

        'execute the command
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()





    End Sub

    Public Function GetClasses(ByVal Classes As ClClasses_app) As DataSet
        Dim ds As DataSet = DalGlobal_app.Instance.getDataFromTable("tblClasses", "*", "ClassID", "Where ClassID=" & Classes.ClassID, "asc")
        Return ds
    End Function

    Public Sub DeleteClasses(ByVal Classes As ClClasses_app)
        ' find the classid

        DalGlobal_app.Instance.DeleteFromTable("tblClasses", "Where ClassID=" & Classes.ClassID)

    End Sub

    Public Sub UpdateClasses(ByVal Classes As ClClasses_app)

        Dim AllFieldNValue As String = ""
        AllFieldNValue = AllFieldNValue & "ClassID=@ClassID, "
        AllFieldNValue = AllFieldNValue & "Deleted=@Deleted, "
        AllFieldNValue = AllFieldNValue & "CourseName=@CourseName, "
        AllFieldNValue = AllFieldNValue & "CourseBook=@CourseBook, "
        AllFieldNValue = AllFieldNValue & "ProgramID=@ProgramID, "
        AllFieldNValue = AllFieldNValue & "Program=@Program, "
        AllFieldNValue = AllFieldNValue & "SeqNo=@SeqNo, "
        AllFieldNValue = AllFieldNValue & "Term=@Term, "
        AllFieldNValue = AllFieldNValue & "TermID=@TermID, "
        AllFieldNValue = AllFieldNValue & "ClassDaysID=@ClassDaysID, "
        AllFieldNValue = AllFieldNValue & "ClassDays=@ClassDays, "
        AllFieldNValue = AllFieldNValue & "DayCount=@DayCount, "
        AllFieldNValue = AllFieldNValue & "DaysMask=@DaysMask, "
        AllFieldNValue = AllFieldNValue & "Time=@Time, "
        AllFieldNValue = AllFieldNValue & "TimeID=@TimeID, "
        AllFieldNValue = AllFieldNValue & "RoomID=@RoomID, "
        AllFieldNValue = AllFieldNValue & "Room=@Room, "
        AllFieldNValue = AllFieldNValue & "MaxStudents=@MaxStudents, "

        AllFieldNValue = AllFieldNValue & "NextLevel=@NextLevel, "
        AllFieldNValue = AllFieldNValue & "ResultFormat=@ResultFormat, "
        AllFieldNValue = AllFieldNValue & "Location=@Location, "
        AllFieldNValue = AllFieldNValue & "StaffID=@StaffID, "
        AllFieldNValue = AllFieldNValue & "StaffName=@StaffName, "
        AllFieldNValue = AllFieldNValue & "StaffDaysID=@StaffDaysID, "
        AllFieldNValue = AllFieldNValue & "StaffDays=@StaffDays, "
        AllFieldNValue = AllFieldNValue & "Hours=@Hours, "
        AllFieldNValue = AllFieldNValue & "SecondStaffID=@SecondStaffID, "
        AllFieldNValue = AllFieldNValue & "SecondStaffName=@SecondStaffName, "
        AllFieldNValue = AllFieldNValue & "SecondStaffDaysID=@SecondStaffDaysID, "
        AllFieldNValue = AllFieldNValue & "SecondStaffDays=@SecondStaffDays, "
        AllFieldNValue = AllFieldNValue & "SecondStaffHours=@SecondStaffHours, "
        AllFieldNValue = AllFieldNValue & "CreatedDate=@CreatedDate, "
        AllFieldNValue = AllFieldNValue & "CreatedBy=@CreatedBy, "
        AllFieldNValue = AllFieldNValue & "ClassStartDate=@ClassStartDate, "
        AllFieldNValue = AllFieldNValue & "ClassEndDate=@ClassEndDate "





        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim adapter As New SqlDataAdapter
        cn.ConnectionString = DalConnection_app.IOSConnectionString

        cmd.CommandText = " UPDATE tblClasses SET " & AllFieldNValue & " Where ClassID=" & Classes.ClassID
        cmd.Connection = cn 'assign the connection

        'add the parameters
        With Classes
            cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = .ClassID
            cmd.Parameters.Add("@Deleted", SqlDbType.Bit).Value = .Deleted
            cmd.Parameters.Add("@CourseName", SqlDbType.Char).Value = .CourseName
            cmd.Parameters.Add("@CourseBook", SqlDbType.Char).Value = .CourseBook
            cmd.Parameters.Add("@ProgramID", SqlDbType.Int).Value = .ProgramID
            cmd.Parameters.Add("@Program", SqlDbType.Char).Value = .Program
            cmd.Parameters.Add("@CourseID", SqlDbType.Int).Value = .CourseID
            cmd.Parameters.Add("@SeqNo", SqlDbType.Int).Value = .SeqNo
            cmd.Parameters.Add("@Term", SqlDbType.Char).Value = .Term
            cmd.Parameters.Add("@TermID", SqlDbType.Int).Value = .TermID
            cmd.Parameters.Add("@ClassDaysID", SqlDbType.Int).Value = .ClassDaysID
            cmd.Parameters.Add("@ClassDays", SqlDbType.Char).Value = .ClassDays
            cmd.Parameters.Add("@DayCount", SqlDbType.Int).Value = .DayCount
            cmd.Parameters.Add("@DaysMask", SqlDbType.Int).Value = .DaysMask
            cmd.Parameters.Add("@Time", SqlDbType.Char).Value = .Time
            cmd.Parameters.Add("@TimeID", SqlDbType.Int).Value = .TimeID
            cmd.Parameters.Add("@RoomID", SqlDbType.Int).Value = .RoomID
            cmd.Parameters.Add("@Room", SqlDbType.Char).Value = .Room
            cmd.Parameters.Add("@CurrentStudents", SqlDbType.Int).Value = .CurrentStudents
            cmd.Parameters.Add("@MaxStudents", SqlDbType.Int).Value = .MaxStudents
            cmd.Parameters.Add("@Pass", SqlDbType.Int).Value = .Pass
            cmd.Parameters.Add("@NextLevel", SqlDbType.Int).Value = .NextLevel
            cmd.Parameters.Add("@ResultFormat", SqlDbType.Int).Value = .ResultFormat
            cmd.Parameters.Add("@Location", SqlDbType.Char).Value = .Location
            cmd.Parameters.Add("@StaffID", SqlDbType.Int).Value = .StaffID
            cmd.Parameters.Add("@StaffName", SqlDbType.Char).Value = .StaffName
            cmd.Parameters.Add("@StaffDaysID", SqlDbType.Int).Value = .StaffDaysID
            cmd.Parameters.Add("@StaffDays", SqlDbType.Char).Value = .StaffDays
            cmd.Parameters.Add("@Hours", SqlDbType.Float).Value = .Hours
            cmd.Parameters.Add("@SecondStaffID", SqlDbType.Int).Value = .SecondStaffID
            cmd.Parameters.Add("@SecondStaffName", SqlDbType.Char).Value = .SecondStaffName
            cmd.Parameters.Add("@SecondStaffDaysID", SqlDbType.Int).Value = .SecondStaffDaysID
            cmd.Parameters.Add("@SecondStaffDays", SqlDbType.Char).Value = .SecondStaffDays
            cmd.Parameters.Add("@SecondStaffHours", SqlDbType.Float).Value = .SecondStaffHours
            cmd.Parameters.Add("@MidTermComplete", SqlDbType.Bit).Value = .MidTermComplete
            cmd.Parameters.Add("@EndTermComplete", SqlDbType.Bit).Value = .EndTermComplete
            cmd.Parameters.Add("@Printed", SqlDbType.Bit).Value = .Printed
            cmd.Parameters.Add("@CreatedDate", SqlDbType.Date).Value = .CreatedDate
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Char).Value = .CreatedBy
            cmd.Parameters.Add("@Young", SqlDbType.Bit).Value = .Young
            cmd.Parameters.Add("@ClassStartDate", SqlDbType.Date).Value = .ClassStartDate
            cmd.Parameters.Add("@ClassEndDate", SqlDbType.Date).Value = .ClassEndDate



        End With

        'execute the command
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

    End Sub

End Class
