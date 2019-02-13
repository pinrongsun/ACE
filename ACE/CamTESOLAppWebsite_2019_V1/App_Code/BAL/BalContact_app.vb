Imports System.Data
Imports Microsoft.VisualBasic
Imports System

Public Class BalContact_app
    Public Sub UpdateContact(ByVal Contact As ClContact_app)
        DalContact_app.Instance.UpdateContact(Contact)
    End Sub
    Public Sub DeleteContact(ByVal Contact As ClContact_app)
        DalContact_app.Instance.DeleteContact(Contact)
    End Sub
    Public Sub AddContact(ByVal Contact As ClContact_app)
        DalContact_app.Instance.AddContact(Contact)
    End Sub
    Public Function GetContact(ByVal Contact As ClContact_app, ByVal Deleted As Boolean) As Data.DataSet
        Return DalContact_app.Instance.GetContact(Contact)
    End Function

    Public Function AdvanceSearchContact(ByVal Contact As ClContact_app, ByVal FieldParamet As Integer, ByVal OptionCode As Integer, ByVal Deleted As Boolean) As Data.DataSet
        Return DalContact_app.Instance.AdvanceSearchContact(Contact, FieldParamet, OptionCode, Deleted)
    End Function

    Public Sub UpdateContactPT(ByVal Contact As ClContact_app)
        DalContact_app.Instance.UpdateContactPT(Contact)
    End Sub

End Class
