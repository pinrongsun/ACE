Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DalConnection

    Public Shared DBUser As String = "sa"
    Public Shared DBPassword As String = "ACEidp.99"
    'Public Shared DBPassword As String = "S@123456"

    Public Shared DBDatabase As String = "CamTESOL"
    'Public Shared DBServer As String = "."
    'Public Shared DBServer As String = "DESKTOP-LKAA4K6"
    Public Shared DBServer As String = "114.134.189.212"

    Public Shared EDBConnectionString As String = "Data Source=" & DBServer & ";Initial Catalog=" & DBDatabase & ";Min Pool Size=5;Max Pool Size=60000;Connect Timeout=60;User Id=" & DBUser & ";Password=" & DBPassword & ";"
End Class
