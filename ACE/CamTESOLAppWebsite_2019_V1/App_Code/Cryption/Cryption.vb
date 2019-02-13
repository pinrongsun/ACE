Imports System.Collections.Generic
Imports System.Text

Public Class Cryption
    Private Shared _strPassPhrase As String = "phPaS5$R@sU]XDMEW<MADoxbf@$GF|x<}"
    ' can be any string                                              
    Private Shared _strSaltValue As String = "W@StVXuUYkLIUmr&Mnt$#@5241xSZMLXyPph"
    ' can be any string                                               
    Private Shared _strHashAlgorithm As String = "SHA1"
    ' can be "MD5"
    Private Shared _intPasswordIterations As Integer = 2
    ' can be any number
    Private Shared _strVector As String = "#$&*910GajLp7q0o"
    ' must be 16 bytes
    Private Shared _intKeySize As Integer = 256
    ' can be 192 or 128

#Region "Cryption"
    ''' <summary>
    ''' Encrypt text string
    ''' </summary>
    ''' <param name="strPlainText"></param>
    ''' <returns></returns>
    Public Shared Function EncryptString(ByVal strPlainText As String) As String
        Return CryptionHelper.Encrypt(strPlainText, _strPassPhrase, _strSaltValue, _strHashAlgorithm, _intPasswordIterations, _strVector, _intKeySize)
    End Function

    ''' <summary>
    ''' Encrypt text string
    ''' </summary>
    ''' <param name="strEncryptedText"></param>
    ''' <returns></returns>
    Public Shared Function DecryptString(ByVal strEncryptedText As String) As String
        Return CryptionHelper.Decrypt(strEncryptedText, _strPassPhrase, _strSaltValue, _strHashAlgorithm, _intPasswordIterations, _strVector, _intKeySize)
    End Function
#End Region

End Class
