﻿Public Class FrmBillOfMaterial
#Region "Declaration"
    Public conditionBOM As String
    Public Shared bomHeaderID As Long = 0
    Dim intBaris As Integer
    Dim intPost As Integer
    Dim buyerCode As String = ""
    Dim statusBOM As Int16
#End Region

#Region "ComboBox"
    Sub ComboBoxBuyer()
        Dim vendorBFC As ClsVendor = New ClsVendor
        Dim status As String = "C"
        Try
            vendorBFC.ComboBoxVendor(cmbBuyer, status)
        Catch ex As Exception
            Throw ex
        Finally
            vendorBFC = Nothing
        End Try
    End Sub
    Sub ComboBoxFabric()
        Dim fabricBFC As ClsFabric = New ClsFabric
        Try
            fabricBFC.ComboBoxFabric(cmbFabric)
        Catch ex As Exception
            Throw ex
        Finally
            fabricBFC = Nothing
        End Try
    End Sub
    Sub ComboBoxStyle()
        Dim styleBFC As ClsStyle = New ClsStyle
        Try
            styleBFC.ComboBoxStyle(cmbStyle)
        Catch ex As Exception
            Throw ex
        Finally
            styleBFC = Nothing
        End Try
    End Sub
    Sub ComboBoxColor()
        Dim colorBFC As ClsColor = New ClsColor
        Try
            colorBFC.ComboBoxColor(cmbColor)
        Catch ex As Exception
            Throw ex
        Finally
            colorBFC = Nothing
        End Try
    End Sub
    Sub ComboBoxRawMaterial()
        Dim rawBFC As ClsRawMaterial = New ClsRawMaterial
        Try
            rawBFC.ComboBoxRawMaterial(cmbRaw)
        Catch ex As Exception
            Throw ex
        Finally
            rawBFC = Nothing
        End Try
    End Sub
    Sub ComboBoxUnit()
        Dim unitBFC As ClsUnit = New ClsUnit
        Try
            unitBFC.ComboBoxUnit(cmbUnit)
        Catch ex As Exception
            Throw ex
        Finally
            unitBFC = Nothing
        End Try
    End Sub
    Sub ComboBoxStatus()
        Dim bomBFC As ClsBOM = New ClsBOM
        Try
            bomBFC.ComboBoxStatus(cmbStatus)
        Catch ex As Exception
            Throw ex
        Finally
            bomBFC = Nothing
        End Try
    End Sub
    Sub ComboBoxAll()
        Try
            ComboBoxBuyer()
            ComboBoxFabric()
            ComboBoxStyle()
            ComboBoxColor()
            ComboBoxRawMaterial()
            ComboBoxUnit()
            ComboBoxStatus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Grid Detail"
    Sub GridDetailRaw()
        Try
            With dgv
                .Columns.Add(0, "RawMaterialID")
                .Columns(0).Visible = False

                .Columns.Add(1, "Raw Material Name")
                .Columns.Add(2, "Specification")
                .Columns.Add(3, "Supplier")

                .Columns.Add(4, "UnitID")
                .Columns(4).Visible = False

                .Columns.Add(5, "UnitName")
                .Columns.Add(6, "Qty")
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Clear Data"
    Sub ClearHeader()
        txtCode.Text = AutoGenerated
        txtCompo.Clear()
        txtSpec.Clear()
        intBaris = 0
        intPost = 0
    End Sub
    Sub ClearDetail()
        txtSpecRaw.Clear()
        txtSuppRaw.Clear()
        txtQty.Text = 0
    End Sub
    Sub ClearDataAll()
        ClearHeader()
        ClearDetail()
    End Sub
#End Region

#Region "Validation Number"
    Private Sub txtQty_TextChanged(sender As Object, e As EventArgs) Handles txtQty.TextChanged
        Try
            CheckNumber(txtQty)
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
    End Sub
#End Region

#Region "Add Grid Detail"
    Sub AddGridDetail()
        Try
            With dgv
                .Rows.Add()
                .Item(0, intBaris).Value = cmbRaw.SelectedValue
                .Item(1, intBaris).Value = cmbRaw.Text
                .Item(2, intBaris).Value = txtSpecRaw.Text
                .Item(3, intBaris).Value = txtSuppRaw.Text
                .Item(4, intBaris).Value = cmbUnit.SelectedValue
                .Item(5, intBaris).Value = cmbUnit.Text
                .Item(6, intBaris).Value = txtQty.Text
            End With
            intBaris = intBaris + 1
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Delete Grid"

#End Region

