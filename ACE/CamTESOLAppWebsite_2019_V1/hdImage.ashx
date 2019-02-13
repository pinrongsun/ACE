
<%@ WebHandler Language="VB" Class="hdImage" %>

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Web
Imports System.Configuration

Public Class hdImage : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        '// Set up the response settings
        context.Response.ContentType = "image/jpeg"
        context.Response.Cache.SetCacheability(HttpCacheability.Public)
        context.Response.BufferOutput = False

        Dim photoId As Integer = -1
        Dim stream As Stream = Nothing

        If (IsNothing(context.Request.QueryString("PhotoID")) = False AndAlso
            context.Request.QueryString("PhotoID") <> "") Then
            photoId = Convert.ToInt32(context.Request.QueryString("PhotoID"))
            'stream = GetPhoto(photoId)
            Dim strDefaultFtpFilePath As String = DalConnection_app.ftpServer & "/" & CStr(photoId) & ".jpg"
            stream = FtpHelper_app.GetImageStreamFromFtp(strDefaultFtpFilePath)
        End If
        If IsNothing(stream) Then
            Dim strDefaultFtpFilePath As String = DalConnection_app.ftpServer & "/no_photo.gif"
            stream = FtpHelper_app.GetImageStreamFromFtp(strDefaultFtpFilePath)
        End If
        '---------
        Try
            Dim MyImage As System.Drawing.Image = System.Drawing.Image.FromStream(stream)
                        
            MyImage.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg)            
        Catch ex As Exception

        End Try
        'MyImage.Dispose()
        '--------------
        'Const buffersize As Integer = 1024 * 8
        'Dim bytes(1024*8) As Byte

        'Dim buffer As Byte() = bytes
       
        'Dim count As Integer = stream.Read(buffer, 0, buffersize)
        'Do While (count > 0)
        '    context.Response.OutputStream.Write(buffer, 0, count)
        '    count = stream.Read(buffer, 0, buffersize)
        'Loop
       
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property
    
  

   
    

End Class