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
    Dim PoID As String = ""
    Dim rawmatrialID As Integer
    Dim restQtyBPB As Integer = 0
#End Region

#Region "ComboBox"
    Public Sub ComboBoxPO()
        Dim poBFC As ClsPO = New ClsPO
        Try
            poBFC.ComboBoxPO(cmbPONo)
        Catch ex As Exception
            Throw ex
        Finally
            poBFC = Nothing
        End Try
    End Sub

    Sub ComboBoxRaw(cmb As ComboBox, headerID As Long)
        Dim poBFC As ClsPO = New ClsPO

        Try
            poBFC.ComboBoxRaw(cmbRawCode, headerID)
        Catch ex As Exception
            Throw ex
        Finally
            poBFC = Nothing
        End Try
    End Sub

    Sub ComboBoxPI(cmb As ComboBox, headerID As Long)
        Dim poBFC As ClsPO = New ClsPO

        Try
            poBFC.ComboBoxPI(cmbPI, headerID)
        Catch ex As Exception
            Throw ex
        Finally
            poBFC = Nothing
        End Try
    End Sub
    Sub ComboBoxUnit()
        Dim unitBFC As ClsUnit = New ClsUnit
        unitBFC.ComboBoxUnit(cmbUnit)
    End Sub
    Sub RetrieveSupplier()
        Dim poBFC As ClsPO = New ClsPO
        Dim poModel As POHeaderModel = New POHeaderModel
        Dim obj As Integer = cmbPONo.SelectedValue
        If obj > 0 Then
            poModel = poBFC.RetrieveByID(obj)
            With poModel
                txtSupplier.Text = .SupplierName
                supplierCode = .SupplierCode

            End With
        Else
            MsgBoxError("PO not valid")
        End If
    End Sub
    Sub RetrieveQtyPO()
        Dim dataTable As DataTable = New DataTable
        Dim poBFC As ClsPO = New ClsPO
        Dim poModel As PODetailModel = New PODetailModel

        Try
            Dim rawmatrialID = cmbRawCode.SelectedValue
            Dim obj As Integer = cmbPONo.SelectedValue
            If obj > 0 Then
                poModel = poBFC.RetrieveByDetailRaw(obj, rawmatrialID)
                With poModel
                    txtQtyPO.Text = .Quantity
                End With
            Else
                MsgBoxError("Raw Code not valid")
            End If
            poModel = Nothing

        Catch ex As Exception

            Throw ex
        End Try
    End Sub

#End Region

#Region "Grid Detail"
    Sub GridDetail()
        Try
            With dgv

                ' Columns.Add(0, "BPB Header ID")
                ' .Columns(0).Width = 200
                ' .Columns(0).Visible = False



                '.Columns.Add(2, "PI HeaderID")
                '.Columns(2).Width = 150
                '.Columns(2).Visible = False

                '.Columns.Add(3, "PI.NO")
                '.Columns(3).ReadOnly = True

                .Columns.Add(0, "ID")
                .Columns(0).Visible = False
                .Columns(0).Width = 50

                .Columns.Add(1, "Raw Material Name")
                .Columns(1).Width = 150

                .Columns.Add(2, "Quantity Received")
                .Columns(2).Width = 150

                .Columns.Add(3, "Quantity Packaging")
                .Columns(3).Width = 150

                .Columns.Add(4, " UnitID")
                .Columns(4).Visible = False

                .Columns.Add(5, " Unit Name")

                .Columns.Add(6, "Outstanding")
                .Columns(6).Width = 150
                .Columns(6).Visible = False

                .Columns.Add(7, "POID")
                .Columns(7).Width = 150
                .Columns(7).Visible = False

                .Columns.Add(8, "PO No")
                .Columns(8).Visible = False

                .Columns.Add(9, "PI ID")
                .Columns(9).Width = 150
                .Columns(9).Visible = False

                .Columns.Add(10, "PI No")
                .Columns(10).Visible = False

                .Columns.Add(11, "BPB ID")
                .Columns(11).Visible = False

                .Columns.Add(12, "Date BPB")
                .Columns(12).Visible = False
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
        txtDONO.Clear()
        txtDONO.Focus()
        dgv.Columns.Clear()
        intBaris = 0
        intPost = 0
    End Sub
    Sub ClearRawMatrial()
        cmbRawCode.Text = ""
        cmbPI.Text = ""
        cmbUnit.Text = ""
        txtQtyPO.Clear()
        TextBox1.Clear()
        txtQtyReceived.Clear()
        txtQuantityPackaging.Clear()
    End Sub