#Region "Check Empty"
    Function CheckEmptyHeader() As Boolean
        Dim check As Boolean = True
        If cmbFabric.SelectedValue = 0 Then
            MsgBoxWarning("Fabric not valid")
            cmbFabric.Focus()
        ElseIf cmbBuyer.SelectedValue = 0 Then
            MsgBoxWarning("Buyer not valid")
            cmbBuyer.Focus()
        ElseIf cmbStyle.SelectedValue = 0 Then
            MsgBoxWarning("Style not valid")
            cmbStyle.Focus()
        ElseIf cmbColor.SelectedValue = 0 Then
            MsgBoxWarning("Color not valid")
            cmbColor.Focus()
        ElseIf cmbStatus.Text = "" Then
            MsgBoxWarning("Status can't empty")
            cmbStatus.Focus()
        ElseIf dgv.Rows.Count - 1 = 0 Then
            MsgBoxWarning("Detail can't empty")
            cmbRaw.Focus()
        Else
            check = False
        End If
        Return check
    End Function
    Function CheckEmptyDetail() As Boolean
        Dim check As Boolean = True
        If cmbRaw.SelectedValue = 0 Then
            MsgBoxWarning("Raw Material not valid")
            cmbRaw.Focus()
        ElseIf cmbUnit.SelectedValue = 0 Then
            MsgBoxWarning("UOM not valid")
            cmbUnit.Focus()
        ElseIf txtQty.Text = 0 Then
            MsgBoxWarning("Qty can't 0")
            txtQty.Focus()
        ElseIf Trim(txtQty.Text) = "" Then
            MsgBoxWarning("Qty can't 0")
            txtQty.Focus()
        Else
            check = False
        End If
        Return check
    End Function
#End Region

#Region "Check Available In List"
    Function CheckDetailInList() As Boolean
        Dim bomBFC As ClsBOM = New ClsBOM
        Dim status As Boolean
        Try
            status = bomBFC.CheckDetailInList(dgv, cmbRaw.SelectedValue)
            Return status
        Catch ex As Exception
            Throw ex
        Finally
            bomBFC = Nothing
        End Try
    End Function
#End Region

#Region "Set Data"
    Function SetDataHeader() As BOMHeaderModel
        Dim headerModel As BOMHeaderModel = New BOMHeaderModel
        Dim bomBFC As ClsBOM = New ClsBOM

        Dim status As Int16
        If cmbStatus.Text = "Production" Then
            status = 1
        ElseIf cmbStatus.Text = "Development" Then
            status = 2
        Else
            status = 0
        End If

        Try
            With headerModel
                Select Case conditionBOM
                    Case "Create"
                        .BOMHeaderID = bomBFC.GetBOMHeaderID
                        .BOMCode = bomBFC.GetBOMCode(buyerCode)
                        .FabricID = cmbFabric.SelectedValue
                        .BuyerID = cmbBuyer.SelectedValue
                        .StyleID = cmbStyle.SelectedValue
                        .ColorID = cmbColor.SelectedValue
                        .StatusBOM = status
                        .IsActive = 1
                        .CreatedBy = userID
                        .CreatedDate = DateTime.Now
                        .UpdatedBy = userID
                        .UpdatedDate = DateTime.Now
                    Case "Update"
                        .BOMHeaderID = bomHeaderID
                        .BOMCode = txtCode.Text
                        .FabricID = cmbFabric.SelectedValue
                        .BuyerID = cmbBuyer.SelectedValue
                        .StyleID = cmbStyle.SelectedValue
                        .ColorID = cmbColor.SelectedValue
                        .StatusBOM = status
                        .IsActive = 1
                        .UpdatedBy = userID
                        .UpdatedDate = DateTime.Now
                End Select
            End With
            Return headerModel
        Catch ex As Exception
            Throw ex
        Finally
            bomBFC = Nothing
        End Try
    End Function

    Function SetDetail(bomID As Long) As List(Of BOMDetailModel)
        Dim bomBFC As ClsBOM = New ClsBOM
        Dim listModel As List(Of BOMDetailModel) = New List(Of BOMDetailModel)
        Try
            listModel = bomBFC.SetDetail(bomID, dgv)
            Return listModel
        Catch ex As Exception
            Throw ex
        Finally
            bomBFC = Nothing
        End Try
    End Function
#End Region

