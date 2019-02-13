
<%@ WebHandler Language="VB" Class="hdImage" %>

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Web
Imports System.Configuration
Imports System.Net
Imports System.Drawing

Public Class hdImage : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        '// Set up the response settings
        context.Response.ContentType = "image/jpeg"
        context.Response.Cache.SetCacheability(HttpCacheability.Public)
        context.Response.BufferOutput = False

        Dim PhotoUrl As String = ""
        Dim width As Integer = 0
        Dim Height As Integer = 0
        Dim stream As Stream = Nothing

        If (IsNothing(context.Request.QueryString("PhotoUrl")) = False AndAlso
            context.Request.QueryString("PhotoUrl") <> "") Then
            PhotoUrl = context.Request.QueryString("PhotoUrl")
            width = context.Request.QueryString("width")
            Height = context.Request.QueryString("height")
           
            'stream = GetPhoto(photoId)
            'Dim strDefaultFtpFilePath As String = "" 'DalConnection.ftpServer & "/" & CStr(photoId) & ".jpg"
            'stream = FtpHelper.GetImageStreamFromFtp(strDefaultFtpFilePath)
            'strDefaultFtpFilePath = "https://app.acecambodia.org/Upload_s/Student/"
            
            Dim photo_url As String = "" 'strDefaultFtpFilePath & photoId & "/" & profile
            
            photo_url = "http://camtesolapp.acecambodia.org/" & PhotoUrl.Replace("^", "/")
        
            Using wc As New WebClient()
                Try
                    stream = wc.OpenRead(photo_url)
                Catch ex As Exception
                    Try
                       
                        stream = wc.OpenRead(photo_url)
                    Catch ex2 As Exception
                        stream = Nothing
                    End Try
                    
                End Try
                
            
            
            End Using
        End If
        If IsNothing(stream) Then
            'Dim strDefaultFtpFilePath As String = DalConnection_app.ftpServer & "/no_photo.gif"
            'stream = FtpHelper_app.GetImageStreamFromFtp(strDefaultFtpFilePath)
        End If
        '---------
        Try
            Dim MyImage As System.Drawing.Image = System.Drawing.Image.FromStream(stream)
            MyImage = FixedSize(MyImage, width, Height, True)
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
    
  

    Public Function FixedSize(ByVal image As Image, ByVal Width As Integer, ByVal Height As Integer, ByVal needToFill As Boolean) As System.Drawing.Image
        '#Region "много арифметики"
        Dim sourceWidth As Integer = image.Width
        Dim sourceHeight As Integer = image.Height
        Dim sourceX As Integer = 0
        Dim sourceY As Integer = 0
        Dim destX As Double = 0
        Dim destY As Double = 0

        Dim nScale As Double = 0
        Dim nScaleW As Double = 0
        Dim nScaleH As Double = 0

        nScaleW = (CDbl(Width) / CDbl(sourceWidth))
        nScaleH = (CDbl(Height) / CDbl(sourceHeight))
        If Not needToFill Then
            nScale = Math.Min(nScaleH, nScaleW)
        Else
            nScale = Math.Max(nScaleH, nScaleW)
            destY = (Height - sourceHeight * nScale) / 2
            destX = (Width - sourceWidth * nScale) / 2
        End If

        'If nScale > 1 Then
        '    nScale = 1
        'End If

        Dim destWidth As Integer = CInt(Math.Round(sourceWidth * nScale))
        Dim destHeight As Integer = CInt(Math.Round(sourceHeight * nScale))
        '#End Region

        Dim bmPhoto As System.Drawing.Bitmap = Nothing
        Try
            bmPhoto = New System.Drawing.Bitmap(destWidth + CInt(Math.Round(2 * destX)), destHeight + CInt(Math.Round(2 * destY)))
        Catch ex As Exception
            Throw New ApplicationException(String.Format("destWidth:{0}, destX:{1}, destHeight:{2}, desxtY:{3}, Width:{4}, Height:{5}", destWidth, destX, destHeight, destY, Width,
                Height), ex)
        End Try
        Using grPhoto As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(bmPhoto)
            'grPhoto.InterpolationMode = _interpolationMode
            'grPhoto.CompositingQuality = _compositingQuality
            'grPhoto.SmoothingMode = _smoothingMode

            grPhoto.InterpolationMode = Drawing2D.InterpolationMode.Default
            grPhoto.CompositingQuality = Drawing2D.CompositingQuality.Default
            grPhoto.SmoothingMode = Drawing2D.SmoothingMode.Default


            Dim [to] As Rectangle = New System.Drawing.Rectangle(CInt(Math.Round(destX)), CInt(Math.Round(destY)), destWidth, destHeight)
            Dim from As Rectangle = New System.Drawing.Rectangle(sourceX, sourceY, sourceWidth, sourceHeight)
            'Console.WriteLine("From: " + from.ToString());
            'Console.WriteLine("To: " + to.ToString());
            grPhoto.DrawImage(image, [to], from, System.Drawing.GraphicsUnit.Pixel)

            Return bmPhoto
        End Using
    End Function
    

End Class