﻿Public Class BankModel
    Inherits CoreModel

    Private xBankID As Integer
    Public Property BankID() As Integer
        Get
            Return xBankID
        End Get
        Set(ByVal value As Integer)
            xBankID = value
        End Set
    End Property
    Private xBankCode As String
    Public Property BankCode() As String
        Get
            Return xBankCode
        End Get
        Set(ByVal value As String)
            xBankCode = value
        End Set
    End Property
    Private xName As String
    Public Property Name() As String
        Get
            Return xName
        End Get
        Set(ByVal value As String)
            xName = value
        End Set
    End Property
    Private xSwiftCode As String
    Public Property SwiftCode() As String
        Get
            Return xSwiftCode
        End Get
        Set(ByVal value As String)
            xSwiftCode = value
        End Set
    End Property
End Class
