Imports Microsoft.VisualBasic
Imports System

Public Class BalEnroll_app
    Public Function GetEnroll(ByVal Enroll As ClEnroll_app) As Data.DataSet
        Return DalEnroll_app.Instance.GetEnroll(Enroll)
    End Function

    Public Sub DeleteEnroll(ByVal Enroll As ClEnroll_app)
        DalEnroll_app.Instance.DeleteEnroll(Enroll)
    End Sub

    Public Sub UpdateEnroll(ByVal Enroll As ClEnroll_app)
        DalEnroll_app.Instance.UpdateEnroll(Enroll)
    End Sub

    Public Sub AddEnroll(ByVal Enroll As ClEnroll_app)
        DalEnroll_app.Instance.AddEnroll(Enroll)
    End Sub



End Class
