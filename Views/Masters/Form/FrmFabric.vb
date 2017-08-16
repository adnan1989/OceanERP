﻿Public Class FrmFabric
#Region "Declaration"
    Dim fabricID As Integer = 0
    Dim display As String = ""
    Dim isCreate As Boolean = False
    Dim isUpdate As Boolean = False
    Dim isDelete As Boolean = False
    Dim fabricName As String = ""
#End Region

#Region "Function"
    Sub ClearText()
        txtCode.Text = AutoGenerated
        txtName.Clear()
        txtCompo.Clear()
        txtSpec.Clear()
        cmbSupp.Text = ""
        cmbCari.Text = ""
        txtCari.Clear()
        fabricName = ""
    End Sub
    Sub PropertiesGrid()
        With dgv
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "Fabric Code"
            .Columns(1).Width = 100
            .Columns(2).HeaderText = "Fabric Name"
            .Columns(2).Width = 200
            .Columns(3).HeaderText = "Composition"
            .Columns(3).Width = 150

            .Columns(4).HeaderText = "Specification"
            .Columns(4).Width = 150

            .Columns(5).HeaderText = "Supplier"
            .Columns(5).Width = 150

            .Columns(6).Visible = False
            .Columns(7).Visible = False
        End With
    End Sub
    Sub ListFabric(myOptions As String, myParam As String)
        Try
            Dim fabricBFC As ClsFabric = New ClsFabric
            With dgv
                .DataSource = fabricBFC.RetrieveList(myOptions, myParam)
                .ReadOnly = True
            End With
            PropertiesGrid()
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
    End Sub
    Sub ComboBoxSupplier()
        Dim vendorBFC As ClsVendor = New ClsVendor
        Dim statusVendor As Char = "S"
        vendorBFC.ComboBoxVendor(cmbSupp, statusVendor)
    End Sub
    Sub EnabledText(status As Boolean)
        txtName.Enabled = status
        txtCompo.Enabled = status
        txtSpec.Enabled = status
        cmbSupp.Enabled = status
    End Sub
    Sub CheckPermissions()
        Dim roleBFC As ClsPermission = New ClsPermission
        Dim roleModel As RoleDModel = New RoleDModel
        roleModel = roleBFC.RetrieveDetailsByRoleIDMenuID(roleIDUser, Tag)
        If roleModel.IsCreate = True Then isCreate = True
        If roleModel.IsUpdate = True Then isUpdate = True
        If roleModel.IsDelete = True Then isDelete = True
    End Sub
    Sub ButtonAdd()
        If isCreate = True Then btnAdd.Enabled = True
        btnSave.Enabled = False
        btnDelete.Enabled = False
        btnCancel.Enabled = False
    End Sub
    Sub ButtonSave()
        btnAdd.Enabled = False
        btnSave.Enabled = True
        btnDelete.Enabled = False
        btnCancel.Enabled = True
    End Sub
    Sub ButtonUpdate()
        btnAdd.Enabled = False
        If isUpdate = True Then btnSave.Enabled = True
        If isDelete = True Then btnDelete.Enabled = True
        btnCancel.Enabled = True
    End Sub
    Sub PreCreateDisplay()
        CheckPermissions()
        ClearText()
        ListFabric(cmbCari.Text, txtCari.Text)
        EnabledText(False)
        ButtonAdd()
        display = ""
        btnAdd.Focus()
        Text = title
    End Sub
    Function CheckEmpty() As Boolean
        Dim check As Boolean = True
        If Trim(txtName.Text) = String.Empty Then
            MsgBoxWarning("Name can't empty")
            txtName.Focus()
        ElseIf Trim(txtCompo.Text) = String.Empty Then
            MsgBoxWarning("Composition can't empty")
            txtCompo.Focus()
        ElseIf Trim(txtSpec.Text) = String.Empty Then
            MsgBoxWarning("Specification can't empty")
            txtSpec.Focus()
        ElseIf cmbSupp.SelectedValue = 0 Then
            MsgBoxError("Supplier not valid")
            cmbSupp.Focus()
        Else
            check = False
        End If
        Return check
    End Function
    Function SetModel() As FabricModel
        Dim fabricModel As FabricModel = New FabricModel
        Dim fabricBFC As ClsFabric = New ClsFabric
        Select Case display
            Case "Create"
                With fabricModel
                    .FabricID = fabricBFC.GeneratedAutoNumber
                    .FabricCode = fabricBFC.GeneratedCode
                    .FabricName = txtName.Text
                    .Composition = txtCompo.Text
                    .Specification = txtSpec.Text
                    .VendorID = cmbSupp.SelectedValue
                    .IsActive = True
                    .CreatedBy = userID
                    .CreatedDate = DateTime.Now
                    .UpdatedBy = userID
                    .UpdatedDate = DateTime.Now
                End With
            Case "Update"
                With fabricModel
                    .FabricID = fabricID
                    .FabricName = txtName.Text
                    .Composition = txtCompo.Text
                    .Specification = txtSpec.Text
                    .VendorID = cmbSupp.SelectedValue
                    .IsActive = True
                    .UpdatedBy = userID
                    .UpdatedDate = DateTime.Now
                End With
            Case Else
                With fabricModel
                    .FabricID = fabricID
                    .IsActive = False
                    .UpdatedBy = userID
                    .UpdatedDate = DateTime.Now
                End With
        End Select
        Return fabricModel
    End Function
    Sub InsertFabric()
        Dim fabricBFC As ClsFabric = New ClsFabric
        Dim logBFC As ClsLogHistory = New ClsLogHistory
        Dim logDesc As String = "Create new Fabric,Fabric name is " + txtName.Text
        Try
            If fabricBFC.GetValidateName(txtName.Text) = True Then
                If fabricBFC.InsertFabric(SetModel, logBFC.SetLogHistory(logDesc)) = True Then
                    MsgBoxSaved()
                    PreCreateDisplay()
                End If
            End If
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
    End Sub
    Sub UpdateFabric()
        Dim fabricBFC As ClsFabric = New ClsFabric
        Dim logBFC As ClsLogHistory = New ClsLogHistory
        Dim logDesc As String = "Update Fabric for FabricCode = " + txtCode.Text
        Try
            If txtName.Text = fabricName Then
                If fabricBFC.UpdateFabric(SetModel, logBFC.SetLogHistory(logDesc), display) = True Then
                    MsgBoxUpdated()
                    PreCreateDisplay()
                End If
            ElseIf txtName.Text <> fabricName Then
                If fabricBFC.GetValidateName(txtName.Text) = True Then
                    If fabricBFC.UpdateFabric(SetModel, logBFC.SetLogHistory(logDesc), display) = True Then
                        MsgBoxUpdated()
                        PreCreateDisplay()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
    End Sub
    Sub DeleteFabric()
        Dim fabricBFC As ClsFabric = New ClsFabric
        Dim logBFC As ClsLogHistory = New ClsLogHistory
        Dim logDesc As String = "Update Fabric for FabricCode = " + txtCode.Text + ",update IsActive = False"
        display = "Delete"
        Try
            If fabricBFC.UpdateFabric(SetModel, logBFC.SetLogHistory(logDesc), display) = True Then
                MsgBoxDeleted()
                PreCreateDisplay()
            End If
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
    End Sub