#Region "Function"
    Sub RetrieveBuyer()
        Dim vendorBFC As ClsVendor = New ClsVendor
        Dim vendorModel As VendorModel = New VendorModel
        Dim obj As Integer = cmbBuyer.SelectedValue
        Try
            If obj > 0 Then
                vendorModel = vendorBFC.RetrieveVendorByID(obj, "C")
                With vendorModel
                    buyerCode = .VendorCode
                End With
            Else
                MsgBoxError("Buyer not valid")
            End If
        Catch ex As Exception
            Throw ex
        Finally
            vendorBFC = Nothing
            vendorModel = Nothing
            obj = Nothing
        End Try
    End Sub
    Sub RetrieveFabric()
        Dim fabricBFC As ClsFabric = New ClsFabric
        Dim fabricModel As FabricModel = New FabricModel
        Dim fabricID As Integer = cmbFabric.SelectedValue
        Try
            If fabricID > 0 Then
                fabricModel = fabricBFC.RetrieveByID(fabricID)
                With fabricModel
                    txtSpec.Text = fabricModel.Specification
                    txtCompo.Text = fabricModel.Composition
                End With
            Else
                MsgBoxError("Fabric Not Valid")
            End If
        Catch ex As Exception
            Throw ex
        Finally
            fabricBFC = Nothing
            fabricModel = Nothing
            fabricID = Nothing
        End Try
    End Sub
    Sub RetrieveRawMaterial()
        Dim rawBFC As ClsRawMaterial = New ClsRawMaterial
        Dim rawModel As RawMaterialModel = New RawMaterialModel
        Dim rawMaterialID As Integer = cmbRaw.SelectedValue
        Try
            If rawMaterialID > 0 Then
                rawModel = rawBFC.RetrieveByID(rawMaterialID)
                With rawModel
                    txtSpecRaw.Text = rawModel.SpecRawMaterial
                    txtSuppRaw.Text = rawModel.VendorName
                End With
            Else
                MsgBoxError("Raw Material Not Valid")
            End If
        Catch ex As Exception
            Throw ex
        Finally
            rawBFC = Nothing
            rawModel = Nothing
            rawMaterialID = Nothing
        End Try
    End Sub
    Sub PrepareByHeaderID()
        Dim headerModel As BOMHeaderModel = New BOMHeaderModel
        Dim bomBFC As ClsBOM = New ClsBOM
        Try
            ComboBoxAll()
            headerModel = bomBFC.RetrieveByID(bomHeaderID)
            With headerModel
                txtCode.Text = .BOMCode
                cmbFabric.SelectedValue = .FabricID
                txtCompo.Text = .Composition
                txtSpec.Text = .Specification
                cmbBuyer.SelectedValue = .BuyerID
                cmbStyle.SelectedValue = .StyleID
                cmbColor.SelectedValue = .ColorID
                If .StatusBOM = 1 Then
                    cmbStatus.Text = "Production"
                ElseIf .StatusBOM = 2 Then
                    cmbStatus.Text = "Development"
                Else
                    cmbStatus.Text = ""
                End If
            End With
        Catch ex As Exception
            Throw ex
        Finally
            headerModel = Nothing
            bomBFC = Nothing
        End Try
    End Sub
    Sub PrepareDetailByHeaderID()
        Dim listDetail As List(Of BOMDetailModel) = New List(Of BOMDetailModel)
        Dim bomBFC As ClsBOM = New ClsBOM
        Try
            GridDetailRaw()
            listDetail = bomBFC.RetrieveDetailByHeaderID(bomHeaderID)
            For Each detail In listDetail
                With dgv
                    .Rows.Add()
                    .Item(0, intBaris).Value = detail.RawMaterialID
                    .Item(1, intBaris).Value = detail.RawMaterialName
                    .Item(2, intBaris).Value = detail.SpecRawMaterial
                    .Item(3, intBaris).Value = detail.VendorName
                    .Item(4, intBaris).Value = detail.UnitID
                    .Item(5, intBaris).Value = detail.UnitName
                    .Item(6, intBaris).Value = detail.Qty
                End With
                intBaris = intBaris + 1
            Next
        Catch ex As Exception
            Throw ex
        Finally
            listDetail = Nothing
            bomBFC = Nothing
        End Try
    End Sub
    Sub PreCreateDisplay()
        Try
            CheckPermissions()
            ClearDataAll()
            dgv.Columns.Clear()
            GridDetailRaw()
            ComboBoxAll()
            cmbFabric.Focus()
            btnUpdate.Enabled = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub PreUpdateDisplay()
        Try
            CheckPermissions()
            ClearDataAll()
            dgv.Columns.Clear()
            PrepareByHeaderID()
            PrepareDetailByHeaderID()
            cmbFabric.Focus()
            btnSave.Enabled = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub CheckPermissions()
        Dim roleBFC As ClsPermission = New ClsPermission
        Dim roleModel As RoleDModel = New RoleDModel
        Try
            roleModel = roleBFC.RetrieveDetailsByRoleIDMenuID(roleIDUser, Tag)
            If roleModel.IsCreate = True Then btnSave.Enabled = True
            If roleModel.IsUpdate = True Then btnUpdate.Enabled = True
        Catch ex As Exception
            Throw ex
        Finally
            roleBFC = Nothing
            roleModel = Nothing
        End Try
    End Sub

    Sub InsertData()
        Dim bomBFC As ClsBOM = New ClsBOM
        Dim logBFC As ClsLogHistory = New ClsLogHistory
        Dim myBomCode As String = bomBFC.GetBOMCode(buyerCode)
        Dim myBomID As Long = bomBFC.GetBOMHeaderID
        Dim logDesc As String = "Create new Bill Of Material,BOM Code is " + myBomCode

        Try
            If bomBFC.InsertData(SetDataHeader, SetDetail(myBomID), logBFC.SetLogHistoryTrans(logDesc)) = True Then
                MsgBoxSaved()
                CheckPermissions()
                PreCreatedisplay()
            End If
        Catch ex As Exception
            Throw ex
        Finally
            bomBFC = Nothing
            logBFC = Nothing
            myBomCode = Nothing
            myBomID = Nothing
            logDesc = Nothing
        End Try
    End Sub

    Sub UpdateData()
        Dim bomBFC As ClsBOM = New ClsBOM
        Dim logBFC As ClsLogHistory = New ClsLogHistory
        Dim logDesc As String = "Update Bill Of Material,Where BOM Code = " + txtCode.Text
        Try
            If bomBFC.UpdateData(SetDataHeader, SetDetail(bomHeaderID), logBFC.SetLogHistoryTrans(logDesc)) = True Then
                MsgBoxUpdated()
                CheckPermissions()
                PreCreateDisplay()
            End If
        Catch ex As Exception
            Throw ex
        Finally
            bomBFC = Nothing
            logBFC = Nothing
            logDesc = Nothing
        End Try
    End Sub

    Private Sub FrmBillOfMaterial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Select Case conditionBOM
                Case "Create"
                    PreCreateDisplay()
                Case "Update"
                    PreUpdateDisplay()
            End Select
            Text = title
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
    End Sub
