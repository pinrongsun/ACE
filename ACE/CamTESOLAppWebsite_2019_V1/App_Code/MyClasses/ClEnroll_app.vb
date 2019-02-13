Imports Microsoft.VisualBasic

Public Class ClEnroll_app

    Public Property EnrollID As String
    Public Property NoClass As Boolean
    Public Property Deleted As Boolean
    Public Property ContactID As Integer
    Public Property StudentName As String
    Public Property Term As String
    Public Property TermID As Integer
    Public Property Program As String
    Public Property CourseID As Integer
    Public Property CourseName As String
    Public Property ClassID As Integer
    Public Property Room As String
    Public Property Sponsored As String
    Public Property StaffSponsor As Boolean
    Public Property SponsorID As Integer
    Public Property SponsorName As String
    Public Property CourseCost As Double 'not sure
    Public Property Credit As Double '----
    Public Property Discount As Double '--------
    Public Property Total As Double '----------
    Public Property CreatedDate As Date
    Public Property CreatedBy As String
    Public Property ClassDays As String
    Public Property ClassDaysID As Integer
    Public Property ClassTime As String
    Public Property StaffName As String
    Public Property SecondStaffName As String
    Public Property MTAbsent As Integer
    Public Property ETAbsent As Integer
    Public Property MidAttendance As Integer
    Public Property EndAttendance As Integer
    Public Property Participation As Integer
    Public Property Motivation As Integer
    Public Property FinalMark As Double
    Public Property Result1 As Double
    Public Property Result2 As Double
    Public Property Result3 As Double
    Public Property Result4 As Double
    Public Property Result5 As Double
    Public Property Result6 As Double
    Public Property NextLevelName As String
    Public Property NextLevelCode As Integer
    Public Property Outcome As String
    Public Property Pass As Boolean
    Public Property FlipFlop As Boolean
    Public Property BookPurchased As Boolean
    Public Property BookCost As Double
    Public Property CDPurchased As Boolean
    Public Property CDCost As Double
    Public Property WorkBookPurchased As Boolean
    Public Property WorkBookCost As Double



    ''.. additional fields, not store in the DB
    Public Property CourseBook As String
    Public Property SubTotal As Double
    Public Property RemainingCredit As Double
    Public Property CurrentStudents As Integer
    Public Property MaxStudents As Integer
    Public Property SchoolAddress As String
    Public Property SchoolAddress2 As String
    Public Property ClassStartDate As Date
    Public Property ClassEndDate As Date

    Public Property EnrolmentType As String

    Public Property EnrolmentStatus As String
    Public Property Exception As Boolean
    Public Property ExceptionDescription As String



End Class
