Imports Microsoft.VisualBasic
Imports System

Public Class BalClasses_app
    Public Function GetClasses(ByVal Classes As ClClasses_app) As Data.DataSet
        Return DalClasses_app.Instance.GetClasses(Classes)
    End Function

    Public Sub DeleteClasses(ByVal Classes As ClClasses_app)
        DalClasses_app.Instance.DeleteClasses(Classes)
    End Sub

    Public Sub UpdateClasses(ByVal Classes As ClClasses_app)
        DalClasses_app.Instance.UpdateClasses(Classes)
    End Sub

    Public Sub AddClasses(ByVal Classes As ClClasses_app)
        DalClasses_app.Instance.AddClasses(Classes)
    End Sub

End Class
