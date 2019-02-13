Imports System
Imports System.IO
Imports System.Security.Cryptography

Public Class DalEncrypt_app
    'private const string KEY = "<random value goes here>";

    'public static string EncryptAndHash(this string value)
    '{
    '    MACTripleDES des = new MACTripleDES();
    '    MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
    '    des.Key = md5.ComputeHash(Encoding.UTF8.GetBytes(KEY));
    '    string encrypted = Convert.ToBase64String(des.ComputeHash(Encoding.UTF8.GetBytes(value))) + '-' + Convert.ToBase64String(Encoding.UTF8.GetBytes(value));

    '    return HttpUtility.UrlEncode(encrypted);
    '}

    '/// <summary>
    '/// Returns null if string has been modified since encryption
    '/// </summary>
    '/// <param name="encoded"></param>
    '/// <returns></returns>
    'public static string DecryptWithHash(this string encoded)
    '{
    '    MACTripleDES des = new MACTripleDES();
    '    MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
    '    des.Key = md5.ComputeHash(Encoding.UTF8.GetBytes(KEY));

    '    string decoded = HttpUtility.UrlDecode(encoded);
    '    // in the act of url encoding and decoding, plus (valid base64 value) gets replaced with space (invalid base64 value). this reverses that.
    '    decoded = decoded.Replace(" ", "+");
    '    string value = Encoding.UTF8.GetString(Convert.FromBase64String(decoded.Split('-')[1]));
    '    string savedHash = Encoding.UTF8.GetString(Convert.FromBase64String(decoded.Split('-')[0]));
    '    string calculatedHash = Encoding.UTF8.GetString(des.ComputeHash(Encoding.UTF8.GetBytes(value)));

    '    if (savedHash != calculatedHash) return null;

    '    return value;
    '}

    Shared Function EnscriptSpam(ByVal Spam As String) As String
        Try
            Spam = Spam.Replace("0", "qpG")
            Spam = Spam.Replace("1", "MTc")
            Spam = Spam.Replace("2", "xJZ")
            Spam = Spam.Replace("3", "E)a")
            Spam = Spam.Replace("4", "bui")
            Spam = Spam.Replace("5", "LOd")
            Spam = Spam.Replace("6", "fnS")
            Spam = Spam.Replace("7", "([;")
            Spam = Spam.Replace("8", ":],")
            Spam = Spam.Replace("9", "*{<")
            Spam = Spam.Replace(".", ">?-")
            Spam = Spam.Replace("@", "=%k")
            Spam = Spam.Replace("h", "v#_")
            Spam = Spam.Replace("r", "+!$")
            Return Spam
        Catch ex As Exception
            Return ""
        End Try

    End Function
    Shared Function DescriptSpam(ByVal Spam As String) As String
        Try
            Spam = Spam.Replace("qpG", "0")
            Spam = Spam.Replace("MTc", "1")
            Spam = Spam.Replace("xJZ", "2")
            Spam = Spam.Replace("E)a", "3")
            Spam = Spam.Replace("bui", "4")
            Spam = Spam.Replace("LOd", "5")
            Spam = Spam.Replace("fnS", "6")
            Spam = Spam.Replace("([;", "7")
            Spam = Spam.Replace(":],", "8")
            Spam = Spam.Replace("*{<", "9")
            Spam = Spam.Replace(">?-", ".")
            Spam = Spam.Replace("=%k", "@")
            Spam = Spam.Replace("v#_", "h")
            Spam = Spam.Replace("+!$", "r")
            Return Spam
        Catch ex As Exception
            Return ""
        End Try

    End Function

End Class
