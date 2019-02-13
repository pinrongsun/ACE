Imports Microsoft.VisualBasic

Public Class ClPlacementTest
    Private pTestID As Integer
    Public Property TestID As Integer
        Get
            Return pTestID
        End Get
        Set(ByVal value As Integer)
            pTestID = value
        End Set
    End Property
End Class
