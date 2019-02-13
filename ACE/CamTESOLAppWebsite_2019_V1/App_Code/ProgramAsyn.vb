Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class ProgramAsyn
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function bookmark(pID As Integer, uID As Integer) As String
        Dim dtUser As DataTable = DalSelectCamTESOL.selectQuery("select UserID from tblUserLogin where UserID=" & uID)
        If dtUser.Rows.Count > 0 Then
            Dim dtP As DataTable = DalSelectCamTESOL.selectQuery("select PresentationID from tblCamTESOLConferenceProgram_AbstractDetail where PresentationID=" & pID)
            If dtP.Rows.Count = 0 Then Return ""
            Dim bm As New ClsBookmark, dalBookmark As New DalBookmark
            Dim dtBookmark As DataTable = DalSelectCamTESOL.selectQuery("select isnull(IsDeleted,0) IsDeleted from tblBookmark where UserID=" & uID & " and PresentationID=" & pID)
            bm.userID = uID
            bm.presentationID = pID
            If dtBookmark.Rows.Count > 0 Then
                If dtBookmark.Rows(0)("IsDeleted").ToString = "True" Then
                    bm.isDeleted = 0
                Else
                    bm.isDeleted = 1
                End If
                dalBookmark.updateBookmark(bm)
            Else
                bm.isDeleted = 0
                bm.createdDate = Now
                dalBookmark.addBookmark(bm)
            End If
        End If
        Return ""
    End Function
    <WebMethod()>
    Public Function checkedTime(id As Integer, isVisible As Integer) As String
        Dim dalProgramMonitor As New DalProgramMonitor
        Return dalProgramMonitor.updateCheckedTime(isVisible, id)
    End Function
    <WebMethod()>
    Public Function cancelProgram(id As Integer, isCancel As Integer) As String
        Dim dalProgramMonitor As New DalProgramMonitor
        Return dalProgramMonitor.updateCancelledProgram(isCancel, id)
    End Function

End Class