#End Region

#Region "Validation Number"
    Private Sub txtQtyReceived_TextChanged(sender As Object, e As EventArgs) Handles txtQtyReceived.TextChanged
        CheckNumber(txtQtyReceived)
    End Sub
    Private Sub txtQuantityPackaging_TextChanged(sender As Object, e As EventArgs) Handles txtQuantityPackaging.TextChanged
        CheckNumber(txtQuantityPackaging)
    End Sub
#End Region

#Region "Add Grid Detail"
    Sub AddGridDetailRawMatrial()
        With dgv
            .Rows.Add()
            .Item(0, intBaris).Value = cmbRawCode.SelectedValue
            .Item(1, intBaris).Value = cmbRawCode.Text
            .Item(2, intBaris).Value = txtQtyReceived.Text
            .Item(3, intBaris).Value = txtQuantityPackaging.Text
            .Item(4, intBaris).Value = cmbUnit.SelectedValue
            .Item(5, intBaris).Value = cmbUnit.Text
            .Item(6, intBaris).Value = Val(txtQtyPO.Text) - Val(txtQtyReceived.Text)
            .Item(7, intBaris).Value = cmbPONo.SelectedValue
            .Item(8, intBaris).Value = cmbPONo.Text
            If IsDBNull(.Item(9, intBaris).Value) Then
                .Item(9, intBaris).Value = 0
            Else
                .Item(9, intBaris).Value = cmbPI.SelectedValue
            End If
            If IsDBNull(.Item(10, intBaris).Value) Then
                .Item(10, intBaris).Value = 0
            Else
                .Item(10, intBaris).Value = cmbPI.Text
            End If
            '.Item(9, intBaris).Value = cmbPI.SelectedValue
            '.Item(10, intBaris).Value = cmbPI.Text
            .Item(11, intBaris).Value = bpbheaderID
            .Item(12, intBaris).Value = Format(dtBPBDate.Value, "yyyy-MM-dd")
        End With
        intBaris = intBaris + 1
    End Sub
#End Region

#Region "Delete Grid"
    Sub DeleteGridDetailRawMatrial()
        DeleteGrid(dgv, intBaris)
    End Sub

#End Region

#Region "Check Empty"
    Function CheckEmptyHeader() As Boolean
        Dim check As Boolean = True
        If Trim(txtDONO.Text) = "" Then
            MsgBoxWarning("Do.No can't empty")
            txtDONO.Focus()
        ElseIf Trim(txtDocType.Text) = "" Then
            MsgBoxWarning("Doc.Type Customs can't empty")
            txtDocType.Focus()
        ElseIf Trim(txtDocNo.Text) = "" Then
            MsgBoxWarning("Doc.No Customs can't empty")
            txtDocNo.Focus()
        ElseIf cmbPONo.SelectedValue = 0 Then
            MsgBoxWarning("PONo not valid")
            cmbPONo.Focus()
        ElseIf Trim(txtSupplier.Text) = "" Then
            MsgBoxWarning("Supplier can't empty,please check your purchase order")
            txtSupplier.Focus()
        ElseIf dgv.Rows.Count - 1 = 0 Then
            MsgBoxWarning("Detail Raw Material Can't Empty")
            cmbRawCode.Focus()
        Else
            check = False
        End If
        Return check
    End Function
    Function CheckEmptyDetail() As Boolean
        Dim check As Boolean = True
        For i As Integer = 0 To dgv.Rows.Count - 2
            If dgv.Rows(i).Cells(0).Value = "" Then
                MsgBoxError("Transaction not yet completed")
                Exit For
            ElseIf dgv.Rows(i).Cells(2).Value = 0 Then
                MsgBoxError("Receveid can't 0")
                Exit For
            Else
                check = False
            End If
        Next
        Return check
    End Function
