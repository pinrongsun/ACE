Imports Microsoft.VisualBasic

Public Class ClContact_app
    Public Property ContactID As Integer
    Public Property FamilyName As String
    Public Property GivenName As String
    Public Property Sex As String
    Public Property DOB As Date
    Public Property Phone As String
    Public Property Email As String
    Public Property Home As String
    Public Property Street As String
    Public Property SangKat As Integer

    Public Property Province As String
    Public Property Khan As String
    Public Property SangKatName As String

    Public Property WorkPlace As String
    Public Property WHome As String
    Public Property WStreet As String
    Public Property School As String
    Public Property Comments As String
    Public Property CreatedDate As Date
    Public Property CreatedBy As String
    Public Property EditedDate As Date
    Public Property EditedBy As String
    Public Property Deleted As Boolean
    Public Property DeletedDate As Date
    Public Property DeletedBy As String
    Public Property Title As String
    Public Property Nationality As String
    Public Property Photo As String

    Public Property EdGrade As String
    Public Property EdPrvEnglishSchool As String
    Public Property EdEnglishLevel As String
    Public Property EdTestIELTS As Boolean
    Public Property EdTestTOEFL As Boolean
    Public Property EdYears As String
    Public Property WPosition As String


    Public Property BPhone As String
    Public Property BEmail As String

    Public Property BeingSponsored As Boolean
    Public Property SponsorName As String

    Public Property GFamilyName As String
    Public Property GGivenName As String
    Public Property GRelationship As String
    Public Property GPhone As String
    Public Property GBPhone As String
    Public Property GEmail As String
    Public Property GBEmail As String
    Public Property GHome As String
    Public Property GStreet As String
    Public Property GSangkat As Integer

    Public Property GProvince As String
    Public Property GKhan As String
    Public Property GSangKatName As String


    Public Property CPreferredGEP As Boolean
    Public Property CPreferredBEP As Boolean
    Public Property CPreferredEAP As Boolean
    Public Property CPreferredIELTSPrep As Boolean
    Public Property CReasonForPreferredCourse As String

    Public Property EmgFamilyName As String
    Public Property EmgGivenName As String
    Public Property EmgPhone As String
    Public Property EmgBPhone As String


    ''.. additional fields, not store in the DB
    Public Property EnrollID As String
    Public Property ClassDays As String
    Public Property ClassTime As String
    Public Property IsNotify As Boolean

    Public Property ByFriends As Boolean
    Public Property ByNewspaper As Boolean
    Public Property BySchool As Boolean
    Public Property ByFacebook As Boolean
    Public Property ByEvents As Boolean
    Public Property ByRadio As Boolean
    Public Property ByScholarship As Boolean

    Public Property ByOther As Boolean
    Public Property ByOtherText As String


End Class
