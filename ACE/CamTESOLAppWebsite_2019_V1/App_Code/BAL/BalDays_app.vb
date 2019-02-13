Imports Microsoft.VisualBasic
Imports System

Public Class BalDays_app
    Public Function GetDays(ByVal Days As ClDays_app) As Data.DataSet
        Return DalDays_app.Instance.GetDays(Days)
    End Function

    Public Sub DeleteDays(ByVal Days As ClDays_app)
        DalDays_app.Instance.DeleteDays(Days)
    End Sub

    Public Sub UpdateDays(ByVal Days As ClDays_app)
        DalDays_app.Instance.UpdateDays(Days)
    End Sub

    Public Sub AddDays(ByVal Days As ClDays_app)
        DalDays_app.Instance.AddDays(Days)
    End Sub
End Class