#End Region

#Region "Check Available In List"
    Function CheckRawMatrialInList() As Boolean
        Dim poBFC As ClsBPB = New ClsBPB
        Dim status As Boolean
        status = poBFC.CheckRawMatrialBPBInList(dgv, cmbRawCode.SelectedValue)
        Return status
    End Function

#End Region

#Region "Set Data"
    Function SetDataHeader(bpbID As Long, bpbCode As String) As BPBHeaderModel
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
                        .DONo = txtDONO.Text
                        .DocTypeCustoms = txtDocType.Text
                        .DocNoCustoms = txtDocNo.Text
                        .DocRegistrationDate = Format(dtDocDate.Value, "yyyy-MM-dd")
                        .Status = 1
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
                        .DONo = txtDONO.Text
                        .DocTypeCustoms = txtDocType.Text
                        .DocNoCustoms = txtDocNo.Text
                        .DocRegistrationDate = Format(dtDocDate.Value, "yyyy-MM-dd")
                        .Status = 1
                        .UpdatedBy = userID
                        .UpdatedDate = DateTime.Now
                    Case "Approved"
                        .BPBHeaderID = bpbheaderID
                        .BPBNo = txtBPBNo.Text
                        .Status = 2
                        .UpdatedBy = userID
                        .UpdatedDate = DateTime.Now
                    Case "Void"
                        .BPBHeaderID = bpbheaderID
                        .BPBNo = txtBPBNo.Text
                        .Status = 0
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
    Function SetDetail(bpbID As Long) As List(Of BPBDetailModel)
        Dim bpbBFC As ClsBPB = New ClsBPB
        Dim listModel As List(Of BPBDetailModel) = New List(Of BPBDetailModel)
        Try
            listModel = bpbBFC.SetDetailRawMatrial(bpbID, dgv)
            bpbBFC = Nothing
            Return listModel
        Catch ex As Exception
            bpbBFC = Nothing
            Throw ex
        End Try
    End Function
    Function SetDetailStok(bpbID As Long, bpbCode As String) As List(Of StockModel)
        Dim bpbBFC As ClsBPB = New ClsBPB
        Dim listModel As List(Of StockModel) = New List(Of StockModel)
        Try
            listModel = bpbBFC.SetDetailStock(bpbID, bpbCode, dgv)
            bpbBFC = Nothing
            Return listModel
        Catch ex As Exception
            bpbBFC = Nothing
            Throw ex
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
    Sub InsertData()
        Dim bpbBFC As ClsBPB = New ClsBPB
        Dim logBFC As ClsLogHistory = New ClsLogHistory
        Dim bpbCode As String = bpbBFC.GetBPBNo(supplierCode)
        Dim mybpbID As Long = bpbBFC.GetBPBHeaderID
        Dim logDesc As String = "Create new BPB,BPB Order is " + bpbCode

        Try

            If bpbBFC.InsertData(SetDataHeader(mybpbID, bpbCode), SetDetail(mybpbID), SetDetailStok(mybpbID, bpbCode), logBFC.SetLogHistoryTrans(logDesc)) = True Then
                MsgBoxSaved()
                CheckPermission()
                btnPrint.Enabled = True
                btnSave.Enabled = False
                btnUpdate.Enabled = False
                PreCreateDisplay()
            End If
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
    End Sub
    Sub UpdateData()
        Dim bpbBFC As ClsBPB = New ClsBPB
        Dim logBFC As ClsLogHistory = New ClsLogHistory
        Dim logDesc As String = "Update BPB,Where BPB Order Code = " + txtBPBNo.Text
        Try
            If bpbBFC.UpdateData(SetDataHeader(bpbheaderID, txtBPBNo.Text), SetDetail(bpbheaderID), logBFC.SetLogHistoryTrans(logDesc)) = True Then
                MsgBoxUpdated()
                CheckPermission()
                btnPrint.Enabled = True
                btnSave.Enabled = False
                btnUpdate.Enabled = False
            End If
            bpbBFC = Nothing
            logBFC = Nothing
        Catch ex As Exception
            bpbBFC = Nothing
            logBFC = Nothing
            Throw ex
        End Try
    End Sub
    Sub ApprovedData()
        Dim bpbBFC As ClsBPB = New ClsBPB
        Dim logpo As ClsLogHistory = New ClsLogHistory
        Dim logDesc As String = "Approved BPB where BPBNO = " + txtBPBNo.Text
        condition = "Approved"
        Try
            If bpbBFC.UpdateStatusHeader(SetDataHeader(bpbheaderID, txtBPBNo.Text), logpo.SetLogHistoryTrans(logDesc)) Then
                MsgBoxApproved()
                PreCreateDisplay()
            End If
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
    End Sub

    'Sub VoidData()
    '    Dim bpbBFC As ClsBPB = New ClsBPB
    '    Dim logpo As ClsLogHistory = New ClsLogHistory
    '    Dim logDesc As String = "Void BPB where BPBNO = " + txtBPBNo.Text
    '    condition = "Void"
    '    Try
    '        If bpbBFC.UpdateStatusHeader(SetDataHeader(bpbheaderID, txtBPBNo.Text), logpo.SetLogHistoryTrans(logDesc)) Then
    '            MsgBoxVoid()
    '            PreCreateDisplay()
    '        End If
    '    Catch ex As Exception
    '        MsgBoxError(ex.Message)
    '    End Try
    'End Sub
    Sub conditionbutton()
        dgv.Enabled = False
        cmbPI.Enabled = False
        cmbRawCode.Enabled = False
        txtQtyPO.Enabled = False
        txtQtyReceived.Enabled = False
        txtQuantityPackaging.Enabled = False
        cmbUnit.Enabled = False
        btnAddRawToList.Enabled = False
        btnDeletetolist.Enabled = False
    End Sub
    'Sub PrintData()
    '    Try
    '        Dim bpbPrint As ClsPrintOut = New ClsPrintOut
    '        If bpbPrint.PrintOutPu(txtBPBNo.Text) Then
    '            PreCreateDisplay()
    '        Else
    '            MsgBoxError("Failed to print")
    '        End If
    '    Catch ex As Exception
    '        MsgBoxError(ex.Message)
    '    End Try
    'End Sub
    Sub ClearDataGrid()
        dgv.Columns.Clear()
    End Sub
    Sub CheckPermissions()
        Try
            Dim rolepoC As ClsPermission = New ClsPermission
            Dim roleModel As RoleDModel = New RoleDModel
            roleModel = rolepoC.RetrieveDetailsByRoleIDMenuID(roleIDUser, Tag)
            If roleModel.IsCreate = True Then btnSave.Enabled = True
            If roleModel.IsUpdate = True Then btnUpdate.Enabled = True
            If roleModel.IsApprove = True Then btnApprove.Enabled = True
            If roleModel.IsVoid = True Then btnVoid.Enabled = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub PrepareHeaderByID()
        ComboBoxUnit()
        ComboBoxPO()
        cmbPONo.Enabled = False
        Dim headerModel As BPBHeaderModel = New BPBHeaderModel
        Dim bpbBFC As ClsBPB = New ClsBPB
        headerModel = bpbBFC.RetrieveByID(bpbheaderID)
        With headerModel
            txtBPBNo.Text = .BPBNo
            dtBPBDate.Value = .BPBDate
            dtInFactory.Value = .InfactDate
            txtDONO.Text = .DONo
            txtDocType.Text = .DocTypeCustoms
            txtDocNo.Text = .DocNoCustoms
            dtDocDate.Value = .DocRegistrationDate
            cmbPONo.SelectedValue = .POHeaderID
            txtSupplier.Text = .SupplierName
            statusBPB = .Status
        End With
    End Sub
    Sub PrepareRawMatrialByHeaderID()
        Try
            GridDetail()
            Dim listRawMatrial As List(Of BPBDetailModel) = New List(Of BPBDetailModel)
            Dim bpbBFC As ClsBPB = New ClsBPB
            listRawMatrial = bpbBFC.RetrieveRawMaterialBPBByHeaderID(bpbheaderID)
            For Each detail In listRawMatrial
                With dgv
                    .Rows.Add()
                    .Item(0, intBaris).Value = detail.RawMaterialID
                    .Item(1, intBaris).Value = detail.RawMaterialName
                    .Item(2, intBaris).Value = detail.QuantityBPB
                    .Item(3, intBaris).Value = detail.QuantityPackaging
                    .Item(4, intBaris).Value = detail.UnitID
                    .Item(5, intBaris).Value = detail.UnitName
                    .Item(6, intBaris).Value = detail.Outstanding
                    .Item(7, intBaris).Value = detail.POHeaderID
                    .Item(8, intBaris).Value = detail.PONo
                    .Item(9, intBaris).Value = detail.PIHeaderID
                    .Item(10, intBaris).Value = detail.PINo
                    .Item(11, intBaris).Value = detail.BPBHeaderID
                    .Item(12, intBaris).Value = Format(dtBPBDate.Value, "yyyy-MM-dd")
                End With
                intBaris = intBaris + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub PreUpdateDisplay()
        Try
            ClearAll()
            ClearRawMatrial()
            ClearDataGrid()
            CheckPermissions()
            PrepareHeaderByID()
            PrepareRawMatrialByHeaderID()
            If statusBPB = 0 Then btnPrint.Enabled = False Else btnPrint.Enabled = True
            If statusBPB = 0 Or statusBPB = 2 Then btnApprove.Enabled = False
            If statusBPB = 0 Then btnVoid.Enabled = False
            btnSave.Enabled = False
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
    End Sub
    Function CheckEmptyRawMatrial() As Boolean
        Dim check As Boolean = True
        If cmbRawCode.SelectedValue = 0 Then
            MsgBoxWarning("Raw Matrial Not Valid")
            cmbRawCode.Focus()
        ElseIf txtQtyReceived.Text = "0" Then
            MsgBoxWarning("Qty Received Can't 0")
            txtQtyReceived.Focus()
        ElseIf txtQtyReceived.Text = "" Then
            MsgBoxWarning("Qty Received Can't Empty")
            txtQtyReceived.Focus()
        ElseIf Val(txtQtyPO.Text) = Val(TextBox1.Text) Then
            MsgBoxError("Qty PO Is Full In BPB ")
            txtQtyReceived.Focus()
        ElseIf Val(txtQtyReceived.Text) > Val(txtQtyPO.Text) Then
            MsgBoxError("Qty Received Greater than Qty PO ")
            txtQtyReceived.Focus()
        ElseIf Val(txtQtyReceived.Text) > restQtyBPB Then
            MsgBoxError("Qty Received Greater than the Rest Qty")
            txtQtyReceived.Focus()
        ElseIf txtQuantityPackaging.Text = "" Then
            MsgBoxWarning("Qty Packaging Can't Empty")
            txtQuantityPackaging.Focus()
        ElseIf txtQuantityPackaging.Text = "0" Then
            MsgBoxWarning("Qty Packaging Can't 0")
            txtQuantityPackaging.Focus()
        ElseIf cmbUnit.SelectedValue = 0 Then
            MsgBoxWarning("Unit For Raw Matrial Not Valid")
            cmbUnit.Focus()

        Else
            check = False
        End If
        Return check
    End Function
    Sub SumOutstanding()
        Dim subTotal As Double
        subTotal = 0
        Try
            For i As Integer = 0 To dgv.Rows.Count - 2
                If Not IsNumeric(dgv.Rows(i).Cells(9).Value) Then
                    dgv.Rows(i).Cells(9).Value = 1

                    MsgBoxError("Error  : Test")

                Else
                    dgv.Rows(i).Cells(10).Value = Val(dgv.Rows(i).Cells(8).Value) - Val(dgv.Rows(i).Cells(9).Value)
                    '  dgv.Rows(i).Cells(10).Value = dgv.Rows(i).Cells(8).Value - dgv.Rows(i).Cells(9).Value
                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub PreCreateDisplay()
        Try
            ClearAll()
            GridDetail()
            ComboBoxPO()
            ComboBoxUnit()
            CheckPermission()
            btnUpdate.Enabled = False
            btnApprove.Enabled = False
            btnVoid.Enabled = False
            btnPrint.Enabled = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub dgv_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs)
        intPost = e.Row.Index
    End Sub
