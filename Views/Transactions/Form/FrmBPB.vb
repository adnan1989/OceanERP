﻿Imports System.ComponentModel

Public Class FrmBPB

#Region "Declaration"
    Public condition As String
    Public Shared bpbheaderID As Long = 0
    Dim intBaris As Integer
    Dim intPost As Integer
    Dim supplierCode As String = ""
    Dim statusBPB As Int16
    Dim msgError As String = "Error BPB : "
#End Region

#Region "ComboBox"
    Sub ComboBoxPO()
        Dim poBFC As ClsPO = New ClsPO
        Try
            poBFC.ComboBoxPO(cmbPONo)
        Catch ex As Exception
            Throw ex
        Finally
            poBFC = Nothing
        End Try
    End Sub
#End Region

#Region "Grid Detail"
    Sub GridDetail()
        Try
            With dgv
                ' .Columns.Add(0, "BPB Header ID")
                ' .Columns(0).Width = 200
                ' .Columns(0).Visible = False

                .Columns.Add(0, "PI HeaderID")
                ' .Columns(1).Width = 150
                .Columns(0).Visible = False

                .Columns.Add(1, "PI No")
                .Columns(1).ReadOnly = True

                .Columns.Add(2, "PO HeaderID")
                .Columns(2).Width = 150
                .Columns(2).Visible = False

                .Columns.Add(3, "PO.NO")
                .Columns(3).ReadOnly = True

                .Columns.Add(4, "Raw Material ID")
                .Columns(4).Visible = False

                .Columns.Add(5, "Raw Material Name")
                .Columns(5).ReadOnly = True

                .Columns.Add(6, " UnitID")
                .Columns(6).Visible = False

                .Columns.Add(7, " Unit Name")
                .Columns(7).ReadOnly = True

                .Columns.Add(8, "Quantity PO")
                .Columns(8).ReadOnly = True

                .Columns.Add(9, "Received")

                .Columns.Add(10, "Outstanding")
                .Columns(10).ReadOnly = True
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Clear Data"
    Sub ClearAll()
        txtBPBNo.Text = AutoGenerated
        cmbPONo.Text = ""
        txtSupplier.Clear()
        txtDocNo.Clear()
        txtDocType.Clear()
        txtDONO.Focus()
        dgv.Columns.Clear()

        intBaris = 0
        intPost = 0
    End Sub
#End Region

#Region "Check Empty"
    Function CheckEmptyHeader() As Boolean
        Dim check As Boolean = True
        If cmbPONo.SelectedValue = 0 Then
            MsgBoxWarning("PINo not valid")
            cmbPONo.Focus()

        ElseIf Trim(txtSupplier.Text) = "" Then
            MsgBoxWarning("Supplier can't empty,please check your purchase order")
            txtSupplier.Focus()
        ElseIf Trim(txtDoNo.Text) = "" Then
            MsgBoxWarning("Do.Type can't empty")
            txtDONO.Focus()
        ElseIf Trim(txtDocType.Text) = "" Then
            MsgBoxWarning("Doc.Type Customs can't empty")
            txtDocType.Focus()
        ElseIf Trim(txtDocNo.Text) = "" Then
            MsgBoxWarning("Doc.No Customs can't empty")
            txtDocNo.Focus()
        Else
            check = False
        End If
        Return check
    End Function
#End Region

#Region "Set Data"
    Function SetDataHeader() As BPBHeaderModel
        Dim headerModel As BPBHeaderModel = New BPBHeaderModel
        Dim bpbBFC As ClsBPB = New ClsBPB
        Try
            With headerModel
                Select Case condition
                    Case "Create"
                        .BPBHeaderID = bpbBFC.GetBPBHeaderID
                        .POHeaderID = cmbPONo.SelectedValue
                        .BPBNo = bpbBFC.GetBPBNo(supplierCode)
                        .BPBDate = Format(dtBPBDate.Value, "yyyy-MM-dd")
                        .InfactDate = Format(dtInFactory.Value, "yyyy-MM-dd")
                        txtDONO.Text = .DONo
                        txtDocType.Text = .DocTypeCustoms
                        txtDocNo.Text = .DocNoCustoms
                        .DocRegistrationDate = Format(dtDocDate.Value, "yyyy-MM-dd")
                        .Status = statusBPB
                        .CreatedBy = userID
                        .CreatedDate = DateTime.Now
                        .UpdatedBy = userID
                        .UpdatedDate = DateTime.Now
                    Case "Update"
                        .BPBHeaderID = bpbheaderID
                        .POHeaderID = cmbPONo.SelectedValue
                        txtBPBNo.Text = .BPBNo
                        .BPBDate = Format(dtBPBDate.Value, "yyyy-MM-dd")
                        .InfactDate = Format(dtInFactory.Value, "yyyy-MM-dd")
                        txtDONO.Text = .DONo
                        txtDocType.Text = .DocTypeCustoms
                        txtDocNo.Text = .DocNoCustoms
                        .DocRegistrationDate = Format(dtDocDate.Value, "yyyy-MM-dd")
                        .Status = statusBPB
                        .UpdatedBy = userID
                        .UpdatedDate = DateTime.Now
                End Select
            End With
            Return headerModel
        Catch ex As Exception
            Throw ex
        Finally
            bpbBFC = Nothing
        End Try
    End Function
