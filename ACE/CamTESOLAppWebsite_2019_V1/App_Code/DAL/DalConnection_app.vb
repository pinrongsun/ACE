Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DalConnection_app

    Public Shared ftpServer As String = "ftp://192.168.3.2"
    'Public Shared ftpServer As String = "ftp://192.168.1.15"
    Public Shared ftpUserName As String = "EDBUser"
    Public Shared ftpPassword As String = "pass$$$$"

    Public Shared DBUser As String = "sa"
    Public Shared DBPassword As String = "ACEidp.99"


    Public Shared DBDatabase As String = "CamTESOLAppWebsite"
    'Public Shared DBDatabase As String = "EMagazine"

    ''..Real database on Sothea PC
    'Public Shared DBServer As String = "192.168.1.3\EDB2"
    'Public Shared DBServer As String = "192.168.1.15"

    'Public Shared DBServer As String = "202.79.26.165"
    'Public Shared DBServer As String = "IDP_WKS015_02\IDP"

    ' ''..Trial database on Sothea PC
    'Public Shared DBServer As String = "192.168.0.224\EDB"
    'Public Shared DBServer As String = "."
    Public Shared DBServer As String = "114.134.189.212"
    'Public Shared DBServer As String = "192.168.3.3"
    Public Shared IOSConnectionString As String = "Data Source=" & DBServer & ";Initial Catalog=" & DBDatabase & ";Min Pool Size=5;Max Pool Size=60000;Connect Timeout=60;User Id=" & DBUser & ";Password=" & DBPassword & ";"

    Public Shared EDBConnectionString As String = "Data Source=" & DBServer & ";Initial Catalog=CamTESOL;Min Pool Size=5;Max Pool Size=60000;Connect Timeout=60;User Id=" & DBUser & ";Password=" & DBPassword & ";"





    ' ''Public Shared EDBConnectionString As String = "Data Source=192.168.0.6\EDB;Initial Catalog=EDB;User Id=sa;Password=pass$1234;"




End Class