#End Region

#Region "Button"
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        EnabledText(True)
        display = "Create"
        ComboBoxSupplier()
        ButtonSave()
        txtName.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If CheckEmpty() = False Then
            Try
                Select Case display
                    Case "Create"
                        InsertFabric()
                    Case "Update"
                        UpdateFabric()
                End Select
            Catch ex As Exception
                MsgBoxError(ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If MsgBoxQuestion() = DialogResult.Yes Then
            Try
                DeleteFabric()
            Catch ex As Exception
                MsgBoxError(ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        PreCreateDisplay()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
#End Region

#Region "Other"
    Private Sub txtName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtName.KeyPress
        If e.KeyChar = Chr(13) Then
            txtCompo.Focus()
        End If
    End Sub
    Private Sub txtCompo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCompo.KeyPress
        If e.KeyChar = Chr(13) Then
            txtSpec.Focus()
        End If
    End Sub

    Private Sub txtSpec_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSpec.KeyPress
        If e.KeyChar = Chr(13) Then
            cmbSupp.Focus()
        End If
    End Sub

    Private Sub cmbCari_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCari.SelectedIndexChanged
        txtCari.Focus()
    End Sub

    Private Sub cmbCari_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbCari.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
        ListFabric(cmbCari.Text, txtCari.Text)
    End Sub
    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        ComboBoxSupplier()
        With dgv
            Dim row As Integer = .CurrentRow.Index
            fabricID = .Item(0, row).Value
            txtCode.Text = .Item(1, row).Value
            txtName.Text = .Item(2, row).Value
            fabricName = .Item(2, row).Value
            txtCompo.Text = .Item(3, row).Value
            txtSpec.Text = .Item(4, row).Value
            cmbSupp.SelectedValue = .Item(6, row).Value
        End With

        display = "Update"

        ButtonUpdate()
        EnabledText(True)
    End Sub
    Private Sub FrmFabric_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PreCreateDisplay()
    End Sub
#End Region
End Class