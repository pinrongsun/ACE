﻿Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System


Public Class BalGlobal_app

    Public Function ChangeToDate(ByVal dd_MM_yyyy As String) As Date
        Return DalGlobal_app.Instance.ChangeToDate(dd_MM_yyyy)
    End Function

    Public Function DeleteRecord(TableName As String, Condition As String) As Boolean
        Return DalGlobal_app.Instance.DeleteRecord(TableName, Condition)
    End Function

    Public Function UpdateRecordInTable(ByVal TableName As String, ByVal UpdatingFieldNvalue As String, ByVal Condition As String) As Boolean
        Return DalGlobal_app.Instance.UpdateRecordInTable(TableName, UpdatingFieldNvalue, Condition)
    End Function

    Public Function Seach(ByVal TableName As String, ByVal Field As String, ByVal Keyword As String, ByVal Choice As Integer, ByVal AdditionalCondition As String, ByVal DisplayFields As String) As DataSet
        Return DalGlobal_app.Instance.Seach(TableName, Field, Keyword, Choice, AdditionalCondition, DisplayFields)
    End Function
    Public Function GenerateID(ByVal TableName As String, ByVal Field As String) As Integer
        Return DalGlobal_app.Instance.GenerateID(TableName, Field)
    End Function
    Public Sub UpdateID(ByVal Field As String, ByVal NewID As Integer)
        DalGlobal_app.Instance.UpdateID(Field, NewID)
    End Sub
    Public Sub UpdateValueInTable(ByVal TableName As String, ByVal UpdatingFieldNvalue As String, ByVal Condition As String)
        DalGlobal_app.Instance.UpdateValueInTable(TableName, UpdatingFieldNvalue, Condition)
    End Sub
    Public Function getBoundData(ByVal TableName As String, ByVal DisplayField As String, ByVal ValueField As String, ByVal NumberofRecords As Integer, ByVal Condition As String, ByVal SortOrder As String) As DataSet
        Return DalGlobal_app.Instance.getBoundData(TableName, DisplayField, ValueField, NumberofRecords, Condition, SortOrder)
    End Function
    Public Function getBoundDataFlexibleSortField(ByVal TableName As String, ByVal DisplayField As String, ByVal ValueField As String, ByVal NumberofRecords As Integer, ByVal Condition As String, ByVal SortField As String, ByVal SortOrder As String) As DataSet
        Return DalGlobal_app.Instance.getBoundDataFlexibleSortField(TableName, DisplayField, ValueField, NumberofRecords, Condition, SortField, SortOrder)
    End Function
    Public Function getDataFromTable(ByVal TableName As String, ByVal DisplayFields As String, ByVal SortField As String, ByVal Condition As String, ByVal SortOrder As String) As DataSet
        Return DalGlobal_app.Instance.getDataFromTable(TableName, DisplayFields, SortField, Condition, SortOrder)
    End Function
    Public Function ConvertStringToNumber(ByVal obj As Object) As String
        Return DalGlobal_app.Instance.ConvertStringToNumber(obj)
    End Function
    Public Function Cut_String_into_Array(ByVal MainString As String, ByVal Separator As String) As Array
        Return DalGlobal_app.Instance.Cut_String_into_Array(MainString, Separator)
    End Function
    Public Function AlphabeticSort(ByVal dtTable As DataTable, ByVal columnkey As String, ByVal sortOrder As Integer) As DataTable
        Return DalGlobal_app.Instance.AlphabeticSort(dtTable, columnkey, sortOrder)
    End Function
    Public Function InsertToTable(ByVal TableName As String, ByVal FieldsName As String, ByVal Values As String) As Integer
        Return DalGlobal_app.Instance.InsertToTable(TableName, FieldsName, Values)
    End Function
    Public Function EnscriptSpam(ByVal Spam As String) As String
        Return DalGlobal_app.Instance.EnscriptSpam(Spam)
        'Return Cryption.EncryptString(Spam)
    End Function
    Public Function DescriptSpam(ByVal Spam As String) As String
        Return DalGlobal_app.Instance.DescriptSpam(Spam)
        'Return Cryption.DecryptString(Spam)
    End Function
    Public Sub MySendEmail(ByVal Subject As String, ByVal Body As String, ByVal Recipient As String, ByVal AttachmentPath As String)
        DalGlobal_app.Instance.MySendEmail(Subject, Body, Recipient, AttachmentPath)
    End Sub

    Public Function SendEmailIDP(ByVal Subject As String, ByVal Body As String, ByVal Recipient As String, ByVal HasAttachment As Boolean _
                                 , AttachmentPath As String, FileName As String, CC As Boolean) As Boolean
        Return DalGlobal_app.Instance.SendEMailIDP(Subject, Body, Recipient, HasAttachment, AttachmentPath, FileName, CC)
    End Function

    Public Function DefaultPass(ByVal input As String) As String
        Return DalGlobal_app.Instance.DefaultPass(input)
    End Function

    Public Function GetServerCurrentDate() As DateTime
        Return DalGlobal_app.GetCurrentDate(Nothing)
    End Function

    Public Function ValidPhone(ByVal PhoneNumber As String) As Boolean
        Return DalGlobal_app.Instance.ValidPhone(PhoneNumber)
    End Function

    Public Function ValidEmail(ByVal Email As String) As Boolean
        Return DalGlobal_app.Instance.ValidEmail(Email)
    End Function

    Public Function GetIPAddress() As String
        Return DalGlobal_app.Instance.GetIPAddress()
    End Function

    Public Sub DeleteFromTable(TableName As String, Condition As String)
        DalGlobal_app.Instance.DeleteFromTable(TableName, Condition)
    End Sub
End Class
