Imports Microsoft.VisualBasic
Imports System

Public Class BalEnrollLog_app
    Public Function GetEnrollLog(ByVal EnrollLog As ClEnrollLog_app) As Data.DataSet
        Return DalEnrollLog_app.Instance.GetEnrollLog(EnrollLog)
    End Function

    Public Sub DeleteEnrollLog(ByVal EnrollLog As ClEnrollLog_app)
        DalEnrollLog_app.Instance.DeleteEnrollLog(EnrollLog)
    End Sub

    Public Sub UpdateEnrollLog(ByVal EnrollLog As ClEnrollLog_app)
        DalEnrollLog_app.Instance.UpdateEnrollLog(EnrollLog)
    End Sub

    Public Sub AddEnrollLog(ByVal EnrollLog As ClEnrollLog_app)
        DalEnrollLog_app.Instance.AddEnrollLog(EnrollLog)
    End Sub
End Class