#End Region

#Region "Button"
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If CheckEmptyHeader() = False Then
            If condition = "Update" Then
                UpdateData()
            End If
        End If
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If CheckEmptyHeader() = False Then
            If condition = "Create" Then
                InsertData()
            End If
        End If
    End Sub
    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        ApprovedData()
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
    Private Sub btnAddRawToList_Click(sender As Object, e As EventArgs) Handles btnAddRawToList.Click
        If CheckEmptyRawMatrial() = False Then
            Try
                If CheckRawMatrialInList() = True Then
                    AddGridDetailRawMatrial()
                    ClearRawMatrial()
                Else
                    MsgBoxError("Raw Matrial available in list")
                    ClearRawMatrial()
                End If
            Catch ex As Exception
                MsgBoxError(ex.Message)
            End Try
        End If
    End Sub
    Private Sub btnShowList_Click(sender As Object, e As EventArgs) Handles btnShowList.Click
        Try
            RetrieveSupplier()
            RetrieveQtyPO()
            ComboBoxRaw(cmbRawCode, cmbPONo.SelectedValue)
            ComboBoxPI(cmbPI, cmbPONo.SelectedValue)
        Catch ex As Exception
            MsgBoxError("Error  : " + ex.Message)
        End Try
    End Sub
#End Region

