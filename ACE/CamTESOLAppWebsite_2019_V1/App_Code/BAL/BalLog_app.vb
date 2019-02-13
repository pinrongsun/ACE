Imports Microsoft.VisualBasic
Imports System

Public Class BalLog_app

    Public Function GetCreditLog(ByVal CreditLog As ClCreditLog_app) As Data.DataSet
        Return DalCreditLog_app.Instance.GetCreditLog(CreditLog)
    End Function

    Public Sub DeleteCreditLog(ByVal CreditLog As ClCreditLog_app)
        DalCreditLog_app.Instance.DeleteCreditLog(CreditLog)
    End Sub

    Public Sub UpdateCreditLog(ByVal CreditLog As ClCreditLog_app)
        DalCreditLog_app.Instance.UpdateCreditLog(CreditLog)
    End Sub

    Public Sub AddCreditLog(ByVal CreditLog As ClCreditLog_app)
        DalCreditLog_app.Instance.AddCreditLog(CreditLog)
    End Sub
End Class
