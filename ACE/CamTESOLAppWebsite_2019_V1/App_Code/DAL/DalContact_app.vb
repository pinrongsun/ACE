Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Linq.Expressions
Imports System.Reflection
Imports System.Type


Public Class DalContact_app
    Private Shared ContactInstance As DalContact_app

    Public Shared ReadOnly Property Instance As DalContact_app
        Get
            If ContactInstance Is Nothing Then
                ContactInstance = New DalContact_app
            End If
            Return ContactInstance
        End Get
    End Property

    Public Sub AddContact(ByVal Contact As ClContact_app)
        Dim AllField As String = ""
        Dim AllValue As String = ""

        AllField = AllField & "ContactID, "
        AllValue = AllValue & "@ContactID, "

        AllField = AllField & "FamilyName, "
        AllValue = AllValue & "@FamilyName, "

        AllField = AllField & "GivenName, "
        AllValue = AllValue & "@GivenName, "

        AllField = AllField & "Sex, "
        AllValue = AllValue & "@Sex, "

        AllField = AllField & "DOB, "
        AllValue = AllValue & "@DOB, "

        AllField = AllField & "Phone, "
        AllValue = AllValue & "@Phone, "

        AllField = AllField & "Email, "
        AllValue = AllValue & "@Email, "

        AllField = AllField & "Home,"
        AllValue = AllValue & "@Home,"

        AllField = AllField & "Street,"
        AllValue = AllValue & "@Street,"

        AllField = AllField & "SangKat,"
        AllValue = AllValue & "@SangKat,"

        AllField = AllField & "Province,"
        AllValue = AllValue & "@Province,"

        AllField = AllField & "Khan,"
        AllValue = AllValue & "@Khan,"

        AllField = AllField & "SangKatName,"
        AllValue = AllValue & "@SangKatName,"

        AllField = AllField & "WorkPlace,"
        AllValue = AllValue & "@WorkPlace,"

        AllField = AllField & "WHome,"
        AllValue = AllValue & "@WHome,"

        AllField = AllField & "WStreet,"
        AllValue = AllValue & "@WStreet,"

        AllField = AllField & "School,"
        AllValue = AllValue & "@School,"

        AllField = AllField & "Comments,"
        AllValue = AllValue & "@Comments,"

        AllField = AllField & "CreatedDate,"
        AllValue = AllValue & "@CreatedDate,"

        AllField = AllField & "CreatedBy,"
        AllValue = AllValue & "@CreatedBy,"

        AllField = AllField & "Deleted,"
        AllValue = AllValue & "@Deleted,"


        AllField = AllField & "Title,"
        AllValue = AllValue & "@Title,"


        AllField = AllField & "Nationality,"
        AllValue = AllValue & "@Nationality,"


        AllField = AllField & "EdGrade,"
        AllValue = AllValue & "@EdGrade,"


        AllField = AllField & "EdPrvEnglishSchool,"
        AllValue = AllValue & "@EdPrvEnglishSchool,"

        AllField = AllField & "EdEnglishLevel,"
        AllValue = AllValue & "@EdEnglishLevel,"

        AllField = AllField & "EdTestIELTS,"
        AllValue = AllValue & "@EdTestIELTS,"

        AllField = AllField & "EdTestTOEFL,"
        AllValue = AllValue & "@EdTestTOEFL,"

        AllField = AllField & "EdYears,"
        AllValue = AllValue & "@EdYears,"

        AllField = AllField & "WPosition,"
        AllValue = AllValue & "@WPosition,"


        AllField = AllField & "BPhone,"
        AllValue = AllValue & "@BPhone,"

        AllField = AllField & "BEmail,"
        AllValue = AllValue & "@BEmail,"


        AllField = AllField & "BeingSponsored,"
        AllValue = AllValue & "@BeingSponsored,"

        AllField = AllField & "SponsorName,"
        AllValue = AllValue & "@SponsorName,"



        AllField = AllField & "GFamilyName,"
        AllValue = AllValue & "@GFamilyName,"

        AllField = AllField & "GGivenName,"
        AllValue = AllValue & "@GGivenName,"

        AllField = AllField & "GRelationship,"
        AllValue = AllValue & "@GRelationship,"

        AllField = AllField & "GPhone,"
        AllValue = AllValue & "@GPhone,"

        AllField = AllField & "GBPhone,"
        AllValue = AllValue & "@GBPhone,"

        AllField = AllField & "GEmail,"
        AllValue = AllValue & "@GEmail,"

        AllField = AllField & "GBEmail,"
        AllValue = AllValue & "@GBEmail,"

        AllField = AllField & "GHome,"
        AllValue = AllValue & "@GHome,"

        AllField = AllField & "GStreet,"
        AllValue = AllValue & "@GStreet,"

        AllField = AllField & "GSangkat,"
        AllValue = AllValue & "@GSangkat,"

        AllField = AllField & "GProvince,"
        AllValue = AllValue & "@GProvince,"

        AllField = AllField & "GKhan,"
        AllValue = AllValue & "@GKhan,"

        AllField = AllField & "GSangKatName,"
        AllValue = AllValue & "@GSangKatName,"

        AllField = AllField & "CReasonForPreferredCourse,"
        AllValue = AllValue & "@CReasonForPreferredCourse,"

        AllField = AllField & "CPreferredGEP,"
        AllValue = AllValue & "@CPreferredGEP,"

        AllField = AllField & "CPreferredEAP,"
        AllValue = AllValue & "@CPreferredEAP,"

        AllField = AllField & "CPreferredBEP,"
        AllValue = AllValue & "@CPreferredBEP,"

        AllField = AllField & "CPreferredIELTSPrep,"
        AllValue = AllValue & "@CPreferredIELTSPrep,"

        AllField = AllField & "EmgFamilyName,"
        AllValue = AllValue & "@EmgFamilyName,"

        AllField = AllField & "EmgGivenName,"
        AllValue = AllValue & "@EmgGivenName,"

        AllField = AllField & "EmgPhone,"
        AllValue = AllValue & "@EmgPhone,"

        AllField = AllField & "EmgBPhone,"
        AllValue = AllValue & "@EmgBPhone,"

        AllField = AllField & "ByFriends,"
        AllValue = AllValue & "@ByFriends,"

        AllField = AllField & "ByNewspaper,"
        AllValue = AllValue & "@ByNewspaper,"

        AllField = AllField & "BySchool,"
        AllValue = AllValue & "@BySchool,"

        AllField = AllField & "ByFacebook,"
        AllValue = AllValue & "@ByFacebook,"

        AllField = AllField & "ByEvents,"
        AllValue = AllValue & "@ByEvents,"

        AllField = AllField & "ByRadio,"
        AllValue = AllValue & "@ByRadio,"

        AllField = AllField & "ByScholarship,"
        AllValue = AllValue & "@ByScholarship,"

        AllField = AllField & "ByOther,"
        AllValue = AllValue & "@ByOther,"

        AllField = AllField & "ByOtherText,"
        AllValue = AllValue & "@ByOtherText,"

        AllField = AllField & "IsNotify"
        AllValue = AllValue & "@IsNotify"

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim adapter As New SqlDataAdapter
        cn.ConnectionString = DalConnection_app.IOSConnectionString

        cmd.CommandText = " Insert into tblContact(" & AllField & ") Values (" & AllValue & "); "
        cmd.Connection = cn 'assign the connection

        'add the parameters
        With Contact
            cmd.Parameters.Add("@ContactID", SqlDbType.Int).Value = .ContactID
            cmd.Parameters.Add("@FamilyName", SqlDbType.Char).Value = .FamilyName
            cmd.Parameters.Add("@GivenName", SqlDbType.Char).Value = .GivenName
            cmd.Parameters.Add("@Sex", SqlDbType.Char).Value = .Sex
            cmd.Parameters.Add("@DOB", SqlDbType.Date).Value = .DOB
            cmd.Parameters.Add("@Phone", SqlDbType.Char).Value = .Phone
            cmd.Parameters.Add("@Email", SqlDbType.Char).Value = .Email
            cmd.Parameters.Add("@Home", SqlDbType.Char).Value = .Home
            cmd.Parameters.Add("@Street", SqlDbType.Char).Value = .Street
            cmd.Parameters.Add("@SangKat", SqlDbType.Int).Value = .SangKat
            cmd.Parameters.Add("@Province", SqlDbType.Char).Value = .Province
            cmd.Parameters.Add("@Khan", SqlDbType.Char).Value = .Khan
            cmd.Parameters.Add("@SangKatName", SqlDbType.Char).Value = .SangKatName
            cmd.Parameters.Add("@WorkPlace", SqlDbType.Char).Value = .WorkPlace
            cmd.Parameters.Add("@WHome", SqlDbType.Char).Value = .WHome
            cmd.Parameters.Add("@WStreet", SqlDbType.Char).Value = .WStreet
            cmd.Parameters.Add("@School", SqlDbType.Char).Value = .School
            cmd.Parameters.Add("@Comments", SqlDbType.Char).Value = .Comments
            cmd.Parameters.Add("@CreatedDate", SqlDbType.Date).Value = .CreatedDate
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Char).Value = .CreatedBy
            cmd.Parameters.Add("@Deleted", SqlDbType.Bit).Value = .Deleted
            cmd.Parameters.Add("@Title", SqlDbType.Char).Value = .Title
            cmd.Parameters.Add("@Nationality", SqlDbType.Char).Value = .Nationality
            cmd.Parameters.Add("@EdGrade", SqlDbType.Char).Value = .EdGrade
            cmd.Parameters.Add("@EdPrvEnglishSchool", SqlDbType.Char).Value = .EdPrvEnglishSchool
            cmd.Parameters.Add("@EdEnglishLevel", SqlDbType.Char).Value = .EdEnglishLevel
            cmd.Parameters.Add("@EdTestIELTS", SqlDbType.Bit).Value = .EdTestIELTS
            cmd.Parameters.Add("@EdTestTOEFL", SqlDbType.Bit).Value = .EdTestTOEFL
            cmd.Parameters.Add("@EdYears", SqlDbType.Char).Value = .EdYears
            cmd.Parameters.Add("@WPosition", SqlDbType.Char).Value = .WPosition

            cmd.Parameters.Add("@BPhone", SqlDbType.Char).Value = .BPhone
            cmd.Parameters.Add("@BEmail", SqlDbType.Char).Value = .BEmail

            cmd.Parameters.Add("@BeingSponsored", SqlDbType.Bit).Value = .BeingSponsored
            cmd.Parameters.Add("@SponsorName", SqlDbType.Char).Value = .SponsorName

            cmd.Parameters.Add("@GFamilyName", SqlDbType.Char).Value = .GFamilyName
            cmd.Parameters.Add("@GGivenName", SqlDbType.Char).Value = .GGivenName
            cmd.Parameters.Add("@GRelationship", SqlDbType.Char).Value = .GRelationship

            cmd.Parameters.Add("@GPhone", SqlDbType.Char).Value = .GPhone
            cmd.Parameters.Add("@GBPhone", SqlDbType.Char).Value = .GBPhone

            cmd.Parameters.Add("@GEmail", SqlDbType.Char).Value = .GEmail
            cmd.Parameters.Add("@GBEmail", SqlDbType.Char).Value = .GBEmail

            cmd.Parameters.Add("@GHome", SqlDbType.Char).Value = .GHome
            cmd.Parameters.Add("@GStreet", SqlDbType.Char).Value = .GStreet
            cmd.Parameters.Add("@GSangkat", SqlDbType.Int).Value = .GSangkat
            cmd.Parameters.Add("@GProvince", SqlDbType.Char).Value = .GProvince
            cmd.Parameters.Add("@GKhan", SqlDbType.Char).Value = .GKhan
            cmd.Parameters.Add("@GSangKatName", SqlDbType.Char).Value = .GSangKatName
            cmd.Parameters.Add("@CReasonForPreferredCourse", SqlDbType.Char).Value = .CReasonForPreferredCourse
            cmd.Parameters.Add("@CPreferredGEP", SqlDbType.Bit).Value = .CPreferredGEP
            cmd.Parameters.Add("@CPreferredEAP", SqlDbType.Bit).Value = .CPreferredEAP
            cmd.Parameters.Add("@CPreferredBEP", SqlDbType.Bit).Value = .CPreferredBEP
            cmd.Parameters.Add("@CPreferredIELTSPrep", SqlDbType.Bit).Value = .CPreferredIELTSPrep

            cmd.Parameters.Add("@EmgFamilyName", SqlDbType.Char).Value = .EmgFamilyName
            cmd.Parameters.Add("@EmgGivenName", SqlDbType.Char).Value = .EmgGivenName
            cmd.Parameters.Add("@EmgPhone", SqlDbType.Char).Value = .EmgPhone
            cmd.Parameters.Add("@EmgBPhone", SqlDbType.Char).Value = .EmgBPhone
            cmd.Parameters.Add("@IsNotify", SqlDbType.Bit).Value = .IsNotify

            cmd.Parameters.Add("@ByFriends", SqlDbType.Bit).Value = .ByFriends
            cmd.Parameters.Add("@ByNewspaper", SqlDbType.Bit).Value = .ByNewspaper
            cmd.Parameters.Add("@BySchool", SqlDbType.Bit).Value = .BySchool
            cmd.Parameters.Add("@ByFacebook", SqlDbType.Bit).Value = .ByFacebook
            cmd.Parameters.Add("@ByEvents", SqlDbType.Bit).Value = .ByEvents
            cmd.Parameters.Add("@ByRadio", SqlDbType.Bit).Value = .ByRadio
            cmd.Parameters.Add("@ByScholarship", SqlDbType.Bit).Value = .ByScholarship
            cmd.Parameters.Add("@ByOther", SqlDbType.Bit).Value = .ByOther
            cmd.Parameters.Add("@ByOtherText", SqlDbType.Char).Value = .ByOtherText

        End With

        'execute the command
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()



    End Sub

    Public Function GetContact(ByVal Contact As ClContact_app) As DataSet
        Dim ds As DataSet = DalGlobal_app.Instance.getDataFromTable("tblContact", "*", "ContactID", "Where ContactID=" & Contact.ContactID, "asc")
        Return ds
    End Function

    Public Sub DeleteContact(ByVal Contact As ClContact_app)
        ' find the classid

        DalGlobal_app.Instance.DeleteFromTable("tblContact", "Where ContactID=" & Contact.ContactID)

    End Sub

    Public Sub UpdateContact(ByVal Contact As ClContact_app)
        Dim AllFieldNValue As String = ""
        AllFieldNValue = AllFieldNValue & "ContactID=@ContactID, "
        AllFieldNValue = AllFieldNValue & "FamilyName=@FamilyName, "
        AllFieldNValue = AllFieldNValue & "GivenName=@GivenName, "
        AllFieldNValue = AllFieldNValue & "Sex=@Sex, "
        AllFieldNValue = AllFieldNValue & "DOB=@DOB, "
        AllFieldNValue = AllFieldNValue & "Phone=@Phone, "
        AllFieldNValue = AllFieldNValue & "Email=@Email, "
        AllFieldNValue = AllFieldNValue & "Home=@Home, "
        AllFieldNValue = AllFieldNValue & "Street=@Street, "
        AllFieldNValue = AllFieldNValue & "SangKat=@SangKat, "
        AllFieldNValue = AllFieldNValue & "WorkPlace=@WorkPlace, "
        AllFieldNValue = AllFieldNValue & "WHome=@WHome, "
        AllFieldNValue = AllFieldNValue & "WStreet=@WStreet, "
        AllFieldNValue = AllFieldNValue & "School=@School, "
        AllFieldNValue = AllFieldNValue & "Comments=@Comments, "
        AllFieldNValue = AllFieldNValue & "EditedDate=@EditedDate, "
        AllFieldNValue = AllFieldNValue & "EditedBy=@EditedBy, "
        AllFieldNValue = AllFieldNValue & "Deleted=@Deleted, "
        AllFieldNValue = AllFieldNValue & "DeletedDate=@DeletedDate, "
        AllFieldNValue = AllFieldNValue & "Title=@Title, "
        AllFieldNValue = AllFieldNValue & "Nationality=@Nationality, "
        AllFieldNValue = AllFieldNValue & "EdGrade=@EdGrade, "
        AllFieldNValue = AllFieldNValue & "EdPrvEnglishSchool=@EdPrvEnglishSchool, "
        AllFieldNValue = AllFieldNValue & "EdEnglishLevel=@EdEnglishLevel, "
        AllFieldNValue = AllFieldNValue & "EdTestIELTS=@EdTestIELTS, "
        AllFieldNValue = AllFieldNValue & "EdTestTOEFL=@EdTestTOEFL,"
        AllFieldNValue = AllFieldNValue & "EdYears=@EdYears, "
        AllFieldNValue = AllFieldNValue & "WPosition=@WPosition, "

        AllFieldNValue = AllFieldNValue & "BPhone=@BPhone, "
        AllFieldNValue = AllFieldNValue & "BEmail=@BEmail, "

        AllFieldNValue = AllFieldNValue & "BeingSponsored=@BeingSponsored, "
        AllFieldNValue = AllFieldNValue & "SponsorName=@SponsorName, "

        AllFieldNValue = AllFieldNValue & "GFamilyName=@GFamilyName, "
        AllFieldNValue = AllFieldNValue & "GGivenName=@GGivenName, "

        AllFieldNValue = AllFieldNValue & "GPhone=@GPhone, "
        AllFieldNValue = AllFieldNValue & "GBPhone=@GBPhone, "

        AllFieldNValue = AllFieldNValue & "GEmail=@GEmail, "
        AllFieldNValue = AllFieldNValue & "GBEmail=@GBEmail, "

        AllFieldNValue = AllFieldNValue & "GHome=@GHome, "
        AllFieldNValue = AllFieldNValue & "GStreet=@GStreet, "
        AllFieldNValue = AllFieldNValue & "GSangkat=@GSangkat, "

        AllFieldNValue = AllFieldNValue & "CReasonForPreferredCourse=@CReasonForPreferredCourse, "
        AllFieldNValue = AllFieldNValue & "CPreferredGEP=@CPreferredGEP, "
        AllFieldNValue = AllFieldNValue & "CPreferredEAP=@CPreferredEAP, "
        AllFieldNValue = AllFieldNValue & "CPreferredBEP=@CPreferredBEP, "
        AllFieldNValue = AllFieldNValue & "CPreferredIELTSPrep=@CPreferredIELTSPrep, "

        AllFieldNValue = AllFieldNValue & "EmgFamilyName=@EmgFamilyName, "
        AllFieldNValue = AllFieldNValue & "EmgGivenName=@EmgGivenName, "
        AllFieldNValue = AllFieldNValue & "EmgPhone=@EmgPhone, "
        AllFieldNValue = AllFieldNValue & "EmgBPhone=@EmgBPhone, "
        AllFieldNValue = AllFieldNValue & "IsNotify=@IsNotify "

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim adapter As New SqlDataAdapter
        cn.ConnectionString = DalConnection_app.IOSConnectionString

        cmd.CommandText = " UPDATE tblContact SET " & AllFieldNValue & " Where ContactID=" & Contact.ContactID
        cmd.Connection = cn 'assign the connection

        With Contact
            cmd.Parameters.Add("@ContactID", SqlDbType.Int).Value = .ContactID
            cmd.Parameters.Add("@FamilyName", SqlDbType.Char).Value = .FamilyName
            cmd.Parameters.Add("@GivenName", SqlDbType.Char).Value = .GivenName
            cmd.Parameters.Add("@Sex", SqlDbType.Char).Value = .Sex
            cmd.Parameters.Add("@DOB", SqlDbType.Date).Value = .DOB
            cmd.Parameters.Add("@Phone", SqlDbType.Char).Value = .Phone
            cmd.Parameters.Add("@Email", SqlDbType.Char).Value = .Email
            cmd.Parameters.Add("@Home", SqlDbType.Char).Value = .Home
            cmd.Parameters.Add("@Street", SqlDbType.Char).Value = .Street
            cmd.Parameters.Add("@SangKat", SqlDbType.Int).Value = .SangKat
            cmd.Parameters.Add("@WorkPlace", SqlDbType.Char).Value = .WorkPlace
            cmd.Parameters.Add("@WHome", SqlDbType.Char).Value = .WHome
            cmd.Parameters.Add("@WStreet", SqlDbType.Char).Value = .WStreet
            cmd.Parameters.Add("@School", SqlDbType.Char).Value = .School
            cmd.Parameters.Add("@Comments", SqlDbType.Char).Value = .Comments
            cmd.Parameters.Add("@EditedDate", SqlDbType.Date).Value = .EditedDate
            cmd.Parameters.Add("@EditedBy", SqlDbType.Char).Value = .EditedBy
            cmd.Parameters.Add("@Deleted", SqlDbType.Bit).Value = .Deleted
            cmd.Parameters.Add("@DeletedDate", SqlDbType.Date).Value = .DeletedDate
            cmd.Parameters.Add("@Title", SqlDbType.Char).Value = .Title
            cmd.Parameters.Add("@Nationality", SqlDbType.Char).Value = .Nationality
            cmd.Parameters.Add("@EdGrade", SqlDbType.Char).Value = .EdGrade
            cmd.Parameters.Add("@EdPrvEnglishSchool", SqlDbType.Char).Value = .EdPrvEnglishSchool
            cmd.Parameters.Add("@EdEnglishLevel", SqlDbType.Char).Value = .EdEnglishLevel
            cmd.Parameters.Add("@EdTestIELTS", SqlDbType.Bit).Value = .EdTestIELTS
            cmd.Parameters.Add("@EdTestTOEFL", SqlDbType.Bit).Value = .EdTestTOEFL
            cmd.Parameters.Add("@EdYears", SqlDbType.Char).Value = .EdYears
            cmd.Parameters.Add("@WPosition", SqlDbType.Char).Value = .WPosition

            cmd.Parameters.Add("@BPhone", SqlDbType.Char).Value = .BPhone
            cmd.Parameters.Add("@BEmail", SqlDbType.Char).Value = .BEmail

            cmd.Parameters.Add("@BeingSponsored", SqlDbType.Bit).Value = .BeingSponsored
            cmd.Parameters.Add("@SponsorName", SqlDbType.Char).Value = .SponsorName

            cmd.Parameters.Add("@GFamilyName", SqlDbType.Char).Value = .GFamilyName
            cmd.Parameters.Add("@GGivenName", SqlDbType.Char).Value = .GGivenName

            cmd.Parameters.Add("@GPhone", SqlDbType.Char).Value = .GPhone
            cmd.Parameters.Add("@GBPhone", SqlDbType.Char).Value = .GBPhone

            cmd.Parameters.Add("@GEmail", SqlDbType.Char).Value = .GEmail
            cmd.Parameters.Add("@GBEmail", SqlDbType.Char).Value = .GBEmail

            cmd.Parameters.Add("@GHome", SqlDbType.Char).Value = .GHome
            cmd.Parameters.Add("@GStreet", SqlDbType.Char).Value = .GStreet
            cmd.Parameters.Add("@GSangkat", SqlDbType.Int).Value = .GSangkat

            cmd.Parameters.Add("@CReasonForPreferredCourse", SqlDbType.Char).Value = .CReasonForPreferredCourse
            cmd.Parameters.Add("@CPreferredGEP", SqlDbType.Bit).Value = .CPreferredGEP
            cmd.Parameters.Add("@CPreferredEAP", SqlDbType.Bit).Value = .CPreferredEAP
            cmd.Parameters.Add("@CPreferredBEP", SqlDbType.Bit).Value = .CPreferredBEP
            cmd.Parameters.Add("@CPreferredIELTSPrep", SqlDbType.Bit).Value = .CPreferredIELTSPrep

            cmd.Parameters.Add("@EmgFamilyName", SqlDbType.Char).Value = .EmgFamilyName
            cmd.Parameters.Add("@EmgGivenName", SqlDbType.Char).Value = .EmgGivenName
            cmd.Parameters.Add("@EmgPhone", SqlDbType.Char).Value = .EmgPhone
            cmd.Parameters.Add("@EmgBPhone", SqlDbType.Char).Value = .EmgBPhone
            cmd.Parameters.Add("@IsNotify", SqlDbType.Bit).Value = .IsNotify

        End With

        'execute the command
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()


    End Sub

    Public Sub UpdateContactPT(ByVal Contact As ClContact_app)
        Dim AllFieldNValue As String = ""
        AllFieldNValue = AllFieldNValue & "ContactID=@ContactID, "
        'AllFieldNValue = AllFieldNValue & "FamilyName=@FamilyName, "
        'AllFieldNValue = AllFieldNValue & "GivenName=@GivenName, "
        'AllFieldNValue = AllFieldNValue & "Sex=@Sex, "
        'AllFieldNValue = AllFieldNValue & "DOB=@DOB, "
        'AllFieldNValue = AllFieldNValue & "Phone=@Phone, "
        'AllFieldNValue = AllFieldNValue & "Email=@Email, "
        AllFieldNValue = AllFieldNValue & "Home=@Home, "
        AllFieldNValue = AllFieldNValue & "Street=@Street, "
        'AllFieldNValue = AllFieldNValue & "SangKat=@SangKat, "
        AllFieldNValue = AllFieldNValue & "WorkPlace=@WorkPlace, "
        AllFieldNValue = AllFieldNValue & "School=@School, "
        'AllFieldNValue = AllFieldNValue & "Comments=@Comments, "
        AllFieldNValue = AllFieldNValue & "EditedDate=@EditedDate, "
        AllFieldNValue = AllFieldNValue & "EditedBy=@EditedBy, "
        'AllFieldNValue = AllFieldNValue & "Deleted=@Deleted, "
        AllFieldNValue = AllFieldNValue & "DeletedDate=@DeletedDate, "
        'AllFieldNValue = AllFieldNValue & "Title=@Title, "
        'AllFieldNValue = AllFieldNValue & "Nationality=@Nationality, "
        AllFieldNValue = AllFieldNValue & "EdGrade=@EdGrade, "
        AllFieldNValue = AllFieldNValue & "EdPrvEnglishSchool=@EdPrvEnglishSchool, "
        AllFieldNValue = AllFieldNValue & "EdEnglishLevel=@EdEnglishLevel, "
        AllFieldNValue = AllFieldNValue & "EdTestIELTS=@EdTestIELTS, "
        AllFieldNValue = AllFieldNValue & "EdTestTOEFL=@EdTestTOEFL,"
        AllFieldNValue = AllFieldNValue & "EdYears=@EdYears, "
        AllFieldNValue = AllFieldNValue & "WPosition=@WPosition, "

        AllFieldNValue = AllFieldNValue & "BPhone=@BPhone, "
        AllFieldNValue = AllFieldNValue & "BEmail=@BEmail, "

        AllFieldNValue = AllFieldNValue & "BeingSponsored=@BeingSponsored, "
        AllFieldNValue = AllFieldNValue & "SponsorName=@SponsorName, "

        AllFieldNValue = AllFieldNValue & "GFamilyName=@GFamilyName, "
        AllFieldNValue = AllFieldNValue & "GGivenName=@GGivenName, "

        AllFieldNValue = AllFieldNValue & "GPhone=@GPhone, "
        AllFieldNValue = AllFieldNValue & "GBPhone=@GBPhone, "

        AllFieldNValue = AllFieldNValue & "GEmail=@GEmail, "
        AllFieldNValue = AllFieldNValue & "GBEmail=@GBEmail, "

        AllFieldNValue = AllFieldNValue & "GHome=@GHome, "
        AllFieldNValue = AllFieldNValue & "GStreet=@GStreet, "
        AllFieldNValue = AllFieldNValue & "GSangkat=@GSangkat, "

        AllFieldNValue = AllFieldNValue & "CReasonForPreferredCourse=@CReasonForPreferredCourse, "
        AllFieldNValue = AllFieldNValue & "CPreferredGEP=@CPreferredGEP, "
        AllFieldNValue = AllFieldNValue & "CPreferredEAP=@CPreferredEAP, "
        AllFieldNValue = AllFieldNValue & "CPreferredBEP=@CPreferredBEP, "
        AllFieldNValue = AllFieldNValue & "CPreferredIELTSPrep=@CPreferredIELTSPrep, "

        AllFieldNValue = AllFieldNValue & "EmgFamilyName=@EmgFamilyName, "
        AllFieldNValue = AllFieldNValue & "EmgGivenName=@EmgGivenName, "
        AllFieldNValue = AllFieldNValue & "EmgPhone=@EmgPhone, "
        AllFieldNValue = AllFieldNValue & "EmgBPhone=@EmgBPhone "


        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim adapter As New SqlDataAdapter
        cn.ConnectionString = DalConnection_app.IOSConnectionString

        cmd.CommandText = " UPDATE tblContact SET " & AllFieldNValue & " Where ContactID=" & Contact.ContactID
        cmd.Connection = cn 'assign the connection

        With Contact
            cmd.Parameters.Add("@ContactID", SqlDbType.Int).Value = .ContactID
            'cmd.Parameters.Add("@FamilyName", SqlDbType.Char).Value = .FamilyName
            'cmd.Parameters.Add("@GivenName", SqlDbType.Char).Value = .GivenName
            'cmd.Parameters.Add("@Sex", SqlDbType.Char).Value = .Sex
            'cmd.Parameters.Add("@DOB", SqlDbType.Date).Value = .DOB
            'cmd.Parameters.Add("@Phone", SqlDbType.Char).Value = .Phone
            'cmd.Parameters.Add("@Email", SqlDbType.Char).Value = .Email
            cmd.Parameters.Add("@Home", SqlDbType.Char).Value = .Home
            cmd.Parameters.Add("@Street", SqlDbType.Char).Value = .Street

            'cmd.Parameters.Add("@SangKat", SqlDbType.Int).Value = .SangKat
            cmd.Parameters.Add("@WorkPlace", SqlDbType.Char).Value = .WorkPlace
            cmd.Parameters.Add("@School", SqlDbType.Char).Value = .School
            'cmd.Parameters.Add("@Comments", SqlDbType.Char).Value = .Comments
            cmd.Parameters.Add("@EditedDate", SqlDbType.Date).Value = .EditedDate
            cmd.Parameters.Add("@EditedBy", SqlDbType.Char).Value = .EditedBy
            'cmd.Parameters.Add("@Deleted", SqlDbType.Bit).Value = .Deleted
            cmd.Parameters.Add("@DeletedDate", SqlDbType.Date).Value = .DeletedDate
            'cmd.Parameters.Add("@Title", SqlDbType.Char).Value = .Title
            'cmd.Parameters.Add("@Nationality", SqlDbType.Char).Value = .Nationality
            cmd.Parameters.Add("@EdGrade", SqlDbType.Char).Value = .EdGrade
            cmd.Parameters.Add("@EdPrvEnglishSchool", SqlDbType.Char).Value = .EdPrvEnglishSchool
            cmd.Parameters.Add("@EdEnglishLevel", SqlDbType.Char).Value = .EdEnglishLevel
            cmd.Parameters.Add("@EdTestIELTS", SqlDbType.Bit).Value = .EdTestIELTS
            cmd.Parameters.Add("@EdTestTOEFL", SqlDbType.Bit).Value = .EdTestTOEFL
            cmd.Parameters.Add("@EdYears", SqlDbType.Char).Value = .EdYears
            cmd.Parameters.Add("@WPosition", SqlDbType.Char).Value = .WPosition

            cmd.Parameters.Add("@BPhone", SqlDbType.Char).Value = .BPhone
            cmd.Parameters.Add("@BEmail", SqlDbType.Char).Value = .BEmail

            cmd.Parameters.Add("@BeingSponsored", SqlDbType.Bit).Value = .BeingSponsored
            cmd.Parameters.Add("@SponsorName", SqlDbType.Char).Value = .SponsorName

            cmd.Parameters.Add("@GFamilyName", SqlDbType.Char).Value = .GFamilyName
            cmd.Parameters.Add("@GGivenName", SqlDbType.Char).Value = .GGivenName

            cmd.Parameters.Add("@GPhone", SqlDbType.Char).Value = .GPhone
            cmd.Parameters.Add("@GBPhone", SqlDbType.Char).Value = .GBPhone

            cmd.Parameters.Add("@GEmail", SqlDbType.Char).Value = .GEmail
            cmd.Parameters.Add("@GBEmail", SqlDbType.Char).Value = .GBEmail

            cmd.Parameters.Add("@GHome", SqlDbType.Char).Value = .GHome
            cmd.Parameters.Add("@GStreet", SqlDbType.Char).Value = .GStreet
            cmd.Parameters.Add("@GSangkat", SqlDbType.Int).Value = .GSangkat

            cmd.Parameters.Add("@CReasonForPreferredCourse", SqlDbType.Char).Value = .CReasonForPreferredCourse
            cmd.Parameters.Add("@CPreferredGEP", SqlDbType.Bit).Value = .CPreferredGEP
            cmd.Parameters.Add("@CPreferredEAP", SqlDbType.Bit).Value = .CPreferredEAP
            cmd.Parameters.Add("@CPreferredBEP", SqlDbType.Bit).Value = .CPreferredBEP
            cmd.Parameters.Add("@CPreferredIELTSPrep", SqlDbType.Bit).Value = .CPreferredIELTSPrep

            cmd.Parameters.Add("@EmgFamilyName", SqlDbType.Char).Value = .EmgFamilyName
            cmd.Parameters.Add("@EmgGivenName", SqlDbType.Char).Value = .EmgGivenName
            cmd.Parameters.Add("@EmgPhone", SqlDbType.Char).Value = .EmgPhone
            cmd.Parameters.Add("@EmgBPhone", SqlDbType.Char).Value = .EmgBPhone

        End With

        'execute the command
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()


    End Sub

    Public Function AdvanceSearchContact(ByVal Contact As ClContact_app, ByVal FieldParamet As Integer, ByVal OptionCode As Integer, ByVal Deleted As Boolean) As DataSet
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim adapter As New SqlDataAdapter
        Dim ds As New DataSet
        'Dim tTestTaker As tblTestTaker = New tblTestTaker
        Dim BalGl As New BalGlobal_app

        If FieldParamet = 0 Then        'Condition for field TestID
            'query from tblContact
            Dim DSContact As DataSet = BalGl.getDataFromTable("tblContact", "ContactID, Title, FamilyName, GivenName, Sex, DOB, Phone, GuardianPhone, Email, Position", "ContactID", "Where (Deleted=" & Deleted & ") and (ContactID=" & Contact.ContactID & ")", "ASC")
            Return DSContact
        ElseIf FieldParamet = 1 Then    'Condition for field GivenName

            If OptionCode = 1 Then          'Condition for Partial
                Dim DSContact As DataSet = BalGl.getDataFromTable("tblContact", "ContactID, Title, FamilyName, GivenName, Sex, DOB, Phone, GuardianPhone, Email, Position", "GivenName", "Where (Deleted=" & Deleted & ") and (GivenName like N'%" & Contact.GivenName & "%')", "ASC")
                Return DSContact
            ElseIf OptionCode = 2 Then      'Condition for StartPartial
                'Search stu by givenName-----------------------
                Dim DSContact As DataSet = BalGl.getDataFromTable("tblContact", "ContactID, Title, FamilyName, GivenName, Sex, DOB, Phone, GuardianPhone, Email, Position", "GivenName", "Where (Deleted=" & Deleted & ") and (GivenName like N'" & Contact.GivenName & "%')", "ASC")
                Return DSContact

            ElseIf OptionCode = 3 Then      'Condition for EndPartial
                Dim DSContact As DataSet = BalGl.getDataFromTable("tblContact", "ContactID, Title, FamilyName, GivenName, Sex, DOB, Phone, GuardianPhone, Email, Position", "GivenName", "Where (Deleted=" & Deleted & ") and (GivenName like N'%" & Contact.GivenName & "')", "ASC")
                Return DSContact

            Else                            'Condition for Whole
                Dim DSContact As DataSet = BalGl.getDataFromTable("tblContact", "ContactID, Title, FamilyName, GivenName, Sex, DOB, Phone, GuardianPhone, Email, Position", "GivenName", "Where (Deleted=" & Deleted & ") and (GivenName ='" & Contact.GivenName & "')", "ASC")
                Return DSContact
            End If


            'End search------------------------------------------
        ElseIf FieldParamet = 2 Then     'Condition for field FamilyName
            If OptionCode = 1 Then
                Dim DSContact As DataSet = BalGl.getDataFromTable("tblContact", "ContactID, Title, FamilyName, GivenName, Sex, DOB, Phone, GuardianPhone, Email, Position", "FamilyName", "Where (Deleted=" & Deleted & ") and (FamilyName like N'%" & Contact.FamilyName & "%')", "ASC")
                Return DSContact

            ElseIf OptionCode = 2 Then
                Dim DSContact As DataSet = BalGl.getDataFromTable("tblContact", "ContactID, Title, FamilyName, GivenName, Sex, DOB, Phone, GuardianPhone, Email, Position", "FamilyName", "Where (Deleted=" & Deleted & ") and (FamilyName like N'" & Contact.FamilyName & "%')", "ASC")
                Return DSContact

            ElseIf OptionCode = 3 Then
                Dim DSContact As DataSet = BalGl.getDataFromTable("tblContact", "ContactID, Title, FamilyName, GivenName, Sex, DOB, Phone, GuardianPhone, Email, Position", "FamilyName", "Where (Deleted=" & Deleted & ") and (FamilyName like N'%" & Contact.FamilyName & "')", "ASC")
                Return DSContact


            Else
                Dim DSContact As DataSet = BalGl.getDataFromTable("tblContact", "ContactID, Title, FamilyName, GivenName, Sex, DOB, Phone, GuardianPhone, Email, Position", "FamilyName", "Where (Deleted=" & Deleted & ") and (FamilyName = '" & Contact.FamilyName & "')", "ASC")
                Return DSContact


            End If


        ElseIf FieldParamet = 3 Then     'Condition for field Email
            If OptionCode = 1 Then
                Dim DSContact As DataSet = BalGl.getDataFromTable("tblContact", "ContactID, Title, FamilyName, GivenName, Sex, DOB, Phone, GuardianPhone, Email, Position", "Email", "Where (Deleted=" & Deleted & ") and (Email like N'%" & Contact.Email & "%')", "ASC")
                Return DSContact


            ElseIf OptionCode = 2 Then
                'Search stu by FamilyName-----------------------
                Dim DSContact As DataSet = BalGl.getDataFromTable("tblContact", "ContactID, Title, FamilyName, GivenName, Sex, DOB, Phone, GuardianPhone, Email, Position", "Email", "Where (Deleted=" & Deleted & ") and (Email like N'" & Contact.Email & "%')", "ASC")
                Return DSContact

            ElseIf OptionCode = 3 Then
                Dim DSContact As DataSet = BalGl.getDataFromTable("tblContact", "ContactID, Title, FamilyName, GivenName, Sex, DOB, Phone, GuardianPhone, Email, Position", "Email", "Where (Deleted=" & Deleted & ") and (Email like N'" & Contact.Email & "%')", "ASC")
                Return DSContact


            Else
                Dim DSContact As DataSet = BalGl.getDataFromTable("tblContact", "ContactID, Title, FamilyName, GivenName, Sex, DOB, Phone, GuardianPhone, Email, Position", "Email", "Where (Deleted=" & Deleted & ") and (Email = '" & Contact.Email & "')", "ASC")
                Return DSContact

            End If


        ElseIf FieldParamet = 4 Then     'Condition for field FullName
            Dim DSContact As DataSet = BalGl.getDataFromTable("tblContact", "ContactID, Title, FamilyName, GivenName, Sex, DOB, Phone, GuardianPhone, Email, Position", "Email", "Where (Deleted=" & Deleted & ") and ( (FamilyName + ' ' + GivenName = 'MENG SONG') = '" & Contact.FamilyName & "')", "ASC")
            Return DSContact
        Else
            Return Nothing
        End If


    End Function
End Class
