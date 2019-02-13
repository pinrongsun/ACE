Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Reflection

Public Class DalCourses_app
    Private Shared CoursesInstance As DalCourses_app

    Public Shared ReadOnly Property Instance As DalCourses_app
        Get
            If CoursesInstance Is Nothing Then
                CoursesInstance = New DalCourses_app
            End If
            Return CoursesInstance
        End Get
    End Property

    Public Sub AddCourses(ByVal Courses As ClCourses_app)
        Dim AllField As String = ""
        Dim AllValue As String = ""

        AllField = AllField & "CourseID, "
        AllValue = AllValue & "@CourseID, "

        AllField = AllField & "Deleted, "
        AllValue = AllValue & "@Deleted, "

        AllField = AllField & "ProgramID, "
        AllValue = AllValue & "@ProgramID, "

        AllField = AllField & "Program, "
        AllValue = AllValue & "@Program, "

        AllField = AllField & "CourseName, "
        AllValue = AllValue & "@CourseName, "

        AllField = AllField & "CourseBook, "
        AllValue = AllValue & "@CourseBook, "

        AllField = AllField & "SeqNo, "
        AllValue = AllValue & "@SeqNo, "

        AllField = AllField & "NextLevel, "
        AllValue = AllValue & "@NextLevel, "

        AllField = AllField & "NextLevelName,"
        AllValue = AllValue & "@NextLevelName,"

        AllField = AllField & "NextProgramLevel1,"
        AllValue = AllValue & "@NextProgramLevel1,"

        AllField = AllField & "NextProgramLevel2,"
        AllValue = AllValue & "@NextProgramLevel2,"

        AllField = AllField & "NextProgramLevel3,"
        AllValue = AllValue & "@NextProgramLevel3,"

        AllField = AllField & "PrereqID,"
        AllValue = AllValue & "@PrereqID,"

        AllField = AllField & "Discontinued,"
        AllValue = AllValue & "@Discontinued,"

        AllField = AllField & "DateDiscontinued,"
        AllValue = AllValue & "@DateDiscontinued,"

        AllField = AllField & "CourseCost,"
        AllValue = AllValue & "@CourseCost,"

        'AllField = AllField & "TextBookCost,"
        'AllValue = AllValue & "@TextBookCost,"

        'AllField = AllField & "TapeCost,"
        'AllValue = AllValue & "@TapeCost,"

        'AllField = AllField & "KidClubCost,"
        'AllValue = AllValue & "@KidClubCost,"

        AllField = AllField & "CreatedDate,"
        AllValue = AllValue & "@CreatedDate,"

        AllField = AllField & "CreatedBy,"
        AllValue = AllValue & "@CreatedBy,"

        AllField = AllField & "MaxStudents,"
        AllValue = AllValue & "@MaxStudents,"

        AllField = AllField & "ResultFormat,"
        AllValue = AllValue & "@ResultFormat,"

        AllField = AllField & "Criteria1,"
        AllValue = AllValue & "@Criteria1,"

        'AllField = AllField & "RegStart,"
        'AllValue = AllValue & "@RegStart,"

        AllField = AllField & "AgeBorder"
        AllValue = AllValue & "@AgeBorder"

        'AllField = AllField & "Notice"
        'AllValue = AllValue & "@Notice"


        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim adapter As New SqlDataAdapter
        cn.ConnectionString = DalConnection_app.IOSConnectionString

        cmd.CommandText = " Insert into tblCourses(" & AllField & ") Values (" & AllValue & "); "
        cmd.Connection = cn 'assign the connection

        'add the parameters
        With Courses
            cmd.Parameters.Add("@CourseID", SqlDbType.Int).Value = .CourseID
            cmd.Parameters.Add("@Deleted", SqlDbType.Bit).Value = .Deleted
            cmd.Parameters.Add("@ProgramID", SqlDbType.Int).Value = .ProgramID
            cmd.Parameters.Add("@Program", SqlDbType.Char).Value = .Program
            cmd.Parameters.Add("@CourseName", SqlDbType.Char).Value = .CourseName
            cmd.Parameters.Add("@CourseBook", SqlDbType.Char).Value = .CourseBook
            cmd.Parameters.Add("@SeqNo", SqlDbType.Int).Value = .SeqNo
            cmd.Parameters.Add("@NextLevel", SqlDbType.Int).Value = .NextLevel
            cmd.Parameters.Add("@NextLevelName", SqlDbType.Char).Value = .NextLevelName
            cmd.Parameters.Add("@NextProgramLevel1", SqlDbType.Int).Value = .NextProgramLevel1
            cmd.Parameters.Add("@NextProgramLevel2", SqlDbType.Int).Value = .NextProgramLevel2
            cmd.Parameters.Add("@NextProgramLevel3", SqlDbType.Int).Value = .NextProgramLevel3
            cmd.Parameters.Add("@PrereqID", SqlDbType.Int).Value = .PrereqID
            cmd.Parameters.Add("@DateDiscontinued", SqlDbType.Date).Value = .DateDiscontinued
            cmd.Parameters.Add("@Discontinued", SqlDbType.Bit).Value = .Discontinued
            cmd.Parameters.Add("@CourseCost", SqlDbType.Float).Value = .CourseCost
            'cmd.Parameters.Add("@TextBookCost", SqlDbType.Float).Value = .TextBookCost
            'cmd.Parameters.Add("@TapeCost", SqlDbType.Float).Value = .TapeCost
            'cmd.Parameters.Add("@KidClubCost", SqlDbType.Float).Value = .KidClubCost
            cmd.Parameters.Add("@CreatedDate", SqlDbType.Date).Value = .CreatedDate
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Char).Value = .CreatedBy
            cmd.Parameters.Add("@MaxStudents", SqlDbType.Int).Value = .MaxStudents
            cmd.Parameters.Add("@ResultFormat", SqlDbType.Int).Value = .ResultFormat
            cmd.Parameters.Add("@Criteria1", SqlDbType.Char).Value = .Criteria1
            'cmd.Parameters.Add("@RegStart", SqlDbType.DateTime).Value = .RegStart
            cmd.Parameters.Add("@AgeBorder", SqlDbType.Int).Value = .AgeBorder
            'cmd.Parameters.Add("@Notice", SqlDbType.Char).Value = .Notice


        End With

        'execute the command
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()


    End Sub

    Public Function GetCourses(ByVal Courses As ClCourses_app) As DataSet
        Dim ds As DataSet = DalGlobal_app.Instance.getDataFromTable("tblCourses", "*", "CourseID", "Where CourseID=" & Courses.CourseID, "asc")
        Return ds
    End Function

    Public Sub DeleteCourses(ByVal Courses As ClCourses_app)
        ' find the classid

        DalGlobal_app.Instance.DeleteFromTable("tblCourses", "Where CourseID=" & Courses.CourseID)

    End Sub

    Public Sub UpdateCourses(ByVal Courses As ClCourses_app)
        Dim AllFieldNValue As String = ""

        AllFieldNValue = AllFieldNValue & "CourseID=@CourseID, "
        AllFieldNValue = AllFieldNValue & "Deleted=@Deleted, "
        AllFieldNValue = AllFieldNValue & "ProgramID=@ProgramID, "
        AllFieldNValue = AllFieldNValue & "Program=@Program, "
        AllFieldNValue = AllFieldNValue & "CourseName=@CourseName, "
        AllFieldNValue = AllFieldNValue & "CourseBook=@CourseBook, "
        AllFieldNValue = AllFieldNValue & "SeqNo=@SeqNo, "
        AllFieldNValue = AllFieldNValue & "NextLevel=@NextLevel, "
        AllFieldNValue = AllFieldNValue & "NextLevelName=@NextLevelName, "
        AllFieldNValue = AllFieldNValue & "NextProgramLevel1=@NextProgramLevel1, "
        AllFieldNValue = AllFieldNValue & "NextProgramLevel2=@NextProgramLevel2, "
        AllFieldNValue = AllFieldNValue & "NextProgramLevel3=@NextProgramLevel3, "
        AllFieldNValue = AllFieldNValue & "PrereqID=@PrereqID, "
        AllFieldNValue = AllFieldNValue & "Discontinued=@Discontinued, "
        AllFieldNValue = AllFieldNValue & "DateDiscontinued=@DateDiscontinued, "
        AllFieldNValue = AllFieldNValue & "CourseCost=@CourseCost, "
        'AllFieldNValue = AllFieldNValue & "TextBookCost=@TextBookCost, "
        'AllFieldNValue = AllFieldNValue & "TapeCost=@TapeCost, "
        'AllFieldNValue = AllFieldNValue & "KidClubCost=@KidClubCost, "
        AllFieldNValue = AllFieldNValue & "CreatedDate=@CreatedDate, "
        AllFieldNValue = AllFieldNValue & "CreatedBy=@CreatedBy, "
        AllFieldNValue = AllFieldNValue & "MaxStudents=@MaxStudents, "
        AllFieldNValue = AllFieldNValue & "ResultFormat=@ResultFormat, "
        AllFieldNValue = AllFieldNValue & "Criteria1=@Criteria1, "
        'AllFieldNValue = AllFieldNValue & "RegStart=@RegStart, "
        AllFieldNValue = AllFieldNValue & "AgeBorder=@AgeBorder "
        'AllFieldNValue = AllFieldNValue & "Notice=@Notice "


        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim adapter As New SqlDataAdapter
        cn.ConnectionString = DalConnection_app.IOSConnectionString

        cmd.CommandText = " UPDATE tblCourses SET " & AllFieldNValue & " Where CourseID=" & Courses.CourseID
        cmd.Connection = cn 'assign the connection

        'add the parameters
        With Courses
            cmd.Parameters.Add("@CourseID", SqlDbType.Int).Value = .CourseID
            cmd.Parameters.Add("@Deleted", SqlDbType.Bit).Value = .Deleted
            cmd.Parameters.Add("@ProgramID", SqlDbType.Int).Value = .ProgramID
            cmd.Parameters.Add("@Program", SqlDbType.Char).Value = .Program
            cmd.Parameters.Add("@CourseName", SqlDbType.Char).Value = .CourseName
            cmd.Parameters.Add("@CourseBook", SqlDbType.Char).Value = .CourseBook
            cmd.Parameters.Add("@SeqNo", SqlDbType.Int).Value = .SeqNo
            cmd.Parameters.Add("@NextLevel", SqlDbType.Int).Value = .NextLevel
            cmd.Parameters.Add("@NextLevelName", SqlDbType.Char).Value = .NextLevelName
            cmd.Parameters.Add("@NextProgramLevel1", SqlDbType.Int).Value = .NextProgramLevel1
            cmd.Parameters.Add("@NextProgramLevel2", SqlDbType.Int).Value = .NextProgramLevel2
            cmd.Parameters.Add("@NextProgramLevel3", SqlDbType.Int).Value = .NextProgramLevel3
            cmd.Parameters.Add("@PrereqID", SqlDbType.Int).Value = .PrereqID
            cmd.Parameters.Add("@DateDiscontinued", SqlDbType.Date).Value = .DateDiscontinued
            cmd.Parameters.Add("@Discontinued", SqlDbType.Bit).Value = .Discontinued
            cmd.Parameters.Add("@CourseCost", SqlDbType.Float).Value = .CourseCost
            'cmd.Parameters.Add("@TextBookCost", SqlDbType.Float).Value = .TextBookCost
            'cmd.Parameters.Add("@TapeCost", SqlDbType.Float).Value = .TapeCost
            'cmd.Parameters.Add("@KidClubCost", SqlDbType.Float).Value = .KidClubCost
            cmd.Parameters.Add("@CreatedDate", SqlDbType.Date).Value = .CreatedDate
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Char).Value = .CreatedBy
            cmd.Parameters.Add("@MaxStudents", SqlDbType.Int).Value = .MaxStudents
            cmd.Parameters.Add("@ResultFormat", SqlDbType.Int).Value = .ResultFormat
            cmd.Parameters.Add("@Criteria1", SqlDbType.Char).Value = .Criteria1
            'cmd.Parameters.Add("@RegStart", SqlDbType.Date).Value = .RegStart
            cmd.Parameters.Add("@AgeBorder", SqlDbType.Int).Value = .AgeBorder
            'cmd.Parameters.Add("@Notice", SqlDbType.Char).Value = .Notice



        End With

        'execute the command
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

    End Sub
End Class
