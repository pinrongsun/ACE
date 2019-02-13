Imports Microsoft.VisualBasic
Imports System

Public Class BalCourses_app
    Public Function GetCourses(ByVal Courses As ClCourses_app) As Data.DataSet
        Return DalCourses_app.Instance.GetCourses(Courses)
    End Function

    Public Sub DeleteCourses(ByVal Courses As ClCourses_app)
        DalCourses_app.Instance.DeleteCourses(Courses)
    End Sub

    Public Sub UpdateCourses(ByVal Courses As ClCourses_app)
        DalCourses_app.Instance.UpdateCourses(Courses)
    End Sub

    Public Sub AddCourses(ByVal Courses As ClCourses_app)
        DalCourses_app.Instance.AddCourses(Courses)
    End Sub
End Class