#Region "Check In BPB"
    Sub RetrieveQtyBPB()
        Dim dataTable As DataTable = New DataTable
        Dim poBFC As ClsBPB = New ClsBPB
        Dim bpbModel As BPBDetailModel = New BPBDetailModel
        Try
            Dim rawmatrialID = cmbRawCode.SelectedValue
            Dim obj As String = cmbPONo.SelectedValue
            If obj > 0 Then
                bpbModel = poBFC.RetrieveRawMaterialBPBByPO(obj, rawmatrialID)
                With bpbModel
                    TextBox1.Text = .QuantityBPB
                    restQtyBPB = Val(txtQtyPO.Text) - Val(TextBox1.Text)
                End With
                Exit Sub
            Else
                MsgBoxError("Raw already available")
            End If
            bpbModel = Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Other"
    Private Sub FrmBPB_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Select Case condition
                Case "Create"
                    PreCreateDisplay()
                Case "Update"
                    PreUpdateDisplay()
            End Select
        Catch ex As Exception
            MsgBoxError("Error : " + ex.Message)
        End Try
    End Sub
    Private Sub cmbRawCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRawCode.SelectedIndexChanged
        Try
            RetrieveQtyPO()
            RetrieveQtyBPB()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnDeletetolist_Click(sender As Object, e As EventArgs) Handles btnDeletetolist.Click
        Try
            DeleteGrid(dgv, intBaris)
        Catch ex As Exception
        End Try
    End Sub
#End Region

End Class

