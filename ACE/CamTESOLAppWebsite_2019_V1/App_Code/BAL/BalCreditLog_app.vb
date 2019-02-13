Imports Microsoft.VisualBasic
Imports System.Data

Public Class BalCreditLog_app
    Public Sub AddCreditLog(ByVal CreditLog As ClCreditLog_app)
        DalCreditLog_app.Instance.AddCreditLog(CreditLog)
    End Sub
    Public Function GetCreditLog(ByVal CreditLog As ClCreditLog_app) As DataSet
        Return DalCreditLog_app.Instance.GetCreditLog(CreditLog)
    End Function
    Public Sub DeleteCreditLog(ByVal CreditLog As ClCreditLog_app)
        DalCreditLog_app.Instance.DeleteCreditLog(CreditLog)
    End Sub
    Public Sub UpdateClass(ByVal CreditLog As ClCreditLog_app)
        DalCreditLog_app.Instance.UpdateCreditLog(CreditLog)
    End Sub
End Class