#End Region

#Region "Button"
    Private Sub btnAddList_Click(sender As Object, e As EventArgs) Handles btnAddList.Click
        If CheckEmptyDetail() = False Then
            Try
                If CheckDetailInList() = True Then
                    AddGridDetail()
                Else
                    MsgBoxError("Raw Material Available in list")
                End If
                ClearDetail()
            Catch ex As Exception
                MsgBoxError(ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnDelList_Click(sender As Object, e As EventArgs) Handles btnDelList.Click
        Try
            DeleteGrid(dgv)
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
        intBaris = intBaris - 1
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If CheckEmptyHeader() = False Then
            If conditionBOM = "Create" Then
                Try
                    InsertData()
                Catch ex As Exception
                    MsgBoxError(ex.Message)
                End Try
            End If
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If CheckEmptyHeader() = False Then
            If conditionBOM = "Update" Then
                Try
                    UpdateData()
                Catch ex As Exception
                    MsgBoxError(ex.Message)
                End Try
            End If
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
#End Region

#Region "KeyPress"

#End Region

#Region "Row State Change"
    Private Sub dgv_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgv.RowStateChanged
        intPost = e.Row.Index
    End Sub
#End Region
#Region "Other"
    Private Sub cmbFabric_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFabric.SelectedIndexChanged
        cmbBuyer.Focus()
    End Sub
    Private Sub cmbFabric_Validated(sender As Object, e As EventArgs) Handles cmbFabric.Validated
        Try
            RetrieveFabric()
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
    End Sub

    Private Sub cmbBuyer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBuyer.SelectedIndexChanged
        cmbStyle.Focus()
    End Sub
    Private Sub cmbStyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStyle.SelectedIndexChanged
        cmbColor.Focus()
    End Sub
    Private Sub cmbColor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbColor.SelectedIndexChanged
        cmbStatus.Focus()
    End Sub
    Private Sub cmbStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStatus.SelectedIndexChanged
        cmbRaw.Focus()
    End Sub

    Private Sub cmbRaw_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRaw.SelectedIndexChanged
        cmbUnit.Focus()
    End Sub

    Private Sub cmbRaw_Validated(sender As Object, e As EventArgs) Handles cmbRaw.Validated
        Try
            RetrieveRawMaterial()
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
    End Sub

    Private Sub cmbUnit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUnit.SelectedIndexChanged
        txtQty.Focus()
    End Sub

    Private Sub txtQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQty.KeyPress
        If e.KeyChar = Chr(13) Then
            btnAddList.Focus()
        End If
    End Sub

    Private Sub cmbBuyer_Validated(sender As Object, e As EventArgs) Handles cmbBuyer.Validated
        Try
            RetrieveBuyer()
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
    End Sub
#End Region
End Class