#End Region


#Region "Function"
    Sub CheckPermission()
        Dim roleBFC As ClsPermission = New ClsPermission
        Dim roleModel As RoleDModel = New RoleDModel
        Try
            roleModel = roleBFC.RetrieveDetailsByRoleIDMenuID(roleIDUser, Tag)
            If roleModel.IsCreate = True Then btnSave.Enabled = True
            If roleModel.IsUpdate = True Then btnUpdate.Enabled = True
            If roleModel.IsApprove = True Then btnApprove.Enabled = True
            If roleModel.IsVoid = True Then btnVoid.Enabled = True
        Catch ex As Exception
            Throw ex
        Finally
            roleBFC = Nothing
            roleModel = Nothing
        End Try
    End Sub
    'Sub PrepareByHeaderID()
    '    Dim headerModel As BPBHeaderModel = New BPBHeaderModel
    '    Dim bonOrderBFC As ClsBPB = New ClsBPB
    '    Try
    '        ComboBoxPO()
    '        headerModel = bonOrderBFC.RetrieveByID(bonOrderID)
    '        With headerModel
    '            txtCode.Text = .BonOrderCode
    '            cmbPINo.SelectedValue = .PIHeaderID
    '            txtNoPO.Text = .RefPO
    '            txtCustomer.Text = .CustomerName
    '            txtBrand.Text = .BuyerName
    '            txtStyle.Text = .StyleName
    '            statusBOn = .Status
    '        End With
    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        headerModel = Nothing
    '        bonOrderBFC = Nothing
    '    End Try
    'End Sub

    Sub PreparePOByPOHeaderID()
        Dim poModel As POHeaderModel = New POHeaderModel
        Dim listDetail As List(Of PODetailModel) = New List(Of PODetailModel)
        Dim poBFC As ClsPO = New ClsPO
        Dim poID As Long = cmbPONo.SelectedValue
        Try
            If poID = 0 Then
                ClearAll()
                GridDetail()
                Throw New Exception("No data available")
            End If

            ClearAll()
            poModel = poBFC.RetrieveByID(poID)
            With poModel
                txtSupplier.Text = poModel.SupplierName

            End With

            GridDetail()
            listDetail = poBFC.RetrieveRawMaterialByHeaderID(poID)
            For Each detail In listDetail
                With dgv
                    .Rows.Add()
                    .Item(0, intBaris).Value = detail.PIHeaderID
                    .Item(1, intBaris).Value = detail.PINo
                    .Item(2, intBaris).Value = detail.POHeaderID
                    .Item(3, intBaris).Value = detail.PONo
                    .Item(4, intBaris).Value = detail.RawMaterialID
                    .Item(5, intBaris).Value = detail.RawMaterialName
                    .Item(6, intBaris).Value = detail.UnitID
                    .Item(7, intBaris).Value = detail.UnitName
                    .Item(8, intBaris).Value = detail.Quantity
                    .Item(9, intBaris).Value = 0
                    .Item(10, intBaris).Value = 0

                End With
                intBaris = intBaris + 1
            Next

            listDetail = Nothing
            poBFC = Nothing
        Catch ex As Exception
            listDetail = Nothing
            poBFC = Nothing
            Throw ex
        End Try
    End Sub

    'Sub SumBruto()
    '    Dim subTotal As Double
    '    subTotal = 0
    '    Try
    '        For i As Integer = 0 To dgv.Rows.Count - 2
    '            If Convert.ToString(dgv.Rows(i).Cells(4).Value) = "" And dgv.Rows(i).Cells(0).Value <> "" Then
    '                dgv.Rows(i).Cells(4).Value = 1
    '                subTotal = subTotal + 1
    '                MsgBoxError("Error Bon Order : Must fill numeric")
    '            ElseIf Not IsNumeric(dgv.Rows(i).Cells(4).Value) And dgv.Rows(i).Cells(0).Value <> "" Then
    '                dgv.Rows(i).Cells(4).Value = 1
    '                subTotal = subTotal + 1
    '                MsgBoxError("Error Bon Order : Must fill numeric")
    '            ElseIf Not IsNumeric(dgv.Rows(i).Cells(4).Value) And dgv.Rows(i).Cells(0).Value = "" Then
    '                dgv.Rows.RemoveAt(i)
    '                'dgv.Rows.Remove(dgv.CurrentRow)
    '                intBaris = intBaris - 1
    '                subTotal = subTotal + 0
    '            ElseIf dgv.Rows(i).Cells(0).Value = "" Then
    '                dgv.Rows.RemoveAt(i)
    '                'dgv.Rows.Remove(dgv.CurrentRow)
    '                intBaris = intBaris - 1
    '                subTotal = subTotal + 0
    '            Else
    '                subTotal = subTotal + Val(dgv.Rows(i).Cells(4).Value)
    '            End If
    '        Next
    '        txtTotBruto.Text = subTotal
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Sub SumNetto()
    '    Dim subTotal As Double
    '    subTotal = 0
    '    Try
    '        For i As Integer = 0 To dgv.Rows.Count - 2
    '            If Convert.ToString(dgv.Rows(i).Cells(5).Value) = "" And dgv.Rows(i).Cells(0).Value <> "" Then
    '                dgv.Rows(i).Cells(5).Value = 1
    '                subTotal = subTotal + 1
    '                MsgBoxError("Error Bon Order : Must fill numeric")
    '            ElseIf Not IsNumeric(dgv.Rows(i).Cells(5).Value) And dgv.Rows(i).Cells(0).Value <> "" Then
    '                dgv.Rows(i).Cells(5).Value = 1
    '                subTotal = subTotal + 1
    '                MsgBoxError("Error Bon Order : Must fill numeric")
    '            ElseIf Not IsNumeric(dgv.Rows(i).Cells(5).Value) And dgv.Rows(i).Cells(0).Value = "" Then
    '                dgv.Rows.RemoveAt(i)
    '                'dgv.Rows.Remove(dgv.CurrentRow)
    '                intBaris = intBaris - 1
    '                subTotal = subTotal + 0
    '            ElseIf dgv.Rows(i).Cells(0).Value = "" Then
    '                dgv.Rows.RemoveAt(i)
    '                'dgv.Rows.Remove(dgv.CurrentRow)
    '                intBaris = intBaris - 1
    '                subTotal = subTotal + 0
    '            Else
    '                subTotal = subTotal + Val(dgv.Rows(i).Cells(5).Value)
    '            End If
    '        Next
    '        txtTotNetto.Text = subTotal
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Sub PreCreateDisplay()
        Try
            ClearAll()
            GridDetail()
            ComboBoxPO()
            CheckPermission()
            btnUpdate.Enabled = False
            btnApprove.Enabled = False
            btnVoid.Enabled = False
            btnPrint.Enabled = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnRawAddList_Click(sender As Object, e As EventArgs) Handles btnRawAddList.Click
        Try
            PreparePOByPOHeaderID()
        Catch ex As Exception
            MsgBoxError("Error  : " + ex.Message)
        End Try
    End Sub

    Private Sub dgv_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgv.RowStateChanged
        intPost = e.Row.Index
    End Sub


#End Region
#Region "Other"


    Private Sub dgv_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgv.KeyPress
        If e.KeyChar = Chr(27) Then 'ESC
            dgv.Rows.Remove(dgv.CurrentRow)

        End If
    End Sub


    Private Sub FrmBPB_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Select Case condition
                Case "Create"
                    PreCreateDisplay()
                Case "Update"
                    ' PreUpdateDisplay()
            End Select
        Catch ex As Exception
            MsgBoxError("Error : " + ex.Message)
        End Try
    End Sub
#End Region


End Class

