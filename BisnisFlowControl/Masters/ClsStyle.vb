﻿Public Class ClsStyle
    Dim queryStyle As String = "Select * From Style Where IsActive = 1"
#Region "Method Retrieve"
    Public Function RetrieveList(options As String, param As String) As DataTable
        Dim dataAccess = New ClsDataAccess
        Dim dataTable = New DataTable

        Select Case options
            Case "Style Code"
                queryStyle += " AND StyleCode Like '%" & param & "%' Order By StyleCode Asc"
            Case "Style Name"
                queryStyle += " AND StyleName Like '%" & param & "%' Order By StyleCode Asc"
            Case "Specification"
                queryStyle += " AND SpecStyle Like '%" & param & "%' Order By StyleCode Asc"
            Case Else
                queryStyle += " Order By StyleCode Asc"
        End Select

        Try
            dataTable = dataAccess.RetrieveListData(queryStyle)
        Catch ex As Exception
            dataAccess = Nothing
            Throw ex
        End Try

        dataAccess = Nothing
        Return dataTable
    End Function
#End Region

#Region "Method Other"
    Public Function GeneratedAutoNumber() As Integer
        Dim id As Integer = 0
        Dim query As String = "Select max(StyleID) from Style"
        Dim dataAccess = New ClsDataAccess
        Try
            id = dataAccess.GeneratedAutoNumber(query)
        Catch ex As Exception
            dataAccess = Nothing
            Throw ex
        End Try
        dataAccess = Nothing
        Return id
    End Function

    Public Function GeneratedCode() As String
        Dim code As String
        Dim hasil As String
        Dim query As String
        Dim dataAccess = New ClsDataAccess

        code = "STY"
        query = "Select Max(StyleCode) as Code From Style"


        Try
            hasil = dataAccess.GeneratedCode(query, code)
            dataAccess = Nothing
            Return hasil
        Catch ex As Exception
            dataAccess = Nothing
            Throw ex
        End Try
    End Function

    Protected Function ListComboBox() As DataTable
        Dim dataAccess As ClsDataAccess = New ClsDataAccess
        Dim dataTable As DataTable = New DataTable
        Dim query As String
        query = "Select StyleID,StyleName From Style Where IsActive = 1"

        Try
            dataTable = dataAccess.RetrieveListData(query)
        Catch ex As Exception
            Throw ex
        End Try
        dataAccess = Nothing
        Return dataTable
    End Function

    Public Sub ComboBoxStyle(cmb As ComboBox)
        With cmb
            .DataSource = ListComboBox()
            .DisplayMember = "StyleName"
            .ValueMember = "StyleID"
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.ListItems
        End With
    End Sub

    Public Function GetValidateName(styleName As String) As Boolean
        Dim dataAccess = New ClsDataAccess
        Dim dataTable = New DataTable
        Dim query As String = "Select StyleName From Style Where StyleName = '" & styleName & "' AND IsActive = 1"
        Try
            dataTable = dataAccess.RetrieveListData(query)

            If dataTable.Rows.Count > 0 Then
                Throw New Exception("Style Name can't duplicate entry")
            Else
                Return True
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "Method CRUD"
    Public Function InsertData(styleModel As StyleModel, logModel As LogHistoryModel) As Boolean
        Dim dataAccess As ClsDataAccess = New ClsDataAccess
        Dim logBFC As ClsLogHistory = New ClsLogHistory
        Dim queryList As New List(Of String)

        Dim sql As String = "Insert into Style(StyleID,StyleCode,StyleName,SpecStyle,IsActive,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate)Values(" &
                                "'" & styleModel.StyleID & "','" & styleModel.StyleCode & "','" & styleModel.StyleName & "'" &
                                ",'" & styleModel.SpecStyle & "','" & styleModel.IsActive & "','" & styleModel.CreatedBy & "','" & Format(styleModel.CreatedDate, "yyyy-MM-dd HH:mm:ss") & "'" &
                                ",'" & styleModel.UpdatedBy & "','" & Format(styleModel.UpdatedDate, "yyyy-MM-dd HH:mm:ss") & "')"
        queryList.Add(sql)

        queryList.Add(logBFC.SqlInsertLog(logModel))

        Try
            dataAccess.InsertMasterDetail(queryList)
            dataAccess = Nothing
            Return True
        Catch ex As Exception
            dataAccess = Nothing
            Throw ex
        End Try
    End Function

    Public Function UpdateData(styleModel As StyleModel, logModel As LogHistoryModel, options As String) As Boolean
        Dim dataAccess As ClsDataAccess = New ClsDataAccess
        Dim logBFC As ClsLogHistory = New ClsLogHistory
        Dim queryList As New List(Of String)
        Dim query As String

        If options = "Update" Then
            query = "Update Style Set StyleName = '" & styleModel.StyleName & "',SpecStyle = '" & styleModel.StyleName & "'" &
                    ",IsActive = '" & styleModel.IsActive & "',UpdatedBy='" & styleModel.UpdatedBy & "',UpdatedDate = '" & Format(styleModel.UpdatedDate, "yyyy-MM-dd HH:mm:ss") & "'" &
                    " Where StyleID='" & styleModel.StyleID & "'"
            queryList.Add(query)

        Else
            query = "Update Style Set IsActive = '" & styleModel.IsActive & "',UpdatedBy='" & styleModel.UpdatedBy & "'" &
                    ",UpdatedDate = '" & Format(styleModel.UpdatedDate, "yyyy-MM-dd HH:mm:ss") & "' Where StyleID='" & styleModel.StyleID & "'"
            queryList.Add(query)
        End If

        queryList.Add(logBFC.SqlInsertLog(logModel))

        Try
            dataAccess.InsertMasterDetail(queryList)
            dataAccess = Nothing
            Return True
        Catch ex As Exception
            dataAccess = Nothing
            Throw ex
        End Try
    End Function
#End Region
End Class
